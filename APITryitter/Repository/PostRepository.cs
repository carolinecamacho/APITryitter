using APITryitter.Context;
using APITryitter.Models;
using APITryitter.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APITryitter.Repository;

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
