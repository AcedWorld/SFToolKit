using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200025E RID: 606
	[Serializable]
	public sealed class UserData
	{
		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06001B9D RID: 7069 RVA: 0x000163E5 File Offset: 0x000145E5
		// (set) Token: 0x06001B9E RID: 7070 RVA: 0x000163ED File Offset: 0x000145ED
		internal IList<Player_Editor> VnvGwsIqlyaVDfkMStriDwUKMMSo { get; private set; }

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06001B9F RID: 7071 RVA: 0x000163F6 File Offset: 0x000145F6
		// (set) Token: 0x06001BA0 RID: 7072 RVA: 0x000163FE File Offset: 0x000145FE
		internal IList<InputAction> ABGnUJfDDpBzJwpBkZvuZruVRScv { get; private set; }

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001BA1 RID: 7073 RVA: 0x00016407 File Offset: 0x00014607
		// (set) Token: 0x06001BA2 RID: 7074 RVA: 0x0001640F File Offset: 0x0001460F
		internal IList<InputCategory> OQXvniYgjUwHSWNCrZGsvanndody { get; private set; }

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06001BA3 RID: 7075 RVA: 0x00016418 File Offset: 0x00014618
		// (set) Token: 0x06001BA4 RID: 7076 RVA: 0x00016420 File Offset: 0x00014620
		internal IList<InputBehavior> RkfefHOeXDEiuaVzhNeqQtLHptfo { get; private set; }

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06001BA5 RID: 7077 RVA: 0x00016429 File Offset: 0x00014629
		// (set) Token: 0x06001BA6 RID: 7078 RVA: 0x00016431 File Offset: 0x00014631
		internal IList<InputMapCategory> bxNZYrWGGMsIWHSTVpBBMkfCoErr { get; private set; }

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x06001BA7 RID: 7079 RVA: 0x0001643A File Offset: 0x0001463A
		// (set) Token: 0x06001BA8 RID: 7080 RVA: 0x00016442 File Offset: 0x00014642
		internal IList<InputLayout> lSnlmZCSxIICafYigEGAImxRqCRR { get; private set; }

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x06001BA9 RID: 7081 RVA: 0x0001644B File Offset: 0x0001464B
		// (set) Token: 0x06001BAA RID: 7082 RVA: 0x00016453 File Offset: 0x00014653
		internal IList<InputLayout> BWSaWZIHkKTOXkZcdjAAcdnzEgaE { get; private set; }

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06001BAB RID: 7083 RVA: 0x0001645C File Offset: 0x0001465C
		// (set) Token: 0x06001BAC RID: 7084 RVA: 0x00016464 File Offset: 0x00014664
		internal IList<InputLayout> SdCANdbcefclZebIeWSLcZPhwnOsB { get; private set; }

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06001BAD RID: 7085 RVA: 0x0001646D File Offset: 0x0001466D
		// (set) Token: 0x06001BAE RID: 7086 RVA: 0x00016475 File Offset: 0x00014675
		internal IList<InputLayout> VxLXMOySfYDSDZxBhqiycXFHroCP { get; private set; }

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06001BAF RID: 7087 RVA: 0x0001647E File Offset: 0x0001467E
		// (set) Token: 0x06001BB0 RID: 7088 RVA: 0x00016486 File Offset: 0x00014686
		internal IList<ControllerMap_Editor> IPiZMelTrFRBUmAmHEIvqucMhSCcA { get; private set; }

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06001BB1 RID: 7089 RVA: 0x0001648F File Offset: 0x0001468F
		// (set) Token: 0x06001BB2 RID: 7090 RVA: 0x00016497 File Offset: 0x00014697
		internal IList<ControllerMap_Editor> ypfhfSbMjUsvGKIgbZemmyPtNhQO { get; private set; }

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06001BB3 RID: 7091 RVA: 0x000164A0 File Offset: 0x000146A0
		// (set) Token: 0x06001BB4 RID: 7092 RVA: 0x000164A8 File Offset: 0x000146A8
		internal IList<ControllerMap_Editor> BeRffImSXfDrXAvQlOSViTVipwSgA { get; private set; }

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06001BB5 RID: 7093 RVA: 0x000164B1 File Offset: 0x000146B1
		// (set) Token: 0x06001BB6 RID: 7094 RVA: 0x000164B9 File Offset: 0x000146B9
		internal IList<ControllerMap_Editor> HtFQzBpopGAkoEwbjmAQkKBdWbDC { get; private set; }

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x06001BB7 RID: 7095 RVA: 0x000164C2 File Offset: 0x000146C2
		// (set) Token: 0x06001BB8 RID: 7096 RVA: 0x000164CA File Offset: 0x000146CA
		internal IList<ControllerMapLayoutManager_RuleSet_Editor> fVrapIKnuSkvchYYsZcetaRbFSXQA { get; private set; }

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06001BB9 RID: 7097 RVA: 0x000164D3 File Offset: 0x000146D3
		// (set) Token: 0x06001BBA RID: 7098 RVA: 0x000164DB File Offset: 0x000146DB
		internal IList<ControllerMapEnabler_RuleSet_Editor> MIyBVditogETVMtHmOypqitNKHUf { get; private set; }

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x06001BBB RID: 7099 RVA: 0x000164E4 File Offset: 0x000146E4
		public ConfigVars ConfigVars
		{
			get
			{
				return this.configVars;
			}
		}

		// Token: 0x06001BBC RID: 7100 RVA: 0x000164EC File Offset: 0x000146EC
		internal IEnumerable<InputMapCategory> tOHeBYPLsQIOugrGVejLbnFqchgJA(string A_1)
		{
			if (A_1 == null || A_1 == string.Empty)
			{
				yield break;
			}
			if (this.mapCategories == null)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.mapCategories.Count; i = num + 1)
			{
				if (this.mapCategories[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
				{
					yield return this.mapCategories[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06001BBD RID: 7101 RVA: 0x00016503 File Offset: 0x00014703
		internal IEnumerable<InputMapCategory> vrAAiyMsAeZaHZwDCkikiItHgxaX
		{
			get
			{
				if (this.mapCategories == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.mapCategories.Count; i = num + 1)
				{
					if (this.mapCategories[i].userAssignable)
					{
						yield return this.mapCategories[i];
					}
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x06001BBE RID: 7102 RVA: 0x00016513 File Offset: 0x00014713
		internal IEnumerable<InputMapCategory> yYRjcGVNtrTXEjSglhEamviSaNod(string A_1)
		{
			if (A_1 == null || A_1 == string.Empty)
			{
				yield break;
			}
			if (this.mapCategories == null)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.mapCategories.Count; i = num + 1)
			{
				if (this.mapCategories[i].userAssignable && this.mapCategories[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
				{
					yield return this.mapCategories[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06001BBF RID: 7103 RVA: 0x0001652A File Offset: 0x0001472A
		internal IEnumerable<InputCategory> UHzFRVcJCDjQquoOQDgEIeNZGdEhA(string A_1)
		{
			if (A_1 == null || A_1 == string.Empty)
			{
				yield break;
			}
			if (this.actionCategories == null)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.actionCategories.Count; i = num + 1)
			{
				if (this.actionCategories[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
				{
					yield return this.actionCategories[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06001BC0 RID: 7104 RVA: 0x00016541 File Offset: 0x00014741
		internal IEnumerable<InputCategory> FEbUyWIbYykDcNCiQdqhBcVnveHrA
		{
			get
			{
				if (this.actionCategories == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.actionCategories.Count; i = num + 1)
				{
					if (this.actionCategories[i].userAssignable)
					{
						yield return this.actionCategories[i];
					}
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x06001BC1 RID: 7105 RVA: 0x00016551 File Offset: 0x00014751
		internal IEnumerable<InputCategory> mjKEQBGMeqFkNNUhoxxgfGoSaoJv(string A_1)
		{
			if (A_1 == null || A_1 == string.Empty)
			{
				yield break;
			}
			if (this.actionCategories == null)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.actionCategories.Count; i = num + 1)
			{
				if (this.actionCategories[i].userAssignable && this.actionCategories[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
				{
					yield return this.actionCategories[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06001BC2 RID: 7106 RVA: 0x00016568 File Offset: 0x00014768
		internal IEnumerable<InputAction> BwCEAOUxKXKnSthjaMhYrkbuomaN
		{
			get
			{
				if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i = num + 1)
				{
					InputAction inputAction = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i];
					InputCategory actionCategoryById = this.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						yield return inputAction;
					}
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x00016578 File Offset: 0x00014778
		internal IEnumerable<InputAction> yNKgChHRbvKPpGmxINFphYfanaGpC(int A_1, bool A_2)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null || this.actionCategories == null)
			{
				yield break;
			}
			if (A_2)
			{
				foreach (int id in this.SortedActionIdsInCategory(A_1))
				{
					InputAction actionById = this.GetActionById(id);
					if (actionById != null)
					{
						yield return actionById;
					}
				}
				IEnumerator<int> enumerator = null;
			}
			else
			{
				int num;
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i = num + 1)
				{
					if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].categoryId == A_1)
					{
						yield return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i];
					}
					num = i;
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x00016596 File Offset: 0x00014796
		internal IEnumerable<InputAction> WiAMprxKZFIuworMQwGSuEqpbbPy(string A_1, bool A_2)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null || this.actionCategories == null)
			{
				yield break;
			}
			if (A_1 == null || A_1 == string.Empty)
			{
				yield break;
			}
			int num = this.IndexOfActionCategory(A_1);
			if (num < 0)
			{
				yield break;
			}
			InputCategory actionCategory = this.GetActionCategory(num);
			if (A_2)
			{
				foreach (int id in this.SortedActionIdsInCategory(actionCategory.id))
				{
					InputAction actionById = this.GetActionById(id);
					if (actionById != null)
					{
						yield return actionById;
					}
				}
				IEnumerator<int> enumerator = null;
			}
			else
			{
				int num2;
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i = num2 + 1)
				{
					if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].categoryId == actionCategory.id)
					{
						yield return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i];
					}
					num2 = i;
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x06001BC5 RID: 7109 RVA: 0x000165B4 File Offset: 0x000147B4
		internal IEnumerable<InputAction> zcaIJJsGDkRmmWLQfgIDcMOXsWHS(string A_1)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null || this.actionCategories == null)
			{
				yield break;
			}
			if (A_1 == null || A_1 == string.Empty)
			{
				yield break;
			}
			int count = this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count;
			int num;
			for (int i = 0; i < this.actionCategories.Count; i = num + 1)
			{
				if (this.actionCategories[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
				{
					InputCategory inputCategory = this.actionCategories[i];
					for (int j = 0; j < count; j = num + 1)
					{
						if (inputCategory.id == this.aTRZoPUHOHBERSaHiQchUzNPWDGT[j].categoryId)
						{
							yield return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[j];
						}
						num = j;
					}
					inputCategory = null;
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x000165CB File Offset: 0x000147CB
		internal IEnumerable<InputAction> FCuHWEkQzkIOZCdjdlCyfURdSIhP(int A_1, bool A_2)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null || this.actionCategories == null)
			{
				yield break;
			}
			InputCategory actionCategoryById = this.GetActionCategoryById(A_1);
			if (actionCategoryById == null || !actionCategoryById.userAssignable)
			{
				yield break;
			}
			if (A_2)
			{
				foreach (int id in this.SortedActionIdsInCategory(actionCategoryById.id))
				{
					InputAction actionById = this.GetActionById(id);
					if (actionById != null && actionById.userAssignable)
					{
						yield return actionById;
					}
				}
				IEnumerator<int> enumerator = null;
			}
			else
			{
				int num;
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i = num + 1)
				{
					InputAction inputAction = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i];
					if (inputAction.categoryId == actionCategoryById.id && inputAction.userAssignable)
					{
						yield return inputAction;
					}
					num = i;
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x000165E9 File Offset: 0x000147E9
		internal IEnumerable<InputAction> kagRtqErSSSqGTCMjJCysLJVDNes(string A_1, bool A_2)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null || this.actionCategories == null)
			{
				yield break;
			}
			InputCategory actionCategory = this.GetActionCategory(A_1);
			if (actionCategory == null || !actionCategory.userAssignable)
			{
				yield break;
			}
			if (A_2)
			{
				foreach (int id in this.SortedActionIdsInCategory(actionCategory.id))
				{
					InputAction actionById = this.GetActionById(id);
					if (actionById != null && actionById.userAssignable)
					{
						yield return actionById;
					}
				}
				IEnumerator<int> enumerator = null;
			}
			else
			{
				int num;
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i = num + 1)
				{
					InputAction inputAction = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i];
					if (inputAction.categoryId == actionCategory.id && inputAction.userAssignable)
					{
						yield return inputAction;
					}
					num = i;
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x00016607 File Offset: 0x00014807
		public UserData() : this(true)
		{
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x00075E30 File Offset: 0x00074030
		private UserData(bool A_1)
		{
			if (A_1)
			{
				this.configVars.updateLoop = UpdateLoopSetting.Update;
				this.configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
				this.configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
				Player_Editor player_Editor = this.yPRZKssPqDeUwuAtRJKGzjVKDvkp();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				this.players.Add(player_Editor);
				InputActionCategory inputActionCategory = this.GqOmrHifijEubAupchCVroXwLwhBA();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				this.actionCategories.Add(inputActionCategory);
				this.actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = this.xZZbOdTeGsNGPPvlkgHnWHBvcRfc();
				inputBehavior.name = "Default";
				this.inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = this.weJbOFdsvSlGThupLPBYbYatWLUsA();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				this.mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = this.UzsasJHPOmtEgydFpECcquRKBTxx();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				this.joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = this.VFkkqgNKTjmyUlirolEmKgINfsKl();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				this.keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = this.rHgbaFObSllvOgMLVeAGEbqMrFRl();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				this.mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = this.ntbjGshTcgULOYcQVBbXKyliIfsi();
				inputLayout4.name = "Default";
				inputLayout4.descriptiveName = inputLayout4.name;
				this.customControllerLayouts.Add(inputLayout3);
			}
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x000760C8 File Offset: 0x000742C8
		[CustomObfuscation(rename = false)]
		internal void SetDefaultValuesOnCreation()
		{
			this.configVars.platformVars_osxStandalone = new ConfigVars.PlatformVars_OSXStandalone();
			this.configVars.platformVars_osxStandalone.useAppleGameController = true;
			this.configVars.platformVars_windowsStandalone = new ConfigVars.PlatformVars_WindowsStandalone();
			this.configVars.platformVars_windowsStandalone.useWindowsGamingInput = true;
			this.configVars.keyCombinationOverrideMode = KeyCombinationOverrideMode.Cancel;
			this.configVars.generateKeyEventsOnKeyCombinationOverride = true;
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x00076130 File Offset: 0x00074330
		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				list.Add(this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i]);
			}
			return list;
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x0007616C File Offset: 0x0007436C
		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			for (int i = 0; i < this.inputBehaviors.Count; i++)
			{
				list.Add(this.inputBehaviors[i].Clone());
			}
			return list;
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x000761B0 File Offset: 0x000743B0
		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				KeyboardMap item = this.keyboardMaps[i].YNsUmlddoSPOqfSpCQmbJQOffggBA(this.containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x000761FC File Offset: 0x000743FC
		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				MouseMap item = this.mouseMaps[i].SIXtwqRHUKcorBGgjrrbiaHhCcJJ(this.containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06001BCF RID: 7119 RVA: 0x00016610 File Offset: 0x00014810
		public int playerCount
		{
			get
			{
				if (this.players == null)
				{
					return 0;
				}
				return this.players.Count;
			}
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x00016627 File Offset: 0x00014827
		public void AddPlayer()
		{
			this.players.Add(this.yPRZKssPqDeUwuAtRJKGzjVKDvkp());
		}

		// Token: 0x06001BD1 RID: 7121 RVA: 0x0001663A File Offset: 0x0001483A
		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= this.players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.players.Insert(index, this.yPRZKssPqDeUwuAtRJKGzjVKDvkp());
		}

		// Token: 0x06001BD2 RID: 7122 RVA: 0x0001666B File Offset: 0x0001486B
		public void DeletePlayer(int index)
		{
			if (this.players == null || index < 0 || index >= this.players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.players.RemoveAt(index);
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x0001669E File Offset: 0x0001489E
		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<Player_Editor>(this.players, index, offsetDown, offsetNow);
		}

		// Token: 0x06001BD4 RID: 7124 RVA: 0x00076248 File Offset: 0x00074448
		public void DuplicatePlayer(int index)
		{
			if (this.players == null || index < 0 || index >= this.players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Player_Editor player_Editor = this.players[index].Clone();
			player_Editor.id = this.GetNewPlayerId();
			player_Editor.name = StringTools.IterateName(player_Editor.name, -1, this.GetPlayerNames());
			player_Editor.assignMouseOnStart = false;
			if (index == this.players.Count - 1)
			{
				this.players.Add(player_Editor);
				return;
			}
			this.players.Insert(index + 1, player_Editor);
		}

		// Token: 0x06001BD5 RID: 7125 RVA: 0x000762E4 File Offset: 0x000744E4
		public string[] GetPlayerNames()
		{
			if (this.players == null)
			{
				return null;
			}
			string[] array = new string[this.players.Count];
			for (int i = 0; i < this.players.Count; i++)
			{
				array[i] = this.players[i].name;
			}
			return array;
		}

		// Token: 0x06001BD6 RID: 7126 RVA: 0x00076338 File Offset: 0x00074538
		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (this.players == null)
			{
				return 0;
			}
			for (int i = 0; i < this.players.Count; i++)
			{
				results.Add(this.players[i].name);
			}
			return results.Count;
		}

		// Token: 0x06001BD7 RID: 7127 RVA: 0x00076398 File Offset: 0x00074598
		public int[] GetPlayerIds()
		{
			if (this.players == null)
			{
				return null;
			}
			int[] array = new int[this.players.Count];
			for (int i = 0; i < this.players.Count; i++)
			{
				array[i] = this.players[i].id;
			}
			return array;
		}

		// Token: 0x06001BD8 RID: 7128 RVA: 0x000763EC File Offset: 0x000745EC
		public int[] GetPlayerRuntimeIds()
		{
			if (this.players == null)
			{
				return null;
			}
			int[] array = new int[this.players.Count];
			for (int i = 0; i < this.players.Count; i++)
			{
				if (i == 0)
				{
					array[i] = 9999999;
				}
				else
				{
					array[i] = i - 1;
				}
			}
			return array;
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x00076440 File Offset: 0x00074640
		public int GetPlayerRuntimeIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (this.players == null)
			{
				return 0;
			}
			for (int i = 0; i < this.players.Count; i++)
			{
				if (i == 0)
				{
					results.Add(9999999);
				}
				else
				{
					results.Add(i - 1);
				}
			}
			return results.Count;
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x000764A0 File Offset: 0x000746A0
		public string GetPlayerNameById(int id)
		{
			if (this.players == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < this.players.Count; i++)
			{
				if (this.players[i].id == id)
				{
					return this.players[i].name;
				}
			}
			return string.Empty;
		}

		// Token: 0x06001BDB RID: 7131 RVA: 0x000166AE File Offset: 0x000148AE
		public Player_Editor GetPlayer(int index)
		{
			if (this.players == null || index < 0 || index >= this.players.Count)
			{
				return null;
			}
			return this.players[index];
		}

		// Token: 0x06001BDC RID: 7132 RVA: 0x000764FC File Offset: 0x000746FC
		public int GetPlayerId(string name)
		{
			if (this.players == null)
			{
				return -1;
			}
			for (int i = 0; i < this.players.Count; i++)
			{
				if (this.players[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return this.players[i].id;
				}
			}
			return -1;
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x00076558 File Offset: 0x00074758
		public bool IsMouseAssigned()
		{
			if (this.players == null)
			{
				return false;
			}
			int count = this.players.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.players[i].assignMouseOnStart)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x000765A0 File Offset: 0x000747A0
		public void ClearMouseAssignments()
		{
			if (this.players == null)
			{
				return;
			}
			int count = this.players.Count;
			for (int i = 0; i < count; i++)
			{
				this.players[i].assignMouseOnStart = false;
			}
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x000765E0 File Offset: 0x000747E0
		public bool IsKeyboardAssigned()
		{
			if (this.players == null)
			{
				return false;
			}
			int count = this.players.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.players[i].assignKeyboardOnStart)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001BE0 RID: 7136 RVA: 0x00076628 File Offset: 0x00074828
		public void ClearKeyboardAssignments()
		{
			if (this.players == null)
			{
				return;
			}
			int count = this.players.Count;
			for (int i = 0; i < count; i++)
			{
				this.players[i].assignKeyboardOnStart = false;
			}
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06001BE1 RID: 7137 RVA: 0x000166D8 File Offset: 0x000148D8
		private List<InputAction> aTRZoPUHOHBERSaHiQchUzNPWDGT
		{
			get
			{
				if (!ReInput.isReady)
				{
					return this.actions;
				}
				return this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc;
			}
		}

		// Token: 0x06001BE2 RID: 7138 RVA: 0x00076668 File Offset: 0x00074868
		public void AddAction(int categoryId)
		{
			InputAction inputAction = this.ZXqVqSuoFvcyDFWrUwuaFHhOWmGs();
			inputAction.categoryId = categoryId;
			this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Add(inputAction);
			this.actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		// Token: 0x06001BE3 RID: 7139 RVA: 0x000766A4 File Offset: 0x000748A4
		public void InsertAction(int categoryId, int actionId)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return;
			}
			InputAction inputAction = this.ZXqVqSuoFvcyDFWrUwuaFHhOWmGs();
			inputAction.categoryId = categoryId;
			this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Add(inputAction);
			int index = this.actionCategoryMap.IndexOfAction(categoryId, actionId);
			this.actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
		}

		// Token: 0x06001BE4 RID: 7140 RVA: 0x000766F8 File Offset: 0x000748F8
		public void DeleteAction(int categoryId, int actionId)
		{
			if (this.IndexOfActionCategory(categoryId) < 0)
			{
				return;
			}
			int num = this.IndexOfAction(actionId);
			if (num < 0)
			{
				return;
			}
			this.aTRZoPUHOHBERSaHiQchUzNPWDGT.RemoveAt(num);
			this.actionCategoryMap.RemoveAction(categoryId, actionId);
		}

		// Token: 0x06001BE5 RID: 7141 RVA: 0x000166EE File Offset: 0x000148EE
		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return this.actionCategoryMap.ReorderAction(categoryId, actionId, offsetDown, offsetNow);
		}

		// Token: 0x06001BE6 RID: 7142 RVA: 0x00076738 File Offset: 0x00074938
		public int DuplicateAction_FromButton(int categoryId, int actionId)
		{
			if (this.IndexOfActionCategory(categoryId) < 0)
			{
				return -1;
			}
			int num = this.IndexOfAction(actionId);
			if (num < 0)
			{
				return -1;
			}
			InputAction actionById = this.GetActionById(actionId);
			if (actionById == null)
			{
				return -1;
			}
			InputAction inputAction = actionById.Clone();
			inputAction.id = this.GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, this.GetActionNames());
			if (num == this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count - 1)
			{
				this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Add(inputAction);
				this.actionCategoryMap.AddAction(categoryId, inputAction.id);
				return this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count - 1;
			}
			this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Insert(num + 1, inputAction);
			int num2 = this.actionCategoryMap.IndexOfAction(categoryId, actionId);
			this.actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x0007680C File Offset: 0x00074A0C
		private int ciuYaTsbCZqyqJxAdeltLbDDhkEU(int A_1, InputAction A_2)
		{
			if (this.IndexOfActionCategory(A_1) < 0)
			{
				return -1;
			}
			InputAction inputAction = A_2.Clone();
			inputAction.id = this.GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, this.GetActionNames());
			this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Add(inputAction);
			return this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count - 1;
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x0007686C File Offset: 0x00074A6C
		public string[] GetActionNames()
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			string[] array = new string[this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count];
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				array[i] = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].name;
			}
			return array;
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x000768C0 File Offset: 0x00074AC0
		public int GetActionNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return 0;
			}
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				results.Add(this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].name);
			}
			return results.Count;
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x00076920 File Offset: 0x00074B20
		public int[] GetActionIds()
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			int[] array = new int[this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count];
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				array[i] = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].id;
			}
			return array;
		}

		// Token: 0x06001BEB RID: 7147 RVA: 0x00076974 File Offset: 0x00074B74
		public int GetActionIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return 0;
			}
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				results.Add(this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].id);
			}
			return results.Count;
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x000769D4 File Offset: 0x00074BD4
		public string GetActionNameById(int id)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].id == id)
				{
					return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].name;
				}
			}
			return string.Empty;
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x00016700 File Offset: 0x00014900
		public InputAction GetAction(int index)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null || index < 0 || index >= this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count)
			{
				return null;
			}
			return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[index];
		}

		// Token: 0x06001BEE RID: 7150 RVA: 0x00076A30 File Offset: 0x00074C30
		public InputAction GetAction(string name)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			int num = this.IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[num];
		}

		// Token: 0x06001BEF RID: 7151 RVA: 0x00076A64 File Offset: 0x00074C64
		public InputAction GetActionById(int id)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].id == id)
				{
					return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i];
				}
			}
			return null;
		}

		// Token: 0x06001BF0 RID: 7152 RVA: 0x00076AB4 File Offset: 0x00074CB4
		public int GetActionId(string name)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return -1;
			}
			int num = this.IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return this.aTRZoPUHOHBERSaHiQchUzNPWDGT[num].id;
		}

		// Token: 0x06001BF1 RID: 7153 RVA: 0x00076AEC File Offset: 0x00074CEC
		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (this.actionCategories == null || this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int id2 in this.actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = this.GetActionById(id2);
				if (actionById != null)
				{
					list.Add(actionById.name);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06001BF2 RID: 7154 RVA: 0x0001672A File Offset: 0x0001492A
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			if (this.actionCategories == null || this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				yield break;
			}
			foreach (int id2 in this.actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = this.GetActionById(id2);
				if (actionById != null)
				{
					yield return actionById.name;
				}
			}
			IEnumerator<int> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06001BF3 RID: 7155 RVA: 0x00076B70 File Offset: 0x00074D70
		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (this.actionCategories == null || this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int id2 in this.actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = this.GetActionById(id2);
				if (actionById != null)
				{
					list.Add(actionById.descriptiveName);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x00016741 File Offset: 0x00014941
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			if (this.actionCategories == null || this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				yield break;
			}
			foreach (int id2 in this.actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = this.GetActionById(id2);
				if (actionById != null)
				{
					yield return actionById.descriptiveName;
				}
			}
			IEnumerator<int> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x00076BF4 File Offset: 0x00074DF4
		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (this.actionCategories == null || this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (int item in this.actionCategoryMap.ActionIdsInCategory(id))
			{
				list.Add(item);
			}
			return list.ToArray();
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x00016758 File Offset: 0x00014958
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			if (this.actionCategories == null || this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				yield break;
			}
			foreach (int num in this.actionCategoryMap.ActionIdsInCategory(id))
			{
				yield return num;
			}
			IEnumerator<int> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06001BF7 RID: 7159 RVA: 0x0001676F File Offset: 0x0001496F
		public bool ContainsAction(int id)
		{
			return this.IndexOfAction(id) >= 0;
		}

		// Token: 0x06001BF8 RID: 7160 RVA: 0x00076C68 File Offset: 0x00074E68
		public int IndexOfAction(int id)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return -1;
			}
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001BF9 RID: 7161 RVA: 0x00076CAC File Offset: 0x00074EAC
		public int IndexOfAction(string name)
		{
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
			{
				if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001BFA RID: 7162 RVA: 0x00076D08 File Offset: 0x00074F08
		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = this.GqOmrHifijEubAupchCVroXwLwhBA();
			this.actionCategories.Add(inputActionCategory);
			this.actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x00076D3C File Offset: 0x00074F3C
		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= this.actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = this.GqOmrHifijEubAupchCVroXwLwhBA();
			this.actionCategories.Insert(index, inputActionCategory);
			this.actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		// Token: 0x06001BFC RID: 7164 RVA: 0x00076D8C File Offset: 0x00074F8C
		public void DeleteActionCategory(int index)
		{
			if (this.actionCategories == null || index < 0 || index >= this.actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.actionCategories[index].id;
			this.actionCategoryMap.RemoveCategory(id);
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT != null)
			{
				for (int i = this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count - 1; i >= 0; i--)
				{
					if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].categoryId == id)
					{
						this.aTRZoPUHOHBERSaHiQchUzNPWDGT.RemoveAt(i);
					}
				}
			}
			this.actionCategories.RemoveAt(index);
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x0001677E File Offset: 0x0001497E
		public bool ReorderActionCategory(int index, bool offsetDown, bool offsetNow)
		{
			return index >= 0 && index < this.actionCategories.Count && ListTools.OffsetAtIndex<InputActionCategory>(this.actionCategories, index, offsetDown, offsetNow);
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x00076E28 File Offset: 0x00075028
		public void DuplicateActionCategory(int index, bool duplicateActions)
		{
			if (this.actionCategories == null || index < 0 || index >= this.actionCategories.Count)
			{
				return;
			}
			InputActionCategory inputActionCategory = new InputActionCategory(this.actionCategories[index]);
			inputActionCategory.id = this.GetNewActionCategoryId();
			inputActionCategory.name = StringTools.IterateName(inputActionCategory.name, -1, this.GetActionCategoryNames());
			if (index == this.actionCategories.Count - 1)
			{
				this.actionCategories.Add(inputActionCategory);
			}
			else
			{
				this.actionCategories.Insert(index + 1, inputActionCategory);
			}
			this.actionCategoryMap.AddCategory(inputActionCategory.id);
			if (duplicateActions && this.aTRZoPUHOHBERSaHiQchUzNPWDGT != null)
			{
				int id = inputActionCategory.id;
				int id2 = this.actionCategories[index].id;
				List<int> list = new List<int>();
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
				{
					if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].categoryId == id2)
					{
						list.Add(i);
					}
				}
				Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
				for (int j = 0; j < list.Count; j++)
				{
					InputAction inputAction = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[list[j]];
					int num = this.ciuYaTsbCZqyqJxAdeltLbDDhkEU(id2, inputAction);
					if (num >= 0)
					{
						InputAction inputAction2 = this.aTRZoPUHOHBERSaHiQchUzNPWDGT[num];
						inputAction2.categoryId = id;
						dictionary.Add(inputAction.id, inputAction2.id);
					}
				}
				foreach (int key in this.actionCategoryMap.ActionIdsInCategory(id2))
				{
					int actionId;
					if (dictionary.TryGetValue(key, out actionId))
					{
						this.actionCategoryMap.AddAction(id, actionId);
					}
				}
			}
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x00077000 File Offset: 0x00075200
		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = this.IndexOfAction(actionId);
			if (num < 0)
			{
				return;
			}
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[num].categoryId == newCategoryId)
			{
				return;
			}
			this.actionCategoryMap.ChangeCategory(actionId, newCategoryId);
			this.aTRZoPUHOHBERSaHiQchUzNPWDGT[num].categoryId = newCategoryId;
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x00077050 File Offset: 0x00075250
		public int GetActionCategoryCount(int id)
		{
			if (this.actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT != null)
			{
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
				{
					if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x000770A0 File Offset: 0x000752A0
		public int GetActionCategoryIndex(int id)
		{
			if (this.actionCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < this.actionCategories.Count; i++)
			{
				if (this.actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x000770E4 File Offset: 0x000752E4
		public string[] GetActionCategoryNames()
		{
			if (this.actionCategories == null)
			{
				return null;
			}
			string[] array = new string[this.actionCategories.Count];
			for (int i = 0; i < this.actionCategories.Count; i++)
			{
				array[i] = this.actionCategories[i].name;
			}
			return array;
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x00077138 File Offset: 0x00075338
		public int[] GetActionCategoryIds()
		{
			if (this.actionCategories == null)
			{
				return null;
			}
			int[] array = new int[this.actionCategories.Count];
			for (int i = 0; i < this.actionCategories.Count; i++)
			{
				array[i] = this.actionCategories[i].id;
			}
			return array;
		}

		// Token: 0x06001C04 RID: 7172 RVA: 0x000167A2 File Offset: 0x000149A2
		public InputCategory GetActionCategory(int index)
		{
			if (this.actionCategories == null || index < 0 || index >= this.actionCategories.Count)
			{
				return null;
			}
			return this.actionCategories[index];
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x0007718C File Offset: 0x0007538C
		public InputCategory GetActionCategory(string name)
		{
			if (this.actionCategories == null)
			{
				return null;
			}
			int num = this.IndexOfActionCategory(name);
			if (num < 0)
			{
				return null;
			}
			return this.actionCategories[num];
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x000771C0 File Offset: 0x000753C0
		public InputCategory GetActionCategoryById(int id)
		{
			int num = this.IndexOfActionCategory(id);
			if (num < 0)
			{
				return null;
			}
			return this.actionCategories[num];
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x000771E8 File Offset: 0x000753E8
		public int GetActionCategoryId(string name)
		{
			if (this.actionCategories == null)
			{
				return -1;
			}
			int num = this.IndexOfActionCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return this.actionCategories[num].id;
		}

		// Token: 0x06001C08 RID: 7176 RVA: 0x00077220 File Offset: 0x00075420
		public string GetActionCategoryNameById(int id)
		{
			if (this.actionCategories == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < this.actionCategories.Count; i++)
			{
				if (this.actionCategories[i].id == id)
				{
					return this.actionCategories[i].name;
				}
			}
			return string.Empty;
		}

		// Token: 0x06001C09 RID: 7177 RVA: 0x0007727C File Offset: 0x0007547C
		public int IndexOfActionCategory(int id)
		{
			if (this.actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < this.actionCategories.Count; i++)
			{
				if (this.actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x000772C0 File Offset: 0x000754C0
		public int IndexOfActionCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < this.actionCategories.Count; i++)
			{
				if (this.actionCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C0B RID: 7179 RVA: 0x000167CC File Offset: 0x000149CC
		public int GetActionCategoryCount()
		{
			if (this.actionCategories == null)
			{
				return 0;
			}
			return this.actionCategories.Count;
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x000167E3 File Offset: 0x000149E3
		public void AddInputBehavior()
		{
			this.inputBehaviors.Add(this.xZZbOdTeGsNGPPvlkgHnWHBvcRfc());
		}

		// Token: 0x06001C0D RID: 7181 RVA: 0x000167F6 File Offset: 0x000149F6
		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= this.inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.inputBehaviors.Insert(index, this.xZZbOdTeGsNGPPvlkgHnWHBvcRfc());
		}

		// Token: 0x06001C0E RID: 7182 RVA: 0x0007731C File Offset: 0x0007551C
		public void DeleteInputBehavior(int index)
		{
			if (this.inputBehaviors == null || index < 0 || index >= this.inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.inputBehaviors[index].id;
			if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT != null)
			{
				for (int i = 0; i < this.aTRZoPUHOHBERSaHiQchUzNPWDGT.Count; i++)
				{
					if (this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].behaviorId == id)
					{
						this.aTRZoPUHOHBERSaHiQchUzNPWDGT[i].behaviorId = 0;
					}
				}
			}
			this.inputBehaviors.RemoveAt(index);
		}

		// Token: 0x06001C0F RID: 7183 RVA: 0x00016827 File Offset: 0x00014A27
		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<InputBehavior>(this.inputBehaviors, index, offsetDown, offsetNow);
		}

		// Token: 0x06001C10 RID: 7184 RVA: 0x000773B0 File Offset: 0x000755B0
		public void DuplicateInputBehavior(int index)
		{
			if (this.inputBehaviors == null || index < 0 || index >= this.inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputBehavior inputBehavior = this.inputBehaviors[index].Clone();
			inputBehavior.id = this.GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, this.GetInputBehaviorNames());
			if (index == this.inputBehaviors.Count - 1)
			{
				this.inputBehaviors.Add(inputBehavior);
				return;
			}
			this.inputBehaviors.Insert(index + 1, inputBehavior);
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x00077444 File Offset: 0x00075644
		public string[] GetInputBehaviorNames()
		{
			if (this.inputBehaviors == null)
			{
				return null;
			}
			string[] array = new string[this.inputBehaviors.Count];
			for (int i = 0; i < this.inputBehaviors.Count; i++)
			{
				array[i] = this.inputBehaviors[i].name;
			}
			return array;
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x00077498 File Offset: 0x00075698
		public int[] GetInputBehaviorIds()
		{
			if (this.inputBehaviors == null)
			{
				return null;
			}
			int[] array = new int[this.inputBehaviors.Count];
			for (int i = 0; i < this.inputBehaviors.Count; i++)
			{
				array[i] = this.inputBehaviors[i].id;
			}
			return array;
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x00016837 File Offset: 0x00014A37
		public InputBehavior GetInputBehavior(int index)
		{
			if (this.inputBehaviors == null || index < 0 || index >= this.inputBehaviors.Count)
			{
				return null;
			}
			return this.inputBehaviors[index];
		}

		// Token: 0x06001C14 RID: 7188 RVA: 0x000774EC File Offset: 0x000756EC
		public InputBehavior GetInputBehavior(string name)
		{
			if (this.inputBehaviors == null)
			{
				return null;
			}
			int num = this.IndexOfInputBehavior(name);
			if (num < 0)
			{
				return null;
			}
			return this.inputBehaviors[num];
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x00077520 File Offset: 0x00075720
		public InputBehavior GetInputBehaviorById(int id)
		{
			if (this.inputBehaviors == null)
			{
				return null;
			}
			for (int i = 0; i < this.inputBehaviors.Count; i++)
			{
				if (this.inputBehaviors[i].id == id)
				{
					return this.inputBehaviors[i];
				}
			}
			return null;
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x00077570 File Offset: 0x00075770
		public int GetInputBehaviorId(string name)
		{
			if (this.inputBehaviors == null)
			{
				return -1;
			}
			int num = this.IndexOfInputBehavior(name);
			if (num < 0)
			{
				return -1;
			}
			return this.inputBehaviors[num].id;
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x000775A8 File Offset: 0x000757A8
		public int IndexOfInputBehavior(int id)
		{
			if (this.inputBehaviors == null)
			{
				return -1;
			}
			for (int i = 0; i < this.inputBehaviors.Count; i++)
			{
				if (this.inputBehaviors[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x000775EC File Offset: 0x000757EC
		public int IndexOfInputBehavior(string name)
		{
			if (this.inputBehaviors == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < this.inputBehaviors.Count; i++)
			{
				if (this.inputBehaviors[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x00016861 File Offset: 0x00014A61
		public void AddMapCategory()
		{
			this.mapCategories.Add(this.weJbOFdsvSlGThupLPBYbYatWLUsA());
		}

		// Token: 0x06001C1A RID: 7194 RVA: 0x00016874 File Offset: 0x00014A74
		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= this.mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.mapCategories.Insert(index, this.weJbOFdsvSlGThupLPBYbYatWLUsA());
		}

		// Token: 0x06001C1B RID: 7195 RVA: 0x00077648 File Offset: 0x00075848
		public void DeleteMapCategory(int index)
		{
			if (this.mapCategories == null || index < 0 || index >= this.mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.mapCategories[index].id;
			if (this.joystickMaps != null)
			{
				for (int i = this.joystickMaps.Count - 1; i >= 0; i--)
				{
					if (this.joystickMaps[i].categoryId == id)
					{
						this.joystickMaps.RemoveAt(i);
					}
				}
			}
			if (this.keyboardMaps != null)
			{
				for (int j = this.keyboardMaps.Count - 1; j >= 0; j--)
				{
					if (this.keyboardMaps[j].categoryId == id)
					{
						this.keyboardMaps.RemoveAt(j);
					}
				}
			}
			if (this.mouseMaps != null)
			{
				for (int k = this.mouseMaps.Count - 1; k >= 0; k--)
				{
					if (this.mouseMaps[k].categoryId == id)
					{
						this.mouseMaps.RemoveAt(k);
					}
				}
			}
			if (this.customControllerMaps != null)
			{
				for (int l = this.customControllerMaps.Count - 1; l >= 0; l--)
				{
					if (this.customControllerMaps[l].categoryId == id)
					{
						this.customControllerMaps.RemoveAt(l);
					}
				}
			}
			if (this.mapCategories != null)
			{
				for (int m = 0; m < this.mapCategories.Count; m++)
				{
					InputMapCategory inputMapCategory = this.mapCategories[m];
					if (inputMapCategory.checkConflictsCategoryIds != null)
					{
						for (int n = 0; n < inputMapCategory.checkConflictsCategoryIds.Count; n++)
						{
							if (inputMapCategory.checkConflictsCategoryIds[n] == id)
							{
								inputMapCategory.checkConflictsCategoryIds.RemoveAt(n);
							}
						}
					}
				}
			}
			if (this.players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = new Action<List<Player_Editor.Mapping>, int>(UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb.<>9.XTvZGUxXoaYHPTZIDXAiVCBZEnuS);
				for (int num = 0; num < this.players.Count; num++)
				{
					Player_Editor player_Editor = this.players[num];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
						action(player_Editor.defaultMouseMaps, id);
						action(player_Editor.defaultJoystickMaps, id);
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			this.mapCategories.RemoveAt(index);
		}

		// Token: 0x06001C1C RID: 7196 RVA: 0x000168A5 File Offset: 0x00014AA5
		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<InputMapCategory>(this.mapCategories, index, offsetDown, offsetNow);
		}

		// Token: 0x06001C1D RID: 7197 RVA: 0x000778A8 File Offset: 0x00075AA8
		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
			if (this.mapCategories == null || index < 0 || index >= this.mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputMapCategory inputMapCategory = new InputMapCategory(this.mapCategories[index]);
			inputMapCategory.id = this.GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, this.GetMapCategoryNames());
			if (index == this.mapCategories.Count - 1)
			{
				this.mapCategories.Add(inputMapCategory);
			}
			else
			{
				this.mapCategories.Insert(index + 1, inputMapCategory);
			}
			if (duplicateMaps)
			{
				int id = inputMapCategory.id;
				int id2 = this.mapCategories[index].id;
				if (this.joystickMaps != null)
				{
					for (int i = this.joystickMaps.Count - 1; i >= 0; i--)
					{
						if (this.joystickMaps[i].categoryId == id2)
						{
							int num = this.DuplicateJoystickMap(i);
							if (num >= 0)
							{
								this.joystickMaps[num].categoryId = id;
							}
						}
					}
				}
				if (this.keyboardMaps != null)
				{
					for (int j = this.keyboardMaps.Count - 1; j >= 0; j--)
					{
						if (this.keyboardMaps[j].categoryId == id2)
						{
							int num2 = this.DuplicateKeyboardMap(j);
							if (num2 >= 0)
							{
								this.keyboardMaps[num2].categoryId = id;
							}
						}
					}
				}
				if (this.mouseMaps != null)
				{
					for (int k = this.mouseMaps.Count - 1; k >= 0; k--)
					{
						if (this.mouseMaps[k].categoryId == id2)
						{
							int num3 = this.DuplicateMouseMap(k);
							if (num3 >= 0)
							{
								this.mouseMaps[num3].categoryId = id;
							}
						}
					}
				}
				if (this.customControllerMaps != null)
				{
					for (int l = this.customControllerMaps.Count - 1; l >= 0; l--)
					{
						if (this.customControllerMaps[l].categoryId == id2)
						{
							int num4 = this.DuplicateCustomControllerMap(l);
							if (num4 >= 0)
							{
								this.customControllerMaps[num4].categoryId = id;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x00077AC4 File Offset: 0x00075CC4
		public int GetMapCategoryMapCount(int id)
		{
			if (this.mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (this.joystickMaps != null)
			{
				for (int i = 0; i < this.joystickMaps.Count; i++)
				{
					if (this.joystickMaps[i].categoryId == id)
					{
						num++;
					}
				}
			}
			if (this.keyboardMaps != null)
			{
				for (int j = 0; j < this.keyboardMaps.Count; j++)
				{
					if (this.keyboardMaps[j].categoryId == id)
					{
						num++;
					}
				}
			}
			if (this.mouseMaps != null)
			{
				for (int k = 0; k < this.mouseMaps.Count; k++)
				{
					if (this.mouseMaps[k].categoryId == id)
					{
						num++;
					}
				}
			}
			if (this.customControllerMaps != null)
			{
				for (int l = 0; l < this.customControllerMaps.Count; l++)
				{
					if (this.customControllerMaps[l].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x00077BBC File Offset: 0x00075DBC
		public int GetMapCategoryIndex(int id)
		{
			if (this.mapCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				if (this.mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x00077C00 File Offset: 0x00075E00
		public string[] GetMapCategoryNames()
		{
			if (this.mapCategories == null)
			{
				return null;
			}
			string[] array = new string[this.mapCategories.Count];
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				array[i] = this.mapCategories[i].name;
			}
			return array;
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00077C54 File Offset: 0x00075E54
		public int[] GetMapCategoryIds()
		{
			if (this.mapCategories == null)
			{
				return null;
			}
			int[] array = new int[this.mapCategories.Count];
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				array[i] = this.mapCategories[i].id;
			}
			return array;
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x000168B5 File Offset: 0x00014AB5
		public InputMapCategory GetMapCategory(int index)
		{
			if (this.mapCategories == null || index < 0 || index >= this.mapCategories.Count)
			{
				return null;
			}
			return this.mapCategories[index];
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x00077CA8 File Offset: 0x00075EA8
		public InputMapCategory GetMapCategory(string name)
		{
			if (this.mapCategories == null)
			{
				return null;
			}
			int num = this.IndexOfMapCategory(name);
			if (num < 0)
			{
				return null;
			}
			return this.mapCategories[num];
		}

		// Token: 0x06001C24 RID: 7204 RVA: 0x00077CDC File Offset: 0x00075EDC
		public InputMapCategory GetMapCategoryById(int id)
		{
			if (this.mapCategories == null)
			{
				return null;
			}
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				if (this.mapCategories[i].id == id)
				{
					return this.mapCategories[i];
				}
			}
			return null;
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x00077D2C File Offset: 0x00075F2C
		public int GetMapCategoryId(string name)
		{
			if (this.mapCategories == null)
			{
				return -1;
			}
			int num = this.IndexOfMapCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return this.mapCategories[num].id;
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x00077D64 File Offset: 0x00075F64
		public string GetMapCategoryNameById(int id)
		{
			if (this.mapCategories == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				if (this.mapCategories[i].id == id)
				{
					return this.mapCategories[i].name;
				}
			}
			return string.Empty;
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x00077DC0 File Offset: 0x00075FC0
		public int IndexOfMapCategory(int id)
		{
			if (this.mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				if (this.mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x00077E04 File Offset: 0x00076004
		public int IndexOfMapCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < this.mapCategories.Count; i++)
			{
				if (this.mapCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x000168DF File Offset: 0x00014ADF
		public string[] GetLayoutNames(ControllerType controllerType)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return this.GetKeyboardLayoutNames();
			case ControllerType.Mouse:
				return this.GetMouseLayoutNames();
			case ControllerType.Joystick:
				return this.GetJoystickLayoutNames();
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return this.GetCustomControllerLayoutNames();
			}
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x0001691B File Offset: 0x00014B1B
		public int[] GetLayoutIds(ControllerType controllerType)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return this.GetKeyboardLayoutIds();
			case ControllerType.Mouse:
				return this.GetMouseLayoutIds();
			case ControllerType.Joystick:
				return this.GetJoystickLayoutIds();
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return this.GetCustomControllerLayoutIds();
			}
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x00016957 File Offset: 0x00014B57
		public void AddJoystickLayout()
		{
			this.joystickLayouts.Add(this.UzsasJHPOmtEgydFpECcquRKBTxx());
		}

		// Token: 0x06001C2C RID: 7212 RVA: 0x0001696A File Offset: 0x00014B6A
		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= this.joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.joystickLayouts.Insert(index, this.UzsasJHPOmtEgydFpECcquRKBTxx());
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x00077E60 File Offset: 0x00076060
		public void DeleteJoystickLayout(int index)
		{
			if (this.joystickLayouts == null || index < 0 || index >= this.joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.joystickLayouts[index].id;
			if (this.joystickMaps != null)
			{
				for (int i = this.joystickMaps.Count - 1; i >= 0; i--)
				{
					if (this.joystickMaps[i].layoutId == id)
					{
						this.joystickMaps.RemoveAt(i);
					}
				}
			}
			if (this.players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = new Action<List<Player_Editor.Mapping>, int>(UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb.<>9.xFUUVZyNdwifPGuMcnFkWiJqJPmn);
				for (int j = 0; j < this.players.Count; j++)
				{
					Player_Editor player_Editor = this.players[j];
					if (player_Editor != null)
					{
						action(player_Editor.defaultJoystickMaps, id);
					}
				}
			}
			this.joystickLayouts.RemoveAt(index);
		}

		// Token: 0x06001C2E RID: 7214 RVA: 0x0001699B File Offset: 0x00014B9B
		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<InputLayout>(this.joystickLayouts, index, offsetDown, offsetNow);
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x00077F50 File Offset: 0x00076150
		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (this.joystickLayouts == null || index < 0 || index >= this.joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = this.joystickLayouts[index].Clone();
			inputLayout.id = this.GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, this.GetJoystickLayoutNames());
			if (index == this.joystickLayouts.Count - 1)
			{
				this.joystickLayouts.Add(inputLayout);
			}
			else
			{
				this.joystickLayouts.Insert(index + 1, inputLayout);
			}
			if (duplicateMaps)
			{
				int id = inputLayout.id;
				int id2 = this.joystickLayouts[index].id;
				if (this.joystickMaps != null)
				{
					for (int i = this.joystickMaps.Count - 1; i >= 0; i--)
					{
						if (this.joystickMaps[i].layoutId == id2)
						{
							int num = this.DuplicateJoystickMap(i);
							if (num >= 0)
							{
								this.joystickMaps[num].layoutId = id;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001C30 RID: 7216 RVA: 0x00078058 File Offset: 0x00076258
		public int GetJoystickLayoutMapCount(int id)
		{
			if (this.joystickLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (this.joystickMaps != null)
			{
				for (int i = 0; i < this.joystickMaps.Count; i++)
				{
					if (this.joystickMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x000780A8 File Offset: 0x000762A8
		public int GetJoystickLayoutIndex(int id)
		{
			if (this.joystickLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < this.joystickLayouts.Count; i++)
			{
				if (this.joystickLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x000780EC File Offset: 0x000762EC
		public string[] GetJoystickLayoutNames()
		{
			if (this.joystickLayouts == null)
			{
				return null;
			}
			string[] array = new string[this.joystickLayouts.Count];
			for (int i = 0; i < this.joystickLayouts.Count; i++)
			{
				array[i] = this.joystickLayouts[i].name;
			}
			return array;
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x00078140 File Offset: 0x00076340
		public int[] GetJoystickLayoutIds()
		{
			if (this.joystickLayouts == null)
			{
				return null;
			}
			int[] array = new int[this.joystickLayouts.Count];
			for (int i = 0; i < this.joystickLayouts.Count; i++)
			{
				array[i] = this.joystickLayouts[i].id;
			}
			return array;
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x000169AB File Offset: 0x00014BAB
		public InputLayout GetJoystickLayout(int index)
		{
			if (this.joystickLayouts == null || index < 0 || index >= this.joystickLayouts.Count)
			{
				return null;
			}
			return this.joystickLayouts[index];
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x00078194 File Offset: 0x00076394
		public InputLayout GetJoystickLayout(string name)
		{
			if (this.joystickLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return null;
			}
			return this.joystickLayouts[num];
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x000781C8 File Offset: 0x000763C8
		public InputLayout GetJoystickLayoutById(int id)
		{
			if (this.joystickLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfJoystickLayout(id);
			if (num < 0)
			{
				return null;
			}
			return this.joystickLayouts[num];
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x000781FC File Offset: 0x000763FC
		public int GetJoystickLayoutId(string name)
		{
			if (this.joystickLayouts == null)
			{
				return -1;
			}
			int num = this.IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return this.joystickLayouts[num].id;
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x00078234 File Offset: 0x00076434
		public int IndexOfJoystickLayout(int id)
		{
			if (this.joystickLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.joystickLayouts.Count; i++)
			{
				if (this.joystickLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x00078278 File Offset: 0x00076478
		public int IndexOfJoystickLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.joystickLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.joystickLayouts.Count; i++)
			{
				if (this.joystickLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x000782D4 File Offset: 0x000764D4
		public string GetJoystickLayoutNameById(int id)
		{
			if (this.joystickLayouts != null)
			{
				for (int i = 0; i < this.joystickLayouts.Count; i++)
				{
					if (this.joystickLayouts[i].id == id)
					{
						return this.joystickLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x000169D5 File Offset: 0x00014BD5
		public void AddKeyboardLayout()
		{
			this.keyboardLayouts.Add(this.VFkkqgNKTjmyUlirolEmKgINfsKl());
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x000169E8 File Offset: 0x00014BE8
		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= this.keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.keyboardLayouts.Insert(index, this.VFkkqgNKTjmyUlirolEmKgINfsKl());
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x0007832C File Offset: 0x0007652C
		public void DeleteKeyboardLayout(int index)
		{
			if (this.keyboardLayouts == null || index < 0 || index >= this.keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.keyboardLayouts[index].id;
			if (this.keyboardMaps != null)
			{
				for (int i = this.keyboardMaps.Count - 1; i >= 0; i--)
				{
					if (this.keyboardMaps[i].layoutId == id)
					{
						this.keyboardMaps.RemoveAt(i);
					}
				}
			}
			if (this.players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = new Action<List<Player_Editor.Mapping>, int>(UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb.<>9.bvBRalnEzfQrNLXfmPpKlJAHSONO);
				for (int j = 0; j < this.players.Count; j++)
				{
					Player_Editor player_Editor = this.players[j];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
					}
				}
			}
			this.keyboardLayouts.RemoveAt(index);
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x00016A19 File Offset: 0x00014C19
		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<InputLayout>(this.keyboardLayouts, index, offsetDown, offsetNow);
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x0007841C File Offset: 0x0007661C
		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (this.keyboardLayouts == null || index < 0 || index >= this.keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = this.keyboardLayouts[index].Clone();
			inputLayout.id = this.GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, this.GetKeyboardLayoutNames());
			if (index == this.keyboardLayouts.Count - 1)
			{
				this.keyboardLayouts.Add(inputLayout);
			}
			else
			{
				this.keyboardLayouts.Insert(index + 1, inputLayout);
			}
			if (duplicateMaps)
			{
				int id = inputLayout.id;
				int id2 = this.keyboardLayouts[index].id;
				if (this.keyboardMaps != null)
				{
					for (int i = this.keyboardMaps.Count - 1; i >= 0; i--)
					{
						if (this.keyboardMaps[i].layoutId == id2)
						{
							int num = this.DuplicateKeyboardMap(i);
							if (num >= 0)
							{
								this.keyboardMaps[num].layoutId = id;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x00078524 File Offset: 0x00076724
		public int GetKeyboardLayoutMapCount(int id)
		{
			if (this.keyboardLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (this.keyboardMaps != null)
			{
				for (int i = 0; i < this.keyboardMaps.Count; i++)
				{
					if (this.keyboardMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x00078574 File Offset: 0x00076774
		public int GetKeyboardLayoutIndex(int id)
		{
			if (this.keyboardLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < this.keyboardLayouts.Count; i++)
			{
				if (this.keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C42 RID: 7234 RVA: 0x000785B8 File Offset: 0x000767B8
		public string[] GetKeyboardLayoutNames()
		{
			if (this.keyboardLayouts == null)
			{
				return null;
			}
			string[] array = new string[this.keyboardLayouts.Count];
			for (int i = 0; i < this.keyboardLayouts.Count; i++)
			{
				array[i] = this.keyboardLayouts[i].name;
			}
			return array;
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x0007860C File Offset: 0x0007680C
		public int[] GetKeyboardLayoutIds()
		{
			if (this.keyboardLayouts == null)
			{
				return null;
			}
			int[] array = new int[this.keyboardLayouts.Count];
			for (int i = 0; i < this.keyboardLayouts.Count; i++)
			{
				array[i] = this.keyboardLayouts[i].id;
			}
			return array;
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x00016A29 File Offset: 0x00014C29
		public InputLayout GetKeyboardLayout(int index)
		{
			if (this.keyboardLayouts == null || index < 0 || index >= this.keyboardLayouts.Count)
			{
				return null;
			}
			return this.keyboardLayouts[index];
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x00078660 File Offset: 0x00076860
		public InputLayout GetKeyboardLayout(string name)
		{
			if (this.keyboardLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return null;
			}
			return this.keyboardLayouts[num];
		}

		// Token: 0x06001C46 RID: 7238 RVA: 0x00078694 File Offset: 0x00076894
		public InputLayout GetKeyboardLayoutById(int id)
		{
			if (this.keyboardLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfKeyboardLayout(id);
			if (num < 0)
			{
				return null;
			}
			return this.keyboardLayouts[num];
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x000786C8 File Offset: 0x000768C8
		public int GetKeyboardLayoutId(string name)
		{
			if (this.keyboardLayouts == null)
			{
				return -1;
			}
			int num = this.IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return this.keyboardLayouts[num].id;
		}

		// Token: 0x06001C48 RID: 7240 RVA: 0x00078700 File Offset: 0x00076900
		public int IndexOfKeyboardLayout(int id)
		{
			if (this.keyboardLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.keyboardLayouts.Count; i++)
			{
				if (this.keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x00078744 File Offset: 0x00076944
		public int IndexOfKeyboardLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.keyboardLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.keyboardLayouts.Count; i++)
			{
				if (this.keyboardLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x000787A0 File Offset: 0x000769A0
		public string GetKeyboardLayoutNameById(int id)
		{
			if (this.keyboardLayouts != null)
			{
				for (int i = 0; i < this.keyboardLayouts.Count; i++)
				{
					if (this.keyboardLayouts[i].id == id)
					{
						return this.keyboardLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x00016A53 File Offset: 0x00014C53
		public void AddMouseLayout()
		{
			this.mouseLayouts.Add(this.rHgbaFObSllvOgMLVeAGEbqMrFRl());
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x00016A66 File Offset: 0x00014C66
		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= this.mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.mouseLayouts.Insert(index, this.rHgbaFObSllvOgMLVeAGEbqMrFRl());
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x000787F8 File Offset: 0x000769F8
		public void DeleteMouseLayout(int index)
		{
			if (this.mouseLayouts == null || index < 0 || index >= this.mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.mouseLayouts[index].id;
			if (this.mouseMaps != null)
			{
				for (int i = this.mouseMaps.Count - 1; i >= 0; i--)
				{
					if (this.mouseMaps[i].layoutId == id)
					{
						this.mouseMaps.RemoveAt(i);
					}
				}
			}
			if (this.players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = new Action<List<Player_Editor.Mapping>, int>(UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb.<>9.MCloqWwEAkzDxQJsDYeUJoSqGbMO);
				for (int j = 0; j < this.players.Count; j++)
				{
					Player_Editor player_Editor = this.players[j];
					if (player_Editor != null)
					{
						action(player_Editor.defaultMouseMaps, id);
					}
				}
			}
			this.mouseLayouts.RemoveAt(index);
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x00016A97 File Offset: 0x00014C97
		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<InputLayout>(this.mouseLayouts, index, offsetDown, offsetNow);
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x000788E8 File Offset: 0x00076AE8
		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (this.mouseLayouts == null || index < 0 || index >= this.mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = this.mouseLayouts[index].Clone();
			inputLayout.id = this.GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, this.GetMouseLayoutNames());
			if (index == this.mouseLayouts.Count - 1)
			{
				this.mouseLayouts.Add(inputLayout);
			}
			else
			{
				this.mouseLayouts.Insert(index + 1, inputLayout);
			}
			if (duplicateMaps)
			{
				int id = inputLayout.id;
				int id2 = this.mouseLayouts[index].id;
				if (this.mouseMaps != null)
				{
					for (int i = this.mouseMaps.Count - 1; i >= 0; i--)
					{
						if (this.mouseMaps[i].layoutId == id2)
						{
							int num = this.DuplicateMouseMap(i);
							if (num >= 0)
							{
								this.mouseMaps[num].layoutId = id;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x000789F0 File Offset: 0x00076BF0
		public int GetMouseLayoutMapCount(int id)
		{
			if (this.mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (this.mouseMaps != null)
			{
				for (int i = 0; i < this.mouseMaps.Count; i++)
				{
					if (this.mouseMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x00078A40 File Offset: 0x00076C40
		public int GetMouseLayoutIndex(int id)
		{
			if (this.mouseLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mouseLayouts.Count; i++)
			{
				if (this.mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x00078A84 File Offset: 0x00076C84
		public string[] GetMouseLayoutNames()
		{
			if (this.mouseLayouts == null)
			{
				return null;
			}
			string[] array = new string[this.mouseLayouts.Count];
			for (int i = 0; i < this.mouseLayouts.Count; i++)
			{
				array[i] = this.mouseLayouts[i].name;
			}
			return array;
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x00078AD8 File Offset: 0x00076CD8
		public int[] GetMouseLayoutIds()
		{
			if (this.mouseLayouts == null)
			{
				return null;
			}
			int[] array = new int[this.mouseLayouts.Count];
			for (int i = 0; i < this.mouseLayouts.Count; i++)
			{
				array[i] = this.mouseLayouts[i].id;
			}
			return array;
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x00016AA7 File Offset: 0x00014CA7
		public InputLayout GetMouseLayout(int index)
		{
			if (this.mouseLayouts == null || index < 0 || index >= this.mouseLayouts.Count)
			{
				return null;
			}
			return this.mouseLayouts[index];
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x00078B2C File Offset: 0x00076D2C
		public InputLayout GetMouseLayout(string name)
		{
			if (this.mouseLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfMouseLayout(name);
			if (num < 0)
			{
				return null;
			}
			return this.mouseLayouts[num];
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x00078B60 File Offset: 0x00076D60
		public InputLayout GetMouseLayoutById(int id)
		{
			if (this.mouseLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfMouseLayout(id);
			if (num < 0)
			{
				return null;
			}
			return this.mouseLayouts[num];
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x00078B94 File Offset: 0x00076D94
		public int GetMouseLayoutId(string name)
		{
			if (this.mouseLayouts == null)
			{
				return -1;
			}
			int num = this.IndexOfMouseLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return this.mouseLayouts[num].id;
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x00078BCC File Offset: 0x00076DCC
		public int IndexOfMouseLayout(int id)
		{
			if (this.mouseLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.mouseLayouts.Count; i++)
			{
				if (this.mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x00078C10 File Offset: 0x00076E10
		public int IndexOfMouseLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.mouseLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.mouseLayouts.Count; i++)
			{
				if (this.mouseLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C5A RID: 7258 RVA: 0x00078C6C File Offset: 0x00076E6C
		public string GetMouseLayoutNameById(int id)
		{
			if (this.mouseLayouts != null)
			{
				for (int i = 0; i < this.mouseLayouts.Count; i++)
				{
					if (this.mouseLayouts[i].id == id)
					{
						return this.mouseLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x00016AD1 File Offset: 0x00014CD1
		public void AddCustomControllerLayout()
		{
			this.customControllerLayouts.Add(this.ntbjGshTcgULOYcQVBbXKyliIfsi());
		}

		// Token: 0x06001C5C RID: 7260 RVA: 0x00016AE4 File Offset: 0x00014CE4
		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= this.customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.customControllerLayouts.Insert(index, this.ntbjGshTcgULOYcQVBbXKyliIfsi());
		}

		// Token: 0x06001C5D RID: 7261 RVA: 0x00078CC4 File Offset: 0x00076EC4
		public void DeleteCustomControllerLayout(int index)
		{
			if (this.customControllerLayouts == null || index < 0 || index >= this.customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.customControllerLayouts[index].id;
			if (this.customControllerMaps != null)
			{
				for (int i = this.customControllerMaps.Count - 1; i >= 0; i--)
				{
					if (this.customControllerMaps[i].layoutId == id)
					{
						this.customControllerMaps.RemoveAt(i);
					}
				}
			}
			if (this.players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = new Action<List<Player_Editor.Mapping>, int>(UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb.<>9.uclABiiYTezhQiDlxgGYPevfjWzl);
				for (int j = 0; j < this.players.Count; j++)
				{
					Player_Editor player_Editor = this.players[j];
					if (player_Editor != null)
					{
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			this.customControllerLayouts.RemoveAt(index);
		}

		// Token: 0x06001C5E RID: 7262 RVA: 0x00016B15 File Offset: 0x00014D15
		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<InputLayout>(this.customControllerLayouts, index, offsetDown, offsetNow);
		}

		// Token: 0x06001C5F RID: 7263 RVA: 0x00078DB4 File Offset: 0x00076FB4
		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (this.customControllerLayouts == null || index < 0 || index >= this.customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = this.customControllerLayouts[index].Clone();
			inputLayout.id = this.GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, this.GetCustomControllerLayoutNames());
			if (index == this.customControllerLayouts.Count - 1)
			{
				this.customControllerLayouts.Add(inputLayout);
			}
			else
			{
				this.customControllerLayouts.Insert(index + 1, inputLayout);
			}
			if (duplicateMaps)
			{
				int id = inputLayout.id;
				int id2 = this.customControllerLayouts[index].id;
				if (this.customControllerMaps != null)
				{
					for (int i = this.customControllerMaps.Count - 1; i >= 0; i--)
					{
						if (this.customControllerMaps[i].layoutId == id2)
						{
							int num = this.DuplicateCustomControllerMap(i);
							if (num >= 0)
							{
								this.customControllerMaps[num].layoutId = id;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001C60 RID: 7264 RVA: 0x00078EBC File Offset: 0x000770BC
		public int GetCustomControllerLayoutMapCount(int id)
		{
			if (this.customControllerLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (this.customControllerMaps != null)
			{
				for (int i = 0; i < this.customControllerMaps.Count; i++)
				{
					if (this.customControllerMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001C61 RID: 7265 RVA: 0x00078F0C File Offset: 0x0007710C
		public int GetCustomControllerLayoutIndex(int id)
		{
			if (this.customControllerLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < this.customControllerLayouts.Count; i++)
			{
				if (this.customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C62 RID: 7266 RVA: 0x00078F50 File Offset: 0x00077150
		public string[] GetCustomControllerLayoutNames()
		{
			if (this.customControllerLayouts == null)
			{
				return null;
			}
			string[] array = new string[this.customControllerLayouts.Count];
			for (int i = 0; i < this.customControllerLayouts.Count; i++)
			{
				array[i] = this.customControllerLayouts[i].name;
			}
			return array;
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x00078FA4 File Offset: 0x000771A4
		public int[] GetCustomControllerLayoutIds()
		{
			if (this.customControllerLayouts == null)
			{
				return null;
			}
			int[] array = new int[this.customControllerLayouts.Count];
			for (int i = 0; i < this.customControllerLayouts.Count; i++)
			{
				array[i] = this.customControllerLayouts[i].id;
			}
			return array;
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x00016B25 File Offset: 0x00014D25
		public InputLayout GetCustomControllerLayout(int index)
		{
			if (this.customControllerLayouts == null || index < 0 || index >= this.customControllerLayouts.Count)
			{
				return null;
			}
			return this.customControllerLayouts[index];
		}

		// Token: 0x06001C65 RID: 7269 RVA: 0x00078FF8 File Offset: 0x000771F8
		public InputLayout GetCustomControllerLayout(string name)
		{
			if (this.customControllerLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return null;
			}
			return this.customControllerLayouts[num];
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x0007902C File Offset: 0x0007722C
		public InputLayout GetCustomControllerLayoutById(int id)
		{
			if (this.customControllerLayouts == null)
			{
				return null;
			}
			int num = this.IndexOfCustomControllerLayout(id);
			if (num < 0)
			{
				return null;
			}
			return this.customControllerLayouts[num];
		}

		// Token: 0x06001C67 RID: 7271 RVA: 0x00079060 File Offset: 0x00077260
		public int GetCustomControllerLayoutId(string name)
		{
			if (this.customControllerLayouts == null)
			{
				return -1;
			}
			int num = this.IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return this.customControllerLayouts[num].id;
		}

		// Token: 0x06001C68 RID: 7272 RVA: 0x00079098 File Offset: 0x00077298
		public int IndexOfCustomControllerLayout(int id)
		{
			if (this.customControllerLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.customControllerLayouts.Count; i++)
			{
				if (this.customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C69 RID: 7273 RVA: 0x000790DC File Offset: 0x000772DC
		public int IndexOfCustomControllerLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.customControllerLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < this.customControllerLayouts.Count; i++)
			{
				if (this.customControllerLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001C6A RID: 7274 RVA: 0x00079138 File Offset: 0x00077338
		public string GetCustomControllerLayoutNameById(int id)
		{
			if (this.customControllerLayouts != null)
			{
				for (int i = 0; i < this.customControllerLayouts.Count; i++)
				{
					if (this.customControllerLayouts[i].id == id)
					{
						return this.customControllerLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001C6B RID: 7275 RVA: 0x00016B4F File Offset: 0x00014D4F
		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return this.GetKeyboardLayoutNameById(id);
			case ControllerType.Mouse:
				return this.GetMouseLayoutNameById(id);
			case ControllerType.Joystick:
				return this.GetJoystickLayoutNameById(id);
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return this.GetCustomControllerLayoutNameById(id);
			}
		}

		// Token: 0x06001C6C RID: 7276 RVA: 0x00079190 File Offset: 0x00077390
		internal ControllerMap orpcuTByDKjWdCWGmwZhSNbviFRtA(Controller A_1, int A_2, int A_3)
		{
			if (A_1 == null)
			{
				return null;
			}
			ControllerType type = A_1.type;
			switch (type)
			{
			case ControllerType.Keyboard:
				return this.FindKeyboardMap_Game((Keyboard)A_1, A_2, A_3);
			case ControllerType.Mouse:
				return this.FindMouseMap_Game((Mouse)A_1, A_2, A_3);
			case ControllerType.Joystick:
				return this.dCtulAuKluDweDSLBLXTmZcbbpEXA((Joystick)A_1, A_2, A_3);
			default:
				if (type != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return this.GIsOtUvWYIJylyqaDKWRZDnDCgTL(A_2, ((CustomController)A_1).sourceControllerId, A_3);
			}
		}

		// Token: 0x06001C6D RID: 7277 RVA: 0x00079208 File Offset: 0x00077408
		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (this.joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (this.joystickMaps[i].categoryId == categoryId && this.joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(this.joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return this.joystickMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C6E RID: 7278 RVA: 0x0007928C File Offset: 0x0007748C
		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			if (this.joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (this.joystickMaps[i].id == id)
				{
					joystickMapIndex = i;
					return this.joystickMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C6F RID: 7279 RVA: 0x000792E4 File Offset: 0x000774E4
		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			if (this.joystickMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(this.joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					list.Add(this.joystickMaps[i]);
				}
			}
			return list;
		}

		// Token: 0x06001C70 RID: 7280 RVA: 0x00079348 File Offset: 0x00077548
		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (this.joystickMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (this.joystickMaps[i].categoryId == categoryId && this.joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(this.joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return this.joystickMaps[i].id;
				}
			}
			return -1;
		}

		// Token: 0x06001C71 RID: 7281 RVA: 0x000793D0 File Offset: 0x000775D0
		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (this.joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (this.joystickMaps[i].categoryId == categoryId && this.joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(this.joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C72 RID: 7282 RVA: 0x00079448 File Offset: 0x00077648
		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (this.joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(this.joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C73 RID: 7283 RVA: 0x00079498 File Offset: 0x00077698
		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			if (this.joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(this.joystickMaps[i].hardwareGuidString) == hardwareGuid && this.joystickMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C74 RID: 7284 RVA: 0x000794FC File Offset: 0x000776FC
		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			if (this.joystickMaps == null)
			{
				this.joystickMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = this.GetNewJoystickMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
			this.joystickMaps.Add(controllerMap_Editor);
			return false;
		}

		// Token: 0x06001C75 RID: 7285 RVA: 0x0007955C File Offset: 0x0007775C
		public void DeleteJoystickMap(int id)
		{
			if (this.joystickMaps == null)
			{
				return;
			}
			for (int i = this.joystickMaps.Count - 1; i >= 0; i--)
			{
				if (this.joystickMaps[i].id == id)
				{
					this.joystickMaps.RemoveAt(i);
				}
			}
		}

		// Token: 0x06001C76 RID: 7286 RVA: 0x000795AC File Offset: 0x000777AC
		public int DuplicateJoystickMap(int index)
		{
			if (this.joystickMaps == null || index < 0 || index >= this.joystickMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = this.joystickMaps[index].Clone();
			controllerMap_Editor.id = this.GetNewJoystickMapId();
			this.joystickMaps.Add(controllerMap_Editor);
			return this.joystickMaps.Count - 1;
		}

		// Token: 0x06001C77 RID: 7287 RVA: 0x00016B8F File Offset: 0x00014D8F
		internal JoystickMap VsWfhIEJSHPwfybYTNgQATDBittLc(HardwareControllerMapIdentifier A_1, int A_2, int A_3)
		{
			return this.IapSQsrNfkCXYfNEKxFuZyZecOgx(new HardwareControllerMapIdentifier(A_1.guid, A_1.inputSource, A_1.actualInputPlatform, A_1.variantIndex), A_2, A_3);
		}

		// Token: 0x06001C78 RID: 7288 RVA: 0x00016BB6 File Offset: 0x00014DB6
		internal JoystickMap dCtulAuKluDweDSLBLXTmZcbbpEXA(Joystick A_1, int A_2, int A_3)
		{
			if (A_1 == null)
			{
				return null;
			}
			return this.IapSQsrNfkCXYfNEKxFuZyZecOgx(A_1.ThGbXXlsifIbguAVciLTnfCzoQwS, A_2, A_3);
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x00079618 File Offset: 0x00077818
		private JoystickMap IapSQsrNfkCXYfNEKxFuZyZecOgx(HardwareControllerMapIdentifier A_1, int A_2, int A_3)
		{
			Guid guid = A_1.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.uvbTXFnBIWdsaBbqTxQYWiewbGQW(guid);
			ControllerMap_Editor controllerMap_Editor = this.qXAZqOtbYugcaUxSZcpWBenpeHUib(A_2, guid, A_3, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.XPPshKhJAPrwuiStAmfGiuotCdyc(this.containsActionDelegate, A_1, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.XLLVBHcQxQsleIwRyOozlDabqaKS(guid, A_2, A_3);
				return joystickMap;
			}
			if (hardwareJoystickMap != null)
			{
				foreach (Guid guid2 in hardwareJoystickMap.TemplateGuids)
				{
					if (!(guid2 == Guid.Empty))
					{
						HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.uRpaawDYhbeOcEvysNVmUlguJYt(guid2);
						if (hardwareJoystickTemplateMap != null)
						{
							controllerMap_Editor = this.qXAZqOtbYugcaUxSZcpWBenpeHUib(A_2, guid2, A_3, false);
							if (controllerMap_Editor != null)
							{
								JoystickMap joystickMap = this.jaxYKzlRywDHJKNFNwPBnQNUWZN(A_1, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, A_2, A_3);
								if (joystickMap != null)
								{
									joystickMap.XLLVBHcQxQsleIwRyOozlDabqaKS(guid, A_2, A_3);
									return joystickMap;
								}
							}
						}
					}
				}
			}
			if (guid == Guid.Empty)
			{
				controllerMap_Editor = this.qXAZqOtbYugcaUxSZcpWBenpeHUib(A_2, Guid.Empty, A_3, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.XPPshKhJAPrwuiStAmfGiuotCdyc(this.containsActionDelegate, A_1, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.XLLVBHcQxQsleIwRyOozlDabqaKS(guid, A_2, A_3);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.HKXFkYgXWGhCJSjCCpslBeOMKWGxA(guid, A_2, A_3);
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x00079764 File Offset: 0x00077964
		private ControllerMap_Editor qXAZqOtbYugcaUxSZcpWBenpeHUib(int A_1, Guid A_2, int A_3, bool A_4)
		{
			ControllerMap_Editor controllerMap_Editor = this.GetJoystickMap(A_1, A_2, A_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (A_4)
			{
				controllerMap_Editor = this.TwMqTnaHnZCDPCsTzbwEUHmbTVdKA(A_1, A_2, A_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		// Token: 0x06001C7B RID: 7291 RVA: 0x00079794 File Offset: 0x00077994
		private ControllerMap_Editor TwMqTnaHnZCDPCsTzbwEUHmbTVdKA(int A_1, Guid A_2, int A_3)
		{
			List<ControllerMap_Editor> list = this.GetJoystickMaps(A_2);
			if (list != null && list.Count > 0)
			{
				this.kVSWOtdcolCfxiviJkiDSDTxzClRA(list, this.joystickLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == A_1)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x00079814 File Offset: 0x00077A14
		private JoystickMap jaxYKzlRywDHJKNFNwPBnQNUWZN(HardwareControllerMapIdentifier A_1, ControllerMap_Editor A_2, HardwareJoystickTemplateMap A_3, HardwareJoystickMap A_4, int A_5, int A_6)
		{
			if (A_3 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = A_2.Clone();
			string text;
			if (!A_3.aeoHOEfveLLngskiiVRagdYEWIqz(controllerMap_Editor, A_4, A_1.guid, out text))
			{
				Logger.LogError(string.Concat(new string[]
				{
					"Error remapping joystick template ",
					A_3.Guid.ToString(),
					" to joystick ",
					A_1.guid.ToString(),
					"\nReason: ",
					text
				}));
				return null;
			}
			return controllerMap_Editor.XPPshKhJAPrwuiStAmfGiuotCdyc(this.containsActionDelegate, A_1, A_4, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		// Token: 0x06001C7D RID: 7293 RVA: 0x000798C4 File Offset: 0x00077AC4
		private JoystickMap XCaDwZMuSkegvjvNahnUcmbaYTiRb(JoystickMap A_1, HardwareControllerMapIdentifier A_2)
		{
			if (A_1 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.uvbTXFnBIWdsaBbqTxQYWiewbGQW(A_1.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.uvbTXFnBIWdsaBbqTxQYWiewbGQW(Guid.Empty);
			if (hardwareJoystickMap2 == null)
			{
				return null;
			}
			int[] array;
			int[] array2;
			hardwareJoystickMap.GetElementIdentifiersForControllerElements(A_2, false, out array, out array2);
			if (array == null && array2 == null)
			{
				return null;
			}
			bool flag = false;
			List<int> list = new List<int>();
			foreach (ActionElementMap actionElementMap in A_1.AllMaps)
			{
				ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(actionElementMap._elementIdentifierId);
				if (elementIdentifier != null)
				{
					string name = elementIdentifier.name;
					if (!string.IsNullOrEmpty(name))
					{
						int num = 0;
						int num2 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
						if (num2 < 0)
						{
							num2 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
							num = 1;
						}
						if (num2 >= 0 && (num != 0 || array != null) && (num != 1 || array2 != null))
						{
							string text = Regex.Replace(name, "[^0-9]+", "");
							Logger.Log(text);
							int num3;
							if (int.TryParse(text, out num3))
							{
								if (num == 0)
								{
									if (num3 >= array.Length)
									{
										goto IL_124;
									}
									actionElementMap._elementIdentifierId = array[num3];
								}
								else
								{
									if (num3 >= array2.Length)
									{
										goto IL_124;
									}
									actionElementMap._elementIdentifierId = array2[num3];
								}
								flag = true;
								continue;
							}
						}
					}
				}
				IL_124:
				list.Add(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB);
			}
			for (int i = 0; i < list.Count; i++)
			{
				A_1.DeleteElementMap(list[i]);
			}
			if (!flag)
			{
				return null;
			}
			return A_1;
		}

		// Token: 0x06001C7E RID: 7294 RVA: 0x00079A5C File Offset: 0x00077C5C
		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			if (this.keyboardMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				if (this.keyboardMaps[i].categoryId == categoryId && this.keyboardMaps[i].layoutId == layoutId)
				{
					return this.keyboardMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C7F RID: 7295 RVA: 0x00079AC0 File Offset: 0x00077CC0
		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			if (this.keyboardMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				if (this.keyboardMaps[i].categoryId == categoryId && this.keyboardMaps[i].layoutId == layoutId)
				{
					return this.keyboardMaps[i].id;
				}
			}
			return -1;
		}

		// Token: 0x06001C80 RID: 7296 RVA: 0x00079B28 File Offset: 0x00077D28
		public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (this.keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				if (this.keyboardMaps[i].categoryId == categoryId && this.keyboardMaps[i].layoutId == layoutId && StringTools.ToGuid(this.keyboardMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C81 RID: 7297 RVA: 0x00079BA0 File Offset: 0x00077DA0
		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (this.keyboardMaps == null)
			{
				this.keyboardMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = this.GetNewKeyboardMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			this.keyboardMaps.Add(controllerMap_Editor);
			return false;
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x00079BF0 File Offset: 0x00077DF0
		public void DeleteKeyboardMap(int id)
		{
			if (this.keyboardMaps == null)
			{
				return;
			}
			for (int i = this.keyboardMaps.Count - 1; i >= 0; i--)
			{
				if (this.keyboardMaps[i].id == id)
				{
					this.keyboardMaps.RemoveAt(i);
				}
			}
		}

		// Token: 0x06001C83 RID: 7299 RVA: 0x00079C40 File Offset: 0x00077E40
		public int DuplicateKeyboardMap(int index)
		{
			if (this.keyboardMaps == null || index < 0 || index >= this.keyboardMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = this.keyboardMaps[index].Clone();
			controllerMap_Editor.id = this.GetNewKeyboardMapId();
			this.keyboardMaps.Add(controllerMap_Editor);
			return this.keyboardMaps.Count - 1;
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x00079CAC File Offset: 0x00077EAC
		public ControllerMap_Editor GetKeyboardMapById(int id, out int keyboardMapIndex)
		{
			keyboardMapIndex = -1;
			if (this.keyboardMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				if (this.keyboardMaps[i].id == id)
				{
					keyboardMapIndex = i;
					return this.keyboardMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x00079D04 File Offset: 0x00077F04
		public KeyboardMap FindKeyboardMap_Game(Keyboard keyboard, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = this.btuQjOrCAMGjMbwzOQFisbjOKWkv(this.keyboardMaps, this.keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.YNsUmlddoSPOqfSpCQmbJQOffggBA(this.containsActionDelegate);
				keyboardMap.yUkhcSLWGUxPKUABHGsjYhImYVXc(keyboard.legQjhUclFMVpVFTfXDlmJRWuUQj, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.JFaSyrHBRaiVbkesrgmCvmgtAwXT(keyboard.legQjhUclFMVpVFTfXDlmJRWuUQj, categoryId, layoutId);
			}
			return keyboardMap;
		}

		// Token: 0x06001C86 RID: 7302 RVA: 0x00079D58 File Offset: 0x00077F58
		public bool HasKeyboardMapInCategory(int categoryId)
		{
			if (this.keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				if (this.keyboardMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C87 RID: 7303 RVA: 0x00079D9C File Offset: 0x00077F9C
		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			if (this.keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.keyboardMaps.Count; i++)
			{
				if (this.keyboardMaps[i].categoryId == categoryId && this.keyboardMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C88 RID: 7304 RVA: 0x00079DF4 File Offset: 0x00077FF4
		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			if (this.mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				if (this.mouseMaps[i].categoryId == categoryId && this.mouseMaps[i].layoutId == layoutId)
				{
					return this.mouseMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x00079E58 File Offset: 0x00078058
		public int GetMouseMapId(int categoryId, int layoutId)
		{
			if (this.mouseMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				if (this.mouseMaps[i].categoryId == categoryId && this.mouseMaps[i].layoutId == layoutId)
				{
					return this.mouseMaps[i].id;
				}
			}
			return -1;
		}

		// Token: 0x06001C8A RID: 7306 RVA: 0x00079EC0 File Offset: 0x000780C0
		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (this.mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				if (this.mouseMaps[i].categoryId == categoryId && this.mouseMaps[i].layoutId == layoutId && StringTools.ToGuid(this.mouseMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C8B RID: 7307 RVA: 0x00079F38 File Offset: 0x00078138
		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (this.mouseMaps == null)
			{
				this.mouseMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = this.GetNewMouseMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			this.mouseMaps.Add(controllerMap_Editor);
			return false;
		}

		// Token: 0x06001C8C RID: 7308 RVA: 0x00079F88 File Offset: 0x00078188
		public void DeleteMouseMap(int id)
		{
			if (this.mouseMaps == null)
			{
				return;
			}
			for (int i = this.mouseMaps.Count - 1; i >= 0; i--)
			{
				if (this.mouseMaps[i].id == id)
				{
					this.mouseMaps.RemoveAt(i);
				}
			}
		}

		// Token: 0x06001C8D RID: 7309 RVA: 0x00079FD8 File Offset: 0x000781D8
		public int DuplicateMouseMap(int index)
		{
			if (this.mouseMaps == null || index < 0 || index >= this.mouseMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = this.mouseMaps[index].Clone();
			controllerMap_Editor.id = this.GetNewMouseMapId();
			this.mouseMaps.Add(controllerMap_Editor);
			return this.mouseMaps.Count - 1;
		}

		// Token: 0x06001C8E RID: 7310 RVA: 0x0007A044 File Offset: 0x00078244
		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (this.mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				if (this.mouseMaps[i].id == id)
				{
					mouseMapIndex = i;
					return this.mouseMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C8F RID: 7311 RVA: 0x0007A09C File Offset: 0x0007829C
		public MouseMap FindMouseMap_Game(Mouse mouse, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = this.btuQjOrCAMGjMbwzOQFisbjOKWkv(this.mouseMaps, this.mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.SIXtwqRHUKcorBGgjrrbiaHhCcJJ(this.containsActionDelegate);
				mouseMap.DaIUDwcOBiNKdDPlNBvjUsMbjBoe(mouse.legQjhUclFMVpVFTfXDlmJRWuUQj, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.RNwLiQPNKIHevYltYooFXsuqwmkl(mouse.legQjhUclFMVpVFTfXDlmJRWuUQj, categoryId, layoutId);
			}
			return mouseMap;
		}

		// Token: 0x06001C90 RID: 7312 RVA: 0x0007A0F0 File Offset: 0x000782F0
		public bool HasMouseMapInCategory(int categoryId)
		{
			if (this.mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				if (this.mouseMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C91 RID: 7313 RVA: 0x0007A134 File Offset: 0x00078334
		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			if (this.mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.mouseMaps.Count; i++)
			{
				if (this.mouseMaps[i].categoryId == categoryId && this.mouseMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C92 RID: 7314 RVA: 0x0007A18C File Offset: 0x0007838C
		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (this.customControllerMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].categoryId == categoryId && this.customControllerMaps[i].layoutId == layoutId && this.customControllerMaps[i].customControllerUid == controllerUid)
				{
					return this.customControllerMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C93 RID: 7315 RVA: 0x0007A204 File Offset: 0x00078404
		public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
		{
			customControllerMapIndex = -1;
			if (this.customControllerMaps == null)
			{
				return null;
			}
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].id == mapId)
				{
					customControllerMapIndex = i;
					return this.customControllerMaps[i];
				}
			}
			return null;
		}

		// Token: 0x06001C94 RID: 7316 RVA: 0x0007A25C File Offset: 0x0007845C
		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (this.customControllerMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].customControllerUid == controllerUid)
				{
					list.Add(this.customControllerMaps[i]);
				}
			}
			return list;
		}

		// Token: 0x06001C95 RID: 7317 RVA: 0x0007A2B8 File Offset: 0x000784B8
		public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
		{
			if (this.customControllerMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].categoryId == categoryId && this.customControllerMaps[i].layoutId == layoutId && this.customControllerMaps[i].customControllerUid == controllerUid)
				{
					return this.customControllerMaps[i].id;
				}
			}
			return -1;
		}

		// Token: 0x06001C96 RID: 7318 RVA: 0x0007A334 File Offset: 0x00078534
		public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
		{
			if (this.customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].categoryId == categoryId && this.customControllerMaps[i].layoutId == layoutId && this.customControllerMaps[i].id == mapId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C97 RID: 7319 RVA: 0x0007A3A0 File Offset: 0x000785A0
		public bool HasCustomControllerMap(int mapId)
		{
			if (this.customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].id == mapId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C98 RID: 7320 RVA: 0x0007A3E4 File Offset: 0x000785E4
		public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
		{
			if (this.customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < this.customControllerMaps.Count; i++)
			{
				if (this.customControllerMaps[i].customControllerUid == controllerUid && this.customControllerMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001C99 RID: 7321 RVA: 0x0007A43C File Offset: 0x0007863C
		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (this.customControllerMaps == null)
			{
				this.customControllerMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = this.GetNewCustomControllerMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = string.Empty;
			controllerMap_Editor.customControllerUid = controllerUid;
			this.customControllerMaps.Add(controllerMap_Editor);
			return false;
		}

		// Token: 0x06001C9A RID: 7322 RVA: 0x0007A49C File Offset: 0x0007869C
		public void DeleteCustomControllerMap(int mapId)
		{
			if (this.customControllerMaps == null)
			{
				return;
			}
			for (int i = this.customControllerMaps.Count - 1; i >= 0; i--)
			{
				if (this.customControllerMaps[i].id == mapId)
				{
					this.customControllerMaps.RemoveAt(i);
				}
			}
		}

		// Token: 0x06001C9B RID: 7323 RVA: 0x0007A4EC File Offset: 0x000786EC
		public int DuplicateCustomControllerMap(int index)
		{
			if (this.customControllerMaps == null || index < 0 || index >= this.customControllerMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = this.customControllerMaps[index].Clone();
			controllerMap_Editor.id = this.GetNewCustomControllerMapId();
			this.customControllerMaps.Add(controllerMap_Editor);
			return this.customControllerMaps.Count - 1;
		}

		// Token: 0x06001C9C RID: 7324 RVA: 0x00016BCB File Offset: 0x00014DCB
		internal CustomControllerMap JufticZIQJGwKdCVMylEvhHUDPYb(Guid A_1, int A_2, int A_3)
		{
			return this.KHszMzlhNNxvdBiHoPEdGfDclxjc(this.GetCustomControllerByHardwareTypeGuid(A_1), A_2, A_3);
		}

		// Token: 0x06001C9D RID: 7325 RVA: 0x00016BDC File Offset: 0x00014DDC
		internal CustomControllerMap GIsOtUvWYIJylyqaDKWRZDnDCgTL(int A_1, int A_2, int A_3)
		{
			return this.KHszMzlhNNxvdBiHoPEdGfDclxjc(this.GetCustomControllerById(A_2), A_1, A_3);
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x0007A558 File Offset: 0x00078758
		private CustomControllerMap KHszMzlhNNxvdBiHoPEdGfDclxjc(CustomController_Editor A_1, int A_2, int A_3)
		{
			if (A_1 == null)
			{
				return null;
			}
			int id = A_1.id;
			ControllerMap_Editor controllerMap_Editor = this.nZNsKrmpgZxlZcyKJptwBHAeJozk(A_2, id, A_3, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.ECEGOeUousPxazvEFycwLpNyllxG(new Func<int, bool>(this.ContainsAction), A_1);
				customControllerMap.NWOGoEOsoPcpvkmXyMKLethdNbuMc(A_1.typeGuid, id, A_2, A_3);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.CktVxwkSxOMnGYFuGSaZIHydTBRF(A_1.typeGuid, id, A_2, A_3);
			customControllerMap2.NWOGoEOsoPcpvkmXyMKLethdNbuMc(A_1.typeGuid, id, A_2, A_3);
			return customControllerMap2;
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x0007A5C0 File Offset: 0x000787C0
		private ControllerMap_Editor nZNsKrmpgZxlZcyKJptwBHAeJozk(int A_1, int A_2, int A_3, bool A_4)
		{
			ControllerMap_Editor controllerMap_Editor = this.GetCustomControllerMap(A_1, A_2, A_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (A_4)
			{
				controllerMap_Editor = this.RtslWjRZdTwSElhjZQBvMhVhuYlt(A_1, A_2, A_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		// Token: 0x06001CA0 RID: 7328 RVA: 0x0007A5F0 File Offset: 0x000787F0
		private ControllerMap_Editor RtslWjRZdTwSElhjZQBvMhVhuYlt(int A_1, int A_2, int A_3)
		{
			List<ControllerMap_Editor> list = this.GetCustomControllerMaps(A_2);
			if (list != null && list.Count > 0)
			{
				this.kVSWOtdcolCfxiviJkiDSDTxzClRA(list, this.customControllerLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == A_1)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		// Token: 0x06001CA1 RID: 7329 RVA: 0x00016BED File Offset: 0x00014DED
		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				this.DeleteKeyboardMap(id);
				return;
			case ControllerType.Mouse:
				this.DeleteMouseMap(id);
				return;
			case ControllerType.Joystick:
				this.DeleteJoystickMap(id);
				return;
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				this.DeleteCustomControllerMap(id);
				return;
			}
		}

		// Token: 0x06001CA2 RID: 7330 RVA: 0x0007A670 File Offset: 0x00078870
		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				if (this.keyboardMaps == null)
				{
					return null;
				}
				return this.keyboardMaps[index];
			case ControllerType.Mouse:
				if (this.mouseMaps == null)
				{
					return null;
				}
				return this.mouseMaps[index];
			case ControllerType.Joystick:
				if (this.joystickMaps == null)
				{
					return null;
				}
				return this.joystickMaps[index];
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				if (this.customControllerMaps == null)
				{
					return null;
				}
				return this.customControllerMaps[index];
			}
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x0007A6F8 File Offset: 0x000788F8
		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return this.GetKeyboardMapById(id, out controllerMapIndex);
			case ControllerType.Mouse:
				return this.GetMouseMapById(id, out controllerMapIndex);
			case ControllerType.Joystick:
				return this.GetJoystickMapById(id, out controllerMapIndex);
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return this.GetCustomControllerMapById(id, out controllerMapIndex);
			}
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x00016C2D File Offset: 0x00014E2D
		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return this.DuplicateKeyboardMap(index);
			case ControllerType.Mouse:
				return this.DuplicateMouseMap(index);
			case ControllerType.Joystick:
				return this.DuplicateJoystickMap(index);
			default:
				if (controllerType != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return this.DuplicateCustomControllerMap(index);
			}
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x0007A748 File Offset: 0x00078948
		internal ControllerTemplateMap PYBtkAKavdubFJuTfiYoFHIiPNpM(Guid A_1, int A_2, int A_3)
		{
			ControllerMap_Editor joystickMap = this.GetJoystickMap(A_2, A_1, A_3);
			if (joystickMap == null)
			{
				return null;
			}
			return joystickMap.FVuvWhIxswUyaXIjTxYhZcdDYMTI();
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x00016C6D File Offset: 0x00014E6D
		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void AddCustomController()
		{
			this.AddCustomController(Guid.NewGuid());
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x00016C7A File Offset: 0x00014E7A
		public void AddCustomController(Guid typeGuid)
		{
			if (this.customControllers == null)
			{
				this.customControllers = new List<CustomController_Editor>();
			}
			this.customControllers.Add(this.yAuqGyDcJYlNVmkCUKnXnOwkZhJt(typeGuid));
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x00016CA1 File Offset: 0x00014EA1
		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void InsertCustomController(int index)
		{
			this.InsertCustomController(index, Guid.NewGuid());
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x0007A76C File Offset: 0x0007896C
		public void InsertCustomController(int index, Guid typeGuid)
		{
			if (this.customControllers == null)
			{
				this.customControllers = new List<CustomController_Editor>();
			}
			if (index < 0 || index >= this.customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.customControllers.Insert(index, this.yAuqGyDcJYlNVmkCUKnXnOwkZhJt(typeGuid));
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x0007A7BC File Offset: 0x000789BC
		public void DeleteCustomController(int index)
		{
			if (this.customControllers == null || index < 0 || index >= this.customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.customControllers[index].id;
			if (this.customControllerMaps != null)
			{
				for (int i = this.customControllerMaps.Count - 1; i >= 0; i--)
				{
					if (this.customControllerMaps[i].customControllerUid == id)
					{
						this.customControllerMaps.RemoveAt(i);
					}
				}
			}
			this.customControllers.RemoveAt(index);
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x00016CAF File Offset: 0x00014EAF
		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<CustomController_Editor>(this.customControllers, index, offsetDown, offsetNow);
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x00016CBF File Offset: 0x00014EBF
		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			this.DuplicateCustomController(index, duplicateMaps, Guid.NewGuid());
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x0007A84C File Offset: 0x00078A4C
		public void DuplicateCustomController(int index, bool duplicateMaps, Guid typeGuid)
		{
			if (this.customControllers == null || index < 0 || index >= this.customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CustomController_Editor customController_Editor = this.customControllers[index].Clone();
			customController_Editor.id = this.GetNewCustomControllerId();
			customController_Editor.typeGuid = typeGuid;
			customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, this.GetCustomControllerNames());
			if (index == this.customControllers.Count - 1)
			{
				this.customControllers.Add(customController_Editor);
			}
			else
			{
				this.customControllers.Insert(index + 1, customController_Editor);
			}
			if (duplicateMaps)
			{
				int id = customController_Editor.id;
				int id2 = this.customControllers[index].id;
				if (this.customControllerMaps != null)
				{
					for (int i = this.customControllerMaps.Count - 1; i >= 0; i--)
					{
						if (this.customControllerMaps[i].customControllerUid == id2)
						{
							int num = this.DuplicateCustomControllerMap(i);
							if (num >= 0)
							{
								this.customControllerMaps[num].customControllerUid = id;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x0007A95C File Offset: 0x00078B5C
		public int GetCustomControllerMapCount(int controllerUid)
		{
			if (this.customControllers == null)
			{
				return 0;
			}
			int num = 0;
			if (this.customControllerMaps != null)
			{
				for (int i = 0; i < this.customControllerMaps.Count; i++)
				{
					if (this.customControllerMaps[i].customControllerUid == controllerUid)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001CAF RID: 7343 RVA: 0x0007A9AC File Offset: 0x00078BAC
		public int GetCustomControllerIndex(int id)
		{
			if (this.customControllers == null)
			{
				return 0;
			}
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				if (this.customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CB0 RID: 7344 RVA: 0x0007A9F0 File Offset: 0x00078BF0
		public string[] GetCustomControllerNames()
		{
			if (this.customControllers == null)
			{
				return null;
			}
			string[] array = new string[this.customControllers.Count];
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				array[i] = this.customControllers[i].name;
			}
			return array;
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x0007AA44 File Offset: 0x00078C44
		public int[] GetCustomControllerIds()
		{
			if (this.customControllers == null)
			{
				return null;
			}
			int[] array = new int[this.customControllers.Count];
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				array[i] = this.customControllers[i].id;
			}
			return array;
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x0007AA98 File Offset: 0x00078C98
		public Guid[] GetCustomControllerGuids()
		{
			if (this.customControllers == null)
			{
				return null;
			}
			Guid[] array = new Guid[this.customControllers.Count];
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				array[i] = this.customControllers[i].typeGuid;
			}
			return array;
		}

		// Token: 0x06001CB3 RID: 7347 RVA: 0x00016CCE File Offset: 0x00014ECE
		public CustomController_Editor GetCustomController(int index)
		{
			if (this.customControllers == null || index < 0 || index >= this.customControllers.Count)
			{
				return null;
			}
			return this.customControllers[index];
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x0007AAF0 File Offset: 0x00078CF0
		public CustomController_Editor GetCustomController(string name)
		{
			if (this.customControllers == null)
			{
				return null;
			}
			int num = this.IndexOfCustomController(name);
			if (num < 0)
			{
				return null;
			}
			return this.customControllers[num];
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x0007AB24 File Offset: 0x00078D24
		public CustomController_Editor GetCustomControllerById(int id)
		{
			if (this.customControllers == null)
			{
				return null;
			}
			int num = this.IndexOfCustomController(id);
			if (num < 0)
			{
				return null;
			}
			return this.customControllers[num];
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x0007AB58 File Offset: 0x00078D58
		public CustomController_Editor GetCustomControllerByHardwareTypeGuid(Guid hardwareTypeGuid)
		{
			if (this.customControllers == null)
			{
				return null;
			}
			int num = this.IndexOfCustomController(hardwareTypeGuid);
			if (num < 0)
			{
				return null;
			}
			return this.customControllers[num];
		}

		// Token: 0x06001CB7 RID: 7351 RVA: 0x0007AB8C File Offset: 0x00078D8C
		public int GetCustomControllerId(string name)
		{
			if (this.customControllers == null)
			{
				return -1;
			}
			int num = this.IndexOfCustomController(name);
			if (num < 0)
			{
				return -1;
			}
			return this.customControllers[num].id;
		}

		// Token: 0x06001CB8 RID: 7352 RVA: 0x0007ABC4 File Offset: 0x00078DC4
		public int IndexOfCustomController(int id)
		{
			if (this.customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				if (this.customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x0007AC08 File Offset: 0x00078E08
		public int IndexOfCustomController(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				if (this.customControllers[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CBA RID: 7354 RVA: 0x0007AC64 File Offset: 0x00078E64
		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (this.customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < this.customControllers.Count; i++)
			{
				if (this.customControllers[i].typeGuid == hardwareTypeGuid)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CBB RID: 7355 RVA: 0x0007ACB0 File Offset: 0x00078EB0
		public string GetCustomControllerNameById(int id)
		{
			if (this.customControllers != null)
			{
				for (int i = 0; i < this.customControllers.Count; i++)
				{
					if (this.customControllers[i].id == id)
					{
						return this.customControllers[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x00016CF8 File Offset: 0x00014EF8
		public void AddControllerMapLayoutManagerRuleSet()
		{
			this.controllerMapLayoutManagerRuleSets.Add(this.VNMBzLMRiSxlvydMpeyIYMOBIcaE());
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x00016D0B File Offset: 0x00014F0B
		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= this.controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.controllerMapLayoutManagerRuleSets.Insert(index, this.VNMBzLMRiSxlvydMpeyIYMOBIcaE());
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x0007AD08 File Offset: 0x00078F08
		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
			if (this.controllerMapLayoutManagerRuleSets == null || index < 0 || index >= this.controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.controllerMapLayoutManagerRuleSets[index].id;
			if (this.players != null)
			{
				for (int i = 0; i < this.players.Count; i++)
				{
					Player_Editor player_Editor = this.players[i];
					if (player_Editor != null)
					{
						List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
						if (ruleSets != null)
						{
							for (int j = ruleSets.Count - 1; j >= 0; j--)
							{
								if (ruleSets[j] != null && ruleSets[j].id == id)
								{
									ruleSets.RemoveAt(j);
								}
							}
						}
					}
				}
			}
			this.controllerMapLayoutManagerRuleSets.RemoveAt(index);
		}

		// Token: 0x06001CBF RID: 7359 RVA: 0x00016D3C File Offset: 0x00014F3C
		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<ControllerMapLayoutManager_RuleSet_Editor>(this.controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		// Token: 0x06001CC0 RID: 7360 RVA: 0x0007ADD0 File Offset: 0x00078FD0
		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (this.controllerMapLayoutManagerRuleSets == null || index < 0 || index >= this.controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = this.controllerMapLayoutManagerRuleSets[index].Clone();
			controllerMapLayoutManager_RuleSet_Editor.id = this.GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, this.GetControllerMapLayoutManagerRuleSetNames());
			if (index == this.controllerMapLayoutManagerRuleSets.Count - 1)
			{
				this.controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
				return;
			}
			this.controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
		}

		// Token: 0x06001CC1 RID: 7361 RVA: 0x0007AE64 File Offset: 0x00079064
		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (this.players != null)
			{
				for (int i = 0; i < this.players.Count; i++)
				{
					Player_Editor player_Editor = this.players[i];
					if (player_Editor != null)
					{
						List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
						if (ruleSets != null)
						{
							for (int j = ruleSets.Count - 1; j >= 0; j--)
							{
								if (ruleSets[j] != null && ruleSets[j].id == id)
								{
									num++;
								}
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06001CC2 RID: 7362 RVA: 0x0007AEF0 File Offset: 0x000790F0
		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < this.controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (this.controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CC3 RID: 7363 RVA: 0x0007AF34 File Offset: 0x00079134
		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[this.controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < this.controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = this.controllerMapLayoutManagerRuleSets[i].name;
			}
			return array;
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x0007AF88 File Offset: 0x00079188
		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[this.controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < this.controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = this.controllerMapLayoutManagerRuleSets[i].id;
			}
			return array;
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x00016D4C File Offset: 0x00014F4C
		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			if (this.controllerMapLayoutManagerRuleSets == null || index < 0 || index >= this.controllerMapLayoutManagerRuleSets.Count)
			{
				return null;
			}
			return this.controllerMapLayoutManagerRuleSets[index];
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x0007AFDC File Offset: 0x000791DC
		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = this.IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return this.controllerMapLayoutManagerRuleSets[num];
		}

		// Token: 0x06001CC7 RID: 7367 RVA: 0x0007B010 File Offset: 0x00079210
		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSetById(int id)
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = this.IndexOfControllerMapLayoutManagerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return this.controllerMapLayoutManagerRuleSets[num];
		}

		// Token: 0x06001CC8 RID: 7368 RVA: 0x0007B044 File Offset: 0x00079244
		public int GetControllerMapLayoutManagerRuleSetId(string name)
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			int num = this.IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return this.controllerMapLayoutManagerRuleSets[num].id;
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x0007B07C File Offset: 0x0007927C
		public int IndexOfControllerMapLayoutManagerRuleSet(int id)
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < this.controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (this.controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CCA RID: 7370 RVA: 0x0007B0C0 File Offset: 0x000792C0
		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < this.controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (this.controllerMapLayoutManagerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CCB RID: 7371 RVA: 0x0007B11C File Offset: 0x0007931C
		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (this.controllerMapLayoutManagerRuleSets != null)
			{
				for (int i = 0; i < this.controllerMapLayoutManagerRuleSets.Count; i++)
				{
					if (this.controllerMapLayoutManagerRuleSets[i].id == id)
					{
						return this.controllerMapLayoutManagerRuleSets[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001CCC RID: 7372 RVA: 0x00016D76 File Offset: 0x00014F76
		public int GetControllerMapLayoutManagerRuleSetCount()
		{
			if (this.controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			return this.controllerMapLayoutManagerRuleSets.Count;
		}

		// Token: 0x06001CCD RID: 7373 RVA: 0x00016D8D File Offset: 0x00014F8D
		public void AddControllerMapEnablerRuleSet()
		{
			this.controllerMapEnablerRuleSets.Add(this.OPgmbZJFToKrMDoDBIHEGSnNLEcN());
		}

		// Token: 0x06001CCE RID: 7374 RVA: 0x00016DA0 File Offset: 0x00014FA0
		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= this.controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.controllerMapEnablerRuleSets.Insert(index, this.OPgmbZJFToKrMDoDBIHEGSnNLEcN());
		}

		// Token: 0x06001CCF RID: 7375 RVA: 0x0007B174 File Offset: 0x00079374
		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (this.controllerMapEnablerRuleSets == null || index < 0 || index >= this.controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = this.controllerMapEnablerRuleSets[index].id;
			if (this.players != null)
			{
				for (int i = 0; i < this.players.Count; i++)
				{
					Player_Editor player_Editor = this.players[i];
					if (player_Editor != null)
					{
						List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
						if (ruleSets != null)
						{
							for (int j = ruleSets.Count - 1; j >= 0; j--)
							{
								if (ruleSets[j] != null && ruleSets[j].id == id)
								{
									ruleSets.RemoveAt(j);
								}
							}
						}
					}
				}
			}
			this.controllerMapEnablerRuleSets.RemoveAt(index);
		}

		// Token: 0x06001CD0 RID: 7376 RVA: 0x00016DD1 File Offset: 0x00014FD1
		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex<ControllerMapEnabler_RuleSet_Editor>(this.controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		// Token: 0x06001CD1 RID: 7377 RVA: 0x0007B23C File Offset: 0x0007943C
		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (this.controllerMapEnablerRuleSets == null || index < 0 || index >= this.controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = this.controllerMapEnablerRuleSets[index].Clone();
			controllerMapEnabler_RuleSet_Editor.id = this.GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, this.GetControllerMapEnablerRuleSetNames());
			if (index == this.controllerMapEnablerRuleSets.Count - 1)
			{
				this.controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
				return;
			}
			this.controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
		}

		// Token: 0x06001CD2 RID: 7378 RVA: 0x0007B2D0 File Offset: 0x000794D0
		public int GetControllerMapEnablerRuleSetUsedCount(int id)
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (this.players != null)
			{
				for (int i = 0; i < this.players.Count; i++)
				{
					Player_Editor player_Editor = this.players[i];
					if (player_Editor != null)
					{
						List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
						if (ruleSets != null)
						{
							for (int j = ruleSets.Count - 1; j >= 0; j--)
							{
								if (ruleSets[j] != null && ruleSets[j].id == id)
								{
									num++;
								}
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06001CD3 RID: 7379 RVA: 0x0007B35C File Offset: 0x0007955C
		public int GetControllerMapEnablerRuleSetIndex(int id)
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < this.controllerMapEnablerRuleSets.Count; i++)
			{
				if (this.controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CD4 RID: 7380 RVA: 0x0007B3A0 File Offset: 0x000795A0
		public string[] GetControllerMapEnablerRuleSetNames()
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[this.controllerMapEnablerRuleSets.Count];
			for (int i = 0; i < this.controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = this.controllerMapEnablerRuleSets[i].name;
			}
			return array;
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x0007B3F4 File Offset: 0x000795F4
		public int[] GetControllerMapEnablerRuleSetIds()
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[this.controllerMapEnablerRuleSets.Count];
			for (int i = 0; i < this.controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = this.controllerMapEnablerRuleSets[i].id;
			}
			return array;
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x00016DE1 File Offset: 0x00014FE1
		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
		{
			if (this.controllerMapEnablerRuleSets == null || index < 0 || index >= this.controllerMapEnablerRuleSets.Count)
			{
				return null;
			}
			return this.controllerMapEnablerRuleSets[index];
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x0007B448 File Offset: 0x00079648
		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(string name)
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = this.IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return this.controllerMapEnablerRuleSets[num];
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x0007B47C File Offset: 0x0007967C
		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSetById(int id)
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = this.IndexOfControllerMapEnablerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return this.controllerMapEnablerRuleSets[num];
		}

		// Token: 0x06001CD9 RID: 7385 RVA: 0x0007B4B0 File Offset: 0x000796B0
		public int GetControllerMapEnablerRuleSetId(string name)
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			int num = this.IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return this.controllerMapEnablerRuleSets[num].id;
		}

		// Token: 0x06001CDA RID: 7386 RVA: 0x0007B4E8 File Offset: 0x000796E8
		public int IndexOfControllerMapEnablerRuleSet(int id)
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < this.controllerMapEnablerRuleSets.Count; i++)
			{
				if (this.controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CDB RID: 7387 RVA: 0x0007B52C File Offset: 0x0007972C
		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (this.controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < this.controllerMapEnablerRuleSets.Count; i++)
			{
				if (this.controllerMapEnablerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001CDC RID: 7388 RVA: 0x0007B588 File Offset: 0x00079788
		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (this.controllerMapEnablerRuleSets != null)
			{
				for (int i = 0; i < this.controllerMapEnablerRuleSets.Count; i++)
				{
					if (this.controllerMapEnablerRuleSets[i].id == id)
					{
						return this.controllerMapEnablerRuleSets[i].name;
					}
				}
			}
			return "Unknown";
		}

		// Token: 0x06001CDD RID: 7389 RVA: 0x00016E0B File Offset: 0x0001500B
		public int GetControllerMapEnablerRuleSetCount()
		{
			if (this.controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			return this.controllerMapEnablerRuleSets.Count;
		}

		// Token: 0x06001CDE RID: 7390 RVA: 0x00016E22 File Offset: 0x00015022
		public int GetNewPlayerId()
		{
			int result = this.playerIdCounter;
			this.playerIdCounter++;
			return result;
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x00016E38 File Offset: 0x00015038
		public int GetNewActionId()
		{
			int result = this.actionIdCounter;
			this.actionIdCounter++;
			return result;
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x00016E4E File Offset: 0x0001504E
		public int GetNewActionCategoryId()
		{
			int result = this.actionCategoryIdCounter;
			this.actionCategoryIdCounter++;
			return result;
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x00016E64 File Offset: 0x00015064
		public int GetNewInputBehaviorId()
		{
			int result = this.inputBehaviorIdCounter;
			this.inputBehaviorIdCounter++;
			return result;
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x00016E7A File Offset: 0x0001507A
		public int GetNewMapCategoryId()
		{
			int result = this.mapCategoryIdCounter;
			this.mapCategoryIdCounter++;
			return result;
		}

		// Token: 0x06001CE3 RID: 7395 RVA: 0x00016E90 File Offset: 0x00015090
		public int GetNewJoystickLayoutId()
		{
			int result = this.joystickLayoutIdCounter;
			this.joystickLayoutIdCounter++;
			return result;
		}

		// Token: 0x06001CE4 RID: 7396 RVA: 0x00016EA6 File Offset: 0x000150A6
		public int GetNewKeyboardLayoutId()
		{
			int result = this.keyboardLayoutIdCounter;
			this.keyboardLayoutIdCounter++;
			return result;
		}

		// Token: 0x06001CE5 RID: 7397 RVA: 0x00016EBC File Offset: 0x000150BC
		public int GetNewMouseLayoutId()
		{
			int result = this.mouseLayoutIdCounter;
			this.mouseLayoutIdCounter++;
			return result;
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x00016ED2 File Offset: 0x000150D2
		public int GetNewCustomControllerLayoutId()
		{
			int result = this.customControllerLayoutIdCounter;
			this.customControllerLayoutIdCounter++;
			return result;
		}

		// Token: 0x06001CE7 RID: 7399 RVA: 0x00016EE8 File Offset: 0x000150E8
		public int GetNewJoystickMapId()
		{
			int result = this.joystickMapIdCounter;
			this.joystickMapIdCounter++;
			return result;
		}

		// Token: 0x06001CE8 RID: 7400 RVA: 0x00016EFE File Offset: 0x000150FE
		public int GetNewKeyboardMapId()
		{
			int result = this.keyboardMapIdCounter;
			this.keyboardMapIdCounter++;
			return result;
		}

		// Token: 0x06001CE9 RID: 7401 RVA: 0x00016F14 File Offset: 0x00015114
		public int GetNewMouseMapId()
		{
			int result = this.mouseMapIdCounter;
			this.mouseMapIdCounter++;
			return result;
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x00016F2A File Offset: 0x0001512A
		public int GetNewCustomControllerMapId()
		{
			int result = this.customControllerMapIdCounter;
			this.customControllerMapIdCounter++;
			return result;
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x00016F40 File Offset: 0x00015140
		public int GetNewCustomControllerId()
		{
			int result = this.customControllerIdCounter;
			this.customControllerIdCounter++;
			return result;
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x00016F56 File Offset: 0x00015156
		public int GetNewControllerMapLayoutManagerRuleSetId()
		{
			int result = this.controllerMapLayoutManagerSetIdCounter;
			this.controllerMapLayoutManagerSetIdCounter++;
			return result;
		}

		// Token: 0x06001CED RID: 7405 RVA: 0x00016F6C File Offset: 0x0001516C
		public int GetNewControllerMapEnablerRuleSetId()
		{
			int result = this.controllerMapEnablerSetIdCounter;
			this.controllerMapEnablerSetIdCounter++;
			return result;
		}

		// Token: 0x06001CEE RID: 7406 RVA: 0x0007B5E0 File Offset: 0x000797E0
		private Player_Editor yPRZKssPqDeUwuAtRJKGzjVKDvkp()
		{
			Player_Editor player_Editor = new Player_Editor();
			player_Editor.id = this.GetNewPlayerId();
			player_Editor.name = StringTools.IterateName("Player", -1, this.GetPlayerNames());
			player_Editor.descriptiveName = player_Editor.name;
			player_Editor.startPlaying = true;
			if (this.players.Count == 1)
			{
				player_Editor.assignMouseOnStart = true;
			}
			player_Editor.assignKeyboardOnStart = true;
			player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
			player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
			return player_Editor;
		}

		// Token: 0x06001CEF RID: 7407 RVA: 0x0007B65C File Offset: 0x0007985C
		private InputAction ZXqVqSuoFvcyDFWrUwuaFHhOWmGs()
		{
			InputAction inputAction = new InputAction();
			inputAction.id = this.GetNewActionId();
			inputAction.name = StringTools.IterateName("Action", -1, this.GetActionNames());
			inputAction.descriptiveName = inputAction.name;
			inputAction.type = InputActionType.Button;
			inputAction.userAssignable = true;
			inputAction.behaviorId = 0;
			return inputAction;
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x00016F82 File Offset: 0x00015182
		private InputActionCategory GqOmrHifijEubAupchCVroXwLwhBA()
		{
			InputActionCategory inputActionCategory = new InputActionCategory();
			inputActionCategory.id = this.GetNewActionCategoryId();
			inputActionCategory.name = StringTools.IterateName("Category", -1, this.GetActionCategoryNames());
			inputActionCategory.descriptiveName = inputActionCategory.name;
			inputActionCategory.userAssignable = true;
			return inputActionCategory;
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x0007B6B4 File Offset: 0x000798B4
		private InputBehavior xZZbOdTeGsNGPPvlkgHnWHBvcRfc()
		{
			return new InputBehavior
			{
				id = this.GetNewInputBehaviorId(),
				name = StringTools.IterateName("Behavior", -1, this.GetInputBehaviorNames()),
				digitalAxisSimulation = true,
				digitalAxisSnap = true,
				digitalAxisInstantReverse = false,
				digitalAxisGravity = 3f,
				digitalAxisSensitivity = 3f,
				mouseXYAxisMode = MouseXYAxisMode.MouseAxis,
				mouseXYAxisSensitivity = 1f,
				mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis,
				mouseOtherAxisSensitivity = 1f,
				buttonDoublePressSpeed = 0.3f,
				buttonShortPressTime = 0.25f,
				buttonShortPressExpiresIn = 0f,
				buttonLongPressTime = 1f,
				buttonLongPressExpiresIn = 0f,
				buttonDeadZone = 0.5f,
				buttonDownBuffer = 0f
			};
		}

		// Token: 0x06001CF2 RID: 7410 RVA: 0x0007B788 File Offset: 0x00079988
		private InputMapCategory weJbOFdsvSlGThupLPBYbYatWLUsA()
		{
			InputMapCategory inputMapCategory = new InputMapCategory();
			inputMapCategory.id = this.GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName("Category", -1, this.GetMapCategoryNames());
			inputMapCategory.descriptiveName = inputMapCategory.name;
			inputMapCategory.userAssignable = true;
			inputMapCategory.checkConflictsWithAllCategories = true;
			return inputMapCategory;
		}

		// Token: 0x06001CF3 RID: 7411 RVA: 0x00016FBF File Offset: 0x000151BF
		private InputLayout UzsasJHPOmtEgydFpECcquRKBTxx()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = this.GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, this.GetJoystickLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x00016FF5 File Offset: 0x000151F5
		private InputLayout VFkkqgNKTjmyUlirolEmKgINfsKl()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = this.GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, this.GetKeyboardLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x0001702B File Offset: 0x0001522B
		private InputLayout rHgbaFObSllvOgMLVeAGEbqMrFRl()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = this.GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, this.GetMouseLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		// Token: 0x06001CF6 RID: 7414 RVA: 0x00017061 File Offset: 0x00015261
		private InputLayout ntbjGshTcgULOYcQVBbXKyliIfsi()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = this.GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, this.GetCustomControllerLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x00017097 File Offset: 0x00015297
		private CustomController_Editor yAuqGyDcJYlNVmkCUKnXnOwkZhJt(Guid A_1)
		{
			CustomController_Editor customController_Editor = new CustomController_Editor();
			customController_Editor.id = this.GetNewCustomControllerId();
			customController_Editor.typeGuid = A_1;
			customController_Editor.name = StringTools.IterateName("CustomController", -1, this.GetCustomControllerNames());
			customController_Editor.descriptiveName = customController_Editor.name;
			return customController_Editor;
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x000170D4 File Offset: 0x000152D4
		private ControllerMapLayoutManager_RuleSet_Editor VNMBzLMRiSxlvydMpeyIYMOBIcaE()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = this.GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, this.GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x000170FE File Offset: 0x000152FE
		private ControllerMapEnabler_RuleSet_Editor OPgmbZJFToKrMDoDBIHEGSnNLEcN()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = this.GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, this.GetControllerMapEnablerRuleSetNames())
			};
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x0007B7D8 File Offset: 0x000799D8
		private ControllerMap_Editor weIBcyWfDVecPQralusnpNEGeQVv(List<ControllerMap_Editor> A_1, int A_2, int A_3)
		{
			if (A_1 == null)
			{
				return null;
			}
			for (int i = 0; i < A_1.Count; i++)
			{
				if (A_1[i].categoryId == A_2 && A_1[i].layoutId == A_3)
				{
					return A_1[i];
				}
			}
			return null;
		}

		// Token: 0x06001CFB RID: 7419 RVA: 0x0007B824 File Offset: 0x00079A24
		private ControllerMap_Editor btuQjOrCAMGjMbwzOQFisbjOKWkv(List<ControllerMap_Editor> A_1, List<InputLayout> A_2, int A_3, int A_4, bool A_5)
		{
			ControllerMap_Editor controllerMap_Editor = this.weIBcyWfDVecPQralusnpNEGeQVv(A_1, A_3, A_4);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (A_5)
			{
				controllerMap_Editor = this.OtYntDSGoAQgjOruMzwAFFwPuvSF(A_1, A_2, A_3, A_4);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x0007B858 File Offset: 0x00079A58
		private ControllerMap_Editor OtYntDSGoAQgjOruMzwAFFwPuvSF(List<ControllerMap_Editor> A_1, List<InputLayout> A_2, int A_3, int A_4)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy<ControllerMap_Editor>(A_1);
			if (list != null && list.Count > 0)
			{
				this.kVSWOtdcolCfxiviJkiDSDTxzClRA(list, A_2);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == A_3)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x0007B8D0 File Offset: 0x00079AD0
		private void kVSWOtdcolCfxiviJkiDSDTxzClRA(List<ControllerMap_Editor> A_1, List<InputLayout> A_2)
		{
			UserData.wMGmJUEQwtZiBsCPMhzIqdbaCrax wMGmJUEQwtZiBsCPMhzIqdbaCrax = new UserData.wMGmJUEQwtZiBsCPMhzIqdbaCrax();
			wMGmJUEQwtZiBsCPMhzIqdbaCrax.dIXEcscVNoRLWUgEeKfMgLTNgjHdA = A_2;
			if (A_1 == null || wMGmJUEQwtZiBsCPMhzIqdbaCrax.dIXEcscVNoRLWUgEeKfMgLTNgjHdA == null)
			{
				return;
			}
			A_1.Sort(new Comparison<ControllerMap_Editor>(wMGmJUEQwtZiBsCPMhzIqdbaCrax.ZyvqeTHRpufZKCZPaSVpfAjPvGVK));
		}

		// Token: 0x06001CFE RID: 7422 RVA: 0x0007B908 File Offset: 0x00079B08
		internal void yDABbxiARLBWAQcRokAdOcDrDbkT()
		{
			if (this.mKsMXHkUtCoHdBjsYfJsiKTPPGPhA)
			{
				return;
			}
			this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc = new List<InputAction>(this.actions.Count);
			for (int i = 0; i < this.actions.Count; i++)
			{
				if (this.actions[i] == null)
				{
					this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc.Add(null);
				}
				this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc.Add(new InputAction(this.actions[i]));
			}
			this.VnvGwsIqlyaVDfkMStriDwUKMMSo = new ReadOnlyCollection<Player_Editor>(this.players);
			this.ABGnUJfDDpBzJwpBkZvuZruVRScv = new ReadOnlyCollection<InputAction>(this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc);
			List<InputCategory> list = new List<InputCategory>((this.actionCategories != null) ? this.actionCategories.Count : 0);
			for (int j = 0; j < this.actionCategories.Count; j++)
			{
				list.Add(this.actionCategories[j]);
			}
			this.OQXvniYgjUwHSWNCrZGsvanndody = new ReadOnlyCollection<InputCategory>(list);
			this.RkfefHOeXDEiuaVzhNeqQtLHptfo = new ReadOnlyCollection<InputBehavior>(this.inputBehaviors);
			this.bxNZYrWGGMsIWHSTVpBBMkfCoErr = new ReadOnlyCollection<InputMapCategory>(this.mapCategories);
			this.lSnlmZCSxIICafYigEGAImxRqCRR = new ReadOnlyCollection<InputLayout>(this.joystickLayouts);
			this.BWSaWZIHkKTOXkZcdjAAcdnzEgaE = new ReadOnlyCollection<InputLayout>(this.keyboardLayouts);
			this.SdCANdbcefclZebIeWSLcZPhwnOsB = new ReadOnlyCollection<InputLayout>(this.mouseLayouts);
			this.VxLXMOySfYDSDZxBhqiycXFHroCP = new ReadOnlyCollection<InputLayout>(this.customControllerLayouts);
			this.IPiZMelTrFRBUmAmHEIvqucMhSCcA = new ReadOnlyCollection<ControllerMap_Editor>(this.joystickMaps);
			this.ypfhfSbMjUsvGKIgbZemmyPtNhQO = new ReadOnlyCollection<ControllerMap_Editor>(this.keyboardMaps);
			this.BeRffImSXfDrXAvQlOSViTVipwSgA = new ReadOnlyCollection<ControllerMap_Editor>(this.mouseMaps);
			this.HtFQzBpopGAkoEwbjmAQkKBdWbDC = new ReadOnlyCollection<ControllerMap_Editor>(this.customControllerMaps);
			this.fVrapIKnuSkvchYYsZcetaRbFSXQA = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(this.controllerMapLayoutManagerRuleSets);
			this.MIyBVditogETVMtHmOypqitNKHUf = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(this.controllerMapEnablerRuleSets);
			if (this.mapCategories != null)
			{
				for (int k = 0; k < this.mapCategories.Count; k++)
				{
					if (this.mapCategories[k] != null)
					{
						this.mapCategories[k].AdhUFRQHbIPQhLkhPNdOptnZYpLD();
					}
				}
			}
			if (this.actionCategories != null)
			{
				for (int l = 0; l < this.actionCategories.Count; l++)
				{
					if (this.actionCategories[l] != null)
					{
						this.actionCategories[l].AdhUFRQHbIPQhLkhPNdOptnZYpLD();
					}
				}
			}
			if (this.joystickLayouts != null)
			{
				for (int m = 0; m < this.joystickLayouts.Count; m++)
				{
					if (this.joystickLayouts[m] != null)
					{
						this.joystickLayouts[m].umDdRyEUMxfHzRybWFTiBUrgIhMvB();
					}
				}
			}
			if (this.keyboardLayouts != null)
			{
				for (int n = 0; n < this.keyboardLayouts.Count; n++)
				{
					if (this.keyboardLayouts[n] != null)
					{
						this.keyboardLayouts[n].umDdRyEUMxfHzRybWFTiBUrgIhMvB();
					}
				}
			}
			if (this.mouseLayouts != null)
			{
				for (int num = 0; num < this.mouseLayouts.Count; num++)
				{
					if (this.mouseLayouts[num] != null)
					{
						this.mouseLayouts[num].umDdRyEUMxfHzRybWFTiBUrgIhMvB();
					}
				}
			}
			if (this.customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < this.customControllerLayouts.Count; num2++)
				{
					if (this.customControllerLayouts[num2] != null)
					{
						this.customControllerLayouts[num2].umDdRyEUMxfHzRybWFTiBUrgIhMvB();
					}
				}
			}
			if (this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc != null)
			{
				for (int num3 = 0; num3 < this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc.Count; num3++)
				{
					if (this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc[num3] != null)
					{
						this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc[num3].CuUuzvRCcKAFhTQQigkFvHPLJMWU();
					}
				}
			}
			this.containsActionDelegate = new Func<int, bool>(this.ContainsAction);
			this.mKsMXHkUtCoHdBjsYfJsiKTPPGPhA = true;
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x0007BCA8 File Offset: 0x00079EA8
		internal void FIFEvFFnromSBQiDTiqGJpwLINNyA()
		{
			if (!this.mKsMXHkUtCoHdBjsYfJsiKTPPGPhA)
			{
				return;
			}
			if (this.mapCategories != null)
			{
				for (int i = 0; i < this.mapCategories.Count; i++)
				{
					if (this.mapCategories[i] != null)
					{
						this.mapCategories[i].kfObqanLScTcVFWnrgBWhuUanFgD();
					}
				}
			}
			if (this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc != null)
			{
				for (int j = 0; j < this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc.Count; j++)
				{
					if (this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc[j] != null)
					{
						this.kAYZsJDXzRxZCEhMSxQTeEYgTDYc[j].bKsApSvdbqUpgWhodCohplcAbcFeA();
					}
				}
			}
			this.mKsMXHkUtCoHdBjsYfJsiKTPPGPhA = false;
		}

		// Token: 0x06001D00 RID: 7424 RVA: 0x00017128 File Offset: 0x00015328
		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.XLpvTbCSZKWmHPpPvEayiBHtOVViA(orig, other, preserveOrigIds);
		}

		// Token: 0x06001D01 RID: 7425 RVA: 0x00017132 File Offset: 0x00015332
		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.XLpvTbCSZKWmHPpPvEayiBHtOVViA(orig, null, false);
		}

		// Token: 0x04000FBC RID: 4028
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars = new ConfigVars();

		// Token: 0x04000FBD RID: 4029
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor> players = new List<Player_Editor>();

		// Token: 0x04000FBE RID: 4030
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputAction> actions = new List<InputAction>();

		// Token: 0x04000FBF RID: 4031
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputActionCategory> actionCategories = new List<InputActionCategory>();

		// Token: 0x04000FC0 RID: 4032
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		// Token: 0x04000FC1 RID: 4033
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		// Token: 0x04000FC2 RID: 4034
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		// Token: 0x04000FC3 RID: 4035
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		// Token: 0x04000FC4 RID: 4036
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		// Token: 0x04000FC5 RID: 4037
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		// Token: 0x04000FC6 RID: 4038
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		// Token: 0x04000FC7 RID: 4039
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		// Token: 0x04000FC8 RID: 4040
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		// Token: 0x04000FC9 RID: 4041
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		// Token: 0x04000FCA RID: 4042
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		// Token: 0x04000FCB RID: 4043
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		// Token: 0x04000FCC RID: 4044
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		// Token: 0x04000FCD RID: 4045
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		// Token: 0x04000FCE RID: 4046
		[NonSerialized]
		private List<InputAction> kAYZsJDXzRxZCEhMSxQTeEYgTDYc;

		// Token: 0x04000FCF RID: 4047
		[NonSerialized]
		private bool mKsMXHkUtCoHdBjsYfJsiKTPPGPhA;

		// Token: 0x04000FDF RID: 4063
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int playerIdCounter;

		// Token: 0x04000FE0 RID: 4064
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionIdCounter;

		// Token: 0x04000FE1 RID: 4065
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionCategoryIdCounter;

		// Token: 0x04000FE2 RID: 4066
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int inputBehaviorIdCounter;

		// Token: 0x04000FE3 RID: 4067
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mapCategoryIdCounter;

		// Token: 0x04000FE4 RID: 4068
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickLayoutIdCounter;

		// Token: 0x04000FE5 RID: 4069
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardLayoutIdCounter;

		// Token: 0x04000FE6 RID: 4070
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseLayoutIdCounter;

		// Token: 0x04000FE7 RID: 4071
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerLayoutIdCounter;

		// Token: 0x04000FE8 RID: 4072
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickMapIdCounter;

		// Token: 0x04000FE9 RID: 4073
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardMapIdCounter;

		// Token: 0x04000FEA RID: 4074
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseMapIdCounter;

		// Token: 0x04000FEB RID: 4075
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerMapIdCounter;

		// Token: 0x04000FEC RID: 4076
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerIdCounter;

		// Token: 0x04000FED RID: 4077
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapLayoutManagerSetIdCounter;

		// Token: 0x04000FEE RID: 4078
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapEnablerSetIdCounter;

		// Token: 0x04000FEF RID: 4079
		private Func<int, bool> containsActionDelegate;

		// Token: 0x0200025F RID: 607
		private static class PNzhXEZBquWTWutuvqUzeSAXzfsF
		{
			// Token: 0x06001D02 RID: 7426 RVA: 0x0007BD40 File Offset: 0x00079F40
			public static UserData XLpvTbCSZKWmHPpPvEayiBHtOVViA(UserData A_0, UserData A_1, bool A_2)
			{
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA rHCmKvaRAfqsRlJBihaSKpaTMOsmA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA();
				if (A_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				A_0 = JsonTools.Clone<UserData>(A_0);
				A_1 = ((A_1 != null) ? JsonTools.Clone<UserData>(A_1) : null);
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb = (A_2 ? A_0 : new UserData(false));
				if (A_1 != null)
				{
					rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.configVars = JsonTools.Clone<ConfigVars>(A_1.configVars);
				}
				else
				{
					rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.configVars = JsonTools.Clone<ConfigVars>(A_0.configVars);
				}
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.xPXJJfgbXluybZaZVCLcPOWlEtcIA = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputActionCategory>("Action Category", A_0.actionCategories, (A_1 != null) ? A_1.actionCategories : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.actionCategories, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.xPXJJfgbXluybZaZVCLcPOWlEtcIA, new Func<InputActionCategory, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.hQNNFQeCzNITRyfEEUamWGfySrEg), new Func<InputActionCategory, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.GTSevdTlzUWqUJNPlxPDBSOGzdSh), new Func<InputActionCategory, IList<InputActionCategory>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.rNRkrYGmWbIXfSeTlPZHHRutEUAn), new Func<UserData<InputActionCategory>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputActionCategory>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.sXvQeHPkylONqXKxsnAYvItbQggn));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.FLNdjYqHZZxHrTujPRIonxZNtWgw = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputBehavior>("Input Behavior", A_0.inputBehaviors, (A_1 != null) ? A_1.inputBehaviors : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.inputBehaviors, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.FLNdjYqHZZxHrTujPRIonxZNtWgw, new Func<InputBehavior, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.npjlTIKdrbYviYbprFZmdHJKvqMvA), new Func<InputBehavior, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.LRyVsNuGKfrYGDubIhFCYELleINH), new Func<InputBehavior, IList<InputBehavior>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.GlYsGCKGuVxSfNiZqyBQJjSfptmI), new Func<UserData<InputBehavior>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputBehavior>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.cCinBYsOJEIbKCgTQfGTDqlKfXRaB));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.AvDryzYVKEtVoBauEwNaHBOpVGoC = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputAction>("Action", A_0.aTRZoPUHOHBERSaHiQchUzNPWDGT, (A_1 != null) ? A_1.aTRZoPUHOHBERSaHiQchUzNPWDGT : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.aTRZoPUHOHBERSaHiQchUzNPWDGT, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.AvDryzYVKEtVoBauEwNaHBOpVGoC, new Func<InputAction, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.muxLRVepwjNqPKGUDvTnqseXUCHl), new Func<InputAction, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.TMcmsYVBGafuCuLAkSGRMhmCpxpG), new Func<InputAction, IList<InputAction>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.KTtgWmOfCTklwyrjKsKRvGFWJpdH), new Func<UserData<InputAction>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputAction>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.ZeVwCOflQoVspdESLPPyMalOLphJ));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.cfrdVEihCYaDpfghHudHhHHCmGcKd = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.VjbgGAgjKArvEAYbZCYIqicKbEZf vjbgGAgjKArvEAYbZCYIqicKbEZf = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.VjbgGAgjKArvEAYbZCYIqicKbEZf();
				vjbgGAgjKArvEAYbZCYIqicKbEZf.FSsNgoVWfNnuhXnsNOmSypRdqpMd = rHCmKvaRAfqsRlJBihaSKpaTMOsmA;
				vjbgGAgjKArvEAYbZCYIqicKbEZf.GvHDdQvoBdOqXMitsHvnfMFkbDZeA = new List<int>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputMapCategory>("Map Category", A_0.mapCategories, (A_1 != null) ? A_1.mapCategories : null, vjbgGAgjKArvEAYbZCYIqicKbEZf.FSsNgoVWfNnuhXnsNOmSypRdqpMd.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.mapCategories, A_2, vjbgGAgjKArvEAYbZCYIqicKbEZf.FSsNgoVWfNnuhXnsNOmSypRdqpMd.cfrdVEihCYaDpfghHudHhHHCmGcKd, new Func<InputMapCategory, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.vjVrlsgWYRIbdYYDoTquZokQpJXv), new Func<InputMapCategory, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.rogApVZfZGqqXvwhFyPOShebEyZd), new Func<InputMapCategory, IList<InputMapCategory>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.eeiffXnvdxDVdcnTbkbFYqKEZoYW), new Func<UserData<InputMapCategory>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputMapCategory>(vjbgGAgjKArvEAYbZCYIqicKbEZf.rbQQNEaThoHWvoHaDgIRbGkAUHIS));
				for (int i = 0; i < vjbgGAgjKArvEAYbZCYIqicKbEZf.GvHDdQvoBdOqXMitsHvnfMFkbDZeA.Count; i++)
				{
					int index = vjbgGAgjKArvEAYbZCYIqicKbEZf.GvHDdQvoBdOqXMitsHvnfMFkbDZeA[i];
					InputMapCategory inputMapCategory = vjbgGAgjKArvEAYbZCYIqicKbEZf.FSsNgoVWfNnuhXnsNOmSypRdqpMd.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.mapCategories[index];
					for (int j = 0; j < inputMapCategory.ORYHklPObneiXhTAKBFvplSmwmTbA.Count; j++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.kOBvWvxhrTJxKgpCtOwmckTgeYpB kOBvWvxhrTJxKgpCtOwmckTgeYpB = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.kOBvWvxhrTJxKgpCtOwmckTgeYpB();
						kOBvWvxhrTJxKgpCtOwmckTgeYpB.CrXJBbSzGyjdMqVIDuIhVeZOMGUW = inputMapCategory.ORYHklPObneiXhTAKBFvplSmwmTbA[j];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = vjbgGAgjKArvEAYbZCYIqicKbEZf.FSsNgoVWfNnuhXnsNOmSypRdqpMd.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(kOBvWvxhrTJxKgpCtOwmckTgeYpB.hCYIHpVyzIERTSmfcRqDTXKlKuVr));
						inputMapCategory.ORYHklPObneiXhTAKBFvplSmwmTbA[j] = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					}
				}
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.KXzABAdDSsYrclZcfwrnFvyQMDRhb = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputLayout>("Keyboard Layout", A_0.keyboardLayouts, (A_1 != null) ? A_1.keyboardLayouts : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.keyboardLayouts, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.KXzABAdDSsYrclZcfwrnFvyQMDRhb, new Func<InputLayout, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.KNZBLTIRorXzNsEgGoZRAHdkQafFc), new Func<InputLayout, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.UVDriuBsGoAPyApayIFGJQfAazRuA), new Func<InputLayout, IList<InputLayout>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.FkPPhbVSHizIiWhQRrJvYmVfzCpT), new Func<UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputLayout>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.kvPtpQtpVWAPQccKocTwfdcoalcLA));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.fpzXioQXJgTWCZuxfiXwpaesvytT = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputLayout>("Mouse Layout", A_0.mouseLayouts, (A_1 != null) ? A_1.mouseLayouts : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.mouseLayouts, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.fpzXioQXJgTWCZuxfiXwpaesvytT, new Func<InputLayout, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.apqJGJGXLlmLHGDWYiiUCkPkIeXi), new Func<InputLayout, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.yNREqIIpyUdAFzowfBlCtgImnexR), new Func<InputLayout, IList<InputLayout>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.KyeseojbEbxOwbHsNtVLOqqudyMhA), new Func<UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputLayout>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.KxgWjSDPsZAOdXMXNKGzktsuvxWA));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.xPXJDvyuOAVhkIFtAVWkQGbWMuZB = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputLayout>("Joystick Layout", A_0.joystickLayouts, (A_1 != null) ? A_1.joystickLayouts : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.joystickLayouts, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.xPXJDvyuOAVhkIFtAVWkQGbWMuZB, new Func<InputLayout, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.zUuzItszQBBYbvHxplkleQMPHjvi), new Func<InputLayout, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.jVSCIfdqNoQNxnOVcDLypmMyAOcXA), new Func<InputLayout, IList<InputLayout>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.WMjROKoTOJacrqsDlSAelYhxSTHO), new Func<UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputLayout>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.OXAAMOONDzxPLaADTuTpTexrDESiA));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.LFnmVkbqYubizvCjyClfkZkHXoCc = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<InputLayout>("Custom Controller Layout", A_0.customControllerLayouts, (A_1 != null) ? A_1.customControllerLayouts : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.customControllerLayouts, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.LFnmVkbqYubizvCjyClfkZkHXoCc, new Func<InputLayout, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.PwNGBqmxkjtlBhQZoVTaidVHiZTe), new Func<InputLayout, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.rZYFQbjPQHnorhKpNBakxgKMuMfPA), new Func<InputLayout, IList<InputLayout>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.pOlAJxBfpzowHXecpcbsVTGgniteb), new Func<UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, InputLayout>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.sZLGfGoKHKpGVJOabdcgFHHdMfedA));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.UgzUaROLwkHbdnVLRcUzhMUmtCWo = new Func<ControllerType, List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.sCWiPaSHfLVClZeyRxhZKznatmLD);
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.TvPCaQWeioXSUByvUkUibabLcwst = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<CustomController_Editor>("Custom Controller", A_0.customControllers, (A_1 != null) ? A_1.customControllers : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.customControllers, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.TvPCaQWeioXSUByvUkUibabLcwst, new Func<CustomController_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.zsOLkREzhlHUJRiyJRNwhoAjicwJA), new Func<CustomController_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.gnAFhnAggAwTRfxyCpzXLmMKUZDn), new Func<CustomController_Editor, IList<CustomController_Editor>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.fDsBgknktLJqrAjrKxKqzhtUDsNjA), new Func<UserData<CustomController_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, CustomController_Editor>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.oYdeqtvKbRtdhOCPtbScgLiCEQHL));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.nhYmGnVzotCjmkNpPHgusikZWUEB = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<ControllerMapLayoutManager_RuleSet_Editor>("Layout Manager Set", A_0.controllerMapLayoutManagerRuleSets, (A_1 != null) ? A_1.controllerMapLayoutManagerRuleSets : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.controllerMapLayoutManagerRuleSets, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.nhYmGnVzotCjmkNpPHgusikZWUEB, new Func<ControllerMapLayoutManager_RuleSet_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.YyLCbjRqsOlkjkbYSPLvPVVKnVrE), new Func<ControllerMapLayoutManager_RuleSet_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.qmJZxLXQNoMzALMlkOyiUZCjOOQR), new Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.IPQGTwAZkjygUgISlKXevwsHbaYNA), new Func<UserData<ControllerMapLayoutManager_RuleSet_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, ControllerMapLayoutManager_RuleSet_Editor>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.iTJpmUjsQMwPqoyarbgtcZlRSZlv));
				rHCmKvaRAfqsRlJBihaSKpaTMOsmA.PcTijjdXuFafHjICIAeDYskzwnvGb = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<ControllerMapEnabler_RuleSet_Editor>("Controller Map Enabler Set", A_0.controllerMapEnablerRuleSets, (A_1 != null) ? A_1.controllerMapEnablerRuleSets : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.controllerMapEnablerRuleSets, A_2, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.PcTijjdXuFafHjICIAeDYskzwnvGb, new Func<ControllerMapEnabler_RuleSet_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.BUMOAnveuVLyDVEXRgAoMOYPPNrV), new Func<ControllerMapEnabler_RuleSet_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.zZcvfuglxwMLFByUkKzLIoKtOUnG), new Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.eoHAIAFCcDoLWBCyJtqIFApYIgsob), new Func<UserData<ControllerMapEnabler_RuleSet_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, ControllerMapEnabler_RuleSet_Editor>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.UFYWxkvgLAUVwOfjeyZURkQmqoSx));
				List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<Player_Editor>("Player", A_0.players, (A_1 != null) ? A_1.players : null, rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.players, A_2, list, new Func<Player_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.wEgWmZvvypgOknsaxVZqfWPCasNC), new Func<Player_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.IFzVssqvNCtlOoxtbyBlpqpTOlti), new Func<Player_Editor, IList<Player_Editor>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.XuAFqUTXcQwsaKKmtjAZOoKbLIbT), new Func<UserData<Player_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, Player_Editor>(rHCmKvaRAfqsRlJBihaSKpaTMOsmA.fvFWOQAgDCBQvxnShDJXDdbKiMahb));
				List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list2 = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.RnUuiFvfagjWKXJJnsrTHdYpeZlc rnUuiFvfagjWKXJJnsrTHdYpeZlc = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.RnUuiFvfagjWKXJJnsrTHdYpeZlc();
				rnUuiFvfagjWKXJJnsrTHdYpeZlc.BTKBqOjFgXCBsJUcuBItUrPvtVedA = rHCmKvaRAfqsRlJBihaSKpaTMOsmA;
				rnUuiFvfagjWKXJJnsrTHdYpeZlc.MQuqblUbvfzuGFaEoWHQpLNXYJXn = rnUuiFvfagjWKXJJnsrTHdYpeZlc.BTKBqOjFgXCBsJUcuBItUrPvtVedA.KXzABAdDSsYrclZcfwrnFvyQMDRhb;
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<ControllerMap_Editor>("Keyboard Map", A_0.keyboardMaps, (A_1 != null) ? A_1.keyboardMaps : null, rnUuiFvfagjWKXJJnsrTHdYpeZlc.BTKBqOjFgXCBsJUcuBItUrPvtVedA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.keyboardMaps, A_2, list2, new Func<ControllerMap_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.UjmXdDzEznyhpLqOADhilZBQVMOQ), new Func<ControllerMap_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.oOjlHmYVHnDANqlrXcwAckwZFvQo), new Func<ControllerMap_Editor, IList<ControllerMap_Editor>, int>(rnUuiFvfagjWKXJJnsrTHdYpeZlc.oEqvekcXyRhumkXfygMzduVvKFUn), new Func<UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, ControllerMap_Editor>(rnUuiFvfagjWKXJJnsrTHdYpeZlc.suGHDTLiObKPUGMYhFmkczoatvvw));
				List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list3 = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ienQtBPAzPgfttbGKoOTmZgweQAi ienQtBPAzPgfttbGKoOTmZgweQAi = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ienQtBPAzPgfttbGKoOTmZgweQAi();
				ienQtBPAzPgfttbGKoOTmZgweQAi.FNoTWZgGaaTlBNoMQBoMHHfdEwHk = rHCmKvaRAfqsRlJBihaSKpaTMOsmA;
				ienQtBPAzPgfttbGKoOTmZgweQAi.KvvRinfoHrQuwoFdGHXKNDqSvdLT = ienQtBPAzPgfttbGKoOTmZgweQAi.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.fpzXioQXJgTWCZuxfiXwpaesvytT;
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<ControllerMap_Editor>("Mouse Map", A_0.mouseMaps, (A_1 != null) ? A_1.mouseMaps : null, ienQtBPAzPgfttbGKoOTmZgweQAi.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.mouseMaps, A_2, list3, new Func<ControllerMap_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.iiTBrfGqYgMaAKxDNBYUIIHwGpAib), new Func<ControllerMap_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.TSzBZKNWBOTUWdoRiOMjUQkeDvHl), new Func<ControllerMap_Editor, IList<ControllerMap_Editor>, int>(ienQtBPAzPgfttbGKoOTmZgweQAi.quhFOxebICpdZwSVrNphSlyhVFNMA), new Func<UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, ControllerMap_Editor>(ienQtBPAzPgfttbGKoOTmZgweQAi.xILVeWwGygnolyRmzltUcAPxDNHh));
				List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list4 = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.PxMGlyygurZvpvKvyXZEhXJGulLI pxMGlyygurZvpvKvyXZEhXJGulLI = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.PxMGlyygurZvpvKvyXZEhXJGulLI();
				pxMGlyygurZvpvKvyXZEhXJGulLI.nBQeiACNYMIPAGRHmwEoDdDJVAXiA = rHCmKvaRAfqsRlJBihaSKpaTMOsmA;
				pxMGlyygurZvpvKvyXZEhXJGulLI.mtfZGqjTegObbKhbZMOXKwBsZac = pxMGlyygurZvpvKvyXZEhXJGulLI.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.xPXJDvyuOAVhkIFtAVWkQGbWMuZB;
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<ControllerMap_Editor>("Joystick Map", A_0.joystickMaps, (A_1 != null) ? A_1.joystickMaps : null, pxMGlyygurZvpvKvyXZEhXJGulLI.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.joystickMaps, A_2, list4, new Func<ControllerMap_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.ujNzqUiFbhGmpIyXxGYrOXnzeLSkA), new Func<ControllerMap_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.bHxGmLbQYCgGwPiRJBAydXIiNJbCc), new Func<ControllerMap_Editor, IList<ControllerMap_Editor>, int>(pxMGlyygurZvpvKvyXZEhXJGulLI.JpdOtBQdLATtxfpHJQVVaLsTyMXw), new Func<UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, ControllerMap_Editor>(pxMGlyygurZvpvKvyXZEhXJGulLI.rXLtxPoypdfKMMmNkbQQiydSwHaNA));
				List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list5 = new List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>();
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.SpwsyPjYkYOIqSnDjbyIilNuxufqA spwsyPjYkYOIqSnDjbyIilNuxufqA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.SpwsyPjYkYOIqSnDjbyIilNuxufqA();
				spwsyPjYkYOIqSnDjbyIilNuxufqA.mWbfcjShVGqOAIASidTegYbTWjeUA = rHCmKvaRAfqsRlJBihaSKpaTMOsmA;
				spwsyPjYkYOIqSnDjbyIilNuxufqA.MWxrrOkKHliaHewvMcyylfcuMwAiA = spwsyPjYkYOIqSnDjbyIilNuxufqA.mWbfcjShVGqOAIASidTegYbTWjeUA.LFnmVkbqYubizvCjyClfkZkHXoCc;
				UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.ibIXMOIyZyQiLuUrnTBiDAGaiiaA<ControllerMap_Editor>("Custom Controller Map", A_0.customControllerMaps, (A_1 != null) ? A_1.customControllerMaps : null, spwsyPjYkYOIqSnDjbyIilNuxufqA.mWbfcjShVGqOAIASidTegYbTWjeUA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.customControllerMaps, A_2, list5, new Func<ControllerMap_Editor, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.TtPHFgqqYUHMABPQRkkWvkwwdmIJ), new Func<ControllerMap_Editor, string>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.vfxbKMDVbetSOpLbmaRIdyMUBvgFA), new Func<ControllerMap_Editor, IList<ControllerMap_Editor>, int>(spwsyPjYkYOIqSnDjbyIilNuxufqA.dRmBfrhFasDDnkreEgvGGwTMEczTA), new Func<UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, ControllerMap_Editor>(spwsyPjYkYOIqSnDjbyIilNuxufqA.RJQdLRskwjbRymoudVQBYtmpryEm));
				return rHCmKvaRAfqsRlJBihaSKpaTMOsmA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb;
			}

			// Token: 0x06001D03 RID: 7427 RVA: 0x0001713C File Offset: 0x0001533C
			[Conditional("DEBUG_IMPORT")]
			private static void UleNPyEMdRRYJoAsFjWhukFbpcGC(object A_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + ((A_0 != null) ? A_0.ToString() : null));
			}

			// Token: 0x06001D04 RID: 7428 RVA: 0x0007C908 File Offset: 0x0007AB08
			private static void avuVkvQFILgIfEGrxGDwxeMERIqs<\u0001>(IList<\u0001> A_0, IList<\u0001> A_1, IList<\u0001> A_2, Func<\u0001, IList<\u0001>, int> A_3)
			{
				for (int i = 0; i < A_0.Count; i++)
				{
					A_2.Add(A_0[i]);
				}
				if (A_1 != null)
				{
					for (int j = 0; j < A_1.Count; j++)
					{
						\u0001 u = A_1[j];
						int num = A_3(u, A_2);
						if (num >= 0)
						{
							A_2[num] = u;
						}
						else
						{
							A_2.Add(u);
						}
					}
				}
			}

			// Token: 0x06001D05 RID: 7429 RVA: 0x0007C970 File Offset: 0x0007AB70
			private static void ibIXMOIyZyQiLuUrnTBiDAGaiiaA<\u0001>(string A_0, IList<\u0001> A_1, IList<\u0001> A_2, IList<\u0001> A_3, bool A_4, List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> A_5, Func<\u0001, int> A_6, Func<\u0001, string> A_7, Func<\u0001, IList<\u0001>, int> A_8, Func<UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm, \u0001> A_9) where \u0001 : class
			{
				UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.QnjOChpkQkHZssBbKkLYBrghCxHo qnjOChpkQkHZssBbKkLYBrghCxHo = new UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.QnjOChpkQkHZssBbKkLYBrghCxHo();
				qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD = A_6;
				for (int i = 0; i < A_1.Count; i++)
				{
					\u0001 u = A_1[i];
					if (A_4)
					{
						A_5.Add(new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA(qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD(u), -1, qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD(u)));
					}
					else
					{
						\u0001 arg = A_9(new UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm(u, default(\u0001), UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.origId, A_3, false));
						A_5.Add(new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA(qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD(u), -1, qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD(arg)));
					}
				}
				if (A_2 != null)
				{
					for (int j = 0; j < A_2.Count; j++)
					{
						\u0001 u2 = A_2[j];
						int num = A_8(u2, A_3);
						if (num >= 0)
						{
							UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.gORtcsTwKuoPdNsXvDwqSJyoUTBR gORtcsTwKuoPdNsXvDwqSJyoUTBR = new UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.gORtcsTwKuoPdNsXvDwqSJyoUTBR();
							gORtcsTwKuoPdNsXvDwqSJyoUTBR.LfxSXYeiIyJRMEnLNgNayGiryWmQ = qnjOChpkQkHZssBbKkLYBrghCxHo;
							\u0001 u3 = A_3[num];
							gORtcsTwKuoPdNsXvDwqSJyoUTBR.maNLyEtCsRmQKWfQDbzVRlzaltqN = A_9(new UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm(u2, u3, UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.otherId, A_3, true));
							A_5.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(gORtcsTwKuoPdNsXvDwqSJyoUTBR.JBgWCQlEkLeEQKhVqYFZhdSTmafTA)).hKjjFvxQBmljyopHwiFLYAlFcKBi = gORtcsTwKuoPdNsXvDwqSJyoUTBR.LfxSXYeiIyJRMEnLNgNayGiryWmQ.AoLkIccofZPPYxloMXlhIPSvegXD(u2);
							string text = (!string.IsNullOrEmpty(A_7(u2))) ? ("\"" + A_7(u2) + "\"") : "";
							Logger.Log(A_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
						}
						else
						{
							\u0001 arg2 = A_9(new UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm(u2, default(\u0001), UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.otherId, A_3, false));
							A_5.Add(new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA(-1, qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD(u2), qnjOChpkQkHZssBbKkLYBrghCxHo.AoLkIccofZPPYxloMXlhIPSvegXD(arg2)));
							string text2 = (!string.IsNullOrEmpty(A_7(u2))) ? ("\"" + A_7(u2) + "\"") : "";
							Logger.Log("Imported new " + A_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
						}
					}
				}
			}

			// Token: 0x02000260 RID: 608
			[DefaultMember("Item")]
			private class pXpGLbrhxqscZSyHiAaoHyHmQeA
			{
				// Token: 0x1700069F RID: 1695
				// (get) Token: 0x06001D06 RID: 7430 RVA: 0x00017159 File Offset: 0x00015359
				// (set) Token: 0x06001D07 RID: 7431 RVA: 0x00017189 File Offset: 0x00015389
				public int WWrJmqrLiSMgAIejSdvaxYVawoeE
				{
					get
					{
						switch (A_1)
						{
						case UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.origId:
							return this.eJGKaEvlQtxgbrGvXwuZbVXWixdq;
						case UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.otherId:
							return this.hKjjFvxQBmljyopHwiFLYAlFcKBi;
						case UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.finalId:
							return this.wwFTVpPSBzdkLrIFZGPvCREGTptkA;
						default:
							throw new NotImplementedException();
						}
					}
					set
					{
						switch (A_1)
						{
						case UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.origId:
							this.eJGKaEvlQtxgbrGvXwuZbVXWixdq = value;
							return;
						case UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.otherId:
							this.hKjjFvxQBmljyopHwiFLYAlFcKBi = value;
							return;
						case UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.finalId:
							this.wwFTVpPSBzdkLrIFZGPvCREGTptkA = value;
							return;
						default:
							throw new NotImplementedException();
						}
					}
				}

				// Token: 0x06001D08 RID: 7432 RVA: 0x000171BC File Offset: 0x000153BC
				public pXpGLbrhxqscZSyHiAaoHyHmQeA(int A_1, int A_2, int A_3)
				{
					this.eJGKaEvlQtxgbrGvXwuZbVXWixdq = A_1;
					this.hKjjFvxQBmljyopHwiFLYAlFcKBi = A_2;
					this.wwFTVpPSBzdkLrIFZGPvCREGTptkA = A_3;
				}

				// Token: 0x06001D09 RID: 7433 RVA: 0x0007CBB8 File Offset: 0x0007ADB8
				public virtual string PIaeCbUToyQusOfwkyviHNRxecuk()
				{
					return "" + StringTools.WriteVar("origId", this.eJGKaEvlQtxgbrGvXwuZbVXWixdq) + StringTools.WriteVar("otherId", this.hKjjFvxQBmljyopHwiFLYAlFcKBi) + StringTools.WriteVar("finalId", this.wwFTVpPSBzdkLrIFZGPvCREGTptkA);
				}

				// Token: 0x04000FF0 RID: 4080
				public int eJGKaEvlQtxgbrGvXwuZbVXWixdq;

				// Token: 0x04000FF1 RID: 4081
				public int hKjjFvxQBmljyopHwiFLYAlFcKBi;

				// Token: 0x04000FF2 RID: 4082
				public int wwFTVpPSBzdkLrIFZGPvCREGTptkA;

				// Token: 0x02000261 RID: 609
				public enum CVIfynQxeIGcpVpAexRaLlhZDmaiA
				{
					// Token: 0x04000FF4 RID: 4084
					origId,
					// Token: 0x04000FF5 RID: 4085
					otherId,
					// Token: 0x04000FF6 RID: 4086
					finalId
				}
			}

			// Token: 0x02000262 RID: 610
			private class qhqAqJjrgQjQZqLevMnzCLQkxnwm<\u0001>
			{
				// Token: 0x06001D0A RID: 7434 RVA: 0x000171D9 File Offset: 0x000153D9
				public qhqAqJjrgQjQZqLevMnzCLQkxnwm(\u0001 A_1, \u0001 A_2, UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA A_3, IList<\u0001> A_4, bool A_5)
				{
					this.JufxgvcLPxbOZixRxOlOuQRnzOaz = A_1;
					this.rzczbfRAMBOTnPryBRfzcijjCGnk = A_2;
					this.DBmesHalKZopbMDhlYtgILNNnLEq = A_3;
					this.zzfBInqNRQXfeMeNfmKmoqoThELc = A_4;
					this.zUSxvdfmlSBzMevcHBnPatsuNanjb = A_5;
				}

				// Token: 0x04000FF7 RID: 4087
				public \u0001 JufxgvcLPxbOZixRxOlOuQRnzOaz;

				// Token: 0x04000FF8 RID: 4088
				public \u0001 rzczbfRAMBOTnPryBRfzcijjCGnk;

				// Token: 0x04000FF9 RID: 4089
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA DBmesHalKZopbMDhlYtgILNNnLEq;

				// Token: 0x04000FFA RID: 4090
				public IList<\u0001> zzfBInqNRQXfeMeNfmKmoqoThELc;

				// Token: 0x04000FFB RID: 4091
				public bool zUSxvdfmlSBzMevcHBnPatsuNanjb;
			}

			// Token: 0x02000263 RID: 611
			[CompilerGenerated]
			[Serializable]
			private sealed class cxQmOlHuLfWTTLrNwkDSQTkDvNlU
			{
				// Token: 0x06001D0D RID: 7437 RVA: 0x00017212 File Offset: 0x00015412
				internal int hQNNFQeCzNITRyfEEUamWGfySrEg(InputActionCategory A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D0E RID: 7438 RVA: 0x0001721A File Offset: 0x0001541A
				internal string GTSevdTlzUWqUJNPlxPDBSOGzdSh(InputActionCategory A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D0F RID: 7439 RVA: 0x0007CC18 File Offset: 0x0007AE18
				internal int rNRkrYGmWbIXfSeTlPZHHRutEUAn(InputActionCategory A_1, IList<InputActionCategory> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D10 RID: 7440 RVA: 0x00017222 File Offset: 0x00015422
				internal int npjlTIKdrbYviYbprFZmdHJKvqMvA(InputBehavior A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D11 RID: 7441 RVA: 0x0001722A File Offset: 0x0001542A
				internal string LRyVsNuGKfrYGDubIhFCYELleINH(InputBehavior A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D12 RID: 7442 RVA: 0x0007CC54 File Offset: 0x0007AE54
				internal int GlYsGCKGuVxSfNiZqyBQJjSfptmI(InputBehavior A_1, IList<InputBehavior> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D13 RID: 7443 RVA: 0x00017232 File Offset: 0x00015432
				internal int muxLRVepwjNqPKGUDvTnqseXUCHl(InputAction A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D14 RID: 7444 RVA: 0x0001723A File Offset: 0x0001543A
				internal string TMcmsYVBGafuCuLAkSGRMhmCpxpG(InputAction A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D15 RID: 7445 RVA: 0x0007CC90 File Offset: 0x0007AE90
				internal int KTtgWmOfCTklwyrjKsKRvGFWJpdH(InputAction A_1, IList<InputAction> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D16 RID: 7446 RVA: 0x00017212 File Offset: 0x00015412
				internal int vjVrlsgWYRIbdYYDoTquZokQpJXv(InputMapCategory A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D17 RID: 7447 RVA: 0x0001721A File Offset: 0x0001541A
				internal string rogApVZfZGqqXvwhFyPOShebEyZd(InputMapCategory A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D18 RID: 7448 RVA: 0x0007CCCC File Offset: 0x0007AECC
				internal int eeiffXnvdxDVdcnTbkbFYqKEZoYW(InputMapCategory A_1, IList<InputMapCategory> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D19 RID: 7449 RVA: 0x00017242 File Offset: 0x00015442
				internal int KNZBLTIRorXzNsEgGoZRAHdkQafFc(InputLayout A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D1A RID: 7450 RVA: 0x0001724A File Offset: 0x0001544A
				internal string UVDriuBsGoAPyApayIFGJQfAazRuA(InputLayout A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D1B RID: 7451 RVA: 0x0007CD08 File Offset: 0x0007AF08
				internal int FkPPhbVSHizIiWhQRrJvYmVfzCpT(InputLayout A_1, IList<InputLayout> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D1C RID: 7452 RVA: 0x00017242 File Offset: 0x00015442
				internal int apqJGJGXLlmLHGDWYiiUCkPkIeXi(InputLayout A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D1D RID: 7453 RVA: 0x0001724A File Offset: 0x0001544A
				internal string yNREqIIpyUdAFzowfBlCtgImnexR(InputLayout A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D1E RID: 7454 RVA: 0x0007CD08 File Offset: 0x0007AF08
				internal int KyeseojbEbxOwbHsNtVLOqqudyMhA(InputLayout A_1, IList<InputLayout> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D1F RID: 7455 RVA: 0x00017242 File Offset: 0x00015442
				internal int zUuzItszQBBYbvHxplkleQMPHjvi(InputLayout A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D20 RID: 7456 RVA: 0x0001724A File Offset: 0x0001544A
				internal string jVSCIfdqNoQNxnOVcDLypmMyAOcXA(InputLayout A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D21 RID: 7457 RVA: 0x0007CD08 File Offset: 0x0007AF08
				internal int WMjROKoTOJacrqsDlSAelYhxSTHO(InputLayout A_1, IList<InputLayout> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D22 RID: 7458 RVA: 0x00017242 File Offset: 0x00015442
				internal int PwNGBqmxkjtlBhQZoVTaidVHiZTe(InputLayout A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D23 RID: 7459 RVA: 0x0001724A File Offset: 0x0001544A
				internal string rZYFQbjPQHnorhKpNBakxgKMuMfPA(InputLayout A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D24 RID: 7460 RVA: 0x0007CD08 File Offset: 0x0007AF08
				internal int pOlAJxBfpzowHXecpcbsVTGgniteb(InputLayout A_1, IList<InputLayout> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D25 RID: 7461 RVA: 0x00017252 File Offset: 0x00015452
				internal int zsOLkREzhlHUJRiyJRNwhoAjicwJA(CustomController_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D26 RID: 7462 RVA: 0x0001725A File Offset: 0x0001545A
				internal string gnAFhnAggAwTRfxyCpzXLmMKUZDn(CustomController_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D27 RID: 7463 RVA: 0x0007CD44 File Offset: 0x0007AF44
				internal int fDsBgknktLJqrAjrKxKqzhtUDsNjA(CustomController_Editor A_1, IList<CustomController_Editor> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D28 RID: 7464 RVA: 0x00017262 File Offset: 0x00015462
				internal int YyLCbjRqsOlkjkbYSPLvPVVKnVrE(ControllerMapLayoutManager_RuleSet_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D29 RID: 7465 RVA: 0x0001726A File Offset: 0x0001546A
				internal string qmJZxLXQNoMzALMlkOyiUZCjOOQR(ControllerMapLayoutManager_RuleSet_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D2A RID: 7466 RVA: 0x0007CD80 File Offset: 0x0007AF80
				internal int IPQGTwAZkjygUgISlKXevwsHbaYNA(ControllerMapLayoutManager_RuleSet_Editor A_1, IList<ControllerMapLayoutManager_RuleSet_Editor> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D2B RID: 7467 RVA: 0x00017272 File Offset: 0x00015472
				internal int BUMOAnveuVLyDVEXRgAoMOYPPNrV(ControllerMapEnabler_RuleSet_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D2C RID: 7468 RVA: 0x0001727A File Offset: 0x0001547A
				internal string zZcvfuglxwMLFByUkKzLIoKtOUnG(ControllerMapEnabler_RuleSet_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D2D RID: 7469 RVA: 0x0007CDBC File Offset: 0x0007AFBC
				internal int eoHAIAFCcDoLWBCyJtqIFApYIgsob(ControllerMapEnabler_RuleSet_Editor A_1, IList<ControllerMapEnabler_RuleSet_Editor> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D2E RID: 7470 RVA: 0x00017282 File Offset: 0x00015482
				internal int wEgWmZvvypgOknsaxVZqfWPCasNC(Player_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D2F RID: 7471 RVA: 0x0001728A File Offset: 0x0001548A
				internal string IFzVssqvNCtlOoxtbyBlpqpTOlti(Player_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D30 RID: 7472 RVA: 0x0007CDF8 File Offset: 0x0007AFF8
				internal int XuAFqUTXcQwsaKKmtjAZOoKbLIbT(Player_Editor A_1, IList<Player_Editor> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (string.Equals(A_1.name, A_2[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D31 RID: 7473 RVA: 0x0007CE34 File Offset: 0x0007B034
				internal int ZUecpQJELooYeVcoIhEhFsryuoxv(Player_Editor.Mapping A_1, IList<Player_Editor.Mapping> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (A_2[i].categoryId == A_1.categoryId && A_2[i].layoutId == A_1.layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D32 RID: 7474 RVA: 0x0007CE80 File Offset: 0x0007B080
				internal int iKVfnBeuOtCJAbOwoBNiNVwfBcPib(Player_Editor.CreateControllerInfo A_1, IList<Player_Editor.CreateControllerInfo> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (A_2[i].sourceId == A_1.sourceId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D33 RID: 7475 RVA: 0x00017292 File Offset: 0x00015492
				internal int UjmXdDzEznyhpLqOADhilZBQVMOQ(ControllerMap_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D34 RID: 7476 RVA: 0x0001729A File Offset: 0x0001549A
				internal string oOjlHmYVHnDANqlrXcwAckwZFvQo(ControllerMap_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D35 RID: 7477 RVA: 0x0007CEB8 File Offset: 0x0007B0B8
				internal int cJkqIaRqThxfeVhpnzgORfyxYhJS(ActionElementMap A_1, IList<ActionElementMap> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (A_2[i]._keyboardKeyCode == A_1._keyboardKeyCode && A_2[i]._modifierKey1 == A_1._modifierKey1 && A_2[i]._modifierKey2 == A_1._modifierKey2 && A_2[i]._modifierKey3 == A_1._modifierKey3 && A_2[i]._axisContribution == A_1._axisContribution && A_2[i]._actionId == A_1._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D36 RID: 7478 RVA: 0x00017292 File Offset: 0x00015492
				internal int iiTBrfGqYgMaAKxDNBYUIIHwGpAib(ControllerMap_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D37 RID: 7479 RVA: 0x0001729A File Offset: 0x0001549A
				internal string TSzBZKNWBOTUWdoRiOMjUQkeDvHl(ControllerMap_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D38 RID: 7480 RVA: 0x0007CF54 File Offset: 0x0007B154
				internal int jahIKyqMFJDhxNNDzDCYEyGSVfDAA(ActionElementMap A_1, IList<ActionElementMap> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (A_2[i]._elementIdentifierId == A_1._elementIdentifierId && A_2[i]._axisRange == A_1._axisRange && A_2[i]._axisContribution == A_1._axisContribution && A_2[i]._actionId == A_1._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D39 RID: 7481 RVA: 0x00017292 File Offset: 0x00015492
				internal int ujNzqUiFbhGmpIyXxGYrOXnzeLSkA(ControllerMap_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D3A RID: 7482 RVA: 0x0001729A File Offset: 0x0001549A
				internal string bHxGmLbQYCgGwPiRJBAydXIiNJbCc(ControllerMap_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D3B RID: 7483 RVA: 0x0007CF54 File Offset: 0x0007B154
				internal int UKQWrnXlBhPkAsOPzGcufRkmoFZDA(ActionElementMap A_1, IList<ActionElementMap> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (A_2[i]._elementIdentifierId == A_1._elementIdentifierId && A_2[i]._axisRange == A_1._axisRange && A_2[i]._axisContribution == A_1._axisContribution && A_2[i]._actionId == A_1._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D3C RID: 7484 RVA: 0x00017292 File Offset: 0x00015492
				internal int TtPHFgqqYUHMABPQRkkWvkwwdmIJ(ControllerMap_Editor A_1)
				{
					return A_1.id;
				}

				// Token: 0x06001D3D RID: 7485 RVA: 0x0001729A File Offset: 0x0001549A
				internal string vfxbKMDVbetSOpLbmaRIdyMUBvgFA(ControllerMap_Editor A_1)
				{
					return A_1.name;
				}

				// Token: 0x06001D3E RID: 7486 RVA: 0x0007CF54 File Offset: 0x0007B154
				internal int IgrbaFifomqgqYSPMOswjuYZXNCS(ActionElementMap A_1, IList<ActionElementMap> A_2)
				{
					for (int i = 0; i < A_2.Count; i++)
					{
						if (A_2[i]._elementIdentifierId == A_1._elementIdentifierId && A_2[i]._axisRange == A_1._axisRange && A_2[i]._axisContribution == A_1._axisContribution && A_2[i]._actionId == A_1._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x04000FFC RID: 4092
				public static readonly UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU <>9 = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU();

				// Token: 0x04000FFD RID: 4093
				public static Func<InputActionCategory, int> <>9__0_0;

				// Token: 0x04000FFE RID: 4094
				public static Func<InputActionCategory, string> <>9__0_1;

				// Token: 0x04000FFF RID: 4095
				public static Func<InputActionCategory, IList<InputActionCategory>, int> <>9__0_2;

				// Token: 0x04001000 RID: 4096
				public static Func<InputBehavior, int> <>9__0_4;

				// Token: 0x04001001 RID: 4097
				public static Func<InputBehavior, string> <>9__0_5;

				// Token: 0x04001002 RID: 4098
				public static Func<InputBehavior, IList<InputBehavior>, int> <>9__0_6;

				// Token: 0x04001003 RID: 4099
				public static Func<InputAction, int> <>9__0_8;

				// Token: 0x04001004 RID: 4100
				public static Func<InputAction, string> <>9__0_9;

				// Token: 0x04001005 RID: 4101
				public static Func<InputAction, IList<InputAction>, int> <>9__0_10;

				// Token: 0x04001006 RID: 4102
				public static Func<InputMapCategory, int> <>9__0_47;

				// Token: 0x04001007 RID: 4103
				public static Func<InputMapCategory, string> <>9__0_48;

				// Token: 0x04001008 RID: 4104
				public static Func<InputMapCategory, IList<InputMapCategory>, int> <>9__0_49;

				// Token: 0x04001009 RID: 4105
				public static Func<InputLayout, int> <>9__0_12;

				// Token: 0x0400100A RID: 4106
				public static Func<InputLayout, string> <>9__0_13;

				// Token: 0x0400100B RID: 4107
				public static Func<InputLayout, IList<InputLayout>, int> <>9__0_14;

				// Token: 0x0400100C RID: 4108
				public static Func<InputLayout, int> <>9__0_16;

				// Token: 0x0400100D RID: 4109
				public static Func<InputLayout, string> <>9__0_17;

				// Token: 0x0400100E RID: 4110
				public static Func<InputLayout, IList<InputLayout>, int> <>9__0_18;

				// Token: 0x0400100F RID: 4111
				public static Func<InputLayout, int> <>9__0_20;

				// Token: 0x04001010 RID: 4112
				public static Func<InputLayout, string> <>9__0_21;

				// Token: 0x04001011 RID: 4113
				public static Func<InputLayout, IList<InputLayout>, int> <>9__0_22;

				// Token: 0x04001012 RID: 4114
				public static Func<InputLayout, int> <>9__0_24;

				// Token: 0x04001013 RID: 4115
				public static Func<InputLayout, string> <>9__0_25;

				// Token: 0x04001014 RID: 4116
				public static Func<InputLayout, IList<InputLayout>, int> <>9__0_26;

				// Token: 0x04001015 RID: 4117
				public static Func<CustomController_Editor, int> <>9__0_29;

				// Token: 0x04001016 RID: 4118
				public static Func<CustomController_Editor, string> <>9__0_30;

				// Token: 0x04001017 RID: 4119
				public static Func<CustomController_Editor, IList<CustomController_Editor>, int> <>9__0_31;

				// Token: 0x04001018 RID: 4120
				public static Func<ControllerMapLayoutManager_RuleSet_Editor, int> <>9__0_33;

				// Token: 0x04001019 RID: 4121
				public static Func<ControllerMapLayoutManager_RuleSet_Editor, string> <>9__0_34;

				// Token: 0x0400101A RID: 4122
				public static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> <>9__0_35;

				// Token: 0x0400101B RID: 4123
				public static Func<ControllerMapEnabler_RuleSet_Editor, int> <>9__0_37;

				// Token: 0x0400101C RID: 4124
				public static Func<ControllerMapEnabler_RuleSet_Editor, string> <>9__0_38;

				// Token: 0x0400101D RID: 4125
				public static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> <>9__0_39;

				// Token: 0x0400101E RID: 4126
				public static Func<Player_Editor, int> <>9__0_41;

				// Token: 0x0400101F RID: 4127
				public static Func<Player_Editor, string> <>9__0_42;

				// Token: 0x04001020 RID: 4128
				public static Func<Player_Editor, IList<Player_Editor>, int> <>9__0_43;

				// Token: 0x04001021 RID: 4129
				public static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> <>9__0_64;

				// Token: 0x04001022 RID: 4130
				public static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> <>9__0_65;

				// Token: 0x04001023 RID: 4131
				public static Func<ControllerMap_Editor, int> <>9__0_66;

				// Token: 0x04001024 RID: 4132
				public static Func<ControllerMap_Editor, string> <>9__0_67;

				// Token: 0x04001025 RID: 4133
				public static Func<ActionElementMap, IList<ActionElementMap>, int> <>9__0_75;

				// Token: 0x04001026 RID: 4134
				public static Func<ControllerMap_Editor, int> <>9__0_76;

				// Token: 0x04001027 RID: 4135
				public static Func<ControllerMap_Editor, string> <>9__0_77;

				// Token: 0x04001028 RID: 4136
				public static Func<ActionElementMap, IList<ActionElementMap>, int> <>9__0_85;

				// Token: 0x04001029 RID: 4137
				public static Func<ControllerMap_Editor, int> <>9__0_86;

				// Token: 0x0400102A RID: 4138
				public static Func<ControllerMap_Editor, string> <>9__0_87;

				// Token: 0x0400102B RID: 4139
				public static Func<ActionElementMap, IList<ActionElementMap>, int> <>9__0_95;

				// Token: 0x0400102C RID: 4140
				public static Func<ControllerMap_Editor, int> <>9__0_96;

				// Token: 0x0400102D RID: 4141
				public static Func<ControllerMap_Editor, string> <>9__0_97;

				// Token: 0x0400102E RID: 4142
				public static Func<ActionElementMap, IList<ActionElementMap>, int> <>9__0_107;
			}

			// Token: 0x02000264 RID: 612
			[CompilerGenerated]
			private sealed class rHCmKvaRAfqsRlJBihaSKpaTMOsmA
			{
				// Token: 0x06001D40 RID: 7488 RVA: 0x0007CFC8 File Offset: 0x0007B1C8
				internal InputActionCategory sXvQeHPkylONqXKxsnAYvItbQggn(UserData<InputActionCategory>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone<InputActionCategory>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputActionCategory inputActionCategory2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputActionCategory2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddActionCategory();
						inputActionCategory2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputActionCategory2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputActionCategory;
					return inputActionCategory;
				}

				// Token: 0x06001D41 RID: 7489 RVA: 0x0007D040 File Offset: 0x0007B240
				internal InputBehavior cCinBYsOJEIbKCgTQfGTDqlKfXRaB(UserData<InputBehavior>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputBehavior inputBehavior = JsonTools.Clone<InputBehavior>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputBehavior inputBehavior2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputBehavior2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddInputBehavior();
						inputBehavior2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputBehavior2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputBehavior;
					return inputBehavior;
				}

				// Token: 0x06001D42 RID: 7490 RVA: 0x0007D0B8 File Offset: 0x0007B2B8
				internal InputAction ZeVwCOflQoVspdESLPPyMalOLphJ(UserData<InputAction>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.HiFAUUDurGANgckqgGJFnQOfAtBEA hiFAUUDurGANgckqgGJFnQOfAtBEA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.HiFAUUDurGANgckqgGJFnQOfAtBEA();
					hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc = A_1;
					InputAction inputAction = JsonTools.Clone<InputAction>(hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.xPXJJfgbXluybZaZVCLcPOWlEtcIA.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(hiFAUUDurGANgckqgGJFnQOfAtBEA.pAqIuAvEzSQdlyagSRpufDdYTuAG));
					int num = (pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : 0;
					InputAction inputAction2;
					if (hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputAction2 = hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddAction(num);
						inputAction2 = hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.zzfBInqNRQXfeMeNfmKmoqoThELc[hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					pXpGLbrhxqscZSyHiAaoHyHmQeA = this.FLNdjYqHZZxHrTujPRIonxZNtWgw.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(hiFAUUDurGANgckqgGJFnQOfAtBEA.OnArwXBtMVIiunTnxOTARcAXSCrd));
					int num2 = (pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputAction2);
					hiFAUUDurGANgckqgGJFnQOfAtBEA.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputAction;
					return inputAction;
				}

				// Token: 0x06001D43 RID: 7491 RVA: 0x0007D1DC File Offset: 0x0007B3DC
				internal InputLayout kvPtpQtpVWAPQccKocTwfdcoalcLA(UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputLayout inputLayout = JsonTools.Clone<InputLayout>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputLayout inputLayout2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputLayout2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddKeyboardLayout();
						inputLayout2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputLayout2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputLayout;
					return inputLayout;
				}

				// Token: 0x06001D44 RID: 7492 RVA: 0x0007D254 File Offset: 0x0007B454
				internal InputLayout KxgWjSDPsZAOdXMXNKGzktsuvxWA(UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputLayout inputLayout = JsonTools.Clone<InputLayout>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputLayout inputLayout2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputLayout2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddMouseLayout();
						inputLayout2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputLayout2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputLayout;
					return inputLayout;
				}

				// Token: 0x06001D45 RID: 7493 RVA: 0x0007D2CC File Offset: 0x0007B4CC
				internal InputLayout OXAAMOONDzxPLaADTuTpTexrDESiA(UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputLayout inputLayout = JsonTools.Clone<InputLayout>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputLayout inputLayout2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputLayout2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddJoystickLayout();
						inputLayout2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputLayout2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputLayout;
					return inputLayout;
				}

				// Token: 0x06001D46 RID: 7494 RVA: 0x0007D344 File Offset: 0x0007B544
				internal InputLayout sZLGfGoKHKpGVJOabdcgFHHdMfedA(UserData<InputLayout>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputLayout inputLayout = JsonTools.Clone<InputLayout>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputLayout inputLayout2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputLayout2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddCustomControllerLayout();
						inputLayout2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputLayout2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = inputLayout;
					return inputLayout;
				}

				// Token: 0x06001D47 RID: 7495 RVA: 0x000172A2 File Offset: 0x000154A2
				internal List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> sCWiPaSHfLVClZeyRxhZKznatmLD(ControllerType A_1)
				{
					switch (A_1)
					{
					case ControllerType.Keyboard:
						return this.KXzABAdDSsYrclZcfwrnFvyQMDRhb;
					case ControllerType.Mouse:
						return this.fpzXioQXJgTWCZuxfiXwpaesvytT;
					case ControllerType.Joystick:
						return this.xPXJDvyuOAVhkIFtAVWkQGbWMuZB;
					default:
						if (A_1 != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.LFnmVkbqYubizvCjyClfkZkHXoCc;
					}
				}

				// Token: 0x06001D48 RID: 7496 RVA: 0x0007D3BC File Offset: 0x0007B5BC
				internal CustomController_Editor oYdeqtvKbRtdhOCPtbScgLiCEQHL(UserData<CustomController_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone<CustomController_Editor>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					CustomController_Editor customController_Editor2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						customController_Editor2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddCustomController(Guid.Empty);
						customController_Editor2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(customController_Editor2);
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = customController_Editor;
					return customController_Editor;
				}

				// Token: 0x06001D49 RID: 7497 RVA: 0x0007D438 File Offset: 0x0007B638
				internal ControllerMapLayoutManager_RuleSet_Editor iTJpmUjsQMwPqoyarbgtcZlRSZlv(UserData<ControllerMapLayoutManager_RuleSet_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.sRTEZFgspikHXeYcoCzsLtLWnvfv sRTEZFgspikHXeYcoCzsLtLWnvfv = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.sRTEZFgspikHXeYcoCzsLtLWnvfv();
					sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb = A_1;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone<ControllerMapLayoutManager_RuleSet_Editor>(sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					int num = (controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0;
					for (int i = 0; i < num; i++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[i];
						if (controllerMapLayoutManager_Rule_Editor != null && controllerMapLayoutManager_Rule_Editor.categoryIds != null)
						{
							List<int> list = new List<int>();
							int num2 = (controllerMapLayoutManager_Rule_Editor.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor.categoryIds.Count : 0;
							for (int j = 0; j < num2; j++)
							{
								UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.VViHlCeJpItWcAygbleCnIiBqOEF vviHlCeJpItWcAygbleCnIiBqOEF = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.VViHlCeJpItWcAygbleCnIiBqOEF();
								vviHlCeJpItWcAygbleCnIiBqOEF.ZnuXegecQWvkPVIyWNoINeldeXKx = sRTEZFgspikHXeYcoCzsLtLWnvfv;
								vviHlCeJpItWcAygbleCnIiBqOEF.lbtObxRtgHDJDUrsQQqmvsVWKPrO = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
								UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(vviHlCeJpItWcAygbleCnIiBqOEF.nhBSPGmNZjldGxvbFKyykwPeJftg));
								if (pXpGLbrhxqscZSyHiAaoHyHmQeA == null)
								{
									Logger.LogError("No new Map Category Id found for old id: " + vviHlCeJpItWcAygbleCnIiBqOEF.lbtObxRtgHDJDUrsQQqmvsVWKPrO.ToString());
								}
								else
								{
									list.Add(pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA);
								}
							}
							controllerMapLayoutManager_Rule_Editor.categoryIds = list;
						}
					}
					int num3 = (controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0;
					for (int k = 0; k < num3; k++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.nnoVyqJHZpXLcqBmajJtpNtuFMZCA nnoVyqJHZpXLcqBmajJtpNtuFMZCA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.nnoVyqJHZpXLcqBmajJtpNtuFMZCA();
						nnoVyqJHZpXLcqBmajJtpNtuFMZCA.qTKyjrOkXsingAkqSfbyjOYUhmHfb = sRTEZFgspikHXeYcoCzsLtLWnvfv;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list2 = this.UgzUaROLwkHbdnVLRcUzhMUmtCWo(controllerType);
							nnoVyqJHZpXLcqBmajJtpNtuFMZCA.hzTcsGECrlbwNNdvumGQVuFHAsENA = controllerMapLayoutManager_Rule_Editor2.layoutId;
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = list2.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(nnoVyqJHZpXLcqBmajJtpNtuFMZCA.YTrLUYUJoNSSTYASEMnzuTEMLmBl));
							if (pXpGLbrhxqscZSyHiAaoHyHmQeA2 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + nnoVyqJHZpXLcqBmajJtpNtuFMZCA.hzTcsGECrlbwNNdvumGQVuFHAsENA.ToString());
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA;
							}
						}
					}
					int num4 = (controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0;
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.clvjxmXfUVEnyhhYXsePrHPxBQeh clvjxmXfUVEnyhhYXsePrHPxBQeh = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.clvjxmXfUVEnyhhYXsePrHPxBQeh();
							clvjxmXfUVEnyhhYXsePrHPxBQeh.yTEiOrDygMMCuDLKClsLjsMTXvNg = sRTEZFgspikHXeYcoCzsLtLWnvfv;
							List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> tvPCaQWeioXSUByvUkUibabLcwst = this.TvPCaQWeioXSUByvUkUibabLcwst;
							clvjxmXfUVEnyhhYXsePrHPxBQeh.GKbUujvfAHkNSyGHQkfcGRqttCGQ = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = tvPCaQWeioXSUByvUkUibabLcwst.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(clvjxmXfUVEnyhhYXsePrHPxBQeh.ludDeRabsbXUigCoKkeEujfZpryN));
							if (pXpGLbrhxqscZSyHiAaoHyHmQeA3 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + clvjxmXfUVEnyhhYXsePrHPxBQeh.GKbUujvfAHkNSyGHQkfcGRqttCGQ.ToString());
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.zzfBInqNRQXfeMeNfmKmoqoThELc[sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					sRTEZFgspikHXeYcoCzsLtLWnvfv.gRRrSoBawKEglpFbjhRHiuFnEvzcb.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				// Token: 0x06001D4A RID: 7498 RVA: 0x0007D79C File Offset: 0x0007B99C
				internal ControllerMapEnabler_RuleSet_Editor UFYWxkvgLAUVwOfjeyZURkQmqoSx(UserData<ControllerMapEnabler_RuleSet_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.zGtNVVqzGlwgkYcSFbuXRekhkLSy zGtNVVqzGlwgkYcSFbuXRekhkLSy = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.zGtNVVqzGlwgkYcSFbuXRekhkLSy();
					zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA = A_1;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone<ControllerMapEnabler_RuleSet_Editor>(zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					int num = (controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0;
					for (int i = 0; i < num; i++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[i];
						if (controllerMapEnabler_Rule_Editor != null && controllerMapEnabler_Rule_Editor.categoryIds != null)
						{
							List<int> list = new List<int>();
							for (int j = 0; j < controllerMapEnabler_Rule_Editor.categoryIds.Count; j++)
							{
								UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LTyAwvrfvXBSBFQGfkOBDlqcUELD ltyAwvrfvXBSBFQGfkOBDlqcUELD = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LTyAwvrfvXBSBFQGfkOBDlqcUELD();
								ltyAwvrfvXBSBFQGfkOBDlqcUELD.kdAeYcDKLheGhxSuAAaZLfNjaeZTA = zGtNVVqzGlwgkYcSFbuXRekhkLSy;
								ltyAwvrfvXBSBFQGfkOBDlqcUELD.JYjGxdeUEdgJsQTuViMPmhoKeMeE = controllerMapEnabler_Rule_Editor.categoryIds[j];
								UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(ltyAwvrfvXBSBFQGfkOBDlqcUELD.bRmIQkSNhAxOkMNlsejjIIQXgfPpA));
								if (pXpGLbrhxqscZSyHiAaoHyHmQeA == null)
								{
									Logger.LogError("No new Map Category Id found for old id: " + ltyAwvrfvXBSBFQGfkOBDlqcUELD.JYjGxdeUEdgJsQTuViMPmhoKeMeE.ToString());
								}
								else
								{
									list.Add(pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA);
								}
							}
							controllerMapEnabler_Rule_Editor.categoryIds = list;
						}
					}
					int num2 = (controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0;
					for (int k = 0; k < num2; k++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[k];
						if (controllerMapEnabler_Rule_Editor2 != null && controllerMapEnabler_Rule_Editor2.layoutIds != null)
						{
							ControllerType controllerType = controllerMapEnabler_Rule_Editor2.controllerSetSelector.controllerType;
							List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list2 = this.UgzUaROLwkHbdnVLRcUzhMUmtCWo(controllerType);
							List<int> list3 = new List<int>();
							int num3 = (controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0;
							for (int l = 0; l < num3; l++)
							{
								UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.jcTWGIoepZEXTKFtBeTZrCzOZGHd jcTWGIoepZEXTKFtBeTZrCzOZGHd = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.jcTWGIoepZEXTKFtBeTZrCzOZGHd();
								jcTWGIoepZEXTKFtBeTZrCzOZGHd.xOSeBGoJdWfnFdWwfgfHJkzThpQYA = zGtNVVqzGlwgkYcSFbuXRekhkLSy;
								jcTWGIoepZEXTKFtBeTZrCzOZGHd.yYfbnWCCeTcedEwennIsTqHJBrhXA = controllerMapEnabler_Rule_Editor2.layoutIds[l];
								UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = list2.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(jcTWGIoepZEXTKFtBeTZrCzOZGHd.NNOtmjHfwtjcOvkIKcxkuseuccLQ));
								if (pXpGLbrhxqscZSyHiAaoHyHmQeA2 == null)
								{
									Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + jcTWGIoepZEXTKFtBeTZrCzOZGHd.yYfbnWCCeTcedEwennIsTqHJBrhXA.ToString());
								}
								else
								{
									list3.Add(pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA);
								}
							}
							controllerMapEnabler_Rule_Editor2.layoutIds = list3;
						}
					}
					int num4 = (controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0;
					for (int m = 0; m < num4; m++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[m];
						if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.kOcdDlAalxEMXGoKfNeBGEwUZnjHb kOcdDlAalxEMXGoKfNeBGEwUZnjHb = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.kOcdDlAalxEMXGoKfNeBGEwUZnjHb();
							kOcdDlAalxEMXGoKfNeBGEwUZnjHb.BClPvKidnleuWdIiWCLKIDbgqbwHB = zGtNVVqzGlwgkYcSFbuXRekhkLSy;
							List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> tvPCaQWeioXSUByvUkUibabLcwst = this.TvPCaQWeioXSUByvUkUibabLcwst;
							kOcdDlAalxEMXGoKfNeBGEwUZnjHb.UYnDeiSNusvgREZRAbxlDdWtQJjt = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = tvPCaQWeioXSUByvUkUibabLcwst.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(kOcdDlAalxEMXGoKfNeBGEwUZnjHb.uYQKnVsHniTteTqdKsdlpFOQZoeW));
							if (pXpGLbrhxqscZSyHiAaoHyHmQeA3 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + kOcdDlAalxEMXGoKfNeBGEwUZnjHb.UYnDeiSNusvgREZRAbxlDdWtQJjt.ToString());
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						controllerMapEnabler_RuleSet_Editor2 = zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.zzfBInqNRQXfeMeNfmKmoqoThELc[zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					zGtNVVqzGlwgkYcSFbuXRekhkLSy.YAVoDHBLKUePqbyuXqnoFraVNORzA.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				// Token: 0x06001D4B RID: 7499 RVA: 0x0007DB38 File Offset: 0x0007BD38
				internal Player_Editor fvFWOQAgDCBQvxnShDJXDdbKiMahb(UserData<Player_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.UZZzFodXDdKoLVjPNiLYCyaUrSvdA uzzzFodXDdKoLVjPNiLYCyaUrSvdA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.UZZzFodXDdKoLVjPNiLYCyaUrSvdA();
					uzzzFodXDdKoLVjPNiLYCyaUrSvdA.UbDaoCSvmLGIPiSUfZEGcZeHJVgDA = this;
					uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh = A_1;
					Player_Editor player_Editor = JsonTools.Clone<Player_Editor>(uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					Action<List<Player_Editor.Mapping>, List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>> action = new Action<List<Player_Editor.Mapping>, List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>>(uzzzFodXDdKoLVjPNiLYCyaUrSvdA.qxNWUOMCxISkErpvNvlsGQUuPayq);
					action(player_Editor.defaultKeyboardMaps, this.KXzABAdDSsYrclZcfwrnFvyQMDRhb);
					action(player_Editor.defaultMouseMaps, this.fpzXioQXJgTWCZuxfiXwpaesvytT);
					action(player_Editor.defaultJoystickMaps, this.xPXJDvyuOAVhkIFtAVWkQGbWMuZB);
					action(player_Editor.defaultCustomControllerMaps, this.LFnmVkbqYubizvCjyClfkZkHXoCc);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.hKiJuVVzThVYWebLNyCAcvFIFVMj hKiJuVVzThVYWebLNyCAcvFIFVMj = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.hKiJuVVzThVYWebLNyCAcvFIFVMj();
						hKiJuVVzThVYWebLNyCAcvFIFVMj.AGJqcbBqEeqynubaKBAGkukGmjxRA = uzzzFodXDdKoLVjPNiLYCyaUrSvdA;
						hKiJuVVzThVYWebLNyCAcvFIFVMj.XehWRWJZlKCjoGMRnoKMWhDwbeLjA = player_Editor.startingCustomControllers[i];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.TvPCaQWeioXSUByvUkUibabLcwst.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(hKiJuVVzThVYWebLNyCAcvFIFVMj.YKwMRlGbiwaDuTdOjiYfawQyEPRC));
						hKiJuVVzThVYWebLNyCAcvFIFVMj.XehWRWJZlKCjoGMRnoKMWhDwbeLjA.sourceId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.brHZNpePhTnCEBWDRNDVeVSJwoVA brHZNpePhTnCEBWDRNDVeVSJwoVA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.brHZNpePhTnCEBWDRNDVeVSJwoVA();
						brHZNpePhTnCEBWDRNDVeVSJwoVA.kMfCXkBrTpCMfcxeazLajqQPgBRqB = uzzzFodXDdKoLVjPNiLYCyaUrSvdA;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							brHZNpePhTnCEBWDRNDVeVSJwoVA.RcpUdPhuPHRNcLVNVmGoCsRDDgCW = ruleSetMapping.id;
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = this.nhYmGnVzotCjmkNpPHgusikZWUEB.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(brHZNpePhTnCEBWDRNDVeVSJwoVA.zBhhyzCuDOBrduRiiMBCfYDywfWS));
							if (pXpGLbrhxqscZSyHiAaoHyHmQeA2 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + brHZNpePhTnCEBWDRNDVeVSJwoVA.RcpUdPhuPHRNcLVNVmGoCsRDDgCW.ToString());
							}
							else
							{
								ruleSetMapping = ruleSetMapping.Clone();
								ruleSetMapping.id = pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA;
								list.Add(ruleSetMapping);
							}
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.wBEKfbDsscFiwftLMgMDSaNfMWii wBEKfbDsscFiwftLMgMDSaNfMWii = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.wBEKfbDsscFiwftLMgMDSaNfMWii();
						wBEKfbDsscFiwftLMgMDSaNfMWii.NZcAnbJyYAUWhXLDLpsnhXZbglml = uzzzFodXDdKoLVjPNiLYCyaUrSvdA;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							wBEKfbDsscFiwftLMgMDSaNfMWii.GpLvZWHzObrOVueIUiCDxAxvdQNS = ruleSetMapping2.id;
							UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = this.PcTijjdXuFafHjICIAeDYskzwnvGb.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(wBEKfbDsscFiwftLMgMDSaNfMWii.fDYayrZRFbhRlshTmRBBvSKnYSmd));
							if (pXpGLbrhxqscZSyHiAaoHyHmQeA3 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + wBEKfbDsscFiwftLMgMDSaNfMWii.GpLvZWHzObrOVueIUiCDxAxvdQNS.ToString());
							}
							else
							{
								ruleSetMapping2 = ruleSetMapping2.Clone();
								ruleSetMapping2.id = pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA;
								list2.Add(ruleSetMapping2);
							}
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						player_Editor2 = uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.rzczbfRAMBOTnPryBRfzcijjCGnk;
						Player_Editor player_Editor3 = JsonTools.Clone<Player_Editor>(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = new Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.ZUecpQJELooYeVcoIhEhFsryuoxv);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<Player_Editor.Mapping>(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<Player_Editor.Mapping>(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<Player_Editor.Mapping>(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<Player_Editor.Mapping>(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<Player_Editor.CreateControllerInfo>(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, new Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.iKVfnBeuOtCJAbOwoBNiNVwfBcPib));
						player_Editor = player_Editor3;
					}
					else
					{
						this.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddPlayer();
						player_Editor2 = uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.zzfBInqNRQXfeMeNfmKmoqoThELc[uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(player_Editor2);
					uzzzFodXDdKoLVjPNiLYCyaUrSvdA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = player_Editor;
					return player_Editor;
				}

				// Token: 0x0400102F RID: 4143
				public UserData RpEWMMfBCwcgrHPFxcyGgckEqVDlb;

				// Token: 0x04001030 RID: 4144
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> xPXJJfgbXluybZaZVCLcPOWlEtcIA;

				// Token: 0x04001031 RID: 4145
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> FLNdjYqHZZxHrTujPRIonxZNtWgw;

				// Token: 0x04001032 RID: 4146
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> KXzABAdDSsYrclZcfwrnFvyQMDRhb;

				// Token: 0x04001033 RID: 4147
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> fpzXioQXJgTWCZuxfiXwpaesvytT;

				// Token: 0x04001034 RID: 4148
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> xPXJDvyuOAVhkIFtAVWkQGbWMuZB;

				// Token: 0x04001035 RID: 4149
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> LFnmVkbqYubizvCjyClfkZkHXoCc;

				// Token: 0x04001036 RID: 4150
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> cfrdVEihCYaDpfghHudHhHHCmGcKd;

				// Token: 0x04001037 RID: 4151
				public Func<ControllerType, List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>> UgzUaROLwkHbdnVLRcUzhMUmtCWo;

				// Token: 0x04001038 RID: 4152
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> TvPCaQWeioXSUByvUkUibabLcwst;

				// Token: 0x04001039 RID: 4153
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> nhYmGnVzotCjmkNpPHgusikZWUEB;

				// Token: 0x0400103A RID: 4154
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> PcTijjdXuFafHjICIAeDYskzwnvGb;

				// Token: 0x0400103B RID: 4155
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> AvDryzYVKEtVoBauEwNaHBOpVGoC;
			}

			// Token: 0x02000265 RID: 613
			[CompilerGenerated]
			private sealed class HiFAUUDurGANgckqgGJFnQOfAtBEA
			{
				// Token: 0x06001D4D RID: 7501 RVA: 0x000172DE File Offset: 0x000154DE
				internal bool pAqIuAvEzSQdlyagSRpufDdYTuAG(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.DBmesHalKZopbMDhlYtgILNNnLEq) == this.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.JufxgvcLPxbOZixRxOlOuQRnzOaz.categoryId;
				}

				// Token: 0x06001D4E RID: 7502 RVA: 0x00017303 File Offset: 0x00015503
				internal bool OnArwXBtMVIiunTnxOTARcAXSCrd(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.DBmesHalKZopbMDhlYtgILNNnLEq) == this.CVqwVVwNQJDcsJTOxMMdbHzIiyVpc.JufxgvcLPxbOZixRxOlOuQRnzOaz.behaviorId;
				}

				// Token: 0x0400103C RID: 4156
				public UserData<InputAction>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm CVqwVVwNQJDcsJTOxMMdbHzIiyVpc;
			}

			// Token: 0x02000266 RID: 614
			[CompilerGenerated]
			private sealed class jcTWGIoepZEXTKFtBeTZrCzOZGHd
			{
				// Token: 0x06001D50 RID: 7504 RVA: 0x00017328 File Offset: 0x00015528
				internal bool NNOtmjHfwtjcOvkIKcxkuseuccLQ(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.xOSeBGoJdWfnFdWwfgfHJkzThpQYA.YAVoDHBLKUePqbyuXqnoFraVNORzA.DBmesHalKZopbMDhlYtgILNNnLEq) == this.yYfbnWCCeTcedEwennIsTqHJBrhXA;
				}

				// Token: 0x0400103D RID: 4157
				public int yYfbnWCCeTcedEwennIsTqHJBrhXA;

				// Token: 0x0400103E RID: 4158
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.zGtNVVqzGlwgkYcSFbuXRekhkLSy xOSeBGoJdWfnFdWwfgfHJkzThpQYA;
			}

			// Token: 0x02000267 RID: 615
			[CompilerGenerated]
			private sealed class kOcdDlAalxEMXGoKfNeBGEwUZnjHb
			{
				// Token: 0x06001D52 RID: 7506 RVA: 0x00017348 File Offset: 0x00015548
				internal bool uYQKnVsHniTteTqdKsdlpFOQZoeW(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.BClPvKidnleuWdIiWCLKIDbgqbwHB.YAVoDHBLKUePqbyuXqnoFraVNORzA.DBmesHalKZopbMDhlYtgILNNnLEq) == this.UYnDeiSNusvgREZRAbxlDdWtQJjt;
				}

				// Token: 0x0400103F RID: 4159
				public int UYnDeiSNusvgREZRAbxlDdWtQJjt;

				// Token: 0x04001040 RID: 4160
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.zGtNVVqzGlwgkYcSFbuXRekhkLSy BClPvKidnleuWdIiWCLKIDbgqbwHB;
			}

			// Token: 0x02000268 RID: 616
			[CompilerGenerated]
			private sealed class UZZzFodXDdKoLVjPNiLYCyaUrSvdA
			{
				// Token: 0x06001D54 RID: 7508 RVA: 0x0007DF3C File Offset: 0x0007C13C
				internal void qxNWUOMCxISkErpvNvlsGQUuPayq(List<Player_Editor.Mapping> A_1, List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> A_2)
				{
					for (int i = 0; i < A_1.Count; i++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.PvXwLcAyReMjlJInRZgCKAhLxxjb pvXwLcAyReMjlJInRZgCKAhLxxjb = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.PvXwLcAyReMjlJInRZgCKAhLxxjb();
						pvXwLcAyReMjlJInRZgCKAhLxxjb.RVZIbdszmbFPCawCeRmEuAmOezsGA = this;
						pvXwLcAyReMjlJInRZgCKAhLxxjb.DuOPKwCrjdTxuQtJlXViiJXAkZai = A_1[i];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.UbDaoCSvmLGIPiSUfZEGcZeHJVgDA.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(pvXwLcAyReMjlJInRZgCKAhLxxjb.OxuJtdLFbMpjciZVolnUDWInbtvI));
						pvXwLcAyReMjlJInRZgCKAhLxxjb.DuOPKwCrjdTxuQtJlXViiJXAkZai.categoryId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
						pXpGLbrhxqscZSyHiAaoHyHmQeA = A_2.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(pvXwLcAyReMjlJInRZgCKAhLxxjb.CThoPhyvRITbkFIVXTOnFHBkIxzhA));
						pvXwLcAyReMjlJInRZgCKAhLxxjb.DuOPKwCrjdTxuQtJlXViiJXAkZai.layoutId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					}
				}

				// Token: 0x04001041 RID: 4161
				public UserData<Player_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm oRuhBgmjNhhTeboJcwDjuyKTIwxh;

				// Token: 0x04001042 RID: 4162
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA UbDaoCSvmLGIPiSUfZEGcZeHJVgDA;
			}

			// Token: 0x02000269 RID: 617
			[CompilerGenerated]
			private sealed class PvXwLcAyReMjlJInRZgCKAhLxxjb
			{
				// Token: 0x06001D56 RID: 7510 RVA: 0x00017368 File Offset: 0x00015568
				internal bool OxuJtdLFbMpjciZVolnUDWInbtvI(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.RVZIbdszmbFPCawCeRmEuAmOezsGA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.DBmesHalKZopbMDhlYtgILNNnLEq) == this.DuOPKwCrjdTxuQtJlXViiJXAkZai.categoryId;
				}

				// Token: 0x06001D57 RID: 7511 RVA: 0x0001738D File Offset: 0x0001558D
				internal bool CThoPhyvRITbkFIVXTOnFHBkIxzhA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.RVZIbdszmbFPCawCeRmEuAmOezsGA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.DBmesHalKZopbMDhlYtgILNNnLEq) == this.DuOPKwCrjdTxuQtJlXViiJXAkZai.layoutId;
				}

				// Token: 0x04001043 RID: 4163
				public Player_Editor.Mapping DuOPKwCrjdTxuQtJlXViiJXAkZai;

				// Token: 0x04001044 RID: 4164
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.UZZzFodXDdKoLVjPNiLYCyaUrSvdA RVZIbdszmbFPCawCeRmEuAmOezsGA;
			}

			// Token: 0x0200026A RID: 618
			[CompilerGenerated]
			private sealed class hKiJuVVzThVYWebLNyCAcvFIFVMj
			{
				// Token: 0x06001D59 RID: 7513 RVA: 0x000173B2 File Offset: 0x000155B2
				internal bool YKwMRlGbiwaDuTdOjiYfawQyEPRC(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.AGJqcbBqEeqynubaKBAGkukGmjxRA.oRuhBgmjNhhTeboJcwDjuyKTIwxh.DBmesHalKZopbMDhlYtgILNNnLEq) == this.XehWRWJZlKCjoGMRnoKMWhDwbeLjA.sourceId;
				}

				// Token: 0x04001045 RID: 4165
				public Player_Editor.CreateControllerInfo XehWRWJZlKCjoGMRnoKMWhDwbeLjA;

				// Token: 0x04001046 RID: 4166
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.UZZzFodXDdKoLVjPNiLYCyaUrSvdA AGJqcbBqEeqynubaKBAGkukGmjxRA;
			}

			// Token: 0x0200026B RID: 619
			[CompilerGenerated]
			private sealed class brHZNpePhTnCEBWDRNDVeVSJwoVA
			{
				// Token: 0x06001D5B RID: 7515 RVA: 0x000173D7 File Offset: 0x000155D7
				internal bool zBhhyzCuDOBrduRiiMBCfYDywfWS(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.kMfCXkBrTpCMfcxeazLajqQPgBRqB.oRuhBgmjNhhTeboJcwDjuyKTIwxh.DBmesHalKZopbMDhlYtgILNNnLEq) == this.RcpUdPhuPHRNcLVNVmGoCsRDDgCW;
				}

				// Token: 0x04001047 RID: 4167
				public int RcpUdPhuPHRNcLVNVmGoCsRDDgCW;

				// Token: 0x04001048 RID: 4168
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.UZZzFodXDdKoLVjPNiLYCyaUrSvdA kMfCXkBrTpCMfcxeazLajqQPgBRqB;
			}

			// Token: 0x0200026C RID: 620
			[CompilerGenerated]
			private sealed class wBEKfbDsscFiwftLMgMDSaNfMWii
			{
				// Token: 0x06001D5D RID: 7517 RVA: 0x000173F7 File Offset: 0x000155F7
				internal bool fDYayrZRFbhRlshTmRBBvSKnYSmd(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.NZcAnbJyYAUWhXLDLpsnhXZbglml.oRuhBgmjNhhTeboJcwDjuyKTIwxh.DBmesHalKZopbMDhlYtgILNNnLEq) == this.GpLvZWHzObrOVueIUiCDxAxvdQNS;
				}

				// Token: 0x04001049 RID: 4169
				public int GpLvZWHzObrOVueIUiCDxAxvdQNS;

				// Token: 0x0400104A RID: 4170
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.UZZzFodXDdKoLVjPNiLYCyaUrSvdA NZcAnbJyYAUWhXLDLpsnhXZbglml;
			}

			// Token: 0x0200026D RID: 621
			[CompilerGenerated]
			private sealed class RnUuiFvfagjWKXJJnsrTHdYpeZlc
			{
				// Token: 0x06001D5F RID: 7519 RVA: 0x0007DFD8 File Offset: 0x0007C1D8
				internal int oEqvekcXyRhumkXfygMzduVvKFUn(ControllerMap_Editor A_1, IList<ControllerMap_Editor> A_2)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.gOPPUVKDxOdrYsKBqHitcwzHUUKaA gOPPUVKDxOdrYsKBqHitcwzHUUKaA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.gOPPUVKDxOdrYsKBqHitcwzHUUKaA();
					gOPPUVKDxOdrYsKBqHitcwzHUUKaA.sWbpqByDYsJOnNDDAvHRSqIsvRhp = A_1;
					for (int i = 0; i < A_2.Count; i++)
					{
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> cfrdVEihCYaDpfghHudHhHHCmGcKd = this.BTKBqOjFgXCBsJUcuBItUrPvtVedA.cfrdVEihCYaDpfghHudHhHHCmGcKd;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match;
						if ((match = gOPPUVKDxOdrYsKBqHitcwzHUUKaA.aACkppdkZpmvXEuOycArpQHznjdt) == null)
						{
							match = (gOPPUVKDxOdrYsKBqHitcwzHUUKaA.aACkppdkZpmvXEuOycArpQHznjdt = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(gOPPUVKDxOdrYsKBqHitcwzHUUKaA.FesQWlmPYFiZgdaEAFLXvLOjnlXc));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(match);
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> mquqblUbvfzuGFaEoWHQpLNXYJXn = this.MQuqblUbvfzuGFaEoWHQpLNXYJXn;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match2;
						if ((match2 = gOPPUVKDxOdrYsKBqHitcwzHUUKaA.JDELeYDPhteSsEvTOGpBiXXXzqJJ) == null)
						{
							match2 = (gOPPUVKDxOdrYsKBqHitcwzHUUKaA.JDELeYDPhteSsEvTOGpBiXXXzqJJ = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(gOPPUVKDxOdrYsKBqHitcwzHUUKaA.VLciRYYpvDOKVmUCmhwQzfYJdXii));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = mquqblUbvfzuGFaEoWHQpLNXYJXn.Find(match2);
						if (pXpGLbrhxqscZSyHiAaoHyHmQeA != null && pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].categoryId && pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null && pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D60 RID: 7520 RVA: 0x0007E09C File Offset: 0x0007C29C
				internal ControllerMap_Editor suGHDTLiObKPUGMYhFmkczoatvvw(UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LNTmgwpDvTbuUYEwyPQMDnysQLnQ lntmgwpDvTbuUYEwyPQMDnysQLnQ = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LNTmgwpDvTbuUYEwyPQMDnysQLnQ();
					lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO = A_1;
					lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX = JsonTools.Clone<ControllerMap_Editor>(lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.BTKBqOjFgXCBsJUcuBItUrPvtVedA.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(lntmgwpDvTbuUYEwyPQMDnysQLnQ.uQGXdLRQLSLVnkqfyLheEYtYXqeH));
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = this.MQuqblUbvfzuGFaEoWHQpLNXYJXn.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(lntmgwpDvTbuUYEwyPQMDnysQLnQ.hAbPcMjHxKBvqvwlNZjbodaSjPYkA));
					lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.categoryId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.layoutId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					for (int i = 0; i < lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.actionElementMaps.Count; i++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.uoUTmveVZqSpLTqfqlxCoCeAaOsFA uoUTmveVZqSpLTqfqlxCoCeAaOsFA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.uoUTmveVZqSpLTqfqlxCoCeAaOsFA();
						uoUTmveVZqSpLTqfqlxCoCeAaOsFA.RlhQIBjAIqzFCDUhCXIKDJKSHiqG = lntmgwpDvTbuUYEwyPQMDnysQLnQ;
						uoUTmveVZqSpLTqfqlxCoCeAaOsFA.pCUPsmnrjSMdOhCfMbHpikDLeeAS = uoUTmveVZqSpLTqfqlxCoCeAaOsFA.RlhQIBjAIqzFCDUhCXIKDJKSHiqG.vPzFxysaGbRAGbaABKsUJDESSkjX.actionElementMaps[i];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = this.BTKBqOjFgXCBsJUcuBItUrPvtVedA.AvDryzYVKEtVoBauEwNaHBOpVGoC.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(uoUTmveVZqSpLTqfqlxCoCeAaOsFA.dIuPvXGMaUEgTCwqcfvEPyTfqkHbA));
						uoUTmveVZqSpLTqfqlxCoCeAaOsFA.pCUPsmnrjSMdOhCfMbHpikDLeeAS._actionId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA3 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
						uoUTmveVZqSpLTqfqlxCoCeAaOsFA.pCUPsmnrjSMdOhCfMbHpikDLeeAS._actionCategoryId = ((this.BTKBqOjFgXCBsJUcuBItUrPvtVedA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(uoUTmveVZqSpLTqfqlxCoCeAaOsFA.pCUPsmnrjSMdOhCfMbHpikDLeeAS._actionId) != null) ? this.BTKBqOjFgXCBsJUcuBItUrPvtVedA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(uoUTmveVZqSpLTqfqlxCoCeAaOsFA.pCUPsmnrjSMdOhCfMbHpikDLeeAS._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						controllerMap_Editor = lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.rzczbfRAMBOTnPryBRfzcijjCGnk;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone<ControllerMap_Editor>(lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = new Func<ActionElementMap, IList<ActionElementMap>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.cJkqIaRqThxfeVhpnzgORfyxYhJS);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<ActionElementMap>(controllerMap_Editor.actionElementMaps, lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX = controllerMap_Editor2;
					}
					else
					{
						this.BTKBqOjFgXCBsJUcuBItUrPvtVedA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.CreateKeyboardMap(lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.categoryId, lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.layoutId);
						controllerMap_Editor = lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.zzfBInqNRQXfeMeNfmKmoqoThELc[lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX.id = controllerMap_Editor.id;
					int index = lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(controllerMap_Editor);
					lntmgwpDvTbuUYEwyPQMDnysQLnQ.ytHlUWQjfyzBbtRiQhCieOFTEanO.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX;
					return lntmgwpDvTbuUYEwyPQMDnysQLnQ.vPzFxysaGbRAGbaABKsUJDESSkjX;
				}

				// Token: 0x0400104B RID: 4171
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> MQuqblUbvfzuGFaEoWHQpLNXYJXn;

				// Token: 0x0400104C RID: 4172
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA BTKBqOjFgXCBsJUcuBItUrPvtVedA;
			}

			// Token: 0x0200026E RID: 622
			[CompilerGenerated]
			private sealed class gOPPUVKDxOdrYsKBqHitcwzHUUKaA
			{
				// Token: 0x06001D62 RID: 7522 RVA: 0x00017417 File Offset: 0x00015617
				internal bool FesQWlmPYFiZgdaEAFLXvLOjnlXc(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.sWbpqByDYsJOnNDDAvHRSqIsvRhp.categoryId;
				}

				// Token: 0x06001D63 RID: 7523 RVA: 0x0001742C File Offset: 0x0001562C
				internal bool VLciRYYpvDOKVmUCmhwQzfYJdXii(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.sWbpqByDYsJOnNDDAvHRSqIsvRhp.layoutId;
				}

				// Token: 0x0400104D RID: 4173
				public ControllerMap_Editor sWbpqByDYsJOnNDDAvHRSqIsvRhp;

				// Token: 0x0400104E RID: 4174
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> aACkppdkZpmvXEuOycArpQHznjdt;

				// Token: 0x0400104F RID: 4175
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> JDELeYDPhteSsEvTOGpBiXXXzqJJ;
			}

			// Token: 0x0200026F RID: 623
			[CompilerGenerated]
			private sealed class LNTmgwpDvTbuUYEwyPQMDnysQLnQ
			{
				// Token: 0x06001D65 RID: 7525 RVA: 0x00017441 File Offset: 0x00015641
				internal bool uQGXdLRQLSLVnkqfyLheEYtYXqeH(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.ytHlUWQjfyzBbtRiQhCieOFTEanO.DBmesHalKZopbMDhlYtgILNNnLEq) == this.vPzFxysaGbRAGbaABKsUJDESSkjX.categoryId;
				}

				// Token: 0x06001D66 RID: 7526 RVA: 0x00017461 File Offset: 0x00015661
				internal bool hAbPcMjHxKBvqvwlNZjbodaSjPYkA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.ytHlUWQjfyzBbtRiQhCieOFTEanO.DBmesHalKZopbMDhlYtgILNNnLEq) == this.vPzFxysaGbRAGbaABKsUJDESSkjX.layoutId;
				}

				// Token: 0x04001050 RID: 4176
				public UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm ytHlUWQjfyzBbtRiQhCieOFTEanO;

				// Token: 0x04001051 RID: 4177
				public ControllerMap_Editor vPzFxysaGbRAGbaABKsUJDESSkjX;
			}

			// Token: 0x02000270 RID: 624
			[CompilerGenerated]
			private sealed class VjbgGAgjKArvEAYbZCYIqicKbEZf
			{
				// Token: 0x06001D68 RID: 7528 RVA: 0x0007E314 File Offset: 0x0007C514
				internal InputMapCategory rbQQNEaThoHWvoHaDgIRbGkAUHIS(UserData<InputMapCategory>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone<InputMapCategory>(A_1.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					InputMapCategory inputMapCategory2;
					if (A_1.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						inputMapCategory2 = A_1.rzczbfRAMBOTnPryBRfzcijjCGnk;
					}
					else
					{
						this.FSsNgoVWfNnuhXnsNOmSypRdqpMd.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.AddMapCategory();
						inputMapCategory2 = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					int num = A_1.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(inputMapCategory2);
					if (A_1.DBmesHalKZopbMDhlYtgILNNnLEq == UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA.CVIfynQxeIGcpVpAexRaLlhZDmaiA.otherId)
					{
						this.GvHDdQvoBdOqXMitsHvnfMFkbDZeA.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					A_1.zzfBInqNRQXfeMeNfmKmoqoThELc[num] = inputMapCategory;
					return inputMapCategory;
				}

				// Token: 0x04001052 RID: 4178
				public List<int> GvHDdQvoBdOqXMitsHvnfMFkbDZeA;

				// Token: 0x04001053 RID: 4179
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA FSsNgoVWfNnuhXnsNOmSypRdqpMd;
			}

			// Token: 0x02000271 RID: 625
			[CompilerGenerated]
			private sealed class uoUTmveVZqSpLTqfqlxCoCeAaOsFA
			{
				// Token: 0x06001D6A RID: 7530 RVA: 0x00017481 File Offset: 0x00015681
				internal bool dIuPvXGMaUEgTCwqcfvEPyTfqkHbA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.RlhQIBjAIqzFCDUhCXIKDJKSHiqG.ytHlUWQjfyzBbtRiQhCieOFTEanO.DBmesHalKZopbMDhlYtgILNNnLEq) == this.pCUPsmnrjSMdOhCfMbHpikDLeeAS._actionId;
				}

				// Token: 0x04001054 RID: 4180
				public ActionElementMap pCUPsmnrjSMdOhCfMbHpikDLeeAS;

				// Token: 0x04001055 RID: 4181
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LNTmgwpDvTbuUYEwyPQMDnysQLnQ RlhQIBjAIqzFCDUhCXIKDJKSHiqG;
			}

			// Token: 0x02000272 RID: 626
			[CompilerGenerated]
			private sealed class ienQtBPAzPgfttbGKoOTmZgweQAi
			{
				// Token: 0x06001D6C RID: 7532 RVA: 0x0007E3A4 File Offset: 0x0007C5A4
				internal int quhFOxebICpdZwSVrNphSlyhVFNMA(ControllerMap_Editor A_1, IList<ControllerMap_Editor> A_2)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pkttyjeCElyxlbBkyOjNnNqkEmWBA pkttyjeCElyxlbBkyOjNnNqkEmWBA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pkttyjeCElyxlbBkyOjNnNqkEmWBA();
					pkttyjeCElyxlbBkyOjNnNqkEmWBA.LEwobMohzsaZmfDrjpretYStCufP = A_1;
					for (int i = 0; i < A_2.Count; i++)
					{
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> cfrdVEihCYaDpfghHudHhHHCmGcKd = this.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.cfrdVEihCYaDpfghHudHhHHCmGcKd;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match;
						if ((match = pkttyjeCElyxlbBkyOjNnNqkEmWBA.tuTlbHhCQzhboRCeOAURJoOrpIuh) == null)
						{
							match = (pkttyjeCElyxlbBkyOjNnNqkEmWBA.tuTlbHhCQzhboRCeOAURJoOrpIuh = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(pkttyjeCElyxlbBkyOjNnNqkEmWBA.xziZeOnZEHLrhbAoULylTmfCBBLg));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(match);
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> kvvRinfoHrQuwoFdGHXKNDqSvdLT = this.KvvRinfoHrQuwoFdGHXKNDqSvdLT;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match2;
						if ((match2 = pkttyjeCElyxlbBkyOjNnNqkEmWBA.ZfZgFPgPQakgNtfEAofsdmtRNcJTA) == null)
						{
							match2 = (pkttyjeCElyxlbBkyOjNnNqkEmWBA.ZfZgFPgPQakgNtfEAofsdmtRNcJTA = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(pkttyjeCElyxlbBkyOjNnNqkEmWBA.FAlGpUNlFMAaxODQBtOeAKYDNKfm));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = kvvRinfoHrQuwoFdGHXKNDqSvdLT.Find(match2);
						if (pXpGLbrhxqscZSyHiAaoHyHmQeA != null && pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].categoryId && pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null && pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D6D RID: 7533 RVA: 0x0007E468 File Offset: 0x0007C668
				internal ControllerMap_Editor xILVeWwGygnolyRmzltUcAPxDNHh(UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LQUDmgEyHoSnLdwnbvuTzDffXscu lqudmgEyHoSnLdwnbvuTzDffXscu = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LQUDmgEyHoSnLdwnbvuTzDffXscu();
					lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI = A_1;
					lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ = JsonTools.Clone<ControllerMap_Editor>(lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(lqudmgEyHoSnLdwnbvuTzDffXscu.lZUfoipgOtHdEVjzXnWkuSHuRYgU));
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = this.KvvRinfoHrQuwoFdGHXKNDqSvdLT.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(lqudmgEyHoSnLdwnbvuTzDffXscu.MlGFjHHnsPyXKdLhFrGufQJvkEgo));
					lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.categoryId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.layoutId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					for (int i = 0; i < lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.actionElementMaps.Count; i++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.HmSgWsAeTmNlgfdwRCjdGXeBJPwo hmSgWsAeTmNlgfdwRCjdGXeBJPwo = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.HmSgWsAeTmNlgfdwRCjdGXeBJPwo();
						hmSgWsAeTmNlgfdwRCjdGXeBJPwo.eiqGQBgZiUymdgUrixgpZUULhyxj = lqudmgEyHoSnLdwnbvuTzDffXscu;
						hmSgWsAeTmNlgfdwRCjdGXeBJPwo.oSOOATfRZXkKcmeFQfLCQKeNkFhM = hmSgWsAeTmNlgfdwRCjdGXeBJPwo.eiqGQBgZiUymdgUrixgpZUULhyxj.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.actionElementMaps[i];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = this.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.AvDryzYVKEtVoBauEwNaHBOpVGoC.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(hmSgWsAeTmNlgfdwRCjdGXeBJPwo.hkTUlaZZENZOsPZQgmRHpGubLJnK));
						hmSgWsAeTmNlgfdwRCjdGXeBJPwo.oSOOATfRZXkKcmeFQfLCQKeNkFhM._actionId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA3 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
						hmSgWsAeTmNlgfdwRCjdGXeBJPwo.oSOOATfRZXkKcmeFQfLCQKeNkFhM._actionCategoryId = ((this.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(hmSgWsAeTmNlgfdwRCjdGXeBJPwo.oSOOATfRZXkKcmeFQfLCQKeNkFhM._actionId) != null) ? this.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(hmSgWsAeTmNlgfdwRCjdGXeBJPwo.oSOOATfRZXkKcmeFQfLCQKeNkFhM._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						controllerMap_Editor = lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.rzczbfRAMBOTnPryBRfzcijjCGnk;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone<ControllerMap_Editor>(lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = new Func<ActionElementMap, IList<ActionElementMap>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.jahIKyqMFJDhxNNDzDCYEyGSVfDAA);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<ActionElementMap>(controllerMap_Editor.actionElementMaps, lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ = controllerMap_Editor2;
					}
					else
					{
						this.FNoTWZgGaaTlBNoMQBoMHHfdEwHk.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.CreateMouseMap(lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.categoryId, lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.layoutId);
						controllerMap_Editor = lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.zzfBInqNRQXfeMeNfmKmoqoThELc[lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.id = controllerMap_Editor.id;
					int index = lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(controllerMap_Editor);
					lqudmgEyHoSnLdwnbvuTzDffXscu.NiHRrczHcWVNIQCHBTIedOOfEuRI.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ;
					return lqudmgEyHoSnLdwnbvuTzDffXscu.CJqpDFuWKtHlmYGTdIVsTdbNWobJ;
				}

				// Token: 0x04001056 RID: 4182
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> KvvRinfoHrQuwoFdGHXKNDqSvdLT;

				// Token: 0x04001057 RID: 4183
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA FNoTWZgGaaTlBNoMQBoMHHfdEwHk;
			}

			// Token: 0x02000273 RID: 627
			[CompilerGenerated]
			private sealed class pkttyjeCElyxlbBkyOjNnNqkEmWBA
			{
				// Token: 0x06001D6F RID: 7535 RVA: 0x000174A6 File Offset: 0x000156A6
				internal bool xziZeOnZEHLrhbAoULylTmfCBBLg(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.LEwobMohzsaZmfDrjpretYStCufP.categoryId;
				}

				// Token: 0x06001D70 RID: 7536 RVA: 0x000174BB File Offset: 0x000156BB
				internal bool FAlGpUNlFMAaxODQBtOeAKYDNKfm(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.LEwobMohzsaZmfDrjpretYStCufP.layoutId;
				}

				// Token: 0x04001058 RID: 4184
				public ControllerMap_Editor LEwobMohzsaZmfDrjpretYStCufP;

				// Token: 0x04001059 RID: 4185
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> tuTlbHhCQzhboRCeOAURJoOrpIuh;

				// Token: 0x0400105A RID: 4186
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> ZfZgFPgPQakgNtfEAofsdmtRNcJTA;
			}

			// Token: 0x02000274 RID: 628
			[CompilerGenerated]
			private sealed class LQUDmgEyHoSnLdwnbvuTzDffXscu
			{
				// Token: 0x06001D72 RID: 7538 RVA: 0x000174D0 File Offset: 0x000156D0
				internal bool lZUfoipgOtHdEVjzXnWkuSHuRYgU(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.NiHRrczHcWVNIQCHBTIedOOfEuRI.DBmesHalKZopbMDhlYtgILNNnLEq) == this.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.categoryId;
				}

				// Token: 0x06001D73 RID: 7539 RVA: 0x000174F0 File Offset: 0x000156F0
				internal bool MlGFjHHnsPyXKdLhFrGufQJvkEgo(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.NiHRrczHcWVNIQCHBTIedOOfEuRI.DBmesHalKZopbMDhlYtgILNNnLEq) == this.CJqpDFuWKtHlmYGTdIVsTdbNWobJ.layoutId;
				}

				// Token: 0x0400105B RID: 4187
				public UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm NiHRrczHcWVNIQCHBTIedOOfEuRI;

				// Token: 0x0400105C RID: 4188
				public ControllerMap_Editor CJqpDFuWKtHlmYGTdIVsTdbNWobJ;
			}

			// Token: 0x02000275 RID: 629
			[CompilerGenerated]
			private sealed class HmSgWsAeTmNlgfdwRCjdGXeBJPwo
			{
				// Token: 0x06001D75 RID: 7541 RVA: 0x00017510 File Offset: 0x00015710
				internal bool hkTUlaZZENZOsPZQgmRHpGubLJnK(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.eiqGQBgZiUymdgUrixgpZUULhyxj.NiHRrczHcWVNIQCHBTIedOOfEuRI.DBmesHalKZopbMDhlYtgILNNnLEq) == this.oSOOATfRZXkKcmeFQfLCQKeNkFhM._actionId;
				}

				// Token: 0x0400105D RID: 4189
				public ActionElementMap oSOOATfRZXkKcmeFQfLCQKeNkFhM;

				// Token: 0x0400105E RID: 4190
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.LQUDmgEyHoSnLdwnbvuTzDffXscu eiqGQBgZiUymdgUrixgpZUULhyxj;
			}

			// Token: 0x02000276 RID: 630
			[CompilerGenerated]
			private sealed class PxMGlyygurZvpvKvyXZEhXJGulLI
			{
				// Token: 0x06001D77 RID: 7543 RVA: 0x0007E6E0 File Offset: 0x0007C8E0
				internal int JpdOtBQdLATtxfpHJQVVaLsTyMXw(ControllerMap_Editor A_1, IList<ControllerMap_Editor> A_2)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.SAXOQyukuBzpULioeIXWnkDPKATf saxoqyukuBzpULioeIXWnkDPKATf = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.SAXOQyukuBzpULioeIXWnkDPKATf();
					saxoqyukuBzpULioeIXWnkDPKATf.YyixxrodlveZFIcfjIbdfXUhDDak = A_1;
					for (int i = 0; i < A_2.Count; i++)
					{
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> cfrdVEihCYaDpfghHudHhHHCmGcKd = this.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.cfrdVEihCYaDpfghHudHhHHCmGcKd;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match;
						if ((match = saxoqyukuBzpULioeIXWnkDPKATf.IbEdqwIKrdVKPEsgeyeXHKutXfTU) == null)
						{
							match = (saxoqyukuBzpULioeIXWnkDPKATf.IbEdqwIKrdVKPEsgeyeXHKutXfTU = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(saxoqyukuBzpULioeIXWnkDPKATf.eFAylsIVbrItsCGbhgDqYWLQNNBu));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(match);
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> list = this.mtfZGqjTegObbKhbZMOXKwBsZac;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match2;
						if ((match2 = saxoqyukuBzpULioeIXWnkDPKATf.MrcvHYfVGnKREHraCAZYSyLubPjl) == null)
						{
							match2 = (saxoqyukuBzpULioeIXWnkDPKATf.MrcvHYfVGnKREHraCAZYSyLubPjl = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(saxoqyukuBzpULioeIXWnkDPKATf.CpNvwZFEcsoHTFJmlvoGTlQnFRFy));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = list.Find(match2);
						if (saxoqyukuBzpULioeIXWnkDPKATf.YyixxrodlveZFIcfjIbdfXUhDDak.hardwareGuid == A_2[i].hardwareGuid && pXpGLbrhxqscZSyHiAaoHyHmQeA != null && pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].categoryId && pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null && pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D78 RID: 7544 RVA: 0x0007E7C0 File Offset: 0x0007C9C0
				internal ControllerMap_Editor rXLtxPoypdfKMMmNkbQQiydSwHaNA(UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.KmGtdlNQvJwWecQBkJdbIhFPDhBI kmGtdlNQvJwWecQBkJdbIhFPDhBI = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.KmGtdlNQvJwWecQBkJdbIhFPDhBI();
					kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA = A_1;
					kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA = JsonTools.Clone<ControllerMap_Editor>(kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(kmGtdlNQvJwWecQBkJdbIhFPDhBI.lHCYWhPVONhNPOslCwBxkvTjJrTH));
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = this.mtfZGqjTegObbKhbZMOXKwBsZac.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(kmGtdlNQvJwWecQBkJdbIhFPDhBI.nhlCiWVvofspDadGrYztgchGffSIA));
					kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.categoryId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.layoutId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					for (int i = 0; i < kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.actionElementMaps.Count; i++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.MWVGHFjsKHMARIGvCKTRvbFwBVvab mwvghfjsKHMARIGvCKTRvbFwBVvab = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.MWVGHFjsKHMARIGvCKTRvbFwBVvab();
						mwvghfjsKHMARIGvCKTRvbFwBVvab.RfEtovjOpKOpuchicIiaxBlERfRD = kmGtdlNQvJwWecQBkJdbIhFPDhBI;
						mwvghfjsKHMARIGvCKTRvbFwBVvab.GgZIfpHIVWbMLAdeGUALBBDavqBte = mwvghfjsKHMARIGvCKTRvbFwBVvab.RfEtovjOpKOpuchicIiaxBlERfRD.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.actionElementMaps[i];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = this.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.AvDryzYVKEtVoBauEwNaHBOpVGoC.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(mwvghfjsKHMARIGvCKTRvbFwBVvab.VkXVImpYQWvCutaVqMWNPekKgNreA));
						mwvghfjsKHMARIGvCKTRvbFwBVvab.GgZIfpHIVWbMLAdeGUALBBDavqBte._actionId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA3 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
						mwvghfjsKHMARIGvCKTRvbFwBVvab.GgZIfpHIVWbMLAdeGUALBBDavqBte._actionCategoryId = ((this.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(mwvghfjsKHMARIGvCKTRvbFwBVvab.GgZIfpHIVWbMLAdeGUALBBDavqBte._actionId) != null) ? this.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(mwvghfjsKHMARIGvCKTRvbFwBVvab.GgZIfpHIVWbMLAdeGUALBBDavqBte._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						controllerMap_Editor = kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.rzczbfRAMBOTnPryBRfzcijjCGnk;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone<ControllerMap_Editor>(kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = new Func<ActionElementMap, IList<ActionElementMap>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.UKQWrnXlBhPkAsOPzGcufRkmoFZDA);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<ActionElementMap>(controllerMap_Editor.actionElementMaps, kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA = controllerMap_Editor2;
					}
					else
					{
						this.nBQeiACNYMIPAGRHmwEoDdDJVAXiA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.CreateJoystickMap(kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.categoryId, kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.hardwareGuid, kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.layoutId);
						controllerMap_Editor = kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.zzfBInqNRQXfeMeNfmKmoqoThELc[kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.id = controllerMap_Editor.id;
					int index = kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(controllerMap_Editor);
					kmGtdlNQvJwWecQBkJdbIhFPDhBI.leTJrGEMRavRyHVeUnqwJfYdEFVcA.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA;
					return kmGtdlNQvJwWecQBkJdbIhFPDhBI.QSMYAEDaFucAfjvqnUJbgpMMfGlyA;
				}

				// Token: 0x0400105F RID: 4191
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> mtfZGqjTegObbKhbZMOXKwBsZac;

				// Token: 0x04001060 RID: 4192
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA nBQeiACNYMIPAGRHmwEoDdDJVAXiA;
			}

			// Token: 0x02000277 RID: 631
			[CompilerGenerated]
			private sealed class SAXOQyukuBzpULioeIXWnkDPKATf
			{
				// Token: 0x06001D7A RID: 7546 RVA: 0x00017535 File Offset: 0x00015735
				internal bool eFAylsIVbrItsCGbhgDqYWLQNNBu(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.YyixxrodlveZFIcfjIbdfXUhDDak.categoryId;
				}

				// Token: 0x06001D7B RID: 7547 RVA: 0x0001754A File Offset: 0x0001574A
				internal bool CpNvwZFEcsoHTFJmlvoGTlQnFRFy(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.YyixxrodlveZFIcfjIbdfXUhDDak.layoutId;
				}

				// Token: 0x04001061 RID: 4193
				public ControllerMap_Editor YyixxrodlveZFIcfjIbdfXUhDDak;

				// Token: 0x04001062 RID: 4194
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> IbEdqwIKrdVKPEsgeyeXHKutXfTU;

				// Token: 0x04001063 RID: 4195
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> MrcvHYfVGnKREHraCAZYSyLubPjl;
			}

			// Token: 0x02000278 RID: 632
			[CompilerGenerated]
			private sealed class KmGtdlNQvJwWecQBkJdbIhFPDhBI
			{
				// Token: 0x06001D7D RID: 7549 RVA: 0x0001755F File Offset: 0x0001575F
				internal bool lHCYWhPVONhNPOslCwBxkvTjJrTH(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.leTJrGEMRavRyHVeUnqwJfYdEFVcA.DBmesHalKZopbMDhlYtgILNNnLEq) == this.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.categoryId;
				}

				// Token: 0x06001D7E RID: 7550 RVA: 0x0001757F File Offset: 0x0001577F
				internal bool nhlCiWVvofspDadGrYztgchGffSIA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.leTJrGEMRavRyHVeUnqwJfYdEFVcA.DBmesHalKZopbMDhlYtgILNNnLEq) == this.QSMYAEDaFucAfjvqnUJbgpMMfGlyA.layoutId;
				}

				// Token: 0x04001064 RID: 4196
				public UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm leTJrGEMRavRyHVeUnqwJfYdEFVcA;

				// Token: 0x04001065 RID: 4197
				public ControllerMap_Editor QSMYAEDaFucAfjvqnUJbgpMMfGlyA;
			}

			// Token: 0x02000279 RID: 633
			[CompilerGenerated]
			private sealed class MWVGHFjsKHMARIGvCKTRvbFwBVvab
			{
				// Token: 0x06001D80 RID: 7552 RVA: 0x0001759F File Offset: 0x0001579F
				internal bool VkXVImpYQWvCutaVqMWNPekKgNreA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.RfEtovjOpKOpuchicIiaxBlERfRD.leTJrGEMRavRyHVeUnqwJfYdEFVcA.DBmesHalKZopbMDhlYtgILNNnLEq) == this.GgZIfpHIVWbMLAdeGUALBBDavqBte._actionId;
				}

				// Token: 0x04001066 RID: 4198
				public ActionElementMap GgZIfpHIVWbMLAdeGUALBBDavqBte;

				// Token: 0x04001067 RID: 4199
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.KmGtdlNQvJwWecQBkJdbIhFPDhBI RfEtovjOpKOpuchicIiaxBlERfRD;
			}

			// Token: 0x0200027A RID: 634
			[CompilerGenerated]
			private sealed class SpwsyPjYkYOIqSnDjbyIilNuxufqA
			{
				// Token: 0x06001D82 RID: 7554 RVA: 0x0007EA40 File Offset: 0x0007CC40
				internal int dRmBfrhFasDDnkreEgvGGwTMEczTA(ControllerMap_Editor A_1, IList<ControllerMap_Editor> A_2)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cicPbejQhYaeDWnuHcDSKARMUThq cicPbejQhYaeDWnuHcDSKARMUThq = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cicPbejQhYaeDWnuHcDSKARMUThq();
					cicPbejQhYaeDWnuHcDSKARMUThq.YpTJdWmBsmZowJXLaKvXrmxLjONm = A_1;
					for (int i = 0; i < A_2.Count; i++)
					{
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> tvPCaQWeioXSUByvUkUibabLcwst = this.mWbfcjShVGqOAIASidTegYbTWjeUA.TvPCaQWeioXSUByvUkUibabLcwst;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match;
						if ((match = cicPbejQhYaeDWnuHcDSKARMUThq.qRYZCIsrLNWybODcMeZdTgzhbIDX) == null)
						{
							match = (cicPbejQhYaeDWnuHcDSKARMUThq.qRYZCIsrLNWybODcMeZdTgzhbIDX = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(cicPbejQhYaeDWnuHcDSKARMUThq.UHQbIgoPgkeyaPMmgluxyroGgioN));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = tvPCaQWeioXSUByvUkUibabLcwst.Find(match);
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> cfrdVEihCYaDpfghHudHhHHCmGcKd = this.mWbfcjShVGqOAIASidTegYbTWjeUA.cfrdVEihCYaDpfghHudHhHHCmGcKd;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match2;
						if ((match2 = cicPbejQhYaeDWnuHcDSKARMUThq.sYxSgTChNUgDFbTRJTvgOpBqftuO) == null)
						{
							match2 = (cicPbejQhYaeDWnuHcDSKARMUThq.sYxSgTChNUgDFbTRJTvgOpBqftuO = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(cicPbejQhYaeDWnuHcDSKARMUThq.eqnCtXIIKtOmnAGzWHsaeunxURKeb));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(match2);
						List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> mwxrrOkKHliaHewvMcyylfcuMwAiA = this.MWxrrOkKHliaHewvMcyylfcuMwAiA;
						Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> match3;
						if ((match3 = cicPbejQhYaeDWnuHcDSKARMUThq.wHzevPbRJhEHJaRVKdadMoBmmZSGc) == null)
						{
							match3 = (cicPbejQhYaeDWnuHcDSKARMUThq.wHzevPbRJhEHJaRVKdadMoBmmZSGc = new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(cicPbejQhYaeDWnuHcDSKARMUThq.vYngTiCXdXgdrFzTRaKQxMgBLsjyA));
						}
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = mwxrrOkKHliaHewvMcyylfcuMwAiA.Find(match3);
						if (pXpGLbrhxqscZSyHiAaoHyHmQeA != null && pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].customControllerUid && pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null && pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].categoryId && pXpGLbrhxqscZSyHiAaoHyHmQeA3 != null && pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA == A_2[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001D83 RID: 7555 RVA: 0x0007EB50 File Offset: 0x0007CD50
				internal ControllerMap_Editor RJQdLRskwjbRymoudVQBYtmpryEm(UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm A_1)
				{
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.JgwRwgfWnsHTXCxUhIMaCtHDmBto jgwRwgfWnsHTXCxUhIMaCtHDmBto = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.JgwRwgfWnsHTXCxUhIMaCtHDmBto();
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb = A_1;
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb = JsonTools.Clone<ControllerMap_Editor>(jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.JufxgvcLPxbOZixRxOlOuQRnzOaz);
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA = this.mWbfcjShVGqOAIASidTegYbTWjeUA.TvPCaQWeioXSUByvUkUibabLcwst.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(jgwRwgfWnsHTXCxUhIMaCtHDmBto.fjOudMctBUCJyqBopZEcTVPvgZQU));
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA2 = this.mWbfcjShVGqOAIASidTegYbTWjeUA.cfrdVEihCYaDpfghHudHhHHCmGcKd.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(jgwRwgfWnsHTXCxUhIMaCtHDmBto.plkKiDXbvEhuhojueRoefluqdsBw));
					UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA3 = this.MWxrrOkKHliaHewvMcyylfcuMwAiA.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(jgwRwgfWnsHTXCxUhIMaCtHDmBto.rMxFileRaKQshWNPCOsrOSNcciTjA));
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.customControllerUid = ((pXpGLbrhxqscZSyHiAaoHyHmQeA != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.categoryId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA2 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA2.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.layoutId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA3 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA3.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
					for (int i = 0; i < jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.actionElementMaps.Count; i++)
					{
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.SeZCSAGXPynNWFgBFfFjXXgirYYcA seZCSAGXPynNWFgBFfFjXXgirYYcA = new UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.SeZCSAGXPynNWFgBFfFjXXgirYYcA();
						seZCSAGXPynNWFgBFfFjXXgirYYcA.XGEcIEHCLAtfuVXPBJeZoyioynjfA = jgwRwgfWnsHTXCxUhIMaCtHDmBto;
						seZCSAGXPynNWFgBFfFjXXgirYYcA.uZHgCqzangvOOXFZhnzWLJukKNIg = seZCSAGXPynNWFgBFfFjXXgirYYcA.XGEcIEHCLAtfuVXPBJeZoyioynjfA.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.actionElementMaps[i];
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA pXpGLbrhxqscZSyHiAaoHyHmQeA4 = this.mWbfcjShVGqOAIASidTegYbTWjeUA.AvDryzYVKEtVoBauEwNaHBOpVGoC.Find(new Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA>(seZCSAGXPynNWFgBFfFjXXgirYYcA.QgNisoBiTPgnFuDStvIRdYZJrOkI));
						seZCSAGXPynNWFgBFfFjXXgirYYcA.uZHgCqzangvOOXFZhnzWLJukKNIg._actionId = ((pXpGLbrhxqscZSyHiAaoHyHmQeA4 != null) ? pXpGLbrhxqscZSyHiAaoHyHmQeA4.wwFTVpPSBzdkLrIFZGPvCREGTptkA : -1);
						seZCSAGXPynNWFgBFfFjXXgirYYcA.uZHgCqzangvOOXFZhnzWLJukKNIg._actionCategoryId = ((this.mWbfcjShVGqOAIASidTegYbTWjeUA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(seZCSAGXPynNWFgBFfFjXXgirYYcA.uZHgCqzangvOOXFZhnzWLJukKNIg._actionId) != null) ? this.mWbfcjShVGqOAIASidTegYbTWjeUA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.GetActionById(seZCSAGXPynNWFgBFfFjXXgirYYcA.uZHgCqzangvOOXFZhnzWLJukKNIg._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.zUSxvdfmlSBzMevcHBnPatsuNanjb)
					{
						controllerMap_Editor = jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.rzczbfRAMBOTnPryBRfzcijjCGnk;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone<ControllerMap_Editor>(jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = new Func<ActionElementMap, IList<ActionElementMap>, int>(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.cxQmOlHuLfWTTLrNwkDSQTkDvNlU.<>9.IgrbaFifomqgqYSPMOswjuYZXNCS);
						UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.avuVkvQFILgIfEGrxGDwxeMERIqs<ActionElementMap>(controllerMap_Editor.actionElementMaps, jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb = controllerMap_Editor2;
					}
					else
					{
						this.mWbfcjShVGqOAIASidTegYbTWjeUA.RpEWMMfBCwcgrHPFxcyGgckEqVDlb.CreateCustomControllerMap(jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.categoryId, jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.customControllerUid, jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.layoutId);
						controllerMap_Editor = jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.zzfBInqNRQXfeMeNfmKmoqoThELc[jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.zzfBInqNRQXfeMeNfmKmoqoThELc.Count - 1];
					}
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.id = controllerMap_Editor.id;
					int index = jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.zzfBInqNRQXfeMeNfmKmoqoThELc.IndexOf(controllerMap_Editor);
					jgwRwgfWnsHTXCxUhIMaCtHDmBto.bPDCVcfqYpBXCjGQVymEtcxblSbGb.zzfBInqNRQXfeMeNfmKmoqoThELc[index] = jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb;
					return jgwRwgfWnsHTXCxUhIMaCtHDmBto.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb;
				}

				// Token: 0x04001068 RID: 4200
				public List<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> MWxrrOkKHliaHewvMcyylfcuMwAiA;

				// Token: 0x04001069 RID: 4201
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.rHCmKvaRAfqsRlJBihaSKpaTMOsmA mWbfcjShVGqOAIASidTegYbTWjeUA;
			}

			// Token: 0x0200027B RID: 635
			[CompilerGenerated]
			private sealed class kOBvWvxhrTJxKgpCtOwmckTgeYpB
			{
				// Token: 0x06001D85 RID: 7557 RVA: 0x000175C4 File Offset: 0x000157C4
				internal bool hCYIHpVyzIERTSmfcRqDTXKlKuVr(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.CrXJBbSzGyjdMqVIDuIhVeZOMGUW;
				}

				// Token: 0x0400106A RID: 4202
				public int CrXJBbSzGyjdMqVIDuIhVeZOMGUW;
			}

			// Token: 0x0200027C RID: 636
			[CompilerGenerated]
			private sealed class cicPbejQhYaeDWnuHcDSKARMUThq
			{
				// Token: 0x06001D87 RID: 7559 RVA: 0x000175D4 File Offset: 0x000157D4
				internal bool UHQbIgoPgkeyaPMmgluxyroGgioN(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.YpTJdWmBsmZowJXLaKvXrmxLjONm.customControllerUid;
				}

				// Token: 0x06001D88 RID: 7560 RVA: 0x000175E9 File Offset: 0x000157E9
				internal bool eqnCtXIIKtOmnAGzWHsaeunxURKeb(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.YpTJdWmBsmZowJXLaKvXrmxLjONm.categoryId;
				}

				// Token: 0x06001D89 RID: 7561 RVA: 0x000175FE File Offset: 0x000157FE
				internal bool vYngTiCXdXgdrFzTRaKQxMgBLsjyA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.hKjjFvxQBmljyopHwiFLYAlFcKBi == this.YpTJdWmBsmZowJXLaKvXrmxLjONm.layoutId;
				}

				// Token: 0x0400106B RID: 4203
				public ControllerMap_Editor YpTJdWmBsmZowJXLaKvXrmxLjONm;

				// Token: 0x0400106C RID: 4204
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> qRYZCIsrLNWybODcMeZdTgzhbIDX;

				// Token: 0x0400106D RID: 4205
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> sYxSgTChNUgDFbTRJTvgOpBqftuO;

				// Token: 0x0400106E RID: 4206
				public Predicate<UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA> wHzevPbRJhEHJaRVKdadMoBmmZSGc;
			}

			// Token: 0x0200027D RID: 637
			[CompilerGenerated]
			private sealed class JgwRwgfWnsHTXCxUhIMaCtHDmBto
			{
				// Token: 0x06001D8B RID: 7563 RVA: 0x00017613 File Offset: 0x00015813
				internal bool fjOudMctBUCJyqBopZEcTVPvgZQU(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.bPDCVcfqYpBXCjGQVymEtcxblSbGb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.customControllerUid;
				}

				// Token: 0x06001D8C RID: 7564 RVA: 0x00017633 File Offset: 0x00015833
				internal bool plkKiDXbvEhuhojueRoefluqdsBw(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.bPDCVcfqYpBXCjGQVymEtcxblSbGb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.categoryId;
				}

				// Token: 0x06001D8D RID: 7565 RVA: 0x00017653 File Offset: 0x00015853
				internal bool rMxFileRaKQshWNPCOsrOSNcciTjA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.bPDCVcfqYpBXCjGQVymEtcxblSbGb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.kcEDrNeXCGbSpfhaGUdwWZmrAGRtb.layoutId;
				}

				// Token: 0x0400106F RID: 4207
				public UserData<ControllerMap_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm bPDCVcfqYpBXCjGQVymEtcxblSbGb;

				// Token: 0x04001070 RID: 4208
				public ControllerMap_Editor kcEDrNeXCGbSpfhaGUdwWZmrAGRtb;
			}

			// Token: 0x0200027E RID: 638
			[CompilerGenerated]
			private sealed class SeZCSAGXPynNWFgBFfFjXXgirYYcA
			{
				// Token: 0x06001D8F RID: 7567 RVA: 0x00017673 File Offset: 0x00015873
				internal bool QgNisoBiTPgnFuDStvIRdYZJrOkI(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.XGEcIEHCLAtfuVXPBJeZoyioynjfA.bPDCVcfqYpBXCjGQVymEtcxblSbGb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.uZHgCqzangvOOXFZhnzWLJukKNIg._actionId;
				}

				// Token: 0x04001071 RID: 4209
				public ActionElementMap uZHgCqzangvOOXFZhnzWLJukKNIg;

				// Token: 0x04001072 RID: 4210
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.JgwRwgfWnsHTXCxUhIMaCtHDmBto XGEcIEHCLAtfuVXPBJeZoyioynjfA;
			}

			// Token: 0x0200027F RID: 639
			[CompilerGenerated]
			private sealed class sRTEZFgspikHXeYcoCzsLtLWnvfv
			{
				// Token: 0x04001073 RID: 4211
				public UserData<ControllerMapLayoutManager_RuleSet_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm gRRrSoBawKEglpFbjhRHiuFnEvzcb;
			}

			// Token: 0x02000280 RID: 640
			[CompilerGenerated]
			private sealed class VViHlCeJpItWcAygbleCnIiBqOEF
			{
				// Token: 0x06001D92 RID: 7570 RVA: 0x00017698 File Offset: 0x00015898
				internal bool nhBSPGmNZjldGxvbFKyykwPeJftg(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.ZnuXegecQWvkPVIyWNoINeldeXKx.gRRrSoBawKEglpFbjhRHiuFnEvzcb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.lbtObxRtgHDJDUrsQQqmvsVWKPrO;
				}

				// Token: 0x04001074 RID: 4212
				public int lbtObxRtgHDJDUrsQQqmvsVWKPrO;

				// Token: 0x04001075 RID: 4213
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.sRTEZFgspikHXeYcoCzsLtLWnvfv ZnuXegecQWvkPVIyWNoINeldeXKx;
			}

			// Token: 0x02000281 RID: 641
			[CompilerGenerated]
			private sealed class nnoVyqJHZpXLcqBmajJtpNtuFMZCA
			{
				// Token: 0x06001D94 RID: 7572 RVA: 0x000176B8 File Offset: 0x000158B8
				internal bool YTrLUYUJoNSSTYASEMnzuTEMLmBl(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.qTKyjrOkXsingAkqSfbyjOYUhmHfb.gRRrSoBawKEglpFbjhRHiuFnEvzcb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.hzTcsGECrlbwNNdvumGQVuFHAsENA;
				}

				// Token: 0x04001076 RID: 4214
				public int hzTcsGECrlbwNNdvumGQVuFHAsENA;

				// Token: 0x04001077 RID: 4215
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.sRTEZFgspikHXeYcoCzsLtLWnvfv qTKyjrOkXsingAkqSfbyjOYUhmHfb;
			}

			// Token: 0x02000282 RID: 642
			[CompilerGenerated]
			private sealed class clvjxmXfUVEnyhhYXsePrHPxBQeh
			{
				// Token: 0x06001D96 RID: 7574 RVA: 0x000176D8 File Offset: 0x000158D8
				internal bool ludDeRabsbXUigCoKkeEujfZpryN(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.yTEiOrDygMMCuDLKClsLjsMTXvNg.gRRrSoBawKEglpFbjhRHiuFnEvzcb.DBmesHalKZopbMDhlYtgILNNnLEq) == this.GKbUujvfAHkNSyGHQkfcGRqttCGQ;
				}

				// Token: 0x04001078 RID: 4216
				public int GKbUujvfAHkNSyGHQkfcGRqttCGQ;

				// Token: 0x04001079 RID: 4217
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.sRTEZFgspikHXeYcoCzsLtLWnvfv yTEiOrDygMMCuDLKClsLjsMTXvNg;
			}

			// Token: 0x02000283 RID: 643
			[CompilerGenerated]
			private sealed class zGtNVVqzGlwgkYcSFbuXRekhkLSy
			{
				// Token: 0x0400107A RID: 4218
				public UserData<ControllerMapEnabler_RuleSet_Editor>.PNzhXEZBquWTWutuvqUzeSAXzfsF.qhqAqJjrgQjQZqLevMnzCLQkxnwm YAVoDHBLKUePqbyuXqnoFraVNORzA;
			}

			// Token: 0x02000284 RID: 644
			[CompilerGenerated]
			private sealed class LTyAwvrfvXBSBFQGfkOBDlqcUELD
			{
				// Token: 0x06001D99 RID: 7577 RVA: 0x000176F8 File Offset: 0x000158F8
				internal bool bRmIQkSNhAxOkMNlsejjIIQXgfPpA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.lZWFyIeGFLCviaUTAZKtkXJpRDhhB(this.kdAeYcDKLheGhxSuAAaZLfNjaeZTA.YAVoDHBLKUePqbyuXqnoFraVNORzA.DBmesHalKZopbMDhlYtgILNNnLEq) == this.JYjGxdeUEdgJsQTuViMPmhoKeMeE;
				}

				// Token: 0x0400107B RID: 4219
				public int JYjGxdeUEdgJsQTuViMPmhoKeMeE;

				// Token: 0x0400107C RID: 4220
				public UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.zGtNVVqzGlwgkYcSFbuXRekhkLSy kdAeYcDKLheGhxSuAAaZLfNjaeZTA;
			}

			// Token: 0x02000285 RID: 645
			[CompilerGenerated]
			private sealed class QnjOChpkQkHZssBbKkLYBrghCxHo<\u0001> where \u0001 : class
			{
				// Token: 0x0400107D RID: 4221
				public Func<\u0001, int> AoLkIccofZPPYxloMXlhIPSvegXD;
			}

			// Token: 0x02000286 RID: 646
			[CompilerGenerated]
			private sealed class gORtcsTwKuoPdNsXvDwqSJyoUTBR<\u0001> where \u0001 : class
			{
				// Token: 0x06001D9C RID: 7580 RVA: 0x00017718 File Offset: 0x00015918
				internal bool JBgWCQlEkLeEQKhVqYFZhdSTmafTA(UserData.PNzhXEZBquWTWutuvqUzeSAXzfsF.pXpGLbrhxqscZSyHiAaoHyHmQeA A_1)
				{
					return A_1.wwFTVpPSBzdkLrIFZGPvCREGTptkA == this.LfxSXYeiIyJRMEnLNgNayGiryWmQ.AoLkIccofZPPYxloMXlhIPSvegXD(this.maNLyEtCsRmQKWfQDbzVRlzaltqN);
				}

				// Token: 0x0400107E RID: 4222
				public \u0001 maNLyEtCsRmQKWfQDbzVRlzaltqN;

				// Token: 0x0400107F RID: 4223
				public UserData<\u0001>.PNzhXEZBquWTWutuvqUzeSAXzfsF.QnjOChpkQkHZssBbKkLYBrghCxHo LfxSXYeiIyJRMEnLNgNayGiryWmQ;
			}
		}

		// Token: 0x02000287 RID: 647
		[CompilerGenerated]
		[Serializable]
		private sealed class JOVEKPeAtJnWiDtuhksiqcCWWrJRb
		{
			// Token: 0x06001D9F RID: 7583 RVA: 0x0007EE08 File Offset: 0x0007D008
			internal void XTvZGUxXoaYHPTZIDXAiVCBZEnuS(List<Player_Editor.Mapping> A_1, int A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				for (int i = A_1.Count - 1; i >= 0; i--)
				{
					if (A_1[i] == null || A_1[i].categoryId == A_2)
					{
						A_1.RemoveAt(i);
					}
				}
			}

			// Token: 0x06001DA0 RID: 7584 RVA: 0x0007EE4C File Offset: 0x0007D04C
			internal void xFUUVZyNdwifPGuMcnFkWiJqJPmn(List<Player_Editor.Mapping> A_1, int A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				for (int i = A_1.Count - 1; i >= 0; i--)
				{
					if (A_1[i] == null || A_1[i].layoutId == A_2)
					{
						A_1.RemoveAt(i);
					}
				}
			}

			// Token: 0x06001DA1 RID: 7585 RVA: 0x0007EE4C File Offset: 0x0007D04C
			internal void bvBRalnEzfQrNLXfmPpKlJAHSONO(List<Player_Editor.Mapping> A_1, int A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				for (int i = A_1.Count - 1; i >= 0; i--)
				{
					if (A_1[i] == null || A_1[i].layoutId == A_2)
					{
						A_1.RemoveAt(i);
					}
				}
			}

			// Token: 0x06001DA2 RID: 7586 RVA: 0x0007EE4C File Offset: 0x0007D04C
			internal void MCloqWwEAkzDxQJsDYeUJoSqGbMO(List<Player_Editor.Mapping> A_1, int A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				for (int i = A_1.Count - 1; i >= 0; i--)
				{
					if (A_1[i] == null || A_1[i].layoutId == A_2)
					{
						A_1.RemoveAt(i);
					}
				}
			}

			// Token: 0x06001DA3 RID: 7587 RVA: 0x0007EE4C File Offset: 0x0007D04C
			internal void uclABiiYTezhQiDlxgGYPevfjWzl(List<Player_Editor.Mapping> A_1, int A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				for (int i = A_1.Count - 1; i >= 0; i--)
				{
					if (A_1[i] == null || A_1[i].layoutId == A_2)
					{
						A_1.RemoveAt(i);
					}
				}
			}

			// Token: 0x04001080 RID: 4224
			public static readonly UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb <>9 = new UserData.JOVEKPeAtJnWiDtuhksiqcCWWrJRb();

			// Token: 0x04001081 RID: 4225
			public static Action<List<Player_Editor.Mapping>, int> <>9__199_0;

			// Token: 0x04001082 RID: 4226
			public static Action<List<Player_Editor.Mapping>, int> <>9__217_0;

			// Token: 0x04001083 RID: 4227
			public static Action<List<Player_Editor.Mapping>, int> <>9__233_0;

			// Token: 0x04001084 RID: 4228
			public static Action<List<Player_Editor.Mapping>, int> <>9__249_0;

			// Token: 0x04001085 RID: 4229
			public static Action<List<Player_Editor.Mapping>, int> <>9__265_0;
		}

		// Token: 0x02000288 RID: 648
		[CompilerGenerated]
		private sealed class wMGmJUEQwtZiBsCPMhzIqdbaCrax
		{
			// Token: 0x06001DA5 RID: 7589 RVA: 0x0007EE90 File Offset: 0x0007D090
			internal int ZyvqeTHRpufZKCZPaSVpfAjPvGVK(ControllerMap_Editor A_1, ControllerMap_Editor A_2)
			{
				UserData.yBuzDtvKIkMremKSjAHmBVbjgWrT yBuzDtvKIkMremKSjAHmBVbjgWrT = new UserData.yBuzDtvKIkMremKSjAHmBVbjgWrT();
				yBuzDtvKIkMremKSjAHmBVbjgWrT.hCKAwkGatZPyhRETVtHKIiOqZSft = A_1;
				yBuzDtvKIkMremKSjAHmBVbjgWrT.lpTULyYPDoxsRpiOjnWRjbGHFgihA = A_2;
				int num = this.dIXEcscVNoRLWUgEeKfMgLTNgjHdA.FindIndex(new Predicate<InputLayout>(yBuzDtvKIkMremKSjAHmBVbjgWrT.VghrEZKfCBeHmoxgyxlzTNdEUBCG));
				int num2 = this.dIXEcscVNoRLWUgEeKfMgLTNgjHdA.FindIndex(new Predicate<InputLayout>(yBuzDtvKIkMremKSjAHmBVbjgWrT.RFZflhfSDjNDUDQdaZlBhKVRdyiJ));
				if (num > num2)
				{
					return 1;
				}
				if (num < num2)
				{
					return -1;
				}
				return 0;
			}

			// Token: 0x04001086 RID: 4230
			public List<InputLayout> dIXEcscVNoRLWUgEeKfMgLTNgjHdA;
		}

		// Token: 0x02000289 RID: 649
		[CompilerGenerated]
		private sealed class yBuzDtvKIkMremKSjAHmBVbjgWrT
		{
			// Token: 0x06001DA7 RID: 7591 RVA: 0x00017744 File Offset: 0x00015944
			internal bool VghrEZKfCBeHmoxgyxlzTNdEUBCG(InputLayout A_1)
			{
				return A_1.id == this.hCKAwkGatZPyhRETVtHKIiOqZSft.id;
			}

			// Token: 0x06001DA8 RID: 7592 RVA: 0x00017759 File Offset: 0x00015959
			internal bool RFZflhfSDjNDUDQdaZlBhKVRdyiJ(InputLayout A_1)
			{
				return A_1.id == this.lpTULyYPDoxsRpiOjnWRjbGHFgihA.id;
			}

			// Token: 0x04001087 RID: 4231
			public ControllerMap_Editor hCKAwkGatZPyhRETVtHKIiOqZSft;

			// Token: 0x04001088 RID: 4232
			public ControllerMap_Editor lpTULyYPDoxsRpiOjnWRjbGHFgihA;
		}
	}
}
