using System;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200001C RID: 28
	[Obsolete("class XAppScreenshotLocalId will be removed in future releases.", false)]
	[Serializable]
	public class XAppScreenshotLocalId
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00008840 File Offset: 0x00006A40
		public byte[] Value { get; }

		// Token: 0x06000258 RID: 600 RVA: 0x00008848 File Offset: 0x00006A48
		public XAppScreenshotLocalId(byte[] value)
		{
			this.Value = value;
		}
	}
}
