using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnityEngine.UIElements
{
	// Token: 0x020003F9 RID: 1017
	internal static class EventInterestReflectionUtils
	{
		// Token: 0x060020D5 RID: 8405 RVA: 0x0007C238 File Offset: 0x0007A438
		internal static void GetDefaultEventInterests(Type elementType, out int defaultActionCategories, out int defaultActionAtTargetCategories)
		{
			EventInterestReflectionUtils.DefaultEventInterests defaultEventInterests;
			bool flag = !EventInterestReflectionUtils.s_DefaultEventInterests.TryGetValue(elementType, out defaultEventInterests);
			if (flag)
			{
				Type baseType = elementType.BaseType;
				bool flag2 = baseType != null;
				if (flag2)
				{
					EventInterestReflectionUtils.GetDefaultEventInterests(baseType, out defaultEventInterests.DefaultActionCategories, out defaultEventInterests.DefaultActionAtTargetCategories);
				}
				defaultEventInterests.DefaultActionCategories |= (EventInterestReflectionUtils.ComputeDefaultEventInterests(elementType, "ExecuteDefaultAction") | EventInterestReflectionUtils.ComputeDefaultEventInterests(elementType, "ExecuteDefaultActionDisabled"));
				defaultEventInterests.DefaultActionAtTargetCategories |= (EventInterestReflectionUtils.ComputeDefaultEventInterests(elementType, "ExecuteDefaultActionAtTarget") | EventInterestReflectionUtils.ComputeDefaultEventInterests(elementType, "ExecuteDefaultActionDisabledAtTarget"));
				EventInterestReflectionUtils.s_DefaultEventInterests.Add(elementType, defaultEventInterests);
			}
			defaultActionCategories = defaultEventInterests.DefaultActionCategories;
			defaultActionAtTargetCategories = defaultEventInterests.DefaultActionAtTargetCategories;
		}

		// Token: 0x060020D6 RID: 8406 RVA: 0x0007C2E8 File Offset: 0x0007A4E8
		private static int ComputeDefaultEventInterests(Type elementType, string methodName)
		{
			MethodInfo method = elementType.GetMethod(methodName, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			bool flag = method == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = false;
				int num = 0;
				object[] customAttributes = method.GetCustomAttributes(typeof(EventInterestAttribute), false);
				foreach (EventInterestAttribute eventInterestAttribute in customAttributes)
				{
					flag2 = true;
					bool flag3 = eventInterestAttribute.eventTypes != null;
					if (flag3)
					{
						foreach (Type eventType in eventInterestAttribute.eventTypes)
						{
							num |= 1 << (int)EventInterestReflectionUtils.GetEventCategory(eventType);
						}
					}
					num |= (int)eventInterestAttribute.categoryFlags;
				}
				result = (flag2 ? num : -1);
			}
			return result;
		}

		// Token: 0x060020D7 RID: 8407 RVA: 0x0007C3B0 File Offset: 0x0007A5B0
		internal static EventCategory GetEventCategory(Type eventType)
		{
			EventCategory category;
			bool flag = EventInterestReflectionUtils.s_EventCategories.TryGetValue(eventType, out category);
			EventCategory result;
			if (flag)
			{
				result = category;
			}
			else
			{
				object[] customAttributes = eventType.GetCustomAttributes(typeof(EventCategoryAttribute), true);
				object[] array = customAttributes;
				int num = 0;
				if (num >= array.Length)
				{
					throw new ArgumentOutOfRangeException("eventType", "Type must derive from EventBase<T>");
				}
				EventCategoryAttribute eventCategoryAttribute = (EventCategoryAttribute)array[num];
				category = eventCategoryAttribute.category;
				EventInterestReflectionUtils.s_EventCategories.Add(eventType, category);
				result = category;
			}
			return result;
		}

		// Token: 0x04000DC3 RID: 3523
		private static readonly Dictionary<Type, EventInterestReflectionUtils.DefaultEventInterests> s_DefaultEventInterests = new Dictionary<Type, EventInterestReflectionUtils.DefaultEventInterests>();

		// Token: 0x04000DC4 RID: 3524
		private static readonly Dictionary<Type, EventCategory> s_EventCategories = new Dictionary<Type, EventCategory>();

		// Token: 0x020003FA RID: 1018
		private struct DefaultEventInterests
		{
			// Token: 0x04000DC5 RID: 3525
			public int DefaultActionCategories;

			// Token: 0x04000DC6 RID: 3526
			public int DefaultActionAtTargetCategories;
		}
	}
}
