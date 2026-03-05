using System;
using System.Collections.Generic;
using System.Text;

namespace Yet_Another_Examination_System.Domain.Entities
{
    internal class Answer : IComparable<Answer>, ICloneable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return $"Answer {Id}: {Text}";
        }
        override public bool Equals(object obj)
        {
            if (obj is Answer otherAnswer)
            {
                return Id == otherAnswer.Id && Text == otherAnswer.Text;
            }
            return false;
        }

        override public int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }

        public int CompareTo(Answer? other)
        {
            if (other == null) return 1;
            return Id.CompareTo(other.Id);
        }

        public object Clone()
        {
            return (Answer)this.MemberwiseClone();
        }
    }
}
