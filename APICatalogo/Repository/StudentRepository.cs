using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APICatalogo.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext contexto) : base(contexto)
        {
        }

        //public async Task<PagedList<Student>> GetStudents(StudentsParameters studentParameters)
        //{
        //    return await PagedList<Student>.ToPagedList(Get().OrderBy(on => on.Nome),
        //                       studentParameters.PageNumber,
        //                       studentParameters.PageSize);
        //}

        public async Task<IEnumerable<Student>> GetStudentsPosts()
        {
            return await Get().Include(x => x.Posts).ToListAsync();
        }
    }
}
