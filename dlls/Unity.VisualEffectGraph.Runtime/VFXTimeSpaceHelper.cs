using System;
using System.Collections.Generic;

namespace UnityEngine.VFX
{
	// Token: 0x02000017 RID: 23
	internal static class VFXTimeSpaceHelper
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00002BCD File Offset: 0x00000DCD
		public static IEnumerable<VisualEffectPlayableSerializedEvent> GetEventNormalizedSpace(PlayableTimeSpace space, VisualEffectControlPlayableBehaviour source)
		{
			return VFXTimeSpaceHelper.GetEventNormalizedSpace(space, source.events, source.clipStart, source.clipEnd);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002BE7 File Offset: 0x00000DE7
		private static IEnumerable<VisualEffectPlayableSerializedEvent> CollectClipEvents(VisualEffectControlClip source)
		{
			if (source.clipEvents != null)
			{
				foreach (VisualEffectControlClip.ClipEvent clipEvent in source.clipEvents)
				{
					VisualEffectPlayableSerializedEvent visualEffectPlayableSerializedEvent = clipEvent.enter;
					VisualEffectPlayableSerializedEvent eventExit = clipEvent.exit;
					visualEffectPlayableSerializedEvent.editorColor = (eventExit.editorColor = clipEvent.editorColor);
					yield return visualEffectPlayableSerializedEvent;
					yield return eventExit;
					eventExit = default(VisualEffectPlayableSerializedEvent);
				}
				List<VisualEffectControlClip.ClipEvent>.Enumerator enumerator = default(List<VisualEffectControlClip.ClipEvent>.Enumerator);
			}
			yield break;
			yield break;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002BF8 File Offset: 0x00000DF8
		public static IEnumerable<VisualEffectPlayableSerializedEvent> GetEventNormalizedSpace(PlayableTimeSpace space, VisualEffectControlClip source, bool clipEvents)
		{
			IEnumerable<VisualEffectPlayableSerializedEvent> events;
			if (clipEvents)
			{
				events = VFXTimeSpaceHelper.CollectClipEvents(source);
			}
			else
			{
				events = source.singleEvents;
			}
			return VFXTimeSpaceHelper.GetEventNormalizedSpace(space, events, source.clipStart, source.clipEnd);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002C2B File Offset: 0x00000E2B
		private static IEnumerable<VisualEffectPlayableSerializedEvent> GetEventNormalizedSpace(PlayableTimeSpace space, IEnumerable<VisualEffectPlayableSerializedEvent> events, double clipStart, double clipEnd)
		{
			foreach (VisualEffectPlayableSerializedEvent visualEffectPlayableSerializedEvent in events)
			{
				VisualEffectPlayableSerializedEvent visualEffectPlayableSerializedEvent2 = visualEffectPlayableSerializedEvent;
				visualEffectPlayableSerializedEvent2.timeSpace = space;
				visualEffectPlayableSerializedEvent2.time = VFXTimeSpaceHelper.GetTimeInSpace(visualEffectPlayableSerializedEvent.timeSpace, visualEffectPlayableSerializedEvent.time, space, clipStart, clipEnd);
				yield return visualEffectPlayableSerializedEvent2;
			}
			IEnumerator<VisualEffectPlayableSerializedEvent> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002C50 File Offset: 0x00000E50
		public static double GetTimeInSpace(PlayableTimeSpace srcSpace, double srcTime, PlayableTimeSpace dstSpace, double clipStart, double clipEnd)
		{
			if (srcSpace == dstSpace)
			{
				return srcTime;
			}
			if (dstSpace == PlayableTimeSpace.AfterClipStart)
			{
				switch (srcSpace)
				{
				case PlayableTimeSpace.BeforeClipEnd:
					return clipEnd - srcTime - clipStart;
				case PlayableTimeSpace.Percentage:
					return (clipEnd - clipStart) * (srcTime / 100.0);
				case PlayableTimeSpace.Absolute:
					return srcTime - clipStart;
				}
			}
			else if (dstSpace == PlayableTimeSpace.BeforeClipEnd)
			{
				switch (srcSpace)
				{
				case PlayableTimeSpace.AfterClipStart:
					return clipEnd - srcTime - clipStart;
				case PlayableTimeSpace.Percentage:
					return clipEnd - clipStart - (clipEnd - clipStart) * (srcTime / 100.0);
				case PlayableTimeSpace.Absolute:
					return clipEnd - srcTime;
				}
			}
			else if (dstSpace == PlayableTimeSpace.Percentage)
			{
				switch (srcSpace)
				{
				case PlayableTimeSpace.AfterClipStart:
					return 100.0 * srcTime / (clipEnd - clipStart);
				case PlayableTimeSpace.BeforeClipEnd:
					return 100.0 * (clipEnd - srcTime - clipStart) / (clipEnd - clipStart);
				case PlayableTimeSpace.Absolute:
					return 100.0 * (srcTime - clipStart) / (clipEnd - clipStart);
				}
			}
			else if (dstSpace == PlayableTimeSpace.Absolute)
			{
				switch (srcSpace)
				{
				case PlayableTimeSpace.AfterClipStart:
					return clipStart + srcTime;
				case PlayableTimeSpace.BeforeClipEnd:
					return clipEnd - srcTime;
				case PlayableTimeSpace.Percentage:
					return clipStart + (clipEnd - clipStart) * (srcTime / 100.0);
				}
			}
			throw new NotImplementedException(srcSpace.ToString() + " to " + dstSpace.ToString());
		}
	}
}
