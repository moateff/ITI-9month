using System;

namespace Examination.Src
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, QuestionList questions, Subject subject) : 
            base(time, questions, subject)
        {
        }
        
        public override void ShowExam()
        {
            Console.WriteLine($"\t{Subject.Name} Final Exam ({Questions.Count} questions) Time: {Time} minutes");
            Console.WriteLine("\n==========================================================================\n");

            foreach (var q in Questions)
            {
                Console.WriteLine(q);

                Console.WriteLine($"    Student's Answer:\n{QuestionAnswerDictionary[q]}");
                
                Console.WriteLine("\n==========================================================================\n");
            }

            int grade = CorrectExam();

            Console.WriteLine($"                    You scored {grade} out of {TotalMarks} marks.");
            Console.WriteLine("\n==========================================================================\n");
        }

        public static Exam GenerateMathExam()
        {
            Subject math = Subject.GenerateMathSubject();
            
            QuestionList questions = QuestionList.GenerateMathQuestions();

            Exam exam = new FinalExam(60, questions, math);

            return exam;
        }
    }
}