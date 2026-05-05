using System;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000270 RID: 624
	[RequiredByNativeCode]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class WaitForSeconds : YieldInstruction
	{
		// Token: 0x06001A21 RID: 6689 RVA: 0x0002C204 File Offset: 0x0002A404
		public WaitForSeconds(float seconds)
		{
			this.m_Seconds = seconds;
		}

		// Token: 0x0400090A RID: 2314
		internal float m_Seconds;
	}
}
