using System;


namespace Core.Util
{
    public static class Utils
    {
        public static T EnsureNotNull<T>(this T? value)
        {
            if (value == null)
            {
                throw new NullReferenceException(typeof(T).FullName);
            }

            return value;
        } 
    }
}