using StatTrackr.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Models.Response
{
    public class GameStatsResponse
    {
        public int GameId { get; set; }
        public TeamStatsResponse HomeStatTotals { get; set; }
        public TeamStatsResponse AwayStatTotals { get; set; }
        public int Period { get; set; }
        public List<StatLineResponse> GameStatLines { get; set; }
    }
}
