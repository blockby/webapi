using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class DeviceDataDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            

            migrationBuilder.CreateTable(
                name: "day_periods",
                columns: table => new
                {
                    id_period_day = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_period = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day_periods", x => x.id_period_day);
                });

            migrationBuilder.CreateTable(
                name: "day_types",
                columns: table => new
                {
                    id_type_day = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type_day = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day_types", x => x.id_type_day);
                });

            migrationBuilder.CreateTable(
                name: "property_types",
                columns: table => new
                {
                    id_type_prop = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type_prop = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_types", x => x.id_type_prop);
                });

            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    id_type_user = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type_user = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.id_type_user);
                });

            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    id_vendor = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_vendor = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.id_vendor);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    id_user_type = table.Column<int>(nullable: false),
                    depent = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_users_user_types_id_user_type",
                        column: x => x.id_user_type,
                        principalTable: "user_types",
                        principalColumn: "id_type_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id_location = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_user = table.Column<int>(nullable: false),
                    id_prop_type = table.Column<int>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    coordinates = table.Column<Point>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id_location);
                    table.ForeignKey(
                        name: "FK_locations_property_types_id_prop_type",
                        column: x => x.id_prop_type,
                        principalTable: "property_types",
                        principalColumn: "id_type_prop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locations_users_id_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collected_data",
                columns: table => new
                {
                    id_coll_data = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_location = table.Column<int>(nullable: false),
                    id_vendor = table.Column<int>(nullable: false),
                    data_created = table.Column<DateTime>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    time_created = table.Column<TimeSpan>(nullable: false),
                    id_day = table.Column<int>(nullable: false),
                    id_day_period = table.Column<int>(nullable: false),
                    src = table.Column<string>(nullable: true),
                    src_resolved = table.Column<string>(nullable: true),
                    dst = table.Column<string>(nullable: true),
                    subtype = table.Column<string>(nullable: true),
                    sn = table.Column<int>(nullable: false),
                    ssid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collected_data", x => x.id_coll_data);
                    table.ForeignKey(
                        name: "FK_collected_data_days_id_day",
                        column: x => x.id_day,
                        principalTable: "days",
                        principalColumn: "id_day",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_day_periods_id_day_period",
                        column: x => x.id_day_period,
                        principalTable: "day_periods",
                        principalColumn: "id_period_day",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_locations_id_location",
                        column: x => x.id_location,
                        principalTable: "locations",
                        principalColumn: "id_location",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_vendors_id_vendor",
                        column: x => x.id_vendor,
                        principalTable: "vendors",
                        principalColumn: "id_vendor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shared_locations",
                columns: table => new
                {
                    id_sh_location = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_user = table.Column<int>(nullable: false),
                    id_location = table.Column<int>(nullable: false),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shared_locations", x => x.id_sh_location);
                    table.ForeignKey(
                        name: "FK_shared_locations_locations_id_location",
                        column: x => x.id_location,
                        principalTable: "locations",
                        principalColumn: "id_location",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_days_id_day_type",
                table: "days",
                column: "id_day_type");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_day",
                table: "collected_data",
                column: "id_day");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_day_period",
                table: "collected_data",
                column: "id_day_period");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_location",
                table: "collected_data",
                column: "id_location");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_vendor",
                table: "collected_data",
                column: "id_vendor");

            migrationBuilder.CreateIndex(
                name: "IX_locations_id_prop_type",
                table: "locations",
                column: "id_prop_type");

            migrationBuilder.CreateIndex(
                name: "IX_locations_id_user",
                table: "locations",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_shared_locations_id_location",
                table: "shared_locations",
                column: "id_location");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_user_type",
                table: "users",
                column: "id_user_type");

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
                name: "FK_days_day_types_id_day_type",
                table: "days");

            migrationBuilder.DropTable(
                name: "collected_data");

            migrationBuilder.DropTable(
                name: "day_types");

            migrationBuilder.DropTable(
                name: "shared_locations");

            migrationBuilder.DropTable(
                name: "day_periods");

            migrationBuilder.DropTable(
                name: "vendors");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "property_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_days",
                table: "days");

            migrationBuilder.DropIndex(
                name: "IX_days_id_day_type",
                table: "days");

            migrationBuilder.DropColumn(
                name: "id_day_type",
                table: "days");

            migrationBuilder.DropColumn(
                name: "name_day",
                table: "days");

            migrationBuilder.RenameTable(
                name: "days",
                newName: "Days");

            migrationBuilder.RenameColumn(
                name: "id_day",
                table: "Days",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Ages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mtcs",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    geom = table.Column<Geometry>(nullable: true),
                    groesse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mtcs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MtcActivitys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    day = table.Column<int>(nullable: false),
                    density = table.Column<decimal>(nullable: true),
                    hour = table.Column<int>(nullable: false),
                    people = table.Column<int>(nullable: false),
                    zone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcActivitys", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcActivitys_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcActivitys_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcAges",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    age = table.Column<int>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    fraction = table.Column<decimal>(nullable: false),
                    hour = table.Column<int>(nullable: false),
                    zone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcAges", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcAges_Ages_age",
                        column: x => x.age,
                        principalTable: "Ages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcAges_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcAges_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcGenders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    day = table.Column<int>(nullable: false),
                    fraction = table.Column<decimal>(nullable: false),
                    gender = table.Column<int>(nullable: false),
                    hour = table.Column<int>(nullable: false),
                    zone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcGenders", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Genders_gender",
                        column: x => x.gender,
                        principalTable: "Genders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcHomezones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    day = table.Column<int>(nullable: false),
                    fraction = table.Column<decimal>(nullable: false),
                    homezone = table.Column<long>(nullable: false),
                    zone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcHomezones", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcHomezones_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcHomezones_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_day",
                table: "MtcActivitys",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_zone",
                table: "MtcActivitys",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_age",
                table: "MtcAges",
                column: "age");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_day",
                table: "MtcAges",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_zone",
                table: "MtcAges",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_day",
                table: "MtcGenders",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_gender",
                table: "MtcGenders",
                column: "gender");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_zone",
                table: "MtcGenders",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_day",
                table: "MtcHomezones",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_zone",
                table: "MtcHomezones",
                column: "zone");
        }
    }
}
