using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000110 RID: 272
	[Serializable]
	public sealed class ActionElementMap
	{
		// Token: 0x060009B6 RID: 2486 RVA: 0x00009E5C File Offset: 0x0000805C
		internal static bool rsKLuCqJSjqWHzNTrOWmcUvmtQFp(ActionElementMap A_0)
		{
			return A_0 != null && (A_0._actionId == -1 || ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.HyTLAIQgcMyMlMmWHCgNRoCBGwh(A_0._actionId));
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x000456EC File Offset: 0x000438EC
		internal static void ggSPedmrIdzdrMxYRbWISDGvXyeR(ActionElementMap A_0, ActionElementMap A_1)
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (A_1 == null)
			{
				throw new ArgumentNullException("destination");
			}
			A_1._actionId = A_0._actionId;
			A_1._actionCategoryId = A_0._actionCategoryId;
			A_1._elementType = A_0._elementType;
			A_1._elementIdentifierId = A_0._elementIdentifierId;
			A_1._axisRange = A_0._axisRange;
			A_1._invert = A_0._invert;
			A_1._axisContribution = A_0._axisContribution;
			A_1._keyboardKeyCode = A_0._keyboardKeyCode;
			A_1._modifierKey1 = A_0._modifierKey1;
			A_1._modifierKey2 = A_0._modifierKey2;
			A_1._modifierKey3 = A_0._modifierKey3;
			A_1.NNDdFGwfHOMtmloXpknTohmlGIGT = A_0.NNDdFGwfHOMtmloXpknTohmlGIGT;
			A_1.mRCBQDgzARDPVbNsvhiBadcDxEwTB = A_0.mRCBQDgzARDPVbNsvhiBadcDxEwTB;
			A_1.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = A_0.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000457C0 File Offset: 0x000439C0
		public static bool TryGetCombinedElementIdentifierName(IList<ActionElementMap> actionElementMaps, out string result)
		{
			int count;
			if (actionElementMaps == null || (count = actionElementMaps.Count) == 0)
			{
				result = null;
				return false;
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = null;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = actionElementMaps[i];
				if (actionElementMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game2 = (actionElementMap.NNDdFGwfHOMtmloXpknTohmlGIGT != null && actionElementMap.NNDdFGwfHOMtmloXpknTohmlGIGT.controller != null) ? actionElementMap.NNDdFGwfHOMtmloXpknTohmlGIGT.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : actionElementMap.wfFHDOooFKfjdMCKziamOGoJrbSL;
					if (hardwareControllerMap_Game != null)
					{
						if (hardwareControllerMap_Game2 != hardwareControllerMap_Game)
						{
							result = null;
							return false;
						}
					}
					else
					{
						hardwareControllerMap_Game = hardwareControllerMap_Game2;
					}
				}
			}
			if (hardwareControllerMap_Game == null)
			{
				result = null;
				return false;
			}
			for (int j = 0; j < count; j++)
			{
				ActionElementMap actionElementMap = actionElementMaps[j];
				if (actionElementMap != null && hardwareControllerMap_Game.TryGetCompoundElementMemberCombinedLocalizedName(actionElementMaps, out result))
				{
					return true;
				}
			}
			result = null;
			return false;
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00045870 File Offset: 0x00043A70
		public static bool TryGetCombinedElementIdentifierGlyph(IList<ActionElementMap> actionElementMaps, out object result)
		{
			string text;
			return ActionElementMap.yUEXyKSCHbJQxpcCvLHcydfUrQxJ(actionElementMaps, true, false, out result, out text);
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00045888 File Offset: 0x00043A88
		public static bool TryGetCombinedElementIdentifierFinalGlyphKey(IList<ActionElementMap> actionElementMaps, out string result)
		{
			object obj;
			return ActionElementMap.yUEXyKSCHbJQxpcCvLHcydfUrQxJ(actionElementMaps, false, true, out obj, out result);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x000458A0 File Offset: 0x00043AA0
		private static bool yUEXyKSCHbJQxpcCvLHcydfUrQxJ(IList<ActionElementMap> A_0, bool A_1, bool A_2, out object A_3, out string A_4)
		{
			int count;
			if (A_0 == null || (count = A_0.Count) == 0)
			{
				A_3 = null;
				A_4 = null;
				return false;
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = null;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = A_0[i];
				if (actionElementMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game2 = (actionElementMap.NNDdFGwfHOMtmloXpknTohmlGIGT != null && actionElementMap.NNDdFGwfHOMtmloXpknTohmlGIGT.controller != null) ? actionElementMap.NNDdFGwfHOMtmloXpknTohmlGIGT.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : actionElementMap.wfFHDOooFKfjdMCKziamOGoJrbSL;
					if (hardwareControllerMap_Game != null)
					{
						if (hardwareControllerMap_Game2 != hardwareControllerMap_Game)
						{
							A_3 = null;
							A_4 = null;
							return false;
						}
					}
					else
					{
						hardwareControllerMap_Game = hardwareControllerMap_Game2;
					}
				}
			}
			if (hardwareControllerMap_Game == null)
			{
				A_3 = null;
				A_4 = null;
				return false;
			}
			for (int j = 0; j < count; j++)
			{
				ActionElementMap actionElementMap = A_0[j];
				if (actionElementMap != null && hardwareControllerMap_Game.TryGetCompoundElementMemberCombinedGlyph(A_0, A_1, A_2, out A_3, out A_4))
				{
					return true;
				}
			}
			A_3 = null;
			A_4 = null;
			return false;
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x00009E81 File Offset: 0x00008081
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x00009E89 File Offset: 0x00008089
		public int actionId
		{
			get
			{
				return this._actionId;
			}
			set
			{
				if (value == this._actionId)
				{
					return;
				}
				this._actionId = value;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x00009E9C File Offset: 0x0000809C
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00009EA4 File Offset: 0x000080A4
		public ControllerElementType elementType
		{
			get
			{
				return this._elementType;
			}
			internal set
			{
				this._elementType = value;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x00009EAD File Offset: 0x000080AD
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x00045964 File Offset: 0x00043B64
		public int elementIdentifierId
		{
			get
			{
				return this._elementIdentifierId;
			}
			set
			{
				if (this._elementIdentifierId == value)
				{
					return;
				}
				this._elementIdentifierId = value;
				if (ReInput.isReady && this.NNDdFGwfHOMtmloXpknTohmlGIGT != null)
				{
					Controller controller = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.YCdAacShUnGEqBEtkCPIWZicyHmg(this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType, this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerId, true);
					if (controller != null)
					{
						Controller.Element elementById = controller.GetElementById(value);
						if (elementById != null && elementById.type != this._elementType)
						{
							this.NNDdFGwfHOMtmloXpknTohmlGIGT.BdzPxgmCxwOVqSMBOsyzttVqyIDK(this.pGMbotKVdjNowDvSSfgThIWDmLSHB, elementById.type);
						}
					}
				}
				if (ReInput.isReady)
				{
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(false);
				}
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00009EB5 File Offset: 0x000080B5
		// (set) Token: 0x060009C3 RID: 2499 RVA: 0x00009EBD File Offset: 0x000080BD
		public AxisRange axisRange
		{
			get
			{
				return this._axisRange;
			}
			set
			{
				if (this._axisRange == value)
				{
					return;
				}
				if (this._elementType != ControllerElementType.Axis && ReInput.isReady)
				{
					Logger.LogWarning("You cannot change AxisRange of a non-Axis mapping.");
					return;
				}
				this._axisRange = value;
				if (ReInput.isReady)
				{
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(false);
				}
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x00009EF8 File Offset: 0x000080F8
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x00009F00 File Offset: 0x00008100
		public bool invert
		{
			get
			{
				return this._invert;
			}
			set
			{
				this._invert = value;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x00009F09 File Offset: 0x00008109
		// (set) Token: 0x060009C7 RID: 2503 RVA: 0x00009F11 File Offset: 0x00008111
		public Pole axisContribution
		{
			get
			{
				return this._axisContribution;
			}
			set
			{
				if (this._axisContribution == value)
				{
					return;
				}
				this._axisContribution = value;
				if (ReInput.isReady)
				{
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(false);
				}
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x00009F32 File Offset: 0x00008132
		// (set) Token: 0x060009C9 RID: 2505 RVA: 0x000459F4 File Offset: 0x00043BF4
		public KeyboardKeyCode keyboardKeyCode
		{
			get
			{
				return this._keyboardKeyCode;
			}
			set
			{
				if (this._keyboardKeyCode == value)
				{
					return;
				}
				if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
					return;
				}
				this._keyboardKeyCode = value;
				if (ReInput.isReady)
				{
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(true);
				}
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060009CA RID: 2506 RVA: 0x00009F3A File Offset: 0x0000813A
		// (set) Token: 0x060009CB RID: 2507 RVA: 0x00045A40 File Offset: 0x00043C40
		public ModifierKey modifierKey1
		{
			get
			{
				return this._modifierKey1;
			}
			set
			{
				if (this._modifierKey1 == value)
				{
					return;
				}
				if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				this._modifierKey1 = value;
				if (ReInput.isReady)
				{
					this.kxlfyYafyrxNTFtovnEsMhtftzCI();
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(true);
				}
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060009CC RID: 2508 RVA: 0x00009F42 File Offset: 0x00008142
		// (set) Token: 0x060009CD RID: 2509 RVA: 0x00045A94 File Offset: 0x00043C94
		public ModifierKey modifierKey2
		{
			get
			{
				return this._modifierKey2;
			}
			set
			{
				if (this._modifierKey2 == value)
				{
					return;
				}
				if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				this._modifierKey2 = value;
				if (ReInput.isReady)
				{
					this.kxlfyYafyrxNTFtovnEsMhtftzCI();
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(true);
				}
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060009CE RID: 2510 RVA: 0x00009F4A File Offset: 0x0000814A
		// (set) Token: 0x060009CF RID: 2511 RVA: 0x00045AE8 File Offset: 0x00043CE8
		public ModifierKey modifierKey3
		{
			get
			{
				return this._modifierKey3;
			}
			set
			{
				if (this._modifierKey3 == value)
				{
					return;
				}
				if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				this._modifierKey3 = value;
				if (ReInput.isReady)
				{
					this.kxlfyYafyrxNTFtovnEsMhtftzCI();
					this.qbuUAysXIFkHcSakWgiDcZOldUnk(true);
				}
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060009D0 RID: 2512 RVA: 0x00009F52 File Offset: 0x00008152
		public AxisType axisType
		{
			get
			{
				if (this._elementType != ControllerElementType.Axis)
				{
					return AxisType.None;
				}
				if (this._axisRange == AxisRange.Full)
				{
					return AxisType.Normal;
				}
				return AxisType.Split;
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x00009F69 File Offset: 0x00008169
		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return ModifierKeyFlags.None | Keyboard.ModifierKeyToModifierKeyFlags(this._modifierKey1) | Keyboard.ModifierKeyToModifierKeyFlags(this._modifierKey2) | Keyboard.ModifierKeyToModifierKeyFlags(this._modifierKey3);
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x00009F90 File Offset: 0x00008190
		// (set) Token: 0x060009D3 RID: 2515 RVA: 0x00009F9D File Offset: 0x0000819D
		public KeyCode keyCode
		{
			get
			{
				return Keyboard.NYIQPzfILwVDAWhVUEBibPLJKiDUA(this._keyboardKeyCode);
			}
			set
			{
				this.keyboardKeyCode = Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(value);
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x00009FAB File Offset: 0x000081AB
		public bool hasModifiers
		{
			get
			{
				return this._keyboardKeyCode != KeyboardKeyCode.None && (this._modifierKey1 != ModifierKey.None || this._modifierKey2 != ModifierKey.None || this._modifierKey3 != ModifierKey.None);
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060009D5 RID: 2517 RVA: 0x00009FD2 File Offset: 0x000081D2
		public ControllerMap controllerMap
		{
			get
			{
				return this.NNDdFGwfHOMtmloXpknTohmlGIGT;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x00009FDA File Offset: 0x000081DA
		// (set) Token: 0x060009D7 RID: 2519 RVA: 0x00009FE2 File Offset: 0x000081E2
		public bool enabled
		{
			get
			{
				return this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA;
			}
			set
			{
				this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = value;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x00045B3C File Offset: 0x00043D3C
		public string elementIdentifierName
		{
			get
			{
				if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType == ControllerType.Keyboard)
				{
					return this.WKImjObTtMSkpIpJdSgylLlQKyho();
				}
				HardwareControllerMap_Game hardwareControllerMap_Game = (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller != null) ? this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : this.wfFHDOooFKfjdMCKziamOGoJrbSL;
				if (hardwareControllerMap_Game == null)
				{
					return string.Empty;
				}
				ControllerElementType elementType = this._elementType;
				if (elementType != ControllerElementType.Axis)
				{
					if (elementType != ControllerElementType.Button)
					{
						throw new NotImplementedException();
					}
					return hardwareControllerMap_Game.GetElementIdentifierName(this._elementIdentifierId);
				}
				else
				{
					if (this.axisType != AxisType.Split)
					{
						return hardwareControllerMap_Game.GetElementIdentifierName(this._elementIdentifierId);
					}
					if (this._axisRange == AxisRange.Positive)
					{
						return hardwareControllerMap_Game.GetElementIdentifierPositiveName(this._elementIdentifierId);
					}
					return hardwareControllerMap_Game.GetElementIdentifierNegativeName(this._elementIdentifierId);
				}
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00045BF8 File Offset: 0x00043DF8
		public string actionDescriptiveName
		{
			get
			{
				InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.zBXmrejZuuEPoeoiDDZIaQYCoFmv(this._actionId);
				if (inputAction == null)
				{
					return string.Empty;
				}
				if (inputAction.type == InputActionType.Axis)
				{
					if (this._elementType == ControllerElementType.Axis && this._axisRange == AxisRange.Full)
					{
						return inputAction.descriptiveName;
					}
					if (this._elementType != ControllerElementType.Axis && this._elementType != ControllerElementType.Button)
					{
						throw new NotImplementedException();
					}
					if (this._axisContribution == Pole.Positive)
					{
						return inputAction.positiveDescriptiveName;
					}
					if (this._axisContribution == Pole.Negative)
					{
						return inputAction.negativeDescriptiveName;
					}
					throw new NotImplementedException();
				}
				else
				{
					if (inputAction.type != InputActionType.Button)
					{
						throw new NotImplementedException();
					}
					if (this._elementType == ControllerElementType.Axis && this._axisRange == AxisRange.Full)
					{
						return inputAction.descriptiveName;
					}
					if (this._elementType != ControllerElementType.Axis && this._elementType != ControllerElementType.Button)
					{
						throw new NotImplementedException();
					}
					if (this._axisContribution == Pole.Negative)
					{
						return inputAction.negativeDescriptiveName;
					}
					return inputAction.descriptiveName;
				}
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00009FEB File Offset: 0x000081EB
		public int elementIndex
		{
			get
			{
				return this.mRCBQDgzARDPVbNsvhiBadcDxEwTB;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x00009FF3 File Offset: 0x000081F3
		public int id
		{
			get
			{
				return this.pGMbotKVdjNowDvSSfgThIWDmLSHB;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x00045CD0 File Offset: 0x00043ED0
		public object elementIdentifierGlyph
		{
			get
			{
				object result;
				using (TempListPool.TList<object> tlist = TempListPool.GetTList<object>())
				{
					int elementIdentifierGlyphs = this.GetElementIdentifierGlyphs(tlist.list);
					if (elementIdentifierGlyphs == 0)
					{
						result = null;
					}
					else
					{
						result = tlist.list[elementIdentifierGlyphs - 1];
					}
				}
				return result;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x00045D24 File Offset: 0x00043F24
		public int elementIdentifierGlyphCount
		{
			get
			{
				int elementIdentifierGlyphs;
				using (TempListPool.TList<object> tlist = TempListPool.GetTList<object>())
				{
					elementIdentifierGlyphs = this.GetElementIdentifierGlyphs(tlist.list);
				}
				return elementIdentifierGlyphs;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x00009FFB File Offset: 0x000081FB
		private bool sRdIJSmEfeXhhXhvlktBcNfktnYb
		{
			get
			{
				return this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType == ControllerType.Keyboard;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x0000A015 File Offset: 0x00008215
		private static int bSEwAbIuyQRtkwdvppROFSEZKsBt
		{
			get
			{
				int result = ActionElementMap.uidCounter;
				if (ActionElementMap.uidCounter == 2147483647)
				{
					ActionElementMap.uidCounter = 0;
					return result;
				}
				ActionElementMap.uidCounter++;
				return result;
			}
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0000A03B File Offset: 0x0000823B
		public ActionElementMap()
		{
			this.pGMbotKVdjNowDvSSfgThIWDmLSHB = ActionElementMap.bSEwAbIuyQRtkwdvppROFSEZKsBt;
			this._actionId = -1;
			this._elementIdentifierId = -1;
			this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = true;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0000A06A File Offset: 0x0000826A
		public ActionElementMap(ActionElementMap A_1) : this()
		{
			ActionElementMap.ggSPedmrIdzdrMxYRbWISDGvXyeR(A_1, this);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0000A079 File Offset: 0x00008279
		public ActionElementMap(int A_1, ControllerElementType A_2, int A_3) : this()
		{
			this._actionId = A_1;
			this._elementType = A_2;
			this._elementIdentifierId = A_3;
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0000A096 File Offset: 0x00008296
		public ActionElementMap(int A_1, ControllerElementType A_2, int A_3, Pole A_4, AxisRange A_5) : this()
		{
			this._actionId = A_1;
			this._elementType = A_2;
			this._elementIdentifierId = A_3;
			this._axisContribution = A_4;
			this._axisRange = A_5;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0000A0C3 File Offset: 0x000082C3
		public ActionElementMap(int A_1, ControllerElementType A_2, int A_3, Pole A_4, AxisRange A_5, bool A_6) : this()
		{
			this._actionId = A_1;
			this._elementType = A_2;
			this._elementIdentifierId = A_3;
			this._axisContribution = A_4;
			this._axisRange = A_5;
			this._invert = A_6;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x00045D64 File Offset: 0x00043F64
		public ActionElementMap(int A_1, ControllerElementType A_2, Pole A_3, KeyboardKeyCode A_4, ModifierKey A_5, ModifierKey A_6, ModifierKey A_7) : this()
		{
			this._actionId = A_1;
			this._elementType = A_2;
			this._axisContribution = A_3;
			this._keyboardKeyCode = A_4;
			this._modifierKey1 = A_5;
			this._modifierKey2 = A_6;
			this._modifierKey3 = A_7;
			this.KcXXMzQwHnOXsTfAgvKKpcvvZJVq();
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x00045DB4 File Offset: 0x00043FB4
		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!this.blPzvPmpBbcIuNjBxaeEuSOiXlro(elementAssignment.type))
			{
				return false;
			}
			if (this.sRdIJSmEfeXhhXhvlktBcNfktnYb || this._keyboardKeyCode != KeyboardKeyCode.None)
			{
				KeyCode keyCode = elementAssignment.keyboardKey;
				if (keyCode == KeyCode.None)
				{
					keyCode = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.TaTrTHwUgSOiWrsYvUpTqAIgrPne.GetKeyCodeById(elementAssignment.elementIdentifierId);
				}
				return this.NTmJlnMfrDVJyMRdpJzpYEWaHUfx(Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(keyCode), elementAssignment.modifierKeyFlags);
			}
			return this.nZNhRCrTGBaEBVSSHgvSGmFmFdeQA(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00045E28 File Offset: 0x00044028
		public bool CheckForAssignmentConflict(ActionElementMap elementMap)
		{
			if (elementMap == null || elementMap == this)
			{
				return false;
			}
			if (this._elementType != elementMap._elementType)
			{
				return false;
			}
			if (this.sRdIJSmEfeXhhXhvlktBcNfktnYb || this._keyboardKeyCode != KeyboardKeyCode.None)
			{
				return this.NTmJlnMfrDVJyMRdpJzpYEWaHUfx(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
			}
			return this.nZNhRCrTGBaEBVSSHgvSGmFmFdeQA(elementMap._elementIdentifierId, elementMap._axisRange);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00045E84 File Offset: 0x00044084
		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.HyTLAIQgcMyMlMmWHCgNRoCBGwh(this._actionId))
			{
				return false;
			}
			if (fieldActionRange == AxisRange.Full)
			{
				if (this._elementType == ControllerElementType.Axis)
				{
					if (this.axisRange != AxisRange.Full)
					{
						return false;
					}
				}
				else if (this._elementType == ControllerElementType.Button && ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.zBXmrejZuuEPoeoiDDZIaQYCoFmv(this._actionId).type == InputActionType.Axis)
				{
					return false;
				}
			}
			else
			{
				if (this.elementType == ControllerElementType.Axis && this.axisRange == AxisRange.Full)
				{
					return false;
				}
				if (ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.zBXmrejZuuEPoeoiDDZIaQYCoFmv(this._actionId).type == InputActionType.Axis)
				{
					if (fieldActionRange == AxisRange.Positive && this.axisContribution != Pole.Positive)
					{
						return false;
					}
					if (fieldActionRange == AxisRange.Negative && this.axisContribution != Pole.Negative)
					{
						return false;
					}
				}
				else if (this.axisContribution != this.axisContribution)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00045F34 File Offset: 0x00044134
		public bool IsTarget(ControllerElementTarget elementTarget)
		{
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			bool result = this.IsTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return result;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00045F58 File Offset: 0x00044158
		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null)
			{
				Controller controller = elementTarget.controller;
				if (controller == null)
				{
					return false;
				}
				if (controller.id != this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerId || controller.type != this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType)
				{
					return false;
				}
			}
			if (this._elementType != elementTarget.elementType)
			{
				return false;
			}
			if (this._elementType == ControllerElementType.Axis)
			{
				return this._elementIdentifierId == elementTarget.elementIdentifierId && this._axisRange == elementTarget.axisRange;
			}
			if (this._elementType == ControllerElementType.Button)
			{
				return this._elementIdentifierId == elementTarget.elementIdentifierId;
			}
			throw new NotImplementedException();
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00045FFC File Offset: 0x000441FC
		public int GetElementIdentifierGlyphs(ICollection<object> results)
		{
			int count = results.Count;
			if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType == ControllerType.Keyboard)
			{
				return this.VaqhbQBsUUjhDDNIKDfYzNBHCfoBc(results);
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller != null) ? this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : this.wfFHDOooFKfjdMCKziamOGoJrbSL;
			if (hardwareControllerMap_Game == null)
			{
				return 0;
			}
			ControllerElementIdentifier elementIdentifierById = hardwareControllerMap_Game.GetElementIdentifierById(this._elementIdentifierId);
			if (elementIdentifierById == null)
			{
				return 0;
			}
			ControllerElementType elementType = this._elementType;
			object obj;
			if (elementType != ControllerElementType.Axis)
			{
				if (elementType != ControllerElementType.Button)
				{
					throw new NotImplementedException();
				}
				obj = elementIdentifierById.glyph;
			}
			else if (this.axisType == AxisType.Split)
			{
				if (this._axisRange == AxisRange.Positive)
				{
					obj = elementIdentifierById.positiveGlyph;
				}
				else
				{
					obj = elementIdentifierById.negativeGlyph;
				}
			}
			else
			{
				obj = elementIdentifierById.glyph;
			}
			if (obj != null)
			{
				results.Add(obj);
			}
			return results.Count - count;
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x000460D4 File Offset: 0x000442D4
		public int GetElementIdentifierGlyphs<T>(ICollection<T> results)
		{
			int result;
			using (TempListPool.TList<object> tlist = TempListPool.GetTList<object>())
			{
				List<object> list = tlist.list;
				int elementIdentifierGlyphs = this.GetElementIdentifierGlyphs(list);
				int count = results.Count;
				for (int i = 0; i < elementIdentifierGlyphs; i++)
				{
					if (!(list[i] is T))
					{
						return 0;
					}
				}
				for (int j = 0; j < elementIdentifierGlyphs; j++)
				{
					results.Add((T)((object)list[j]));
				}
				result = results.Count - count;
			}
			return result;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0004616C File Offset: 0x0004436C
		public int GetElementIdentifierFinalGlyphKeys(ICollection<string> results)
		{
			int count = results.Count;
			if (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType == ControllerType.Keyboard)
			{
				return this.iXpOmRDSkecnPwXmJhezyeimiphFA(results);
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null && this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller != null) ? this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : this.wfFHDOooFKfjdMCKziamOGoJrbSL;
			if (hardwareControllerMap_Game == null)
			{
				return 0;
			}
			ControllerElementIdentifier elementIdentifierById = hardwareControllerMap_Game.GetElementIdentifierById(this._elementIdentifierId);
			if (elementIdentifierById == null)
			{
				return 0;
			}
			ControllerElementType elementType = this._elementType;
			string finalGlyphKey;
			if (elementType != ControllerElementType.Axis)
			{
				if (elementType != ControllerElementType.Button)
				{
					throw new NotImplementedException();
				}
				finalGlyphKey = elementIdentifierById.GetFinalGlyphKey(this._elementType, AxisRange.Full);
			}
			else if (this.axisType == AxisType.Split)
			{
				finalGlyphKey = elementIdentifierById.GetFinalGlyphKey(this._elementType, this._axisRange);
			}
			else
			{
				finalGlyphKey = elementIdentifierById.GetFinalGlyphKey(this._elementType, AxisRange.Full);
			}
			if (finalGlyphKey != null)
			{
				results.Add(finalGlyphKey);
			}
			return results.Count - count;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0004624C File Offset: 0x0004444C
		internal void YmjBUAFlEbXvUpfGfovFCfjkhaLrc(ControllerMap A_1)
		{
			this.NNDdFGwfHOMtmloXpknTohmlGIGT = A_1;
			ControllerType controllerType = A_1.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = (A_1.controller != null) ? A_1.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : null;
			this.UtrryNjuGgrHFMnPyHfCbSWomdlK(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && this._elementIdentifierId <= 0);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0000A0F8 File Offset: 0x000082F8
		internal void ubBnNGFeqSMOJcQMgXczBUsQMzgN(ControllerMap A_1, HardwareControllerMap_Game A_2)
		{
			this.NNDdFGwfHOMtmloXpknTohmlGIGT = A_1;
			this.wfFHDOooFKfjdMCKziamOGoJrbSL = A_2;
			this.UtrryNjuGgrHFMnPyHfCbSWomdlK(A_1.controllerType, A_2, A_1.controllerType == ControllerType.Keyboard && this._elementIdentifierId <= 0);
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0000A12C File Offset: 0x0000832C
		private void qbuUAysXIFkHcSakWgiDcZOldUnk(bool A_1)
		{
			if (this.NNDdFGwfHOMtmloXpknTohmlGIGT == null)
			{
				return;
			}
			this.UtrryNjuGgrHFMnPyHfCbSWomdlK(this.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType, (this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller != null) ? this.NNDdFGwfHOMtmloXpknTohmlGIGT.controller.WGnseNgKihPuTwMSEeDkNInQXGEb : null, A_1);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x00046298 File Offset: 0x00044498
		private void UtrryNjuGgrHFMnPyHfCbSWomdlK(ControllerType A_1, HardwareControllerMap_Game A_2, bool A_3)
		{
			if (this.NNDdFGwfHOMtmloXpknTohmlGIGT == null)
			{
				return;
			}
			if (A_1 == ControllerType.Keyboard)
			{
				Keyboard keyboard = ReInput.controllers.Keyboard;
				if (A_3)
				{
					this.mRCBQDgzARDPVbNsvhiBadcDxEwTB = keyboard.GetButtonIndex(this._keyboardKeyCode);
					this.KcXXMzQwHnOXsTfAgvKKpcvvZJVq();
					return;
				}
				this.mRCBQDgzARDPVbNsvhiBadcDxEwTB = keyboard.GetButtonIndexById(this._elementIdentifierId);
				this.alLtuiDcLkmRLxdxmjEOYtbhUmhv();
				return;
			}
			else
			{
				if (A_2 == null)
				{
					return;
				}
				ControllerElementType elementType = this._elementType;
				if (elementType == ControllerElementType.Axis)
				{
					this.mRCBQDgzARDPVbNsvhiBadcDxEwTB = A_2.GetAxisIndex(this._elementIdentifierId);
					return;
				}
				if (elementType != ControllerElementType.Button)
				{
					throw new NotImplementedException();
				}
				this.mRCBQDgzARDPVbNsvhiBadcDxEwTB = A_2.GetButtonIndex(this._elementIdentifierId);
				return;
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00046330 File Offset: 0x00044530
		private string WKImjObTtMSkpIpJdSgylLlQKyho()
		{
			string text = Keyboard.GetKeyName((KeyCode)this._keyboardKeyCode);
			if (string.Equals(text, this.zhbDDcxpqLPKysVlukCrwYGdqCaS, StringComparison.Ordinal) && this.kzteAhfhIrTzNCdHchaFtnLuoTRn == this.modifierKeyFlags && (!LocalizationManager.isEnabled || this.QLNNoLPNnFrAWEfHaFAvPwzkiRwU == LocalizationManager.version))
			{
				return this.iYXtOkkokIhLdgbtwKrjIhfcNnqW;
			}
			this.zhbDDcxpqLPKysVlukCrwYGdqCaS = text;
			this.kzteAhfhIrTzNCdHchaFtnLuoTRn = this.modifierKeyFlags;
			if (LocalizationManager.isEnabled)
			{
				this.QLNNoLPNnFrAWEfHaFAvPwzkiRwU = LocalizationManager.version;
			}
			if (this._modifierKey3 != ModifierKey.None)
			{
				text = string.Format("{0} + {1}", Keyboard.GetModifierKeyName(this._modifierKey3, true), text);
			}
			if (this._modifierKey2 != ModifierKey.None)
			{
				text = string.Format("{0} + {1}", Keyboard.GetModifierKeyName(this._modifierKey2, true), text);
			}
			if (this._modifierKey1 != ModifierKey.None)
			{
				text = string.Format("{0} + {1}", Keyboard.GetModifierKeyName(this._modifierKey1, true), text);
			}
			this.iYXtOkkokIhLdgbtwKrjIhfcNnqW = text;
			return this.iYXtOkkokIhLdgbtwKrjIhfcNnqW;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00046414 File Offset: 0x00044614
		private int VaqhbQBsUUjhDDNIKDfYzNBHCfoBc(ICollection<object> A_1)
		{
			object glyph = ReInput.controllers.Keyboard.GetElementIdentifierByKeyCode((KeyCode)this._keyboardKeyCode).glyph;
			if (glyph == null)
			{
				return 0;
			}
			int count = A_1.Count;
			using (TempListPool.TList<object> tlist = TempListPool.GetTList<object>())
			{
				List<object> list = tlist.list;
				if (this._modifierKey1 != ModifierKey.None)
				{
					object modifierKeyGlyph = Keyboard.GetModifierKeyGlyph(this._modifierKey1);
					if (modifierKeyGlyph == null)
					{
						return 0;
					}
					list.Add(modifierKeyGlyph);
				}
				if (this._modifierKey2 != ModifierKey.None)
				{
					object modifierKeyGlyph2 = Keyboard.GetModifierKeyGlyph(this._modifierKey2);
					if (modifierKeyGlyph2 == null)
					{
						return 0;
					}
					list.Add(modifierKeyGlyph2);
				}
				if (this._modifierKey3 != ModifierKey.None)
				{
					object modifierKeyGlyph3 = Keyboard.GetModifierKeyGlyph(this._modifierKey3);
					if (modifierKeyGlyph3 == null)
					{
						return 0;
					}
					list.Add(modifierKeyGlyph3);
				}
				for (int i = 0; i < list.Count; i++)
				{
					A_1.Add(list[i]);
				}
			}
			A_1.Add(glyph);
			return A_1.Count - count;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0004651C File Offset: 0x0004471C
		private int iXpOmRDSkecnPwXmJhezyeimiphFA(ICollection<string> A_1)
		{
			string finalGlyphKey = ReInput.controllers.Keyboard.GetElementIdentifierByKeyCode((KeyCode)this._keyboardKeyCode).GetFinalGlyphKey(AxisRange.Full);
			if (finalGlyphKey == null)
			{
				return 0;
			}
			int count = A_1.Count;
			using (TempListPool.TList<string> tlist = TempListPool.GetTList<string>())
			{
				List<string> list = tlist.list;
				if (this._modifierKey1 != ModifierKey.None)
				{
					string text = Keyboard.FdqjQnteTucAfKvEcwKgTkUINPZhb(this._modifierKey1);
					if (text == null)
					{
						return 0;
					}
					list.Add(text);
				}
				if (this._modifierKey2 != ModifierKey.None)
				{
					string text2 = Keyboard.FdqjQnteTucAfKvEcwKgTkUINPZhb(this._modifierKey2);
					if (text2 == null)
					{
						return 0;
					}
					list.Add(text2);
				}
				if (this._modifierKey3 != ModifierKey.None)
				{
					string text3 = Keyboard.FdqjQnteTucAfKvEcwKgTkUINPZhb(this._modifierKey3);
					if (text3 == null)
					{
						return 0;
					}
					list.Add(text3);
				}
				for (int i = 0; i < list.Count; i++)
				{
					A_1.Add(list[i]);
				}
			}
			A_1.Add(finalGlyphKey);
			return A_1.Count - count;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00046624 File Offset: 0x00044824
		internal void rErenmVlDpOKWgehhlDnVYBzQEz()
		{
			this._actionCategoryId = -1;
			this._actionId = -1;
			this._elementType = ControllerElementType.Axis;
			this._elementIdentifierId = -1;
			this._axisRange = AxisRange.Full;
			this._invert = false;
			this._axisContribution = Pole.Positive;
			this._keyboardKeyCode = KeyboardKeyCode.None;
			this._modifierKey1 = ModifierKey.None;
			this._modifierKey2 = ModifierKey.None;
			this._modifierKey3 = ModifierKey.None;
			this.NNDdFGwfHOMtmloXpknTohmlGIGT = null;
			this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = true;
			this.zhbDDcxpqLPKysVlukCrwYGdqCaS = null;
			this.iYXtOkkokIhLdgbtwKrjIhfcNnqW = null;
			this.QLNNoLPNnFrAWEfHaFAvPwzkiRwU = 0U;
			this.kzteAhfhIrTzNCdHchaFtnLuoTRn = ModifierKeyFlags.None;
			this.mRCBQDgzARDPVbNsvhiBadcDxEwTB = -1;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0000A169 File Offset: 0x00008369
		private bool NTmJlnMfrDVJyMRdpJzpYEWaHUfx(KeyboardKeyCode A_1, ModifierKeyFlags A_2)
		{
			return this._elementType == ControllerElementType.Button && A_1 != KeyboardKeyCode.None && this._keyboardKeyCode == A_1 && Keyboard.UVekDNaaaHgaveFOtjBsGWwqZiBWA(this.modifierKeyFlags) == Keyboard.UVekDNaaaHgaveFOtjBsGWwqZiBWA(A_2);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x000466B0 File Offset: 0x000448B0
		private bool nZNhRCrTGBaEBVSSHgvSGmFmFdeQA(int A_1, AxisRange A_2)
		{
			if (this._elementIdentifierId != A_1)
			{
				return false;
			}
			if (this._elementType == ControllerElementType.Button)
			{
				return true;
			}
			if (this._elementType == ControllerElementType.Axis)
			{
				return this._axisRange == AxisRange.Full || A_2 == AxisRange.Full || (this._axisRange == AxisRange.Positive && A_2 == AxisRange.Positive) || (this._axisRange == AxisRange.Negative && A_2 == AxisRange.Negative);
			}
			throw new NotImplementedException();
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0000A19C File Offset: 0x0000839C
		private bool blPzvPmpBbcIuNjBxaeEuSOiXlro(ElementAssignmentType A_1)
		{
			if (this._elementType == ControllerElementType.Button)
			{
				if (A_1 == ElementAssignmentType.Button || A_1 == ElementAssignmentType.KeyboardKey)
				{
					return true;
				}
			}
			else
			{
				if (this._elementType != ControllerElementType.Axis)
				{
					throw new NotImplementedException();
				}
				if (A_1 == ElementAssignmentType.FullAxis || A_1 == ElementAssignmentType.SplitAxis)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0000A1C9 File Offset: 0x000083C9
		private void KcXXMzQwHnOXsTfAgvKKpcvvZJVq()
		{
			this._elementIdentifierId = Keyboard.IFoSAsBTTtpfVdkaUlCcapmfGYci(this._keyboardKeyCode);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0000A1DC File Offset: 0x000083DC
		private void alLtuiDcLkmRLxdxmjEOYtbhUmhv()
		{
			if (this._elementIdentifierId < 0)
			{
				this._keyboardKeyCode = KeyboardKeyCode.None;
				return;
			}
			if (!ReInput.isReady)
			{
				return;
			}
			this._keyboardKeyCode = Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.TaTrTHwUgSOiWrsYvUpTqAIgrPne.GetKeyCodeById(this._elementIdentifierId));
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00046710 File Offset: 0x00044910
		private void kxlfyYafyrxNTFtovnEsMhtftzCI()
		{
			if (this._modifierKey1 != ModifierKey.None)
			{
				if (this._modifierKey1 == this._modifierKey2)
				{
					this._modifierKey2 = ModifierKey.None;
				}
				if (this._modifierKey1 == this._modifierKey3)
				{
					this._modifierKey3 = ModifierKey.None;
				}
			}
			if (this._modifierKey2 != ModifierKey.None && this._modifierKey2 == this._modifierKey3)
			{
				this._modifierKey3 = ModifierKey.None;
			}
			if (this._modifierKey3 != ModifierKey.None && this._modifierKey2 == ModifierKey.None)
			{
				this._modifierKey2 = this._modifierKey3;
				this._modifierKey3 = ModifierKey.None;
			}
			if (this._modifierKey2 != ModifierKey.None && this._modifierKey1 == ModifierKey.None)
			{
				this._modifierKey1 = this._modifierKey2;
				this._modifierKey2 = ModifierKey.None;
			}
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000467B4 File Offset: 0x000449B4
		internal SerializedObject rsOAdCguLNDFfxcMNarlfYblvkOrA()
		{
			return new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object)
			{
				{
					"actionCategoryId",
					this._actionCategoryId,
					SerializedObject.FieldOptions.None
				},
				{
					"actionId",
					this._actionId,
					SerializedObject.FieldOptions.None
				},
				{
					"elementType",
					this._elementType,
					SerializedObject.FieldOptions.None
				},
				{
					"elementIdentifierId",
					this._elementIdentifierId,
					SerializedObject.FieldOptions.None
				},
				{
					"axisRange",
					this._axisRange,
					SerializedObject.FieldOptions.None
				},
				{
					"invert",
					this._invert,
					SerializedObject.FieldOptions.None
				},
				{
					"axisContribution",
					this._axisContribution,
					SerializedObject.FieldOptions.None
				},
				{
					"keyboardKeyCode",
					this._keyboardKeyCode,
					SerializedObject.FieldOptions.None
				},
				{
					"modifierKey1",
					this._modifierKey1,
					SerializedObject.FieldOptions.None
				},
				{
					"modifierKey2",
					this._modifierKey2,
					SerializedObject.FieldOptions.None
				},
				{
					"modifierKey3",
					this._modifierKey3,
					SerializedObject.FieldOptions.None
				},
				{
					"enabled",
					this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA,
					SerializedObject.FieldOptions.None
				}
			};
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x000468A8 File Offset: 0x00044AA8
		internal void jDXBmuWueOfuvhElQmjIrsZoRVLz(SerializedObject A_1)
		{
			this._actionCategoryId = -1;
			this._actionId = -1;
			this._elementIdentifierId = -1;
			this._axisRange = AxisRange.Full;
			this._invert = false;
			this._axisContribution = Pole.Positive;
			this._keyboardKeyCode = KeyboardKeyCode.None;
			this._modifierKey1 = ModifierKey.None;
			this._modifierKey2 = ModifierKey.None;
			this._modifierKey3 = ModifierKey.None;
			this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = true;
			A_1.TryGetDeserializedValueByRef<int>("actionCategoryId", ref this._actionCategoryId);
			A_1.TryGetDeserializedValueByRef<int>("actionId", ref this._actionId);
			A_1.TryGetDeserializedValueByRef<ControllerElementType>("elementType", ref this._elementType);
			A_1.TryGetDeserializedValueByRef<int>("elementIdentifierId", ref this._elementIdentifierId);
			A_1.TryGetDeserializedValueByRef<AxisRange>("axisRange", ref this._axisRange);
			A_1.TryGetDeserializedValueByRef<bool>("invert", ref this._invert);
			A_1.TryGetDeserializedValueByRef<Pole>("axisContribution", ref this._axisContribution);
			A_1.TryGetDeserializedValueByRef<KeyboardKeyCode>("keyboardKeyCode", ref this._keyboardKeyCode);
			A_1.TryGetDeserializedValueByRef<ModifierKey>("modifierKey1", ref this._modifierKey1);
			A_1.TryGetDeserializedValueByRef<ModifierKey>("modifierKey2", ref this._modifierKey2);
			A_1.TryGetDeserializedValueByRef<ModifierKey>("modifierKey3", ref this._modifierKey3);
			A_1.TryGetDeserializedValueByRef<bool>("enabled", ref this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000469DC File Offset: 0x00044BDC
		public override string ToString()
		{
			if (ActionElementMap.s_toStringSB == null)
			{
				ActionElementMap.s_toStringSB = new StringBuilder();
			}
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Id", this.pGMbotKVdjNowDvSSfgThIWDmLSHB);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Enabled", this.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Controller Map Id", (this.NNDdFGwfHOMtmloXpknTohmlGIGT != null) ? this.NNDdFGwfHOMtmloXpknTohmlGIGT.id : -1);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Action Id", this._actionId);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Action Descriptive Name", this.actionDescriptiveName);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Element Type", this._elementType);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Element Identifier Id", this._elementIdentifierId);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Element Index", this.mRCBQDgzARDPVbNsvhiBadcDxEwTB);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Axis Range", this._axisRange);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Invert", this._invert);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Axis Contribution", this._axisContribution);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Keyboard Key Code", this._keyboardKeyCode);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Has Modifiers", this.hasModifiers);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "Modifier Key 1", this._modifierKey1);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "modifier Key 2", this._modifierKey2);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "modifier Key 3", this._modifierKey3);
			StringTools.WriteVar(ActionElementMap.s_toStringSB, "modifier Key Flags", this.modifierKeyFlags);
			string result = ActionElementMap.s_toStringSB.ToString();
			ActionElementMap.s_toStringSB.Length = 0;
			return result;
		}

		// Token: 0x04000738 RID: 1848
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionCategoryId;

		// Token: 0x04000739 RID: 1849
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionId;

		// Token: 0x0400073A RID: 1850
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ControllerElementType _elementType;

		// Token: 0x0400073B RID: 1851
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _elementIdentifierId;

		// Token: 0x0400073C RID: 1852
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal AxisRange _axisRange;

		// Token: 0x0400073D RID: 1853
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal bool _invert;

		// Token: 0x0400073E RID: 1854
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal Pole _axisContribution;

		// Token: 0x0400073F RID: 1855
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal KeyboardKeyCode _keyboardKeyCode;

		// Token: 0x04000740 RID: 1856
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey1;

		// Token: 0x04000741 RID: 1857
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey2;

		// Token: 0x04000742 RID: 1858
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey3;

		// Token: 0x04000743 RID: 1859
		[NonSerialized]
		internal ControllerMap NNDdFGwfHOMtmloXpknTohmlGIGT;

		// Token: 0x04000744 RID: 1860
		[NonSerialized]
		internal bool kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = true;

		// Token: 0x04000745 RID: 1861
		[NonSerialized]
		internal int mRCBQDgzARDPVbNsvhiBadcDxEwTB;

		// Token: 0x04000746 RID: 1862
		[NonSerialized]
		internal readonly int pGMbotKVdjNowDvSSfgThIWDmLSHB;

		// Token: 0x04000747 RID: 1863
		[NonSerialized]
		private uint QLNNoLPNnFrAWEfHaFAvPwzkiRwU;

		// Token: 0x04000748 RID: 1864
		[NonSerialized]
		private string zhbDDcxpqLPKysVlukCrwYGdqCaS;

		// Token: 0x04000749 RID: 1865
		[NonSerialized]
		private string iYXtOkkokIhLdgbtwKrjIhfcNnqW;

		// Token: 0x0400074A RID: 1866
		[NonSerialized]
		private ModifierKeyFlags kzteAhfhIrTzNCdHchaFtnLuoTRn;

		// Token: 0x0400074B RID: 1867
		[NonSerialized]
		private HardwareControllerMap_Game wfFHDOooFKfjdMCKziamOGoJrbSL;

		// Token: 0x0400074C RID: 1868
		private static int uidCounter;

		// Token: 0x0400074D RID: 1869
		private static StringBuilder s_toStringSB;
	}
}
