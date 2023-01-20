namespace EmployeesDapper.Model
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string CodEmployee { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }   
        public DateTime EntryDate { get; set; }
        public DateTime? DepartureDate { get; set;}

    }
}
