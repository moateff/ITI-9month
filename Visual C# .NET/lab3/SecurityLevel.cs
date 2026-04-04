using System;

namespace Task
{
    [Flags]
    public enum SecurityLevel : byte
    {
        Guest = 1, 
        Developer = 2, 
        Secretary = 4,
        DBA = 8
    }
}