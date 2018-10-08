using System;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling
{
    class CrudHandler
    {
        public static ExceptionHandlingResult AddOrUpdate(Action action)
        {
            try
            {
                action.Invoke();
                return new ExceptionHandlingResult(true, "İşlem Başarılı");
            }
            catch (Exception e)
            {
                return new ExceptionHandlingResult(false, e.Message);
            }
        }
    }
}
