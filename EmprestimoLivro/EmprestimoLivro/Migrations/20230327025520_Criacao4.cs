using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivro.Migrations
{
    /// <inheritdoc />
    public partial class Criacao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecebedorTest",
                table: "Emprestimos",
                newName: "Recebedor");

            migrationBuilder.AddColumn<string>(
                name: "Fornecedor",
                table: "Emprestimos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "Recebedor",
                table: "Emprestimos",
                newName: "RecebedorTest");
        }
    }
}
