using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Common.Extensions
{
    public static class ASCII
    {
        public static char ToASCII(this int number)
        {
            return Convert.ToChar(number + 97);
        }
    }
}