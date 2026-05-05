using System;
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityEngine.VFX
{
	// Token: 0x0200001C RID: 28
	[TrackColor(0.5990566f, 0.9038978f, 1f)]
	[TrackClipType(typeof(VisualEffectControlClip))]
	[TrackBindingType(typeof(VisualEffect))]
	internal class VisualEffectControlTrack : TrackAsset
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00002E9D File Offset: 0x0000109D
		public bool IsUpToDate()
		{
			return this.m_VFXVersion == 1;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002EA8 File Offset: 0x000010A8
		protected override void OnBeforeTrackSerialize()
		{
			base.OnBeforeTrackSerialize();
			if (base.GetClips().All((TimelineClip x) => x.asset is VisualEffectControlClip))
			{
				this.m_VFXVersion = 1;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002EE4 File Offset: 0x000010E4
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			foreach (TimelineClip timelineClip in base.GetClips())
			{
				VisualEffectControlClip visualEffectControlClip = timelineClip.asset as VisualEffectControlClip;
				if (visualEffectControlClip != null)
				{
					visualEffectControlClip.clipStart = timelineClip.start;
					visualEffectControlClip.clipEnd = timelineClip.end;
				}
			}
			ScriptPlayable<VisualEffectControlTrackMixerBehaviour> playable = ScriptPlayable<VisualEffectControlTrackMixerBehaviour>.Create(graph, inputCount);
			VisualEffectControlTrackMixerBehaviour behaviour = playable.GetBehaviour();
			bool reinitWithBinding = this.reinit == VisualEffectControlTrack.ReinitMode.OnBindingEnable || this.reinit == VisualEffectControlTrack.ReinitMode.OnBindingEnableOrDisable;
			bool reinitWithUnbinding = this.reinit == VisualEffectControlTrack.ReinitMode.OnBindingDisable || this.reinit == VisualEffectControlTrack.ReinitMode.OnBindingEnableOrDisable;
			behaviour.Init(this, reinitWithBinding, reinitWithUnbinding);
			return playable;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002FA4 File Offset: 0x000011A4
		public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
		{
			if (director.GetGenericBinding(this) is VisualEffect)
			{
				base.GatherProperties(director, driver);
			}
		}

		// Token: 0x04000041 RID: 65
		private const int kCurrentVersion = 1;

		// Token: 0x04000042 RID: 66
		[SerializeField]
		[HideInInspector]
		private int m_VFXVersion;

		// Token: 0x04000043 RID: 67
		[SerializeField]
		[NotKeyable]
		public VisualEffectControlTrack.ReinitMode reinit = VisualEffectControlTrack.ReinitMode.OnBindingEnableOrDisable;

		// Token: 0x02000055 RID: 85
		public enum ReinitMode
		{
			// Token: 0x04000169 RID: 361
			None,
			// Token: 0x0400016A RID: 362
			OnBindingEnable,
			// Token: 0x0400016B RID: 363
			OnBindingDisable,
			// Token: 0x0400016C RID: 364
			OnBindingEnableOrDisable
		}
	}
}
