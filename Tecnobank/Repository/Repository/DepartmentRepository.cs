using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tecnobank.Models;
using Tecnobank.Repository.Interface;

namespace Tecnobank.Repository.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string ConnectionString = string.Empty;

        public DepartmentRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public void CreateDepartment(Department department)
        {
            string sqlQuery = "EXEC DEPARTMENT_INSERT @name= '" + department.Name + "'";

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            var commandResult = command.ExecuteScalar();

            command.Dispose();
            connection.Close();
            connection.Dispose();
        }

        public void DeleteDepartment(int id)
        {
            string sqlQuery = "EXEC DEPARTMENT_DELETE @id = " + id;

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

        public Department GetDepartmentById(int id)
        {
            Department department = new Department();

            string sqlQuery = "EXEC DEPARTMENT_SELECT_ID @id = " + id;

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
                    department.Id = (int)dataReader["id"];
                    department.Name = (string)dataReader["Name"];
                }
            }

            return department;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string sqlQuery = "EXEC DEPARTMENT_SELECT_ALL";

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Department department = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    department = new Department
                    {
                        Id = (int)dataReader["id"],
                        Name = (string)dataReader["Name"]
                    };

                    departments.Add(department);

                }
            }

            return departments;
        }

        public void UpdateDepartment(Department department)
        {
            string sqlQuery = "EXEC DEPARTMENT_UPDATE @name= '" + department.Name + "', @id = " + department.Id;

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            var commandResult = command.ExecuteScalar();

            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}