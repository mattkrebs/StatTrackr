using StatTrackr.WebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.WebApi.Models.Response
{
    public class PlayerResponse : IPlayerViewModel
    {
        public int PlayerId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public int? PositionId { get; set; }
        public int? Age { get; set; }
        
    }
}
