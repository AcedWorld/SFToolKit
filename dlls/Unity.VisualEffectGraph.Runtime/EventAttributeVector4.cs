using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	internal class EventAttributeVector4 : EventAttributeValue<Vector4>
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002A80 File Offset: 0x00000C80
		public EventAttributeVector4() : base((VFXEventAttribute e, int id) => e.HasVector4(id), delegate(VFXEventAttribute e, int id, Vector4 value)
		{
			e.SetVector4(id, value);
		})
		{
		}
	}
}
