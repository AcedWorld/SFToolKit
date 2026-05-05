using System;

namespace Rewired
{
	// Token: 0x02000004 RID: 4
	public sealed class ControllerStatusChangedEventArgs : EventArgs
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000023AE File Offset: 0x000005AE
		public string name
		{
			get
			{
				return this.ESUkTnBxMhwmlJlUwMghBKRLIUMf;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000023B6 File Offset: 0x000005B6
		public int controllerId
		{
			get
			{
				return this.kbeTBkFTbmuiQqbRHaCZJnAsooxCb;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000023BE File Offset: 0x000005BE
		public ControllerType controllerType
		{
			get
			{
				return this.RclleeVXHiqgerasXpegnmgxeGSY;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000023C6 File Offset: 0x000005C6
		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(this.RclleeVXHiqgerasXpegnmgxeGSY, this.kbeTBkFTbmuiQqbRHaCZJnAsooxCb);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000023E7 File Offset: 0x000005E7
		public ControllerStatusChangedEventArgs(string A_1, int A_2, ControllerType A_3)
		{
			this.ESUkTnBxMhwmlJlUwMghBKRLIUMf = A_1;
			this.kbeTBkFTbmuiQqbRHaCZJnAsooxCb = A_2;
			this.RclleeVXHiqgerasXpegnmgxeGSY = A_3;
		}

		// Token: 0x04000003 RID: 3
		private string ESUkTnBxMhwmlJlUwMghBKRLIUMf;

		// Token: 0x04000004 RID: 4
		private int kbeTBkFTbmuiQqbRHaCZJnAsooxCb;

		// Token: 0x04000005 RID: 5
		private ControllerType RclleeVXHiqgerasXpegnmgxeGSY;
	}
}
