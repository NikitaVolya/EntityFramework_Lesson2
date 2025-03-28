using EntityFrameworkLesson.DAL;
using EntityFrameworkLesson.DAL.Entities;

namespace EntityFrameworkLesson.ConsoleApp
{
    internal class Program
    {

        private static FootballTeamRepository _repository;

        static void Main(string[] args)
        {
            _repository = new FootballTeamRepository();
            List<FootballTeam> response = _repository.GetAll();

            Console.WriteLine("Teams:");
            foreach (FootballTeam team in response)
            {
                Console.WriteLine($"Name: {team.Name}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}, GoalsNumber: {team.GoalsNumber}, GoalsConcededNumber: {team.GoalsConcededNumber}");
            }
        }
    }
}
