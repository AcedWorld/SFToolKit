using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	// Token: 0x02000144 RID: 324
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class HardwareControllerMap_Game
	{
		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
		public DeviceLocalizationInfo deviceLocalizationInfo
		{
			get
			{
				return this.KvZrnXKkYcnCPiNwpbsheIolWqMR;
			}
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x000515F0 File Offset: 0x0004F7F0
		public HardwareControllerMap_Game(string A_1, DeviceLocalizationInfo A_2, int A_3, ControllerElementIdentifier[] A_4, int[] A_5, int[] A_6, AxisCalibrationData[] A_7, AxisRange[] A_8, HardwareAxisInfo[] A_9, HardwareButtonInfo[] A_10, HardwareJoystickMap.CompoundElement[] A_11) : this(A_1, A_2, A_4, A_5, A_6, A_7, A_8, A_9, A_10, A_11)
		{
			this.customControllerSourceId = A_3;
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x0005161C File Offset: 0x0004F81C
		public HardwareControllerMap_Game(string A_1, DeviceLocalizationInfo A_2, HardwareControllerMapIdentifier A_3, JoystickType[] A_4, ControllerElementIdentifier[] A_5, int[] A_6, int[] A_7, AxisCalibrationData[] A_8, AxisRange[] A_9, HardwareAxisInfo[] A_10, HardwareButtonInfo[] A_11, HardwareJoystickMap.CompoundElement[] A_12) : this(A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_10, A_11, A_12)
		{
			this.hardwareMapIdentifier = A_3;
			if (A_4 == null)
			{
				this.joystickTypes = new JoystickType[1];
				return;
			}
			this.joystickTypes = ArrayTools.ShallowCopy<JoystickType>(A_4);
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00051668 File Offset: 0x0004F868
		public HardwareControllerMap_Game(string A_1, HardwareControllerMapIdentifier A_2, ControllerElementIdentifier[] A_3, int[] A_4, int[] A_5, AxisCalibrationData[] A_6, AxisRange[] A_7, HardwareAxisInfo[] A_8, HardwareButtonInfo[] A_9, HardwareJoystickMap.CompoundElement[] A_10) : this(A_1, string.Equals(A_1, "Keyboard", StringComparison.OrdinalIgnoreCase) ? new DeviceLocalizationInfo(ControllerType.Keyboard, false, Consts.hardwareTypeGuid_universalKeyboard, new List<string>
		{
			"keyboard"
		}, null) : (string.Equals(A_1, "Mouse", StringComparison.OrdinalIgnoreCase) ? new DeviceLocalizationInfo(ControllerType.Mouse, false, Consts.hardwareTypeGuid_universalMouse, new List<string>
		{
			"mouse"
		}, null) : new DeviceLocalizationInfo()), A_2, null, A_3, A_4, A_5, A_6, A_7, A_8, A_9, A_10)
		{
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x000516EC File Offset: 0x0004F8EC
		private HardwareControllerMap_Game(string A_1, DeviceLocalizationInfo A_2, ControllerElementIdentifier[] A_3, int[] A_4, int[] A_5, AxisCalibrationData[] A_6, AxisRange[] A_7, HardwareAxisInfo[] A_8, HardwareButtonInfo[] A_9, HardwareJoystickMap.CompoundElement[] A_10)
		{
			this.controllerName = A_1;
			this.KvZrnXKkYcnCPiNwpbsheIolWqMR = A_2;
			if (this.KvZrnXKkYcnCPiNwpbsheIolWqMR == null)
			{
				this.KvZrnXKkYcnCPiNwpbsheIolWqMR = new DeviceLocalizationInfo();
			}
			this.KvZrnXKkYcnCPiNwpbsheIolWqMR.FinishRuntimeSetup();
			bool flag = this.KvZrnXKkYcnCPiNwpbsheIolWqMR.controllerType != ControllerType.Keyboard && this.KvZrnXKkYcnCPiNwpbsheIolWqMR.controllerType != ControllerType.Mouse;
			for (int i = 0; i < A_3.Length; i++)
			{
				if (A_3[i] != null)
				{
					if (flag)
					{
						ControllerElementIdentifier controllerElementIdentifier;
						if (ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.AAnvbotNUfhOvbMtAftzlaSEOgdi(this.KvZrnXKkYcnCPiNwpbsheIolWqMR, A_3[i], out controllerElementIdentifier))
						{
							A_3[i] = controllerElementIdentifier;
							goto IL_A8;
						}
						ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.WeTjQiPEGeZSGwUzJoLXpXILycBJ(this.KvZrnXKkYcnCPiNwpbsheIolWqMR, A_3[i]);
					}
					A_3[i].FinishRuntimeSetup(this.KvZrnXKkYcnCPiNwpbsheIolWqMR, this.KvZrnXKkYcnCPiNwpbsheIolWqMR.controllerType);
				}
				IL_A8:;
			}
			this.elementIdentifierCount = ((A_3 != null) ? A_3.Length : 0);
			int num = (A_4 != null) ? A_4.Length : 0;
			int num2 = (A_5 != null) ? A_5.Length : 0;
			A_10 = ArrayTools.DeepClone<HardwareJoystickMap.CompoundElement>(A_10);
			this.compoundElements = A_10;
			this.compoundElementCount = ((A_10 != null) ? A_10.Length : 0);
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			for (int j = 0; j < this.compoundElementCount; j++)
			{
				if (A_10[j] != null)
				{
					CompoundControllerElementType type = A_10[j].type;
					if (type != CompoundControllerElementType.Axis2D)
					{
						if (type != CompoundControllerElementType.DPad)
						{
							if (type == CompoundControllerElementType.Hat)
							{
								num4++;
								list2.Add(A_10[j].elementIdentifier);
								HardwareJoystickMap.CompoundElement.SortHatElementsClockwise(A_10[j]);
							}
						}
						else
						{
							num5++;
							list3.Add(A_10[j].elementIdentifier);
						}
					}
					else
					{
						num3++;
						list.Add(A_10[j].elementIdentifier);
					}
				}
			}
			int[] array = list.ToArray();
			int[] array2 = list2.ToArray();
			int[] array3 = list3.ToArray();
			this.elementIdentifiers = new ADictionary<int, ControllerElementIdentifier>(this.elementIdentifierCount);
			this.elementIdentifiers_cache = new ControllerElementIdentifier[this.elementIdentifierCount];
			this.buttonElementIdentifiers_cache = new ControllerElementIdentifier[num];
			this.axisElementIdentifiers_cache = new ControllerElementIdentifier[num2];
			this.axis2DElementIdentifiers_cache = new ControllerElementIdentifier[num3];
			this.hatElementIdentifiers_cache = new ControllerElementIdentifier[num4];
			this.dpadElementIdentifiers_cache = new ControllerElementIdentifier[num5];
			this.elementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(this.elementIdentifiers_cache);
			this.buttonElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(this.buttonElementIdentifiers_cache);
			this.axisElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(this.axisElementIdentifiers_cache);
			this.axis2DElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(this.axis2DElementIdentifiers_cache);
			this.hatElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(this.hatElementIdentifiers_cache);
			this.dpadElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(this.dpadElementIdentifiers_cache);
			for (int k = 0; k < this.elementIdentifierCount; k++)
			{
				this.elementIdentifiers_cache[k] = A_3[k];
				this.elementIdentifiers.Add(A_3[k].id, A_3[k]);
			}
			for (int l = 0; l < num; l++)
			{
				int num6 = this.YrRWcNFuNXLITFYFFKkvLBZxFeBl(A_3, A_4[l]);
				if (num6 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					this.buttonElementIdentifiers_cache[l] = A_3[num6];
				}
			}
			for (int m = 0; m < num2; m++)
			{
				int num7 = this.YrRWcNFuNXLITFYFFKkvLBZxFeBl(A_3, A_5[m]);
				if (num7 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					this.axisElementIdentifiers_cache[m] = A_3[num7];
				}
			}
			for (int n = 0; n < num3; n++)
			{
				int num8 = this.YrRWcNFuNXLITFYFFKkvLBZxFeBl(A_3, array[n]);
				if (num8 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					this.axis2DElementIdentifiers_cache[n] = A_3[num8];
				}
			}
			for (int num9 = 0; num9 < num4; num9++)
			{
				int num10 = this.YrRWcNFuNXLITFYFFKkvLBZxFeBl(A_3, array2[num9]);
				if (num10 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					this.hatElementIdentifiers_cache[num9] = A_3[num10];
				}
			}
			for (int num11 = 0; num11 < num5; num11++)
			{
				int num12 = this.YrRWcNFuNXLITFYFFKkvLBZxFeBl(A_3, array3[num11]);
				if (num12 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					this.dpadElementIdentifiers_cache[num11] = A_3[num12];
				}
			}
			this.buttonElementIdentifierIds = A_4;
			this.axisElementIdentifierIds = A_5;
			this.axis2DElementIdentifierIds = array;
			this.hatElementIdentifierIds = array2;
			this.dpadElementIdentifierIds = array3;
			this.elementIdentifierCount = ((this.elementIdentifiers != null) ? this.elementIdentifiers.Count : 0);
			this.buttonCount = ((A_4 != null) ? A_4.Length : 0);
			this.axisCount = ((A_5 != null) ? A_5.Length : 0);
			this.axis2DCount = num3;
			this.hatCount = num4;
			this.dpadCount = num5;
			this.hwAxisCalibrationData = A_6;
			this.hwAxisRanges = A_7;
			this.hwAxisInfo = A_8;
			this.hwButtonInfo = A_9;
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00051B84 File Offset: 0x0004FD84
		public string GetElementIdentifierName(int elementIdentifierId)
		{
			ControllerElementIdentifier controllerElementIdentifier;
			if (!this.elementIdentifiers.TryGetValue(elementIdentifierId, out controllerElementIdentifier))
			{
				return string.Empty;
			}
			return controllerElementIdentifier.name;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00051BB0 File Offset: 0x0004FDB0
		public string GetElementIdentifierPositiveName(int elementIdentifierId)
		{
			ControllerElementIdentifier controllerElementIdentifier;
			if (!this.elementIdentifiers.TryGetValue(elementIdentifierId, out controllerElementIdentifier))
			{
				return string.Empty;
			}
			return controllerElementIdentifier.positiveName;
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00051BDC File Offset: 0x0004FDDC
		public string GetElementIdentifierNegativeName(int elementIdentifierId)
		{
			ControllerElementIdentifier controllerElementIdentifier;
			if (!this.elementIdentifiers.TryGetValue(elementIdentifierId, out controllerElementIdentifier))
			{
				return string.Empty;
			}
			return controllerElementIdentifier.negativeName;
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00051C08 File Offset: 0x0004FE08
		public int GetAxisIndex(int elementIdentifierId)
		{
			for (int i = 0; i < this.axisCount; i++)
			{
				if (this.axisElementIdentifierIds[i] == elementIdentifierId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00051C34 File Offset: 0x0004FE34
		public int GetAxisIndex(string elementIdentifierName)
		{
			if (elementIdentifierName == null || elementIdentifierName == string.Empty)
			{
				return -1;
			}
			int count = this.elementIdentifiers.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.elementIdentifiers_cache[i].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
				{
					return this.GetAxisIndex(this.elementIdentifiers_cache[i].id);
				}
			}
			return -1;
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x00051C98 File Offset: 0x0004FE98
		public int GetButtonIndex(int elementIdentifierId)
		{
			for (int i = 0; i < this.buttonCount; i++)
			{
				if (this.buttonElementIdentifierIds[i] == elementIdentifierId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00051CC4 File Offset: 0x0004FEC4
		public int GetButtonIndex(string elementIdentifierName)
		{
			if (elementIdentifierName == null || elementIdentifierName == string.Empty)
			{
				return -1;
			}
			int count = this.elementIdentifiers.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.elementIdentifiers_cache[i].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
				{
					return this.GetButtonIndex(this.elementIdentifiers_cache[i].id);
				}
			}
			return -1;
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00051D28 File Offset: 0x0004FF28
		public ControllerElementIdentifier GetElementIdentifierById(int id)
		{
			int count = this.elementIdentifiers.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.elementIdentifiers_cache[i].id == id)
				{
					return this.elementIdentifiers_cache[i];
				}
			}
			return null;
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00051D68 File Offset: 0x0004FF68
		public ControllerElementIdentifier GetButtonElementIdentifierById(int id)
		{
			int num = this.buttonCount;
			for (int i = 0; i < num; i++)
			{
				if (this.buttonElementIdentifierIds[i] == id)
				{
					return this.buttonElementIdentifiers_cache[i];
				}
			}
			return null;
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00051DA0 File Offset: 0x0004FFA0
		public ControllerElementIdentifier GetAxisElementIdentifierById(int id)
		{
			int num = this.axisCount;
			for (int i = 0; i < num; i++)
			{
				if (this.axisElementIdentifierIds[i] == id)
				{
					return this.axisElementIdentifiers_cache[i];
				}
			}
			return null;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00051DD8 File Offset: 0x0004FFD8
		public HardwareJoystickMap.CompoundElement GetAxis2DData(int index)
		{
			if (this.compoundElements == null)
			{
				return null;
			}
			int num = 0;
			for (int i = 0; i < this.compoundElements.Length; i++)
			{
				if (this.compoundElements[i] != null && this.compoundElements[i].type == CompoundControllerElementType.Axis2D)
				{
					if (num == index)
					{
						return this.compoundElements[i];
					}
					num++;
				}
			}
			return null;
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00051E30 File Offset: 0x00050030
		public HardwareJoystickMap.CompoundElement GetHatData(int index)
		{
			if (this.compoundElements == null)
			{
				return null;
			}
			int num = 0;
			for (int i = 0; i < this.compoundElements.Length; i++)
			{
				if (this.compoundElements[i] != null && this.compoundElements[i].type == CompoundControllerElementType.Hat)
				{
					if (num == index)
					{
						return this.compoundElements[i];
					}
					num++;
				}
			}
			return null;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00051E8C File Offset: 0x0005008C
		public HardwareJoystickMap.CompoundElement GetDPadData(int index)
		{
			if (this.compoundElements == null)
			{
				return null;
			}
			int num = 0;
			for (int i = 0; i < this.compoundElements.Length; i++)
			{
				if (this.compoundElements[i] != null && this.compoundElements[i].type == CompoundControllerElementType.DPad)
				{
					if (num == index)
					{
						return this.compoundElements[i];
					}
					num++;
				}
			}
			return null;
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x0000CCA8 File Offset: 0x0000AEA8
		public ControllerElementType GetElementType(int elementIdentifierId)
		{
			if (!this.elementIdentifiers.ContainsKey(elementIdentifierId))
			{
				return ControllerElementType.Button;
			}
			return this.elementIdentifiers[elementIdentifierId].elementType;
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00051EE8 File Offset: 0x000500E8
		public bool TryGetCompoundElementMemberCombinedLocalizedName(IList<ActionElementMap> aems, out string result)
		{
			result = null;
			if (aems == null || this.compoundElements == null || aems.Count == 0)
			{
				return false;
			}
			int count = aems.Count;
			for (int i = 0; i < this.compoundElements.Length; i++)
			{
				HardwareJoystickMap.CompoundElement compoundElement = this.compoundElements[i];
				if (compoundElement != null)
				{
					int num = 0;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aems[j];
						if (actionElementMap != null && ArrayTools.IndexOf(compoundElement.componentElementIdentifiers, actionElementMap.elementIdentifierId) >= 0)
						{
							num++;
						}
					}
					if (num == count)
					{
						ControllerElementIdentifier elementIdentifierById = this.GetElementIdentifierById(compoundElement.elementIdentifier);
						if (elementIdentifierById != null)
						{
							int num2;
							HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv hcwfMpHltpcskGDfEnRYPhylkJyv = HardwareControllerMap_Game.yssaaYBRhZscqeOYVPXhYtusosEqA(compoundElement, elementIdentifierById, aems, out num2);
							if (hcwfMpHltpcskGDfEnRYPhylkJyv != HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.FoundIndex)
							{
								if (hcwfMpHltpcskGDfEnRYPhylkJyv == HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement)
								{
									result = elementIdentifierById.name;
								}
							}
							else if (num2 >= 0)
							{
								result = elementIdentifierById.GetCompoundElementSpecialName(num2);
							}
							if (!string.IsNullOrEmpty(result))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00051FCC File Offset: 0x000501CC
		public bool TryGetCompoundElementMemberCombinedGlyph(IList<ActionElementMap> aems, bool getGlyph, bool getFinalKey, out object glyphResult, out string finalKey)
		{
			glyphResult = null;
			finalKey = null;
			if (aems == null || this.compoundElements == null || aems.Count == 0)
			{
				return false;
			}
			int count = aems.Count;
			for (int i = 0; i < this.compoundElements.Length; i++)
			{
				HardwareJoystickMap.CompoundElement compoundElement = this.compoundElements[i];
				if (compoundElement != null)
				{
					int num = 0;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aems[j];
						if (actionElementMap != null && ArrayTools.IndexOf(compoundElement.componentElementIdentifiers, actionElementMap.elementIdentifierId) >= 0)
						{
							num++;
						}
					}
					if (num == count)
					{
						ControllerElementIdentifier elementIdentifierById = this.GetElementIdentifierById(compoundElement.elementIdentifier);
						if (elementIdentifierById != null)
						{
							int num2;
							HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv hcwfMpHltpcskGDfEnRYPhylkJyv = HardwareControllerMap_Game.yssaaYBRhZscqeOYVPXhYtusosEqA(compoundElement, elementIdentifierById, aems, out num2);
							if (hcwfMpHltpcskGDfEnRYPhylkJyv != HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.FoundIndex)
							{
								if (hcwfMpHltpcskGDfEnRYPhylkJyv == HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement)
								{
									if (getGlyph)
									{
										glyphResult = elementIdentifierById.glyph;
									}
									if (getFinalKey)
									{
										finalKey = elementIdentifierById.GetFinalGlyphKey(AxisRange.Full);
									}
								}
							}
							else if (num2 >= 0)
							{
								if (getGlyph)
								{
									glyphResult = elementIdentifierById.GetCompoundElementSpecialGlyph(num2);
								}
								if (getFinalKey)
								{
									finalKey = elementIdentifierById.GetCompoundElementSpecialFinalGlyphKey(num2);
								}
							}
							if (getGlyph && glyphResult != null)
							{
								return true;
							}
							if (getFinalKey && !string.IsNullOrEmpty(finalKey))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x000520E4 File Offset: 0x000502E4
		private int YrRWcNFuNXLITFYFFKkvLBZxFeBl(ControllerElementIdentifier[] A_1, int A_2)
		{
			if (A_1 == null)
			{
				return -1;
			}
			int result = -1;
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].id == A_2)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00052118 File Offset: 0x00050318
		private static HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv yssaaYBRhZscqeOYVPXhYtusosEqA(HardwareJoystickMap.CompoundElement A_0, ControllerElementIdentifier A_1, IList<ActionElementMap> A_2, out int A_3)
		{
			A_3 = -1;
			if (A_0 == null || A_1 == null || A_2 == null)
			{
				return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
			}
			if (A_0.componentElementIdentifiers == null)
			{
				return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
			}
			if (A_1.elementType != ControllerElementType.CompoundElement)
			{
				return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
			}
			int count = A_2.Count;
			VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc wBVDEckclaCUdHrHdLHuTDoxJWNc;
			VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ zqaUXWpANFaPfdXDRaVZzDjduZzZ;
			ControllerElementIdentifier.ToElementNameLocalizerTypes(A_1.elementType, A_1.compoundElementType, out wBVDEckclaCUdHrHdLHuTDoxJWNc, out zqaUXWpANFaPfdXDRaVZzDjduZzZ);
			CompoundControllerElementType compoundElementType = A_1.compoundElementType;
			if (compoundElementType != CompoundControllerElementType.Axis2D)
			{
				if (compoundElementType == CompoundControllerElementType.DPad)
				{
					int num = 0;
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap = A_2[i];
						if (actionElementMap != null)
						{
							if (actionElementMap.elementType != ControllerElementType.Button)
							{
								return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
							}
							int num2 = ArrayTools.IndexOf(A_0.componentElementIdentifiers, actionElementMap.elementIdentifierId);
							if (num2 < 0)
							{
								return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
							}
							num |= 1 << num2;
						}
					}
					VhrRjYDSXtDmPGPepEmutTeotlnr.jviFgsInzaMyYlcNYoKGKgoWfIrjb jviFgsInzaMyYlcNYoKGKgoWfIrjb;
					if (num != 5)
					{
						if (num != 10)
						{
							if (num == 15)
							{
								return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
							}
						}
						else if (VhrRjYDSXtDmPGPepEmutTeotlnr.hczCJHcgfDwQYCcSAvrCLwkpWdhHA(zqaUXWpANFaPfdXDRaVZzDjduZzZ, out jviFgsInzaMyYlcNYoKGKgoWfIrjb))
						{
							A_3 = jviFgsInzaMyYlcNYoKGKgoWfIrjb.iESpVwWgeIPhOoVlZgcNNaDxOVlw(AxisDirection.Horizontal);
							if (A_3 >= 0)
							{
								return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.FoundIndex;
							}
							return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
						}
					}
					else if (VhrRjYDSXtDmPGPepEmutTeotlnr.hczCJHcgfDwQYCcSAvrCLwkpWdhHA(zqaUXWpANFaPfdXDRaVZzDjduZzZ, out jviFgsInzaMyYlcNYoKGKgoWfIrjb))
					{
						A_3 = jviFgsInzaMyYlcNYoKGKgoWfIrjb.iESpVwWgeIPhOoVlZgcNNaDxOVlw(AxisDirection.Vertical);
						if (A_3 >= 0)
						{
							return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.FoundIndex;
						}
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
					}
				}
			}
			else
			{
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap = A_2[j];
					if (actionElementMap != null)
					{
						if (actionElementMap.elementType != ControllerElementType.Axis)
						{
							return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
						}
						int num9 = ArrayTools.IndexOf(A_0.componentElementIdentifiers, actionElementMap.elementIdentifierId);
						if (num9 < 0)
						{
							return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
						}
						if (actionElementMap.axisRange == AxisRange.Full)
						{
							if (num9 != 0)
							{
								if (num9 != 1)
								{
									return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
								}
								num4++;
							}
							else
							{
								num3++;
							}
						}
						else if (num9 != 0)
						{
							if (num9 != 1)
							{
								return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
							}
							if (actionElementMap.axisRange == AxisRange.Positive)
							{
								num7++;
							}
							else if (actionElementMap.axisRange == AxisRange.Negative)
							{
								num8++;
							}
						}
						else if (actionElementMap.axisRange == AxisRange.Positive)
						{
							num6++;
						}
						else if (actionElementMap.axisRange == AxisRange.Negative)
						{
							num5++;
						}
					}
				}
				if (num3 == 1)
				{
					if (num4 == 1)
					{
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
					}
					if (num7 == 1 && num8 == 1)
					{
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
					}
				}
				else if (num4 == 1)
				{
					if (num3 == 1)
					{
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
					}
					if (num5 == 1 && num6 == 1)
					{
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
					}
				}
				else if (num5 == 1 && num6 == 1)
				{
					if (num7 == 1 && num8 == 1)
					{
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
					}
					VhrRjYDSXtDmPGPepEmutTeotlnr.jviFgsInzaMyYlcNYoKGKgoWfIrjb jviFgsInzaMyYlcNYoKGKgoWfIrjb;
					if (VhrRjYDSXtDmPGPepEmutTeotlnr.hczCJHcgfDwQYCcSAvrCLwkpWdhHA(zqaUXWpANFaPfdXDRaVZzDjduZzZ, out jviFgsInzaMyYlcNYoKGKgoWfIrjb))
					{
						A_3 = jviFgsInzaMyYlcNYoKGKgoWfIrjb.iESpVwWgeIPhOoVlZgcNNaDxOVlw(AxisDirection.Horizontal);
						if (A_3 >= 0)
						{
							return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.FoundIndex;
						}
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
					}
				}
				else if (num7 == 1 && num8 == 1)
				{
					if (num5 == 1 && num6 == 1)
					{
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.IsWholeElement;
					}
					VhrRjYDSXtDmPGPepEmutTeotlnr.jviFgsInzaMyYlcNYoKGKgoWfIrjb jviFgsInzaMyYlcNYoKGKgoWfIrjb;
					if (VhrRjYDSXtDmPGPepEmutTeotlnr.hczCJHcgfDwQYCcSAvrCLwkpWdhHA(zqaUXWpANFaPfdXDRaVZzDjduZzZ, out jviFgsInzaMyYlcNYoKGKgoWfIrjb))
					{
						A_3 = jviFgsInzaMyYlcNYoKGKgoWfIrjb.iESpVwWgeIPhOoVlZgcNNaDxOVlw(AxisDirection.Vertical);
						if (A_3 >= 0)
						{
							return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.FoundIndex;
						}
						return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
					}
				}
			}
			return HardwareControllerMap_Game.HCWfMpHltpcskGDfEnRYPhylkJyv.Error;
		}

		// Token: 0x04000873 RID: 2163
		public readonly string controllerName;

		// Token: 0x04000874 RID: 2164
		public readonly HardwareControllerMapIdentifier hardwareMapIdentifier;

		// Token: 0x04000875 RID: 2165
		public readonly int customControllerSourceId;

		// Token: 0x04000876 RID: 2166
		public readonly ADictionary<int, ControllerElementIdentifier> elementIdentifiers;

		// Token: 0x04000877 RID: 2167
		public readonly ControllerElementIdentifier[] elementIdentifiers_cache;

		// Token: 0x04000878 RID: 2168
		public readonly ControllerElementIdentifier[] buttonElementIdentifiers_cache;

		// Token: 0x04000879 RID: 2169
		public readonly ControllerElementIdentifier[] axisElementIdentifiers_cache;

		// Token: 0x0400087A RID: 2170
		public readonly ControllerElementIdentifier[] axis2DElementIdentifiers_cache;

		// Token: 0x0400087B RID: 2171
		public readonly ControllerElementIdentifier[] hatElementIdentifiers_cache;

		// Token: 0x0400087C RID: 2172
		public readonly ControllerElementIdentifier[] dpadElementIdentifiers_cache;

		// Token: 0x0400087D RID: 2173
		public readonly IList<ControllerElementIdentifier> elementIdentifiers_readOnly;

		// Token: 0x0400087E RID: 2174
		public readonly IList<ControllerElementIdentifier> buttonElementIdentifiers_readOnly;

		// Token: 0x0400087F RID: 2175
		public readonly IList<ControllerElementIdentifier> axisElementIdentifiers_readOnly;

		// Token: 0x04000880 RID: 2176
		public readonly IList<ControllerElementIdentifier> axis2DElementIdentifiers_readOnly;

		// Token: 0x04000881 RID: 2177
		public readonly IList<ControllerElementIdentifier> hatElementIdentifiers_readOnly;

		// Token: 0x04000882 RID: 2178
		public readonly IList<ControllerElementIdentifier> dpadElementIdentifiers_readOnly;

		// Token: 0x04000883 RID: 2179
		public readonly int[] buttonElementIdentifierIds;

		// Token: 0x04000884 RID: 2180
		public readonly int[] axisElementIdentifierIds;

		// Token: 0x04000885 RID: 2181
		public readonly int[] axis2DElementIdentifierIds;

		// Token: 0x04000886 RID: 2182
		public readonly int[] hatElementIdentifierIds;

		// Token: 0x04000887 RID: 2183
		public readonly int[] dpadElementIdentifierIds;

		// Token: 0x04000888 RID: 2184
		public readonly int elementIdentifierCount;

		// Token: 0x04000889 RID: 2185
		public readonly int axisCount;

		// Token: 0x0400088A RID: 2186
		public readonly int buttonCount;

		// Token: 0x0400088B RID: 2187
		public readonly int compoundElementCount;

		// Token: 0x0400088C RID: 2188
		public readonly int axis2DCount;

		// Token: 0x0400088D RID: 2189
		public readonly int hatCount;

		// Token: 0x0400088E RID: 2190
		public readonly int dpadCount;

		// Token: 0x0400088F RID: 2191
		public readonly JoystickType[] joystickTypes;

		// Token: 0x04000890 RID: 2192
		public readonly AxisCalibrationData[] hwAxisCalibrationData;

		// Token: 0x04000891 RID: 2193
		public readonly AxisRange[] hwAxisRanges;

		// Token: 0x04000892 RID: 2194
		public readonly HardwareAxisInfo[] hwAxisInfo;

		// Token: 0x04000893 RID: 2195
		public readonly HardwareButtonInfo[] hwButtonInfo;

		// Token: 0x04000894 RID: 2196
		public readonly HardwareJoystickMap.CompoundElement[] compoundElements;

		// Token: 0x04000895 RID: 2197
		private readonly DeviceLocalizationInfo KvZrnXKkYcnCPiNwpbsheIolWqMR;

		// Token: 0x02000145 RID: 325
		private enum HCWfMpHltpcskGDfEnRYPhylkJyv
		{
			// Token: 0x04000897 RID: 2199
			Error,
			// Token: 0x04000898 RID: 2200
			FoundIndex,
			// Token: 0x04000899 RID: 2201
			IsWholeElement
		}
	}
}
