using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface IPlayerService : IEntityService<Player>
    {
        Player GetById(int id);
    }
}
