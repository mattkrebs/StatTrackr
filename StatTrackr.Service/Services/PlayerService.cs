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
    public class PlayerService : EntityService<Player>, IPlayerService
    {
        IUnitOfWork _unitOfWork;
        IPlayerRepository _playerRespository;

        public PlayerService(IUnitOfWork unitOfWork, IPlayerRepository playerRespository)
            : base(unitOfWork, playerRespository)
        {
            _unitOfWork = unitOfWork;
            _playerRespository = playerRespository;
        }
        public Player GetById(int id)
        {
            return _playerRespository.GetById(id);
        }
    }
}
