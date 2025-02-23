﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFistMVc.Migrations
{
    /// <inheritdoc />
    public partial class codefistAddClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "standard",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "standard",
                table: "Students");
        }
    }
}
