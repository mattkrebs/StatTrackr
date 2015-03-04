using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Models.Response
{
    public class TeamStatsResponse
    {
        public int TeamId { get; set; }
        public int Score { get; set; }
        public int Fouls { get; set; }
        public int FullTimeouts { get; set; }
        public int ShortTimeouts { get; set; }
    }
}
