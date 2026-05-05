using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001DA RID: 474
	public abstract class CloudRenderer
	{
		// Token: 0x06000E61 RID: 3681
		public abstract void Build();

		// Token: 0x06000E62 RID: 3682
		public abstract void Cleanup();

		// Token: 0x06000E63 RID: 3683 RVA: 0x00072963 File Offset: 0x00070B63
		public virtual bool GetSunLightCookieParameters(CloudSettings settings, ref CookieParameters cookieParams)
		{
			return false;
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x00072966 File Offset: 0x00070B66
		public virtual void RenderSunLightCookie(BuiltinSunCookieParameters builtinParams)
		{
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00072968 File Offset: 0x00070B68
		protected virtual bool Update(BuiltinSkyParameters builtinParams)
		{
			return false;
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x0007296B File Offset: 0x00070B6B
		public virtual void PreRenderClouds(BuiltinSkyParameters builtinParams, bool renderForCubemap)
		{
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x0007296D File Offset: 0x00070B6D
		public virtual bool RequiresPreRenderClouds(BuiltinSkyParameters builtinParams)
		{
			return false;
		}

		// Token: 0x06000E68 RID: 3688
		public abstract void RenderClouds(BuiltinSkyParameters builtinParams, bool renderForCubemap);

		// Token: 0x06000E69 RID: 3689 RVA: 0x00072970 File Offset: 0x00070B70
		internal bool DoUpdate(BuiltinSkyParameters parameters)
		{
			if (this.m_LastFrameUpdate < parameters.frameIndex)
			{
				this.m_LastFrameUpdate = parameters.frameIndex;
				return this.Update(parameters);
			}
			return false;
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00072995 File Offset: 0x00070B95
		internal void Reset()
		{
			this.m_LastFrameUpdate = -1;
		}

		// Token: 0x040016BC RID: 5820
		private int m_LastFrameUpdate = -1;

		// Token: 0x040016BD RID: 5821
		public bool SupportDynamicSunLight = true;
	}
}
