using PlayerFlowX.Domain.Enums;
using System.ComponentModel;

namespace PlayerFlowX.Business.Extentions
{
    public static class MessageExtention
    {
        public static string Description(this EMessage message)
        {
            var type = message.GetType();
            var memberInfo = type.GetMember(message.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
