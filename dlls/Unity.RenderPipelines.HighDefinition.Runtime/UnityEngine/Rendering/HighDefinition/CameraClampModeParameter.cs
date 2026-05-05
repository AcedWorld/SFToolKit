using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000138 RID: 312
	[Serializable]
	public sealed class CameraClampModeParameter : VolumeParameter<CameraClampMode>
	{
		// Token: 0x06000ABB RID: 2747 RVA: 0x0005A511 File Offset: 0x00058711
		public CameraClampModeParameter(CameraClampMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
