using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace frp_desktop.Domain
{
        public class FrpServerConfig
        {
            public string ServerAddr { get; set; }
            public int ServerPort { get; set; }

            public string AuthMethod { get; set; } = "token";
            public string AuthToken { get; set; }

            public int HeartbeatInterval { get; set; }
            public int HeartbeatTimeout { get; set; }
        }

}
