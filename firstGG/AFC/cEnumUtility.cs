using System;
using System.Collections.Generic;
using System.Text;

namespace AFC
{
    public static class cEnumUtility
    {
        public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
        {
            if (false == typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            if (true == string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().ToLower().Equals(value.Trim().ToLower()))
                {
                    return item;
                }
            }

            return defaultValue;
        }
    }
}
