using System;

namespace Examination.Src
{
    public class Subject
    {
        public string Name { get; }
        public List<Student> EnrolledStudents;
        public Subject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.");
            
            Name = name;
            EnrolledStudents = new List<Student>();
        }

        public bool Enroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Answer cannot be null.");

            if (EnrolledStudents.Contains(student))
                return false;

            EnrolledStudents.Add(student);

            // subscribe? to event
            // Exam.ExamStarted += student.OnExamStarted;

            return true;
        }

        public void NotifyStudents(object sender, ExamEventArgs e)
        {
            foreach (var student in EnrolledStudents)
            {
                student.OnExamStarted(sender, e);
            }
        }

        public override string ToString()
        {
            return $"{Name} - {EnrolledStudents.Count} students enrolled";
        }

        public static Subject GenerateMathSubject()
        {
            Subject math = new Subject("Mathematics");

            var students = Student.GenerateStudents();

            foreach (var student in students)
            {
                math.Enroll(student);
            }
            
            return math;
        }
    }
}