using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class deletevendortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_vendors_id_oui",
                table: "collected_data");

            migrationBuilder.DropTable(
                name: "vendors");

            migrationBuilder.DropIndex(
                name: "IX_collected_data_id_oui",
                table: "collected_data");

            migrationBuilder.DropColumn(
                name: "id_oui",
                table: "collected_data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id_oui",
                table: "collected_data",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    id_oui = table.Column<string>(nullable: false),
                    name_vendor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.id_oui);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_oui",
                table: "collected_data",
                column: "id_oui");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_vendors_id_oui",
                table: "collected_data",
                column: "id_oui",
                principalTable: "vendors",
                principalColumn: "id_oui",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
