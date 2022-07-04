using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreComp.Migrations
{
    public partial class removeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdMarca",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProdMarca",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
