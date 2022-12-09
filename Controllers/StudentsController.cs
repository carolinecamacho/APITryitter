using APITryitter.Context;
using APITryitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}/posts")]
        public ActionResult<List<Post>> GetPostsByStudent(int id)
        {
            try
            {
                 return _context.Posts.Where(p => p.StudentId == id).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}/last")]
        public ActionResult<Post> GetPostsByStudentLast(int id)
        {
            try
            {
                var allPosts = _context.Posts.Where(p => p.StudentId == id).ToList();
                return allPosts.Last();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("posts")]
        public ActionResult<IEnumerable<Student>> GetStudentsPosts()
        {
            try
            {
                return _context.Students.Include(p => p.Posts).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _context.Students.AsNoTracking().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterAluno")]
        public ActionResult<Student> Get(int id)
        {
            var student = _context.Students.FirstOrDefault(p => p.StudentId == id);

            if (student == null)
            {
                return NotFound("Aluno não encontrado...");
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult Post(Student student)
        {
            if (student is null)
                return BadRequest();

            _context.Students.Add(student);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterAluno",
                new { id = student.StudentId }, student);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(p => p.StudentId == id);

            if (student == null)
            {
                return NotFound("Aluno não encontrado...");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok(student);
        }
    }

}
