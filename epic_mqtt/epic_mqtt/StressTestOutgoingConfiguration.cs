using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace epic_mqtt
{
    class StressTestOutgoingConfiguration
    {
        [JsonPropertyName("clients")]
        public List<ClientConfiguration> Clients { get; set; }
    }
}
