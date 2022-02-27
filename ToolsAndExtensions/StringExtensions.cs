using System.ComponentModel;
using System.Reflection;

namespace ToolsAndExtensions
{
    public static class StringExtensions
    {
        public static string ToUpperFirst(this string input) =>
            input switch
            {
                null => null,
                "" => null,
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };

        public static string ToUpperFirstList(this string self, string separator)
        {
            if (string.IsNullOrEmpty(self)) return string.Empty;
            var oldValues = self.Split(separator).ToList().Where(v => !string.IsNullOrEmpty(v));
            return string.Join(separator, oldValues.Select(val => val.ToUpperFirst()));
        }

        public static string GetDescriptionAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi?
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else return source.ToString();
        }
    }
}
