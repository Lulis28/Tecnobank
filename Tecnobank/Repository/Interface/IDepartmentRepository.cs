using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnobank.Models;

namespace Tecnobank.Repository.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();
        Department GetDepartmentById(int id);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }
}
