using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Entities;
using Yet_Another_Examination_System.Domain.Enums;
using Yet_Another_Examination_System.Domain.Questions;

namespace Yet_Another_Examination_System.Domain.Exams
{
    internal abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public Dictionary<Question, Answer> QuestionAnswerDictionary { get; set; } = new Dictionary<Question, Answer>();
        public Subject Subject { get; set; } = new Subject();
        private ExamMode _mode = ExamMode.Queued;

        public ExamMode Mode
        {
            get { return _mode; }

            set
            {
                _mode = value;
                if (_mode == ExamMode.Starting)
                {
                    Subject?.NotifyStudents(new ExamEventArgs(this, Subject));
                }
            }
        }

        public event EventHandler<ExamEventArgs> ExamStarted;

        public abstract void ShowExam();
        public abstract void CorrectExam();

        override public bool Equals(object obj)
        {
            if (obj is Exam otherExam)
            {
                return Time == otherExam.Time &&
                        NumberOfQuestions == otherExam.NumberOfQuestions &&
                        Subject.Equals(otherExam.Subject) &&
                        Mode == otherExam.Mode &&
                        Questions.SequenceEqual(otherExam.Questions); // sequence equal checks if the questions are the same in the same order using Equals method of Question class
            }
            return false;
        }
        override public int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions, Subject, Mode, Questions);
        }
        override public string ToString()
        {
            return $"Exam for {Subject.Name} with {NumberOfQuestions} questions and time limit of {Time} minutes";
        }

        public object Clone()
        {
            Exam clonedExam = (Exam)this.MemberwiseClone();
            
            clonedExam.Questions = new List<Question>(Questions); 
            
            foreach(var q in this.Questions)
            {
                clonedExam.Questions.Add((Question)q.Clone());
            }
            
            clonedExam.QuestionAnswerDictionary = new Dictionary<Question, Answer>(QuestionAnswerDictionary);
            foreach(var kvp in this.QuestionAnswerDictionary)
            {
                clonedExam.QuestionAnswerDictionary.Add((Question)kvp.Key.Clone(), (Answer)kvp.Value.Clone());
            }

            return clonedExam;
        }

        public int CompareTo(Exam? other)
        {
            if (this.Time == other.Time)
            {
                return this.NumberOfQuestions.CompareTo(other.NumberOfQuestions);
            }

            if (this.Time < other?.Time)
                return -1;
            else if (this.Time > other?.Time)
                return 1;
            else
                return 0;
        }
    }
}
