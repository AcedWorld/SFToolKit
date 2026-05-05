using System;
using UnityEngine;

namespace CafofoStudio
{
	// Token: 0x020001CB RID: 459
	[CreateAssetMenu(fileName = "MyCityAmbientPreset", menuName = "CafofoStudio/Create Custom Preset Asset/City", order = 1)]
	public class CityAmbientPreset : AmbientPreset
	{
		// Token: 0x04000C9C RID: 3228
		[Range(0f, 1f)]
		public float trafficIntensity;

		// Token: 0x04000C9D RID: 3229
		[Range(0f, 1f)]
		public float trafficVolumeMultiplier = 1f;

		// Token: 0x04000C9E RID: 3230
		[Range(0f, 1f)]
		public float vehicleIntensity;

		// Token: 0x04000C9F RID: 3231
		[Range(0f, 1f)]
		public float vehicleVolumeMultiplier = 1f;

		// Token: 0x04000CA0 RID: 3232
		[Range(0f, 1f)]
		public float crowdIntensity;

		// Token: 0x04000CA1 RID: 3233
		[Range(0f, 1f)]
		public float crowdVolumeMultiplier = 1f;

		// Token: 0x04000CA2 RID: 3234
		[Range(0f, 1f)]
		public float constructionIntensity;

		// Token: 0x04000CA3 RID: 3235
		[Range(0f, 1f)]
		public float constructionVolumeMultiplier = 1f;

		// Token: 0x04000CA4 RID: 3236
		[Range(0f, 1f)]
		public float birdsIntensity;

		// Token: 0x04000CA5 RID: 3237
		[Range(0f, 1f)]
		public float birdsVolumeMultiplier = 1f;

		// Token: 0x04000CA6 RID: 3238
		[Range(0f, 1f)]
		public float rainIntensity;

		// Token: 0x04000CA7 RID: 3239
		[Range(0f, 1f)]
		public float rainVolumeMultiplier = 1f;
	}
}
