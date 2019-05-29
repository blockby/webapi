using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class ouifixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_vendors_oui",
                table: "collected_data");

            migrationBuilder.RenameColumn(
                name: "oui",
                table: "collected_data",
                newName: "oui_id");

            migrationBuilder.RenameIndex(
                name: "IX_collected_data_oui",
                table: "collected_data",
                newName: "IX_collected_data_oui_id");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_vendors_oui_id",
                table: "collected_data",
                column: "oui_id",
                principalTable: "vendors",
                principalColumn: "oui",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_vendors_oui_id",
                table: "collected_data");

            migrationBuilder.RenameColumn(
                name: "oui_id",
                table: "collected_data",
                newName: "oui");

            migrationBuilder.RenameIndex(
                name: "IX_collected_data_oui_id",
                table: "collected_data",
                newName: "IX_collected_data_oui");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_vendors_oui",
                table: "collected_data",
                column: "oui",
                principalTable: "vendors",
                principalColumn: "oui",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
