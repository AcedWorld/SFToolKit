using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000005 RID: 5
	public sealed class AnimationCurveCloner : Cloner<AnimationCurve>
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000214D File Offset: 0x0000034D
		public override bool Handles(Type type)
		{
			return type == typeof(AnimationCurve);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000215F File Offset: 0x0000035F
		public override AnimationCurve ConstructClone(Type type, AnimationCurve original)
		{
			return new AnimationCurve();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002168 File Offset: 0x00000368
		public override void FillClone(Type type, ref AnimationCurve clone, AnimationCurve original, CloningContext context)
		{
			for (int i = 0; i < clone.length; i++)
			{
				clone.RemoveKey(i);
			}
			foreach (Keyframe key in original.keys)
			{
				clone.AddKey(key);
			}
		}
	}
}
