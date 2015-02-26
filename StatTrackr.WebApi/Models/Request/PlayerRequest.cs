using StatTrackr.WebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Request
{
    public class PlayerRequest : IPlayerViewModel
    {
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public int? PositionId { get; set; }
        public int? Age { get; set; }
    }
}
