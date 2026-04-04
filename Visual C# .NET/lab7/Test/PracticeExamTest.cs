using System;
using System.Collections.Generic;
using Examination.Src;

namespace Examination.Test
{
    public static class PracticeExamTest
    {
        public static void Execute()
        {
            Console.WriteLine("======= Practice Exam Test ======");

            // ----- Setup Subject and Students -----
            Subject math = new Subject("Mathematics");
            Student s1 = new Student(1, "Ali");
            Student s2 = new Student(2, "Sara");
            math.Enroll(s1);
            math.Enroll(s2);

            TestUtil.PrintResult("Math enrollment count", math.EnrolledStudents.Count == 2);

            // ----- Setup Questions -----
            Question q1 = new TrueFalseQuestion("C# is strongly typed?", 5, new Answer(1, "True"));
            Question q2 = new ChooseOneQuestion(
                "What is 2 + 2?", 
                5, 
                new AnswerList { new Answer(1, "3"), new Answer(2, "4"), new Answer(3, "5") }, 
                new Answer(2, "4")
            );
            Question q3 = new ChooseAllQuestion(
                "Select prime numbers", 
                10,
                new AnswerList { new Answer(1,"2"), new Answer(2,"3"), new Answer(3,"4"), new Answer(4,"5") },
                new AnswerList { new Answer(1,"2"), new Answer(2,"3"), new Answer(4,"5") }
            );

            FileLogger logger = new FileLogger("Question.txt");

            // ----- Add Questions to QuestionList -----
            QuestionList questions = new QuestionList(logger);
            questions.Add(q1);
            questions.Add(q2);
            questions.Add(q3);


            // ----- Create Practice Exam -----
            PracticeExam practiceExam = new PracticeExam(60, questions, math);

            // ----- Mock student answers -----
            practiceExam.QuestionAnswerDictionary[q1] = new AnswerList { new Answer(1, "True") }; // correct
            practiceExam.QuestionAnswerDictionary[q2] = new AnswerList { new Answer(2, "4") };    // correct
            practiceExam.QuestionAnswerDictionary[q3] = new AnswerList { new Answer(1,"2"), new Answer(2,"3"), new Answer(4,"5") }; // correct

            // ----- Start Exam -----
            practiceExam.Start();
            TestUtil.PrintResult("PracticeExam Mode After Start", practiceExam.Mode == ExamMode.Starting);

            // ----- Show Exam (PracticeExam shows student + correct answers) -----
            Console.WriteLine("\nDisplaying Practice Exam:");
            practiceExam.ShowExam();

            // ----- Check CorrectExam Grade -----
            int grade = practiceExam.CorrectExam();
            TestUtil.PrintResult("PracticeExam CorrectExam grade", grade == 20);

            // ----- Finish Exam -----
            practiceExam.Finish();
            TestUtil.PrintResult("PracticeExam Mode After Finish", practiceExam.Mode == ExamMode.Finished);
        }
    }
}