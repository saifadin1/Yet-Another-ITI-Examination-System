using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Entities;

namespace Yet_Another_Examination_System.Domain.Collections
{
    internal class AnswerList : ICloneable
    {
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int Count { get; set; } = 0;

        public void AddAnswer(Answer answer)
        {
            Answers.Add(answer);
            Count++;
        }   

        public Answer GetAnswerById(int id)
        {
            return Answers.Find(a => a.Id == id);
        }

        public object Clone()
        {
            var clone = new AnswerList() { Count = this.Count};
            foreach (var answer in Answers)
            {
                clone.AddAnswer((Answer)answer.Clone());
            }
            return clone;
        }

        public Answer this[int index]
        {
            get 
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return Answers[index]; 
            }
        }

    }
}
