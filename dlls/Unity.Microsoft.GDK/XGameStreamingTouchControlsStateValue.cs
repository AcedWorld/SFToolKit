using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000136 RID: 310
	public class XGameStreamingTouchControlsStateValue
	{
		// Token: 0x0600079C RID: 1948 RVA: 0x0000D1D9 File Offset: 0x0000B3D9
		internal XGameStreamingTouchControlsStateValue(XGameStreamingTouchControlsStateValue interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
		public XGameStreamingTouchControlsStateValue()
		{
			this.interop = default(XGameStreamingTouchControlsStateValue);
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x0000D1FC File Offset: 0x0000B3FC
		// (set) Token: 0x0600079F RID: 1951 RVA: 0x0000D209 File Offset: 0x0000B409
		public XGameStreamingTouchControlsStateValueKind ValueKind
		{
			get
			{
				return this.interop.valueKind;
			}
			set
			{
				this.interop.valueKind = value;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0000D217 File Offset: 0x0000B417
		// (set) Token: 0x060007A1 RID: 1953 RVA: 0x0000D21F File Offset: 0x0000B41F
		public string StringValue
		{
			get
			{
				return this._stringValue;
			}
			set
			{
				this._stringValue = value;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x0000D228 File Offset: 0x0000B428
		// (set) Token: 0x060007A3 RID: 1955 RVA: 0x0000D235 File Offset: 0x0000B435
		public double DoubleValue
		{
			get
			{
				return this.interop.doubleValue;
			}
			set
			{
				this.interop.doubleValue = value;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0000D243 File Offset: 0x0000B443
		// (set) Token: 0x060007A5 RID: 1957 RVA: 0x0000D250 File Offset: 0x0000B450
		public bool BoolValue
		{
			get
			{
				return this.interop.boolValue;
			}
			set
			{
				this.interop.boolValue = value;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x0000D25E File Offset: 0x0000B45E
		// (set) Token: 0x060007A7 RID: 1959 RVA: 0x0000D26B File Offset: 0x0000B46B
		public uint IntegerValue
		{
			get
			{
				return this.interop.integerValue;
			}
			set
			{
				this.interop.integerValue = value;
			}
		}

		// Token: 0x040004A8 RID: 1192
		internal XGameStreamingTouchControlsStateValue interop;

		// Token: 0x040004A9 RID: 1193
		internal string _stringValue;
	}
}
