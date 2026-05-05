using System;
using System.Collections.Generic;
using System.Text;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

// Token: 0x02000454 RID: 1108
internal static class pIxAfPCGFQRFBOwQPqPHNpZroQXw
{
	// Token: 0x06002C48 RID: 11336 RVA: 0x00021FD5 File Offset: 0x000201D5
	internal static string JFMSjqZqDaHCEDpMBlJfyqpAuSbBA(ControllerType A_0)
	{
		return pIxAfPCGFQRFBOwQPqPHNpZroQXw.VVzvgRjswVUhRPhwkGPCJHMkDQkL(aIgzybSrpFHIbiUgoNExgtkiaahP.OdziduRxdrBAnKCQEaAHjFHZSGBeb(A_0));
	}

	// Token: 0x06002C49 RID: 11337 RVA: 0x00021FE2 File Offset: 0x000201E2
	internal static string VVzvgRjswVUhRPhwkGPCJHMkDQkL(qIdXPWaZDFjemNjbsLrswVoVIvUh A_0)
	{
		switch (A_0)
		{
		case qIdXPWaZDFjemNjbsLrswVoVIvUh.Joystick:
		case qIdXPWaZDFjemNjbsLrswVoVIvUh.Keyboard:
		case qIdXPWaZDFjemNjbsLrswVoVIvUh.Mouse:
			return "controller";
		case qIdXPWaZDFjemNjbsLrswVoVIvUh.CustomController:
			return "controller/custom";
		case qIdXPWaZDFjemNjbsLrswVoVIvUh.ControllerTemplate:
			return "controller/template";
		default:
			throw new NotImplementedException();
		}
	}

	// Token: 0x06002C4A RID: 11338 RVA: 0x0009E290 File Offset: 0x0009C490
	internal static bool JqFGZncCphSFliYDavQsBeqFIlgbA(LocalizedString A_0, string A_1, string A_2, string A_3, uint A_4, DeviceLocalizationInfo A_5, qIdXPWaZDFjemNjbsLrswVoVIvUh A_6, int A_7, AxisRange A_8, int A_9, out string A_10)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			A_10 = A_3;
			return false;
		}
		bool result = false;
		uint dependenciesVersion = 0U;
		bool flag = !string.IsNullOrEmpty(A_2);
		StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
		if (A_5 != null && A_5.parentKeys != null)
		{
			for (int i = 0; i < A_5.parentKeys.Count; i++)
			{
				if (!string.IsNullOrEmpty(A_5.parentKeys[i]))
				{
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(A_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_5.parentKeys[i]);
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
					if (LocalizationManager.TryLocalizeString(A_0, sharedStringBuilder.ToString(), A_4, dependenciesVersion, out A_10))
					{
						result = true;
						goto IL_185;
					}
				}
			}
		}
		if (A_6 != qIdXPWaZDFjemNjbsLrswVoVIvUh.Keyboard)
		{
			sharedStringBuilder.Length = 0;
			sharedStringBuilder.Append("controller/element");
			LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
			if (LocalizationManager.TryLocalizeString(A_0, sharedStringBuilder.ToString(), A_4, dependenciesVersion, out A_10))
			{
				result = true;
				goto IL_185;
			}
		}
		if (A_6 == qIdXPWaZDFjemNjbsLrswVoVIvUh.Joystick && A_7 >= 0 && A_5 != null && A_5.controllerTemplateGuids != null)
		{
			for (int j = 0; j < A_5.controllerTemplateGuids.Count; j++)
			{
				string text;
				string value;
				if (pIxAfPCGFQRFBOwQPqPHNpZroQXw.kSJCmhcUtEtWWbRZfbxlDgwjdopUA(A_5.guid, A_5.controllerTemplateGuids[j], A_7, A_8, A_9, out text, out value) && !string.IsNullOrEmpty(value))
				{
					sharedStringBuilder.Length = 0;
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, "controller/template");
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, value);
					if (LocalizationManager.TryLocalizeString(A_0, sharedStringBuilder.ToString(), A_4, dependenciesVersion, out A_10))
					{
						result = true;
						goto IL_185;
					}
				}
			}
		}
		A_10 = A_3;
		IL_185:
		A_0.cachedValue = A_10;
		return result;
	}

	// Token: 0x06002C4B RID: 11339 RVA: 0x0009E42C File Offset: 0x0009C62C
	public static bool kSJCmhcUtEtWWbRZfbxlDgwjdopUA(Guid A_0, Guid A_1, int A_2, AxisRange A_3, int A_4, out string A_5, out string A_6)
	{
		IHardwareControllerTemplateMap_Internal hardwareControllerTemplateMap_Internal = ReInput.UKCRsGlOBNUIwmXiQxEalDQxdbAF(A_1) as IHardwareControllerTemplateMap_Internal;
		if (hardwareControllerTemplateMap_Internal == null)
		{
			A_6 = null;
			A_5 = null;
			return false;
		}
		using (TempListPool.TList<HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv> tlist = TempListPool.GetTList<HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv>())
		{
			List<HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv> list = tlist.list;
			ReInput.mapping.OuotgntRrVAFpOsdsfOdexABAWGj(A_1, A_0, A_2, list);
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv vNUinRqnjfTkAskqXltQLMfPUMUv = list[i];
				IControllerTemplateElementIdentifier templateElementIdentifierById = hardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(vNUinRqnjfTkAskqXltQLMfPUMUv.UIHXARWEFIUQvHamiuIUzSVIaBFb);
				if (templateElementIdentifierById != null)
				{
					if (A_4 >= 0)
					{
						A_5 = templateElementIdentifierById.GetSpecialElementKey(A_4);
					}
					else if (!vNUinRqnjfTkAskqXltQLMfPUMUv.tgGVJPmoMdsLlKFiRFfKEnLphuSt || (vNUinRqnjfTkAskqXltQLMfPUMUv.gxqDjvURKgAphrnHLBgXhhAevmWo == A_2 && vNUinRqnjfTkAskqXltQLMfPUMUv.zeCfOGzHrAArWDHkKnYIkfgqsJXSA == A_2))
					{
						switch (A_3)
						{
						case AxisRange.Full:
							A_5 = templateElementIdentifierById.key;
							break;
						case AxisRange.Positive:
							A_5 = templateElementIdentifierById.positiveKey;
							break;
						case AxisRange.Negative:
							A_5 = templateElementIdentifierById.negativeKey;
							break;
						default:
							throw new NotImplementedException();
						}
					}
					else
					{
						A_5 = ((vNUinRqnjfTkAskqXltQLMfPUMUv.gxqDjvURKgAphrnHLBgXhhAevmWo == A_2) ? templateElementIdentifierById.positiveKey : templateElementIdentifierById.negativeKey);
					}
					if (!string.IsNullOrEmpty(A_5))
					{
						A_6 = ((!string.IsNullOrEmpty(hardwareControllerTemplateMap_Internal.typeKey)) ? LocalizationManager.AppendToKeyAsPath(hardwareControllerTemplateMap_Internal.typeKey, A_5) : null);
						return true;
					}
				}
			}
		}
		A_6 = null;
		A_5 = null;
		return false;
	}

	// Token: 0x06002C4C RID: 11340 RVA: 0x0009E598 File Offset: 0x0009C798
	internal static LocalizationManager.GetAndUpdateLocalizedStringResultFlags YhyCZcwKukjhsGtlmpYBaTIHhRuF(LocalizedString A_0, string A_1, string A_2, string A_3, DeviceLocalizationInfo A_4, qIdXPWaZDFjemNjbsLrswVoVIvUh A_5, int A_6, AxisRange A_7, int A_8, out string A_9)
	{
		if (!LocalizationManager.isEnabled)
		{
			A_9 = A_3;
			return LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
		}
		bool flag;
		LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags;
		if (LocalizationManager.TryGetCachedLocalizedString(A_0, A_3, LocalizationManager.version, 0U, out flag, out A_9))
		{
			getAndUpdateLocalizedStringResultFlags = LocalizationManager.GetAndUpdateLocalizedStringResultFlags.IsCachedValue;
		}
		else
		{
			getAndUpdateLocalizedStringResultFlags = LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
		}
		if (!A_0.hasCachedValue || flag)
		{
			getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed;
			if (pIxAfPCGFQRFBOwQPqPHNpZroQXw.JqFGZncCphSFliYDavQsBeqFIlgbA(A_0, A_1, A_2, A_3, LocalizationManager.version, A_4, A_5, A_6, A_7, A_8, out A_9))
			{
				getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized;
				getAndUpdateLocalizedStringResultFlags &= (LocalizationManager.GetAndUpdateLocalizedStringResultFlags)(-2);
			}
			else
			{
				getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
			}
		}
		return getAndUpdateLocalizedStringResultFlags;
	}
}
