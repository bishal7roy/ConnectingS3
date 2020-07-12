using System;
using System.IO;
using System.Text;

namespace ConnectingS3
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveToS3 s3 = new MoveToS3();
            try
            {
                string s3Location = "";
                string s3FilePath = "\\ConnectingAWS\\S3Path.config";
                string value = "";
                string s3Data = "";
                
                if (!Directory.Exists("\\ConnectingAWS\\"))
                    Directory.CreateDirectory("\\ConnectingAWS\\");
                if (File.Exists(s3FilePath))
                {
                    value = File.ReadAllText(s3FilePath, Encoding.UTF8);
                    Console.WriteLine("\nBucket Path used last time--> " + value);
                    Console.WriteLine("\nPress Y to continue with S3 Bucket Path used last time \nPress N to enter new S3 Bucket path");
                    s3Data = Console.ReadLine().ToString();
                }

                if (s3Data.ToLower().Equals("y"))
                    s3Location = value;
                else
                {
                    Console.WriteLine("Enter S3 Bucket Name with Directory where you want to move (bucketname/foldername/) e.g. - bdp-lambdas-dev/stats/ ");
                    s3Location = Console.ReadLine().ToString();
                }
                File.WriteAllText(s3FilePath, s3Location);
                s3Location = "s3://" + s3Location;
                s3.LocaltoS3(s3Location);
            }
            catch(Exception ex)
            {

            }
        }

    }
}
