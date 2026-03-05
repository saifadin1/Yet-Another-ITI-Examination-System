namespace Yet_Another_Examination_System.Domain.Entities
{
    public class Subject
    {
        public string Name { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public void Enroll(Student stu)
        {
            EnrolledStudents.Add(stu);
        }

        public void NotifyStudents()
        {

        }
    }
}