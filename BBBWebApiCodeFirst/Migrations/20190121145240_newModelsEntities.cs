using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class newModelsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MtcAges",
                columns: table => new
                {
                    IdAge = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ZoneAge = table.Column<int>(nullable: false),
                    AgeAge = table.Column<long>(nullable: false),
                    HoursAge = table.Column<int>(nullable: false),
                    DaysAge = table.Column<int>(nullable: false),
                    ShareAge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcAges", x => x.IdAge);
                    table.ForeignKey(
                        name: "FK_MtcAges_Dayss_DaysAge",
                        column: x => x.DaysAge,
                        principalTable: "Dayss",
                        principalColumn: "IdDay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcAges_Mtcs_ZoneAge",
                        column: x => x.ZoneAge,
                        principalTable: "Mtcs",
                        principalColumn: "Gid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcGenders",
                columns: table => new
                {
                    IdGen = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ZoneGen = table.Column<int>(nullable: false),
                    GenderGen = table.Column<long>(nullable: false),
                    HoursGen = table.Column<int>(nullable: false),
                    DaysGen = table.Column<int>(nullable: false),
                    ShareGen = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcGenders", x => x.IdGen);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Dayss_DaysGen",
                        column: x => x.DaysGen,
                        principalTable: "Dayss",
                        principalColumn: "IdDay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Mtcs_ZoneGen",
                        column: x => x.ZoneGen,
                        principalTable: "Mtcs",
                        principalColumn: "Gid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_DaysAge",
                table: "MtcAges",
                column: "DaysAge");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_ZoneAge",
                table: "MtcAges",
                column: "ZoneAge");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_DaysGen",
                table: "MtcGenders",
                column: "DaysGen");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_ZoneGen",
                table: "MtcGenders",
                column: "ZoneGen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MtcAges");

            migrationBuilder.DropTable(
                name: "MtcGenders");
        }
    }
}
