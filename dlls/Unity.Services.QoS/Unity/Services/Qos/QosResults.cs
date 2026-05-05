using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core.Internal;
using Unity.Services.Qos.Internal;

namespace Unity.Services.Qos
{
	// Token: 0x02000010 RID: 16
	internal class QosResults : IQosResults, IServiceComponent
	{
		// Token: 0x06000043 RID: 67 RVA: 0x000035D8 File Offset: 0x000017D8
		internal QosResults(WrappedQosService qosService)
		{
			this._qosService = qosService;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000035E7 File Offset: 0x000017E7
		public Task<IList<QosResult>> GetSortedQosResultsAsync(string service, IList<string> regions)
		{
			return this._qosService.GetSortedInternalQosResultsAsync(service, regions);
		}

		// Token: 0x04000046 RID: 70
		private WrappedQosService _qosService;
	}
}
