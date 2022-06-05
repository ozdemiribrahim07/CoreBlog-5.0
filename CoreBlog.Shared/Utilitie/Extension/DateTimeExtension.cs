using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Utilitie.Extension
{
    public static class DateTimeExtension
    {

        public static string FullDateTime(this DateTime dateTime)
        {
            return $"{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}";

        }

    }
}
