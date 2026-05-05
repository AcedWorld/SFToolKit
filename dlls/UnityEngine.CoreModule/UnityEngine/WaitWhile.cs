using System;

namespace UnityEngine
{
	// Token: 0x02000273 RID: 627
	public sealed class WaitWhile : CustomYieldInstruction
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001A29 RID: 6697 RVA: 0x0002C2E0 File Offset: 0x0002A4E0
		public override bool keepWaiting
		{
			get
			{
				return this.m_Predicate();
			}
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x0002C2FD File Offset: 0x0002A4FD
		public WaitWhile(Func<bool> predicate)
		{
			this.m_Predicate = predicate;
		}

		// Token: 0x0400090E RID: 2318
		private Func<bool> m_Predicate;
	}
}
