using System;
using System.Text;
using Rewired;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;

// Token: 0x0200046E RID: 1134
internal static class RUpmbvJtGrVJvbLCXAeFqKfaIGHDA
{
	// Token: 0x06002D28 RID: 11560 RVA: 0x0009F834 File Offset: 0x0009DA34
	internal static bool MFeUDknvvaUzodTNvoWhZuXJRCgJ(KeyedGlyph A_0, string A_1, string A_2, uint A_3, DeviceLocalizationInfo A_4, qIdXPWaZDFjemNjbsLrswVoVIvUh A_5, int A_6, AxisRange A_7, int A_8, out object A_9)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			A_9 = null;
			return false;
		}
		bool result = false;
		uint dependenciesVersion = 0U;
		bool flag = !string.IsNullOrEmpty(A_2);
		StringBuilder sharedStringBuilder = GlyphManager.GetSharedStringBuilder();
		if (A_4 != null && A_4.parentKeys != null)
		{
			for (int i = 0; i < A_4.parentKeys.Count; i++)
			{
				if (!string.IsNullOrEmpty(A_4.parentKeys[i]))
				{
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(A_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_4.parentKeys[i]);
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
					if (GlyphManager.TryGetGlyph(A_0, sharedStringBuilder.ToString(), A_3, dependenciesVersion, out A_9))
					{
						result = true;
						goto IL_182;
					}
				}
			}
		}
		if (A_5 != qIdXPWaZDFjemNjbsLrswVoVIvUh.Keyboard)
		{
			sharedStringBuilder.Length = 0;
			sharedStringBuilder.Append("controller/element");
			LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
			if (GlyphManager.TryGetGlyph(A_0, sharedStringBuilder.ToString(), A_3, dependenciesVersion, out A_9))
			{
				result = true;
				goto IL_182;
			}
		}
		if (A_5 == qIdXPWaZDFjemNjbsLrswVoVIvUh.Joystick && A_6 >= 0 && A_4 != null && A_4.controllerTemplateGuids != null)
		{
			for (int j = 0; j < A_4.controllerTemplateGuids.Count; j++)
			{
				string text;
				string value;
				if (pIxAfPCGFQRFBOwQPqPHNpZroQXw.kSJCmhcUtEtWWbRZfbxlDgwjdopUA(A_4.guid, A_4.controllerTemplateGuids[j], A_6, A_7, A_8, out text, out value) && !string.IsNullOrEmpty(value))
				{
					sharedStringBuilder.Length = 0;
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, "controller/template");
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, value);
					if (GlyphManager.TryGetGlyph(A_0, sharedStringBuilder.ToString(), A_3, dependenciesVersion, out A_9))
					{
						result = true;
						goto IL_182;
					}
				}
			}
		}
		A_9 = null;
		IL_182:
		A_0.cachedValue = A_9;
		return result;
	}

	// Token: 0x06002D29 RID: 11561 RVA: 0x0009F9D0 File Offset: 0x0009DBD0
	internal static GlyphManager.GetAndUpdateGlyphResultFlags uhyBUPgZaSJnZWmtZhovJoVdQOsSA(KeyedGlyph A_0, string A_1, string A_2, DeviceLocalizationInfo A_3, qIdXPWaZDFjemNjbsLrswVoVIvUh A_4, int A_5, AxisRange A_6, int A_7, out object A_8)
	{
		if (!GlyphManager.isEnabled)
		{
			A_8 = null;
			return GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
		}
		bool flag;
		GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags;
		if (GlyphManager.TryGetCachedGlyph(A_0, GlyphManager.version, 0U, out flag, out A_8))
		{
			getAndUpdateGlyphResultFlags = GlyphManager.GetAndUpdateGlyphResultFlags.IsCachedValue;
		}
		else
		{
			getAndUpdateGlyphResultFlags = GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
		}
		if (!A_0.hasCachedValue || flag)
		{
			getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.Changed;
			if (RUpmbvJtGrVJvbLCXAeFqKfaIGHDA.MFeUDknvvaUzodTNvoWhZuXJRCgJ(A_0, A_1, A_2, GlyphManager.version, A_3, A_4, A_5, A_6, A_7, out A_8))
			{
				getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.JustGot;
				getAndUpdateGlyphResultFlags &= (GlyphManager.GetAndUpdateGlyphResultFlags)(-2);
			}
			else
			{
				getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
			}
		}
		return getAndUpdateGlyphResultFlags;
	}
}
