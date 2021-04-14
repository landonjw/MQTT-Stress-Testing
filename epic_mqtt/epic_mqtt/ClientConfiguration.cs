using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace epic_mqtt
{
    public class ClientConfiguration
    {
        private int _packetIntervalMS = 1000;
        [JsonPropertyName("packet_interval_ms")]
        public int PacketIntervalMS
        {
            get => _packetIntervalMS;
            set
            {
                if (value % 25 == 0 && value >= 25)
                {
                    _packetIntervalMS = value;
                }
                else
                {
                    throw new ArgumentException("packet interval must be divisible by 25");
                }
            }
        }

        private int _packetSizeBytes = 100;
        [JsonPropertyName("packet_size_bytes")]
        public int PacketSizeBytes
        {
            get => _packetSizeBytes;
            set
            {
                if (value >= 100)
                {
                    _packetSizeBytes = value;
                }
                else
                {
                    throw new ArgumentException("packet size must be atleast 100 bytes");
                }
            }
        }

        private int _durationSeconds = 3;
        [JsonPropertyName("duration_seconds")]
        public int DurationSeconds
        {
            get => _durationSeconds;
            set
            {
                if (value > 0)
                {
                    _durationSeconds = value;
                }
                else
                {
                    throw new ArgumentException("duration must be above 0");
                }
            }
        }

        private int _qosLevel = 0;
        [JsonPropertyName("qos_level")]
        public int QOSLevel
        {
            get => _qosLevel;
            set
            {
                // Changed from 1|2|3 to 0|1|2
                if (value == 0 || value == 1 || value == 2)
                {
                    _qosLevel = value;
                }
                else
                {
                    throw new ArgumentException("qos level must be between 0 and 2");
                }
            }
        }
    }
}