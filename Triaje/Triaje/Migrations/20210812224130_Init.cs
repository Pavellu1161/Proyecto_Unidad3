using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Triaje.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdentidadPaciente = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NombresPaciente = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ApellidosPaciente = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroContacto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdentidadPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TipoSignos",
                columns: table => new
                {
                    IdTipoSignoGeneral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSignos", x => x.IdTipoSignoGeneral);
                });

            migrationBuilder.CreateTable(
                name: "TiposPrioridades",
                columns: table => new
                {
                    IdPrioridadGeneral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPrioridades", x => x.IdPrioridadGeneral);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    IdentidadPersonal = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NombresPersonal = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ApellidosPersonal = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.IdentidadPersonal);
                    table.ForeignKey(
                        name: "FK_Personals_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signos",
                columns: table => new
                {
                    IdSignoGeneral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPrioridadGeneral = table.Column<int>(type: "int", nullable: false),
                    IdTipoSignoGeneral = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signos", x => x.IdSignoGeneral);
                    table.ForeignKey(
                        name: "FK_Signos_TipoSignos_IdTipoSignoGeneral",
                        column: x => x.IdTipoSignoGeneral,
                        principalTable: "TipoSignos",
                        principalColumn: "IdTipoSignoGeneral",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Signos_TiposPrioridades_IdPrioridadGeneral",
                        column: x => x.IdPrioridadGeneral,
                        principalTable: "TiposPrioridades",
                        principalColumn: "IdPrioridadGeneral",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pediatrias",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hemorragia_Incontrolable = table.Column<bool>(type: "bit", nullable: false),
                    Herida_Arma = table.Column<bool>(type: "bit", nullable: false),
                    Gran_Quemado = table.Column<bool>(type: "bit", nullable: false),
                    Dengue_Grave = table.Column<bool>(type: "bit", nullable: false),
                    Mordeduras_Graves = table.Column<bool>(type: "bit", nullable: false),
                    Paciente_Oncologico = table.Column<bool>(type: "bit", nullable: false),
                    Estridor_Laringeo = table.Column<bool>(type: "bit", nullable: false),
                    Trauma_Ocular = table.Column<bool>(type: "bit", nullable: false),
                    Varicela_Sobreinfectada = table.Column<bool>(type: "bit", nullable: false),
                    Ingesta_Cuerpos_Extraños = table.Column<bool>(type: "bit", nullable: false),
                    Cafalea_Aguda = table.Column<bool>(type: "bit", nullable: false),
                    Urticaria = table.Column<bool>(type: "bit", nullable: false),
                    Otalgia = table.Column<bool>(type: "bit", nullable: false),
                    Dolor_Toracico = table.Column<bool>(type: "bit", nullable: false),
                    Contusiones_Menores = table.Column<bool>(type: "bit", nullable: false),
                    Patologia_Respiratoria = table.Column<bool>(type: "bit", nullable: false),
                    Dolor_Garganta = table.Column<bool>(type: "bit", nullable: false),
                    Estrenimiento_Cronico = table.Column<bool>(type: "bit", nullable: false),
                    Dolor_Abdominal = table.Column<bool>(type: "bit", nullable: false),
                    Curaciones = table.Column<bool>(type: "bit", nullable: false),
                    IdentidadPaciente = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    IdentidadPersonal = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pediatrias", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Pediatrias_Pacientes_IdentidadPaciente",
                        column: x => x.IdentidadPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdentidadPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pediatrias_Personals_IdentidadPersonal",
                        column: x => x.IdentidadPersonal,
                        principalTable: "Personals",
                        principalColumn: "IdentidadPersonal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSignoGeneral = table.Column<int>(type: "int", nullable: false),
                    HoraTriaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentidadPaciente = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    IdentidadPersonal = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_IdentidadPaciente",
                        column: x => x.IdentidadPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdentidadPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Personals_IdentidadPersonal",
                        column: x => x.IdentidadPersonal,
                        principalTable: "Personals",
                        principalColumn: "IdentidadPersonal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Signos_IdSignoGeneral",
                        column: x => x.IdSignoGeneral,
                        principalTable: "Signos",
                        principalColumn: "IdSignoGeneral",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdentidadPaciente",
                table: "Consultas",
                column: "IdentidadPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdentidadPersonal",
                table: "Consultas",
                column: "IdentidadPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdSignoGeneral",
                table: "Consultas",
                column: "IdSignoGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_Pediatrias_IdentidadPaciente",
                table: "Pediatrias",
                column: "IdentidadPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Pediatrias_IdentidadPersonal",
                table: "Pediatrias",
                column: "IdentidadPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdRol",
                table: "Personals",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Signos_IdPrioridadGeneral",
                table: "Signos",
                column: "IdPrioridadGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_Signos_IdTipoSignoGeneral",
                table: "Signos",
                column: "IdTipoSignoGeneral");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Pediatrias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Signos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "TipoSignos");

            migrationBuilder.DropTable(
                name: "TiposPrioridades");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
