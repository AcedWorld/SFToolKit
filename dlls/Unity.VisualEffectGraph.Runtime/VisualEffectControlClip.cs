using System;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.VFX.Utility;

namespace UnityEngine.VFX
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	internal class VisualEffectControlClip : PlayableAsset, ITimelineClipAsset
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000257F File Offset: 0x0000077F
		public ClipCaps clipCaps
		{
			get
			{
				return ClipCaps.None;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002582 File Offset: 0x00000782
		// (set) Token: 0x06000028 RID: 40 RVA: 0x0000258A File Offset: 0x0000078A
		public double clipStart { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002593 File Offset: 0x00000793
		// (set) Token: 0x0600002A RID: 42 RVA: 0x0000259B File Offset: 0x0000079B
		public double clipEnd { get; set; }

		// Token: 0x0600002B RID: 43 RVA: 0x000025A4 File Offset: 0x000007A4
		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<VisualEffectControlPlayableBehaviour> playable = ScriptPlayable<VisualEffectControlPlayableBehaviour>.Create(graph, 0);
			VisualEffectControlPlayableBehaviour behaviour = playable.GetBehaviour();
			behaviour.clipStart = this.clipStart;
			behaviour.clipEnd = this.clipEnd;
			behaviour.scrubbing = this.scrubbing;
			behaviour.startSeed = this.startSeed;
			if (this.scrubbing)
			{
				behaviour.reinitEnter = true;
				behaviour.reinitExit = true;
			}
			else
			{
				switch (this.reinit)
				{
				case VisualEffectControlClip.ReinitMode.None:
					behaviour.reinitEnter = false;
					behaviour.reinitExit = false;
					break;
				case VisualEffectControlClip.ReinitMode.OnExitClip:
					behaviour.reinitEnter = false;
					behaviour.reinitExit = true;
					break;
				case VisualEffectControlClip.ReinitMode.OnEnterClip:
					behaviour.reinitEnter = true;
					behaviour.reinitExit = false;
					break;
				case VisualEffectControlClip.ReinitMode.OnEnterOrExitClip:
					behaviour.reinitEnter = true;
					behaviour.reinitExit = true;
					break;
				}
			}
			if (this.clipEvents == null)
			{
				this.clipEvents = new List<VisualEffectControlClip.ClipEvent>();
			}
			if (this.singleEvents == null)
			{
				this.singleEvents = new List<VisualEffectPlayableSerializedEvent>();
			}
			behaviour.clipEventsCount = (uint)this.clipEvents.Count;
			List<VisualEffectPlayableSerializedEvent> list = new List<VisualEffectPlayableSerializedEvent>();
			foreach (VisualEffectControlClip.ClipEvent clipEvent in this.clipEvents)
			{
				list.Add(clipEvent.enter);
				list.Add(clipEvent.exit);
			}
			foreach (VisualEffectPlayableSerializedEvent item in this.singleEvents)
			{
				list.Add(item);
			}
			behaviour.events = list.ToArray();
			if (!this.prewarm.enable || !behaviour.reinitEnter || this.prewarm.eventName == null || string.IsNullOrEmpty((string)this.prewarm.eventName))
			{
				behaviour.prewarmStepCount = 0U;
				behaviour.prewarmDeltaTime = 0f;
				behaviour.prewarmEvent = null;
			}
			else
			{
				behaviour.prewarmStepCount = this.prewarm.stepCount;
				behaviour.prewarmDeltaTime = this.prewarm.deltaTime;
				behaviour.prewarmEvent = this.prewarm.eventName;
			}
			return playable;
		}

		// Token: 0x0400001D RID: 29
		[NotKeyable]
		public bool scrubbing = true;

		// Token: 0x0400001E RID: 30
		[NotKeyable]
		public uint startSeed;

		// Token: 0x0400001F RID: 31
		[NotKeyable]
		public VisualEffectControlClip.ReinitMode reinit = VisualEffectControlClip.ReinitMode.OnEnterOrExitClip;

		// Token: 0x04000020 RID: 32
		[NotKeyable]
		public VisualEffectControlClip.PrewarmClipSettings prewarm = new VisualEffectControlClip.PrewarmClipSettings
		{
			enable = false,
			stepCount = 20U,
			deltaTime = 0.05f,
			eventName = "OnPlay"
		};

		// Token: 0x04000021 RID: 33
		[NotKeyable]
		public List<VisualEffectControlClip.ClipEvent> clipEvents = new List<VisualEffectControlClip.ClipEvent>
		{
			new VisualEffectControlClip.ClipEvent
			{
				editorColor = VisualEffectControlClip.ClipEvent.defaultEditorColor,
				enter = new VisualEffectPlayableSerializedEventNoColor
				{
					name = "OnPlay",
					time = 0.0,
					timeSpace = PlayableTimeSpace.AfterClipStart,
					eventAttributes = new EventAttributes
					{
						content = Array.Empty<EventAttribute>()
					}
				},
				exit = new VisualEffectPlayableSerializedEventNoColor
				{
					name = "OnStop",
					time = 0.0,
					timeSpace = PlayableTimeSpace.BeforeClipEnd,
					eventAttributes = new EventAttributes
					{
						content = Array.Empty<EventAttribute>()
					}
				}
			}
		};

		// Token: 0x04000022 RID: 34
		[NotKeyable]
		public List<VisualEffectPlayableSerializedEvent> singleEvents = new List<VisualEffectPlayableSerializedEvent>();

		// Token: 0x02000049 RID: 73
		public enum ReinitMode
		{
			// Token: 0x04000134 RID: 308
			None,
			// Token: 0x04000135 RID: 309
			OnExitClip,
			// Token: 0x04000136 RID: 310
			OnEnterClip,
			// Token: 0x04000137 RID: 311
			OnEnterOrExitClip
		}

		// Token: 0x0200004A RID: 74
		[Serializable]
		public struct PrewarmClipSettings
		{
			// Token: 0x04000138 RID: 312
			public bool enable;

			// Token: 0x04000139 RID: 313
			public uint stepCount;

			// Token: 0x0400013A RID: 314
			public float deltaTime;

			// Token: 0x0400013B RID: 315
			public ExposedProperty eventName;
		}

		// Token: 0x0200004B RID: 75
		[Serializable]
		public struct ClipEvent
		{
			// Token: 0x0400013C RID: 316
			public static Color defaultEditorColor = new Color32(123, 158, 5, byte.MaxValue);

			// Token: 0x0400013D RID: 317
			public Color editorColor;

			// Token: 0x0400013E RID: 318
			public VisualEffectPlayableSerializedEventNoColor enter;

			// Token: 0x0400013F RID: 319
			public VisualEffectPlayableSerializedEventNoColor exit;
		}
	}
}
