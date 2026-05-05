using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal
{
	// Token: 0x02000433 RID: 1075
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	internal sealed class StandaloneAxis2D
	{
		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06002B49 RID: 11081 RVA: 0x000213E8 File Offset: 0x0001F5E8
		public Axis2DCalibration calibration
		{
			get
			{
				return this._calibration;
			}
		}

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06002B4A RID: 11082 RVA: 0x000213F0 File Offset: 0x0001F5F0
		public StandaloneAxis xAxis
		{
			get
			{
				return this._xAxis;
			}
		}

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x06002B4B RID: 11083 RVA: 0x000213F8 File Offset: 0x0001F5F8
		public StandaloneAxis yAxis
		{
			get
			{
				return this._yAxis;
			}
		}

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x06002B4C RID: 11084 RVA: 0x00021400 File Offset: 0x0001F600
		public Vector2 value
		{
			get
			{
				return this.GetCalibratedValue(this._xAxis, this._yAxis);
			}
		}

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x06002B4D RID: 11085 RVA: 0x00021414 File Offset: 0x0001F614
		public Vector2 valuePrev
		{
			get
			{
				return this.GetCalibratedValuePrev(this._xAxis, this._yAxis);
			}
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x06002B4E RID: 11086 RVA: 0x00021428 File Offset: 0x0001F628
		public Vector2 valueDelta
		{
			get
			{
				return this.value - this.valuePrev;
			}
		}

		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06002B4F RID: 11087 RVA: 0x0002143B File Offset: 0x0001F63B
		public Vector2 rawValue
		{
			get
			{
				return new Vector2((this._xAxis != null) ? this._xAxis.value : 0f, (this._yAxis != null) ? this._yAxis.value : 0f);
			}
		}

		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x06002B50 RID: 11088 RVA: 0x00021476 File Offset: 0x0001F676
		public Vector2 rawValuePrev
		{
			get
			{
				return new Vector2((this._xAxis != null) ? this._xAxis.valuePrev : 0f, (this._yAxis != null) ? this._yAxis.valuePrev : 0f);
			}
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06002B51 RID: 11089 RVA: 0x000214B1 File Offset: 0x0001F6B1
		public Vector2 rawValueDelta
		{
			get
			{
				return this.rawValue - this.rawValuePrev;
			}
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x06002B52 RID: 11090 RVA: 0x000214C4 File Offset: 0x0001F6C4
		internal Vector2 rawZero
		{
			get
			{
				return new Vector2((this._xAxis != null) ? this._xAxis.rawZero : 0f, (this._yAxis != null) ? this._yAxis.rawZero : 0f);
			}
		}

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x06002B53 RID: 11091 RVA: 0x0009C57C File Offset: 0x0009A77C
		// (remove) Token: 0x06002B54 RID: 11092 RVA: 0x0009C5B4 File Offset: 0x0009A7B4
		private event StandaloneAxis2D.ValueChangedEventHandler _ValueChangedEvent;

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x06002B55 RID: 11093 RVA: 0x000214FF File Offset: 0x0001F6FF
		// (remove) Token: 0x06002B56 RID: 11094 RVA: 0x00021508 File Offset: 0x0001F708
		public event StandaloneAxis2D.ValueChangedEventHandler ValueChangedEvent
		{
			add
			{
				this._ValueChangedEvent += value;
			}
			remove
			{
				this._ValueChangedEvent -= value;
			}
		}

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x06002B57 RID: 11095 RVA: 0x0009C5EC File Offset: 0x0009A7EC
		// (remove) Token: 0x06002B58 RID: 11096 RVA: 0x0009C624 File Offset: 0x0009A824
		private event StandaloneAxis2D.ValueChangedEventHandler _RawValueChangedEvent;

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x06002B59 RID: 11097 RVA: 0x00021511 File Offset: 0x0001F711
		// (remove) Token: 0x06002B5A RID: 11098 RVA: 0x0002151A File Offset: 0x0001F71A
		public event StandaloneAxis2D.ValueChangedEventHandler RawValueChangedEvent
		{
			add
			{
				this._RawValueChangedEvent += value;
			}
			remove
			{
				this._RawValueChangedEvent -= value;
			}
		}

		// Token: 0x06002B5B RID: 11099 RVA: 0x00021523 File Offset: 0x0001F723
		internal StandaloneAxis2D()
		{
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x00021553 File Offset: 0x0001F753
		internal StandaloneAxis2D(StandaloneAxis A_1, StandaloneAxis A_2)
		{
			this._xAxis = A_1;
			this._yAxis = A_2;
		}

		// Token: 0x06002B5D RID: 11101 RVA: 0x0009C65C File Offset: 0x0009A85C
		public void SetRawValue(float x, float y)
		{
			bool allowEvents = this._allowEvents;
			this._allowEvents = false;
			if (this._xAxis != null)
			{
				this._xAxis.SetRawValue(x);
			}
			if (this._yAxis != null)
			{
				this._yAxis.SetRawValue(y);
			}
			this._allowEvents = allowEvents;
			this.EvalAndSendValueChangeEvents();
		}

		// Token: 0x06002B5E RID: 11102 RVA: 0x00021591 File Offset: 0x0001F791
		public void SetRawValue(Vector2 value)
		{
			this.SetRawValue(value.x, value.y);
		}

		// Token: 0x06002B5F RID: 11103 RVA: 0x0009C6AC File Offset: 0x0009A8AC
		public void Clear()
		{
			bool allowEvents = this._allowEvents;
			this._allowEvents = false;
			if (this._xAxis != null)
			{
				this._xAxis.Clear();
			}
			if (this._yAxis != null)
			{
				this._yAxis.Clear();
			}
			this._allowEvents = allowEvents;
			this.EvalAndSendValueChangeEvents();
		}

		// Token: 0x06002B60 RID: 11104 RVA: 0x000215A5 File Offset: 0x0001F7A5
		internal void Initialize()
		{
			this.Subscribe();
		}

		// Token: 0x06002B61 RID: 11105 RVA: 0x000215AD File Offset: 0x0001F7AD
		internal void Deinitialize()
		{
			this.Unsubscribe();
		}

		// Token: 0x06002B62 RID: 11106 RVA: 0x0009C6FC File Offset: 0x0009A8FC
		private void EvalAndSendValueChangeEvents()
		{
			if (this._allowEvents)
			{
				return;
			}
			Vector2 rawValueDelta = this.rawValueDelta;
			if (!MathTools.ApproximatelyZero(rawValueDelta.x) && !MathTools.ApproximatelyZero(rawValueDelta.y) && this._RawValueChangedEvent != null)
			{
				this._RawValueChangedEvent(this.rawValue);
			}
			Vector2 valueDelta = this.valueDelta;
			if (!MathTools.ApproximatelyZero(valueDelta.x) && !MathTools.ApproximatelyZero(valueDelta.y) && this._ValueChangedEvent != null)
			{
				this._ValueChangedEvent(this.value);
			}
		}

		// Token: 0x06002B63 RID: 11107 RVA: 0x0009C788 File Offset: 0x0009A988
		private void Subscribe()
		{
			this.Unsubscribe();
			if (this._xAxis != null)
			{
				this._xAxis.AxisValueChangedEvent += this.OnAxisValueChanged;
				this._xAxis.RawAxisValueChangedEvent += this.OnAxisRawValueChanged;
			}
			if (this._yAxis != null)
			{
				this._yAxis.AxisValueChangedEvent += this.OnAxisValueChanged;
				this._yAxis.RawAxisValueChangedEvent += this.OnAxisRawValueChanged;
			}
		}

		// Token: 0x06002B64 RID: 11108 RVA: 0x0009C808 File Offset: 0x0009AA08
		private void Unsubscribe()
		{
			if (this._xAxis != null)
			{
				this._xAxis.AxisValueChangedEvent -= this.OnAxisValueChanged;
				this._xAxis.RawAxisValueChangedEvent -= this.OnAxisRawValueChanged;
			}
			if (this._yAxis != null)
			{
				this._yAxis.AxisValueChangedEvent -= this.OnAxisValueChanged;
				this._yAxis.RawAxisValueChangedEvent -= this.OnAxisRawValueChanged;
			}
		}

		// Token: 0x06002B65 RID: 11109 RVA: 0x0009C884 File Offset: 0x0009AA84
		private Vector2 GetCalibratedValue(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (this._calibration == null)
			{
				return Vector2.zero;
			}
			AxisCalibration xAxis2;
			float valueRawX;
			if (xAxis != null)
			{
				xAxis2 = xAxis.calibration;
				valueRawX = xAxis.valueRaw;
			}
			else
			{
				xAxis2 = null;
				valueRawX = 0f;
			}
			AxisCalibration yAxis2;
			float valueRawY;
			if (yAxis != null)
			{
				yAxis2 = yAxis.calibration;
				valueRawY = yAxis.valueRaw;
			}
			else
			{
				yAxis2 = null;
				valueRawY = 0f;
			}
			return this._calibration.GetCalibrated2DValue(valueRawX, valueRawY, xAxis2, yAxis2);
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x0009C8E4 File Offset: 0x0009AAE4
		private Vector2 GetCalibratedValuePrev(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (this._calibration == null)
			{
				return Vector2.zero;
			}
			AxisCalibration xAxis2;
			float valueRawX;
			if (xAxis != null)
			{
				xAxis2 = xAxis.calibration;
				valueRawX = xAxis.valueRawPrev;
			}
			else
			{
				xAxis2 = null;
				valueRawX = 0f;
			}
			AxisCalibration yAxis2;
			float valueRawY;
			if (yAxis != null)
			{
				yAxis2 = yAxis.calibration;
				valueRawY = yAxis.valueRawPrev;
			}
			else
			{
				yAxis2 = null;
				valueRawY = 0f;
			}
			return this._calibration.GetCalibrated2DValue(valueRawX, valueRawY, xAxis2, yAxis2);
		}

		// Token: 0x06002B67 RID: 11111 RVA: 0x000215B5 File Offset: 0x0001F7B5
		private void OnAxisValueChanged(float value)
		{
			if (this._allowEvents)
			{
				return;
			}
			if (this._ValueChangedEvent != null)
			{
				this._ValueChangedEvent(this.value);
			}
		}

		// Token: 0x06002B68 RID: 11112 RVA: 0x000215D9 File Offset: 0x0001F7D9
		private void OnAxisRawValueChanged(float value)
		{
			if (this._allowEvents)
			{
				return;
			}
			if (this._RawValueChangedEvent != null)
			{
				this._RawValueChangedEvent(this.rawValue);
			}
		}

		// Token: 0x06002B69 RID: 11113 RVA: 0x000215FD File Offset: 0x0001F7FD
		internal static StandaloneAxis2D CreateRelative()
		{
			return new StandaloneAxis2D(StandaloneAxis.CreateRelative(), StandaloneAxis.CreateRelative())
			{
				calibration = 
				{
					deadZoneType = DeadZone2DType.Radial,
					sensitivityType = AxisSensitivity2DType.Radial
				}
			};
		}

		// Token: 0x040018B8 RID: 6328
		[Tooltip("Contains calibration settings for the 2D axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Axis2DCalibration _calibration = new Axis2DCalibration();

		// Token: 0x040018B9 RID: 6329
		[Tooltip("The X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _xAxis = new StandaloneAxis();

		// Token: 0x040018BA RID: 6330
		[Tooltip("The Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _yAxis = new StandaloneAxis();

		// Token: 0x040018BB RID: 6331
		private bool _allowEvents = true;

		// Token: 0x02000434 RID: 1076
		// (Invoke) Token: 0x06002B6B RID: 11115
		[CustomObfuscation(rename = false)]
		public delegate void ValueChangedEventHandler(Vector2 value);
	}
}
