namespace Employees.Models
{
    public interface IEmployee
    {
        public Employee SelectEmpoyee(int id);
        public Employee UpdateEmpoyee( Employee employee);
        public Employee InsertEmpoyee(Employee employee);
        public string DeleteEmpoyee(int id);
    }
}
