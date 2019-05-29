using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class daytablenamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_day_table_id_day",
                table: "collected_data");

            migrationBuilder.DropForeignKey(
                name: "FK_day_table_day_types_id_day_type",
                table: "day_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_day_table",
                table: "day_table");

            migrationBuilder.RenameTable(
                name: "day_table",
                newName: "days");

            migrationBuilder.RenameIndex(
                name: "IX_day_table_id_day_type",
                table: "days",
                newName: "IX_days_id_day_type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_days",
                table: "days",
                column: "id_day");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_days_id_day",
                table: "collected_data",
                column: "id_day",
                principalTable: "days",
                principalColumn: "id_day",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_days_day_types_id_day_type",
                table: "days",
                column: "id_day_type",
                principalTable: "day_types",
                principalColumn: "id_type_day",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collected_data_days_id_day",
                table: "collected_data");

            migrationBuilder.DropForeignKey(
                name: "FK_days_day_types_id_day_type",
                table: "days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_days",
                table: "days");

            migrationBuilder.RenameTable(
                name: "days",
                newName: "day_table");

            migrationBuilder.RenameIndex(
                name: "IX_days_id_day_type",
                table: "day_table",
                newName: "IX_day_table_id_day_type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_day_table",
                table: "day_table",
                column: "id_day");

            migrationBuilder.AddForeignKey(
                name: "FK_collected_data_day_table_id_day",
                table: "collected_data",
                column: "id_day",
                principalTable: "day_table",
                principalColumn: "id_day",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_day_table_day_types_id_day_type",
                table: "day_table",
                column: "id_day_type",
                principalTable: "day_types",
                principalColumn: "id_type_day",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
