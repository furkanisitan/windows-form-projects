using System.Diagnostics;

namespace WifiPasswords.Library
{
    public static class CmdHelper
    {
        public static string RunCmdCommand(string cmd)
        {
            string output;
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = cmd,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            return output;
        }

    }
}
