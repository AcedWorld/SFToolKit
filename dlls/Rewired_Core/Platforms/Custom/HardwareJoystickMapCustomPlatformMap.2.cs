using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000234 RID: 564
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public abstract class HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> : HardwareJoystickMapCustomPlatformMap where TMatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
	{
		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06001A00 RID: 6656 RVA: 0x000153E3 File Offset: 0x000135E3
		internal override bool hasData
		{
			get
			{
				return base.hasData || (this.matchingCriteria != null && this.matchingCriteria.hasData);
			}
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06001A01 RID: 6657 RVA: 0x00015413 File Offset: 0x00013613
		internal override bool disabled
		{
			get
			{
				return this.matchingCriteria != null && this.matchingCriteria.disabled;
			}
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06001A02 RID: 6658 RVA: 0x00015434 File Offset: 0x00013634
		internal override bool isAllowed
		{
			get
			{
				return base.isAllowed && this.matchingCriteria != null && this.matchingCriteria.isAllowed;
			}
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x00072378 File Offset: 0x00070578
		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (this.matchingCriteria != null && this.matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			if (base.hasVariants)
			{
				IList<HardwareJoystickMap.Platform> variants = this.GetVariants();
				for (int i = 0; i < variants.Count; i++)
				{
					int num;
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out num, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x0001545F File Offset: 0x0001365F
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

		// Token: 0x06001A05 RID: 6661 RVA: 0x0001546F File Offset: 0x0001366F
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

		// Token: 0x06001A06 RID: 6662 RVA: 0x000723F8 File Offset: 0x000705F8
		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			using (IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> enumerator = this.IterateAxes().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (((HardwareJoystickMapCustomPlatformMap.Axis)enumerator.Current).elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
			}
			using (IEnumerator<HardwareJoystickMap.Platform_Custom.Button> enumerator2 = this.IterateButtons().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (((HardwareJoystickMapCustomPlatformMap.Button)enumerator2.Current).elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001A07 RID: 6663 RVA: 0x00072498 File Offset: 0x00070698
		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[this.assignedButtonCount];
			axes = new int[this.assignedAxisCount];
			int num = 0;
			foreach (HardwareJoystickMap.Platform_Custom.Button button in this.IterateButtons())
			{
				HardwareJoystickMapCustomPlatformMap.Button button2 = (HardwareJoystickMapCustomPlatformMap.Button)button;
				buttons[num] = button2.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (HardwareJoystickMap.Platform_Custom.Axis axis in this.IterateAxes())
			{
				HardwareJoystickMapCustomPlatformMap.Axis axis2 = (HardwareJoystickMapCustomPlatformMap.Axis)axis;
				axes[num] = axis2.elementIdentifier;
				num++;
			}
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x0007255C File Offset: 0x0007075C
		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			HardwareJoystickMapCustomPlatformMap.Axis[] axes_orig = base.Axes_orig;
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
					if (base.Axes_orig[i].calibrateAxis)
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

		// Token: 0x06001A09 RID: 6665 RVA: 0x00072668 File Offset: 0x00070868
		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (base.Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[base.Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[base.Axes_orig.Length];
			for (int i = 0; i < base.Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone<HardwareAxisInfo>(base.Axes_orig[i].axisInfo, true);
				if (base.Axes_orig[i].sourceType == 1 || base.Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = base.Axes_orig[i].sourceAxisRange;
				}
				else
				{
					if (base.Axes_orig[i].sourceType != 0)
					{
						throw new Exception();
					}
					axisRanges[i] = AxisRange.Full;
				}
			}
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x0007271C File Offset: 0x0007091C
		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (base.Buttons_orig == null)
			{
				return;
			}
			buttonInfos = new HardwareButtonInfo[base.Buttons_orig.Length];
			for (int i = 0; i < base.Buttons_orig.Length; i++)
			{
				buttonInfos[i] = MiscTools.DeepClone<HardwareButtonInfo>(base.Buttons_orig[i].buttonInfo, true);
			}
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x0001547F File Offset: 0x0001367F
		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (this.elements == null)
			{
				return ControllerElementType.Axis;
			}
			return this.elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x00015497 File Offset: 0x00013697
		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (this.elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return this.elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x00072770 File Offset: 0x00070970
		internal override void CopyVars(HardwareJoystickMap.Platform destination)
		{
			base.CopyVars(destination);
			HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> hardwareJoystickMapCustomPlatformMap = destination as HardwareJoystickMapCustomPlatformMap<TMatchingCriteria>;
			if (hardwareJoystickMapCustomPlatformMap == null)
			{
				return;
			}
			hardwareJoystickMapCustomPlatformMap.matchingCriteria = MiscTools.DeepClone<TMatchingCriteria>(this.matchingCriteria);
		}

		// Token: 0x04000EC6 RID: 3782
		[Tooltip("User-defined matching criteria. Determines whether this platform map matches to a particular controller.")]
		public TMatchingCriteria matchingCriteria;
	}
}
