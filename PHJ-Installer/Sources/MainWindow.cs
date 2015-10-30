using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using Ionic.Zip;
using System.Runtime.InteropServices;

namespace PHJ
{
    public partial class PHJ : Form
    {
        Stopwatch sw = new Stopwatch();

        private bool allowClose = true;
        private bool installSucc = false;
        private bool serviceStarted = false;

        static string dnPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Downloads";
        static string exPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Downloads\Extracted";
        static string rootPath = Path.GetPathRoot(Environment.SystemDirectory);

        // Download apachex64
        static string apachex64Url = "http://ddi.altervista.org/x64/Apache24.zip";
        static string apachex64FileName = @"\Apache24.zip";
        static string apachex64Path = dnPath + apachex64FileName;

        // Download apachex86
        static string apachex86Url = "http://ddi.altervista.org/x86/Apache24.zip";
        static string apachex86FileName = @"\Apache24.zip";
        static string apachex86Path = dnPath + apachex86FileName;

        // Download PHJ
        static string phjUrl = "https://github.com/tncrazvan/phj/archive/master.zip";
        static string phjFileName = @"\phj-master.zip";
        static string phjPath = dnPath + phjFileName;

        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }

        public PHJ()
        {
            InitializeComponent();
            instProgress.Value = 0;
            instDetails.Text = "Ready";
            dnSpeed.Text = "- kB/s";
            dnPerc.Text = "- %";
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void phjInstall_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(rootPath + @"\Apache24") && !IsDirectoryEmpty(rootPath + @"\Apache24\htdocs"))
            {
                installSucc = true;
                if (!IsServiceAlive())
                {
                    startInstall.Text = "Start Service";
                    instDetails.Text = "Service not started";
                    startInstall.BackColor = Color.DodgerBlue;
                    startInstall.Enabled = true;
                    allowClose = true;
                    instDetails.Text = "PHJ Found";
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
                    linkLocalhost.Visible = false;
                }
                else
                {
                    startInstall.Text = "Stop Service";
                    instDetails.Text = "Service started";
                    startInstall.BackColor = Color.Red;
                    startInstall.Enabled = true;
                    allowClose = true;
                    serviceStarted = true;
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
                    linkLocalhost.Visible = true;
                }
            }
        }

        private void StartInstall_Click(object sender, EventArgs e)
        {
            if (installSucc == false)
            {
                if (!InstallApache24Async.IsBusy)
                {
                    InstallApache24Async.RunWorkerAsync();
                }
            }
            else
            {
                if (IsServiceAlive())
                {
                    instDetails.Text = "Service started";
                    startInstall.Enabled = true;
                    startInstall.BackColor = Color.Red;
                    startInstall.Text = "Stop Service";
                    allowClose = true;
                    linkLocalhost.Visible = true;

                    if (IsProcessOpen("httpd") == true)
                    {
                        foreach (var apacheServ in Process.GetProcessesByName("httpd"))
                        {
                            apacheServ.Kill();
                        }
                    }
                    if (IsProcessOpen("mysqld") == true)
                    {
                        foreach (var mysqlServ in Process.GetProcessesByName("mysqld"))
                        {
                            mysqlServ.Kill();
                        }
                    }
                    instDetails.Text = "Service stopped";
                    startInstall.Enabled = true;
                    startInstall.BackColor = Color.DodgerBlue;
                    startInstall.Text = "Start Service";
                    allowClose = true;
                    linkLocalhost.Visible = false;
                }
                else
                {
                    instDetails.Text = "Service not started";
                    startInstall.Enabled = true;
                    startInstall.BackColor = Color.DodgerBlue;
                    startInstall.Text = "Start Service";
                    allowClose = true;
                    serviceStarted = false;
                    linkLocalhost.Visible = false;
                }

                if (InstallApache24Async.IsBusy)
                {
                    InstallApache24Async.CancelAsync();
                }

                if (serviceStarted == false)
                {
                    Process.Start(rootPath + @"Apache24\bin\httpd.exe");
                    Process.Start(rootPath + @"Apache24\mysql\bin\mysqld.exe");
                    serviceStarted = true;
                    instDetails.Text = "Service started";
                    startInstall.Enabled = true;
                    startInstall.BackColor = Color.Red;
                    startInstall.Text = "Stop Service";
                    allowClose = true;
                    linkLocalhost.Visible = true;
                }
            }
        }

        private void InstallApache24Async_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (InternalCheckIsWow64() == true)
                {
                    if (!Directory.Exists(rootPath + @"Apache24"))
                    {
                        DownloadSelected("Apache24", apachex64Url, apachex64Path, InstallApache24Async);
                    }
                }
                else
                {
                    if (!Directory.Exists(rootPath + @"Apache24"))
                    {
                        DownloadSelected("Apache24", apachex86Url, apachex86Path, InstallApache24Async);
                    }
                }
            }
            catch (Exception ex)
            {
                if (InstallApache24Async.IsBusy)
                {
                    InstallApache24Async.CancelAsync();
                }
                InstallationFailed(ex);
            }
        }

        private void InstallApache24Async_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            instProgress.Value = e.ProgressPercentage;
            dnPerc.Text = e.ProgressPercentage + "%";
        }

        private void InstallApache24Async_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Directory.Exists(exPath))
            {
                Directory.CreateDirectory(exPath);
            }

            ExtractorApache24Async.RunWorkerAsync();
        }

        private void ExtractorApache24Async_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Directory.Exists(exPath) && !Directory.Exists(exPath + @"\Apache24"))
                {
                    if (File.Exists(apachex64Path) || File.Exists(apachex86Path))
                    {
                        if (InternalCheckIsWow64() == true)
                        {
                            ExtractZipFile(apachex64Path, exPath);
                        }
                        else
                        {
                            ExtractZipFile(apachex86Path, exPath);
                        }
                        CopyFolder("Apache24");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ExtractorApache24Async.IsBusy)
                {
                    ExtractorApache24Async.CancelAsync();
                }
                InstallationFailed(ex);
            }
        }

        private void ExtractorApache24Async_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void ExtractorApache24Async_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ExtractorApache24Async.IsBusy)
            {
                ExtractorApache24Async.CancelAsync();
            }
            if (!File.Exists(phjPath) && IsDirectoryEmpty(rootPath + @"\Apache24\htdocs"))
            {
                InstallPHJAsync.RunWorkerAsync();
            }
            else if(File.Exists(phjPath) && IsDirectoryEmpty(rootPath + @"\Apache24\htdocs"))
            {
                ExtractorPHJAsync.RunWorkerAsync();
            }
        }

        private void InstallPHJAsync_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (InstallApache24Async.IsBusy)
                {
                    InstallApache24Async.CancelAsync();
                }

                if ((File.Exists(apachex64Path) || File.Exists(apachex86Path)) && !File.Exists(phjPath))
                {
                    DownloadSelected("phj-master", phjUrl, phjPath, InstallPHJAsync);
                }
            }
            catch (Exception ex)
            {
                if (InstallPHJAsync.IsBusy)
                {
                    InstallPHJAsync.CancelAsync();
                }
                InstallationFailed(ex);
            }
        }

        private void InstallPHJAsync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            instProgress.Value = e.ProgressPercentage;
            dnPerc.Text = e.ProgressPercentage + "%";
        }

        private void InstallPHJAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(exPath))
                {
                    Directory.CreateDirectory(exPath);
                }

                if (Directory.Exists(exPath) && !Directory.Exists(exPath + @"\phj-master") && File.Exists(phjPath))
                {
                    ExtractorPHJAsync.RunWorkerAsync();
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //InstallationFailed(ex);
            }
        }

        private void ExtractorPHJAsync_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists(phjPath))
                {
                    if (!Directory.Exists(exPath + @"\phj-master"))
                    {
                        ExtractZipFile(phjPath, exPath);
                    }
                    CopyPHJContent("phj-master");
                    installSucc = true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                if (ExtractorPHJAsync.IsBusy)
                {
                    ExtractorPHJAsync.CancelAsync();
                }
                InstallationFailed(ex);
            }
        }

        private void ExtractorPHJAsync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void ExtractorPHJAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (installSucc == true)
                {
                    instProgress.Value = instProgress.Maximum;
                    dnPerc.Text = "100%";
                    startInstall.Text = "Start Service";
                    startInstall.BackColor = Color.DodgerBlue;
                    startInstall.Enabled = true;
                    allowClose = true;
                    instDetails.Text = "Installation Complete";
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
                    /*DialogResult bracketsInstall = MessageBox.Show("Do you want to install Brackets IDE?", "Install Brackets?", MessageBoxButtons.YesNo);
                    if (bracketsInstall == DialogResult.Yes)
                    {
                        Process.Start("http://brackets.io/");
                    }*/
                }
            }
            catch (Exception ex)
            {
                if (ExtractorPHJAsync.IsBusy)
                {
                    ExtractorPHJAsync.CancelAsync();
                }
                InstallationFailed(ex);
            }
        }

        private void DownloadSelected(string software, string Url, string Path, BackgroundWorker worker)
        {
            try
            {
                FileInfo phjFileInfo;
                startInstall.Text = "Preparing";
                startInstall.Enabled = false;
                allowClose = false;
                tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                instProgress.Value = 0;

                if (!Directory.Exists(dnPath))
                {
                    Directory.CreateDirectory(dnPath);
                }
                
                if (File.Exists(Path) && !IsDirectoryEmpty(rootPath + @"\Apache24\htdocs\"))
                {
                    phjFileInfo = new FileInfo(Path);

                    if (phjFileInfo.Length > 0)
                    {
                        instDetails.Text = software + " found";
                    }
                }
                else
                {
                    File.Delete(Path);
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    instDetails.Text = "Downloading " + software;
                    startInstall.Text = "Downloading";
                    StartWorkerDownload(Url, Path, worker);
                }

                if (Directory.Exists(rootPath + @software))
                {
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    instDetails.Text = "Installing " + software;
                    CopyFolder(software);

                    if (software == "phj-master")
                    {
                        CopyPHJContent(software);
                    }
                }
                else if (Directory.Exists(exPath + @"\" + software) && !Directory.Exists(rootPath + @software))
                {
                    Directory.CreateDirectory(rootPath + @software);
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    instDetails.Text = "Installing " + software;
                    CopyFolder(software);

                    if (software == "phj-master")
                    {
                        CopyPHJContent(software);
                    }
                }
            }
            catch (Exception ex)
            {
                //InstallationFailed(ex);
            }
        }

        private void StartWorkerDownload(string downUrl, string destination, BackgroundWorker worker)
        {
            // first, we need to get the exact size (in bytes) of the file we are downloading
            Uri url = new Uri(downUrl);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            // gets the size of the file in bytes
            Int64 iSize = response.ContentLength;

            // keeps track of the total bytes downloaded so we can update the progress bar
            Int64 iRunningByteTotal = 0;

            // use the webclient object to download the file
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                // open the file at the remote URL for reading
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(downUrl)))
                {
                    // using the FileStream object, we can write the downloaded bytes to the file system
                    using (Stream streamLocal = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // loop the stream and get the file into the byte buffer
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            // write the bytes to the file system at the file path specified
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            // calculate the progress out of a base "100"
                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);
                            sw.Start();
                            dnSpeed.Text = string.Format("{0} kB/s", (iRunningByteTotal / 1024d / sw.Elapsed.TotalSeconds).ToString("0"));

                            // update the progress bar
                            worker.ReportProgress(iProgressPercentage);
                        }

                        // clean up the file stream
                        streamLocal.Close();
                    }

                    // close the connection to the remote server
                    streamRemote.Close();
                }
            }
        }

        private void ExtractZipFile(string zipFileLocation, string destination)
        {
            try
            {
                using (ZipFile zip = new ZipFile(zipFileLocation))
                {
                    instDetails.Text = "Extracting";
                    startInstall.Enabled = false;
                    allowClose = false;
                    dnSpeed.Text = "- kB/s";
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    zip.ExtractProgress += ExtractProgressChanged;
                    zip.ExtractAll(destination);
                }
            }
            catch (Exception ex)
            {
                InstallationFailed(ex);
            }
        }

        public void ExtractProgressChanged(object sender, ExtractProgressEventArgs e)
        {
            try
            {
                if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractAll)
                {
                    startInstall.Text = "Extracting";
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                }
                else if (e.EventType == ZipProgressEventType.Extracting_AfterExtractAll)
                {
                    tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
                    startInstall.Text = "Completed";
                    allowClose = true;
                }

                if (e.EntriesExtracted != 0)
                {
                    instDetails.Text = "Extracting: " + (e.EntriesExtracted) + "/" + e.EntriesTotal;
                    instProgress.Maximum = e.EntriesTotal;
                    instProgress.Value = e.EntriesExtracted;
                    int perc = (int)((e.EntriesExtracted * 100) / e.EntriesTotal);
                    dnPerc.Text = perc.ToString() + "%";
                }
            }
            catch (Exception ex)
            {
                //instDetails.Text = ex.Message;
            }
        }

        private void CopyFolder(string relFolder)
        {
            startInstall.Text = "Installing";
            tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            DirectoryInfo exInfo = new DirectoryInfo(exPath + @"\" + relFolder);
            DirectoryInfo rootInfo = new DirectoryInfo(rootPath + @relFolder);
            CopyDir.CopyAll(exInfo, rootInfo);
            startInstall.Text = "Completed";
            dnSpeed.Text = "- kB/s";
            startInstall.Enabled = true;
            allowClose = true;
            instDetails.Text = "Installation Complete";
        }

        private void CopyPHJContent(string phjFolder)
        {
            try
            {
                startInstall.Text = "Installing";
                startInstall.Enabled = false;
                allowClose = false;
                dnSpeed.Text = "- kB/s";
                tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                DirectoryInfo htdocsInfo;
                DirectoryInfo phjInfo;
                htdocsInfo = new DirectoryInfo(rootPath + @"Apache24\htdocs\");
                phjInfo = new DirectoryInfo(exPath + @"\" + phjFolder);
                CopyDir.CopyAll(phjInfo, htdocsInfo);
                installSucc = true;

                instProgress.Value = instProgress.Maximum;
                dnPerc.Text = "100%";
                startInstall.Text = "Start Service";
                startInstall.BackColor = Color.DodgerBlue;
                startInstall.Enabled = true;
                allowClose = true;
                instDetails.Text = "Installation Complete";
                tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                InstallationFailed(ex);
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //instProgress.Value = e.ProgressPercentage;
            instDetails.Text = "Downloading Apache";
            //dnPerc.Text = e.ProgressPercentage + "%";
            dnSpeed.Text = string.Format("{0} kB/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0"));
        }

        private void phjInstall_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (allowClose == false)
                {
                    e.Cancel = true;

                    DialogResult quitYesno = MessageBox.Show("Installation in progress. \n\n Quit installation?", "Warning!", MessageBoxButtons.YesNo);

                    if (quitYesno == DialogResult.Yes)
                    {
                        e.Cancel = false;
                        allowClose = true;

                        if (InstallApache24Async.IsBusy)
                        {
                            InstallApache24Async.CancelAsync();
                        }
                        if (InstallPHJAsync.IsBusy)
                        {
                            InstallPHJAsync.CancelAsync();
                        }
                        if (ExtractorApache24Async.IsBusy)
                        {
                            ExtractorApache24Async.CancelAsync();
                        }
                        if (ExtractorPHJAsync.IsBusy)
                        {
                            ExtractorPHJAsync.CancelAsync();
                        }

                        this.Close();
                    }
                    else if (quitYesno == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch (Exception ex)
            {
                /*e.Cancel = true;
                MessageBox.Show(ex.Message);*/
            }
        }

        public void InstallationFailed(Exception ex)
        {
            installSucc = false;
            instDetails.Text = ex.Message;
            startInstall.Text = "Retry";
            startInstall.BackColor = Color.Red;
            startInstall.Enabled = true;
            allowClose = true;
            tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default; installSucc = false;
        }

        public bool IsServiceAlive()
        {
            if (IsProcessOpen("httpd") == true && IsProcessOpen("mysqld") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAppRunning()
        {
            // get the name of our process

            string proc = Process.GetCurrentProcess().ProcessName;

            // get the list of all processes by that name

            Process[] processes = Process.GetProcessesByName(proc);

            // if there is more than one process...

            if (processes.Length > 1)

            {

                MessageBox.Show("Application is already running");
                return true;

            }
            else
            {
                return false;
            }
        }

        private void linkLocalhost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://localhost/");
        }
    }
}
