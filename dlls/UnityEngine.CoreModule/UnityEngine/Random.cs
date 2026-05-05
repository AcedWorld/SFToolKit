using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x0200021B RID: 539
	[NativeHeader("Runtime/Export/Random/Random.bindings.h")]
	public static class Random
	{
		// Token: 0x060017C0 RID: 6080
		[StaticAccessor("GetScriptingRand()", StaticAccessorType.Dot)]
		[NativeMethod("SetSeed")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void InitState(int seed);

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x060017C1 RID: 6081 RVA: 0x0002787C File Offset: 0x00025A7C
		// (set) Token: 0x060017C2 RID: 6082 RVA: 0x00027891 File Offset: 0x00025A91
		[StaticAccessor("GetScriptingRand()", StaticAccessorType.Dot)]
		public static Random.State state
		{
			get
			{
				Random.State result;
				Random.get_state_Injected(out result);
				return result;
			}
			set
			{
				Random.set_state_Injected(ref value);
			}
		}

		// Token: 0x060017C3 RID: 6083
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float Range(float minInclusive, float maxInclusive);

		// Token: 0x060017C4 RID: 6084 RVA: 0x0002789C File Offset: 0x00025A9C
		public static int Range(int minInclusive, int maxExclusive)
		{
			return Random.RandomRangeInt(minInclusive, maxExclusive);
		}

		// Token: 0x060017C5 RID: 6085
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int RandomRangeInt(int minInclusive, int maxExclusive);

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x060017C6 RID: 6086
		public static extern float value { [FreeFunction] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x000278B8 File Offset: 0x00025AB8
		public static Vector3 insideUnitSphere
		{
			[FreeFunction]
			get
			{
				Vector3 result;
				Random.get_insideUnitSphere_Injected(out result);
				return result;
			}
		}

		// Token: 0x060017C8 RID: 6088
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRandomUnitCircle(out Vector2 output);

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000278D0 File Offset: 0x00025AD0
		public static Vector2 insideUnitCircle
		{
			get
			{
				Vector2 result;
				Random.GetRandomUnitCircle(out result);
				return result;
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x000278EC File Offset: 0x00025AEC
		public static Vector3 onUnitSphere
		{
			[FreeFunction]
			get
			{
				Vector3 result;
				Random.get_onUnitSphere_Injected(out result);
				return result;
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x060017CB RID: 6091 RVA: 0x00027904 File Offset: 0x00025B04
		public static Quaternion rotation
		{
			[FreeFunction]
			get
			{
				Quaternion result;
				Random.get_rotation_Injected(out result);
				return result;
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x060017CC RID: 6092 RVA: 0x0002791C File Offset: 0x00025B1C
		public static Quaternion rotationUniform
		{
			[FreeFunction]
			get
			{
				Quaternion result;
				Random.get_rotationUniform_Injected(out result);
				return result;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x060017CD RID: 6093
		// (set) Token: 0x060017CE RID: 6094
		[StaticAccessor("GetScriptingRand()", StaticAccessorType.Dot)]
		[Obsolete("Deprecated. Use InitState() function or Random.state property instead.")]
		public static extern int seed { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060017CF RID: 6095 RVA: 0x00027934 File Offset: 0x00025B34
		[Obsolete("Use Random.Range instead")]
		public static float RandomRange(float min, float max)
		{
			return Random.Range(min, max);
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x00027950 File Offset: 0x00025B50
		[Obsolete("Use Random.Range instead")]
		public static int RandomRange(int min, int max)
		{
			return Random.Range(min, max);
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x0002796C File Offset: 0x00025B6C
		public static Color ColorHSV()
		{
			return Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x000279AC File Offset: 0x00025BAC
		public static Color ColorHSV(float hueMin, float hueMax)
		{
			return Random.ColorHSV(hueMin, hueMax, 0f, 1f, 0f, 1f, 1f, 1f);
		}

		// Token: 0x060017D3 RID: 6099 RVA: 0x000279E4 File Offset: 0x00025BE4
		public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax)
		{
			return Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, 0f, 1f, 1f, 1f);
		}

		// Token: 0x060017D4 RID: 6100 RVA: 0x00027A14 File Offset: 0x00025C14
		public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax)
		{
			return Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, 1f, 1f);
		}

		// Token: 0x060017D5 RID: 6101 RVA: 0x00027A40 File Offset: 0x00025C40
		public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax)
		{
			float h = Mathf.Lerp(hueMin, hueMax, Random.value);
			float s = Mathf.Lerp(saturationMin, saturationMax, Random.value);
			float v = Mathf.Lerp(valueMin, valueMax, Random.value);
			Color result = Color.HSVToRGB(h, s, v, true);
			result.a = Mathf.Lerp(alphaMin, alphaMax, Random.value);
			return result;
		}

		// Token: 0x060017D6 RID: 6102
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_state_Injected(out Random.State ret);

		// Token: 0x060017D7 RID: 6103
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_state_Injected(ref Random.State value);

		// Token: 0x060017D8 RID: 6104
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_insideUnitSphere_Injected(out Vector3 ret);

		// Token: 0x060017D9 RID: 6105
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_onUnitSphere_Injected(out Vector3 ret);

		// Token: 0x060017DA RID: 6106
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotation_Injected(out Quaternion ret);

		// Token: 0x060017DB RID: 6107
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationUniform_Injected(out Quaternion ret);

		// Token: 0x0200021C RID: 540
		[Serializable]
		public struct State
		{
			// Token: 0x0400087D RID: 2173
			[SerializeField]
			private int s0;

			// Token: 0x0400087E RID: 2174
			[SerializeField]
			private int s1;

			// Token: 0x0400087F RID: 2175
			[SerializeField]
			private int s2;

			// Token: 0x04000880 RID: 2176
			[SerializeField]
			private int s3;
		}
	}
}
