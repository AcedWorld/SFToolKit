using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000148 RID: 328
	[Serializable]
	public sealed class InputBehavior
	{
		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x0000CFCB File Offset: 0x0000B1CB
		// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x0000CFD3 File Offset: 0x0000B1D3
		public int id
		{
			get
			{
				return this._id;
			}
			internal set
			{
				this._id = value;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x0000CFDC File Offset: 0x0000B1DC
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x0000CFE4 File Offset: 0x0000B1E4
		public string name
		{
			get
			{
				return this._name;
			}
			internal set
			{
				this._name = value;
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x0000CFED File Offset: 0x0000B1ED
		// (set) Token: 0x06000DFC RID: 3580 RVA: 0x0000CFF5 File Offset: 0x0000B1F5
		public float joystickAxisSensitivity
		{
			get
			{
				return this._joystickAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._joystickAxisSensitivity = value;
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000DFD RID: 3581 RVA: 0x0000D010 File Offset: 0x0000B210
		// (set) Token: 0x06000DFE RID: 3582 RVA: 0x0000D018 File Offset: 0x0000B218
		public bool digitalAxisSimulation
		{
			get
			{
				return this._digitalAxisSimulation;
			}
			set
			{
				this._digitalAxisSimulation = value;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000DFF RID: 3583 RVA: 0x0000D021 File Offset: 0x0000B221
		// (set) Token: 0x06000E00 RID: 3584 RVA: 0x0000D029 File Offset: 0x0000B229
		public bool digitalAxisSnap
		{
			get
			{
				return this._digitalAxisSnap;
			}
			set
			{
				this._digitalAxisSnap = value;
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000E01 RID: 3585 RVA: 0x0000D032 File Offset: 0x0000B232
		// (set) Token: 0x06000E02 RID: 3586 RVA: 0x0000D03A File Offset: 0x0000B23A
		public bool digitalAxisInstantReverse
		{
			get
			{
				return this._digitalAxisInstantReverse;
			}
			set
			{
				this._digitalAxisInstantReverse = value;
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000E03 RID: 3587 RVA: 0x0000D043 File Offset: 0x0000B243
		// (set) Token: 0x06000E04 RID: 3588 RVA: 0x0000D04B File Offset: 0x0000B24B
		public float digitalAxisGravity
		{
			get
			{
				return this._digitalAxisGravity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._digitalAxisGravity = value;
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000E05 RID: 3589 RVA: 0x0000D066 File Offset: 0x0000B266
		// (set) Token: 0x06000E06 RID: 3590 RVA: 0x0000D06E File Offset: 0x0000B26E
		public float digitalAxisSensitivity
		{
			get
			{
				return this._digitalAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._digitalAxisSensitivity = value;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000E07 RID: 3591 RVA: 0x0000D089 File Offset: 0x0000B289
		// (set) Token: 0x06000E08 RID: 3592 RVA: 0x0000D091 File Offset: 0x0000B291
		public MouseXYAxisMode mouseXYAxisMode
		{
			get
			{
				return this._mouseXYAxisMode;
			}
			set
			{
				this._mouseXYAxisMode = value;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000E09 RID: 3593 RVA: 0x0000D09A File Offset: 0x0000B29A
		// (set) Token: 0x06000E0A RID: 3594 RVA: 0x0000D0A2 File Offset: 0x0000B2A2
		public MouseOtherAxisMode mouseOtherAxisMode
		{
			get
			{
				return this._mouseOtherAxisMode;
			}
			set
			{
				this._mouseOtherAxisMode = value;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x0000D0AB File Offset: 0x0000B2AB
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x0000D0B3 File Offset: 0x0000B2B3
		public float mouseXYAxisSensitivity
		{
			get
			{
				return this._mouseXYAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._mouseXYAxisSensitivity = value;
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x0000D0CE File Offset: 0x0000B2CE
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x0000D0D6 File Offset: 0x0000B2D6
		public MouseXYAxisDeltaCalc mouseXYAxisDeltaCalc
		{
			get
			{
				return this._mouseXYAxisDeltaCalc;
			}
			set
			{
				this._mouseXYAxisDeltaCalc = value;
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0000D0DF File Offset: 0x0000B2DF
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x0000D0E7 File Offset: 0x0000B2E7
		public float mouseOtherAxisSensitivity
		{
			get
			{
				return this._mouseOtherAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._mouseOtherAxisSensitivity = value;
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x0000D102 File Offset: 0x0000B302
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x0000D10A File Offset: 0x0000B30A
		public float customControllerAxisSensitivity
		{
			get
			{
				return this._customControllerAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._customControllerAxisSensitivity = value;
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x0000D125 File Offset: 0x0000B325
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x0000D12D File Offset: 0x0000B32D
		public float buttonDoublePressSpeed
		{
			get
			{
				return this._buttonDoublePressSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				this._buttonDoublePressSpeed = value;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000E15 RID: 3605 RVA: 0x0000D148 File Offset: 0x0000B348
		// (set) Token: 0x06000E16 RID: 3606 RVA: 0x0000D150 File Offset: 0x0000B350
		public float buttonShortPressTime
		{
			get
			{
				return this._buttonShortPressTime;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				this._buttonShortPressTime = value;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x0000D16B File Offset: 0x0000B36B
		// (set) Token: 0x06000E18 RID: 3608 RVA: 0x0000D173 File Offset: 0x0000B373
		public float buttonShortPressExpiresIn
		{
			get
			{
				return this._buttonShortPressExpiresIn;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				this._buttonShortPressExpiresIn = value;
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x0000D18E File Offset: 0x0000B38E
		// (set) Token: 0x06000E1A RID: 3610 RVA: 0x0000D196 File Offset: 0x0000B396
		public float buttonLongPressTime
		{
			get
			{
				return this._buttonLongPressTime;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				this._buttonLongPressTime = value;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x0000D1B1 File Offset: 0x0000B3B1
		// (set) Token: 0x06000E1C RID: 3612 RVA: 0x0000D1B9 File Offset: 0x0000B3B9
		public float buttonLongPressExpiresIn
		{
			get
			{
				return this._buttonLongPressExpiresIn;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				this._buttonLongPressExpiresIn = value;
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x0000D1D4 File Offset: 0x0000B3D4
		// (set) Token: 0x06000E1E RID: 3614 RVA: 0x0000D1DC File Offset: 0x0000B3DC
		public float buttonDeadZone
		{
			get
			{
				return this._buttonDeadZone;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 1f);
				this._buttonDeadZone = value;
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x0000D1F7 File Offset: 0x0000B3F7
		// (set) Token: 0x06000E20 RID: 3616 RVA: 0x0000D1FF File Offset: 0x0000B3FF
		public float buttonDownBuffer
		{
			get
			{
				return this._buttonDownBuffer;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				this._buttonDownBuffer = value;
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x0000D21A File Offset: 0x0000B41A
		// (set) Token: 0x06000E22 RID: 3618 RVA: 0x0000D222 File Offset: 0x0000B422
		public float buttonRepeatRate
		{
			get
			{
				return this._buttonRepeatRate;
			}
			set
			{
				value = MathTools.Max(0.001f, value);
				this._buttonRepeatRate = value;
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x0000D238 File Offset: 0x0000B438
		// (set) Token: 0x06000E24 RID: 3620 RVA: 0x0000D240 File Offset: 0x0000B440
		public float buttonRepeatDelay
		{
			get
			{
				return this._buttonRepeatDelay;
			}
			set
			{
				value = MathTools.Max(0f, value);
				this._buttonRepeatDelay = value;
			}
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x0005270C File Offset: 0x0005090C
		public InputBehavior()
		{
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x0000D256 File Offset: 0x0000B456
		public InputBehavior(InputBehavior A_1) : this()
		{
			InputBehavior.sOpNVlmWBUkYiyMnDmCYjLqYwLmR(A_1, this, true);
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00052760 File Offset: 0x00050960
		public string ToXmlString()
		{
			try
			{
				return this.GOfPQTUJplXLVdsxMvpVlwfZXmhm().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing InputBehavior to XML. " + ex.Message);
			}
			return string.Empty;
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x000527AC File Offset: 0x000509AC
		public bool ImportXmlString(string xmlString)
		{
			bool result;
			try
			{
				this.DhUsqASPqUNmZWtfhlaNsAYHCrcU(SerializedObject.FromXml(base.GetType(), xmlString));
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error reading InputBehavior from XML. " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x000527FC File Offset: 0x000509FC
		public string ToJsonString()
		{
			try
			{
				return this.GOfPQTUJplXLVdsxMvpVlwfZXmhm().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing InputBehavior to JSON. " + ex.Message);
			}
			return string.Empty;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00052848 File Offset: 0x00050A48
		public bool ImportJsonString(string jsonString)
		{
			bool result;
			try
			{
				this.DhUsqASPqUNmZWtfhlaNsAYHCrcU(SerializedObject.FromJson(base.GetType(), jsonString));
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error reading InputBehavior from JSON. " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x0000D266 File Offset: 0x0000B466
		public bool ImportData(InputBehavior inputBehavior)
		{
			if (inputBehavior == null)
			{
				return false;
			}
			InputBehavior.sOpNVlmWBUkYiyMnDmCYjLqYwLmR(inputBehavior, this, false);
			return true;
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x0000D276 File Offset: 0x0000B476
		public InputBehavior Clone()
		{
			return new InputBehavior(this);
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00052898 File Offset: 0x00050A98
		public void Reset()
		{
			InputBehavior inputBehavior = ReInput.mapping.CgOzhEpnKagvLdqSMPNiejaceEgNA(this._id);
			if (inputBehavior == null)
			{
				return;
			}
			InputBehavior.sOpNVlmWBUkYiyMnDmCYjLqYwLmR(inputBehavior, this, true);
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000528C4 File Offset: 0x00050AC4
		internal SerializedObject GOfPQTUJplXLVdsxMvpVlwfZXmhm()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add<int>("dataVersion", 5, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				icHQGefQbedChDWtubHCUkbucRzbb = "dataVersion",
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = 5.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				icHQGefQbedChDWtubHCUkbucRzbb = "id",
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = this._id.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xmlns",
				icHQGefQbedChDWtubHCUkbucRzbb = "xsi",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xsi",
				icHQGefQbedChDWtubHCUkbucRzbb = "schemaLocation",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = string.Format("{0} {1}{2}{3}{4}{5}", new object[]
				{
					"http://guavaman.com/rewired",
					"http://guavaman.com/schemas/rewired/",
					"1.4",
					"/",
					base.GetType().Name,
					".xsd"
				})
			});
			serializedObject.Add<int>("id", this._id, SerializedObject.FieldOptions.None);
			serializedObject.Add<string>("name", this._name, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("joystickAxisSensitivity", this._joystickAxisSensitivity, SerializedObject.FieldOptions.None);
			serializedObject.Add<bool>("digitalAxisSimulation", this._digitalAxisSimulation, SerializedObject.FieldOptions.None);
			serializedObject.Add<bool>("digitalAxisSnap", this._digitalAxisSnap, SerializedObject.FieldOptions.None);
			serializedObject.Add<bool>("digitalAxisInstantReverse", this._digitalAxisInstantReverse, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("digitalAxisGravity", this._digitalAxisGravity, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("digitalAxisSensitivity", this._digitalAxisSensitivity, SerializedObject.FieldOptions.None);
			serializedObject.Add<MouseXYAxisMode>("mouseXYAxisMode", this._mouseXYAxisMode, SerializedObject.FieldOptions.None);
			serializedObject.Add<MouseOtherAxisMode>("mouseOtherAxisMode", this._mouseOtherAxisMode, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("mouseXYAxisSensitivity", this._mouseXYAxisSensitivity, SerializedObject.FieldOptions.None);
			serializedObject.Add<MouseXYAxisDeltaCalc>("mouseXYAxisDeltaCalc", this._mouseXYAxisDeltaCalc, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("mouseOtherAxisSensitivity", this._mouseOtherAxisSensitivity, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("customControllerAxisSensitivity", this._customControllerAxisSensitivity, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonDoublePressSpeed", this._buttonDoublePressSpeed, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonShortPressTime", this._buttonShortPressTime, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonShortPressExpiresIn", this._buttonShortPressExpiresIn, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonLongPressTime", this._buttonLongPressTime, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonLongPressExpiresIn", this._buttonLongPressExpiresIn, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonDeadZone", this._buttonDeadZone, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonDownBuffer", this._buttonDownBuffer, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonRepeatRate", this._buttonRepeatRate, SerializedObject.FieldOptions.None);
			serializedObject.Add<float>("buttonRepeatDelay", this._buttonRepeatDelay, SerializedObject.FieldOptions.None);
			return serializedObject;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00052BB4 File Offset: 0x00050DB4
		internal void DhUsqASPqUNmZWtfhlaNsAYHCrcU(SerializedObject A_1)
		{
			this.Reset();
			A_1.TryGetDeserializedValueByRef<float>("joystickAxisSensitivity", ref this._joystickAxisSensitivity);
			A_1.TryGetDeserializedValueByRef<bool>("digitalAxisSimulation", ref this._digitalAxisSimulation);
			A_1.TryGetDeserializedValueByRef<bool>("digitalAxisSnap", ref this._digitalAxisSnap);
			A_1.TryGetDeserializedValueByRef<bool>("digitalAxisInstantReverse", ref this._digitalAxisInstantReverse);
			A_1.TryGetDeserializedValueByRef<float>("digitalAxisGravity", ref this._digitalAxisGravity);
			A_1.TryGetDeserializedValueByRef<float>("digitalAxisSensitivity", ref this._digitalAxisSensitivity);
			A_1.TryGetDeserializedValueByRef<MouseXYAxisMode>("mouseXYAxisMode", ref this._mouseXYAxisMode);
			A_1.TryGetDeserializedValueByRef<MouseOtherAxisMode>("mouseOtherAxisMode", ref this._mouseOtherAxisMode);
			A_1.TryGetDeserializedValueByRef<float>("mouseXYAxisSensitivity", ref this._mouseXYAxisSensitivity);
			A_1.TryGetDeserializedValueByRef<MouseXYAxisDeltaCalc>("mouseXYAxisDeltaCalc", ref this._mouseXYAxisDeltaCalc);
			A_1.TryGetDeserializedValueByRef<float>("mouseOtherAxisSensitivity", ref this._mouseOtherAxisSensitivity);
			A_1.TryGetDeserializedValueByRef<float>("customControllerAxisSensitivity", ref this._customControllerAxisSensitivity);
			A_1.TryGetDeserializedValueByRef<float>("buttonDoublePressSpeed", ref this._buttonDoublePressSpeed);
			A_1.TryGetDeserializedValueByRef<float>("buttonShortPressTime", ref this._buttonShortPressTime);
			A_1.TryGetDeserializedValueByRef<float>("buttonShortPressExpiresIn", ref this._buttonShortPressExpiresIn);
			A_1.TryGetDeserializedValueByRef<float>("buttonLongPressTime", ref this._buttonLongPressTime);
			A_1.TryGetDeserializedValueByRef<float>("buttonLongPressExpiresIn", ref this._buttonLongPressExpiresIn);
			A_1.TryGetDeserializedValueByRef<float>("buttonDeadZone", ref this._buttonDeadZone);
			A_1.TryGetDeserializedValueByRef<float>("buttonDownBuffer", ref this._buttonDownBuffer);
			A_1.TryGetDeserializedValueByRef<float>("buttonRepeatRate", ref this._buttonRepeatRate);
			A_1.TryGetDeserializedValueByRef<float>("buttonRepeatDelay", ref this._buttonRepeatDelay);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00052D44 File Offset: 0x00050F44
		private static void sOpNVlmWBUkYiyMnDmCYjLqYwLmR(InputBehavior A_0, InputBehavior A_1, bool A_2)
		{
			if (A_2)
			{
				A_1._id = A_0._id;
			}
			A_1._name = A_0._name;
			A_1._joystickAxisSensitivity = A_0._joystickAxisSensitivity;
			A_1._digitalAxisSimulation = A_0._digitalAxisSimulation;
			A_1._digitalAxisSnap = A_0._digitalAxisSnap;
			A_1._digitalAxisInstantReverse = A_0._digitalAxisInstantReverse;
			A_1._digitalAxisGravity = A_0._digitalAxisGravity;
			A_1._digitalAxisSensitivity = A_0._digitalAxisSensitivity;
			A_1._mouseXYAxisMode = A_0._mouseXYAxisMode;
			A_1._mouseOtherAxisMode = A_0._mouseOtherAxisMode;
			A_1._mouseXYAxisSensitivity = A_0._mouseXYAxisSensitivity;
			A_1._mouseOtherAxisSensitivity = A_0._mouseOtherAxisSensitivity;
			A_1._mouseXYAxisDeltaCalc = A_0._mouseXYAxisDeltaCalc;
			A_1._customControllerAxisSensitivity = A_0._customControllerAxisSensitivity;
			A_1._buttonDoublePressSpeed = A_0._buttonDoublePressSpeed;
			A_1._buttonShortPressTime = A_0._buttonShortPressTime;
			A_1._buttonShortPressExpiresIn = A_0._buttonShortPressExpiresIn;
			A_1._buttonLongPressTime = A_0._buttonLongPressTime;
			A_1._buttonLongPressExpiresIn = A_0._buttonLongPressExpiresIn;
			A_1._buttonDeadZone = A_0._buttonDeadZone;
			A_1._buttonDownBuffer = A_0._buttonDownBuffer;
			A_1._buttonRepeatRate = A_0._buttonRepeatRate;
			A_1._buttonRepeatDelay = A_0._buttonRepeatDelay;
		}

		// Token: 0x040008B4 RID: 2228
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		// Token: 0x040008B5 RID: 2229
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		// Token: 0x040008B6 RID: 2230
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _joystickAxisSensitivity = 1f;

		// Token: 0x040008B7 RID: 2231
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSimulation = true;

		// Token: 0x040008B8 RID: 2232
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSnap;

		// Token: 0x040008B9 RID: 2233
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisInstantReverse;

		// Token: 0x040008BA RID: 2234
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisGravity;

		// Token: 0x040008BB RID: 2235
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisSensitivity;

		// Token: 0x040008BC RID: 2236
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisMode _mouseXYAxisMode;

		// Token: 0x040008BD RID: 2237
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseOtherAxisMode _mouseOtherAxisMode;

		// Token: 0x040008BE RID: 2238
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _mouseXYAxisSensitivity;

		// Token: 0x040008BF RID: 2239
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisDeltaCalc _mouseXYAxisDeltaCalc;

		// Token: 0x040008C0 RID: 2240
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _mouseOtherAxisSensitivity;

		// Token: 0x040008C1 RID: 2241
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _customControllerAxisSensitivity = 1f;

		// Token: 0x040008C2 RID: 2242
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDoublePressSpeed;

		// Token: 0x040008C3 RID: 2243
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressTime = 0.25f;

		// Token: 0x040008C4 RID: 2244
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressExpiresIn;

		// Token: 0x040008C5 RID: 2245
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonLongPressTime = 1f;

		// Token: 0x040008C6 RID: 2246
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonLongPressExpiresIn;

		// Token: 0x040008C7 RID: 2247
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDeadZone;

		// Token: 0x040008C8 RID: 2248
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDownBuffer;

		// Token: 0x040008C9 RID: 2249
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonRepeatRate = 30f;

		// Token: 0x040008CA RID: 2250
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonRepeatDelay;
	}
}
