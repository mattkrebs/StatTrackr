using StatTrackr.Data.Interfaces;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Services
{
    public class GameService : EntityService<Game>, IGameService
    {
        IUnitOfWork _unitOfWork;
        IGameRepository _respository;

        public GameService(IUnitOfWork unitOfWork, IGameRepository respository)
            : base(unitOfWork, respository)
        {
            _unitOfWork = unitOfWork;
            _respository = respository;
        }
        public Game GetById(int id)
        {
            return _respository.GetById(id);
        }
    }
}
