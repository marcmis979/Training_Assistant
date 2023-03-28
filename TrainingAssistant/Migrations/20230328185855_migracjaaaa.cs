using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class migracjaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingExercise",
                keyColumns: new[] { "IdExcercises", "IdTrainings" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "IdTraining",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "IdTraining", "Days", "Name", "Training" },
                values: new object[] { 3, 5, "Strength training", null });

            migrationBuilder.InsertData(
                table: "TrainingExercise",
                columns: new[] { "IdExcercises", "IdTrainings" },
                values: new object[] { 1, 3 });
        }
    }
}
