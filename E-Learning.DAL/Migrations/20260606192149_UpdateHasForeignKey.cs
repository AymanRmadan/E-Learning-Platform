using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHasForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Learners_AspNetUsers_Id",
                table: "Learners");

            migrationBuilder.CreateIndex(
                name: "IX_Learners_UserId",
                table: "Learners",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Learners_AspNetUsers_UserId",
                table: "Learners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Learners_AspNetUsers_UserId",
                table: "Learners");

            migrationBuilder.DropIndex(
                name: "IX_Learners_UserId",
                table: "Learners");

            migrationBuilder.AddForeignKey(
                name: "FK_Learners_AspNetUsers_Id",
                table: "Learners",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
