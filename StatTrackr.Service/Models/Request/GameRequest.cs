﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StatTrackr.Service.Models.Request
{
    public class GameRequest
    {
        public int GameId { get; set; }
        [Required]
        public int AwayTeamId { get;set;}
        [Required]
        public int HomeTeamId { get; set; }       
        [Required]
        public int Periods { get; set; }
        public int PeriodTime { get; set; }
        public string Location { get; set; }
        public string Referees { get; set; }
        public DateTime GameStartTime { get; set; }

        

    }
}
