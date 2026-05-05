using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200018A RID: 394
	public class Gradient_DirectConverter : fsDirectConverter<Gradient>
	{
		// Token: 0x06000A74 RID: 2676 RVA: 0x0002B998 File Offset: 0x00029B98
		protected override fsResult DoSerialize(Gradient model, Dictionary<string, fsData> serialized)
		{
			fsResult fsResult = fsResult.Success;
			fsResult += base.SerializeMember<GradientAlphaKey[]>(serialized, null, "alphaKeys", model.alphaKeys);
			fsResult += base.SerializeMember<GradientColorKey[]>(serialized, null, "colorKeys", model.colorKeys);
			try
			{
				fsResult += base.SerializeMember<GradientMode>(serialized, null, "mode", model.mode);
			}
			catch (Exception)
			{
				Gradient_DirectConverter.LogWarning("serialized");
			}
			return fsResult;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0002BA1C File Offset: 0x00029C1C
		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Gradient model)
		{
			fsResult fsResult = fsResult.Success;
			GradientAlphaKey[] alphaKeys = model.alphaKeys;
			fsResult += base.DeserializeMember<GradientAlphaKey[]>(data, null, "alphaKeys", out alphaKeys);
			model.alphaKeys = alphaKeys;
			GradientColorKey[] colorKeys = model.colorKeys;
			fsResult += base.DeserializeMember<GradientColorKey[]>(data, null, "colorKeys", out colorKeys);
			model.colorKeys = colorKeys;
			try
			{
				GradientMode mode = model.mode;
				fsResult += base.DeserializeMember<GradientMode>(data, null, "mode", out mode);
				model.mode = mode;
			}
			catch (Exception)
			{
				Gradient_DirectConverter.LogWarning("deserialized");
			}
			return fsResult;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0002BAC4 File Offset: 0x00029CC4
		private static void LogWarning(string phase)
		{
			string text = "2022.2.0a18";
			Debug.LogWarning(string.Concat(new string[]
			{
				"Gradient.mode could not be ",
				phase,
				". Please use Unity ",
				text,
				" or newer to resolve this issue."
			}));
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0002BB0D File Offset: 0x00029D0D
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new Gradient();
		}
	}
}
