namespace RestaurantSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ProductWitNoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tables_TableNumber",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TableNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableNumber",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TableNumber",
                table: "Products",
                column: "TableNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tables_TableNumber",
                table: "Products",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}