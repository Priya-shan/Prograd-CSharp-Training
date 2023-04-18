using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityExample2.Migrations
{
    /// <inheritdoc />
    public partial class deletecol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dept",
                table: "StudentsTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dept",
                table: "StudentsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
