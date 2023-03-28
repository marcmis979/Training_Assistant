using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class finalfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercise",
                table: "TrainingExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Training_IdTraining",
                table: "TrainingExercise");

            migrationBuilder.RenameColumn(
                name: "IdExcercise",
                table: "TrainingExercise",
                newName: "IdExcercises");

            migrationBuilder.RenameColumn(
                name: "IdTraining",
                table: "TrainingExercise",
                newName: "IdTrainings");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExercise_IdExcercise",
                table: "TrainingExercise",
                newName: "IX_TrainingExercise_IdExcercises");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercises",
                table: "TrainingExercise",
                column: "IdExcercises",
                principalTable: "Excercise",
                principalColumn: "IdExcercise",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Training_IdTrainings",
                table: "TrainingExercise",
                column: "IdTrainings",
                principalTable: "Training",
                principalColumn: "IdTraining",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercises",
                table: "TrainingExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Training_IdTrainings",
                table: "TrainingExercise");

            migrationBuilder.RenameColumn(
                name: "IdExcercises",
                table: "TrainingExercise",
                newName: "IdExcercise");

            migrationBuilder.RenameColumn(
                name: "IdTrainings",
                table: "TrainingExercise",
                newName: "IdTraining");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExercise_IdExcercises",
                table: "TrainingExercise",
                newName: "IX_TrainingExercise_IdExcercise");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercise",
                table: "TrainingExercise",
                column: "IdExcercise",
                principalTable: "Excercise",
                principalColumn: "IdExcercise",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Training_IdTraining",
                table: "TrainingExercise",
                column: "IdTraining",
                principalTable: "Training",
                principalColumn: "IdTraining",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
