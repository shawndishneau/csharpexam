using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam2.Migrations
{
    public partial class Exam2migrationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdeaDate",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "IdeaHoursInt",
                table: "Ideas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IdeaDate",
                table: "Ideas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdeaHoursInt",
                table: "Ideas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
