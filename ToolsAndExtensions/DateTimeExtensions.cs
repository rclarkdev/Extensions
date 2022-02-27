using System.Runtime.InteropServices;

namespace ToolsAndExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the time stamp to the date that represents midnight
        /// for the end of the month.
        /// </summary>
        /// <param name="timeStamp">The time stamp to convert.</param>
        /// <returns>The end of the month at midnight.</returns>
        public static DateTime ToEndOfMonth(this DateTime timeStamp)
        {
            return new DateTime(
                timeStamp.Year,
                timeStamp.Month,
                1,
                0,
                0,
                0
            ).AddMonths(1).AddDays(-1);
        }

        public static DateTime ToPST(this DateTime utc)
        {
            TimeZoneInfo pacificZone = TimeZoneInfo.FindSystemTimeZoneById(GetPSTTimeZone());
            var pacificTime = TimeZoneInfo.ConvertTimeFromUtc(utc, pacificZone);
            return pacificTime;
        }

        public static string GetPSTTimeZone()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "Pacific Standard Time";
            }
            else
            {
                return "America/Los_Angeles";
            }
        }

        public static bool IsValidDate(this string date)
        {
            return DateTime.TryParse(date, out var dateValue);
        }
    }
}