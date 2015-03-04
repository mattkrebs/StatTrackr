using StatTrackr.Data.Interfaces;
using StatTrackr.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Services
{
    public class StatTypeService : IStatTypeService
    {
        IUnitOfWork _unitOfWork;
        IStatTypeRepository _repository;

        public StatTypeService(IUnitOfWork unitOfWork, IStatTypeRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public IEnumerable<Model.Data.StatType> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
