using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200011F RID: 287
	[VolumeComponentMenuForRenderPipeline("Post-processing/Color Curves", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ColorCurves : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000A93 RID: 2707 RVA: 0x000599D9 File Offset: 0x00057BD9
		public bool IsActive()
		{
			return true;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x000599DC File Offset: 0x00057BDC
		public ColorCurves()
		{
			Keyframe[] keys = new Keyframe[]
			{
				new Keyframe(0f, 0f, 1f, 1f),
				new Keyframe(1f, 1f, 1f, 1f)
			};
			float zeroValue = 0f;
			bool loop = false;
			Vector2 vector = new Vector2(0f, 1f);
			this.master = new TextureCurveParameter(new TextureCurve(keys, zeroValue, loop, ref vector), false);
			Keyframe[] keys2 = new Keyframe[]
			{
				new Keyframe(0f, 0f, 1f, 1f),
				new Keyframe(1f, 1f, 1f, 1f)
			};
			float zeroValue2 = 0f;
			bool loop2 = false;
			vector = new Vector2(0f, 1f);
			this.red = new TextureCurveParameter(new TextureCurve(keys2, zeroValue2, loop2, ref vector), false);
			Keyframe[] keys3 = new Keyframe[]
			{
				new Keyframe(0f, 0f, 1f, 1f),
				new Keyframe(1f, 1f, 1f, 1f)
			};
			float zeroValue3 = 0f;
			bool loop3 = false;
			vector = new Vector2(0f, 1f);
			this.green = new TextureCurveParameter(new TextureCurve(keys3, zeroValue3, loop3, ref vector), false);
			Keyframe[] keys4 = new Keyframe[]
			{
				new Keyframe(0f, 0f, 1f, 1f),
				new Keyframe(1f, 1f, 1f, 1f)
			};
			float zeroValue4 = 0f;
			bool loop4 = false;
			vector = new Vector2(0f, 1f);
			this.blue = new TextureCurveParameter(new TextureCurve(keys4, zeroValue4, loop4, ref vector), false);
			Keyframe[] keys5 = new Keyframe[0];
			float zeroValue5 = 0.5f;
			bool loop5 = true;
			vector = new Vector2(0f, 1f);
			this.hueVsHue = new TextureCurveParameter(new TextureCurve(keys5, zeroValue5, loop5, ref vector), false);
			Keyframe[] keys6 = new Keyframe[0];
			float zeroValue6 = 0.5f;
			bool loop6 = true;
			vector = new Vector2(0f, 1f);
			this.hueVsSat = new TextureCurveParameter(new TextureCurve(keys6, zeroValue6, loop6, ref vector), false);
			Keyframe[] keys7 = new Keyframe[0];
			float zeroValue7 = 0.5f;
			bool loop7 = false;
			vector = new Vector2(0f, 1f);
			this.satVsSat = new TextureCurveParameter(new TextureCurve(keys7, zeroValue7, loop7, ref vector), false);
			Keyframe[] keys8 = new Keyframe[0];
			float zeroValue8 = 0.5f;
			bool loop8 = false;
			vector = new Vector2(0f, 1f);
			this.lumVsSat = new TextureCurveParameter(new TextureCurve(keys8, zeroValue8, loop8, ref vector), false);
			base..ctor();
		}

		// Token: 0x04000B47 RID: 2887
		public TextureCurveParameter master;

		// Token: 0x04000B48 RID: 2888
		public TextureCurveParameter red;

		// Token: 0x04000B49 RID: 2889
		public TextureCurveParameter green;

		// Token: 0x04000B4A RID: 2890
		public TextureCurveParameter blue;

		// Token: 0x04000B4B RID: 2891
		public TextureCurveParameter hueVsHue;

		// Token: 0x04000B4C RID: 2892
		public TextureCurveParameter hueVsSat;

		// Token: 0x04000B4D RID: 2893
		public TextureCurveParameter satVsSat;

		// Token: 0x04000B4E RID: 2894
		public TextureCurveParameter lumVsSat;

		// Token: 0x04000B4F RID: 2895
		[SerializeField]
		private int m_SelectedCurve;
	}
}
