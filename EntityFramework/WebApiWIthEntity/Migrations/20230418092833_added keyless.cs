using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWIthEntity.Migrations
{
    /// <inheritdoc />
    public partial class addedkeyless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsEntity",
                table: "StudentsEntity");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentsEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentsEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsEntity",
                table: "StudentsEntity",
                column: "Id");
        }
    }
}
