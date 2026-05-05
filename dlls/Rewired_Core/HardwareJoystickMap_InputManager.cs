using System;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils;

namespace Rewired
{
	// Token: 0x02000146 RID: 326
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class HardwareJoystickMap_InputManager
	{
		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x0000CCCB File Offset: 0x0000AECB
		public DeviceLocalizationInfo deviceLocalizationInfo
		{
			get
			{
				return this.LqPZaMbjYGlmrnDrAZIhptYjubhf;
			}
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x0005239C File Offset: 0x0005059C
		public HardwareJoystickMap_InputManager(HardwareControllerMapIdentifier A_1, JoystickType[] A_2, DeviceLocalizationInfo A_3, HardwareJoystickMap.Platform A_4, string A_5, int A_6, int A_7, int A_8, HardwareJoystickMap.CompoundElement[] A_9)
		{
			this.hardwareMapIdentifier = A_1;
			this.joystickTypes = A_2;
			this.map = A_4;
			this.controllerName = A_5;
			this.LqPZaMbjYGlmrnDrAZIhptYjubhf = ((A_3 != null) ? A_3 : new DeviceLocalizationInfo(ControllerType.Joystick, false, A_1.guid, null, null));
			this.buttonCount = A_6;
			this.axisCount = A_7;
			this.elementIdentifiers = new ControllerElementIdentifier[A_8];
			this.compoundElements = A_9;
			this.isUnknownController = (A_1.guid == Guid.Empty);
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x00052424 File Offset: 0x00050624
		public HardwareControllerMap_Game ToGameHardwareControllerMap()
		{
			JoystickType[] array = ArrayTools.ShallowCopy<JoystickType>(this.joystickTypes);
			int[] array2;
			int[] array3;
			this.map.GetGameElementIdentifierIdMappings(out array2, out array3);
			AxisCalibrationData[] axisCalibrationData = this.map.GetAxisCalibrationData();
			if (this.axisCount > 0 && (axisCalibrationData == null || axisCalibrationData.Length != this.axisCount))
			{
				Logger.LogError("Axis mismatch!");
				return null;
			}
			AxisRange[] array4;
			HardwareAxisInfo[] array5;
			this.map.GetAxisData(out array4, out array5);
			if (array4 == null || array4.Length != this.axisCount)
			{
				Logger.LogWarning("Invalid AxisRange array returned by HardwareJoystickMap!");
				if (array4 != null)
				{
					AxisRange[] array6 = new AxisRange[this.axisCount];
					for (int i = 0; i < MathTools.Min(array4.Length, this.axisCount); i++)
					{
						array6[i] = array4[i];
					}
					array4 = array6;
				}
				else
				{
					array4 = new AxisRange[this.axisCount];
				}
			}
			if (array5 == null || array5.Length != this.axisCount)
			{
				Logger.LogWarning("Invalid HardwareAxisInfo array returned by HardwareJoystickMap!");
				if (array5 != null)
				{
					HardwareAxisInfo[] array7 = new HardwareAxisInfo[this.axisCount];
					for (int j = 0; j < this.axisCount; j++)
					{
						if (j < array5.Length)
						{
							array7[j] = array5[j];
						}
						if (array7[j] == null)
						{
							array7[j] = new HardwareAxisInfo();
						}
					}
					array5 = array7;
				}
				else
				{
					array5 = new HardwareAxisInfo[this.axisCount];
					for (int k = 0; k < this.axisCount; k++)
					{
						array5[k] = new HardwareAxisInfo();
					}
				}
			}
			HardwareButtonInfo[] array8;
			this.map.GetButtonData(out array8);
			if (array8 == null || array8.Length != this.buttonCount)
			{
				Logger.LogWarning("Invalid HardwareButtonInfo array returned by HardwareJoystickMap!");
				if (array8 != null)
				{
					HardwareButtonInfo[] array9 = new HardwareButtonInfo[this.buttonCount];
					for (int l = 0; l < this.buttonCount; l++)
					{
						if (l < array8.Length)
						{
							array9[l] = array8[l];
						}
						if (array9[l] == null)
						{
							array9[l] = new HardwareButtonInfo();
						}
					}
					array8 = array9;
				}
				else
				{
					array8 = new HardwareButtonInfo[this.buttonCount];
					for (int m = 0; m < this.buttonCount; m++)
					{
						array8[m] = new HardwareButtonInfo();
					}
				}
			}
			return new HardwareControllerMap_Game(this.controllerName, this.LqPZaMbjYGlmrnDrAZIhptYjubhf, this.hardwareMapIdentifier, array, this.elementIdentifiers, array2, array3, axisCalibrationData, array4, array5, array8, this.compoundElements);
		}

		// Token: 0x0400089A RID: 2202
		public string controllerName;

		// Token: 0x0400089B RID: 2203
		public readonly HardwareControllerMapIdentifier hardwareMapIdentifier;

		// Token: 0x0400089C RID: 2204
		public readonly HardwareJoystickMap.Platform map;

		// Token: 0x0400089D RID: 2205
		public readonly int buttonCount;

		// Token: 0x0400089E RID: 2206
		public readonly int axisCount;

		// Token: 0x0400089F RID: 2207
		public readonly ControllerElementIdentifier[] elementIdentifiers;

		// Token: 0x040008A0 RID: 2208
		public readonly HardwareJoystickMap.CompoundElement[] compoundElements;

		// Token: 0x040008A1 RID: 2209
		public bool useSystemName;

		// Token: 0x040008A2 RID: 2210
		public readonly bool isUnknownController;

		// Token: 0x040008A3 RID: 2211
		public readonly JoystickType[] joystickTypes;

		// Token: 0x040008A4 RID: 2212
		private readonly DeviceLocalizationInfo LqPZaMbjYGlmrnDrAZIhptYjubhf;
	}
}
