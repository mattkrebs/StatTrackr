using StatTrackr.Data.Interfaces;
using StatTrackr.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(DbContext context)
           : base(context)
       {
           
       }

        public override IEnumerable<Game> GetAll()
        {
            return _context.Set<Game>().AsEnumerable();
        }
        public Game GetById(int id)
        {
            return _dbSet.Include(x => x.HomeTeam).Include(x => x.AwayTeam).Include(x => x.StatLines).Where(x => x.GameId == id).FirstOrDefault();
        }
    }
}
