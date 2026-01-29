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
                name: "RecruitmentExercises",
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
                    table.PrimaryKey("PK_RecruitmentExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentJobPostings",
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
                    table.PrimaryKey("PK_RecruitmentJobPostings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentExercises_EndDate",
                table: "RecruitmentExercises",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentExercises_IsActive",
                table: "RecruitmentExercises",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentExercises_ReferenceNumber",
                table: "RecruitmentExercises",
                column: "ReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentExercises_StartDate",
                table: "RecruitmentExercises",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJobPostings_ApplicationDeadline",
                table: "RecruitmentJobPostings",
                column: "ApplicationDeadline");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJobPostings_ExerciseId",
                table: "RecruitmentJobPostings",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJobPostings_ExerciseId_IsPublished",
                table: "RecruitmentJobPostings",
                columns: new[] { "ExerciseId", "IsPublished" });

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJobPostings_IsPublished",
                table: "RecruitmentJobPostings",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentJobPostings_ReferenceNumber",
                table: "RecruitmentJobPostings",
                column: "ReferenceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruitmentExercises");

            migrationBuilder.DropTable(
                name: "RecruitmentJobPostings");
        }
    }
}
