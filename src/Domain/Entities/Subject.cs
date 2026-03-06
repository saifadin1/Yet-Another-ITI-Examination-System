namespace Yet_Another_Examination_System.Domain.Entities
{
    internal class Subject
    {
        public string Name { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public void Enroll(Student stu)
        {
            ExamStarted += stu.OnExamStarted;
            EnrolledStudents.Add(stu);
        }

        public event EventHandler<ExamEventArgs> ExamStarted;

        public void NotifyStudents(ExamEventArgs e)
        {
            ExamStarted?.Invoke(this, e);
        }
    }
}