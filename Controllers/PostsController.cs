using APITryitter.Context;
using APITryitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;


        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            var posts = _context.Posts.ToList();
            if (posts is null)
            {
                return NotFound();
            }
            return posts;
        }

        [HttpGet("{id:int}", Name = "ObterPost")]
        public ActionResult<Post> Get(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (post is null)
            {
                return NotFound("Post não encontrado...");
            }
            return post;
        }

        [HttpPost]
        public ActionResult Post(Post post)
        {
            if (post is null)
                return BadRequest();

            _context.Posts.Add(post);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPost",
                new { id = post.PostId }, post);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(post);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);

            if (post is null)
            {
                return NotFound("Post não localizado...");
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();

            return Ok(post);
        }
    }
}
