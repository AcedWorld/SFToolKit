using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// Token: 0x02000004 RID: 4
[Serializable]
internal class VisualEffectActivationClip : PlayableAsset, ITimelineClipAsset
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000008 RID: 8 RVA: 0x00002192 File Offset: 0x00000392
	public ClipCaps clipCaps
	{
		get
		{
			return ClipCaps.None;
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002198 File Offset: 0x00000398
	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		ScriptPlayable<VisualEffectActivationBehaviour> playable = ScriptPlayable<VisualEffectActivationBehaviour>.Create(graph, this.activationBehavior, 0);
		playable.GetBehaviour();
		return playable;
	}

	// Token: 0x04000007 RID: 7
	public VisualEffectActivationBehaviour activationBehavior = new VisualEffectActivationBehaviour();
}
