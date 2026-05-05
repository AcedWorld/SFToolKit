using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000090 RID: 144
	[ExecuteAlways]
	[AddComponentMenu("Rendering/Probe Volume")]
	public class ProbeVolume : MonoBehaviour
	{
		// Token: 0x060004C8 RID: 1224 RVA: 0x00017425 File Offset: 0x00015625
		private void Awake()
		{
			if (this.version == ProbeVolume.Version.Count)
			{
				return;
			}
			if (this.version == ProbeVolume.Version.Initial)
			{
				this.mode = (this.globalVolume ? ProbeVolume.Mode.Scene : ProbeVolume.Mode.Local);
				this.version++;
			}
		}

		// Token: 0x04000314 RID: 788
		[Tooltip("When set to Global this Probe Volume considers all renderers with Contribute Global Illumination enabled. Local only considers renderers in the scene.\nThis list updates every time the Scene is saved or the lighting is baked.")]
		public ProbeVolume.Mode mode = ProbeVolume.Mode.Scene;

		// Token: 0x04000315 RID: 789
		public Vector3 size = new Vector3(10f, 10f, 10f);

		// Token: 0x04000316 RID: 790
		[HideInInspector]
		[Min(0f)]
		public bool overrideRendererFilters;

		// Token: 0x04000317 RID: 791
		[HideInInspector]
		[Min(0f)]
		public float minRendererVolumeSize = 0.1f;

		// Token: 0x04000318 RID: 792
		public LayerMask objectLayerMask = -1;

		// Token: 0x04000319 RID: 793
		[HideInInspector]
		public int lowestSubdivLevelOverride;

		// Token: 0x0400031A RID: 794
		[HideInInspector]
		public int highestSubdivLevelOverride = -1;

		// Token: 0x0400031B RID: 795
		[HideInInspector]
		public bool overridesSubdivLevels;

		// Token: 0x0400031C RID: 796
		[SerializeField]
		internal bool mightNeedRebaking;

		// Token: 0x0400031D RID: 797
		[SerializeField]
		internal Matrix4x4 cachedTransform;

		// Token: 0x0400031E RID: 798
		[SerializeField]
		internal int cachedHashCode;

		// Token: 0x0400031F RID: 799
		[HideInInspector]
		[Tooltip("Whether spaces with no renderers need to be filled with bricks at lowest subdivision level.")]
		public bool fillEmptySpaces;

		// Token: 0x04000320 RID: 800
		[SerializeField]
		private ProbeVolume.Version version;

		// Token: 0x04000321 RID: 801
		[SerializeField]
		[Obsolete("Use mode instead")]
		public bool globalVolume;

		// Token: 0x020001A9 RID: 425
		public enum Mode
		{
			// Token: 0x04000704 RID: 1796
			Global,
			// Token: 0x04000705 RID: 1797
			Scene,
			// Token: 0x04000706 RID: 1798
			Local
		}

		// Token: 0x020001AA RID: 426
		private enum Version
		{
			// Token: 0x04000708 RID: 1800
			Initial,
			// Token: 0x04000709 RID: 1801
			LocalMode,
			// Token: 0x0400070A RID: 1802
			Count
		}
	}
}
