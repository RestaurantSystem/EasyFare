namespace RestaurantSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TableOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableProduct_Products_ProductId",
                table: "TableProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TableProduct_Tables_TableNumber",
                table: "TableProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableProduct",
                table: "TableProduct");

            migrationBuilder.RenameTable(
                name: "TableProduct",
                newName: "TableProducts");

            migrationBuilder.RenameIndex(
                name: "IX_TableProduct_ProductId",
                table: "TableProducts",
                newName: "IX_TableProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableProducts",
                table: "TableProducts",
                columns: new[] { "TableNumber", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TableProducts_Products_ProductId",
                table: "TableProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableProducts_Tables_TableNumber",
                table: "TableProducts",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableProducts_Products_ProductId",
                table: "TableProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TableProducts_Tables_TableNumber",
                table: "TableProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableProducts",
                table: "TableProducts");

            migrationBuilder.RenameTable(
                name: "TableProducts",
                newName: "TableProduct");

            migrationBuilder.RenameIndex(
                name: "IX_TableProducts_ProductId",
                table: "TableProduct",
                newName: "IX_TableProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableProduct",
                table: "TableProduct",
                columns: new[] { "TableNumber", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TableProduct_Products_ProductId",
                table: "TableProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableProduct_Tables_TableNumber",
                table: "TableProduct",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}