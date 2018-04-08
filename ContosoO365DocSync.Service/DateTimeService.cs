using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public static class DateTimeService
    {
        public static DateTime ToPSTDateTime(this DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
        }
    }
}
