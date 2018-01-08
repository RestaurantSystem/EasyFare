using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantSystem.Data.Migrations
{
    public partial class CascadeDeleteOnReservatioNWhenDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableNumber",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableNumber",
                table: "Reservations",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableNumber",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableNumber",
                table: "Reservations",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
