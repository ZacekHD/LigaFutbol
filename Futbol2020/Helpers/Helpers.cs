using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Futbol2020.Helpers
{
    public class Helpers
    {
        public static String GetValidDateTime()
        {
            return GetTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static DateTime GetTime(int days = 0)
        {
            try
            {
                return TimeZoneInfo.ConvertTime((days == 0) ? DateTime.Now : DateTime.Now.AddDays(days), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)"));
            }
            catch (Exception ex)
            {
                return TimeZoneInfo.ConvertTime((days == 0) ? DateTime.Now : DateTime.Now.AddDays(days), TimeZoneInfo.FindSystemTimeZoneById("America/Mexico_City"));
            }
        }
    }
}



