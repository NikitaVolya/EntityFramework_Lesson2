using EntityFrameworkLesson.DAL;
using EntityFrameworkLesson.DAL.Entities;

namespace EntityFrameworkLesson.ConsoleApp
{
    internal class Program
    {

        private static FootballTeamRepository _repository;

        /*static void Exercice3()
        {
            List<FootballTeam> teams = new List<FootballTeam> {
                new FootballTeam { Name = "Manchester United", City = "Manchester", Wins = 3, Losses = 0, Draws = 2 },
                new FootballTeam { Name = "Chelsea", City = "London", Wins = 1, Losses = 1, Draws = 3  },
                new FootballTeam { Name = "Liverpool", City = "Liverpool", Wins = 0, Losses = 2, Draws = 0  },
                new FootballTeam { Name = "Arsenal", City = "London", Wins = 2, Losses = 1, Draws = 2  }
            };
            _repository.AddRange(teams);

            List<FootballTeam> response = _repository.GetAll();

            Console.WriteLine("Teams:");
            foreach (FootballTeam team in response)
            {
                Console.WriteLine($"Name: {team.Name}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}");
            }
            Console.ReadKey();
        }*/

        static void Main(string[] args)
        {
            _repository = new FootballTeamRepository();
            //Exercice3();
        }
    }
}
