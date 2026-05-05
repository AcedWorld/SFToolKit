using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200020D RID: 525
	[Flags]
	public enum ProbeSettingsFields
	{
		// Token: 0x04001813 RID: 6163
		none = 0,
		// Token: 0x04001814 RID: 6164
		type = 1,
		// Token: 0x04001815 RID: 6165
		mode = 2,
		// Token: 0x04001816 RID: 6166
		lightingMultiplier = 4,
		// Token: 0x04001817 RID: 6167
		lightingWeight = 8,
		// Token: 0x04001818 RID: 6168
		lightingLightLayer = 16,
		// Token: 0x04001819 RID: 6169
		lightingRangeCompression = 32,
		// Token: 0x0400181A RID: 6170
		proxyUseInfluenceVolumeAsProxyVolume = 64,
		// Token: 0x0400181B RID: 6171
		proxyCapturePositionProxySpace = 128,
		// Token: 0x0400181C RID: 6172
		proxyCaptureRotationProxySpace = 256,
		// Token: 0x0400181D RID: 6173
		proxyMirrorPositionProxySpace = 512,
		// Token: 0x0400181E RID: 6174
		proxyMirrorRotationProxySpace = 1024,
		// Token: 0x0400181F RID: 6175
		frustumFieldOfViewMode = 2048,
		// Token: 0x04001820 RID: 6176
		frustumFixedValue = 4096,
		// Token: 0x04001821 RID: 6177
		frustumAutomaticScale = 8192,
		// Token: 0x04001822 RID: 6178
		frustumViewerScale = 16384,
		// Token: 0x04001823 RID: 6179
		lightingFadeDistance = 32768,
		// Token: 0x04001824 RID: 6180
		resolution = 65536,
		// Token: 0x04001825 RID: 6181
		roughReflections = 131072,
		// Token: 0x04001826 RID: 6182
		cubeResolution = 262144
	}
}
