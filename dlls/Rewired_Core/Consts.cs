using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Rewired.Config;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired
{
	// Token: 0x02000043 RID: 67
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public static class Consts
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000285 RID: 645 RVA: 0x000042DE File Offset: 0x000024DE
		internal static int nintendoSwitchPlugin_minPluginVersion
		{
			get
			{
				return 22;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000286 RID: 646 RVA: 0x000042E2 File Offset: 0x000024E2
		internal static int gameCorePlugin_minPluginVersion
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000287 RID: 647 RVA: 0x000042E2 File Offset: 0x000024E2
		internal static int ps4Plugin_minPluginVersion
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000288 RID: 648 RVA: 0x000042E2 File Offset: 0x000024E2
		internal static int ps5Plugin_minPluginVersion
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0002EDEC File Offset: 0x0002CFEC
		static Consts()
		{
			Consts.mouseAxisUnityNames = new ReadOnlyCollection<string>(Consts.tVyfvrIVnnhVUgwVQvvAeEfOGfCR);
			Consts.mouseButtonUnityNames = new ReadOnlyCollection<string>(Consts.yBtiHKWamubXZQXfTZnjewchvnLt);
			Consts.keyboardKeyNames = new ReadOnlyCollection<string>(Consts.uJHFWoebPPWftnWDMDIkiMHzDtDcb);
			Consts.keyboardKeyValues = new ReadOnlyCollection<int>(Consts._keyboardKeyValues);
			Consts.VLDuSlodqwMnIppsryLgbiBKIfohA = new ReadOnlyCollection<string>(Consts.XpivZyubmmQTgxbZfGYBBmpqLeeHb);
			Consts.qeVcdskKUVHbKAnDvMArOjLgSHOHA = new ReadOnlyCollection<string>(Consts.fUIPChbLMptyQWoujEkQKMrHplMl);
			Consts.pidVids_sony_dualShock4 = new ReadOnlyCollection<PidVid>(Consts.bGqkNtszxXdkKcYdJPOUnssYjOiu);
			Consts.productNames_sony_dualShock4 = new ReadOnlyCollection<string>(Consts.qCmjpxFwZVwiYicyXcwAoEhBtZdv);
			Consts.pidVids_sony_dualSense = new ReadOnlyCollection<PidVid>(Consts.CWNrmDRvhDHlvXhbYKxDVNFzNeae);
			Consts.productNames_sony_dualSense = new ReadOnlyCollection<string>(Consts.uwiEWHNxCjHaldCvjrUNoMqghFcBA);
			Consts.reservedHardwareTypeGuids = new ReadOnlyCollection<Guid>(Consts.jBzBqwuhzGZmPBDJoNYwdrnBkYqj);
			Consts.questionablePidVids = new PidVid[]
			{
				new PidVid(0, 0),
				new PidVid(0, ushort.MaxValue),
				new PidVid(ushort.MaxValue, ushort.MaxValue),
				new PidVid(ushort.MaxValue, 0)
			};
			Consts.questionableVIDs = new int[]
			{
				0,
				65535
			};
			Consts.thQnjTlkdmmTbihsDyjyBjKoGdQhA = Consts.IBlxAwDLyNMaAnHkXFNGfRkSmSYg();
			if (132 != Consts.uJHFWoebPPWftnWDMDIkiMHzDtDcb.Length)
			{
				Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyNames.Length!");
			}
			if (132 != Consts._keyboardKeyValues.Length)
			{
				Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyValues.Length!");
			}
			if (132 != Consts.XpivZyubmmQTgxbZfGYBBmpqLeeHb.Length)
			{
				Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyStringKeys.Length!");
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600028A RID: 650 RVA: 0x0002FBD8 File Offset: 0x0002DDD8
		internal static ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps[] commonMouseElementIdentifierInitOptions
		{
			get
			{
				if (Consts.vxEtJtcHgSwRZOIXFUgEdMBfincX != null)
				{
					return Consts.vxEtJtcHgSwRZOIXFUgEdMBfincX;
				}
				Consts.vxEtJtcHgSwRZOIXFUgEdMBfincX = new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps[]
				{
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 0,
						name = "Mouse Horizontal",
						positiveName = "Mouse Right",
						negativeName = "Mouse Left",
						key = "move/horizontal",
						positiveKey = "move/right",
						negativeKey = "move/left",
						elementType = ControllerElementType.Axis,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 1,
						name = "Mouse Vertical",
						positiveName = "Mouse Up",
						negativeName = "Mouse Down",
						key = "move/vertical",
						positiveKey = "move/up",
						negativeKey = "move/down",
						elementType = ControllerElementType.Axis,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 2,
						name = "Mouse Wheel",
						positiveName = "Mouse Wheel Up",
						negativeName = "Mouse Wheel Down",
						key = "wheel/vertical",
						positiveKey = "wheel/up",
						negativeKey = "wheel/down",
						elementType = ControllerElementType.Axis,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 3,
						name = "Left Mouse Button",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "left_button",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 4,
						name = "Right Mouse Button",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "right_button",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 5,
						name = "Mouse Button 3",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "middle_button",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 6,
						name = "Mouse Button 4",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "button_4",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 7,
						name = "Mouse Button 5",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "button_5",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 8,
						name = "Mouse Button 6",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "button_6",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 9,
						name = "Mouse Button 7",
						positiveName = string.Empty,
						negativeName = string.Empty,
						key = "button_7",
						positiveKey = string.Empty,
						negativeKey = string.Empty,
						elementType = ControllerElementType.Button,
						compoundElementType = CompoundControllerElementType.Axis2D
					},
					new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
					{
						id = 10,
						name = "Mouse Wheel Horizontal",
						positiveName = "Mouse Wheel Right",
						negativeName = "Mouse Wheel Left",
						key = "wheel/horizontal",
						positiveKey = "wheel/right",
						negativeKey = "wheel/left",
						elementType = ControllerElementType.Axis,
						compoundElementType = CompoundControllerElementType.Axis2D
					}
				};
				return Consts.vxEtJtcHgSwRZOIXFUgEdMBfincX;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0003001C File Offset: 0x0002E21C
		internal static IList<ControllerElementIdentifier> unityUnifiedMouseElementIdentifiers
		{
			get
			{
				ReadOnlyCollection<ControllerElementIdentifier> result;
				if ((result = Consts.ITGYzgbUhcnKZPkcaGcQbbYKQQtuA) == null)
				{
					result = (Consts.ITGYzgbUhcnKZPkcaGcQbbYKQQtuA = new ReadOnlyCollection<ControllerElementIdentifier>(new ControllerElementIdentifier[]
					{
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[0]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[1]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[2]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[10]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[3]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[4]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[5]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[6]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[7]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[8]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[9])
					}));
				}
				return result;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600028C RID: 652 RVA: 0x000300F0 File Offset: 0x0002E2F0
		internal static IList<ControllerElementIdentifier> rawInputUnifiedMouseElementIdentifiers
		{
			get
			{
				ReadOnlyCollection<ControllerElementIdentifier> result;
				if ((result = Consts.hppCxTJgXTLnwcpHBdjfkuXOTiLnA) == null)
				{
					result = (Consts.hppCxTJgXTLnwcpHBdjfkuXOTiLnA = new ReadOnlyCollection<ControllerElementIdentifier>(new ControllerElementIdentifier[]
					{
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[0]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[1]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[2]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[3]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[4]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[5]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[6]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[7]),
						new ControllerElementIdentifier(Consts.commonMouseElementIdentifierInitOptions[10])
					}));
				}
				return result;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000042E5 File Offset: 0x000024E5
		public static IList<string> keyboardKeyKeys
		{
			get
			{
				return Consts.VLDuSlodqwMnIppsryLgbiBKIfohA;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000042EC File Offset: 0x000024EC
		public static IList<string> keyboardModifierKeyKeys
		{
			get
			{
				return Consts.qeVcdskKUVHbKAnDvMArOjLgSHOHA;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600028F RID: 655 RVA: 0x000042F3 File Offset: 0x000024F3
		internal static ControllerElementIdentifier[] unknownJoystickElementIdentifiers_orig
		{
			get
			{
				return Consts.thQnjTlkdmmTbihsDyjyBjKoGdQhA;
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000301A4 File Offset: 0x0002E3A4
		private static ControllerElementIdentifier[] IBlxAwDLyNMaAnHkXFNGfRkSmSYg()
		{
			int num = 0;
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>(288);
			ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps vNIqbrYzBBGsknBKgoQEcoARaWps = new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps();
			for (int i = 0; i < 32; i++)
			{
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Axis " + i.ToString();
				vNIqbrYzBBGsknBKgoQEcoARaWps.positiveName = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.negativeName = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.ConcatenateKeyStrings("axis", i.ToString());
				vNIqbrYzBBGsknBKgoQEcoARaWps.positiveKey = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.negativeKey = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.elementType = ControllerElementType.Axis;
				vNIqbrYzBBGsknBKgoQEcoARaWps.compoundElementType = CompoundControllerElementType.Axis2D;
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				num++;
			}
			for (int j = 0; j < 128; j++)
			{
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Button " + j.ToString();
				vNIqbrYzBBGsknBKgoQEcoARaWps.positiveName = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.negativeName = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.ConcatenateKeyStrings("button", j.ToString());
				vNIqbrYzBBGsknBKgoQEcoARaWps.positiveKey = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.negativeKey = string.Empty;
				vNIqbrYzBBGsknBKgoQEcoARaWps.elementType = ControllerElementType.Button;
				vNIqbrYzBBGsknBKgoQEcoARaWps.compoundElementType = CompoundControllerElementType.Axis2D;
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				num++;
			}
			int num2 = num;
			int num3 = num + 64;
			vNIqbrYzBBGsknBKgoQEcoARaWps = new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps();
			vNIqbrYzBBGsknBKgoQEcoARaWps.elementType = ControllerElementType.Button;
			vNIqbrYzBBGsknBKgoQEcoARaWps.compoundElementType = CompoundControllerElementType.Axis2D;
			for (int k = 0; k < 16; k++)
			{
				string a = LocalizationManager.ConcatenateKeyStrings("hat", k.ToString());
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num2++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Up";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "up");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num3++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Up Right";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "up_right");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num2++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Right";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "right");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num3++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Down Right";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "down_right");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num2++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Down";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "down");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num3++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Down Left";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "down_left");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num2++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Left";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "left");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
				vNIqbrYzBBGsknBKgoQEcoARaWps.id = num3++;
				vNIqbrYzBBGsknBKgoQEcoARaWps.name = "Hat " + k.ToString() + " Up Left";
				vNIqbrYzBBGsknBKgoQEcoARaWps.key = LocalizationManager.AppendToKeyAsPath(a, "up_left");
				list.Add(new ControllerElementIdentifier(vNIqbrYzBBGsknBKgoQEcoARaWps));
			}
			return list.ToArray();
		}

		// Token: 0x04000133 RID: 307
		public const int systemPlayerId = 9999999;

		// Token: 0x04000134 RID: 308
		public const string menuRoot = "Window/Rewired";

		// Token: 0x04000135 RID: 309
		internal const int programVersion1 = 1;

		// Token: 0x04000136 RID: 310
		internal const int programVersion2 = 1;

		// Token: 0x04000137 RID: 311
		internal const int programVersion3 = 58;

		// Token: 0x04000138 RID: 312
		internal const int programVersion4 = 4;

		// Token: 0x04000139 RID: 313
		internal const int dataVersion = 1;

		// Token: 0x0400013A RID: 314
		internal const int unityMajorVersion = 2022;

		// Token: 0x0400013B RID: 315
		internal const string unityMajorVersionIdentifier = "U2022";

		// Token: 0x0400013C RID: 316
		internal const bool isTrial = false;

		// Token: 0x0400013D RID: 317
		internal const string copyrightYear = "2021";

		// Token: 0x0400013E RID: 318
		internal const string defaultNamespace = "Rewired";

		// Token: 0x0400013F RID: 319
		internal const LogLevelFlags defaultLogLevel = LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;

		// Token: 0x04000140 RID: 320
		internal const bool allowInputWhenEditorPaused = true;

		// Token: 0x04000141 RID: 321
		internal const string hwDefinitionVariantTag_RawInputDirectInput_xboxOneController_splitTriggers = "[SplitTriggers]";

		// Token: 0x04000142 RID: 322
		internal const string hwDefinitionVariantTag_RawInputDirectInput_xboxOneController_combinedTriggers = "[CombinedTriggers]";

		// Token: 0x04000143 RID: 323
		internal const float editorGUIUpdateInterval = 0.5f;

		// Token: 0x04000144 RID: 324
		internal const float joystickRefreshPollCheckTimeout = 1f;

		// Token: 0x04000145 RID: 325
		internal const float controllerRefreshWaitTimeout = 0.5f;

		// Token: 0x04000146 RID: 326
		internal const int buttonsPerHat = 8;

		// Token: 0x04000147 RID: 327
		internal const int keyboardKeyCount = 132;

		// Token: 0x04000148 RID: 328
		internal const int keyboardModifierKeyCount = 8;

		// Token: 0x04000149 RID: 329
		internal const int unityMouseButtonCount = 7;

		// Token: 0x0400014A RID: 330
		internal const int unityMouseAxisCount = 4;

		// Token: 0x0400014B RID: 331
		internal const int unityMaxJoysticks = 16;

		// Token: 0x0400014C RID: 332
		internal const int unityJoystickButtonCount = 20;

		// Token: 0x0400014D RID: 333
		internal const int unityJoystickStartingButtonKeycodeValue = 350;

		// Token: 0x0400014E RID: 334
		internal const int unityJoystickAxisCount = 29;

		// Token: 0x0400014F RID: 335
		internal const int unityJoystickLastJoystickIdWithButtonKeyCodes = 16;

		// Token: 0x04000150 RID: 336
		internal const string unityJoystickPrefix = "Joy";

		// Token: 0x04000151 RID: 337
		internal const string unityJoystickAxisSuffix = "Axis";

		// Token: 0x04000152 RID: 338
		internal const string unityJoystickButtonSuffix = "Button";

		// Token: 0x04000153 RID: 339
		internal const int directInputMaxButtons = 128;

		// Token: 0x04000154 RID: 340
		internal const int directInputMaxAxes = 32;

		// Token: 0x04000155 RID: 341
		internal const int directInputMaxHats = 4;

		// Token: 0x04000156 RID: 342
		internal const int directInputMaxSliders = 2;

		// Token: 0x04000157 RID: 343
		internal const int directInputMaxAxisValue = 65535;

		// Token: 0x04000158 RID: 344
		internal const int directInputMinAxisValue = -65535;

		// Token: 0x04000159 RID: 345
		internal const int directInputMaxHatValue = 36000;

		// Token: 0x0400015A RID: 346
		internal const int directInputHatZeroValue = -1;

		// Token: 0x0400015B RID: 347
		internal const int directInputHatSpan = 4500;

		// Token: 0x0400015C RID: 348
		internal const int directInputHatSpan4Way = 9000;

		// Token: 0x0400015D RID: 349
		internal const int directInput_hatValue_up = 0;

		// Token: 0x0400015E RID: 350
		internal const int directInput_hatValue_right = 9000;

		// Token: 0x0400015F RID: 351
		internal const int directInput_hatValue_down = 18000;

		// Token: 0x04000160 RID: 352
		internal const int directInput_hatValue_left = 27000;

		// Token: 0x04000161 RID: 353
		internal const int directInputLastDirectionValue = 31500;

		// Token: 0x04000162 RID: 354
		internal const int directInputLastDirectionValue4Way = 27000;

		// Token: 0x04000163 RID: 355
		internal const int directInputUnknownJoystickHatCount = 2;

		// Token: 0x04000164 RID: 356
		internal const int directInputUnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x04000165 RID: 357
		internal const int directInputJoystickStateByteSize = 264;

		// Token: 0x04000166 RID: 358
		internal const int rawInputMaxButtons = 256;

		// Token: 0x04000167 RID: 359
		internal const int rawInputMaxAxes = 56;

		// Token: 0x04000168 RID: 360
		internal const int rawInputMaxHats = 4;

		// Token: 0x04000169 RID: 361
		internal const int rawInputMaxSliders = 2;

		// Token: 0x0400016A RID: 362
		internal const int rawInputMaxAxisValue = 65535;

		// Token: 0x0400016B RID: 363
		internal const int rawInputMinAxisValue = -65535;

		// Token: 0x0400016C RID: 364
		internal const int rawInputMaxHatValue = 36000;

		// Token: 0x0400016D RID: 365
		internal const int rawInputHatZeroValue = -1;

		// Token: 0x0400016E RID: 366
		internal const int rawInputHatSpan = 4500;

		// Token: 0x0400016F RID: 367
		internal const int rawInputHatSpan4Way = 9000;

		// Token: 0x04000170 RID: 368
		internal const int rawInput_hatValue_up = 0;

		// Token: 0x04000171 RID: 369
		internal const int rawInput_hatValue_right = 9000;

		// Token: 0x04000172 RID: 370
		internal const int rawInput_hatValue_down = 18000;

		// Token: 0x04000173 RID: 371
		internal const int rawInput_hatValue_left = 27000;

		// Token: 0x04000174 RID: 372
		internal const int rawInputLastDirectionValue = 31500;

		// Token: 0x04000175 RID: 373
		internal const int rawInputLastDirectionValue4Way = 27000;

		// Token: 0x04000176 RID: 374
		internal const int rawInputUnknownJoystickHatCount = 2;

		// Token: 0x04000177 RID: 375
		internal const int rawInputUnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x04000178 RID: 376
		internal const int rawInputUnifiedMouseButtonCount = 5;

		// Token: 0x04000179 RID: 377
		internal const int rawInputUnifiedMouseAxisCount = 4;

		// Token: 0x0400017A RID: 378
		internal const float rawInputUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		// Token: 0x0400017B RID: 379
		internal const int rawInputUnifiedKeyboardButtonCount = 132;

		// Token: 0x0400017C RID: 380
		internal const int osxMaxSticks = 4;

		// Token: 0x0400017D RID: 381
		internal const int osxMaxButtons = 128;

		// Token: 0x0400017E RID: 382
		internal const int osxMaxAxesPerStick = 14;

		// Token: 0x0400017F RID: 383
		internal const int osxMaxHatsPerStick = 4;

		// Token: 0x04000180 RID: 384
		internal const int osxMaxAxisValue = 65536;

		// Token: 0x04000181 RID: 385
		internal const int osxMinAxisValue = -65536;

		// Token: 0x04000182 RID: 386
		internal const int osxMaxPressureSensitiveButtonValue = 65536;

		// Token: 0x04000183 RID: 387
		internal const int osxMinPressureSensitiveButtonValue = 0;

		// Token: 0x04000184 RID: 388
		internal const int osxMaxHatValue = 36000;

		// Token: 0x04000185 RID: 389
		internal const int osxInputHatZeroValue = -1;

		// Token: 0x04000186 RID: 390
		internal const int osxHatSpan = 4500;

		// Token: 0x04000187 RID: 391
		internal const int osxHatSpan4Way = 9000;

		// Token: 0x04000188 RID: 392
		internal const int osx_hatValue_up = 0;

		// Token: 0x04000189 RID: 393
		internal const int osx_hatValue_right = 9000;

		// Token: 0x0400018A RID: 394
		internal const int osx_hatValue_down = 18000;

		// Token: 0x0400018B RID: 395
		internal const int osx_hatValue_left = 27000;

		// Token: 0x0400018C RID: 396
		internal const int osxLastDirectionValue = 31500;

		// Token: 0x0400018D RID: 397
		internal const int osxLastDirectionValue4Way = 27000;

		// Token: 0x0400018E RID: 398
		internal const int osxUnknownJoystickHatCount = 16;

		// Token: 0x0400018F RID: 399
		internal const int osxUnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x04000190 RID: 400
		internal const int linuxMaxButtons = 256;

		// Token: 0x04000191 RID: 401
		internal const int linuxMaxAxes = 56;

		// Token: 0x04000192 RID: 402
		internal const int linuxMaxHats = 4;

		// Token: 0x04000193 RID: 403
		internal const int linuxMaxSliders = 2;

		// Token: 0x04000194 RID: 404
		internal const int linuxMaxAxisValue = 32767;

		// Token: 0x04000195 RID: 405
		internal const int linuxMinAxisValue = -32768;

		// Token: 0x04000196 RID: 406
		internal const int linuxMaxHatValue = 36000;

		// Token: 0x04000197 RID: 407
		internal const int linuxHatZeroValue = -1;

		// Token: 0x04000198 RID: 408
		internal const int linuxHatSpan = 4500;

		// Token: 0x04000199 RID: 409
		internal const int linuxHatSpan4Way = 9000;

		// Token: 0x0400019A RID: 410
		internal const int linux_hatValue_up = 0;

		// Token: 0x0400019B RID: 411
		internal const int linux_hatValue_right = 9000;

		// Token: 0x0400019C RID: 412
		internal const int linux_hatValue_down = 18000;

		// Token: 0x0400019D RID: 413
		internal const int linux_hatValue_left = 27000;

		// Token: 0x0400019E RID: 414
		internal const int linuxLastDirectionValue = 31500;

		// Token: 0x0400019F RID: 415
		internal const int linuxLastDirectionValue4Way = 27000;

		// Token: 0x040001A0 RID: 416
		internal const int linuxUnknownJoystickHatCount = 2;

		// Token: 0x040001A1 RID: 417
		internal const int linuxUnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x040001A2 RID: 418
		internal const int linuxUnifiedMouseButtonCount = 5;

		// Token: 0x040001A3 RID: 419
		internal const int linuxUnifiedMouseAxisCount = 3;

		// Token: 0x040001A4 RID: 420
		internal const float linuxUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		// Token: 0x040001A5 RID: 421
		internal const int sdl2MaxButtons = 256;

		// Token: 0x040001A6 RID: 422
		internal const int sdl2MaxAxes = 56;

		// Token: 0x040001A7 RID: 423
		internal const int sdl2MaxHats = 4;

		// Token: 0x040001A8 RID: 424
		internal const int sdl2MaxSliders = 2;

		// Token: 0x040001A9 RID: 425
		internal const int sdl2MaxAxisValue = 32768;

		// Token: 0x040001AA RID: 426
		internal const int sdl2MinAxisValue = -32767;

		// Token: 0x040001AB RID: 427
		internal const int sdl2AxisZeroValue = 0;

		// Token: 0x040001AC RID: 428
		internal const int sdl2MaxHatValue = 36000;

		// Token: 0x040001AD RID: 429
		internal const int sdl2HatZeroValue = -1;

		// Token: 0x040001AE RID: 430
		internal const int sdl2HatSpan = 4500;

		// Token: 0x040001AF RID: 431
		internal const int sdl2HatSpan4Way = 9000;

		// Token: 0x040001B0 RID: 432
		internal const int sdl2_hatValue_up = 0;

		// Token: 0x040001B1 RID: 433
		internal const int sdl2_hatValue_right = 9000;

		// Token: 0x040001B2 RID: 434
		internal const int sdl2_hatValue_down = 18000;

		// Token: 0x040001B3 RID: 435
		internal const int sdl2_hatValue_left = 27000;

		// Token: 0x040001B4 RID: 436
		internal const int sdl2LastDirectionValue = 31500;

		// Token: 0x040001B5 RID: 437
		internal const int sdl2LastDirectionValue4Way = 27000;

		// Token: 0x040001B6 RID: 438
		internal const int sdl2UnknownJoystickHatCount = 2;

		// Token: 0x040001B7 RID: 439
		internal const int sdl2UnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x040001B8 RID: 440
		internal const int sdl2UnifiedMouseButtonCount = 5;

		// Token: 0x040001B9 RID: 441
		internal const int sdl2UnifiedMouseAxisCount = 3;

		// Token: 0x040001BA RID: 442
		internal const float sdl2UnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		// Token: 0x040001BB RID: 443
		internal const int windowsUWPMaxButtons = 256;

		// Token: 0x040001BC RID: 444
		internal const int windowsUWPMaxAxes = 56;

		// Token: 0x040001BD RID: 445
		internal const int windowsUWPMaxHats = 4;

		// Token: 0x040001BE RID: 446
		internal const int windowsUWPMaxSliders = 2;

		// Token: 0x040001BF RID: 447
		internal const int windowsUWPMaxAxisValue = 32767;

		// Token: 0x040001C0 RID: 448
		internal const int windowsUWPMinAxisValue = -32768;

		// Token: 0x040001C1 RID: 449
		internal const int windowsUWPMaxHatValue = 36000;

		// Token: 0x040001C2 RID: 450
		internal const int windowsUWPHatZeroValue = -1;

		// Token: 0x040001C3 RID: 451
		internal const int windowsUWPDirectionsPerHat = 8;

		// Token: 0x040001C4 RID: 452
		internal const int windowsUWPHatSpan = 4500;

		// Token: 0x040001C5 RID: 453
		internal const int windowsUWPHatSpan4Way = 9000;

		// Token: 0x040001C6 RID: 454
		internal const int windowsUWPLastDirectionValue = 31500;

		// Token: 0x040001C7 RID: 455
		internal const int windowsUWPLastDirectionValue4Way = 27000;

		// Token: 0x040001C8 RID: 456
		internal const int windowsUWPUnknownJoystickHatCount = 2;

		// Token: 0x040001C9 RID: 457
		internal const int windowsUWPUnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x040001CA RID: 458
		internal const int windowsUWPUnifiedMouseButtonCount = 5;

		// Token: 0x040001CB RID: 459
		internal const int windowsUWPUnifiedMouseAxisCount = 3;

		// Token: 0x040001CC RID: 460
		internal const float windowsUWPUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		// Token: 0x040001CD RID: 461
		internal const int windowsGamingInputHatZeroValue = -1;

		// Token: 0x040001CE RID: 462
		internal const int xInputMaxVibration = 65535;

		// Token: 0x040001CF RID: 463
		internal const int xInputMinVibration = 0;

		// Token: 0x040001D0 RID: 464
		internal const float xInputAllowedVibrationInterval = 0.01f;

		// Token: 0x040001D1 RID: 465
		internal const int customPlatformMaxButtons = 256;

		// Token: 0x040001D2 RID: 466
		internal const int customPlatformMaxAxes = 128;

		// Token: 0x040001D3 RID: 467
		internal const int internalDriverMaxButtons = 256;

		// Token: 0x040001D4 RID: 468
		internal const int internalDriverMaxAxes = 56;

		// Token: 0x040001D5 RID: 469
		internal const int internalDriverMaxHats = 4;

		// Token: 0x040001D6 RID: 470
		internal const int internalDriverMaxSliders = 2;

		// Token: 0x040001D7 RID: 471
		internal const int internalDriverMaxAxisValue = 65535;

		// Token: 0x040001D8 RID: 472
		internal const int internalDriverMinAxisValue = -65535;

		// Token: 0x040001D9 RID: 473
		internal const int internalDriverMaxHatValue = 36000;

		// Token: 0x040001DA RID: 474
		internal const int internalDriverHatZeroValue = -1;

		// Token: 0x040001DB RID: 475
		internal const int internalDriverHatSpan = 4500;

		// Token: 0x040001DC RID: 476
		internal const int internalDriverHatSpan4Way = 9000;

		// Token: 0x040001DD RID: 477
		internal const int internalDriver_hatValue_up = 0;

		// Token: 0x040001DE RID: 478
		internal const int internalDriver_hatValue_right = 9000;

		// Token: 0x040001DF RID: 479
		internal const int internalDriver_hatValue_down = 18000;

		// Token: 0x040001E0 RID: 480
		internal const int internalDriver_hatValue_left = 27000;

		// Token: 0x040001E1 RID: 481
		internal const int internalDriverLastDirectionValue = 31500;

		// Token: 0x040001E2 RID: 482
		internal const int internalDriverLastDirectionValue4Way = 27000;

		// Token: 0x040001E3 RID: 483
		internal const int internalDriverUnknownJoystickHatCount = 2;

		// Token: 0x040001E4 RID: 484
		internal const int internalDriverUnknownJoystickHatButtonStartIndex = 128;

		// Token: 0x040001E5 RID: 485
		internal const int internalDriverUnifiedMouseButtonCount = 5;

		// Token: 0x040001E6 RID: 486
		internal const int internalDriverUnifiedMouseAxisCount = 3;

		// Token: 0x040001E7 RID: 487
		internal const float internalDriverUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		// Token: 0x040001E8 RID: 488
		internal const int webGLMaxButtons = 256;

		// Token: 0x040001E9 RID: 489
		internal const int webGLMaxAxes = 128;

		// Token: 0x040001EA RID: 490
		internal const int gameCoreMaxButtons = 256;

		// Token: 0x040001EB RID: 491
		internal const int gameCoreMaxAxes = 32;

		// Token: 0x040001EC RID: 492
		internal const int gameCoreMaxHats = 4;

		// Token: 0x040001ED RID: 493
		internal const int gameCoreUnknownJoystickButtonCount = 128;

		// Token: 0x040001EE RID: 494
		internal const int gameCoreUnknownJoystickAxisCount = 32;

		// Token: 0x040001EF RID: 495
		internal const int gameCoreUnknownJoystickHatCount = 2;

		// Token: 0x040001F0 RID: 496
		internal const int appleGCControllerMaxButtons = 128;

		// Token: 0x040001F1 RID: 497
		internal const int appleGCControllerMaxAxes = 32;

		// Token: 0x040001F2 RID: 498
		internal const int appleGCControllerMaxCompoundElements = 32;

		// Token: 0x040001F3 RID: 499
		internal const int appleGCControllerUnknownJoystickButtonCount = 128;

		// Token: 0x040001F4 RID: 500
		internal const int appleGCControllerUnknownJoystickAxisCount = 32;

		// Token: 0x040001F5 RID: 501
		internal const int windowsGamingInputMaxButtons = 128;

		// Token: 0x040001F6 RID: 502
		internal const int windowsGamingInputMaxAxes = 32;

		// Token: 0x040001F7 RID: 503
		internal const int windowsGamingInputMaxHats = 16;

		// Token: 0x040001F8 RID: 504
		internal const int windowsGamingInputMaxCompoundElements = 32;

		// Token: 0x040001F9 RID: 505
		internal const int windowsGamingInputUnknownJoystickButtonCount = 128;

		// Token: 0x040001FA RID: 506
		internal const int windowsGamingInputUnknownJoystickAxisCount = 32;

		// Token: 0x040001FB RID: 507
		internal const int windowsGamingInputUnknownJoystickHatCount = 16;

		// Token: 0x040001FC RID: 508
		internal const int unknownJoystickMaxButtons = 128;

		// Token: 0x040001FD RID: 509
		internal const int unknownJoystickMaxAxes = 32;

		// Token: 0x040001FE RID: 510
		internal const int unknownJoystickMaxHats = 16;

		// Token: 0x040001FF RID: 511
		internal const int unknownJoystickButtonsPerHat = 8;

		// Token: 0x04000200 RID: 512
		internal const int unknownJoystickAxisElementIdentifierStartIndex = 0;

		// Token: 0x04000201 RID: 513
		internal const int unknownJoystickButtonElementIdentifierStartIndex = 32;

		// Token: 0x04000202 RID: 514
		internal const int unknownJoystickHatElementIdentifierStartIndex = 160;

		// Token: 0x04000203 RID: 515
		internal const float unknownJoystickDefaultAxisDeadZone = 0.1f;

		// Token: 0x04000204 RID: 516
		internal const float defaultAbsoluteAxisPollingDeadZone = 0.7f;

		// Token: 0x04000205 RID: 517
		internal const float defaultRelativeAxisPollingDeadZone = 100f;

		// Token: 0x04000206 RID: 518
		internal const float defaultMouseXYAxisPollingDeadzone = 100f;

		// Token: 0x04000207 RID: 519
		internal const float defaultMouseOtherAxisPollingDeadzone = 2f;

		// Token: 0x04000208 RID: 520
		internal const float defaultButtonDeadZone = 0.5f;

		// Token: 0x04000209 RID: 521
		internal const float hardwareButtonDeadZone = 0.01f;

		// Token: 0x0400020A RID: 522
		internal const float axisDefaultSensitivity = 1f;

		// Token: 0x0400020B RID: 523
		internal const AxisSensitivityType axisDefaultSensitivityType = AxisSensitivityType.Multiplier;

		// Token: 0x0400020C RID: 524
		internal const float defaultButtonDoublePressSpeed = 0.3f;

		// Token: 0x0400020D RID: 525
		internal const float minDoubleButtonPressSpeed = 0.01f;

		// Token: 0x0400020E RID: 526
		internal const float maxDoubleButtonPressSpeed = 10f;

		// Token: 0x0400020F RID: 527
		internal const float defaultButtonShortPressTime = 0.25f;

		// Token: 0x04000210 RID: 528
		internal const float minButtonShortPressTime = 0f;

		// Token: 0x04000211 RID: 529
		internal const float maxButtonShortPressTime = 3.4028235E+38f;

		// Token: 0x04000212 RID: 530
		internal const float defaultButtonShortPressExpiresIn = 0f;

		// Token: 0x04000213 RID: 531
		internal const float minButtonShortPressExpiresIn = 0f;

		// Token: 0x04000214 RID: 532
		internal const float maxButtonShortPressExpiresIn = 3.4028235E+38f;

		// Token: 0x04000215 RID: 533
		internal const float defaultButtonLongPressTime = 1f;

		// Token: 0x04000216 RID: 534
		internal const float minButtonLongPressTime = 0f;

		// Token: 0x04000217 RID: 535
		internal const float maxButtonLongPressTime = 3.4028235E+38f;

		// Token: 0x04000218 RID: 536
		internal const float defaultButtonLongPressExpiresIn = 0f;

		// Token: 0x04000219 RID: 537
		internal const float minButtonLongPressExpiresIn = 0f;

		// Token: 0x0400021A RID: 538
		internal const float maxButtonLongPressExpiresIn = 3.4028235E+38f;

		// Token: 0x0400021B RID: 539
		internal const float defaultButtonRepeatDelay = 0f;

		// Token: 0x0400021C RID: 540
		internal const float defaultButtonRepeatRate = 30f;

		// Token: 0x0400021D RID: 541
		internal const float minButtonRepeatRate = 0.001f;

		// Token: 0x0400021E RID: 542
		internal const float mouseAxisPollingTimerLength = 1f;

		// Token: 0x0400021F RID: 543
		internal const float fallbackPollingTimeout = 1f;

		// Token: 0x04000220 RID: 544
		internal const KeyCombinationOverrideMode defaultKeyCombinationOverrideMode = KeyCombinationOverrideMode.Cancel;

		// Token: 0x04000221 RID: 545
		internal const bool defaultGenerateKeyEventsOnKeyCombinationOverride = true;

		// Token: 0x04000222 RID: 546
		internal const string unknownJoystickName = "Unknown Controller";

		// Token: 0x04000223 RID: 547
		internal const float xInputControllerVibrationRenewalInterval = 1.5f;

		// Token: 0x04000224 RID: 548
		internal const int defaultInputThreadUpdateRateFPS = 240;

		// Token: 0x04000225 RID: 549
		internal const int maxInputThreadUpdateRateFPS = 2000;

		// Token: 0x04000226 RID: 550
		internal const int osxXInputOutputReportRefreshRateFPS = 60;

		// Token: 0x04000227 RID: 551
		internal const int defaultOutputRefreshRateFPS = 100;

		// Token: 0x04000228 RID: 552
		internal const int hidOutputReportRefreshRateFPS = 100;

		// Token: 0x04000229 RID: 553
		internal const int hidOutputReportThreadKillTimeout = 10000;

		// Token: 0x0400022A RID: 554
		internal const int joystickInputReportRingBufferCapacity = 60;

		// Token: 0x0400022B RID: 555
		internal const float joystickInputReportRingBufferCapacityDuration = 0.25f;

		// Token: 0x0400022C RID: 556
		internal const string resourecesDLLPath_windowsStandalone = "Libs/Rewired_Windows";

		// Token: 0x0400022D RID: 557
		internal const string resourecesDLLPath_osxStandalone = "Libs/Rewired_OSX";

		// Token: 0x0400022E RID: 558
		internal const string resourecesDLLPath_linux = "Libs/Rewired_Linux";

		// Token: 0x0400022F RID: 559
		internal const float defaultInputBehaviorAxisSensitivity = 1f;

		// Token: 0x04000230 RID: 560
		internal const float defaultInputBehaviorAxisSimulation_gravity = 3f;

		// Token: 0x04000231 RID: 561
		internal const float defaultInputBehaviorAxisSimulation_sensitivity = 3f;

		// Token: 0x04000232 RID: 562
		internal const bool defaultInputBehaviorAxisSmoothing_snap = true;

		// Token: 0x04000233 RID: 563
		internal const bool defaultInputBehaviorAxisSmoothing_instantReverse = false;

		// Token: 0x04000234 RID: 564
		internal const bool defaultInputBehaviorAxisSimulation_enabled = true;

		// Token: 0x04000235 RID: 565
		internal const int allFlagsIntEnum = -1;

		// Token: 0x04000236 RID: 566
		internal const float osxPreventSystemSleepInterval = 30f;

		// Token: 0x04000237 RID: 567
		internal const string schemaNameSpace = "http://guavaman.com/rewired";

		// Token: 0x04000238 RID: 568
		internal const string schemaBaseLocation = "http://guavaman.com/schemas/rewired/";

		// Token: 0x04000239 RID: 569
		internal const string schemaVersionControllerMap = "1.1";

		// Token: 0x0400023A RID: 570
		internal const string schemaVersionCalibrationMap = "1.3";

		// Token: 0x0400023B RID: 571
		internal const string schemaVersionInputBehavior = "1.4";

		// Token: 0x0400023C RID: 572
		internal const string schemaVersionControllerTemplateMap = "1.0";

		// Token: 0x0400023D RID: 573
		internal const string schemaVersionPlayerEnabledMapsHelperData = "1.0";

		// Token: 0x0400023E RID: 574
		internal const string schemaVersionPlayerControllerMapLayoutManagerData = "1.0";

		// Token: 0x0400023F RID: 575
		internal const int controllerMapDataVersion = 2;

		// Token: 0x04000240 RID: 576
		internal const int calibrationMapDataVersion = 4;

		// Token: 0x04000241 RID: 577
		internal const int inputBehaviorDataVersion = 5;

		// Token: 0x04000242 RID: 578
		internal const int controllerTemplateMapDataVersion = 1;

		// Token: 0x04000243 RID: 579
		internal const int playerMapEnablerDataVersion = 1;

		// Token: 0x04000244 RID: 580
		internal const int playerControllerMapLayoutManagerDataVersion = 1;

		// Token: 0x04000245 RID: 581
		internal static readonly PidVid[] questionablePidVids;

		// Token: 0x04000246 RID: 582
		internal static readonly int[] questionableVIDs;

		// Token: 0x04000247 RID: 583
		internal const int controllerElementType_trueElements_minValue = 0;

		// Token: 0x04000248 RID: 584
		internal const int controllerElementType_trueElements_maxValue = 99;

		// Token: 0x04000249 RID: 585
		internal const float pressureSensitiveButtonDeadZone = 0.001f;

		// Token: 0x0400024A RID: 586
		internal const string rewiredEditorAssembly = "Rewired_Editor";

		// Token: 0x0400024B RID: 587
		internal const string rewiredEditorInputEditorClassFullName = "Rewired.Editor.InputEditor";

		// Token: 0x0400024C RID: 588
		internal const string nintendoSwitchPluginEditorRuntimeAssembly = "Rewired_NintendoSwitch_EditorRuntime";

		// Token: 0x0400024D RID: 589
		internal const string nintendoSwitchPluginInputManagerFullClassPath = "Rewired.Platforms.Switch.NintendoSwitchInputManager";

		// Token: 0x0400024E RID: 590
		internal const string nintendoSwitchPluginHWJoystickMapGuid_JoyConDual = "521b808c-0248-4526-bc10-f1d16ee76bf1";

		// Token: 0x0400024F RID: 591
		internal const string nintendoSwitchPluginHWJoystickMapGuid_Handheld = "1fbdd13b-0795-4173-8a95-a2a75de9d204";

		// Token: 0x04000250 RID: 592
		internal const string gameCorePluginEditorRuntimeAssembly = "Rewired_GameCore_EditorRuntime";

		// Token: 0x04000251 RID: 593
		internal const string gameCorePluginInputManagerFullClassPath = "Rewired.Platforms.GameCore.GameCoreInputManager";

		// Token: 0x04000252 RID: 594
		internal const string ps4PluginEditorRuntimeAssembly = "Rewired_PlayStation4_EditorRuntime";

		// Token: 0x04000253 RID: 595
		internal const string ps5PluginEditorRuntimeAssembly = "Rewired_PlayStation5_EditorRuntime";

		// Token: 0x04000254 RID: 596
		internal static Guid joystickGuid_unknownController = Guid.Empty;

		// Token: 0x04000255 RID: 597
		internal static Guid joystickGuid_appleMFiController = new Guid("3d919cfa-468e-49f4-bce9-f6c43f2e7e62");

		// Token: 0x04000256 RID: 598
		internal static Guid joystickGuid_standardizedGamepad = new Guid("04c23ab3-2b99-4404-a5c4-f0df7e62938f");

		// Token: 0x04000257 RID: 599
		internal static Guid joystickGuid_steamController = new Guid("2694f4b9-9d84-4f55-9ee8-78fbba744b7d");

		// Token: 0x04000258 RID: 600
		internal static Guid joystickGuid_SonyDualShock4 = new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f");

		// Token: 0x04000259 RID: 601
		internal static Guid joystickGuid_SonyPS4AimController = new Guid("65ea105c-6390-4d11-a49b-13a402b1f2d9");

		// Token: 0x0400025A RID: 602
		internal static Guid joystickGuid_SonyPS4Drums = new Guid("7c338d42-ec21-4402-84ed-7ab547343c19");

		// Token: 0x0400025B RID: 603
		internal static Guid joystickGuid_SonyPS4FlightStick = new Guid("a75d195b-27a8-41ac-97db-2bd5a649a817");

		// Token: 0x0400025C RID: 604
		internal static Guid joystickGuid_SonyPS4Guitar = new Guid("274096a0-b4d5-413f-bb4c-7dd68cae6f0f");

		// Token: 0x0400025D RID: 605
		internal static Guid joystickGuid_SonyPS4SteeringWheel = new Guid("1b5a521b-6833-4c54-ab6c-bac653c93e9c");

		// Token: 0x0400025E RID: 606
		internal static Guid joystickGuid_SonyDualSense = new Guid("5286706d-19b4-4a45-b635-207ce78d8394");

		// Token: 0x0400025F RID: 607
		internal static Guid hardwareTypeGuid_universalKeyboard = new Guid("ae4830f963db4d4c90b31beb46ecaf49");

		// Token: 0x04000260 RID: 608
		internal static Guid hardwareTypeGuid_universalMouse = new Guid("ad60107cea394d9cb90656d39d07be95");

		// Token: 0x04000261 RID: 609
		private static readonly Guid[] jBzBqwuhzGZmPBDJoNYwdrnBkYqj = new Guid[]
		{
			Consts.joystickGuid_unknownController,
			Consts.hardwareTypeGuid_universalKeyboard,
			Consts.hardwareTypeGuid_universalMouse
		};

		// Token: 0x04000262 RID: 610
		internal static readonly ReadOnlyCollection<Guid> reservedHardwareTypeGuids;

		// Token: 0x04000263 RID: 611
		private static ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps[] vxEtJtcHgSwRZOIXFUgEdMBfincX;

		// Token: 0x04000264 RID: 612
		private static ReadOnlyCollection<ControllerElementIdentifier> ITGYzgbUhcnKZPkcaGcQbbYKQQtuA;

		// Token: 0x04000265 RID: 613
		private static ReadOnlyCollection<ControllerElementIdentifier> hppCxTJgXTLnwcpHBdjfkuXOTiLnA;

		// Token: 0x04000266 RID: 614
		internal static readonly IList<string> mouseAxisUnityNames;

		// Token: 0x04000267 RID: 615
		private static readonly string[] tVyfvrIVnnhVUgwVQvvAeEfOGfCR = new string[]
		{
			"MouseAxis1",
			"MouseAxis2",
			"MouseAxis3"
		};

		// Token: 0x04000268 RID: 616
		internal static readonly IList<string> mouseButtonUnityNames;

		// Token: 0x04000269 RID: 617
		private static readonly string[] yBtiHKWamubXZQXfTZnjewchvnLt = new string[]
		{
			"MouseButton0",
			"MouseButton1",
			"MouseButton2",
			"MouseButton3",
			"MouseButton4",
			"MouseButton5",
			"MouseButton6"
		};

		// Token: 0x0400026A RID: 618
		internal static readonly IList<string> keyboardKeyNames;

		// Token: 0x0400026B RID: 619
		private static readonly string[] uJHFWoebPPWftnWDMDIkiMHzDtDcb = new string[]
		{
			"None",
			"A",
			"B",
			"C",
			"D",
			"E",
			"F",
			"G",
			"H",
			"I",
			"J",
			"K",
			"L",
			"M",
			"N",
			"O",
			"P",
			"Q",
			"R",
			"S",
			"T",
			"U",
			"V",
			"W",
			"X",
			"Y",
			"Z",
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"Keypad 0",
			"Keypad 1",
			"Keypad 2",
			"Keypad 3",
			"Keypad 4",
			"Keypad 5",
			"Keypad 6",
			"Keypad 7",
			"Keypad 8",
			"Keypad 9",
			"Keypad .",
			"Keypad /",
			"Keypad *",
			"Keypad -",
			"Keypad +",
			"Keypad Enter",
			"Keypad =",
			"Space",
			"Backspace",
			"Tab",
			"Clear",
			"Return",
			"Pause",
			"ESC",
			"!",
			"\"",
			"#",
			"$",
			"&",
			"'",
			"(",
			")",
			"*",
			"+",
			",",
			"-",
			".",
			"/",
			":",
			";",
			"<",
			"=",
			">",
			"?",
			"@",
			"[",
			"\\",
			"]",
			"^",
			"_",
			"Back Quote",
			"Delete",
			"Up Arrow",
			"Down Arrow",
			"Right Arrow",
			"Left Arrow",
			"Insert",
			"Home",
			"End",
			"Page Up",
			"Page Down",
			"F1",
			"F2",
			"F3",
			"F4",
			"F5",
			"F6",
			"F7",
			"F8",
			"F9",
			"F10",
			"F11",
			"F12",
			"F13",
			"F14",
			"F15",
			"Numlock",
			"Caps Lock",
			"Scroll Lock",
			"Right Shift",
			"Left Shift",
			"Right Control",
			"Left Control",
			"Right Alt",
			"Left Alt",
			"Right Command",
			"Left Command",
			"Left Windows",
			"Right Windows",
			"AltGr",
			"Help",
			"Print",
			"SysReq",
			"Break",
			"Menu"
		};

		// Token: 0x0400026C RID: 620
		internal static readonly IList<int> keyboardKeyValues;

		// Token: 0x0400026D RID: 621
		internal static readonly int[] _keyboardKeyValues = new int[]
		{
			0,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			256,
			257,
			258,
			259,
			260,
			261,
			262,
			263,
			264,
			265,
			266,
			267,
			268,
			269,
			270,
			271,
			272,
			32,
			8,
			9,
			12,
			13,
			19,
			27,
			33,
			34,
			35,
			36,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			58,
			59,
			60,
			61,
			62,
			63,
			64,
			91,
			92,
			93,
			94,
			95,
			96,
			127,
			273,
			274,
			275,
			276,
			277,
			278,
			279,
			280,
			281,
			282,
			283,
			284,
			285,
			286,
			287,
			288,
			289,
			290,
			291,
			292,
			293,
			294,
			295,
			296,
			300,
			301,
			302,
			303,
			304,
			305,
			306,
			307,
			308,
			309,
			310,
			311,
			312,
			313,
			315,
			316,
			317,
			318,
			319
		};

		// Token: 0x0400026E RID: 622
		private static readonly IList<string> VLDuSlodqwMnIppsryLgbiBKIfohA;

		// Token: 0x0400026F RID: 623
		private static readonly string[] XpivZyubmmQTgxbZfGYBBmpqLeeHb = new string[]
		{
			"",
			"a",
			"b",
			"c",
			"d",
			"e",
			"f",
			"g",
			"h",
			"i",
			"j",
			"k",
			"l",
			"m",
			"n",
			"o",
			"p",
			"q",
			"r",
			"s",
			"t",
			"u",
			"v",
			"w",
			"x",
			"y",
			"z",
			"alpha_0",
			"alpha_1",
			"alpha_2",
			"alpha_3",
			"alpha_4",
			"alpha_5",
			"alpha_6",
			"alpha_7",
			"alpha_8",
			"alpha_9",
			"keypad_0",
			"keypad_1",
			"keypad_2",
			"keypad_3",
			"keypad_4",
			"keypad_5",
			"keypad_6",
			"keypad_7",
			"keypad_8",
			"keypad_9",
			"keypad_period",
			"keypad_slash",
			"keypad_asterisk",
			"keypad_minus",
			"keypad_plus",
			"keypad_enter",
			"keypad_equals",
			"space",
			"backspace",
			"tab",
			"clear",
			"return",
			"pause",
			"escape",
			"exclamation_point",
			"double_quote",
			"hash",
			"dollar_sign",
			"ampersand",
			"quote",
			"left_parenthesis",
			"right_parenthesis",
			"asterisk",
			"plus",
			"comma",
			"minus",
			"period",
			"slash",
			"colon",
			"semicolon",
			"less_than",
			"equals",
			"greater_than",
			"question_mark",
			"at",
			"left_bracket",
			"backslash",
			"right_bracket",
			"caret",
			"underscore",
			"back_quote",
			"delete",
			"up_arrow",
			"down_arrow",
			"right_arrow",
			"left_arrow",
			"insert",
			"home",
			"end",
			"page_up",
			"page_down",
			"f1",
			"f2",
			"f3",
			"f4",
			"f5",
			"f6",
			"f7",
			"f8",
			"f9",
			"f10",
			"f11",
			"f12",
			"f13",
			"f14",
			"f15",
			"num_lock",
			"caps_lock",
			"scroll_lock",
			"right_shift",
			"left_shift",
			"right_control",
			"left_control",
			"right_alt",
			"left_alt",
			"right_command",
			"left_command",
			"left_windows",
			"right_windows",
			"alt_gr",
			"help",
			"print_screen",
			"sys_req",
			"break",
			"menu"
		};

		// Token: 0x04000270 RID: 624
		private static readonly IList<string> qeVcdskKUVHbKAnDvMArOjLgSHOHA;

		// Token: 0x04000271 RID: 625
		private static readonly string[] fUIPChbLMptyQWoujEkQKMrHplMl = new string[]
		{
			"",
			"control",
			"alt",
			"shift",
			"command"
		};

		// Token: 0x04000272 RID: 626
		internal static readonly Rewired.Utils.Interfaces.IReadOnlyDictionary<int, Keyboard.ModifierKeyInfo> modifierKeyInfo = new ADictionary<int, Keyboard.ModifierKeyInfo>
		{
			{
				0,
				new Keyboard.ModifierKeyInfo(string.Empty, string.Empty, string.Empty, string.Empty)
			},
			{
				1,
				new Keyboard.ModifierKeyInfo("Ctrl", "Control", "control_short", "control")
			},
			{
				2,
				new Keyboard.ModifierKeyInfo("Alt", "Alt", "alt_short", "alt")
			},
			{
				3,
				new Keyboard.ModifierKeyInfo("Shift", "Shift", "shift_short", "shift")
			},
			{
				4,
				new Keyboard.ModifierKeyInfo("Cmd", "Command", "command_short", "command")
			}
		};

		// Token: 0x04000273 RID: 627
		public const int vendorId_sony = 1356;

		// Token: 0x04000274 RID: 628
		internal static readonly IList<PidVid> pidVids_sony_dualShock4;

		// Token: 0x04000275 RID: 629
		private static readonly PidVid[] bGqkNtszxXdkKcYdJPOUnssYjOiu = new PidVid[]
		{
			new PidVid(1476, 1356),
			new PidVid(2976, 1356),
			new PidVid(2508, 1356)
		};

		// Token: 0x04000276 RID: 630
		internal static readonly IList<string> productNames_sony_dualShock4;

		// Token: 0x04000277 RID: 631
		private static readonly string[] qCmjpxFwZVwiYicyXcwAoEhBtZdv = new string[]
		{
			"Sony Computer Entertainment Wireless Controller",
			"Sony Interactive Entertainment DUALSHOCK®4 USB Wireless Adaptor",
			"Wireless Controller",
			"Sony Interactive Entertainment Wireless Controller",
			"Wireless Controller Touchpad"
		};

		// Token: 0x04000278 RID: 632
		internal static readonly IList<PidVid> pidVids_sony_dualSense;

		// Token: 0x04000279 RID: 633
		private static readonly PidVid[] CWNrmDRvhDHlvXhbYKxDVNFzNeae = new PidVid[]
		{
			new PidVid(3302, 1356),
			new PidVid(3570, 1356)
		};

		// Token: 0x0400027A RID: 634
		internal static readonly IList<string> productNames_sony_dualSense;

		// Token: 0x0400027B RID: 635
		private static readonly string[] uwiEWHNxCjHaldCvjrUNoMqghFcBA = new string[]
		{
			"DualSense Wireless Controller"
		};

		// Token: 0x0400027C RID: 636
		private static readonly ControllerElementIdentifier[] thQnjTlkdmmTbihsDyjyBjKoGdQhA;

		// Token: 0x0400027D RID: 637
		internal const int updateLoopTypeCount = 3;
	}
}
