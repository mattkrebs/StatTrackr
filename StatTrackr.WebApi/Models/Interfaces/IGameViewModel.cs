using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Interfaces
{
    public interface IGameViewModel 
    {
        int GameId { get; set; }    
        int Periods { get; set; }
        int PeriodTime { get; set; }
        string Location { get; set; }
        string Referees { get; set; }
        DateTime GameStartTime { get; set; }
    }
}
