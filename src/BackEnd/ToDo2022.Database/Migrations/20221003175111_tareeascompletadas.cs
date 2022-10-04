using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo2022.Database.Migrations
{
    public partial class tareeascompletadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Completed",
                schema: "TODO",
                table: "Meta",
                newName: "TotalTareasSelected");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(3111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 7, 21, 7, 156, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(1219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 7, 21, 7, 156, DateTimeKind.Local).AddTicks(5183));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalTareasSelected",
                schema: "TODO",
                table: "Meta",
                newName: "Completed");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 7, 21, 7, 156, DateTimeKind.Local).AddTicks(6252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 7, 21, 7, 156, DateTimeKind.Local).AddTicks(5183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(1219));
        }
    }
}
