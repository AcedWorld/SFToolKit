using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200000B RID: 11
	internal sealed class GradientCloner : Cloner<Gradient>
	{
		// Token: 0x06000026 RID: 38 RVA: 0x0000245A File Offset: 0x0000065A
		public override bool Handles(Type type)
		{
			return type == typeof(Gradient);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000246C File Offset: 0x0000066C
		public override Gradient ConstructClone(Type type, Gradient original)
		{
			return new Gradient();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002473 File Offset: 0x00000673
		public override void FillClone(Type type, ref Gradient clone, Gradient original, CloningContext context)
		{
			clone.mode = original.mode;
			clone.SetKeys(original.colorKeys, original.alphaKeys);
		}
	}
}
