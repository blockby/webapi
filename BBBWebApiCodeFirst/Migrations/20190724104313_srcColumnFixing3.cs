using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class srcColumnFixing3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "src",
                table: "collected_data",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "src",
                table: "collected_data",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
