using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentCourseProject.Migrations
{
    public partial class SeedingCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Students",
                newName: "CourseIdentificationCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                newName: "IX_Students_CourseIdentificationCourseId");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Students",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 40);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { 1, "Math", new DateTime(2021, 1, 15, 15, 34, 53, 492, DateTimeKind.Local).AddTicks(8030), new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { 2, "Programming", new DateTime(2021, 1, 15, 15, 34, 53, 527, DateTimeKind.Local).AddTicks(3281), new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { 3, "Data Structures", new DateTime(2021, 1, 15, 15, 34, 53, 527, DateTimeKind.Local).AddTicks(3551), new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseIdentificationCourseId",
                table: "Students",
                column: "CourseIdentificationCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseIdentificationCourseId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "CourseIdentificationCourseId",
                table: "Students",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseIdentificationCourseId",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Students",
                type: "int",
                maxLength: 40,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
