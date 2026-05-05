using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000465 RID: 1125
	internal static class Shaders
	{
		// Token: 0x0600230D RID: 8973 RVA: 0x00087D30 File Offset: 0x00085F30
		static Shaders()
		{
			bool isUIEPackageLoaded = UIElementsPackageUtility.IsUIEPackageLoaded;
			if (isUIEPackageLoaded)
			{
				Shaders.k_AtlasBlit = "Hidden/UIE-AtlasBlit";
				Shaders.k_Editor = "Hidden/UIE-Editor";
				Shaders.k_Runtime = "Hidden/UIE-Runtime";
				Shaders.k_RuntimeWorld = "Hidden/UIE-RuntimeWorld";
				Shaders.k_GraphView = "Hidden/UIE-GraphView";
				Shaders.k_ColorConversionBlit = "Hidden/UIE-ColorConversionBlit";
			}
			else
			{
				Shaders.k_AtlasBlit = "Hidden/Internal-UIRAtlasBlitCopy";
				Shaders.k_Editor = "Hidden/UIElements/EditorUIE";
				Shaders.k_Runtime = "Hidden/Internal-UIRDefault";
				Shaders.k_RuntimeWorld = "Hidden/Internal-UIRDefaultWorld";
				Shaders.k_GraphView = "Hidden/GraphView/GraphViewUIE";
				Shaders.k_ColorConversionBlit = "Hidden/Internal-UIE-ColorConversionBlit";
			}
		}

		// Token: 0x04001028 RID: 4136
		public static readonly string k_AtlasBlit;

		// Token: 0x04001029 RID: 4137
		public static readonly string k_Editor;

		// Token: 0x0400102A RID: 4138
		public static readonly string k_Runtime;

		// Token: 0x0400102B RID: 4139
		public static readonly string k_RuntimeWorld;

		// Token: 0x0400102C RID: 4140
		public static readonly string k_GraphView;

		// Token: 0x0400102D RID: 4141
		public static readonly string k_ColorConversionBlit;
	}
}
