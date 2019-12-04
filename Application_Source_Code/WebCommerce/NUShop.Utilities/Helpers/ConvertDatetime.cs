using System;

namespace NUShop.Utilities.Helpers
{
    public static class ConvertDatetime
    {
        public static string ConvertToTimeSpan(string time)
        {
            var dateTime = DateTime.Parse(time).ToLocalTime();
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds().ToString();
        }

        public static string ConvertToTimeSpan(DateTime time)
        {
            var dateTimeOffset = new DateTimeOffset(time.ToLocalTime());
            return dateTimeOffset.ToUnixTimeSeconds().ToString();
        }

        public static DateTime UnixTimestampToDateTime(double unixTime)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
            return dateTime;
        }
        public static DateTime UnixTimestampToDateTime(string unixTime)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(Convert.ToDouble(unixTime)).ToLocalTime();
            return dateTime;
        }
    }
}