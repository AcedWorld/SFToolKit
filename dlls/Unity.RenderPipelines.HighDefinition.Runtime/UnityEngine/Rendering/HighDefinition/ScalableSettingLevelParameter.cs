using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200015C RID: 348
	[Serializable]
	public sealed class ScalableSettingLevelParameter : NoInterpIntParameter
	{
		// Token: 0x06000BCB RID: 3019 RVA: 0x0005FBAA File Offset: 0x0005DDAA
		public ScalableSettingLevelParameter(int level, bool useOverride, bool overrideState = false) : base(useOverride ? 3 : level, overrideState)
		{
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0005FBBA File Offset: 0x0005DDBA
		internal static int GetScalableSettingLevelParameterValue(int level, bool useOverride)
		{
			if (!useOverride)
			{
				return level;
			}
			return 3;
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x0005FBC2 File Offset: 0x0005DDC2
		// (set) Token: 0x06000BCE RID: 3022 RVA: 0x0005FBE4 File Offset: 0x0005DDE4
		[TupleElementNames(new string[]
		{
			"level",
			"useOverride"
		})]
		public ValueTuple<int, bool> levelAndOverride
		{
			[return: TupleElementNames(new string[]
			{
				"level",
				"useOverride"
			})]
			get
			{
				if (this.value != 3)
				{
					return new ValueTuple<int, bool>(this.value, false);
				}
				return new ValueTuple<int, bool>(0, true);
			}
			[param: TupleElementNames(new string[]
			{
				"level",
				"useOverride"
			})]
			set
			{
				int item = value.Item1;
				bool item2 = value.Item2;
				this.value = ScalableSettingLevelParameter.GetScalableSettingLevelParameterValue(item, item2);
			}
		}

		// Token: 0x04000D1E RID: 3358
		public const int LevelCount = 3;

		// Token: 0x020003BC RID: 956
		public enum Level
		{
			// Token: 0x04002652 RID: 9810
			Low,
			// Token: 0x04002653 RID: 9811
			Medium,
			// Token: 0x04002654 RID: 9812
			High
		}
	}
}
