using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mggz.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class MaxLenghtCampoCodeTel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoTelefono",
                schema: "oficiales",
                table: "Paises",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoTelefono",
                schema: "oficiales",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
