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
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext context)
           : base(context)
       {
           
       }

        public override IEnumerable<Player> GetAll()
        {
            return _context.Set<Player>().Include(x => x.Position).AsEnumerable();
        }
        public Player GetById(int id)
        {
            return _dbSet.Include(x => x.Position).Where(x => x.PlayerId == id).FirstOrDefault();
        }
        
    }
}
