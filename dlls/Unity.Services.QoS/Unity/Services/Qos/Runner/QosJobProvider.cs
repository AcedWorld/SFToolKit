using System;
using System.Collections.Generic;
using Unity.Networking.QoS;

namespace Unity.Services.Qos.Runner
{
	// Token: 0x0200004C RID: 76
	// (Invoke) Token: 0x06000168 RID: 360
	internal delegate IQosJob QosJobProvider(IList<UcgQosServer> servers, string title);
}
