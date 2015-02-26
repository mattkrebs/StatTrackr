using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Interfaces
{
    public interface IPlayerViewModel
    {
        int PlayerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int? Number { get; set; }
        int? PositionId { get; set; }
        int? Age { get; set; }
    }
}
