using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantSystem.Data.Migrations
{
    public partial class WaiterOrderRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bills_BillId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "WaiterOrders");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WaiterId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bills_BillId",
                table: "Orders",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_WaiterId",
                table: "Orders",
                column: "WaiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bills_BillId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_WaiterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WaiterOrders",
                columns: table => new
                {
                    WaiterId = table.Column<string>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterOrders", x => new { x.WaiterId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_WaiterOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaiterOrders_AspNetUsers_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaiterOrders_OrderId",
                table: "WaiterOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bills_BillId",
                table: "Orders",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
