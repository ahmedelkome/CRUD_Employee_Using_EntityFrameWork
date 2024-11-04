using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employees.Controllers
{
    [ApiController]
    [Route("EmployeeApi")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public Employee SelectEmployee([Required] int id)
        {
            return _employee.SelectEmpoyee(id);
        }

        [HttpDelete]
        public string DeleteEmployee([Required] int id)
        {
            return _employee.DeleteEmpoyee(id);
        }

        [HttpPost]
        public Employee InsertEmployee([Required][FromBody] Employee employee)
        {
           return _employee.InsertEmpoyee(employee);
        }

        [HttpPut]
        public Employee UpdateEmployee([Required] Employee employee)
        {
            return _employee.UpdateEmpoyee( employee);
        }

    }
}
