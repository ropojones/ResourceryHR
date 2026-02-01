using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceryHR.Recruitment.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseJobPostingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Requirements = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    Responsibilities = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    Department = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Location = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    EmploymentType = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    SalaryRange = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    NumberOfPositions = table.Column<int>(type: "integer", nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_EndDate",
                table: "Exercises",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_IsActive",
                table: "Exercises",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ReferenceNumber",
                table: "Exercises",
                column: "ReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_StartDate",
                table: "Exercises",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_ApplicationDeadline",
                table: "JobPostings",
                column: "ApplicationDeadline");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_ExerciseId",
                table: "JobPostings",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_ExerciseId_IsPublished",
                table: "JobPostings",
                columns: new[] { "ExerciseId", "IsPublished" });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_IsPublished",
                table: "JobPostings",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_ReferenceNumber",
                table: "JobPostings",
                column: "ReferenceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "JobPostings");
        }
    }
}
