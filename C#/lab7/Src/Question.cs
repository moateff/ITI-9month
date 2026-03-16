using System;

namespace Examination.Src
{
    public abstract class Question
    {
        public string Header { get; }
        public string Body { get; }
        public int Marks { get; }
        protected readonly AnswerList _answers;
        protected readonly AnswerList _correctAnswers;

        public AnswerList Answers => _answers;
        public AnswerList CorrectAnswers => _correctAnswers;


        public Question(string header, string body, int marks, 
                        AnswerList answers, AnswerList correctAnswers)
        {
            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentException("Header cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentException("Body cannot be null or empty.");
            if (marks <= 0)
                throw new ArgumentOutOfRangeException(nameof(marks), "Marks must be greater than 0.");
            if (answers == null || correctAnswers == null)
                throw new ArgumentNullException(nameof(answers), "Answers cannot be null.");

            Header = header;
            Body = body;
            Marks = marks;
            _answers = answers;
            _correctAnswers = correctAnswers;
        }

        public virtual void Display()
        {
            Console.WriteLine(ToString());

            // for (int i = 0; i < _answers.Count; i++)
            // {
            //     Console.WriteLine(_answers[i]);
            // }

            // Console.WriteLine();
        }

        public virtual bool CheckAnswer(AnswerList studentAnswer)
        {
            if (studentAnswer == null)
                throw new ArgumentNullException(nameof(studentAnswer), "studentAnswer cannot be null.");

            if (studentAnswer.Count != _correctAnswers.Count)
                return false;

            for(int i = 0; i < studentAnswer.Count; i++)
            {
                bool found = false;

                for(int j = 0; j < _correctAnswers.Count; j++)
                {
                    if (studentAnswer[i].Equals(_correctAnswers[j]))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found) return false;
            }

            return true;
        }

        public override string ToString()
        {
            string result = $"    {Header}: {Body} ({Marks} marks)\n";

            for (int i = 0; i < _answers.Count; i++)
            {
                result += $"    {_answers[i]}\n";
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Question q) return false;

            return Header == q.Header &&
                    Body == q.Body &&
                    Marks == q.Marks;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body, Marks, _correctAnswers);
        }

        public virtual AnswerList TakeQuestion()
        {
            return new AnswerList();
        }
    }
}