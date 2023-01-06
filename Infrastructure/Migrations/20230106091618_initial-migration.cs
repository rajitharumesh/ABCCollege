using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseSubjectID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollments_CourseSubjects_CourseSubjectID",
                        column: x => x.CourseSubjectID,
                        principalTable: "CourseSubjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Information Technology", "Information Technology" },
                    { 2, "Master Science Of Computer", "Master Science Of Computer" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "BirthDate", "EnrollmentDate", "FirstName", "LastName", "RegistrationNo" },
                values: new object[,]
                {
                    { 1, new DateTime(1926, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marilyn", "Monroe", "" },
                    { 2, new DateTime(1809, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abraham", "Lincoln", "" },
                    { 3, new DateTime(1918, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nelson", "Mandela", "" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Using Visual Studio", "C#" },
                    { 2, "Using Eclips", "JAVA" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "BirthDate", "FirstName", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 6, 13, 16, 18, 190, DateTimeKind.Local).AddTicks(8830), "Teacher 1", "Teacher 1", 0.0 },
                    { 2, new DateTime(2023, 1, 6, 13, 16, 18, 190, DateTimeKind.Local).AddTicks(8848), "Teacher 2", "Teacher 2", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "CourseSubjects",
                columns: new[] { "ID", "CourseID", "SubjectID", "TeacherID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 1 },
                    { 3, 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "ID", "CourseSubjectID", "Grade", "StudentID" },
                values: new object[,]
                {
                    { 1, 1, 0.0, 1 },
                    { 2, 2, 0.0, 1 },
                    { 3, 3, 0.0, 1 },
                    { 4, 2, 0.0, 2 },
                    { 5, 3, 0.0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseID",
                table: "CourseSubjects",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_SubjectID",
                table: "CourseSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_TeacherID",
                table: "CourseSubjects",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseSubjectID",
                table: "Enrollments",
                column: "CourseSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "CourseSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
