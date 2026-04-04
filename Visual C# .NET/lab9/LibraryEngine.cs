using System;
using System.Collections.Concurrent;

namespace Task
{
    public delegate string BookFuncDelegate(Book B);

    public class LibraryEngine 
    { 
        public static void ProcessBooks(List<Book> bList, BookFuncDelegate fPtr) 
        { 
            foreach (Book B in bList) 
            { 
                Console.WriteLine(fPtr(B)); 
            } 
        } 

        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr) 
        { 
            foreach (Book B in bList) 
            { 
                Console.WriteLine(fPtr(B)); 
            } 
        } 
    } 
 
}