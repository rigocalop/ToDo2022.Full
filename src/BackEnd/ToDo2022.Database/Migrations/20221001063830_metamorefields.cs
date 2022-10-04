using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo2022.Database.Migrations
{
    public partial class metamorefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 1, 1, 38, 30, 316, DateTimeKind.Local).AddTicks(7450),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 25, 1, 34, 6, 691, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.AddColumn<decimal>(
                name: "Completed",
                schema: "TODO",
                table: "Meta",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 1, 1, 38, 30, 316, DateTimeKind.Local).AddTicks(5373));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                schema: "TODO",
                table: "Meta");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "TODO",
                table: "Meta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 25, 1, 34, 6, 691, DateTimeKind.Local).AddTicks(5681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 1, 1, 38, 30, 316, DateTimeKind.Local).AddTicks(7450));
        }
    }
}
