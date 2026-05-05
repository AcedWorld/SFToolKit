using System;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000381 RID: 897
	public abstract class HardwareControllerTemplateMap : ScriptableObject
	{
		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x060024CE RID: 9422
		public abstract Guid Guid { get; }

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x060024CF RID: 9423
		public abstract string Key { get; }

		// Token: 0x060024D0 RID: 9424
		[CustomObfuscation(rename = false)]
		public abstract ControllerTemplateElementIdentifier GetElementIdentifier(int id);

		// Token: 0x060024D1 RID: 9425
		[CustomObfuscation(rename = false)]
		public abstract bool ContainsElementIdentifier(int id);

		// Token: 0x02000382 RID: 898
		internal struct vNUinRqnjfTkAskqXltQLMfPUMUv
		{
			// Token: 0x0400150C RID: 5388
			public int UIHXARWEFIUQvHamiuIUzSVIaBFb;

			// Token: 0x0400150D RID: 5389
			public int gxqDjvURKgAphrnHLBgXhhAevmWo;

			// Token: 0x0400150E RID: 5390
			public int zeCfOGzHrAArWDHkKnYIkfgqsJXSA;

			// Token: 0x0400150F RID: 5391
			public bool tgGVJPmoMdsLlKFiRFfKEnLphuSt;
		}
	}
}
