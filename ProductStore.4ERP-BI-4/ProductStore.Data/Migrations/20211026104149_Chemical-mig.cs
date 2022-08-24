using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStore.Data.Migrations
{
    public partial class Chemicalmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_StreetAddress",
                table: "Products",
                newName: "MyStreet");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Products",
                newName: "MyCity");

            migrationBuilder.AlterColumn<string>(
                name: "MyStreet",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyStreet",
                table: "Products",
                newName: "Address_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "MyCity",
                table: "Products",
                newName: "Address_City");

            migrationBuilder.AlterColumn<string>(
                name: "Address_StreetAddress",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
