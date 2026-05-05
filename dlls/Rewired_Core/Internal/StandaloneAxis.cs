using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal
{
	// Token: 0x0200042E RID: 1070
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	internal sealed class StandaloneAxis
	{
		// Token: 0x17000A2D RID: 2605
		// (get) Token: 0x06002B02 RID: 11010 RVA: 0x0002112C File Offset: 0x0001F32C
		// (set) Token: 0x06002B03 RID: 11011 RVA: 0x00021134 File Offset: 0x0001F334
		public float buttonActivationThreshold
		{
			get
			{
				return this._buttonActivationThreshold;
			}
			set
			{
				if (value == this._buttonActivationThreshold)
				{
					return;
				}
				this._buttonActivationThreshold = MathTools.Abs(value);
			}
		}

		// Token: 0x17000A2E RID: 2606
		// (get) Token: 0x06002B04 RID: 11012 RVA: 0x0002114C File Offset: 0x0001F34C
		// (set) Token: 0x06002B05 RID: 11013 RVA: 0x00021154 File Offset: 0x0001F354
		public AxisCalibration calibration
		{
			get
			{
				return this._calibration;
			}
			private set
			{
				if (value == this._calibration)
				{
					return;
				}
				this._calibration = value;
			}
		}

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x06002B06 RID: 11014 RVA: 0x00021167 File Offset: 0x0001F367
		// (set) Token: 0x06002B07 RID: 11015 RVA: 0x0002116F File Offset: 0x0001F36F
		public float valueRaw
		{
			get
			{
				return this._valueRaw;
			}
			private set
			{
				if (value == this._valueRaw)
				{
					return;
				}
				this._valueRaw = value;
			}
		}

		// Token: 0x17000A30 RID: 2608
		// (get) Token: 0x06002B08 RID: 11016 RVA: 0x00021182 File Offset: 0x0001F382
		// (set) Token: 0x06002B09 RID: 11017 RVA: 0x0002118A File Offset: 0x0001F38A
		public float valueRawPrev
		{
			get
			{
				return this._valueRawPrev;
			}
			private set
			{
				if (value == this._valueRawPrev)
				{
					return;
				}
				this._valueRawPrev = value;
			}
		}

		// Token: 0x17000A31 RID: 2609
		// (get) Token: 0x06002B0A RID: 11018 RVA: 0x0002119D File Offset: 0x0001F39D
		public float valueRawDelta
		{
			get
			{
				return this._valueRaw - this._valueRawPrev;
			}
		}

		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x06002B0B RID: 11019 RVA: 0x000211AC File Offset: 0x0001F3AC
		public float value
		{
			get
			{
				if (this._calibration == null)
				{
					return this._valueRaw;
				}
				return this._calibration.GetCalibratedValue(this._valueRaw);
			}
		}

		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x06002B0C RID: 11020 RVA: 0x000211CE File Offset: 0x0001F3CE
		public float valuePrev
		{
			get
			{
				if (this._calibration == null)
				{
					return this._valueRawPrev;
				}
				return this._calibration.GetCalibratedValue(this._valueRawPrev);
			}
		}

		// Token: 0x17000A34 RID: 2612
		// (get) Token: 0x06002B0D RID: 11021 RVA: 0x000211F0 File Offset: 0x0001F3F0
		public float valueDelta
		{
			get
			{
				if (this._calibration == null)
				{
					return this.valueRawDelta;
				}
				return this._calibration.GetCalibratedValue(this._valueRaw) - this._calibration.GetCalibratedValue(this._valueRawPrev);
			}
		}

		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x06002B0E RID: 11022 RVA: 0x00021224 File Offset: 0x0001F424
		public bool rawButtonValue
		{
			get
			{
				return this._valueRaw >= this._buttonActivationThreshold;
			}
		}

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x06002B0F RID: 11023 RVA: 0x00021237 File Offset: 0x0001F437
		public bool rawButtonValuePrev
		{
			get
			{
				return this._valueRawPrev >= this._buttonActivationThreshold;
			}
		}

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x06002B10 RID: 11024 RVA: 0x0002124A File Offset: 0x0001F44A
		public bool buttonValue
		{
			get
			{
				return MathTools.Abs(this._calibration.GetCalibratedValue(this.value)) >= this._buttonActivationThreshold;
			}
		}

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x06002B11 RID: 11025 RVA: 0x0002126D File Offset: 0x0001F46D
		public bool buttonValuePrev
		{
			get
			{
				return MathTools.Abs(this._calibration.GetCalibratedValue(this.valuePrev)) >= this._buttonActivationThreshold;
			}
		}

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x06002B12 RID: 11026 RVA: 0x00021290 File Offset: 0x0001F490
		internal float rawMin
		{
			get
			{
				if (this._calibration == null)
				{
					return -1f;
				}
				if (!this._calibration.applyRangeCalibration)
				{
					return float.NegativeInfinity;
				}
				return this._calibration.calibratedMin;
			}
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x06002B13 RID: 11027 RVA: 0x000212BE File Offset: 0x0001F4BE
		internal float rawMax
		{
			get
			{
				if (this._calibration == null)
				{
					return 1f;
				}
				if (!this._calibration.applyRangeCalibration)
				{
					return float.PositiveInfinity;
				}
				return this._calibration.calibratedMax;
			}
		}

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x06002B14 RID: 11028 RVA: 0x000212EC File Offset: 0x0001F4EC
		internal float rawZero
		{
			get
			{
				if (this._calibration == null)
				{
					return 0f;
				}
				if (!this._calibration.applyRangeCalibration)
				{
					return 0f;
				}
				return this._calibration.calibratedZero;
			}
		}

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x06002B15 RID: 11029 RVA: 0x0009C0B0 File Offset: 0x0009A2B0
		// (remove) Token: 0x06002B16 RID: 11030 RVA: 0x0009C0E8 File Offset: 0x0009A2E8
		private event StandaloneAxis.AxisValueChangedEventHandler _AxisValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler = this.GerFntTmjRPqJOTXJSOJxfYtMCpv;
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					StandaloneAxis.AxisValueChangedEventHandler value2 = (StandaloneAxis.AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.AxisValueChangedEventHandler>(ref this.GerFntTmjRPqJOTXJSOJxfYtMCpv, value2, axisValueChangedEventHandler2);
				}
				while (axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler = this.GerFntTmjRPqJOTXJSOJxfYtMCpv;
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					StandaloneAxis.AxisValueChangedEventHandler value2 = (StandaloneAxis.AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.AxisValueChangedEventHandler>(ref this.GerFntTmjRPqJOTXJSOJxfYtMCpv, value2, axisValueChangedEventHandler2);
				}
				while (axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
		}

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06002B17 RID: 11031 RVA: 0x0002131A File Offset: 0x0001F51A
		// (remove) Token: 0x06002B18 RID: 11032 RVA: 0x00021323 File Offset: 0x0001F523
		public event StandaloneAxis.AxisValueChangedEventHandler AxisValueChangedEvent
		{
			add
			{
				this._AxisValueChangedEvent += value;
			}
			remove
			{
				this._AxisValueChangedEvent -= value;
			}
		}

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06002B19 RID: 11033 RVA: 0x0009C120 File Offset: 0x0009A320
		// (remove) Token: 0x06002B1A RID: 11034 RVA: 0x0009C158 File Offset: 0x0009A358
		private event StandaloneAxis.AxisValueChangedEventHandler _RawAxisValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler = this.JDELoENKhMWKGGHFBuFppDWuWOoi;
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					StandaloneAxis.AxisValueChangedEventHandler value2 = (StandaloneAxis.AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.AxisValueChangedEventHandler>(ref this.JDELoENKhMWKGGHFBuFppDWuWOoi, value2, axisValueChangedEventHandler2);
				}
				while (axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler = this.JDELoENKhMWKGGHFBuFppDWuWOoi;
				StandaloneAxis.AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					StandaloneAxis.AxisValueChangedEventHandler value2 = (StandaloneAxis.AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.AxisValueChangedEventHandler>(ref this.JDELoENKhMWKGGHFBuFppDWuWOoi, value2, axisValueChangedEventHandler2);
				}
				while (axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
		}

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x06002B1B RID: 11035 RVA: 0x0002132C File Offset: 0x0001F52C
		// (remove) Token: 0x06002B1C RID: 11036 RVA: 0x00021335 File Offset: 0x0001F535
		public event StandaloneAxis.AxisValueChangedEventHandler RawAxisValueChangedEvent
		{
			add
			{
				this._RawAxisValueChangedEvent += value;
			}
			remove
			{
				this._RawAxisValueChangedEvent -= value;
			}
		}

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x06002B1D RID: 11037 RVA: 0x0009C190 File Offset: 0x0009A390
		// (remove) Token: 0x06002B1E RID: 11038 RVA: 0x0009C1C8 File Offset: 0x0009A3C8
		private event StandaloneAxis.ButtonDownEventHandler _ButtonDownEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler = this.qBNhuhgGUmETmUjCzqKqHxCIStkeA;
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					StandaloneAxis.ButtonDownEventHandler value2 = (StandaloneAxis.ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonDownEventHandler>(ref this.qBNhuhgGUmETmUjCzqKqHxCIStkeA, value2, buttonDownEventHandler2);
				}
				while (buttonDownEventHandler != buttonDownEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler = this.qBNhuhgGUmETmUjCzqKqHxCIStkeA;
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					StandaloneAxis.ButtonDownEventHandler value2 = (StandaloneAxis.ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonDownEventHandler>(ref this.qBNhuhgGUmETmUjCzqKqHxCIStkeA, value2, buttonDownEventHandler2);
				}
				while (buttonDownEventHandler != buttonDownEventHandler2);
			}
		}

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x06002B1F RID: 11039 RVA: 0x0002133E File Offset: 0x0001F53E
		// (remove) Token: 0x06002B20 RID: 11040 RVA: 0x00021347 File Offset: 0x0001F547
		public event StandaloneAxis.ButtonDownEventHandler ButtonDownEvent
		{
			add
			{
				this._ButtonDownEvent += value;
			}
			remove
			{
				this._ButtonDownEvent -= value;
			}
		}

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06002B21 RID: 11041 RVA: 0x0009C200 File Offset: 0x0009A400
		// (remove) Token: 0x06002B22 RID: 11042 RVA: 0x0009C238 File Offset: 0x0009A438
		private event StandaloneAxis.ButtonUpEventHandler _ButtonUpEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler = this.KjPGdzuuMqFUOvFpWJemNmVQLxET;
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					StandaloneAxis.ButtonUpEventHandler value2 = (StandaloneAxis.ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonUpEventHandler>(ref this.KjPGdzuuMqFUOvFpWJemNmVQLxET, value2, buttonUpEventHandler2);
				}
				while (buttonUpEventHandler != buttonUpEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler = this.KjPGdzuuMqFUOvFpWJemNmVQLxET;
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					StandaloneAxis.ButtonUpEventHandler value2 = (StandaloneAxis.ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonUpEventHandler>(ref this.KjPGdzuuMqFUOvFpWJemNmVQLxET, value2, buttonUpEventHandler2);
				}
				while (buttonUpEventHandler != buttonUpEventHandler2);
			}
		}

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06002B23 RID: 11043 RVA: 0x00021350 File Offset: 0x0001F550
		// (remove) Token: 0x06002B24 RID: 11044 RVA: 0x00021359 File Offset: 0x0001F559
		public event StandaloneAxis.ButtonUpEventHandler ButtonUpEvent
		{
			add
			{
				this._ButtonUpEvent += value;
			}
			remove
			{
				this._ButtonUpEvent -= value;
			}
		}

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06002B25 RID: 11045 RVA: 0x0009C270 File Offset: 0x0009A470
		// (remove) Token: 0x06002B26 RID: 11046 RVA: 0x0009C2A8 File Offset: 0x0009A4A8
		private event StandaloneAxis.ButtonValueChangedEventHandler _ButtonValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler = this.lznbZqXiZfJOIFnuZQctcHyyMAxI;
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					StandaloneAxis.ButtonValueChangedEventHandler value2 = (StandaloneAxis.ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonValueChangedEventHandler>(ref this.lznbZqXiZfJOIFnuZQctcHyyMAxI, value2, buttonValueChangedEventHandler2);
				}
				while (buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler = this.lznbZqXiZfJOIFnuZQctcHyyMAxI;
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					StandaloneAxis.ButtonValueChangedEventHandler value2 = (StandaloneAxis.ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonValueChangedEventHandler>(ref this.lznbZqXiZfJOIFnuZQctcHyyMAxI, value2, buttonValueChangedEventHandler2);
				}
				while (buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
		}

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06002B27 RID: 11047 RVA: 0x00021362 File Offset: 0x0001F562
		// (remove) Token: 0x06002B28 RID: 11048 RVA: 0x0002136B File Offset: 0x0001F56B
		public event StandaloneAxis.ButtonValueChangedEventHandler ButtonValueChangedEvent
		{
			add
			{
				this._ButtonValueChangedEvent += value;
			}
			remove
			{
				this._ButtonValueChangedEvent -= value;
			}
		}

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06002B29 RID: 11049 RVA: 0x0009C2E0 File Offset: 0x0009A4E0
		// (remove) Token: 0x06002B2A RID: 11050 RVA: 0x0009C318 File Offset: 0x0009A518
		private event StandaloneAxis.ButtonDownEventHandler _RawButtonDownEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler = this.xUjJpjNlwMHDtgsktJEzZBkHIzGe;
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					StandaloneAxis.ButtonDownEventHandler value2 = (StandaloneAxis.ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonDownEventHandler>(ref this.xUjJpjNlwMHDtgsktJEzZBkHIzGe, value2, buttonDownEventHandler2);
				}
				while (buttonDownEventHandler != buttonDownEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler = this.xUjJpjNlwMHDtgsktJEzZBkHIzGe;
				StandaloneAxis.ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					StandaloneAxis.ButtonDownEventHandler value2 = (StandaloneAxis.ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonDownEventHandler>(ref this.xUjJpjNlwMHDtgsktJEzZBkHIzGe, value2, buttonDownEventHandler2);
				}
				while (buttonDownEventHandler != buttonDownEventHandler2);
			}
		}

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x06002B2B RID: 11051 RVA: 0x00021374 File Offset: 0x0001F574
		// (remove) Token: 0x06002B2C RID: 11052 RVA: 0x0002137D File Offset: 0x0001F57D
		public event StandaloneAxis.ButtonDownEventHandler RawButtonDownEvent
		{
			add
			{
				this._RawButtonDownEvent += value;
			}
			remove
			{
				this._RawButtonDownEvent -= value;
			}
		}

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x06002B2D RID: 11053 RVA: 0x0009C350 File Offset: 0x0009A550
		// (remove) Token: 0x06002B2E RID: 11054 RVA: 0x0009C388 File Offset: 0x0009A588
		private event StandaloneAxis.ButtonUpEventHandler _RawButtonUpEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler = this.hicLvCaHFKQKIYJKeFmvDkUHjnXBb;
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					StandaloneAxis.ButtonUpEventHandler value2 = (StandaloneAxis.ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonUpEventHandler>(ref this.hicLvCaHFKQKIYJKeFmvDkUHjnXBb, value2, buttonUpEventHandler2);
				}
				while (buttonUpEventHandler != buttonUpEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler = this.hicLvCaHFKQKIYJKeFmvDkUHjnXBb;
				StandaloneAxis.ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					StandaloneAxis.ButtonUpEventHandler value2 = (StandaloneAxis.ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonUpEventHandler>(ref this.hicLvCaHFKQKIYJKeFmvDkUHjnXBb, value2, buttonUpEventHandler2);
				}
				while (buttonUpEventHandler != buttonUpEventHandler2);
			}
		}

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x06002B2F RID: 11055 RVA: 0x00021386 File Offset: 0x0001F586
		// (remove) Token: 0x06002B30 RID: 11056 RVA: 0x0002138F File Offset: 0x0001F58F
		public event StandaloneAxis.ButtonUpEventHandler RawButtonUpEvent
		{
			add
			{
				this._RawButtonUpEvent += value;
			}
			remove
			{
				this._RawButtonUpEvent -= value;
			}
		}

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x06002B31 RID: 11057 RVA: 0x0009C3C0 File Offset: 0x0009A5C0
		// (remove) Token: 0x06002B32 RID: 11058 RVA: 0x0009C3F8 File Offset: 0x0009A5F8
		private event StandaloneAxis.ButtonValueChangedEventHandler _RawButtonValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler = this.kvSXpfMwvTPxicxJsvursmfcrRWn;
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					StandaloneAxis.ButtonValueChangedEventHandler value2 = (StandaloneAxis.ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonValueChangedEventHandler>(ref this.kvSXpfMwvTPxicxJsvursmfcrRWn, value2, buttonValueChangedEventHandler2);
				}
				while (buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler = this.kvSXpfMwvTPxicxJsvursmfcrRWn;
				StandaloneAxis.ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					StandaloneAxis.ButtonValueChangedEventHandler value2 = (StandaloneAxis.ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange<StandaloneAxis.ButtonValueChangedEventHandler>(ref this.kvSXpfMwvTPxicxJsvursmfcrRWn, value2, buttonValueChangedEventHandler2);
				}
				while (buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
		}

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x06002B33 RID: 11059 RVA: 0x00021398 File Offset: 0x0001F598
		// (remove) Token: 0x06002B34 RID: 11060 RVA: 0x000213A1 File Offset: 0x0001F5A1
		public event StandaloneAxis.ButtonValueChangedEventHandler RawButtonValueChangedEvent
		{
			add
			{
				this._RawButtonValueChangedEvent += value;
			}
			remove
			{
				this._RawButtonValueChangedEvent -= value;
			}
		}

		// Token: 0x06002B35 RID: 11061 RVA: 0x000213AA File Offset: 0x0001F5AA
		internal StandaloneAxis()
		{
		}

		// Token: 0x06002B36 RID: 11062 RVA: 0x0009C430 File Offset: 0x0009A630
		public void SetRawValue(float value)
		{
			this._valueRawPrev = this._valueRaw;
			this._valueRaw = value;
			if (value == this._valueRawPrev)
			{
				return;
			}
			if (this.JDELoENKhMWKGGHFBuFppDWuWOoi != null && this._valueRaw != this._valueRawPrev)
			{
				this.JDELoENKhMWKGGHFBuFppDWuWOoi(this._valueRaw);
			}
			if (this.GerFntTmjRPqJOTXJSOJxfYtMCpv != null)
			{
				float value2 = this.value;
				if (value2 != this.valuePrev)
				{
					this.GerFntTmjRPqJOTXJSOJxfYtMCpv(value2);
				}
			}
			if (this.kvSXpfMwvTPxicxJsvursmfcrRWn != null)
			{
				bool rawButtonValue = this.rawButtonValue;
				if (rawButtonValue != this.rawButtonValuePrev)
				{
					this.kvSXpfMwvTPxicxJsvursmfcrRWn(rawButtonValue);
				}
			}
			if (this.xUjJpjNlwMHDtgsktJEzZBkHIzGe != null && this.rawButtonValue && !this.rawButtonValuePrev)
			{
				this.xUjJpjNlwMHDtgsktJEzZBkHIzGe();
			}
			if (this.hicLvCaHFKQKIYJKeFmvDkUHjnXBb != null && !this.rawButtonValue && this.rawButtonValuePrev)
			{
				this.hicLvCaHFKQKIYJKeFmvDkUHjnXBb();
			}
			if (this.lznbZqXiZfJOIFnuZQctcHyyMAxI != null)
			{
				bool buttonValue = this.buttonValue;
				if (buttonValue != this.buttonValuePrev)
				{
					this.lznbZqXiZfJOIFnuZQctcHyyMAxI(buttonValue);
				}
			}
			if (this.qBNhuhgGUmETmUjCzqKqHxCIStkeA != null && this.buttonValue && !this.buttonValuePrev)
			{
				this.qBNhuhgGUmETmUjCzqKqHxCIStkeA();
			}
			if (this.KjPGdzuuMqFUOvFpWJemNmVQLxET != null && !this.buttonValue && this.buttonValuePrev)
			{
				this.KjPGdzuuMqFUOvFpWJemNmVQLxET();
			}
		}

		// Token: 0x06002B37 RID: 11063 RVA: 0x000213C8 File Offset: 0x0001F5C8
		public void Clear()
		{
			this.SetRawValue(this.rawZero);
		}

		// Token: 0x06002B38 RID: 11064 RVA: 0x000213D6 File Offset: 0x0001F5D6
		[CustomObfuscation(rename = false)]
		internal static StandaloneAxis CreateRelative()
		{
			return new StandaloneAxis
			{
				_calibration = AxisCalibration.CreateRelative()
			};
		}

		// Token: 0x040018AC RID: 6316
		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		private float _buttonActivationThreshold = 0.5f;

		// Token: 0x040018AD RID: 6317
		[Tooltip("Contains calibration settings for the axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisCalibration _calibration = new AxisCalibration();

		// Token: 0x040018AE RID: 6318
		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		// Token: 0x040018AF RID: 6319
		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		// Token: 0x040018B0 RID: 6320
		[CompilerGenerated]
		private StandaloneAxis.AxisValueChangedEventHandler GerFntTmjRPqJOTXJSOJxfYtMCpv;

		// Token: 0x040018B1 RID: 6321
		[CompilerGenerated]
		private StandaloneAxis.AxisValueChangedEventHandler JDELoENKhMWKGGHFBuFppDWuWOoi;

		// Token: 0x040018B2 RID: 6322
		[CompilerGenerated]
		private StandaloneAxis.ButtonDownEventHandler qBNhuhgGUmETmUjCzqKqHxCIStkeA;

		// Token: 0x040018B3 RID: 6323
		[CompilerGenerated]
		private StandaloneAxis.ButtonUpEventHandler KjPGdzuuMqFUOvFpWJemNmVQLxET;

		// Token: 0x040018B4 RID: 6324
		[CompilerGenerated]
		private StandaloneAxis.ButtonValueChangedEventHandler lznbZqXiZfJOIFnuZQctcHyyMAxI;

		// Token: 0x040018B5 RID: 6325
		[CompilerGenerated]
		private StandaloneAxis.ButtonDownEventHandler xUjJpjNlwMHDtgsktJEzZBkHIzGe;

		// Token: 0x040018B6 RID: 6326
		[CompilerGenerated]
		private StandaloneAxis.ButtonUpEventHandler hicLvCaHFKQKIYJKeFmvDkUHjnXBb;

		// Token: 0x040018B7 RID: 6327
		[CompilerGenerated]
		private StandaloneAxis.ButtonValueChangedEventHandler kvSXpfMwvTPxicxJsvursmfcrRWn;

		// Token: 0x0200042F RID: 1071
		// (Invoke) Token: 0x06002B3A RID: 11066
		[CustomObfuscation(rename = false)]
		public delegate void AxisValueChangedEventHandler(float value);

		// Token: 0x02000430 RID: 1072
		// (Invoke) Token: 0x06002B3E RID: 11070
		[CustomObfuscation(rename = false)]
		public delegate void ButtonValueChangedEventHandler(bool value);

		// Token: 0x02000431 RID: 1073
		// (Invoke) Token: 0x06002B42 RID: 11074
		[CustomObfuscation(rename = false)]
		public delegate void ButtonDownEventHandler();

		// Token: 0x02000432 RID: 1074
		// (Invoke) Token: 0x06002B46 RID: 11078
		[CustomObfuscation(rename = false)]
		public delegate void ButtonUpEventHandler();
	}
}
