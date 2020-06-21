using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Tecnobank.Models;
using Tecnobank.Repository.Interface;


namespace Tecnobank.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string ConnectionString = string.Empty;

        public EmployeeRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string sqlQuery = "EXEC EMPLOYEE_SELECT_ALL";

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Employee employee = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    employee = new Employee
                    {
                        Id = (int)dataReader["id"],
                        Name = (string)dataReader["Name"],
                        Email = (string)dataReader["Email"],
                        DepartmentId = (int)dataReader["DepartmentId"]
                    };
                    employee.Department.Id = (int)dataReader["DepartmentId"];
                    employee.Department.Name = (string)dataReader["DepartmentName"];

                    employees.Add(employee);

                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();

            string sqlQuery = "EXEC EMPLOYEE_SELECT_ID @id = " + id;

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    employee.Id = (int)dataReader["id"];
                    employee.Name = (string)dataReader["Name"];
                    employee.Email = (string)dataReader["Email"];
                    employee.DepartmentId = (int)dataReader["IdDepartament"];
                }
            }

            return employee;
        }

        public void CreateEmployee(Employee employee)
        {

            string sqlQuery = "EXEC EMPLOYEE_INSERT @name= '" + employee.Name + "', @email= '" + employee.Email + "', @departamentid= " + employee.DepartmentId;

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            var commandResult = command.ExecuteScalar();

            command.Dispose();
            connection.Close();
            connection.Dispose();

        }

        public void UpdateEmployee(Employee employee)
        {
            string sqlQuery = "EXEC EMPLOYEE_UPDATE @name= '" + employee.Name + "', @email= '" + employee.Email + "', @departamentid= " + employee.DepartmentId + ", @id= " + employee.Id;

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            var commandResult = command.ExecuteScalar();

            command.Dispose();
            connection.Close();
            connection.Dispose();
        }

        public void DeleteEmployee(int id)
        {
            string sqlQuery = "EXEC EMPLOYEE_DELETE @id = " + id;

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            command.ExecuteNonQuery();

            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}