using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000052 RID: 82
	public static class EventBus
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000260 RID: 608 RVA: 0x0000604B File Offset: 0x0000424B
		internal static Dictionary<EventHook, HashSet<Delegate>> testAccessEvents
		{
			get
			{
				return EventBus.events;
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00006054 File Offset: 0x00004254
		public static void Register<TArgs>(EventHook hook, Action<TArgs> handler)
		{
			HashSet<Delegate> hashSet;
			if (!EventBus.events.TryGetValue(hook, out hashSet))
			{
				hashSet = new HashSet<Delegate>();
				EventBus.events.Add(hook, hashSet);
			}
			hashSet.Add(handler);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000608C File Offset: 0x0000428C
		public static void Unregister(EventHook hook, Delegate handler)
		{
			HashSet<Delegate> hashSet;
			if (EventBus.events.TryGetValue(hook, out hashSet) && hashSet.Remove(handler) && hashSet.Count == 0)
			{
				EventBus.events.Remove(hook);
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000060C8 File Offset: 0x000042C8
		public static void Trigger<TArgs>(EventHook hook, TArgs args)
		{
			HashSet<Action<TArgs>> hashSet = null;
			HashSet<Delegate> hashSet2;
			if (EventBus.events.TryGetValue(hook, out hashSet2))
			{
				foreach (Delegate @delegate in hashSet2)
				{
					Action<TArgs> action = @delegate as Action<TArgs>;
					if (action != null)
					{
						if (hashSet == null)
						{
							hashSet = HashSetPool<Action<TArgs>>.New();
						}
						hashSet.Add(action);
					}
				}
			}
			if (hashSet != null)
			{
				foreach (Action<TArgs> action2 in hashSet)
				{
					if (hashSet2.Contains(action2))
					{
						action2(args);
					}
				}
				hashSet.Free<Action<TArgs>>();
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000618C File Offset: 0x0000438C
		public static void Trigger<TArgs>(string name, GameObject target, TArgs args)
		{
			EventBus.Trigger<TArgs>(new EventHook(name, target, null), args);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000619C File Offset: 0x0000439C
		public static void Trigger(EventHook hook)
		{
			EventBus.Trigger<EmptyEventArgs>(hook, default(EmptyEventArgs));
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000061B8 File Offset: 0x000043B8
		public static void Trigger(string name, GameObject target)
		{
			EventBus.Trigger(new EventHook(name, target, null));
		}

		// Token: 0x0400006F RID: 111
		private static readonly Dictionary<EventHook, HashSet<Delegate>> events = new Dictionary<EventHook, HashSet<Delegate>>(new EventHookComparer());
	}
}
