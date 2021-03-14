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

        public List<String> ToCSV()
        {
            List<String> lines = new List<String>();

            lines.Add("Client,Average Latency,Minimum Latency,Maximum Latency,Packets Lost\n");
            for(int i = 0; i < ClientResults.Count; i++)
            {
                lines.Add($"Client {i + 1},{ClientResults[i].AverageLatency},{ClientResults[i].MinimumLatency},{ClientResults[i].MaximumLatency},{ClientResults[i].PacketsLost}\n");
            }
            lines.Add($"Total,{TotalResults.AverageLatency},{TotalResults.MinimumLatency},{TotalResults.MaximumLatency},{TotalResults.PacketsLost}\n");

            return lines;
        }
    }
}
