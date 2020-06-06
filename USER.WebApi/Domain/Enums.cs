using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace USER.WebApi.Domain
{
    public static class Enums
    {
        public enum ErrorCode
        {
            [Description("Missing fields")]
            MF = 1,
            [Description("Invalid fields")]
            IF = 2,
            [Description("E-mail already exists")]
            EAE = 3,
            [Description("Unexpected error")]
            UNE = 4,

        }
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
