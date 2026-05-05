using System;
using Unity.Multiplayer.Tools.Common;
using Unity.Multiplayer.Tools.MetricTypes;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000004 RID: 4
	internal static class MetricTypeExtensions
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		internal static string GetDisplayNameString(string metricType)
		{
			return StringUtil.AddSpacesToCamelCase(metricType);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		internal static string GetDisplayNameString(this MetricType metricType)
		{
			return MetricTypeExtensions.GetDisplayNameString(metricType.ToString());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020DC File Offset: 0x000002DC
		internal static string GetTypeNameString(string metricType)
		{
			return metricType.ToLowerInvariant();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020E4 File Offset: 0x000002E4
		internal static string GetTypeNameString(this MetricType metricType)
		{
			return MetricTypeExtensions.GetTypeNameString(metricType.ToString());
		}
	}
}
