using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x020001B5 RID: 437
	internal class EventDebugger
	{
		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x00033B07 File Offset: 0x00031D07
		// (set) Token: 0x06000D46 RID: 3398 RVA: 0x00033B0F File Offset: 0x00031D0F
		public IPanel panel { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00033B18 File Offset: 0x00031D18
		// (set) Token: 0x06000D48 RID: 3400 RVA: 0x00033B20 File Offset: 0x00031D20
		public bool isReplaying { get; private set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00033B29 File Offset: 0x00031D29
		// (set) Token: 0x06000D4A RID: 3402 RVA: 0x00033B31 File Offset: 0x00031D31
		public float playbackSpeed { get; set; } = 1f;

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x00033B3A File Offset: 0x00031D3A
		// (set) Token: 0x06000D4C RID: 3404 RVA: 0x00033B42 File Offset: 0x00031D42
		public bool isPlaybackPaused { get; set; }

		// Token: 0x06000D4D RID: 3405 RVA: 0x00033B4C File Offset: 0x00031D4C
		public void UpdateModificationCount()
		{
			bool flag = this.panel == null;
			if (!flag)
			{
				long num;
				bool flag2 = !this.m_ModificationCount.TryGetValue(this.panel, out num);
				if (flag2)
				{
					num = 0L;
				}
				num += 1L;
				this.m_ModificationCount[this.panel] = num;
			}
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00033BA0 File Offset: 0x00031DA0
		public void BeginProcessEvent(EventBase evt, IEventHandler mouseCapture)
		{
			this.AddBeginProcessEvent(evt, mouseCapture);
			this.UpdateModificationCount();
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00033BB3 File Offset: 0x00031DB3
		public void EndProcessEvent(EventBase evt, long duration, IEventHandler mouseCapture)
		{
			this.AddEndProcessEvent(evt, duration, mouseCapture);
			this.UpdateModificationCount();
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00033BC8 File Offset: 0x00031DC8
		public void LogCall(int cbHashCode, string cbName, EventBase evt, bool propagationHasStopped, bool immediatePropagationHasStopped, bool defaultHasBeenPrevented, long duration, IEventHandler mouseCapture)
		{
			this.AddCallObject(cbHashCode, cbName, evt, propagationHasStopped, immediatePropagationHasStopped, defaultHasBeenPrevented, duration, mouseCapture);
			this.UpdateModificationCount();
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x00033BF1 File Offset: 0x00031DF1
		public void LogIMGUICall(EventBase evt, long duration, IEventHandler mouseCapture)
		{
			this.AddIMGUICall(evt, duration, mouseCapture);
			this.UpdateModificationCount();
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x00033C05 File Offset: 0x00031E05
		public void LogExecuteDefaultAction(EventBase evt, PropagationPhase phase, long duration, IEventHandler mouseCapture)
		{
			this.AddExecuteDefaultAction(evt, phase, duration, mouseCapture);
			this.UpdateModificationCount();
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public static void LogPropagationPaths(EventBase evt, PropagationPaths paths)
		{
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00033C1C File Offset: 0x00031E1C
		private void LogPropagationPathsInternal(EventBase evt, PropagationPaths paths)
		{
			PropagationPaths paths2 = (paths == null) ? new PropagationPaths() : new PropagationPaths(paths);
			this.AddPropagationPaths(evt, paths2);
			this.UpdateModificationCount();
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00033C4C File Offset: 0x00031E4C
		public List<EventDebuggerCallTrace> GetCalls(IPanel panel, EventDebuggerEventRecord evt = null)
		{
			List<EventDebuggerCallTrace> list;
			bool flag = !this.m_EventCalledObjects.TryGetValue(panel, out list);
			List<EventDebuggerCallTrace> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = evt != null && list != null;
				if (flag2)
				{
					List<EventDebuggerCallTrace> list2 = new List<EventDebuggerCallTrace>();
					foreach (EventDebuggerCallTrace eventDebuggerCallTrace in list)
					{
						bool flag3 = eventDebuggerCallTrace.eventBase.eventId == evt.eventId;
						if (flag3)
						{
							list2.Add(eventDebuggerCallTrace);
						}
					}
					list = list2;
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x00033CFC File Offset: 0x00031EFC
		public List<EventDebuggerDefaultActionTrace> GetDefaultActions(IPanel panel, EventDebuggerEventRecord evt = null)
		{
			List<EventDebuggerDefaultActionTrace> list;
			bool flag = !this.m_EventDefaultActionObjects.TryGetValue(panel, out list);
			List<EventDebuggerDefaultActionTrace> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = evt != null && list != null;
				if (flag2)
				{
					List<EventDebuggerDefaultActionTrace> list2 = new List<EventDebuggerDefaultActionTrace>();
					foreach (EventDebuggerDefaultActionTrace eventDebuggerDefaultActionTrace in list)
					{
						bool flag3 = eventDebuggerDefaultActionTrace.eventBase.eventId == evt.eventId;
						if (flag3)
						{
							list2.Add(eventDebuggerDefaultActionTrace);
						}
					}
					list = list2;
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x00033DAC File Offset: 0x00031FAC
		public List<EventDebuggerPathTrace> GetPropagationPaths(IPanel panel, EventDebuggerEventRecord evt = null)
		{
			List<EventDebuggerPathTrace> list;
			bool flag = !this.m_EventPathObjects.TryGetValue(panel, out list);
			List<EventDebuggerPathTrace> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = evt != null && list != null;
				if (flag2)
				{
					List<EventDebuggerPathTrace> list2 = new List<EventDebuggerPathTrace>();
					foreach (EventDebuggerPathTrace eventDebuggerPathTrace in list)
					{
						bool flag3 = eventDebuggerPathTrace.eventBase.eventId == evt.eventId;
						if (flag3)
						{
							list2.Add(eventDebuggerPathTrace);
						}
					}
					list = list2;
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x00033E5C File Offset: 0x0003205C
		public List<EventDebuggerTrace> GetBeginEndProcessedEvents(IPanel panel, EventDebuggerEventRecord evt = null)
		{
			List<EventDebuggerTrace> list;
			bool flag = !this.m_EventProcessedEvents.TryGetValue(panel, out list);
			List<EventDebuggerTrace> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = evt != null && list != null;
				if (flag2)
				{
					List<EventDebuggerTrace> list2 = new List<EventDebuggerTrace>();
					foreach (EventDebuggerTrace eventDebuggerTrace in list)
					{
						bool flag3 = eventDebuggerTrace.eventBase.eventId == evt.eventId;
						if (flag3)
						{
							list2.Add(eventDebuggerTrace);
						}
					}
					list = list2;
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x00033F0C File Offset: 0x0003210C
		public long GetModificationCount(IPanel panel)
		{
			bool flag = panel == null;
			long result;
			if (flag)
			{
				result = -1L;
			}
			else
			{
				long num;
				bool flag2 = !this.m_ModificationCount.TryGetValue(panel, out num);
				if (flag2)
				{
					num = -1L;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x00033F48 File Offset: 0x00032148
		public void ClearLogs()
		{
			this.UpdateModificationCount();
			bool flag = this.panel == null;
			if (flag)
			{
				this.m_EventCalledObjects.Clear();
				this.m_EventDefaultActionObjects.Clear();
				this.m_EventPathObjects.Clear();
				this.m_EventProcessedEvents.Clear();
				this.m_StackOfProcessedEvent.Clear();
				this.m_EventTypeProcessedCount.Clear();
			}
			else
			{
				this.m_EventCalledObjects.Remove(this.panel);
				this.m_EventDefaultActionObjects.Remove(this.panel);
				this.m_EventPathObjects.Remove(this.panel);
				this.m_EventProcessedEvents.Remove(this.panel);
				this.m_StackOfProcessedEvent.Remove(this.panel);
				Dictionary<long, int> dictionary;
				bool flag2 = this.m_EventTypeProcessedCount.TryGetValue(this.panel, out dictionary);
				if (flag2)
				{
					dictionary.Clear();
				}
			}
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x00034030 File Offset: 0x00032230
		public void SaveReplaySessionFromSelection(string path, List<EventDebuggerEventRecord> eventList)
		{
			bool flag = string.IsNullOrEmpty(path);
			if (!flag)
			{
				EventDebuggerRecordList obj = new EventDebuggerRecordList
				{
					eventList = eventList
				};
				string contents = JsonUtility.ToJson(obj);
				File.WriteAllText(path, contents);
				Debug.Log("Saved under: " + path);
			}
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x00034078 File Offset: 0x00032278
		public EventDebuggerRecordList LoadReplaySession(string path)
		{
			bool flag = string.IsNullOrEmpty(path);
			EventDebuggerRecordList result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string json = File.ReadAllText(path);
				result = JsonUtility.FromJson<EventDebuggerRecordList>(json);
			}
			return result;
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x000340A5 File Offset: 0x000322A5
		public IEnumerator ReplayEvents(IEnumerable<EventDebuggerEventRecord> eventBases, Action<int, int> refreshList)
		{
			bool flag = eventBases == null;
			if (flag)
			{
				yield break;
			}
			this.isReplaying = true;
			IEnumerator doReplay = this.DoReplayEvents(eventBases, refreshList);
			while (doReplay.MoveNext())
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x000340C2 File Offset: 0x000322C2
		public void StopPlayback()
		{
			this.isReplaying = false;
			this.isPlaybackPaused = false;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x000340D5 File Offset: 0x000322D5
		private IEnumerator DoReplayEvents(IEnumerable<EventDebuggerEventRecord> eventBases, Action<int, int> refreshList)
		{
			EventDebugger.<>c__DisplayClass34_0 CS$<>8__locals1 = new EventDebugger.<>c__DisplayClass34_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.sortedEvents = (from e in eventBases
			orderby e.timestamp
			select e).ToList<EventDebuggerEventRecord>();
			int sortedEventsCount = CS$<>8__locals1.sortedEvents.Count;
			int i = 0;
			while (i < sortedEventsCount)
			{
				bool flag = !this.isReplaying;
				if (flag)
				{
					break;
				}
				EventDebuggerEventRecord eventBase = CS$<>8__locals1.sortedEvents[i];
				Event newEvent = new Event
				{
					button = eventBase.button,
					clickCount = eventBase.clickCount,
					modifiers = eventBase.modifiers,
					mousePosition = eventBase.mousePosition
				};
				bool flag2 = eventBase.eventTypeId == EventBase<MouseMoveEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag2)
				{
					newEvent.type = EventType.MouseMove;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseMove), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag3 = eventBase.eventTypeId == EventBase<MouseDownEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag3)
				{
					newEvent.type = EventType.MouseDown;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseDown), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag4 = eventBase.eventTypeId == EventBase<MouseUpEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag4)
				{
					newEvent.type = EventType.MouseUp;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseUp), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag5 = eventBase.eventTypeId == EventBase<ContextClickEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag5)
				{
					newEvent.type = EventType.ContextClick;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.ContextClick), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag6 = eventBase.eventTypeId == EventBase<MouseEnterWindowEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag6)
				{
					newEvent.type = EventType.MouseEnterWindow;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseEnterWindow), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag7 = eventBase.eventTypeId == EventBase<MouseLeaveWindowEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag7)
				{
					newEvent.type = EventType.MouseLeaveWindow;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseLeaveWindow), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag8 = eventBase.eventTypeId == EventBase<PointerMoveEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag8)
				{
					newEvent.type = EventType.MouseMove;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseMove), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag9 = eventBase.eventTypeId == EventBase<PointerDownEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag9)
				{
					newEvent.type = EventType.MouseDown;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseDown), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag10 = eventBase.eventTypeId == EventBase<PointerUpEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag10)
				{
					newEvent.type = EventType.MouseUp;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.MouseUp), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag11 = eventBase.eventTypeId == EventBase<WheelEvent>.TypeId() && eventBase.hasUnderlyingPhysicalEvent;
				if (flag11)
				{
					newEvent.type = EventType.ScrollWheel;
					newEvent.delta = eventBase.delta;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.ScrollWheel), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag12 = eventBase.eventTypeId == EventBase<KeyDownEvent>.TypeId();
				if (flag12)
				{
					newEvent.type = EventType.KeyDown;
					newEvent.character = eventBase.character;
					newEvent.keyCode = eventBase.keyCode;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.KeyDown), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag13 = eventBase.eventTypeId == EventBase<KeyUpEvent>.TypeId();
				if (flag13)
				{
					newEvent.type = EventType.KeyUp;
					newEvent.character = eventBase.character;
					newEvent.keyCode = eventBase.keyCode;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.KeyUp), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag14 = eventBase.eventTypeId == EventBase<NavigationMoveEvent>.TypeId();
				if (flag14)
				{
					this.panel.dispatcher.Dispatch(NavigationMoveEvent.GetPooled(eventBase.navigationDirection, eventBase.deviceType, eventBase.modifiers), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag15 = eventBase.eventTypeId == EventBase<NavigationSubmitEvent>.TypeId();
				if (flag15)
				{
					this.panel.dispatcher.Dispatch(NavigationEventBase<NavigationSubmitEvent>.GetPooled(eventBase.deviceType, eventBase.modifiers), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag16 = eventBase.eventTypeId == EventBase<NavigationCancelEvent>.TypeId();
				if (flag16)
				{
					this.panel.dispatcher.Dispatch(NavigationEventBase<NavigationCancelEvent>.GetPooled(eventBase.deviceType, eventBase.modifiers), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag17 = eventBase.eventTypeId == EventBase<ValidateCommandEvent>.TypeId();
				if (flag17)
				{
					newEvent.type = EventType.ValidateCommand;
					newEvent.commandName = eventBase.commandName;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.ValidateCommand), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag18 = eventBase.eventTypeId == EventBase<ExecuteCommandEvent>.TypeId();
				if (flag18)
				{
					newEvent.type = EventType.ExecuteCommand;
					newEvent.commandName = eventBase.commandName;
					this.panel.dispatcher.Dispatch(UIElementsUtility.CreateEvent(newEvent, EventType.ExecuteCommand), this.panel, DispatchMode.Default);
					goto IL_987;
				}
				bool flag19 = eventBase.eventTypeId == EventBase<IMGUIEvent>.TypeId();
				if (flag19)
				{
					string str = "Skipped IMGUI event (";
					string eventBaseName = eventBase.eventBaseName;
					string str2 = "): ";
					EventDebuggerEventRecord eventDebuggerEventRecord = eventBase;
					Debug.Log(str + eventBaseName + str2 + ((eventDebuggerEventRecord != null) ? eventDebuggerEventRecord.ToString() : null));
					IEnumerator awaitSkipped = CS$<>8__locals1.<DoReplayEvents>g__AwaitForNextEvent|1(i);
					while (awaitSkipped.MoveNext())
					{
						yield return null;
					}
				}
				else
				{
					string str3 = "Skipped event (";
					string eventBaseName2 = eventBase.eventBaseName;
					string str4 = "): ";
					EventDebuggerEventRecord eventDebuggerEventRecord2 = eventBase;
					Debug.Log(str3 + eventBaseName2 + str4 + ((eventDebuggerEventRecord2 != null) ? eventDebuggerEventRecord2.ToString() : null));
					IEnumerator awaitSkipped2 = CS$<>8__locals1.<DoReplayEvents>g__AwaitForNextEvent|1(i);
					while (awaitSkipped2.MoveNext())
					{
						yield return null;
					}
				}
				IL_A31:
				int num = i;
				i = num + 1;
				continue;
				IL_987:
				if (refreshList != null)
				{
					refreshList(i, sortedEventsCount);
				}
				Debug.Log(string.Format("Replayed event {0} ({1}): {2}", eventBase.eventId.ToString(), eventBase.eventBaseName, newEvent));
				IEnumerator await = CS$<>8__locals1.<DoReplayEvents>g__AwaitForNextEvent|1(i);
				while (await.MoveNext())
				{
					yield return null;
				}
				eventBase = null;
				newEvent = null;
				await = null;
				goto IL_A31;
			}
			this.isReplaying = false;
			yield break;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x000340F4 File Offset: 0x000322F4
		public Dictionary<string, EventDebugger.HistogramRecord> ComputeHistogram(List<EventDebuggerEventRecord> eventBases)
		{
			List<EventDebuggerTrace> list;
			bool flag = this.panel == null || !this.m_EventProcessedEvents.TryGetValue(this.panel, out list);
			Dictionary<string, EventDebugger.HistogramRecord> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = list == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					Dictionary<string, EventDebugger.HistogramRecord> dictionary = new Dictionary<string, EventDebugger.HistogramRecord>();
					foreach (EventDebuggerTrace eventDebuggerTrace in list)
					{
						bool flag3 = eventBases == null || eventBases.Count == 0 || eventBases.Contains(eventDebuggerTrace.eventBase);
						if (flag3)
						{
							string eventBaseName = eventDebuggerTrace.eventBase.eventBaseName;
							long num = eventDebuggerTrace.duration;
							long num2 = 1L;
							EventDebugger.HistogramRecord histogramRecord;
							bool flag4 = dictionary.TryGetValue(eventBaseName, out histogramRecord);
							if (flag4)
							{
								num += histogramRecord.duration;
								num2 += histogramRecord.count;
							}
							dictionary[eventBaseName] = new EventDebugger.HistogramRecord
							{
								count = num2,
								duration = num
							};
						}
					}
					result = dictionary;
				}
			}
			return result;
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x00034220 File Offset: 0x00032420
		public Dictionary<long, int> eventTypeProcessedCount
		{
			get
			{
				Dictionary<long, int> dictionary;
				return this.m_EventTypeProcessedCount.TryGetValue(this.panel, out dictionary) ? dictionary : null;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x00034246 File Offset: 0x00032446
		// (set) Token: 0x06000D63 RID: 3427 RVA: 0x0003424E File Offset: 0x0003244E
		public bool suspended { get; set; }

		// Token: 0x06000D64 RID: 3428 RVA: 0x00034258 File Offset: 0x00032458
		public EventDebugger()
		{
			this.m_EventCalledObjects = new Dictionary<IPanel, List<EventDebuggerCallTrace>>();
			this.m_EventDefaultActionObjects = new Dictionary<IPanel, List<EventDebuggerDefaultActionTrace>>();
			this.m_EventPathObjects = new Dictionary<IPanel, List<EventDebuggerPathTrace>>();
			this.m_StackOfProcessedEvent = new Dictionary<IPanel, Stack<EventDebuggerTrace>>();
			this.m_EventProcessedEvents = new Dictionary<IPanel, List<EventDebuggerTrace>>();
			this.m_EventTypeProcessedCount = new Dictionary<IPanel, Dictionary<long, int>>();
			this.m_ModificationCount = new Dictionary<IPanel, long>();
			this.m_Log = true;
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x000342CC File Offset: 0x000324CC
		private void AddCallObject(int cbHashCode, string cbName, EventBase evt, bool propagationHasStopped, bool immediatePropagationHasStopped, bool defaultHasBeenPrevented, long duration, IEventHandler mouseCapture)
		{
			bool suspended = this.suspended;
			if (!suspended)
			{
				bool log = this.m_Log;
				if (log)
				{
					EventDebuggerCallTrace item = new EventDebuggerCallTrace(this.panel, evt, cbHashCode, cbName, propagationHasStopped, immediatePropagationHasStopped, defaultHasBeenPrevented, duration, mouseCapture);
					List<EventDebuggerCallTrace> list;
					bool flag = !this.m_EventCalledObjects.TryGetValue(this.panel, out list);
					if (flag)
					{
						list = new List<EventDebuggerCallTrace>();
						this.m_EventCalledObjects.Add(this.panel, list);
					}
					list.Add(item);
				}
			}
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x0003434C File Offset: 0x0003254C
		private void AddExecuteDefaultAction(EventBase evt, PropagationPhase phase, long duration, IEventHandler mouseCapture)
		{
			bool suspended = this.suspended;
			if (!suspended)
			{
				bool log = this.m_Log;
				if (log)
				{
					EventDebuggerDefaultActionTrace item = new EventDebuggerDefaultActionTrace(this.panel, evt, phase, duration, mouseCapture);
					List<EventDebuggerDefaultActionTrace> list;
					bool flag = !this.m_EventDefaultActionObjects.TryGetValue(this.panel, out list);
					if (flag)
					{
						list = new List<EventDebuggerDefaultActionTrace>();
						this.m_EventDefaultActionObjects.Add(this.panel, list);
					}
					list.Add(item);
				}
			}
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x000343C4 File Offset: 0x000325C4
		private void AddPropagationPaths(EventBase evt, PropagationPaths paths)
		{
			bool suspended = this.suspended;
			if (!suspended)
			{
				bool log = this.m_Log;
				if (log)
				{
					EventDebuggerPathTrace item = new EventDebuggerPathTrace(this.panel, evt, paths);
					List<EventDebuggerPathTrace> list;
					bool flag = !this.m_EventPathObjects.TryGetValue(this.panel, out list);
					if (flag)
					{
						list = new List<EventDebuggerPathTrace>();
						this.m_EventPathObjects.Add(this.panel, list);
					}
					list.Add(item);
				}
			}
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00034438 File Offset: 0x00032638
		private void AddIMGUICall(EventBase evt, long duration, IEventHandler mouseCapture)
		{
			bool suspended = this.suspended;
			if (!suspended)
			{
				bool log = this.m_Log;
				if (log)
				{
					EventDebuggerCallTrace item = new EventDebuggerCallTrace(this.panel, evt, 0, "OnGUI", false, false, false, duration, mouseCapture);
					List<EventDebuggerCallTrace> list;
					bool flag = !this.m_EventCalledObjects.TryGetValue(this.panel, out list);
					if (flag)
					{
						list = new List<EventDebuggerCallTrace>();
						this.m_EventCalledObjects.Add(this.panel, list);
					}
					list.Add(item);
				}
			}
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x000344B8 File Offset: 0x000326B8
		private void AddBeginProcessEvent(EventBase evt, IEventHandler mouseCapture)
		{
			bool suspended = this.suspended;
			if (!suspended)
			{
				EventDebuggerTrace eventDebuggerTrace = new EventDebuggerTrace(this.panel, evt, -1L, mouseCapture);
				Stack<EventDebuggerTrace> stack;
				bool flag = !this.m_StackOfProcessedEvent.TryGetValue(this.panel, out stack);
				if (flag)
				{
					stack = new Stack<EventDebuggerTrace>();
					this.m_StackOfProcessedEvent.Add(this.panel, stack);
				}
				List<EventDebuggerTrace> list;
				bool flag2 = !this.m_EventProcessedEvents.TryGetValue(this.panel, out list);
				if (flag2)
				{
					list = new List<EventDebuggerTrace>();
					this.m_EventProcessedEvents.Add(this.panel, list);
				}
				list.Add(eventDebuggerTrace);
				stack.Push(eventDebuggerTrace);
				Dictionary<long, int> dictionary;
				bool flag3 = !this.m_EventTypeProcessedCount.TryGetValue(this.panel, out dictionary);
				if (!flag3)
				{
					int num;
					bool flag4 = !dictionary.TryGetValue(eventDebuggerTrace.eventBase.eventTypeId, out num);
					if (flag4)
					{
						num = 0;
					}
					dictionary[eventDebuggerTrace.eventBase.eventTypeId] = num + 1;
				}
			}
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x000345B8 File Offset: 0x000327B8
		private void AddEndProcessEvent(EventBase evt, long duration, IEventHandler mouseCapture)
		{
			bool suspended = this.suspended;
			if (!suspended)
			{
				bool flag = false;
				Stack<EventDebuggerTrace> stack;
				bool flag2 = this.m_StackOfProcessedEvent.TryGetValue(this.panel, out stack);
				if (flag2)
				{
					bool flag3 = stack.Count > 0;
					if (flag3)
					{
						EventDebuggerTrace eventDebuggerTrace = stack.Peek();
						bool flag4 = eventDebuggerTrace.eventBase.eventId == evt.eventId;
						if (flag4)
						{
							stack.Pop();
							eventDebuggerTrace.duration = duration;
							bool flag5 = eventDebuggerTrace.eventBase.target == null;
							if (flag5)
							{
								eventDebuggerTrace.eventBase.target = evt.target;
							}
							flag = true;
						}
					}
				}
				bool flag6 = !flag;
				if (flag6)
				{
					EventDebuggerTrace eventDebuggerTrace2 = new EventDebuggerTrace(this.panel, evt, duration, mouseCapture);
					List<EventDebuggerTrace> list;
					bool flag7 = !this.m_EventProcessedEvents.TryGetValue(this.panel, out list);
					if (flag7)
					{
						list = new List<EventDebuggerTrace>();
						this.m_EventProcessedEvents.Add(this.panel, list);
					}
					list.Add(eventDebuggerTrace2);
					Dictionary<long, int> dictionary;
					bool flag8 = !this.m_EventTypeProcessedCount.TryGetValue(this.panel, out dictionary);
					if (!flag8)
					{
						int num;
						bool flag9 = !dictionary.TryGetValue(eventDebuggerTrace2.eventBase.eventTypeId, out num);
						if (flag9)
						{
							num = 0;
						}
						dictionary[eventDebuggerTrace2.eventBase.eventTypeId] = num + 1;
					}
				}
			}
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x0003471C File Offset: 0x0003291C
		public static string GetObjectDisplayName(object obj, bool withHashCode = true)
		{
			bool flag = obj == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				Type type = obj.GetType();
				string text = EventDebugger.GetTypeDisplayName(type);
				bool flag2 = obj is VisualElement;
				if (flag2)
				{
					VisualElement visualElement = obj as VisualElement;
					bool flag3 = !string.IsNullOrEmpty(visualElement.name);
					if (flag3)
					{
						text = text + "#" + visualElement.name;
					}
				}
				if (withHashCode)
				{
					text = text + " (" + obj.GetHashCode().ToString("x8") + ")";
				}
				result = text;
			}
			return result;
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x000347C4 File Offset: 0x000329C4
		public static string GetTypeDisplayName(Type type)
		{
			return type.IsGenericType ? (type.Name.TrimEnd(new char[]
			{
				'`',
				'1'
			}) + "<" + type.GetGenericArguments()[0].Name + ">") : type.Name;
		}

		// Token: 0x04000645 RID: 1605
		private Dictionary<IPanel, List<EventDebuggerCallTrace>> m_EventCalledObjects;

		// Token: 0x04000646 RID: 1606
		private Dictionary<IPanel, List<EventDebuggerDefaultActionTrace>> m_EventDefaultActionObjects;

		// Token: 0x04000647 RID: 1607
		private Dictionary<IPanel, List<EventDebuggerPathTrace>> m_EventPathObjects;

		// Token: 0x04000648 RID: 1608
		private Dictionary<IPanel, List<EventDebuggerTrace>> m_EventProcessedEvents;

		// Token: 0x04000649 RID: 1609
		private Dictionary<IPanel, Stack<EventDebuggerTrace>> m_StackOfProcessedEvent;

		// Token: 0x0400064A RID: 1610
		private Dictionary<IPanel, Dictionary<long, int>> m_EventTypeProcessedCount;

		// Token: 0x0400064B RID: 1611
		private readonly Dictionary<IPanel, long> m_ModificationCount;

		// Token: 0x0400064C RID: 1612
		private readonly bool m_Log;

		// Token: 0x020001B6 RID: 438
		internal struct HistogramRecord
		{
			// Token: 0x0400064E RID: 1614
			public long count;

			// Token: 0x0400064F RID: 1615
			public long duration;
		}
	}
}
