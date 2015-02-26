using StatTrackr.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{

    public interface IEntityService<T> : IService
        where T : EntityBase
    {
        void Create(T entity);
        bool Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
