using APITryitter.Models;
using APITryitter.Pagination;

namespace APITryitter.Repository;

public interface IPostRepository : IRepository<Post>
{
    Task<PagedList<Post>> GetPosts(PostsParameters postsParameters);
    //Task<IEnumerable<Post>> GetPostsPorPreco();
}
