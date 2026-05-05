using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000011 RID: 17
	[Serializable]
	internal class EventAttributeVector3 : EventAttributeValue<Vector3>
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002A24 File Offset: 0x00000C24
		public EventAttributeVector3() : base((VFXEventAttribute e, int id) => e.HasVector3(id), delegate(VFXEventAttribute e, int id, Vector3 value)
		{
			e.SetVector3(id, value);
		})
		{
		}
	}
}
