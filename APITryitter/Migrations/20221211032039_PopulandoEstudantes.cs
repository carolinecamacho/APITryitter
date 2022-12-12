using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITryitter.Migrations
{
    public partial class PopulandoEstudantes : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Students(Name, Email, Modulo, Status, Password) Values('Carol', 'carolinecamacho@xpi.com.br', '4', 'Online', '123abc')");
            mb.Sql("Insert into Students(Name, Email, Modulo, Status, Password) Values('Ingrid', 'ingrid@xpi.com.br', '5', 'Online', 'In123456!')");
            mb.Sql("Insert into Students(Name, Email, Modulo, Status, Password) Values('Dante', 'dante@xpi.com.br', '3', 'Ausente', '123abc')");
            mb.Sql("Insert into Students(Name, Email, Modulo, Status, Password) Values('Carlos', 'carlos@xpi.com.br', '3', 'Ausente', '123abc')");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Students");
        }
    }
}
