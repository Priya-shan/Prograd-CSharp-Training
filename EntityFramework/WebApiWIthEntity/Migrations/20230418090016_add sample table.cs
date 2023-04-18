using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWIthEntity.Migrations
{
    /// <inheritdoc />
    public partial class addsampletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    RollNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                 table.PrimaryKey("PK_StudentsEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleTable");

            migrationBuilder.DropTable(
                name: "StudentsEntity");
        }
    }
}
