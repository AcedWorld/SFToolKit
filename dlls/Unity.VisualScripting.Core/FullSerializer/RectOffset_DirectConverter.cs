using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200018F RID: 399
	public class RectOffset_DirectConverter : fsDirectConverter<RectOffset>
	{
		// Token: 0x06000A89 RID: 2697 RVA: 0x0002C428 File Offset: 0x0002A628
		protected override fsResult DoSerialize(RectOffset model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<int>(serialized, null, "bottom", model.bottom) + base.SerializeMember<int>(serialized, null, "left", model.left) + base.SerializeMember<int>(serialized, null, "right", model.right) + base.SerializeMember<int>(serialized, null, "top", model.top);
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0002C49C File Offset: 0x0002A69C
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref RectOffset model)
		{
			fsResult success = fsResult.Success;
			int bottom = model.bottom;
			fsResult a = success + base.DeserializeMember<int>(data, null, "bottom", out bottom);
			model.bottom = bottom;
			int left = model.left;
			fsResult a2 = a + base.DeserializeMember<int>(data, null, "left", out left);
			model.left = left;
			int right = model.right;
			fsResult a3 = a2 + base.DeserializeMember<int>(data, null, "right", out right);
			model.right = right;
			int top = model.top;
			fsResult result = a3 + base.DeserializeMember<int>(data, null, "top", out top);
			model.top = top;
			return result;
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0002C53E File Offset: 0x0002A73E
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new RectOffset();
		}
	}
}
