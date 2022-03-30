using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class GroupResults
    {
        [JsonProperty("ordered_teams")]
        public List<OrderedTeam> OrderedTeams { get; set; }
    }
}
