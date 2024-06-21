using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tsero_Social.Migrations
{
    /// <inheritdoc />
    public partial class Notificationanduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the userid column
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Set the userid column to valid values from Users
            migrationBuilder.Sql(@"
        UPDATE Notifications
        SET userid = Users.id
        FROM Notifications
        INNER JOIN Users ON Notifications.User1 = Users.id
    ");

            // Create an index on the userid column
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userid",
                table: "Notifications",
                column: "userid");

            // Add the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_userid",
                table: "Notifications",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_userid",
                table: "Notifications");

            // Drop the index on userid column
            migrationBuilder.DropIndex(
                name: "IX_Notifications_userid",
                table: "Notifications");

            // Drop the userid column
            migrationBuilder.DropColumn(
                name: "userid",
                table: "Notifications");
        }

    }
}
