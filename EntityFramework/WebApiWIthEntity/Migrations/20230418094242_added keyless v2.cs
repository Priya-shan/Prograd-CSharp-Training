using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWIthEntity.Migrations
{
    /// <inheritdoc />
    public partial class addedkeylessv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsEntity",
                table: "StudentsEntity");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentsEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentsEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
