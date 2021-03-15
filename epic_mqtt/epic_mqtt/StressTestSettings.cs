using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epic_mqtt
{
    public class StressTestSettings
    {
        public int GracePeriod { get; set; }
        public String BrokerHost { get; set; }
        public int BrokerPort { get; set; }
        public int NumClients { get; set; }
    }
}
