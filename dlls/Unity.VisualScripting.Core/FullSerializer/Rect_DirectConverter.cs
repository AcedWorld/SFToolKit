using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000190 RID: 400
	public class Rect_DirectConverter : fsDirectConverter<Rect>
	{
		// Token: 0x06000A8D RID: 2701 RVA: 0x0002C550 File Offset: 0x0002A750
		protected override fsResult DoSerialize(Rect model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<float>(serialized, null, "xMin", model.xMin) + base.SerializeMember<float>(serialized, null, "yMin", model.yMin) + base.SerializeMember<float>(serialized, null, "xMax", model.xMax) + base.SerializeMember<float>(serialized, null, "yMax", model.yMax);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x0002C5C8 File Offset: 0x0002A7C8
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Rect model)
		{
			fsResult success = fsResult.Success;
			float xMin = model.xMin;
			fsResult a = success + base.DeserializeMember<float>(data, null, "xMin", out xMin);
			model.xMin = xMin;
			float yMin = model.yMin;
			fsResult a2 = a + base.DeserializeMember<float>(data, null, "yMin", out yMin);
			model.yMin = yMin;
			float xMax = model.xMax;
			fsResult a3 = a2 + base.DeserializeMember<float>(data, null, "xMax", out xMax);
			model.xMax = xMax;
			float yMax = model.yMax;
			fsResult result = a3 + base.DeserializeMember<float>(data, null, "yMax", out yMax);
			model.yMax = yMax;
			return result;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x0002C664 File Offset: 0x0002A864
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Rect);
		}
	}
}
