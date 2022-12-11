using APITryitter.Context;
using APITryitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITryitterxUnitTests
{
    internal class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        { }
        public void Seed(AppDbContext context)
        {
            context.Students.Add
            (new Student { StudentId = 1, Name = "Carol", Email = "caroline@xpi.com.br", Modulo = "4", Status= "online", Password = "Abc123456!" });

            context.Students.Add
            (new Student { StudentId = 2, Name = "Lucia", Email = "lucia@xpi.com.br", Modulo = "1", Status = "online", Password = "Abc123456!" });
            
            context.Students.Add
            (new Student { StudentId = 3, Name = "Isabela", Email = "isabela@xpi.com.br", Modulo = "2", Status = "online", Password = "Abc123456!" });
            
            context.Students.Add
            (new Student { StudentId = 4, Name = "Lucas", Email = "lucas@xpi.com.br", Modulo = "3", Status = "online", Password = "Abc123456!" });
            
            context.Students.Add
            (new Student { StudentId = 5, Name = "Guilherme", Email = "guilherme@xpi.com.br", Modulo = "4", Status = "online", Password = "Abc123456!" });

            context.SaveChanges();
        }
    }
}
