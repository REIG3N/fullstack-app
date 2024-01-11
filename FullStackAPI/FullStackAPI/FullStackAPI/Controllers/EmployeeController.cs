using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FullStack.Core.Dtos;
using FullStack.Core.Models;
using FullStack.Service.Filters.ActionFilter;
using FullStack.Service.Interfaces;


namespace FullStackAPI.Controllers
{
        [Route("api/department/{departementId}/employee")]
     [ApiController] 
    public class EmployeesController : BaseApiController
    {
        public EmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateDepartementExists))]
        public async Task<IActionResult> CreateEmployeeForDepartement(int departementId, [FromBody] EmployeeCreationDto employee)
        {
            var employeeData = _mapper.Map<Employee>(employee);
            await _repository.Employee.CreateEmployeeForDepartement(departementId, employeeData);
            await _repository.SaveAsync();
            var employeeReturn = _mapper.Map<EmployeeDto>(employeeData);
            return Ok(employeeReturn);
        }


        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateEmployeeExistsForDepartement))]
        public async Task<IActionResult> UpdateEmployeeForDepartement(int departementId, int id, [FromBody] EmployeeUpdateDto employee)
        {
            var employeeData = HttpContext.Items["employee"] as Employee;
            _mapper.Map(employee, employeeData);
            await _repository.SaveAsync();
            return NoContent();
        }


        [HttpGet]
        [ServiceFilter(typeof(ValidateEmployeeExistsForDepartement))]
        public async Task<IActionResult> GetEmployee(int departementId, int employeeId)
        {
            try
            {
                var employee = await _repository.Employee.GetEmployee(departementId, employeeId, trackChanges: false);
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetEmployee)} action {ex}");
                return StatusCode(500, $"Something went wrong in the {nameof(GetEmployee)} action {ex}");
            }
        }
        [HttpGet]
        [ServiceFilter(typeof(ValidateDepartementExists))]
        public async Task<IActionResult> GetEmployeesByDepartment(int departmentId)
        {
            try
            {
                var employees = await _repository.Employee.GetEmployeesByDepartment(departmentId, trackChanges: false);
                var employeeDtos = employees.Select(e => _mapper.Map<EmployeeDto>(e)).ToList();
                return Ok(employeeDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetEmployeesByDepartment)} action: {ex}");
                return StatusCode(500, $"Something went wrong in the {nameof(GetEmployeesByDepartment)} action: {ex}");
            }
        }



    }
}
