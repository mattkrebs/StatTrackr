using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.ServiceModel.Request;
using StatTrackr.ServiceModel.Response;
using System;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface IGameService : IEntityService<GameRequest,GameResponse>
    {
        GameResponse GetById(int id);
        bool Delete(int id);
        GameResponse Update(int id, GameRequest entity);

        GameStatsResponse GetGameStats(int id);


    }
}
