using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class databasee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Excercise",
                columns: new[] { "IdExcercise", "BurnedKcal", "Name", "Time", "Type" },
                values: new object[,]
                {
                    { 1, 0.38, "Squat", 3, 4 },
                    { 2, 0.28999999999999998, "Push-up", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercise",
                keyColumn: "IdExcercise",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Excercise",
                keyColumn: "IdExcercise",
                keyValue: 2);
        }
    }
}
