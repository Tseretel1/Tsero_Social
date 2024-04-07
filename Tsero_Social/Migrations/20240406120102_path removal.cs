using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tsero_Social.Migrations
{
    /// <inheritdoc />
    public partial class pathremoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePath",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
