using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E2 RID: 226
	[Serializable]
	public class TextureCurveParameter : VolumeParameter<TextureCurve>
	{
		// Token: 0x0600078D RID: 1933 RVA: 0x00024AAD File Offset: 0x00022CAD
		public TextureCurveParameter(TextureCurve value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00024AB7 File Offset: 0x00022CB7
		public override void Release()
		{
			this.m_Value.Release();
		}
	}
}
