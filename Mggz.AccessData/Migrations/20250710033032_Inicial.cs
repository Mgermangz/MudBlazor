using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mggz.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Oficiales");

            migrationBuilder.EnsureSchema(
                name: "oficiales");

            migrationBuilder.CreateTable(
                name: "Paises",
                schema: "oficiales",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                schema: "Oficiales",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_PaisId",
                        column: x => x.PaisId,
                        principalSchema: "oficiales",
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                schema: "Oficiales",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "Oficiales",
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_EstadoId",
                schema: "Oficiales",
                table: "Ciudades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Nombre",
                schema: "Oficiales",
                table: "Ciudades",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Nombre",
                schema: "Oficiales",
                table: "Estados",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisId",
                schema: "Oficiales",
                table: "Estados",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                schema: "oficiales",
                table: "Paises",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudades",
                schema: "Oficiales");

            migrationBuilder.DropTable(
                name: "Estados",
                schema: "Oficiales");

            migrationBuilder.DropTable(
                name: "Paises",
                schema: "oficiales");
        }
    }
}
