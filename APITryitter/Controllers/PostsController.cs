using APITryitter.DTOs;
using APITryitter.Models;
using APITryitter.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace APITryitter.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[Controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public PostsController(IUnitOfWork contexto, IMapper mapper)
        {
            _uof = contexto;
            _mapper = mapper;
        }

        //[HttpGet("menorpreco")]
        //public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostsPrecos()
        //{
        //    var posts = await _uof.PostRepository.GetPostsPorPreco();
        //    var postsDto = _mapper.Map<List<PostDTO>>(posts);

        //    return postsDto;
        //}

        // api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> Get()
        {
            var posts = await _uof.PostRepository.Get().ToListAsync();

            var postsDto = _mapper.Map<List<PostDTO>>(posts);
            return postsDto;
        }

        // api/posts/1
        [HttpGet("{id}", Name = "ObterPost")]
        public async Task<ActionResult<PostDTO>> Get(int id)
        {
            var post = await _uof.PostRepository.GetById(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            var postDto = _mapper.Map<PostDTO>(post);
            return postDto;
        }

        //  api/posts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            _uof.PostRepository.Add(post);
            await _uof.Commit();

            var postDTO = _mapper.Map<PostDTO>(post);

            return new CreatedAtRouteResult("ObterPost",
               new { id = post.PostId }, postDTO);
        }

        // api/posts/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostDTO postDto)
        {
            if (id != postDto.PostId)
            {
                return BadRequest();
            }

            var post = _mapper.Map<Post>(postDto);

            _uof.PostRepository.Update(post);

            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostDTO>> Delete(int id)
        {
            var post = await _uof.PostRepository.GetById(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            _uof.PostRepository.Delete(post);
            await _uof.Commit();

            var postDto = _mapper.Map<PostDTO>(post);

            return postDto;
        }
    }
}
