using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''");

            migrationBuilder.CreateTable(
                name: "day_types",
                columns: table => new
                {
                    id_day_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    day_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day_types", x => x.id_day_type);
                });

            migrationBuilder.CreateTable(
                name: "days",
                columns: table => new
                {
                    id_day = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_days", x => x.id_day);
                });

            migrationBuilder.CreateTable(
                name: "in_activitys",
                columns: table => new
                {
                    id_in_activity = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_activity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_in_activitys", x => x.id_in_activity);
                });

            migrationBuilder.CreateTable(
                name: "in_day_periods",
                columns: table => new
                {
                    id_in_day_period = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_period = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_in_day_periods", x => x.id_in_day_period);
                });

            migrationBuilder.CreateTable(
                name: "out_activitys",
                columns: table => new
                {
                    id_out_activity = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_activity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_out_activitys", x => x.id_out_activity);
                });

            migrationBuilder.CreateTable(
                name: "out_day_periods",
                columns: table => new
                {
                    id_out_day_period = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_period = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_out_day_periods", x => x.id_out_day_period);
                });

            migrationBuilder.CreateTable(
                name: "property_types",
                columns: table => new
                {
                    id_prop_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    prop_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_types", x => x.id_prop_type);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id_service = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_service = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id_service);
                });

            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    id_user_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.id_user_type);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    id_user_type = table.Column<int>(nullable: false),
                    depent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_users_user_types_id_user_type",
                        column: x => x.id_user_type,
                        principalTable: "user_types",
                        principalColumn: "id_user_type",
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
                    description = table.Column<string>(nullable: true),
                    id_service = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id_location);
                    table.ForeignKey(
                        name: "FK_locations_property_types_id_prop_type",
                        column: x => x.id_prop_type,
                        principalTable: "property_types",
                        principalColumn: "id_prop_type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locations_services_id_service",
                        column: x => x.id_service,
                        principalTable: "services",
                        principalColumn: "id_service",
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
                    data_created = table.Column<DateTime>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    time_created = table.Column<TimeSpan>(nullable: false),
                    id_day = table.Column<int>(nullable: false),
                    id_in_day_period = table.Column<int>(nullable: false),
                    id_out_day_period = table.Column<int>(nullable: false),
                    src = table.Column<string>(nullable: true),
                    src_resolved = table.Column<string>(nullable: true),
                    dst = table.Column<string>(nullable: true),
                    subtype = table.Column<string>(nullable: true),
                    sn = table.Column<int>(nullable: false),
                    ssid = table.Column<string>(nullable: true),
                    id_oui = table.Column<string>(nullable: true),
                    stay = table.Column<double>(nullable: false),
                    id_in_activity = table.Column<int>(nullable: false),
                    id_out_activity = table.Column<int>(nullable: false),
                    hours = table.Column<int>(nullable: false),
                    id_day_type = table.Column<int>(nullable: false),
                    id_service = table.Column<int>(nullable: false),
                    returning = table.Column<int>(nullable: false)
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
                        name: "FK_collected_data_day_types_id_day_type",
                        column: x => x.id_day_type,
                        principalTable: "day_types",
                        principalColumn: "id_day_type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_in_activitys_id_in_activity",
                        column: x => x.id_in_activity,
                        principalTable: "in_activitys",
                        principalColumn: "id_in_activity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_in_day_periods_id_in_day_period",
                        column: x => x.id_in_day_period,
                        principalTable: "in_day_periods",
                        principalColumn: "id_in_day_period",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_locations_id_location",
                        column: x => x.id_location,
                        principalTable: "locations",
                        principalColumn: "id_location",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_out_activitys_id_out_activity",
                        column: x => x.id_out_activity,
                        principalTable: "out_activitys",
                        principalColumn: "id_out_activity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collected_data_out_day_periods_id_out_day_period",
                        column: x => x.id_out_day_period,
                        principalTable: "out_day_periods",
                        principalColumn: "id_out_day_period",
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
                name: "IX_collected_data_id_day",
                table: "collected_data",
                column: "id_day");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_day_type",
                table: "collected_data",
                column: "id_day_type");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_in_activity",
                table: "collected_data",
                column: "id_in_activity");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_in_day_period",
                table: "collected_data",
                column: "id_in_day_period");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_location",
                table: "collected_data",
                column: "id_location");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_out_activity",
                table: "collected_data",
                column: "id_out_activity");

            migrationBuilder.CreateIndex(
                name: "IX_collected_data_id_out_day_period",
                table: "collected_data",
                column: "id_out_day_period");

            migrationBuilder.CreateIndex(
                name: "IX_locations_id_prop_type",
                table: "locations",
                column: "id_prop_type");

            migrationBuilder.CreateIndex(
                name: "IX_locations_id_service",
                table: "locations",
                column: "id_service");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collected_data");

            migrationBuilder.DropTable(
                name: "shared_locations");

            migrationBuilder.DropTable(
                name: "days");

            migrationBuilder.DropTable(
                name: "day_types");

            migrationBuilder.DropTable(
                name: "in_activitys");

            migrationBuilder.DropTable(
                name: "in_day_periods");

            migrationBuilder.DropTable(
                name: "out_activitys");

            migrationBuilder.DropTable(
                name: "out_day_periods");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "property_types");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_types");
        }
    }
}
