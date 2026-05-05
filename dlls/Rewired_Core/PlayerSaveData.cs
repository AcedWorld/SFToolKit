using System;
using System.Collections.Generic;

namespace Rewired
{
	// Token: 0x02000163 RID: 355
	public struct PlayerSaveData
	{
		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000F20 RID: 3872 RVA: 0x0000DC3F File Offset: 0x0000BE3F
		public JoystickMapSaveData[] joystickMapSaveData
		{
			get
			{
				return this.gZZWSsNNSQPOjfdELyTamtQSdUxk;
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x0000DC47 File Offset: 0x0000BE47
		public KeyboardMapSaveData[] keyboardMapSaveData
		{
			get
			{
				return this.LcAjVyrdoLeJtTuImDqLLZVbhAoj;
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x0000DC4F File Offset: 0x0000BE4F
		public MouseMapSaveData[] mouseMapSaveData
		{
			get
			{
				return this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb;
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x0000DC57 File Offset: 0x0000BE57
		public CustomControllerMapSaveData[] customControllerMapSaveData
		{
			get
			{
				return this.oIpCgxBchHaBlubiWCeDxqpAgPnA;
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x0000DC5F File Offset: 0x0000BE5F
		public InputBehavior[] inputBehaviors
		{
			get
			{
				return this.aTVRNSUhfFjVghIQqYWoQoRgQOYIA;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x0000DC67 File Offset: 0x0000BE67
		public int joystickMapCount
		{
			get
			{
				if (this.gZZWSsNNSQPOjfdELyTamtQSdUxk == null)
				{
					return 0;
				}
				return this.gZZWSsNNSQPOjfdELyTamtQSdUxk.Length;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x0000DC7B File Offset: 0x0000BE7B
		public int keyboardMapCount
		{
			get
			{
				if (this.LcAjVyrdoLeJtTuImDqLLZVbhAoj == null)
				{
					return 0;
				}
				return this.LcAjVyrdoLeJtTuImDqLLZVbhAoj.Length;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x0000DC8F File Offset: 0x0000BE8F
		public int mouseMapCount
		{
			get
			{
				if (this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb == null)
				{
					return 0;
				}
				return this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb.Length;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x0000DCA3 File Offset: 0x0000BEA3
		public int customControllerMapCount
		{
			get
			{
				if (this.oIpCgxBchHaBlubiWCeDxqpAgPnA == null)
				{
					return 0;
				}
				return this.oIpCgxBchHaBlubiWCeDxqpAgPnA.Length;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x0000DCB7 File Offset: 0x0000BEB7
		public int inputBehaviorCount
		{
			get
			{
				if (this.aTVRNSUhfFjVghIQqYWoQoRgQOYIA == null)
				{
					return 0;
				}
				return this.aTVRNSUhfFjVghIQqYWoQoRgQOYIA.Length;
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x0000DCCB File Offset: 0x0000BECB
		public IEnumerable<ControllerMapSaveData> AllControllerMapSaveData
		{
			get
			{
				if (this.gZZWSsNNSQPOjfdELyTamtQSdUxk != null)
				{
					int num;
					for (int i = 0; i < this.gZZWSsNNSQPOjfdELyTamtQSdUxk.Length; i = num + 1)
					{
						if (this.gZZWSsNNSQPOjfdELyTamtQSdUxk[i] != null)
						{
							yield return this.gZZWSsNNSQPOjfdELyTamtQSdUxk[i];
						}
						num = i;
					}
				}
				if (this.LcAjVyrdoLeJtTuImDqLLZVbhAoj != null)
				{
					int num;
					for (int i = 0; i < this.LcAjVyrdoLeJtTuImDqLLZVbhAoj.Length; i = num + 1)
					{
						if (this.LcAjVyrdoLeJtTuImDqLLZVbhAoj[i] != null)
						{
							yield return this.LcAjVyrdoLeJtTuImDqLLZVbhAoj[i];
						}
						num = i;
					}
				}
				if (this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb != null)
				{
					int num;
					for (int i = 0; i < this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb.Length; i = num + 1)
					{
						if (this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb[i] != null)
						{
							yield return this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb[i];
						}
						num = i;
					}
				}
				if (this.oIpCgxBchHaBlubiWCeDxqpAgPnA != null)
				{
					int num;
					for (int i = 0; i < this.oIpCgxBchHaBlubiWCeDxqpAgPnA.Length; i = num + 1)
					{
						if (this.oIpCgxBchHaBlubiWCeDxqpAgPnA[i] != null)
						{
							yield return this.oIpCgxBchHaBlubiWCeDxqpAgPnA[i];
						}
						num = i;
					}
				}
				yield break;
			}
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00054FC0 File Offset: 0x000531C0
		internal PlayerSaveData(JoystickMapSaveData[] A_1, KeyboardMapSaveData[] A_2, MouseMapSaveData[] A_3, CustomControllerMapSaveData[] A_4, IList<InputBehavior> A_5)
		{
			this.gZZWSsNNSQPOjfdELyTamtQSdUxk = A_1;
			this.LcAjVyrdoLeJtTuImDqLLZVbhAoj = A_2;
			this.pNcRAdPEPDBeWfFsTGxMHvcNszRfb = A_3;
			this.oIpCgxBchHaBlubiWCeDxqpAgPnA = A_4;
			int num = (A_5 != null) ? A_5.Count : 0;
			this.aTVRNSUhfFjVghIQqYWoQoRgQOYIA = new InputBehavior[num];
			for (int i = 0; i < num; i++)
			{
				this.aTVRNSUhfFjVghIQqYWoQoRgQOYIA[i] = A_5[i];
			}
		}

		// Token: 0x0400093D RID: 2365
		private JoystickMapSaveData[] gZZWSsNNSQPOjfdELyTamtQSdUxk;

		// Token: 0x0400093E RID: 2366
		private KeyboardMapSaveData[] LcAjVyrdoLeJtTuImDqLLZVbhAoj;

		// Token: 0x0400093F RID: 2367
		private MouseMapSaveData[] pNcRAdPEPDBeWfFsTGxMHvcNszRfb;

		// Token: 0x04000940 RID: 2368
		private CustomControllerMapSaveData[] oIpCgxBchHaBlubiWCeDxqpAgPnA;

		// Token: 0x04000941 RID: 2369
		private InputBehavior[] aTVRNSUhfFjVghIQqYWoQoRgQOYIA;
	}
}
