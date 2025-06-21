using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientesAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Clientes");
        }
    }
}
