using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Entities;

namespace Yet_Another_Examination_System.Domain.Exams
{
    internal class PracticeExam : Exam
    {
        public override void CorrectExam()
        {
            if (QuestionAnswerDictionary == null || QuestionAnswerDictionary.Count == 0)
            {
                Console.WriteLine("No student answers to correct.");
                return;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Practice Exam Correction: Student Answers vs Correct Answers");

            int qIndex = 1;
            int totalMarks = 0;
            int obtainedMarks = 0;

            foreach (var q in Questions)
            {
                Console.WriteLine($"Question {qIndex++}: {q.Header} ({q.Mark} marks)");

                QuestionAnswerDictionary.TryGetValue(q, out Answer studentAnswer);

                Console.WriteLine($"Student's Answer: {(studentAnswer != null ? studentAnswer.ToString() : "No answer")}");
                Console.WriteLine($"Correct Answer: {(q.CorrectAnswer != null ? q.CorrectAnswer.ToString() : "Not provided")}");

                totalMarks += q.Mark;
                if (studentAnswer != null && q.CorrectAnswer != null && studentAnswer.Equals(q.CorrectAnswer))
                {
                    obtainedMarks += q.Mark;
                }

                Console.WriteLine();
            }

            double percent = totalMarks > 0 ? (obtainedMarks * 100.0 / totalMarks) : 0;
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Final Grade: {obtainedMarks}/{totalMarks} ({percent:F2}%)");
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Practice Exam: {Subject?.Name ?? "Unknown Subject"} - Mode: {Mode}");
            Console.WriteLine($"Time: {Time} minutes | Questions: {NumberOfQuestions}");
            Console.WriteLine(new string('-', 40));

            int index = 1;
            foreach (var q in Questions)
            {
                Console.WriteLine($"Question {index++}: {q.Header} ({q.Mark} marks)");
                Console.WriteLine(q.Body);

                if (q.Answers != null && q.Answers.Count > 0)
                {
                    foreach (var a in q.Answers.Answers)
                    {
                        Console.WriteLine(a.ToString());
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
