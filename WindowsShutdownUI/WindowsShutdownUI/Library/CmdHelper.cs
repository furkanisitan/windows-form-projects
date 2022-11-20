using System.ComponentModel;
using System.Diagnostics;

namespace WindowsShutdownUI.Library
{
    public static class CmdHelper
    {
        public static string RunShutdownCommand(string arguments)
        {
            string message;
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "shutdown.exe",
                    Arguments = arguments,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                process.WaitForExit();
                message = new Win32Exception(process.ExitCode).Message;
            }
            return message;
        }

    }
}
