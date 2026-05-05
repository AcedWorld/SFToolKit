using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	internal class EventAttributeBool : EventAttributeValue<bool>
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00002B7C File Offset: 0x00000D7C
		public EventAttributeBool() : base((VFXEventAttribute e, int id) => e.HasBool(id), delegate(VFXEventAttribute e, int id, bool value)
		{
			e.SetBool(id, value);
		})
		{
		}
	}
}
