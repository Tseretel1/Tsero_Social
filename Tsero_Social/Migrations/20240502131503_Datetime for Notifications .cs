﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tsero_Social.Migrations
{
    /// <inheritdoc />
    public partial class DatetimeforNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NTF_DateTime",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NTF_DateTime",
                table: "Notifications");
        }
    }
}
