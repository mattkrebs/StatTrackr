using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.ServiceModel.Request;
using StatTrackr.ServiceModel.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface IPlayerService : IEntityService<PlayerRequest, PlayerResponse>
    {
        PlayerResponse GetById(int id);
        bool Delete(int id);
        PlayerResponse Update(int id, PlayerRequest entity);

        IEnumerable<PlayerResponse> GetAvailablePlayersByTeamId(int teamId);

        
    }
}
