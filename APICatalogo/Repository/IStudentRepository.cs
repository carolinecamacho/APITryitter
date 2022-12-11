using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repository;

public interface IStudentRepository : IRepository<Student>
{
    //Task<PagedList<Student>> GetStudents(StudentsParameters studentParameters);
    Task<IEnumerable<Student>> GetStudentsPosts();
}
