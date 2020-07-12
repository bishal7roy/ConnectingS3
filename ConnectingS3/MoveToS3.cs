using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConnectingS3
{
    class MoveToS3
    {
        public void LocaltoS3(string s3Location)
        {
            string sourceDirectory = "\\ConnectingAWS\\S3\\";
            string destinationDirectory = "\\ConnectingAWS\\S3_BackUp\\";
            string command = "aws s3 cp ";
            Console.WriteLine("Local to S3");
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
                Directory.CreateDirectory(destinationDirectory);
            }
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.Verb = "runas";


            string[] Files = Directory.GetFiles(sourceDirectory);
            try
            {
                if (Files.Length > 0)
                {
                    command += sourceDirectory + " " + s3Location + " --recursive";
                    Console.WriteLine(command);
                    //startInfo.Arguments = "/user:Administrator \"cmd /K " + command + "\"";
                    process.StartInfo = startInfo;
                    process.Start();

                    using (StreamWriter sw = process.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine(command);
                            sw.WriteLine("exit \n");
                        }
                    }
                    process.WaitForExit();

                    foreach (var item in Files)
                    {
                        if(File.Exists(Path.Combine(destinationDirectory, Path.GetFileName(item))))
                            File.Delete(Path.Combine(destinationDirectory, Path.GetFileName(item)));
                        File.Move(item, Path.Combine(destinationDirectory, Path.GetFileName(item)));
                    }

                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                process.Close();

            }
        }
    }
}
