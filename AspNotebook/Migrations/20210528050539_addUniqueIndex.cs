using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNotebook.Migrations
{
    public partial class addUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "Telephone" },
                values: new object[] { 1, "Ляксандр", "555-55-55" });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Name",
                table: "Persons",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_Name",
                table: "Persons");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "Telephone" },
                values: new object[] { -1, "Ляксандр", "555-55-55" });
        }
    }
}
