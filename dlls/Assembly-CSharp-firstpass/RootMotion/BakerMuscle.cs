using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class BakerMuscle
	{
		// Token: 0x0600004E RID: 78 RVA: 0x000034A6 File Offset: 0x000016A6
		public BakerMuscle(int muscleIndex)
		{
			this.muscleIndex = muscleIndex;
			this.propertyName = this.MuscleNameToPropertyName(HumanTrait.MuscleName[muscleIndex]);
			this.Reset();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000034D8 File Offset: 0x000016D8
		private string MuscleNameToPropertyName(string n)
		{
			if (n == "Left Index 1 Stretched")
			{
				return "LeftHand.Index.1 Stretched";
			}
			if (n == "Left Index 2 Stretched")
			{
				return "LeftHand.Index.2 Stretched";
			}
			if (n == "Left Index 3 Stretched")
			{
				return "LeftHand.Index.3 Stretched";
			}
			if (n == "Left Middle 1 Stretched")
			{
				return "LeftHand.Middle.1 Stretched";
			}
			if (n == "Left Middle 2 Stretched")
			{
				return "LeftHand.Middle.2 Stretched";
			}
			if (n == "Left Middle 3 Stretched")
			{
				return "LeftHand.Middle.3 Stretched";
			}
			if (n == "Left Ring 1 Stretched")
			{
				return "LeftHand.Ring.1 Stretched";
			}
			if (n == "Left Ring 2 Stretched")
			{
				return "LeftHand.Ring.2 Stretched";
			}
			if (n == "Left Ring 3 Stretched")
			{
				return "LeftHand.Ring.3 Stretched";
			}
			if (n == "Left Little 1 Stretched")
			{
				return "LeftHand.Little.1 Stretched";
			}
			if (n == "Left Little 2 Stretched")
			{
				return "LeftHand.Little.2 Stretched";
			}
			if (n == "Left Little 3 Stretched")
			{
				return "LeftHand.Little.3 Stretched";
			}
			if (n == "Left Thumb 1 Stretched")
			{
				return "LeftHand.Thumb.1 Stretched";
			}
			if (n == "Left Thumb 2 Stretched")
			{
				return "LeftHand.Thumb.2 Stretched";
			}
			if (n == "Left Thumb 3 Stretched")
			{
				return "LeftHand.Thumb.3 Stretched";
			}
			if (n == "Left Index Spread")
			{
				return "LeftHand.Index.Spread";
			}
			if (n == "Left Middle Spread")
			{
				return "LeftHand.Middle.Spread";
			}
			if (n == "Left Ring Spread")
			{
				return "LeftHand.Ring.Spread";
			}
			if (n == "Left Little Spread")
			{
				return "LeftHand.Little.Spread";
			}
			if (n == "Left Thumb Spread")
			{
				return "LeftHand.Thumb.Spread";
			}
			if (n == "Right Index 1 Stretched")
			{
				return "RightHand.Index.1 Stretched";
			}
			if (n == "Right Index 2 Stretched")
			{
				return "RightHand.Index.2 Stretched";
			}
			if (n == "Right Index 3 Stretched")
			{
				return "RightHand.Index.3 Stretched";
			}
			if (n == "Right Middle 1 Stretched")
			{
				return "RightHand.Middle.1 Stretched";
			}
			if (n == "Right Middle 2 Stretched")
			{
				return "RightHand.Middle.2 Stretched";
			}
			if (n == "Right Middle 3 Stretched")
			{
				return "RightHand.Middle.3 Stretched";
			}
			if (n == "Right Ring 1 Stretched")
			{
				return "RightHand.Ring.1 Stretched";
			}
			if (n == "Right Ring 2 Stretched")
			{
				return "RightHand.Ring.2 Stretched";
			}
			if (n == "Right Ring 3 Stretched")
			{
				return "RightHand.Ring.3 Stretched";
			}
			if (n == "Right Little 1 Stretched")
			{
				return "RightHand.Little.1 Stretched";
			}
			if (n == "Right Little 2 Stretched")
			{
				return "RightHand.Little.2 Stretched";
			}
			if (n == "Right Little 3 Stretched")
			{
				return "RightHand.Little.3 Stretched";
			}
			if (n == "Right Thumb 1 Stretched")
			{
				return "RightHand.Thumb.1 Stretched";
			}
			if (n == "Right Thumb 2 Stretched")
			{
				return "RightHand.Thumb.2 Stretched";
			}
			if (n == "Right Thumb 3 Stretched")
			{
				return "RightHand.Thumb.3 Stretched";
			}
			if (n == "Right Index Spread")
			{
				return "RightHand.Index.Spread";
			}
			if (n == "Right Middle Spread")
			{
				return "RightHand.Middle.Spread";
			}
			if (n == "Right Ring Spread")
			{
				return "RightHand.Ring.Spread";
			}
			if (n == "Right Little Spread")
			{
				return "RightHand.Little.Spread";
			}
			if (n == "Right Thumb Spread")
			{
				return "RightHand.Thumb.Spread";
			}
			return n;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000037E0 File Offset: 0x000019E0
		public void MultiplyLength(AnimationCurve curve, float mlp)
		{
			Keyframe[] keys = curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				Keyframe[] array = keys;
				int num = i;
				array[num].time = array[num].time * mlp;
			}
			curve.keys = keys;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000381D File Offset: 0x00001A1D
		public void SetCurves(ref AnimationClip clip, float maxError, float lengthMlp)
		{
			this.MultiplyLength(this.curve, lengthMlp);
			BakerUtilities.ReduceKeyframes(this.curve, maxError);
			clip.SetCurve(string.Empty, typeof(Animator), this.propertyName, this.curve);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000385A File Offset: 0x00001A5A
		public void Reset()
		{
			this.curve = new AnimationCurve();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003867 File Offset: 0x00001A67
		public void SetKeyframe(float time, float[] muscles)
		{
			this.curve.AddKey(time, muscles[this.muscleIndex]);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000387E File Offset: 0x00001A7E
		public void SetLoopFrame(float time)
		{
			BakerUtilities.SetLoopFrame(time, this.curve);
		}

		// Token: 0x0400005A RID: 90
		public AnimationCurve curve;

		// Token: 0x0400005B RID: 91
		private int muscleIndex = -1;

		// Token: 0x0400005C RID: 92
		private string propertyName;
	}
}
