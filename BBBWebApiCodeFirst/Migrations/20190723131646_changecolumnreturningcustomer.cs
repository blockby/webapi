using Microsoft.EntityFrameworkCore.Migrations;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class changecolumnreturningcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "returning",
                table: "collected_data",
                newName: "returning_customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "returning_customer",
                table: "collected_data",
                newName: "returning");
        }
    }
}
