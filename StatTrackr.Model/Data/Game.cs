using StatTrackr.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Model.Data
{
    public partial class Game : EntityBase
    {
        public int GameId { get; set; }
        public int? HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }
        public int? AwayTeamId { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }
        public int Periods { get; set; }
        public decimal PeriodTime { get; set; }
        public string Location { get; set; }
        public string Referees { get; set; }
        public DateTime GameStartTime { get; set; }
        public virtual ICollection<StatLine> StatLines { get; set; }

    }
}
