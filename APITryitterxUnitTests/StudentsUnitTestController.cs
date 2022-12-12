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
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;

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

            DBUnitTestsMockInitializer db = new DBUnitTestsMockInitializer();
            // db.Seed(context);

            repository = new UnitOfWork(context);
        }

        //=======================================================================
        // testes unit�rios
        // Inicio dos testes : m�todo GET

        [Fact]
        public async Task GetStudents_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            //Act  
            var data = await controller.Get(1);
            Console.WriteLine(data);

            //Assert  
            Assert.IsType<StudentDTO>(data.Value);
        }

        [Fact]
        public async Task GetStudents_Return_NotFound()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            //Act  
            var data = await controller.Get(20);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        //GET retorna uma lista de objetos student
        //objetivo verificar se os dados esperados est�o corretos
        [Fact]
        public async Task GetStudents_MatchResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            //Act  
            var data = await controller.GetStudentsPosts();

            //Assert  
            Assert.IsType<List<StudentDTO>>(data.Value);
            var cat = data.Value.Should().BeAssignableTo<List<StudentDTO>>().Subject;

            Assert.Equal("Carol", cat[0].Name);
            Assert.Equal("carolinecamacho@xpi.com.br", cat[0].Email);
        }

        //-------------------------------------------------------------
        //GET - Retorna student por Id : Retorna objeto StudentDTO
        [Fact]
        public async Task GetStudentById_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 2;

            //Act  
            var data = await controller.Get(catId);

            //Assert  
            Assert.IsType<StudentDTO>(data.Value);
        }

        //-------------------------------------------------------------
        //GET - Retorna Student por Id : NotFound
        [Fact]
        public async Task GetStudentById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 9999;

            //Act  
            var data = await controller.Get(catId);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        //-------------------------------------------------------------
        // POST - Incluir nova student - Obter CreatedResult
        [Fact]
        public async Task Post_Student_AddValidData_Return_CreatedResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);

            var cat = new Student() { Name = "Bianca", Email = "bianca@xpi.com.br", Modulo = "4", Status = "online", Password = "Abc123456!" };

            //Act  
            var data = await controller.Post(cat);

            //Assert  
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        //-------------------------------------------------------------
        //PUT - Atualizar uma student existente com sucesso
        // [Fact]
        // public async Task Put_Student_Update_ValidData_Return_OkResult()
        // {
        //     //Arrange  
        //     var controller = new StudentsController(repository, mapper);
        //     var catId = 1;

        //     //Act  
        //     var existingPost = await controller.Get(catId);
        //     var result = existingPost.Value.Should().BeAssignableTo<StudentDTO>().Subject;

        //     var catDto = new StudentDTO();
        //     catDto.StudentId = catId;
        //     catDto.Name = "Carol";
        //     catDto.Email = "caroline@xpi.com.br";
        //     catDto.Modulo = "4";
        //     catDto.Status = "Online";
        //     var updatedData = await controller.Put(catId, catDto);
        //     //Assert  
        //     Assert.IsType<OkResult>(updatedData);
        // }

        //-------------------------------------------------------------
        //Delete - Deleta student por id - Retorna StudentDTO
        [Fact]
        public async Task Delete_Student_Return_OkResult()
        {
            //Arrange  
            var controller = new StudentsController(repository, mapper);
            var catId = 3;

            //Act  
            var data = await controller.Delete(catId);

            //Assert  
            Assert.IsType<StudentDTO>(data.Value);
        }
    }
