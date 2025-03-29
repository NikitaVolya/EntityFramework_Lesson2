using EntityFrameworkLesson.DAL.Entities;

namespace EntityFrameworkLesson.DAL
{
    public class FootballTeamRepository
    {
        private AppDbContext _context;
        public FootballTeamRepository() { 
            _context = new AppDbContext();
        }

        public void Add(FootballTeam team)
        {
            _context.FootballTeams.Add(team);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<FootballTeam> teams)
        {
            _context.FootballTeams.AddRange(teams);
            _context.SaveChanges();
        }

        public void Update(FootballTeam team)
        {
            _context.FootballTeams.Update(team);
            _context.SaveChanges();
        }

        public void Delete(FootballTeam team)
        {
            _context.FootballTeams.Remove(team);
            _context.SaveChanges();
        }

        public FootballTeam? GetById(int id)
        {
            return _context.FootballTeams.Find(id);
        }

        public IEnumerable<FootballTeam> GetTeamsByName(string name)
        {
            return _context.FootballTeams.Where(x => x.Name == name);
        }

        public IEnumerable<FootballTeam> GetTeamsByCity(string city_name)
        {
            return _context.FootballTeams.Where(x => x.City == city_name);
        }

        public IEnumerable<FootballTeam> GetTeamsByNameCityName(string name, string city_name)
        {
            return _context.FootballTeams.Where(x => x.Name == name && x.City == city_name);
        }

        public IEnumerable<FootballTeam> GetByNameCity(string name, string city_name)
        {
            return _context.FootballTeams.Where(x => x.Name == name && x.City == city_name);
        }

        public IEnumerable<FootballTeam> GetAll()
        {
            return _context.FootballTeams;
        }
    }
}
