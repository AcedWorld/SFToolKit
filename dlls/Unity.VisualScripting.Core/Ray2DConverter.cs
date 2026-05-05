using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000131 RID: 305
	public class Ray2DConverter : fsDirectConverter<Ray2D>
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x000255CB File Offset: 0x000237CB
		protected override fsResult DoSerialize(Ray2D model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<Vector2>(serialized, null, "origin", model.origin) + base.SerializeMember<Vector2>(serialized, null, "direction", model.direction);
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00025604 File Offset: 0x00023804
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Ray2D model)
		{
			fsResult success = fsResult.Success;
			Vector2 origin = model.origin;
			fsResult a = success + base.DeserializeMember<Vector2>(data, null, "origin", out origin);
			model.origin = origin;
			Vector2 direction = model.direction;
			fsResult result = a + base.DeserializeMember<Vector2>(data, null, "direction", out direction);
			model.direction = direction;
			return result;
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0002565C File Offset: 0x0002385C
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Ray2D);
		}
	}
}
