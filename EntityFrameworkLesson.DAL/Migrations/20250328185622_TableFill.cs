using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLesson.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TableFill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO FootballTeams (Name, City, Wins, Losses, Draws, GoalsNumber, GoalsConcededNumber)    
            VALUES ('Manchester United', 'Manchester', 3, 0, 2, 10, 5),
                   ('Chelsea', 'London', 1, 1, 3, 5, 5),
                   ('Liverpool', 'Liverpool', 0, 2, 0, 2, 5),
                   ('Arsenal', 'London', 4, 1, 2, 12, 2);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
