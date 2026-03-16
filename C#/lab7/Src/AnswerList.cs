using System;
using System.Collections;
using System.Collections.Generic;

namespace Examination.Src
{
    public class AnswerList : ICloneable, IEnumerable<Answer>
    {
        private readonly List<Answer> _answers = new List<Answer>();
        public int Count => _answers.Count;

        public bool Add(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer), "Answer cannot be null.");

            if (_answers.Contains(answer))
                return false;

            _answers.Add(answer);
            return true;
        }

        public Answer GetById(int id)
        {
            return _answers.Find(a => a.Id == id);
        }

        public Answer this[int index]
        {
            get
            {
                if (index < 0 || index >= _answers.Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                
                return _answers[index];
            }
        }

        override public string ToString()
        {
            return string.Join(Environment.NewLine, _answers);
        }

        public object Clone()
        {
            AnswerList copy = new AnswerList();

            for (int i = 0; i < _answers.Count; i++)
                copy.Add(_answers[i]);

            return copy;
        }

        public IEnumerator<Answer> GetEnumerator()
        {
            return _answers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}