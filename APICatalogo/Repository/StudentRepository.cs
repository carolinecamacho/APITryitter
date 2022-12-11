using APITryitter.Context;
using APITryitter.Models;
using APITryitter.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APITryitter.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public async Task<PagedList<Student>> GetStudents(StudentsParameters studentParameters)
        {
            return await PagedList<Student>.ToPagedList(Get().OrderBy(on => on.Name),
                               studentParameters.PageNumber,
                               studentParameters.PageSize);
        }

        public async Task<IEnumerable<Student>> GetStudentsPosts()
        {
            return await Get().Include(x => x.Posts).ToListAsync();
        }
    }
}
