using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryProject.Data.Migrations
{
    public partial class AlterColumnAddedDateWithDefaultValue1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 29, 49, 252, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 29, 49, 253, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 9, 29, 8, 29, 49, 253, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.AlterColumn<DateTime>(name: "AddedDate", table: "Products", oldDefaultValue: DateTime.Now, defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
