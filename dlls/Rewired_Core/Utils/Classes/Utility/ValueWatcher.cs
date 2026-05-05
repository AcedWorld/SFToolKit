using System;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004DE RID: 1246
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		// Token: 0x17000B61 RID: 2913
		// (get) Token: 0x06003210 RID: 12816
		public abstract bool changed { get; }

		// Token: 0x17000B62 RID: 2914
		// (get) Token: 0x06003211 RID: 12817
		// (set) Token: 0x06003212 RID: 12818
		public abstract bool autoTriggerEvent { get; set; }

		// Token: 0x06003213 RID: 12819
		public abstract bool Update();

		// Token: 0x06003214 RID: 12820
		public abstract bool Use();

		// Token: 0x06003215 RID: 12821
		public abstract bool TriggerEvent();

		// Token: 0x06003216 RID: 12822
		public abstract void AddEventListener(ValueWatcher.fqHUsVqcogYvzYMdHoOEIYSpSUiS eventType, Delegate listener);

		// Token: 0x06003217 RID: 12823
		public abstract void RemoveEventListener(ValueWatcher.fqHUsVqcogYvzYMdHoOEIYSpSUiS eventType, Delegate listener);

		// Token: 0x020004DF RID: 1247
		public enum fqHUsVqcogYvzYMdHoOEIYSpSUiS
		{
			// Token: 0x04001B60 RID: 7008
			ValueChanged
		}
	}
}
