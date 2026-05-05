using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200016F RID: 367
	public interface IUnitPortDefinition
	{
		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000973 RID: 2419
		string key { get; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000974 RID: 2420
		string label { get; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000975 RID: 2421
		string summary { get; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000976 RID: 2422
		bool hideLabel { get; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000977 RID: 2423
		bool isValid { get; }
	}
}
