using System;

namespace UnityEngine.SearchService
{
	// Token: 0x02000312 RID: 786
	[Obsolete("ObjectSelectorHandlerWithLabelsAttribute has been deprecated. Use SearchContextAttribute instead.", true)]
	[AttributeUsage(AttributeTargets.Field)]
	public class ObjectSelectorHandlerWithLabelsAttribute : Attribute
	{
		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x0600202E RID: 8238 RVA: 0x00035933 File Offset: 0x00033B33
		public string[] labels { get; }

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x0600202F RID: 8239 RVA: 0x0003593B File Offset: 0x00033B3B
		public bool matchAll { get; }

		// Token: 0x06002030 RID: 8240 RVA: 0x00035943 File Offset: 0x00033B43
		public ObjectSelectorHandlerWithLabelsAttribute(params string[] labels)
		{
			this.labels = labels;
			this.matchAll = 1;
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x0003595B File Offset: 0x00033B5B
		public ObjectSelectorHandlerWithLabelsAttribute(bool matchAll, params string[] labels)
		{
			this.labels = labels;
			this.matchAll = matchAll;
		}
	}
}
