using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000008 RID: 8
	internal class SetSpawnTime : VFXSpawnerCallbacks
	{
		// Token: 0x06000017 RID: 23 RVA: 0x000023C5 File Offset: 0x000005C5
		public sealed override void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000023C7 File Offset: 0x000005C7
		public sealed override void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			state.vfxEventAttribute.SetFloat(SetSpawnTime.spawnTimeID, state.totalTime);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000023DF File Offset: 0x000005DF
		public sealed override void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
		}

		// Token: 0x04000011 RID: 17
		private static readonly int spawnTimeID = Shader.PropertyToID("spawnTime");
	}
}
