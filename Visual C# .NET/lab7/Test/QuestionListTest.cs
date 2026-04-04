using System;
using Examination.Src;

namespace Examination.Test
{
    public static class QuestionListTest
    {
        public static void Execute()
        {
            Console.WriteLine("======= QuestionList Test ======");
            
            // Create logger and QuestionList
            FileLogger logger = new FileLogger();
            QuestionList questions = new QuestionList(logger);

            // === TrueFalseQuestions ===
            var tf1 = new TrueFalseQuestion("C# is a programming language.", 5, new Answer(1, "True"));
            var tf2 = new TrueFalseQuestion("The sky is green.", 5, new Answer(2, "False"));

            questions.Add(tf1);
            questions.Add(tf2);

            // Student answers
            AnswerList tfStudentCorrect = new AnswerList { new Answer(1, "True") };
            AnswerList tfStudentIncorrect = new AnswerList { new Answer(2, "True") };

            TestUtil.PrintResult("TF Correct Answer tf1", tf1.CheckAnswer(tfStudentCorrect));
            TestUtil.PrintResult("TF Incorrect Answer tf1", !tf1.CheckAnswer(tfStudentIncorrect));

            // === ChooseOneQuestions ===
            AnswerList coAnswers = new AnswerList
            {
                new Answer(1, "Red"),
                new Answer(2, "Blue"),
                new Answer(3, "Green")
            };
            Answer coCorrect = new Answer(2, "Blue");
            var co1 = new ChooseOneQuestion("Pick the color of the sky", 5, coAnswers, coCorrect);

            questions.Add(co1);

            AnswerList coStudentCorrect = new AnswerList { new Answer(2, "Blue") };
            AnswerList coStudentIncorrect = new AnswerList { new Answer(1, "Red") };

            TestUtil.PrintResult("ChooseOne Correct Answer", co1.CheckAnswer(coStudentCorrect));
            TestUtil.PrintResult("ChooseOne Incorrect Answer", !co1.CheckAnswer(coStudentIncorrect));

            // === ChooseAllQuestions ===
            AnswerList caAnswers = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(2, "Java"),
                new Answer(3, "Python"),
                new Answer(4, "HTML")
            };
            AnswerList caCorrect = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(2, "Java"),
                new Answer(3, "Python")
            };
            var ca1 = new ChooseAllQuestion("Pick all programming languages", 10, caAnswers, caCorrect);

            questions.Add(ca1);

            AnswerList caStudentCorrect = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(2, "Java"),
                new Answer(3, "Python")
            };
            AnswerList caStudentIncorrect = new AnswerList
            {
                new Answer(1, "C#"),
                new Answer(4, "HTML")
            };

            TestUtil.PrintResult("ChooseAll Correct Answer", ca1.CheckAnswer(caStudentCorrect));
            TestUtil.PrintResult("ChooseAll Incorrect Answer", !ca1.CheckAnswer(caStudentIncorrect));

            System.Console.WriteLine($"Total Questions: {questions.Count}");
            TestUtil.PrintResult("Total Questions Added", questions.Count == 4);

            Console.WriteLine($"Questions logged to: {logger.FilePath}");
        }
    }
}