using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000010 RID: 16
	[Serializable]
	internal class EventAttributeVector2 : EventAttributeValue<Vector2>
	{
		// Token: 0x06000032 RID: 50 RVA: 0x000029D0 File Offset: 0x00000BD0
		public EventAttributeVector2() : base((VFXEventAttribute e, int id) => e.HasVector2(id), delegate(VFXEventAttribute e, int id, Vector2 value)
		{
			e.SetVector2(id, value);
		})
		{
		}
	}
}
