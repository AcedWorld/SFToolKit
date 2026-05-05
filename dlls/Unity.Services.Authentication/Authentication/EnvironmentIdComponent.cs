using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x02000011 RID: 17
	internal class EnvironmentIdComponent : IEnvironmentId, IServiceComponent
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000116 RID: 278 RVA: 0x000048B4 File Offset: 0x00002AB4
		// (set) Token: 0x06000117 RID: 279 RVA: 0x000048BC File Offset: 0x00002ABC
		public string EnvironmentId
		{
			get
			{
				return this.m_EnvironmentId;
			}
			internal set
			{
				this.m_EnvironmentId = value;
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000048C5 File Offset: 0x00002AC5
		internal EnvironmentIdComponent()
		{
		}

		// Token: 0x0400004A RID: 74
		private string m_EnvironmentId;
	}
}
