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
    public class StatLine : EntityBase
    {
        [Key]
        public Guid StatLineId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        [ForeignKey("StatTypeId")]
        public StatType StatType { get; set; }
        public decimal ClockTime { get; set; }
        public int Period { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public string ShotLocation { get; set; }
    }
}
