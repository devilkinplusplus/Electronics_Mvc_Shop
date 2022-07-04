using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreComp.Migrations
{
    public partial class addTwoColumnsToProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProdMadedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdMarca",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdMadedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdMarca",
                table: "Products");
        }
    }
}
