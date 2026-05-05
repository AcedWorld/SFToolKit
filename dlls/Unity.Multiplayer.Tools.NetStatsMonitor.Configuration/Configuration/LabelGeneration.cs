using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;

namespace Unity.Multiplayer.Tools.NetStatsMonitor.Configuration
{
	// Token: 0x02000014 RID: 20
	internal static class LabelGeneration
	{
		// Token: 0x06000059 RID: 89 RVA: 0x00002AF8 File Offset: 0x00000CF8
		public static ValueTuple<string, NetworkDirection> SeparateDirectionFromName(string name)
		{
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			NetworkDirection networkDirection = NetworkDirection.None;
			string text = name;
			int num = text.IndexOf("sent", comparisonType);
			if (num > 0)
			{
				networkDirection |= NetworkDirection.Sent;
				text = text.Remove(num, "sent".Length);
			}
			int num2 = text.IndexOf("received", comparisonType);
			if (num2 > 0)
			{
				networkDirection |= NetworkDirection.Received;
				text = text.Remove(num2, "received".Length);
			}
			text = text.Trim();
			return new ValueTuple<string, NetworkDirection>(text, networkDirection);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002B6C File Offset: 0x00000D6C
		public static string GenerateLabel(List<MetricId> stats)
		{
			switch (stats.Count)
			{
			case 0:
				return "";
			case 1:
				return stats[0].DisplayName;
			case 2:
			{
				string displayName = stats[0].DisplayName;
				string displayName2 = stats[1].DisplayName;
				if (displayName == displayName2)
				{
					return "2 × " + displayName;
				}
				ValueTuple<string, NetworkDirection> valueTuple = LabelGeneration.SeparateDirectionFromName(displayName);
				string item = valueTuple.Item1;
				NetworkDirection item2 = valueTuple.Item2;
				ValueTuple<string, NetworkDirection> valueTuple2 = LabelGeneration.SeparateDirectionFromName(displayName2);
				string item3 = valueTuple2.Item1;
				NetworkDirection item4 = valueTuple2.Item2;
				if (item == item3)
				{
					if (item2 != NetworkDirection.Received)
					{
						if (item2 != NetworkDirection.Sent)
						{
							goto IL_C1;
						}
						if (item4 != NetworkDirection.Received)
						{
							goto IL_C1;
						}
					}
					else if (item4 != NetworkDirection.Sent)
					{
						goto IL_C1;
					}
					return item + " Sent and Received";
				}
				IL_C1:
				if (item2 != NetworkDirection.Received)
				{
					if (item2 == NetworkDirection.Sent)
					{
						if (item4 == NetworkDirection.Sent)
						{
							return item + " and " + item3 + " Sent";
						}
					}
				}
				else if (item4 == NetworkDirection.Received)
				{
					return item + " and " + item3 + " Received";
				}
				return displayName + " and " + displayName2;
			}
			default:
				return "";
			}
		}
	}
}
