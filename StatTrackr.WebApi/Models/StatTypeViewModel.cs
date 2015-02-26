using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.WebApi.Models
{
    public class StatTypeViewModel
    {
        public int StatTypeId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
