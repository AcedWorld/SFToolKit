using System;
using Unity.Services.Core.Internal;

namespace Unity.Services.Qos
{
	// Token: 0x0200001B RID: 27
	internal class QosServiceComponent : IQosServiceComponent, IServiceComponent
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003837 File Offset: 0x00001A37
		public IQosService Service { get; }

		// Token: 0x06000067 RID: 103 RVA: 0x0000383F File Offset: 0x00001A3F
		internal QosServiceComponent(IQosService qos)
		{
			this.Service = qos;
		}
	}
}
