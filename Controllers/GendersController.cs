using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderRepository _studentRepository;
        private readonly IMapper _mapper;

        public GendersController(IGenderRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAllGenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _studentRepository.GetAllGenders();
            //var studentsDTO = IActionResultTypeMapper.map

            if (genders ==null || !genders.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<Gender>>(genders));
        }
    }
}
