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
    public class StatLineService : EntityService<StatLine>, IStatLineService
    {
         IUnitOfWork _unitOfWork;
        IStatLineRepository _respository;

        public StatLineService(IUnitOfWork unitOfWork, IStatLineRepository respository)
            : base(unitOfWork, respository)
        {
            _unitOfWork = unitOfWork;
            _respository = respository;
        }
        public StatLine GetById(Guid id)
        {
            return _respository.GetById(id);
        }

        public IEnumerable<StatLine> GetAllByGameId(int id)
        {
            return _respository.GetAllByGameId(id);
        }

       
    }
}
