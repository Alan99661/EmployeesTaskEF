using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTask.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMeeting_Employees_EmployeesId",
                table: "EmployeeMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_EmployeesId",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskEnt_Tasks_TaskEntsId",
                table: "EmployeeTaskEnt");

            migrationBuilder.RenameColumn(
                name: "TaskEntsId",
                table: "EmployeeTaskEnt",
                newName: "AssigneesId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeTaskEnt",
                newName: "AssignedTasksId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTaskEnt_TaskEntsId",
                table: "EmployeeTaskEnt",
                newName: "IX_EmployeeTaskEnt_AssigneesId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeMeeting",
                newName: "AttendeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMeeting_Employees_AttendeesId",
                table: "EmployeeMeeting",
                column: "AttendeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_AssigneesId",
                table: "EmployeeTaskEnt",
                column: "AssigneesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskEnt_Tasks_AssignedTasksId",
                table: "EmployeeTaskEnt",
                column: "AssignedTasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMeeting_Employees_AttendeesId",
                table: "EmployeeMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_AssigneesId",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskEnt_Tasks_AssignedTasksId",
                table: "EmployeeTaskEnt");

            migrationBuilder.RenameColumn(
                name: "AssigneesId",
                table: "EmployeeTaskEnt",
                newName: "TaskEntsId");

            migrationBuilder.RenameColumn(
                name: "AssignedTasksId",
                table: "EmployeeTaskEnt",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTaskEnt_AssigneesId",
                table: "EmployeeTaskEnt",
                newName: "IX_EmployeeTaskEnt_TaskEntsId");

            migrationBuilder.RenameColumn(
                name: "AttendeesId",
                table: "EmployeeMeeting",
                newName: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMeeting_Employees_EmployeesId",
                table: "EmployeeMeeting",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_EmployeesId",
                table: "EmployeeTaskEnt",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskEnt_Tasks_TaskEntsId",
                table: "EmployeeTaskEnt",
                column: "TaskEntsId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
