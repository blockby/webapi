using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class changeidoui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "oui",
                table: "vendors",
                newName: "id_oui");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_oui",
                table: "vendors",
                newName: "oui");
        }
    }
}
