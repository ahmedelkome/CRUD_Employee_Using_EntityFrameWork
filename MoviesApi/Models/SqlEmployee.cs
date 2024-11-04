using Employees.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class SqlEmployee : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public SqlEmployee(ApplicationDbContext context)
        {
            _context = context;
        }
        public string DeleteEmpoyee(int id)
        {
            if (id > 0)
            {
                var employee = _context.Employees.Find(id);
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return "Delete Successfully";
            }
            else
            {
                return "Can't Find Employee Please Enter Valid Id";
            }
        }


        public Employee InsertEmpoyee([Required][FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;

        }

        public Employee SelectEmpoyee(int id)
        {
            Employee employee = new Employee();
            if (id > 0)
            {
                var result = _context.Employees.Where(emp => emp.id == id).ToList();
                _context.SaveChanges();
                foreach (var emp in result)
                {
                    employee = emp;
                }

            }
            return employee;
        }

        public Employee UpdateEmpoyee(Employee employee)
        {

            var id = employee.id;
            if (id != null)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return employee ;
            }
            else
            {
                return null;
            }

        }
    }
}
