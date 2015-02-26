using StatTrackr.WebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.WebApi.Models.Response
{
    public class StatLineResponse : IStatLineViewModel
    {
        public Guid StatLineId { get; set; }
        public GameResponse Game { get; set; }
        public int GameId { get; set; }
        public int StatTypeId { get; set; }
        public StatTypeViewModel StatType { get; set; }
        public decimal ClockTime { get; set; }
        public int Period { get; set; }
        public PlayerResponse Player { get; set; }
        public int PlayerId { get; set; }
        public string ShotLocation { get; set; }

    }
}
