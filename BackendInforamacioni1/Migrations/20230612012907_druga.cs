using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendInforamacioni1.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPosla",
                table: "Osoba",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPosla",
                table: "Osoba");
        }
    }
}
