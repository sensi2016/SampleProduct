using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProduct.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Reminder",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Reminder",
                table: "Product",
                type: "datetime2",
                nullable: true);
        }
    }
}
