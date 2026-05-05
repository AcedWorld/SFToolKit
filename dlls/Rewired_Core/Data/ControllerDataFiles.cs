using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200024E RID: 590
	public sealed class ControllerDataFiles : ScriptableObject
	{
		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06001ADC RID: 6876 RVA: 0x00015C8B File Offset: 0x00013E8B
		public Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!(this.defaultHardwareJoystickMap == null))
				{
					return this.defaultHardwareJoystickMap.Guid;
				}
				return Guid.Empty;
			}
		}

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06001ADD RID: 6877 RVA: 0x00015CAC File Offset: 0x00013EAC
		// (set) Token: 0x06001ADE RID: 6878 RVA: 0x00015CB4 File Offset: 0x00013EB4
		public HardwareJoystickTemplateMap[] JoystickTemplates
		{
			get
			{
				return this.joystickTemplates;
			}
			set
			{
				this.joystickTemplates = value;
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06001ADF RID: 6879 RVA: 0x00015CBD File Offset: 0x00013EBD
		// (set) Token: 0x06001AE0 RID: 6880 RVA: 0x00015CC5 File Offset: 0x00013EC5
		public HardwareJoystickMap[] HardwareJoystickMaps
		{
			get
			{
				return this.hardwareJoystickMaps;
			}
			set
			{
				this.hardwareJoystickMaps = value;
			}
		}

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06001AE1 RID: 6881 RVA: 0x00015CCE File Offset: 0x00013ECE
		// (set) Token: 0x06001AE2 RID: 6882 RVA: 0x00015CD6 File Offset: 0x00013ED6
		public HardwareJoystickMap DefaultHardwareJoystickMap
		{
			get
			{
				return this.defaultHardwareJoystickMap;
			}
			set
			{
				this.defaultHardwareJoystickMap = value;
			}
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x00074054 File Offset: 0x00072254
		public string[] GetJoystickNames()
		{
			if (this.hardwareJoystickMaps == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < this.hardwareJoystickMaps.Length; i++)
			{
				if (!(this.hardwareJoystickMaps[i] == null) && !this.hardwareJoystickMaps[i].HideInLists)
				{
					list.Add(this.hardwareJoystickMaps[i].ControllerName);
				}
			}
			list.Insert(0, this.defaultHardwareJoystickMap.ControllerName);
			return list.ToArray();
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x000740D0 File Offset: 0x000722D0
		public string[] GetEditorJoystickNames()
		{
			if (this.hardwareJoystickMaps == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < this.hardwareJoystickMaps.Length; i++)
			{
				if (!(this.hardwareJoystickMaps[i] == null) && !this.hardwareJoystickMaps[i].HideInLists)
				{
					if (!string.IsNullOrEmpty(this.hardwareJoystickMaps[i].EditorControllerName))
					{
						list.Add(this.hardwareJoystickMaps[i].EditorControllerName);
					}
					else
					{
						list.Add(this.hardwareJoystickMaps[i].ControllerName);
					}
				}
			}
			list.Insert(0, this.defaultHardwareJoystickMap.ControllerName);
			return list.ToArray();
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x00074174 File Offset: 0x00072374
		public Guid[] GetJoystickGuids()
		{
			if (this.hardwareJoystickMaps == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			for (int i = 0; i < this.hardwareJoystickMaps.Length; i++)
			{
				if (!(this.hardwareJoystickMaps[i] == null) && !this.hardwareJoystickMaps[i].HideInLists)
				{
					list.Add(this.hardwareJoystickMaps[i].Guid);
				}
			}
			list.Insert(0, this.defaultHardwareJoystickMap.Guid);
			return list.ToArray();
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x000741F0 File Offset: 0x000723F0
		public string[] GetJoystickTemplateNames()
		{
			if (this.joystickTemplates == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < this.joystickTemplates.Length; i++)
			{
				if (!(this.joystickTemplates[i] == null))
				{
					list.Add(this.joystickTemplates[i].ControllerName);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x0007424C File Offset: 0x0007244C
		public Guid[] GetJoystickTemplateGuids()
		{
			if (this.joystickTemplates == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			for (int i = 0; i < this.joystickTemplates.Length; i++)
			{
				if (!(this.joystickTemplates[i] == null))
				{
					list.Add(this.joystickTemplates[i].Guid);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x000742A8 File Offset: 0x000724A8
		public HardwareJoystickMap GetHardwareJoystickMap(Guid guid)
		{
			if (this.hardwareJoystickMaps == null)
			{
				return null;
			}
			if (guid == this.defaultHardwareJoystickMap.Guid)
			{
				return this.defaultHardwareJoystickMap;
			}
			for (int i = 0; i < this.hardwareJoystickMaps.Length; i++)
			{
				if (!(this.hardwareJoystickMaps[i] == null) && this.hardwareJoystickMaps[i].Guid == guid)
				{
					return this.hardwareJoystickMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001AEA RID: 6890 RVA: 0x0007431C File Offset: 0x0007251C
		public HardwareJoystickTemplateMap GetJoystickTemplate(Guid guid)
		{
			if (this.joystickTemplates == null)
			{
				return null;
			}
			for (int i = 0; i < this.joystickTemplates.Length; i++)
			{
				if (!(this.joystickTemplates[i] == null) && this.joystickTemplates[i].Guid == guid)
				{
					return this.joystickTemplates[i];
				}
			}
			return null;
		}

		// Token: 0x06001AEB RID: 6891 RVA: 0x00015CF7 File Offset: 0x00013EF7
		public IHardwareControllerTemplateMap GetControllerTemplate(Guid guid)
		{
			return this.GetJoystickTemplate(guid);
		}

		// Token: 0x06001AEC RID: 6892 RVA: 0x00074378 File Offset: 0x00072578
		public IHardwareControllerMap GetHardwareJoystickOrTemplateMap(Guid guid)
		{
			HardwareJoystickMap hardwareJoystickMap = this.GetHardwareJoystickMap(guid);
			if (hardwareJoystickMap != null)
			{
				return hardwareJoystickMap;
			}
			return this.GetJoystickTemplate(guid);
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x000743A0 File Offset: 0x000725A0
		internal ControllerTemplateElementIdentifier pIiOPUSGnzaTfxuhQrhQfIoMHfEDA(Guid A_1, int A_2, out HardwareJoystickMap A_3)
		{
			A_3 = null;
			if (A_2 < 0)
			{
				return null;
			}
			if (A_1 == Guid.Empty)
			{
				return null;
			}
			A_3 = this.GetHardwareJoystickMap(A_1);
			if (A_3 == null)
			{
				return null;
			}
			foreach (Guid guid in A_3.TemplateGuids)
			{
				COootOIiwXGzUSdmLyqHaOKMeIvB coootOIiwXGzUSdmLyqHaOKMeIvB = this.dTqQVwDISJZDemPvAbgXbTdrRlSM(guid);
				if (coootOIiwXGzUSdmLyqHaOKMeIvB != null)
				{
					ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = coootOIiwXGzUSdmLyqHaOKMeIvB.grPlAFggxlMRFZfwGkMaZjUnSfNB(A_1, A_2);
					if (controllerTemplateElementIdentifier != null)
					{
						return controllerTemplateElementIdentifier;
					}
				}
			}
			return null;
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x00074434 File Offset: 0x00072634
		internal int dRcvyAFHPsqCinGETODjfDxvMOPp(Guid A_1, Guid A_2, int A_3, List<HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv> A_4)
		{
			if (A_3 < 0)
			{
				return 0;
			}
			if (A_2 == Guid.Empty)
			{
				return 0;
			}
			HardwareJoystickMap hardwareJoystickMap = this.GetHardwareJoystickMap(A_2);
			if (hardwareJoystickMap == null)
			{
				return 0;
			}
			if (!hardwareJoystickMap.ContainsTemplateGuid(A_1))
			{
				return 0;
			}
			COootOIiwXGzUSdmLyqHaOKMeIvB coootOIiwXGzUSdmLyqHaOKMeIvB = this.dTqQVwDISJZDemPvAbgXbTdrRlSM(A_1);
			if (coootOIiwXGzUSdmLyqHaOKMeIvB == null)
			{
				return 0;
			}
			return coootOIiwXGzUSdmLyqHaOKMeIvB.QTJiclENSsFlSCogpqemVyqvZqbHA(A_2, A_3, A_4);
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x0007448C File Offset: 0x0007268C
		internal HardwareJoystickMap_InputManager bYKGjlSTjPdeUuJkJiNnhxSonKVhA(Guid A_1, InputSource A_2)
		{
			this.wSRNZKRfdUdZOuWMTagVASvSOMXD();
			BridgedController bridgedController = new BridgedController
			{
				isMock = true,
				inputManagerSource = A_2,
				inputSource = A_2
			};
			HardwareJoystickMap hardwareJoystickMap = this.GetHardwareJoystickMap(A_1);
			if (hardwareJoystickMap != null)
			{
				InputPlatform inputPlatform;
				int num;
				HardwareJoystickMap.Platform platform;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = this.wkFaxSYpsicHcbBDiavNEUImQakfA(hardwareJoystickMap, bridgedController, true, out inputPlatform, out num, out platform);
				if (hardwareJoystickMap_InputManager != null)
				{
					return hardwareJoystickMap_InputManager;
				}
			}
			return this.defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(bridgedController);
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x000744F0 File Offset: 0x000726F0
		internal HardwareJoystickMap_InputManager bavNHeqJEpxWdAaJxQBUPtdrXCRD(BridgedControllerHWInfo A_1)
		{
			if (A_1 == null)
			{
				return null;
			}
			this.wSRNZKRfdUdZOuWMTagVASvSOMXD();
			if (A_1.inputSource == InputSource.SDL2 && A_1.hw_isSDL2Gamepad)
			{
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = this.QGVzKriueJnEmnMEURXgNJqGflWg(A_1);
				if (hardwareJoystickMap_InputManager != null)
				{
					return hardwareJoystickMap_InputManager;
				}
			}
			for (int i = 0; i < this.hardwareJoystickMaps.Length; i++)
			{
				InputPlatform inputPlatform;
				int num;
				HardwareJoystickMap.Platform platform;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager2 = this.wkFaxSYpsicHcbBDiavNEUImQakfA(this.hardwareJoystickMaps[i], A_1, true, out inputPlatform, out num, out platform);
				if (hardwareJoystickMap_InputManager2 != null)
				{
					return hardwareJoystickMap_InputManager2;
				}
			}
			for (int j = 0; j < this.hardwareJoystickMaps.Length; j++)
			{
				InputPlatform inputPlatform2;
				int num2;
				HardwareJoystickMap.Platform platform2;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager3 = this.wkFaxSYpsicHcbBDiavNEUImQakfA(this.hardwareJoystickMaps[j], A_1, false, out inputPlatform2, out num2, out platform2);
				if (hardwareJoystickMap_InputManager3 != null)
				{
					return hardwareJoystickMap_InputManager3;
				}
			}
			if (A_1.inputSource == InputSource.Fallback_PreConfigured)
			{
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager4 = this.nrNfeyztSefjoHdmHfPDDQzvLZlab(A_1, "[UNITY PRECONFIGURED JOYSTICK]");
				if (hardwareJoystickMap_InputManager4 != null)
				{
					hardwareJoystickMap_InputManager4.useSystemName = true;
					return hardwareJoystickMap_InputManager4;
				}
			}
			if (UnityTools.isAndroidPlatform && ReInput.configVars.android_supportUnknownGamepads)
			{
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager5 = this.QGVzKriueJnEmnMEURXgNJqGflWg(A_1);
				if (hardwareJoystickMap_InputManager5 != null)
				{
					return hardwareJoystickMap_InputManager5;
				}
			}
			return this.defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(A_1);
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x000745E8 File Offset: 0x000727E8
		private HardwareJoystickMap_InputManager wkFaxSYpsicHcbBDiavNEUImQakfA(HardwareJoystickMap A_1, BridgedControllerHWInfo A_2, bool A_3, out InputPlatform A_4, out int A_5, out HardwareJoystickMap.Platform A_6)
		{
			A_4 = InputPlatform.Unknown;
			A_5 = -1;
			A_6 = null;
			if (A_1 == null)
			{
				return null;
			}
			if (!A_1.Matches(A_2, A_3, false, out A_4, out A_5, out A_6))
			{
				return null;
			}
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = A_6.ToHardwareJoystickMap_InputManager(A_1, A_2.inputSource, A_4, A_5);
			if (hardwareJoystickMap_InputManager == null)
			{
				return null;
			}
			return hardwareJoystickMap_InputManager;
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x0007463C File Offset: 0x0007283C
		private HardwareJoystickMap_InputManager nrNfeyztSefjoHdmHfPDDQzvLZlab(BridgedControllerHWInfo A_1, string A_2)
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo(A_1);
			bridgedControllerHWInfo.hw_productName = A_2;
			bridgedControllerHWInfo.hardwareButtonCount = 0;
			bridgedControllerHWInfo.hardwareAxisCount = 0;
			bridgedControllerHWInfo.hardwareHatCount = 0;
			for (int i = 0; i < this.hardwareJoystickMaps.Length; i++)
			{
				InputPlatform actualInputPlatform;
				int variantIndex;
				HardwareJoystickMap.Platform platform;
				if (!(this.hardwareJoystickMaps[i] == null) && this.hardwareJoystickMaps[i].Matches(bridgedControllerHWInfo, false, false, out actualInputPlatform, out variantIndex, out platform))
				{
					HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = platform.ToHardwareJoystickMap_InputManager(this.hardwareJoystickMaps[i], A_1.inputSource, actualInputPlatform, variantIndex);
					if (hardwareJoystickMap_InputManager != null)
					{
						return hardwareJoystickMap_InputManager;
					}
				}
			}
			return null;
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x000746C8 File Offset: 0x000728C8
		private HardwareJoystickMap_InputManager QGVzKriueJnEmnMEURXgNJqGflWg(BridgedControllerHWInfo A_1)
		{
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = this.nrNfeyztSefjoHdmHfPDDQzvLZlab(A_1, "[STANDARDIZED GAMEPAD]");
			if (hardwareJoystickMap_InputManager == null)
			{
				return null;
			}
			hardwareJoystickMap_InputManager.useSystemName = true;
			return hardwareJoystickMap_InputManager;
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x000746F0 File Offset: 0x000728F0
		internal COootOIiwXGzUSdmLyqHaOKMeIvB dTqQVwDISJZDemPvAbgXbTdrRlSM(Guid A_1)
		{
			COootOIiwXGzUSdmLyqHaOKMeIvB coootOIiwXGzUSdmLyqHaOKMeIvB;
			if (this.vfhyoGAYYLsYLajegMMTcFskLopo.TryGetValue(A_1, out coootOIiwXGzUSdmLyqHaOKMeIvB))
			{
				return coootOIiwXGzUSdmLyqHaOKMeIvB;
			}
			HardwareJoystickTemplateMap joystickTemplate = this.GetJoystickTemplate(A_1);
			if (joystickTemplate == null)
			{
				return null;
			}
			coootOIiwXGzUSdmLyqHaOKMeIvB = joystickTemplate.GLvdgqXJwQYPqEgAecqKhEHxbJyab();
			this.vfhyoGAYYLsYLajegMMTcFskLopo.Add(A_1, coootOIiwXGzUSdmLyqHaOKMeIvB);
			return coootOIiwXGzUSdmLyqHaOKMeIvB;
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x00015D00 File Offset: 0x00013F00
		internal IHardwareControllerTemplateMap kxKktQsKYiLdrwjwHgKIXbZzEyzK(Guid A_1)
		{
			return this.dTqQVwDISJZDemPvAbgXbTdrRlSM(A_1);
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x00015D09 File Offset: 0x00013F09
		private void wSRNZKRfdUdZOuWMTagVASvSOMXD()
		{
			if (this.BfaHxXbxprXjyImtYOmnJChhokRkA)
			{
				return;
			}
			if (this.hardwareJoystickMaps == null || this.defaultHardwareJoystickMap == null || this.joystickTemplates == null)
			{
				Logger.LogError("ControllerDataFiles is missing critical data! The serialized data may have been corrupted. Please see the Known Issues in the documentation for possible causes and solutions.");
				return;
			}
			this.BfaHxXbxprXjyImtYOmnJChhokRkA = true;
		}

		// Token: 0x04000F71 RID: 3953
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap defaultHardwareJoystickMap;

		// Token: 0x04000F72 RID: 3954
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap[] hardwareJoystickMaps;

		// Token: 0x04000F73 RID: 3955
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickTemplateMap[] joystickTemplates;

		// Token: 0x04000F74 RID: 3956
		[NonSerialized]
		private bool BfaHxXbxprXjyImtYOmnJChhokRkA;

		// Token: 0x04000F75 RID: 3957
		[NonSerialized]
		private readonly ADictionary<Guid, COootOIiwXGzUSdmLyqHaOKMeIvB> vfhyoGAYYLsYLajegMMTcFskLopo = new ADictionary<Guid, COootOIiwXGzUSdmLyqHaOKMeIvB>(EqualityComparerNoAlloc<Guid>.Default);
	}
}
