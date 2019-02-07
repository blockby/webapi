using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class newdbwithforeignkeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MtcActivitys_Dayss_DaysAct",
                table: "MtcActivitys");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcActivitys_Mtcs_ZoneAct",
                table: "MtcActivitys");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcAges_Dayss_DaysAge",
                table: "MtcAges");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcAges_Mtcs_ZoneAge",
                table: "MtcAges");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcGenders_Dayss_DaysGen",
                table: "MtcGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcGenders_Mtcs_ZoneGen",
                table: "MtcGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcHomezones_Mtcs_HomeHz",
                table: "MtcHomezones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mtcs",
                table: "Mtcs");

            migrationBuilder.DropIndex(
                name: "IX_MtcHomezones_HomeHz",
                table: "MtcHomezones");

            migrationBuilder.DropIndex(
                name: "IX_MtcGenders_ZoneGen",
                table: "MtcGenders");

            migrationBuilder.DropIndex(
                name: "IX_MtcAges_ZoneAge",
                table: "MtcAges");

            migrationBuilder.DropIndex(
                name: "IX_MtcActivitys_ZoneAct",
                table: "MtcActivitys");

            migrationBuilder.DropColumn(
                name: "Gid",
                table: "Mtcs");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Mtcs");

            migrationBuilder.DropColumn(
                name: "DaysHz",
                table: "MtcHomezones");

            migrationBuilder.DropColumn(
                name: "HomeHz",
                table: "MtcHomezones");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mtcs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Groesse",
                table: "Mtcs",
                newName: "groesse");

            migrationBuilder.RenameColumn(
                name: "Geom",
                table: "Mtcs",
                newName: "geom");

            migrationBuilder.RenameColumn(
                name: "ZoneHz",
                table: "MtcHomezones",
                newName: "day");

            migrationBuilder.RenameColumn(
                name: "SharedHz",
                table: "MtcHomezones",
                newName: "fraction");

            migrationBuilder.RenameColumn(
                name: "IdHz",
                table: "MtcHomezones",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZoneGen",
                table: "MtcGenders",
                newName: "hour");

            migrationBuilder.RenameColumn(
                name: "ShareGen",
                table: "MtcGenders",
                newName: "fraction");

            migrationBuilder.RenameColumn(
                name: "HoursGen",
                table: "MtcGenders",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "GenderGen",
                table: "MtcGenders",
                newName: "zone");

            migrationBuilder.RenameColumn(
                name: "DaysGen",
                table: "MtcGenders",
                newName: "day");

            migrationBuilder.RenameColumn(
                name: "IdGen",
                table: "MtcGenders",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_MtcGenders_DaysGen",
                table: "MtcGenders",
                newName: "IX_MtcGenders_day");

            migrationBuilder.RenameColumn(
                name: "ZoneAge",
                table: "MtcAges",
                newName: "hour");

            migrationBuilder.RenameColumn(
                name: "ShareAge",
                table: "MtcAges",
                newName: "fraction");

            migrationBuilder.RenameColumn(
                name: "HoursAge",
                table: "MtcAges",
                newName: "day");

            migrationBuilder.RenameColumn(
                name: "DaysAge",
                table: "MtcAges",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "AgeAge",
                table: "MtcAges",
                newName: "zone");

            migrationBuilder.RenameColumn(
                name: "IdAge",
                table: "MtcAges",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_MtcAges_DaysAge",
                table: "MtcAges",
                newName: "IX_MtcAges_age");

            migrationBuilder.RenameColumn(
                name: "Density",
                table: "MtcActivitys",
                newName: "density");

            migrationBuilder.RenameColumn(
                name: "ZoneAct",
                table: "MtcActivitys",
                newName: "people");

            migrationBuilder.RenameColumn(
                name: "HoursAct",
                table: "MtcActivitys",
                newName: "hour");

            migrationBuilder.RenameColumn(
                name: "DaysAct",
                table: "MtcActivitys",
                newName: "day");

            migrationBuilder.RenameColumn(
                name: "CountAct",
                table: "MtcActivitys",
                newName: "zone");

            migrationBuilder.RenameColumn(
                name: "IdAct",
                table: "MtcActivitys",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_MtcActivitys_DaysAct",
                table: "MtcActivitys",
                newName: "IX_MtcActivitys_day");

            migrationBuilder.RenameColumn(
                name: "NameDay",
                table: "Dayss",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "IdDay",
                table: "Dayss",
                newName: "id");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Mtcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "groesse",
                table: "Mtcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "homezone",
                table: "MtcHomezones",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "zone",
                table: "MtcHomezones",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mtcs",
                table: "Mtcs",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Age",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Age", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_day",
                table: "MtcHomezones",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_zone",
                table: "MtcHomezones",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_gender",
                table: "MtcGenders",
                column: "gender");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_zone",
                table: "MtcGenders",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_day",
                table: "MtcAges",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_zone",
                table: "MtcAges",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_zone",
                table: "MtcActivitys",
                column: "zone");

            migrationBuilder.AddForeignKey(
                name: "FK_MtcActivitys_Dayss_day",
                table: "MtcActivitys",
                column: "day",
                principalTable: "Dayss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcActivitys_Mtcs_zone",
                table: "MtcActivitys",
                column: "zone",
                principalTable: "Mtcs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcAges_Age_age",
                table: "MtcAges",
                column: "age",
                principalTable: "Age",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcAges_Dayss_day",
                table: "MtcAges",
                column: "day",
                principalTable: "Dayss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcAges_Mtcs_zone",
                table: "MtcAges",
                column: "zone",
                principalTable: "Mtcs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcGenders_Dayss_day",
                table: "MtcGenders",
                column: "day",
                principalTable: "Dayss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcGenders_Gender_gender",
                table: "MtcGenders",
                column: "gender",
                principalTable: "Gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcGenders_Mtcs_zone",
                table: "MtcGenders",
                column: "zone",
                principalTable: "Mtcs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcHomezones_Dayss_day",
                table: "MtcHomezones",
                column: "day",
                principalTable: "Dayss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcHomezones_Mtcs_zone",
                table: "MtcHomezones",
                column: "zone",
                principalTable: "Mtcs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MtcActivitys_Dayss_day",
                table: "MtcActivitys");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcActivitys_Mtcs_zone",
                table: "MtcActivitys");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcAges_Age_age",
                table: "MtcAges");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcAges_Dayss_day",
                table: "MtcAges");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcAges_Mtcs_zone",
                table: "MtcAges");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcGenders_Dayss_day",
                table: "MtcGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcGenders_Gender_gender",
                table: "MtcGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcGenders_Mtcs_zone",
                table: "MtcGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcHomezones_Dayss_day",
                table: "MtcHomezones");

            migrationBuilder.DropForeignKey(
                name: "FK_MtcHomezones_Mtcs_zone",
                table: "MtcHomezones");

            migrationBuilder.DropTable(
                name: "Age");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mtcs",
                table: "Mtcs");

            migrationBuilder.DropIndex(
                name: "IX_MtcHomezones_day",
                table: "MtcHomezones");

            migrationBuilder.DropIndex(
                name: "IX_MtcHomezones_zone",
                table: "MtcHomezones");

            migrationBuilder.DropIndex(
                name: "IX_MtcGenders_gender",
                table: "MtcGenders");

            migrationBuilder.DropIndex(
                name: "IX_MtcGenders_zone",
                table: "MtcGenders");

            migrationBuilder.DropIndex(
                name: "IX_MtcAges_day",
                table: "MtcAges");

            migrationBuilder.DropIndex(
                name: "IX_MtcAges_zone",
                table: "MtcAges");

            migrationBuilder.DropIndex(
                name: "IX_MtcActivitys_zone",
                table: "MtcActivitys");

            migrationBuilder.DropColumn(
                name: "homezone",
                table: "MtcHomezones");

            migrationBuilder.DropColumn(
                name: "zone",
                table: "MtcHomezones");

            migrationBuilder.RenameColumn(
                name: "groesse",
                table: "Mtcs",
                newName: "Groesse");

            migrationBuilder.RenameColumn(
                name: "geom",
                table: "Mtcs",
                newName: "Geom");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Mtcs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "fraction",
                table: "MtcHomezones",
                newName: "SharedHz");

            migrationBuilder.RenameColumn(
                name: "day",
                table: "MtcHomezones",
                newName: "ZoneHz");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MtcHomezones",
                newName: "IdHz");

            migrationBuilder.RenameColumn(
                name: "zone",
                table: "MtcGenders",
                newName: "GenderGen");

            migrationBuilder.RenameColumn(
                name: "hour",
                table: "MtcGenders",
                newName: "ZoneGen");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "MtcGenders",
                newName: "HoursGen");

            migrationBuilder.RenameColumn(
                name: "fraction",
                table: "MtcGenders",
                newName: "ShareGen");

            migrationBuilder.RenameColumn(
                name: "day",
                table: "MtcGenders",
                newName: "DaysGen");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MtcGenders",
                newName: "IdGen");

            migrationBuilder.RenameIndex(
                name: "IX_MtcGenders_day",
                table: "MtcGenders",
                newName: "IX_MtcGenders_DaysGen");

            migrationBuilder.RenameColumn(
                name: "zone",
                table: "MtcAges",
                newName: "AgeAge");

            migrationBuilder.RenameColumn(
                name: "hour",
                table: "MtcAges",
                newName: "ZoneAge");

            migrationBuilder.RenameColumn(
                name: "fraction",
                table: "MtcAges",
                newName: "ShareAge");

            migrationBuilder.RenameColumn(
                name: "day",
                table: "MtcAges",
                newName: "HoursAge");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "MtcAges",
                newName: "DaysAge");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MtcAges",
                newName: "IdAge");

            migrationBuilder.RenameIndex(
                name: "IX_MtcAges_age",
                table: "MtcAges",
                newName: "IX_MtcAges_DaysAge");

            migrationBuilder.RenameColumn(
                name: "density",
                table: "MtcActivitys",
                newName: "Density");

            migrationBuilder.RenameColumn(
                name: "zone",
                table: "MtcActivitys",
                newName: "CountAct");

            migrationBuilder.RenameColumn(
                name: "people",
                table: "MtcActivitys",
                newName: "ZoneAct");

            migrationBuilder.RenameColumn(
                name: "hour",
                table: "MtcActivitys",
                newName: "HoursAct");

            migrationBuilder.RenameColumn(
                name: "day",
                table: "MtcActivitys",
                newName: "DaysAct");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MtcActivitys",
                newName: "IdAct");

            migrationBuilder.RenameIndex(
                name: "IX_MtcActivitys_day",
                table: "MtcActivitys",
                newName: "IX_MtcActivitys_DaysAct");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Dayss",
                newName: "NameDay");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Dayss",
                newName: "IdDay");

            migrationBuilder.AlterColumn<decimal>(
                name: "Groesse",
                table: "Mtcs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                table: "Mtcs",
                nullable: true,
                oldClrType: typeof(long))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "Gid",
                table: "Mtcs",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "Area",
                table: "Mtcs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaysHz",
                table: "MtcHomezones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeHz",
                table: "MtcHomezones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mtcs",
                table: "Mtcs",
                column: "Gid");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_HomeHz",
                table: "MtcHomezones",
                column: "HomeHz");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_ZoneGen",
                table: "MtcGenders",
                column: "ZoneGen");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_ZoneAge",
                table: "MtcAges",
                column: "ZoneAge");

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_ZoneAct",
                table: "MtcActivitys",
                column: "ZoneAct");

            migrationBuilder.AddForeignKey(
                name: "FK_MtcActivitys_Dayss_DaysAct",
                table: "MtcActivitys",
                column: "DaysAct",
                principalTable: "Dayss",
                principalColumn: "IdDay",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcActivitys_Mtcs_ZoneAct",
                table: "MtcActivitys",
                column: "ZoneAct",
                principalTable: "Mtcs",
                principalColumn: "Gid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcAges_Dayss_DaysAge",
                table: "MtcAges",
                column: "DaysAge",
                principalTable: "Dayss",
                principalColumn: "IdDay",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcAges_Mtcs_ZoneAge",
                table: "MtcAges",
                column: "ZoneAge",
                principalTable: "Mtcs",
                principalColumn: "Gid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcGenders_Dayss_DaysGen",
                table: "MtcGenders",
                column: "DaysGen",
                principalTable: "Dayss",
                principalColumn: "IdDay",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcGenders_Mtcs_ZoneGen",
                table: "MtcGenders",
                column: "ZoneGen",
                principalTable: "Mtcs",
                principalColumn: "Gid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MtcHomezones_Mtcs_HomeHz",
                table: "MtcHomezones",
                column: "HomeHz",
                principalTable: "Mtcs",
                principalColumn: "Gid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
