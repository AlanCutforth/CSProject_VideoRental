using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject1
{
    //Static class that stores details of the currently logged in user.
    public static class Session
    {
        public static string User { get; set; }
        public static bool IsAdmin { get; set; }
    }
}
