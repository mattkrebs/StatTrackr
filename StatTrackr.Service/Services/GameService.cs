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
            return Mapper.Map<GameResponse>(_repository.GetById(id));
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
    }
}
