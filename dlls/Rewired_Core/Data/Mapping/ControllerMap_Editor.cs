using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;

namespace Rewired.Data.Mapping
{
	// Token: 0x0200039D RID: 925
	[Serializable]
	public sealed class ControllerMap_Editor
	{
		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x0600256A RID: 9578 RVA: 0x0001B651 File Offset: 0x00019851
		public IEnumerable<ActionElementMap> ActionElementMaps
		{
			get
			{
				if (this.actionElementMaps == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.actionElementMaps.Count; i = num + 1)
				{
					yield return this.actionElementMaps[i];
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x0600256B RID: 9579 RVA: 0x0001B661 File Offset: 0x00019861
		public Guid hardwareGuid
		{
			get
			{
				return StringTools.ToGuid(this.hardwareGuidString);
			}
		}

		// Token: 0x0600256C RID: 9580 RVA: 0x0001B66E File Offset: 0x0001986E
		public ControllerMap_Editor()
		{
			this.actionElementMaps = new List<ActionElementMap>();
		}

		// Token: 0x0600256D RID: 9581 RVA: 0x0009228C File Offset: 0x0009048C
		public ControllerMap_Editor Clone()
		{
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = this.id;
			controllerMap_Editor.categoryId = this.categoryId;
			controllerMap_Editor.layoutId = this.layoutId;
			controllerMap_Editor.name = this.name;
			controllerMap_Editor.hardwareGuidString = this.hardwareGuidString;
			controllerMap_Editor.customControllerUid = this.customControllerUid;
			if (this.actionElementMaps != null)
			{
				controllerMap_Editor.actionElementMaps = new List<ActionElementMap>();
				for (int i = 0; i < this.actionElementMaps.Count; i++)
				{
					controllerMap_Editor.actionElementMaps.Add(new ActionElementMap(this.actionElementMaps[i]));
				}
			}
			return controllerMap_Editor;
		}

		// Token: 0x0600256E RID: 9582 RVA: 0x0001B681 File Offset: 0x00019881
		public ActionElementMap GetActionElementMap(int index)
		{
			if (index < 0 || index >= this.actionElementMaps.Count)
			{
				return null;
			}
			return this.actionElementMaps[index];
		}

		// Token: 0x0600256F RID: 9583 RVA: 0x00092330 File Offset: 0x00090530
		internal JoystickMap XPPshKhJAPrwuiStAmfGiuotCdyc(Func<int, bool> A_1, HardwareControllerMapIdentifier A_2, HardwareJoystickMap A_3, bool A_4)
		{
			JoystickMap joystickMap = new JoystickMap();
			this.lUPBdKcbTJPGRvsLOwvTnovaAsIkA(A_1, joystickMap, A_2, A_3, A_4);
			return joystickMap;
		}

		// Token: 0x06002570 RID: 9584 RVA: 0x00092350 File Offset: 0x00090550
		internal KeyboardMap YNsUmlddoSPOqfSpCQmbJQOffggBA(Func<int, bool> A_1)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			this.lUPBdKcbTJPGRvsLOwvTnovaAsIkA(A_1, keyboardMap, default(HardwareControllerMapIdentifier), null, false);
			return keyboardMap;
		}

		// Token: 0x06002571 RID: 9585 RVA: 0x00092378 File Offset: 0x00090578
		internal MouseMap SIXtwqRHUKcorBGgjrrbiaHhCcJJ(Func<int, bool> A_1)
		{
			MouseMap mouseMap = new MouseMap();
			this.lUPBdKcbTJPGRvsLOwvTnovaAsIkA(A_1, mouseMap, default(HardwareControllerMapIdentifier), null, false);
			return mouseMap;
		}

		// Token: 0x06002572 RID: 9586 RVA: 0x000923A0 File Offset: 0x000905A0
		internal CustomControllerMap ECEGOeUousPxazvEFycwLpNyllxG(Func<int, bool> A_1, CustomController_Editor A_2)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			this.WcYdRpGMuirRaqoXvAmZbqpJEhaac(A_1, InputSource.Custom, customControllerMap, A_2);
			return customControllerMap;
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x000923C0 File Offset: 0x000905C0
		internal ControllerTemplateMap FVuvWhIxswUyaXIjTxYhZcdDYMTI()
		{
			if (ReInput.UKCRsGlOBNUIwmXiQxEalDQxdbAF(this.hardwareGuid) == null)
			{
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(this.hardwareGuid, this.categoryId, this.layoutId, this.id);
			int num = (this.actionElementMaps != null) ? this.actionElementMaps.Count : 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = this.actionElementMaps[i];
				if (actionElementMap != null && InputTools.IsMappableType(actionElementMap._elementType))
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.ltvevvAbFrYvfZCxtACIcyrVkcYAA(actionElementMap);
					if (controllerTemplateActionElementMap != null)
					{
						controllerTemplateMap.wGiCZcFTesGTMmlvYShgrpCRWrtF(controllerTemplateActionElementMap);
					}
				}
			}
			return controllerTemplateMap;
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x00092450 File Offset: 0x00090650
		private void lUPBdKcbTJPGRvsLOwvTnovaAsIkA(Func<int, bool> A_1, ControllerMap A_2, HardwareControllerMapIdentifier A_3, HardwareJoystickMap A_4, bool A_5)
		{
			A_2.sourceMapId = this.id;
			A_2.categoryId = this.categoryId;
			A_2.name = this.name;
			A_2.hardwareGuid = StringTools.ToGuid(this.hardwareGuidString);
			if (this.actionElementMaps == null)
			{
				return;
			}
			for (int i = 0; i < this.actionElementMaps.Count; i++)
			{
				if (A_1(this.actionElementMaps[i].actionId))
				{
					ActionElementMap actionElementMap = new ActionElementMap(this.actionElementMaps[i]);
					if (A_4 != null)
					{
						ControllerElementIdentifier elementIdentifier = A_4.GetElementIdentifier(this.actionElementMaps[i].elementIdentifierId);
						if (elementIdentifier != null)
						{
							ControllerElementType effectiveElementIdentifierType = A_4.GetEffectiveElementIdentifierType(A_3, this.actionElementMaps[i].elementIdentifierId, A_5);
							ControllerElementType elementType = elementIdentifier.elementType;
							if (effectiveElementIdentifierType != this.actionElementMaps[i].elementType)
							{
								actionElementMap._elementType = effectiveElementIdentifierType;
								if (effectiveElementIdentifierType == ControllerElementType.Axis)
								{
									AxisRange axisRange;
									if (elementIdentifier.elementType == ControllerElementType.Button)
									{
										actionElementMap._axisRange = AxisRange.Positive;
									}
									else if (A_4.GetEffectiveAxisRange(A_3, this.actionElementMaps[i].elementIdentifierId, A_5, out axisRange))
									{
										actionElementMap._axisRange = axisRange;
									}
									else if (actionElementMap.axisContribution == Pole.Negative)
									{
										actionElementMap._axisRange = AxisRange.Negative;
									}
									else
									{
										actionElementMap._axisRange = AxisRange.Positive;
									}
									actionElementMap._invert = false;
								}
								else
								{
									if (effectiveElementIdentifierType != ControllerElementType.Button)
									{
										throw new NotImplementedException();
									}
									if (actionElementMap._axisRange == AxisRange.Full)
									{
										actionElementMap._axisContribution = (actionElementMap._invert ? Pole.Negative : Pole.Positive);
									}
									actionElementMap._invert = false;
									actionElementMap._axisRange = AxisRange.Full;
								}
							}
						}
					}
					A_2.SNSempsrfLhzSBkFeitYdlebhkwZB(actionElementMap);
				}
			}
		}

		// Token: 0x06002575 RID: 9589 RVA: 0x000925F0 File Offset: 0x000907F0
		private void WcYdRpGMuirRaqoXvAmZbqpJEhaac(Func<int, bool> A_1, InputSource A_2, CustomControllerMap A_3, CustomController_Editor A_4)
		{
			A_3.sourceMapId = this.id;
			A_3.categoryId = this.categoryId;
			A_3.name = this.name;
			A_3.sourceControllerId = this.customControllerUid;
			if (this.actionElementMaps == null)
			{
				return;
			}
			for (int i = 0; i < this.actionElementMaps.Count; i++)
			{
				if (A_1(this.actionElementMaps[i].actionId))
				{
					ActionElementMap actionElementMap = new ActionElementMap(this.actionElementMaps[i]);
					if (A_4 != null)
					{
						ControllerElementIdentifier elementIdentifier = A_4.GetElementIdentifier(this.actionElementMaps[i].elementIdentifierId);
						if (elementIdentifier != null)
						{
							ControllerElementType effectiveElementIdentifierType = A_4.GetEffectiveElementIdentifierType(this.actionElementMaps[i].elementIdentifierId);
							ControllerElementType elementType = elementIdentifier.elementType;
							if (effectiveElementIdentifierType != this.actionElementMaps[i].elementType)
							{
								actionElementMap.elementType = effectiveElementIdentifierType;
								if (effectiveElementIdentifierType == ControllerElementType.Axis)
								{
									AxisRange axisRange;
									if (elementIdentifier.elementType == ControllerElementType.Button)
									{
										actionElementMap.axisRange = AxisRange.Positive;
									}
									else if (A_4.GetEffectiveAxisRange(this.actionElementMaps[i].elementIdentifierId, out axisRange))
									{
										actionElementMap.axisRange = axisRange;
									}
									else if (actionElementMap.axisContribution == Pole.Negative)
									{
										actionElementMap.axisRange = AxisRange.Negative;
									}
									else
									{
										actionElementMap.axisRange = AxisRange.Positive;
									}
									actionElementMap.invert = false;
								}
								else
								{
									if (effectiveElementIdentifierType != ControllerElementType.Button)
									{
										throw new NotImplementedException();
									}
									if (actionElementMap.axisRange == AxisRange.Full)
									{
										actionElementMap.axisContribution = (actionElementMap.invert ? Pole.Negative : Pole.Positive);
									}
									actionElementMap.invert = false;
									actionElementMap.axisRange = AxisRange.Full;
								}
							}
						}
					}
					A_3.SNSempsrfLhzSBkFeitYdlebhkwZB(actionElementMap);
				}
			}
		}

		// Token: 0x06002576 RID: 9590 RVA: 0x00092780 File Offset: 0x00090980
		public void CreateElementsFromHardwareMap(IHardwareControllerMap hardwareJoystickMap)
		{
			if (hardwareJoystickMap == null)
			{
				return;
			}
			int num = 0;
			foreach (IControllerElementIdentifierCommon_Internal controllerElementIdentifierCommon_Internal in (hardwareJoystickMap as IHardwareControllerMap_Internal).ElementIdentifiers)
			{
				if (InputTools.IsMappableControllerElementType(controllerElementIdentifierCommon_Internal.elementType))
				{
					ActionElementMap item = new ActionElementMap(-1, gRvITEHjKMrWaeGYEmAHofbpCtEU.rWmttbzDhkUyaRzogdiwQRutjWNU(controllerElementIdentifierCommon_Internal.elementType), controllerElementIdentifierCommon_Internal.id);
					this.actionElementMaps.Add(item);
					num++;
				}
			}
		}

		// Token: 0x06002577 RID: 9591 RVA: 0x00092808 File Offset: 0x00090A08
		public void CreateElementsFromHardwareMap(CustomController_Editor customController)
		{
			if (customController == null)
			{
				return;
			}
			List<ActionElementMap> list = new List<ActionElementMap>();
			List<ActionElementMap> list2 = new List<ActionElementMap>();
			foreach (ControllerElementIdentifier controllerElementIdentifier in customController.ElementIdentifiers)
			{
				ActionElementMap item = new ActionElementMap(-1, controllerElementIdentifier.elementType, controllerElementIdentifier.id);
				if (controllerElementIdentifier.elementType == ControllerElementType.Axis)
				{
					list2.Add(item);
				}
				else
				{
					if (controllerElementIdentifier.elementType != ControllerElementType.Button)
					{
						throw new NotImplementedException();
					}
					list.Add(item);
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				this.actionElementMaps.Add(list2[i]);
			}
			for (int j = 0; j < list.Count; j++)
			{
				this.actionElementMaps.Add(list[j]);
			}
		}

		// Token: 0x06002578 RID: 9592 RVA: 0x0001B6A3 File Offset: 0x000198A3
		public void AddActionElementMap()
		{
			this.actionElementMaps.Add(this.iGDXXmhNSDIHbgaktdUzwQsYkyzp());
		}

		// Token: 0x06002579 RID: 9593 RVA: 0x0001B6B6 File Offset: 0x000198B6
		public void InsertActionElementMap(int index)
		{
			if (index < 0 || index >= this.actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.actionElementMaps.Insert(index, this.iGDXXmhNSDIHbgaktdUzwQsYkyzp());
		}

		// Token: 0x0600257A RID: 9594 RVA: 0x0001B6E7 File Offset: 0x000198E7
		public void DeleteActionElementMap(int index)
		{
			if (this.actionElementMaps == null || index < 0 || index >= this.actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.actionElementMaps.RemoveAt(index);
		}

		// Token: 0x0600257B RID: 9595 RVA: 0x0001B71A File Offset: 0x0001991A
		public bool ReorderActionElementMap(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<ActionElementMap>(this.actionElementMaps, index, offsetDown, offsetNow);
		}

		// Token: 0x0600257C RID: 9596 RVA: 0x000928F0 File Offset: 0x00090AF0
		public void DuplicateActionElementMap(int index)
		{
			if (this.actionElementMaps == null || index < 0 || index >= this.actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ActionElementMap item = new ActionElementMap(this.actionElementMaps[index]);
			if (index == this.actionElementMaps.Count - 1)
			{
				this.actionElementMaps.Add(item);
				return;
			}
			this.actionElementMaps.Insert(index + 1, item);
		}

		// Token: 0x0600257D RID: 9597 RVA: 0x0001B72A File Offset: 0x0001992A
		private ActionElementMap iGDXXmhNSDIHbgaktdUzwQsYkyzp()
		{
			return new ActionElementMap
			{
				elementType = ControllerElementType.Button
			};
		}

		// Token: 0x04001570 RID: 5488
		public int id;

		// Token: 0x04001571 RID: 5489
		public int categoryId;

		// Token: 0x04001572 RID: 5490
		public int layoutId;

		// Token: 0x04001573 RID: 5491
		public string name;

		// Token: 0x04001574 RID: 5492
		public string hardwareGuidString;

		// Token: 0x04001575 RID: 5493
		public int customControllerUid;

		// Token: 0x04001576 RID: 5494
		public List<ActionElementMap> actionElementMaps;
	}
}
