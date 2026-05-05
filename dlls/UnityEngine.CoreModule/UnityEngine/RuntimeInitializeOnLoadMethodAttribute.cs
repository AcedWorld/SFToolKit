using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000255 RID: 597
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	[RequiredByNativeCode]
	public class RuntimeInitializeOnLoadMethodAttribute : PreserveAttribute
	{
		// Token: 0x06001965 RID: 6501 RVA: 0x0002A758 File Offset: 0x00028958
		public RuntimeInitializeOnLoadMethodAttribute()
		{
			this.loadType = RuntimeInitializeLoadType.AfterSceneLoad;
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x0002A76A File Offset: 0x0002896A
		public RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType loadType)
		{
			this.loadType = loadType;
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06001967 RID: 6503 RVA: 0x0002A77C File Offset: 0x0002897C
		// (set) Token: 0x06001968 RID: 6504 RVA: 0x0002A794 File Offset: 0x00028994
		public RuntimeInitializeLoadType loadType
		{
			get
			{
				return this.m_LoadType;
			}
			private set
			{
				this.m_LoadType = value;
			}
		}

		// Token: 0x040008D6 RID: 2262
		private RuntimeInitializeLoadType m_LoadType;
	}
}
