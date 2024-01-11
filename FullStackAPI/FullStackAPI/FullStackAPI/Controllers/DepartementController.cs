using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FullStack.Core.Dtos;
using FullStack.Core.Models;
using FullStack.Service.Filters.ActionFilter;
using FullStack.Service.Interfaces;
using FullStack.Repo.Data;

namespace FullStackAPI.Controllers
{

    [Route("api/departments")]
    [ApiController]
    public class DepartementController : BaseApiController
    {
        public DepartementController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateDepartement([FromBody] DepartementCreationDto departement)
        {
            var departementdata = _mapper.Map<Departement>(departement);
            await _repository.Departement.CreateDepartement(departementdata);
            await _repository.SaveAsync();
            var departementReturn = _mapper.Map<DepartementDto>(departementdata);
            return CreatedAtRoute("DepartementById",
                new
                {
                    departementId = departementReturn.Id
                },
                departementReturn);
        }


        [HttpGet]
        public async Task<IActionResult> GetDepartements()
        {
            try
            {
                var departements = await _repository.Departement.GetAllDepartements(trackChanges: false);
                var departementsDto = _mapper.Map<IEnumerable<DepartementDto>>(departements);
                return Ok(departementsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetDepartements)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
            finally
            {
            }
        }


        [HttpGet("{departementId}", Name = "DepartementById")]
        public async Task<IActionResult> GetDepartement(int departementId)
        {
            var departement = await _repository.Departement.GetDepartement(departementId, trackChanges: false);
            if (departement is null)
            {
                _logger.LogInfo($"Departement with id: {departementId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var departementDto = _mapper.Map<DepartementDto>(departement);
                return Ok(departementDto);
            }
        }


        [HttpPut("{departementId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateDepartementExists))]
        public async Task<IActionResult> UpdateDepartement(int departementId, [FromBody] DepartementCreationDto departement)
        {
            var departementData = HttpContext.Items["departement"] as Departement;
            _mapper.Map(departement, departementData);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
