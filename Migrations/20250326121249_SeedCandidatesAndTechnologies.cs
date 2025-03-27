using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CandidateProfileSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedCandidatesAndTechnologies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "TechnologyName" },
                values: new object[,]
                {
                    { 1, "Java 1" },
                    { 2, "C#" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DegreeCompletionYear", "DegreeName", "Email", "Name", "TechnologyId" },
                values: new object[,]
                {
                    { 1, "9878", 2025, "Btech", "rahulg@gmail.com", "Rahul", 1 },
                    { 2, "9879", 2025, "Btech", "sky@gmail.com", "Sky", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_TechnologyId",
                table: "Candidates",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Technologies_TechnologyId",
                table: "Candidates",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Technologies_TechnologyId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_TechnologyId",
                table: "Candidates");

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
