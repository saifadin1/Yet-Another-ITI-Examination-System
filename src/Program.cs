using System;
using Yet_Another_Examination_System.Domain.Entities;
using Yet_Another_Examination_System.Domain.Exams;
using Yet_Another_Examination_System.Domain.Questions;
using Yet_Another_Examination_System.Domain.Collections;
using Yet_Another_Examination_System.Domain.Enums;

namespace Yet_Another_Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory("log");

            var practiceQuestionList = new Yet_Another_Examination_System.Domain.Collections.QuestionList("log/practice_questions.log");
            var finalQuestionList = new Yet_Another_Examination_System.Domain.Collections.QuestionList("log/final_questions.log");

            var math = new Subject { Name = "Mathematics" };

            var alice = new Student { Id = 1, Name = "Alice" };
            var bob = new Student { Id = 2, Name = "Bob" };
            math.Enroll(alice);
            math.Enroll(bob);

            var practice = new PracticeExam
            {
                Subject = math,
                Time = 30,
                Mode = ExamMode.Queued
            };

            var p1Answers = new AnswerList();
            p1Answers.AddAnswer(new Answer { Id = 1, Text = "2" });
            p1Answers.AddAnswer(new Answer { Id = 2, Text = "4" });
            p1Answers.AddAnswer(new Answer { Id = 3, Text = "6" });

            var p1 = new ChooseOneQuestion("What is 2+2?", 5, "Simple addition", p1Answers.GetAnswerById(2));
            p1.Answers = p1Answers;
            
            
            var p2Answers = new AnswerList();
            p2Answers.AddAnswer(new Answer { Id = 1, Text = "3" });
            p2Answers.AddAnswer(new Answer { Id = 2, Text = "5" });
            p2Answers.AddAnswer(new Answer { Id = 3, Text = "7" });

            var p2 = new ChooseOneQuestion("What is 2+3?", 5, "Simple addition 2", p2Answers.GetAnswerById(2));
            p2.Answers = p2Answers;

            practice.Questions.Add(p1);
            practiceQuestionList.Add(p1);
            practice.Questions.Add(p2);
            practiceQuestionList.Add(p2);
            practice.NumberOfQuestions = practice.Questions.Count;

            practice.QuestionAnswerDictionary[p1] = p1Answers.GetAnswerById(2);
            practice.QuestionAnswerDictionary[p2] = p2Answers.GetAnswerById(1); 

            Console.WriteLine();
            Console.WriteLine(new string('*', 60));
            Console.WriteLine();

            var final = new FinalExam
            {
                Subject = math,
                Time = 60,
                Mode = ExamMode.Queued
            };

            var f1Answers = new AnswerList();
            f1Answers.AddAnswer(new Answer { Id = 1, Text = "True" });
            f1Answers.AddAnswer(new Answer { Id = 2, Text = "False" });

            var f1 = new ChooseOneQuestion("The earth is flat.", 10, "True/False", f1Answers.GetAnswerById(2));
            f1.Answers = f1Answers;

            final.Questions.Add(f1);
            finalQuestionList.Add(f1);
            final.NumberOfQuestions = final.Questions.Count;

            final.QuestionAnswerDictionary[f1] = f1Answers.GetAnswerById(1); 

            // Ask user which exam to start
            Console.WriteLine("Select Exam Type:\n1 - Practice\n2 - Final");
            var key = Console.ReadKey(true);
            Console.WriteLine();

            if (key.KeyChar == '1')
            {
                Console.WriteLine("Starting Practice Exam...\n");
                practice.Mode = ExamMode.Starting; 
                practice.ShowExam();
                Console.WriteLine("--- End of Practice Exam ---\n");
                practice.Mode = ExamMode.Finished;
                practice.CorrectExam();
            }
            else if (key.KeyChar == '2')
            {
                Console.WriteLine("Starting Final Exam...\n");
                final.Mode = ExamMode.Starting; 
                final.ShowExam();
                Console.WriteLine("--- End of Final Exam ---\n");
                final.Mode = ExamMode.Finished;
                final.CorrectExam();
            }
            else
            {
                Console.WriteLine("Invalid selection. Exiting.");
            }

            Console.WriteLine("Testing complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
