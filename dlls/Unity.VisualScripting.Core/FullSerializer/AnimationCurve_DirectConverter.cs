using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000188 RID: 392
	public class AnimationCurve_DirectConverter : fsDirectConverter<AnimationCurve>
	{
		// Token: 0x06000A6C RID: 2668 RVA: 0x0002B7F8 File Offset: 0x000299F8
		protected override fsResult DoSerialize(AnimationCurve model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<Keyframe[]>(serialized, null, "keys", model.keys) + base.SerializeMember<WrapMode>(serialized, null, "preWrapMode", model.preWrapMode) + base.SerializeMember<WrapMode>(serialized, null, "postWrapMode", model.postWrapMode);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0002B854 File Offset: 0x00029A54
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref AnimationCurve model)
		{
			fsResult success = fsResult.Success;
			Keyframe[] keys = model.keys;
			fsResult a = success + base.DeserializeMember<Keyframe[]>(data, null, "keys", out keys);
			model.keys = keys;
			WrapMode preWrapMode = model.preWrapMode;
			fsResult a2 = a + base.DeserializeMember<WrapMode>(data, null, "preWrapMode", out preWrapMode);
			model.preWrapMode = preWrapMode;
			WrapMode postWrapMode = model.postWrapMode;
			fsResult result = a2 + base.DeserializeMember<WrapMode>(data, null, "postWrapMode", out postWrapMode);
			model.postWrapMode = postWrapMode;
			return result;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0002B8D2 File Offset: 0x00029AD2
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new AnimationCurve();
		}
	}
}
