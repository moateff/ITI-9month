using System;
using Examination.Src;

namespace Examination.Test
{
    public static class ChooseAllQuestionTest
    {
        public static void Execute()
        {
            Console.WriteLine("======= ChooseAllQuestion Test ======");
            
            var logger = new FileLogger();
            var questions = new QuestionList(logger);

            var answers = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(2, "Java"),
                new Answer(3, "Python"),
                new Answer(4, "HTML")
            };
            var correct = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(2, "Java"),
                new Answer(3, "Python")
            };

            var q1 = new ChooseAllQuestion("Pick all programming languages", 10, answers, correct);
            questions.Add(q1);

            AnswerList student1 = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(2, "Java"),
                new Answer(3, "Python")
            }; // correct

            AnswerList student2 = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(4, "HTML")
            }; // incorrect

            foreach (var q in questions)
            {
                TestUtil.PrintResult("Correct Answer", q.CheckAnswer(student1));
                TestUtil.PrintResult("Incorrect Answer", !q.CheckAnswer(student2));
            }

            Console.WriteLine($"Total ChooseAll Questions: {questions.Count}");
            Console.WriteLine($"Logged to: {logger.FilePath}\n");
        }
    }
}