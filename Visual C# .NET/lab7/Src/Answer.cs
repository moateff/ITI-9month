using System;

namespace Examination.Src
{
    public class Answer : IComparable<Answer>, ICloneable
    {
        public int Id { get; }
        public string Text { get; }

        public Answer(int id, string text)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be null or empty.");

            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return $"    {Id}) {Text}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Answer other)
                return false;
            
            return Id == other.Id && 
                string.Equals(Text, other.Text, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }

        public int CompareTo(Answer other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }

        public object Clone()
        {
            var copy = new Answer(Id, Text);
            return copy;
        }
    }
}