using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraingAssistantDAL.Migrations
{
    /// <inheritdoc />
    public partial class DataChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exerciseMuscleParts_Exercises_ExercisesId",
                table: "exerciseMuscleParts");

            migrationBuilder.DropForeignKey(
                name: "FK_exerciseMuscleParts_MuscleParts_MusclePartsId",
                table: "exerciseMuscleParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exerciseMuscleParts",
                table: "exerciseMuscleParts");

            migrationBuilder.RenameTable(
                name: "exerciseMuscleParts",
                newName: "ExerciseMuscleParts");

            migrationBuilder.RenameIndex(
                name: "IX_exerciseMuscleParts_MusclePartsId",
                table: "ExerciseMuscleParts",
                newName: "IX_ExerciseMuscleParts_MusclePartsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseMuscleParts",
                table: "ExerciseMuscleParts",
                columns: new[] { "ExercisesId", "MusclePartsId" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "BurnedKcal", "Name", "Time", "Type" },
                values: new object[,]
                {
                    { 1, 0.0, "Bench press", 0, 0 },
                    { 2, 0.0, "Squat", 0, 0 },
                    { 3, 0.0, "Deadlift", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "MuscleParts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Legs" },
                    { 3, "Back" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscleParts",
                columns: new[] { "ExercisesId", "MusclePartsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscleParts_Exercises_ExercisesId",
                table: "ExerciseMuscleParts",
                column: "ExercisesId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscleParts_MuscleParts_MusclePartsId",
                table: "ExerciseMuscleParts",
                column: "MusclePartsId",
                principalTable: "MuscleParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscleParts_Exercises_ExercisesId",
                table: "ExerciseMuscleParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscleParts_MuscleParts_MusclePartsId",
                table: "ExerciseMuscleParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseMuscleParts",
                table: "ExerciseMuscleParts");

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleParts",
                keyColumns: new[] { "ExercisesId", "MusclePartsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleParts",
                keyColumns: new[] { "ExercisesId", "MusclePartsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleParts",
                keyColumns: new[] { "ExercisesId", "MusclePartsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleParts",
                keyColumns: new[] { "ExercisesId", "MusclePartsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleParts",
                keyColumns: new[] { "ExercisesId", "MusclePartsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MuscleParts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MuscleParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MuscleParts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "ExerciseMuscleParts",
                newName: "exerciseMuscleParts");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseMuscleParts_MusclePartsId",
                table: "exerciseMuscleParts",
                newName: "IX_exerciseMuscleParts_MusclePartsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exerciseMuscleParts",
                table: "exerciseMuscleParts",
                columns: new[] { "ExercisesId", "MusclePartsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_exerciseMuscleParts_Exercises_ExercisesId",
                table: "exerciseMuscleParts",
                column: "ExercisesId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exerciseMuscleParts_MuscleParts_MusclePartsId",
                table: "exerciseMuscleParts",
                column: "MusclePartsId",
                principalTable: "MuscleParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
