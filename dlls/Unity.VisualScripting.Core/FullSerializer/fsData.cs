using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000198 RID: 408
	public sealed class fsData
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x0002CF5D File Offset: 0x0002B15D
		public override string ToString()
		{
			return fsJsonPrinter.CompressedJson(this);
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0002CF65 File Offset: 0x0002B165
		public fsData()
		{
			this._value = null;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0002CF74 File Offset: 0x0002B174
		public fsData(bool boolean)
		{
			this._value = boolean;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0002CF88 File Offset: 0x0002B188
		public fsData(double f)
		{
			this._value = f;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0002CF9C File Offset: 0x0002B19C
		public fsData(long i)
		{
			this._value = i;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0002CFB0 File Offset: 0x0002B1B0
		public fsData(string str)
		{
			this._value = str;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x0002CFBF File Offset: 0x0002B1BF
		public fsData(Dictionary<string, fsData> dict)
		{
			this._value = dict;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0002CFCE File Offset: 0x0002B1CE
		public fsData(List<fsData> list)
		{
			this._value = list;
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0002CFDD File Offset: 0x0002B1DD
		public static fsData CreateDictionary()
		{
			return new fsData(new Dictionary<string, fsData>(fsGlobalConfig.IsCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase));
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0002CFFC File Offset: 0x0002B1FC
		public static fsData CreateList()
		{
			return new fsData(new List<fsData>());
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0002D008 File Offset: 0x0002B208
		public static fsData CreateList(int capacity)
		{
			return new fsData(new List<fsData>(capacity));
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0002D015 File Offset: 0x0002B215
		internal void BecomeDictionary()
		{
			this._value = new Dictionary<string, fsData>();
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0002D022 File Offset: 0x0002B222
		internal fsData Clone()
		{
			return new fsData
			{
				_value = this._value
			};
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x0002D038 File Offset: 0x0002B238
		public fsDataType Type
		{
			get
			{
				if (this._value == null)
				{
					return fsDataType.Null;
				}
				if (this._value is double)
				{
					return fsDataType.Double;
				}
				if (this._value is long)
				{
					return fsDataType.Int64;
				}
				if (this._value is bool)
				{
					return fsDataType.Boolean;
				}
				if (this._value is string)
				{
					return fsDataType.String;
				}
				if (this._value is Dictionary<string, fsData>)
				{
					return fsDataType.Object;
				}
				if (this._value is List<fsData>)
				{
					return fsDataType.Array;
				}
				throw new InvalidOperationException("unknown JSON data type");
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0002D0B3 File Offset: 0x0002B2B3
		public bool IsNull
		{
			get
			{
				return this._value == null;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x0002D0BE File Offset: 0x0002B2BE
		public bool IsDouble
		{
			get
			{
				return this._value is double;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0002D0CE File Offset: 0x0002B2CE
		public bool IsInt64
		{
			get
			{
				return this._value is long;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x0002D0DE File Offset: 0x0002B2DE
		public bool IsBool
		{
			get
			{
				return this._value is bool;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000ABF RID: 2751 RVA: 0x0002D0EE File Offset: 0x0002B2EE
		public bool IsString
		{
			get
			{
				return this._value is string;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0002D0FE File Offset: 0x0002B2FE
		public bool IsDictionary
		{
			get
			{
				return this._value is Dictionary<string, fsData>;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0002D10E File Offset: 0x0002B30E
		public bool IsList
		{
			get
			{
				return this._value is List<fsData>;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x0002D11E File Offset: 0x0002B31E
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double AsDouble
		{
			get
			{
				return this.Cast<double>();
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0002D126 File Offset: 0x0002B326
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long AsInt64
		{
			get
			{
				return this.Cast<long>();
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x0002D12E File Offset: 0x0002B32E
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool AsBool
		{
			get
			{
				return this.Cast<bool>();
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0002D136 File Offset: 0x0002B336
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string AsString
		{
			get
			{
				return this.Cast<string>();
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0002D13E File Offset: 0x0002B33E
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Dictionary<string, fsData> AsDictionary
		{
			get
			{
				return this.Cast<Dictionary<string, fsData>>();
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0002D146 File Offset: 0x0002B346
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public List<fsData> AsList
		{
			get
			{
				return this.Cast<List<fsData>>();
			}
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0002D150 File Offset: 0x0002B350
		private T Cast<T>()
		{
			if (this._value is T)
			{
				return (T)((object)this._value);
			}
			string[] array = new string[6];
			array[0] = "Unable to cast <";
			array[1] = ((this != null) ? this.ToString() : null);
			array[2] = "> (with type = ";
			int num = 3;
			Type type = this._value.GetType();
			array[num] = ((type != null) ? type.ToString() : null);
			array[4] = ") to type ";
			int num2 = 5;
			Type typeFromHandle = typeof(T);
			array[num2] = ((typeFromHandle != null) ? typeFromHandle.ToString() : null);
			throw new InvalidCastException(string.Concat(array));
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0002D1E1 File Offset: 0x0002B3E1
		public override bool Equals(object obj)
		{
			return this.Equals(obj as fsData);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0002D1F0 File Offset: 0x0002B3F0
		public bool Equals(fsData other)
		{
			if (other == null || this.Type != other.Type)
			{
				return false;
			}
			switch (this.Type)
			{
			case fsDataType.Array:
			{
				List<fsData> asList = this.AsList;
				List<fsData> asList2 = other.AsList;
				if (asList.Count != asList2.Count)
				{
					return false;
				}
				for (int i = 0; i < asList.Count; i++)
				{
					if (!asList[i].Equals(asList2[i]))
					{
						return false;
					}
				}
				return true;
			}
			case fsDataType.Object:
			{
				Dictionary<string, fsData> asDictionary = this.AsDictionary;
				Dictionary<string, fsData> asDictionary2 = other.AsDictionary;
				if (asDictionary.Count != asDictionary2.Count)
				{
					return false;
				}
				foreach (string key in asDictionary.Keys)
				{
					if (!asDictionary2.ContainsKey(key))
					{
						return false;
					}
					if (!asDictionary[key].Equals(asDictionary2[key]))
					{
						return false;
					}
				}
				return true;
			}
			case fsDataType.Double:
				return this.AsDouble == other.AsDouble || Math.Abs(this.AsDouble - other.AsDouble) < double.Epsilon;
			case fsDataType.Int64:
				return this.AsInt64 == other.AsInt64;
			case fsDataType.Boolean:
				return this.AsBool == other.AsBool;
			case fsDataType.String:
				return this.AsString == other.AsString;
			case fsDataType.Null:
				return true;
			default:
				throw new Exception("Unknown data type");
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0002D390 File Offset: 0x0002B590
		public static bool operator ==(fsData a, fsData b)
		{
			if (a == b)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			if (a.IsDouble && b.IsDouble)
			{
				return Math.Abs(a.AsDouble - b.AsDouble) < double.Epsilon;
			}
			return a.Equals(b);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0002D3E0 File Offset: 0x0002B5E0
		public static bool operator !=(fsData a, fsData b)
		{
			return !(a == b);
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x0002D3EC File Offset: 0x0002B5EC
		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}

		// Token: 0x04000283 RID: 643
		private object _value;

		// Token: 0x04000284 RID: 644
		public static readonly fsData True = new fsData(true);

		// Token: 0x04000285 RID: 645
		public static readonly fsData False = new fsData(false);

		// Token: 0x04000286 RID: 646
		public static readonly fsData Null = new fsData();
	}
}
