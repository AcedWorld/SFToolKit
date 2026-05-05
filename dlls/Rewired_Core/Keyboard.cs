using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200005F RID: 95
	public sealed class Keyboard : ControllerWithMap
	{
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00035CF8 File Offset: 0x00033EF8
		private static KeyboardKeyCode[] cXCdpWiPhBoaZCrtClzVDEwUKHAGc
		{
			get
			{
				if (Keyboard.xXAGPNQSGNwVPguzQTHHKHfaSVaA == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					Keyboard.xXAGPNQSGNwVPguzQTHHKHfaSVaA = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						Keyboard.xXAGPNQSGNwVPguzQTHHKHfaSVaA[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return Keyboard.xXAGPNQSGNwVPguzQTHHKHfaSVaA;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00035D3C File Offset: 0x00033F3C
		private Dictionary<int, Keyboard.pfzPNAtLrqZoVhhdUhwWeciWCiDcb> GlLQfrvQUwELGcidlkBHDezAacCU
		{
			get
			{
				if (this.RGKDcukVWRNwMosFvVJwAuqjqHbw == null)
				{
					IEnumerable<KeyValuePair<int, Keyboard.ModifierKeyInfo>> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, Keyboard.pfzPNAtLrqZoVhhdUhwWeciWCiDcb> dictionary = new Dictionary<int, Keyboard.pfzPNAtLrqZoVhhdUhwWeciWCiDcb>();
					foreach (KeyValuePair<int, Keyboard.ModifierKeyInfo> keyValuePair in modifierKeyInfo)
					{
						if (keyValuePair.Key != 0)
						{
							dictionary.Add(keyValuePair.Key, new Keyboard.pfzPNAtLrqZoVhhdUhwWeciWCiDcb(keyValuePair.Value.shortKey, keyValuePair.Value.longKey));
						}
					}
					this.RGKDcukVWRNwMosFvVJwAuqjqHbw = dictionary;
				}
				return this.RGKDcukVWRNwMosFvVJwAuqjqHbw;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00035DD0 File Offset: 0x00033FD0
		private Dictionary<int, Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl> KeJolmwhSGyKrLNpcDJxcGckqPpuA
		{
			get
			{
				if (this.RVuDyFLXYNDqvjxKSbIiGUCpNzAX == null)
				{
					IEnumerable<KeyValuePair<int, Keyboard.ModifierKeyInfo>> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl> dictionary = new Dictionary<int, Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl>();
					foreach (KeyValuePair<int, Keyboard.ModifierKeyInfo> keyValuePair in modifierKeyInfo)
					{
						if (keyValuePair.Key != 0)
						{
							Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl value = new Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl(new KeyedGlyph());
							dictionary.Add(keyValuePair.Key, value);
						}
					}
					this.RVuDyFLXYNDqvjxKSbIiGUCpNzAX = dictionary;
				}
				return this.RVuDyFLXYNDqvjxKSbIiGUCpNzAX;
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00035E54 File Offset: 0x00034054
		internal Keyboard(string A_1, IUnifiedKeyboardSource A_2) : this(0, A_2.inputSource, A_1, InputTools.FormatHardwareIdentifierString(A_1), A_2.hardwareMap, 132, (A_2 != null) ? A_2.controllerExtension : null, new ControllerDataUpdater(A_2.inputSource, 0, 132, null))
		{
			Keyboard.GkKbFVcXVEBzeCYkakrhZYwDUfID = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			this.ANvpxyZzbUUEYiWuwuOWBmSqKnJu = new bCHqIsWsJLmmIkpuWMBAcITGmVCV(new Action(this.SFRBPvLQfMuoxOUrXNMthFJMcTeDA));
			this.YVjnUZQDoZFaIBuWmkzhUYWjsVrw = new dsuEdngwoNruBIzguTitTUraCkOc(new Action(this.BAxrGYyaYmptfAwQNRzzuFElHlFV));
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
				{
					this.rqfvHvasFXDnqDRUoBUUWieZuGGI = keyboardKeyValues[i];
				}
			}
			this.LWTbjNWfNjDvePNBzUKoPHzERRnJ = new int[this.rqfvHvasFXDnqDRUoBUUWieZuGGI + 1];
			ArrayTools.Fill<int>(this.LWTbjNWfNjDvePNBzUKoPHzERRnJ, -1);
			for (int j = 0; j < num; j++)
			{
				this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[keyboardKeyValues[j]] = j;
			}
			this.VqNcuFhgDQhqIcsACpYgIEJaJTaWe = A_2;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((qRARPoZhenAEzvKQshZvLFcmqQCG)this.ANvpxyZzbUUEYiWuwuOWBmSqKnJu).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)this.YVjnUZQDoZFaIBuWmkzhUYWjsVrw).Prefetch();
			}
			this.qEnvtUAzINATYqQGwxMxBBiSsAkj();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00035F7C File Offset: 0x0003417C
		private Keyboard(int A_1, InputSource A_2, string A_3, string A_4, HardwareControllerMap_Game A_5, int A_6, Controller.Extension A_7, ControllerDataUpdater A_8) : base(A_1, A_2, A_3, A_3, A_4, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, A_6, null, A_5, A_7, A_8)
		{
			Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB = this;
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x00005F50 File Offset: 0x00004150
		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Guid.Empty;
				}
				return Keyboard.GkKbFVcXVEBzeCYkakrhZYwDUfID;
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00035FAC File Offset: 0x000341AC
		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].value;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00035FFC File Offset: 0x000341FC
		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].justPressed;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0003604C File Offset: 0x0003424C
		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].justReleased;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0003609C File Offset: 0x0003429C
		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].DoublePressedAndHeld(speed);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000360EC File Offset: 0x000342EC
		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].DoublePressedAndHeld(0f);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00036128 File Offset: 0x00034328
		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].JustDoublePressed(speed);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00036178 File Offset: 0x00034378
		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].JustDoublePressed(0f);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000361CC File Offset: 0x000343CC
		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			return num >= 0 && this.buttons[num].valuePrev;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0003621C File Offset: 0x0003441C
		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return 0.0;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return this.buttons[num].timePressed;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00036284 File Offset: 0x00034484
		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return 0.0;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return this.buttons[num].timeUnpressed;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000362EC File Offset: 0x000344EC
		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			Controller.Button button;
			Controller.Button button2;
			return this.yRNvpxUXsXlrzYQIzADQXgkuciet(out button, out button2, key) && (button.value || button2.value);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00036338 File Offset: 0x00034538
		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			Controller.Button button;
			Controller.Button button2;
			return this.yRNvpxUXsXlrzYQIzADQXgkuciet(out button, out button2, key) && (button.value || button2.value) && !button.valuePrev && !button2.valuePrev;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00036394 File Offset: 0x00034594
		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			Controller.Button button;
			Controller.Button button2;
			return this.yRNvpxUXsXlrzYQIzADQXgkuciet(out button, out button2, key) && !button.value && !button2.value && (button.valuePrev || button2.valuePrev);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x000363F0 File Offset: 0x000345F0
		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			Controller.Button button;
			Controller.Button button2;
			return this.yRNvpxUXsXlrzYQIzADQXgkuciet(out button, out button2, key) && (button.valuePrev || button2.valuePrev);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0003643C File Offset: 0x0003463C
		public double GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			Controller.Button button;
			Controller.Button button2;
			if (!this.yRNvpxUXsXlrzYQIzADQXgkuciet(out button, out button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00036494 File Offset: 0x00034694
		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			Controller.Button button;
			Controller.Button button2;
			if (!this.yRNvpxUXsXlrzYQIzADQXgkuciet(out button, out button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00005F76 File Offset: 0x00004176
		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return KeyCode.None;
			}
			return Keyboard.NYIQPzfILwVDAWhVUEBibPLJKiDUA(Keyboard.GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00005F9E File Offset: 0x0000419E
		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return KeyCode.None;
			}
			return this.GetKeyCodeByButtonIndex(base.GetButtonIndexById(elementIdentifierId));
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00005FC8 File Offset: 0x000041C8
		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return -1;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return -1;
			}
			return this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000364EC File Offset: 0x000346EC
		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			if (keyCode > (KeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return null;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifiers_cache[num];
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0003653C File Offset: 0x0003473C
		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (this.GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, Keyboard.GetKeyName(keyCode), this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00005FF8 File Offset: 0x000041F8
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			int count = Consts.keyboardKeyValues.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (this.GetKey(keyCode))
				{
					yield return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, Keyboard.GetKeyName(keyCode), this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifierIds[i], keyCode);
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00006008 File Offset: 0x00004208
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			int count = Consts.keyboardKeyValues.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (this.GetKeyDown(keyCode))
				{
					yield return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, Keyboard.GetKeyName(keyCode), this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifierIds[i], keyCode);
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x000365CC File Offset: 0x000347CC
		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (this.GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, Keyboard.GetKeyName(keyCode), this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00006018 File Offset: 0x00004218
		public override ControllerPollingInfo PollForFirstButton()
		{
			return this.PollForFirstKey();
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00006020 File Offset: 0x00004220
		public override ControllerPollingInfo PollForFirstButtonDown()
		{
			return this.PollForFirstKeyDown();
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00006028 File Offset: 0x00004228
		public override IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return this.PollForAllKeys();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00006030 File Offset: 0x00004230
		public override IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return this.PollForAllKeysDown();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00006038 File Offset: 0x00004238
		public static bool IsModifierKey(KeyCode key)
		{
			return key != KeyCode.None && key - KeyCode.RightShift <= 7;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00006038 File Offset: 0x00004238
		internal static bool XqnjpppgtijCVhzfMBKTjWIDmjMD(KeyboardKeyCode A_0)
		{
			return A_0 != KeyboardKeyCode.None && A_0 - KeyboardKeyCode.RightShift <= 7;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000604E File Offset: 0x0000424E
		public static ModifierKey KeyCodeToModifierKey(KeyCode key)
		{
			if (key == KeyCode.None)
			{
				return ModifierKey.None;
			}
			switch (key)
			{
			case KeyCode.RightShift:
			case KeyCode.LeftShift:
				return ModifierKey.Shift;
			case KeyCode.RightControl:
			case KeyCode.LeftControl:
				return ModifierKey.Control;
			case KeyCode.RightAlt:
			case KeyCode.LeftAlt:
				return ModifierKey.Alt;
			case KeyCode.RightMeta:
			case KeyCode.LeftMeta:
				return ModifierKey.Command;
			default:
				return ModifierKey.None;
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0003665C File Offset: 0x0003485C
		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.RightShift:
				return ModifierKeyFlags.RightShift;
			case KeyCode.LeftShift:
				return ModifierKeyFlags.LeftShift;
			case KeyCode.RightControl:
				return ModifierKeyFlags.RightControl;
			case KeyCode.LeftControl:
				return ModifierKeyFlags.LeftControl;
			case KeyCode.RightAlt:
				return ModifierKeyFlags.RightAlt;
			case KeyCode.LeftAlt:
				return ModifierKeyFlags.LeftAlt;
			case KeyCode.RightMeta:
				return ModifierKeyFlags.RightCommand;
			case KeyCode.LeftMeta:
				return ModifierKeyFlags.LeftCommand;
			default:
				return ModifierKeyFlags.None;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000366B0 File Offset: 0x000348B0
		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
			switch (key)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				return (flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl || (flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl;
			case ModifierKey.Alt:
				return (flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt || (flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt;
			case ModifierKey.Shift:
				return (flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift || (flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift;
			case ModifierKey.Command:
				return (flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand || (flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand;
			default:
				return false;
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00036734 File Offset: 0x00034934
		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			if (key == KeyCode.None)
			{
				return false;
			}
			switch (key)
			{
			case KeyCode.RightShift:
				return (flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift;
			case KeyCode.LeftShift:
				return (flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift;
			case KeyCode.RightControl:
				return (flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl;
			case KeyCode.LeftControl:
				return (flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl;
			case KeyCode.RightAlt:
				return (flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt;
			case KeyCode.LeftAlt:
				return (flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt;
			case KeyCode.RightMeta:
				return (flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand;
			case KeyCode.LeftMeta:
				return (flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand;
			default:
				return false;
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x000367D4 File Offset: 0x000349D4
		public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return ModifierKey.Command;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return ModifierKey.Command;
			}
			return ModifierKey.None;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00036830 File Offset: 0x00034A30
		public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return KeyCode.LeftControl;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return KeyCode.RightControl;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return KeyCode.LeftAlt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return KeyCode.RightAlt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return KeyCode.LeftShift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return KeyCode.RightShift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return KeyCode.LeftMeta;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return KeyCode.RightMeta;
			}
			return KeyCode.None;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000608C File Offset: 0x0000428C
		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			switch (key)
			{
			case ModifierKey.None:
				return ModifierKeyFlags.None;
			case ModifierKey.Control:
				return ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl;
			case ModifierKey.Alt:
				return ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt;
			case ModifierKey.Shift:
				return ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift;
			case ModifierKey.Command:
				return ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand;
			default:
				return ModifierKeyFlags.None;
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x000368AC File Offset: 0x00034AAC
		public static string GetKeyName(KeyCode key)
		{
			if (Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB == null)
			{
				return string.Empty;
			}
			int buttonIndex = Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.GetButtonIndex(Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.ButtonElementIdentifiers[buttonIndex].name;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x000368F8 File Offset: 0x00034AF8
		public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
		{
			string text = Keyboard.GetKeyName(key);
			if (flags != ModifierKeyFlags.None)
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				stringBuilder.Append(" + ");
				stringBuilder.Append(Keyboard.ModifierKeyFlagsToString(flags));
				text = stringBuilder.ToString();
			}
			return text;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000060BB File Offset: 0x000042BB
		public static string GetModifierKeyName(ModifierKey modifierKey)
		{
			if (Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB == null)
			{
				return string.Empty;
			}
			return Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.rkIcZwwhOClYBFfuSfxznfYtomkO(modifierKey, false);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000060D6 File Offset: 0x000042D6
		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB == null)
			{
				return string.Empty;
			}
			return Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.rkIcZwwhOClYBFfuSfxznfYtomkO(modifierKey, getShortName);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00036938 File Offset: 0x00034B38
		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool getShortName)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Control))
			{
				stringBuilder.Append(Keyboard.GetModifierKeyName(ModifierKey.Control, getShortName));
				num++;
			}
			if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Command))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(Keyboard.GetModifierKeyName(ModifierKey.Command, getShortName));
				num++;
			}
			if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Alt))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(Keyboard.GetModifierKeyName(ModifierKey.Alt, getShortName));
				num++;
			}
			if (num >= 3)
			{
				return stringBuilder.ToString();
			}
			if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Shift))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(Keyboard.GetModifierKeyName(ModifierKey.Shift, getShortName));
				num++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000060F1 File Offset: 0x000042F1
		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return Keyboard.ModifierKeyFlagsToString(flags, false);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000060FA File Offset: 0x000042FA
		public static object GetModifierKeyGlyph(ModifierKey modifierKey)
		{
			if (Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB == null)
			{
				return null;
			}
			return Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.FcPEkaHzaezaxGnLqSFnrkfImifi(modifierKey);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00006110 File Offset: 0x00004310
		internal static string FdqjQnteTucAfKvEcwKgTkUINPZhb(ModifierKey A_0)
		{
			if (Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB == null)
			{
				return string.Empty;
			}
			return Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.PISAGQOeEKUnjSdzSQCYGovvCcaz(A_0);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000612A File Offset: 0x0000432A
		internal static KeyboardKeyCode VsDTJkbqYgxyNEBuoIqHeiiGBbXu(KeyCode A_0)
		{
			return (KeyboardKeyCode)A_0;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000612A File Offset: 0x0000432A
		internal static KeyCode NYIQPzfILwVDAWhVUEBibPLJKiDUA(KeyboardKeyCode A_0)
		{
			return (KeyCode)A_0;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x000369FC File Offset: 0x00034BFC
		internal static ModifierKeyFlags UVekDNaaaHgaveFOtjBsGWwqZiBWA(ModifierKeyFlags A_0)
		{
			if ((A_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				A_0 |= ModifierKeyFlags.RightControl;
			}
			if ((A_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				A_0 |= ModifierKeyFlags.LeftControl;
			}
			if ((A_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				A_0 |= ModifierKeyFlags.RightCommand;
			}
			if ((A_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				A_0 |= ModifierKeyFlags.LeftCommand;
			}
			if ((A_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				A_0 |= ModifierKeyFlags.RightAlt;
			}
			if ((A_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				A_0 |= ModifierKeyFlags.LeftAlt;
			}
			if ((A_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				A_0 |= ModifierKeyFlags.RightShift;
			}
			if ((A_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				A_0 |= ModifierKeyFlags.LeftShift;
			}
			return A_0;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00036A78 File Offset: 0x00034C78
		internal static int uhPnaQuSkkpXFbbpixqWvezwdZyfA(ModifierKeyFlags A_0)
		{
			if (A_0 == ModifierKeyFlags.None)
			{
				return 0;
			}
			int num = 0;
			if ((A_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				num++;
			}
			else if ((A_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				num++;
			}
			if ((A_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				num++;
			}
			else if ((A_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				num++;
			}
			if ((A_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num++;
			}
			else if ((A_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				num++;
			}
			if ((A_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				num++;
			}
			else if ((A_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				num++;
			}
			return num;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000612D File Offset: 0x0000432D
		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			if (buttonIndex > 132)
			{
				return KeyboardKeyCode.None;
			}
			return Keyboard.cXCdpWiPhBoaZCrtClzVDEwUKHAGc[buttonIndex];
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00036AF4 File Offset: 0x00034CF4
		internal static int IFoSAsBTTtpfVdkaUlCcapmfGYci(KeyboardKeyCode A_0)
		{
			int buttonIndex = Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.GetButtonIndex(A_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return Keyboard.KzwdzTbHobHspfLIbkCiDasLBCCeB.ButtonElementIdentifiers[buttonIndex].id;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00006140 File Offset: 0x00004340
		internal static void FdiUlMlPThEdJiDeaiGhYbnwVhVoA(ref int A_0, ref KeyCode A_1)
		{
			if (A_1 != KeyCode.None)
			{
				A_0 = Keyboard.IFoSAsBTTtpfVdkaUlCcapmfGYci(Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(A_1));
				return;
			}
			A_1 = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.TaTrTHwUgSOiWrsYvUpTqAIgrPne.GetKeyCodeById(A_0);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00006168 File Offset: 0x00004368
		internal void zCUrtrmIVmpEtTJPEanPHRumaiTMA(UpdateLoopType A_1)
		{
			this.VqNcuFhgDQhqIcsACpYgIEJaJTaWe.UpdateInputData(this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			base.FQTBjLASwKIywYemFGwowQCkCzxHA(A_1);
			this.zcyVrVEMKwbnrCAxNSmedBNRFLKDA();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00036B28 File Offset: 0x00034D28
		internal void MKKcvYIJUiNkQqdmOLKxseeMfOYbA(UpdateLoopType A_1)
		{
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			this.buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00036C00 File Offset: 0x00034E00
		internal bool dtbNfKRpqlPOUvoMhjRHJLMfDbGx(KeyboardKeyCode A_1)
		{
			if (A_1 > (KeyboardKeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)A_1];
			return num >= 0 && this.buttons[num].value;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00036C34 File Offset: 0x00034E34
		internal bool UZEuMkeooKDDHyajIBawMcZAWGuU(KeyboardKeyCode A_1)
		{
			if (A_1 > (KeyboardKeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return false;
			}
			int num = this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)A_1];
			return num >= 0 && this.buttons[num].valuePrev;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00036C68 File Offset: 0x00034E68
		internal bool dokynBuAaDKzLWczKTaNWvdpJtZF(KeyboardKeyCode A_1, ModifierKeyFlags A_2)
		{
			if (!this.dtbNfKRpqlPOUvoMhjRHJLMfDbGx(A_1))
			{
				return false;
			}
			if (A_2 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((A_2 & this.iQVvbYoaLpNgDFllCjqMKYuCVzBKA) != A_2)
			{
				return false;
			}
			double keyTimePressed = this.GetKeyTimePressed((KeyCode)A_1);
			return ((A_2 & ModifierKeyFlags.LeftControl) != ModifierKeyFlags.LeftControl || keyTimePressed <= this.GetModifierKeyTimePressed(ModifierKey.Control)) && ((A_2 & ModifierKeyFlags.LeftCommand) != ModifierKeyFlags.LeftCommand || keyTimePressed <= this.GetModifierKeyTimePressed(ModifierKey.Command)) && ((A_2 & ModifierKeyFlags.LeftAlt) != ModifierKeyFlags.LeftAlt || keyTimePressed <= this.GetModifierKeyTimePressed(ModifierKey.Alt)) && ((A_2 & ModifierKeyFlags.LeftShift) != ModifierKeyFlags.LeftShift || keyTimePressed <= this.GetModifierKeyTimePressed(ModifierKey.Shift));
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00006188 File Offset: 0x00004388
		internal bool DToblyCVQhPJqeCHpUlrEBfQHhKiA(KeyboardKeyCode A_1, ModifierKeyFlags A_2)
		{
			return this.dtbNfKRpqlPOUvoMhjRHJLMfDbGx(A_1) || this.GetModifierKey(Keyboard.ModifierKeyFlagsToModifierKey(A_2));
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x000061A6 File Offset: 0x000043A6
		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			if (keyCode > (KeyboardKeyCode)this.rqfvHvasFXDnqDRUoBUUWieZuGGI)
			{
				return -1;
			}
			return this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[(int)keyCode];
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00036CE8 File Offset: 0x00034EE8
		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap == null)
			{
				return;
			}
			IList<ActionElementMap> list = controllerMap.DWkEfFJRIhxezCgjNNPhQPxZoAPO;
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				this.ZIaqgsDccGvTITgnjUFeFXRKbtuj(controllerMap, list[i]);
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000061BB File Offset: 0x000043BB
		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			if (map == null)
			{
				return;
			}
			map.YmjBUAFlEbXvUpfGfovFCfjkhaLrc(controllerMap);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000061C8 File Offset: 0x000043C8
		internal void IFkpVCCfdKLKUucpOQtVlfywEUWh()
		{
			base.teTpHyJcIRafhlIJVTCUfrhAktlq();
			this.DsVtFoIbNJvmFfoiAljIDvyZYppf = ModifierKeyFlags.None;
			this.iQVvbYoaLpNgDFllCjqMKYuCVzBKA = ModifierKeyFlags.None;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000061DE File Offset: 0x000043DE
		internal bool XEcOMWBceTSfHVZDssjkyHoDGMdiA(bool A_1)
		{
			if (!base.YiinlzRStddWAaeiqMWoRMYdMJYK(A_1))
			{
				return false;
			}
			if (this.VqNcuFhgDQhqIcsACpYgIEJaJTaWe is IGetSetEnabled)
			{
				(this.VqNcuFhgDQhqIcsACpYgIEJaJTaWe as IGetSetEnabled).enabled = A_1;
			}
			return true;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00036D24 File Offset: 0x00034F24
		private bool yRNvpxUXsXlrzYQIzADQXgkuciet(out Controller.Button A_1, out Controller.Button A_2, ModifierKey A_3)
		{
			A_1 = null;
			A_2 = null;
			switch (A_3)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				A_1 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[306]];
				A_2 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[305]];
				return true;
			case ModifierKey.Alt:
				A_1 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[308]];
				A_2 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[307]];
				return true;
			case ModifierKey.Shift:
				A_1 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[304]];
				A_2 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[303]];
				return true;
			case ModifierKey.Command:
				A_1 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[310]];
				A_2 = this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[309]];
				return true;
			default:
				return false;
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00036E0C File Offset: 0x0003500C
		private void zcyVrVEMKwbnrCAxNSmedBNRFLKDA()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (this.buttons[this.LWTbjNWfNjDvePNBzUKoPHzERRnJ[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			this.DsVtFoIbNJvmFfoiAljIDvyZYppf = modifierKeyFlags;
			this.iQVvbYoaLpNgDFllCjqMKYuCVzBKA = Keyboard.UVekDNaaaHgaveFOtjBsGWwqZiBWA(modifierKeyFlags);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00036F28 File Offset: 0x00035128
		private string rkIcZwwhOClYBFfuSfxznfYtomkO(ModifierKey A_1, bool A_2)
		{
			if (A_1 == ModifierKey.None)
			{
				return string.Empty;
			}
			Keyboard.ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)A_1];
			string name = modifierKeyInfo.GetName(A_2);
			if (!LocalizationManager.isEnabled)
			{
				return name;
			}
			Keyboard.pfzPNAtLrqZoVhhdUhwWeciWCiDcb pfzPNAtLrqZoVhhdUhwWeciWCiDcb;
			if (!this.GlLQfrvQUwELGcidlkBHDezAacCU.TryGetValue((int)A_1, out pfzPNAtLrqZoVhhdUhwWeciWCiDcb))
			{
				return name;
			}
			if (A_2)
			{
				string result;
				if (pfzPNAtLrqZoVhhdUhwWeciWCiDcb.oWlMQaAmaeuZRUPoRGCJihueuDqD != null && Keyboard.SkhCWuhQwsCQvKlnugtRwQdClsct(pfzPNAtLrqZoVhhdUhwWeciWCiDcb.oWlMQaAmaeuZRUPoRGCJihueuDqD, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, this.WGnseNgKihPuTwMSEeDkNInQXGEb.deviceLocalizationInfo, out result))
				{
					return result;
				}
				if (pfzPNAtLrqZoVhhdUhwWeciWCiDcb.eXNHwpHfYPuSwflxBiWNnTBFtrKr != null && Keyboard.SkhCWuhQwsCQvKlnugtRwQdClsct(pfzPNAtLrqZoVhhdUhwWeciWCiDcb.eXNHwpHfYPuSwflxBiWNnTBFtrKr, modifierKeyInfo.longKey, modifierKeyInfo.longName, this.WGnseNgKihPuTwMSEeDkNInQXGEb.deviceLocalizationInfo, out result))
				{
					return result;
				}
				return name;
			}
			else
			{
				if (pfzPNAtLrqZoVhhdUhwWeciWCiDcb.eXNHwpHfYPuSwflxBiWNnTBFtrKr == null)
				{
					return name;
				}
				string result;
				Keyboard.SkhCWuhQwsCQvKlnugtRwQdClsct(pfzPNAtLrqZoVhhdUhwWeciWCiDcb.eXNHwpHfYPuSwflxBiWNnTBFtrKr, modifierKeyInfo.longKey, modifierKeyInfo.longName, this.WGnseNgKihPuTwMSEeDkNInQXGEb.deviceLocalizationInfo, out result);
				return result;
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00037004 File Offset: 0x00035204
		private static bool SkhCWuhQwsCQvKlnugtRwQdClsct(Keyboard.zfgcDwaSiICdVePMnTWlSunfcKVD A_0, string A_1, string A_2, DeviceLocalizationInfo A_3, out string A_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = pIxAfPCGFQRFBOwQPqPHNpZroQXw.YhyCZcwKukjhsGtlmpYBaTIHhRuF(A_0.jmdHKusNTJETbMtALhtqanyDmRYdA, A_1, "controller", A_2, A_3, qIdXPWaZDFjemNjbsLrswVoVIvUh.Keyboard, -1, AxisRange.Full, -1, out A_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				A_0.QOcdjMpIqQQPzTTIPOmtudGqAiHeA = ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) > LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None);
			}
			return A_0.QOcdjMpIqQQPzTTIPOmtudGqAiHeA;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00037044 File Offset: 0x00035244
		private object FcPEkaHzaezaxGnLqSFnrkfImifi(ModifierKey A_1)
		{
			if (A_1 == ModifierKey.None)
			{
				return null;
			}
			Keyboard.ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)A_1];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl wtepjxfEHMMcOPybXTVqyIZanEQl;
			if (!this.KeJolmwhSGyKrLNpcDJxcGckqPpuA.TryGetValue((int)A_1, out wtepjxfEHMMcOPybXTVqyIZanEQl))
			{
				return null;
			}
			object result;
			if (Keyboard.oDLNCjHZtjeKMKuxfaYNlkwndaKv(wtepjxfEHMMcOPybXTVqyIZanEQl, modifierKeyInfo.longKey, this.WGnseNgKihPuTwMSEeDkNInQXGEb.deviceLocalizationInfo, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0003709C File Offset: 0x0003529C
		private string PISAGQOeEKUnjSdzSQCYGovvCcaz(ModifierKey A_1)
		{
			if (A_1 == ModifierKey.None)
			{
				return null;
			}
			Keyboard.ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)A_1];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl wtepjxfEHMMcOPybXTVqyIZanEQl;
			if (!this.KeJolmwhSGyKrLNpcDJxcGckqPpuA.TryGetValue((int)A_1, out wtepjxfEHMMcOPybXTVqyIZanEQl))
			{
				return null;
			}
			string result;
			if (Keyboard.eVjiAyDAlzJYdBDYTclizQQjTTnW(wtepjxfEHMMcOPybXTVqyIZanEQl, modifierKeyInfo.longKey, this.WGnseNgKihPuTwMSEeDkNInQXGEb.deviceLocalizationInfo, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000370F4 File Offset: 0x000352F4
		private static bool oDLNCjHZtjeKMKuxfaYNlkwndaKv(Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl A_0, string A_1, DeviceLocalizationInfo A_2, out object A_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = RUpmbvJtGrVJvbLCXAeFqKfaIGHDA.uhyBUPgZaSJnZWmtZhovJoVdQOsSA(A_0.chgqfTOKhTdoRCBaLAkZgRcJKYeD, A_1, "controller", A_2, qIdXPWaZDFjemNjbsLrswVoVIvUh.Keyboard, -1, AxisRange.Full, -1, out A_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				A_0.IunFvtDIczfUnQvocAnLgtTyQkTdb = ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) > GlyphManager.GetAndUpdateGlyphResultFlags.None);
			}
			return A_0.IunFvtDIczfUnQvocAnLgtTyQkTdb;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00037130 File Offset: 0x00035330
		private static bool eVjiAyDAlzJYdBDYTclizQQjTTnW(Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl A_0, string A_1, DeviceLocalizationInfo A_2, out string A_3)
		{
			object obj;
			bool result = Keyboard.oDLNCjHZtjeKMKuxfaYNlkwndaKv(A_0, A_1, A_2, out obj);
			A_3 = A_0.chgqfTOKhTdoRCBaLAkZgRcJKYeD.cachedKey;
			return result;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00037154 File Offset: 0x00035354
		[CompilerGenerated]
		private void SFRBPvLQfMuoxOUrXNMthFJMcTeDA()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				this.rkIcZwwhOClYBFfuSfxznfYtomkO(values[i], true);
				this.rkIcZwwhOClYBFfuSfxznfYtomkO(values[i], false);
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0003719C File Offset: 0x0003539C
		[CompilerGenerated]
		private void BAxrGYyaYmptfAwQNRzzuFElHlFV()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				this.FcPEkaHzaezaxGnLqSFnrkfImifi(values[i]);
			}
		}

		// Token: 0x04000327 RID: 807
		private const string amFuoJNumlXFPMcOXHWMKwwEeNBY = " + ";

		// Token: 0x04000328 RID: 808
		private static Keyboard KzwdzTbHobHspfLIbkCiDasLBCCeB;

		// Token: 0x04000329 RID: 809
		private static KeyboardKeyCode[] xXAGPNQSGNwVPguzQTHHKHfaSVaA;

		// Token: 0x0400032A RID: 810
		private static Guid GkKbFVcXVEBzeCYkakrhZYwDUfID;

		// Token: 0x0400032B RID: 811
		private readonly IUnifiedKeyboardSource VqNcuFhgDQhqIcsACpYgIEJaJTaWe;

		// Token: 0x0400032C RID: 812
		private ModifierKeyFlags DsVtFoIbNJvmFfoiAljIDvyZYppf;

		// Token: 0x0400032D RID: 813
		private ModifierKeyFlags iQVvbYoaLpNgDFllCjqMKYuCVzBKA;

		// Token: 0x0400032E RID: 814
		private Func<KeyboardKeyCode, int> GWlbYUSHrmZMSFJFNOeVKxtdUuqD;

		// Token: 0x0400032F RID: 815
		private readonly int[] LWTbjNWfNjDvePNBzUKoPHzERRnJ;

		// Token: 0x04000330 RID: 816
		private readonly int rqfvHvasFXDnqDRUoBUUWieZuGGI;

		// Token: 0x04000331 RID: 817
		private readonly bCHqIsWsJLmmIkpuWMBAcITGmVCV ANvpxyZzbUUEYiWuwuOWBmSqKnJu;

		// Token: 0x04000332 RID: 818
		private readonly dsuEdngwoNruBIzguTitTUraCkOc YVjnUZQDoZFaIBuWmkzhUYWjsVrw;

		// Token: 0x04000333 RID: 819
		private Dictionary<int, Keyboard.pfzPNAtLrqZoVhhdUhwWeciWCiDcb> RGKDcukVWRNwMosFvVJwAuqjqHbw;

		// Token: 0x04000334 RID: 820
		private Dictionary<int, Keyboard.WtepjxfEHMMcOPybXTVqyIZanEQl> RVuDyFLXYNDqvjxKSbIiGUCpNzAX;

		// Token: 0x02000060 RID: 96
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class ModifierKeyInfo
		{
			// Token: 0x06000496 RID: 1174 RVA: 0x0000620A File Offset: 0x0000440A
			public ModifierKeyInfo(string A_1, string A_2, string A_3, string A_4)
			{
				this.shortName = A_1;
				this.longName = A_2;
				this.shortKey = A_3;
				this.longKey = A_4;
			}

			// Token: 0x06000497 RID: 1175 RVA: 0x0000622F File Offset: 0x0000442F
			public string GetName(bool useShort)
			{
				if (!useShort)
				{
					return this.longName;
				}
				return this.shortName;
			}

			// Token: 0x06000498 RID: 1176 RVA: 0x00006241 File Offset: 0x00004441
			public string GetKey(bool useShort)
			{
				if (!useShort)
				{
					return this.longKey;
				}
				return this.shortKey;
			}

			// Token: 0x04000335 RID: 821
			public readonly string shortName;

			// Token: 0x04000336 RID: 822
			public readonly string longName;

			// Token: 0x04000337 RID: 823
			public readonly string shortKey;

			// Token: 0x04000338 RID: 824
			public readonly string longKey;
		}

		// Token: 0x02000061 RID: 97
		private class pfzPNAtLrqZoVhhdUhwWeciWCiDcb
		{
			// Token: 0x06000499 RID: 1177 RVA: 0x00006253 File Offset: 0x00004453
			public pfzPNAtLrqZoVhhdUhwWeciWCiDcb(string A_1, string A_2)
			{
				if (!string.IsNullOrEmpty(A_1))
				{
					this.oWlMQaAmaeuZRUPoRGCJihueuDqD = new Keyboard.zfgcDwaSiICdVePMnTWlSunfcKVD(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(A_2))
				{
					this.eXNHwpHfYPuSwflxBiWNnTBFtrKr = new Keyboard.zfgcDwaSiICdVePMnTWlSunfcKVD(new LocalizedString());
				}
			}

			// Token: 0x04000339 RID: 825
			public readonly Keyboard.zfgcDwaSiICdVePMnTWlSunfcKVD oWlMQaAmaeuZRUPoRGCJihueuDqD;

			// Token: 0x0400033A RID: 826
			public readonly Keyboard.zfgcDwaSiICdVePMnTWlSunfcKVD eXNHwpHfYPuSwflxBiWNnTBFtrKr;
		}

		// Token: 0x02000062 RID: 98
		private sealed class zfgcDwaSiICdVePMnTWlSunfcKVD
		{
			// Token: 0x0600049A RID: 1178 RVA: 0x0000628B File Offset: 0x0000448B
			public zfgcDwaSiICdVePMnTWlSunfcKVD(LocalizedString A_1)
			{
				this.jmdHKusNTJETbMtALhtqanyDmRYdA = A_1;
			}

			// Token: 0x0400033B RID: 827
			public readonly LocalizedString jmdHKusNTJETbMtALhtqanyDmRYdA;

			// Token: 0x0400033C RID: 828
			public bool QOcdjMpIqQQPzTTIPOmtudGqAiHeA;
		}

		// Token: 0x02000063 RID: 99
		private sealed class WtepjxfEHMMcOPybXTVqyIZanEQl
		{
			// Token: 0x0600049B RID: 1179 RVA: 0x0000629A File Offset: 0x0000449A
			public WtepjxfEHMMcOPybXTVqyIZanEQl(KeyedGlyph A_1)
			{
				this.chgqfTOKhTdoRCBaLAkZgRcJKYeD = A_1;
			}

			// Token: 0x0400033D RID: 829
			public readonly KeyedGlyph chgqfTOKhTdoRCBaLAkZgRcJKYeD;

			// Token: 0x0400033E RID: 830
			public bool IunFvtDIczfUnQvocAnLgtTyQkTdb;
		}
	}
}
