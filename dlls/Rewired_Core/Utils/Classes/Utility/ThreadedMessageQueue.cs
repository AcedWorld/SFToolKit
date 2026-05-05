using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004CC RID: 1228
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		// Token: 0x0600316D RID: 12653 RVA: 0x000ABFBC File Offset: 0x000AA1BC
		public ThreadedMessageQueue(int A_1, int A_2, int A_3, bool A_4, Action<T> A_5)
		{
			if (A_5 == null)
			{
				throw new ArgumentNullException("messageReceiverDelegate");
			}
			if (A_1 < 0)
			{
				A_1 = 0;
			}
			if (A_2 < 0)
			{
				A_2 = 0;
			}
			if (A_3 < 0)
			{
				A_3 = 0;
			}
			this.HUvYaArkFBDIskzPrSTHnGGiqGfEA = A_1;
			this.NloMMgFrvmkQfQeGIPlqyIovVIdK = A_2;
			this.jWyOaOGMJonMQQPqGNsnrqPpQJoh = A_3;
			this.LkihRwBMgwnSxJFZRVEamJSSAopv = A_4;
			this.utctxXgKZFPRRBjEKgWwhqGVMqeeb = A_5;
			this.TnACyfDVFqaEdfBgdIYaADgJLnTGA = new Queue<T>(A_1);
			this.HWadUpIHjhWpPYaQKzjwzxccmaqk = new Queue<T>(A_1);
		}

		// Token: 0x0600316E RID: 12654 RVA: 0x000AC030 File Offset: 0x000AA230
		public void Enqueue(T message)
		{
			if (!this.mxweUFQiXzBigDBwuFEmxBvizNmfA())
			{
				return;
			}
			Queue<T> tnACyfDVFqaEdfBgdIYaADgJLnTGA = this.TnACyfDVFqaEdfBgdIYaADgJLnTGA;
			lock (tnACyfDVFqaEdfBgdIYaADgJLnTGA)
			{
				if (this.HUvYaArkFBDIskzPrSTHnGGiqGfEA > 0)
				{
					while (this.TnACyfDVFqaEdfBgdIYaADgJLnTGA.Count >= this.HUvYaArkFBDIskzPrSTHnGGiqGfEA)
					{
						this.TnACyfDVFqaEdfBgdIYaADgJLnTGA.Dequeue();
					}
				}
				this.TnACyfDVFqaEdfBgdIYaADgJLnTGA.Enqueue(message);
			}
		}

		// Token: 0x0600316F RID: 12655 RVA: 0x00025E81 File Offset: 0x00024081
		private bool mxweUFQiXzBigDBwuFEmxBvizNmfA()
		{
			if (this.XHEgWeenzqFAowhYRqHFDqmGjYnt)
			{
				return false;
			}
			if (!this.KyUlXgVaEhdPTgDJqIeZryRaYpJJA())
			{
				return false;
			}
			if (this.FeBfHjJPHSwlvqQeTMXmynHlershA)
			{
				return true;
			}
			this.FeBfHjJPHSwlvqQeTMXmynHlershA = true;
			return true;
		}

		// Token: 0x06003170 RID: 12656 RVA: 0x000AC0AC File Offset: 0x000AA2AC
		private bool KyUlXgVaEhdPTgDJqIeZryRaYpJJA()
		{
			if (this.XHEgWeenzqFAowhYRqHFDqmGjYnt)
			{
				return false;
			}
			if (this.BYWhHRPovNebqPvIZkDsHqlHWsdC == null)
			{
				try
				{
					this.BYWhHRPovNebqPvIZkDsHqlHWsdC = ThreadHelper.CreateFixedTimeStep(this.NloMMgFrvmkQfQeGIPlqyIovVIdK, this.jWyOaOGMJonMQQPqGNsnrqPpQJoh);
					this.BYWhHRPovNebqPvIZkDsHqlHWsdC.ThreadUpdateEvent += this.YIxlqZfjBHQAsMvfmnhbUHrwOFmE;
					this.BYWhHRPovNebqPvIZkDsHqlHWsdC.Start(this.LkihRwBMgwnSxJFZRVEamJSSAopv);
					return true;
				}
				catch (Exception ex)
				{
					string str = "Exception occurred while creating thread!\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null), true);
					if (this.BYWhHRPovNebqPvIZkDsHqlHWsdC != null)
					{
						this.BYWhHRPovNebqPvIZkDsHqlHWsdC.Stop(this.LkihRwBMgwnSxJFZRVEamJSSAopv);
					}
					this.XHEgWeenzqFAowhYRqHFDqmGjYnt = true;
					return false;
				}
			}
			if (!this.BYWhHRPovNebqPvIZkDsHqlHWsdC.isRunning)
			{
				this.BYWhHRPovNebqPvIZkDsHqlHWsdC.Start(this.LkihRwBMgwnSxJFZRVEamJSSAopv);
			}
			else if (this.jWyOaOGMJonMQQPqGNsnrqPpQJoh > 0)
			{
				this.BYWhHRPovNebqPvIZkDsHqlHWsdC.ResetTimeout();
			}
			return true;
		}

		// Token: 0x06003171 RID: 12657 RVA: 0x000AC19C File Offset: 0x000AA39C
		private void QgdjZYvbcxfAaMUNSIxVdZgDmRKPA()
		{
			Queue<T> tnACyfDVFqaEdfBgdIYaADgJLnTGA = this.TnACyfDVFqaEdfBgdIYaADgJLnTGA;
			lock (tnACyfDVFqaEdfBgdIYaADgJLnTGA)
			{
				Queue<T> hwadUpIHjhWpPYaQKzjwzxccmaqk = this.HWadUpIHjhWpPYaQKzjwzxccmaqk;
				lock (hwadUpIHjhWpPYaQKzjwzxccmaqk)
				{
					MiscTools.Swap<Queue<T>>(ref this.TnACyfDVFqaEdfBgdIYaADgJLnTGA, ref this.HWadUpIHjhWpPYaQKzjwzxccmaqk);
				}
			}
		}

		// Token: 0x06003172 RID: 12658 RVA: 0x000AC210 File Offset: 0x000AA410
		private void YIxlqZfjBHQAsMvfmnhbUHrwOFmE()
		{
			this.QgdjZYvbcxfAaMUNSIxVdZgDmRKPA();
			Queue<T> hwadUpIHjhWpPYaQKzjwzxccmaqk = this.HWadUpIHjhWpPYaQKzjwzxccmaqk;
			lock (hwadUpIHjhWpPYaQKzjwzxccmaqk)
			{
				while (this.HWadUpIHjhWpPYaQKzjwzxccmaqk.Count > 0)
				{
					try
					{
						this.utctxXgKZFPRRBjEKgWwhqGVMqeeb(this.HWadUpIHjhWpPYaQKzjwzxccmaqk.Dequeue());
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred while sending message.\nMessage: " + ex.Message, true);
					}
				}
			}
		}

		// Token: 0x06003173 RID: 12659 RVA: 0x00025EA9 File Offset: 0x000240A9
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003174 RID: 12660 RVA: 0x000AC2A0 File Offset: 0x000AA4A0
		~ThreadedMessageQueue()
		{
			this.Dispose(false);
		}

		// Token: 0x06003175 RID: 12661 RVA: 0x000AC2D0 File Offset: 0x000AA4D0
		protected void Dispose(bool disposing)
		{
			if (this.flRjkdNJsIVNkzsmBszViHkvMSyF)
			{
				return;
			}
			if (disposing)
			{
				if (this.TnACyfDVFqaEdfBgdIYaADgJLnTGA != null)
				{
					Queue<T> obj;
					if (this.HWadUpIHjhWpPYaQKzjwzxccmaqk != null)
					{
						obj = this.TnACyfDVFqaEdfBgdIYaADgJLnTGA;
						lock (obj)
						{
							Queue<T> hwadUpIHjhWpPYaQKzjwzxccmaqk = this.HWadUpIHjhWpPYaQKzjwzxccmaqk;
							lock (hwadUpIHjhWpPYaQKzjwzxccmaqk)
							{
								this.TnACyfDVFqaEdfBgdIYaADgJLnTGA.Clear();
								this.HWadUpIHjhWpPYaQKzjwzxccmaqk.Clear();
								goto IL_C5;
							}
						}
					}
					obj = this.TnACyfDVFqaEdfBgdIYaADgJLnTGA;
					lock (obj)
					{
						this.TnACyfDVFqaEdfBgdIYaADgJLnTGA.Clear();
						goto IL_C5;
					}
				}
				if (this.HWadUpIHjhWpPYaQKzjwzxccmaqk != null)
				{
					Queue<T> obj = this.HWadUpIHjhWpPYaQKzjwzxccmaqk;
					lock (obj)
					{
						this.HWadUpIHjhWpPYaQKzjwzxccmaqk.Clear();
					}
				}
				IL_C5:
				if (this.BYWhHRPovNebqPvIZkDsHqlHWsdC != null)
				{
					this.BYWhHRPovNebqPvIZkDsHqlHWsdC.Dispose();
				}
			}
			this.flRjkdNJsIVNkzsmBszViHkvMSyF = true;
		}

		// Token: 0x04001B17 RID: 6935
		private readonly int HUvYaArkFBDIskzPrSTHnGGiqGfEA;

		// Token: 0x04001B18 RID: 6936
		private readonly int NloMMgFrvmkQfQeGIPlqyIovVIdK;

		// Token: 0x04001B19 RID: 6937
		private readonly int jWyOaOGMJonMQQPqGNsnrqPpQJoh;

		// Token: 0x04001B1A RID: 6938
		private readonly bool LkihRwBMgwnSxJFZRVEamJSSAopv;

		// Token: 0x04001B1B RID: 6939
		private ThreadHelper BYWhHRPovNebqPvIZkDsHqlHWsdC;

		// Token: 0x04001B1C RID: 6940
		private Queue<T> TnACyfDVFqaEdfBgdIYaADgJLnTGA;

		// Token: 0x04001B1D RID: 6941
		private Queue<T> HWadUpIHjhWpPYaQKzjwzxccmaqk;

		// Token: 0x04001B1E RID: 6942
		private bool XHEgWeenzqFAowhYRqHFDqmGjYnt;

		// Token: 0x04001B1F RID: 6943
		private bool FeBfHjJPHSwlvqQeTMXmynHlershA;

		// Token: 0x04001B20 RID: 6944
		private Action<T> utctxXgKZFPRRBjEKgWwhqGVMqeeb;

		// Token: 0x04001B21 RID: 6945
		private bool flRjkdNJsIVNkzsmBszViHkvMSyF;
	}
}
