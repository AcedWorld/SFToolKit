using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200000E RID: 14
	internal class EventMetricFactory : IMetricFactory
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002949 File Offset: 0x00000B49
		public static bool TryGetFactoryTypeName(Type type, out FixedString128Bytes typeName)
		{
			return EventMetricFactory.k_TypeNames.TryGetValue(type, out typeName);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002957 File Offset: 0x00000B57
		static EventMetricFactory()
		{
			TypeRegistration.RunIfNeeded();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002974 File Offset: 0x00000B74
		internal static void RegisterType<[IsUnmanaged] T>() where T : struct, ValueType
		{
			if (EventMetricFactory.k_TypeNames.ContainsKey(typeof(T)))
			{
				return;
			}
			FixedString128Bytes fixedString128Bytes = typeof(T).FullName;
			EventMetricFactory.k_FactoriesByName.Add(fixedString128Bytes, new EventMetricFactory.EventMetricFactoryImpl<T>());
			EventMetricFactory.k_TypeNames.Add(typeof(T), fixedString128Bytes);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000029D4 File Offset: 0x00000BD4
		public bool TryConstruct(MetricHeader header, out IMetric metric)
		{
			EventMetricFactory.IEventMetricFactory eventMetricFactory;
			if (!EventMetricFactory.k_FactoriesByName.TryGetValue(header.EventFactoryTypeName, out eventMetricFactory))
			{
				Debug.LogError("Failed to find factory for event type " + header.EventFactoryTypeName.ToString());
				metric = null;
				return false;
			}
			metric = eventMetricFactory.Construct(header.MetricId);
			return true;
		}

		// Token: 0x0400001C RID: 28
		private static readonly Dictionary<FixedString128Bytes, EventMetricFactory.IEventMetricFactory> k_FactoriesByName = new Dictionary<FixedString128Bytes, EventMetricFactory.IEventMetricFactory>();

		// Token: 0x0400001D RID: 29
		private static readonly Dictionary<Type, FixedString128Bytes> k_TypeNames = new Dictionary<Type, FixedString128Bytes>();

		// Token: 0x02000040 RID: 64
		private interface IEventMetricFactory
		{
			// Token: 0x06000168 RID: 360
			IMetric Construct(MetricId id);
		}

		// Token: 0x02000041 RID: 65
		private class EventMetricFactoryImpl<[IsUnmanaged] T> : EventMetricFactory.IEventMetricFactory where T : struct, ValueType
		{
			// Token: 0x06000169 RID: 361 RVA: 0x000053DC File Offset: 0x000035DC
			public IMetric Construct(MetricId id)
			{
				return new EventMetric<T>(id);
			}
		}
	}
}
