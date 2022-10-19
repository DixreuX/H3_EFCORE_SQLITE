using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H3_EFCORE_SQLITE.Migrations
{
    public partial class TechCollege5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Tasks_TasksTaskId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "TasksTaskId",
                table: "Todos",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_TasksTaskId",
                table: "Todos",
                newName: "IX_Todos_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Tasks_TaskId",
                table: "Todos",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Tasks_TaskId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Todos",
                newName: "TasksTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_TaskId",
                table: "Todos",
                newName: "IX_Todos_TasksTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Tasks_TasksTaskId",
                table: "Todos",
                column: "TasksTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
