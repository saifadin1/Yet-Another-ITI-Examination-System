using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Entities;

namespace Yet_Another_Examination_System.Domain.Questions
{
    internal class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string body, int mark, string header, Answer correctAnswer) : base(body, mark, header, correctAnswer)
        {
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer);
        }

        public override void Display()
        { 
            Console.WriteLine($"Question: {Header} ({Mark} marks)");
        }
    }
}
