using StatTrackr.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface IStatTypeService
    {
        IEnumerable<StatType> GetAll();
    }
}
