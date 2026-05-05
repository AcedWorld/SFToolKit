using System;

namespace UnityEngine.VFX
{
	// Token: 0x0200000F RID: 15
	[Serializable]
	internal class EventAttributeFloat : EventAttributeValue<float>
	{
		// Token: 0x06000031 RID: 49 RVA: 0x0000297C File Offset: 0x00000B7C
		public EventAttributeFloat() : base((VFXEventAttribute e, int id) => e.HasFloat(id), delegate(VFXEventAttribute e, int id, float value)
		{
			e.SetFloat(id, value);
		})
		{
		}
	}
}
