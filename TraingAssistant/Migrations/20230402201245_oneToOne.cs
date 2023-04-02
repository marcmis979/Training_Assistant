using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraingAssistantDAL.Migrations
{
    /// <inheritdoc />
    public partial class oneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanTraings_Trainings_TrainigId",
                table: "TrainingPlanTraings");

            migrationBuilder.RenameColumn(
                name: "TrainigId",
                table: "TrainingPlanTraings",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlanTraings_TrainigId",
                table: "TrainingPlanTraings",
                newName: "IX_TrainingPlanTraings_TrainingId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    TargetWeight = table.Column<double>(type: "float", nullable: false),
                    Tempo = table.Column<double>(type: "float", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_TrainingPlans_Id",
                        column: x => x.Id,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Height", "Name", "Password", "Sex", "Surname", "TargetWeight", "Tempo", "Weight" },
                values: new object[,]
                {
                    { 1, 22, "xDD", 0, "Rafał", "xyz", false, "Hońca", 0.0, 0.0, 0.0 },
                    { 2, 22, "xDD", 0, "Marcin", "xyz", true, "Misiuna", 0.0, 0.0, 0.0 },
                    { 3, 33, "xDD", 0, "Mateusz", "xyz", false, "Bachowski", 0.0, 0.0, 0.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanTraings_Trainings_TrainingId",
                table: "TrainingPlanTraings",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanTraings_Trainings_TrainingId",
                table: "TrainingPlanTraings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TrainingPlans");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "TrainingPlanTraings",
                newName: "TrainigId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlanTraings_TrainingId",
                table: "TrainingPlanTraings",
                newName: "IX_TrainingPlanTraings_TrainigId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanTraings_Trainings_TrainigId",
                table: "TrainingPlanTraings",
                column: "TrainigId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
