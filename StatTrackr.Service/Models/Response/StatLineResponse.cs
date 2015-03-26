using StatTrackr.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.Service.Models.Response
{
    public class StatLineResponse
    {
        public Guid StatLineId { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        public StatType StatType { get; set; }
        public decimal ClockTime { get; set; }
        public int Period { get; set; }      
        public PlayerResponse Player { get; set; }
        public string ShotLocation { get; set; }
        public int TeamId { get; set; }

        public string StatLineNotes { get; set; }

    }
}
