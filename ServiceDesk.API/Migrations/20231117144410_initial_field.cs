using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceDesk.API.Migrations
{
    public partial class initial_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStates_TaskStateId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskStates");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStateId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskStateId",
                table: "Tasks");

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskStateId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TaskStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStateId",
                table: "Tasks",
                column: "TaskStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStates_TaskStateId",
                table: "Tasks",
                column: "TaskStateId",
                principalTable: "TaskStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
