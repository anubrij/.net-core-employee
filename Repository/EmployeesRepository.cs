using Employee_API.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Employee_API.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeesRepository(EmployeeDbContext context)
        {
            _employeeDbContext = context ?? throw new ArgumentNullException(typeof(EmployeeDbContext).Name);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var param = new SqlParameter("id", -1);
            return await _employeeDbContext.Employees.FromSqlRaw(Resource.GetEmployeesQuery, param).ToListAsync();
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var param = new SqlParameter("id", id);
            return (await _employeeDbContext.Employees.FromSqlRaw(Resource.GetEmployeesQuery, param).ToListAsync()).FirstOrDefault();
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var param = new SqlParameter("id", id);
            return await _employeeDbContext.Database.ExecuteSqlRawAsync(Resource.DeleteEmployeeCommand, param);
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("id", employee.Id),
                new SqlParameter("firstName", employee.FirstName),
                new SqlParameter("lastName", employee.LastName),
                new SqlParameter("dateOfBirth", employee.DateOfBirth),
                new SqlParameter("designation", employee.Designation),
                new SqlParameter("dateOfJoining", employee.DateOfJoining),
                new SqlParameter("CTC", employee.CTC),
            };
            return await _employeeDbContext.Database.ExecuteSqlRawAsync(Resource.UpdateEmployeeCommand, parameters.ToArray());
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var idParam = new SqlParameter("id", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter[] parameters =
            {
                new SqlParameter("firstName", employee.FirstName),
                new SqlParameter("lastName", employee.LastName),
                new SqlParameter("dateOfBirth", employee.DateOfBirth),
                new SqlParameter("designation", employee.Designation),
                new SqlParameter("dateOfJoining", employee.DateOfJoining),
                new SqlParameter("CTC", employee.CTC),
                idParam
            };
            await _employeeDbContext.Database
                .ExecuteSqlRawAsync(Resource.CreateEmployeeCommand, parameters);

            return await GetEmployee(Convert.ToInt32(idParam.Value));
        }
    }
}
