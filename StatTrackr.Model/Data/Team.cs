using StatTrackr.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.Model.Data
{
    public partial class Team : EntityBase
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string CoachName { get; set; }
        public string Hometown { get; set; }
        public string State { get; set; }
        public virtual ICollection<Player> Players { get; set; }



    }
}
