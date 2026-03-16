
using System;

namespace Examination.Src
{
    public class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }

        public ExamEventArgs(Subject subject, Exam exam)
        {
            if (subject == null)
                throw new ArgumentNullException(nameof(subject));
            if (exam == null)
                throw new ArgumentNullException(nameof(exam));
                
            Subject = subject;
            Exam = exam;
        }
    }
}