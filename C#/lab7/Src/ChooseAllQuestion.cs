using System;

namespace Examination.Src
{
    public class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string body, int marks, AnswerList answers, AnswerList correctAnswers) :
                        base("Choose ALL correct answers", body, marks, answers, correctAnswers)
        {
            if (answers == null || answers.Count > 4)
                throw new ArgumentException("correctAnswers must be only one.");
            if (correctAnswers == null || correctAnswers.Count == 1)
                throw new ArgumentException("correctAnswers must be greater than one.");
        }
        
        public override AnswerList TakeQuestion()
        {
            Console.WriteLine(ToString());


            Console.Write($"    Enter your number of answers: ");
            
            int numberOfAnswers = 0;
            while (!int.TryParse(Console.ReadLine(), out numberOfAnswers) || numberOfAnswers < 2 || numberOfAnswers > _answers.Count)
            {
                Console.Write($"    Enter a valid number of answers!: ");
            }

            AnswerList studentAnswers = new AnswerList();

            for (int i = 0; i < numberOfAnswers; i++)
            {
                string str = "";

                if (i == 0) str = "1st";
                else if (i == 1) str = "2nd";
                else if (i == 2) str = "3rd";
                else str = $"{i + 1}th";
                    
                Console.Write($"    Enter your {str} answer: ");

                int answerId = 0;

                while (!int.TryParse(Console.ReadLine(), out answerId) || _answers.GetById(answerId) == null)
                {
                    Console.Write($"    Enter a valid answer!: ");
                }

                Answer answer = _answers.GetById(answerId);
                studentAnswers.Add(answer);
            }
        
            return studentAnswers;
        }
    }
}