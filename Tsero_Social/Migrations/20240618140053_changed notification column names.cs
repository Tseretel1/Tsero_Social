using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tsero_Social.Migrations
{
    /// <inheritdoc />
    public partial class changednotificationcolumnnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserID",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Notifications",
                newName: "User2");

            migrationBuilder.RenameColumn(
                name: "ReceiverID",
                table: "Notifications",
                newName: "User1");

            migrationBuilder.RenameColumn(
                name: "NTF_Type",
                table: "Notifications",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "NTF_DateTime",
                table: "Notifications",
                newName: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User2",
                table: "Notifications",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "User1",
                table: "Notifications",
                newName: "ReceiverID");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Notifications",
                newName: "NTF_Type");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Notifications",
                newName: "NTF_DateTime");

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
    }
}
