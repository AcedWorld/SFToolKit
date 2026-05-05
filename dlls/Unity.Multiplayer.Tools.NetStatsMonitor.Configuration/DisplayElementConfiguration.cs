using System;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.Common;
using Unity.Multiplayer.Tools.NetStats;
using Unity.Multiplayer.Tools.NetStatsMonitor.Configuration;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public sealed class DisplayElementConfiguration : ISerializationCallbackReceiver
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002286 File Offset: 0x00000486
		// (set) Token: 0x06000020 RID: 32 RVA: 0x0000228E File Offset: 0x0000048E
		internal bool FieldsInitialized { get; private set; } = true;

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002297 File Offset: 0x00000497
		// (set) Token: 0x06000022 RID: 34 RVA: 0x0000229F File Offset: 0x0000049F
		[Tooltip("The label to display for this visual element in the on-screen display. For graphs this field is optional, as the variables displayed in the graph are shown in the legend. Consider leaving this field blank for graphs if you would like to make them more compact.")]
		public DisplayElementType Type { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000022A8 File Offset: 0x000004A8
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000022B0 File Offset: 0x000004B0
		public string Label { get; set; } = "";

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000022B9 File Offset: 0x000004B9
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000022C1 File Offset: 0x000004C1
		public List<MetricId> Stats { get; set; } = new List<MetricId>();

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000022CA File Offset: 0x000004CA
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000022D2 File Offset: 0x000004D2
		public CounterConfiguration CounterConfiguration { get; set; } = new CounterConfiguration();

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000022DB File Offset: 0x000004DB
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000022E3 File Offset: 0x000004E3
		public GraphConfiguration GraphConfiguration { get; set; } = new GraphConfiguration();

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000022EC File Offset: 0x000004EC
		internal int SampleCount
		{
			get
			{
				DisplayElementType type = this.Type;
				if (type == DisplayElementType.Counter)
				{
					return this.CounterConfiguration.SampleCount;
				}
				if (type - DisplayElementType.LineGraph > 1)
				{
					throw new NotSupportedException(string.Format("Unhandled {0} {1}", "DisplayElementType", this.Type));
				}
				return this.GraphConfiguration.SampleCount;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002344 File Offset: 0x00000544
		internal SampleRate SampleRate
		{
			get
			{
				DisplayElementType type = this.Type;
				if (type == DisplayElementType.Counter)
				{
					return this.CounterConfiguration.SampleRate;
				}
				if (type - DisplayElementType.LineGraph > 1)
				{
					throw new NotSupportedException(string.Format("Unhandled {0} {1}", "DisplayElementType", this.Type));
				}
				return this.GraphConfiguration.SampleRate;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000239C File Offset: 0x0000059C
		internal double? HalfLife
		{
			get
			{
				DisplayElementType type = this.Type;
				if (type != DisplayElementType.Counter)
				{
					if (type - DisplayElementType.LineGraph > 1)
					{
						throw new NotSupportedException(string.Format("Unhandled {0} {1}", "DisplayElementType", this.Type));
					}
					return null;
				}
				else
				{
					SmoothingMethod smoothingMethod = this.CounterConfiguration.SmoothingMethod;
					if (smoothingMethod == SmoothingMethod.ExponentialMovingAverage)
					{
						return new double?(this.CounterConfiguration.ExponentialMovingAverageParams.HalfLife);
					}
					if (smoothingMethod != SmoothingMethod.SimpleMovingAverage)
					{
						throw new NotSupportedException(string.Format("Unhandled {0} {1}", "SmoothingMethod", smoothingMethod));
					}
					return null;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002434 File Offset: 0x00000634
		internal double? DecayConstant
		{
			get
			{
				if (this.HalfLife == null)
				{
					return null;
				}
				return new double?(ContinuousExponentialMovingAverage.GetDecayConstantForHalfLife(this.HalfLife.Value));
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002473 File Offset: 0x00000673
		internal void OnValidate()
		{
			this.RefreshGenerateLabel();
			this.ValidateColors();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002484 File Offset: 0x00000684
		private void RefreshGenerateLabel()
		{
			if (this.Type != DisplayElementType.Counter)
			{
				return;
			}
			int num = this.ComputeStatsHashCode();
			if (this.m_PreviousStatsHash == 0)
			{
				this.m_PreviousStatsHash = num;
				this.m_PreviousGeneratedLabel = LabelGeneration.GenerateLabel(this.Stats);
				return;
			}
			if (num == this.m_PreviousStatsHash)
			{
				return;
			}
			this.m_PreviousStatsHash = num;
			string text = LabelGeneration.GenerateLabel(this.Stats);
			if (this.Label == this.m_PreviousGeneratedLabel)
			{
				this.Label = text;
			}
			this.m_PreviousGeneratedLabel = text;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002500 File Offset: 0x00000700
		private void ValidateColors()
		{
			GraphConfiguration graphConfiguration = this.GraphConfiguration;
			List<Color> list = (graphConfiguration != null) ? graphConfiguration.VariableColors : null;
			if (list == null)
			{
				return;
			}
			bool flag = true;
			for (int i = 0; i < list.Count; i++)
			{
				Color color = list[i];
				if (color.a != 0f || color.r != 0f || color.g != 0f || color.b != 0f)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				for (int j = 0; j < list.Count; j++)
				{
					Color value = list[j];
					value.a = 1f;
					list[j] = value;
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000025AF File Offset: 0x000007AF
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000025B7 File Offset: 0x000007B7
		private List<DisplayElementConfiguration.SerializedStat> SerializedStats { get; set; } = new List<DisplayElementConfiguration.SerializedStat>();

		// Token: 0x06000034 RID: 52 RVA: 0x000025C0 File Offset: 0x000007C0
		public void OnBeforeSerialize()
		{
			int count = this.Stats.Count;
			this.SerializedStats.Resize(count, default(DisplayElementConfiguration.SerializedStat));
			for (int i = 0; i < count; i++)
			{
				MetricId metricId = this.Stats[i];
				this.SerializedStats[i] = new DisplayElementConfiguration.SerializedStat
				{
					TypeName = metricId.EnumType.AssemblyQualifiedName,
					ValueName = metricId.Name
				};
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002640 File Offset: 0x00000840
		public void OnAfterDeserialize()
		{
			if (this.m_SerializedStatsLoaded)
			{
				return;
			}
			this.m_SerializedStatsLoaded = true;
			int count = this.SerializedStats.Count;
			this.Stats.Resize(count, default(MetricId));
			for (int i = 0; i < count; i++)
			{
				DisplayElementConfiguration.SerializedStat serializedStat = this.SerializedStats[i];
				Type type = System.Type.GetType(serializedStat.TypeName);
				if (!(type == null))
				{
					int typeIndex = MetricIdTypeLibrary.GetTypeIndex(type);
					IReadOnlyList<string> enumNames = MetricIdTypeLibrary.GetEnumNames(typeIndex);
					string valueName = serializedStat.ValueName;
					int num = enumNames.IndexOf(valueName);
					if (num != -1)
					{
						int enumValue = MetricIdTypeLibrary.GetEnumValues(typeIndex)[num];
						this.Stats[i] = new MetricId(typeIndex, enumValue);
					}
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000026FC File Offset: 0x000008FC
		internal int ComputeStatsHashCode()
		{
			int num = 0;
			foreach (MetricId value in this.Stats)
			{
				num = HashCode.Combine<int, MetricId>(num, value);
			}
			return num;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002754 File Offset: 0x00000954
		internal int ComputeHashCode()
		{
			int num = HashCode.Combine<DisplayElementType, string, int>(this.Type, this.Label, this.ComputeStatsHashCode());
			DisplayElementType type = this.Type;
			if (type != DisplayElementType.Counter)
			{
				if (type - DisplayElementType.LineGraph > 1)
				{
					throw new ArgumentOutOfRangeException(string.Format("Unknow {0} {1}", "DisplayElementType", this.Type));
				}
				num = HashCode.Combine<int, int>(num, this.GraphConfiguration.ComputeHashCode());
			}
			else
			{
				num = HashCode.Combine<int, int>(num, this.CounterConfiguration.ComputeHashCode());
			}
			return num;
		}

		// Token: 0x04000023 RID: 35
		private int m_PreviousStatsHash;

		// Token: 0x04000024 RID: 36
		private string m_PreviousGeneratedLabel = "";

		// Token: 0x04000026 RID: 38
		private bool m_SerializedStatsLoaded;

		// Token: 0x02000017 RID: 23
		[Serializable]
		private struct SerializedStat
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600005B RID: 91 RVA: 0x00002C8C File Offset: 0x00000E8C
			// (set) Token: 0x0600005C RID: 92 RVA: 0x00002C94 File Offset: 0x00000E94
			public string TypeName { readonly get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600005D RID: 93 RVA: 0x00002C9D File Offset: 0x00000E9D
			// (set) Token: 0x0600005E RID: 94 RVA: 0x00002CA5 File Offset: 0x00000EA5
			public string ValueName { readonly get; set; }
		}
	}
}
