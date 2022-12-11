using APITryitter.Context;
using APITryitter.Controllers;
using APITryitter.DTOs;
using APITryitter.DTOs.Mappings;
using APITryitter.Models;
using APITryitter.Repository;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITryitterxUnitTests;

   public class StudentsUnitTestController
   {
        private IMapper mapper;
        private IUnitOfWork repository;

        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        public static string connectionString =
           "Server=localhost;DataBase=TryitterDB;Uid=root;Pwd=123456";

        static StudentsUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString,
                 ServerVersion.AutoDetect(connectionString))
                .Options;
        }

        public StudentsUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            var context = new AppDbContext(dbContextOptions);

            //DBUnitTestsMockInitializer db = new DBUnitTestsMockInitializer();
            // db.Seed(context);

            repository = new UnitOfWork(context);
        }

        //=======================================================================
        // testes unitários
        // Inicio dos testes : método GET

        [Fact]
        public void GetStudents_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            //Act  
            var data = controller.Get(1);

            //Assert  
            Assert.IsType<List<StudentDTO>>(data);
        }

        [Fact]
        public void GetStudents_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            //Act  
            var data = controller.Get(1);

            //Assert  
            Assert.IsType<BadRequestResult>(data.Result);
        }

        //GET retorna uma lista de objetos student
        //objetivo verificar se os dados esperados estão corretos
        [Fact]
        public void GetStudents_MatchResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            //Act  
            var data = controller.Get(1);

            //Assert  
            Assert.IsType<List<StudentDTO>>(data);
            var cat = data.Should().BeAssignableTo<List<StudentDTO>>().Subject;

            Assert.Equal("Carol", cat[0].Name);
            Assert.Equal("caroline@xpi.com.br", cat[0].Email);
        }

        //-------------------------------------------------------------
        //GET - Retorna student por Id : Retorna objeto StudentDTO
        [Fact]
        public void GetStudentById_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 2;

            //Act  
            var data = controller.Get(catId);

            //Assert  
            Assert.IsType<StudentDTO>(data);
        }

        //-------------------------------------------------------------
        //GET - Retorna Student por Id : NotFound
        [Fact]
        public void GetStudentById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 9999;

            //Act  
            var data = controller.Get(catId);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        //-------------------------------------------------------------
        // POST - Incluir nova student - Obter CreatedResult
        [Fact]
        public void Post_Student_AddValidData_Return_CreatedResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            var cat = new Student() { Name = "Bianca", Email = "bianca@xpi.com.br", Modulo = "4", Status = "online", Password = "Abc123456!" };

            //Act  
            var data = controller.Post(cat);

            //Assert  
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        //-------------------------------------------------------------
        //PUT - Atualizar uma student existente com sucesso
        [Fact]
        public void Put_Student_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 15;

            //Act  
            var existingPost = controller.Get(catId);
            var result = existingPost.Should().BeAssignableTo<StudentDTO>().Subject;

            var catDto = new StudentDTO();
            catDto.StudentId = catId;
            catDto.Name = "Carol";
            catDto.Email = "caroline@xpi.com.br";

            var updatedData = controller.Put(catId, catDto);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        //-------------------------------------------------------------
        //Delete - Deleta student por id - Retorna StudentDTO
        [Fact]
        public void Delete_Student_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 4;

            //Act  
            var data = controller.Delete(catId);

            //Assert  
            Assert.IsType<StudentDTO>(data);
        }
    }
