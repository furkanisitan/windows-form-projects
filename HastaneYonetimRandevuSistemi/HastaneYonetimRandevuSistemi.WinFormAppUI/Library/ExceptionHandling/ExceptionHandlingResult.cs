namespace HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling
{
    class ExceptionHandlingResult
    {
        public string Message { get; }
        public bool IsSuccess { get; }

        public ExceptionHandlingResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
