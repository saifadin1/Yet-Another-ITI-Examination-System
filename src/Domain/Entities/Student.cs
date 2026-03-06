namespace Yet_Another_Examination_System.Domain.Entities
{
    internal class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"Student {Name} with ID {Id} has started the exam for {e.Subject.Name}");
        }
    }
}