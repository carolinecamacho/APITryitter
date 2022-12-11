namespace APITryitter.Repository
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task Commit();
    }
}
