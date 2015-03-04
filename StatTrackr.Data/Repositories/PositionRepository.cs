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
    public class PositionRepository : IPositionRepository
    {
       protected DbContext _context;
         protected readonly IDbSet<Position> _dbSet;

         public PositionRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Position>();
        }


         public IEnumerable<Position> GetAll()
        {
            return _dbSet.AsEnumerable<Position>();
        }

    }
}
