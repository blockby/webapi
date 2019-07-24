using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class srcColumnFixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "src",
                table: "collected_data",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "src",
                table: "collected_data",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}
