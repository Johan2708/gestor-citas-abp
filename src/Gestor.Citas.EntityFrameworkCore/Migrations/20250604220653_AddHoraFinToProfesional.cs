using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Citas.Migrations
{
    /// <inheritdoc />
    public partial class AddHoraFinToProfesional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horarios",
                table: "Profesionales");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFin",
                table: "Profesionales",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicio",
                table: "Profesionales",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFin",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Profesionales");

            migrationBuilder.AddColumn<string>(
                name: "Horarios",
                table: "Profesionales",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
