using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Interfaces
{
    public interface ITeamViewModel
    {
        int TeamId { get; set; }
        string Name { get; set; }
        string CoachName { get; set; }
        string Hometown { get; set; }
        string State { get; set; }
    }
}
