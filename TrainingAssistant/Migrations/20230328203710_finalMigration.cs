using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class finalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingPlan_Training",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_Training",
                table: "Training");

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "IdTraining",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "IdTraining",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "IdPlan",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Training",
                table: "Training",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTrainingPlan",
                table: "Training",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Training_IdTrainingPlan",
                table: "Training",
                column: "IdTrainingPlan");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingPlan_IdTrainingPlan",
                table: "Training",
                column: "IdTrainingPlan",
                principalTable: "TrainingPlan",
                principalColumn: "IdPlan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_User_IdPlan",
                table: "TrainingPlan",
                column: "IdPlan",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingPlan_IdTrainingPlan",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_User_IdPlan",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_Training_IdTrainingPlan",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "IdTrainingPlan",
                table: "Training");

            migrationBuilder.AlterColumn<int>(
                name: "IdPlan",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Training",
                table: "Training",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "IdTraining", "Days", "Name", "Training" },
                values: new object[,]
                {
                    { 1, 3, "Endurance training", null },
                    { 2, 4, "Acrobatic training", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Training_Training",
                table: "Training",
                column: "Training");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingPlan_Training",
                table: "Training",
                column: "Training",
                principalTable: "TrainingPlan",
                principalColumn: "IdPlan");
        }
    }
}
