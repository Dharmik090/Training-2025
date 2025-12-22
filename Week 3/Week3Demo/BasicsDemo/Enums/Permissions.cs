using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.Enums
{
    [Flags]
    internal enum Permissions
    {
        None = 0,
        Read = 1,      // 0001
        Write = 2,     // 0010
        ReadWrite = Read | Write, // 0011,
        Execute = 4,   // 0100
        Admin = Read | Write | Execute // 0111
    }
}
