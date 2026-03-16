using System;
using Examination.Src;

namespace Examination.Test
{
    public static class TrueFalseQuestionTest
    {
        public static void Execute()
        {
            Console.WriteLine("======= TrueFalseQuestion Test ======");
            
            var logger = new FileLogger();
            var questions = new QuestionList(logger);

            // Add multiple TF questions
            var q1 = new TrueFalseQuestion("C# is a programming language.", 5, new Answer(1, "True"));
            var q2 = new TrueFalseQuestion("The sky is green.", 5, new Answer(2, "False"));

            questions.Add(q1);
            questions.Add(q2);

            // Test student answers
            AnswerList student1 = new AnswerList { new Answer(1, "True") };   // correct
            AnswerList student2 = new AnswerList { new Answer(2, "True") };   // incorrect

            foreach (var q in questions)
            {
                TestUtil.PrintResult("Correct Answer", q.CheckAnswer(student1));
                TestUtil.PrintResult("Incorrect Answer", !q.CheckAnswer(student2));
            }

            Console.WriteLine($"Total TF Questions: {questions.Count}");
            Console.WriteLine($"Logged to: {logger.FilePath}\n");
        }
    }
}