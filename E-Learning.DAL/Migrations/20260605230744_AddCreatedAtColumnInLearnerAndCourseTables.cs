using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtColumnInLearnerAndCourseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Learners",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Courses",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Learners");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Courses");
        }
    }
}
