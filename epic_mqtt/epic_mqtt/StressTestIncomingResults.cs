using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace epic_mqtt
{
    public class StressTestIncomingResults
    {
        [JsonPropertyName("total")]
        public StressTestEntityResults TotalResults { get; set; }
        [JsonPropertyName("clients")]
        public List<StressTestEntityResults> ClientResults { get; set; } = new List<StressTestEntityResults>();
    }
}
