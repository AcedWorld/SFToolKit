using System;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004F8 RID: 1272
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x060033F2 RID: 13298 RVA: 0x00027EC8 File Offset: 0x000260C8
		public int Length
		{
			get
			{
				if (this.jtQakuWMCkkUXdvTHOQGNMDeDYuB == null)
				{
					return 0;
				}
				return this.jtQakuWMCkkUXdvTHOQGNMDeDYuB.Length;
			}
		}

		// Token: 0x17000BDF RID: 3039
		public T this[int index]
		{
			get
			{
				return this.jtQakuWMCkkUXdvTHOQGNMDeDYuB[index];
			}
		}

		// Token: 0x060033F4 RID: 13300 RVA: 0x00027EEA File Offset: 0x000260EA
		public ReadOnlyArrayStruct(T[] A_1)
		{
			this.jtQakuWMCkkUXdvTHOQGNMDeDYuB = A_1;
		}

		// Token: 0x04001BD3 RID: 7123
		private T[] jtQakuWMCkkUXdvTHOQGNMDeDYuB;
	}
}
