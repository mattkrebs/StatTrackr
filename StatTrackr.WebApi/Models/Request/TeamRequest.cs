using StatTrackr.WebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Request
{
    public class TeamRequest : ITeamViewModel
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string CoachName { get; set; }
        public string Hometown { get; set; }
        public string State { get; set; }
    }
}
