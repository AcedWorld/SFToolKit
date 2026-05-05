using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200008E RID: 142
	public sealed class ProbeReferenceVolumeProfile : ScriptableObject
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0001730A File Offset: 0x0001550A
		public int cellSizeInBricks
		{
			get
			{
				return (int)Mathf.Pow(3f, (float)this.simplificationLevels);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0001731E File Offset: 0x0001551E
		public int maxSubdivision
		{
			get
			{
				return this.simplificationLevels + 1;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00017328 File Offset: 0x00015528
		public float minBrickSize
		{
			get
			{
				return Mathf.Max(0.01f, this.minDistanceBetweenProbes * 3f);
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00017340 File Offset: 0x00015540
		public float cellSizeInMeters
		{
			get
			{
				return (float)this.cellSizeInBricks * this.minBrickSize;
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00017350 File Offset: 0x00015550
		private void OnEnable()
		{
			ProbeReferenceVolumeProfile.Version version = this.version;
			CoreUtils.GetLastEnumValue<ProbeReferenceVolumeProfile.Version>();
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00017360 File Offset: 0x00015560
		public bool IsEquivalent(ProbeReferenceVolumeProfile otherProfile)
		{
			return this.minDistanceBetweenProbes == otherProfile.minDistanceBetweenProbes && this.cellSizeInMeters == otherProfile.cellSizeInMeters && this.simplificationLevels == otherProfile.simplificationLevels && this.renderersLayerMask == otherProfile.renderersLayerMask;
		}

		// Token: 0x04000309 RID: 777
		[SerializeField]
		private ProbeReferenceVolumeProfile.Version version = CoreUtils.GetLastEnumValue<ProbeReferenceVolumeProfile.Version>();

		// Token: 0x0400030A RID: 778
		[SerializeField]
		internal bool freezePlacement;

		// Token: 0x0400030B RID: 779
		[Range(2f, 5f)]
		public int simplificationLevels = 3;

		// Token: 0x0400030C RID: 780
		[Min(0.1f)]
		public float minDistanceBetweenProbes = 1f;

		// Token: 0x0400030D RID: 781
		public LayerMask renderersLayerMask = -1;

		// Token: 0x0400030E RID: 782
		[Min(0f)]
		public float minRendererVolumeSize = 0.1f;

		// Token: 0x020001A8 RID: 424
		internal enum Version
		{
			// Token: 0x04000702 RID: 1794
			Initial
		}
	}
}
