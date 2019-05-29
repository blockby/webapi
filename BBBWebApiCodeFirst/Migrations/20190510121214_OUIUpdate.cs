using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class OUIUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_vendors_id_vendor",
                table: "collected_data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vendors",
                table: "vendors");

            migrationBuilder.DropIndex(
                name: "IX_collected_data_id_vendor",
                table: "collected_data");

            migrationBuilder.DropColumn(
                name: "id_vendor",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "id_vendor",
                table: "collected_data");

            migrationBuilder.AddColumn<string>(
                name: "oui",
                table: "vendors",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "oui",
                table: "collected_data",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vendors",
                table: "vendors",
                column: "oui");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_oui",
                table: "collected_data",
                column: "oui");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_vendors_oui",
                table: "collected_data",
                column: "oui",
                principalTable: "vendors",
                principalColumn: "oui",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_vendors_oui",
                table: "collected_data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vendors",
                table: "vendors");

            migrationBuilder.DropIndex(
                name: "IX_collected_data_oui",
                table: "collected_data");

            migrationBuilder.DropColumn(
                name: "oui",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "oui",
                table: "collected_data");

            migrationBuilder.AddColumn<int>(
                name: "id_vendor",
                table: "vendors",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "id_vendor",
                table: "collected_data",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vendors",
                table: "vendors",
                column: "id_vendor");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_vendor",
                table: "collected_data",
                column: "id_vendor");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_vendors_id_vendor",
                table: "collected_data",
                column: "id_vendor",
                principalTable: "vendors",
                principalColumn: "id_vendor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
