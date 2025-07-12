using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mggz.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoPais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoTelefono",
                schema: "oficiales",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoTelefono",
                schema: "oficiales",
                table: "Paises");
        }
    }
}
