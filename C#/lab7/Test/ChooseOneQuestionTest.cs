using System;
using Examination.Src;

namespace Examination.Test
{
    public static class ChooseOneQuestionTest
    {
        public static void Execute()
        {
            Console.WriteLine("======= ChooseOneQuestion Test ======");
            
            var logger = new FileLogger();
            var questions = new QuestionList(logger);

            var answers = new AnswerList
            {
                new Answer(1, "Red"),
                new Answer(2, "Blue"),
                new Answer(3, "Green")
            };
            var correct = new Answer(2, "Blue");

            var q1 = new ChooseOneQuestion("Pick the color of the sky", 5, answers, correct);
            questions.Add(q1);

            AnswerList student1 = new AnswerList { new Answer(2, "Blue") }; // correct
            AnswerList student2 = new AnswerList { new Answer(1, "Red") };  // incorrect

            foreach (var q in questions)
            {
                TestUtil.PrintResult("Correct Answer", q.CheckAnswer(student1));
                TestUtil.PrintResult("Incorrect Answer", !q.CheckAnswer(student2));
            }

            Console.WriteLine($"Total ChooseOne Questions: {questions.Count}");
            Console.WriteLine($"Logged to: {logger.FilePath}\n");
        }
    }
}