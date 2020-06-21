using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tecnobank.Models;
using Tecnobank.Repository.Interface;

namespace Tecnobank.ApiControllers
{
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IHttpActionResult Get()
        {
            IList<Department> departments = new List<Department>();
            departments = _departmentRepository.GetDepartments();

            if (departments.Count == 0)
            {
                return NotFound();
            }

            return Ok(departments);
        }

        public IHttpActionResult Get(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);

        }



        [HttpPost]
        public IHttpActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos!");
            }

            _departmentRepository.CreateDepartment(department);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos!");
            }

            _departmentRepository.UpdateDepartment(department);

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Usuário inválido");
            }

            _departmentRepository.DeleteDepartment(id);

            return Ok();
        }
    }
}
