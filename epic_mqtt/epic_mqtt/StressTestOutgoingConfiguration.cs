using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace epic_mqtt
{
    public class StressTestOutgoingConfiguration
    {
        [JsonPropertyName("grace_period_seconds")]
        public int GracePeriodSeconds { get; set; }
        [JsonPropertyName("clients")]
        public List<ClientConfiguration> Clients { get; set; }
    }
}
