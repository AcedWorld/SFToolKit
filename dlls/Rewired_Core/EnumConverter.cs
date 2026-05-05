using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	// Token: 0x0200003D RID: 61
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EnumConverter
	{
		// Token: 0x06000246 RID: 582 RVA: 0x0002E89C File Offset: 0x0002CA9C
		public static int ToUpdateLoopTypes(UpdateLoopSetting updateLoopSetting, List<UpdateLoopType> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			EnumNameValueCache<UpdateLoopSetting> @default = EnumNameValueCache<UpdateLoopSetting>.Default;
			int count = @default.Count;
			for (int i = 0; i < count; i++)
			{
				UpdateLoopSetting valueAt = @default.GetValueAt(i);
				if (valueAt != UpdateLoopSetting.None && (updateLoopSetting & valueAt) != UpdateLoopSetting.None)
				{
					results.Add(EnumNameValueCache<UpdateLoopType>.Default.GetValue(@default.GetName((long)valueAt)));
				}
			}
			return results.Count;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00003E2E File Offset: 0x0000202E
		public static AlternateAxisCalibrationType ToAlternateAxisCalibrationType(ThrottleCalibrationMode throttleCalibrationMode)
		{
			if (throttleCalibrationMode == ThrottleCalibrationMode.ZeroToOne)
			{
				return AlternateAxisCalibrationType.Default;
			}
			if (throttleCalibrationMode != ThrottleCalibrationMode.NegativeOneToOne)
			{
				throw new NotImplementedException();
			}
			return AlternateAxisCalibrationType.ThrottleZeroCenter;
		}
	}
}
