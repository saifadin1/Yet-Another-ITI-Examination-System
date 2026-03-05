using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Entities;

namespace Yet_Another_Examination_System.Domain.Questions
{
    internal class TrueFalseQuestion : Question
    {
        public override bool CheckAnswer(Answer studentAnswer)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
