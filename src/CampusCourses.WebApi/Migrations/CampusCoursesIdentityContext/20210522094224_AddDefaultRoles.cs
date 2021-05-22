using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCourses.WebApi.Identity.Data
{
    public partial class AddDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52c94a78-b308-428f-b478-e1419587e877", "22293bc8-cb34-43d0-b137-82937d7cf02c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52c94a78-b308-428f-b478-e1419587e877");
        }
    }
}
