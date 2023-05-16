using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivro.Migrations
{
    /// <inheritdoc />
    public partial class Criacao3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recebedor",
                table: "Emprestimos",
                newName: "RecebedorTest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecebedorTest",
                table: "Emprestimos",
                newName: "Recebedor");
        }
    }
}
