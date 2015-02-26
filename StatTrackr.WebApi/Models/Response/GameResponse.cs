using StatTrackr.WebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StatTrackr.WebApi.Models.Response
{
    public class GameResponse : IGameViewModel
    {
        public int GameId { get; set; }      
        public TeamResponse HomeTeam { get; set; }
        public TeamResponse AwayTeam { get; set; }      
        public int Periods { get; set; }
        public int PeriodTime { get; set; }
        public string Location { get; set; }
        public string Referees { get; set; }
        public DateTime GameStartTime { get; set; }
        public List<StatLineResponse> StatLines { get; set; }

        

    }
}
