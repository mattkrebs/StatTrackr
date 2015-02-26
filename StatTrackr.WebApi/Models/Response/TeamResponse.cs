using StatTrackr.WebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Response
{
    public class TeamResponse : ITeamViewModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string CoachName { get; set; }
        public string Hometown { get; set; }
        public string State { get; set; }
        public List<PlayerResponse> Players { get; set; }
    }
}
