using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000006 RID: 6
	internal class IncrementStripIndexOnStart : VFXSpawnerCallbacks
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002244 File Offset: 0x00000444
		public override void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			this.m_Index = (this.m_Index + 1U) % Math.Max(1U, vfxValues.GetUInt(IncrementStripIndexOnStart.stripMaxCountID));
			state.vfxEventAttribute.SetUint(IncrementStripIndexOnStart.stripIndexID, this.m_Index);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000227C File Offset: 0x0000047C
		public override void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			this.m_Index = 0U;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002285 File Offset: 0x00000485
		public override void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
		}

		// Token: 0x04000008 RID: 8
		private static readonly int stripMaxCountID = Shader.PropertyToID("StripMaxCount");

		// Token: 0x04000009 RID: 9
		private static readonly int stripIndexID = Shader.PropertyToID("stripIndex");

		// Token: 0x0400000A RID: 10
		private uint m_Index;

		// Token: 0x02000045 RID: 69
		public class InputProperties
		{
			// Token: 0x04000127 RID: 295
			[Tooltip("Maximum Strip Count (Used to cycle indices)")]
			public uint StripMaxCount = 8U;
		}
	}
}
