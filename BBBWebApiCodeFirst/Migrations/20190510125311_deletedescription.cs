using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class deletedescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "description",
                table: "users");

            migrationBuilder.DropColumn(
                name: "description",
                table: "user_types");

            migrationBuilder.DropColumn(
                name: "description",
                table: "property_types");

            migrationBuilder.DropColumn(
                name: "description",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "description",
                table: "days");

            migrationBuilder.DropColumn(
                name: "description",
                table: "day_types");

            migrationBuilder.DropColumn(
                name: "description",
                table: "day_periods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "user_types",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "property_types",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "days",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "day_types",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "day_periods",
                nullable: true);
        }
    }
}
