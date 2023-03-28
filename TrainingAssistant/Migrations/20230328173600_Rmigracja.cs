using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class Rmigracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "IdTraining", "Days", "Name", "Training" },
                values: new object[,]
                {
                    { 1, 3, "Endurance training", null },
                    { 2, 4, "Acrobatic training", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "IdTraining",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "IdTraining",
                keyValue: 2);
        }
    }
}
