using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000014 RID: 20
	[Serializable]
	internal class EventAttributeInt : EventAttributeValue<int>
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00002AD4 File Offset: 0x00000CD4
		public EventAttributeInt() : base((VFXEventAttribute e, int id) => e.HasInt(id), delegate(VFXEventAttribute e, int id, int value)
		{
			e.SetInt(id, value);
		})
		{
		}
	}
}
