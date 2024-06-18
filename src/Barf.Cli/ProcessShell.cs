using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Barf.Cli
{
    public class ProcessShell
    {
        private readonly Process _process = new Process();

        public void DotnetFormat()
        {
            ConsoleWriter.Standard("Running Dotnet Format");
            Execute("dotnet", "format");
        }

        public void Execute(string script)
        {
            script = script
                .Replace("\r\n", "")
                .Replace("\n", "");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _process.StartInfo.FileName = "powershell.exe";
                _process.StartInfo.Arguments = $"-Command \"{script.Replace("\\;", ";")}\"";

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                _process.StartInfo.FileName = "/bin/bash";
                _process.StartInfo.Arguments = $"-c \"{script}\"";
            }

            _process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };
            _process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine("ERROR: " + e.Data);
            };

            if (_process.Start())
            {
                _process.WaitForExit();
            }

        }

        public void Execute(string command, string args, string workingDirectory = "")
        {
            _process.StartInfo.FileName = command;
            _process.StartInfo.Arguments = args;
            if (!string.IsNullOrEmpty(workingDirectory))
            {
                _process.StartInfo.WorkingDirectory = workingDirectory;
            }

            if (_process.Start())
            {
                _process.WaitForExit();
            }
        }

        public void DeleteFileInSubDirectories(string fileName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _process.StartInfo.FileName = "powershell.exe";
                _process.StartInfo.Arguments = $"-Command \"Get-ChildItem -Path . -Recurse -Filter \"{fileName}\" | Remove-Item\"";

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                _process.StartInfo.FileName = "/bin/bash";
                _process.StartInfo.Arguments = $"-c \"find . -type f -name \"{fileName}\" -exec rm {{}} \\;\"";
            }

            _process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };
            _process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine("ERROR: " + e.Data);
            };


            if (_process.Start())
            {
                _process.WaitForExit();
            }

        }
    }
}