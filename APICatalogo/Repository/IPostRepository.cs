using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repository;

public interface IPostRepository : IRepository<Post>
{
    Task<PagedList<Post>> GetPosts(PostsParameters postsParameters);
    //Task<IEnumerable<Post>> GetPostsPorPreco();
}
