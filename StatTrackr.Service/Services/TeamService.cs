using AutoMapper;
using StatTrackr.Data.Interfaces;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.Service.Models.Request;
using StatTrackr.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Services
{
    public class TeamService : IEntityService<TeamRequest, TeamResponse>, ITeamService
    {
        IUnitOfWork _unitOfWork;
        ITeamRepository _repository;
        IPlayerRepository _playerRepository;

        public TeamService(IUnitOfWork unitOfWork, ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = teamRepository;
            _playerRepository = playerRepository;
        }
        public TeamResponse GetById(int id)
        {
            return Mapper.Map<TeamResponse>(_repository.GetById(id));
        }


        public TeamResponse Create(TeamRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("entity");
            }
            var response = _repository.Add(Mapper.Map<Team>(request));
            _unitOfWork.Commit();
            return Mapper.Map<TeamResponse>(response);
        }

        public TeamResponse Update(int id, TeamRequest request)
        {
            if (request == null) throw new ArgumentNullException("entity");

            var entity = _repository.GetById(id);

            entity = Mapper.Map<TeamRequest, Team>(request, entity);

            _repository.Edit(entity);
            _unitOfWork.Commit();
            return Mapper.Map<TeamResponse>(entity);
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) throw new ArgumentNullException("entity");

            _repository.Delete(entity);
            _unitOfWork.Commit();
            return true;
        }


        public IEnumerable<TeamResponse> GetAll()
        {
            return Mapper.Map<IEnumerable<TeamResponse>>(_repository.GetAll());
        }


        public TeamResponse AddPlayerToTeam(int teamId, PlayerRequest player)
        {
            
            var entity = _repository.GetById(teamId);
            
            //TODO:Wrap this in a Response object to send errors;
            if (entity == null)
                return null;

            //if player id present get player from db and add it other wise create a new player
           
            if (player.PlayerId > 0){
                var existingPlayer = _playerRepository.GetById(player.PlayerId);
                if (existingPlayer != null)
                    entity.Players.Add(existingPlayer);
            }
            else
                entity.Players.Add(Mapper.Map<Player>(player));           

            _repository.Edit(entity);
            _unitOfWork.Commit();
            return Mapper.Map<TeamResponse>(entity);
        }


     
    }
}
