using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000189 RID: 393
	public class Bounds_DirectConverter : fsDirectConverter<Bounds>
	{
		// Token: 0x06000A70 RID: 2672 RVA: 0x0002B8E1 File Offset: 0x00029AE1
		protected override fsResult DoSerialize(Bounds model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<Vector3>(serialized, null, "center", model.center) + base.SerializeMember<Vector3>(serialized, null, "size", model.size);
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0002B91C File Offset: 0x00029B1C
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Bounds model)
		{
			fsResult success = fsResult.Success;
			Vector3 center = model.center;
			fsResult a = success + base.DeserializeMember<Vector3>(data, null, "center", out center);
			model.center = center;
			Vector3 size = model.size;
			fsResult result = a + base.DeserializeMember<Vector3>(data, null, "size", out size);
			model.size = size;
			return result;
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0002B974 File Offset: 0x00029B74
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Bounds);
		}
	}
}
