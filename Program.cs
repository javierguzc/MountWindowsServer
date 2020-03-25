using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountWindowsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Settings
            string serverDirectory = ConfigurationManager.AppSettings["serverDirectory"];
            string mountedDirectory = ConfigurationManager.AppSettings["mountedDirectory"];
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string command = "sudo mount -t cifs " + serverDirectory + " " + mountedDirectory + " -o username=" + username + ",password=" + password;
            
            Console.WriteLine("Attempting to mount " + serverDirectory);
            Console.WriteLine("Command: " + command);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = "-c \"" + command +"\"";
            startInfo.UseShellExecute = false;

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
