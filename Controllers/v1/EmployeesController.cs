using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_API.Repository;
using Employee_API.Model;
using Serilog;
using Employee_API.Helper;
using System.Net;

namespace Employee_API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected readonly IEmployeesRepository _repository;
        protected readonly ILogger _logger;

        public EmployeesController(IEmployeesRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Employee>>> GetEmployees()
        {
            _logger.Information("Get Employee Callled");
            return ApiResponse<IEnumerable<Employee>>.CreateSuccessResponse(HttpStatusCode.OK, (await _repository.GetEmployees()));
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Employee>> GetEmployee(int id)
        {
            _logger.Information("Get Employee with id callled");
            var employee = await _repository.GetEmployee(id);

            if (employee == null)
            {
                return ApiResponse<Employee>.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id {id} not found");
            }

            return ApiResponse<Employee>.CreateSuccessResponse(HttpStatusCode.OK, employee);
        }

        [HttpPost]
        public async Task<ApiResponse<Employee>> PostEmployee(Employee employee)
        {

            employee = await _repository.CreateEmployee(employee);
            _logger.Information($"new employee {employee.FirstName} {employee.LastName} has been created");
            return ApiResponse<Employee>.CreateSuccessResponse(HttpStatusCode.Created, employee);
        }

    }
}
