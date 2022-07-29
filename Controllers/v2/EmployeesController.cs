using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_API.Model;
using Employee_API.Repository;
using Serilog;
using Employee_API.Helper;
using System.Net;

namespace Employee_API.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : v1.EmployeesController
    {
        public EmployeesController(IEmployeesRepository repository, ILogger logger) : base(repository, logger) { }
        

        [HttpPut("{id}")]
        public async Task<ApiResponse<Employee>> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return ApiResponse<Employee>.CreateErrorResponse(HttpStatusCode.BadRequest, $"id parameter {id} is not matching with payload id {employee.Id}");
            }

            try
            {
                await _repository.UpdateEmployee(employee);
                _logger.Information($"employee {employee.FirstName} {employee.LastName} has been updated");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return ApiResponse<Employee>.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id {id} not found");
                }
                else
                {
                    throw;
                }
            }

            return ApiResponse<Employee>.CreateSuccessResponse(HttpStatusCode.OK, null);
        }
        
        [HttpDelete("{id}")]
        public async Task<ApiResponse<Employee>> DeleteEmployee(int id)
        {
            await _repository.DeleteEmployee(id);
            _logger.Information($"employee {id.ToString()} has been deleted");
            return ApiResponse<Employee>.CreateSuccessResponse(HttpStatusCode.OK, null);
        }

        private bool EmployeeExists(int id)
        {
            return _repository.GetEmployee(id) != null;
        }
    }
}
