using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epic_mqtt
{
    class ClientConfiguration
    {
        private int _packetIntervalMS = 25;
        public int PacketIntervalMS
        {
            get => _packetIntervalMS;
            set
            {
                if (value % 25 == 0 && value >= 25)
                {
                    _packetIntervalMS = value;
                }
            }
        }

        private int _packetSizeBytes = 50;
        public int PacketSizeBytes
        {
            get => _packetSizeBytes;
            set
            {
                if (value >= 50)
                {
                    _packetSizeBytes = value;
                }
            }
        }

        private int _durationSeconds = 15;
        public int DurationSeconds
        {
            get => _durationSeconds;
            set
            {
                if (value > 0)
                {
                    _durationSeconds = value;
                }
            }
        }

        private int _qosLevel = 0;
        public int QOSLevel
        {
            get => _qosLevel;
            set
            {
                if (value == 1 || value == 2 || value == 3)
                {
                    _qosLevel = value;
                }
            }
        }
    }
}