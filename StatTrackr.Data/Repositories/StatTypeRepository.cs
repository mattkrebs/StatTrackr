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
   public class StatTypeRepository: IStatTypeRepository
    {
         protected DbContext _context;
         protected readonly IDbSet<StatType> _dbSet;

        public StatTypeRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<StatType>();
        }


        public IEnumerable<StatType> GetAll()
        {
            return _dbSet.AsEnumerable<StatType>();
        }

      
    }
}
