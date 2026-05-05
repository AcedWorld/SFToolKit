using System;
using System.Collections;
using UnityEngine.Scripting;

namespace Unity.VisualScripting
{
	// Token: 0x02000013 RID: 19
	public sealed class AotList : ArrayList
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00002C1E File Offset: 0x00000E1E
		public AotList()
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002C26 File Offset: 0x00000E26
		public AotList(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002C2F File Offset: 0x00000E2F
		public AotList(ICollection c) : base(c)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002C38 File Offset: 0x00000E38
		[Preserve]
		public static void AotStubs()
		{
			AotList aotList = new AotList();
			aotList.Add(null);
			aotList.Remove(null);
			object obj = aotList[0];
			aotList[0] = null;
			aotList.Contains(null);
			aotList.Clear();
			int count = aotList.Count;
		}
	}
}
