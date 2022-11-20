using System;
using System.Linq;

namespace WifiPasswords.Library
{
    public static class WifiHelper
    {
        public static string[] GetWifiNames()
        {
            var output = CmdHelper.RunCmdCommand("/C netsh wlan show profile | findstr All");
            var wNames = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < wNames.Length; i++)
                wNames[i] = wNames[i].Substring(wNames[i].LastIndexOf(':') + 1).Trim();
            return wNames;
        }

        public static string GetPwdOfWifi(string wifiName)
        {
            var output = CmdHelper.RunCmdCommand($"/C netsh wlan show profile name=\"{wifiName}\" key=clear | findstr Key");
            return output.Split(':').Last().Trim();
        }
    }
}
