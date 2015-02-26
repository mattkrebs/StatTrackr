using StatTrackr.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Model.Data
{
    public partial class Player : EntityBase
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

    }
}
