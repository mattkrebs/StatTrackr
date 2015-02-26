using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Response
{
    public class GameStatsResponse
    {
        public int GameId { get; set; }
        public TeamStatsViewModel HomeStatTotals { get; set; }
        public TeamStatsViewModel AwayStatTotals { get; set; }
        public int Period { get; set; }
        public List<StatLineResponse> GameStatLines { get; set; }
    }
}
