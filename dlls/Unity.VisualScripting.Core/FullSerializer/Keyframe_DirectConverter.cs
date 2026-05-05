using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200018D RID: 397
	public class Keyframe_DirectConverter : fsDirectConverter<Keyframe>
	{
		// Token: 0x06000A81 RID: 2689 RVA: 0x0002C23C File Offset: 0x0002A43C
		protected override fsResult DoSerialize(Keyframe model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<float>(serialized, null, "time", model.time) + base.SerializeMember<float>(serialized, null, "value", model.value) + base.SerializeMember<int>(serialized, null, "tangentMode", model.tangentMode) + base.SerializeMember<float>(serialized, null, "inTangent", model.inTangent) + base.SerializeMember<float>(serialized, null, "outTangent", model.outTangent);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0002C2CC File Offset: 0x0002A4CC
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Keyframe model)
		{
			fsResult success = fsResult.Success;
			float time = model.time;
			fsResult a = success + base.DeserializeMember<float>(data, null, "time", out time);
			model.time = time;
			float value = model.value;
			fsResult a2 = a + base.DeserializeMember<float>(data, null, "value", out value);
			model.value = value;
			int tangentMode = model.tangentMode;
			fsResult a3 = a2 + base.DeserializeMember<int>(data, null, "tangentMode", out tangentMode);
			model.tangentMode = tangentMode;
			float inTangent = model.inTangent;
			fsResult a4 = a3 + base.DeserializeMember<float>(data, null, "inTangent", out inTangent);
			model.inTangent = inTangent;
			float outTangent = model.outTangent;
			fsResult result = a4 + base.DeserializeMember<float>(data, null, "outTangent", out outTangent);
			model.outTangent = outTangent;
			return result;
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0002C38C File Offset: 0x0002A58C
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Keyframe);
		}
	}
}
