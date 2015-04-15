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
    public class StatLineService : IStatLineService
    {
        IUnitOfWork _unitOfWork;
        IStatLineRepository _repository;

        public StatLineService(IUnitOfWork unitOfWork, IStatLineRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public StatLineResponse GetById(Guid id)
        {
            return Mapper.Map<StatLineResponse>(_repository.GetById(id));
        }

        public IEnumerable<StatLineResponse> GetAllByGameId(int id)
        {
            return Mapper.Map<IEnumerable<StatLineResponse>>(_repository.GetAllByGameId(id));
        }


        public StatLineResponse Create(StatLineRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("entity");
            }
            var response = _repository.Add(Mapper.Map<StatLine>(request));
            _unitOfWork.Commit();
            return Mapper.Map<StatLineResponse>(response);
        }
      

        public bool Delete(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) throw new ArgumentNullException("entity");

            _repository.Delete(entity);
            _unitOfWork.Commit();
            return true;
        }
        
        public IEnumerable<StatLineResponse> GetAll()
        {
            return Mapper.Map<IEnumerable<StatLineResponse>>(_repository.GetAll());

        }
    }
}
