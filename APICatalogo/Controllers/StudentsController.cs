using APITryitter.DTOs;
using APITryitter.Models;
using APITryitter.Pagination;
using APITryitter.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace APITryitter.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[EnableCors("PermitirApiRequest")]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public StudentsController(IUnitOfWork contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }

        [HttpGet("posts")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsPosts()
        {
            var students = await _context.StudentRepository
                            .GetStudentsPosts();

            var studentsDto = _mapper.Map<List<Student>>(students);
            return studentsDto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>>
            Get([FromQuery] StudentsParameters studentsParameters)
        {
            var students = await _context.StudentRepository.
                                GetStudents(studentsParameters);

            var metadata = new
            {
                students.TotalCount,
                students.PageSize,
                students.CurrentPage,
                students.TotalPages,
                students.HasNext,
                students.HasPrevious
            };

           Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

           var studentsDto = _mapper.Map<List<StudentDTO>>(students);
           return studentsDto;
       }

        [HttpGet("{id}", Name = "ObterStudent")]
        //[EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<StudentDTO>> Get(int id)
        {
            var student = await _context.StudentRepository
                             .GetById(p => p.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return studentDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Student studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            _context.StudentRepository.Add(student);
            await _context.Commit();

            var studentDTO = _mapper.Map<Student>(student);

            return new CreatedAtRouteResult("ObterStudent",
                new { id = student.StudentId }, studentDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentDTO studentDto)
        {
            if (id != studentDto.StudentId)
            {
                return BadRequest();
            }

            var student = _mapper.Map<Student>(studentDto);

            _context.StudentRepository.Update(student);
            await _context.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDTO>> Delete(int id)
        {
            var student = await _context.StudentRepository
                            .GetById(p => p.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }
            _context.StudentRepository.Delete(student);
            await _context.Commit();

            var studentDto = _mapper.Map<StudentDTO>(student);

            return studentDto;
        }
    }
}
