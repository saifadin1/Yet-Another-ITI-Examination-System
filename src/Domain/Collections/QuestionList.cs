using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Questions;

namespace Yet_Another_Examination_System.Domain.Collections
{
    internal class QuestionList : List<Question>
    {
        private readonly string filePath;
        public QuestionList(string filePath)
        {
            this.filePath = filePath;
        }
        public void Add(Question question)
        {
            base.Add(question);
            LogQuestionDetails(question);
        }

        private void LogQuestionDetails(Question question)
        {
            using (var writer = new System.IO.StreamWriter(filePath, true))
            {
                writer.WriteLine($"Question Added: {question.Header}");
                writer.WriteLine($"Body: {question.Body}");
                writer.WriteLine($"Mark: {question.Mark}");
                writer.WriteLine($"Correct Answer: {question.CorrectAnswer}");
                writer.WriteLine("-----");
            }
        }


    }
}
