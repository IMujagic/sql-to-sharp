using System;

namespace SqlToSharp.Common
{
    public static class Extensions
    {
        public static string Nullable(this string s, bool isNullable)
        {
            if(isNullable && IsValueType(s))
                return $"Nullable<{s}>";

            return s;
        }

        private static bool IsValueType(string typeName)
        {
            var type = Type.GetType(typeName);

            if(type == null)
                throw new ArgumentException($"Provided type name {typeName} doesn't exist.");
            
            return type.IsValueType;
        }

        public static string Format(this Exception ex)
        {
            //todo: implement full formatting
            return ex.ToString();
        }
    }
}