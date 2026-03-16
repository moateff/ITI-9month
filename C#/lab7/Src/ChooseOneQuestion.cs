using System;

namespace Examination.Src
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string body, int marks, AnswerList answers, Answer correctAnswer) :
                        base("Choose one choice ONLY", body, marks, answers, new AnswerList { correctAnswer })
        {
            if (answers == null || answers.Count > 4)
                throw new ArgumentException("answers must be less than or equal to 4.");
        }

        public override AnswerList TakeQuestion()
        {
            Console.WriteLine(ToString());

            // Console.Write($"    Enter your answer [1:{_answers.Count}]: ");
            Console.Write($"    Enter your answer: ");
            
            int answerId = 0;

            while (!int.TryParse(Console.ReadLine(), out answerId) || _answers.GetById(answerId) == null)
            {
                Console.Write($"    Enter a valid answer!: ");
            }

            Answer answer = _answers.GetById(answerId);
            AnswerList studentAnswers = new AnswerList();
            studentAnswers.Add(answer);
            return studentAnswers;
        }
    }
}