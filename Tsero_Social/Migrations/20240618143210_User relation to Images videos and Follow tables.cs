using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tsero_Social.Migrations
{
    /// <inheritdoc />
    public partial class UserrelationtoImagesvideosandFollowtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_userid",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_userid",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_userid",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_images_Users_Userid",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_videos_Users_Userid",
                table: "videos");

            // Handle existing data to match Users table
            migrationBuilder.Sql(@"
        UPDATE Follows
        SET userid = Users.id
        FROM Follows
        INNER JOIN Users ON Follows.userid = Users.id
    ");

            migrationBuilder.Sql(@"
        UPDATE images
        SET Userid = Users.id
        FROM images
        INNER JOIN Users ON images.Userid = Users.id
    ");

            migrationBuilder.Sql(@"
        UPDATE videos
        SET Userid = Users.id
        FROM videos
        INNER JOIN Users ON videos.Userid = Users.id
    ");

            migrationBuilder.DropIndex(
                name: "IX_videos_Userid",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_images_Userid",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_Follows_userid",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Follows");

            migrationBuilder.CreateIndex(
                name: "IX_videos_Userid",
                table: "videos",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_images_Userid",
                table: "images",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_userid",
                table: "Follows",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_userid",
                table: "Follows",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_images_Users_Userid",
                table: "images",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_videos_Users_Userid",
                table: "videos",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_userid",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_images_Users_Userid",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_videos_Users_Userid",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_videos_Userid",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_images_Userid",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_Follows_userid",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Follows");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userid",
                table: "Notifications",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_userid",
                table: "Notifications",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
