using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantSystem.Data.Migrations
{
    public partial class ListOfProductsOnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
