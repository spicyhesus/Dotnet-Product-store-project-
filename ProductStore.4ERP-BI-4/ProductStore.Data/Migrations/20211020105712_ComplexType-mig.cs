using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStore.Data.Migrations
{
    public partial class ComplexTypemig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Products",
                newName: "Address_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Products",
                newName: "Address_City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_StreetAddress",
                table: "Products",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Products",
                newName: "City");
        }
    }
}
