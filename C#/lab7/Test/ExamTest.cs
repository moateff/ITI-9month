// using System;
// using Examination.Src;

// namespace Examination.Test
// {
//     public static class ExamTest
//     {
//         public static void Execute()
//         {
//             Console.WriteLine("======= Exam Test ======");

//             // --- Subjects & Students ---
//             Subject physics = new Subject("Physics");
//             Student st1 = new Student(1, "Alice");
//             Student st2 = new Student(2, "Bob");
//             physics.Enroll(st1);
//             physics.Enroll(st2);

//             TestUtil.PrintResult("Physics enrolled students count", physics.EnrolledStudents.Count == 2);

//             // --- Questions ---
//             Question q1 = new TrueFalseQuestion("The earth is round?", 5, new Answer(1, "True"));
//             Question q2 = new ChooseOneQuestion(
//                 "2 + 2 = ?", 5,
//                 new AnswerList { new Answer(1,"3"), new Answer(2,"4") },
//                 new Answer(2,"4") 
//             );

//             FileLogger logger = new FileLogger("Question.txt");

//             QuestionList questions = new QuestionList(logger);
//             questions.Add(q1);
//             questions.Add(q2);

//             // --- Create Base Exam using anonymous derived type ---
//             Exam exam = new Exam(60, questions, physics);

//             // Mock student answers
//             exam.QuestionAnswerDictionary[q1] = new AnswerList { new Answer(1, "True") }; // correct
//             exam.QuestionAnswerDictionary[q2] = new AnswerList { new Answer(1, "3") }; // wrong

//             // --- Start Exam ---
//             exam.Start();
//             TestUtil.PrintResult("Exam mode after start", exam.Mode == ExamMode.Starting);

//             // --- CorrectExam ---
//             int grade = exam.CorrectExam();
//             TestUtil.PrintResult("CorrectExam calculates grade", grade == 5);

//             // --- Finish Exam ---
//             exam.Finish();
//             TestUtil.PrintResult("Exam mode after finish", exam.Mode == ExamMode.Finished);

//             // --- ToString, Equals, GetHashCode ---
//             TestUtil.PrintResult("Exam ToString non-empty", !string.IsNullOrEmpty(exam.ToString()));
//             Exam sameExam = new Exam(60, questions, physics);
//             TestUtil.PrintResult("Exam Equals test", exam.Equals(sameExam));

//             // --- CompareTo ---
//             Exam longerExam = new Exam(90, questions, physics);
//             TestUtil.PrintResult("Exam CompareTo test", exam.CompareTo(longerExam) < 0);
//         }
//     }
// }