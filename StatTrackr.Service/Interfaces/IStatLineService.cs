using StatTrackr.Model.Data;
using StatTrackr.Service.Models.Request;
using StatTrackr.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface IStatLineService : IEntityService<StatLineRequest, StatLineResponse>
    {
        StatLineResponse GetById(Guid id);
        IEnumerable<StatLineResponse> GetAllByGameId(int id);
        bool Delete(Guid id);
       

    }
}
