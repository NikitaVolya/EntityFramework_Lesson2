using EntityFrameworkLesson.DAL;
using EntityFrameworkLesson.DAL.Entities;

namespace EntityFrameworkLesson.ConsoleApp
{

    internal class FootballTeamService
    {
        private FootballTeamRepository _repository;

        public FootballTeamService()
        {
            _repository = new FootballTeamRepository();
        }

        public void Add(FootballTeam team) => _repository.Add(team);

        public void AddRange(IEnumerable<FootballTeam> teams)
        {
            _repository.AddRange(teams);
        }

        public void Update(FootballTeam team)
        {
            _repository.Update(team);
        }

        public void Delete(FootballTeam team)
        {
            _repository.Delete(team);
        }

        public FootballTeam? GetById(int id)
        {
            FootballTeam? rep = _repository.GetById(id);

            return rep == null
                ? _repository.GetAll().FirstOrDefault()
                : rep;
        }

        public FootballTeam? GetByName(string name)
        {
            return _repository.GetTeamsByName(name).FirstOrDefault();
        }

        public FootballTeam? GetByCity(string city_name)
        {
            return _repository.GetTeamsByCity(city_name).FirstOrDefault();
        }

        public FootballTeam? GetByNameCityName(string name, string city_name)
        {
            return _repository.GetByNameCity(name, city_name).FirstOrDefault();
        }

        public bool FindTeam(string name, string city_name)
        {
            return GetByNameCityName(name, city_name) != null;
        }

        public IEnumerable<FootballTeam> GetAll() => _repository.GetAll();

        public IEnumerable<FootballTeam> GetMostWinTeams(bool desending = false)
        {
            var teams = _repository.GetAll().OrderByDescending(x => x.Wins);
            FootballTeam? most_loss_team = teams.FirstOrDefault();
            if (most_loss_team == null)
                return teams;
            return teams.Where(x => x.Wins == most_loss_team.Wins);
        }

        public IEnumerable<FootballTeam> GetMostLosseTeams()
        {
            var teams = _repository.GetAll().OrderByDescending(x => x.Losses);
            FootballTeam? most_loss_team = teams.FirstOrDefault();
            if (most_loss_team == null)
                return teams;
            return teams.Where(x => x.Losses == most_loss_team.Losses);
        }
        public IEnumerable<FootballTeam> GetMostDrawnTeams()
        {
            var teams = _repository.GetAll().OrderByDescending(x => x.Draws);
            FootballTeam? most_loss_team = teams.FirstOrDefault();
            if (most_loss_team == null)
                return teams;
            return teams.Where(x => x.Draws == most_loss_team.Draws);
        }

        public IEnumerable<FootballTeam> GetMostGoalsTeams()
        {
            var teams = _repository.GetAll().OrderByDescending(x => x.GoalsNumber);
            FootballTeam? most_loss_team = teams.FirstOrDefault();
            if (most_loss_team == null)
                return teams;
            return teams.Where(x => x.GoalsNumber == most_loss_team.GoalsNumber);
        }

        public IEnumerable<FootballTeam> GetMostGoalsConcededTeams()
        {
            var teams = _repository.GetAll().OrderByDescending(x => x.GoalsConcededNumber);
            FootballTeam? most_loss_team = teams.FirstOrDefault();
            if (most_loss_team == null)
                return teams;
            return teams.Where(x => x.GoalsConcededNumber == most_loss_team.GoalsConcededNumber);
        }

        public IEnumerable<FootballTeam> GetOrderByName(bool desending = false)
        {
            return desending
                ? _repository.GetAll().OrderByDescending(x => x.Name)
                : _repository.GetAll().OrderBy(x => x.Name);
        }

    }
}
