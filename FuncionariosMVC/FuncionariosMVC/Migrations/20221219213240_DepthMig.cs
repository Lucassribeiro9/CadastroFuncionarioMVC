using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionariosMVC.Migrations
{
    public partial class DepthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentosId",
                table: "Funcionario",
                column: "DepartamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Departamentos_DepartamentosId",
                table: "Funcionario",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Departamentos_DepartamentosId",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_DepartamentosId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Funcionario");
        }
    }
}
