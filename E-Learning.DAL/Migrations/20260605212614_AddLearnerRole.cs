using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLearnerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "3ee6bc12-5cb0-4304-91e7-6a00744e042c", "Learner", "LEARNER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
