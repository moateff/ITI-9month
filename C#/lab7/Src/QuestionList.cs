using System;

namespace Examination.Src
{
    public class QuestionList : List<Question>
    {
        private readonly FileLogger _logger;

        public QuestionList(FileLogger logger) : base()
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");

            _logger = logger;
        }

        public new void Add(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question), "Question cannot be null.");
                
            base.Add(question);
            _logger.Log(question.ToString());
        }

        override public string ToString()
        {
            string result = "";
            for (int i = 0; i < Count; i++)
            {
                result += $"{this[i].ToString()}\n";
            }
            return result;
        }

        public static QuestionList GenerateMathQuestions()
        {
            QuestionList questions = new QuestionList(new FileLogger("Exam.txt"));

            // ---------- TRUE / FALSE (3) ----------

            questions.Add(new TrueFalseQuestion(
                "12 is an even number?",
                2,
                new Answer(1, "True")
            ));

            questions.Add(new TrueFalseQuestion(
                "5 is divisible by 2?",
                2,
                new Answer(2, "False")
            ));

            questions.Add(new TrueFalseQuestion(
                "The square root of 9 is 3",
                2,
                new Answer(1, "True")
            ));

            // ---------- CHOOSE ONE (4) ----------

            questions.Add(new ChooseOneQuestion(
                "2 + 3 = ?",
                3,
                new AnswerList
                {
                    new Answer(1,"4"),
                    new Answer(2,"5"),
                    new Answer(3,"6"),
                    new Answer(4,"7")
                },
                new Answer(2,"5")
            ));

            questions.Add(new ChooseOneQuestion(
                "10 / 2 = ?",
                3,
                new AnswerList
                {
                    new Answer(1,"2"),
                    new Answer(2,"3"),
                    new Answer(3,"5"),
                    new Answer(4,"10")
                },
                new Answer(3,"5")
            ));

            questions.Add(new ChooseOneQuestion(
                "7 × 6 = ?",
                3,
                new AnswerList
                {
                    new Answer(1,"36"),
                    new Answer(2,"42"),
                    new Answer(3,"48"),
                    new Answer(4,"52")
                },
                new Answer(2,"42")
            ));

            questions.Add(new ChooseOneQuestion(
                "9 % 2 = ?",
                3,
                new AnswerList
                {
                    new Answer(1,"0"),
                    new Answer(2,"1"),
                    new Answer(3,"2"),
                    new Answer(4,"3")
                },
                new Answer(2,"1")
            ));

            // ---------- CHOOSE ALL (3) ----------

            questions.Add(new ChooseAllQuestion(
                "Select prime numbers",
                4,
                new AnswerList
                {
                    new Answer(1,"2"),
                    new Answer(2,"3"),
                    new Answer(3,"4"),
                    new Answer(4,"5")
                },
                new AnswerList
                {
                    new Answer(1,"2"),
                    new Answer(2,"3"),
                    new Answer(4,"5")
                }
            ));

            questions.Add(new ChooseAllQuestion(
                "Select even numbers",
                4,
                new AnswerList
                {
                    new Answer(1,"2"),
                    new Answer(2,"4"),
                    new Answer(3,"20"),
                    new Answer(4,"100")
                },
                new AnswerList
                {
                    new Answer(1,"2"),
                    new Answer(2,"4"),
                    new Answer(3,"20"),
                    new Answer(4,"100")
                }
            ));

            questions.Add(new ChooseAllQuestion(
                "Select perfect squares",
                4,
                new AnswerList
                {
                    new Answer(1,"4"),
                    new Answer(2,"6"),
                    new Answer(3,"9"),
                    new Answer(4,"12")
                },
                new AnswerList
                {
                    new Answer(1,"4"),
                    new Answer(3,"9")
                }
            ));

            return questions;
        }
    }
}