using Employee_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_API.Repository
{
    public interface IEmployeesRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
        Task<Employee> GetEmployee(int id);
        Task<List<Employee>> GetEmployees();
        Task<int> UpdateEmployee(Employee employee);
    }
}