using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class add_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "depent",
                table: "users",
                newName: "depend");

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
                table: "out_day_periods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "out_activitys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "in_day_periods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "in_activitys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "day_types",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "out_day_periods");

            migrationBuilder.DropColumn(
                name: "description",
                table: "out_activitys");

            migrationBuilder.DropColumn(
                name: "description",
                table: "in_day_periods");

            migrationBuilder.DropColumn(
                name: "description",
                table: "in_activitys");

            migrationBuilder.DropColumn(
                name: "description",
                table: "day_types");

            migrationBuilder.RenameColumn(
                name: "depend",
                table: "users",
                newName: "depent");
        }
    }
}
