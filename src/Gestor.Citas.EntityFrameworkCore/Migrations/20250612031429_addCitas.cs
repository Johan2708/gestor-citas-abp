using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Citas.Migrations
{
    /// <inheritdoc />
    public partial class addCitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "date", nullable: false),
                    Motivo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfesionalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCitas_AppClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AppClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCitas_AppProfesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "AppProfesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCitas_ClienteId",
                table: "AppCitas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCitas_ProfesionalId",
                table: "AppCitas",
                column: "ProfesionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCitas");
        }
    }
}
