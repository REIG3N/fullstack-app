using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FullStack.Core.Models;
using FullStack.Service.Interfaces;

namespace FullStack.Service.Filters.ActionFilter
{
    public class ValidateEmployeeExistsForDepartement : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateEmployeeExistsForDepartement(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository; _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = method.Equals("PUT") ? true : false;

            var departementId = (int)context.ActionArguments["departementId"];
            var departement = await _repository.Departement.GetDepartement(departementId, false);

            if (departement is null)
            {
                _logger.LogInfo($"departement with id: {departementId} doesn't exist in the database.");
                var response = new ObjectResult(new ResponseModel
                {
                    StatusCode = 404,
                    Message = $"Departement with id: {departementId} doesn't exist in the database."
                });
                context.Result = response;
                return;
            }
            var id = (int)context.ActionArguments[context.ActionArguments.Keys.Where(x => x.Equals("id") || x.Equals("employeeId")).SingleOrDefault()];
            var employee = await _repository.Employee.GetEmployee(departementId, id, trackChanges);

            if (employee == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                var response = new ObjectResult(new ResponseModel
                {
                    StatusCode = 404,
                    Message = $"Employee with id: {id} doesn't exist in the database."
                });
                context.Result = response;
            }
            else
            {
                context.HttpContext.Items.Add("employee", employee);
                await next();
            }
        }
    }
}
