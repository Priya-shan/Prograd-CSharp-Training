using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWIthEntity.Migrations
{
    /// <inheritdoc />
    public partial class altecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "StudentsEntity");

            migrationBuilder.AddColumn<string>(
                name: "sample_dept",
                table: "SampleTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sample_dept",
                table: "SampleTable");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "StudentsEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
