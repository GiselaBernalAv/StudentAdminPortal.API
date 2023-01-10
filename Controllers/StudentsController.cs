using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;   

        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetStudents();
            //var studentsDTO = IActionResultTypeMapper.map
            return Ok(_mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("GetStudentbyid/{id:guid}")]

        public async Task<IActionResult> GetStudentbyId([FromRoute] Guid id)
        {
            var student = await _studentRepository.GetStudentbyId(id);

            if(student == null)
                return NotFound();

            return Ok(_mapper.Map<Student>(student));
        }
    }
}
