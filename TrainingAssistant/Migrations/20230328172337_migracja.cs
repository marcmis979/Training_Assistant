using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class migracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingExercise",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "int", nullable: false),
                    IdExcercise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercise", x => new { x.IdTraining, x.IdExcercise });
                    table.ForeignKey(
                        name: "FK_TrainingExercise_Excercise_IdExcercise",
                        column: x => x.IdExcercise,
                        principalTable: "Excercise",
                        principalColumn: "IdExcercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingExercise_Training_IdTraining",
                        column: x => x.IdTraining,
                        principalTable: "Training",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TrainingExercise",
                columns: new[] { "IdExcercise", "IdTraining" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercise_IdExcercise",
                table: "TrainingExercise",
                column: "IdExcercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingExercise");
        }
    }
}
