using System;
using System.Collections.Generic;
using System.Text;

namespace Serenity
{
    public static class StaticContext
    {
        public static Timer Timer2h { get; set; }
        public static Timer Timer1s { get; set; }
        public static TimeSpan TempsRestant { get; set; }
        public static int Starting { get; set; }
        public static bool AccessTimer { get; set; }
    }
}
