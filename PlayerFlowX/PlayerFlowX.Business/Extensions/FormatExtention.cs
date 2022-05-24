namespace PlayerFlowX.Business.Extensions
{
    public static class FormatExtention
    {
        public static string FormatTo(this string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }
}
