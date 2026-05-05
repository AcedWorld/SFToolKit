using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200042D RID: 1069
	[RequiredByNativeCode]
	public class OnDemandRendering
	{
		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06002229 RID: 8745 RVA: 0x00038CF8 File Offset: 0x00036EF8
		public static bool willCurrentFrameRender
		{
			get
			{
				return Time.frameCount % OnDemandRendering.renderFrameInterval == 0;
			}
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x0600222A RID: 8746 RVA: 0x00038D18 File Offset: 0x00036F18
		// (set) Token: 0x0600222B RID: 8747 RVA: 0x00038D2F File Offset: 0x00036F2F
		public static int renderFrameInterval
		{
			get
			{
				return OnDemandRendering.m_RenderFrameInterval;
			}
			set
			{
				OnDemandRendering.m_RenderFrameInterval = Math.Max(1, value);
			}
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x00038D3E File Offset: 0x00036F3E
		[RequiredByNativeCode]
		internal static void GetRenderFrameInterval(out int frameInterval)
		{
			frameInterval = OnDemandRendering.renderFrameInterval;
		}

		// Token: 0x0600222D RID: 8749
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float GetEffectiveRenderFrameRate();

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x0600222E RID: 8750 RVA: 0x00038D48 File Offset: 0x00036F48
		public static int effectiveRenderFrameRate
		{
			get
			{
				float effectiveRenderFrameRate = OnDemandRendering.GetEffectiveRenderFrameRate();
				bool flag = (double)effectiveRenderFrameRate <= 0.0;
				int result;
				if (flag)
				{
					result = (int)effectiveRenderFrameRate;
				}
				else
				{
					result = (int)(effectiveRenderFrameRate + 0.5f);
				}
				return result;
			}
		}

		// Token: 0x04000D16 RID: 3350
		private static int m_RenderFrameInterval = 1;
	}
}
