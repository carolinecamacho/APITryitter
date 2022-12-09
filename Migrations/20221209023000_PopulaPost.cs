using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITryitter.Migrations
{
    public partial class PopulaPost : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Oiii', 'image.jpg', 1)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('abcasdahfhafjshdf', 'image1.jpg', 2)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Oidfasdfasdgsaii', 'image3.jpg', 3)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('asdfsadfgdsfgsd', 'image4.jpg', 4)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('vxzgrtewrtwe', 'image12.jpg', 1)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('bbdhtye', 'image145.jpg', 2)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('sfdgsdfgrtwe', 'image13.jpg', 3)");
            mb.Sql("Insert into Posts(Content, ImageUrl, StudentId) Values('Oisdfsdsdfgii', 'image14.jpg', 4)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Posts");
        }
    }
}
