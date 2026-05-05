using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	public struct MetricId : IEquatable<MetricId>
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002C96 File Offset: 0x00000E96
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002C9E File Offset: 0x00000E9E
		internal int TypeIndex { readonly get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002CA7 File Offset: 0x00000EA7
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002CAF File Offset: 0x00000EAF
		internal int EnumValue { readonly get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002CB8 File Offset: 0x00000EB8
		internal Type EnumType
		{
			get
			{
				return MetricIdTypeLibrary.GetType(this.TypeIndex);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002CC5 File Offset: 0x00000EC5
		[NotNull]
		internal string Name
		{
			get
			{
				return MetricIdTypeLibrary.GetEnumName(this.TypeIndex, this.EnumValue);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002CD8 File Offset: 0x00000ED8
		[NotNull]
		internal string DisplayName
		{
			get
			{
				return MetricIdTypeLibrary.GetEnumDisplayName(this.TypeIndex, this.EnumValue);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002CEB File Offset: 0x00000EEB
		internal MetricKind MetricKind
		{
			get
			{
				return MetricIdTypeLibrary.GetEnumMetricKind(this.TypeIndex, this.EnumValue);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002CFE File Offset: 0x00000EFE
		internal BaseUnits Units
		{
			get
			{
				return MetricIdTypeLibrary.GetEnumUnit(this.TypeIndex, this.EnumValue);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002D11 File Offset: 0x00000F11
		internal bool DisplayAsPercentage
		{
			get
			{
				return MetricIdTypeLibrary.GetDisplayAsPercentage(this.TypeIndex, this.EnumValue);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002D24 File Offset: 0x00000F24
		internal MetricId(int typeIndex, int enumValue)
		{
			if (!MetricIdTypeLibrary.IsValidTypeIndex(typeIndex))
			{
				throw new ArgumentOutOfRangeException(string.Format("Cannot construct {0} with out-of-range {1} {2}.", "MetricId", "TypeIndex", typeIndex));
			}
			this.TypeIndex = typeIndex;
			this.EnumValue = enumValue;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002D5C File Offset: 0x00000F5C
		internal MetricId(Type enumType, int enumValue)
		{
			this.TypeIndex = MetricIdTypeLibrary.GetTypeIndex(enumType);
			this.EnumValue = enumValue;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002D74 File Offset: 0x00000F74
		public static MetricId Create<T>(T value) where T : struct, IConvertible
		{
			Type typeFromHandle = typeof(T);
			int enumValue = value.ToInt32(CultureInfo.InvariantCulture);
			return new MetricId(typeFromHandle, enumValue);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002DA4 File Offset: 0x00000FA4
		public bool Equals(MetricId other)
		{
			return this.TypeIndex == other.TypeIndex && this.EnumValue == other.EnumValue;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002DC6 File Offset: 0x00000FC6
		public override bool Equals(object obj)
		{
			return obj != null && !(obj.GetType() != base.GetType()) && this.Equals((MetricId)obj);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002DF8 File Offset: 0x00000FF8
		public override int GetHashCode()
		{
			return 173 * this.TypeIndex + 13 * this.EnumValue;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002E10 File Offset: 0x00001010
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002E18 File Offset: 0x00001018
		public static implicit operator string(MetricId metricId)
		{
			return metricId.ToString();
		}
	}
}
