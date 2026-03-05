namespace Yet_Another_Examination_System.Domain.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public void OnExamStarted(object sender, ExamEventArgs e)
        {

        }
    }
}