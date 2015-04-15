using AutoMapper;
using StatTrackr.Data.Interfaces;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.ServiceModel.Request;
using StatTrackr.ServiceModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Services
{
    public class GameService : IGameService
    {
        IUnitOfWork _unitOfWork;
        IGameRepository _repository;

        public GameService(IUnitOfWork unitOfWork, IGameRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IEnumerable<GameResponse> GetAll()
        {
            return Mapper.Map<IEnumerable<GameResponse>>(_repository.GetAll());
        }
        public GameResponse GetById(int id)
        {
            var response = Mapper.Map<GameResponse>(_repository.GetById(id));
            response.AwayTeam.Players.ToList().ForEach(x => x.TeamId = response.AwayTeam.TeamId);
            //response.HomeTeam.Players.ToList().ForEach(x=> x.TeamId = response.HomeTeam.TeamId);

            var newlist = new List<PlayerResponse>();
            foreach (var item in response.HomeTeam.Players)
            {
                
                var player = Mapper.Map<PlayerResponse, PlayerResponse>(item);
                //player.PlayerId = item.PlayerId;
                //player.FirstName = item.FirstName;
                //player.LastName = item.LastName;
                //player.Number = item.Number;
                //player.PositionId = item.PositionId;
                //player.Age = item.Age;
                
                player.TeamId = response.HomeTeam.TeamId;
                newlist.Add(player);
            }
            
            response.HomeTeam.Players = newlist;
            
            return response;
        }
        public GameResponse Create(GameRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(Mapper.Map<Game>(request));
            _unitOfWork.Commit();
            return Mapper.Map<GameResponse>(request);
        }

        public GameResponse Update(int id, GameRequest request)
        {
            if (request == null) throw new ArgumentNullException("entity");

            var entity = _repository.GetById(id);

            entity = Mapper.Map<GameRequest, Game>(request, entity);

            _repository.Edit(entity);
            _unitOfWork.Commit();
            return Mapper.Map<GameResponse>(entity);
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) throw new ArgumentNullException("entity");

            _repository.Delete(entity);
            _unitOfWork.Commit();

            return true;
        }

        public GameStatsResponse GetGameStats(int id)
        {
            var entity = _repository.GetById(id);

            var game = GetTotals(entity);

            return game;

        }
        public GameStatsResponse GetTotals(Game game)
        {
            var gameStats = new GameStatsResponse();
            var stats = game.StatLines.OrderByDescending(x => x.CreatedDate).ToList();
            if (stats.Count > 0)
            {
                var homeStatLines = stats.Where(s => s.TeamId == game.HomeTeamId).ToList();
                var awayStatLines = stats.Where(s => s.TeamId == game.AwayTeamId).ToList();

                gameStats.HomeStatTotals = new TeamStatsResponse()
                {
                    Fouls = homeStatLines.Where(x => x.StatTypeId == 10 || x.StatTypeId == 11).Select(x => x.StatType.Value).Sum(),
                    Score = homeStatLines.Where(x => x.StatTypeId == 14 || x.StatTypeId == 16 || x.StatTypeId == 1).Select(x => x.StatType.Value).Sum()
                };
                gameStats.AwayStatTotals = new TeamStatsResponse()
                {
                    Fouls = awayStatLines.Where(x => x.StatTypeId == 10 || x.StatTypeId == 11).Select(x => x.StatType.Value).Sum(),
                    Score = awayStatLines.Where(x => x.StatTypeId == 14 || x.StatTypeId == 16 || x.StatTypeId == 1).Select(x => x.StatType.Value).Sum()
                };

                gameStats.ClockTime = stats.First().ClockTime;

                gameStats.GameStatLines = Mapper.Map<List<StatLineResponse>>(stats);

            }
            return gameStats;
        }
    }
}
