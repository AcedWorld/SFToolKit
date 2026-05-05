using System;

namespace UnityEngine.VFX
{
	// Token: 0x02000007 RID: 7
	internal class LoopAndDelay : VFXSpawnerCallbacks
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000022AF File Offset: 0x000004AF
		public sealed override void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			this.m_LoopMaxCount = vfxValues.GetInt(LoopAndDelay.loopCountPropertyID);
			this.m_WaitingForTotalTime = vfxValues.GetFloat(LoopAndDelay.loopDurationPropertyID);
			this.m_LoopCurrentIndex = 0;
			if (this.m_LoopMaxCount == this.m_LoopCurrentIndex)
			{
				state.playing = false;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022F0 File Offset: 0x000004F0
		public sealed override void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			if (this.m_LoopCurrentIndex != this.m_LoopMaxCount && state.totalTime > this.m_WaitingForTotalTime)
			{
				if (state.playing)
				{
					this.m_WaitingForTotalTime = state.totalTime + vfxValues.GetFloat(LoopAndDelay.delayPropertyID);
					state.playing = false;
					this.m_LoopCurrentIndex = ((this.m_LoopCurrentIndex + 1 > 0) ? (this.m_LoopCurrentIndex + 1) : 0);
					return;
				}
				this.m_WaitingForTotalTime = vfxValues.GetFloat(LoopAndDelay.loopDurationPropertyID);
				state.totalTime = 0f;
				state.playing = true;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002380 File Offset: 0x00000580
		public sealed override void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
		{
			this.m_LoopCurrentIndex = this.m_LoopMaxCount;
		}

		// Token: 0x0400000B RID: 11
		private int m_LoopMaxCount;

		// Token: 0x0400000C RID: 12
		private int m_LoopCurrentIndex;

		// Token: 0x0400000D RID: 13
		private float m_WaitingForTotalTime;

		// Token: 0x0400000E RID: 14
		private static readonly int loopCountPropertyID = Shader.PropertyToID("LoopCount");

		// Token: 0x0400000F RID: 15
		private static readonly int loopDurationPropertyID = Shader.PropertyToID("LoopDuration");

		// Token: 0x04000010 RID: 16
		private static readonly int delayPropertyID = Shader.PropertyToID("Delay");

		// Token: 0x02000046 RID: 70
		public class InputProperties
		{
			// Token: 0x04000128 RID: 296
			[Tooltip("Number of Loops (< 0 for infinite), evaluated when Context Start is hit")]
			public int LoopCount = 1;

			// Token: 0x04000129 RID: 297
			[Tooltip("Duration of one loop, evaluated every loop")]
			public float LoopDuration = 4f;

			// Token: 0x0400012A RID: 298
			[Tooltip("Duration of in-between delay (after each loop), evaluated every loop")]
			public float Delay = 1f;
		}
	}
}
