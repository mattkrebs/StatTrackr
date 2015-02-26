using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.WebApi.Models.Request
{
    public class StatLineRequest
    {
        public Guid StatLineId { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int StatTypeId { get; set; }
        public decimal ClockTime { get; set; }
        public int Period { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public string ShotLocation { get; set; }


    }
}
