using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C6 RID: 198
	[Obsolete("BatchRendererGroupGlobals and associated cbuffer are now set automatically by Unity. Setting it manually is no longer necessary or supported.")]
	[Serializable]
	public struct BatchRendererGroupGlobals : IEquatable<BatchRendererGroupGlobals>
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x0001F298 File Offset: 0x0001D498
		public static BatchRendererGroupGlobals Default
		{
			get
			{
				BatchRendererGroupGlobals batchRendererGroupGlobals = default(BatchRendererGroupGlobals);
				batchRendererGroupGlobals.ProbesOcclusion = Vector4.one;
				batchRendererGroupGlobals.SpecCube0_HDR = ReflectionProbe.defaultTextureHDRDecodeValues;
				batchRendererGroupGlobals.SpecCube1_HDR = batchRendererGroupGlobals.SpecCube0_HDR;
				batchRendererGroupGlobals.SHCoefficients = new SHCoefficients(RenderSettings.ambientProbe);
				return batchRendererGroupGlobals;
			}
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
		public bool Equals(BatchRendererGroupGlobals other)
		{
			return this.ProbesOcclusion.Equals(other.ProbesOcclusion) && this.SpecCube0_HDR.Equals(other.SpecCube0_HDR) && this.SpecCube1_HDR.Equals(other.SpecCube1_HDR) && this.SHCoefficients.Equals(other.SHCoefficients);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001F340 File Offset: 0x0001D540
		public override bool Equals(object obj)
		{
			if (obj is BatchRendererGroupGlobals)
			{
				BatchRendererGroupGlobals other = (BatchRendererGroupGlobals)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0001F365 File Offset: 0x0001D565
		public override int GetHashCode()
		{
			return HashCode.Combine<Vector4, Vector4, Vector4, SHCoefficients>(this.ProbesOcclusion, this.SpecCube0_HDR, this.SpecCube1_HDR, this.SHCoefficients);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001F384 File Offset: 0x0001D584
		public static bool operator ==(BatchRendererGroupGlobals left, BatchRendererGroupGlobals right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001F38E File Offset: 0x0001D58E
		public static bool operator !=(BatchRendererGroupGlobals left, BatchRendererGroupGlobals right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000466 RID: 1126
		public const string kGlobalsPropertyName = "unity_DOTSInstanceGlobalValues";

		// Token: 0x04000467 RID: 1127
		public static readonly int kGlobalsPropertyId = Shader.PropertyToID("unity_DOTSInstanceGlobalValues");

		// Token: 0x04000468 RID: 1128
		public Vector4 ProbesOcclusion;

		// Token: 0x04000469 RID: 1129
		public Vector4 SpecCube0_HDR;

		// Token: 0x0400046A RID: 1130
		public Vector4 SpecCube1_HDR;

		// Token: 0x0400046B RID: 1131
		public SHCoefficients SHCoefficients;
	}
}
