using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWIthEntity.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsEntityApi",
                table: "StudentsEntityApi");

            //migrationBuilder.RenameTable(
            //    name: "StudentsEntityApi",
            //    newName: "StudentsEntity");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_StudentsEntity",
            //    table: "StudentsEntity",
            //    column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsEntity",
                table: "StudentsEntity");

            //migrationBuilder.RenameTable(
            //    name: "StudentsEntity",
            //    newName: "StudentsEntityApi");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_StudentsEntityApi",
            //    table: "StudentsEntityApi",
            //    column: "Id");
        }
    }
}
