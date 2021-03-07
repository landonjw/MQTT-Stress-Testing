using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace epic_mqtt
{
    class StressTestIncomingResults
    {
        [JsonPropertyName("total")]
        public StressTestEntityResults totalResults { get; set; }
        [JsonPropertyName("clients")]
        public List<StressTestEntityResults> clientResults { get; set; } = new List<StressTestEntityResults>();
    }
}
