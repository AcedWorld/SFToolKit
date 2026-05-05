using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002B7 RID: 695
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class HardwareJoystickMap : ScriptableObject, IHardwareControllerMap, IHardwareControllerMap_Internal
	{
		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06001EDD RID: 7901 RVA: 0x0001812F File Offset: 0x0001632F
		private Guid runtimeControllerGuid
		{
			get
			{
				if (this.__runtimeControllerGuidCache == null || this.__runtimeControllerGuidCache == null)
				{
					this.__runtimeControllerGuidCache = new Guid?(StringTools.ToGuid(this.controllerGuid));
				}
				return this.__runtimeControllerGuidCache.Value;
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06001EDE RID: 7902 RVA: 0x0008152C File Offset: 0x0007F72C
		private Guid[] runtimeTemplateGuids
		{
			get
			{
				if (this.__runtimeTemplateGuidCache == null && this.templateGuids != null)
				{
					this.__runtimeTemplateGuidCache = new Guid[this.templateGuids.Length];
					for (int i = 0; i < this.templateGuids.Length; i++)
					{
						this.__runtimeTemplateGuidCache[i] = StringTools.ToGuid(this.templateGuids[i]);
					}
				}
				return this.__runtimeTemplateGuidCache;
			}
		}

		// Token: 0x06001EDF RID: 7903 RVA: 0x00081590 File Offset: 0x0007F790
		public HardwareJoystickMap()
		{
			if (this.joystickTypes == null || this.joystickTypes.Length == 0)
			{
				this.joystickTypes = new JoystickType[1];
			}
			if (this.directInput == null)
			{
				this.directInput = new HardwareJoystickMap.Platform_DirectInput();
			}
			if (this.rawInput == null)
			{
				this.rawInput = new HardwareJoystickMap.Platform_RawInput();
			}
			if (this.xInput == null)
			{
				this.xInput = new HardwareJoystickMap.Platform_XInput();
			}
			if (this.windowsWGI == null)
			{
				this.windowsWGI = new HardwareJoystickMap.Platform_WindowsWGI();
			}
			if (this.osx == null)
			{
				this.osx = new HardwareJoystickMap.Platform_OSX();
			}
			if (this.appleGCController == null)
			{
				this.appleGCController = new HardwareJoystickMap.Platform_AppleGCController();
			}
			if (this.linux == null)
			{
				this.linux = new HardwareJoystickMap.Platform_Linux();
			}
			if (this.windowsUWP == null)
			{
				this.windowsUWP = new HardwareJoystickMap.Platform_WindowsUWP();
			}
			if (this.fallback_Android == null)
			{
				this.fallback_Android = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_iOS == null)
			{
				this.fallback_iOS = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_Linux == null)
			{
				this.fallback_Linux = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_Linux_PreConfigured == null)
			{
				this.fallback_Linux_PreConfigured = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_OSX == null)
			{
				this.fallback_OSX = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_PS4 == null)
			{
				this.fallback_PS4 = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_PSM == null)
			{
				this.fallback_PSM = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_PSVita == null)
			{
				this.fallback_PSVita = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_Windows == null)
			{
				this.fallback_Windows = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_WindowsUWP == null)
			{
				this.fallback_WindowsUWP = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_XBoxOne == null)
			{
				this.fallback_XBoxOne = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.fallback_AmazonFireTV == null)
			{
				this.fallback_AmazonFireTV = new HardwareJoystickMap.Platform_Fallback();
			}
			if (this.webGL == null)
			{
				this.webGL = new HardwareJoystickMap.Platform_WebGL();
			}
			if (this.xboxOne == null)
			{
				this.xboxOne = new HardwareJoystickMap.Platform_XboxOne();
			}
			if (this.gameCore == null)
			{
				this.gameCore = new HardwareJoystickMap.Platform_GameCore();
			}
			if (this.ps4 == null)
			{
				this.ps4 = new HardwareJoystickMap.Platform_PS4();
			}
			if (this.ps5 == null)
			{
				this.ps5 = new HardwareJoystickMap.Platform_PS5();
			}
			if (this.nintendoSwitch == null)
			{
				this.nintendoSwitch = new HardwareJoystickMap.Platform_NintendoSwitch();
			}
			if (this.internalDriver == null)
			{
				this.internalDriver = new HardwareJoystickMap.Platform_InternalDriver();
			}
			if (this.sdl2_Linux == null)
			{
				this.sdl2_Linux = new HardwareJoystickMap.Platform_SDL2();
			}
			if (this.sdl2_Windows == null)
			{
				this.sdl2_Windows = new HardwareJoystickMap.Platform_SDL2();
			}
			if (this.sdl2_OSX == null)
			{
				this.sdl2_OSX = new HardwareJoystickMap.Platform_SDL2();
			}
		}

		// Token: 0x06001EE0 RID: 7904 RVA: 0x000817FC File Offset: 0x0007F9FC
		public HardwareJoystickMap(HardwareJoystickMap A_1) : this()
		{
			this.controllerGuid = A_1.controllerGuid;
			if (A_1.templateGuids != null)
			{
				int num = A_1.templateGuids.Length;
				this.templateGuids = new string[num];
				for (int i = 0; i < num; i++)
				{
					this.templateGuids[i] = this.templateGuids[i];
				}
			}
			if (A_1.elementIdentifiers != null)
			{
				int num2 = A_1.elementIdentifiers.Length;
				this.elementIdentifiers = new ControllerElementIdentifier[num2];
				for (int j = 0; j < num2; j++)
				{
					this.elementIdentifiers[j] = this.elementIdentifiers[j].Clone();
				}
			}
			this.elementIdentifierIdCounter = A_1.elementIdentifierIdCounter;
			if (A_1.compoundElements != null)
			{
				int num3 = A_1.compoundElements.Length;
				this.compoundElements = new HardwareJoystickMap.CompoundElement[num3];
				for (int k = 0; k < num3; k++)
				{
					this.compoundElements[k] = (A_1.compoundElements[k].DeepClone() as HardwareJoystickMap.CompoundElement);
				}
			}
			this.joystickTypes = ArrayTools.ShallowCopy<JoystickType>(A_1.joystickTypes);
			if (A_1.directInput != null)
			{
				this.directInput = MiscTools.DeepClone<HardwareJoystickMap.Platform_DirectInput>(A_1.directInput);
			}
			if (A_1.rawInput != null)
			{
				this.rawInput = MiscTools.DeepClone<HardwareJoystickMap.Platform_RawInput>(this.rawInput);
			}
			if (A_1.xInput != null)
			{
				this.xInput = MiscTools.DeepClone<HardwareJoystickMap.Platform_XInput>(A_1.xInput);
			}
			if (A_1.windowsWGI != null)
			{
				this.windowsWGI = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsWGI>(A_1.windowsWGI);
			}
			if (A_1.osx != null)
			{
				this.osx = MiscTools.DeepClone<HardwareJoystickMap.Platform_OSX>(A_1.osx);
			}
			if (A_1.appleGCController != null)
			{
				this.appleGCController = MiscTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController>(A_1.appleGCController);
			}
			if (A_1.linux != null)
			{
				this.linux = MiscTools.DeepClone<HardwareJoystickMap.Platform_Linux>(A_1.linux);
			}
			if (A_1.windowsUWP != null)
			{
				this.windowsUWP = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsUWP>(A_1.windowsUWP);
			}
			if (A_1.fallback_Windows != null)
			{
				this.fallback_Windows = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_Windows);
			}
			if (A_1.fallback_WindowsUWP != null)
			{
				this.fallback_WindowsUWP = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_WindowsUWP);
			}
			if (A_1.fallback_OSX != null)
			{
				this.fallback_OSX = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_OSX);
			}
			if (A_1.fallback_Android != null)
			{
				this.fallback_Android = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_Android);
			}
			if (A_1.fallback_iOS != null)
			{
				this.fallback_iOS = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_iOS);
			}
			if (A_1.fallback_Linux != null)
			{
				this.fallback_Linux = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_Linux);
			}
			if (A_1.fallback_Linux_PreConfigured != null)
			{
				this.fallback_Linux_PreConfigured = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_Linux_PreConfigured);
			}
			if (A_1.fallback_PS4 != null)
			{
				this.fallback_PS4 = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_PS4);
			}
			if (A_1.fallback_PSM != null)
			{
				this.fallback_PSM = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_PSM);
			}
			if (A_1.fallback_PSVita != null)
			{
				this.fallback_PSVita = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_PSVita);
			}
			if (A_1.fallback_XBoxOne != null)
			{
				this.fallback_XBoxOne = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_XBoxOne);
			}
			if (A_1.nintendoSwitch != null)
			{
				this.nintendoSwitch = MiscTools.DeepClone<HardwareJoystickMap.Platform_NintendoSwitch>(A_1.nintendoSwitch);
			}
			if (A_1.fallback_AmazonFireTV != null)
			{
				this.fallback_AmazonFireTV = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback>(this.fallback_AmazonFireTV);
			}
			if (A_1.webGL != null)
			{
				this.webGL = MiscTools.DeepClone<HardwareJoystickMap.Platform_WebGL>(A_1.webGL);
			}
			if (A_1.xboxOne != null)
			{
				this.xboxOne = MiscTools.DeepClone<HardwareJoystickMap.Platform_XboxOne>(A_1.xboxOne);
			}
			if (A_1.gameCore != null)
			{
				this.gameCore = MiscTools.DeepClone<HardwareJoystickMap.Platform_GameCore>(A_1.gameCore);
			}
			if (A_1.ps4 != null)
			{
				this.ps4 = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS4>(A_1.ps4);
			}
			if (A_1.ps5 != null)
			{
				this.ps5 = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS5>(A_1.ps5);
			}
			if (A_1.internalDriver != null)
			{
				this.internalDriver = MiscTools.DeepClone<HardwareJoystickMap.Platform_InternalDriver>(A_1.internalDriver);
			}
			if (A_1.sdl2_Linux != null)
			{
				this.sdl2_Linux = MiscTools.DeepClone<HardwareJoystickMap.Platform_SDL2>(A_1.sdl2_Linux);
			}
			if (A_1.sdl2_Windows != null)
			{
				this.sdl2_Windows = MiscTools.DeepClone<HardwareJoystickMap.Platform_SDL2>(A_1.sdl2_Windows);
			}
			if (A_1.sdl2_OSX != null)
			{
				this.sdl2_OSX = MiscTools.DeepClone<HardwareJoystickMap.Platform_SDL2>(A_1.sdl2_OSX);
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06001EE1 RID: 7905 RVA: 0x0001816C File Offset: 0x0001636C
		public string ControllerName
		{
			get
			{
				return this.controllerName;
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06001EE2 RID: 7906 RVA: 0x00018174 File Offset: 0x00016374
		public string EditorControllerName
		{
			get
			{
				return this.editorControllerName;
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x06001EE3 RID: 7907 RVA: 0x0001817C File Offset: 0x0001637C
		public Guid Guid
		{
			get
			{
				if (!ReInput.isReady)
				{
					return StringTools.ToGuid(this.controllerGuid);
				}
				return this.runtimeControllerGuid;
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06001EE4 RID: 7908 RVA: 0x00018197 File Offset: 0x00016397
		public string Key
		{
			get
			{
				return this.controllerKey;
			}
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06001EE5 RID: 7909 RVA: 0x0001819F File Offset: 0x0001639F
		public IEnumerable<Guid> TemplateGuids
		{
			get
			{
				if (ReInput.isReady)
				{
					Guid[] array = this.runtimeTemplateGuids;
					if (array == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < array.Length; i = num + 1)
					{
						yield return array[i];
						num = i;
					}
					array = null;
				}
				else
				{
					if (this.templateGuids == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.templateGuids.Length; i = num + 1)
					{
						yield return StringTools.ToGuid(this.templateGuids[i]);
						num = i;
					}
				}
				yield break;
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06001EE6 RID: 7910 RVA: 0x000181AF File Offset: 0x000163AF
		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
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

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06001EE7 RID: 7911 RVA: 0x000181BF File Offset: 0x000163BF
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

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001EE8 RID: 7912 RVA: 0x000181D3 File Offset: 0x000163D3
		public bool HideInLists
		{
			get
			{
				return this.hideInLists;
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001EE9 RID: 7913 RVA: 0x000181DB File Offset: 0x000163DB
		internal IEnumerable<JoystickType> JoystickTypes
		{
			get
			{
				if (this.joystickTypes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.joystickTypes.Length; i = num + 1)
				{
					yield return this.joystickTypes[i];
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06001EEA RID: 7914 RVA: 0x000181EB File Offset: 0x000163EB
		Guid IHardwareControllerMap_Internal.typeGuid
		{
			get
			{
				return this.Guid;
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06001EEB RID: 7915 RVA: 0x00018197 File Offset: 0x00016397
		string IHardwareControllerMap_Internal.typeKey
		{
			get
			{
				return this.controllerKey;
			}
		}

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001EEC RID: 7916 RVA: 0x0000550E File Offset: 0x0000370E
		ControllerType IHardwareControllerMap_Internal.controllerType
		{
			get
			{
				return ControllerType.Joystick;
			}
		}

		// Token: 0x06001EED RID: 7917 RVA: 0x00081BEC File Offset: 0x0007FDEC
		public int GetTemplateGuids(IList<Guid> results)
		{
			int num = 0;
			if (ReInput.isReady)
			{
				Guid[] runtimeTemplateGuids = this.runtimeTemplateGuids;
				if (runtimeTemplateGuids == null)
				{
					return 0;
				}
				int num2 = runtimeTemplateGuids.Length;
				for (int i = 0; i < num2; i++)
				{
					results.Add(runtimeTemplateGuids[i]);
					num++;
				}
			}
			else
			{
				if (this.templateGuids == null)
				{
					return 0;
				}
				for (int j = 0; j < this.templateGuids.Length; j++)
				{
					results.Add(StringTools.ToGuid(this.templateGuids[j]));
					num++;
				}
			}
			return num;
		}

		// Token: 0x06001EEE RID: 7918 RVA: 0x00081C6C File Offset: 0x0007FE6C
		public bool ContainsTemplateGuid(Guid guid)
		{
			if (ReInput.isReady)
			{
				Guid[] runtimeTemplateGuids = this.runtimeTemplateGuids;
				if (runtimeTemplateGuids == null)
				{
					return false;
				}
				int num = runtimeTemplateGuids.Length;
				for (int i = 0; i < num; i++)
				{
					if (guid == runtimeTemplateGuids[i])
					{
						return true;
					}
				}
			}
			else
			{
				if (this.templateGuids == null)
				{
					return false;
				}
				for (int j = 0; j < this.templateGuids.Length; j++)
				{
					if (guid == StringTools.ToGuid(this.templateGuids[j]))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001EEF RID: 7919 RVA: 0x00081CE4 File Offset: 0x0007FEE4
		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.elementIdentifiers[i].name;
			}
			return array;
		}

		// Token: 0x06001EF0 RID: 7920 RVA: 0x00081D30 File Offset: 0x0007FF30
		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			if (num == 0)
			{
				return null;
			}
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.elementIdentifiers[i].id;
			}
			return array;
		}

		// Token: 0x06001EF1 RID: 7921 RVA: 0x00081D7C File Offset: 0x0007FF7C
		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = this.IndexOfElementIdentifier(id);
			if (num < 0 || num >= this.elementIdentifiers.Length)
			{
				return null;
			}
			return this.elementIdentifiers[num];
		}

		// Token: 0x06001EF2 RID: 7922 RVA: 0x000181F3 File Offset: 0x000163F3
		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			if (index < 0 || index >= this.elementIdentifiers.Length)
			{
				return null;
			}
			return this.elementIdentifiers[index];
		}

		// Token: 0x06001EF3 RID: 7923 RVA: 0x0001820E File Offset: 0x0001640E
		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return this.IndexOfElementIdentifier(id) >= 0;
		}

		// Token: 0x06001EF4 RID: 7924 RVA: 0x00081DAC File Offset: 0x0007FFAC
		[CustomObfuscation(rename = false)]
		public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			if (num == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (this.elementIdentifiers[i] != null && this.elementIdentifiers[i].elementType == type)
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

		// Token: 0x06001EF5 RID: 7925 RVA: 0x00081E64 File Offset: 0x00080064
		[CustomObfuscation(rename = false)]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = (this.elementIdentifiers != null) ? this.elementIdentifiers.Length : 0;
			if (num == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
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

		// Token: 0x06001EF6 RID: 7926 RVA: 0x0001821D File Offset: 0x0001641D
		internal HardwareJoystickMap Clone()
		{
			return new HardwareJoystickMap(this);
		}

		// Token: 0x06001EF7 RID: 7927 RVA: 0x00081F20 File Offset: 0x00080120
		internal int IndexOfElementIdentifier(int id)
		{
			if (this.elementIdentifiers == null)
			{
				return -1;
			}
			for (int i = 0; i < this.elementIdentifiers.Length; i++)
			{
				if (this.elementIdentifiers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001EF8 RID: 7928 RVA: 0x00081F60 File Offset: 0x00080160
		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			ControllerElementIdentifier elementIdentifier = this.GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return ControllerElementType.Axis;
			}
			HardwareJoystickMap.Platform specificPlatformMap = this.GetSpecificPlatformMap(hardwareMapIdentifier);
			if (specificPlatformMap == null)
			{
				return ControllerElementType.Axis;
			}
			return specificPlatformMap.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		// Token: 0x06001EF9 RID: 7929 RVA: 0x00081F90 File Offset: 0x00080190
		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = AxisRange.Full;
			ControllerElementIdentifier elementIdentifier = this.GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return false;
			}
			HardwareJoystickMap.Platform specificPlatformMap = this.GetSpecificPlatformMap(hardwareMapIdentifier);
			return specificPlatformMap != null && specificPlatformMap.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		// Token: 0x06001EFA RID: 7930 RVA: 0x00081FC4 File Offset: 0x000801C4
		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			axes = null;
			HardwareJoystickMap.Platform specificPlatformMap = this.GetSpecificPlatformMap(hardwareMapIdentifier);
			if (specificPlatformMap == null)
			{
				return;
			}
			if (specificPlatformMap.assignedButtonCount <= 0)
			{
				return;
			}
			specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x00018225 File Offset: 0x00016425
		internal static bool Matches(HardwareJoystickMap.Platform platform, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
		{
			if (platform == null)
			{
				variantIndex = -1;
				platformMap = null;
				return false;
			}
			return platform.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		}

		// Token: 0x06001EFC RID: 7932 RVA: 0x00081FF8 File Offset: 0x000801F8
		internal bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
		{
			actualInputPlatform = InputPlatform.Unknown;
			variantIndex = -1;
			platformMap = null;
			if (bridgedControllerHWInfo == null)
			{
				return false;
			}
			InputSource inputSource = bridgedControllerHWInfo.inputSource;
			switch (inputSource)
			{
			case InputSource.DirectInput:
				if (HardwareJoystickMap.Matches(this.directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					return true;
				}
				if (HardwareJoystickMap.Matches(this.rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsRawInput;
					return true;
				}
				return false;
			case InputSource.XInput:
				if (this.xInput == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsXInput;
				return this.xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.OSX:
				if (this.osx == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.OSXNative;
				return this.osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				platformMap = this.FindFallbackMatch(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
				return platformMap != null;
			case InputSource.RawInput:
				if (HardwareJoystickMap.Matches(this.rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsRawInput;
					return true;
				}
				if (HardwareJoystickMap.Matches(this.directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					return true;
				}
				return false;
			case InputSource.Linux:
				if (this.linux == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.LinuxNative;
				return this.linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WindowsUWP:
				if (this.windowsUWP == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsUWP;
				return this.windowsUWP.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WebGL:
				if (this.webGL == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WebGL;
				return this.webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case (InputSource)10:
			case (InputSource)11:
			case (InputSource)12:
			case (InputSource)13:
			case (InputSource)14:
			case (InputSource)15:
			case (InputSource)16:
			case (InputSource)17:
			case InputSource.Ouya:
			case (InputSource)23:
			case (InputSource)25:
				break;
			case InputSource.Steam:
				actualInputPlatform = InputPlatform.Steam;
				return false;
			case InputSource.SDL2:
				platformMap = this.FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
				return platformMap != null;
			case InputSource.XboxOne:
				if (this.xboxOne == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.XboxOne;
				return this.xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS4:
				if (this.ps4 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.PS4;
				return this.ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.NintendoSwitch:
				if (this.nintendoSwitch == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.NintendoSwitch;
				return this.nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				if (this.gameCore == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.GameCore;
				return this.gameCore.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS5:
				if (this.ps5 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.PS5;
				return this.ps5.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.AppleGameController:
				if (this.appleGCController == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.AppleGameController;
				return this.appleGCController.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WindowsGamingInput:
				if (this.windowsWGI == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsWGI;
				return this.windowsWGI.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			default:
				if (inputSource != InputSource.InternalDriver)
				{
					if (inputSource == InputSource.Custom)
					{
						if (!xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.Custom;
						platformMap = xApfUAgfQcPgXcXdmaKvwTZGIoxYA.smuPPWtijAeWDxTnQgXWGCxzyKZf().GetPlatformMap(xApfUAgfQcPgXcXdmaKvwTZGIoxYA.OmZwoJVuDaIJjIIgibqUDqkIfENMA, this.Guid);
						return platformMap != null && platformMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					}
				}
				else
				{
					if (this.internalDriver == null)
					{
						return false;
					}
					actualInputPlatform = InputPlatform.InternalDriver;
					return this.internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
				}
				break;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001EFD RID: 7933 RVA: 0x0008233C File Offset: 0x0008053C
		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			InputSource inputSource = bridgedController.inputSource;
			InputPlatform actualInputPlatform;
			HardwareJoystickMap.Platform platform;
			if (inputSource <= InputSource.InternalDriver)
			{
				switch (inputSource)
				{
				case InputSource.None:
					return null;
				case InputSource.DirectInput:
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					platform = this.directInput;
					goto IL_1E6;
				case InputSource.XInput:
					actualInputPlatform = InputPlatform.WindowsXInput;
					platform = this.xInput;
					goto IL_1E6;
				case InputSource.OSX:
					actualInputPlatform = InputPlatform.OSXNative;
					platform = this.osx;
					goto IL_1E6;
				case InputSource.Fallback:
				case InputSource.Fallback_PreConfigured:
				{
					int num;
					platform = this.FindFallbackMap(inputSource, true, out actualInputPlatform, out num);
					goto IL_1E6;
				}
				case InputSource.RawInput:
					actualInputPlatform = InputPlatform.WindowsRawInput;
					platform = this.rawInput;
					goto IL_1E6;
				case InputSource.Linux:
					actualInputPlatform = InputPlatform.LinuxNative;
					platform = this.linux;
					goto IL_1E6;
				case InputSource.WindowsUWP:
					actualInputPlatform = InputPlatform.WindowsUWP;
					platform = this.windowsUWP;
					goto IL_1E6;
				case InputSource.WebGL:
					actualInputPlatform = InputPlatform.WebGL;
					platform = this.webGL;
					goto IL_1E6;
				case (InputSource)10:
				case (InputSource)11:
				case (InputSource)12:
				case (InputSource)13:
				case (InputSource)14:
				case (InputSource)15:
				case (InputSource)16:
				case (InputSource)17:
				case InputSource.Ouya:
				case (InputSource)23:
				case (InputSource)25:
					goto IL_1E0;
				case InputSource.Steam:
					break;
				case InputSource.SDL2:
				{
					int num;
					platform = this.FindSDL2Map(inputSource, true, out actualInputPlatform, out num);
					goto IL_1E6;
				}
				case InputSource.XboxOne:
					actualInputPlatform = InputPlatform.XboxOne;
					platform = this.xboxOne;
					goto IL_1E6;
				case InputSource.PS4:
					actualInputPlatform = InputPlatform.PS4;
					platform = this.ps4;
					goto IL_1E6;
				case InputSource.NintendoSwitch:
					actualInputPlatform = InputPlatform.NintendoSwitch;
					platform = this.nintendoSwitch;
					goto IL_1E6;
				case InputSource.GameCoreXboxOne:
				case InputSource.GameCoreScarlett:
					actualInputPlatform = InputPlatform.GameCore;
					platform = this.gameCore;
					if (!this.gameCore.hasData)
					{
						platform = HardwareJoystickMap.Platform_GameCore.CreateDefaultMap(bridgedController);
						goto IL_1E6;
					}
					goto IL_1E6;
				case InputSource.PS5:
					actualInputPlatform = InputPlatform.PS5;
					platform = this.ps5;
					goto IL_1E6;
				case InputSource.AppleGameController:
					actualInputPlatform = InputPlatform.AppleGameController;
					platform = this.appleGCController;
					goto IL_1E6;
				case InputSource.WindowsGamingInput:
					actualInputPlatform = InputPlatform.WindowsWGI;
					platform = this.windowsWGI;
					goto IL_1E6;
				default:
					if (inputSource != InputSource.InternalDriver)
					{
						goto IL_1E0;
					}
					actualInputPlatform = InputPlatform.InternalDriver;
					platform = this.internalDriver;
					goto IL_1E6;
				}
			}
			else if (inputSource != InputSource.UnityKeyboardAndMouse)
			{
				if (inputSource != InputSource.Custom)
				{
					goto IL_1E0;
				}
				if (!xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
				{
					return null;
				}
				actualInputPlatform = InputPlatform.Custom;
				platform = xApfUAgfQcPgXcXdmaKvwTZGIoxYA.smuPPWtijAeWDxTnQgXWGCxzyKZf().GetPlatformMap(xApfUAgfQcPgXcXdmaKvwTZGIoxYA.OmZwoJVuDaIJjIIgibqUDqkIfENMA, this.Guid);
				goto IL_1E6;
			}
			throw new NotImplementedException();
			IL_1E0:
			throw new NotImplementedException();
			IL_1E6:
			if (platform == null)
			{
				return null;
			}
			return platform.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x0001823E File Offset: 0x0001643E
		internal string[] GetTemplateGuidsOrig()
		{
			return this.templateGuids;
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001EFF RID: 7935 RVA: 0x00018246 File Offset: 0x00016446
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

		// Token: 0x06001F00 RID: 7936 RVA: 0x00018256 File Offset: 0x00016456
		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return this.GetElementIdentifier(id);
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x00082540 File Offset: 0x00080740
		private HardwareJoystickMap.Platform_Fallback_Base FindFallbackMatch(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			InputSource inputSource = bridgedControllerHWInfo.inputSource;
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			HardwareJoystickMap.Platform_Fallback_Base platform_Fallback_Base;
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			case Rewired.Platforms.Platform.WindowsAppStore:
				platform_Fallback_Base = this.fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.WindowsPhone8:
			case Rewired.Platforms.Platform.Blackberry:
			case Rewired.Platforms.Platform.Xbox360:
			case Rewired.Platforms.Platform.PS3:
				goto IL_26F;
			case Rewired.Platforms.Platform.OSX:
				platform_Fallback_Base = this.fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.iOS:
				break;
			case Rewired.Platforms.Platform.Linux:
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					platform_Fallback_Base = this.fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
					platform_Fallback_Base = this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
					{
						platform_Fallback_Base = null;
					}
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
				}
				platform_Fallback_Base = this.fallback_Linux;
				actualInputPlatform = InputPlatform.LinuxFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.Android:
				platform_Fallback_Base = this.fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					platform_Fallback_Base = this.fallback_Windows;
					actualInputPlatform = InputPlatform.WindowsFallback;
					return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					platform_Fallback_Base = this.fallback_OSX;
					actualInputPlatform = InputPlatform.OSXFallback;
					return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				goto IL_26F;
			case Rewired.Platforms.Platform.XboxOne:
				platform_Fallback_Base = this.fallback_XBoxOne;
				actualInputPlatform = InputPlatform.XBoxOneFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.PS4:
				platform_Fallback_Base = this.fallback_PS4;
				actualInputPlatform = InputPlatform.PS4Fallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.PSVita:
				platform_Fallback_Base = this.fallback_PSVita;
				actualInputPlatform = InputPlatform.PSVitaFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.PSMobile:
				platform_Fallback_Base = this.fallback_PSM;
				actualInputPlatform = InputPlatform.PSMFallback;
				return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			default:
				switch (platform)
				{
				case Rewired.Platforms.Platform.tvOS:
					break;
				case Rewired.Platforms.Platform.WindowsUWP:
					platform_Fallback_Base = this.fallback_WindowsUWP;
					actualInputPlatform = InputPlatform.WindowsUWPFallback;
					return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.Windows81Store:
				case Rewired.Platforms.Platform.N3DS:
				case Rewired.Platforms.Platform.Switch:
					goto IL_26F;
				default:
					if (platform != Rewired.Platforms.Platform.AmazonFireTV)
					{
						goto IL_26F;
					}
					platform_Fallback_Base = this.fallback_AmazonFireTV;
					actualInputPlatform = InputPlatform.AmazonFireTVFallback;
					platform_Fallback_Base = this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
					{
						platform_Fallback_Base = null;
					}
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					platform_Fallback_Base = this.fallback_Android;
					actualInputPlatform = InputPlatform.AndroidFallback;
					return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			platform_Fallback_Base = this.fallback_iOS;
			actualInputPlatform = InputPlatform.iOSFallback;
			return this.TryGetFirstMatchingMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			IL_26F:
			if (isDefaultMap)
			{
				return this.GetUniversalDefaultMap<HardwareJoystickMap.Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.Unknown;
			return null;
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x000827D4 File Offset: 0x000809D4
		private HardwareJoystickMap.Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			HardwareJoystickMap.Platform_Fallback_Base platform_Fallback_Base;
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			case Rewired.Platforms.Platform.WindowsAppStore:
				platform_Fallback_Base = this.fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.WindowsPhone8:
			case Rewired.Platforms.Platform.Blackberry:
			case Rewired.Platforms.Platform.Xbox360:
			case Rewired.Platforms.Platform.PS3:
				goto IL_22A;
			case Rewired.Platforms.Platform.OSX:
				platform_Fallback_Base = this.fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.iOS:
				break;
			case Rewired.Platforms.Platform.Linux:
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					platform_Fallback_Base = this.fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
					platform_Fallback_Base = this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
					{
						platform_Fallback_Base = null;
					}
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
				}
				platform_Fallback_Base = this.fallback_Linux;
				actualInputPlatform = InputPlatform.LinuxFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.Android:
				platform_Fallback_Base = this.fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					platform_Fallback_Base = this.fallback_Windows;
					actualInputPlatform = InputPlatform.WindowsFallback;
					return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					platform_Fallback_Base = this.fallback_OSX;
					actualInputPlatform = InputPlatform.OSXFallback;
					return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				goto IL_22A;
			case Rewired.Platforms.Platform.XboxOne:
				platform_Fallback_Base = this.fallback_XBoxOne;
				actualInputPlatform = InputPlatform.XBoxOneFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.PS4:
				platform_Fallback_Base = this.fallback_PS4;
				actualInputPlatform = InputPlatform.PS4Fallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.PSVita:
				platform_Fallback_Base = this.fallback_PSVita;
				actualInputPlatform = InputPlatform.PSVitaFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			case Rewired.Platforms.Platform.PSMobile:
				platform_Fallback_Base = this.fallback_PSM;
				actualInputPlatform = InputPlatform.PSMFallback;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			default:
				switch (platform)
				{
				case Rewired.Platforms.Platform.tvOS:
					break;
				case Rewired.Platforms.Platform.WindowsUWP:
					platform_Fallback_Base = this.fallback_WindowsUWP;
					actualInputPlatform = InputPlatform.WindowsUWPFallback;
					return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.Windows81Store:
				case Rewired.Platforms.Platform.N3DS:
				case Rewired.Platforms.Platform.Switch:
					goto IL_22A;
				default:
					if (platform != Rewired.Platforms.Platform.AmazonFireTV)
					{
						goto IL_22A;
					}
					platform_Fallback_Base = this.fallback_AmazonFireTV;
					actualInputPlatform = InputPlatform.AmazonFireTVFallback;
					platform_Fallback_Base = this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
					{
						platform_Fallback_Base = null;
					}
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					platform_Fallback_Base = this.fallback_Android;
					actualInputPlatform = InputPlatform.AndroidFallback;
					return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			platform_Fallback_Base = this.fallback_iOS;
			actualInputPlatform = InputPlatform.iOSFallback;
			return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_Fallback_Base>(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
			IL_22A:
			if (isDefaultMap)
			{
				return this.GetUniversalDefaultMap<HardwareJoystickMap.Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.Unknown;
			return null;
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x00082A20 File Offset: 0x00080C20
		private HardwareJoystickMap.Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			HardwareJoystickMap.Platform_SDL2_Base mainMap;
			if (platform == Rewired.Platforms.Platform.Windows)
			{
				mainMap = this.sdl2_Windows;
				actualInputPlatform = InputPlatform.SDL2Windows;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_SDL2_Base>(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			if (platform == Rewired.Platforms.Platform.OSX)
			{
				mainMap = this.sdl2_OSX;
				actualInputPlatform = InputPlatform.SDL2OSX;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_SDL2_Base>(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			if (platform != Rewired.Platforms.Platform.Linux)
			{
				if (isDefaultMap)
				{
					this.GetUniversalDefaultMap<HardwareJoystickMap.Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				}
				actualInputPlatform = InputPlatform.Unknown;
				variantIndex = -1;
				return null;
			}
			mainMap = this.sdl2_Linux;
			actualInputPlatform = InputPlatform.SDL2Linux;
			return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_SDL2_Base>(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x00082ACC File Offset: 0x00080CCC
		private HardwareJoystickMap.Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			HardwareJoystickMap.Platform_SDL2_Base mainMap;
			if (platform == Rewired.Platforms.Platform.Windows)
			{
				mainMap = this.sdl2_Windows;
				actualInputPlatform = InputPlatform.SDL2Windows;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_SDL2_Base>(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			if (platform == Rewired.Platforms.Platform.OSX)
			{
				mainMap = this.sdl2_OSX;
				actualInputPlatform = InputPlatform.SDL2OSX;
				return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_SDL2_Base>(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			if (platform != Rewired.Platforms.Platform.Linux)
			{
				if (isDefaultMap)
				{
					this.GetUniversalDefaultMap<HardwareJoystickMap.Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				}
				actualInputPlatform = InputPlatform.Unknown;
				variantIndex = -1;
				return null;
			}
			mainMap = this.sdl2_Linux;
			actualInputPlatform = InputPlatform.SDL2Linux;
			return this.TryGetFirstValidMap<HardwareJoystickMap.Platform_SDL2_Base>(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}

		// Token: 0x06001F05 RID: 7941 RVA: 0x00082B70 File Offset: 0x00080D70
		private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : HardwareJoystickMap.Platform
		{
			if (isDefaultMap)
			{
				if (mainMap == null || !mainMap.selfOrVariantIsAllowed)
				{
					return this.GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				if (mainMap.isAllowed)
				{
					variantIndex = -1;
					return mainMap;
				}
				IList<HardwareJoystickMap.Platform> variants = mainMap.GetVariants();
				if (variants != null)
				{
					for (int i = 0; i < variants.Count; i++)
					{
						HardwareJoystickMap.Platform platform = variants[i];
						if (platform != null && platform.isAllowed)
						{
							variantIndex = i;
							return platform as T;
						}
					}
				}
				return this.GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			else
			{
				if (mainMap == null || !mainMap.selfOrVariantIsValid)
				{
					variantIndex = -1;
					return default(T);
				}
				return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
			}
		}

		// Token: 0x06001F06 RID: 7942 RVA: 0x00082C3C File Offset: 0x00080E3C
		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : HardwareJoystickMap.Platform
		{
			if (isDefaultMap)
			{
				if (mainMap == null)
				{
					return this.GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				HardwareJoystickMap.Platform platform;
				if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platform))
				{
					return platform as T;
				}
				return this.GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			else
			{
				if (mainMap == null)
				{
					variantIndex = -1;
					return default(T);
				}
				HardwareJoystickMap.Platform platform;
				if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platform))
				{
					return platform as T;
				}
				variantIndex = -1;
				return default(T);
			}
		}

		// Token: 0x06001F07 RID: 7943 RVA: 0x00082CCC File Offset: 0x00080ECC
		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : HardwareJoystickMap.Platform
		{
			T universalDefaultMapRoot = this.GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
			actualInputPlatform = InputPlatform.SDL2Windows;
			variantIndex = -1;
			if (universalDefaultMapRoot == null || !universalDefaultMapRoot.selfOrVariantIsAllowed)
			{
				return default(T);
			}
			if (universalDefaultMapRoot.isAllowed)
			{
				return universalDefaultMapRoot;
			}
			IList<HardwareJoystickMap.Platform> variants = universalDefaultMapRoot.GetVariants();
			if (variants != null)
			{
				for (int i = 0; i < variants.Count; i++)
				{
					if (variants[i] != null && variants[i].isAllowed)
					{
						variantIndex = i;
						return variants[i] as T;
					}
				}
			}
			return default(T);
		}

		// Token: 0x06001F08 RID: 7944 RVA: 0x00082D78 File Offset: 0x00080F78
		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : HardwareJoystickMap.Platform
		{
			if (type == typeof(HardwareJoystickMap.Platform_Fallback_Base))
			{
				actualInputPlatform = InputPlatform.WindowsFallback;
				return this.fallback_Windows as T;
			}
			if (type == typeof(HardwareJoystickMap.Platform_SDL2_Base))
			{
				actualInputPlatform = InputPlatform.SDL2Windows;
				return this.sdl2_Windows as T;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001F09 RID: 7945 RVA: 0x00082DD0 File Offset: 0x00080FD0
		private HardwareJoystickMap.Platform GetSpecificPlatformMap(HardwareControllerMapIdentifier hardwareMapIdentifier)
		{
			HardwareJoystickMap.Platform specificPlatformRoot = this.GetSpecificPlatformRoot(hardwareMapIdentifier.actualInputPlatform);
			if (specificPlatformRoot == null)
			{
				return null;
			}
			return specificPlatformRoot.GetPlatformMap(hardwareMapIdentifier.variantIndex);
		}

		// Token: 0x06001F0A RID: 7946 RVA: 0x00082DFC File Offset: 0x00080FFC
		private HardwareJoystickMap.Platform GetSpecificPlatformRoot(InputPlatform exactInputPlatform)
		{
			switch (exactInputPlatform)
			{
			case InputPlatform.Unknown:
			case InputPlatform.Steam:
				throw new NotImplementedException();
			case InputPlatform.WindowsDirectInput:
				return this.directInput;
			case InputPlatform.WindowsRawInput:
				return this.rawInput;
			case InputPlatform.WindowsXInput:
				return this.xInput;
			case InputPlatform.WindowsFallback:
				return this.fallback_Windows;
			case InputPlatform.WindowsUWP:
				return this.windowsUWP;
			case InputPlatform.WindowsUWPFallback:
				return this.fallback_WindowsUWP;
			case InputPlatform.WindowsWGI:
				return this.windowsWGI;
			case InputPlatform.OSXNative:
				return this.osx;
			case InputPlatform.OSXFallback:
				return this.fallback_OSX;
			case InputPlatform.LinuxNative:
				return this.linux;
			case InputPlatform.LinuxFallback:
				return this.fallback_Linux;
			case InputPlatform.LinuxFallback_PreConfigured:
				return this.fallback_Linux_PreConfigured;
			case InputPlatform.AndroidFallback:
				return this.fallback_Android;
			case InputPlatform.AmazonFireTVFallback:
				return this.fallback_AmazonFireTV;
			case InputPlatform.RazerForgeTVFallback:
				return this.fallback_Android;
			case InputPlatform.iOSFallback:
				return this.fallback_iOS;
			case InputPlatform.WindowsPhone8Fallback:
			case InputPlatform.BlackberryFallback:
			case InputPlatform.PS3Fallback:
			case InputPlatform.XBox360Fallback:
			case InputPlatform.WiiFallback:
			case InputPlatform.WiiUFallback:
			case InputPlatform.Ouya:
			case InputPlatform.NintendoSwitchFallback:
				goto IL_1DA;
			case InputPlatform.PS4Fallback:
				return this.fallback_PS4;
			case InputPlatform.PSMFallback:
				return this.fallback_PSM;
			case InputPlatform.PSVitaFallback:
				return this.fallback_PSVita;
			case InputPlatform.XBoxOneFallback:
				return this.fallback_XBoxOne;
			case InputPlatform.Fallback:
				throw new NotImplementedException();
			case InputPlatform.XboxOne:
				return this.xboxOne;
			case InputPlatform.GameCore:
				return this.gameCore;
			case InputPlatform.PS4:
				return this.ps4;
			case InputPlatform.PS5:
				return this.ps5;
			case InputPlatform.NintendoSwitch:
				return this.nintendoSwitch;
			case InputPlatform.Custom:
				if (!xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
				{
					throw new Exception("Custom Platform is not set.");
				}
				try
				{
					return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.smuPPWtijAeWDxTnQgXWGCxzyKZf().GetPlatformMap(xApfUAgfQcPgXcXdmaKvwTZGIoxYA.OmZwoJVuDaIJjIIgibqUDqkIfENMA, this.Guid);
				}
				catch (Exception msg)
				{
					Logger.LogError(msg);
					return null;
				}
				break;
			case InputPlatform.InternalDriver:
				break;
			case InputPlatform.SDL2:
				throw new NotImplementedException();
			case InputPlatform.SDL2Windows:
				return this.sdl2_Windows;
			case InputPlatform.SDL2OSX:
				return this.sdl2_OSX;
			case InputPlatform.SDL2Linux:
				return this.sdl2_Linux;
			case InputPlatform.WebGL:
				return this.webGL;
			case InputPlatform.AppleGameController:
				return this.appleGCController;
			default:
				goto IL_1DA;
			}
			return this.internalDriver;
			IL_1DA:
			throw new NotImplementedException();
		}

		// Token: 0x06001F0B RID: 7947 RVA: 0x0001825F File Offset: 0x0001645F
		string IHardwareControllerMap_Internal.get_name()
		{
			return base.name;
		}

		// Token: 0x04001163 RID: 4451
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		// Token: 0x04001164 RID: 4452
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string editorControllerName;

		// Token: 0x04001165 RID: 4453
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		// Token: 0x04001166 RID: 4454
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerGuid;

		// Token: 0x04001167 RID: 4455
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerKey;

		// Token: 0x04001168 RID: 4456
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string[] templateGuids;

		// Token: 0x04001169 RID: 4457
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool hideInLists;

		// Token: 0x0400116A RID: 4458
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickType[] joystickTypes;

		// Token: 0x0400116B RID: 4459
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementIdentifier[] elementIdentifiers;

		// Token: 0x0400116C RID: 4460
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.CompoundElement[] compoundElements;

		// Token: 0x0400116D RID: 4461
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_DirectInput directInput;

		// Token: 0x0400116E RID: 4462
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_RawInput rawInput;

		// Token: 0x0400116F RID: 4463
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_XInput xInput;

		// Token: 0x04001170 RID: 4464
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_WindowsWGI windowsWGI;

		// Token: 0x04001171 RID: 4465
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_OSX osx;

		// Token: 0x04001172 RID: 4466
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Linux linux;

		// Token: 0x04001173 RID: 4467
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_WindowsUWP windowsUWP;

		// Token: 0x04001174 RID: 4468
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_Windows;

		// Token: 0x04001175 RID: 4469
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_WindowsUWP;

		// Token: 0x04001176 RID: 4470
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_OSX;

		// Token: 0x04001177 RID: 4471
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_Linux;

		// Token: 0x04001178 RID: 4472
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_Linux_PreConfigured;

		// Token: 0x04001179 RID: 4473
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_Android;

		// Token: 0x0400117A RID: 4474
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_iOS;

		// Token: 0x0400117B RID: 4475
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_XBoxOne;

		// Token: 0x0400117C RID: 4476
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_PS4;

		// Token: 0x0400117D RID: 4477
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_PS5 ps5;

		// Token: 0x0400117E RID: 4478
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_PSM;

		// Token: 0x0400117F RID: 4479
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_PSVita;

		// Token: 0x04001180 RID: 4480
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_Fallback fallback_AmazonFireTV;

		// Token: 0x04001181 RID: 4481
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_WebGL webGL;

		// Token: 0x04001182 RID: 4482
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_XboxOne xboxOne;

		// Token: 0x04001183 RID: 4483
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_GameCore gameCore;

		// Token: 0x04001184 RID: 4484
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_PS4 ps4;

		// Token: 0x04001185 RID: 4485
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_NintendoSwitch nintendoSwitch;

		// Token: 0x04001186 RID: 4486
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_InternalDriver internalDriver;

		// Token: 0x04001187 RID: 4487
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_SDL2 sdl2_Linux;

		// Token: 0x04001188 RID: 4488
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_SDL2 sdl2_Windows;

		// Token: 0x04001189 RID: 4489
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_SDL2 sdl2_OSX;

		// Token: 0x0400118A RID: 4490
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap.Platform_AppleGCController appleGCController;

		// Token: 0x0400118B RID: 4491
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		// Token: 0x0400118C RID: 4492
		[NonSerialized]
		private Guid? __runtimeControllerGuidCache;

		// Token: 0x0400118D RID: 4493
		[NonSerialized]
		private Guid[] __runtimeTemplateGuidCache;

		// Token: 0x020002B8 RID: 696
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public abstract class Platform : IDeepCloneable
		{
			// Token: 0x170006FB RID: 1787
			// (get) Token: 0x06001F0C RID: 7948
			internal abstract InputPlatform platform { get; }

			// Token: 0x170006FC RID: 1788
			// (get) Token: 0x06001F0D RID: 7949
			public abstract int assignedButtonCount { get; }

			// Token: 0x170006FD RID: 1789
			// (get) Token: 0x06001F0E RID: 7950
			public abstract int assignedAxisCount { get; }

			// Token: 0x170006FE RID: 1790
			// (get) Token: 0x06001F0F RID: 7951 RVA: 0x000067FE File Offset: 0x000049FE
			public virtual string controllerNameOverride
			{
				get
				{
					return null;
				}
			}

			// Token: 0x170006FF RID: 1791
			// (get) Token: 0x06001F10 RID: 7952
			internal abstract HardwareJoystickMap.Elements_Base elements_base { get; }

			// Token: 0x17000700 RID: 1792
			// (get) Token: 0x06001F11 RID: 7953 RVA: 0x00018267 File Offset: 0x00016467
			internal virtual bool isAllowed
			{
				get
				{
					return !this.disabled && (this.assignedButtonCount > 0 || this.assignedAxisCount > 0);
				}
			}

			// Token: 0x06001F12 RID: 7954
			internal abstract bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap);

			// Token: 0x06001F13 RID: 7955
			internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

			// Token: 0x06001F14 RID: 7956
			internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

			// Token: 0x17000701 RID: 1793
			// (get) Token: 0x06001F15 RID: 7957
			internal abstract bool hasData { get; }

			// Token: 0x17000702 RID: 1794
			// (get) Token: 0x06001F16 RID: 7958
			internal abstract bool disabled { get; }

			// Token: 0x06001F17 RID: 7959
			public abstract IList<HardwareJoystickMap.Platform> GetVariants();

			// Token: 0x17000703 RID: 1795
			// (get) Token: 0x06001F18 RID: 7960 RVA: 0x00018287 File Offset: 0x00016487
			internal IEnumerable<HardwareJoystickMap.Platform> Variants
			{
				get
				{
					IList<HardwareJoystickMap.Platform> variants = this.GetVariants();
					if (variants == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < variants.Count; i = num + 1)
					{
						if (variants[i] != null)
						{
							yield return variants[i];
						}
						num = i;
					}
					yield break;
				}
			}

			// Token: 0x17000704 RID: 1796
			// (get) Token: 0x06001F19 RID: 7961 RVA: 0x00018297 File Offset: 0x00016497
			internal bool hasVariants
			{
				get
				{
					return this.variantCount > 0;
				}
			}

			// Token: 0x17000705 RID: 1797
			// (get) Token: 0x06001F1A RID: 7962 RVA: 0x000182A2 File Offset: 0x000164A2
			[CustomObfuscation(rename = false)]
			internal int variantCount
			{
				get
				{
					if (this.GetVariants() == null)
					{
						return 0;
					}
					return this.GetVariants().Count;
				}
			}

			// Token: 0x17000706 RID: 1798
			// (get) Token: 0x06001F1B RID: 7963 RVA: 0x00082FFC File Offset: 0x000811FC
			internal bool selfOrVariantHasData
			{
				get
				{
					if (this.hasData)
					{
						return true;
					}
					using (IEnumerator<HardwareJoystickMap.Platform> enumerator = this.Variants.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.hasData)
							{
								return true;
							}
						}
					}
					return false;
				}
			}

			// Token: 0x17000707 RID: 1799
			// (get) Token: 0x06001F1C RID: 7964 RVA: 0x0008305C File Offset: 0x0008125C
			internal bool selfOrVariantIsValid
			{
				get
				{
					if (!this.selfOrVariantHasData)
					{
						return false;
					}
					if (this.isAllowed && this.hasData)
					{
						return true;
					}
					foreach (HardwareJoystickMap.Platform platform in this.Variants)
					{
						if (platform.isAllowed && platform.hasData)
						{
							return true;
						}
					}
					return false;
				}
			}

			// Token: 0x17000708 RID: 1800
			// (get) Token: 0x06001F1D RID: 7965 RVA: 0x000830D8 File Offset: 0x000812D8
			internal bool selfOrVariantIsAllowed
			{
				get
				{
					if (this.isAllowed)
					{
						return true;
					}
					using (IEnumerator<HardwareJoystickMap.Platform> enumerator = this.Variants.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.isAllowed)
							{
								return true;
							}
						}
					}
					return false;
				}
			}

			// Token: 0x06001F1E RID: 7966 RVA: 0x00083138 File Offset: 0x00081338
			internal HardwareJoystickMap.Platform GetFirstValidPlatformMap(out int variantIndex)
			{
				variantIndex = -1;
				if (!this.selfOrVariantIsValid)
				{
					return null;
				}
				if (this.isAllowed && this.hasData)
				{
					variantIndex = -1;
					return this;
				}
				IList<HardwareJoystickMap.Platform> variants = this.GetVariants();
				if (variants != null)
				{
					for (int i = 0; i < variants.Count; i++)
					{
						HardwareJoystickMap.Platform platform = variants[i];
						if (platform != null && platform.isAllowed && platform.hasData)
						{
							variantIndex = i;
							return platform;
						}
					}
				}
				return null;
			}

			// Token: 0x06001F1F RID: 7967 RVA: 0x000831A4 File Offset: 0x000813A4
			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				if (elementIdentifiers == null)
				{
					return -1;
				}
				for (int i = 0; i < elementIdentifiers.Length; i++)
				{
					if (elementIdentifiers[i].id == id)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06001F20 RID: 7968
			internal abstract AxisCalibrationData[] GetAxisCalibrationData();

			// Token: 0x06001F21 RID: 7969
			internal abstract void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos);

			// Token: 0x06001F22 RID: 7970
			internal abstract void GetButtonData(out HardwareButtonInfo[] buttonInfos);

			// Token: 0x06001F23 RID: 7971
			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			// Token: 0x06001F24 RID: 7972
			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			// Token: 0x06001F25 RID: 7973 RVA: 0x000831D4 File Offset: 0x000813D4
			internal HardwareJoystickMap.Platform GetPlatformMap(int variantIndex)
			{
				if (variantIndex < 0)
				{
					return this;
				}
				if (!this.hasVariants)
				{
					return null;
				}
				IList<HardwareJoystickMap.Platform> variants = this.GetVariants();
				if (this.variantCount <= variantIndex)
				{
					return null;
				}
				return variants[variantIndex];
			}

			// Token: 0x06001F26 RID: 7974 RVA: 0x0008320C File Offset: 0x0008140C
			internal HardwareJoystickMap_InputManager ToHardwareJoystickMap_InputManager(HardwareJoystickMap hardwareJoystickMap, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
			{
				if (hardwareJoystickMap == null)
				{
					return null;
				}
				HardwareJoystickMap.Platform platform = MiscTools.DeepClone<HardwareJoystickMap.Platform>(this);
				string text = platform.controllerNameOverride;
				if (string.IsNullOrEmpty(text))
				{
					text = hardwareJoystickMap.controllerName;
				}
				List<Guid> list = new List<Guid>();
				hardwareJoystickMap.GetTemplateGuids(list);
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(ControllerType.Joystick, false, hardwareJoystickMap.Guid, new List<string>
				{
					hardwareJoystickMap.Key
				}, list);
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, deviceLocalizationInfo, platform, text, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
				ControllerElementIdentifier[] elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
				int elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
				for (int i = 0; i < elementIdentifierCount; i++)
				{
					hardwareJoystickMap_InputManager.elementIdentifiers[i] = new ControllerElementIdentifier(elementIdentifiers[i], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[i].id), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[i]));
				}
				if (inputSource == InputSource.PS4 && (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4 || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
				{
					for (int j = 0; j < elementIdentifierCount; j++)
					{
						switch (elementIdentifiers[j].id)
						{
						case 0:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "left stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "left stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "left stick left";
							break;
						case 1:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "left stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "left stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "left stick down";
							break;
						case 2:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "right stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "right stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "right stick left";
							break;
						case 3:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "right stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "right stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "right stick down";
							break;
						case 4:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "L2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "L2 button";
							break;
						case 5:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "R2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "R2 button";
							break;
						case 6:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "cross button";
							break;
						case 7:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "circle button";
							break;
						case 8:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "square button";
							break;
						case 9:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "triangle button";
							break;
						case 10:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "L1 button";
							break;
						case 11:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "R1 button";
							break;
						case 12:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "SHARE button";
							break;
						case 13:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "OPTIONS button";
							break;
						case 14:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "PS button";
							break;
						case 15:
							if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "pad button";
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "touch pad button";
							}
							break;
						case 16:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "L3 button";
							break;
						case 17:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "R3 button";
							break;
						case 18:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "up button";
							break;
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "right button";
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "down button";
							break;
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "left button";
							break;
						}
					}
				}
				if (inputSource == InputSource.PS5)
				{
					if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualSense)
					{
						for (int k = 0; k < elementIdentifierCount; k++)
						{
							switch (elementIdentifiers[k].id)
							{
							case 0:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "left stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "left stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "left stick left";
								break;
							case 1:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "left stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "left stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "left stick down";
								break;
							case 2:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "right stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "right stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "right stick left";
								break;
							case 3:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "right stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "right stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "right stick down";
								break;
							case 4:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "L2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "L2 button";
								break;
							case 5:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "R2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "R2 button";
								break;
							case 6:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "cross button";
								break;
							case 7:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "circle button";
								break;
							case 8:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "square button";
								break;
							case 9:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "triangle button";
								break;
							case 10:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "L1 button";
								break;
							case 11:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "R1 button";
								break;
							case 12:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "create button";
								break;
							case 13:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "options button";
								break;
							case 14:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "PS button";
								break;
							case 15:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "touch pad button";
								break;
							case 16:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "L3 button";
								break;
							case 17:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "R3 button";
								break;
							case 18:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "up button";
								break;
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "right button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "down button";
								break;
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "left button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Drums || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Guitar || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4SteeringWheel)
					{
						for (int l = 0; l < elementIdentifierCount; l++)
						{
							int id = elementIdentifiers[l].id;
							if (id != 19)
							{
								if (id == 20)
								{
									hardwareJoystickMap_InputManager.elementIdentifiers[l].name = "options button";
								}
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[l].name = "create button";
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4FlightStick)
					{
						for (int m = 0; m < elementIdentifierCount; m++)
						{
							int id = elementIdentifiers[m].id;
							if (id != 21)
							{
								if (id == 22)
								{
									hardwareJoystickMap_InputManager.elementIdentifiers[m].name = "options button";
								}
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[m].name = "create button";
							}
						}
					}
				}
				return hardwareJoystickMap_InputManager;
			}

			// Token: 0x06001F27 RID: 7975
			public abstract object DeepClone();

			// Token: 0x06001F28 RID: 7976
			internal abstract void CopyVars(HardwareJoystickMap.Platform destination);

			// Token: 0x0400118E RID: 4494
			[Tooltip("A description of this platform map. For reference only.")]
			public string description;
		}

		// Token: 0x020002BA RID: 698
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public abstract class Elements_Base : IDeepCloneable
		{
			// Token: 0x06001F32 RID: 7986 RVA: 0x00002FF9 File Offset: 0x000011F9
			internal virtual void CopyVars(HardwareJoystickMap.Elements_Base destination)
			{
			}

			// Token: 0x1700070B RID: 1803
			// (get) Token: 0x06001F33 RID: 7987
			public abstract int buttonCount { get; }

			// Token: 0x1700070C RID: 1804
			// (get) Token: 0x06001F34 RID: 7988
			public abstract int axisCount { get; }

			// Token: 0x06001F35 RID: 7989
			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			// Token: 0x06001F36 RID: 7990
			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			// Token: 0x06001F37 RID: 7991
			public abstract object DeepClone();
		}

		// Token: 0x020002BB RID: 699
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public abstract class MatchingCriteria_Base : IDeepCloneable
		{
			// Token: 0x1700070D RID: 1805
			// (get) Token: 0x06001F39 RID: 7993
			internal abstract bool hasData { get; }

			// Token: 0x1700070E RID: 1806
			// (get) Token: 0x06001F3A RID: 7994 RVA: 0x000182E3 File Offset: 0x000164E3
			internal virtual bool isAllowed
			{
				get
				{
					return !this.disabled;
				}
			}

			// Token: 0x06001F3B RID: 7995 RVA: 0x00083C24 File Offset: 0x00081E24
			internal virtual bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch)
			{
				bool flag;
				return !this.disabled && this.isAllowed && this.ElementCountsMatch(BridgedControllerHWInfo, out flag) && (string.IsNullOrEmpty(BridgedControllerHWInfo.definitionMatchTag) || BridgedControllerHWInfo.definitionMatchTag.Equals(this.tag, StringComparison.OrdinalIgnoreCase));
			}

			// Token: 0x1700070F RID: 1807
			// (get) Token: 0x06001F3C RID: 7996
			internal abstract int alternateElementCount { get; }

			// Token: 0x06001F3D RID: 7997
			internal abstract HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index);

			// Token: 0x06001F3E RID: 7998 RVA: 0x00083C78 File Offset: 0x00081E78
			internal virtual bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				alternateMatched = false;
				if (bridgedControllerHWInfo == null)
				{
					return false;
				}
				int alternateElementCount = this.alternateElementCount;
				for (int i = 0; i < alternateElementCount; i++)
				{
					HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base alternateElementCount2 = this.GetAlternateElementCount(i);
					if (alternateElementCount2 != null && alternateElementCount2.SzFaabwiwVxhtNCAlMSNVIkspaRo(bridgedControllerHWInfo))
					{
						alternateMatched = true;
						return true;
					}
				}
				return (this.axisCount < 0 || this.axisCount == bridgedControllerHWInfo.hardwareAxisCount) && (this.buttonCount < 0 || this.buttonCount == bridgedControllerHWInfo.hardwareButtonCount);
			}

			// Token: 0x06001F3F RID: 7999 RVA: 0x000182F0 File Offset: 0x000164F0
			internal virtual void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
			{
				destination.axisCount = this.axisCount;
				destination.buttonCount = this.buttonCount;
				destination.disabled = this.disabled;
				destination.tag = this.tag;
			}

			// Token: 0x06001F40 RID: 8000 RVA: 0x00018322 File Offset: 0x00016522
			internal static bool StringMatches(string searchIn, string searchFor, bool useRegex)
			{
				if (searchIn == null)
				{
					searchIn = string.Empty;
				}
				if (searchFor == null)
				{
					searchFor = string.Empty;
				}
				if (useRegex)
				{
					return Regex.IsMatch(searchIn, searchFor, RegexOptions.IgnoreCase);
				}
				return searchFor.Trim().Equals(searchIn.Trim(), StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x06001F41 RID: 8001
			public abstract object DeepClone();

			// Token: 0x04001195 RID: 4501
			[Tooltip("The number of axes reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of axes]")]
			public int axisCount;

			// Token: 0x04001196 RID: 4502
			[Tooltip("The number of buttons reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of buttons]")]
			public int buttonCount;

			// Token: 0x04001197 RID: 4503
			[Tooltip("If checked, this entire platform map will be skipped and will not match to any controller.")]
			public bool disabled;

			// Token: 0x04001198 RID: 4504
			[Tooltip("User-defined string. May have functionality on some input sources but not on others.")]
			public string tag;

			// Token: 0x020002BC RID: 700
			[Serializable]
			public class ElementCount_Base : IDeepCloneable
			{
				// Token: 0x06001F44 RID: 8004 RVA: 0x00083CEC File Offset: 0x00081EEC
				public virtual object DeepClone()
				{
					HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base elementCount_Base = new HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base();
					this.lIEfPuoiEXSCAiedHDGrZvHOsLxw(elementCount_Base);
					return elementCount_Base;
				}

				// Token: 0x06001F45 RID: 8005 RVA: 0x00018356 File Offset: 0x00016556
				internal virtual void lIEfPuoiEXSCAiedHDGrZvHOsLxw(HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base A_1)
				{
					if (A_1 == null)
					{
						return;
					}
					A_1.axisCount = this.axisCount;
					A_1.buttonCount = this.buttonCount;
				}

				// Token: 0x06001F46 RID: 8006 RVA: 0x00018374 File Offset: 0x00016574
				internal virtual bool SzFaabwiwVxhtNCAlMSNVIkspaRo(BridgedControllerHWInfo A_1)
				{
					return A_1 != null && (this.axisCount < 0 || this.axisCount == A_1.hardwareAxisCount) && (this.buttonCount < 0 || this.buttonCount == A_1.hardwareButtonCount);
				}

				// Token: 0x04001199 RID: 4505
				public int axisCount;

				// Token: 0x0400119A RID: 4506
				public int buttonCount;
			}
		}

		// Token: 0x020002BD RID: 701
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class CompoundElement : IDeepCloneable
		{
			// Token: 0x17000710 RID: 1808
			// (get) Token: 0x06001F47 RID: 8007 RVA: 0x000183AD File Offset: 0x000165AD
			public int elementCount
			{
				get
				{
					if (this.componentElementIdentifiers == null)
					{
						return 0;
					}
					return this.componentElementIdentifiers.Length;
				}
			}

			// Token: 0x06001F48 RID: 8008 RVA: 0x000183C1 File Offset: 0x000165C1
			public CompoundElement()
			{
				if (this.componentElementIdentifiers == null)
				{
					this.componentElementIdentifiers = new int[0];
				}
			}

			// Token: 0x06001F49 RID: 8009 RVA: 0x000183F0 File Offset: 0x000165F0
			public CompoundElement(HardwareJoystickMap.CompoundElement A_1)
			{
				this.ImportVars(A_1);
			}

			// Token: 0x06001F4A RID: 8010 RVA: 0x00018412 File Offset: 0x00016612
			public int GetComponentElementIdentifierId(int index)
			{
				if (index < 0 || index >= this.elementCount)
				{
					return -1;
				}
				return this.componentElementIdentifiers[index];
			}

			// Token: 0x06001F4B RID: 8011 RVA: 0x0001842B File Offset: 0x0001662B
			public virtual object DeepClone()
			{
				return new HardwareJoystickMap.CompoundElement(this);
			}

			// Token: 0x06001F4C RID: 8012 RVA: 0x00018433 File Offset: 0x00016633
			protected virtual void ImportVars(HardwareJoystickMap.CompoundElement source)
			{
				this.type = source.type;
				this.elementIdentifier = source.elementIdentifier;
				this.componentElementIdentifiers = ArrayTools.ShallowCopy<int>(source.componentElementIdentifiers);
			}

			// Token: 0x06001F4D RID: 8013 RVA: 0x00083D08 File Offset: 0x00081F08
			internal static void SortHatElementsClockwise(HardwareJoystickMap.CompoundElement element)
			{
				if (element == null)
				{
					return;
				}
				if (element.type != CompoundControllerElementType.Hat)
				{
					return;
				}
				if (element.componentElementIdentifiers == null)
				{
					return;
				}
				if (element.componentElementIdentifiers.Length != 8)
				{
					return;
				}
				int[] array = new int[]
				{
					element.componentElementIdentifiers[0],
					element.componentElementIdentifiers[4],
					element.componentElementIdentifiers[1],
					element.componentElementIdentifiers[5],
					element.componentElementIdentifiers[2],
					element.componentElementIdentifiers[6],
					element.componentElementIdentifiers[3],
					element.componentElementIdentifiers[7]
				};
				Array.Copy(array, element.componentElementIdentifiers, array.Length);
			}

			// Token: 0x0400119B RID: 4507
			public CompoundControllerElementType type;

			// Token: 0x0400119C RID: 4508
			public int elementIdentifier = -1;

			// Token: 0x0400119D RID: 4509
			public int[] componentElementIdentifiers = new int[0];
		}

		// Token: 0x020002BE RID: 702
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class VidPid
		{
			// Token: 0x0400119E RID: 4510
			public int vendorId;

			// Token: 0x0400119F RID: 4511
			public int productId;
		}

		// Token: 0x020002BF RID: 703
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class AxisCalibrationInfoEntry : IDeepCloneable
		{
			// Token: 0x06001F4F RID: 8015 RVA: 0x0001845E File Offset: 0x0001665E
			public AxisCalibrationInfoEntry(HardwareJoystickMap.AxisCalibrationInfoEntry A_1)
			{
				this.ImportVars(A_1);
			}

			// Token: 0x06001F50 RID: 8016 RVA: 0x0001846D File Offset: 0x0001666D
			public virtual object DeepClone()
			{
				return new HardwareJoystickMap.AxisCalibrationInfoEntry(this);
			}

			// Token: 0x06001F51 RID: 8017 RVA: 0x00018475 File Offset: 0x00016675
			protected virtual void ImportVars(HardwareJoystickMap.AxisCalibrationInfoEntry source)
			{
				this.key = source.key;
				this.calibration = MiscTools.DeepClone<AxisCalibrationInfo>(source.calibration);
			}

			// Token: 0x06001F52 RID: 8018 RVA: 0x00083DA8 File Offset: 0x00081FA8
			public static Dictionary<int, AxisCalibrationInfo> ToDictionary(HardwareJoystickMap.AxisCalibrationInfoEntry[] calibrations, bool deepClone)
			{
				if (calibrations == null)
				{
					return new Dictionary<int, AxisCalibrationInfo>();
				}
				Dictionary<int, AxisCalibrationInfo> dictionary = new Dictionary<int, AxisCalibrationInfo>();
				foreach (HardwareJoystickMap.AxisCalibrationInfoEntry axisCalibrationInfoEntry in calibrations)
				{
					if (axisCalibrationInfoEntry != null && axisCalibrationInfoEntry.calibration != null && Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
					{
						if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
						{
							Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
						}
						else if (deepClone)
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
						}
						else
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
						}
					}
				}
				return dictionary;
			}

			// Token: 0x040011A0 RID: 4512
			[SerializeField]
			internal AlternateAxisCalibrationType key;

			// Token: 0x040011A1 RID: 4513
			[SerializeField]
			internal AxisCalibrationInfo calibration;
		}

		// Token: 0x020002C0 RID: 704
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public abstract class Platform_RawOrDirectInput : HardwareJoystickMap.Platform
		{
			// Token: 0x17000711 RID: 1809
			// (get) Token: 0x06001F53 RID: 8019 RVA: 0x00018494 File Offset: 0x00016694
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x17000712 RID: 1810
			// (get) Token: 0x06001F54 RID: 8020 RVA: 0x000184C2 File Offset: 0x000166C2
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000713 RID: 1811
			// (get) Token: 0x06001F55 RID: 8021 RVA: 0x000184D9 File Offset: 0x000166D9
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x06001F56 RID: 8022
			internal abstract IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> IterateAxes();

			// Token: 0x06001F57 RID: 8023
			internal abstract IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> IterateButtons();

			// Token: 0x06001F58 RID: 8024 RVA: 0x00083E50 File Offset: 0x00082050
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_RawOrDirectInput platform_RawOrDirectInput = destination as HardwareJoystickMap.Platform_RawOrDirectInput;
				if (platform_RawOrDirectInput == null)
				{
					return;
				}
				platform_RawOrDirectInput.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria>(this.matchingCriteria);
			}

			// Token: 0x040011A2 RID: 4514
			public HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria matchingCriteria;

			// Token: 0x020002C1 RID: 705
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x17000714 RID: 1812
				// (get) Token: 0x06001F5A RID: 8026 RVA: 0x00018502 File Offset: 0x00016702
				internal override bool hasData
				{
					get
					{
						return !this.disabled && ((this.productGUID != null && this.productGUID.Length != 0) || (this.productName != null && this.productName.Length != 0));
					}
				}

				// Token: 0x17000715 RID: 1813
				// (get) Token: 0x06001F5B RID: 8027 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x06001F5C RID: 8028 RVA: 0x00083E7C File Offset: 0x0008207C
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!strictMatch)
					{
						return this.ProductNameMatches(bridgedControllerHWInfo);
					}
					if (PidVid.ArrayContains(this.productGUID, ref bridgedControllerHWInfo.hw_pidVid))
					{
						return !ArrayTools.Contains<PidVid>(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid) || (this.productName == null || this.productName.Length == 0) || this.ProductNameMatches(bridgedControllerHWInfo);
					}
					return this.ProductNameMatches(bridgedControllerHWInfo);
				}

				// Token: 0x17000716 RID: 1814
				// (get) Token: 0x06001F5D RID: 8029 RVA: 0x00018542 File Offset: 0x00016742
				internal override int alternateElementCount
				{
					get
					{
						if (this.alternateElementCounts == null)
						{
							return 0;
						}
						return this.alternateElementCounts.Length;
					}
				}

				// Token: 0x06001F5E RID: 8030 RVA: 0x00018556 File Offset: 0x00016756
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					if (this.alternateElementCounts == null || index < 0 || index >= this.alternateElementCounts.Length)
					{
						return null;
					}
					return this.alternateElementCounts[index];
				}

				// Token: 0x06001F5F RID: 8031 RVA: 0x00018579 File Offset: 0x00016779
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (alternateMatched || this.hatCount < 0 || bridgedControllerHWInfo.hardwareHatCount == this.hatCount);
				}

				// Token: 0x06001F60 RID: 8032 RVA: 0x00083F08 File Offset: 0x00082108
				private bool ProductNameMatches(BridgedControllerHWInfo controller)
				{
					if (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
					{
						return this.ProductNameMatches(controller.hw_productName) || this.ProductNameMatches(controller.hw_bluetoothDeviceName);
					}
					return this.ProductNameMatches(controller.hw_productName);
				}

				// Token: 0x06001F61 RID: 8033 RVA: 0x00083F58 File Offset: 0x00082158
				private bool ProductNameMatches(string name)
				{
					if (string.IsNullOrEmpty(name) || this.productName == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < this.productName.Length; i++)
					{
						if (this.productName[i] != null && !(this.productName[i] == string.Empty) && HardwareJoystickMap.MatchingCriteria_Base.StringMatches(searchIn, this.productName[i], this.productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001F62 RID: 8034 RVA: 0x00083FC8 File Offset: 0x000821C8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06001F63 RID: 8035 RVA: 0x00083FE4 File Offset: 0x000821E4
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy<string>(this.productGUID);
					matchingCriteria.productId = ArrayTools.ShallowCopy<int>(this.productId);
					matchingCriteria.deviceType = this.deviceType;
				}

				// Token: 0x040011A3 RID: 4515
				public int hatCount;

				// Token: 0x040011A4 RID: 4516
				public HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria.ElementCount[] alternateElementCounts;

				// Token: 0x040011A5 RID: 4517
				public bool productName_useRegex;

				// Token: 0x040011A6 RID: 4518
				public string[] productName;

				// Token: 0x040011A7 RID: 4519
				public string[] productGUID;

				// Token: 0x040011A8 RID: 4520
				public int[] productId;

				// Token: 0x040011A9 RID: 4521
				public HardwareJoystickMap.Platform_RawOrDirectInput.DeviceType deviceType;

				// Token: 0x020002C2 RID: 706
				[Serializable]
				public sealed class ElementCount : HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base
				{
					// Token: 0x06001F66 RID: 8038 RVA: 0x0008405C File Offset: 0x0008225C
					public override object DeepClone()
					{
						HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria.ElementCount elementCount = new HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria.ElementCount();
						this.lIEfPuoiEXSCAiedHDGrZvHOsLxw(elementCount);
						return elementCount;
					}

					// Token: 0x06001F67 RID: 8039 RVA: 0x00084078 File Offset: 0x00082278
					internal void xqfSzQlRYNSSpwktpgwiahErMHXQ(HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base A_1)
					{
						base.lIEfPuoiEXSCAiedHDGrZvHOsLxw(A_1);
						HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria.ElementCount elementCount = A_1 as HardwareJoystickMap.Platform_RawOrDirectInput.MatchingCriteria.ElementCount;
						if (elementCount == null)
						{
							return;
						}
						elementCount.hatCount = this.hatCount;
					}

					// Token: 0x06001F68 RID: 8040 RVA: 0x000185B6 File Offset: 0x000167B6
					internal bool MxPzdQtHovLiyVMdaRLsgJRsmBkH(BridgedControllerHWInfo A_1)
					{
						return base.SzFaabwiwVxhtNCAlMSNVIkspaRo(A_1) && (this.hatCount < 0 || this.hatCount == A_1.hardwareHatCount);
					}

					// Token: 0x040011AA RID: 4522
					public int hatCount;
				}
			}

			// Token: 0x020002C3 RID: 707
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Elements_Platform_Base : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x06001F69 RID: 8041
				internal abstract HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base GetAxis(int axisIndex);

				// Token: 0x17000717 RID: 1815
				// (get) Token: 0x06001F6A RID: 8042
				internal abstract IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> Axes { get; }

				// Token: 0x17000718 RID: 1816
				// (get) Token: 0x06001F6B RID: 8043
				internal abstract IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> Buttons { get; }
			}

			// Token: 0x020002C4 RID: 708
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				// Token: 0x06001F6D RID: 8045 RVA: 0x000840A4 File Offset: 0x000822A4
				public object DeepClone()
				{
					return new HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData
					{
						sourceType = this.sourceType,
						sourceAxis = this.sourceAxis,
						sourceButton = this.sourceButton,
						sourceOtherAxis = this.sourceOtherAxis,
						sourceAxisRange = this.sourceAxisRange,
						axisDeadZone = this.axisDeadZone,
						invert = this.invert,
						axisCalibrationType = this.axisCalibrationType,
						axisZero = this.axisZero,
						axisMin = this.axisMin,
						axisMax = this.axisMax
					};
				}

				// Token: 0x040011AB RID: 4523
				public int sourceType;

				// Token: 0x040011AC RID: 4524
				public int sourceAxis;

				// Token: 0x040011AD RID: 4525
				public int sourceButton;

				// Token: 0x040011AE RID: 4526
				public int sourceOtherAxis;

				// Token: 0x040011AF RID: 4527
				public AxisRange sourceAxisRange;

				// Token: 0x040011B0 RID: 4528
				public float axisDeadZone;

				// Token: 0x040011B1 RID: 4529
				public bool invert;

				// Token: 0x040011B2 RID: 4530
				public AxisCalibrationType axisCalibrationType;

				// Token: 0x040011B3 RID: 4531
				public float axisZero;

				// Token: 0x040011B4 RID: 4532
				public float axisMin;

				// Token: 0x040011B5 RID: 4533
				public float axisMax;
			}

			// Token: 0x020002C5 RID: 709
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x06001F6F RID: 8047
				public abstract object DeepClone();

				// Token: 0x06001F70 RID: 8048 RVA: 0x000185E4 File Offset: 0x000167E4
				protected void ImportVars(HardwareJoystickMap.Platform_RawOrDirectInput.Element source)
				{
					this.customCalculation = source.customCalculation;
					this.customCalculationSourceData = ArrayTools.DeepClone<HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData>(source.customCalculationSourceData);
				}

				// Token: 0x040011B6 RID: 4534
				public CustomCalculation customCalculation;

				// Token: 0x040011B7 RID: 4535
				public HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData;
			}

			// Token: 0x020002C6 RID: 710
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Button_Base : HardwareJoystickMap.Platform_RawOrDirectInput.Element
			{
				// Token: 0x06001F72 RID: 8050 RVA: 0x00018603 File Offset: 0x00016803
				public Button_Base()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				// Token: 0x06001F73 RID: 8051 RVA: 0x0008413C File Offset: 0x0008233C
				protected void ImportVars(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base source)
				{
					base.ImportVars(source);
					this.elementIdentifier = source.elementIdentifier;
					this.sourceType = source.sourceType;
					this.sourceButton = source.sourceButton;
					this.sourceAxis = source.sourceAxis;
					this.sourceAxisPole = source.sourceAxisPole;
					this.axisDeadZone = source.axisDeadZone;
					this.sourceHat = source.sourceHat;
					this.sourceHatType = source.sourceHatType;
					this.sourceHatDirection = source.sourceHatDirection;
					this.requireMultipleButtons = source.requireMultipleButtons;
					this.requiredButtons = ArrayTools.ShallowCopy<int>(source.requiredButtons);
					this.ignoreIfButtonsActive = source.ignoreIfButtonsActive;
					this.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<int>(source.ignoreIfButtonsActiveButtons);
					this.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(source.buttonInfo);
				}

				// Token: 0x040011B8 RID: 4536
				public int elementIdentifier;

				// Token: 0x040011B9 RID: 4537
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x040011BA RID: 4538
				public int sourceButton;

				// Token: 0x040011BB RID: 4539
				public int sourceAxis;

				// Token: 0x040011BC RID: 4540
				public Pole sourceAxisPole;

				// Token: 0x040011BD RID: 4541
				public float axisDeadZone;

				// Token: 0x040011BE RID: 4542
				public int sourceHat;

				// Token: 0x040011BF RID: 4543
				public HatType sourceHatType;

				// Token: 0x040011C0 RID: 4544
				public HatDirection sourceHatDirection;

				// Token: 0x040011C1 RID: 4545
				public bool requireMultipleButtons;

				// Token: 0x040011C2 RID: 4546
				public int[] requiredButtons;

				// Token: 0x040011C3 RID: 4547
				public bool ignoreIfButtonsActive;

				// Token: 0x040011C4 RID: 4548
				public int[] ignoreIfButtonsActiveButtons;

				// Token: 0x040011C5 RID: 4549
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x020002C7 RID: 711
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Axis_Base : HardwareJoystickMap.Platform_RawOrDirectInput.Element
			{
				// Token: 0x06001F74 RID: 8052 RVA: 0x00018612 File Offset: 0x00016812
				public Axis_Base()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				// Token: 0x06001F75 RID: 8053 RVA: 0x00084208 File Offset: 0x00082408
				protected void ImportVars(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base source)
				{
					base.ImportVars(source);
					this.elementIdentifier = source.elementIdentifier;
					this.sourceType = source.sourceType;
					this.sourceAxis = source.sourceAxis;
					this.sourceAxisRange = source.sourceAxisRange;
					this.invert = source.invert;
					this.axisDeadZone = source.axisDeadZone;
					this.calibrateAxis = source.calibrateAxis;
					this.axisZero = source.axisZero;
					this.axisMin = source.axisMin;
					this.axisMax = source.axisMax;
					this.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(source.axisInfo);
					this.sourceButton = source.sourceButton;
					this.buttonAxisContribution = source.buttonAxisContribution;
					this.sourceHat = source.sourceHat;
					this.sourceHatDirection = source.sourceHatDirection;
					this.sourceHatRange = source.sourceHatRange;
					this.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(source.alternateCalibrations);
				}

				// Token: 0x040011C6 RID: 4550
				public int elementIdentifier;

				// Token: 0x040011C7 RID: 4551
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x040011C8 RID: 4552
				public int sourceAxis;

				// Token: 0x040011C9 RID: 4553
				public AxisRange sourceAxisRange;

				// Token: 0x040011CA RID: 4554
				public bool invert;

				// Token: 0x040011CB RID: 4555
				public float axisDeadZone;

				// Token: 0x040011CC RID: 4556
				public bool calibrateAxis;

				// Token: 0x040011CD RID: 4557
				public float axisZero;

				// Token: 0x040011CE RID: 4558
				public float axisMin;

				// Token: 0x040011CF RID: 4559
				public float axisMax;

				// Token: 0x040011D0 RID: 4560
				public HardwareAxisInfo axisInfo;

				// Token: 0x040011D1 RID: 4561
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x040011D2 RID: 4562
				public int sourceButton;

				// Token: 0x040011D3 RID: 4563
				public Pole buttonAxisContribution;

				// Token: 0x040011D4 RID: 4564
				public int sourceHat;

				// Token: 0x040011D5 RID: 4565
				public AxisDirection sourceHatDirection;

				// Token: 0x040011D6 RID: 4566
				public AxisRange sourceHatRange;
			}

			// Token: 0x020002C8 RID: 712
			public enum DeviceType
			{
				// Token: 0x040011D8 RID: 4568
				Any,
				// Token: 0x040011D9 RID: 4569
				Device = 17,
				// Token: 0x040011DA RID: 4570
				Mouse,
				// Token: 0x040011DB RID: 4571
				Keyboard,
				// Token: 0x040011DC RID: 4572
				Joystick,
				// Token: 0x040011DD RID: 4573
				Gamepad,
				// Token: 0x040011DE RID: 4574
				Driving,
				// Token: 0x040011DF RID: 4575
				Flight,
				// Token: 0x040011E0 RID: 4576
				FirstPerson,
				// Token: 0x040011E1 RID: 4577
				ControlDevice,
				// Token: 0x040011E2 RID: 4578
				ScreenPointer,
				// Token: 0x040011E3 RID: 4579
				Remote,
				// Token: 0x040011E4 RID: 4580
				Supplemental
			}
		}

		// Token: 0x020002C9 RID: 713
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_DirectInput_Base : HardwareJoystickMap.Platform_RawOrDirectInput
		{
			// Token: 0x17000719 RID: 1817
			// (get) Token: 0x06001F76 RID: 8054 RVA: 0x000042E2 File Offset: 0x000024E2
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.WindowsDirectInput;
				}
			}

			// Token: 0x1700071A RID: 1818
			// (get) Token: 0x06001F77 RID: 8055 RVA: 0x00018621 File Offset: 0x00016821
			internal HardwareJoystickMap.Platform_DirectInput_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x1700071B RID: 1819
			// (get) Token: 0x06001F78 RID: 8056 RVA: 0x00018638 File Offset: 0x00016838
			internal HardwareJoystickMap.Platform_DirectInput_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x06001F79 RID: 8057 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x1700071C RID: 1820
			// (get) Token: 0x06001F7A RID: 8058 RVA: 0x0001864F File Offset: 0x0001684F
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x1700071D RID: 1821
			// (get) Token: 0x06001F7B RID: 8059 RVA: 0x00018666 File Offset: 0x00016866
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x06001F7C RID: 8060 RVA: 0x0001867D File Offset: 0x0001687D
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06001F7D RID: 8061 RVA: 0x000842F4 File Offset: 0x000824F4
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_DirectInput_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_DirectInput_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06001F7E RID: 8062 RVA: 0x00084394 File Offset: 0x00082594
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base button_Base in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button button = (HardwareJoystickMap.Platform_DirectInput_Base.Button)button_Base;
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base axis_Base in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Axis axis = (HardwareJoystickMap.Platform_DirectInput_Base.Axis)axis_Base;
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06001F7F RID: 8063 RVA: 0x00084458 File Offset: 0x00082658
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06001F80 RID: 8064 RVA: 0x00084570 File Offset: 0x00082770
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06001F81 RID: 8065 RVA: 0x00084638 File Offset: 0x00082838
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06001F82 RID: 8066 RVA: 0x000186A4 File Offset: 0x000168A4
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06001F83 RID: 8067 RVA: 0x000186BC File Offset: 0x000168BC
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06001F84 RID: 8068 RVA: 0x000186D8 File Offset: 0x000168D8
			internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num = this.elements.axes.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.axes[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x06001F85 RID: 8069 RVA: 0x000186E8 File Offset: 0x000168E8
			internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num = this.elements.buttons.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.buttons[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x1700071E RID: 1822
			// (get) Token: 0x06001F86 RID: 8070 RVA: 0x000186F8 File Offset: 0x000168F8
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06001F87 RID: 8071 RVA: 0x0008468C File Offset: 0x0008288C
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = new HardwareJoystickMap.Platform_DirectInput_Base();
				this.CopyVars(platform_DirectInput_Base);
				return platform_DirectInput_Base;
			}

			// Token: 0x06001F88 RID: 8072 RVA: 0x000846A8 File Offset: 0x000828A8
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = destination as HardwareJoystickMap.Platform_DirectInput_Base;
				if (platform_DirectInput_Base == null)
				{
					return;
				}
				platform_DirectInput_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_DirectInput_Base.Elements>(this.elements);
			}

			// Token: 0x040011E5 RID: 4581
			public HardwareJoystickMap.Platform_DirectInput_Base.Elements elements;

			// Token: 0x020002CA RID: 714
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Platform_RawOrDirectInput.Elements_Platform_Base
			{
				// Token: 0x1700071F RID: 1823
				// (get) Token: 0x06001F8A RID: 8074 RVA: 0x00018708 File Offset: 0x00016908
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x17000720 RID: 1824
				// (get) Token: 0x06001F8B RID: 8075 RVA: 0x0001871C File Offset: 0x0001691C
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06001F8C RID: 8076 RVA: 0x00018730 File Offset: 0x00016930
				internal override HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base GetAxis(int axisIndex)
				{
					if (this.axes == null || axisIndex < 0 || axisIndex >= this.axes.Length)
					{
						return null;
					}
					return this.axes[axisIndex];
				}

				// Token: 0x17000721 RID: 1825
				// (get) Token: 0x06001F8D RID: 8077 RVA: 0x00018753 File Offset: 0x00016953
				internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> Axes
				{
					get
					{
						if (this.axes == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.axes.Length; i = num + 1)
						{
							yield return this.axes[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x17000722 RID: 1826
				// (get) Token: 0x06001F8E RID: 8078 RVA: 0x00018763 File Offset: 0x00016963
				internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> Buttons
				{
					get
					{
						if (this.buttons == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.buttons.Length; i = num + 1)
						{
							yield return this.buttons[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x06001F8F RID: 8079 RVA: 0x000846D8 File Offset: 0x000828D8
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06001F90 RID: 8080 RVA: 0x0008473C File Offset: 0x0008293C
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							switch (this.axes[i].sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Axis:
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							case HardwareElementSourceTypeWithHat.Hat:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								throw new NotImplementedException();
							}
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06001F91 RID: 8081 RVA: 0x000847F8 File Offset: 0x000829F8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Elements elements = new HardwareJoystickMap.Platform_DirectInput_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06001F92 RID: 8082 RVA: 0x00084814 File Offset: 0x00082A14
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_DirectInput_Base.Elements elements = destination as HardwareJoystickMap.Platform_DirectInput_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_DirectInput_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_DirectInput_Base.Button>(this.buttons);
				}

				// Token: 0x040011E6 RID: 4582
				public HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes;

				// Token: 0x040011E7 RID: 4583
				public HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons;
			}

			// Token: 0x020002CD RID: 717
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Button : HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base
			{
				// Token: 0x06001FA5 RID: 8101 RVA: 0x000187D7 File Offset: 0x000169D7
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button button = new HardwareJoystickMap.Platform_DirectInput_Base.Button();
					button.ImportVars(this);
					return button;
				}

				// Token: 0x06001FA6 RID: 8102 RVA: 0x000187E5 File Offset: 0x000169E5
				private void ImportVars(HardwareJoystickMap.Platform_DirectInput_Base.Button source)
				{
					base.ImportVars(source);
				}
			}

			// Token: 0x020002CE RID: 718
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Axis : HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base
			{
				// Token: 0x06001FA8 RID: 8104 RVA: 0x000187F6 File Offset: 0x000169F6
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Axis axis = new HardwareJoystickMap.Platform_DirectInput_Base.Axis();
					axis.ImportVars(this);
					return axis;
				}

				// Token: 0x06001FA9 RID: 8105 RVA: 0x00018804 File Offset: 0x00016A04
				private void ImportVars(HardwareJoystickMap.Platform_DirectInput_Base.Axis source)
				{
					base.ImportVars(source);
				}
			}
		}

		// Token: 0x020002D1 RID: 721
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_DirectInput : HardwareJoystickMap.Platform_DirectInput_Base
		{
			// Token: 0x06001FBA RID: 8122 RVA: 0x00018861 File Offset: 0x00016A61
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06001FBB RID: 8123 RVA: 0x00084BC0 File Offset: 0x00082DC0
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06001FBC RID: 8124 RVA: 0x00084C1C File Offset: 0x00082E1C
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_DirectInput platform_DirectInput = new HardwareJoystickMap.Platform_DirectInput();
				this.CopyVars(platform_DirectInput);
				return platform_DirectInput;
			}

			// Token: 0x06001FBD RID: 8125 RVA: 0x00084C38 File Offset: 0x00082E38
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_DirectInput platform_DirectInput = destination as HardwareJoystickMap.Platform_DirectInput;
				if (platform_DirectInput == null)
				{
					return;
				}
				platform_DirectInput.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_DirectInput_Base>(this.variants);
			}

			// Token: 0x040011FE RID: 4606
			public HardwareJoystickMap.Platform_DirectInput_Base[] variants;
		}

		// Token: 0x020002D2 RID: 722
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_RawInput_Base : HardwareJoystickMap.Platform_RawOrDirectInput
		{
			// Token: 0x1700072B RID: 1835
			// (get) Token: 0x06001FBF RID: 8127 RVA: 0x0000550E File Offset: 0x0000370E
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.WindowsRawInput;
				}
			}

			// Token: 0x1700072C RID: 1836
			// (get) Token: 0x06001FC0 RID: 8128 RVA: 0x00018871 File Offset: 0x00016A71
			internal HardwareJoystickMap.Platform_RawInput_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x1700072D RID: 1837
			// (get) Token: 0x06001FC1 RID: 8129 RVA: 0x00018888 File Offset: 0x00016A88
			internal HardwareJoystickMap.Platform_RawInput_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x06001FC2 RID: 8130 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x1700072E RID: 1838
			// (get) Token: 0x06001FC3 RID: 8131 RVA: 0x0001889F File Offset: 0x00016A9F
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x1700072F RID: 1839
			// (get) Token: 0x06001FC4 RID: 8132 RVA: 0x000188B6 File Offset: 0x00016AB6
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x06001FC5 RID: 8133 RVA: 0x0001867D File Offset: 0x0001687D
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06001FC6 RID: 8134 RVA: 0x00084C68 File Offset: 0x00082E68
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_RawInput_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_RawInput_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06001FC7 RID: 8135 RVA: 0x00084D08 File Offset: 0x00082F08
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base button_Base in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button button = (HardwareJoystickMap.Platform_RawInput_Base.Button)button_Base;
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base axis_Base in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_RawInput_Base.Axis axis = (HardwareJoystickMap.Platform_RawInput_Base.Axis)axis_Base;
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06001FC8 RID: 8136 RVA: 0x00084DCC File Offset: 0x00082FCC
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06001FC9 RID: 8137 RVA: 0x00084EE4 File Offset: 0x000830E4
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06001FCA RID: 8138 RVA: 0x00084FAC File Offset: 0x000831AC
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06001FCB RID: 8139 RVA: 0x000188CD File Offset: 0x00016ACD
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06001FCC RID: 8140 RVA: 0x000188E5 File Offset: 0x00016AE5
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06001FCD RID: 8141 RVA: 0x00018901 File Offset: 0x00016B01
			internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num = this.elements.axes.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.axes[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x06001FCE RID: 8142 RVA: 0x00018911 File Offset: 0x00016B11
			internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num = this.elements.buttons.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.buttons[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x17000730 RID: 1840
			// (get) Token: 0x06001FCF RID: 8143 RVA: 0x00018921 File Offset: 0x00016B21
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06001FD0 RID: 8144 RVA: 0x00085000 File Offset: 0x00083200
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = new HardwareJoystickMap.Platform_RawInput_Base();
				this.CopyVars(platform_RawInput_Base);
				return platform_RawInput_Base;
			}

			// Token: 0x06001FD1 RID: 8145 RVA: 0x0008501C File Offset: 0x0008321C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = destination as HardwareJoystickMap.Platform_RawInput_Base;
				if (platform_RawInput_Base == null)
				{
					return;
				}
				platform_RawInput_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_RawInput_Base.Elements>(this.elements);
			}

			// Token: 0x040011FF RID: 4607
			public HardwareJoystickMap.Platform_RawInput_Base.Elements elements;

			// Token: 0x020002D3 RID: 723
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Platform_RawOrDirectInput.Elements_Platform_Base
			{
				// Token: 0x17000731 RID: 1841
				// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x00018929 File Offset: 0x00016B29
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x17000732 RID: 1842
				// (get) Token: 0x06001FD4 RID: 8148 RVA: 0x0001893D File Offset: 0x00016B3D
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06001FD5 RID: 8149 RVA: 0x00018951 File Offset: 0x00016B51
				internal override HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base GetAxis(int axisIndex)
				{
					if (this.axes == null || axisIndex < 0 || axisIndex >= this.axes.Length)
					{
						return null;
					}
					return this.axes[axisIndex];
				}

				// Token: 0x17000733 RID: 1843
				// (get) Token: 0x06001FD6 RID: 8150 RVA: 0x00018974 File Offset: 0x00016B74
				internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base> Axes
				{
					get
					{
						if (this.axes == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.axes.Length; i = num + 1)
						{
							yield return this.axes[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x17000734 RID: 1844
				// (get) Token: 0x06001FD7 RID: 8151 RVA: 0x00018984 File Offset: 0x00016B84
				internal override IEnumerable<HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base> Buttons
				{
					get
					{
						if (this.buttons == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.buttons.Length; i = num + 1)
						{
							yield return this.buttons[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x06001FD8 RID: 8152 RVA: 0x0008504C File Offset: 0x0008324C
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06001FD9 RID: 8153 RVA: 0x000850B0 File Offset: 0x000832B0
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceTypeWithHat sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Axis:
								break;
							case HardwareElementSourceTypeWithHat.Hat:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06001FDA RID: 8154 RVA: 0x00085174 File Offset: 0x00083374
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_RawInput_Base.Elements elements = new HardwareJoystickMap.Platform_RawInput_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06001FDB RID: 8155 RVA: 0x00085190 File Offset: 0x00083390
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_RawInput_Base.Elements elements = destination as HardwareJoystickMap.Platform_RawInput_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_RawInput_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_RawInput_Base.Button>(this.buttons);
				}

				// Token: 0x04001200 RID: 4608
				public HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes;

				// Token: 0x04001201 RID: 4609
				public HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons;
			}

			// Token: 0x020002D6 RID: 726
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Button : HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base
			{
				// Token: 0x06001FEE RID: 8174 RVA: 0x000189E8 File Offset: 0x00016BE8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button button = new HardwareJoystickMap.Platform_RawInput_Base.Button();
					button.ImportVars(this);
					return button;
				}

				// Token: 0x06001FEF RID: 8175 RVA: 0x000189F6 File Offset: 0x00016BF6
				private void ImportVars(HardwareJoystickMap.Platform_RawInput_Base.Button source)
				{
					base.ImportVars(source);
					this.sourceOtherAxis = source.sourceOtherAxis;
				}

				// Token: 0x0400120C RID: 4620
				public int sourceOtherAxis;
			}

			// Token: 0x020002D7 RID: 727
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Axis : HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base
			{
				// Token: 0x06001FF1 RID: 8177 RVA: 0x00018A0B File Offset: 0x00016C0B
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_RawInput_Base.Axis axis = new HardwareJoystickMap.Platform_RawInput_Base.Axis();
					axis.ImportVars(this);
					return axis;
				}

				// Token: 0x06001FF2 RID: 8178 RVA: 0x00018A19 File Offset: 0x00016C19
				private void ImportVars(HardwareJoystickMap.Platform_RawInput_Base.Axis source)
				{
					base.ImportVars(source);
					this.sourceOtherAxis = source.sourceOtherAxis;
				}

				// Token: 0x0400120D RID: 4621
				public int sourceOtherAxis;
			}
		}

		// Token: 0x020002DA RID: 730
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_RawInput : HardwareJoystickMap.Platform_RawInput_Base
		{
			// Token: 0x06002003 RID: 8195 RVA: 0x00018A82 File Offset: 0x00016C82
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002004 RID: 8196 RVA: 0x0008553C File Offset: 0x0008373C
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002005 RID: 8197 RVA: 0x00085598 File Offset: 0x00083798
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_RawInput platform_RawInput = new HardwareJoystickMap.Platform_RawInput();
				this.CopyVars(platform_RawInput);
				return platform_RawInput;
			}

			// Token: 0x06002006 RID: 8198 RVA: 0x000855B4 File Offset: 0x000837B4
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_RawInput platform_RawInput = destination as HardwareJoystickMap.Platform_RawInput;
				if (platform_RawInput == null)
				{
					return;
				}
				platform_RawInput.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_RawInput_Base>(this.variants);
			}

			// Token: 0x0400121A RID: 4634
			public HardwareJoystickMap.Platform_RawInput_Base[] variants;
		}

		// Token: 0x020002DB RID: 731
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_XInput_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x1700073D RID: 1853
			// (get) Token: 0x06002008 RID: 8200 RVA: 0x00018A92 File Offset: 0x00016C92
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x1700073E RID: 1854
			// (get) Token: 0x06002009 RID: 8201 RVA: 0x00018AA9 File Offset: 0x00016CA9
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x1700073F RID: 1855
			// (get) Token: 0x0600200A RID: 8202 RVA: 0x00018AC0 File Offset: 0x00016CC0
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.WindowsXInput;
				}
			}

			// Token: 0x17000740 RID: 1856
			// (get) Token: 0x0600200B RID: 8203 RVA: 0x00018AC3 File Offset: 0x00016CC3
			internal HardwareJoystickMap.Platform_XInput_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000741 RID: 1857
			// (get) Token: 0x0600200C RID: 8204 RVA: 0x00018ADA File Offset: 0x00016CDA
			internal HardwareJoystickMap.Platform_XInput_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x17000742 RID: 1858
			// (get) Token: 0x0600200D RID: 8205 RVA: 0x00018AF1 File Offset: 0x00016CF1
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x17000743 RID: 1859
			// (get) Token: 0x0600200E RID: 8206 RVA: 0x00018B1F File Offset: 0x00016D1F
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000744 RID: 1860
			// (get) Token: 0x0600200F RID: 8207 RVA: 0x00018B36 File Offset: 0x00016D36
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000745 RID: 1861
			// (get) Token: 0x06002010 RID: 8208 RVA: 0x00018B57 File Offset: 0x00016D57
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002011 RID: 8209 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002012 RID: 8210 RVA: 0x00018B5F File Offset: 0x00016D5F
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06002013 RID: 8211 RVA: 0x00018B86 File Offset: 0x00016D86
			internal IEnumerable<HardwareJoystickMap.Platform_XInput_Base.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002014 RID: 8212 RVA: 0x00018B96 File Offset: 0x00016D96
			internal IEnumerable<HardwareJoystickMap.Platform_XInput_Base.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002015 RID: 8213 RVA: 0x000855E4 File Offset: 0x000837E4
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_XInput_Base.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_XInput_Base.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002016 RID: 8214 RVA: 0x00085678 File Offset: 0x00083878
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_XInput_Base.Button button in this.IterateButtons())
				{
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_XInput_Base.Axis axis in this.IterateAxes())
				{
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06002017 RID: 8215 RVA: 0x00085730 File Offset: 0x00083930
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceType.Axis || axes_orig[i].sourceType == HardwareElementSourceType.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceType.Button)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002018 RID: 8216 RVA: 0x0008583C File Offset: 0x00083A3C
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceType.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceType.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceType.Button)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002019 RID: 8217 RVA: 0x000858F0 File Offset: 0x00083AF0
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x0600201A RID: 8218 RVA: 0x00018BA6 File Offset: 0x00016DA6
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x0600201B RID: 8219 RVA: 0x00018BBE File Offset: 0x00016DBE
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x0600201C RID: 8220 RVA: 0x00085944 File Offset: 0x00083B44
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_XInput_Base platform_XInput_Base = new HardwareJoystickMap.Platform_XInput_Base();
				this.CopyVars(platform_XInput_Base);
				return platform_XInput_Base;
			}

			// Token: 0x0600201D RID: 8221 RVA: 0x00085960 File Offset: 0x00083B60
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_XInput_Base platform_XInput_Base = destination as HardwareJoystickMap.Platform_XInput_Base;
				if (platform_XInput_Base == null)
				{
					return;
				}
				platform_XInput_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_XInput_Base.MatchingCriteria>(this.matchingCriteria);
				platform_XInput_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_XInput_Base.Elements>(this.elements);
			}

			// Token: 0x0400121B RID: 4635
			public HardwareJoystickMap.Platform_XInput_Base.MatchingCriteria matchingCriteria;

			// Token: 0x0400121C RID: 4636
			public HardwareJoystickMap.Platform_XInput_Base.Elements elements;

			// Token: 0x020002DC RID: 732
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x17000746 RID: 1862
				// (get) Token: 0x0600201F RID: 8223 RVA: 0x00018BDA File Offset: 0x00016DDA
				internal override bool hasData
				{
					get
					{
						return !this.disabled && this.subType.Length != 0;
					}
				}

				// Token: 0x17000747 RID: 1863
				// (get) Token: 0x06002020 RID: 8224 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x06002021 RID: 8225 RVA: 0x0008599C File Offset: 0x00083B9C
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (this.disabled)
					{
						return false;
					}
					if (!this.isAllowed)
					{
						return false;
					}
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					for (int i = 0; i < this.subType.Length; i++)
					{
						if (this.subType[i] == bridgedControllerHWInfo.hw_xInputSubType)
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x17000748 RID: 1864
				// (get) Token: 0x06002022 RID: 8226 RVA: 0x00003E2B File Offset: 0x0000202B
				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x06002023 RID: 8227 RVA: 0x000067FE File Offset: 0x000049FE
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				// Token: 0x06002024 RID: 8228 RVA: 0x00018BF2 File Offset: 0x00016DF2
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				// Token: 0x06002025 RID: 8229 RVA: 0x00085A00 File Offset: 0x00083C00
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XInput_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_XInput_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002026 RID: 8230 RVA: 0x00085A1C File Offset: 0x00083C1C
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XInput_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_XInput_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.subType = ArrayTools.ShallowCopy<XInputDeviceSubType>(this.subType);
				}

				// Token: 0x0400121D RID: 4637
				public XInputDeviceSubType[] subType;
			}

			// Token: 0x020002DD RID: 733
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x17000749 RID: 1865
				// (get) Token: 0x06002028 RID: 8232 RVA: 0x00018BFC File Offset: 0x00016DFC
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x1700074A RID: 1866
				// (get) Token: 0x06002029 RID: 8233 RVA: 0x00018C10 File Offset: 0x00016E10
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x0600202A RID: 8234 RVA: 0x00085A4C File Offset: 0x00083C4C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XInput_Base.Elements elements = new HardwareJoystickMap.Platform_XInput_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x0600202B RID: 8235 RVA: 0x00085A68 File Offset: 0x00083C68
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XInput_Base.Elements elements = destination as HardwareJoystickMap.Platform_XInput_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_XInput_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_XInput_Base.Button>(this.buttons);
				}

				// Token: 0x0600202C RID: 8236 RVA: 0x00085AAC File Offset: 0x00083CAC
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x0600202D RID: 8237 RVA: 0x00085B10 File Offset: 0x00083D10
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceType sourceType = this.axes[i].sourceType;
							if (sourceType == HardwareElementSourceType.Button)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == HardwareElementSourceType.Axis || sourceType == HardwareElementSourceType.Custom)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x0400121E RID: 4638
				public HardwareJoystickMap.Platform_XInput_Base.Axis[] axes;

				// Token: 0x0400121F RID: 4639
				public HardwareJoystickMap.Platform_XInput_Base.Button[] buttons;
			}

			// Token: 0x020002DE RID: 734
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x0600202F RID: 8239
				public abstract object DeepClone();

				// Token: 0x06002030 RID: 8240 RVA: 0x00018C24 File Offset: 0x00016E24
				internal virtual void CopyVars(HardwareJoystickMap.Platform_XInput_Base.Element destination)
				{
					destination.elementIdentifier = this.elementIdentifier;
					destination.sourceType = this.sourceType;
					destination.sourceButton = this.sourceButton;
					destination.sourceAxis = this.sourceAxis;
					destination.axisDeadZone = this.axisDeadZone;
				}

				// Token: 0x04001220 RID: 4640
				public int elementIdentifier;

				// Token: 0x04001221 RID: 4641
				public HardwareElementSourceType sourceType;

				// Token: 0x04001222 RID: 4642
				public XInputButton sourceButton;

				// Token: 0x04001223 RID: 4643
				public XInputAxis sourceAxis;

				// Token: 0x04001224 RID: 4644
				public float axisDeadZone;
			}

			// Token: 0x020002DF RID: 735
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Button : HardwareJoystickMap.Platform_XInput_Base.Element
			{
				// Token: 0x06002032 RID: 8242 RVA: 0x00018C62 File Offset: 0x00016E62
				public Button()
				{
					this.sourceType = HardwareElementSourceType.Button;
				}

				// Token: 0x06002033 RID: 8243 RVA: 0x00085B98 File Offset: 0x00083D98
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XInput_Base.Button button = new HardwareJoystickMap.Platform_XInput_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x06002034 RID: 8244 RVA: 0x00085BB4 File Offset: 0x00083DB4
				internal override void CopyVars(HardwareJoystickMap.Platform_XInput_Base.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XInput_Base.Button button = destination as HardwareJoystickMap.Platform_XInput_Base.Button;
					if (button == null)
					{
						return;
					}
					button.sourceAxisPole = this.sourceAxisPole;
					button.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(this.buttonInfo);
				}

				// Token: 0x04001225 RID: 4645
				public Pole sourceAxisPole;

				// Token: 0x04001226 RID: 4646
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x020002E0 RID: 736
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Axis : HardwareJoystickMap.Platform_XInput_Base.Element
			{
				// Token: 0x06002035 RID: 8245 RVA: 0x00018C71 File Offset: 0x00016E71
				public Axis()
				{
					this.sourceType = HardwareElementSourceType.Axis;
				}

				// Token: 0x06002036 RID: 8246 RVA: 0x00085BF0 File Offset: 0x00083DF0
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XInput_Base.Axis axis = new HardwareJoystickMap.Platform_XInput_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x06002037 RID: 8247 RVA: 0x00085C0C File Offset: 0x00083E0C
				internal override void CopyVars(HardwareJoystickMap.Platform_XInput_Base.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XInput_Base.Axis axis = destination as HardwareJoystickMap.Platform_XInput_Base.Axis;
					if (axis == null)
					{
						return;
					}
					axis.invert = this.invert;
					axis.buttonAxisContribution = this.buttonAxisContribution;
					axis.sourceAxisRange = this.sourceAxisRange;
					axis.calibrateAxis = this.calibrateAxis;
					axis.axisZero = this.axisZero;
					axis.axisMin = this.axisMin;
					axis.axisMax = this.axisMax;
					axis.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(this.axisInfo);
					axis.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(this.alternateCalibrations);
				}

				// Token: 0x04001227 RID: 4647
				public bool invert;

				// Token: 0x04001228 RID: 4648
				public Pole buttonAxisContribution;

				// Token: 0x04001229 RID: 4649
				public AxisRange sourceAxisRange;

				// Token: 0x0400122A RID: 4650
				public bool calibrateAxis;

				// Token: 0x0400122B RID: 4651
				public float axisZero;

				// Token: 0x0400122C RID: 4652
				public float axisMin;

				// Token: 0x0400122D RID: 4653
				public float axisMax;

				// Token: 0x0400122E RID: 4654
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x0400122F RID: 4655
				public HardwareAxisInfo axisInfo;
			}
		}

		// Token: 0x020002E3 RID: 739
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_XInput : HardwareJoystickMap.Platform_XInput_Base
		{
			// Token: 0x06002048 RID: 8264 RVA: 0x00018CD4 File Offset: 0x00016ED4
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002049 RID: 8265 RVA: 0x00085E64 File Offset: 0x00084064
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600204A RID: 8266 RVA: 0x00085EC0 File Offset: 0x000840C0
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_XInput platform_XInput = new HardwareJoystickMap.Platform_XInput();
				this.CopyVars(platform_XInput);
				return platform_XInput;
			}

			// Token: 0x0600204B RID: 8267 RVA: 0x00085EDC File Offset: 0x000840DC
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_XInput platform_XInput = destination as HardwareJoystickMap.Platform_XInput;
				if (platform_XInput == null)
				{
					return;
				}
				platform_XInput.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_XInput_Base>(this.variants);
			}

			// Token: 0x0400123A RID: 4666
			public HardwareJoystickMap.Platform_XInput_Base[] variants;
		}

		// Token: 0x020002E4 RID: 740
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_OSX_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x1700074F RID: 1871
			// (get) Token: 0x0600204D RID: 8269 RVA: 0x00018CE4 File Offset: 0x00016EE4
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000750 RID: 1872
			// (get) Token: 0x0600204E RID: 8270 RVA: 0x00018CFB File Offset: 0x00016EFB
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x17000751 RID: 1873
			// (get) Token: 0x0600204F RID: 8271 RVA: 0x000055D1 File Offset: 0x000037D1
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.OSXNative;
				}
			}

			// Token: 0x17000752 RID: 1874
			// (get) Token: 0x06002050 RID: 8272 RVA: 0x00018D12 File Offset: 0x00016F12
			internal HardwareJoystickMap.Platform_OSX_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x17000753 RID: 1875
			// (get) Token: 0x06002051 RID: 8273 RVA: 0x00018D29 File Offset: 0x00016F29
			internal HardwareJoystickMap.Platform_OSX_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000754 RID: 1876
			// (get) Token: 0x06002052 RID: 8274 RVA: 0x00018D40 File Offset: 0x00016F40
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x17000755 RID: 1877
			// (get) Token: 0x06002053 RID: 8275 RVA: 0x00018D6E File Offset: 0x00016F6E
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000756 RID: 1878
			// (get) Token: 0x06002054 RID: 8276 RVA: 0x00018D85 File Offset: 0x00016F85
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000757 RID: 1879
			// (get) Token: 0x06002055 RID: 8277 RVA: 0x00018DA6 File Offset: 0x00016FA6
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002056 RID: 8278 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002057 RID: 8279 RVA: 0x00018DAE File Offset: 0x00016FAE
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06002058 RID: 8280 RVA: 0x00018DD5 File Offset: 0x00016FD5
			internal IEnumerable<HardwareJoystickMap.Platform_OSX_Base.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002059 RID: 8281 RVA: 0x00018DE5 File Offset: 0x00016FE5
			internal IEnumerable<HardwareJoystickMap.Platform_OSX_Base.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x0600205A RID: 8282 RVA: 0x00085F0C File Offset: 0x0008410C
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_OSX_Base.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_OSX_Base.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600205B RID: 8283 RVA: 0x00085FA0 File Offset: 0x000841A0
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_OSX_Base.Button button in this.IterateButtons())
				{
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_OSX_Base.Axis axis in this.IterateAxes())
				{
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x0600205C RID: 8284 RVA: 0x00086058 File Offset: 0x00084258
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_OSX_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x0600205D RID: 8285 RVA: 0x00086170 File Offset: 0x00084370
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x0600205E RID: 8286 RVA: 0x00086238 File Offset: 0x00084438
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x0600205F RID: 8287 RVA: 0x00018DF5 File Offset: 0x00016FF5
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002060 RID: 8288 RVA: 0x00018E0D File Offset: 0x0001700D
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002061 RID: 8289 RVA: 0x0008628C File Offset: 0x0008448C
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_OSX_Base platform_OSX_Base = new HardwareJoystickMap.Platform_OSX_Base();
				this.CopyVars(platform_OSX_Base);
				return platform_OSX_Base;
			}

			// Token: 0x06002062 RID: 8290 RVA: 0x000862A8 File Offset: 0x000844A8
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_OSX_Base platform_OSX_Base = destination as HardwareJoystickMap.Platform_OSX_Base;
				if (platform_OSX_Base == null)
				{
					return;
				}
				platform_OSX_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria>(this.matchingCriteria);
				platform_OSX_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_OSX_Base.Elements>(this.elements);
			}

			// Token: 0x0400123B RID: 4667
			public HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria matchingCriteria;

			// Token: 0x0400123C RID: 4668
			public HardwareJoystickMap.Platform_OSX_Base.Elements elements;

			// Token: 0x020002E5 RID: 741
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x17000758 RID: 1880
				// (get) Token: 0x06002064 RID: 8292 RVA: 0x000862E4 File Offset: 0x000844E4
				internal override bool hasData
				{
					get
					{
						return !this.disabled && ((this.productName != null && this.productName.Length != 0) || (this.productId != null && this.productId.Length != 0 && this.vendorId != null && this.vendorId.Length != 0));
					}
				}

				// Token: 0x17000759 RID: 1881
				// (get) Token: 0x06002065 RID: 8293 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x06002066 RID: 8294 RVA: 0x00086334 File Offset: 0x00084534
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!strictMatch)
					{
						string text = (bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName;
						text = text.Trim();
						return this.ProductNameMatches(text);
					}
					bool flag = false;
					for (int i = 0; i < this.vendorId.Length; i++)
					{
						if (this.vendorId[i] == bridgedControllerHWInfo.hw_vendorId && i < this.productId.Length && this.productId[i] == bridgedControllerHWInfo.hw_productId)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						return false;
					}
					if (ArrayTools.Contains<int>(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
					{
						string name = (bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName;
						if (!this.ProductNameMatches(name))
						{
							return false;
						}
					}
					return true;
				}

				// Token: 0x1700075A RID: 1882
				// (get) Token: 0x06002067 RID: 8295 RVA: 0x00018E29 File Offset: 0x00017029
				internal override int alternateElementCount
				{
					get
					{
						if (this.alternateElementCounts == null)
						{
							return 0;
						}
						return this.alternateElementCounts.Length;
					}
				}

				// Token: 0x06002068 RID: 8296 RVA: 0x00018E3D File Offset: 0x0001703D
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					if (this.alternateElementCounts == null || index < 0 || index >= this.alternateElementCounts.Length)
					{
						return null;
					}
					return this.alternateElementCounts[index];
				}

				// Token: 0x06002069 RID: 8297 RVA: 0x00018E60 File Offset: 0x00017060
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (alternateMatched || this.hatCount < 0 || bridgedControllerHWInfo.hardwareHatCount == this.hatCount);
				}

				// Token: 0x0600206A RID: 8298 RVA: 0x00086410 File Offset: 0x00084610
				private bool ProductNameMatches(string name)
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						string text = (this.productName[i] == null) ? string.Empty : this.productName[i];
						text = text.Trim();
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(name, text, this.productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600206B RID: 8299 RVA: 0x00086470 File Offset: 0x00084670
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x0600206C RID: 8300 RVA: 0x0008648C File Offset: 0x0008468C
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy<string>(this.manufacturer);
					matchingCriteria.productId = ArrayTools.ShallowCopy<int>(this.productId);
					matchingCriteria.vendorId = ArrayTools.ShallowCopy<int>(this.vendorId);
				}

				// Token: 0x0400123D RID: 4669
				public int hatCount;

				// Token: 0x0400123E RID: 4670
				public HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria.ElementCount[] alternateElementCounts;

				// Token: 0x0400123F RID: 4671
				public bool productName_useRegex;

				// Token: 0x04001240 RID: 4672
				public string[] productName;

				// Token: 0x04001241 RID: 4673
				public string[] manufacturer;

				// Token: 0x04001242 RID: 4674
				public int[] productId;

				// Token: 0x04001243 RID: 4675
				public int[] vendorId;

				// Token: 0x020002E6 RID: 742
				[Serializable]
				public sealed class ElementCount : HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base
				{
					// Token: 0x0600206F RID: 8303 RVA: 0x00086508 File Offset: 0x00084708
					public override object DeepClone()
					{
						HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria.ElementCount elementCount = new HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria.ElementCount();
						this.lIEfPuoiEXSCAiedHDGrZvHOsLxw(elementCount);
						return elementCount;
					}

					// Token: 0x06002070 RID: 8304 RVA: 0x00086524 File Offset: 0x00084724
					internal void rcXwajhfhtBZOADbrIkKvWNESKOx(HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base A_1)
					{
						base.lIEfPuoiEXSCAiedHDGrZvHOsLxw(A_1);
						HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria.ElementCount elementCount = A_1 as HardwareJoystickMap.Platform_OSX_Base.MatchingCriteria.ElementCount;
						if (elementCount == null)
						{
							return;
						}
						elementCount.hatCount = this.hatCount;
					}

					// Token: 0x06002071 RID: 8305 RVA: 0x00018E8D File Offset: 0x0001708D
					internal bool RNzfJlXbFpkeWEucXXkNzkOclpaD(BridgedControllerHWInfo A_1)
					{
						return base.SzFaabwiwVxhtNCAlMSNVIkspaRo(A_1) && (this.hatCount < 0 || this.hatCount == A_1.hardwareHatCount);
					}

					// Token: 0x04001244 RID: 4676
					public int hatCount;
				}
			}

			// Token: 0x020002E7 RID: 743
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x1700075B RID: 1883
				// (get) Token: 0x06002072 RID: 8306 RVA: 0x00018EB3 File Offset: 0x000170B3
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x1700075C RID: 1884
				// (get) Token: 0x06002073 RID: 8307 RVA: 0x00018EC7 File Offset: 0x000170C7
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06002074 RID: 8308 RVA: 0x00018EDB File Offset: 0x000170DB
				public IEnumerable<HardwareJoystickMap.Platform_OSX_Base.Axis> IterateAxes()
				{
					if (this.axes == null)
					{
						yield break;
					}
					foreach (HardwareJoystickMap.Platform_OSX_Base.Axis axis in this.axes)
					{
						yield return axis;
					}
					HardwareJoystickMap.Platform_OSX_Base.Axis[] array = null;
					yield break;
				}

				// Token: 0x06002075 RID: 8309 RVA: 0x00018EEB File Offset: 0x000170EB
				public IEnumerable<HardwareJoystickMap.Platform_OSX_Base.Button> IterateButtons()
				{
					if (this.buttons == null)
					{
						yield break;
					}
					foreach (HardwareJoystickMap.Platform_OSX_Base.Button button in this.buttons)
					{
						yield return button;
					}
					HardwareJoystickMap.Platform_OSX_Base.Button[] array = null;
					yield break;
				}

				// Token: 0x06002076 RID: 8310 RVA: 0x00086550 File Offset: 0x00084750
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_OSX_Base.Elements elements = new HardwareJoystickMap.Platform_OSX_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002077 RID: 8311 RVA: 0x0008656C File Offset: 0x0008476C
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_OSX_Base.Elements elements = destination as HardwareJoystickMap.Platform_OSX_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_OSX_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_OSX_Base.Button>(this.buttons);
				}

				// Token: 0x06002078 RID: 8312 RVA: 0x000865B0 File Offset: 0x000847B0
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002079 RID: 8313 RVA: 0x00086614 File Offset: 0x00084814
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceTypeWithHat sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Axis:
								break;
							case HardwareElementSourceTypeWithHat.Hat:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x04001245 RID: 4677
				public HardwareJoystickMap.Platform_OSX_Base.Axis[] axes;

				// Token: 0x04001246 RID: 4678
				public HardwareJoystickMap.Platform_OSX_Base.Button[] buttons;
			}

			// Token: 0x020002EA RID: 746
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x0600208B RID: 8331
				public abstract object DeepClone();
			}

			// Token: 0x020002EB RID: 747
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Button : HardwareJoystickMap.Platform_OSX_Base.Element
			{
				// Token: 0x0600208D RID: 8333 RVA: 0x00018F4F File Offset: 0x0001714F
				public Button()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				// Token: 0x0600208E RID: 8334 RVA: 0x00086890 File Offset: 0x00084A90
				public override object DeepClone()
				{
					return new HardwareJoystickMap.Platform_OSX_Base.Button
					{
						elementIdentifier = this.elementIdentifier,
						sourceType = this.sourceType,
						sourceButton = this.sourceButton,
						sourceStick = this.sourceStick,
						sourceAxis = this.sourceAxis,
						sourceOtherAxis = this.sourceOtherAxis,
						sourceAxisPole = this.sourceAxisPole,
						axisDeadZone = this.axisDeadZone,
						sourceHat = this.sourceHat,
						sourceHatType = this.sourceHatType,
						sourceHatDirection = this.sourceHatDirection,
						requireMultipleButtons = this.requireMultipleButtons,
						requiredButtons = ArrayTools.ShallowCopy<int>(this.requiredButtons),
						ignoreIfButtonsActive = this.ignoreIfButtonsActive,
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<int>(this.ignoreIfButtonsActiveButtons),
						buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(this.buttonInfo)
					};
				}

				// Token: 0x04001253 RID: 4691
				public int elementIdentifier;

				// Token: 0x04001254 RID: 4692
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x04001255 RID: 4693
				public int sourceButton;

				// Token: 0x04001256 RID: 4694
				public int sourceStick;

				// Token: 0x04001257 RID: 4695
				public OSXAxis sourceAxis;

				// Token: 0x04001258 RID: 4696
				public int sourceOtherAxis;

				// Token: 0x04001259 RID: 4697
				public Pole sourceAxisPole;

				// Token: 0x0400125A RID: 4698
				public float axisDeadZone;

				// Token: 0x0400125B RID: 4699
				public int sourceHat;

				// Token: 0x0400125C RID: 4700
				public HatType sourceHatType;

				// Token: 0x0400125D RID: 4701
				public HatDirection sourceHatDirection;

				// Token: 0x0400125E RID: 4702
				public bool requireMultipleButtons;

				// Token: 0x0400125F RID: 4703
				public int[] requiredButtons;

				// Token: 0x04001260 RID: 4704
				public bool ignoreIfButtonsActive;

				// Token: 0x04001261 RID: 4705
				public int[] ignoreIfButtonsActiveButtons;

				// Token: 0x04001262 RID: 4706
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x020002EC RID: 748
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Axis : HardwareJoystickMap.Platform_OSX_Base.Element
			{
				// Token: 0x0600208F RID: 8335 RVA: 0x00018F5E File Offset: 0x0001715E
				public Axis()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Axis;
					this.axisZero = 0f;
					this.axisMin = -1f;
					this.axisMax = 1f;
				}

				// Token: 0x06002090 RID: 8336 RVA: 0x00086974 File Offset: 0x00084B74
				public override object DeepClone()
				{
					return new HardwareJoystickMap.Platform_OSX_Base.Axis
					{
						elementIdentifier = this.elementIdentifier,
						sourceType = this.sourceType,
						sourceStick = this.sourceStick,
						sourceAxis = this.sourceAxis,
						sourceOtherAxis = this.sourceOtherAxis,
						sourceAxisRange = this.sourceAxisRange,
						invert = this.invert,
						axisDeadZone = this.axisDeadZone,
						calibrateAxis = this.calibrateAxis,
						axisZero = this.axisZero,
						axisMin = this.axisMin,
						axisMax = this.axisMax,
						axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(this.axisInfo),
						sourceButton = this.sourceButton,
						buttonAxisContribution = this.buttonAxisContribution,
						sourceHat = this.sourceHat,
						sourceHatDirection = this.sourceHatDirection,
						sourceHatRange = this.sourceHatRange,
						alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(this.alternateCalibrations)
					};
				}

				// Token: 0x04001263 RID: 4707
				public int elementIdentifier;

				// Token: 0x04001264 RID: 4708
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x04001265 RID: 4709
				public int sourceStick;

				// Token: 0x04001266 RID: 4710
				public OSXAxis sourceAxis;

				// Token: 0x04001267 RID: 4711
				public int sourceOtherAxis;

				// Token: 0x04001268 RID: 4712
				public AxisRange sourceAxisRange;

				// Token: 0x04001269 RID: 4713
				public bool invert;

				// Token: 0x0400126A RID: 4714
				public float axisDeadZone;

				// Token: 0x0400126B RID: 4715
				public bool calibrateAxis;

				// Token: 0x0400126C RID: 4716
				public float axisZero;

				// Token: 0x0400126D RID: 4717
				public float axisMin;

				// Token: 0x0400126E RID: 4718
				public float axisMax;

				// Token: 0x0400126F RID: 4719
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x04001270 RID: 4720
				public HardwareAxisInfo axisInfo;

				// Token: 0x04001271 RID: 4721
				public int sourceButton;

				// Token: 0x04001272 RID: 4722
				public Pole buttonAxisContribution;

				// Token: 0x04001273 RID: 4723
				public int sourceHat;

				// Token: 0x04001274 RID: 4724
				public AxisDirection sourceHatDirection;

				// Token: 0x04001275 RID: 4725
				public AxisRange sourceHatRange;
			}
		}

		// Token: 0x020002EF RID: 751
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_OSX : HardwareJoystickMap.Platform_OSX_Base
		{
			// Token: 0x060020A1 RID: 8353 RVA: 0x00018FE2 File Offset: 0x000171E2
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060020A2 RID: 8354 RVA: 0x00086C34 File Offset: 0x00084E34
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060020A3 RID: 8355 RVA: 0x00086C90 File Offset: 0x00084E90
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_OSX platform_OSX = new HardwareJoystickMap.Platform_OSX();
				this.CopyVars(platform_OSX);
				return platform_OSX;
			}

			// Token: 0x060020A4 RID: 8356 RVA: 0x00086CAC File Offset: 0x00084EAC
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_OSX platform_OSX = destination as HardwareJoystickMap.Platform_OSX;
				if (platform_OSX == null)
				{
					return;
				}
				platform_OSX.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_OSX_Base>(this.variants);
			}

			// Token: 0x04001280 RID: 4736
			public HardwareJoystickMap.Platform_OSX_Base[] variants;
		}

		// Token: 0x020002F0 RID: 752
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_Linux_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x17000765 RID: 1893
			// (get) Token: 0x060020A6 RID: 8358 RVA: 0x00018100 File Offset: 0x00016300
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.LinuxNative;
				}
			}

			// Token: 0x17000766 RID: 1894
			// (get) Token: 0x060020A7 RID: 8359 RVA: 0x00018FF2 File Offset: 0x000171F2
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x17000767 RID: 1895
			// (get) Token: 0x060020A8 RID: 8360 RVA: 0x00019020 File Offset: 0x00017220
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000768 RID: 1896
			// (get) Token: 0x060020A9 RID: 8361 RVA: 0x00019037 File Offset: 0x00017237
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000769 RID: 1897
			// (get) Token: 0x060020AA RID: 8362 RVA: 0x00019058 File Offset: 0x00017258
			internal HardwareJoystickMap.Platform_Linux_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x1700076A RID: 1898
			// (get) Token: 0x060020AB RID: 8363 RVA: 0x0001906F File Offset: 0x0001726F
			internal HardwareJoystickMap.Platform_Linux_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x060020AC RID: 8364 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x060020AD RID: 8365 RVA: 0x00019086 File Offset: 0x00017286
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x1700076B RID: 1899
			// (get) Token: 0x060020AE RID: 8366 RVA: 0x000190AD File Offset: 0x000172AD
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x1700076C RID: 1900
			// (get) Token: 0x060020AF RID: 8367 RVA: 0x000190C4 File Offset: 0x000172C4
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x060020B0 RID: 8368 RVA: 0x00086CDC File Offset: 0x00084EDC
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Linux_Base.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Linux_Base.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060020B1 RID: 8369 RVA: 0x00086D70 File Offset: 0x00084F70
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Linux_Base.Button button in this.IterateButtons())
				{
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Linux_Base.Axis axis in this.IterateAxes())
				{
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x060020B2 RID: 8370 RVA: 0x00086E28 File Offset: 0x00085028
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_Linux_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x060020B3 RID: 8371 RVA: 0x00086F40 File Offset: 0x00085140
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x060020B4 RID: 8372 RVA: 0x00087008 File Offset: 0x00085208
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x060020B5 RID: 8373 RVA: 0x000190DB File Offset: 0x000172DB
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x060020B6 RID: 8374 RVA: 0x000190F3 File Offset: 0x000172F3
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x060020B7 RID: 8375 RVA: 0x0001910F File Offset: 0x0001730F
			internal IEnumerable<HardwareJoystickMap.Platform_Linux_Base.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num = this.elements.axes.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.axes[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x060020B8 RID: 8376 RVA: 0x0001911F File Offset: 0x0001731F
			internal IEnumerable<HardwareJoystickMap.Platform_Linux_Base.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num = this.elements.buttons.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.buttons[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x1700076D RID: 1901
			// (get) Token: 0x060020B9 RID: 8377 RVA: 0x0001912F File Offset: 0x0001732F
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x060020BA RID: 8378 RVA: 0x0008705C File Offset: 0x0008525C
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_Linux_Base platform_Linux_Base = new HardwareJoystickMap.Platform_Linux_Base();
				this.CopyVars(platform_Linux_Base);
				return platform_Linux_Base;
			}

			// Token: 0x060020BB RID: 8379 RVA: 0x00087078 File Offset: 0x00085278
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_Linux_Base platform_Linux_Base = destination as HardwareJoystickMap.Platform_Linux_Base;
				if (platform_Linux_Base == null)
				{
					return;
				}
				platform_Linux_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_Linux_Base.Elements>(this.elements);
			}

			// Token: 0x04001281 RID: 4737
			public HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria matchingCriteria;

			// Token: 0x04001282 RID: 4738
			public HardwareJoystickMap.Platform_Linux_Base.Elements elements;

			// Token: 0x020002F1 RID: 753
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x1700076E RID: 1902
				// (get) Token: 0x060020BD RID: 8381 RVA: 0x00019137 File Offset: 0x00017337
				internal override bool hasData
				{
					get
					{
						return !this.disabled && ((this.productGUID != null && this.productGUID.Length != 0) || (this.productName != null && this.productName.Length != 0));
					}
				}

				// Token: 0x1700076F RID: 1903
				// (get) Token: 0x060020BE RID: 8382 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x060020BF RID: 8383 RVA: 0x000870A4 File Offset: 0x000852A4
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(this.productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains<PidVid>(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (this.productName == null || this.productName.Length == 0)
							{
								return true;
							}
						}
						return this.AnyNameMatches(bridgedControllerHWInfo);
					}
					return this.AnyNameMatches(bridgedControllerHWInfo);
				}

				// Token: 0x17000770 RID: 1904
				// (get) Token: 0x060020C0 RID: 8384 RVA: 0x0001916A File Offset: 0x0001736A
				internal override int alternateElementCount
				{
					get
					{
						if (this.alternateElementCounts == null)
						{
							return 0;
						}
						return this.alternateElementCounts.Length;
					}
				}

				// Token: 0x060020C1 RID: 8385 RVA: 0x0001917E File Offset: 0x0001737E
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					if (this.alternateElementCounts == null || index < 0 || index >= this.alternateElementCounts.Length)
					{
						return null;
					}
					return this.alternateElementCounts[index];
				}

				// Token: 0x060020C2 RID: 8386 RVA: 0x000191A1 File Offset: 0x000173A1
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (alternateMatched || this.hatCount < 0 || bridgedControllerHWInfo.hardwareHatCount == this.hatCount);
				}

				// Token: 0x060020C3 RID: 8387 RVA: 0x000191CE File Offset: 0x000173CE
				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return this.NameMatches(bridgedControllerHWInfo.hw_productName, this.productName, this.productName_useRegex) || this.NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, this.systemName, this.systemName_useRegex);
				}

				// Token: 0x060020C4 RID: 8388 RVA: 0x00087128 File Offset: 0x00085328
				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && HardwareJoystickMap.MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x060020C5 RID: 8389 RVA: 0x00087170 File Offset: 0x00085370
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x060020C6 RID: 8390 RVA: 0x0008718C File Offset: 0x0008538C
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.manufacturer_useRegex = this.manufacturer_useRegex;
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.systemName_useRegex = this.systemName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy<string>(this.manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.systemName = ArrayTools.ShallowCopy<string>(this.systemName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy<string>(this.productGUID);
				}

				// Token: 0x04001283 RID: 4739
				public int hatCount;

				// Token: 0x04001284 RID: 4740
				public HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria.ElementCount[] alternateElementCounts;

				// Token: 0x04001285 RID: 4741
				public bool manufacturer_useRegex;

				// Token: 0x04001286 RID: 4742
				public bool productName_useRegex;

				// Token: 0x04001287 RID: 4743
				public bool systemName_useRegex;

				// Token: 0x04001288 RID: 4744
				public string[] manufacturer;

				// Token: 0x04001289 RID: 4745
				public string[] productName;

				// Token: 0x0400128A RID: 4746
				public string[] systemName;

				// Token: 0x0400128B RID: 4747
				public string[] productGUID;

				// Token: 0x020002F2 RID: 754
				[Serializable]
				public sealed class ElementCount : HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base
				{
					// Token: 0x060020C9 RID: 8393 RVA: 0x00087220 File Offset: 0x00085420
					public override object DeepClone()
					{
						HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria.ElementCount elementCount = new HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria.ElementCount();
						this.lIEfPuoiEXSCAiedHDGrZvHOsLxw(elementCount);
						return elementCount;
					}

					// Token: 0x060020CA RID: 8394 RVA: 0x0008723C File Offset: 0x0008543C
					internal void KWZQivYbFqIVwCXSLIetKwIltdtHA(HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base A_1)
					{
						base.lIEfPuoiEXSCAiedHDGrZvHOsLxw(A_1);
						HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria.ElementCount elementCount = A_1 as HardwareJoystickMap.Platform_Linux_Base.MatchingCriteria.ElementCount;
						if (elementCount == null)
						{
							return;
						}
						elementCount.hatCount = this.hatCount;
					}

					// Token: 0x060020CB RID: 8395 RVA: 0x00019209 File Offset: 0x00017409
					internal bool KyJXMyvjSbiKjwWnkgSRIJvMMHgS(BridgedControllerHWInfo A_1)
					{
						return base.SzFaabwiwVxhtNCAlMSNVIkspaRo(A_1) && (this.hatCount < 0 || this.hatCount == A_1.hardwareHatCount);
					}

					// Token: 0x0400128C RID: 4748
					public int hatCount;
				}
			}

			// Token: 0x020002F3 RID: 755
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x17000771 RID: 1905
				// (get) Token: 0x060020CC RID: 8396 RVA: 0x0001922F File Offset: 0x0001742F
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x17000772 RID: 1906
				// (get) Token: 0x060020CD RID: 8397 RVA: 0x00019243 File Offset: 0x00017443
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x060020CE RID: 8398 RVA: 0x00019257 File Offset: 0x00017457
				internal HardwareJoystickMap.Platform_Linux_Base.Axis GetAxis(int axisIndex)
				{
					if (this.axes == null || axisIndex < 0 || axisIndex >= this.axes.Length)
					{
						return null;
					}
					return this.axes[axisIndex];
				}

				// Token: 0x17000773 RID: 1907
				// (get) Token: 0x060020CF RID: 8399 RVA: 0x0001927A File Offset: 0x0001747A
				internal IEnumerable<HardwareJoystickMap.Platform_Linux_Base.Axis> Axes
				{
					get
					{
						if (this.axes == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.axes.Length; i = num + 1)
						{
							yield return this.axes[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x17000774 RID: 1908
				// (get) Token: 0x060020D0 RID: 8400 RVA: 0x0001928A File Offset: 0x0001748A
				internal IEnumerable<HardwareJoystickMap.Platform_Linux_Base.Button> Buttons
				{
					get
					{
						if (this.buttons == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.buttons.Length; i = num + 1)
						{
							yield return this.buttons[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x060020D1 RID: 8401 RVA: 0x00087268 File Offset: 0x00085468
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x060020D2 RID: 8402 RVA: 0x000872CC File Offset: 0x000854CC
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceTypeWithHat sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Axis:
								break;
							case HardwareElementSourceTypeWithHat.Hat:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x060020D3 RID: 8403 RVA: 0x00087390 File Offset: 0x00085590
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Linux_Base.Elements elements = new HardwareJoystickMap.Platform_Linux_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x060020D4 RID: 8404 RVA: 0x000873AC File Offset: 0x000855AC
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Linux_Base.Elements elements = destination as HardwareJoystickMap.Platform_Linux_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_Linux_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_Linux_Base.Button>(this.buttons);
				}

				// Token: 0x0400128D RID: 4749
				public HardwareJoystickMap.Platform_Linux_Base.Axis[] axes;

				// Token: 0x0400128E RID: 4750
				public HardwareJoystickMap.Platform_Linux_Base.Button[] buttons;
			}

			// Token: 0x020002F6 RID: 758
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x060020E6 RID: 8422
				public abstract object DeepClone();

				// Token: 0x060020E7 RID: 8423 RVA: 0x00002FF9 File Offset: 0x000011F9
				protected virtual void ImportVars(HardwareJoystickMap.Platform_Linux_Base.Element source)
				{
				}
			}

			// Token: 0x020002F7 RID: 759
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class Button : HardwareJoystickMap.Platform_Linux_Base.Element
			{
				// Token: 0x060020E9 RID: 8425 RVA: 0x000192EE File Offset: 0x000174EE
				public Button()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				// Token: 0x060020EA RID: 8426 RVA: 0x000192FD File Offset: 0x000174FD
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Linux_Base.Button button = new HardwareJoystickMap.Platform_Linux_Base.Button();
					button.ImportVars(this);
					return button;
				}

				// Token: 0x060020EB RID: 8427 RVA: 0x00087580 File Offset: 0x00085780
				protected override void ImportVars(HardwareJoystickMap.Platform_Linux_Base.Element source)
				{
					base.ImportVars(source);
					HardwareJoystickMap.Platform_Linux_Base.Button button = source as HardwareJoystickMap.Platform_Linux_Base.Button;
					if (button == null)
					{
						return;
					}
					this.elementIdentifier = button.elementIdentifier;
					this.sourceType = button.sourceType;
					this.sourceButton = button.sourceButton;
					this.sourceAxis = button.sourceAxis;
					this.sourceAxisPole = button.sourceAxisPole;
					this.axisDeadZone = button.axisDeadZone;
					this.sourceHat = button.sourceHat;
					this.sourceHatType = button.sourceHatType;
					this.sourceHatDirection = button.sourceHatDirection;
					this.requireMultipleButtons = button.requireMultipleButtons;
					this.requiredButtons = ArrayTools.ShallowCopy<int>(button.requiredButtons);
					this.ignoreIfButtonsActive = button.ignoreIfButtonsActive;
					this.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<int>(button.ignoreIfButtonsActiveButtons);
					this.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(button.buttonInfo);
				}

				// Token: 0x04001299 RID: 4761
				public int elementIdentifier;

				// Token: 0x0400129A RID: 4762
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x0400129B RID: 4763
				public int sourceButton;

				// Token: 0x0400129C RID: 4764
				public int sourceAxis;

				// Token: 0x0400129D RID: 4765
				public Pole sourceAxisPole;

				// Token: 0x0400129E RID: 4766
				public float axisDeadZone;

				// Token: 0x0400129F RID: 4767
				public int sourceHat;

				// Token: 0x040012A0 RID: 4768
				public HatType sourceHatType;

				// Token: 0x040012A1 RID: 4769
				public HatDirection sourceHatDirection;

				// Token: 0x040012A2 RID: 4770
				public bool requireMultipleButtons;

				// Token: 0x040012A3 RID: 4771
				public int[] requiredButtons;

				// Token: 0x040012A4 RID: 4772
				public bool ignoreIfButtonsActive;

				// Token: 0x040012A5 RID: 4773
				public int[] ignoreIfButtonsActiveButtons;

				// Token: 0x040012A6 RID: 4774
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x020002F8 RID: 760
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class Axis : HardwareJoystickMap.Platform_Linux_Base.Element
			{
				// Token: 0x060020EC RID: 8428 RVA: 0x0001930B File Offset: 0x0001750B
				public Axis()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				// Token: 0x060020ED RID: 8429 RVA: 0x0001931A File Offset: 0x0001751A
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Linux_Base.Axis axis = new HardwareJoystickMap.Platform_Linux_Base.Axis();
					axis.ImportVars(this);
					return axis;
				}

				// Token: 0x060020EE RID: 8430 RVA: 0x00087658 File Offset: 0x00085858
				protected override void ImportVars(HardwareJoystickMap.Platform_Linux_Base.Element source)
				{
					base.ImportVars(source);
					HardwareJoystickMap.Platform_Linux_Base.Axis axis = source as HardwareJoystickMap.Platform_Linux_Base.Axis;
					if (axis == null)
					{
						return;
					}
					this.elementIdentifier = axis.elementIdentifier;
					this.sourceType = axis.sourceType;
					this.sourceAxis = axis.sourceAxis;
					this.sourceAxisRange = axis.sourceAxisRange;
					this.invert = axis.invert;
					this.axisDeadZone = axis.axisDeadZone;
					this.calibrateAxis = axis.calibrateAxis;
					this.axisZero = axis.axisZero;
					this.axisMin = axis.axisMin;
					this.axisMax = axis.axisMax;
					this.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(axis.axisInfo);
					this.sourceButton = axis.sourceButton;
					this.buttonAxisContribution = axis.buttonAxisContribution;
					this.sourceHat = axis.sourceHat;
					this.sourceHatDirection = axis.sourceHatDirection;
					this.sourceHatRange = axis.sourceHatRange;
					this.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(axis.alternateCalibrations);
				}

				// Token: 0x040012A7 RID: 4775
				public int elementIdentifier;

				// Token: 0x040012A8 RID: 4776
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x040012A9 RID: 4777
				public int sourceAxis;

				// Token: 0x040012AA RID: 4778
				public AxisRange sourceAxisRange;

				// Token: 0x040012AB RID: 4779
				public bool invert;

				// Token: 0x040012AC RID: 4780
				public float axisDeadZone;

				// Token: 0x040012AD RID: 4781
				public bool calibrateAxis;

				// Token: 0x040012AE RID: 4782
				public float axisZero;

				// Token: 0x040012AF RID: 4783
				public float axisMin;

				// Token: 0x040012B0 RID: 4784
				public float axisMax;

				// Token: 0x040012B1 RID: 4785
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x040012B2 RID: 4786
				public HardwareAxisInfo axisInfo;

				// Token: 0x040012B3 RID: 4787
				public int sourceButton;

				// Token: 0x040012B4 RID: 4788
				public Pole buttonAxisContribution;

				// Token: 0x040012B5 RID: 4789
				public int sourceHat;

				// Token: 0x040012B6 RID: 4790
				public AxisDirection sourceHatDirection;

				// Token: 0x040012B7 RID: 4791
				public AxisRange sourceHatRange;
			}
		}

		// Token: 0x020002FB RID: 763
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_Linux : HardwareJoystickMap.Platform_Linux_Base
		{
			// Token: 0x060020FF RID: 8447 RVA: 0x0001937C File Offset: 0x0001757C
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002100 RID: 8448 RVA: 0x00087928 File Offset: 0x00085B28
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002101 RID: 8449 RVA: 0x00087984 File Offset: 0x00085B84
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_Linux platform_Linux = new HardwareJoystickMap.Platform_Linux();
				this.CopyVars(platform_Linux);
				return platform_Linux;
			}

			// Token: 0x06002102 RID: 8450 RVA: 0x000879A0 File Offset: 0x00085BA0
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_Linux platform_Linux = destination as HardwareJoystickMap.Platform_Linux;
				if (platform_Linux == null)
				{
					return;
				}
				platform_Linux.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_Linux_Base>(this.variants);
			}

			// Token: 0x040012C4 RID: 4804
			public HardwareJoystickMap.Platform_Linux_Base[] variants;
		}

		// Token: 0x020002FC RID: 764
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_WindowsUWP_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x1700077D RID: 1917
			// (get) Token: 0x06002104 RID: 8452 RVA: 0x0001938C File Offset: 0x0001758C
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.WindowsUWP;
				}
			}

			// Token: 0x1700077E RID: 1918
			// (get) Token: 0x06002105 RID: 8453 RVA: 0x0001938F File Offset: 0x0001758F
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x1700077F RID: 1919
			// (get) Token: 0x06002106 RID: 8454 RVA: 0x000193BD File Offset: 0x000175BD
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000780 RID: 1920
			// (get) Token: 0x06002107 RID: 8455 RVA: 0x000193D4 File Offset: 0x000175D4
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000781 RID: 1921
			// (get) Token: 0x06002108 RID: 8456 RVA: 0x000193F5 File Offset: 0x000175F5
			internal HardwareJoystickMap.Platform_WindowsUWP_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000782 RID: 1922
			// (get) Token: 0x06002109 RID: 8457 RVA: 0x0001940C File Offset: 0x0001760C
			internal HardwareJoystickMap.Platform_WindowsUWP_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x0600210A RID: 8458 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x0600210B RID: 8459 RVA: 0x00019423 File Offset: 0x00017623
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x17000783 RID: 1923
			// (get) Token: 0x0600210C RID: 8460 RVA: 0x0001944A File Offset: 0x0001764A
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000784 RID: 1924
			// (get) Token: 0x0600210D RID: 8461 RVA: 0x00019461 File Offset: 0x00017661
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x0600210E RID: 8462 RVA: 0x000879D0 File Offset: 0x00085BD0
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_WindowsUWP_Base.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_WindowsUWP_Base.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600210F RID: 8463 RVA: 0x00087A64 File Offset: 0x00085C64
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_WindowsUWP_Base.Button button in this.IterateButtons())
				{
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_WindowsUWP_Base.Axis axis in this.IterateAxes())
				{
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06002110 RID: 8464 RVA: 0x00087B1C File Offset: 0x00085D1C
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_WindowsUWP_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002111 RID: 8465 RVA: 0x00087C34 File Offset: 0x00085E34
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002112 RID: 8466 RVA: 0x00087CFC File Offset: 0x00085EFC
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06002113 RID: 8467 RVA: 0x00019478 File Offset: 0x00017678
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002114 RID: 8468 RVA: 0x00019490 File Offset: 0x00017690
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002115 RID: 8469 RVA: 0x000194AC File Offset: 0x000176AC
			internal IEnumerable<HardwareJoystickMap.Platform_WindowsUWP_Base.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num = this.elements.axes.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.axes[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x06002116 RID: 8470 RVA: 0x000194BC File Offset: 0x000176BC
			internal IEnumerable<HardwareJoystickMap.Platform_WindowsUWP_Base.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num = this.elements.buttons.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.buttons[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x17000785 RID: 1925
			// (get) Token: 0x06002117 RID: 8471 RVA: 0x000194CC File Offset: 0x000176CC
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002118 RID: 8472 RVA: 0x00087D50 File Offset: 0x00085F50
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_WindowsUWP_Base platform_WindowsUWP_Base = new HardwareJoystickMap.Platform_WindowsUWP_Base();
				this.CopyVars(platform_WindowsUWP_Base);
				return platform_WindowsUWP_Base;
			}

			// Token: 0x06002119 RID: 8473 RVA: 0x00087D6C File Offset: 0x00085F6C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_WindowsUWP_Base platform_WindowsUWP_Base = destination as HardwareJoystickMap.Platform_WindowsUWP_Base;
				if (platform_WindowsUWP_Base == null)
				{
					return;
				}
				platform_WindowsUWP_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsUWP_Base.Elements>(this.elements);
			}

			// Token: 0x040012C5 RID: 4805
			public HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria matchingCriteria;

			// Token: 0x040012C6 RID: 4806
			public HardwareJoystickMap.Platform_WindowsUWP_Base.Elements elements;

			// Token: 0x020002FD RID: 765
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x17000786 RID: 1926
				// (get) Token: 0x0600211B RID: 8475 RVA: 0x000194D4 File Offset: 0x000176D4
				internal override bool hasData
				{
					get
					{
						return !this.disabled && ((this.productGUID != null && this.productGUID.Length != 0) || (this.productName != null && this.productName.Length != 0));
					}
				}

				// Token: 0x17000787 RID: 1927
				// (get) Token: 0x0600211C RID: 8476 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x0600211D RID: 8477 RVA: 0x00087D98 File Offset: 0x00085F98
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.deviceType != (HardwareJoystickMap.Platform_WindowsUWP_Base.DeviceType)bridgedControllerHWInfo.deviceType)
					{
						return false;
					}
					if (!this.HasProductName() && (this.productGUID == null || this.productGUID.Length == 0))
					{
						return true;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(this.productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains<PidVid>(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (this.productName == null || this.productName.Length == 0)
							{
								return true;
							}
						}
						return this.AnyNameMatches(bridgedControllerHWInfo);
					}
					return this.AnyNameMatches(bridgedControllerHWInfo);
				}

				// Token: 0x17000788 RID: 1928
				// (get) Token: 0x0600211E RID: 8478 RVA: 0x00019507 File Offset: 0x00017707
				internal override int alternateElementCount
				{
					get
					{
						if (this.alternateElementCounts == null)
						{
							return 0;
						}
						return this.alternateElementCounts.Length;
					}
				}

				// Token: 0x0600211F RID: 8479 RVA: 0x0001951B File Offset: 0x0001771B
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					if (this.alternateElementCounts == null || index < 0 || index >= this.alternateElementCounts.Length)
					{
						return null;
					}
					return this.alternateElementCounts[index];
				}

				// Token: 0x06002120 RID: 8480 RVA: 0x0001953E File Offset: 0x0001773E
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (alternateMatched || this.hatCount < 0 || bridgedControllerHWInfo.hardwareHatCount == this.hatCount);
				}

				// Token: 0x06002121 RID: 8481 RVA: 0x0001956B File Offset: 0x0001776B
				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return this.NameMatches(bridgedControllerHWInfo.hw_productName, this.productName, this.productName_useRegex);
				}

				// Token: 0x06002122 RID: 8482 RVA: 0x00087128 File Offset: 0x00085328
				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && HardwareJoystickMap.MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06002123 RID: 8483 RVA: 0x00087E48 File Offset: 0x00086048
				private bool HasProductName()
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(this.productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06002124 RID: 8484 RVA: 0x00087E84 File Offset: 0x00086084
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002125 RID: 8485 RVA: 0x00087EA0 File Offset: 0x000860A0
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.manufacturer_useRegex = this.manufacturer_useRegex;
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy<string>(this.manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy<string>(this.productGUID);
					matchingCriteria.deviceType = this.deviceType;
				}

				// Token: 0x040012C7 RID: 4807
				public int hatCount;

				// Token: 0x040012C8 RID: 4808
				public HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria.ElementCount[] alternateElementCounts;

				// Token: 0x040012C9 RID: 4809
				public bool manufacturer_useRegex;

				// Token: 0x040012CA RID: 4810
				public bool productName_useRegex;

				// Token: 0x040012CB RID: 4811
				public string[] manufacturer;

				// Token: 0x040012CC RID: 4812
				public string[] productName;

				// Token: 0x040012CD RID: 4813
				public string[] productGUID;

				// Token: 0x040012CE RID: 4814
				public HardwareJoystickMap.Platform_WindowsUWP_Base.DeviceType deviceType;

				// Token: 0x020002FE RID: 766
				[Serializable]
				public sealed class ElementCount : HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base
				{
					// Token: 0x06002128 RID: 8488 RVA: 0x00087F24 File Offset: 0x00086124
					public override object DeepClone()
					{
						HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria.ElementCount elementCount = new HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria.ElementCount();
						this.lIEfPuoiEXSCAiedHDGrZvHOsLxw(elementCount);
						return elementCount;
					}

					// Token: 0x06002129 RID: 8489 RVA: 0x00087F40 File Offset: 0x00086140
					internal void TWfguQVjLfBnIcQAkWKwmnCuSoSwA(HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base A_1)
					{
						base.lIEfPuoiEXSCAiedHDGrZvHOsLxw(A_1);
						HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria.ElementCount elementCount = A_1 as HardwareJoystickMap.Platform_WindowsUWP_Base.MatchingCriteria.ElementCount;
						if (elementCount == null)
						{
							return;
						}
						elementCount.hatCount = this.hatCount;
					}

					// Token: 0x0600212A RID: 8490 RVA: 0x0001958A File Offset: 0x0001778A
					internal bool UFrEQPGlshJRbrjCfGYDPggpxPzG(BridgedControllerHWInfo A_1)
					{
						return base.SzFaabwiwVxhtNCAlMSNVIkspaRo(A_1) && (this.hatCount < 0 || this.hatCount == A_1.hardwareHatCount);
					}

					// Token: 0x040012CF RID: 4815
					public int hatCount;
				}
			}

			// Token: 0x020002FF RID: 767
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x17000789 RID: 1929
				// (get) Token: 0x0600212B RID: 8491 RVA: 0x000195B0 File Offset: 0x000177B0
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x1700078A RID: 1930
				// (get) Token: 0x0600212C RID: 8492 RVA: 0x000195C4 File Offset: 0x000177C4
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x0600212D RID: 8493 RVA: 0x000195D8 File Offset: 0x000177D8
				internal HardwareJoystickMap.Platform_WindowsUWP_Base.Axis GetAxis(int axisIndex)
				{
					if (this.axes == null || axisIndex < 0 || axisIndex >= this.axes.Length)
					{
						return null;
					}
					return this.axes[axisIndex];
				}

				// Token: 0x1700078B RID: 1931
				// (get) Token: 0x0600212E RID: 8494 RVA: 0x000195FB File Offset: 0x000177FB
				internal IEnumerable<HardwareJoystickMap.Platform_WindowsUWP_Base.Axis> Axes
				{
					get
					{
						if (this.axes == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.axes.Length; i = num + 1)
						{
							yield return this.axes[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x1700078C RID: 1932
				// (get) Token: 0x0600212F RID: 8495 RVA: 0x0001960B File Offset: 0x0001780B
				internal IEnumerable<HardwareJoystickMap.Platform_WindowsUWP_Base.Button> Buttons
				{
					get
					{
						if (this.buttons == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.buttons.Length; i = num + 1)
						{
							yield return this.buttons[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x06002130 RID: 8496 RVA: 0x00087F6C File Offset: 0x0008616C
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002131 RID: 8497 RVA: 0x00087FD0 File Offset: 0x000861D0
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceTypeWithHat sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Axis:
								break;
							case HardwareElementSourceTypeWithHat.Hat:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06002132 RID: 8498 RVA: 0x00088094 File Offset: 0x00086294
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsUWP_Base.Elements elements = new HardwareJoystickMap.Platform_WindowsUWP_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002133 RID: 8499 RVA: 0x000880B0 File Offset: 0x000862B0
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WindowsUWP_Base.Elements elements = destination as HardwareJoystickMap.Platform_WindowsUWP_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WindowsUWP_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WindowsUWP_Base.Button>(this.buttons);
				}

				// Token: 0x040012D0 RID: 4816
				public HardwareJoystickMap.Platform_WindowsUWP_Base.Axis[] axes;

				// Token: 0x040012D1 RID: 4817
				public HardwareJoystickMap.Platform_WindowsUWP_Base.Button[] buttons;
			}

			// Token: 0x02000302 RID: 770
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x06002145 RID: 8517
				public abstract object DeepClone();

				// Token: 0x06002146 RID: 8518 RVA: 0x00002FF9 File Offset: 0x000011F9
				protected virtual void ImportVars(HardwareJoystickMap.Platform_WindowsUWP_Base.Element source)
				{
				}
			}

			// Token: 0x02000303 RID: 771
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class Button : HardwareJoystickMap.Platform_WindowsUWP_Base.Element
			{
				// Token: 0x06002148 RID: 8520 RVA: 0x0001966F File Offset: 0x0001786F
				public Button()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				// Token: 0x06002149 RID: 8521 RVA: 0x0001967E File Offset: 0x0001787E
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsUWP_Base.Button button = new HardwareJoystickMap.Platform_WindowsUWP_Base.Button();
					button.ImportVars(this);
					return button;
				}

				// Token: 0x0600214A RID: 8522 RVA: 0x00088284 File Offset: 0x00086484
				protected override void ImportVars(HardwareJoystickMap.Platform_WindowsUWP_Base.Element source)
				{
					base.ImportVars(source);
					HardwareJoystickMap.Platform_WindowsUWP_Base.Button button = source as HardwareJoystickMap.Platform_WindowsUWP_Base.Button;
					if (button == null)
					{
						return;
					}
					this.elementIdentifier = button.elementIdentifier;
					this.sourceType = button.sourceType;
					this.sourceButton = button.sourceButton;
					this.sourceAxis = button.sourceAxis;
					this.sourceAxisPole = button.sourceAxisPole;
					this.axisDeadZone = button.axisDeadZone;
					this.sourceHat = button.sourceHat;
					this.sourceHatType = button.sourceHatType;
					this.sourceHatDirection = button.sourceHatDirection;
					this.requireMultipleButtons = button.requireMultipleButtons;
					this.requiredButtons = ArrayTools.ShallowCopy<int>(button.requiredButtons);
					this.ignoreIfButtonsActive = button.ignoreIfButtonsActive;
					this.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<int>(button.ignoreIfButtonsActiveButtons);
					this.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(button.buttonInfo);
				}

				// Token: 0x040012DC RID: 4828
				public int elementIdentifier;

				// Token: 0x040012DD RID: 4829
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x040012DE RID: 4830
				public int sourceButton;

				// Token: 0x040012DF RID: 4831
				public int sourceAxis;

				// Token: 0x040012E0 RID: 4832
				public Pole sourceAxisPole;

				// Token: 0x040012E1 RID: 4833
				public float axisDeadZone;

				// Token: 0x040012E2 RID: 4834
				public int sourceHat;

				// Token: 0x040012E3 RID: 4835
				public HatType sourceHatType;

				// Token: 0x040012E4 RID: 4836
				public HatDirection sourceHatDirection;

				// Token: 0x040012E5 RID: 4837
				public bool requireMultipleButtons;

				// Token: 0x040012E6 RID: 4838
				public int[] requiredButtons;

				// Token: 0x040012E7 RID: 4839
				public bool ignoreIfButtonsActive;

				// Token: 0x040012E8 RID: 4840
				public int[] ignoreIfButtonsActiveButtons;

				// Token: 0x040012E9 RID: 4841
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x02000304 RID: 772
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class Axis : HardwareJoystickMap.Platform_WindowsUWP_Base.Element
			{
				// Token: 0x0600214B RID: 8523 RVA: 0x0001968C File Offset: 0x0001788C
				public Axis()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				// Token: 0x0600214C RID: 8524 RVA: 0x0001969B File Offset: 0x0001789B
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsUWP_Base.Axis axis = new HardwareJoystickMap.Platform_WindowsUWP_Base.Axis();
					axis.ImportVars(this);
					return axis;
				}

				// Token: 0x0600214D RID: 8525 RVA: 0x0008835C File Offset: 0x0008655C
				protected override void ImportVars(HardwareJoystickMap.Platform_WindowsUWP_Base.Element source)
				{
					base.ImportVars(source);
					HardwareJoystickMap.Platform_WindowsUWP_Base.Axis axis = source as HardwareJoystickMap.Platform_WindowsUWP_Base.Axis;
					if (axis == null)
					{
						return;
					}
					this.elementIdentifier = axis.elementIdentifier;
					this.sourceType = axis.sourceType;
					this.sourceAxis = axis.sourceAxis;
					this.sourceAxisRange = axis.sourceAxisRange;
					this.invert = axis.invert;
					this.axisDeadZone = axis.axisDeadZone;
					this.calibrateAxis = axis.calibrateAxis;
					this.axisZero = axis.axisZero;
					this.axisMin = axis.axisMin;
					this.axisMax = axis.axisMax;
					this.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(axis.axisInfo);
					this.sourceButton = axis.sourceButton;
					this.buttonAxisContribution = axis.buttonAxisContribution;
					this.sourceHat = axis.sourceHat;
					this.sourceHatDirection = axis.sourceHatDirection;
					this.sourceHatRange = axis.sourceHatRange;
					this.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(axis.alternateCalibrations);
				}

				// Token: 0x040012EA RID: 4842
				public int elementIdentifier;

				// Token: 0x040012EB RID: 4843
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x040012EC RID: 4844
				public int sourceAxis;

				// Token: 0x040012ED RID: 4845
				public AxisRange sourceAxisRange;

				// Token: 0x040012EE RID: 4846
				public bool invert;

				// Token: 0x040012EF RID: 4847
				public float axisDeadZone;

				// Token: 0x040012F0 RID: 4848
				public bool calibrateAxis;

				// Token: 0x040012F1 RID: 4849
				public float axisZero;

				// Token: 0x040012F2 RID: 4850
				public float axisMin;

				// Token: 0x040012F3 RID: 4851
				public float axisMax;

				// Token: 0x040012F4 RID: 4852
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x040012F5 RID: 4853
				public HardwareAxisInfo axisInfo;

				// Token: 0x040012F6 RID: 4854
				public int sourceButton;

				// Token: 0x040012F7 RID: 4855
				public Pole buttonAxisContribution;

				// Token: 0x040012F8 RID: 4856
				public int sourceHat;

				// Token: 0x040012F9 RID: 4857
				public AxisDirection sourceHatDirection;

				// Token: 0x040012FA RID: 4858
				public AxisRange sourceHatRange;
			}

			// Token: 0x02000305 RID: 773
			public enum DeviceType
			{
				// Token: 0x040012FC RID: 4860
				HIDJoystick,
				// Token: 0x040012FD RID: 4861
				WGIGamepad
			}
		}

		// Token: 0x02000308 RID: 776
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_WindowsUWP : HardwareJoystickMap.Platform_WindowsUWP_Base
		{
			// Token: 0x0600215E RID: 8542 RVA: 0x000196FD File Offset: 0x000178FD
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x0600215F RID: 8543 RVA: 0x0008862C File Offset: 0x0008682C
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002160 RID: 8544 RVA: 0x00088688 File Offset: 0x00086888
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_WindowsUWP platform_WindowsUWP = new HardwareJoystickMap.Platform_WindowsUWP();
				this.CopyVars(platform_WindowsUWP);
				return platform_WindowsUWP;
			}

			// Token: 0x06002161 RID: 8545 RVA: 0x000886A4 File Offset: 0x000868A4
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_WindowsUWP platform_WindowsUWP = destination as HardwareJoystickMap.Platform_WindowsUWP;
				if (platform_WindowsUWP == null)
				{
					return;
				}
				platform_WindowsUWP.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsUWP_Base>(this.variants);
			}

			// Token: 0x0400130A RID: 4874
			public HardwareJoystickMap.Platform_WindowsUWP_Base[] variants;
		}

		// Token: 0x02000309 RID: 777
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_Fallback_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x17000795 RID: 1941
			// (get) Token: 0x06002163 RID: 8547 RVA: 0x0001970D File Offset: 0x0001790D
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000796 RID: 1942
			// (get) Token: 0x06002164 RID: 8548 RVA: 0x00019724 File Offset: 0x00017924
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x17000797 RID: 1943
			// (get) Token: 0x06002165 RID: 8549 RVA: 0x0001973B File Offset: 0x0001793B
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.Fallback;
				}
			}

			// Token: 0x17000798 RID: 1944
			// (get) Token: 0x06002166 RID: 8550 RVA: 0x0001973F File Offset: 0x0001793F
			internal HardwareJoystickMap.Platform_Fallback_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000799 RID: 1945
			// (get) Token: 0x06002167 RID: 8551 RVA: 0x00019756 File Offset: 0x00017956
			internal HardwareJoystickMap.Platform_Fallback_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x1700079A RID: 1946
			// (get) Token: 0x06002168 RID: 8552 RVA: 0x0001976D File Offset: 0x0001796D
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x1700079B RID: 1947
			// (get) Token: 0x06002169 RID: 8553 RVA: 0x0001979B File Offset: 0x0001799B
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x1700079C RID: 1948
			// (get) Token: 0x0600216A RID: 8554 RVA: 0x000197B2 File Offset: 0x000179B2
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x1700079D RID: 1949
			// (get) Token: 0x0600216B RID: 8555 RVA: 0x000197D3 File Offset: 0x000179D3
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x0600216C RID: 8556 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x0600216D RID: 8557 RVA: 0x000197DB File Offset: 0x000179DB
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x0600216E RID: 8558 RVA: 0x00019802 File Offset: 0x00017A02
			internal IEnumerable<HardwareJoystickMap.Platform_Fallback_Base.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x0600216F RID: 8559 RVA: 0x00019812 File Offset: 0x00017A12
			internal IEnumerable<HardwareJoystickMap.Platform_Fallback_Base.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002170 RID: 8560 RVA: 0x000886D4 File Offset: 0x000868D4
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Fallback_Base.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Fallback_Base.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002171 RID: 8561 RVA: 0x00088768 File Offset: 0x00086968
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Fallback_Base.Button button in this.IterateButtons())
				{
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Fallback_Base.Axis axis in this.IterateAxes())
				{
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06002172 RID: 8562 RVA: 0x00088820 File Offset: 0x00086A20
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002173 RID: 8563 RVA: 0x00088938 File Offset: 0x00086B38
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002174 RID: 8564 RVA: 0x00088A00 File Offset: 0x00086C00
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06002175 RID: 8565 RVA: 0x00019822 File Offset: 0x00017A22
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002176 RID: 8566 RVA: 0x0001983A File Offset: 0x00017A3A
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002177 RID: 8567 RVA: 0x00088A54 File Offset: 0x00086C54
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_Fallback_Base platform_Fallback_Base = new HardwareJoystickMap.Platform_Fallback_Base();
				this.CopyVars(platform_Fallback_Base);
				return platform_Fallback_Base;
			}

			// Token: 0x06002178 RID: 8568 RVA: 0x00088A70 File Offset: 0x00086C70
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_Fallback_Base platform_Fallback_Base = destination as HardwareJoystickMap.Platform_Fallback_Base;
				if (platform_Fallback_Base == null)
				{
					return;
				}
				platform_Fallback_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback_Base.MatchingCriteria>(this.matchingCriteria);
				platform_Fallback_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback_Base.Elements>(this.elements);
			}

			// Token: 0x0400130B RID: 4875
			public HardwareJoystickMap.Platform_Fallback_Base.MatchingCriteria matchingCriteria;

			// Token: 0x0400130C RID: 4876
			public HardwareJoystickMap.Platform_Fallback_Base.Elements elements;

			// Token: 0x0200030A RID: 778
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x1700079E RID: 1950
				// (get) Token: 0x0600217A RID: 8570 RVA: 0x00019856 File Offset: 0x00017A56
				internal override bool hasData
				{
					get
					{
						return !this.disabled && (this.alwaysMatch || (this.productName != null && this.productName.Length != 0));
					}
				}

				// Token: 0x1700079F RID: 1951
				// (get) Token: 0x0600217B RID: 8571 RVA: 0x00088AAC File Offset: 0x00086CAC
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && (!this.matchUnityVersion || UnityTools.IsUnityVersionInRange(this.matchUnityVersion_min, this.matchUnityVersion_max)) && (!this.matchSysVersion || PlatformTools.IsSysVersionInRange(this.matchSysVersion_min, this.matchSysVersion_max));
					}
				}

				// Token: 0x0600217C RID: 8572 RVA: 0x00088B00 File Offset: 0x00086D00
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!this.isAllowed)
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (this.productName != null)
					{
						for (int i = 0; i < this.productName.Length; i++)
						{
							string searchFor = this.productName[i];
							if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, this.productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				// Token: 0x170007A0 RID: 1952
				// (get) Token: 0x0600217D RID: 8573 RVA: 0x00003E2B File Offset: 0x0000202B
				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x0600217E RID: 8574 RVA: 0x000067FE File Offset: 0x000049FE
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				// Token: 0x0600217F RID: 8575 RVA: 0x00018BF2 File Offset: 0x00016DF2
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				// Token: 0x06002180 RID: 8576 RVA: 0x00088B94 File Offset: 0x00086D94
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Fallback_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_Fallback_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002181 RID: 8577 RVA: 0x00088BB0 File Offset: 0x00086DB0
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Fallback_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_Fallback_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.alwaysMatch = this.alwaysMatch;
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.matchUnityVersion = this.matchUnityVersion;
					matchingCriteria.matchUnityVersion_min = this.matchUnityVersion_min;
					matchingCriteria.matchUnityVersion_max = this.matchUnityVersion_max;
					matchingCriteria.matchSysVersion = this.matchSysVersion;
					matchingCriteria.matchSysVersion_min = this.matchSysVersion_min;
					matchingCriteria.matchSysVersion_max = this.matchSysVersion_max;
				}

				// Token: 0x0400130D RID: 4877
				public bool alwaysMatch;

				// Token: 0x0400130E RID: 4878
				public bool productName_useRegex;

				// Token: 0x0400130F RID: 4879
				public string[] productName;

				// Token: 0x04001310 RID: 4880
				public bool matchUnityVersion;

				// Token: 0x04001311 RID: 4881
				public string matchUnityVersion_min;

				// Token: 0x04001312 RID: 4882
				public string matchUnityVersion_max;

				// Token: 0x04001313 RID: 4883
				public bool matchSysVersion;

				// Token: 0x04001314 RID: 4884
				public string matchSysVersion_min;

				// Token: 0x04001315 RID: 4885
				public string matchSysVersion_max;
			}

			// Token: 0x0200030B RID: 779
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x170007A1 RID: 1953
				// (get) Token: 0x06002183 RID: 8579 RVA: 0x00019880 File Offset: 0x00017A80
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x170007A2 RID: 1954
				// (get) Token: 0x06002184 RID: 8580 RVA: 0x00019894 File Offset: 0x00017A94
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06002185 RID: 8581 RVA: 0x00088C40 File Offset: 0x00086E40
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002186 RID: 8582 RVA: 0x00088CA4 File Offset: 0x00086EA4
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceTypeWithHat sourceType = this.axes[i].sourceType;
							if (sourceType == HardwareElementSourceTypeWithHat.Button)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == HardwareElementSourceTypeWithHat.Axis || sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06002187 RID: 8583 RVA: 0x00088D2C File Offset: 0x00086F2C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Fallback_Base.Elements elements = new HardwareJoystickMap.Platform_Fallback_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002188 RID: 8584 RVA: 0x00088D48 File Offset: 0x00086F48
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Fallback_Base.Elements elements = destination as HardwareJoystickMap.Platform_Fallback_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_Fallback_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_Fallback_Base.Button>(this.buttons);
				}

				// Token: 0x04001316 RID: 4886
				public HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes;

				// Token: 0x04001317 RID: 4887
				public HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons;
			}

			// Token: 0x0200030C RID: 780
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				// Token: 0x0600218A RID: 8586 RVA: 0x00088D8C File Offset: 0x00086F8C
				public object DeepClone()
				{
					return new HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData
					{
						sourceType = this.sourceType,
						sourceElement = this.sourceElement,
						sourceAxisRange = this.sourceAxisRange,
						deadzone = this.deadzone,
						invert = this.invert
					};
				}

				// Token: 0x04001318 RID: 4888
				public int sourceType;

				// Token: 0x04001319 RID: 4889
				public int sourceElement;

				// Token: 0x0400131A RID: 4890
				public AxisRange sourceAxisRange;

				// Token: 0x0400131B RID: 4891
				public float deadzone;

				// Token: 0x0400131C RID: 4892
				public bool invert;
			}

			// Token: 0x0200030D RID: 781
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x0600218C RID: 8588
				public abstract object DeepClone();

				// Token: 0x0600218D RID: 8589 RVA: 0x00088DDC File Offset: 0x00086FDC
				internal virtual void CopyVars(HardwareJoystickMap.Platform_Fallback_Base.Element destination)
				{
					if (destination == null)
					{
						return;
					}
					destination.elementIdentifier = this.elementIdentifier;
					destination.sourceType = this.sourceType;
					destination.sourceAxis = this.sourceAxis;
					destination.axisDeadZone = this.axisDeadZone;
					destination.sourceButton = this.sourceButton;
					destination.sourceKeyCode = this.sourceKeyCode;
					destination.customCalculation = this.customCalculation;
					destination.customCalculationSourceData = ArrayTools.DeepClone<HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData>(this.customCalculationSourceData);
				}

				// Token: 0x0400131D RID: 4893
				public int elementIdentifier;

				// Token: 0x0400131E RID: 4894
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x0400131F RID: 4895
				public UnityAxis sourceAxis;

				// Token: 0x04001320 RID: 4896
				public float axisDeadZone;

				// Token: 0x04001321 RID: 4897
				public UnityButton sourceButton;

				// Token: 0x04001322 RID: 4898
				public KeyCode sourceKeyCode;

				// Token: 0x04001323 RID: 4899
				public CustomCalculation customCalculation;

				// Token: 0x04001324 RID: 4900
				public HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData;
			}

			// Token: 0x0200030E RID: 782
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Button : HardwareJoystickMap.Platform_Fallback_Base.Element
			{
				// Token: 0x0600218F RID: 8591 RVA: 0x00088E54 File Offset: 0x00087054
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Fallback_Base.Button button = new HardwareJoystickMap.Platform_Fallback_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x06002190 RID: 8592 RVA: 0x00088E70 File Offset: 0x00087070
				internal override void CopyVars(HardwareJoystickMap.Platform_Fallback_Base.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Fallback_Base.Button button = destination as HardwareJoystickMap.Platform_Fallback_Base.Button;
					if (button == null)
					{
						return;
					}
					button.sourceAxisPole = this.sourceAxisPole;
					button.unityHat_sourceAxis1 = this.unityHat_sourceAxis1;
					button.unityHat_sourceAxis2 = this.unityHat_sourceAxis2;
					button.unityHat_isActiveAxisValues1 = this.unityHat_isActiveAxisValues1;
					button.unityHat_isActiveAxisValues2 = this.unityHat_isActiveAxisValues2;
					button.unityHat_isActiveAxisValues3 = this.unityHat_isActiveAxisValues3;
					button.unityHat_zeroValues = this.unityHat_zeroValues;
					button.unityHat_checkNeverPressed = this.unityHat_checkNeverPressed;
					button.unityHat_neverPressedZeroValues = this.unityHat_neverPressedZeroValues;
					button.requireMultipleButtons = this.requireMultipleButtons;
					button.requiredButtons = ArrayTools.ShallowCopy<UnityButton>(this.requiredButtons);
					button.ignoreIfButtonsActive = this.ignoreIfButtonsActive;
					button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<UnityButton>(this.ignoreIfButtonsActiveButtons);
					button.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(this.buttonInfo);
				}

				// Token: 0x04001325 RID: 4901
				public Pole sourceAxisPole;

				// Token: 0x04001326 RID: 4902
				public UnityAxis unityHat_sourceAxis1;

				// Token: 0x04001327 RID: 4903
				public UnityAxis unityHat_sourceAxis2;

				// Token: 0x04001328 RID: 4904
				public Vector2 unityHat_isActiveAxisValues1;

				// Token: 0x04001329 RID: 4905
				public Vector2 unityHat_isActiveAxisValues2;

				// Token: 0x0400132A RID: 4906
				public Vector2 unityHat_isActiveAxisValues3;

				// Token: 0x0400132B RID: 4907
				public Vector2 unityHat_zeroValues;

				// Token: 0x0400132C RID: 4908
				public bool unityHat_checkNeverPressed;

				// Token: 0x0400132D RID: 4909
				public Vector2 unityHat_neverPressedZeroValues;

				// Token: 0x0400132E RID: 4910
				public bool requireMultipleButtons;

				// Token: 0x0400132F RID: 4911
				public UnityButton[] requiredButtons;

				// Token: 0x04001330 RID: 4912
				public bool ignoreIfButtonsActive;

				// Token: 0x04001331 RID: 4913
				public UnityButton[] ignoreIfButtonsActiveButtons;

				// Token: 0x04001332 RID: 4914
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x0200030F RID: 783
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Axis : HardwareJoystickMap.Platform_Fallback_Base.Element
			{
				// Token: 0x06002192 RID: 8594 RVA: 0x00088F48 File Offset: 0x00087148
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Fallback_Base.Axis axis = new HardwareJoystickMap.Platform_Fallback_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x06002193 RID: 8595 RVA: 0x00088F64 File Offset: 0x00087164
				internal override void CopyVars(HardwareJoystickMap.Platform_Fallback_Base.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Fallback_Base.Axis axis = destination as HardwareJoystickMap.Platform_Fallback_Base.Axis;
					if (axis == null)
					{
						return;
					}
					axis.invert = this.invert;
					axis.sourceAxisRange = this.sourceAxisRange;
					axis.buttonAxisContribution = this.buttonAxisContribution;
					axis.calibrateAxis = this.calibrateAxis;
					axis.axisZero = this.axisZero;
					axis.axisMin = this.axisMin;
					axis.axisMax = this.axisMax;
					axis.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(this.axisInfo);
					axis.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(this.alternateCalibrations);
				}

				// Token: 0x04001333 RID: 4915
				public bool invert;

				// Token: 0x04001334 RID: 4916
				public AxisRange sourceAxisRange;

				// Token: 0x04001335 RID: 4917
				public Pole buttonAxisContribution;

				// Token: 0x04001336 RID: 4918
				public bool calibrateAxis;

				// Token: 0x04001337 RID: 4919
				public float axisZero;

				// Token: 0x04001338 RID: 4920
				public float axisMin;

				// Token: 0x04001339 RID: 4921
				public float axisMax;

				// Token: 0x0400133A RID: 4922
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x0400133B RID: 4923
				public HardwareAxisInfo axisInfo;
			}
		}

		// Token: 0x02000312 RID: 786
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_Fallback : HardwareJoystickMap.Platform_Fallback_Base
		{
			// Token: 0x060021A5 RID: 8613 RVA: 0x00019904 File Offset: 0x00017B04
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060021A6 RID: 8614 RVA: 0x000891BC File Offset: 0x000873BC
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060021A7 RID: 8615 RVA: 0x00089218 File Offset: 0x00087418
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_Fallback platform_Fallback = new HardwareJoystickMap.Platform_Fallback();
				this.CopyVars(platform_Fallback);
				return platform_Fallback;
			}

			// Token: 0x060021A8 RID: 8616 RVA: 0x00089234 File Offset: 0x00087434
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_Fallback platform_Fallback = destination as HardwareJoystickMap.Platform_Fallback;
				if (platform_Fallback == null)
				{
					return;
				}
				platform_Fallback.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_Fallback_Base>(this.variants);
			}

			// Token: 0x04001346 RID: 4934
			public HardwareJoystickMap.Platform_Fallback_Base[] variants;
		}

		// Token: 0x02000313 RID: 787
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public abstract class Platform_Custom : HardwareJoystickMap.Platform
		{
			// Token: 0x170007A7 RID: 1959
			// (get) Token: 0x060021AA RID: 8618
			internal abstract HardwareJoystickMap.Platform_Custom.Axis[] Axes { get; }

			// Token: 0x170007A8 RID: 1960
			// (get) Token: 0x060021AB RID: 8619
			internal abstract HardwareJoystickMap.Platform_Custom.Button[] Buttons { get; }

			// Token: 0x060021AC RID: 8620
			internal abstract IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes();

			// Token: 0x060021AD RID: 8621
			internal abstract IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons();

			// Token: 0x060021AE RID: 8622 RVA: 0x00002FF9 File Offset: 0x000011F9
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
			}

			// Token: 0x02000314 RID: 788
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x170007A9 RID: 1961
				// (get) Token: 0x060021B0 RID: 8624 RVA: 0x00019914 File Offset: 0x00017B14
				internal override bool hasData
				{
					get
					{
						return !this.disabled && this.alwaysMatch;
					}
				}

				// Token: 0x170007AA RID: 1962
				// (get) Token: 0x060021B1 RID: 8625 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x060021B2 RID: 8626 RVA: 0x0001992B File Offset: 0x00017B2B
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (this.disabled)
					{
						return false;
					}
					if (!this.isAllowed)
					{
						return false;
					}
					bool flag = this.alwaysMatch;
					return true;
				}

				// Token: 0x170007AB RID: 1963
				// (get) Token: 0x060021B3 RID: 8627 RVA: 0x00003E2B File Offset: 0x0000202B
				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x060021B4 RID: 8628 RVA: 0x000067FE File Offset: 0x000049FE
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				// Token: 0x060021B5 RID: 8629 RVA: 0x00018BF2 File Offset: 0x00016DF2
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				// Token: 0x060021B6 RID: 8630 RVA: 0x00089264 File Offset: 0x00087464
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Custom.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_Custom.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.alwaysMatch = this.alwaysMatch;
				}

				// Token: 0x04001347 RID: 4935
				[Tooltip("If enabled, this will match to every controller regardless of other matching criteria.")]
				public bool alwaysMatch;
			}

			// Token: 0x02000315 RID: 789
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Elements : HardwareJoystickMap.Elements_Base
			{
			}

			// Token: 0x02000316 RID: 790
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				// Token: 0x060021B9 RID: 8633 RVA: 0x00089290 File Offset: 0x00087490
				public virtual object DeepClone()
				{
					return new HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData
					{
						sourceType = this.sourceType,
						sourceAxis = this.sourceAxis,
						sourceButton = this.sourceButton,
						sourceOtherAxis = this.sourceOtherAxis,
						sourceAxisRange = this.sourceAxisRange,
						axisDeadZone = this.axisDeadZone,
						invert = this.invert,
						axisCalibrationType = this.axisCalibrationType,
						axisZero = this.axisZero,
						axisMin = this.axisMin,
						axisMax = this.axisMax
					};
				}

				// Token: 0x04001348 RID: 4936
				public int sourceType;

				// Token: 0x04001349 RID: 4937
				public int sourceAxis;

				// Token: 0x0400134A RID: 4938
				public int sourceButton;

				// Token: 0x0400134B RID: 4939
				public int sourceOtherAxis;

				// Token: 0x0400134C RID: 4940
				public AxisRange sourceAxisRange;

				// Token: 0x0400134D RID: 4941
				public float axisDeadZone;

				// Token: 0x0400134E RID: 4942
				public bool invert;

				// Token: 0x0400134F RID: 4943
				public AxisCalibrationType axisCalibrationType;

				// Token: 0x04001350 RID: 4944
				public float axisZero;

				// Token: 0x04001351 RID: 4945
				public float axisMin;

				// Token: 0x04001352 RID: 4946
				public float axisMax;
			}

			// Token: 0x02000317 RID: 791
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x060021BB RID: 8635 RVA: 0x00089328 File Offset: 0x00087528
				internal virtual void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					destination.elementIdentifier = this.elementIdentifier;
					destination.sourceType = this.sourceType;
					destination.sourceAxis = this.sourceAxis;
					destination.axisDeadZone = this.axisDeadZone;
					destination.sourceButton = this.sourceButton;
					destination.customCalculation = this.customCalculation;
					destination.customCalculationSourceData = ArrayTools.DeepClone<HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData>(this.customCalculationSourceData);
				}

				// Token: 0x060021BC RID: 8636
				public abstract object DeepClone();

				// Token: 0x04001353 RID: 4947
				public int elementIdentifier;

				// Token: 0x04001354 RID: 4948
				public int sourceType;

				// Token: 0x04001355 RID: 4949
				public int sourceAxis;

				// Token: 0x04001356 RID: 4950
				public float axisDeadZone;

				// Token: 0x04001357 RID: 4951
				public int sourceButton;

				// Token: 0x04001358 RID: 4952
				public CustomCalculation customCalculation;

				// Token: 0x04001359 RID: 4953
				public HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData[] customCalculationSourceData;
			}

			// Token: 0x02000318 RID: 792
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Button : HardwareJoystickMap.Platform_Custom.Element
			{
				// Token: 0x060021BE RID: 8638 RVA: 0x00089390 File Offset: 0x00087590
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Custom.Button button = destination as HardwareJoystickMap.Platform_Custom.Button;
					if (button == null)
					{
						return;
					}
					button.sourceAxisPole = this.sourceAxisPole;
					button.requireMultipleButtons = this.requireMultipleButtons;
					button.requiredButtons = ArrayTools.ShallowCopy<int>(this.requiredButtons);
					button.ignoreIfButtonsActive = this.ignoreIfButtonsActive;
					button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<int>(this.ignoreIfButtonsActiveButtons);
					button.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(this.buttonInfo);
				}

				// Token: 0x0400135A RID: 4954
				public Pole sourceAxisPole;

				// Token: 0x0400135B RID: 4955
				public bool requireMultipleButtons;

				// Token: 0x0400135C RID: 4956
				public int[] requiredButtons;

				// Token: 0x0400135D RID: 4957
				public bool ignoreIfButtonsActive;

				// Token: 0x0400135E RID: 4958
				public int[] ignoreIfButtonsActiveButtons;

				// Token: 0x0400135F RID: 4959
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x02000319 RID: 793
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Axis : HardwareJoystickMap.Platform_Custom.Element
			{
				// Token: 0x060021C0 RID: 8640 RVA: 0x00089408 File Offset: 0x00087608
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Custom.Axis axis = destination as HardwareJoystickMap.Platform_Custom.Axis;
					if (axis == null)
					{
						return;
					}
					axis.invert = this.invert;
					axis.sourceAxisRange = this.sourceAxisRange;
					axis.buttonAxisContribution = this.buttonAxisContribution;
					axis.calibrateAxis = this.calibrateAxis;
					axis.axisZero = this.axisZero;
					axis.axisMin = this.axisMin;
					axis.axisMax = this.axisMax;
					axis.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(this.axisInfo);
					axis.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(this.alternateCalibrations);
				}

				// Token: 0x04001360 RID: 4960
				public bool invert;

				// Token: 0x04001361 RID: 4961
				public AxisRange sourceAxisRange;

				// Token: 0x04001362 RID: 4962
				public Pole buttonAxisContribution;

				// Token: 0x04001363 RID: 4963
				public bool calibrateAxis;

				// Token: 0x04001364 RID: 4964
				public float axisZero;

				// Token: 0x04001365 RID: 4965
				public float axisMin;

				// Token: 0x04001366 RID: 4966
				public float axisMax;

				// Token: 0x04001367 RID: 4967
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x04001368 RID: 4968
				public HardwareAxisInfo axisInfo;
			}
		}

		// Token: 0x0200031A RID: 794
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_XboxOne_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x170007AC RID: 1964
			// (get) Token: 0x060021C2 RID: 8642 RVA: 0x0001996B File Offset: 0x00017B6B
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x170007AD RID: 1965
			// (get) Token: 0x060021C3 RID: 8643 RVA: 0x00019982 File Offset: 0x00017B82
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x170007AE RID: 1966
			// (get) Token: 0x060021C4 RID: 8644 RVA: 0x00019999 File Offset: 0x00017B99
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.XboxOne;
				}
			}

			// Token: 0x170007AF RID: 1967
			// (get) Token: 0x060021C5 RID: 8645 RVA: 0x000894A0 File Offset: 0x000876A0
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_XboxOne_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x170007B0 RID: 1968
			// (get) Token: 0x060021C6 RID: 8646 RVA: 0x000894EC File Offset: 0x000876EC
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_XboxOne_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x170007B1 RID: 1969
			// (get) Token: 0x060021C7 RID: 8647 RVA: 0x0001999D File Offset: 0x00017B9D
			internal HardwareJoystickMap.Platform_XboxOne_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x170007B2 RID: 1970
			// (get) Token: 0x060021C8 RID: 8648 RVA: 0x000199B4 File Offset: 0x00017BB4
			internal HardwareJoystickMap.Platform_XboxOne_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x170007B3 RID: 1971
			// (get) Token: 0x060021C9 RID: 8649 RVA: 0x000199CB File Offset: 0x00017BCB
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x170007B4 RID: 1972
			// (get) Token: 0x060021CA RID: 8650 RVA: 0x000199F9 File Offset: 0x00017BF9
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x170007B5 RID: 1973
			// (get) Token: 0x060021CB RID: 8651 RVA: 0x00019A10 File Offset: 0x00017C10
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x170007B6 RID: 1974
			// (get) Token: 0x060021CC RID: 8652 RVA: 0x00019A31 File Offset: 0x00017C31
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x060021CD RID: 8653 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x060021CE RID: 8654 RVA: 0x00019A39 File Offset: 0x00017C39
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x060021CF RID: 8655 RVA: 0x00019A60 File Offset: 0x00017C60
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060021D0 RID: 8656 RVA: 0x00019A70 File Offset: 0x00017C70
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060021D1 RID: 8657 RVA: 0x00089538 File Offset: 0x00087738
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_XboxOne_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_XboxOne_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060021D2 RID: 8658 RVA: 0x000895D8 File Offset: 0x000877D8
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_XboxOne_Base.Button button2 = (HardwareJoystickMap.Platform_XboxOne_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_XboxOne_Base.Axis axis2 = (HardwareJoystickMap.Platform_XboxOne_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x060021D3 RID: 8659 RVA: 0x0008969C File Offset: 0x0008789C
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_XboxOne_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x060021D4 RID: 8660 RVA: 0x000897A8 File Offset: 0x000879A8
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x060021D5 RID: 8661 RVA: 0x0008985C File Offset: 0x00087A5C
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x060021D6 RID: 8662 RVA: 0x00019A80 File Offset: 0x00017C80
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x060021D7 RID: 8663 RVA: 0x00019A98 File Offset: 0x00017C98
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x060021D8 RID: 8664 RVA: 0x000898B0 File Offset: 0x00087AB0
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_XboxOne_Base platform_XboxOne_Base = new HardwareJoystickMap.Platform_XboxOne_Base();
				this.CopyVars(platform_XboxOne_Base);
				return platform_XboxOne_Base;
			}

			// Token: 0x060021D9 RID: 8665 RVA: 0x000898CC File Offset: 0x00087ACC
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_XboxOne_Base platform_XboxOne_Base = destination as HardwareJoystickMap.Platform_XboxOne_Base;
				if (platform_XboxOne_Base == null)
				{
					return;
				}
				platform_XboxOne_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_XboxOne_Base.MatchingCriteria>(this.matchingCriteria);
				platform_XboxOne_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_XboxOne_Base.Elements>(this.elements);
			}

			// Token: 0x04001369 RID: 4969
			public HardwareJoystickMap.Platform_XboxOne_Base.MatchingCriteria matchingCriteria;

			// Token: 0x0400136A RID: 4970
			public HardwareJoystickMap.Platform_XboxOne_Base.Elements elements;

			// Token: 0x0400136B RID: 4971
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x0400136C RID: 4972
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x0200031B RID: 795
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x170007B7 RID: 1975
				// (get) Token: 0x060021DB RID: 8667 RVA: 0x00019AB4 File Offset: 0x00017CB4
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0);
					}
				}

				// Token: 0x170007B8 RID: 1976
				// (get) Token: 0x060021DC RID: 8668 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x060021DD RID: 8669 RVA: 0x00089910 File Offset: 0x00087B10
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (this.productName != null)
					{
						for (int i = 0; i < this.productName.Length; i++)
						{
							string searchFor = this.productName[i];
							if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, this.productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				// Token: 0x060021DE RID: 8670 RVA: 0x0008999C File Offset: 0x00087B9C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XboxOne_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_XboxOne_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x060021DF RID: 8671 RVA: 0x000899B8 File Offset: 0x00087BB8
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XboxOne_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_XboxOne_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
				}

				// Token: 0x0400136D RID: 4973
				public bool productName_useRegex;

				// Token: 0x0400136E RID: 4974
				public string[] productName;
			}

			// Token: 0x0200031C RID: 796
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x170007B9 RID: 1977
				// (get) Token: 0x060021E1 RID: 8673 RVA: 0x00019AD4 File Offset: 0x00017CD4
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x170007BA RID: 1978
				// (get) Token: 0x060021E2 RID: 8674 RVA: 0x00019AE8 File Offset: 0x00017CE8
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x060021E3 RID: 8675 RVA: 0x000899F4 File Offset: 0x00087BF4
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x060021E4 RID: 8676 RVA: 0x00089A58 File Offset: 0x00087C58
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							if (sourceType == 0)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == 1 || sourceType == 100)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x060021E5 RID: 8677 RVA: 0x00089AE0 File Offset: 0x00087CE0
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XboxOne_Base.Elements elements = new HardwareJoystickMap.Platform_XboxOne_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x060021E6 RID: 8678 RVA: 0x00089AFC File Offset: 0x00087CFC
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XboxOne_Base.Elements elements = destination as HardwareJoystickMap.Platform_XboxOne_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_XboxOne_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_XboxOne_Base.Button>(this.buttons);
				}

				// Token: 0x0400136F RID: 4975
				public HardwareJoystickMap.Platform_XboxOne_Base.Axis[] axes;

				// Token: 0x04001370 RID: 4976
				public HardwareJoystickMap.Platform_XboxOne_Base.Button[] buttons;
			}

			// Token: 0x0200031D RID: 797
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x060021E8 RID: 8680 RVA: 0x00089B40 File Offset: 0x00087D40
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XboxOne_Base.Button button = new HardwareJoystickMap.Platform_XboxOne_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x060021E9 RID: 8681 RVA: 0x00019AFC File Offset: 0x00017CFC
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XboxOne_Base.Button button = destination as HardwareJoystickMap.Platform_XboxOne_Base.Button;
				}
			}

			// Token: 0x0200031E RID: 798
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x060021EB RID: 8683 RVA: 0x00089B5C File Offset: 0x00087D5C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_XboxOne_Base.Axis axis = new HardwareJoystickMap.Platform_XboxOne_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x060021EC RID: 8684 RVA: 0x00019B0C File Offset: 0x00017D0C
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_XboxOne_Base.Axis axis = destination as HardwareJoystickMap.Platform_XboxOne_Base.Axis;
				}
			}
		}

		// Token: 0x02000321 RID: 801
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_XboxOne : HardwareJoystickMap.Platform_XboxOne_Base
		{
			// Token: 0x060021FE RID: 8702 RVA: 0x00019B70 File Offset: 0x00017D70
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060021FF RID: 8703 RVA: 0x00089D38 File Offset: 0x00087F38
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002200 RID: 8704 RVA: 0x00089D94 File Offset: 0x00087F94
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_XboxOne platform_XboxOne = new HardwareJoystickMap.Platform_XboxOne();
				this.CopyVars(platform_XboxOne);
				return platform_XboxOne;
			}

			// Token: 0x06002201 RID: 8705 RVA: 0x00089DB0 File Offset: 0x00087FB0
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_XboxOne platform_XboxOne = destination as HardwareJoystickMap.Platform_XboxOne;
				if (platform_XboxOne == null)
				{
					return;
				}
				platform_XboxOne.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_XboxOne_Base>(this.variants);
			}

			// Token: 0x0400137B RID: 4987
			public HardwareJoystickMap.Platform_XboxOne_Base[] variants;
		}

		// Token: 0x02000322 RID: 802
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_PS4_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x170007BF RID: 1983
			// (get) Token: 0x06002203 RID: 8707 RVA: 0x00019B80 File Offset: 0x00017D80
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x170007C0 RID: 1984
			// (get) Token: 0x06002204 RID: 8708 RVA: 0x00019B97 File Offset: 0x00017D97
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x170007C1 RID: 1985
			// (get) Token: 0x06002205 RID: 8709 RVA: 0x00019BAE File Offset: 0x00017DAE
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.PS4;
				}
			}

			// Token: 0x170007C2 RID: 1986
			// (get) Token: 0x06002206 RID: 8710 RVA: 0x00089DE0 File Offset: 0x00087FE0
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_PS4_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x170007C3 RID: 1987
			// (get) Token: 0x06002207 RID: 8711 RVA: 0x00089E2C File Offset: 0x0008802C
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_PS4_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x170007C4 RID: 1988
			// (get) Token: 0x06002208 RID: 8712 RVA: 0x00019BB2 File Offset: 0x00017DB2
			internal HardwareJoystickMap.Platform_PS4_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x170007C5 RID: 1989
			// (get) Token: 0x06002209 RID: 8713 RVA: 0x00019BC9 File Offset: 0x00017DC9
			internal HardwareJoystickMap.Platform_PS4_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x170007C6 RID: 1990
			// (get) Token: 0x0600220A RID: 8714 RVA: 0x00019BE0 File Offset: 0x00017DE0
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x170007C7 RID: 1991
			// (get) Token: 0x0600220B RID: 8715 RVA: 0x00019C0E File Offset: 0x00017E0E
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x170007C8 RID: 1992
			// (get) Token: 0x0600220C RID: 8716 RVA: 0x00019C25 File Offset: 0x00017E25
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x170007C9 RID: 1993
			// (get) Token: 0x0600220D RID: 8717 RVA: 0x00019C46 File Offset: 0x00017E46
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x0600220E RID: 8718 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x0600220F RID: 8719 RVA: 0x00019C4E File Offset: 0x00017E4E
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06002210 RID: 8720 RVA: 0x00019C75 File Offset: 0x00017E75
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002211 RID: 8721 RVA: 0x00019C85 File Offset: 0x00017E85
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002212 RID: 8722 RVA: 0x00089E78 File Offset: 0x00088078
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_PS4_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_PS4_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002213 RID: 8723 RVA: 0x00089F18 File Offset: 0x00088118
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_PS4_Base.Button button2 = (HardwareJoystickMap.Platform_PS4_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_PS4_Base.Axis axis2 = (HardwareJoystickMap.Platform_PS4_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06002214 RID: 8724 RVA: 0x00089FDC File Offset: 0x000881DC
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_PS4_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002215 RID: 8725 RVA: 0x0008A0E8 File Offset: 0x000882E8
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002216 RID: 8726 RVA: 0x0008A19C File Offset: 0x0008839C
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06002217 RID: 8727 RVA: 0x00019C95 File Offset: 0x00017E95
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002218 RID: 8728 RVA: 0x00019CAD File Offset: 0x00017EAD
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002219 RID: 8729 RVA: 0x0008A1F0 File Offset: 0x000883F0
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_PS4_Base platform_PS4_Base = new HardwareJoystickMap.Platform_PS4_Base();
				this.CopyVars(platform_PS4_Base);
				return platform_PS4_Base;
			}

			// Token: 0x0600221A RID: 8730 RVA: 0x0008A20C File Offset: 0x0008840C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_PS4_Base platform_PS4_Base = destination as HardwareJoystickMap.Platform_PS4_Base;
				if (platform_PS4_Base == null)
				{
					return;
				}
				platform_PS4_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS4_Base.MatchingCriteria>(this.matchingCriteria);
				platform_PS4_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS4_Base.Elements>(this.elements);
			}

			// Token: 0x0400137C RID: 4988
			public HardwareJoystickMap.Platform_PS4_Base.MatchingCriteria matchingCriteria;

			// Token: 0x0400137D RID: 4989
			public HardwareJoystickMap.Platform_PS4_Base.Elements elements;

			// Token: 0x0400137E RID: 4990
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x0400137F RID: 4991
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x02000323 RID: 803
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x170007CA RID: 1994
				// (get) Token: 0x0600221C RID: 8732 RVA: 0x00019CC9 File Offset: 0x00017EC9
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0);
					}
				}

				// Token: 0x170007CB RID: 1995
				// (get) Token: 0x0600221D RID: 8733 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x0600221E RID: 8734 RVA: 0x0008A250 File Offset: 0x00088450
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (this.productName != null)
					{
						for (int i = 0; i < this.productName.Length; i++)
						{
							string searchFor = this.productName[i];
							if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, this.productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				// Token: 0x0600221F RID: 8735 RVA: 0x0008A2DC File Offset: 0x000884DC
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS4_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_PS4_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002220 RID: 8736 RVA: 0x0008A2F8 File Offset: 0x000884F8
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS4_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_PS4_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
				}

				// Token: 0x04001380 RID: 4992
				public bool productName_useRegex;

				// Token: 0x04001381 RID: 4993
				public string[] productName;
			}

			// Token: 0x02000324 RID: 804
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x170007CC RID: 1996
				// (get) Token: 0x06002222 RID: 8738 RVA: 0x00019CE9 File Offset: 0x00017EE9
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x170007CD RID: 1997
				// (get) Token: 0x06002223 RID: 8739 RVA: 0x00019CFD File Offset: 0x00017EFD
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06002224 RID: 8740 RVA: 0x0008A334 File Offset: 0x00088534
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002225 RID: 8741 RVA: 0x0008A398 File Offset: 0x00088598
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							if (sourceType == 0)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == 1 || sourceType == 100)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06002226 RID: 8742 RVA: 0x0008A420 File Offset: 0x00088620
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS4_Base.Elements elements = new HardwareJoystickMap.Platform_PS4_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002227 RID: 8743 RVA: 0x0008A43C File Offset: 0x0008863C
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS4_Base.Elements elements = destination as HardwareJoystickMap.Platform_PS4_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_PS4_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_PS4_Base.Button>(this.buttons);
				}

				// Token: 0x04001382 RID: 4994
				public HardwareJoystickMap.Platform_PS4_Base.Axis[] axes;

				// Token: 0x04001383 RID: 4995
				public HardwareJoystickMap.Platform_PS4_Base.Button[] buttons;
			}

			// Token: 0x02000325 RID: 805
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x06002229 RID: 8745 RVA: 0x0008A480 File Offset: 0x00088680
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS4_Base.Button button = new HardwareJoystickMap.Platform_PS4_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x0600222A RID: 8746 RVA: 0x00019D11 File Offset: 0x00017F11
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS4_Base.Button button = destination as HardwareJoystickMap.Platform_PS4_Base.Button;
				}
			}

			// Token: 0x02000326 RID: 806
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x0600222C RID: 8748 RVA: 0x0008A49C File Offset: 0x0008869C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS4_Base.Axis axis = new HardwareJoystickMap.Platform_PS4_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x0600222D RID: 8749 RVA: 0x00019D21 File Offset: 0x00017F21
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS4_Base.Axis axis = destination as HardwareJoystickMap.Platform_PS4_Base.Axis;
				}
			}
		}

		// Token: 0x02000329 RID: 809
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_PS4 : HardwareJoystickMap.Platform_PS4_Base
		{
			// Token: 0x0600223F RID: 8767 RVA: 0x00019D85 File Offset: 0x00017F85
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002240 RID: 8768 RVA: 0x0008A678 File Offset: 0x00088878
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002241 RID: 8769 RVA: 0x0008A6D4 File Offset: 0x000888D4
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_PS4 platform_PS = new HardwareJoystickMap.Platform_PS4();
				this.CopyVars(platform_PS);
				return platform_PS;
			}

			// Token: 0x06002242 RID: 8770 RVA: 0x0008A6F0 File Offset: 0x000888F0
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_PS4 platform_PS = destination as HardwareJoystickMap.Platform_PS4;
				if (platform_PS == null)
				{
					return;
				}
				platform_PS.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS4_Base>(this.variants);
			}

			// Token: 0x0400138E RID: 5006
			public HardwareJoystickMap.Platform_PS4_Base[] variants;
		}

		// Token: 0x0200032A RID: 810
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_NintendoSwitch_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x170007D2 RID: 2002
			// (get) Token: 0x06002244 RID: 8772 RVA: 0x00019D95 File Offset: 0x00017F95
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x170007D3 RID: 2003
			// (get) Token: 0x06002245 RID: 8773 RVA: 0x00019DAC File Offset: 0x00017FAC
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x170007D4 RID: 2004
			// (get) Token: 0x06002246 RID: 8774 RVA: 0x00019DC3 File Offset: 0x00017FC3
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.NintendoSwitch;
				}
			}

			// Token: 0x170007D5 RID: 2005
			// (get) Token: 0x06002247 RID: 8775 RVA: 0x0008A720 File Offset: 0x00088920
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x170007D6 RID: 2006
			// (get) Token: 0x06002248 RID: 8776 RVA: 0x0008A76C File Offset: 0x0008896C
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_NintendoSwitch_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x170007D7 RID: 2007
			// (get) Token: 0x06002249 RID: 8777 RVA: 0x00019DC7 File Offset: 0x00017FC7
			internal HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x170007D8 RID: 2008
			// (get) Token: 0x0600224A RID: 8778 RVA: 0x00019DDE File Offset: 0x00017FDE
			internal HardwareJoystickMap.Platform_NintendoSwitch_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x170007D9 RID: 2009
			// (get) Token: 0x0600224B RID: 8779 RVA: 0x00019DF5 File Offset: 0x00017FF5
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x170007DA RID: 2010
			// (get) Token: 0x0600224C RID: 8780 RVA: 0x00019E23 File Offset: 0x00018023
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x170007DB RID: 2011
			// (get) Token: 0x0600224D RID: 8781 RVA: 0x00019E3A File Offset: 0x0001803A
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x170007DC RID: 2012
			// (get) Token: 0x0600224E RID: 8782 RVA: 0x00019E5B File Offset: 0x0001805B
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x0600224F RID: 8783 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002250 RID: 8784 RVA: 0x00019E63 File Offset: 0x00018063
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06002251 RID: 8785 RVA: 0x00019E8A File Offset: 0x0001808A
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002252 RID: 8786 RVA: 0x00019E9A File Offset: 0x0001809A
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002253 RID: 8787 RVA: 0x0008A7B8 File Offset: 0x000889B8
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_NintendoSwitch_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002254 RID: 8788 RVA: 0x0008A858 File Offset: 0x00088A58
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Button button2 = (HardwareJoystickMap.Platform_NintendoSwitch_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis axis2 = (HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06002255 RID: 8789 RVA: 0x0008A91C File Offset: 0x00088B1C
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002256 RID: 8790 RVA: 0x0008AA28 File Offset: 0x00088C28
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002257 RID: 8791 RVA: 0x0008AADC File Offset: 0x00088CDC
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06002258 RID: 8792 RVA: 0x00019EAA File Offset: 0x000180AA
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002259 RID: 8793 RVA: 0x00019EC2 File Offset: 0x000180C2
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x0600225A RID: 8794 RVA: 0x0008AB30 File Offset: 0x00088D30
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = new HardwareJoystickMap.Platform_NintendoSwitch_Base();
				this.CopyVars(platform_NintendoSwitch_Base);
				return platform_NintendoSwitch_Base;
			}

			// Token: 0x0600225B RID: 8795 RVA: 0x0008AB4C File Offset: 0x00088D4C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = destination as HardwareJoystickMap.Platform_NintendoSwitch_Base;
				if (platform_NintendoSwitch_Base == null)
				{
					return;
				}
				platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_NintendoSwitch_Base.MatchingCriteria>(this.matchingCriteria);
				platform_NintendoSwitch_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_NintendoSwitch_Base.Elements>(this.elements);
			}

			// Token: 0x0400138F RID: 5007
			public HardwareJoystickMap.Platform_NintendoSwitch_Base.MatchingCriteria matchingCriteria;

			// Token: 0x04001390 RID: 5008
			public HardwareJoystickMap.Platform_NintendoSwitch_Base.Elements elements;

			// Token: 0x04001391 RID: 5009
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x04001392 RID: 5010
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x0200032B RID: 811
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x170007DD RID: 2013
				// (get) Token: 0x0600225D RID: 8797 RVA: 0x00019EDE File Offset: 0x000180DE
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0);
					}
				}

				// Token: 0x170007DE RID: 2014
				// (get) Token: 0x0600225E RID: 8798 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x0600225F RID: 8799 RVA: 0x0008AB90 File Offset: 0x00088D90
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (this.productName != null)
					{
						for (int i = 0; i < this.productName.Length; i++)
						{
							string searchFor = this.productName[i];
							if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, this.productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				// Token: 0x06002260 RID: 8800 RVA: 0x0008AC1C File Offset: 0x00088E1C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_NintendoSwitch_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_NintendoSwitch_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002261 RID: 8801 RVA: 0x0008AC38 File Offset: 0x00088E38
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_NintendoSwitch_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_NintendoSwitch_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
				}

				// Token: 0x04001393 RID: 5011
				public bool productName_useRegex;

				// Token: 0x04001394 RID: 5012
				public string[] productName;
			}

			// Token: 0x0200032C RID: 812
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x170007DF RID: 2015
				// (get) Token: 0x06002263 RID: 8803 RVA: 0x00019EFE File Offset: 0x000180FE
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x170007E0 RID: 2016
				// (get) Token: 0x06002264 RID: 8804 RVA: 0x00019F12 File Offset: 0x00018112
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06002265 RID: 8805 RVA: 0x0008AC74 File Offset: 0x00088E74
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002266 RID: 8806 RVA: 0x0008ACD8 File Offset: 0x00088ED8
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							if (sourceType == 0)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == 1 || sourceType == 100)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06002267 RID: 8807 RVA: 0x0008AD60 File Offset: 0x00088F60
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Elements elements = new HardwareJoystickMap.Platform_NintendoSwitch_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002268 RID: 8808 RVA: 0x0008AD7C File Offset: 0x00088F7C
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Elements elements = destination as HardwareJoystickMap.Platform_NintendoSwitch_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_NintendoSwitch_Base.Button>(this.buttons);
				}

				// Token: 0x04001395 RID: 5013
				public HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis[] axes;

				// Token: 0x04001396 RID: 5014
				public HardwareJoystickMap.Platform_NintendoSwitch_Base.Button[] buttons;
			}

			// Token: 0x0200032D RID: 813
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x0600226A RID: 8810 RVA: 0x0008ADC0 File Offset: 0x00088FC0
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Button button = new HardwareJoystickMap.Platform_NintendoSwitch_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x0600226B RID: 8811 RVA: 0x00019F26 File Offset: 0x00018126
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Button button = destination as HardwareJoystickMap.Platform_NintendoSwitch_Base.Button;
				}
			}

			// Token: 0x0200032E RID: 814
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x0600226D RID: 8813 RVA: 0x0008ADDC File Offset: 0x00088FDC
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis axis = new HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x0600226E RID: 8814 RVA: 0x00019F36 File Offset: 0x00018136
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis axis = destination as HardwareJoystickMap.Platform_NintendoSwitch_Base.Axis;
				}
			}
		}

		// Token: 0x02000331 RID: 817
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_NintendoSwitch : HardwareJoystickMap.Platform_NintendoSwitch_Base
		{
			// Token: 0x06002280 RID: 8832 RVA: 0x00019F9A File Offset: 0x0001819A
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002281 RID: 8833 RVA: 0x0008AFB8 File Offset: 0x000891B8
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002282 RID: 8834 RVA: 0x0008B014 File Offset: 0x00089214
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_NintendoSwitch platform_NintendoSwitch = new HardwareJoystickMap.Platform_NintendoSwitch();
				this.CopyVars(platform_NintendoSwitch);
				return platform_NintendoSwitch;
			}

			// Token: 0x06002283 RID: 8835 RVA: 0x0008B030 File Offset: 0x00089230
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_NintendoSwitch platform_NintendoSwitch = destination as HardwareJoystickMap.Platform_NintendoSwitch;
				if (platform_NintendoSwitch == null)
				{
					return;
				}
				platform_NintendoSwitch.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_NintendoSwitch_Base>(this.variants);
			}

			// Token: 0x040013A1 RID: 5025
			public HardwareJoystickMap.Platform_NintendoSwitch_Base[] variants;
		}

		// Token: 0x02000332 RID: 818
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_GameCore_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x170007E5 RID: 2021
			// (get) Token: 0x06002285 RID: 8837 RVA: 0x00019FAA File Offset: 0x000181AA
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x170007E6 RID: 2022
			// (get) Token: 0x06002286 RID: 8838 RVA: 0x00019FC1 File Offset: 0x000181C1
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x170007E7 RID: 2023
			// (get) Token: 0x06002287 RID: 8839 RVA: 0x00019FD8 File Offset: 0x000181D8
			public override string controllerNameOverride
			{
				get
				{
					return this.controllerName;
				}
			}

			// Token: 0x170007E8 RID: 2024
			// (get) Token: 0x06002288 RID: 8840 RVA: 0x00019FE0 File Offset: 0x000181E0
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.GameCore;
				}
			}

			// Token: 0x170007E9 RID: 2025
			// (get) Token: 0x06002289 RID: 8841 RVA: 0x0008B060 File Offset: 0x00089260
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_GameCore_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x170007EA RID: 2026
			// (get) Token: 0x0600228A RID: 8842 RVA: 0x0008B0AC File Offset: 0x000892AC
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_GameCore_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x170007EB RID: 2027
			// (get) Token: 0x0600228B RID: 8843 RVA: 0x00019FE4 File Offset: 0x000181E4
			internal HardwareJoystickMap.Platform_GameCore_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x170007EC RID: 2028
			// (get) Token: 0x0600228C RID: 8844 RVA: 0x00019FFB File Offset: 0x000181FB
			internal HardwareJoystickMap.Platform_GameCore_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x170007ED RID: 2029
			// (get) Token: 0x0600228D RID: 8845 RVA: 0x0001A012 File Offset: 0x00018212
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x170007EE RID: 2030
			// (get) Token: 0x0600228E RID: 8846 RVA: 0x0001A040 File Offset: 0x00018240
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x170007EF RID: 2031
			// (get) Token: 0x0600228F RID: 8847 RVA: 0x0001A057 File Offset: 0x00018257
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x170007F0 RID: 2032
			// (get) Token: 0x06002290 RID: 8848 RVA: 0x0001A078 File Offset: 0x00018278
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002291 RID: 8849 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002292 RID: 8850 RVA: 0x0001A080 File Offset: 0x00018280
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06002293 RID: 8851 RVA: 0x0001A0A7 File Offset: 0x000182A7
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002294 RID: 8852 RVA: 0x0001A0B7 File Offset: 0x000182B7
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002295 RID: 8853 RVA: 0x0008B0F8 File Offset: 0x000892F8
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_GameCore_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_GameCore_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002296 RID: 8854 RVA: 0x0008B198 File Offset: 0x00089398
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_GameCore_Base.Button button2 = (HardwareJoystickMap.Platform_GameCore_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_GameCore_Base.Axis axis2 = (HardwareJoystickMap.Platform_GameCore_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x06002297 RID: 8855 RVA: 0x0008B25C File Offset: 0x0008945C
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_GameCore_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002298 RID: 8856 RVA: 0x0008B374 File Offset: 0x00089574
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0 && this.Axes_orig[i].sourceType != 2)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002299 RID: 8857 RVA: 0x0008B43C File Offset: 0x0008963C
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x0600229A RID: 8858 RVA: 0x0001A0C7 File Offset: 0x000182C7
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x0600229B RID: 8859 RVA: 0x0001A0DF File Offset: 0x000182DF
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x0600229C RID: 8860 RVA: 0x0008B490 File Offset: 0x00089690
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_GameCore_Base platform_GameCore_Base = new HardwareJoystickMap.Platform_GameCore_Base();
				this.CopyVars(platform_GameCore_Base);
				return platform_GameCore_Base;
			}

			// Token: 0x0600229D RID: 8861 RVA: 0x0008B4AC File Offset: 0x000896AC
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_GameCore_Base platform_GameCore_Base = destination as HardwareJoystickMap.Platform_GameCore_Base;
				if (platform_GameCore_Base == null)
				{
					return;
				}
				platform_GameCore_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria>(this.matchingCriteria);
				platform_GameCore_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_GameCore_Base.Elements>(this.elements);
				platform_GameCore_Base.controllerName = this.controllerName;
			}

			// Token: 0x040013A2 RID: 5026
			public HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria matchingCriteria;

			// Token: 0x040013A3 RID: 5027
			public HardwareJoystickMap.Platform_GameCore_Base.Elements elements;

			// Token: 0x040013A4 RID: 5028
			public string controllerName;

			// Token: 0x040013A5 RID: 5029
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x040013A6 RID: 5030
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x02000333 RID: 819
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x170007F1 RID: 2033
				// (get) Token: 0x0600229F RID: 8863 RVA: 0x0001A0FB File Offset: 0x000182FB
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0) || this.deviceType != HardwareJoystickMap.Platform_GameCore_Base.DeviceType.None || (this.vidPid != null && this.vidPid.Length != 0);
					}
				}

				// Token: 0x170007F2 RID: 2034
				// (get) Token: 0x060022A0 RID: 8864 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x060022A1 RID: 8865 RVA: 0x0001A138 File Offset: 0x00018338
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (this.hatCount < 0 || this.hatCount == bridgedControllerHWInfo.hardwareHatCount);
				}

				// Token: 0x060022A2 RID: 8866 RVA: 0x0008B4FC File Offset: 0x000896FC
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					bool flag;
					if (!this.ElementCountsMatch(bridgedControllerHWInfo, out flag))
					{
						return false;
					}
					if (this.deviceType != HardwareJoystickMap.Platform_GameCore_Base.DeviceType.None)
					{
						if (this.deviceType != (HardwareJoystickMap.Platform_GameCore_Base.DeviceType)bridgedControllerHWInfo.deviceType)
						{
							return false;
						}
						if (this.deviceType == HardwareJoystickMap.Platform_GameCore_Base.DeviceType.Gamepad && this.gamepadSubType != HardwareJoystickMap.Platform_GameCore_Base.GamepadSubType.None && this.gamepadSubType != (HardwareJoystickMap.Platform_GameCore_Base.GamepadSubType)bridgedControllerHWInfo.hw_xInputSubType)
						{
							return false;
						}
						if (!this.HasProductName() && (this.vidPid == null || this.vidPid.Length == 0))
						{
							return true;
						}
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (this.vidPid != null)
						{
							for (int i = 0; i < this.vidPid.Length; i++)
							{
								int vendorId = this.vidPid[i].vendorId;
								int productId = this.vidPid[i].productId;
								if (ArrayTools.Contains<int>(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = (bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName;
									if (!this.ProductNameMatches(name))
									{
										return false;
									}
								}
								if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
								{
									return true;
								}
							}
						}
						return false;
					}
					return this.ProductNameMatches(text);
				}

				// Token: 0x060022A3 RID: 8867 RVA: 0x0008B648 File Offset: 0x00089848
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x060022A4 RID: 8868 RVA: 0x0008B664 File Offset: 0x00089864
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.deviceType = this.deviceType;
					matchingCriteria.gamepadSubType = this.gamepadSubType;
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.vidPid = ArrayTools.ShallowCopy<HardwareJoystickMap.VidPid>(this.vidPid);
				}

				// Token: 0x060022A5 RID: 8869 RVA: 0x0008B6D8 File Offset: 0x000898D8
				private bool HasProductName()
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(this.productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x060022A6 RID: 8870 RVA: 0x0008B714 File Offset: 0x00089914
				private bool ProductNameMatches(string name)
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						string searchFor = this.productName[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(name, searchFor, this.productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x040013A7 RID: 5031
				public bool productName_useRegex;

				// Token: 0x040013A8 RID: 5032
				public string[] productName;

				// Token: 0x040013A9 RID: 5033
				public HardwareJoystickMap.VidPid[] vidPid;

				// Token: 0x040013AA RID: 5034
				public HardwareJoystickMap.Platform_GameCore_Base.DeviceType deviceType;

				// Token: 0x040013AB RID: 5035
				public HardwareJoystickMap.Platform_GameCore_Base.GamepadSubType gamepadSubType;

				// Token: 0x040013AC RID: 5036
				public int hatCount;
			}

			// Token: 0x02000334 RID: 820
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x170007F3 RID: 2035
				// (get) Token: 0x060022A8 RID: 8872 RVA: 0x0001A15F File Offset: 0x0001835F
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x170007F4 RID: 2036
				// (get) Token: 0x060022A9 RID: 8873 RVA: 0x0001A173 File Offset: 0x00018373
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x060022AA RID: 8874 RVA: 0x0008B75C File Offset: 0x0008995C
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x060022AB RID: 8875 RVA: 0x0008B7C0 File Offset: 0x000899C0
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case 0:
								axisRange = AxisRange.Positive;
								return true;
							case 1:
								break;
							case 2:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != 100)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x060022AC RID: 8876 RVA: 0x0008B884 File Offset: 0x00089A84
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_GameCore_Base.Elements elements = new HardwareJoystickMap.Platform_GameCore_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x060022AD RID: 8877 RVA: 0x0008B8A0 File Offset: 0x00089AA0
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_GameCore_Base.Elements elements = destination as HardwareJoystickMap.Platform_GameCore_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_GameCore_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_GameCore_Base.Button>(this.buttons);
				}

				// Token: 0x040013AD RID: 5037
				public HardwareJoystickMap.Platform_GameCore_Base.Axis[] axes;

				// Token: 0x040013AE RID: 5038
				public HardwareJoystickMap.Platform_GameCore_Base.Button[] buttons;
			}

			// Token: 0x02000335 RID: 821
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x060022AF RID: 8879 RVA: 0x0008B8E4 File Offset: 0x00089AE4
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_GameCore_Base.Button button = new HardwareJoystickMap.Platform_GameCore_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x060022B0 RID: 8880 RVA: 0x0008B900 File Offset: 0x00089B00
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_GameCore_Base.Button button = destination as HardwareJoystickMap.Platform_GameCore_Base.Button;
					if (button == null)
					{
						return;
					}
					button.sourceHat = this.sourceHat;
					button.sourceHatDirection = this.sourceHatDirection;
					button.sourceHatType = this.sourceHatType;
				}

				// Token: 0x040013AF RID: 5039
				public int sourceHat;

				// Token: 0x040013B0 RID: 5040
				public HatDirection sourceHatDirection;

				// Token: 0x040013B1 RID: 5041
				public HatType sourceHatType;
			}

			// Token: 0x02000336 RID: 822
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x060022B2 RID: 8882 RVA: 0x0008B944 File Offset: 0x00089B44
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_GameCore_Base.Axis axis = new HardwareJoystickMap.Platform_GameCore_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x060022B3 RID: 8883 RVA: 0x0008B960 File Offset: 0x00089B60
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_GameCore_Base.Axis axis = destination as HardwareJoystickMap.Platform_GameCore_Base.Axis;
					if (axis == null)
					{
						return;
					}
					axis.sourceHat = this.sourceHat;
					axis.sourceHatDirection = this.sourceHatDirection;
					axis.sourceHatType = this.sourceHatType;
					axis.sourceHatRange = this.sourceHatRange;
				}

				// Token: 0x040013B2 RID: 5042
				public int sourceHat;

				// Token: 0x040013B3 RID: 5043
				public AxisDirection sourceHatDirection;

				// Token: 0x040013B4 RID: 5044
				public HatType sourceHatType;

				// Token: 0x040013B5 RID: 5045
				public AxisRange sourceHatRange;
			}

			// Token: 0x02000337 RID: 823
			public enum DeviceType
			{
				// Token: 0x040013B7 RID: 5047
				None,
				// Token: 0x040013B8 RID: 5048
				Gamepad,
				// Token: 0x040013B9 RID: 5049
				ArcadeStick,
				// Token: 0x040013BA RID: 5050
				FlightStick,
				// Token: 0x040013BB RID: 5051
				RacingWheel,
				// Token: 0x040013BC RID: 5052
				Raw = 6
			}

			// Token: 0x02000338 RID: 824
			public enum GamepadSubType
			{
				// Token: 0x040013BE RID: 5054
				None,
				// Token: 0x040013BF RID: 5055
				Xbox360,
				// Token: 0x040013C0 RID: 5056
				XboxOne,
				// Token: 0x040013C1 RID: 5057
				DualShock,
				// Token: 0x040013C2 RID: 5058
				NintendoProController,
				// Token: 0x040013C3 RID: 5059
				Unknown = 1000
			}
		}

		// Token: 0x0200033B RID: 827
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_GameCore : HardwareJoystickMap.Platform_GameCore_Base
		{
			// Token: 0x060022C5 RID: 8901 RVA: 0x0001A1DB File Offset: 0x000183DB
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060022C6 RID: 8902 RVA: 0x0008BB70 File Offset: 0x00089D70
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060022C7 RID: 8903 RVA: 0x0008BBCC File Offset: 0x00089DCC
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_GameCore platform_GameCore = new HardwareJoystickMap.Platform_GameCore();
				this.CopyVars(platform_GameCore);
				return platform_GameCore;
			}

			// Token: 0x060022C8 RID: 8904 RVA: 0x0008BBE8 File Offset: 0x00089DE8
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_GameCore platform_GameCore = destination as HardwareJoystickMap.Platform_GameCore;
				if (platform_GameCore == null)
				{
					return;
				}
				platform_GameCore.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_GameCore_Base>(this.variants);
			}

			// Token: 0x060022C9 RID: 8905 RVA: 0x0008BC18 File Offset: 0x00089E18
			internal static HardwareJoystickMap.Platform_GameCore CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				HardwareJoystickMap.Platform_GameCore platform_GameCore = new HardwareJoystickMap.Platform_GameCore();
				ControllerElementIdentifier[] unknownJoystickElementIdentifiers_orig = Consts.unknownJoystickElementIdentifiers_orig;
				platform_GameCore.controllerName = "Unknown Controller";
				platform_GameCore.description = "";
				HardwareJoystickMap.Platform_GameCore_Base.Elements elements = new HardwareJoystickMap.Platform_GameCore_Base.Elements();
				platform_GameCore.elements = elements;
				int num = 32;
				elements.axes = new HardwareJoystickMap.Platform_GameCore_Base.Axis[num];
				for (int i = 0; i < num; i++)
				{
					HardwareJoystickMap.Platform_GameCore_Base.Axis axis = new HardwareJoystickMap.Platform_GameCore_Base.Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = false;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				int num3 = 2 * 8;
				elements.buttons = new HardwareJoystickMap.Platform_GameCore_Base.Button[num2 + num3];
				for (int j = 0; j < num2; j++)
				{
					HardwareJoystickMap.Platform_GameCore_Base.Button button = new HardwareJoystickMap.Platform_GameCore_Base.Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				int num4 = num2;
				int num5 = 160;
				int num6 = 224;
				for (int k = 0; k < 2; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						bool flag = l % 2 == 0;
						HardwareJoystickMap.Platform_GameCore_Base.Button button2 = new HardwareJoystickMap.Platform_GameCore_Base.Button();
						elements.buttons[num4++] = button2;
						button2.buttonInfo = new HardwareButtonInfo(false, false);
						HardwareJoystickMap.Platform_Custom.Element element = button2;
						int elementIdentifier;
						if (!flag)
						{
							num6 = (elementIdentifier = num6) + 1;
						}
						else
						{
							num5 = (elementIdentifier = num5) + 1;
						}
						element.elementIdentifier = elementIdentifier;
						button2.sourceHat = k;
						button2.sourceType = 2;
						button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
					}
				}
				HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_GameCore_Base.MatchingCriteria();
				platform_GameCore.matchingCriteria = matchingCriteria;
				platform_GameCore.variants = new HardwareJoystickMap.Platform_GameCore_Base[0];
				return platform_GameCore;
			}

			// Token: 0x040013CE RID: 5070
			public HardwareJoystickMap.Platform_GameCore_Base[] variants;
		}

		// Token: 0x0200033C RID: 828
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_PS5_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x170007F9 RID: 2041
			// (get) Token: 0x060022CB RID: 8907 RVA: 0x0001A1EB File Offset: 0x000183EB
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x170007FA RID: 2042
			// (get) Token: 0x060022CC RID: 8908 RVA: 0x0001A202 File Offset: 0x00018402
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x170007FB RID: 2043
			// (get) Token: 0x060022CD RID: 8909 RVA: 0x0001A219 File Offset: 0x00018419
			public override string controllerNameOverride
			{
				get
				{
					return this.controllerName;
				}
			}

			// Token: 0x170007FC RID: 2044
			// (get) Token: 0x060022CE RID: 8910 RVA: 0x0001A221 File Offset: 0x00018421
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.PS5;
				}
			}

			// Token: 0x170007FD RID: 2045
			// (get) Token: 0x060022CF RID: 8911 RVA: 0x0008BE2C File Offset: 0x0008A02C
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_PS5_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x170007FE RID: 2046
			// (get) Token: 0x060022D0 RID: 8912 RVA: 0x0008BE78 File Offset: 0x0008A078
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_PS5_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x170007FF RID: 2047
			// (get) Token: 0x060022D1 RID: 8913 RVA: 0x0001A225 File Offset: 0x00018425
			internal HardwareJoystickMap.Platform_PS5_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000800 RID: 2048
			// (get) Token: 0x060022D2 RID: 8914 RVA: 0x0001A23C File Offset: 0x0001843C
			internal HardwareJoystickMap.Platform_PS5_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x17000801 RID: 2049
			// (get) Token: 0x060022D3 RID: 8915 RVA: 0x0001A253 File Offset: 0x00018453
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x17000802 RID: 2050
			// (get) Token: 0x060022D4 RID: 8916 RVA: 0x0001A281 File Offset: 0x00018481
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000803 RID: 2051
			// (get) Token: 0x060022D5 RID: 8917 RVA: 0x0001A298 File Offset: 0x00018498
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000804 RID: 2052
			// (get) Token: 0x060022D6 RID: 8918 RVA: 0x0001A2B9 File Offset: 0x000184B9
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x060022D7 RID: 8919 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x060022D8 RID: 8920 RVA: 0x0001A2C1 File Offset: 0x000184C1
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x060022D9 RID: 8921 RVA: 0x0001A2E8 File Offset: 0x000184E8
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060022DA RID: 8922 RVA: 0x0001A2F8 File Offset: 0x000184F8
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060022DB RID: 8923 RVA: 0x0008BEC4 File Offset: 0x0008A0C4
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_PS5_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_PS5_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060022DC RID: 8924 RVA: 0x0008BF64 File Offset: 0x0008A164
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_PS5_Base.Button button2 = (HardwareJoystickMap.Platform_PS5_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_PS5_Base.Axis axis2 = (HardwareJoystickMap.Platform_PS5_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x060022DD RID: 8925 RVA: 0x0008C028 File Offset: 0x0008A228
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_PS5_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x060022DE RID: 8926 RVA: 0x0008C134 File Offset: 0x0008A334
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x060022DF RID: 8927 RVA: 0x0008C1E8 File Offset: 0x0008A3E8
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x060022E0 RID: 8928 RVA: 0x0001A308 File Offset: 0x00018508
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x060022E1 RID: 8929 RVA: 0x0001A320 File Offset: 0x00018520
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x060022E2 RID: 8930 RVA: 0x0008C23C File Offset: 0x0008A43C
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_PS5_Base platform_PS5_Base = new HardwareJoystickMap.Platform_PS5_Base();
				this.CopyVars(platform_PS5_Base);
				return platform_PS5_Base;
			}

			// Token: 0x060022E3 RID: 8931 RVA: 0x0008C258 File Offset: 0x0008A458
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_PS5_Base platform_PS5_Base = destination as HardwareJoystickMap.Platform_PS5_Base;
				if (platform_PS5_Base == null)
				{
					return;
				}
				platform_PS5_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS5_Base.MatchingCriteria>(this.matchingCriteria);
				platform_PS5_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS5_Base.Elements>(this.elements);
				platform_PS5_Base.controllerName = this.controllerName;
			}

			// Token: 0x040013CF RID: 5071
			public HardwareJoystickMap.Platform_PS5_Base.MatchingCriteria matchingCriteria;

			// Token: 0x040013D0 RID: 5072
			public HardwareJoystickMap.Platform_PS5_Base.Elements elements;

			// Token: 0x040013D1 RID: 5073
			public string controllerName;

			// Token: 0x040013D2 RID: 5074
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x040013D3 RID: 5075
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x0200033D RID: 829
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x17000805 RID: 2053
				// (get) Token: 0x060022E5 RID: 8933 RVA: 0x0001A33C File Offset: 0x0001853C
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0);
					}
				}

				// Token: 0x17000806 RID: 2054
				// (get) Token: 0x060022E6 RID: 8934 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x060022E7 RID: 8935 RVA: 0x0008C2A8 File Offset: 0x0008A4A8
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (this.productName != null)
					{
						for (int i = 0; i < this.productName.Length; i++)
						{
							string searchFor = this.productName[i];
							if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, this.productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
				}

				// Token: 0x060022E8 RID: 8936 RVA: 0x0008C334 File Offset: 0x0008A534
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS5_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_PS5_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x060022E9 RID: 8937 RVA: 0x0008C350 File Offset: 0x0008A550
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS5_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_PS5_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
				}

				// Token: 0x040013D4 RID: 5076
				public bool productName_useRegex;

				// Token: 0x040013D5 RID: 5077
				public string[] productName;
			}

			// Token: 0x0200033E RID: 830
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x17000807 RID: 2055
				// (get) Token: 0x060022EB RID: 8939 RVA: 0x0001A35C File Offset: 0x0001855C
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x17000808 RID: 2056
				// (get) Token: 0x060022EC RID: 8940 RVA: 0x0001A370 File Offset: 0x00018570
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x060022ED RID: 8941 RVA: 0x0008C38C File Offset: 0x0008A58C
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x060022EE RID: 8942 RVA: 0x0008C3F0 File Offset: 0x0008A5F0
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							if (sourceType == 0)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == 1 || sourceType == 100)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x060022EF RID: 8943 RVA: 0x0008C478 File Offset: 0x0008A678
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS5_Base.Elements elements = new HardwareJoystickMap.Platform_PS5_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x060022F0 RID: 8944 RVA: 0x0008C494 File Offset: 0x0008A694
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS5_Base.Elements elements = destination as HardwareJoystickMap.Platform_PS5_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_PS5_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_PS5_Base.Button>(this.buttons);
				}

				// Token: 0x040013D6 RID: 5078
				public HardwareJoystickMap.Platform_PS5_Base.Axis[] axes;

				// Token: 0x040013D7 RID: 5079
				public HardwareJoystickMap.Platform_PS5_Base.Button[] buttons;
			}

			// Token: 0x0200033F RID: 831
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x060022F2 RID: 8946 RVA: 0x0008C4D8 File Offset: 0x0008A6D8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS5_Base.Button button = new HardwareJoystickMap.Platform_PS5_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x060022F3 RID: 8947 RVA: 0x0001A384 File Offset: 0x00018584
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS5_Base.Button button = destination as HardwareJoystickMap.Platform_PS5_Base.Button;
				}
			}

			// Token: 0x02000340 RID: 832
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x060022F5 RID: 8949 RVA: 0x0008C4F4 File Offset: 0x0008A6F4
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_PS5_Base.Axis axis = new HardwareJoystickMap.Platform_PS5_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x060022F6 RID: 8950 RVA: 0x0001A394 File Offset: 0x00018594
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_PS5_Base.Axis axis = destination as HardwareJoystickMap.Platform_PS5_Base.Axis;
				}
			}
		}

		// Token: 0x02000343 RID: 835
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_PS5 : HardwareJoystickMap.Platform_PS5_Base
		{
			// Token: 0x06002308 RID: 8968 RVA: 0x0001A3F8 File Offset: 0x000185F8
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002309 RID: 8969 RVA: 0x0008C6D0 File Offset: 0x0008A8D0
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600230A RID: 8970 RVA: 0x0008C72C File Offset: 0x0008A92C
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_PS5 platform_PS = new HardwareJoystickMap.Platform_PS5();
				this.CopyVars(platform_PS);
				return platform_PS;
			}

			// Token: 0x0600230B RID: 8971 RVA: 0x0008C748 File Offset: 0x0008A948
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_PS5 platform_PS = destination as HardwareJoystickMap.Platform_PS5;
				if (platform_PS == null)
				{
					return;
				}
				platform_PS.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_PS5_Base>(this.variants);
			}

			// Token: 0x040013E2 RID: 5090
			public HardwareJoystickMap.Platform_PS5_Base[] variants;
		}

		// Token: 0x02000344 RID: 836
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_InternalDriver_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x1700080D RID: 2061
			// (get) Token: 0x0600230D RID: 8973 RVA: 0x0001A408 File Offset: 0x00018608
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x1700080E RID: 2062
			// (get) Token: 0x0600230E RID: 8974 RVA: 0x0001A41F File Offset: 0x0001861F
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x1700080F RID: 2063
			// (get) Token: 0x0600230F RID: 8975 RVA: 0x0001A436 File Offset: 0x00018636
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.InternalDriver;
				}
			}

			// Token: 0x17000810 RID: 2064
			// (get) Token: 0x06002310 RID: 8976 RVA: 0x0008C778 File Offset: 0x0008A978
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x17000811 RID: 2065
			// (get) Token: 0x06002311 RID: 8977 RVA: 0x0008C7C4 File Offset: 0x0008A9C4
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x17000812 RID: 2066
			// (get) Token: 0x06002312 RID: 8978 RVA: 0x0001A43A File Offset: 0x0001863A
			internal HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000813 RID: 2067
			// (get) Token: 0x06002313 RID: 8979 RVA: 0x0001A451 File Offset: 0x00018651
			internal HardwareJoystickMap.Platform_InternalDriver_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x17000814 RID: 2068
			// (get) Token: 0x06002314 RID: 8980 RVA: 0x0001A468 File Offset: 0x00018668
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x17000815 RID: 2069
			// (get) Token: 0x06002315 RID: 8981 RVA: 0x0001A496 File Offset: 0x00018696
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000816 RID: 2070
			// (get) Token: 0x06002316 RID: 8982 RVA: 0x0001A4AD File Offset: 0x000186AD
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000817 RID: 2071
			// (get) Token: 0x06002317 RID: 8983 RVA: 0x0001A4CE File Offset: 0x000186CE
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002318 RID: 8984 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002319 RID: 8985 RVA: 0x0001A4D6 File Offset: 0x000186D6
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x0600231A RID: 8986 RVA: 0x0001A4FD File Offset: 0x000186FD
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x0600231B RID: 8987 RVA: 0x0001A50D File Offset: 0x0001870D
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x0600231C RID: 8988 RVA: 0x0008C810 File Offset: 0x0008AA10
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_InternalDriver_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_InternalDriver_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600231D RID: 8989 RVA: 0x0008C8B0 File Offset: 0x0008AAB0
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_InternalDriver_Base.Button button2 = (HardwareJoystickMap.Platform_InternalDriver_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_InternalDriver_Base.Axis axis2 = (HardwareJoystickMap.Platform_InternalDriver_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x0600231E RID: 8990 RVA: 0x0008C974 File Offset: 0x0008AB74
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x0600231F RID: 8991 RVA: 0x0008CA8C File Offset: 0x0008AC8C
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0 && this.Axes_orig[i].sourceType != 2)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002320 RID: 8992 RVA: 0x0008CB54 File Offset: 0x0008AD54
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06002321 RID: 8993 RVA: 0x0001A51D File Offset: 0x0001871D
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002322 RID: 8994 RVA: 0x0001A535 File Offset: 0x00018735
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002323 RID: 8995 RVA: 0x0008CBA8 File Offset: 0x0008ADA8
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = new HardwareJoystickMap.Platform_InternalDriver_Base();
				this.CopyVars(platform_InternalDriver_Base);
				return platform_InternalDriver_Base;
			}

			// Token: 0x06002324 RID: 8996 RVA: 0x0008CBC4 File Offset: 0x0008ADC4
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = destination as HardwareJoystickMap.Platform_InternalDriver_Base;
				if (platform_InternalDriver_Base == null)
				{
					return;
				}
				platform_InternalDriver_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_InternalDriver_Base.MatchingCriteria>(this.matchingCriteria);
				platform_InternalDriver_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_InternalDriver_Base.Elements>(this.elements);
			}

			// Token: 0x040013E3 RID: 5091
			public HardwareJoystickMap.Platform_InternalDriver_Base.MatchingCriteria matchingCriteria;

			// Token: 0x040013E4 RID: 5092
			public HardwareJoystickMap.Platform_InternalDriver_Base.Elements elements;

			// Token: 0x040013E5 RID: 5093
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x040013E6 RID: 5094
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x02000345 RID: 837
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x17000818 RID: 2072
				// (get) Token: 0x06002326 RID: 8998 RVA: 0x0001A551 File Offset: 0x00018751
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0) || (this.vidPid != null && this.vidPid.Length != 0);
					}
				}

				// Token: 0x17000819 RID: 2073
				// (get) Token: 0x06002327 RID: 8999 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x06002328 RID: 9000 RVA: 0x0008CC08 File Offset: 0x0008AE08
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					bool flag;
					if (!this.ElementCountsMatch(bridgedControllerHWInfo, out flag))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (this.vidPid != null)
						{
							for (int i = 0; i < this.vidPid.Length; i++)
							{
								int vendorId = this.vidPid[i].vendorId;
								int productId = this.vidPid[i].productId;
								if (ArrayTools.Contains<int>(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = (bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName;
									if (!this.ProductNameMatches(name))
									{
										return false;
									}
								}
								if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
								{
									return true;
								}
							}
						}
						return false;
					}
					return this.ProductNameMatches(text);
				}

				// Token: 0x06002329 RID: 9001 RVA: 0x0001A584 File Offset: 0x00018784
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (alternateMatched || this.hatCount < 0 || bridgedControllerHWInfo.hardwareHatCount == this.hatCount);
				}

				// Token: 0x0600232A RID: 9002 RVA: 0x0008CD00 File Offset: 0x0008AF00
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_InternalDriver_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_InternalDriver_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x0600232B RID: 9003 RVA: 0x0008CD1C File Offset: 0x0008AF1C
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_InternalDriver_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_InternalDriver_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.vidPid = ArrayTools.ShallowCopy<HardwareJoystickMap.VidPid>(this.vidPid);
					matchingCriteria.hatCount = this.hatCount;
				}

				// Token: 0x0600232C RID: 9004 RVA: 0x0008CD78 File Offset: 0x0008AF78
				private bool ProductNameMatches(string name)
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						string searchFor = this.productName[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(name, searchFor, this.productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x040013E7 RID: 5095
				public bool productName_useRegex;

				// Token: 0x040013E8 RID: 5096
				public string[] productName;

				// Token: 0x040013E9 RID: 5097
				public HardwareJoystickMap.VidPid[] vidPid;

				// Token: 0x040013EA RID: 5098
				public int hatCount;
			}

			// Token: 0x02000346 RID: 838
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x1700081A RID: 2074
				// (get) Token: 0x0600232E RID: 9006 RVA: 0x0001A5B1 File Offset: 0x000187B1
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x1700081B RID: 2075
				// (get) Token: 0x0600232F RID: 9007 RVA: 0x0001A5C5 File Offset: 0x000187C5
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06002330 RID: 9008 RVA: 0x0008CDC0 File Offset: 0x0008AFC0
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002331 RID: 9009 RVA: 0x0008CE24 File Offset: 0x0008B024
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case 0:
								axisRange = AxisRange.Positive;
								return true;
							case 1:
								break;
							case 2:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != 100)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06002332 RID: 9010 RVA: 0x0008CEE8 File Offset: 0x0008B0E8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_InternalDriver_Base.Elements elements = new HardwareJoystickMap.Platform_InternalDriver_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002333 RID: 9011 RVA: 0x0008CF04 File Offset: 0x0008B104
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_InternalDriver_Base.Elements elements = destination as HardwareJoystickMap.Platform_InternalDriver_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_InternalDriver_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_InternalDriver_Base.Button>(this.buttons);
				}

				// Token: 0x040013EB RID: 5099
				public HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes;

				// Token: 0x040013EC RID: 5100
				public HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons;
			}

			// Token: 0x02000347 RID: 839
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x06002335 RID: 9013 RVA: 0x0008CF48 File Offset: 0x0008B148
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_InternalDriver_Base.Button button = new HardwareJoystickMap.Platform_InternalDriver_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x06002336 RID: 9014 RVA: 0x0008CF64 File Offset: 0x0008B164
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_InternalDriver_Base.Button button = destination as HardwareJoystickMap.Platform_InternalDriver_Base.Button;
					if (button == null)
					{
						return;
					}
					button.sourceHat = this.sourceHat;
					button.sourceHatDirection = this.sourceHatDirection;
					button.sourceHatType = this.sourceHatType;
				}

				// Token: 0x040013ED RID: 5101
				public int sourceHat;

				// Token: 0x040013EE RID: 5102
				public HatDirection sourceHatDirection;

				// Token: 0x040013EF RID: 5103
				public HatType sourceHatType;
			}

			// Token: 0x02000348 RID: 840
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x06002338 RID: 9016 RVA: 0x0008CFA8 File Offset: 0x0008B1A8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_InternalDriver_Base.Axis axis = new HardwareJoystickMap.Platform_InternalDriver_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x06002339 RID: 9017 RVA: 0x0008CFC4 File Offset: 0x0008B1C4
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_InternalDriver_Base.Axis axis = destination as HardwareJoystickMap.Platform_InternalDriver_Base.Axis;
					if (axis == null)
					{
						return;
					}
					axis.sourceHat = this.sourceHat;
					axis.sourceHatDirection = this.sourceHatDirection;
					axis.sourceHatType = this.sourceHatType;
					axis.sourceHatRange = this.sourceHatRange;
				}

				// Token: 0x040013F0 RID: 5104
				public int sourceHat;

				// Token: 0x040013F1 RID: 5105
				public AxisDirection sourceHatDirection;

				// Token: 0x040013F2 RID: 5106
				public HatType sourceHatType;

				// Token: 0x040013F3 RID: 5107
				public AxisRange sourceHatRange;
			}
		}

		// Token: 0x0200034B RID: 843
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_InternalDriver : HardwareJoystickMap.Platform_InternalDriver_Base
		{
			// Token: 0x0600234B RID: 9035 RVA: 0x0001A62D File Offset: 0x0001882D
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x0600234C RID: 9036 RVA: 0x0008D1D4 File Offset: 0x0008B3D4
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600234D RID: 9037 RVA: 0x0008D230 File Offset: 0x0008B430
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_InternalDriver platform_InternalDriver = new HardwareJoystickMap.Platform_InternalDriver();
				this.CopyVars(platform_InternalDriver);
				return platform_InternalDriver;
			}

			// Token: 0x0600234E RID: 9038 RVA: 0x0008D24C File Offset: 0x0008B44C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_InternalDriver platform_InternalDriver = destination as HardwareJoystickMap.Platform_InternalDriver;
				if (platform_InternalDriver == null)
				{
					return;
				}
				platform_InternalDriver.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_InternalDriver_Base>(this.variants);
			}

			// Token: 0x040013FE RID: 5118
			public HardwareJoystickMap.Platform_InternalDriver_Base[] variants;
		}

		// Token: 0x0200034C RID: 844
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_SDL2_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x17000820 RID: 2080
			// (get) Token: 0x06002350 RID: 9040 RVA: 0x0001A63D File Offset: 0x0001883D
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.SDL2;
				}
			}

			// Token: 0x17000821 RID: 2081
			// (get) Token: 0x06002351 RID: 9041 RVA: 0x0001A641 File Offset: 0x00018841
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x17000822 RID: 2082
			// (get) Token: 0x06002352 RID: 9042 RVA: 0x0001A66F File Offset: 0x0001886F
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000823 RID: 2083
			// (get) Token: 0x06002353 RID: 9043 RVA: 0x0001A686 File Offset: 0x00018886
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000824 RID: 2084
			// (get) Token: 0x06002354 RID: 9044 RVA: 0x0001A6A7 File Offset: 0x000188A7
			internal HardwareJoystickMap.Platform_SDL2_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000825 RID: 2085
			// (get) Token: 0x06002355 RID: 9045 RVA: 0x0001A6BE File Offset: 0x000188BE
			internal HardwareJoystickMap.Platform_SDL2_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x06002356 RID: 9046 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002357 RID: 9047 RVA: 0x0001A6D5 File Offset: 0x000188D5
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x17000826 RID: 2086
			// (get) Token: 0x06002358 RID: 9048 RVA: 0x0001A6FC File Offset: 0x000188FC
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000827 RID: 2087
			// (get) Token: 0x06002359 RID: 9049 RVA: 0x0001A713 File Offset: 0x00018913
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x0600235A RID: 9050 RVA: 0x0008D27C File Offset: 0x0008B47C
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_SDL2_Base.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_SDL2_Base.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600235B RID: 9051 RVA: 0x0008D310 File Offset: 0x0008B510
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_SDL2_Base.Button button in this.IterateButtons())
				{
					buttons[num] = button.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_SDL2_Base.Axis axis in this.IterateAxes())
				{
					axes[num] = axis.elementIdentifier;
					num++;
				}
			}

			// Token: 0x0600235C RID: 9052 RVA: 0x0008D3C8 File Offset: 0x0008B5C8
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x0600235D RID: 9053 RVA: 0x0008D4E0 File Offset: 0x0008B6E0
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || this.Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && this.Axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x0600235E RID: 9054 RVA: 0x0008D5A8 File Offset: 0x0008B7A8
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x0600235F RID: 9055 RVA: 0x0001A72A File Offset: 0x0001892A
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002360 RID: 9056 RVA: 0x0001A742 File Offset: 0x00018942
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002361 RID: 9057 RVA: 0x0001A75E File Offset: 0x0001895E
			internal IEnumerable<HardwareJoystickMap.Platform_SDL2_Base.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num = this.elements.axes.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.axes[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x06002362 RID: 9058 RVA: 0x0001A76E File Offset: 0x0001896E
			internal IEnumerable<HardwareJoystickMap.Platform_SDL2_Base.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num = this.elements.buttons.Length;
				int num2;
				for (int i = 0; i < num; i = num2 + 1)
				{
					yield return this.elements.buttons[i];
					num2 = i;
				}
				yield break;
			}

			// Token: 0x17000828 RID: 2088
			// (get) Token: 0x06002363 RID: 9059 RVA: 0x0001A77E File Offset: 0x0001897E
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002364 RID: 9060 RVA: 0x0008D5FC File Offset: 0x0008B7FC
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = new HardwareJoystickMap.Platform_SDL2_Base();
				this.CopyVars(platform_SDL2_Base);
				return platform_SDL2_Base;
			}

			// Token: 0x06002365 RID: 9061 RVA: 0x0008D618 File Offset: 0x0008B818
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = destination as HardwareJoystickMap.Platform_SDL2_Base;
				if (platform_SDL2_Base == null)
				{
					return;
				}
				platform_SDL2_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_SDL2_Base.Elements>(this.elements);
			}

			// Token: 0x040013FF RID: 5119
			public HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria matchingCriteria;

			// Token: 0x04001400 RID: 5120
			public HardwareJoystickMap.Platform_SDL2_Base.Elements elements;

			// Token: 0x0200034D RID: 845
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x17000829 RID: 2089
				// (get) Token: 0x06002367 RID: 9063 RVA: 0x0001A786 File Offset: 0x00018986
				internal override bool hasData
				{
					get
					{
						return !this.disabled && ((this.productGUID != null && this.productGUID.Length != 0) || (this.productName != null && this.productName.Length != 0));
					}
				}

				// Token: 0x1700082A RID: 2090
				// (get) Token: 0x06002368 RID: 9064 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x06002369 RID: 9065 RVA: 0x0008D644 File Offset: 0x0008B844
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(this.productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains<PidVid>(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (this.productName == null || this.productName.Length == 0)
							{
								return true;
							}
						}
						return this.AnyNameMatches(bridgedControllerHWInfo);
					}
					return this.AnyNameMatches(bridgedControllerHWInfo);
				}

				// Token: 0x1700082B RID: 2091
				// (get) Token: 0x0600236A RID: 9066 RVA: 0x00003E2B File Offset: 0x0000202B
				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x0600236B RID: 9067 RVA: 0x000067FE File Offset: 0x000049FE
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				// Token: 0x0600236C RID: 9068 RVA: 0x0001A7B9 File Offset: 0x000189B9
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (alternateMatched || this.hatCount < 0 || bridgedControllerHWInfo.hardwareHatCount == this.hatCount);
				}

				// Token: 0x0600236D RID: 9069 RVA: 0x0001A7E6 File Offset: 0x000189E6
				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return this.NameMatches(bridgedControllerHWInfo.hw_productName, this.productName, this.productName_useRegex) || this.NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, this.systemName, this.systemName_useRegex);
				}

				// Token: 0x0600236E RID: 9070 RVA: 0x00087128 File Offset: 0x00085328
				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && HardwareJoystickMap.MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600236F RID: 9071 RVA: 0x0008D6C8 File Offset: 0x0008B8C8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002370 RID: 9072 RVA: 0x0008D6E4 File Offset: 0x0008B8E4
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.manufacturer_useRegex = this.manufacturer_useRegex;
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.systemName_useRegex = this.systemName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy<string>(this.manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.systemName = ArrayTools.ShallowCopy<string>(this.systemName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy<string>(this.productGUID);
				}

				// Token: 0x04001401 RID: 5121
				public int hatCount;

				// Token: 0x04001402 RID: 5122
				public bool manufacturer_useRegex;

				// Token: 0x04001403 RID: 5123
				public bool productName_useRegex;

				// Token: 0x04001404 RID: 5124
				public bool systemName_useRegex;

				// Token: 0x04001405 RID: 5125
				public string[] manufacturer;

				// Token: 0x04001406 RID: 5126
				public string[] productName;

				// Token: 0x04001407 RID: 5127
				public string[] systemName;

				// Token: 0x04001408 RID: 5128
				public string[] productGUID;

				// Token: 0x0200034E RID: 846
				[Serializable]
				public sealed class ElementCount : HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base
				{
					// Token: 0x06002373 RID: 9075 RVA: 0x0008D778 File Offset: 0x0008B978
					public override object DeepClone()
					{
						HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria.ElementCount elementCount = new HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria.ElementCount();
						this.lIEfPuoiEXSCAiedHDGrZvHOsLxw(elementCount);
						return elementCount;
					}

					// Token: 0x06002374 RID: 9076 RVA: 0x0008D794 File Offset: 0x0008B994
					internal void GjXxBHPGoLEyMeClIIRRVSbFuVoFA(HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base A_1)
					{
						base.lIEfPuoiEXSCAiedHDGrZvHOsLxw(A_1);
						HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria.ElementCount elementCount = A_1 as HardwareJoystickMap.Platform_SDL2_Base.MatchingCriteria.ElementCount;
						if (elementCount == null)
						{
							return;
						}
						elementCount.hatCount = this.hatCount;
					}

					// Token: 0x06002375 RID: 9077 RVA: 0x0001A821 File Offset: 0x00018A21
					internal bool JhwRbhXMOREYiYvVoUPHhjFGhUZB(BridgedControllerHWInfo A_1)
					{
						return base.SzFaabwiwVxhtNCAlMSNVIkspaRo(A_1) && (this.hatCount < 0 || this.hatCount == A_1.hardwareHatCount);
					}

					// Token: 0x04001409 RID: 5129
					public int hatCount;
				}
			}

			// Token: 0x0200034F RID: 847
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x1700082C RID: 2092
				// (get) Token: 0x06002376 RID: 9078 RVA: 0x0001A847 File Offset: 0x00018A47
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x1700082D RID: 2093
				// (get) Token: 0x06002377 RID: 9079 RVA: 0x0001A85B File Offset: 0x00018A5B
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x06002378 RID: 9080 RVA: 0x0001A86F File Offset: 0x00018A6F
				internal HardwareJoystickMap.Platform_SDL2_Base.Axis GetAxis(int axisIndex)
				{
					if (this.axes == null || axisIndex < 0 || axisIndex >= this.axes.Length)
					{
						return null;
					}
					return this.axes[axisIndex];
				}

				// Token: 0x1700082E RID: 2094
				// (get) Token: 0x06002379 RID: 9081 RVA: 0x0001A892 File Offset: 0x00018A92
				internal IEnumerable<HardwareJoystickMap.Platform_SDL2_Base.Axis> Axes
				{
					get
					{
						if (this.axes == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.axes.Length; i = num + 1)
						{
							yield return this.axes[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x1700082F RID: 2095
				// (get) Token: 0x0600237A RID: 9082 RVA: 0x0001A8A2 File Offset: 0x00018AA2
				internal IEnumerable<HardwareJoystickMap.Platform_SDL2_Base.Button> Buttons
				{
					get
					{
						if (this.buttons == null)
						{
							yield break;
						}
						int num;
						for (int i = 0; i < this.buttons.Length; i = num + 1)
						{
							yield return this.buttons[i];
							num = i;
						}
						yield break;
					}
				}

				// Token: 0x0600237B RID: 9083 RVA: 0x0008D7C0 File Offset: 0x0008B9C0
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x0600237C RID: 9084 RVA: 0x0008D824 File Offset: 0x0008BA24
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							HardwareElementSourceTypeWithHat sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Axis:
								break;
							case HardwareElementSourceTypeWithHat.Hat:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x0600237D RID: 9085 RVA: 0x0008D8E8 File Offset: 0x0008BAE8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_SDL2_Base.Elements elements = new HardwareJoystickMap.Platform_SDL2_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x0600237E RID: 9086 RVA: 0x0008D904 File Offset: 0x0008BB04
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_SDL2_Base.Elements elements = destination as HardwareJoystickMap.Platform_SDL2_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_SDL2_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_SDL2_Base.Button>(this.buttons);
				}

				// Token: 0x0400140A RID: 5130
				public HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes;

				// Token: 0x0400140B RID: 5131
				public HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons;
			}

			// Token: 0x02000352 RID: 850
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public abstract class Element : IDeepCloneable
			{
				// Token: 0x06002390 RID: 9104
				public abstract object DeepClone();

				// Token: 0x06002391 RID: 9105 RVA: 0x00002FF9 File Offset: 0x000011F9
				protected virtual void ImportVars(HardwareJoystickMap.Platform_SDL2_Base.Element source)
				{
				}
			}

			// Token: 0x02000353 RID: 851
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class Button : HardwareJoystickMap.Platform_SDL2_Base.Element
			{
				// Token: 0x06002393 RID: 9107 RVA: 0x0001A906 File Offset: 0x00018B06
				public Button()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				// Token: 0x06002394 RID: 9108 RVA: 0x0001A915 File Offset: 0x00018B15
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_SDL2_Base.Button button = new HardwareJoystickMap.Platform_SDL2_Base.Button();
					button.ImportVars(this);
					return button;
				}

				// Token: 0x06002395 RID: 9109 RVA: 0x0008DAD8 File Offset: 0x0008BCD8
				protected override void ImportVars(HardwareJoystickMap.Platform_SDL2_Base.Element source)
				{
					base.ImportVars(source);
					HardwareJoystickMap.Platform_SDL2_Base.Button button = source as HardwareJoystickMap.Platform_SDL2_Base.Button;
					if (button == null)
					{
						return;
					}
					this.elementIdentifier = button.elementIdentifier;
					this.sourceType = button.sourceType;
					this.sourceButton = button.sourceButton;
					this.sourceAxis = button.sourceAxis;
					this.sourceAxisPole = button.sourceAxisPole;
					this.axisDeadZone = button.axisDeadZone;
					this.sourceHat = button.sourceHat;
					this.sourceHatType = button.sourceHatType;
					this.sourceHatDirection = button.sourceHatDirection;
					this.requireMultipleButtons = button.requireMultipleButtons;
					this.requiredButtons = ArrayTools.ShallowCopy<int>(button.requiredButtons);
					this.ignoreIfButtonsActive = button.ignoreIfButtonsActive;
					this.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy<int>(button.ignoreIfButtonsActiveButtons);
					this.buttonInfo = MiscTools.DeepClone<HardwareButtonInfo>(button.buttonInfo);
				}

				// Token: 0x04001416 RID: 5142
				public int elementIdentifier;

				// Token: 0x04001417 RID: 5143
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x04001418 RID: 5144
				public int sourceButton;

				// Token: 0x04001419 RID: 5145
				public int sourceAxis;

				// Token: 0x0400141A RID: 5146
				public Pole sourceAxisPole;

				// Token: 0x0400141B RID: 5147
				public float axisDeadZone;

				// Token: 0x0400141C RID: 5148
				public int sourceHat;

				// Token: 0x0400141D RID: 5149
				public HatType sourceHatType;

				// Token: 0x0400141E RID: 5150
				public HatDirection sourceHatDirection;

				// Token: 0x0400141F RID: 5151
				public bool requireMultipleButtons;

				// Token: 0x04001420 RID: 5152
				public int[] requiredButtons;

				// Token: 0x04001421 RID: 5153
				public bool ignoreIfButtonsActive;

				// Token: 0x04001422 RID: 5154
				public int[] ignoreIfButtonsActiveButtons;

				// Token: 0x04001423 RID: 5155
				public HardwareButtonInfo buttonInfo;
			}

			// Token: 0x02000354 RID: 852
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public class Axis : HardwareJoystickMap.Platform_SDL2_Base.Element
			{
				// Token: 0x06002396 RID: 9110 RVA: 0x0001A923 File Offset: 0x00018B23
				public Axis()
				{
					this.sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				// Token: 0x06002397 RID: 9111 RVA: 0x0001A932 File Offset: 0x00018B32
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_SDL2_Base.Axis axis = new HardwareJoystickMap.Platform_SDL2_Base.Axis();
					axis.ImportVars(this);
					return axis;
				}

				// Token: 0x06002398 RID: 9112 RVA: 0x0008DBB0 File Offset: 0x0008BDB0
				protected override void ImportVars(HardwareJoystickMap.Platform_SDL2_Base.Element source)
				{
					base.ImportVars(source);
					HardwareJoystickMap.Platform_SDL2_Base.Axis axis = source as HardwareJoystickMap.Platform_SDL2_Base.Axis;
					if (axis == null)
					{
						return;
					}
					this.elementIdentifier = axis.elementIdentifier;
					this.sourceType = axis.sourceType;
					this.sourceAxis = axis.sourceAxis;
					this.sourceAxisRange = axis.sourceAxisRange;
					this.invert = axis.invert;
					this.axisDeadZone = axis.axisDeadZone;
					this.calibrateAxis = axis.calibrateAxis;
					this.axisZero = axis.axisZero;
					this.axisMin = axis.axisMin;
					this.axisMax = axis.axisMax;
					this.axisInfo = MiscTools.DeepClone<HardwareAxisInfo>(axis.axisInfo);
					this.sourceButton = axis.sourceButton;
					this.buttonAxisContribution = axis.buttonAxisContribution;
					this.sourceHat = axis.sourceHat;
					this.sourceHatDirection = axis.sourceHatDirection;
					this.sourceHatRange = axis.sourceHatRange;
					this.alternateCalibrations = MiscTools.DeepClone<HardwareJoystickMap.AxisCalibrationInfoEntry>(axis.alternateCalibrations);
				}

				// Token: 0x04001424 RID: 5156
				public int elementIdentifier;

				// Token: 0x04001425 RID: 5157
				public HardwareElementSourceTypeWithHat sourceType;

				// Token: 0x04001426 RID: 5158
				public int sourceAxis;

				// Token: 0x04001427 RID: 5159
				public AxisRange sourceAxisRange;

				// Token: 0x04001428 RID: 5160
				public bool invert;

				// Token: 0x04001429 RID: 5161
				public float axisDeadZone;

				// Token: 0x0400142A RID: 5162
				public bool calibrateAxis;

				// Token: 0x0400142B RID: 5163
				public float axisZero;

				// Token: 0x0400142C RID: 5164
				public float axisMin;

				// Token: 0x0400142D RID: 5165
				public float axisMax;

				// Token: 0x0400142E RID: 5166
				public HardwareJoystickMap.AxisCalibrationInfoEntry[] alternateCalibrations;

				// Token: 0x0400142F RID: 5167
				public HardwareAxisInfo axisInfo;

				// Token: 0x04001430 RID: 5168
				public int sourceButton;

				// Token: 0x04001431 RID: 5169
				public Pole buttonAxisContribution;

				// Token: 0x04001432 RID: 5170
				public int sourceHat;

				// Token: 0x04001433 RID: 5171
				public AxisDirection sourceHatDirection;

				// Token: 0x04001434 RID: 5172
				public AxisRange sourceHatRange;
			}
		}

		// Token: 0x02000357 RID: 855
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_SDL2 : HardwareJoystickMap.Platform_SDL2_Base
		{
			// Token: 0x060023A9 RID: 9129 RVA: 0x0001A994 File Offset: 0x00018B94
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060023AA RID: 9130 RVA: 0x0008DE80 File Offset: 0x0008C080
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060023AB RID: 9131 RVA: 0x0008DEDC File Offset: 0x0008C0DC
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_SDL2 platform_SDL = new HardwareJoystickMap.Platform_SDL2();
				this.CopyVars(platform_SDL);
				return platform_SDL;
			}

			// Token: 0x060023AC RID: 9132 RVA: 0x0008DEF8 File Offset: 0x0008C0F8
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_SDL2 platform_SDL = destination as HardwareJoystickMap.Platform_SDL2;
				if (platform_SDL == null)
				{
					return;
				}
				platform_SDL.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_SDL2_Base>(this.variants);
			}

			// Token: 0x04001441 RID: 5185
			public HardwareJoystickMap.Platform_SDL2_Base[] variants;
		}

		// Token: 0x02000358 RID: 856
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_Steam_Base : HardwareJoystickMap.Platform
		{
			// Token: 0x17000838 RID: 2104
			// (get) Token: 0x060023AE RID: 9134 RVA: 0x0001A9A4 File Offset: 0x00018BA4
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000839 RID: 2105
			// (get) Token: 0x060023AF RID: 9135 RVA: 0x0001A9BB File Offset: 0x00018BBB
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x1700083A RID: 2106
			// (get) Token: 0x060023B0 RID: 9136 RVA: 0x0001A9D2 File Offset: 0x00018BD2
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.Steam;
				}
			}

			// Token: 0x1700083B RID: 2107
			// (get) Token: 0x060023B1 RID: 9137 RVA: 0x0001A9D6 File Offset: 0x00018BD6
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedAxisCount != 0 || this.assignedButtonCount != 0);
				}
			}

			// Token: 0x1700083C RID: 2108
			// (get) Token: 0x060023B2 RID: 9138 RVA: 0x0001AA04 File Offset: 0x00018C04
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x1700083D RID: 2109
			// (get) Token: 0x060023B3 RID: 9139 RVA: 0x0001AA1B File Offset: 0x00018C1B
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x1700083E RID: 2110
			// (get) Token: 0x060023B4 RID: 9140 RVA: 0x0001AA3C File Offset: 0x00018C3C
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x060023B5 RID: 9141 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x060023B6 RID: 9142 RVA: 0x0001AA44 File Offset: 0x00018C44
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x060023B7 RID: 9143 RVA: 0x00003E2B File Offset: 0x0000202B
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			// Token: 0x060023B8 RID: 9144 RVA: 0x0001AA6B File Offset: 0x00018C6B
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[0];
				axes = new int[0];
			}

			// Token: 0x060023B9 RID: 9145 RVA: 0x0001AA7D File Offset: 0x00018C7D
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return new AxisCalibrationData[0];
			}

			// Token: 0x060023BA RID: 9146 RVA: 0x0001AA85 File Offset: 0x00018C85
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = new AxisRange[0];
				axisInfos = new HardwareAxisInfo[0];
			}

			// Token: 0x060023BB RID: 9147 RVA: 0x0001AA97 File Offset: 0x00018C97
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = new HardwareButtonInfo[0];
			}

			// Token: 0x060023BC RID: 9148 RVA: 0x0001AAA1 File Offset: 0x00018CA1
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x060023BD RID: 9149 RVA: 0x0001AAB9 File Offset: 0x00018CB9
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x060023BE RID: 9150 RVA: 0x0008DF28 File Offset: 0x0008C128
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_Steam_Base platform_Steam_Base = new HardwareJoystickMap.Platform_Steam_Base();
				this.CopyVars(platform_Steam_Base);
				return platform_Steam_Base;
			}

			// Token: 0x060023BF RID: 9151 RVA: 0x0008DF44 File Offset: 0x0008C144
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				HardwareJoystickMap.Platform_Steam_Base platform_Steam_Base = destination as HardwareJoystickMap.Platform_Steam_Base;
				if (platform_Steam_Base == null)
				{
					return;
				}
				platform_Steam_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_Steam_Base.MatchingCriteria>(this.matchingCriteria);
				platform_Steam_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_Steam_Base.Elements>(this.elements);
			}

			// Token: 0x04001442 RID: 5186
			public HardwareJoystickMap.Platform_Steam_Base.MatchingCriteria matchingCriteria;

			// Token: 0x04001443 RID: 5187
			public HardwareJoystickMap.Platform_Steam_Base.Elements elements;

			// Token: 0x02000359 RID: 857
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class MatchingCriteria : HardwareJoystickMap.MatchingCriteria_Base
			{
				// Token: 0x1700083F RID: 2111
				// (get) Token: 0x060023C1 RID: 9153 RVA: 0x000042E2 File Offset: 0x000024E2
				internal override bool hasData
				{
					get
					{
						return true;
					}
				}

				// Token: 0x17000840 RID: 2112
				// (get) Token: 0x060023C2 RID: 9154 RVA: 0x00018535 File Offset: 0x00016735
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed;
					}
				}

				// Token: 0x060023C3 RID: 9155 RVA: 0x0001AAD5 File Offset: 0x00018CD5
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed) || (!this.disabled && this.isAllowed);
				}

				// Token: 0x17000841 RID: 2113
				// (get) Token: 0x060023C4 RID: 9156 RVA: 0x00003E2B File Offset: 0x0000202B
				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x060023C5 RID: 9157 RVA: 0x000067FE File Offset: 0x000049FE
				internal override HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				// Token: 0x060023C6 RID: 9158 RVA: 0x00018BF2 File Offset: 0x00016DF2
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				// Token: 0x060023C7 RID: 9159 RVA: 0x0008DF80 File Offset: 0x0008C180
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Steam_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_Steam_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x060023C8 RID: 9160 RVA: 0x0001AB06 File Offset: 0x00018D06
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Steam_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_Steam_Base.MatchingCriteria;
				}
			}

			// Token: 0x0200035A RID: 858
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class Elements : HardwareJoystickMap.Elements_Base
			{
				// Token: 0x17000842 RID: 2114
				// (get) Token: 0x060023CA RID: 9162 RVA: 0x00003E2B File Offset: 0x0000202B
				public override int buttonCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x17000843 RID: 2115
				// (get) Token: 0x060023CB RID: 9163 RVA: 0x00003E2B File Offset: 0x0000202B
				public override int axisCount
				{
					get
					{
						return 0;
					}
				}

				// Token: 0x060023CC RID: 9164 RVA: 0x0008DF9C File Offset: 0x0008C19C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_Steam_Base.Elements elements = new HardwareJoystickMap.Platform_Steam_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x060023CD RID: 9165 RVA: 0x0001AB16 File Offset: 0x00018D16
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_Steam_Base.Elements elements = destination as HardwareJoystickMap.Platform_Steam_Base.Elements;
				}

				// Token: 0x060023CE RID: 9166 RVA: 0x0001AB26 File Offset: 0x00018D26
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return elementIdentifier.elementType;
				}

				// Token: 0x060023CF RID: 9167 RVA: 0x0001AB2E File Offset: 0x00018D2E
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = AxisRange.Full;
					return false;
				}
			}
		}

		// Token: 0x0200035B RID: 859
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_Steam : HardwareJoystickMap.Platform_Steam_Base
		{
			// Token: 0x060023D1 RID: 9169 RVA: 0x0001AB34 File Offset: 0x00018D34
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060023D2 RID: 9170 RVA: 0x0008DFB8 File Offset: 0x0008C1B8
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060023D3 RID: 9171 RVA: 0x0008E014 File Offset: 0x0008C214
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_Steam platform_Steam = new HardwareJoystickMap.Platform_Steam();
				this.CopyVars(platform_Steam);
				return platform_Steam;
			}

			// Token: 0x060023D4 RID: 9172 RVA: 0x0008E030 File Offset: 0x0008C230
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_Steam platform_Steam = destination as HardwareJoystickMap.Platform_Steam;
				if (platform_Steam == null)
				{
					return;
				}
				platform_Steam.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_Steam_Base>(this.variants);
			}

			// Token: 0x04001444 RID: 5188
			public HardwareJoystickMap.Platform_Steam_Base[] variants;
		}

		// Token: 0x0200035C RID: 860
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_WebGL_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x17000844 RID: 2116
			// (get) Token: 0x060023D6 RID: 9174 RVA: 0x0001AB44 File Offset: 0x00018D44
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000845 RID: 2117
			// (get) Token: 0x060023D7 RID: 9175 RVA: 0x0001AB5B File Offset: 0x00018D5B
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x17000846 RID: 2118
			// (get) Token: 0x060023D8 RID: 9176 RVA: 0x0001AB72 File Offset: 0x00018D72
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.WebGL;
				}
			}

			// Token: 0x17000847 RID: 2119
			// (get) Token: 0x060023D9 RID: 9177 RVA: 0x0008E060 File Offset: 0x0008C260
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_WebGL_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x17000848 RID: 2120
			// (get) Token: 0x060023DA RID: 9178 RVA: 0x0008E0AC File Offset: 0x0008C2AC
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_WebGL_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x17000849 RID: 2121
			// (get) Token: 0x060023DB RID: 9179 RVA: 0x0001AB76 File Offset: 0x00018D76
			internal HardwareJoystickMap.Platform_WebGL_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x1700084A RID: 2122
			// (get) Token: 0x060023DC RID: 9180 RVA: 0x0001AB8D File Offset: 0x00018D8D
			internal HardwareJoystickMap.Platform_WebGL_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x1700084B RID: 2123
			// (get) Token: 0x060023DD RID: 9181 RVA: 0x0001ABA4 File Offset: 0x00018DA4
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x1700084C RID: 2124
			// (get) Token: 0x060023DE RID: 9182 RVA: 0x0001ABD2 File Offset: 0x00018DD2
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x1700084D RID: 2125
			// (get) Token: 0x060023DF RID: 9183 RVA: 0x0001ABE9 File Offset: 0x00018DE9
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x1700084E RID: 2126
			// (get) Token: 0x060023E0 RID: 9184 RVA: 0x0001AC0A File Offset: 0x00018E0A
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x060023E1 RID: 9185 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x060023E2 RID: 9186 RVA: 0x0001AC12 File Offset: 0x00018E12
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x060023E3 RID: 9187 RVA: 0x0001AC39 File Offset: 0x00018E39
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060023E4 RID: 9188 RVA: 0x0001AC49 File Offset: 0x00018E49
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060023E5 RID: 9189 RVA: 0x0008E0F8 File Offset: 0x0008C2F8
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_WebGL_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_WebGL_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060023E6 RID: 9190 RVA: 0x0008E198 File Offset: 0x0008C398
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_WebGL_Base.Button button2 = (HardwareJoystickMap.Platform_WebGL_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_WebGL_Base.Axis axis2 = (HardwareJoystickMap.Platform_WebGL_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x060023E7 RID: 9191 RVA: 0x0008E25C File Offset: 0x0008C45C
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_WebGL_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x060023E8 RID: 9192 RVA: 0x0008E368 File Offset: 0x0008C568
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x060023E9 RID: 9193 RVA: 0x0008E41C File Offset: 0x0008C61C
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x060023EA RID: 9194 RVA: 0x0001AC59 File Offset: 0x00018E59
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x060023EB RID: 9195 RVA: 0x0001AC71 File Offset: 0x00018E71
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x060023EC RID: 9196 RVA: 0x0008E470 File Offset: 0x0008C670
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_WebGL_Base platform_WebGL_Base = new HardwareJoystickMap.Platform_WebGL_Base();
				this.CopyVars(platform_WebGL_Base);
				return platform_WebGL_Base;
			}

			// Token: 0x060023ED RID: 9197 RVA: 0x0008E48C File Offset: 0x0008C68C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_WebGL_Base platform_WebGL_Base = destination as HardwareJoystickMap.Platform_WebGL_Base;
				if (platform_WebGL_Base == null)
				{
					return;
				}
				platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria>(this.matchingCriteria);
				platform_WebGL_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_WebGL_Base.Elements>(this.elements);
			}

			// Token: 0x04001445 RID: 5189
			public HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria matchingCriteria;

			// Token: 0x04001446 RID: 5190
			public HardwareJoystickMap.Platform_WebGL_Base.Elements elements;

			// Token: 0x04001447 RID: 5191
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x04001448 RID: 5192
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x0200035D RID: 861
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x1700084F RID: 2127
				// (get) Token: 0x060023EF RID: 9199 RVA: 0x0008E4D0 File Offset: 0x0008C6D0
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0) || (this.mapping != null && this.mapping.Length != 0) || (this.productGUID != null && this.productGUID.Length != 0) || (this.elementCount != null && this.elementCount.Length != 0) || (this.clientInfo != null && this.clientInfo.Length != 0);
					}
				}

				// Token: 0x17000850 RID: 2128
				// (get) Token: 0x060023F0 RID: 9200 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x060023F1 RID: 9201 RVA: 0x0008E548 File Offset: 0x0008C748
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					bool flag = false;
					string text = StringTools.Trim(this.tag);
					if (!string.IsNullOrEmpty(text) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, text, StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					if (this.clientInfo != null && this.clientInfo.Length != 0)
					{
						bool flag2 = false;
						for (int i = 0; i < this.clientInfo.Length; i++)
						{
							HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria.ClientInfo clientInfo = this.clientInfo[i];
							if (clientInfo != null)
							{
								if (clientInfo.browser != 0)
								{
									if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
									{
										goto IL_FE;
									}
									if (!HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria.CheckBrowserVersion(clientInfo.browser, clientInfo.browserVersionMin, clientInfo.browserVersionMax, bridgedControllerHWInfo.webGL_webBrowserVersionSplit))
									{
										return false;
									}
								}
								if (clientInfo.os != 0)
								{
									if (clientInfo.os != (int)bridgedControllerHWInfo.webGL_osType)
									{
										goto IL_FE;
									}
									if (!HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria.CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
									{
										return false;
									}
								}
								flag2 = true;
								break;
							}
							IL_FE:;
						}
						if (!flag2)
						{
							return false;
						}
						flag = true;
					}
					if (this.elementCount != null && this.elementCount.Length != 0)
					{
						bool flag3 = false;
						for (int j = 0; j < this.elementCount.Length; j++)
						{
							HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base elementCount_Base = this.elementCount[j];
							if (elementCount_Base != null && (elementCount_Base.buttonCount < 0 || elementCount_Base.buttonCount == bridgedControllerHWInfo.hardwareButtonCount) && (elementCount_Base.axisCount < 0 || elementCount_Base.axisCount == bridgedControllerHWInfo.hardwareAxisCount))
							{
								flag3 = true;
							}
						}
						if (!flag3)
						{
							return false;
						}
						flag = true;
					}
					if (this.mapping != null && this.mapping.Length != 0)
					{
						bool flag4 = false;
						for (int k = 0; k < this.mapping.Length; k++)
						{
							if (this.mapping[k] == (int)bridgedControllerHWInfo.webGL_mappingType)
							{
								flag4 = true;
							}
						}
						if (!flag4)
						{
							return false;
						}
						flag = true;
					}
					bool flag5 = false;
					bool flag6 = false;
					if (this.productGUID != null && this.productGUID.Length != 0 && !ArrayTools.Contains<PidVid>(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
					{
						flag6 = true;
						for (int l = 0; l < this.productGUID.Length; l++)
						{
							if (bridgedControllerHWInfo.hw_pidVid.Equals(this.productGUID[l]))
							{
								flag5 = true;
								break;
							}
						}
					}
					if (flag5)
					{
						return true;
					}
					string text2 = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
					if (text2 == null)
					{
						text2 = string.Empty;
					}
					if (this.productName != null && this.productName.Length != 0)
					{
						flag6 = true;
						for (int m = 0; m < this.productName.Length; m++)
						{
							string searchFor = this.productName[m];
							if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text2, searchFor, this.productName_useRegex))
							{
								flag5 = true;
								break;
							}
						}
					}
					return flag5 || (!flag6 && flag);
				}

				// Token: 0x060023F2 RID: 9202 RVA: 0x0008E7FC File Offset: 0x0008C9FC
				private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag = !string.IsNullOrEmpty(versionMin);
					bool flag2 = !string.IsNullOrEmpty(versionMax);
					if (!flag && !flag2)
					{
						return true;
					}
					if (currentVersion == null || currentVersion.Length == 0)
					{
						return false;
					}
					if (browser - -1 > 1)
					{
						if (browser - 1 > 5)
						{
						}
						if (flag)
						{
							string[] array = versionMin.Split('.', StringSplitOptions.None);
							int num = MathTools.Min(array.Length, currentVersion.Length);
							bool flag3 = false;
							for (int i = 0; i < num; i++)
							{
								int num2;
								bool flag4 = int.TryParse(array[i], out num2);
								int num3;
								bool flag5 = int.TryParse(currentVersion[i], out num3);
								if (flag4 && !flag5)
								{
									return false;
								}
								if (!flag4)
								{
									break;
								}
								if (num3 < num2)
								{
									return false;
								}
								flag3 = true;
							}
							if (!flag3)
							{
								return false;
							}
						}
						if (flag2)
						{
							string[] array2 = versionMax.Split('.', StringSplitOptions.None);
							int num4 = MathTools.Min(array2.Length, currentVersion.Length);
							bool flag6 = false;
							for (int j = 0; j < num4; j++)
							{
								int num5;
								bool flag7 = int.TryParse(array2[j], out num5);
								int num6;
								bool flag8 = int.TryParse(currentVersion[j], out num6);
								if (flag7 && !flag8)
								{
									return false;
								}
								if (!flag7)
								{
									break;
								}
								if (num6 > num5)
								{
									return false;
								}
								flag6 = true;
							}
							if (!flag6)
							{
								return false;
							}
						}
						return true;
					}
					return true;
				}

				// Token: 0x060023F3 RID: 9203 RVA: 0x0008E920 File Offset: 0x0008CB20
				private static bool CheckOSVersion(string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag = !string.IsNullOrEmpty(versionMin);
					bool flag2 = !string.IsNullOrEmpty(versionMax);
					if (!flag && !flag2)
					{
						return true;
					}
					if (currentVersion == null || currentVersion.Length == 0)
					{
						return false;
					}
					if (flag)
					{
						string[] array = versionMin.Split('.', StringSplitOptions.None);
						int num = MathTools.Min(array.Length, currentVersion.Length);
						bool flag3 = false;
						for (int i = 0; i < num; i++)
						{
							int num2;
							bool flag4 = int.TryParse(array[i], out num2);
							int num3;
							bool flag5 = int.TryParse(currentVersion[i], out num3);
							if (flag4 && !flag5)
							{
								return false;
							}
							if (!flag4)
							{
								break;
							}
							if (num3 < num2)
							{
								return false;
							}
							flag3 = true;
						}
						if (!flag3)
						{
							return false;
						}
					}
					if (flag2)
					{
						string[] array2 = versionMax.Split('.', StringSplitOptions.None);
						int num4 = MathTools.Min(array2.Length, currentVersion.Length);
						bool flag6 = false;
						for (int j = 0; j < num4; j++)
						{
							int num5;
							bool flag7 = int.TryParse(array2[j], out num5);
							int num6;
							bool flag8 = int.TryParse(currentVersion[j], out num6);
							if (flag7 && !flag8)
							{
								return false;
							}
							if (!flag7)
							{
								break;
							}
							if (num6 > num5)
							{
								return false;
							}
							flag6 = true;
						}
						if (!flag6)
						{
							return false;
						}
					}
					return true;
				}

				// Token: 0x060023F4 RID: 9204 RVA: 0x0008EA34 File Offset: 0x0008CC34
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x060023F5 RID: 9205 RVA: 0x0008EA50 File Offset: 0x0008CC50
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy<string>(this.productGUID);
					matchingCriteria.mapping = ArrayTools.ShallowCopy<int>(this.mapping);
					matchingCriteria.elementCount = ArrayTools.DeepClone<HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base>(this.elementCount);
					matchingCriteria.clientInfo = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria.ClientInfo>(this.clientInfo);
				}

				// Token: 0x04001449 RID: 5193
				public bool productName_useRegex;

				// Token: 0x0400144A RID: 5194
				public string[] productName;

				// Token: 0x0400144B RID: 5195
				public string[] productGUID;

				// Token: 0x0400144C RID: 5196
				public int[] mapping;

				// Token: 0x0400144D RID: 5197
				public HardwareJoystickMap.MatchingCriteria_Base.ElementCount_Base[] elementCount;

				// Token: 0x0400144E RID: 5198
				public HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria.ClientInfo[] clientInfo;

				// Token: 0x0200035E RID: 862
				[Serializable]
				public sealed class ClientInfo : IDeepCloneable
				{
					// Token: 0x060023F7 RID: 9207 RVA: 0x0008EAD0 File Offset: 0x0008CCD0
					public object DeepClone()
					{
						return new HardwareJoystickMap.Platform_WebGL_Base.MatchingCriteria.ClientInfo
						{
							browser = this.browser,
							browserVersionMin = this.browserVersionMin,
							browserVersionMax = this.browserVersionMax,
							os = this.os,
							osVersionMin = this.osVersionMin,
							osVersionMax = this.osVersionMax
						};
					}

					// Token: 0x0400144F RID: 5199
					public int browser;

					// Token: 0x04001450 RID: 5200
					public string browserVersionMin;

					// Token: 0x04001451 RID: 5201
					public string browserVersionMax;

					// Token: 0x04001452 RID: 5202
					public int os;

					// Token: 0x04001453 RID: 5203
					public string osVersionMin;

					// Token: 0x04001454 RID: 5204
					public string osVersionMax;
				}
			}

			// Token: 0x0200035F RID: 863
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x17000851 RID: 2129
				// (get) Token: 0x060023F9 RID: 9209 RVA: 0x0001AC8D File Offset: 0x00018E8D
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x17000852 RID: 2130
				// (get) Token: 0x060023FA RID: 9210 RVA: 0x0001ACA1 File Offset: 0x00018EA1
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x060023FB RID: 9211 RVA: 0x0008EB2C File Offset: 0x0008CD2C
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x060023FC RID: 9212 RVA: 0x0008EB90 File Offset: 0x0008CD90
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							if (sourceType == 0)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == 1 || sourceType == 100)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x060023FD RID: 9213 RVA: 0x0008EC18 File Offset: 0x0008CE18
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WebGL_Base.Elements elements = new HardwareJoystickMap.Platform_WebGL_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x060023FE RID: 9214 RVA: 0x0008EC34 File Offset: 0x0008CE34
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WebGL_Base.Elements elements = destination as HardwareJoystickMap.Platform_WebGL_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WebGL_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WebGL_Base.Button>(this.buttons);
				}

				// Token: 0x04001455 RID: 5205
				public HardwareJoystickMap.Platform_WebGL_Base.Axis[] axes;

				// Token: 0x04001456 RID: 5206
				public HardwareJoystickMap.Platform_WebGL_Base.Button[] buttons;
			}

			// Token: 0x02000360 RID: 864
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x06002400 RID: 9216 RVA: 0x0008EC78 File Offset: 0x0008CE78
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WebGL_Base.Button button = new HardwareJoystickMap.Platform_WebGL_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x06002401 RID: 9217 RVA: 0x0001ACB5 File Offset: 0x00018EB5
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WebGL_Base.Button button = destination as HardwareJoystickMap.Platform_WebGL_Base.Button;
				}
			}

			// Token: 0x02000361 RID: 865
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x06002403 RID: 9219 RVA: 0x0008EC94 File Offset: 0x0008CE94
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WebGL_Base.Axis axis = new HardwareJoystickMap.Platform_WebGL_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x06002404 RID: 9220 RVA: 0x0001ACC5 File Offset: 0x00018EC5
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WebGL_Base.Axis axis = destination as HardwareJoystickMap.Platform_WebGL_Base.Axis;
				}
			}
		}

		// Token: 0x02000364 RID: 868
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_WebGL : HardwareJoystickMap.Platform_WebGL_Base
		{
			// Token: 0x06002416 RID: 9238 RVA: 0x0001AD29 File Offset: 0x00018F29
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002417 RID: 9239 RVA: 0x0008EE70 File Offset: 0x0008D070
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002418 RID: 9240 RVA: 0x0008EECC File Offset: 0x0008D0CC
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_WebGL platform_WebGL = new HardwareJoystickMap.Platform_WebGL();
				this.CopyVars(platform_WebGL);
				return platform_WebGL;
			}

			// Token: 0x06002419 RID: 9241 RVA: 0x0008EEE8 File Offset: 0x0008D0E8
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_WebGL platform_WebGL = destination as HardwareJoystickMap.Platform_WebGL;
				if (platform_WebGL == null)
				{
					return;
				}
				platform_WebGL.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_WebGL_Base>(this.variants);
			}

			// Token: 0x04001461 RID: 5217
			public HardwareJoystickMap.Platform_WebGL_Base[] variants;
		}

		// Token: 0x02000365 RID: 869
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_AppleGCController_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x17000857 RID: 2135
			// (get) Token: 0x0600241B RID: 9243 RVA: 0x0001AD39 File Offset: 0x00018F39
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x17000858 RID: 2136
			// (get) Token: 0x0600241C RID: 9244 RVA: 0x0001AD50 File Offset: 0x00018F50
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x17000859 RID: 2137
			// (get) Token: 0x0600241D RID: 9245 RVA: 0x0001AD67 File Offset: 0x00018F67
			public override string controllerNameOverride
			{
				get
				{
					return this.controllerName;
				}
			}

			// Token: 0x1700085A RID: 2138
			// (get) Token: 0x0600241E RID: 9246 RVA: 0x0001AD6F File Offset: 0x00018F6F
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.AppleGameController;
				}
			}

			// Token: 0x1700085B RID: 2139
			// (get) Token: 0x0600241F RID: 9247 RVA: 0x0008EF18 File Offset: 0x0008D118
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_AppleGCController_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x1700085C RID: 2140
			// (get) Token: 0x06002420 RID: 9248 RVA: 0x0008EF64 File Offset: 0x0008D164
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_AppleGCController_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x1700085D RID: 2141
			// (get) Token: 0x06002421 RID: 9249 RVA: 0x0008EFB0 File Offset: 0x0008D1B0
			internal HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement[] CompoundElements
			{
				get
				{
					if (this._compoundElementsOrigGame == null)
					{
						HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement[] compoundElements_orig = this.CompoundElements_orig;
						if (compoundElements_orig != null)
						{
							this._compoundElementsOrigGame = new HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement[compoundElements_orig.Length];
							for (int i = 0; i < compoundElements_orig.Length; i++)
							{
								this._compoundElementsOrigGame[i] = compoundElements_orig[i];
							}
						}
					}
					return this._compoundElementsOrigGame;
				}
			}

			// Token: 0x1700085E RID: 2142
			// (get) Token: 0x06002422 RID: 9250 RVA: 0x0001AD73 File Offset: 0x00018F73
			internal HardwareJoystickMap.Platform_AppleGCController_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x1700085F RID: 2143
			// (get) Token: 0x06002423 RID: 9251 RVA: 0x0001AD8A File Offset: 0x00018F8A
			internal HardwareJoystickMap.Platform_AppleGCController_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x17000860 RID: 2144
			// (get) Token: 0x06002424 RID: 9252 RVA: 0x0001ADA1 File Offset: 0x00018FA1
			internal HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement[] CompoundElements_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.compoundElements;
				}
			}

			// Token: 0x17000861 RID: 2145
			// (get) Token: 0x06002425 RID: 9253 RVA: 0x0001ADB8 File Offset: 0x00018FB8
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x17000862 RID: 2146
			// (get) Token: 0x06002426 RID: 9254 RVA: 0x0001ADE6 File Offset: 0x00018FE6
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000863 RID: 2147
			// (get) Token: 0x06002427 RID: 9255 RVA: 0x0001ADFD File Offset: 0x00018FFD
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000864 RID: 2148
			// (get) Token: 0x06002428 RID: 9256 RVA: 0x0001AE1E File Offset: 0x0001901E
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002429 RID: 9257 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x0600242A RID: 9258 RVA: 0x0001AE26 File Offset: 0x00019026
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x0600242B RID: 9259 RVA: 0x0001AE4D File Offset: 0x0001904D
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x0600242C RID: 9260 RVA: 0x0001AE5D File Offset: 0x0001905D
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x0600242D RID: 9261 RVA: 0x0008EFFC File Offset: 0x0008D1FC
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_AppleGCController_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_AppleGCController_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600242E RID: 9262 RVA: 0x0008F09C File Offset: 0x0008D29C
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Button button2 = (HardwareJoystickMap.Platform_AppleGCController_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Axis axis2 = (HardwareJoystickMap.Platform_AppleGCController_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x0600242F RID: 9263 RVA: 0x0008F160 File Offset: 0x0008D360
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_AppleGCController_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x06002430 RID: 9264 RVA: 0x0008F26C File Offset: 0x0008D46C
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x06002431 RID: 9265 RVA: 0x0008F320 File Offset: 0x0008D520
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x06002432 RID: 9266 RVA: 0x0001AE6D File Offset: 0x0001906D
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x06002433 RID: 9267 RVA: 0x0001AE85 File Offset: 0x00019085
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x06002434 RID: 9268 RVA: 0x0008F374 File Offset: 0x0008D574
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_AppleGCController_Base platform_AppleGCController_Base = new HardwareJoystickMap.Platform_AppleGCController_Base();
				this.CopyVars(platform_AppleGCController_Base);
				return platform_AppleGCController_Base;
			}

			// Token: 0x06002435 RID: 9269 RVA: 0x0008F390 File Offset: 0x0008D590
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_AppleGCController_Base platform_AppleGCController_Base = destination as HardwareJoystickMap.Platform_AppleGCController_Base;
				if (platform_AppleGCController_Base == null)
				{
					return;
				}
				platform_AppleGCController_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria>(this.matchingCriteria);
				platform_AppleGCController_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController_Base.Elements>(this.elements);
				platform_AppleGCController_Base.controllerName = this.controllerName;
			}

			// Token: 0x04001462 RID: 5218
			public HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria matchingCriteria;

			// Token: 0x04001463 RID: 5219
			public HardwareJoystickMap.Platform_AppleGCController_Base.Elements elements;

			// Token: 0x04001464 RID: 5220
			public string controllerName;

			// Token: 0x04001465 RID: 5221
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x04001466 RID: 5222
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x04001467 RID: 5223
			private HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement[] _compoundElementsOrigGame;

			// Token: 0x02000366 RID: 870
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x17000865 RID: 2149
				// (get) Token: 0x06002437 RID: 9271 RVA: 0x0008F3E0 File Offset: 0x0008D5E0
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productCategory != null && this.productCategory.Length != 0) || (this.productName != null && this.productName.Length != 0) || this.primaryProfileType != HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerProfileTypeFlags.None || (this.profileSubTypes != null && this.profileSubTypes.Length != 0);
					}
				}

				// Token: 0x17000866 RID: 2150
				// (get) Token: 0x06002438 RID: 9272 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x06002439 RID: 9273 RVA: 0x0008F43C File Offset: 0x0008D63C
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					bool flag;
					if (!this.ElementCountsMatch(bridgedControllerHWInfo, out flag))
					{
						return false;
					}
					bool flag2 = this.HasProductName();
					bool flag3 = this.HasProductCategory();
					bool flag4 = false;
					if (this.primaryProfileType != HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerProfileTypeFlags.None)
					{
						if ((bridgedControllerHWInfo.deviceType & (ControlDeviceType)this.primaryProfileType) == ControlDeviceType.Keyboard)
						{
							return false;
						}
						if (this.profileSubTypes != null && this.profileSubTypes.Length != 0)
						{
							bool flag5 = false;
							for (int i = 0; i < this.profileSubTypes.Length; i++)
							{
								if (this.profileSubTypes[i] == (HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerProfileSubType)bridgedControllerHWInfo.hw_xInputSubType)
								{
									flag5 = true;
									break;
								}
							}
							if (!flag5)
							{
								return false;
							}
						}
						flag4 = true;
					}
					bool flag6 = false;
					if (flag3)
					{
						flag6 = true;
						if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_systemDeviceName) && this.ProductCategoryMatches(bridgedControllerHWInfo.hw_systemDeviceName.Trim()))
						{
							return true;
						}
					}
					if (flag2)
					{
						flag6 = true;
						if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_productName) && this.ProductNameMatches(bridgedControllerHWInfo.hw_productName.Trim()))
						{
							return true;
						}
					}
					return !flag6 && flag4;
				}

				// Token: 0x0600243A RID: 9274 RVA: 0x0008F554 File Offset: 0x0008D754
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x0600243B RID: 9275 RVA: 0x0008F570 File Offset: 0x0008D770
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productCategory_useRegex = this.productCategory_useRegex;
					matchingCriteria.productCategory = ArrayTools.ShallowCopy<string>(this.productCategory);
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.primaryProfileType = this.primaryProfileType;
					matchingCriteria.profileSubTypes = ArrayTools.ShallowCopy<HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerProfileSubType>(this.profileSubTypes);
				}

				// Token: 0x0600243C RID: 9276 RVA: 0x0008F5E8 File Offset: 0x0008D7E8
				private bool HasProductCategory()
				{
					if (this.productCategory == null)
					{
						return false;
					}
					for (int i = 0; i < this.productCategory.Length; i++)
					{
						if (!string.IsNullOrEmpty(this.productCategory[i]))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600243D RID: 9277 RVA: 0x0008F624 File Offset: 0x0008D824
				private bool ProductCategoryMatches(string name)
				{
					if (this.productCategory == null)
					{
						return false;
					}
					for (int i = 0; i < this.productCategory.Length; i++)
					{
						string searchFor = this.productCategory[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(name, searchFor, this.productCategory_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600243E RID: 9278 RVA: 0x0008F66C File Offset: 0x0008D86C
				private bool HasProductName()
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(this.productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600243F RID: 9279 RVA: 0x0008F6A8 File Offset: 0x0008D8A8
				private bool ProductNameMatches(string name)
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						string searchFor = this.productName[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(name, searchFor, this.productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x04001468 RID: 5224
				public bool productCategory_useRegex;

				// Token: 0x04001469 RID: 5225
				public string[] productCategory;

				// Token: 0x0400146A RID: 5226
				public bool productName_useRegex;

				// Token: 0x0400146B RID: 5227
				public string[] productName;

				// Token: 0x0400146C RID: 5228
				public HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerProfileTypeFlags primaryProfileType;

				// Token: 0x0400146D RID: 5229
				public HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerProfileSubType[] profileSubTypes;
			}

			// Token: 0x02000367 RID: 871
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x17000867 RID: 2151
				// (get) Token: 0x06002441 RID: 9281 RVA: 0x0001AEA1 File Offset: 0x000190A1
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x17000868 RID: 2152
				// (get) Token: 0x06002442 RID: 9282 RVA: 0x0001AEB5 File Offset: 0x000190B5
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x17000869 RID: 2153
				// (get) Token: 0x06002443 RID: 9283 RVA: 0x0001AEC9 File Offset: 0x000190C9
				public int compoundElementCount
				{
					get
					{
						if (this.compoundElements == null)
						{
							return 0;
						}
						return this.compoundElements.Length;
					}
				}

				// Token: 0x06002444 RID: 9284 RVA: 0x0008F6F0 File Offset: 0x0008D8F0
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x06002445 RID: 9285 RVA: 0x0008F754 File Offset: 0x0008D954
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int i = 0;
					while (i < this.axisCount)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							if (sourceType == 0)
							{
								axisRange = AxisRange.Positive;
								return true;
							}
							if (sourceType == 1 || sourceType == 100)
							{
								axisRange = this.axes[i].sourceAxisRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							}
							throw new NotImplementedException();
						}
						else
						{
							i++;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x06002446 RID: 9286 RVA: 0x0008F7DC File Offset: 0x0008D9DC
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Elements elements = new HardwareJoystickMap.Platform_AppleGCController_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002447 RID: 9287 RVA: 0x0008F7F8 File Offset: 0x0008D9F8
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_AppleGCController_Base.Elements elements = destination as HardwareJoystickMap.Platform_AppleGCController_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController_Base.Button>(this.buttons);
					elements.compoundElements = ArrayTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement>(this.compoundElements);
				}

				// Token: 0x0400146E RID: 5230
				public HardwareJoystickMap.Platform_AppleGCController_Base.Axis[] axes;

				// Token: 0x0400146F RID: 5231
				public HardwareJoystickMap.Platform_AppleGCController_Base.Button[] buttons;

				// Token: 0x04001470 RID: 5232
				public HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement[] compoundElements;
			}

			// Token: 0x02000368 RID: 872
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x06002449 RID: 9289 RVA: 0x0008F84C File Offset: 0x0008DA4C
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Button button = new HardwareJoystickMap.Platform_AppleGCController_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x0600244A RID: 9290 RVA: 0x0008F868 File Offset: 0x0008DA68
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_AppleGCController_Base.Button button = destination as HardwareJoystickMap.Platform_AppleGCController_Base.Button;
					if (button == null)
					{
						return;
					}
					button.sourceElementId = this.sourceElementId;
				}

				// Token: 0x04001471 RID: 5233
				public HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerElementIdentifier sourceElementId;
			}

			// Token: 0x02000369 RID: 873
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x0600244C RID: 9292 RVA: 0x0008F894 File Offset: 0x0008DA94
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Axis axis = new HardwareJoystickMap.Platform_AppleGCController_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x0600244D RID: 9293 RVA: 0x0008F8B0 File Offset: 0x0008DAB0
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_AppleGCController_Base.Axis axis = destination as HardwareJoystickMap.Platform_AppleGCController_Base.Axis;
					if (axis == null)
					{
						return;
					}
					axis.sourceElementId = this.sourceElementId;
				}

				// Token: 0x04001472 RID: 5234
				public HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerElementIdentifier sourceElementId;
			}

			// Token: 0x0200036A RID: 874
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public sealed class CompoundElement : IDeepCloneable
			{
				// Token: 0x0600244F RID: 9295 RVA: 0x0001AEDD File Offset: 0x000190DD
				internal void CopyVars(HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement destination)
				{
					destination.elementIdentifier = this.elementIdentifier;
					destination.sourceElementIndex = this.sourceElementIndex;
					destination.sourceElementId = this.sourceElementId;
				}

				// Token: 0x06002450 RID: 9296 RVA: 0x0008F8DC File Offset: 0x0008DADC
				public object DeepClone()
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement compoundElement = new HardwareJoystickMap.Platform_AppleGCController_Base.CompoundElement();
					this.CopyVars(compoundElement);
					return compoundElement;
				}

				// Token: 0x04001473 RID: 5235
				public int elementIdentifier;

				// Token: 0x04001474 RID: 5236
				public int sourceElementIndex;

				// Token: 0x04001475 RID: 5237
				public HardwareJoystickMap.Platform_AppleGCController_Base.AppleGCControllerElementIdentifierCompoundElements sourceElementId;
			}

			// Token: 0x0200036B RID: 875
			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileTypeFlags
			{
				// Token: 0x04001477 RID: 5239
				None,
				// Token: 0x04001478 RID: 5240
				Generic,
				// Token: 0x04001479 RID: 5241
				ExtendedGamepad,
				// Token: 0x0400147A RID: 5242
				MicroGamepad = 4,
				// Token: 0x0400147B RID: 5243
				Unknown = -2147483648
			}

			// Token: 0x0200036C RID: 876
			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileSubType
			{
				// Token: 0x0400147D RID: 5245
				None,
				// Token: 0x0400147E RID: 5246
				Xbox,
				// Token: 0x0400147F RID: 5247
				DualShock,
				// Token: 0x04001480 RID: 5248
				DualSense,
				// Token: 0x04001481 RID: 5249
				Unknown = -1
			}

			// Token: 0x0200036D RID: 877
			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerElementIdentifier
			{
				// Token: 0x04001483 RID: 5251
				None,
				// Token: 0x04001484 RID: 5252
				A,
				// Token: 0x04001485 RID: 5253
				B,
				// Token: 0x04001486 RID: 5254
				X,
				// Token: 0x04001487 RID: 5255
				Y,
				// Token: 0x04001488 RID: 5256
				LeftShoulder,
				// Token: 0x04001489 RID: 5257
				RightShoulder,
				// Token: 0x0400148A RID: 5258
				Menu,
				// Token: 0x0400148B RID: 5259
				Options,
				// Token: 0x0400148C RID: 5260
				Home,
				// Token: 0x0400148D RID: 5261
				LeftStickButton,
				// Token: 0x0400148E RID: 5262
				RightStickButton,
				// Token: 0x0400148F RID: 5263
				DPadUp,
				// Token: 0x04001490 RID: 5264
				DPadRight,
				// Token: 0x04001491 RID: 5265
				DPadDown,
				// Token: 0x04001492 RID: 5266
				DPadLeft,
				// Token: 0x04001493 RID: 5267
				LeftStickX,
				// Token: 0x04001494 RID: 5268
				LeftStickY,
				// Token: 0x04001495 RID: 5269
				RightStickX,
				// Token: 0x04001496 RID: 5270
				RightStickY,
				// Token: 0x04001497 RID: 5271
				LeftTrigger,
				// Token: 0x04001498 RID: 5272
				RightTrigger,
				// Token: 0x04001499 RID: 5273
				DPadVertical,
				// Token: 0x0400149A RID: 5274
				DPadHorizontal,
				// Token: 0x0400149B RID: 5275
				TouchpadButton,
				// Token: 0x0400149C RID: 5276
				Paddle1,
				// Token: 0x0400149D RID: 5277
				Paddle2,
				// Token: 0x0400149E RID: 5278
				Paddle3,
				// Token: 0x0400149F RID: 5279
				Paddle4,
				// Token: 0x040014A0 RID: 5280
				IndexedButton,
				// Token: 0x040014A1 RID: 5281
				IndexedAxis
			}

			// Token: 0x0200036E RID: 878
			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerElementIdentifierCompoundElements
			{
				// Token: 0x040014A3 RID: 5283
				None,
				// Token: 0x040014A4 RID: 5284
				IndexedStick = 31,
				// Token: 0x040014A5 RID: 5285
				IndexedDPad,
				// Token: 0x040014A6 RID: 5286
				LeftStick,
				// Token: 0x040014A7 RID: 5287
				RightStick,
				// Token: 0x040014A8 RID: 5288
				DPad
			}

			// Token: 0x0200036F RID: 879
			[CustomObfuscation(rename = false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal enum AppleGCControllerElementIdentifierAxes
			{
				// Token: 0x040014AA RID: 5290
				[CustomObfuscation(rename = false)]
				None,
				// Token: 0x040014AB RID: 5291
				[CustomObfuscation(rename = false)]
				LeftStickX = 16,
				// Token: 0x040014AC RID: 5292
				[CustomObfuscation(rename = false)]
				LeftStickY,
				// Token: 0x040014AD RID: 5293
				[CustomObfuscation(rename = false)]
				RightStickX,
				// Token: 0x040014AE RID: 5294
				[CustomObfuscation(rename = false)]
				RightStickY,
				// Token: 0x040014AF RID: 5295
				[CustomObfuscation(rename = false)]
				DPadVertical = 22,
				// Token: 0x040014B0 RID: 5296
				[CustomObfuscation(rename = false)]
				DPadHorizontal,
				// Token: 0x040014B1 RID: 5297
				[CustomObfuscation(rename = false)]
				IndexedAxis = 30
			}

			// Token: 0x02000370 RID: 880
			[CustomObfuscation(rename = false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal enum AppleGCControllerElementIdentifierButtons
			{
				// Token: 0x040014B3 RID: 5299
				[CustomObfuscation(rename = false)]
				None,
				// Token: 0x040014B4 RID: 5300
				[CustomObfuscation(rename = false)]
				A,
				// Token: 0x040014B5 RID: 5301
				[CustomObfuscation(rename = false)]
				B,
				// Token: 0x040014B6 RID: 5302
				[CustomObfuscation(rename = false)]
				X,
				// Token: 0x040014B7 RID: 5303
				[CustomObfuscation(rename = false)]
				Y,
				// Token: 0x040014B8 RID: 5304
				[CustomObfuscation(rename = false)]
				LeftShoulder,
				// Token: 0x040014B9 RID: 5305
				[CustomObfuscation(rename = false)]
				RightShoulder,
				// Token: 0x040014BA RID: 5306
				[CustomObfuscation(rename = false)]
				Menu,
				// Token: 0x040014BB RID: 5307
				[CustomObfuscation(rename = false)]
				Options,
				// Token: 0x040014BC RID: 5308
				[CustomObfuscation(rename = false)]
				Home,
				// Token: 0x040014BD RID: 5309
				[CustomObfuscation(rename = false)]
				LeftStickButton,
				// Token: 0x040014BE RID: 5310
				[CustomObfuscation(rename = false)]
				RightStickButton,
				// Token: 0x040014BF RID: 5311
				[CustomObfuscation(rename = false)]
				DPadUp,
				// Token: 0x040014C0 RID: 5312
				[CustomObfuscation(rename = false)]
				DPadRight,
				// Token: 0x040014C1 RID: 5313
				[CustomObfuscation(rename = false)]
				DPadDown,
				// Token: 0x040014C2 RID: 5314
				[CustomObfuscation(rename = false)]
				DPadLeft,
				// Token: 0x040014C3 RID: 5315
				[CustomObfuscation(rename = false)]
				LeftTrigger = 20,
				// Token: 0x040014C4 RID: 5316
				[CustomObfuscation(rename = false)]
				RightTrigger,
				// Token: 0x040014C5 RID: 5317
				[CustomObfuscation(rename = false)]
				TouchpadButton = 24,
				// Token: 0x040014C6 RID: 5318
				[CustomObfuscation(rename = false)]
				Paddle1,
				// Token: 0x040014C7 RID: 5319
				[CustomObfuscation(rename = false)]
				Paddle2,
				// Token: 0x040014C8 RID: 5320
				[CustomObfuscation(rename = false)]
				Paddle3,
				// Token: 0x040014C9 RID: 5321
				[CustomObfuscation(rename = false)]
				Paddle4,
				// Token: 0x040014CA RID: 5322
				[CustomObfuscation(rename = false)]
				IndexedButton
			}
		}

		// Token: 0x02000373 RID: 883
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_AppleGCController : HardwareJoystickMap.Platform_AppleGCController_Base
		{
			// Token: 0x06002462 RID: 9314 RVA: 0x0001AF57 File Offset: 0x00019157
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06002463 RID: 9315 RVA: 0x0008FAB8 File Offset: 0x0008DCB8
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002464 RID: 9316 RVA: 0x0008FB14 File Offset: 0x0008DD14
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_AppleGCController platform_AppleGCController = new HardwareJoystickMap.Platform_AppleGCController();
				this.CopyVars(platform_AppleGCController);
				return platform_AppleGCController;
			}

			// Token: 0x06002465 RID: 9317 RVA: 0x0008FB30 File Offset: 0x0008DD30
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_AppleGCController platform_AppleGCController = destination as HardwareJoystickMap.Platform_AppleGCController;
				if (platform_AppleGCController == null)
				{
					return;
				}
				platform_AppleGCController.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_AppleGCController_Base>(this.variants);
			}

			// Token: 0x06002466 RID: 9318 RVA: 0x0008FB60 File Offset: 0x0008DD60
			internal static HardwareJoystickMap.Platform_AppleGCController CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				HardwareJoystickMap.Platform_AppleGCController platform_AppleGCController = new HardwareJoystickMap.Platform_AppleGCController();
				ControllerElementIdentifier[] unknownJoystickElementIdentifiers_orig = Consts.unknownJoystickElementIdentifiers_orig;
				platform_AppleGCController.controllerName = "Unknown Controller";
				platform_AppleGCController.description = "";
				HardwareJoystickMap.Platform_AppleGCController_Base.Elements elements = new HardwareJoystickMap.Platform_AppleGCController_Base.Elements();
				platform_AppleGCController.elements = elements;
				int num = 32;
				elements.axes = new HardwareJoystickMap.Platform_AppleGCController_Base.Axis[num];
				for (int i = 0; i < num; i++)
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Axis axis = new HardwareJoystickMap.Platform_AppleGCController_Base.Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = false;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				elements.buttons = new HardwareJoystickMap.Platform_AppleGCController_Base.Button[num2];
				for (int j = 0; j < num2; j++)
				{
					HardwareJoystickMap.Platform_AppleGCController_Base.Button button = new HardwareJoystickMap.Platform_AppleGCController_Base.Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_AppleGCController_Base.MatchingCriteria();
				platform_AppleGCController.matchingCriteria = matchingCriteria;
				platform_AppleGCController.variants = new HardwareJoystickMap.Platform_AppleGCController_Base[0];
				return platform_AppleGCController;
			}

			// Token: 0x040014D5 RID: 5333
			public HardwareJoystickMap.Platform_AppleGCController_Base[] variants;
		}

		// Token: 0x02000374 RID: 884
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public class Platform_WindowsWGI_Base : HardwareJoystickMap.Platform_Custom
		{
			// Token: 0x1700086E RID: 2158
			// (get) Token: 0x06002468 RID: 9320 RVA: 0x0001AF67 File Offset: 0x00019167
			public override int assignedButtonCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.buttonCount;
				}
			}

			// Token: 0x1700086F RID: 2159
			// (get) Token: 0x06002469 RID: 9321 RVA: 0x0001AF7E File Offset: 0x0001917E
			public override int assignedAxisCount
			{
				get
				{
					if (this.elements == null)
					{
						return 0;
					}
					return this.elements.axisCount;
				}
			}

			// Token: 0x17000870 RID: 2160
			// (get) Token: 0x0600246A RID: 9322 RVA: 0x0001AF95 File Offset: 0x00019195
			public override string controllerNameOverride
			{
				get
				{
					return this.controllerName;
				}
			}

			// Token: 0x17000871 RID: 2161
			// (get) Token: 0x0600246B RID: 9323 RVA: 0x000089D7 File Offset: 0x00006BD7
			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.WindowsWGI;
				}
			}

			// Token: 0x17000872 RID: 2162
			// (get) Token: 0x0600246C RID: 9324 RVA: 0x0008FCC4 File Offset: 0x0008DEC4
			internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
			{
				get
				{
					if (this._axesOrigGame == null)
					{
						HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = this.Axes_orig;
						if (axes_orig != null)
						{
							this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								this._axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return this._axesOrigGame;
				}
			}

			// Token: 0x17000873 RID: 2163
			// (get) Token: 0x0600246D RID: 9325 RVA: 0x0008FD10 File Offset: 0x0008DF10
			internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
			{
				get
				{
					if (this._buttonsOrigGame == null)
					{
						HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = this.Buttons_orig;
						if (buttons_orig != null)
						{
							this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								this._buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return this._buttonsOrigGame;
				}
			}

			// Token: 0x17000874 RID: 2164
			// (get) Token: 0x0600246E RID: 9326 RVA: 0x0001AF9D File Offset: 0x0001919D
			internal HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] Axes_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.axes;
				}
			}

			// Token: 0x17000875 RID: 2165
			// (get) Token: 0x0600246F RID: 9327 RVA: 0x0001AFB4 File Offset: 0x000191B4
			internal HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] Buttons_orig
			{
				get
				{
					if (this.elements == null)
					{
						return null;
					}
					return this.elements.buttons;
				}
			}

			// Token: 0x17000876 RID: 2166
			// (get) Token: 0x06002470 RID: 9328 RVA: 0x0001AFCB File Offset: 0x000191CB
			internal override bool hasData
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.hasData && (this.assignedButtonCount != 0 || this.assignedAxisCount != 0);
				}
			}

			// Token: 0x17000877 RID: 2167
			// (get) Token: 0x06002471 RID: 9329 RVA: 0x0001AFF9 File Offset: 0x000191F9
			internal override bool disabled
			{
				get
				{
					return this.matchingCriteria != null && this.matchingCriteria.disabled;
				}
			}

			// Token: 0x17000878 RID: 2168
			// (get) Token: 0x06002472 RID: 9330 RVA: 0x0001B010 File Offset: 0x00019210
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
				}
			}

			// Token: 0x17000879 RID: 2169
			// (get) Token: 0x06002473 RID: 9331 RVA: 0x0001B031 File Offset: 0x00019231
			internal override HardwareJoystickMap.Elements_Base elements_base
			{
				get
				{
					return this.elements;
				}
			}

			// Token: 0x06002474 RID: 9332 RVA: 0x000067FE File Offset: 0x000049FE
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			// Token: 0x06002475 RID: 9333 RVA: 0x0001B039 File Offset: 0x00019239
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			// Token: 0x06002476 RID: 9334 RVA: 0x0001B060 File Offset: 0x00019260
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
			{
				if (this.elements == null || this.elements.axes == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.axes.Length; i = num + 1)
				{
					yield return this.elements.axes[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002477 RID: 9335 RVA: 0x0001B070 File Offset: 0x00019270
			internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
			{
				if (this.elements == null || this.elements.buttons == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.elements.buttons.Length; i = num + 1)
				{
					yield return this.elements.buttons[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x06002478 RID: 9336 RVA: 0x0008FD5C File Offset: 0x0008DF5C
			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_WindowsWGI_Base.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (((HardwareJoystickMap.Platform_WindowsWGI_Base.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06002479 RID: 9337 RVA: 0x0008FDFC File Offset: 0x0008DFFC
			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[this.assignedButtonCount];
				axes = new int[this.assignedAxisCount];
				int num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Button button2 = (HardwareJoystickMap.Platform_WindowsWGI_Base.Button)button;
					buttons[num] = button2.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Axis axis2 = (HardwareJoystickMap.Platform_WindowsWGI_Base.Axis)axis;
					axes[num] = axis2.elementIdentifier;
					num++;
				}
			}

			// Token: 0x0600247A RID: 9338 RVA: 0x0008FEC0 File Offset: 0x0008E0C0
			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = this.Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (this.Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, true);
				}
				return array;
			}

			// Token: 0x0600247B RID: 9339 RVA: 0x0008FFD8 File Offset: 0x0008E1D8
			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (this.Axes_orig == null)
				{
					return;
				}
				axisRanges = new AxisRange[this.Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[this.Axes_orig.Length];
				for (int i = 0; i < this.Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(this.Axes_orig[i].axisInfo, true);
					if (this.Axes_orig[i].sourceType == 1 || this.Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = this.Axes_orig[i].sourceAxisRange;
					}
					else
					{
						if (this.Axes_orig[i].sourceType != 0 && this.Axes_orig[i].sourceType != 2)
						{
							throw new Exception();
						}
						axisRanges[i] = AxisRange.Full;
					}
				}
			}

			// Token: 0x0600247C RID: 9340 RVA: 0x000900A0 File Offset: 0x0008E2A0
			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (this.Buttons_orig == null)
				{
					return;
				}
				buttonInfos = new HardwareButtonInfo[this.Buttons_orig.Length];
				for (int i = 0; i < this.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(this.Buttons_orig[i].buttonInfo, true);
				}
			}

			// Token: 0x0600247D RID: 9341 RVA: 0x0001B080 File Offset: 0x00019280
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (this.elements == null)
				{
					return ControllerElementType.Axis;
				}
				return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			// Token: 0x0600247E RID: 9342 RVA: 0x0001B098 File Offset: 0x00019298
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (this.elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			// Token: 0x0600247F RID: 9343 RVA: 0x000900F4 File Offset: 0x0008E2F4
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base platform_WindowsWGI_Base = new HardwareJoystickMap.Platform_WindowsWGI_Base();
				this.CopyVars(platform_WindowsWGI_Base);
				return platform_WindowsWGI_Base;
			}

			// Token: 0x06002480 RID: 9344 RVA: 0x00090110 File Offset: 0x0008E310
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_WindowsWGI_Base platform_WindowsWGI_Base = destination as HardwareJoystickMap.Platform_WindowsWGI_Base;
				if (platform_WindowsWGI_Base == null)
				{
					return;
				}
				platform_WindowsWGI_Base.matchingCriteria = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria>(this.matchingCriteria);
				platform_WindowsWGI_Base.elements = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsWGI_Base.Elements>(this.elements);
				platform_WindowsWGI_Base.controllerName = this.controllerName;
			}

			// Token: 0x040014D6 RID: 5334
			public HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria matchingCriteria;

			// Token: 0x040014D7 RID: 5335
			public HardwareJoystickMap.Platform_WindowsWGI_Base.Elements elements;

			// Token: 0x040014D8 RID: 5336
			public string controllerName;

			// Token: 0x040014D9 RID: 5337
			private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

			// Token: 0x040014DA RID: 5338
			private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

			// Token: 0x02000375 RID: 885
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
			{
				// Token: 0x1700087A RID: 2170
				// (get) Token: 0x06002482 RID: 9346 RVA: 0x0001B0B4 File Offset: 0x000192B4
				internal override bool hasData
				{
					get
					{
						return base.hasData || (this.productName != null && this.productName.Length != 0) || this.deviceType != HardwareJoystickMap.Platform_WindowsWGI_Base.DeviceType.None || (this.vidPid != null && this.vidPid.Length != 0);
					}
				}

				// Token: 0x1700087B RID: 2171
				// (get) Token: 0x06002483 RID: 9347 RVA: 0x000153C4 File Offset: 0x000135C4
				internal override bool isAllowed
				{
					get
					{
						return base.isAllowed && !this.disabled;
					}
				}

				// Token: 0x06002484 RID: 9348 RVA: 0x0001B0F1 File Offset: 0x000192F1
				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched) && (this.hatCount < 0 || this.hatCount == bridgedControllerHWInfo.hardwareHatCount);
				}

				// Token: 0x06002485 RID: 9349 RVA: 0x00090160 File Offset: 0x0008E360
				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
					{
						return true;
					}
					if (this.alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					bool flag;
					if (!this.ElementCountsMatch(bridgedControllerHWInfo, out flag))
					{
						return false;
					}
					if ((!string.IsNullOrEmpty(bridgedControllerHWInfo.definitionMatchTag) || !string.IsNullOrEmpty(this.tag)) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, this.tag, StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					if (this.deviceType != HardwareJoystickMap.Platform_WindowsWGI_Base.DeviceType.None)
					{
						if (this.deviceType != (HardwareJoystickMap.Platform_WindowsWGI_Base.DeviceType)bridgedControllerHWInfo.deviceType)
						{
							return false;
						}
						if (!this.HasProductName() && (this.vidPid == null || this.vidPid.Length == 0))
						{
							return true;
						}
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (this.vidPid != null)
						{
							for (int i = 0; i < this.vidPid.Length; i++)
							{
								int vendorId = this.vidPid[i].vendorId;
								int productId = this.vidPid[i].productId;
								if (ArrayTools.Contains<int>(Consts.questionableVIDs, (int)bridgedControllerHWInfo.hw_pidVid.vendorId))
								{
									string name = (bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName;
									if (!this.ProductNameMatches(name))
									{
										return false;
									}
								}
								if ((vendorId < 0 || (int)bridgedControllerHWInfo.hw_pidVid.vendorId == vendorId) && (productId < 0 || (int)bridgedControllerHWInfo.hw_pidVid.productId == productId))
								{
									return true;
								}
							}
						}
						return false;
					}
					return this.ProductNameMatches(text);
				}

				// Token: 0x06002486 RID: 9350 RVA: 0x000902D8 File Offset: 0x0008E4D8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria();
					this.CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				// Token: 0x06002487 RID: 9351 RVA: 0x000902F4 File Offset: 0x0008E4F4
				internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria matchingCriteria = destination as HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					matchingCriteria.productName_useRegex = this.productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy<string>(this.productName);
					matchingCriteria.deviceType = this.deviceType;
					matchingCriteria.hatCount = this.hatCount;
					matchingCriteria.vidPid = ArrayTools.ShallowCopy<HardwareJoystickMap.VidPid>(this.vidPid);
				}

				// Token: 0x06002488 RID: 9352 RVA: 0x0009035C File Offset: 0x0008E55C
				private bool HasProductName()
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(this.productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06002489 RID: 9353 RVA: 0x00090398 File Offset: 0x0008E598
				private bool ProductNameMatches(string name)
				{
					if (this.productName == null)
					{
						return false;
					}
					for (int i = 0; i < this.productName.Length; i++)
					{
						string searchFor = this.productName[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(name, searchFor, this.productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x040014DB RID: 5339
				public bool productName_useRegex;

				// Token: 0x040014DC RID: 5340
				public string[] productName;

				// Token: 0x040014DD RID: 5341
				public HardwareJoystickMap.VidPid[] vidPid;

				// Token: 0x040014DE RID: 5342
				public HardwareJoystickMap.Platform_WindowsWGI_Base.DeviceType deviceType;

				// Token: 0x040014DF RID: 5343
				public int hatCount;
			}

			// Token: 0x02000376 RID: 886
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
			{
				// Token: 0x1700087C RID: 2172
				// (get) Token: 0x0600248B RID: 9355 RVA: 0x0001B118 File Offset: 0x00019318
				public override int buttonCount
				{
					get
					{
						if (this.buttons == null)
						{
							return 0;
						}
						return this.buttons.Length;
					}
				}

				// Token: 0x1700087D RID: 2173
				// (get) Token: 0x0600248C RID: 9356 RVA: 0x0001B12C File Offset: 0x0001932C
				public override int axisCount
				{
					get
					{
						if (this.axes == null)
						{
							return 0;
						}
						return this.axes.Length;
					}
				}

				// Token: 0x0600248D RID: 9357 RVA: 0x000903E0 File Offset: 0x0008E5E0
				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < this.buttonCount; j++)
					{
						if (this.buttons[j].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				// Token: 0x0600248E RID: 9358 RVA: 0x00090444 File Offset: 0x0008E644
				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < this.axisCount; i++)
					{
						if (this.axes[i].elementIdentifier == elementIdentifier.id)
						{
							int sourceType = this.axes[i].sourceType;
							switch (sourceType)
							{
							case 0:
								axisRange = AxisRange.Positive;
								return true;
							case 1:
								break;
							case 2:
								axisRange = this.axes[i].sourceHatRange;
								if (this.axes[i].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
								}
								return true;
							default:
								if (sourceType != 100)
								{
									throw new NotImplementedException();
								}
								break;
							}
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				// Token: 0x0600248F RID: 9359 RVA: 0x00090508 File Offset: 0x0008E708
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Elements elements = new HardwareJoystickMap.Platform_WindowsWGI_Base.Elements();
					this.CopyVars(elements);
					return elements;
				}

				// Token: 0x06002490 RID: 9360 RVA: 0x00090524 File Offset: 0x0008E724
				internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WindowsWGI_Base.Elements elements = destination as HardwareJoystickMap.Platform_WindowsWGI_Base.Elements;
					if (elements == null)
					{
						return;
					}
					elements.axes = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WindowsWGI_Base.Axis>(this.axes);
					elements.buttons = ArrayTools.DeepClone<HardwareJoystickMap.Platform_WindowsWGI_Base.Button>(this.buttons);
				}

				// Token: 0x040014E0 RID: 5344
				public HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes;

				// Token: 0x040014E1 RID: 5345
				public HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons;
			}

			// Token: 0x02000377 RID: 887
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
			{
				// Token: 0x06002492 RID: 9362 RVA: 0x00090568 File Offset: 0x0008E768
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Button button = new HardwareJoystickMap.Platform_WindowsWGI_Base.Button();
					this.CopyVars(button);
					return button;
				}

				// Token: 0x06002493 RID: 9363 RVA: 0x00090584 File Offset: 0x0008E784
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WindowsWGI_Base.Button button = destination as HardwareJoystickMap.Platform_WindowsWGI_Base.Button;
					if (button == null)
					{
						return;
					}
					button.sourceHat = this.sourceHat;
					button.sourceHatDirection = this.sourceHatDirection;
					button.sourceHatType = this.sourceHatType;
				}

				// Token: 0x040014E2 RID: 5346
				public int sourceHat;

				// Token: 0x040014E3 RID: 5347
				public HatDirection sourceHatDirection;

				// Token: 0x040014E4 RID: 5348
				public HatType sourceHatType;
			}

			// Token: 0x02000378 RID: 888
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			[Serializable]
			public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
			{
				// Token: 0x06002495 RID: 9365 RVA: 0x000905C8 File Offset: 0x0008E7C8
				public override object DeepClone()
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Axis axis = new HardwareJoystickMap.Platform_WindowsWGI_Base.Axis();
					this.CopyVars(axis);
					return axis;
				}

				// Token: 0x06002496 RID: 9366 RVA: 0x000905E4 File Offset: 0x0008E7E4
				internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
				{
					base.CopyVars(destination);
					HardwareJoystickMap.Platform_WindowsWGI_Base.Axis axis = destination as HardwareJoystickMap.Platform_WindowsWGI_Base.Axis;
					if (axis == null)
					{
						return;
					}
					axis.sourceHat = this.sourceHat;
					axis.sourceHatDirection = this.sourceHatDirection;
					axis.sourceHatType = this.sourceHatType;
					axis.sourceHatRange = this.sourceHatRange;
				}

				// Token: 0x040014E5 RID: 5349
				public int sourceHat;

				// Token: 0x040014E6 RID: 5350
				public AxisDirection sourceHatDirection;

				// Token: 0x040014E7 RID: 5351
				public HatType sourceHatType;

				// Token: 0x040014E8 RID: 5352
				public AxisRange sourceHatRange;
			}

			// Token: 0x02000379 RID: 889
			public enum DeviceType
			{
				// Token: 0x040014EA RID: 5354
				None,
				// Token: 0x040014EB RID: 5355
				Gamepad
			}
		}

		// Token: 0x0200037C RID: 892
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Platform_WindowsWGI : HardwareJoystickMap.Platform_WindowsWGI_Base
		{
			// Token: 0x060024A8 RID: 9384 RVA: 0x0001B194 File Offset: 0x00019394
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x060024A9 RID: 9385 RVA: 0x000907F4 File Offset: 0x0008E9F4
			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < this.variants.Length; i++)
					{
						int num;
						if (this.variants[i] != null && this.variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060024AA RID: 9386 RVA: 0x00090850 File Offset: 0x0008EA50
			public override object DeepClone()
			{
				HardwareJoystickMap.Platform_WindowsWGI platform_WindowsWGI = new HardwareJoystickMap.Platform_WindowsWGI();
				this.CopyVars(platform_WindowsWGI);
				return platform_WindowsWGI;
			}

			// Token: 0x060024AB RID: 9387 RVA: 0x0009086C File Offset: 0x0008EA6C
			internal override void CopyVars(HardwareJoystickMap.Platform destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMap.Platform_WindowsWGI platform_WindowsWGI = destination as HardwareJoystickMap.Platform_WindowsWGI;
				if (platform_WindowsWGI == null)
				{
					return;
				}
				platform_WindowsWGI.variants = MiscTools.DeepClone<HardwareJoystickMap.Platform_WindowsWGI_Base>(this.variants);
			}

			// Token: 0x060024AC RID: 9388 RVA: 0x0009089C File Offset: 0x0008EA9C
			internal static HardwareJoystickMap.Platform_WindowsWGI CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				HardwareJoystickMap.Platform_WindowsWGI platform_WindowsWGI = new HardwareJoystickMap.Platform_WindowsWGI();
				ControllerElementIdentifier[] unknownJoystickElementIdentifiers_orig = Consts.unknownJoystickElementIdentifiers_orig;
				platform_WindowsWGI.controllerName = "Unknown Controller";
				platform_WindowsWGI.description = "";
				HardwareJoystickMap.Platform_WindowsWGI_Base.Elements elements = new HardwareJoystickMap.Platform_WindowsWGI_Base.Elements();
				platform_WindowsWGI.elements = elements;
				int num = 32;
				elements.axes = new HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[num];
				for (int i = 0; i < num; i++)
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Axis axis = new HardwareJoystickMap.Platform_WindowsWGI_Base.Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = false;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				int num3 = 16 * 8;
				elements.buttons = new HardwareJoystickMap.Platform_WindowsWGI_Base.Button[num2 + num3];
				for (int j = 0; j < num2; j++)
				{
					HardwareJoystickMap.Platform_WindowsWGI_Base.Button button = new HardwareJoystickMap.Platform_WindowsWGI_Base.Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				int num4 = num2;
				int num5 = 160;
				int num6 = 224;
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						bool flag = l % 2 == 0;
						HardwareJoystickMap.Platform_WindowsWGI_Base.Button button2 = new HardwareJoystickMap.Platform_WindowsWGI_Base.Button();
						elements.buttons[num4++] = button2;
						button2.buttonInfo = new HardwareButtonInfo(false, false);
						HardwareJoystickMap.Platform_Custom.Element element = button2;
						int elementIdentifier;
						if (!flag)
						{
							num6 = (elementIdentifier = num6) + 1;
						}
						else
						{
							num5 = (elementIdentifier = num5) + 1;
						}
						element.elementIdentifier = elementIdentifier;
						button2.sourceHat = k;
						button2.sourceType = 2;
						button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
					}
				}
				HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria matchingCriteria = new HardwareJoystickMap.Platform_WindowsWGI_Base.MatchingCriteria();
				platform_WindowsWGI.matchingCriteria = matchingCriteria;
				platform_WindowsWGI.variants = new HardwareJoystickMap.Platform_WindowsWGI_Base[0];
				return platform_WindowsWGI;
			}

			// Token: 0x040014F6 RID: 5366
			public HardwareJoystickMap.Platform_WindowsWGI_Base[] variants;
		}
	}
}
