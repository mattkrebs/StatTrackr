using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.ServiceModel.Request
{
    public class TeamRequest
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string CoachName { get; set; }
        public string Hometown { get; set; }
        public string State { get; set; }
    }
}
