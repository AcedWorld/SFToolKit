using System;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E1 RID: 225
	[Serializable]
	public class TextureCurve : IDisposable
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x00024786 File Offset: 0x00022986
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x0002478E File Offset: 0x0002298E
		public int length { get; private set; }

		// Token: 0x17000120 RID: 288
		public Keyframe this[int index]
		{
			get
			{
				return this.m_Curve[index];
			}
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x000247A5 File Offset: 0x000229A5
		public TextureCurve(AnimationCurve baseCurve, float zeroValue, bool loop, in Vector2 bounds) : this(baseCurve.keys, zeroValue, loop, bounds)
		{
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x000247B8 File Offset: 0x000229B8
		public TextureCurve(Keyframe[] keys, float zeroValue, bool loop, in Vector2 bounds)
		{
			this.m_Curve = new AnimationCurve(keys);
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			Vector2 vector = bounds;
			this.m_Range = vector.magnitude;
			this.length = keys.Length;
			this.SetDirty();
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0002480C File Offset: 0x00022A0C
		~TextureCurve()
		{
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00024834 File Offset: 0x00022A34
		[Obsolete("Please use Release() instead.")]
		public void Dispose()
		{
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00024836 File Offset: 0x00022A36
		public void Release()
		{
			CoreUtils.Destroy(this.m_Texture);
			this.m_Texture = null;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0002484A File Offset: 0x00022A4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetDirty()
		{
			this.m_IsCurveDirty = true;
			this.m_IsTextureDirty = true;
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0002485A File Offset: 0x00022A5A
		private static GraphicsFormat GetTextureFormat()
		{
			if (SystemInfo.IsFormatSupported(GraphicsFormat.R16_SFloat, FormatUsage.SetPixels))
			{
				return GraphicsFormat.R16_SFloat;
			}
			if (SystemInfo.IsFormatSupported(GraphicsFormat.R8_UNorm, FormatUsage.SetPixels))
			{
				return GraphicsFormat.R8_UNorm;
			}
			return GraphicsFormat.R8G8B8A8_UNorm;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00024878 File Offset: 0x00022A78
		public Texture2D GetTexture()
		{
			if (this.m_Texture == null)
			{
				this.m_Texture = new Texture2D(128, 1, TextureCurve.GetTextureFormat(), TextureCreationFlags.None);
				this.m_Texture.name = "CurveTexture";
				this.m_Texture.hideFlags = HideFlags.HideAndDontSave;
				this.m_Texture.filterMode = FilterMode.Bilinear;
				this.m_Texture.wrapMode = TextureWrapMode.Clamp;
				this.m_Texture.anisoLevel = 0;
				this.m_IsTextureDirty = true;
			}
			if (this.m_IsTextureDirty)
			{
				Color[] array = new Color[128];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].r = this.Evaluate((float)i * 0.0078125f);
				}
				this.m_Texture.SetPixels(array);
				this.m_Texture.Apply(false, false);
				this.m_IsTextureDirty = false;
			}
			return this.m_Texture;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00024954 File Offset: 0x00022B54
		public float Evaluate(float time)
		{
			if (this.m_IsCurveDirty)
			{
				this.length = this.m_Curve.length;
			}
			if (this.length == 0)
			{
				return this.m_ZeroValue;
			}
			if (!this.m_Loop || this.length == 1)
			{
				return this.m_Curve.Evaluate(time);
			}
			if (this.m_IsCurveDirty)
			{
				if (this.m_LoopingCurve == null)
				{
					this.m_LoopingCurve = new AnimationCurve();
				}
				Keyframe key = this.m_Curve[this.length - 1];
				key.time -= this.m_Range;
				Keyframe key2 = this.m_Curve[0];
				key2.time += this.m_Range;
				this.m_LoopingCurve.keys = this.m_Curve.keys;
				this.m_LoopingCurve.AddKey(key);
				this.m_LoopingCurve.AddKey(key2);
				this.m_IsCurveDirty = false;
			}
			return this.m_LoopingCurve.Evaluate(time);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00024A51 File Offset: 0x00022C51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int AddKey(float time, float value)
		{
			int num = this.m_Curve.AddKey(time, value);
			if (num > -1)
			{
				this.SetDirty();
			}
			return num;
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00024A6A File Offset: 0x00022C6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int MoveKey(int index, in Keyframe key)
		{
			int result = this.m_Curve.MoveKey(index, key);
			this.SetDirty();
			return result;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00024A84 File Offset: 0x00022C84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RemoveKey(int index)
		{
			this.m_Curve.RemoveKey(index);
			this.SetDirty();
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x00024A98 File Offset: 0x00022C98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SmoothTangents(int index, float weight)
		{
			this.m_Curve.SmoothTangents(index, weight);
			this.SetDirty();
		}

		// Token: 0x040004B4 RID: 1204
		private const int k_Precision = 128;

		// Token: 0x040004B5 RID: 1205
		private const float k_Step = 0.0078125f;

		// Token: 0x040004B7 RID: 1207
		[SerializeField]
		private bool m_Loop;

		// Token: 0x040004B8 RID: 1208
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x040004B9 RID: 1209
		[SerializeField]
		private float m_Range;

		// Token: 0x040004BA RID: 1210
		[SerializeField]
		private AnimationCurve m_Curve;

		// Token: 0x040004BB RID: 1211
		private AnimationCurve m_LoopingCurve;

		// Token: 0x040004BC RID: 1212
		private Texture2D m_Texture;

		// Token: 0x040004BD RID: 1213
		private bool m_IsCurveDirty;

		// Token: 0x040004BE RID: 1214
		private bool m_IsTextureDirty;
	}
}
