using EntityFrameworkLesson.DAL.Entities;

namespace EntityFrameworkLesson.ConsoleApp
{
    internal class MenuServise
    {
        struct MenuItem
        {
            public string Caption { get; set; }
            public Action Action { get; set; }
        }

        private FootballTeamService _footballteam_service;
        private bool _menu_cycle;
        private MenuItem[] _menu_items;


        public MenuServise()
        {
            _footballteam_service = new FootballTeamService();
            _menu_cycle = false;
            _menu_items = new MenuItem[] {
                new MenuItem { Caption = "Show all teams", Action = () => ShowAllTeams() },
                new MenuItem { Caption = "Find team by name", Action = () => FindTeamByName() },
                new MenuItem { Caption = "Find team by city name", Action = () => FindTeamByCityName() },
                new MenuItem { Caption = "Find team by name and city name", Action = () => FindTeamByNameCityName() },
                new MenuItem { Caption = "Show leaders", Action = () => ShowLeaders() },
                new MenuItem { Caption = "Show outsiders", Action = () => ShowOutsiders() },
                new MenuItem { Caption = "Show most drawn teams", Action = () => ShowMostDrawnTeams() },
                new MenuItem { Caption = "Show most goals conceder team", Action = () => ShowMostGoalsConcederTeams() },
                new MenuItem { Caption = "Show most goals team", Action = () => ShowMostGoalsTeams() },
                new MenuItem { Caption = "Add new team", Action = () => AddNewTeam() },
                new MenuItem { Caption = "Update team", Action = () => UpdateTeam() },
                new MenuItem { Caption = "Delete team", Action = () => DeleteTeam() },
                new MenuItem { Caption = "Exit", Action = () => StopMenu() },
            };
        }

        private void StopMenu()
        {
            Console.WriteLine("Goodbye!");
            _menu_cycle = false;
        }

        private void PrintTeam(FootballTeam team)
        {
            Console.WriteLine($"Id: {team.Id}, Name: {team.Name}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}, GoalsNumber: {team.GoalsNumber}, GoalsConcededNumber: {team.GoalsConcededNumber}");
        }

        private void PrintAll(IEnumerable<FootballTeam> teams)
        {
            foreach (var team in teams)
                PrintTeam(team);
        }

        private void ConsolePause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private string ConsoleInputString(string message)
        {
            string? input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (input == null)
                    Console.WriteLine("Invalid input");
            } while (input == null);
            return input;
        }

        private FootballTeam UserInputFoorballTeam()
        {
            string name = ConsoleInputString("Enter team name: ");
            string city = ConsoleInputString("Enter city name: ");
            int winds = Convert.ToInt32(ConsoleInputString("Enter wins: "));
            int losses = Convert.ToInt32(ConsoleInputString("Enter losses: "));
            int draws = Convert.ToInt32(ConsoleInputString("Enter draws: "));
            int goals = Convert.ToInt32(ConsoleInputString("Enter goals: "));
            int goals_conceded = Convert.ToInt32(ConsoleInputString("Enter goals conceded: "));
            return new FootballTeam 
            { 
                Name = name, 
                City = city,
                Wins = winds, 
                Losses = losses, 
                Draws = draws, 
                GoalsNumber = goals, 
                GoalsConcededNumber = goals_conceded
            };
        }


        private void FindTeamByName()
        {
            Console.Write("Enter team name: ");
            string? name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Invalid name");
                return;
            }
            FootballTeam? team = _footballteam_service.GetByName(name);
            if (team == null)
            {
                Console.WriteLine("Team not found");
                return;
            }
            PrintTeam(team);
        }

        private void FindTeamByCityName()
        {
            Console.Write("Enter city name: ");
            string? city_name = Console.ReadLine();
            if (city_name == null)
            {
                Console.WriteLine("Invalid name");
                return;
            }
            FootballTeam? team = _footballteam_service.GetByCity(city_name);
            if (team == null)
            {
                Console.WriteLine("Team not found");
                return;
            }
            PrintTeam(team);
        }

        private void FindTeamByNameCityName()
        {
            Console.Write("Enter team name: ");
            string? name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Invalid name");
                return;
            }
            Console.Write("Enter city name: ");
            string? city_name = Console.ReadLine();
            if (city_name == null)
            {
                Console.WriteLine("Invalid city name");
                return;
            }
            FootballTeam? team = _footballteam_service.GetByNameCityName(name, city_name);
            if (team == null)
            {
                Console.WriteLine("Team not found");
                return;
            }
            PrintTeam(team);
        }


        private void ShowAllTeams()
        {
            PrintAll(_footballteam_service.GetAll());
        }


        public void ShowLeaders()
        {
            Console.WriteLine("Leaders:");
            PrintAll(_footballteam_service.GetMostWinTeams());
        }

        public void ShowOutsiders()
        {
            Console.WriteLine("Outsiders:");
            PrintAll(_footballteam_service.GetMostLosseTeams());
        }

        public void ShowMostDrawnTeams()
        {
            Console.WriteLine("Most draws:");
            PrintAll(_footballteam_service.GetMostDrawnTeams());
        }

        public void ShowMostGoalsConcederTeams()
        {
            Console.WriteLine("Most goals conceder teams:");
            PrintAll(_footballteam_service.GetMostGoalsConcededTeams());
        }

        public void ShowMostGoalsTeams()
        {
            Console.WriteLine("Most goals teams:");
            PrintAll(_footballteam_service.GetMostGoalsTeams());
        }


        public void AddNewTeam()
        {
            FootballTeam team = UserInputFoorballTeam();
            if (_footballteam_service.FindTeam(team.Name, team.City))
            {
                Console.WriteLine("Team already exists");
                return;
            }
            _footballteam_service.Add(team);
            Console.WriteLine("Team added");
        }

        public void UpdateTeam()
        {
            Console.Write("Enter team id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            FootballTeam? team = _footballteam_service.GetById(id);
            if (team == null)
            {
                Console.WriteLine("Team not found");
                return;
            }
            
            Console.WriteLine("Current team: ");
            PrintTeam(team);
            Console.WriteLine("Do you want to update this team?");
            string? answer = Console.ReadLine();
            if (answer == null || (answer.ToLower() != "yes" && answer.ToLower() != "y"))
            {
                Console.WriteLine("Update canceled");
                return;
            }
            Console.WriteLine("Enter new team data:");
            FootballTeam new_team = UserInputFoorballTeam();
            if (new_team.Name != "")
                team.Name = new_team.Name;
            if (new_team.City != "")
                team.Name = new_team.Name;
            team.Wins = new_team.Wins;
            team.Losses = new_team.Losses;
            team.Draws = new_team.Draws;
            team.GoalsNumber = new_team.GoalsNumber;
            team.GoalsConcededNumber = new_team.GoalsConcededNumber;
            _footballteam_service.Update(team);
            Console.WriteLine("Team updated");
        }

        public void DeleteTeam()
        {
            Console.Write("Enter team name to delete: ");
            string? name = Console.ReadLine();
            Console.Write("Enter city name to delete: ");
            string? city_name = Console.ReadLine();
            if (name == null || city_name == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            FootballTeam? team = _footballteam_service.GetByNameCityName(name, city_name);
            if (team == null)
            {
                Console.WriteLine("Team not found");
                return;
            }
            PrintTeam(team);
            Console.Write("Do you want to delete this team?: ");
            string? answer = Console.ReadLine();
            if (answer == null || (answer.ToLower() != "yes" && answer.ToLower() != "y"))
            {
                Console.WriteLine("Delete canceled");
                return;
            }
            _footballteam_service.Delete(team);
            Console.WriteLine("Team deleted");
        }


        public void ShowMenu()
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < _menu_items.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_menu_items[i].Caption}");
            }
        }

        public int UserChoice()
        {
            try
            {
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine()) - 1;
                if (choice < 0 || choice >= _menu_items.Length)
                {
                    Console.WriteLine("Invalid choice");
                    return -1;
                }
                return choice;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return -1;
            }
        }

        public void Main()
        {
            _menu_cycle = true;
            while (_menu_cycle)
            {
                Console.Clear();
                ShowMenu();
                int user_choice = UserChoice();

                if (user_choice == -1)
                {
                    ConsolePause();
                    continue;
                }
                Console.Clear();
                _menu_items[user_choice].Action();
                ConsolePause();
            }
        }
    }
}
