using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200018E RID: 398
	public class LayerMask_DirectConverter : fsDirectConverter<LayerMask>
	{
		// Token: 0x06000A85 RID: 2693 RVA: 0x0002C3AF File Offset: 0x0002A5AF
		protected override fsResult DoSerialize(LayerMask model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<int>(serialized, null, "value", model.value);
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0002C3D0 File Offset: 0x0002A5D0
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref LayerMask model)
		{
			fsResult success = fsResult.Success;
			int value = model.value;
			fsResult result = success + base.DeserializeMember<int>(data, null, "value", out value);
			model.value = value;
			return result;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0002C404 File Offset: 0x0002A604
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(LayerMask);
		}
	}
}
