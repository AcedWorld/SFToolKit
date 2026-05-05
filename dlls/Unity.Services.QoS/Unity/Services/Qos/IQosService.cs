using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Qos.V2.Models;

namespace Unity.Services.Qos
{
	// Token: 0x02000016 RID: 22
	public interface IQosService
	{
		// Token: 0x0600005A RID: 90
		Task<IList<IQosResult>> GetSortedQosResultsAsync(string service, IList<string> regions);

		// Token: 0x0600005B RID: 91
		Task<IList<IQosAnnotatedResult>> GetSortedRelayQosResultsAsync(IList<string> regions);

		// Token: 0x0600005C RID: 92
		Task<IList<IQosAnnotatedResult>> GetSortedMultiplayQosResultsAsync(IList<string> fleet);

		// Token: 0x0600005D RID: 93
		Task<IList<QosServer>> GetAllServersAsync();

		// Token: 0x0600005E RID: 94
		Task<IList<ValueTuple<QosServer, IQosMeasurements>>> GetQosResultsAsync(IList<QosServer> servers);
	}
}
