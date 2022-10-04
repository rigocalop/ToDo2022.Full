using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo2022.Database.Migrations
{
    public partial class fieldCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 2, 23, 19, 2, 319, DateTimeKind.Local).AddTicks(1804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 2, 23, 11, 13, 221, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 2, 23, 19, 2, 319, DateTimeKind.Local).AddTicks(643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 2, 23, 11, 13, 221, DateTimeKind.Local).AddTicks(3945));

            migrationBuilder.AddColumn<int>(
                name: "Completed",
                schema: "TODO",
                table: "Meta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                schema: "TODO",
                table: "Meta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 2, 23, 11, 13, 221, DateTimeKind.Local).AddTicks(4819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 2, 23, 19, 2, 319, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 2, 23, 11, 13, 221, DateTimeKind.Local).AddTicks(3945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 2, 23, 19, 2, 319, DateTimeKind.Local).AddTicks(643));
        }
    }
}
