﻿using StatTrackr.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Interfaces
{
    public interface IStatLineService : IEntityService<StatLine>
    {
        StatLine GetById(Guid id);
        IEnumerable<StatLine> GetAllByGameId(int id);
    }
}
