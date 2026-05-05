using System;
using UnityEngine.Playables;

namespace UnityEngine.VFX
{
	// Token: 0x0200001E RID: 30
	internal class VisualEffectControlTrackMixerBehaviour : PlayableBehaviour
	{
		// Token: 0x06000068 RID: 104 RVA: 0x00003B22 File Offset: 0x00001D22
		public void Init(VisualEffectControlTrack parentTrack, bool reinitWithBinding, bool reinitWithUnbinding)
		{
			this.m_ReinitWithBinding = reinitWithBinding;
			this.m_ReinitWithUnbinding = reinitWithUnbinding;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003B34 File Offset: 0x00001D34
		public override void PrepareFrame(Playable playable, FrameData data)
		{
			if (this.m_Target == null)
			{
				return;
			}
			if (this.m_ScrubbingCacheHelper == null)
			{
				this.m_ScrubbingCacheHelper = new VisualEffectControlTrackController();
				VisualEffectControlTrack parentTrack = null;
				this.m_ScrubbingCacheHelper.Init(playable, this.m_Target, parentTrack);
			}
			double duration = playable.GetOutput(0).GetDuration<Playable>();
			double num = playable.GetTime<Playable>();
			int num2 = (int)(num / duration);
			num -= (double)num2 * duration;
			float deltaTime = data.deltaTime;
			this.m_ScrubbingCacheHelper.Update(num, deltaTime);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003BAF File Offset: 0x00001DAF
		private void BindVFX(VisualEffect vfx)
		{
			this.m_Target = vfx;
			if (this.m_Target != null && this.m_ReinitWithBinding)
			{
				this.m_Target.Reinit(false);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003BDA File Offset: 0x00001DDA
		private void UnbindVFX()
		{
			if (this.m_Target != null && this.m_ReinitWithUnbinding)
			{
				this.m_Target.Reinit(true);
			}
			this.m_Target = null;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003C08 File Offset: 0x00001E08
		public override void ProcessFrame(Playable playable, FrameData data, object playerData)
		{
			VisualEffect visualEffect = playerData as VisualEffect;
			if (this.m_Target == visualEffect)
			{
				return;
			}
			this.UnbindVFX();
			if (visualEffect != null)
			{
				if (visualEffect.visualEffectAsset == null)
				{
					visualEffect = null;
				}
				else if (!visualEffect.isActiveAndEnabled)
				{
					visualEffect = null;
				}
			}
			this.BindVFX(visualEffect);
			this.InvalidateScrubbingHelper();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003C63 File Offset: 0x00001E63
		public override void OnBehaviourPause(Playable playable, FrameData data)
		{
			base.OnBehaviourPause(playable, data);
			this.PrepareFrame(playable, data);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003C75 File Offset: 0x00001E75
		private void InvalidateScrubbingHelper()
		{
			if (this.m_ScrubbingCacheHelper != null)
			{
				this.m_ScrubbingCacheHelper.Release();
				this.m_ScrubbingCacheHelper = null;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003C91 File Offset: 0x00001E91
		public override void OnPlayableCreate(Playable playable)
		{
			this.InvalidateScrubbingHelper();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003C99 File Offset: 0x00001E99
		public override void OnPlayableDestroy(Playable playable)
		{
			this.InvalidateScrubbingHelper();
			this.UnbindVFX();
		}

		// Token: 0x0400004D RID: 77
		private VisualEffectControlTrackController m_ScrubbingCacheHelper;

		// Token: 0x0400004E RID: 78
		private VisualEffect m_Target;

		// Token: 0x0400004F RID: 79
		private bool m_ReinitWithBinding;

		// Token: 0x04000050 RID: 80
		private bool m_ReinitWithUnbinding;
	}
}
