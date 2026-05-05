using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000011 RID: 17
	public static class BakerUtilities
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002A57 File Offset: 0x00000C57
		public static void ReduceKeyframes(AnimationCurve curve, float maxError)
		{
			if (maxError <= 0f)
			{
				return;
			}
			curve.keys = BakerUtilities.GetReducedKeyframes(curve, maxError);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002A70 File Offset: 0x00000C70
		public static Keyframe[] GetReducedKeyframes(AnimationCurve curve, float maxError)
		{
			Keyframe[] array = curve.keys;
			int num = 1;
			while (num < array.Length - 1 && array.Length > 2)
			{
				Keyframe[] array2 = new Keyframe[array.Length - 1];
				int num2 = 0;
				for (int i = 0; i < array.Length; i++)
				{
					if (num != i)
					{
						array2[num2] = new Keyframe(array[i].time, array[i].value, array[i].inTangent, array[i].outTangent);
						num2++;
					}
				}
				AnimationCurve animationCurve = new AnimationCurve();
				animationCurve.keys = array2;
				float num3 = Mathf.Abs(animationCurve.Evaluate(array[num].time) - array[num].value);
				float time = array[num].time + (array[num - 1].time - array[num].time) * 0.5f;
				float time2 = array[num].time + (array[num + 1].time - array[num].time) * 0.5f;
				float num4 = Mathf.Abs(animationCurve.Evaluate(time) - curve.Evaluate(time));
				float num5 = Mathf.Abs(animationCurve.Evaluate(time2) - curve.Evaluate(time2));
				if (num3 < maxError && num4 < maxError && num5 < maxError)
				{
					array = array2;
				}
				else
				{
					num++;
				}
			}
			return array;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002BE0 File Offset: 0x00000DE0
		public static void SetLoopFrame(float time, AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys[keys.Length - 1].value = keys[0].value;
			float inTangent = Mathf.Lerp(keys[0].inTangent, keys[keys.Length - 1].inTangent, 0.5f);
			keys[0].inTangent = inTangent;
			keys[keys.Length - 1].inTangent = inTangent;
			float outTangent = Mathf.Lerp(keys[0].outTangent, keys[keys.Length - 1].outTangent, 0.5f);
			keys[0].outTangent = outTangent;
			keys[keys.Length - 1].outTangent = outTangent;
			keys[keys.Length - 1].time = time;
			curve.keys = keys;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000223E File Offset: 0x0000043E
		public static void SetTangentMode(AnimationCurve curve)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public static Quaternion EnsureQuaternionContinuity(Quaternion lastQ, Quaternion q)
		{
			Quaternion quaternion = new Quaternion(-q.x, -q.y, -q.z, -q.w);
			Quaternion b = new Quaternion(Mathf.Lerp(lastQ.x, q.x, 0.5f), Mathf.Lerp(lastQ.y, q.y, 0.5f), Mathf.Lerp(lastQ.z, q.z, 0.5f), Mathf.Lerp(lastQ.w, q.w, 0.5f));
			Quaternion b2 = new Quaternion(Mathf.Lerp(lastQ.x, quaternion.x, 0.5f), Mathf.Lerp(lastQ.y, quaternion.y, 0.5f), Mathf.Lerp(lastQ.z, quaternion.z, 0.5f), Mathf.Lerp(lastQ.w, quaternion.w, 0.5f));
			float num = Quaternion.Angle(lastQ, b);
			if (Quaternion.Angle(lastQ, b2) >= num)
			{
				return q;
			}
			return quaternion;
		}
	}
}
