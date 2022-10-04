using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo2022.Database.Migrations
{
    public partial class porcentajeCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 13, 4, 43, 137, DateTimeKind.Local).AddTicks(587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 13, 4, 43, 136, DateTimeKind.Local).AddTicks(9311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.AddColumn<int>(
                name: "PorcentajeTareasCompleted",
                schema: "TODO",
                table: "Meta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeTareasCompleted",
                schema: "TODO",
                table: "Meta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(3111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 13, 4, 43, 137, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "TODO",
                table: "Meta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 3, 12, 51, 11, 141, DateTimeKind.Local).AddTicks(1219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 3, 13, 4, 43, 136, DateTimeKind.Local).AddTicks(9311));
        }
    }
}
