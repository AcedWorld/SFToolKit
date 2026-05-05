using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000009 RID: 9
	internal class SpawnOverDistance : VFXSpawnerCallbacks
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000023FA File Offset: 0x000005FA
		public sealed override void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			this.m_OldPosition = vfxValues.GetVector3(SpawnOverDistance.positionPropertyId);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002410 File Offset: 0x00000610
		public sealed override void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			if (!state.playing || state.deltaTime == 0f)
			{
				return;
			}
			float @float = vfxValues.GetFloat(SpawnOverDistance.velocityThresholdPropertyId);
			Vector3 vector = vfxValues.GetVector3(SpawnOverDistance.positionPropertyId);
			float num = Vector3.Magnitude(this.m_OldPosition - vector);
			if (@float <= 0f || num < @float * state.deltaTime)
			{
				float num2 = num * vfxValues.GetFloat(SpawnOverDistance.ratePerUnitPropertyId);
				if (vfxValues.GetBool(SpawnOverDistance.clampToOnePropertyId))
				{
					num2 = Mathf.Min(num2, 1f);
				}
				state.spawnCount += num2;
				state.vfxEventAttribute.SetVector3(SpawnOverDistance.oldPositionAttributeId, this.m_OldPosition);
				state.vfxEventAttribute.SetVector3(SpawnOverDistance.positionAttributeId, vector);
			}
			this.m_OldPosition = vector;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024D3 File Offset: 0x000006D3
		public sealed override void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
		}

		// Token: 0x04000012 RID: 18
		private Vector3 m_OldPosition;

		// Token: 0x04000013 RID: 19
		private static readonly int positionPropertyId = Shader.PropertyToID("Position");

		// Token: 0x04000014 RID: 20
		private static readonly int ratePerUnitPropertyId = Shader.PropertyToID("RatePerUnit");

		// Token: 0x04000015 RID: 21
		private static readonly int velocityThresholdPropertyId = Shader.PropertyToID("VelocityThreshold");

		// Token: 0x04000016 RID: 22
		private static readonly int clampToOnePropertyId = Shader.PropertyToID("ClampToOne");

		// Token: 0x04000017 RID: 23
		private static readonly int positionAttributeId = Shader.PropertyToID("position");

		// Token: 0x04000018 RID: 24
		private static readonly int oldPositionAttributeId = Shader.PropertyToID("oldPosition");

		// Token: 0x02000047 RID: 71
		public class InputProperties
		{
			// Token: 0x0400012B RID: 299
			public Vector3 Position = Vector3.zero;

			// Token: 0x0400012C RID: 300
			public float RatePerUnit = 10f;

			// Token: 0x0400012D RID: 301
			public float VelocityThreshold = 50f;

			// Token: 0x0400012E RID: 302
			public bool ClampToOne;
		}
	}
}
