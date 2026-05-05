using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	internal class EventAttributeUInt : EventAttributeValue<uint>
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002B28 File Offset: 0x00000D28
		public EventAttributeUInt() : base((VFXEventAttribute e, int id) => e.HasUint(id), delegate(VFXEventAttribute e, int id, uint value)
		{
			e.SetUint(id, value);
		})
		{
		}
	}
}
