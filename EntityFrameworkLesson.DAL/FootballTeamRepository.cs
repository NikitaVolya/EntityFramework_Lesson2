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

        public List<FootballTeam> GetAll()
        {
            return _context.FootballTeams.ToList();
        }
    }
}
