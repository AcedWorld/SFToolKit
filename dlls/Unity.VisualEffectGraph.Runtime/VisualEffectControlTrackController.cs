using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Playables;

namespace UnityEngine.VFX
{
	// Token: 0x0200001D RID: 29
	internal class VisualEffectControlTrackController
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00002FCC File Offset: 0x000011CC
		private void OnEnterChunk(int currentChunk)
		{
			VisualEffectControlTrackController.Chunk chunk = this.m_Chunks[currentChunk];
			if (chunk.reinitEnter)
			{
				this.m_Target.resetSeedOnPlay = false;
				this.m_Target.startSeed = chunk.startSeed;
				this.m_Target.Reinit(false);
				if (chunk.prewarmCount != 0U)
				{
					this.m_Target.SendEvent(chunk.prewarmEvent);
					this.m_Target.Simulate(chunk.prewarmDeltaTime, chunk.prewarmCount);
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003048 File Offset: 0x00001248
		private void OnLeaveChunk(int previousChunkIndex, bool leavingGoingBeforeClip)
		{
			VisualEffectControlTrackController.Chunk chunk = this.m_Chunks[previousChunkIndex];
			if (chunk.reinitExit)
			{
				this.m_Target.Reinit(false);
			}
			else
			{
				this.ProcessNoScrubbingEvents(chunk, this.m_LastPlayableTime, leavingGoingBeforeClip ? double.NegativeInfinity : double.PositiveInfinity);
			}
			this.RestoreVFXState(chunk.scrubbing, chunk.reinitEnter);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000030B0 File Offset: 0x000012B0
		private bool IsTimeInChunk(double time, int index)
		{
			VisualEffectControlTrackController.Chunk chunk = this.m_Chunks[index];
			return chunk.begin <= time && time < chunk.end;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000030E0 File Offset: 0x000012E0
		public void Update(double playableTime, float deltaTime)
		{
			bool flag = (double)deltaTime == 0.0;
			int num = int.MinValue;
			if (this.m_LastChunk != num && this.IsTimeInChunk(playableTime, this.m_LastChunk))
			{
				num = this.m_LastChunk;
			}
			if (num == -2147483648)
			{
				uint num2 = (uint)((this.m_LastChunk != int.MinValue) ? this.m_LastEvent : 0);
				uint num3 = num2;
				while ((ulong)num3 < (ulong)num2 + (ulong)((long)this.m_Chunks.Length))
				{
					int num4 = (int)((ulong)num3 % (ulong)((long)this.m_Chunks.Length));
					if (this.IsTimeInChunk(playableTime, num4))
					{
						num = num4;
						break;
					}
					num3 += 1U;
				}
			}
			bool flag2 = false;
			if (this.m_LastChunk != num)
			{
				if (this.m_LastChunk != -2147483648)
				{
					bool leavingGoingBeforeClip = playableTime < this.m_Chunks[this.m_LastChunk].begin;
					this.OnLeaveChunk(this.m_LastChunk, leavingGoingBeforeClip);
				}
				if (num != -2147483648)
				{
					this.OnEnterChunk(num);
					flag2 = true;
				}
				this.m_LastChunk = num;
				this.m_LastEvent = int.MinValue;
			}
			if (num != -2147483648)
			{
				VisualEffectControlTrackController.Chunk chunk = this.m_Chunks[num];
				if (chunk.scrubbing)
				{
					this.m_Target.pause = flag;
					double num5 = chunk.begin + (double)this.m_Target.time;
					if (!flag2)
					{
						num5 -= chunk.prewarmOffset;
					}
					if (playableTime >= this.m_LastPlayableTime)
					{
						if (Math.Abs(this.m_LastPlayableTime - num5) < (double)VFXManager.maxDeltaTime)
						{
							num5 = this.m_LastPlayableTime;
						}
					}
					else
					{
						num5 = chunk.begin;
						this.m_LastEvent = int.MinValue;
						this.OnEnterChunk(this.m_LastChunk);
					}
					double num6;
					if (flag)
					{
						num6 = playableTime;
					}
					else
					{
						num6 = playableTime - (double)VFXManager.fixedTimeStep;
					}
					if (this.m_LastPlayableTime < num5)
					{
						List<int> eventListIndexCache = this.m_EventListIndexCache;
						VisualEffectControlTrackController.GetEventsIndex(chunk, this.m_LastPlayableTime, num5, this.m_LastEvent, eventListIndexCache);
						foreach (int eventIndex in eventListIndexCache)
						{
							this.ProcessEvent(eventIndex, chunk);
						}
					}
					if (num5 < num6)
					{
						List<int> eventListIndexCache2 = this.m_EventListIndexCache;
						VisualEffectControlTrackController.GetEventsIndex(chunk, num5, num6, this.m_LastEvent, eventListIndexCache2);
						int count = eventListIndexCache2.Count;
						int num7 = 0;
						float maxScrubTime = VFXManager.maxScrubTime;
						float num8 = VFXManager.maxDeltaTime;
						if (num6 - num5 > (double)maxScrubTime)
						{
							num8 = (float)((num6 - num5) * (double)VFXManager.maxDeltaTime / (double)maxScrubTime);
						}
						while (num5 < num6)
						{
							int num9 = int.MinValue;
							uint num10;
							if (num7 < count)
							{
								num9 = eventListIndexCache2.ElementAt(num7++);
								num10 = (uint)((chunk.events[num9].time - num5) / (double)num8);
							}
							else
							{
								num10 = (uint)((num6 - num5) / (double)num8);
								if (num10 == 0U)
								{
									break;
								}
							}
							if (num10 != 0U)
							{
								this.m_Target.Simulate(num8, num10);
								num5 += (double)(num8 * num10);
							}
							this.ProcessEvent(num9, chunk);
						}
					}
					if (num5 >= playableTime)
					{
						goto IL_353;
					}
					List<int> eventListIndexCache3 = this.m_EventListIndexCache;
					VisualEffectControlTrackController.GetEventsIndex(chunk, num5, playableTime, this.m_LastEvent, eventListIndexCache3);
					using (List<int>.Enumerator enumerator = eventListIndexCache3.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							int eventIndex2 = enumerator.Current;
							this.ProcessEvent(eventIndex2, chunk);
						}
						goto IL_353;
					}
				}
				this.m_Target.pause = false;
				this.ProcessNoScrubbingEvents(chunk, this.m_LastPlayableTime, playableTime);
			}
			IL_353:
			this.m_LastPlayableTime = playableTime;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003464 File Offset: 0x00001664
		private void ProcessNoScrubbingEvents(VisualEffectControlTrackController.Chunk chunk, double oldTime, double newTime)
		{
			if (newTime < oldTime)
			{
				List<int> eventListIndexCache = this.m_EventListIndexCache;
				VisualEffectControlTrackController.GetEventsIndex(chunk, newTime, oldTime, int.MinValue, eventListIndexCache);
				if (eventListIndexCache.Count > 0)
				{
					for (int i = eventListIndexCache.Count - 1; i >= 0; i--)
					{
						int num = eventListIndexCache[i];
						VisualEffectControlTrackController.Event @event = chunk.events[num];
						if (@event.clipType == VisualEffectControlTrackController.Event.ClipType.Enter)
						{
							this.ProcessEvent(chunk.clips[@event.clipIndex].exit, chunk);
						}
						else if (@event.clipType == VisualEffectControlTrackController.Event.ClipType.Exit)
						{
							this.ProcessEvent(chunk.clips[@event.clipIndex].enter, chunk);
						}
					}
					this.m_LastEvent = int.MinValue;
					return;
				}
			}
			else
			{
				List<int> eventListIndexCache2 = this.m_EventListIndexCache;
				VisualEffectControlTrackController.GetEventsIndex(chunk, oldTime, newTime, this.m_LastEvent, eventListIndexCache2);
				foreach (int eventIndex in eventListIndexCache2)
				{
					this.ProcessEvent(eventIndex, chunk);
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000357C File Offset: 0x0000177C
		private void ProcessEvent(int eventIndex, VisualEffectControlTrackController.Chunk currentChunk)
		{
			if (eventIndex == -2147483648)
			{
				return;
			}
			this.m_LastEvent = eventIndex;
			VisualEffectControlTrackController.Event @event = currentChunk.events[eventIndex];
			this.m_Target.SendEvent(@event.nameId, @event.attribute);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000035C0 File Offset: 0x000017C0
		private static void GetEventsIndex(VisualEffectControlTrackController.Chunk chunk, double minTime, double maxTime, int lastIndex, List<int> eventListIndex)
		{
			eventListIndex.Clear();
			for (int i = (lastIndex == int.MinValue) ? 0 : (lastIndex + 1); i < chunk.events.Length; i++)
			{
				VisualEffectControlTrackController.Event @event = chunk.events[i];
				if (@event.time >= maxTime)
				{
					break;
				}
				if (minTime <= @event.time)
				{
					eventListIndex.Add(i);
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000361C File Offset: 0x0000181C
		private static VFXEventAttribute ComputeAttribute(VisualEffect vfx, EventAttributes attributes)
		{
			if (attributes.content == null || attributes.content.Length == 0)
			{
				return null;
			}
			VFXEventAttribute vfxAttribute = vfx.CreateVFXEventAttribute();
			if (attributes.content.Count((EventAttribute x) => x != null && x.ApplyToVFX(vfxAttribute)) == 0)
			{
				return null;
			}
			return vfxAttribute;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000366F File Offset: 0x0000186F
		private static IEnumerable<VisualEffectControlTrackController.Event> ComputeRuntimeEvent(VisualEffectControlPlayableBehaviour behavior, VisualEffect vfx)
		{
			IEnumerable<VisualEffectPlayableSerializedEvent> eventNormalizedSpace = VFXTimeSpaceHelper.GetEventNormalizedSpace(PlayableTimeSpace.Absolute, behavior);
			foreach (VisualEffectPlayableSerializedEvent visualEffectPlayableSerializedEvent in eventNormalizedSpace)
			{
				double time = Math.Max(behavior.clipStart, Math.Min(behavior.clipEnd, visualEffectPlayableSerializedEvent.time));
				yield return new VisualEffectControlTrackController.Event
				{
					attribute = VisualEffectControlTrackController.ComputeAttribute(vfx, visualEffectPlayableSerializedEvent.eventAttributes),
					nameId = visualEffectPlayableSerializedEvent.name,
					time = time,
					clipIndex = -1,
					clipType = VisualEffectControlTrackController.Event.ClipType.None
				};
			}
			IEnumerator<VisualEffectPlayableSerializedEvent> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003688 File Offset: 0x00001888
		public void RestoreVFXState(bool restorePause = true, bool restoreSeedState = true)
		{
			if (this.m_Target == null)
			{
				return;
			}
			if (restorePause)
			{
				this.m_Target.pause = false;
			}
			if (restoreSeedState)
			{
				this.m_Target.startSeed = this.m_BackupStartSeed;
				this.m_Target.resetSeedOnPlay = this.m_BackupReseedOnPlay;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000036D8 File Offset: 0x000018D8
		public void Init(Playable playable, VisualEffect vfx, VisualEffectControlTrack parentTrack)
		{
			this.m_Target = vfx;
			this.m_BackupStartSeed = this.m_Target.startSeed;
			this.m_BackupReseedOnPlay = this.m_Target.resetSeedOnPlay;
			Stack<VisualEffectControlTrackController.Chunk> stack = new Stack<VisualEffectControlTrackController.Chunk>();
			int inputCount = playable.GetInputCount<Playable>();
			List<VisualEffectControlPlayableBehaviour> list = new List<VisualEffectControlPlayableBehaviour>();
			for (int k = 0; k < inputCount; k++)
			{
				Playable input = playable.GetInput(k);
				if (!(input.GetPlayableType() != typeof(VisualEffectControlPlayableBehaviour)))
				{
					VisualEffectControlPlayableBehaviour behaviour = ((ScriptPlayable<T>)input).GetBehaviour();
					if (behaviour != null)
					{
						list.Add(behaviour);
					}
				}
			}
			list.Sort(new VisualEffectControlTrackController.VisualEffectControlPlayableBehaviourComparer());
			foreach (VisualEffectControlPlayableBehaviour visualEffectControlPlayableBehaviour in list)
			{
				if (!stack.Any<VisualEffectControlTrackController.Chunk>() || visualEffectControlPlayableBehaviour.clipStart > stack.Peek().end || visualEffectControlPlayableBehaviour.scrubbing != stack.Peek().scrubbing || (!visualEffectControlPlayableBehaviour.scrubbing && (visualEffectControlPlayableBehaviour.reinitEnter || stack.Peek().reinitExit)) || visualEffectControlPlayableBehaviour.startSeed != stack.Peek().startSeed || visualEffectControlPlayableBehaviour.prewarmStepCount != 0U)
				{
					stack.Push(new VisualEffectControlTrackController.Chunk
					{
						begin = visualEffectControlPlayableBehaviour.clipStart,
						events = new VisualEffectControlTrackController.Event[0],
						clips = new VisualEffectControlTrackController.Clip[0],
						scrubbing = visualEffectControlPlayableBehaviour.scrubbing,
						startSeed = visualEffectControlPlayableBehaviour.startSeed,
						reinitEnter = visualEffectControlPlayableBehaviour.reinitEnter,
						reinitExit = visualEffectControlPlayableBehaviour.reinitExit,
						prewarmCount = visualEffectControlPlayableBehaviour.prewarmStepCount,
						prewarmDeltaTime = visualEffectControlPlayableBehaviour.prewarmDeltaTime,
						prewarmEvent = ((visualEffectControlPlayableBehaviour.prewarmEvent != null) ? visualEffectControlPlayableBehaviour.prewarmEvent : 0),
						prewarmOffset = visualEffectControlPlayableBehaviour.prewarmStepCount * (double)visualEffectControlPlayableBehaviour.prewarmDeltaTime
					});
				}
				VisualEffectControlTrackController.Chunk chunk = stack.Peek();
				chunk.end = visualEffectControlPlayableBehaviour.clipEnd;
				IEnumerable<VisualEffectControlTrackController.Event> enumerable = VisualEffectControlTrackController.ComputeRuntimeEvent(visualEffectControlPlayableBehaviour, vfx);
				if (!chunk.scrubbing)
				{
					var list2 = (from o in enumerable.Select((VisualEffectControlTrackController.Event e, int i) => new
					{
						evt = e,
						sourceIndex = i
					})
					orderby o.evt.time
					select o).ToList();
					VisualEffectControlTrackController.Clip[] array = new VisualEffectControlTrackController.Clip[visualEffectControlPlayableBehaviour.clipEventsCount];
					List<VisualEffectControlTrackController.Event> list3 = new List<VisualEffectControlTrackController.Event>();
					for (int j = 0; j < list2.Count; j++)
					{
						VisualEffectControlTrackController.Event evt = list2[j].evt;
						int sourceIndex = list2[j].sourceIndex;
						if ((long)sourceIndex < (long)((ulong)(visualEffectControlPlayableBehaviour.clipEventsCount * 2U)))
						{
							int num = chunk.events.Length + j;
							int num2 = sourceIndex / 2;
							evt.clipIndex = num2 + chunk.clips.Length;
							if (sourceIndex % 2 == 0)
							{
								evt.clipType = VisualEffectControlTrackController.Event.ClipType.Enter;
								array[num2].enter = num;
							}
							else
							{
								evt.clipType = VisualEffectControlTrackController.Event.ClipType.Exit;
								array[num2].exit = num;
							}
							list3.Add(evt);
						}
						else
						{
							list3.Add(evt);
						}
					}
					chunk.clips = chunk.clips.Concat(array).ToArray<VisualEffectControlTrackController.Clip>();
					chunk.events = chunk.events.Concat(list3).ToArray<VisualEffectControlTrackController.Event>();
				}
				else
				{
					enumerable = from o in enumerable
					orderby o.time
					select o;
					chunk.events = chunk.events.Concat(enumerable).ToArray<VisualEffectControlTrackController.Event>();
				}
				stack.Pop();
				stack.Push(chunk);
			}
			this.m_Chunks = stack.Reverse<VisualEffectControlTrackController.Chunk>().ToArray<VisualEffectControlTrackController.Chunk>();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003AE0 File Offset: 0x00001CE0
		public void Release()
		{
			this.RestoreVFXState(true, true);
		}

		// Token: 0x04000044 RID: 68
		private const int kErrorIndex = -2147483648;

		// Token: 0x04000045 RID: 69
		private int m_LastChunk = int.MinValue;

		// Token: 0x04000046 RID: 70
		private int m_LastEvent = int.MinValue;

		// Token: 0x04000047 RID: 71
		private double m_LastPlayableTime = double.MinValue;

		// Token: 0x04000048 RID: 72
		private List<int> m_EventListIndexCache = new List<int>();

		// Token: 0x04000049 RID: 73
		private VisualEffect m_Target;

		// Token: 0x0400004A RID: 74
		private bool m_BackupReseedOnPlay;

		// Token: 0x0400004B RID: 75
		private uint m_BackupStartSeed;

		// Token: 0x0400004C RID: 76
		private VisualEffectControlTrackController.Chunk[] m_Chunks;

		// Token: 0x02000057 RID: 87
		private struct Event
		{
			// Token: 0x0400016F RID: 367
			public int nameId;

			// Token: 0x04000170 RID: 368
			public VFXEventAttribute attribute;

			// Token: 0x04000171 RID: 369
			public double time;

			// Token: 0x04000172 RID: 370
			public int clipIndex;

			// Token: 0x04000173 RID: 371
			public VisualEffectControlTrackController.Event.ClipType clipType;

			// Token: 0x0200006B RID: 107
			public enum ClipType
			{
				// Token: 0x040001F8 RID: 504
				None,
				// Token: 0x040001F9 RID: 505
				Enter,
				// Token: 0x040001FA RID: 506
				Exit
			}
		}

		// Token: 0x02000058 RID: 88
		private struct Clip
		{
			// Token: 0x04000174 RID: 372
			public int enter;

			// Token: 0x04000175 RID: 373
			public int exit;
		}

		// Token: 0x02000059 RID: 89
		private struct Chunk
		{
			// Token: 0x04000176 RID: 374
			public bool scrubbing;

			// Token: 0x04000177 RID: 375
			public bool reinitEnter;

			// Token: 0x04000178 RID: 376
			public bool reinitExit;

			// Token: 0x04000179 RID: 377
			public uint startSeed;

			// Token: 0x0400017A RID: 378
			public double begin;

			// Token: 0x0400017B RID: 379
			public double end;

			// Token: 0x0400017C RID: 380
			public uint prewarmCount;

			// Token: 0x0400017D RID: 381
			public float prewarmDeltaTime;

			// Token: 0x0400017E RID: 382
			public double prewarmOffset;

			// Token: 0x0400017F RID: 383
			public int prewarmEvent;

			// Token: 0x04000180 RID: 384
			public VisualEffectControlTrackController.Event[] events;

			// Token: 0x04000181 RID: 385
			public VisualEffectControlTrackController.Clip[] clips;
		}

		// Token: 0x0200005A RID: 90
		private class VisualEffectControlPlayableBehaviourComparer : IComparer<VisualEffectControlPlayableBehaviour>
		{
			// Token: 0x060001DA RID: 474 RVA: 0x00009724 File Offset: 0x00007924
			public int Compare(VisualEffectControlPlayableBehaviour x, VisualEffectControlPlayableBehaviour y)
			{
				return x.clipStart.CompareTo(y.clipStart);
			}
		}
	}
}
