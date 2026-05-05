using System;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000150 RID: 336
	[UsedByNativeCode]
	[NativeHeader("Runtime/Graphics/LightmapData.h")]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class LightmapData
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000A7C RID: 2684 RVA: 0x000110F8 File Offset: 0x0000F2F8
		// (set) Token: 0x06000A7D RID: 2685 RVA: 0x00011110 File Offset: 0x0000F310
		[Obsolete("Use lightmapColor property (UnityUpgradable) -> lightmapColor", false)]
		public Texture2D lightmapLight
		{
			get
			{
				return this.m_Light;
			}
			set
			{
				this.m_Light = value;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0001111C File Offset: 0x0000F31C
		// (set) Token: 0x06000A7F RID: 2687 RVA: 0x00011110 File Offset: 0x0000F310
		public Texture2D lightmapColor
		{
			get
			{
				return this.m_Light;
			}
			set
			{
				this.m_Light = value;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x00011134 File Offset: 0x0000F334
		// (set) Token: 0x06000A81 RID: 2689 RVA: 0x0001114C File Offset: 0x0000F34C
		public Texture2D lightmapDir
		{
			get
			{
				return this.m_Dir;
			}
			set
			{
				this.m_Dir = value;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00011158 File Offset: 0x0000F358
		// (set) Token: 0x06000A83 RID: 2691 RVA: 0x00011170 File Offset: 0x0000F370
		public Texture2D shadowMask
		{
			get
			{
				return this.m_ShadowMask;
			}
			set
			{
				this.m_ShadowMask = value;
			}
		}

		// Token: 0x0400043A RID: 1082
		internal Texture2D m_Light;

		// Token: 0x0400043B RID: 1083
		internal Texture2D m_Dir;

		// Token: 0x0400043C RID: 1084
		internal Texture2D m_ShadowMask;
	}
}
