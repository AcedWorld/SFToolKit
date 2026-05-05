using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

// Token: 0x020002D9 RID: 729
internal abstract class JGFbzxrKsMtqJZQTcBBDYcUaYRLl : zHTBvVyhFGDLpEJMFINchPNfqnfnb
{
	// Token: 0x06001592 RID: 5522 RVA: 0x0001C16F File Offset: 0x0001A36F
	public JGFbzxrKsMtqJZQTcBBDYcUaYRLl(JGFbzxrKsMtqJZQTcBBDYcUaYRLl.UxTPMCWPXdPGmxJSAAiaIMUGYnZDA A_1, byte A_2, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_3) : base(A_2, A_3)
	{
		this.InZtVzhOMxUowYlAfTZXwgYyTApB = A_1;
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x0001C180 File Offset: 0x0001A380
	public virtual void hoMJvKdDsQTbxBzHERzCeWBTvZsI(UpdateLoopType A_1)
	{
		if (this.InZtVzhOMxUowYlAfTZXwgYyTApB == null)
		{
			return;
		}
		this.InZtVzhOMxUowYlAfTZXwgYyTApB.wVeLnxGFPrfeFduhlOubnjkXiPCEb(A_1);
	}

	// Token: 0x04002F23 RID: 12067
	internal JGFbzxrKsMtqJZQTcBBDYcUaYRLl.UxTPMCWPXdPGmxJSAAiaIMUGYnZDA InZtVzhOMxUowYlAfTZXwgYyTApB;

	// Token: 0x020002DA RID: 730
	internal abstract class UxTPMCWPXdPGmxJSAAiaIMUGYnZDA
	{
		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06001594 RID: 5524 RVA: 0x0001C197 File Offset: 0x0001A397
		protected int bHyFvjNpVJNWWLtHaozgztJIFAmf
		{
			get
			{
				return this.TNHRgiuMhMwAGvyQtQakZRdKSMES;
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06001595 RID: 5525 RVA: 0x0001C19F File Offset: 0x0001A39F
		protected int[] dnjYXaChreHLUnWbqQfRAMObWVbE
		{
			get
			{
				return this.oqAdGUapvvtfOBImRwVAFgTJnnKG;
			}
		}

		// Token: 0x1700036C RID: 876
		// (set) Token: 0x06001596 RID: 5526 RVA: 0x0004BE04 File Offset: 0x0004A004
		public UpdateLoopType fULiBLaRAEKRUNCmFggXvmJVwHio
		{
			set
			{
				if (this.ibHksltkxrwqcmWuxvLQhPwLHvrh == (int)value)
				{
					return;
				}
				this.ibHksltkxrwqcmWuxvLQhPwLHvrh = (int)value;
				this.ZuaNCjhdFDweIJmyMfohobhSDWYGA = this.oqAdGUapvvtfOBImRwVAFgTJnnKG[(int)value];
				this.uQOLOCSMTTRLHAPKrDnqcKqBEOxeb = this.sodTncZlIGFzNBOAdyDpfHjSzgzsA[this.ZuaNCjhdFDweIJmyMfohobhSDWYGA];
			}
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0001C1A7 File Offset: 0x0001A3A7
		public UxTPMCWPXdPGmxJSAAiaIMUGYnZDA()
		{
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0004BE48 File Offset: 0x0004A048
		public void pFtGBKZfLwRqlkbLeQwHWGIbkJgx(UpdateLoopSetting A_1, Func<UpdateLoopType, JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO> A_2)
		{
			if (this.kNpKdmIOUrvOCYHYaIBuEBOPgBcIA)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			this.oqAdGUapvvtfOBImRwVAFgTJnnKG = new int[3];
			this.TNHRgiuMhMwAGvyQtQakZRdKSMES = 0;
			List<JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO> list = new List<JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO>();
			using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tlist.list;
				EnumConverter.ToUpdateLoopTypes(A_1, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					this.oqAdGUapvvtfOBImRwVAFgTJnnKG[(int)list2[i]] = this.TNHRgiuMhMwAGvyQtQakZRdKSMES;
					this.TNHRgiuMhMwAGvyQtQakZRdKSMES++;
					list.Add(A_2(list2[i]));
				}
			}
			this.sodTncZlIGFzNBOAdyDpfHjSzgzsA = list.ToArray();
			this.uQOLOCSMTTRLHAPKrDnqcKqBEOxeb = this.sodTncZlIGFzNBOAdyDpfHjSzgzsA[0];
			this.kNpKdmIOUrvOCYHYaIBuEBOPgBcIA = true;
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0001C1B6 File Offset: 0x0001A3B6
		private void ubepNUhJWSuLsdDwKMMFcZjYdbOh(UpdateLoopType A_1, JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO A_2)
		{
			this.sodTncZlIGFzNBOAdyDpfHjSzgzsA[this.oqAdGUapvvtfOBImRwVAFgTJnnKG[(int)A_1]] = A_2;
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0001C1C8 File Offset: 0x0001A3C8
		public virtual void wVeLnxGFPrfeFduhlOubnjkXiPCEb(UpdateLoopType A_1)
		{
			if (this.ibHksltkxrwqcmWuxvLQhPwLHvrh == (int)A_1)
			{
				return;
			}
			this.fULiBLaRAEKRUNCmFggXvmJVwHio = A_1;
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0004BF1C File Offset: 0x0004A11C
		public void KAwMHXpOfCxAyOHvktmJMvoRDuIV()
		{
			for (int i = 0; i < this.TNHRgiuMhMwAGvyQtQakZRdKSMES; i++)
			{
				this.sodTncZlIGFzNBOAdyDpfHjSzgzsA[i].ArjTClvPzbjPJeOOgwKCzmpnaOQA();
			}
		}

		// Token: 0x04002F24 RID: 12068
		private int TNHRgiuMhMwAGvyQtQakZRdKSMES;

		// Token: 0x04002F25 RID: 12069
		private int[] oqAdGUapvvtfOBImRwVAFgTJnnKG;

		// Token: 0x04002F26 RID: 12070
		protected JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO[] sodTncZlIGFzNBOAdyDpfHjSzgzsA;

		// Token: 0x04002F27 RID: 12071
		public JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO uQOLOCSMTTRLHAPKrDnqcKqBEOxeb;

		// Token: 0x04002F28 RID: 12072
		private int ZuaNCjhdFDweIJmyMfohobhSDWYGA;

		// Token: 0x04002F29 RID: 12073
		private int ibHksltkxrwqcmWuxvLQhPwLHvrh = -1;

		// Token: 0x04002F2A RID: 12074
		private bool kNpKdmIOUrvOCYHYaIBuEBOPgBcIA;
	}

	// Token: 0x020002DB RID: 731
	internal abstract class yPBPgWtSRCZnxqcPhEOyFjuHDOLO
	{
		// Token: 0x0600159C RID: 5532 RVA: 0x0001C1DB File Offset: 0x0001A3DB
		public yPBPgWtSRCZnxqcPhEOyFjuHDOLO(UpdateLoopType A_1)
		{
			this.AtTwjYjHTTAbxsIXBjRxFVbMuGJx = A_1;
		}

		// Token: 0x0600159D RID: 5533
		public abstract void ArjTClvPzbjPJeOOgwKCzmpnaOQA();

		// Token: 0x04002F2B RID: 12075
		public readonly UpdateLoopType AtTwjYjHTTAbxsIXBjRxFVbMuGJx;
	}
}
