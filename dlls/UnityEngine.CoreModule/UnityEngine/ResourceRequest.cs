using System;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200021E RID: 542
	[RequiredByNativeCode]
	[StructLayout(LayoutKind.Sequential)]
	public class ResourceRequest : AsyncOperation
	{
		// Token: 0x060017DF RID: 6111 RVA: 0x00027AB8 File Offset: 0x00025CB8
		protected virtual Object GetResult()
		{
			return Resources.Load(this.m_Path, this.m_Type);
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x060017E0 RID: 6112 RVA: 0x00027ADC File Offset: 0x00025CDC
		public Object asset
		{
			get
			{
				return this.GetResult();
			}
		}

		// Token: 0x04000882 RID: 2178
		internal string m_Path;

		// Token: 0x04000883 RID: 2179
		internal Type m_Type;
	}
}
