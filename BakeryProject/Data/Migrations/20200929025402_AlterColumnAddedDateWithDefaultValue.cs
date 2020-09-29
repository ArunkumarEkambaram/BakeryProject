using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryProject.Data.Migrations
{
    public partial class AlterColumnAddedDateWithDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 24, 1, 684, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 24, 1, 685, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 24, 1, 685, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.AlterColumn<DateTime>(
                table: "Products",
                name: "AddedDate",
                defaultValue: DateTime.Now
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 17, 17, 448, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 17, 17, 448, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 17, 17, 448, DateTimeKind.Local).AddTicks(9187));
        }
    }
}
