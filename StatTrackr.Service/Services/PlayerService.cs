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
    public class PlayerService : IPlayerService
    {
        IUnitOfWork _unitOfWork;
        IPlayerRepository _repository;
        ITeamRepository _teamRepository;

        public PlayerService(IUnitOfWork unitOfWork, IPlayerRepository playerRespository, ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = playerRespository;
            _teamRepository = teamRepository;
        }
        public IEnumerable<PlayerResponse> GetAll()
        {
            return Mapper.Map<IEnumerable<PlayerResponse>>(_repository.GetAll());
        }
        public PlayerResponse GetById(int id)
        {
            return Mapper.Map<PlayerResponse>(_repository.GetById(id));
        }
        public IEnumerable<PlayerResponse> GetAvailablePlayersByTeamId(int teamId)
        {
            var teamPlayers = _teamRepository.GetById(teamId);
            var players = _repository.GetAll();

            var query = from t in players
                        where !(from p in teamPlayers.Players
                                select p.PlayerId).Contains(t.PlayerId)
                        select t;

            return Mapper.Map<IEnumerable<PlayerResponse>>(query);
        }
        public PlayerResponse Create(PlayerRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("entity");
            }
            var response = _repository.Add(Mapper.Map<Player>(request));
            _unitOfWork.Commit();
            return Mapper.Map<PlayerResponse>(response);
        }

        public PlayerResponse Update(int id, PlayerRequest request)
        {
            if (request == null) throw new ArgumentNullException("entity");

            var entity = _repository.GetById(id);

            entity = Mapper.Map<PlayerRequest, Player>(request, entity);

            _repository.Edit(entity);
            _unitOfWork.Commit();
            return Mapper.Map<PlayerResponse>(entity);
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) throw new ArgumentNullException("entity");

            _repository.Delete(entity);
            _unitOfWork.Commit();
            return true;
        }

     
    }
}
