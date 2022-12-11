using APITryitter.Context;

namespace APITryitter.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PostRepository _postRepo;
        private StudentRepository _studentRepo;
        public AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepo = _postRepo ?? new PostRepository(_context);
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                return _studentRepo = _studentRepo ?? new StudentRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
