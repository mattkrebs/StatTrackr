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
    public class StatLineRepsoitory : Repository<StatLine>, IStatLineRepository
    {
        public StatLineRepsoitory(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<StatLine> GetAll()
        {
            return _context.Set<StatLine>().AsEnumerable();
        }


        public StatLine GetById(Guid id)
        {
            return _dbSet.Where(x => x.StatLineId == id).FirstOrDefault();
        }

        public IEnumerable<StatLine> GetAllByGameId(int id)
        {
            return _dbSet.Where(x => x.GameId == id);
        }
    }
}
