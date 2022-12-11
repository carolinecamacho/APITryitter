using APITryitter.Models;
using APITryitter.Pagination;

namespace APITryitter.Repository;

public interface IStudentRepository : IRepository<Student>
{
    Task<PagedList<Student>> GetStudents(StudentsParameters studentParameters);
    Task<IEnumerable<Student>> GetStudentsPosts();
}
