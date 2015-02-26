using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models
{
    public class TeamStatsViewModel
    {
        public int TeamId { get; set; }
        public int Score { get; set; }
        public int Fouls { get; set; }
        public int FullTimeouts { get; set; }
        public int ShortTimeouts { get; set; }

    }
}
