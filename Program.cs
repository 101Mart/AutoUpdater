using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Auto_Updater
{
    class Program
    {
        //The name of your project
        public static string Program_Name = "your_program";

        //The name of the folder in your zipped file
        public static string folder_name_in_zip = "myprogram";

        //The name of your .exe file without the .exe
        public static string exe_file = "program";

        //Your download link url use vps or web hosting to host your files
        public static string download_link = "https://martizio.dev/api/download/project.zip";
        private static void StartProcess()
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "C:\\ProgramData\\" + Program_Name + "\\" + folder_name_in_zip + "\\" + exe_file + ".exe";
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.WorkingDirectory = Path.GetDirectoryName("C:\\ProgramData\\" + Program_Name + "\\" + folder_name_in_zip + "\\");
            processInfo.RedirectStandardError = true;
            Process proc = Process.Start(processInfo);

        }

        static void Main(string[] args)
        {



            Console.WriteLine("Downloading...");

            if (Directory.Exists("C:\\ProgramData\\" + Program_Name))
            {

                foreach (Process proc in Process.GetProcessesByName(exe_file))
                {
                    proc.Kill();
                }
                System.Threading.Thread.Sleep(1000);
                Directory.Delete("C:\\ProgramData\\" + Program_Name, true);
                Directory.CreateDirectory("C:\\ProgramData\\" + Program_Name);
                WebClient wc = new WebClient();
                wc.DownloadFile(download_link, "C:\\ProgramData\\" + Program_Name + "\\ilililili.zip");
                string startPath = "C:\\ProgramData\\" + Program_Name + "\\ilililili.zip";
                string extractPath = "C:\\ProgramData\\" + Program_Name + "\\";

                System.IO.Compression.ZipFile.ExtractToDirectory(startPath, extractPath);

                File.Delete("C:\\ProgramData\\" + Program_Name + "\\ilililili.zip");

                StartProcess();

            }
            else
            {
                Directory.CreateDirectory("C:\\ProgramData\\buv4");
                WebClient wc = new WebClient();
                wc.DownloadFile(download_link, "C:\\ProgramData\\" + Program_Name + "\\ilililili.zip");
                string startPath = "C:\\ProgramData\\" + Program_Name + "\\ilililili.zip";
                string extractPath = "C:\\ProgramData\\" + Program_Name + "\\";

                System.IO.Compression.ZipFile.ExtractToDirectory(startPath, extractPath);

                File.Delete("C:\\ProgramData\\" + Program_Name + "\\ilililili.zip");

                StartProcess();
            }





        }
    }
}






