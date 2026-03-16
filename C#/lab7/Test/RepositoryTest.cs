using System;
using Examination.Src;

namespace Examination.Test
{
    public static class RepositoryTest
    {
        public static void Execute()
        {
            Console.WriteLine("========== Repository Test =========");

            var repo = new Repository<Point>();

            var p1 = new Point() { X = 1, Y = 2 };
            var p2 = new Point() { X = 5, Y = 4 };
            var p3 = new Point() { X = 2, Y = 6 };
            var p4 = new Point() { X = 2, Y = 1 };

            System.Console.WriteLine($"Count: {repo.Count}");

            repo.Add(p1);
            repo.Add(p2);
            repo.Add(p3);
            repo.Add(p4);
            
            System.Console.WriteLine($"Count: {repo.Count}");

            Console.WriteLine("Before sorting:");
            foreach (var p in repo.GetAll())
                Console.WriteLine(p);

            repo.Sort();

            Console.WriteLine("After sorting:");
            foreach (var p in repo.GetAll())
                Console.WriteLine(p);
            
            Console.WriteLine("======= End of Repository Test ======");
        }
    }
}