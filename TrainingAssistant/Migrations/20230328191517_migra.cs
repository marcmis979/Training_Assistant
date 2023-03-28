using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_Excercise_IdExercise",
                table: "ExerciseMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_MusclePart_IdMusclePart",
                table: "ExerciseMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercises",
                table: "TrainingExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Training_IdTrainings",
                table: "TrainingExercise");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_Excercise_IdExercise",
                table: "ExerciseMuscle",
                column: "IdExercise",
                principalTable: "Excercise",
                principalColumn: "IdExcercise",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_MusclePart_IdMusclePart",
                table: "ExerciseMuscle",
                column: "IdMusclePart",
                principalTable: "MusclePart",
                principalColumn: "IdPart",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercises",
                table: "TrainingExercise",
                column: "IdExcercises",
                principalTable: "Excercise",
                principalColumn: "IdExcercise",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Training_IdTrainings",
                table: "TrainingExercise",
                column: "IdTrainings",
                principalTable: "Training",
                principalColumn: "IdTraining",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_Excercise_IdExercise",
                table: "ExerciseMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_MusclePart_IdMusclePart",
                table: "ExerciseMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Excercise_IdExcercises",
                table: "TrainingExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Training_IdTrainings",
                table: "TrainingExercise");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_Excercise_IdExercise",
                table: "ExerciseMuscle",
                column: "IdExercise",
                principalTable: "Excercise",
                principalColumn: "IdExcercise",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_MusclePart_IdMusclePart",
                table: "ExerciseMuscle",
                column: "IdMusclePart",
                principalTable: "MusclePart",
                principalColumn: "IdPart",
                onDelete: ReferentialAction.Cascade);

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
    }
}
