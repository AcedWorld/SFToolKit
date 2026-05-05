using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000132 RID: 306
	public class RayConverter : fsDirectConverter<Ray>
	{
		// Token: 0x0600084F RID: 2127 RVA: 0x0002567F File Offset: 0x0002387F
		protected override fsResult DoSerialize(Ray model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<Vector3>(serialized, null, "origin", model.origin) + base.SerializeMember<Vector3>(serialized, null, "direction", model.direction);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x000256B8 File Offset: 0x000238B8
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Ray model)
		{
			fsResult success = fsResult.Success;
			Vector3 origin = model.origin;
			fsResult a = success + base.DeserializeMember<Vector3>(data, null, "origin", out origin);
			model.origin = origin;
			Vector3 direction = model.direction;
			fsResult result = a + base.DeserializeMember<Vector3>(data, null, "direction", out direction);
			model.direction = direction;
			return result;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00025710 File Offset: 0x00023910
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Ray);
		}
	}
}
