using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITryitter.Migrations
{
    public partial class PopulaPostStudents : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Oi!', 'image121.jpg', 1)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Bom Dia', 'image145.jpg', 2)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Bom Tarde', 'image356.jpg', 3)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Bom Noite', 'image4456.jpg', 4)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Bom Fim de Semana', 'image124.jpg', 1)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('tudo bem?', 'image1445.jpg', 2)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Feliz Natal?', 'image413.jpg', 3)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Feliz Ano Novo', 'image1446.jpg', 4)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Posts");
        }
    }
}
