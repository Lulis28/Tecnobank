using System.Collections.Generic;
using System.Web.Http;
using Tecnobank.Models;
using Tecnobank.Repository.Interface;

namespace Tecnobank.ApiControllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IHttpActionResult Get()
        {
            IList<Employee> employees = new List<Employee>();
            employees = _employeeRepository.GetEmployees();

            if (employees.Count == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        public IHttpActionResult Get(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);

        }



        [HttpPost]
        public IHttpActionResult Post(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos!");
            }

            _employeeRepository.CreateEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos!");
            }

            _employeeRepository.UpdateEmployee(employee);

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Usuário inválido");
            }

            _employeeRepository.DeleteEmployee(id);

            return Ok();
        }


    }
}