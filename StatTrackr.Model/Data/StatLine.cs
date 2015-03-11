using StatTrackr.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Model.Data
{
    public partial class StatLine : EntityBase
    {
        
        
        [Key]
        public virtual Guid StatLineId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        [ForeignKey("StatTypeId")]
        public virtual StatType StatType { get; set; }
        public decimal ClockTime { get; set; }
        public int Period { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }
        public string ShotLocation { get; set; }
    }
}
