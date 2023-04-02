using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoEvents.Migrations
{
    /// <inheritdoc />
    public partial class V5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventTime",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserEvents");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Events",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventTime",
                table: "UserEvents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserEvents",
                type: "TEXT",
                nullable: true);
        }
    }
}
