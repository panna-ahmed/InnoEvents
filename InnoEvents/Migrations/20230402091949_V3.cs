using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoEvents.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ContactUserId",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventTime",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "ContactUserId",
                table: "Events");
        }
    }
}
