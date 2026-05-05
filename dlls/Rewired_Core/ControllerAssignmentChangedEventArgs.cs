using System;

namespace Rewired
{
	// Token: 0x02000005 RID: 5
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002404 File Offset: 0x00000604
		public bool state
		{
			get
			{
				return this.bcjrTBZZRGfoajWVrnvtkURkGgut;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000240C File Offset: 0x0000060C
		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(this.UbMGhhoIiiCctgSRjQkHZTPHAvuE, this.hvIrOgvlTyqVUGODuwbefDUwgbaC);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000242D File Offset: 0x0000062D
		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(this.IpptyAzlbvKpZGmRsmSOdVYXWFub);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002448 File Offset: 0x00000648
		internal ControllerAssignmentChangedEventArgs(int A_1, int A_2, ControllerType A_3, bool A_4)
		{
			this.bcjrTBZZRGfoajWVrnvtkURkGgut = A_4;
			this.IpptyAzlbvKpZGmRsmSOdVYXWFub = A_1;
			this.hvIrOgvlTyqVUGODuwbefDUwgbaC = A_2;
			this.UbMGhhoIiiCctgSRjQkHZTPHAvuE = A_3;
		}

		// Token: 0x04000006 RID: 6
		private bool bcjrTBZZRGfoajWVrnvtkURkGgut;

		// Token: 0x04000007 RID: 7
		private int IpptyAzlbvKpZGmRsmSOdVYXWFub;

		// Token: 0x04000008 RID: 8
		private int hvIrOgvlTyqVUGODuwbefDUwgbaC;

		// Token: 0x04000009 RID: 9
		private ControllerType UbMGhhoIiiCctgSRjQkHZTPHAvuE;
	}
}
