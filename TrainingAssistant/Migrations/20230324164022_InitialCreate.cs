using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Excercise",
                columns: table => new
                {
                    IdExcercise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BurnedKcal = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercise", x => x.IdExcercise);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.IdPlan);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    TargetWeight = table.Column<double>(type: "float", nullable: false),
                    Tempo = table.Column<double>(type: "float", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "MusclePart",
                columns: table => new
                {
                    IdPart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExcerciseIdExcercise = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusclePart", x => x.IdPart);
                    table.ForeignKey(
                        name: "FK_MusclePart_Excercise_ExcerciseIdExcercise",
                        column: x => x.ExcerciseIdExcercise,
                        principalTable: "Excercise",
                        principalColumn: "IdExcercise");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Training = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.IdTraining);
                    table.ForeignKey(
                        name: "FK_Training_TrainingPlan_Training",
                        column: x => x.Training,
                        principalTable: "TrainingPlan",
                        principalColumn: "IdPlan");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusclePart_ExcerciseIdExcercise",
                table: "MusclePart",
                column: "ExcerciseIdExcercise");

            migrationBuilder.CreateIndex(
                name: "IX_Training_Training",
                table: "Training",
                column: "Training");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusclePart");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Excercise");

            migrationBuilder.DropTable(
                name: "TrainingPlan");
        }
    }
}
