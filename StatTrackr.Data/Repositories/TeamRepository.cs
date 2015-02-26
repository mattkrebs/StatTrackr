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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context)
           : base(context)
       {
           
       }

        public override IEnumerable<Team> GetAll()
        {
            return _context.Set<Team>().Include(x => x.Players).AsEnumerable();
        }
        public Team GetById(int id)
        {
            return _dbSet.Include(x => x.Players).Where(x => x.TeamId == id).FirstOrDefault();
        }

      
    }
}
