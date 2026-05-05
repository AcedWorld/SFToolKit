using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200018B RID: 395
	public class GUIStyleState_DirectConverter : fsDirectConverter<GUIStyleState>
	{
		// Token: 0x06000A79 RID: 2681 RVA: 0x0002BB1C File Offset: 0x00029D1C
		protected override fsResult DoSerialize(GUIStyleState model, Dictionary<string, fsData> serialized)
		{
			return fsResult.Success + base.SerializeMember<Texture2D>(serialized, null, "background", model.background) + base.SerializeMember<Color>(serialized, null, "textColor", model.textColor);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0002BB54 File Offset: 0x00029D54
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref GUIStyleState model)
		{
			fsResult success = fsResult.Success;
			Texture2D background = model.background;
			fsResult a = success + base.DeserializeMember<Texture2D>(data, null, "background", out background);
			model.background = background;
			Color textColor = model.textColor;
			fsResult result = a + base.DeserializeMember<Color>(data, null, "textColor", out textColor);
			model.textColor = textColor;
			return result;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0002BBAE File Offset: 0x00029DAE
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new GUIStyleState();
		}
	}
}
