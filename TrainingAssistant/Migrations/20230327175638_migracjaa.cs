using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class migracjaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusclePart_Excercise_ExcerciseIdExcercise",
                table: "MusclePart");

            migrationBuilder.DropIndex(
                name: "IX_MusclePart_ExcerciseIdExcercise",
                table: "MusclePart");

            migrationBuilder.DropColumn(
                name: "ExcerciseIdExcercise",
                table: "MusclePart");

            migrationBuilder.CreateTable(
                name: "ExerciseMuscle",
                columns: table => new
                {
                    IdExercise = table.Column<int>(type: "int", nullable: false),
                    IdMusclePart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscle", x => new { x.IdExercise, x.IdMusclePart });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscle_Excercise_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Excercise",
                        principalColumn: "IdExcercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscle_MusclePart_IdMusclePart",
                        column: x => x.IdMusclePart,
                        principalTable: "MusclePart",
                        principalColumn: "IdPart",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MusclePart",
                columns: new[] { "IdPart", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Legs" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscle",
                columns: new[] { "IdExercise", "IdMusclePart" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscle_IdMusclePart",
                table: "ExerciseMuscle",
                column: "IdMusclePart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscle");

            migrationBuilder.DeleteData(
                table: "MusclePart",
                keyColumn: "IdPart",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusclePart",
                keyColumn: "IdPart",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ExcerciseIdExcercise",
                table: "MusclePart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusclePart_ExcerciseIdExcercise",
                table: "MusclePart",
                column: "ExcerciseIdExcercise");

            migrationBuilder.AddForeignKey(
                name: "FK_MusclePart_Excercise_ExcerciseIdExcercise",
                table: "MusclePart",
                column: "ExcerciseIdExcercise",
                principalTable: "Excercise",
                principalColumn: "IdExcercise");
        }
    }
}
