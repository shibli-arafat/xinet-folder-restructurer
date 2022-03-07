namespace ConsoleApp1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Employee Manager { get; set; }
    }
}
