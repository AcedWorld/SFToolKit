using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003E3 RID: 995
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Component Controls/Tilt Control")]
	[Serializable]
	public sealed class TiltControl : CustomControllerControl
	{
		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x060027D7 RID: 10199 RVA: 0x0001DD17 File Offset: 0x0001BF17
		// (set) Token: 0x060027D8 RID: 10200 RVA: 0x0001DD1F File Offset: 0x0001BF1F
		public TiltControl.TiltDirection axesToUse
		{
			get
			{
				return this._allowedTiltDirections;
			}
			set
			{
				if (this._allowedTiltDirections == value)
				{
					return;
				}
				this.sUvEzkBQemIlxqVDmlhJovTQwfrQA(value);
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x060027D9 RID: 10201 RVA: 0x0001DD38 File Offset: 0x0001BF38
		public CustomControllerElementTargetSetForFloat horizontalTiltCustomControllerElement
		{
			get
			{
				return this._horizontalTiltCustomControllerElement;
			}
		}

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x060027DA RID: 10202 RVA: 0x0001DD40 File Offset: 0x0001BF40
		// (set) Token: 0x060027DB RID: 10203 RVA: 0x0001DD48 File Offset: 0x0001BF48
		public float horizontalTiltLimit
		{
			get
			{
				return this._horizontalTiltLimit;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 180f);
				if (this._horizontalTiltLimit == value)
				{
					return;
				}
				this._horizontalTiltLimit = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x060027DC RID: 10204 RVA: 0x0001DD73 File Offset: 0x0001BF73
		// (set) Token: 0x060027DD RID: 10205 RVA: 0x0001DD7B File Offset: 0x0001BF7B
		public float horizontalRestAngle
		{
			get
			{
				return this._horizontalRestAngle;
			}
			set
			{
				value = MathTools.Clamp(value, -90f, 90f);
				if (this._horizontalRestAngle == value)
				{
					return;
				}
				this._horizontalRestAngle = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x060027DE RID: 10206 RVA: 0x0001DDA6 File Offset: 0x0001BFA6
		public CustomControllerElementTargetSetForFloat forwardTiltCustomControllerElement
		{
			get
			{
				return this._forwardTiltCustomControllerElement;
			}
		}

		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x060027DF RID: 10207 RVA: 0x0001DDAE File Offset: 0x0001BFAE
		// (set) Token: 0x060027E0 RID: 10208 RVA: 0x0001DDB6 File Offset: 0x0001BFB6
		public float forwardTiltLimit
		{
			get
			{
				return this._forwardTiltLimit;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 180f);
				if (this._forwardTiltLimit == value)
				{
					return;
				}
				this._forwardTiltLimit = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x060027E1 RID: 10209 RVA: 0x0001DDE1 File Offset: 0x0001BFE1
		// (set) Token: 0x060027E2 RID: 10210 RVA: 0x0001DDE9 File Offset: 0x0001BFE9
		public float forwardRestAngle
		{
			get
			{
				return this._forwardRestAngle;
			}
			set
			{
				value = MathTools.Clamp(value, -90f, 90f);
				if (this._forwardRestAngle == value)
				{
					return;
				}
				this._forwardRestAngle = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000960 RID: 2400
		// (get) Token: 0x060027E3 RID: 10211 RVA: 0x0001DE14 File Offset: 0x0001C014
		public AxisCalibration horizontalAxisCalibration
		{
			get
			{
				return this._axis2D.xAxis.calibration;
			}
		}

		// Token: 0x17000961 RID: 2401
		// (get) Token: 0x060027E4 RID: 10212 RVA: 0x0001DE26 File Offset: 0x0001C026
		public AxisCalibration verticalAxisCalibration
		{
			get
			{
				return this._axis2D.yAxis.calibration;
			}
		}

		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x060027E5 RID: 10213 RVA: 0x0001DE38 File Offset: 0x0001C038
		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType
		{
			get
			{
				return this._axis2D.calibration;
			}
		}

		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x060027E6 RID: 10214 RVA: 0x0001DE38 File Offset: 0x0001C038
		public Axis2DCalibration axis2DCalibration
		{
			get
			{
				return this._axis2D.calibration;
			}
		}

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x060027E7 RID: 10215 RVA: 0x0001DE45 File Offset: 0x0001C045
		internal StandaloneAxis2D ueCdwsCcZnOoFyCEDRkqolCAcFqmA
		{
			get
			{
				return this._axis2D;
			}
		}

		// Token: 0x17000965 RID: 2405
		// (get) Token: 0x060027E8 RID: 10216 RVA: 0x0001DE4D File Offset: 0x0001C04D
		private Vector3 gymqZctoRKHUkDQBNNZOoDcdSdfQ
		{
			get
			{
				if (this._getAccelerationValue == null)
				{
					return Input.acceleration;
				}
				return this._getAccelerationValue();
			}
		}

		// Token: 0x060027E9 RID: 10217 RVA: 0x0009631C File Offset: 0x0009451C
		[CustomObfuscation(rename = false)]
		internal TiltControl()
		{
		}

		// Token: 0x060027EA RID: 10218 RVA: 0x0001DE68 File Offset: 0x0001C068
		public void SetAccelerationSourceCallback(Func<Vector3> callback)
		{
			this._getAccelerationValue = callback;
		}

		// Token: 0x060027EB RID: 10219 RVA: 0x00096374 File Offset: 0x00094574
		public void SetRestOrientation()
		{
			Vector3 vector = this.gymqZctoRKHUkDQBNNZOoDcdSdfQ;
			this.horizontalRestAngle = Mathf.Atan2(vector.x, -vector.y) * 57.29578f * -1f;
			this.forwardRestAngle = Mathf.Atan2(vector.z, -vector.y) * 57.29578f * -1f;
		}

		// Token: 0x060027EC RID: 10220 RVA: 0x0001DE71 File Offset: 0x0001C071
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.wKiwctTAHLuQCqgXqTyIbKOlSBVl();
		}

		// Token: 0x060027ED RID: 10221 RVA: 0x0001DE88 File Offset: 0x0001C088
		internal bool QlZccrFeoDqxAOVNlrTNYoyvUwso()
		{
			if (!base.ffHwuTrmnsLzfzVoVLncxktdhwuQ())
			{
				return false;
			}
			this.wKiwctTAHLuQCqgXqTyIbKOlSBVl();
			return true;
		}

		// Token: 0x060027EE RID: 10222 RVA: 0x0001DE9B File Offset: 0x0001C09B
		internal void kHmypmfEuDqakfNKthNkedvlYRFVA()
		{
			base.AoHwozRsjiUmhnUZxZinlrstaSL();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.BspngsFJOJMRYXEeGAVvfnGMPGjs();
		}

		// Token: 0x060027EF RID: 10223 RVA: 0x000963D0 File Offset: 0x000945D0
		internal void OFSdNRXaMLMtVjfLHjvpxnZKSDcx()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			if (this._useFAxis)
			{
				base.WiKtlIjluObCctWuxDsizpItcifHA(this._forwardTiltCustomControllerElement, this._axis2D.yAxis.value, this._axis2D.yAxis.buttonActivationThreshold);
			}
			if (this._useHAxis)
			{
				base.WiKtlIjluObCctWuxDsizpItcifHA(this._horizontalTiltCustomControllerElement, this._axis2D.xAxis.value, this._axis2D.xAxis.buttonActivationThreshold);
			}
		}

		// Token: 0x060027F0 RID: 10224 RVA: 0x00096458 File Offset: 0x00094658
		public override void ClearValue()
		{
			this._axis2D.xAxis.Clear();
			this._axis2D.yAxis.Clear();
			if (this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._horizontalTiltCustomControllerElement);
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._forwardTiltCustomControllerElement);
			}
		}

		// Token: 0x060027F1 RID: 10225 RVA: 0x000964B0 File Offset: 0x000946B0
		private void BspngsFJOJMRYXEeGAVvfnGMPGjs()
		{
			if (this._useHAxis)
			{
				float rawValue;
				if (this.gymqZctoRKHUkDQBNNZOoDcdSdfQ == Vector3.zero)
				{
					rawValue = 0f;
				}
				else
				{
					float value = Mathf.Atan2(this.gymqZctoRKHUkDQBNNZOoDcdSdfQ.x, -this.gymqZctoRKHUkDQBNNZOoDcdSdfQ.y) * 57.29578f + this._horizontalRestAngle;
					rawValue = Mathf.InverseLerp(-this._horizontalTiltLimit, this._horizontalTiltLimit, value) * 2f - 1f;
				}
				this._axis2D.xAxis.SetRawValue(rawValue);
			}
			if (this._useFAxis)
			{
				float num;
				if (this.gymqZctoRKHUkDQBNNZOoDcdSdfQ == Vector3.zero)
				{
					num = 0f;
				}
				else
				{
					float value2 = Mathf.Atan2(this.gymqZctoRKHUkDQBNNZOoDcdSdfQ.z, -this.gymqZctoRKHUkDQBNNZOoDcdSdfQ.y) * 57.29578f + this._forwardRestAngle;
					num = Mathf.InverseLerp(-this._forwardTiltLimit, this._forwardTiltLimit, value2) * 2f - 1f;
				}
				this._axis2D.yAxis.SetRawValue(-num);
			}
		}

		// Token: 0x060027F2 RID: 10226 RVA: 0x000965B8 File Offset: 0x000947B8
		private void wKiwctTAHLuQCqgXqTyIbKOlSBVl()
		{
			this.sUvEzkBQemIlxqVDmlhJovTQwfrQA(this._allowedTiltDirections);
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			if (this._useHAxis)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ValidateElements(this._horizontalTiltCustomControllerElement);
			}
			if (this._useFAxis)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ValidateElements(this._forwardTiltCustomControllerElement);
			}
		}

		// Token: 0x060027F3 RID: 10227 RVA: 0x00096610 File Offset: 0x00094810
		private void sUvEzkBQemIlxqVDmlhJovTQwfrQA(TiltControl.TiltDirection A_1)
		{
			bool flag = A_1 == TiltControl.TiltDirection.Both || A_1 == TiltControl.TiltDirection.Horizontal;
			if (this._useHAxis != flag)
			{
				this._useHAxis = flag;
				if (!flag && this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
				{
					base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._horizontalTiltCustomControllerElement);
				}
			}
			bool flag2 = A_1 == TiltControl.TiltDirection.Both || A_1 == TiltControl.TiltDirection.Forward;
			if (this._useFAxis != flag2)
			{
				this._useFAxis = flag2;
				if (!flag2 && this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
				{
					base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._forwardTiltCustomControllerElement);
				}
			}
			this._allowedTiltDirections = A_1;
		}

		// Token: 0x04001713 RID: 5907
		private const float maxFullTiltAngle = 180f;

		// Token: 0x04001714 RID: 5908
		private const float maxAngleOffset = 90f;

		// Token: 0x04001715 RID: 5909
		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TiltControl.TiltDirection _allowedTiltDirections;

		// Token: 0x04001716 RID: 5910
		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		// Token: 0x04001717 RID: 5911
		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _horizontalTiltLimit = 25f;

		// Token: 0x04001718 RID: 5912
		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _horizontalRestAngle;

		// Token: 0x04001719 RID: 5913
		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		// Token: 0x0400171A RID: 5914
		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _forwardTiltLimit = 25f;

		// Token: 0x0400171B RID: 5915
		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _forwardRestAngle = 40f;

		// Token: 0x0400171C RID: 5916
		[Tooltip("The underlying 2D axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		// Token: 0x0400171D RID: 5917
		private bool _useHAxis;

		// Token: 0x0400171E RID: 5918
		private bool _useFAxis;

		// Token: 0x0400171F RID: 5919
		private Func<Vector3> _getAccelerationValue;

		// Token: 0x020003E4 RID: 996
		public enum TiltDirection
		{
			// Token: 0x04001721 RID: 5921
			Both,
			// Token: 0x04001722 RID: 5922
			Horizontal,
			// Token: 0x04001723 RID: 5923
			Forward
		}
	}
}
