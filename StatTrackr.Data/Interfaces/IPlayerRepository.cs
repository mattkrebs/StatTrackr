using StatTrackr.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Data.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetById(int id);
    }
}
