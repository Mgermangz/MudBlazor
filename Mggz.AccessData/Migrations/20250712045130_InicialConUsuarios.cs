using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mggz.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class InicialConUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Oficiales");

            migrationBuilder.EnsureSchema(
                name: "Negocio");

            migrationBuilder.EnsureSchema(
                name: "oficiales");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.EnsureSchema(
                name: "WebIdentity");

            migrationBuilder.CreateTable(
                name: "Paises",
                schema: "oficiales",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoTelefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftPlans",
                schema: "Negocio",
                columns: table => new
                {
                    SoftPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Meses = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    ClinicsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftPlans", x => x.SoftPlanId);
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
                name: "RolesClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                schema: "Negocio",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RazonSocial = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    SoftPlanId = table.Column<int>(type: "int", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    UrlLogo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresas_Paises_PaisID",
                        column: x => x.PaisID,
                        principalSchema: "oficiales",
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresas_SoftPlans_SoftPlanId",
                        column: x => x.SoftPlanId,
                        principalSchema: "Negocio",
                        principalTable: "SoftPlans",
                        principalColumn: "SoftPlanId",
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

            migrationBuilder.CreateTable(
                name: "Gerentes",
                schema: "Negocio",
                columns: table => new
                {
                    GerenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    APaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: "http://localhost:5229/imagenes/NoImagen.png"),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.GerenteId);
                    table.ForeignKey(
                        name: "FK_Gerentes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "Negocio",
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "Negocio",
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosClaims_Usuarios_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UsuariosLogins_Usuarios_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuarios_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosTokens",
                schema: "WebIdentity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsuariosTokens_Usuarios_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
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
                name: "IX_Empresas_PaisID",
                schema: "Negocio",
                table: "Empresas",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_RFC",
                schema: "Negocio",
                table: "Empresas",
                column: "RFC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SoftPlanId",
                schema: "Negocio",
                table: "Empresas",
                column: "SoftPlanId");

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
                name: "IX_Gerentes_EmpresaId",
                schema: "Negocio",
                table: "Gerentes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerentes_RFC",
                schema: "Negocio",
                table: "Gerentes",
                column: "RFC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                schema: "oficiales",
                table: "Paises",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaims_RoleId",
                schema: "Identity",
                table: "RolesClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftPlans_Nombre",
                schema: "Negocio",
                table: "SoftPlans",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Usuarios",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                schema: "Identity",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Usuarios",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClaims_UserId",
                schema: "Identity",
                table: "UsuariosClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosLogins_UserId",
                schema: "Identity",
                table: "UsuariosLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_RoleId",
                schema: "Identity",
                table: "UsuariosRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudades",
                schema: "Oficiales");

            migrationBuilder.DropTable(
                name: "Gerentes",
                schema: "Negocio");

            migrationBuilder.DropTable(
                name: "RolesClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsuariosClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsuariosLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsuariosRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsuariosTokens",
                schema: "WebIdentity");

            migrationBuilder.DropTable(
                name: "Estados",
                schema: "Oficiales");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Empresas",
                schema: "Negocio");

            migrationBuilder.DropTable(
                name: "Paises",
                schema: "oficiales");

            migrationBuilder.DropTable(
                name: "SoftPlans",
                schema: "Negocio");
        }
    }
}
