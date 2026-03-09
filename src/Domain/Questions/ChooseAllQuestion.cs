using System;
using System.Collections.Generic;
using System.Linq;
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
            if (studentAnswer == null || CorrectAnswer == null)
                return false;

            var parseIds = new Func<string, HashSet<int>>(s =>
            {
                var set = new HashSet<int>();
                if (string.IsNullOrWhiteSpace(s)) return set;
                foreach (var part in s.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (int.TryParse(part.Trim(), out var id)) set.Add(id);
                }
                return set;
            });

            var expected = parseIds(CorrectAnswer.Text);
            var given = parseIds(studentAnswer.Text);

            return expected.SetEquals(given);
        }

        public override void Display()
        { 
            Console.WriteLine($"Question: {Header} ({Mark} marks)");
        }
    }
}
