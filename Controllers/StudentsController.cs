using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System;

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
        [Route("GetStudentbyid/{id:guid}"), ActionName("GetStudentbyId")]

        public async Task<IActionResult> GetStudentbyId([FromRoute] Guid id)
        {
            var student = await _studentRepository.GetStudentbyId(id);

            if(student == null)
                return NotFound();

            //return Ok(_mapper.Map<Student>(student));
            return new ObjectResult(_mapper.Map<Student>(student)) {StatusCode = 200};
        }

        [HttpPut]
        [Route("UpdateStudent/{id:guid}")]

        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id,
            [FromBody] UpdateStudentRequest studentRequest)
        {
            var modifiedstudent = await _studentRepository.ModifyStudent(id, _mapper.Map<Models.Student>(studentRequest));
            if(modifiedstudent != null)
            {
                return Ok(_mapper.Map<Student>(modifiedstudent));
            }


            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteStudent/{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var deletedStudent = await _studentRepository.DeleteStudent(id);
            if(deletedStudent != null)
            {
                return Ok();
            }

            return NotFound();

        }

        [HttpPost]  
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
            var student = await _studentRepository.AddStudent(_mapper.Map<Models.Student>(request));

            return CreatedAtAction(nameof(GetStudentbyId), new { id = student.Id },
               _mapper.Map<Student>(student));

           // return CreatedAtAction()
        }

    }
}
