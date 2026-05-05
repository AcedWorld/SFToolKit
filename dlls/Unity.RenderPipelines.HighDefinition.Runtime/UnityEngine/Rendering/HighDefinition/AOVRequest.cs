using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000192 RID: 402
	public struct AOVRequest
	{
		// Token: 0x06000C7A RID: 3194 RVA: 0x00068594 File Offset: 0x00066794
		public static AOVRequest NewDefault()
		{
			return new AOVRequest
			{
				m_MaterialProperty = MaterialSharedProperty.None,
				m_LightingProperty = LightingProperty.None,
				m_DebugFullScreen = DebugFullScreen.None,
				m_LightFilterProperty = DebugLightFilterMode.None,
				m_OverrideRenderFormat = false
			};
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x000685D2 File Offset: 0x000667D2
		internal bool overrideRenderFormat
		{
			get
			{
				return this.m_OverrideRenderFormat;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000C7C RID: 3196 RVA: 0x000685DC File Offset: 0x000667DC
		private unsafe AOVRequest* thisPtr
		{
			get
			{
				fixed (AOVRequest* ptr = &this)
				{
					return ptr;
				}
			}
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x000685ED File Offset: 0x000667ED
		public AOVRequest(AOVRequest other)
		{
			this.m_MaterialProperty = other.m_MaterialProperty;
			this.m_LightingProperty = other.m_LightingProperty;
			this.m_DebugFullScreen = other.m_DebugFullScreen;
			this.m_LightFilterProperty = other.m_LightFilterProperty;
			this.m_OverrideRenderFormat = other.m_OverrideRenderFormat;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x0006862B File Offset: 0x0006682B
		public unsafe ref AOVRequest SetFullscreenOutput(MaterialSharedProperty materialProperty)
		{
			this.m_MaterialProperty = materialProperty;
			return ref *this.thisPtr;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0006863A File Offset: 0x0006683A
		public unsafe ref AOVRequest SetFullscreenOutput(LightingProperty lightingProperty)
		{
			this.m_LightingProperty = lightingProperty;
			return ref *this.thisPtr;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00068649 File Offset: 0x00066849
		public unsafe ref AOVRequest SetFullscreenOutput(DebugFullScreen debugFullScreen)
		{
			this.m_DebugFullScreen = debugFullScreen;
			return ref *this.thisPtr;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00068658 File Offset: 0x00066858
		public unsafe ref AOVRequest SetLightFilter(DebugLightFilterMode filter)
		{
			this.m_LightFilterProperty = filter;
			return ref *this.thisPtr;
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00068667 File Offset: 0x00066867
		public unsafe ref AOVRequest SetOverrideRenderFormat(bool flag)
		{
			this.m_OverrideRenderFormat = flag;
			return ref *this.thisPtr;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00068678 File Offset: 0x00066878
		public void FillDebugData(DebugDisplaySettings debug)
		{
			debug.SetDebugViewCommonMaterialProperty(this.m_MaterialProperty);
			switch (this.m_LightingProperty)
			{
			case LightingProperty.DiffuseOnly:
				debug.SetDebugLightingMode(DebugLightingMode.DiffuseLighting);
				break;
			case LightingProperty.SpecularOnly:
				debug.SetDebugLightingMode(DebugLightingMode.SpecularLighting);
				break;
			case LightingProperty.DirectDiffuseOnly:
				debug.SetDebugLightingMode(DebugLightingMode.DirectDiffuseLighting);
				break;
			case LightingProperty.DirectSpecularOnly:
				debug.SetDebugLightingMode(DebugLightingMode.DirectSpecularLighting);
				break;
			case LightingProperty.IndirectDiffuseOnly:
				debug.SetDebugLightingMode(DebugLightingMode.IndirectDiffuseLighting);
				break;
			case LightingProperty.ReflectionOnly:
				debug.SetDebugLightingMode(DebugLightingMode.ReflectionLighting);
				break;
			case LightingProperty.RefractionOnly:
				debug.SetDebugLightingMode(DebugLightingMode.RefractionLighting);
				break;
			case LightingProperty.EmissiveOnly:
				debug.SetDebugLightingMode(DebugLightingMode.EmissiveLighting);
				break;
			default:
				debug.SetDebugLightingMode(DebugLightingMode.None);
				break;
			}
			debug.SetDebugLightFilterMode(this.m_LightFilterProperty);
			switch (this.m_DebugFullScreen)
			{
			case DebugFullScreen.None:
				debug.SetFullScreenDebugMode(FullScreenDebugMode.None);
				return;
			case DebugFullScreen.Depth:
				debug.SetFullScreenDebugMode(FullScreenDebugMode.DepthPyramid);
				return;
			case DebugFullScreen.ScreenSpaceAmbientOcclusion:
				debug.SetFullScreenDebugMode(FullScreenDebugMode.ScreenSpaceAmbientOcclusion);
				return;
			case DebugFullScreen.MotionVectors:
				debug.SetFullScreenDebugMode(FullScreenDebugMode.MotionVectors);
				return;
			case DebugFullScreen.WorldSpacePosition:
				debug.SetFullScreenDebugMode(FullScreenDebugMode.WorldSpacePosition);
				return;
			default:
				throw new ArgumentException("Unknown DebugFullScreen");
			}
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00068775 File Offset: 0x00066975
		public override bool Equals(object obj)
		{
			return obj is AOVRequest && (AOVRequest)obj == this;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00068794 File Offset: 0x00066994
		public static bool operator ==(AOVRequest a, AOVRequest b)
		{
			return a.m_DebugFullScreen == b.m_DebugFullScreen && a.m_LightFilterProperty == b.m_LightFilterProperty && a.m_LightingProperty == b.m_LightingProperty && a.m_MaterialProperty == b.m_MaterialProperty && a.m_OverrideRenderFormat == b.m_OverrideRenderFormat;
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x000687E9 File Offset: 0x000669E9
		public static bool operator !=(AOVRequest a, AOVRequest b)
		{
			return !(a == b);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x000687F8 File Offset: 0x000669F8
		public override int GetHashCode()
		{
			int num = 17;
			num = (int)(num * 23 + this.m_DebugFullScreen);
			num = (int)(num * 23 + this.m_LightFilterProperty);
			num = (int)(num * 23 + this.m_LightingProperty);
			num = (int)(num * 23 + this.m_MaterialProperty);
			return this.m_OverrideRenderFormat ? (num * 23 + 1) : num;
		}

		// Token: 0x040013B2 RID: 5042
		[Obsolete("Since 2019.3, use AOVRequest.NewDefault() instead.")]
		public static readonly AOVRequest @default;

		// Token: 0x040013B3 RID: 5043
		private MaterialSharedProperty m_MaterialProperty;

		// Token: 0x040013B4 RID: 5044
		private LightingProperty m_LightingProperty;

		// Token: 0x040013B5 RID: 5045
		private DebugLightFilterMode m_LightFilterProperty;

		// Token: 0x040013B6 RID: 5046
		private DebugFullScreen m_DebugFullScreen;

		// Token: 0x040013B7 RID: 5047
		internal bool m_OverrideRenderFormat;
	}
}
