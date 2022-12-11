using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(AppDbContext contexto) : base(contexto)
    {
    }

    public async Task<PagedList<Post>> GetPosts(PostsParameters postsParameters)
    {

        return await PagedList<Post>.ToPagedList(Get().OrderBy(on => on.PostId),
            postsParameters.PageNumber, postsParameters.PageSize);
    }

    //public async Task<IEnumerable<Post>> GetPostsPorPreco()
    //{
    //    return await Get().OrderBy(c => c.Preco).ToListAsync();
    //}
}
