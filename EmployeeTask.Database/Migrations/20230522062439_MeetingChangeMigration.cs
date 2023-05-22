using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTask.Database.Migrations
{
    /// <inheritdoc />
    public partial class MeetingChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Meeting_MeetingId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_AssigneesId",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTaskEnt",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MeetingId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "AssigneesId",
                table: "EmployeeTaskEnt",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "EmployeeTaskEnt",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskId",
                table: "EmployeeTaskEnt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTaskEnt",
                table: "EmployeeTaskEnt",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeMeeting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeetingId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskEnt_EmployeeId",
                table: "EmployeeTaskEnt",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeeting_EmployeeId",
                table: "EmployeeMeeting",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeeting_MeetingId",
                table: "EmployeeMeeting",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_EmployeeId",
                table: "EmployeeTaskEnt",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_EmployeeId",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropTable(
                name: "EmployeeMeeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTaskEnt",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTaskEnt_EmployeeId",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeTaskEnt");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "EmployeeTaskEnt");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeTaskEnt",
                newName: "AssigneesId");

            migrationBuilder.AddColumn<string>(
                name: "MeetingId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTaskEnt",
                table: "EmployeeTaskEnt",
                columns: new[] { "AssigneesId", "AssingnedTasksId" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MeetingId",
                table: "Employees",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Meeting_MeetingId",
                table: "Employees",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskEnt_Employees_AssigneesId",
                table: "EmployeeTaskEnt",
                column: "AssigneesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
