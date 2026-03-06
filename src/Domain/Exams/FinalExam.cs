using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Entities;

namespace Yet_Another_Examination_System.Domain.Exams
{
    internal class FinalExam : Exam
    {
        public override void CorrectExam()
        {
            if (QuestionAnswerDictionary == null || QuestionAnswerDictionary.Count == 0)
            {
                Console.WriteLine("No student answers to correct.");
                return;
            }

            Console.WriteLine(new string('=', 40));
            Console.WriteLine("Final Exam Correction: Student Answers (no correct answers shown)");

            int qIndex = 1;

            foreach (var q in Questions)
            {
                Console.WriteLine($"Question {qIndex++}: {q.Header} ({q.Mark} marks)");
                QuestionAnswerDictionary.TryGetValue(q, out Answer studentAnswer);
                Console.WriteLine($"Student's Answer: {(studentAnswer != null ? studentAnswer.ToString() : "No answer")}");
                Console.WriteLine();
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam: {Subject?.Name ?? "Unknown Subject"} - Mode: {Mode}");
            Console.WriteLine($"Time: {Time} minutes | Questions: {NumberOfQuestions}");
            Console.WriteLine(new string('=', 40));

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
