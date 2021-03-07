using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace epic_mqtt
{
    public class StressTestEntityResults
    {
        [JsonPropertyName("latency_average")]
        public decimal AverageLatency { get; set; } = -1;
        [JsonPropertyName("latency_min")]
        public int MinimumLatency { get; set; } = -1;
        [JsonPropertyName("latency_max")]
        public int MaximumLatency { get; set; } = -1;
        [JsonPropertyName("packets_lost")]
        public int PacketsLost { get; set; } = -1;
    }
}
