using StatTrackr.Data.Interfaces;
using StatTrackr.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Services
{
    public class PositionService : IPositionService
    {
        IUnitOfWork _unitOfWork;
        IPositionRepository _repository;

        public PositionService(IUnitOfWork unitOfWork, IPositionRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public IEnumerable<Model.Data.Position> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
