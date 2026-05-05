using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000233 RID: 563
	[UsedByNativeCode]
	[AttributeUsage(AttributeTargets.Class)]
	public class DefaultExecutionOrder : Attribute
	{
		// Token: 0x06001859 RID: 6233 RVA: 0x000285E1 File Offset: 0x000267E1
		public DefaultExecutionOrder(int order)
		{
			this.m_Order = order;
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x0600185A RID: 6234 RVA: 0x000285F4 File Offset: 0x000267F4
		public int order
		{
			get
			{
				return this.m_Order;
			}
		}

		// Token: 0x04000899 RID: 2201
		private int m_Order;
	}
}
