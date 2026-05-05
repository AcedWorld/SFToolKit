using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200045D RID: 1117
	public class ObjectIdResult
	{
		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x0600258F RID: 9615 RVA: 0x00040121 File Offset: 0x0003E321
		public Object[] idToObjectMapping { get; }

		// Token: 0x06002590 RID: 9616 RVA: 0x00040129 File Offset: 0x0003E329
		internal ObjectIdResult(Object[] idToObjectMapping)
		{
			this.idToObjectMapping = idToObjectMapping;
		}

		// Token: 0x06002591 RID: 9617 RVA: 0x0004013C File Offset: 0x0003E33C
		public static int DecodeIdFromColor(Color color)
		{
			return (int)(color.r * 255f) + ((int)(color.g * 255f) << 8) + ((int)(color.b * 255f) << 16) + ((int)(color.a * 255f) << 24);
		}
	}
}
