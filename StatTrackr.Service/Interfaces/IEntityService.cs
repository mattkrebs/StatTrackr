using StatTrackr.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{

    public interface IEntityService<TRequest, TResponse> : IService
        where TRequest : class, new() where TResponse : class
    {
        TResponse Create(TRequest request);
        IEnumerable<TResponse> GetAll();
      
    }
}
