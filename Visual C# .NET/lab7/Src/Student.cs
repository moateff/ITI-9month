using System;

namespace Examination.Src
{
    public class Student
    {
        public string Name { get; }
        public int Id { get; }

        public Student(int id, string name)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
                
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.");

            Name = name;
            Id = id;
        }

        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            if (sender is not Exam exam)
                return;
            
            FileLogger logger = new FileLogger();
            logger.LogWithDate($"{ToString()} notified: Exam for {e.Subject.Name} started at {DateTime.Now}.");
        }

        public override string ToString()
        {
            return $"Student {Name} (ID:{Id})";
        }

        public static List<Student> GenerateStudents()
        {
            var students = new List<Student>();

            students.Add(new Student(1, "Alice"));
            students.Add(new Student(2, "Bob"));
            students.Add(new Student(3, "Charlie"));
            students.Add(new Student(4, "David"));
            students.Add(new Student(5, "Eve"));
            students.Add(new Student(6, "Fiona"));
            students.Add(new Student(7, "Grace"));
            students.Add(new Student(8, "Helen"));
            students.Add(new Student(9, "Ivy"));
            students.Add(new Student(10, "Jack"));
        
            return students;
        }
    }
}