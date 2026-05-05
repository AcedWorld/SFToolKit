using System;

namespace UnityEngine
{
	// Token: 0x02000215 RID: 533
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class ColorUsageAttribute : PropertyAttribute
	{
		// Token: 0x060017AA RID: 6058 RVA: 0x00027594 File Offset: 0x00025794
		public ColorUsageAttribute(bool showAlpha)
		{
			this.showAlpha = showAlpha;
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x000275EC File Offset: 0x000257EC
		public ColorUsageAttribute(bool showAlpha, bool hdr)
		{
			this.showAlpha = showAlpha;
			this.hdr = hdr;
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x0002764C File Offset: 0x0002584C
		[Obsolete("Brightness and exposure parameters are no longer used for anything. Use ColorUsageAttribute(bool showAlpha, bool hdr)")]
		public ColorUsageAttribute(bool showAlpha, bool hdr, float minBrightness, float maxBrightness, float minExposureValue, float maxExposureValue)
		{
			this.showAlpha = showAlpha;
			this.hdr = hdr;
			this.minBrightness = minBrightness;
			this.maxBrightness = maxBrightness;
			this.minExposureValue = minExposureValue;
			this.maxExposureValue = maxExposureValue;
		}

		// Token: 0x04000874 RID: 2164
		public readonly bool showAlpha = true;

		// Token: 0x04000875 RID: 2165
		public readonly bool hdr = false;

		// Token: 0x04000876 RID: 2166
		[Obsolete("This field is no longer used for anything.")]
		public readonly float minBrightness = 0f;

		// Token: 0x04000877 RID: 2167
		[Obsolete("This field is no longer used for anything.")]
		public readonly float maxBrightness = 8f;

		// Token: 0x04000878 RID: 2168
		[Obsolete("This field is no longer used for anything.")]
		public readonly float minExposureValue = 0.125f;

		// Token: 0x04000879 RID: 2169
		[Obsolete("This field is no longer used for anything.")]
		public readonly float maxExposureValue = 3f;
	}
}
