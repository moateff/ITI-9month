using System;
using System.Collections.Generic;

namespace Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Book> bList = new List<Book>
            {
                new Book("333", "C++ Basics",
                    new[] { "Ahmed", "Sara" },
                    new DateTime(2023, 2, 1), 250),

                new Book("111", "C# Basics",
                    new[] { "Ali", "Omar" },
                    new DateTime(2022, 5, 10), 150),

                new Book("222", "Advanced C#",
                    new[] { "Mona" },
                    new DateTime(2023, 1, 1), 220)
            };

            Console.WriteLine("a) User Defined Delegate");
            BookFuncDelegate fDel1 = new BookFuncDelegate(BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks(bList, fDel1);

            Console.WriteLine("\nb) BCL Delegate (Func)");
            Func<Book, string> fDel2 = BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(bList, fDel2);

            Console.WriteLine("\nc) Anonymous Method (ISBN)");
            Func<Book, string> fDel3 = delegate (Book b) { return b.ISBN; };
            LibraryEngine.ProcessBooks(bList, fDel3);

            Console.WriteLine("\nd) Lambda (Publication Date)");
            Func<Book, string> fDel4 = b => (b.PublicationDate).ToString();
            LibraryEngine.ProcessBooks(bList, fDel4);
        }
    }
}