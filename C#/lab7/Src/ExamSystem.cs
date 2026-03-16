using System;

namespace Examination.Src
{
    public static class ExamSystem
    {
        public static void Run()
        {
            Console.WriteLine("\n==========================================================================\n");
            Console.WriteLine("                      Welcome to the Exam System!");
            Console.WriteLine("\n==========================================================================\n");
            
            do
            {
                Console.WriteLine("    1) Final Exam");
                Console.WriteLine("    2) Practice Exam");
                Console.WriteLine("    3) Exit");
                Console.Write("\n    Select a choice: ");
                
                int choice = 0;
                
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Enter a valid choice!");
                    Console.Write("\nSelect a choice: ");
                }

                switch (choice)
                {
                    case (int)ExamType.Final:
                        Exam finalExam = FinalExam.GenerateMathExam();
                        finalExam.TakeExam();
                        finalExam.ShowExam();
                        return;
                    case (int)ExamType.Practice:
                        Exam practiceExam  = PracticeExam.GenerateMathExam();
                        practiceExam.TakeExam();
                        practiceExam.ShowExam();
                        return;
                    case 3:
                        Console.WriteLine("\n==========================================================================\n");
                        Console.WriteLine("                                Goodbye!");
                        Console.WriteLine("\n==========================================================================\n");
                        return;
                }
            } while (true); 
        }
    }
}
