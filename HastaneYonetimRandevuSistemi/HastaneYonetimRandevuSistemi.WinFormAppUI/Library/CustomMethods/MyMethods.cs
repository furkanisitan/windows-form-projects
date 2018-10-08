using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods
{
    class MyMethods
    {
        public static bool PasswordCompare(string pass1, string pass2)
        {
            return !string.IsNullOrWhiteSpace(pass1) && string.Equals(pass1, pass2);
        }

        public static void ShowMessageBox(ExceptionHandlingResult result)
        {
            MessageBox.Show(result.Message, "", MessageBoxButtons.OK,
                result.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
