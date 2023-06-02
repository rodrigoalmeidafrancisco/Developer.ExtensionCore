using System;

namespace Developer.ExtensionCore
{
    public static class TimeSpanExtension
    {
        /// <summary>
        /// Retorna a hora de um DateTime em um TimeSpan (HH:MM:SS).
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this DateTime val)
        {
            return new TimeSpan(val.Hour, val.Minute, val.Second);
        }

    }
}
