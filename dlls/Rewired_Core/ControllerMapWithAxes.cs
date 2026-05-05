using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	// Token: 0x02000137 RID: 311
	public abstract class ControllerMapWithAxes : ControllerMap
	{
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000CCE RID: 3278 RVA: 0x0000C4DA File Offset: 0x0000A6DA
		public int axisMapCount
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return 0;
				}
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
				{
					return 0;
				}
				return this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x0000C50C File Offset: 0x0000A70C
		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return this.xcBtvOIHgUgdNvcBsEYbbqnzhlXT;
			}
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x0000C533 File Offset: 0x0000A733
		public ControllerMapWithAxes()
		{
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv = new AList<ActionElementMap>();
			this.xcBtvOIHgUgdNvcBsEYbbqnzhlXT = new ReadOnlyCollection<ActionElementMap>(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv);
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x0004E970 File Offset: 0x0004CB70
		public ControllerMapWithAxes(ControllerMapWithAxes A_1) : base(A_1)
		{
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv = new AList<ActionElementMap>();
			this.xcBtvOIHgUgdNvcBsEYbbqnzhlXT = new ReadOnlyCollection<ActionElementMap>(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv);
			if (A_1.NPTJTzsgJvByVNbqbLCIVGkpLnwv != null)
			{
				int count = A_1.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
				for (int i = 0; i < count; i++)
				{
					this.BtpSFEObJwHdhzcFODQoNiIiqjZc(new ActionElementMap(A_1.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]));
				}
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0004E9D8 File Offset: 0x0004CBD8
		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return false;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x0004EA44 File Offset: 0x0004CC44
		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			base.BakeElementMap(actionElementMap);
			this.BtpSFEObJwHdhzcFODQoNiIiqjZc(actionElementMap);
			result = actionElementMap;
			return true;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x0004EAB4 File Offset: 0x0004CCB4
		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = this.GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(elementMap._elementType))
			{
				this.DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				this.BtpSFEObJwHdhzcFODQoNiIiqjZc(elementMap);
			}
			if (this.MZNxBrdFPXOouOFQkFNlrSzcKBkl(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.LEAbhiCauElIrGssAmMeAWNDgZgEd(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			base.BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x0004EB5C File Offset: 0x0004CD5C
		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = this.MZNxBrdFPXOouOFQkFNlrSzcKBkl(elementMapId);
			if (num < 0)
			{
				return false;
			}
			this.tMRzKcvsMaUxtatZCAAqAwTSeJpP(elementMapId, num);
			return true;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x0000C557 File Offset: 0x0000A757
		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			return this.DeleteElementMapsWithAction(ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false));
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x0000C586 File Offset: 0x0000A786
		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | this.DeleteAxisMapsWithAction(actionId);
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x0004EBA8 File Offset: 0x0004CDA8
		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return null;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == elementMapId)
				{
					return this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				}
			}
			return null;
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0000BD87 File Offset: 0x00009F87
		public override ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return this.GetFirstElementMapWithAction(actionId, false);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0004EC24 File Offset: 0x0004CE24
		public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			ActionElementMap firstElementMapWithAction = base.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
			if (firstElementMapWithAction != null)
			{
				return firstElementMapWithAction;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0004EC9C File Offset: 0x0004CE9C
		internal virtual ActionElementMap KCzDkoejwmprxKCISdmdhzFLACAhb(Predicate<ActionElementMap> A_1, bool A_2)
		{
			ActionElementMap actionElementMap = base.rDLgZuiPnayTmkrLkGvuWxrcXFAo(A_1, A_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return this.wuvqvBKZWwDiRpQOwpJTdCREOfej(A_1, A_2);
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0000C5B2 File Offset: 0x0000A7B2
		internal virtual int NWPwSORnQyDWmigNiUUErxcgYkqr(Predicate<ActionElementMap> A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			return base.rxumvJUWAAwEeLGFVYlnIfIHxfPS(A_1, A_2, A_3, A_4) + this.dMMDkEhmWMRzGbohQawfjVwfBBTIb(A_1, A_2, A_3, true);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0000C5CA File Offset: 0x0000A7CA
		public override void ClearElementMaps()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return;
			}
			base.ClearElementMaps();
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Clear();
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0004ECC0 File Offset: 0x0004CEC0
		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null || index < 0 || index >= this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count)
			{
				return null;
			}
			return this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[index];
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0000C5F7 File Offset: 0x0000A7F7
		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			return this.GetAxisMaps(false);
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0004ED10 File Offset: 0x0004CF10
		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray<ActionElementMap>(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv);
			}
			int axisMapCount = this.axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(axisMapCount);
			for (int i = 0; i < axisMapCount; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0000C61F File Offset: 0x0000A81F
		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.oBojyFxHRWDOAWqMXIRhurYKfHSm(skipDisabledMaps, results, false);
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x0004ED88 File Offset: 0x0004CF88
		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return this.GetAxisMapsWithAction(inputAction.id);
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0000C645 File Offset: 0x0000A845
		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return this.GetAxisMapsWithAction(actionId, false);
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0004EDD8 File Offset: 0x0004CFD8
		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return this.GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0004EE28 File Offset: 0x0004D028
		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int axisMapCount = this.axisMapCount;
			if (axisMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			for (int i = 0; i < axisMapCount; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			for (int j = 0; j < axisMapCount; j++)
			{
				ActionElementMap actionElementMap2 = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					array[num2] = actionElementMap2;
					num2++;
				}
			}
			return array;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x0004EEFC File Offset: 0x0004D0FC
		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear<ActionElementMap>(results);
				return 0;
			}
			return this.GetAxisMapsWithAction(inputAction.id, results);
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0000C64F File Offset: 0x0000A84F
		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return this.GetAxisMapsWithAction(actionId, false, results);
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x0004EF4C File Offset: 0x0004D14C
		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear<ActionElementMap>(results);
				return 0;
			}
			return this.GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x0000C65A File Offset: 0x0000A85A
		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.JRQagtmKBSJLHIKaMzysyjcOtXlI(actionId, skipDisabledMaps, results, false);
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0004EF9C File Offset: 0x0004D19C
		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.AxisMapsWithAction(actionId);
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x0000C681 File Offset: 0x0000A881
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return this.AxisMapsWithAction(actionId, false);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0004EFDC File Offset: 0x0004D1DC
		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0000C68B File Offset: 0x0000A88B
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (actionId < 0)
			{
				yield break;
			}
			foreach (ActionElementMap actionElementMap in this.AxisMaps)
			{
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					yield return actionElementMap;
				}
			}
			IEnumerator<ActionElementMap> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x0000C6A9 File Offset: 0x0000A8A9
		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			return this.GetFirstAxisMapWithAction(actionId, false);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x0004F000 File Offset: 0x0004D200
		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstAxisMapWithAction(actionId);
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x0004F03C File Offset: 0x0004D23C
		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> axisMaps = this.AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x0004F0A4 File Offset: 0x0004D2A4
		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x0000C6CE File Offset: 0x0000A8CE
		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			return this.wuvqvBKZWwDiRpQOwpJTdCREOfej(predicate, false);
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0004F0E4 File Offset: 0x0004D2E4
		internal ActionElementMap wuvqvBKZWwDiRpQOwpJTdCREOfej(Predicate<ActionElementMap> A_1, bool A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> axisMaps = this.AxisMaps;
			int axisMapCount = this.axisMapCount;
			try
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!A_2 || actionElementMap.enabled) && A_1(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstAxisMapMatch", exception);
			}
			return null;
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x0000C6F3 File Offset: 0x0000A8F3
		public int GetAxisMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.dMMDkEhmWMRzGbohQawfjVwfBBTIb(predicate, false, results, false);
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x0004F160 File Offset: 0x0004D360
		internal int dMMDkEhmWMRzGbohQawfjVwfBBTIb(Predicate<ActionElementMap> A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (A_3 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!A_4)
			{
				A_3.Clear();
			}
			else
			{
				num = A_3.Count;
			}
			IList<ActionElementMap> axisMaps = this.AxisMaps;
			int axisMapCount = this.axisMapCount;
			try
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!A_2 || actionElementMap.enabled) && A_1(actionElementMap))
					{
						A_3.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetAxisMapMatches", exception);
			}
			return A_3.Count - num;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x0004F20C File Offset: 0x0004D40C
		public void ForEachAxisMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return;
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachAxisMapMatch", exception);
			}
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x0000C71A File Offset: 0x0000A91A
		public bool DeleteAxisMapsWithAction(string actionName)
		{
			return this.DeleteAxisMapsWithAction(ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false));
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x0004F2A4 File Offset: 0x0004D4A4
		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int axisMapCount = this.axisMapCount;
			if (axisMapCount == 0)
			{
				return false;
			}
			bool result = false;
			for (int i = axisMapCount - 1; i >= 0; i--)
			{
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i] != null && this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._actionId == actionId)
				{
					this.tMRzKcvsMaUxtatZCAAqAwTSeJpP(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x0004F32C File Offset: 0x0004D52C
		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int num = 0;
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA != state)
				{
					actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = state;
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x0004F390 File Offset: 0x0004D590
		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(controllerMap, skipDisabledMaps))
			{
				return true;
			}
			ControllerMapWithAxes controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMapWithAxes._enabled))
			{
				return false;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count2; j++)
					{
						ActionElementMap actionElementMap2 = axisMaps[j];
						if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x0004F474 File Offset: 0x0004D674
		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (actionElementMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return false;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return false;
			}
			for (int i = 0; i < this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count; i++)
			{
				ActionElementMap actionElementMap2 = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x0004F508 File Offset: 0x0004D708
		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (base.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && !this._enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return false;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x0000C72E File Offset: 0x0000A92E
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (controllerMap == null)
			{
				yield break;
			}
			foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.lSJmFVQSqaPXOMiCTOjnwPNvOtmD(controllerMap, skipDisabledMaps))
			{
				yield return elementAssignmentConflictInfo;
			}
			IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
			ControllerMapWithAxes controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				yield break;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMapWithAxes._enabled))
			{
				yield break;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				yield break;
			}
			int count = axisMaps.Count;
			int num;
			for (int i = 0; i < this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count; i = num + 1)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count; j = num + 1)
					{
						ActionElementMap actionElementMap2 = axisMaps[j];
						if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							yield return new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(this._categoryId).userAssignable, -1, this._controllerType, this._controllerId, this._id, actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						}
						num = j;
					}
					actionElementMap = null;
				}
				num = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x0000C74C File Offset: 0x0000A94C
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (actionElementMap == null)
			{
				yield break;
			}
			foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.UyEHdlhzOPsLPrFcfkMnqGarARgdA(actionElementMap, skipDisabledMaps))
			{
				yield return elementAssignmentConflictInfo;
			}
			IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				yield break;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count; i = num + 1)
			{
				ActionElementMap actionElementMap2 = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					yield return new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(this._categoryId).userAssignable, -1, this._controllerType, this._controllerId, this._id, actionElementMap2.pGMbotKVdjNowDvSSfgThIWDmLSHB, actionElementMap2._actionId, actionElementMap2._elementType, actionElementMap2._elementIdentifierId, actionElementMap2.keyCode, actionElementMap2.modifierKeyFlags);
				}
				num = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x0000C76A File Offset: 0x0000A96A
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.GCXLSiozzdjOqRIpgMXufFmbSbsl(conflictCheck, skipDisabledMaps))
			{
				yield return elementAssignmentConflictInfo;
			}
			IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
			if (skipDisabledMaps && !this._enabled)
			{
				yield break;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				yield break;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num;
			for (int i = 0; i < this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count; i = num + 1)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					yield return new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(this._categoryId).userAssignable, -1, this._controllerType, this._controllerId, this._id, actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
				}
				num = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x0004F5BC File Offset: 0x0004D7BC
		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			ControllerMapWithAxes controllerMapWithAxes = controllerMap as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				return num;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			int count2 = axisMaps.Count;
			for (int i = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count2; j++)
					{
						ActionElementMap actionElementMap2 = axisMaps[j];
						if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							this.tMRzKcvsMaUxtatZCAAqAwTSeJpP(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x0004F6DC File Offset: 0x0004D8DC
		public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return num;
			}
			for (int i = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap2 = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					this.tMRzKcvsMaUxtatZCAAqAwTSeJpP(actionElementMap2.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x0004F79C File Offset: 0x0004D99C
		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !this._enabled)
			{
				return num;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return num;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					this.tMRzKcvsMaUxtatZCAAqAwTSeJpP(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0004F880 File Offset: 0x0004DA80
		internal virtual int FlAKtrNMOzDYRXzIHmupLqyPCwRy(ControllerMap A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			int num = base.oYfeUUNDbOWfjygZOQmLKPGJhOMf(A_1, A_2, A_3, A_4);
			ControllerMapWithAxes controllerMapWithAxes = A_1 as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				return num;
			}
			if (A_2 && (!this._enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count2; j++)
					{
						ActionElementMap actionElementMap2 = axisMaps[j];
						if ((!A_2 || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							actionElementMap.enabled = false;
							if (A_3 != null)
							{
								A_3.Add(actionElementMap);
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x0004F978 File Offset: 0x0004DB78
		internal virtual int pXCZvSIulWOQMwPGwYCTPWnnHJAs(ActionElementMap A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			int num = base.iYObeNDzWBShOCtJrwtrYgvLbQKU(A_1, A_2, A_3, A_4);
			if (A_1 == null)
			{
				return num;
			}
			if (A_2 && (!this._enabled || !A_1.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return num;
			}
			if (A_1.elementIdentifierId < 0)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int axisMapCount = this.axisMapCount;
			for (int i = 0; i < axisMapCount; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && A_1.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					if (A_3 != null)
					{
						A_3.Add(actionElementMap);
					}
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0004FA24 File Offset: 0x0004DC24
		internal virtual int AeuFOEymzADJdgjfHhuHiwlMmtSg(ElementAssignmentConflictCheck A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			int num = base.CgqGVjNDzTEOuNcIRWhWJMfOvNov(A_1, A_2, A_3, A_4);
			if (A_2 && !this._enabled)
			{
				return num;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return num;
			}
			if (A_1.elementAssignmentType != ElementAssignmentType.FullAxis && A_1.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			ElementAssignment elementAssignment = A_1.ToElementAssignment();
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != A_1.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					if (A_3 != null)
					{
						A_3.Add(actionElementMap);
					}
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0004FAF8 File Offset: 0x0004DCF8
		public string[] GetAxisNames()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<string>.array;
			}
			int axisMapCount = this.axisMapCount;
			if (axisMapCount == 0)
			{
				return null;
			}
			string[] array = new string[axisMapCount];
			for (int i = 0; i < axisMapCount; i++)
			{
				array[i] = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].elementIdentifierName;
			}
			return array;
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000D07 RID: 3335 RVA: 0x0000C788 File Offset: 0x0000A988
		internal AList<ActionElementMap> ltItJCWElJbkLlrjlhWQQWOGEYDq
		{
			get
			{
				return (AList<ActionElementMap>)this.NPTJTzsgJvByVNbqbLCIVGkpLnwv;
			}
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0004FB58 File Offset: 0x0004DD58
		internal virtual bool lYvuyZKmGqNYUrGYMcNXaAcVlaBB(ActionElementMap A_1)
		{
			if (base.SNSempsrfLhzSBkFeitYdlebhkwZB(A_1))
			{
				return true;
			}
			ControllerElementType elementType = A_1._elementType;
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(elementType))
			{
				return false;
			}
			this.BtpSFEObJwHdhzcFODQoNiIiqjZc(A_1);
			return true;
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x0004FB8C File Offset: 0x0004DD8C
		internal virtual int RcpxtNpSOIaoTaqOVElPWMnRZMRQ(List<ActionElementMap> A_1, bool A_2)
		{
			base.ajdiJhXMqrwIHOHDQzktaWNSJglO(A_1, A_2);
			int count = A_1.Count;
			int count2 = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!A_2 || this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					A_1.Add(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]);
				}
			}
			return A_1.Count - count;
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x0004FBF4 File Offset: 0x0004DDF4
		internal virtual ActionElementMap dClOkliFRJBUgeXdJEyesjlXlynq(int A_1, int A_2, ControllerElementType A_3)
		{
			ActionElementMap actionElementMap = base.JSNovEDxowSIZyOYTBaVACuKDKGrA(A_1, A_2, A_3);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(A_3))
			{
				return null;
			}
			int num = this.tXTvBSOLiOuwLtuHfWPMESYdpEre(A_1, A_2, A_3);
			if (num < 0)
			{
				return null;
			}
			if (A_3 == ControllerElementType.Axis)
			{
				return this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[num];
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0004FC40 File Offset: 0x0004DE40
		internal virtual int tRLmGmMvXyoEiMCETmCltcwRlYKE(int A_1, List<ActionElementMap> A_2, bool A_3)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = A_3 ? A_2.Count : 0;
			base.kJgoMsDubnHnkLcahHbmlVFwtyRu(A_1, A_2, A_3);
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return A_2.Count - num;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._elementIdentifierId == A_1)
				{
					A_2.Add(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]);
				}
			}
			return A_2.Count - num;
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x0004FCCC File Offset: 0x0004DECC
		internal virtual bool bsiwcWgoZedAWTsbRhteHgwNLiXA(int A_1, int A_2, ControllerElementType A_3)
		{
			if (base.fyvAooZAakpcxpgDeAyPkGufyIJ(A_1, A_2, A_3))
			{
				return true;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(A_3))
			{
				return false;
			}
			if (A_3 == ControllerElementType.Axis)
			{
				int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._elementIdentifierId == A_1 && this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._actionId == A_2)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0004FD40 File Offset: 0x0004DF40
		internal virtual int hYmEshZETdkLqyagbjUAHUgWmKKF(int A_1, int A_2, ControllerElementType A_3)
		{
			int num = base.tXTvBSOLiOuwLtuHfWPMESYdpEre(A_1, A_2, A_3);
			if (num >= 0)
			{
				return num;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(A_3))
			{
				return -1;
			}
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return -1;
			}
			if (A_3 == ControllerElementType.Axis)
			{
				int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._elementIdentifierId == A_1 && this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._actionId == A_2)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0004FDC0 File Offset: 0x0004DFC0
		internal int MZNxBrdFPXOouOFQkFNlrSzcKBkl(int A_1)
		{
			if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv == null)
			{
				return -1;
			}
			int count = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == A_1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0004FE08 File Offset: 0x0004E008
		internal int oBojyFxHRWDOAWqMXIRhurYKfHSm(bool A_1, List<ActionElementMap> A_2, bool A_3)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_3)
			{
				A_2.Clear();
			}
			int axisMapCount = this.axisMapCount;
			int num = 0;
			for (int i = 0; i < axisMapCount; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (!A_1 || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					A_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0004FE68 File Offset: 0x0004E068
		internal int JRQagtmKBSJLHIKaMzysyjcOtXlI(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_3 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_4)
			{
				A_3.Clear();
			}
			if (A_1 < 0)
			{
				return 0;
			}
			int axisMapCount = this.axisMapCount;
			int num = 0;
			for (int i = 0; i < axisMapCount; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap._actionId == A_1 && (!A_2 || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					A_3.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0004FED8 File Offset: 0x0004E0D8
		internal virtual int MpcAJlFEchzogcSmmHeUZTAHrRmW(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			int num = base.SKUXJwoIaunBEdjJKstnsFfqeDRj(A_1, A_2, A_3, A_4);
			if (A_1 < 0)
			{
				return num;
			}
			int axisMapCount = this.axisMapCount;
			for (int i = 0; i < axisMapCount; i++)
			{
				ActionElementMap actionElementMap = this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				if (actionElementMap._actionId == A_1 && (!A_2 || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					A_3.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x0004FF38 File Offset: 0x0004E138
		internal virtual ActionElementMap tALNnNnksNxYdixauOgYIDUSYuuS(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4, out bool A_5)
		{
			ActionElementMap actionElementMap = base.VWwHPcWBNEZnnVHhltRXgvEuUTBR(A_1, A_2, A_3, A_4, out A_5);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (A_5)
			{
				return null;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(A_1.elementType))
			{
				return null;
			}
			int axisMapCount = this.axisMapCount;
			int elementIdentifierId = A_1.elementIdentifierId;
			for (int i = 0; i < axisMapCount; i++)
			{
				if ((!A_2 || this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._actionId == A_3) && (!A_4 || this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].IsTarget(A_1))
				{
					return this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i];
				}
			}
			return null;
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0004FFDC File Offset: 0x0004E1DC
		internal virtual int xpYivWVBikiRvcJzZxOSHBBsUcsIA(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4, List<ActionElementMap> A_5, bool A_6, out bool A_7)
		{
			int num = base.qZOynvlardfOgSmhUcYADceZXgiK(A_1, A_2, A_3, A_4, A_5, A_6, out A_7);
			if (A_7)
			{
				return num;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(A_1.elementType))
			{
				return num;
			}
			int axisMapCount = this.axisMapCount;
			int elementIdentifierId = A_1.elementIdentifierId;
			for (int i = 0; i < axisMapCount; i++)
			{
				if ((!A_2 || this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]._actionId == A_3) && (!A_4 || this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].IsTarget(A_1))
				{
					A_5.Add(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i]);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0000C795 File Offset: 0x0000A995
		internal virtual bool sjqtfPSlOhGNUAJjQljaGxQDKUgib(ActionElementMap A_1)
		{
			if (base.FOkrqztDUJcOGmSIWcjPCVfiSuzt(A_1))
			{
				return true;
			}
			if (A_1 == null)
			{
				return false;
			}
			if (!this.IJXOOguDBJfgvdSHtCMcBuUduvFt(A_1._elementType))
			{
				return false;
			}
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Add(A_1);
			base.DgHXiydIOzSDUuugcvoLKbGdIIKbA(A_1);
			return true;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0000C7CB File Offset: 0x0000A9CB
		private bool IJXOOguDBJfgvdSHtCMcBuUduvFt(ControllerElementType A_1)
		{
			return A_1 == ControllerElementType.Axis;
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x0000C7D3 File Offset: 0x0000A9D3
		private void tMRzKcvsMaUxtatZCAAqAwTSeJpP(int A_1, int A_2)
		{
			base.LUFETllQnJZuBIzKSzSieYuqsseE(A_1);
			if (A_2 < 0 || A_2 >= this.axisMapCount)
			{
				return;
			}
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.RemoveAt(A_2);
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0000C7F6 File Offset: 0x0000A9F6
		private void BtpSFEObJwHdhzcFODQoNiIiqjZc(ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv.Add(A_1);
			base.DgHXiydIOzSDUuugcvoLKbGdIIKbA(A_1);
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0000C80F File Offset: 0x0000AA0F
		private void DnMTOQzuDyhFEYtRLQsBOdambQFP(ActionElementMap A_1, int A_2)
		{
			if (A_1 == null)
			{
				return;
			}
			if (A_2 < 0 || A_2 >= this.axisMapCount)
			{
				return;
			}
			base.huRetGmoSIwuSDDmterzMcvLecLR(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[A_2].pGMbotKVdjNowDvSSfgThIWDmLSHB, A_1);
			this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[A_2] = A_1;
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x00050088 File Offset: 0x0004E288
		internal virtual void YRJnXypkTELAcOVIpcccuUzgMuII(SerializedObject A_1)
		{
			base.daBkbOQuLTcpvLQDGvFyctuSeSjD(A_1);
			int axisMapCount = this.axisMapCount;
			List<object> list = new List<object>();
			A_1.Add<List<object>>("axisMaps", list, SerializedObject.FieldOptions.None);
			for (int i = 0; i < axisMapCount; i++)
			{
				if (this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i] != null)
				{
					list.Add(this.NPTJTzsgJvByVNbqbLCIVGkpLnwv[i].rsOAdCguLNDFfxcMNarlfYblvkOrA());
				}
			}
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x000500E8 File Offset: 0x0004E2E8
		internal virtual bool QIFnmGSAnBimkPfACacbQQLgmEoM(SerializedObject A_1)
		{
			bool flag = base.CJWrYTJPVnzPlgWTnRyPLpdTJbjD(A_1);
			if (!flag)
			{
				this.ClearElementMaps();
				flag = true;
			}
			SerializedObject serializedObject = null;
			if (A_1.TryGetDeserializedValueByRef<SerializedObject>("axisMaps", ref serializedObject) && serializedObject != null)
			{
				for (int i = 0; i < serializedObject.count; i++)
				{
					SerializedObject serializedObject2;
					if (serializedObject.TryGetDeserializedValue<SerializedObject>(i, out serializedObject2) || serializedObject2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.jDXBmuWueOfuvhElQmjIrsZoRVLz(serializedObject2);
						if (ActionElementMap.rsKLuCqJSjqWHzNTrOWmcUvmtQFp(actionElementMap))
						{
							this.BtpSFEObJwHdhzcFODQoNiIiqjZc(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x0000C848 File Offset: 0x0000AA48
		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> lSJmFVQSqaPXOMiCTOjnwPNvOtmD(ControllerMap A_1, bool A_2)
		{
			return base.ElementAssignmentConflicts(A_1, A_2);
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0000C852 File Offset: 0x0000AA52
		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> UyEHdlhzOPsLPrFcfkMnqGarARgdA(ActionElementMap A_1, bool A_2)
		{
			return base.ElementAssignmentConflicts(A_1, A_2);
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0000C85C File Offset: 0x0000AA5C
		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> GCXLSiozzdjOqRIpgMXufFmbSbsl(ElementAssignmentConflictCheck A_1, bool A_2)
		{
			return base.ElementAssignmentConflicts(A_1, A_2);
		}

		// Token: 0x04000833 RID: 2099
		private readonly IList<ActionElementMap> NPTJTzsgJvByVNbqbLCIVGkpLnwv;

		// Token: 0x04000834 RID: 2100
		private readonly ReadOnlyCollection<ActionElementMap> xcBtvOIHgUgdNvcBsEYbbqnzhlXT;
	}
}
