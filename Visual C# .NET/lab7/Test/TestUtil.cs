using System;
using Examination.Src;

namespace Examination.Test
{
    public static class TestUtil
    {
        public static void PrintResult(string testName, bool result)
        {
            Console.WriteLine($"{testName}: {(result ? "PASS" : "FAIL")}");
        }
    }
}


