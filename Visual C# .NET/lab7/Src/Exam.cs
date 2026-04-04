using System;

namespace Examination.Src
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; }
        public int NumberOfQuestions => Questions.Count;
        public int TotalMarks { get; protected set; }
        public QuestionList Questions { get; private set; }
        public Dictionary<Question, AnswerList> QuestionAnswerDictionary { get; }
        public Subject Subject { get; }
        public ExamMode Mode { get; protected set; }
        
        public event ExamStartedHandler ExamStarted;

        private void OnExamStarted(ExamEventArgs e)
        {
            ExamStarted?.Invoke(this, e);
        }

        public Exam(int time, QuestionList questions, Subject subject)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time), "time must be greater than 0.");
            if (questions == null)
                throw new ArgumentNullException(nameof(questions), "Questions cannot be null.");
            if (subject == null)
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
            
            Time = time;
            Questions = questions;
            Subject = subject;

            Mode = ExamMode.Queued;
            QuestionAnswerDictionary = new Dictionary<Question, AnswerList>();

            ExamStarted = Subject.NotifyStudents;

            FileLogger logger = new FileLogger();
            logger.LogWithDate($"[Exam queued] {ToString()}");
        }

        public abstract void ShowExam();

        public virtual void Start()
        {
            Mode = ExamMode.Starting;

            FileLogger logger = new FileLogger();
            logger.LogWithDate($"[Exam started] {ToString()}");

            OnExamStarted(new ExamEventArgs(Subject, this));
        }

        public virtual void Finish()
        {
            Mode = ExamMode.Finished;

            FileLogger logger = new FileLogger();
            logger.LogWithDate($"[Exam finished] {ToString()}");
        }

        public int CorrectExam()
        {
            int totalScore = 0;
            int grade = 0;

            foreach (var pair in QuestionAnswerDictionary)
            {
                Question question = pair.Key;
                AnswerList studentAnswers = pair.Value;

                if (question.CheckAnswer(studentAnswers))
                    grade += question.Marks;

                totalScore += question.Marks;
            }

            TotalMarks = totalScore;

            return grade;
        }

        public override string ToString()
        {
            return $"Subject: {Subject.Name}, Time: {Time}, Questions: {NumberOfQuestions}, Mode: {Mode}";
        }   

        public override bool Equals(object obj)
        {
            if (obj is not Exam other)
                return false;

            return Time == other.Time &&
                   NumberOfQuestions == other.NumberOfQuestions &&
                   Subject.Name == other.Subject.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions, Subject.Name);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(Exam other)
        {
            if (other is not Exam exam)
                return 1;
            
            int timeCompare = Time.CompareTo(other.Time);

            if (timeCompare != 0)
                return timeCompare;

            return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

	public void TakeExam()
        {   
            Console.WriteLine("\n==========================================================================\n");

            Console.Write("    Are you ready to start? (y/N): ");

            string str = Console.ReadLine();
            while (str.ToLower() != "y" && str.ToLower() != "n")
            {
                Console.Write("    Are you ready to start? (y/N): ");
                str = Console.ReadLine();
            }
            
            if (str.ToLower() == "n")
                return;

            Console.WriteLine("\n==========================================================================\n");
            Console.WriteLine($"\t{Subject.Name} Practice Exam ({Questions.Count} questions) Time: {Time} minutes");
            Console.WriteLine("\n==========================================================================\n");

            Start();

            foreach (Question question in Questions)
            {
                AnswerList studentAnswers = question.TakeQuestion();
                QuestionAnswerDictionary.Add(question, studentAnswers);
                Console.WriteLine("\n==========================================================================\n");
            }

            Console.WriteLine("                       Thank you for taking the exam!");
            Console.WriteLine("\n==========================================================================\n");

            Finish();
        }   
    }
}
