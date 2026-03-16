using System;

namespace Examination.Src
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, int marks, Answer correctAnswers) :
                        base("True or False", body, marks, GenerateAnswers(), new AnswerList { correctAnswers })
        {
        }

        private static AnswerList GenerateAnswers()
        {
            var list = new AnswerList();
            list.Add(new Answer(1, "True"));
            list.Add(new Answer(2, "False"));
            return list;
        }

        public override AnswerList TakeQuestion()
        {
            Console.WriteLine(ToString());

            Console.Write("    Enter your answer: ");
            
            int answerId = 0;

            while (!int.TryParse(Console.ReadLine(), out answerId) || _answers.GetById(answerId) == null)
            {
                Console.Write("    Enter a valid answer!: ");
            }

            Answer answer = _answers.GetById(answerId);
            AnswerList studentAnswers = new AnswerList();
            studentAnswers.Add(answer);
            return studentAnswers;
        }
    }
}