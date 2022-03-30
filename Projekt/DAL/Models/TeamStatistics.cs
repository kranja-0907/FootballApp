using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("starting_eleven")]
        public List<StartingEleven> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<StartingEleven> Substitutes { get; set; }

        public override string ToString() => $"{Country} {StartingEleven}";
    }
}
