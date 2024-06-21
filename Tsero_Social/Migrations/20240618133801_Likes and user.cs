using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tsero_Social.Migrations
{
    public partial class Likesanduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Delete likes records with non-existent UserID
            migrationBuilder.Sql("DELETE FROM Likes WHERE UserID NOT IN (SELECT id FROM Users)");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_PostID",
                table: "Likes");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserID",
                table: "Likes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserID",
                table: "Likes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserID",
                table: "Likes");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostID",
                table: "Likes",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostID",
                table: "Likes",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
