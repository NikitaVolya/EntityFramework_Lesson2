using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLesson.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropetiesGoalsNumberGoalsConcededNumberToFootballTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsConcededNumber",
                table: "FootballTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsNumber",
                table: "FootballTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalsConcededNumber",
                table: "FootballTeams");

            migrationBuilder.DropColumn(
                name: "GoalsNumber",
                table: "FootballTeams");
        }
    }
}
