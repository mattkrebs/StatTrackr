using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.ServiceModel.Request;
using StatTrackr.ServiceModel.Response;
using System;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface ITeamService : IEntityService<TeamRequest, TeamResponse>
    {
        TeamResponse GetById(int id);
        TeamResponse AddPlayerToTeam(int teamId, PlayerRequest player);
        bool Delete(int id);
        TeamResponse Update(int teamId, TeamRequest team);

    }
}
