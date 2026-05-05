using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000383 RID: 899
	public sealed class HardwareJoystickTemplateMap : HardwareControllerTemplateMap, IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal, IHardwareControllerMap, IHardwareControllerMap_Internal
	{
		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x060024D3 RID: 9427 RVA: 0x0001B266 File Offset: 0x00019466
		public override Guid Guid
		{
			get
			{
				return StringTools.ToGuid(this.templateGuid);
			}
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x060024D4 RID: 9428 RVA: 0x0001B273 File Offset: 0x00019473
		public override string Key
		{
			get
			{
				return this.templateKey;
			}
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x060024D5 RID: 9429 RVA: 0x0001B27B File Offset: 0x0001947B
		public string ControllerName
		{
			get
			{
				return this.controllerName;
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x060024D6 RID: 9430 RVA: 0x0001B283 File Offset: 0x00019483
		public string ClassName
		{
			get
			{
				return this.className;
			}
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x060024D7 RID: 9431 RVA: 0x0001B28B File Offset: 0x0001948B
		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (this.elementIdentifiers == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elementIdentifiers.Length; i = num + 1)
				{
					yield return this.elementIdentifiers[i];
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x060024D8 RID: 9432 RVA: 0x0001B29B File Offset: 0x0001949B
		public int elementIdentifierCount
		{
			get
			{
				if (this.elementIdentifiers == null)
				{
					return 0;
				}
				return this.elementIdentifiers.Length;
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x060024D9 RID: 9433 RVA: 0x0001B2AF File Offset: 0x000194AF
		Guid IHardwareControllerMap_Internal.typeGuid
		{
			get
			{
				return this.Guid;
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x060024DA RID: 9434 RVA: 0x0001B273 File Offset: 0x00019473
		string IHardwareControllerMap_Internal.typeKey
		{
			get
			{
				return this.templateKey;
			}
		}

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x060024DB RID: 9435 RVA: 0x0000550E File Offset: 0x0000370E
		ControllerType IHardwareControllerMap_Internal.controllerType
		{
			get
			{
				return ControllerType.Joystick;
			}
		}

		// Token: 0x060024DC RID: 9436 RVA: 0x00090E58 File Offset: 0x0008F058
		[CustomObfuscation(rename = false)]
		public override ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			ControllerTemplateElementIdentifier[] array = this.elementIdentifiers;
			return HardwareJoystickTemplateMap.oCWzblfMOSbkQbShRbMmwWQpBuJgA(array, id);
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x0001B2B7 File Offset: 0x000194B7
		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			if (index < 0 || index >= this.elementIdentifiers.Length)
			{
				return null;
			}
			return this.elementIdentifiers[index];
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x00090E74 File Offset: 0x0008F074
		[CustomObfuscation(rename = false)]
		public override bool ContainsElementIdentifier(int id)
		{
			ControllerTemplateElementIdentifier[] array = this.elementIdentifiers;
			return HardwareJoystickTemplateMap.gcWKamMehrDIpoHgSvGCYKVkXltL(array, id);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x00090E90 File Offset: 0x0008F090
		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.elementIdentifiers[i].name;
			}
			return array;
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x00090ED8 File Offset: 0x0008F0D8
		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.elementIdentifiers[i].id;
			}
			return array;
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x00090F20 File Offset: 0x0008F120
		[CustomObfuscation(rename = false)]
		internal string[] GetElementIdentifierScriptingNames(bool useAlternate)
		{
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (useAlternate ? this.elementIdentifiers[i].alternateScriptingName : this.elementIdentifiers[i].scriptingName);
			}
			return array;
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x00090F78 File Offset: 0x0008F178
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			ids = EmptyObjects<int>.array;
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			if (num == 0)
			{
				return 0;
			}
			List<ControllerTemplateElementIdentifier> list = new List<ControllerTemplateElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (this.elementIdentifiers[i] != null && InputTools.IsMappableType(this.elementIdentifiers[i].elementType))
				{
					list.Add(this.elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].name;
				ids[j] = list[j].id;
			}
			return count;
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x0009103C File Offset: 0x0008F23C
		public int GetNonMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			ids = EmptyObjects<int>.array;
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			if (num == 0)
			{
				return 0;
			}
			List<ControllerTemplateElementIdentifier> list = new List<ControllerTemplateElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (this.elementIdentifiers[i] != null && !InputTools.IsMappableType(this.elementIdentifiers[i].elementType))
				{
					list.Add(this.elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].name;
				ids[j] = list[j].id;
			}
			return count;
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x00091100 File Offset: 0x0008F300
		public string[] GetJoystickNames()
		{
			int num = (this.joysticks != null) ? this.joysticks.Count : 0;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.joysticks[i].name;
			}
			return array;
		}

		// Token: 0x060024E5 RID: 9445 RVA: 0x0009114C File Offset: 0x0008F34C
		public int[] GetJoystickIds()
		{
			int num = (this.joysticks != null) ? this.joysticks.Count : 0;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.joysticks[i].id;
			}
			return array;
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x00091198 File Offset: 0x0008F398
		public Guid GetJoystickGuid(int joystickId)
		{
			if (this.joysticks == null)
			{
				return Guid.Empty;
			}
			for (int i = 0; i < this.joysticks.Count; i++)
			{
				if (this.joysticks[i].id == joystickId)
				{
					return StringTools.ToGuid(this.joysticks[i].joystickGuid);
				}
			}
			return Guid.Empty;
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x000911FC File Offset: 0x0008F3FC
		public int GetJoystickId(Guid guid)
		{
			for (int i = 0; i < this.joysticks.Count; i++)
			{
				if (StringTools.ToGuid(this.joysticks[i].joystickGuid) == guid)
				{
					return this.joysticks[i].id;
				}
			}
			return -1;
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x00091250 File Offset: 0x0008F450
		public string GetJoystickFileGuidString(int joystickId)
		{
			if (this.joysticks == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < this.joysticks.Count; i++)
			{
				if (this.joysticks[i].id == joystickId)
				{
					return this.joysticks[i].fileGuid;
				}
			}
			return string.Empty;
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x0001B2D2 File Offset: 0x000194D2
		[CustomObfuscation(rename = false)]
		internal HardwareJoystickTemplateMap.SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return this.specialElements;
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x000912AC File Offset: 0x0008F4AC
		internal bool aeoHOEfveLLngskiiVRagdYEWIqz(ControllerMap_Editor A_1, HardwareJoystickMap A_2, Guid A_3, out string A_4)
		{
			if (A_1 == null)
			{
				A_4 = "Template Map was null.";
				return false;
			}
			A_1.hardwareGuidString = A_3.ToString();
			HardwareJoystickTemplateMap.Entry entry = this.nOJwtKLzpEVivLUBRxbClsAiDqrK(A_3);
			if (entry == null)
			{
				string str = "Hardware guid not found in ControllerDataFiles: ";
				Guid guid = A_3;
				A_4 = str + guid.ToString() + "\nThis error should never happen. Please contact support.";
				return false;
			}
			List<ActionElementMap> actionElementMaps = A_1.actionElementMaps;
			using (TempListPool.TList<ActionElementMap> tlist = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tlist.list;
				using (TempListPool.TList<HardwareJoystickTemplateMap.ElementIdentifierMap> tlist2 = TempListPool.GetTList<HardwareJoystickTemplateMap.ElementIdentifierMap>())
				{
					List<HardwareJoystickTemplateMap.ElementIdentifierMap> list2 = tlist2.list;
					for (int i = 0; i < actionElementMaps.Count; i++)
					{
						list2.Clear();
						ActionElementMap actionElementMap = actionElementMaps[i];
						int elementIdentifierId = actionElementMap._elementIdentifierId;
						entry.GetElementIdentifierMaps(elementIdentifierId, list2);
						for (int j = 0; j < list2.Count; j++)
						{
							HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = list2[j];
							if (elementIdentifierMap != null && elementIdentifierMap.joystickId >= 0)
							{
								ActionElementMap actionElementMap2 = new ActionElementMap(actionElementMap);
								ActionElementMap actionElementMap3 = null;
								bool flag = false;
								ControllerTemplateElementIdentifier[] array = this.elementIdentifiers;
								int num = HardwareJoystickTemplateMap.TJrUuvqoAvfeKPZlqdmIuzLOflAx(array, elementIdentifierId);
								if (num >= 0 && num < this.elementIdentifiers.Length)
								{
									ControllerElementIdentifier elementIdentifier = A_2.GetElementIdentifier(elementIdentifierMap.joystickId);
									ControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = this.elementIdentifiers[num];
									if (elementIdentifier != null && controllerTemplateElementIdentifier_Editor != null)
									{
										ControllerTemplateElementType effectiveElementType = controllerTemplateElementIdentifier_Editor.effectiveElementType;
										if (!gRvITEHjKMrWaeGYEmAHofbpCtEU.OTBocvISlRKBAUnyQtOPzQbOOoit(effectiveElementType, elementIdentifier.elementType))
										{
											if (effectiveElementType == ControllerTemplateElementType.Axis && elementIdentifier.elementType == ControllerElementType.Button)
											{
												if (elementIdentifierMap.splitAxis)
												{
													if (actionElementMap2.axisType == AxisType.Normal && actionElementMap2._axisRange == AxisRange.Full)
													{
														actionElementMap3 = new ActionElementMap(actionElementMap2);
														actionElementMap3._elementType = ControllerElementType.Button;
														actionElementMap3._elementIdentifierId = elementIdentifierMap.joystickId2;
														if (actionElementMap2._invert)
														{
															actionElementMap2._axisContribution = Pole.Negative;
															actionElementMap3._axisContribution = Pole.Positive;
														}
														else
														{
															actionElementMap2._axisContribution = Pole.Positive;
															actionElementMap3._axisContribution = Pole.Negative;
														}
													}
													else if (actionElementMap2.axisType == AxisType.Split)
													{
														if (actionElementMap2._axisRange == AxisRange.Positive)
														{
															actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId;
														}
														else if (actionElementMap2._axisRange == AxisRange.Negative)
														{
															actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId2;
														}
														flag = true;
													}
												}
												actionElementMap2._elementType = ControllerElementType.Button;
											}
											else
											{
												if (effectiveElementType != ControllerTemplateElementType.Button || elementIdentifier.elementType != ControllerElementType.Axis)
												{
													throw new NotImplementedException();
												}
												actionElementMap2._axisRange = AxisRange.Positive;
												actionElementMap2._elementType = ControllerElementType.Axis;
											}
										}
									}
								}
								if (!flag)
								{
									actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId;
								}
								list.Add(actionElementMap2);
								if (actionElementMap3 != null)
								{
									list.Add(actionElementMap3);
								}
							}
						}
					}
				}
				actionElementMaps.Clear();
				ListTools.CopyTo<ActionElementMap>(list, actionElementMaps);
			}
			A_4 = null;
			return true;
		}

		// Token: 0x060024EB RID: 9451 RVA: 0x0009159C File Offset: 0x0008F79C
		internal COootOIiwXGzUSdmLyqHaOKMeIvB GLvdgqXJwQYPqEgAecqKhEHxbJyab()
		{
			int num = (this.joysticks != null) ? this.joysticks.Count : 0;
			List<HardwareJoystickTemplateMap.Entry> list = new List<HardwareJoystickTemplateMap.Entry>(num);
			for (int i = 0; i < num; i++)
			{
				if (this.joysticks[i] != null)
				{
					list.Add(new HardwareJoystickTemplateMap.Entry(this.joysticks[i]));
				}
			}
			ControllerTemplateElementIdentifier[] array = new ControllerTemplateElementIdentifier[(this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0];
			for (int j = 0; j < array.Length; j++)
			{
				if (this.elementIdentifiers[j] != null)
				{
					array[j] = new ControllerTemplateElementIdentifier(this.elementIdentifiers[j]);
				}
			}
			return new COootOIiwXGzUSdmLyqHaOKMeIvB(this, list, array);
		}

		// Token: 0x060024EC RID: 9452 RVA: 0x00091648 File Offset: 0x0008F848
		private HardwareJoystickTemplateMap.Entry nOJwtKLzpEVivLUBRxbClsAiDqrK(Guid A_1)
		{
			if (this.joysticks == null)
			{
				return null;
			}
			for (int i = 0; i < this.joysticks.Count; i++)
			{
				if (this.joysticks[i].JoystickGuid == A_1)
				{
					return this.joysticks[i];
				}
			}
			return null;
		}

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x060024ED RID: 9453 RVA: 0x0001B2DA File Offset: 0x000194DA
		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				if (this.elementIdentifiers == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elementIdentifiers.Length; i = num + 1)
				{
					yield return this.elementIdentifiers[i];
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x0001B2EA File Offset: 0x000194EA
		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return this.GetElementIdentifier(id);
		}

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x060024EF RID: 9455 RVA: 0x0001B27B File Offset: 0x0001947B
		string IHardwareControllerTemplateMap_Internal.name
		{
			get
			{
				return this.controllerName;
			}
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x060024F0 RID: 9456 RVA: 0x0001B2AF File Offset: 0x000194AF
		Guid IHardwareControllerTemplateMap_Internal.typeGuid
		{
			get
			{
				return this.Guid;
			}
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x060024F1 RID: 9457 RVA: 0x0001B273 File Offset: 0x00019473
		string IHardwareControllerTemplateMap_Internal.typeKey
		{
			get
			{
				return this.templateKey;
			}
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x0001B29B File Offset: 0x0001949B
		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			if (this.elementIdentifiers == null)
			{
				return 0;
			}
			return this.elementIdentifiers.Length;
		}

		// Token: 0x060024F3 RID: 9459 RVA: 0x0001B2F3 File Offset: 0x000194F3
		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
		{
			if (this.elementIdentifiers == null)
			{
				return null;
			}
			return this.elementIdentifiers[index];
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x0001B2EA File Offset: 0x000194EA
		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
		{
			return this.GetElementIdentifier(elementIdentifierId);
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x0009169C File Offset: 0x0008F89C
		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
		{
			if (this.specialElements == null)
			{
				return null;
			}
			for (int i = 0; i < this.specialElements.Length; i++)
			{
				if (this.specialElements[i] != null && this.specialElements[i].elementIdentifierId == id)
				{
					return this.specialElements[i];
				}
			}
			return null;
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x0001B307 File Offset: 0x00019507
		zzIYMvAnMtpiMJyIjwvHCSyknhJk IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
		{
			return HardwareJoystickTemplateMap.TTcMpmkxaXCfVuNtxqoHbBddRNYS(this, controller, elementIdentifierId, this.HFCckSlyTuDFRSaZWzjGmzTeAMBB);
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x0001B317 File Offset: 0x00019517
		zzIYMvAnMtpiMJyIjwvHCSyknhJk IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
		{
			return HardwareJoystickTemplateMap.oFdcjuhlnTvFnsPJrzRVSnTJgcMw(this, controller, elementIdentifierId, this.HFCckSlyTuDFRSaZWzjGmzTeAMBB);
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x060024F8 RID: 9464 RVA: 0x000916EC File Offset: 0x0008F8EC
		private Func<Guid, HardwareJoystickTemplateMap.Entry> HFCckSlyTuDFRSaZWzjGmzTeAMBB
		{
			get
			{
				Func<Guid, HardwareJoystickTemplateMap.Entry> result;
				if ((result = this.RxoOXBedeajkuBlbcqqbIMLKAhgJ) == null)
				{
					result = (this.RxoOXBedeajkuBlbcqqbIMLKAhgJ = new Func<Guid, HardwareJoystickTemplateMap.Entry>(this.nOJwtKLzpEVivLUBRxbClsAiDqrK));
				}
				return result;
			}
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x00091718 File Offset: 0x0008F918
		internal static zzIYMvAnMtpiMJyIjwvHCSyknhJk TTcMpmkxaXCfVuNtxqoHbBddRNYS(IHardwareControllerTemplateMap_Internal A_0, Controller A_1, int A_2, Func<Guid, HardwareJoystickTemplateMap.Entry> A_3)
		{
			if (A_0 == null)
			{
				return null;
			}
			if (A_1 == null)
			{
				return null;
			}
			if (A_3 == null)
			{
				return null;
			}
			IControllerTemplateElementIdentifier templateElementIdentifierById = A_0.GetTemplateElementIdentifierById(A_2);
			if (templateElementIdentifierById == null)
			{
				return null;
			}
			if (templateElementIdentifierById.elementType != ControllerTemplateElementType.Axis)
			{
				return null;
			}
			if (A_1 == null)
			{
				return null;
			}
			HardwareJoystickTemplateMap.Entry entry = A_3(A_1.legQjhUclFMVpVFTfXDlmJRWuUQj);
			if (entry == null)
			{
				return null;
			}
			List<HardwareJoystickTemplateMap.ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			if (elementIdentifierMappings == null)
			{
				return null;
			}
			int count = elementIdentifierMappings.Count;
			int i = 0;
			while (i < count)
			{
				HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = elementIdentifierMappings[i];
				if (elementIdentifierMap != null && elementIdentifierMap.templateId == A_2)
				{
					if (elementIdentifierMap.splitAxis)
					{
						return new zzIYMvAnMtpiMJyIjwvHCSyknhJk(ControllerTemplateElementType.Axis, true, new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, -1, AxisRange.Full), new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, elementIdentifierMap.joystickId, AxisRange.Positive), new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, elementIdentifierMap.joystickId2, AxisRange.Positive));
					}
					return new zzIYMvAnMtpiMJyIjwvHCSyknhJk(ControllerTemplateElementType.Axis, false, new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, elementIdentifierMap.joystickId, AxisRange.Full), new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, -1, AxisRange.Positive), new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, -1, AxisRange.Positive));
				}
				else
				{
					i++;
				}
			}
			return null;
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x000917FC File Offset: 0x0008F9FC
		internal static zzIYMvAnMtpiMJyIjwvHCSyknhJk oFdcjuhlnTvFnsPJrzRVSnTJgcMw(IHardwareControllerTemplateMap_Internal A_0, Controller A_1, int A_2, Func<Guid, HardwareJoystickTemplateMap.Entry> A_3)
		{
			if (A_0 == null)
			{
				return null;
			}
			if (A_1 == null)
			{
				return null;
			}
			if (A_3 == null)
			{
				return null;
			}
			IControllerTemplateElementIdentifier templateElementIdentifierById = A_0.GetTemplateElementIdentifierById(A_2);
			if (templateElementIdentifierById == null)
			{
				return null;
			}
			if (templateElementIdentifierById.elementType != ControllerTemplateElementType.Button)
			{
				return null;
			}
			if (A_1 == null)
			{
				return null;
			}
			HardwareJoystickTemplateMap.Entry entry = A_3(A_1.legQjhUclFMVpVFTfXDlmJRWuUQj);
			if (entry == null)
			{
				return null;
			}
			List<HardwareJoystickTemplateMap.ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			if (elementIdentifierMappings == null)
			{
				return null;
			}
			int count = elementIdentifierMappings.Count;
			for (int i = 0; i < count; i++)
			{
				HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = elementIdentifierMappings[i];
				if (elementIdentifierMap != null && elementIdentifierMap.templateId == A_2)
				{
					return new zzIYMvAnMtpiMJyIjwvHCSyknhJk(ControllerTemplateElementType.Button, false, new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, elementIdentifierMap.joystickId, AxisRange.Full), new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, -1, AxisRange.Positive), new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(A_1, -1, AxisRange.Positive));
				}
			}
			return null;
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x000918AC File Offset: 0x0008FAAC
		internal static ControllerTemplateElementIdentifier oCWzblfMOSbkQbShRbMmwWQpBuJgA(ControllerTemplateElementIdentifier[] A_0, int A_1)
		{
			int num = HardwareJoystickTemplateMap.TJrUuvqoAvfeKPZlqdmIuzLOflAx(A_0, A_1);
			if (num < 0 || num >= A_0.Length)
			{
				return null;
			}
			return A_0[num];
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x000918D0 File Offset: 0x0008FAD0
		internal static int TJrUuvqoAvfeKPZlqdmIuzLOflAx(ControllerTemplateElementIdentifier[] A_0, int A_1)
		{
			if (A_0 == null)
			{
				return -1;
			}
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i].id == A_1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x0001B327 File Offset: 0x00019527
		internal static bool gcWKamMehrDIpoHgSvGCYKVkXltL(ControllerTemplateElementIdentifier[] A_0, int A_1)
		{
			return HardwareJoystickTemplateMap.TJrUuvqoAvfeKPZlqdmIuzLOflAx(A_0, A_1) >= 0;
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x0001825F File Offset: 0x0001645F
		string IHardwareControllerMap_Internal.get_name()
		{
			return base.name;
		}

		// Token: 0x04001510 RID: 5392
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		// Token: 0x04001511 RID: 5393
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		// Token: 0x04001512 RID: 5394
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string templateGuid;

		// Token: 0x04001513 RID: 5395
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string templateKey;

		// Token: 0x04001514 RID: 5396
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string className;

		// Token: 0x04001515 RID: 5397
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementIdentifier_Editor[] elementIdentifiers;

		// Token: 0x04001516 RID: 5398
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<HardwareJoystickTemplateMap.Entry> joysticks;

		// Token: 0x04001517 RID: 5399
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickTemplateMap.SpecialElementEntry[] specialElements = new HardwareJoystickTemplateMap.SpecialElementEntry[0];

		// Token: 0x04001518 RID: 5400
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		// Token: 0x04001519 RID: 5401
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickIdCounter;

		// Token: 0x0400151A RID: 5402
		[NonSerialized]
		private Func<Guid, HardwareJoystickTemplateMap.Entry> RxoOXBedeajkuBlbcqqbIMLKAhgJ;

		// Token: 0x02000384 RID: 900
		[Serializable]
		public sealed class Entry
		{
			// Token: 0x06002500 RID: 9472 RVA: 0x000033F4 File Offset: 0x000015F4
			[Preserve]
			public Entry()
			{
			}

			// Token: 0x06002501 RID: 9473 RVA: 0x00091900 File Offset: 0x0008FB00
			internal Entry(HardwareJoystickTemplateMap.Entry A_1)
			{
				this.id = A_1.id;
				this.name = A_1.name;
				this.joystickGuid = A_1.joystickGuid;
				this.fileGuid = A_1.fileGuid;
				if (A_1.elementIdentifierMappings != null)
				{
					this.elementIdentifierMappings = new List<HardwareJoystickTemplateMap.ElementIdentifierMap>(A_1.elementIdentifierMappings.Count);
					for (int i = 0; i < A_1.elementIdentifierMappings.Count; i++)
					{
						if (A_1.elementIdentifierMappings[i] != null)
						{
							this.elementIdentifierMappings.Add(new HardwareJoystickTemplateMap.ElementIdentifierMap(A_1.elementIdentifierMappings[i]));
						}
					}
				}
			}

			// Token: 0x1700089A RID: 2202
			// (get) Token: 0x06002502 RID: 9474 RVA: 0x000919A4 File Offset: 0x0008FBA4
			public Guid JoystickGuid
			{
				get
				{
					Guid result;
					try
					{
						result = new Guid(this.joystickGuid);
					}
					catch
					{
						Logger.LogWarning("Error converting string to Guid due to invalid characters or bad Guid string format. Guid string = \"" + this.joystickGuid + "\"");
						result = Guid.Empty;
					}
					return result;
				}
			}

			// Token: 0x06002503 RID: 9475 RVA: 0x000919F4 File Offset: 0x0008FBF4
			public int GetJoystickElementId(int templateElementId)
			{
				if (this.elementIdentifierMappings == null)
				{
					return -1;
				}
				int count = this.elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.elementIdentifierMappings[i].templateId == templateElementId)
					{
						return this.elementIdentifierMappings[i].joystickId;
					}
				}
				return -1;
			}

			// Token: 0x06002504 RID: 9476 RVA: 0x00091A4C File Offset: 0x0008FC4C
			public int GetTemplateElementId(int joystickElementId)
			{
				if (this.elementIdentifierMappings == null)
				{
					return -1;
				}
				int count = this.elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.elementIdentifierMappings[i].joystickId == joystickElementId)
					{
						return this.elementIdentifierMappings[i].templateId;
					}
				}
				return -1;
			}

			// Token: 0x06002505 RID: 9477 RVA: 0x00091AA4 File Offset: 0x0008FCA4
			public HardwareJoystickTemplateMap.ElementIdentifierMap GetElementIdentifierMap(int templateId)
			{
				if (this.elementIdentifierMappings == null)
				{
					return null;
				}
				int count = this.elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.elementIdentifierMappings[i].templateId == templateId)
					{
						return this.elementIdentifierMappings[i];
					}
				}
				return null;
			}

			// Token: 0x06002506 RID: 9478 RVA: 0x00091AF8 File Offset: 0x0008FCF8
			public void GetElementIdentifierMaps(int templateId, List<HardwareJoystickTemplateMap.ElementIdentifierMap> results)
			{
				if (results == null)
				{
					return;
				}
				if (this.elementIdentifierMappings == null)
				{
					return;
				}
				int count = this.elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.elementIdentifierMappings[i].templateId == templateId)
					{
						results.Add(this.elementIdentifierMappings[i]);
					}
				}
			}

			// Token: 0x0400151B RID: 5403
			public int id;

			// Token: 0x0400151C RID: 5404
			public string name;

			// Token: 0x0400151D RID: 5405
			public string joystickGuid;

			// Token: 0x0400151E RID: 5406
			public string fileGuid;

			// Token: 0x0400151F RID: 5407
			public List<HardwareJoystickTemplateMap.ElementIdentifierMap> elementIdentifierMappings;
		}

		// Token: 0x02000385 RID: 901
		[Serializable]
		public sealed class ElementIdentifierMap
		{
			// Token: 0x06002507 RID: 9479 RVA: 0x000033F4 File Offset: 0x000015F4
			[Preserve]
			public ElementIdentifierMap()
			{
			}

			// Token: 0x06002508 RID: 9480 RVA: 0x0001B34A File Offset: 0x0001954A
			internal ElementIdentifierMap(HardwareJoystickTemplateMap.ElementIdentifierMap A_1)
			{
				this.templateId = A_1.templateId;
				this.joystickId = A_1.joystickId;
				this.joystickId2 = A_1.joystickId2;
				this.splitAxis = A_1.splitAxis;
			}

			// Token: 0x04001520 RID: 5408
			public int templateId;

			// Token: 0x04001521 RID: 5409
			public int joystickId;

			// Token: 0x04001522 RID: 5410
			public int joystickId2;

			// Token: 0x04001523 RID: 5411
			public bool splitAxis;
		}

		// Token: 0x02000386 RID: 902
		[Serializable]
		public sealed class SpecialElementEntry : IControllerTemplateMapSpecialElement_Internal
		{
			// Token: 0x06002509 RID: 9481 RVA: 0x0001B382 File Offset: 0x00019582
			[Preserve]
			public SpecialElementEntry()
			{
			}

			// Token: 0x0600250A RID: 9482 RVA: 0x0001B391 File Offset: 0x00019591
			internal SpecialElementEntry(HardwareJoystickTemplateMap.SpecialElementEntry A_1)
			{
				this.elementIdentifierId = A_1.elementIdentifierId;
				this.data = A_1.data;
			}

			// Token: 0x0600250B RID: 9483 RVA: 0x00091B50 File Offset: 0x0008FD50
			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				T result;
				JsonParser.TryFromJson<T>(this.data, out result);
				return result;
			}

			// Token: 0x04001524 RID: 5412
			public int elementIdentifierId = -1;

			// Token: 0x04001525 RID: 5413
			public string data;
		}
	}
}
