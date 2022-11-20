namespace WindowsShutdownUI.Library
{
    public static class ShutdownHelper
    {
        /// <summary>
        /// Bilgisayarı, belirtilen saniye kadar gecikmeyle, kapatır.
        /// </summary>
        /// <param name="second"></param>
        /// <returns>exit code (0:success, other:false)</returns>
        public static string Shutdown(double second)
        {
            return CmdHelper.RunShutdownCommand($"/s /t {second}");
        }

        /// <summary>
        /// Bilgisayarı, belirtilen saniye kadar gecikmeyle, yeniden başlatır.
        /// </summary>
        /// <returns>exit code (0:success, other:false)</returns>
        public static string Restart(double second)
        {
            return CmdHelper.RunShutdownCommand($"/r /t {second}");
        }

        /// <summary>
        /// Zamanlanmış kapatma işlemini iptal eder.
        /// </summary>
        /// <returns>exit code (0:success, other:false)</returns>
        public static string Cancel()
        {
            return CmdHelper.RunShutdownCommand("/a");
        }
    }
}
