// using Examination.Src;

// namespace Examination.Test
// {
//     public static class QuestionTest
//     {
//         public static void Execute()
//         {
//             Console.WriteLine("======= Question Test ======");

//             AnswerList answers = new AnswerList();

//             Answer a1 = new Answer(1, "Answer 1");
//             Answer a2 = new Answer(2, "Answer 2");
//             Answer a3 = new Answer(3, "Answer 3");
//             Answer a4 = new Answer(4, "Answer 4");

//             answers.Add(a1);
//             answers.Add(a2);
//             answers.Add(a3);
//             answers.Add(a4);

//             AnswerList correctAnswers = new AnswerList();
//             correctAnswers.Add(a1);
//             correctAnswers.Add(a2);

//             Question question = new Question(
//                 "Sample Question",
//                 "Choose correct answers",
//                 10,
//                 answers,
//                 correctAnswers
//             );

//             // TEST 1
//             AnswerList test1 = new AnswerList();
//             test1.Add(new Answer(1, "Answer 1"));
//             test1.Add(new Answer(2, "Answer 2"));
//             TestUtil.PrintResult("Correct answers", question.CheckAnswer(test1));

//             // TEST 2
//             AnswerList test2 = new AnswerList();
//             test2.Add(new Answer(2, "Answer 2"));
//             test2.Add(new Answer(1, "Answer 1"));
//             TestUtil.PrintResult("Correct answers (reversed order)", question.CheckAnswer(test2));

//             // TEST 3
//             AnswerList test3 = new AnswerList();
//             test3.Add(new Answer(1, "Answer 1"));
//             test3.Add(new Answer(3, "Answer 3"));
//             TestUtil.PrintResult("One wrong answer", !question.CheckAnswer(test3));

//             // TEST 4
//             AnswerList test4 = new AnswerList();
//             test4.Add(new Answer(1, "Answer 1"));
//             TestUtil.PrintResult("Missing answer", !question.CheckAnswer(test4));

//             // TEST 5
//             AnswerList test5 = new AnswerList();
//             test5.Add(new Answer(1, "Answer 1"));
//             test5.Add(new Answer(2, "Answer 2"));
//             test5.Add(new Answer(3, "Answer 3"));
//             TestUtil.PrintResult("Extra answer", !question.CheckAnswer(test5));

//             // TEST 6
//             AnswerList test6 = new AnswerList();
//             test6.Add(new Answer(1, "Answer 1"));
//             test6.Add(new Answer(1, "Answer 1"));
//             TestUtil.PrintResult("Duplicate answers", !question.CheckAnswer(test6));

//             // TEST 7
//             AnswerList test7 = new AnswerList();
//             test7.Add(new Answer(3, "Answer 3"));
//             test7.Add(new Answer(4, "Answer 4"));
//             TestUtil.PrintResult("All wrong answers", !question.CheckAnswer(test7));


//             var found = answers.GetById(3);
//             Console.WriteLine(found != null ? "GetById PASS" : "GetById FAIL");

//             Console.Write("CompareTo test:");
//             Console.WriteLine(a1.CompareTo(a2) < 0 ? "PASS" : "FAIL");

//             Answer equalTest = new Answer(1, "Answer 1");
//             Console.WriteLine(a1.Equals(equalTest) ? "Equals PASS" : "Equals FAIL");

//             Console.WriteLine();
//         }
//     }
// }
