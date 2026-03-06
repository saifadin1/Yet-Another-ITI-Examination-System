using Yet_Another_Examination_System.Domain.Entities;
using Yet_Another_Examination_System.Domain.Exams;

namespace Yet_Another_Examination_System
{
    internal class ExamEventArgs : EventArgs
    {
        public ExamEventArgs(Exam e, Subject s) { Exam = e; Subject = s; }
        public Subject Subject { get; }
        public Exam Exam { get; }

    }
}