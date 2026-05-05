using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004CB RID: 1227
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadHelper : IDisposable
	{
		// Token: 0x06003145 RID: 12613 RVA: 0x000AB868 File Offset: 0x000A9A68
		public static ThreadHelper Create(bool fixedTimeStep = false, int fixedTimeStepFPS = 100, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			ThreadHelper result;
			if (fixedTimeStep)
			{
				result = new ThreadHelper(fixedTimeStepFPS, useHighPrecisionTimer, timeoutMS);
			}
			else
			{
				result = new ThreadHelper(timeoutMS);
			}
			return result;
		}

		// Token: 0x06003146 RID: 12614 RVA: 0x00025C92 File Offset: 0x00023E92
		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
		{
			return ThreadHelper.CreateFixedTimeStep(timeStepFPS, false, timeoutMS);
		}

		// Token: 0x06003147 RID: 12615 RVA: 0x00025C9C File Offset: 0x00023E9C
		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			return new ThreadHelper(timeStepFPS, useHighPrecisionTimer, timeoutMS);
		}

		// Token: 0x17000B2D RID: 2861
		// (get) Token: 0x06003148 RID: 12616 RVA: 0x00025CA6 File Offset: 0x00023EA6
		public bool isRunning
		{
			get
			{
				return this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb;
			}
		}

		// Token: 0x17000B2E RID: 2862
		// (get) Token: 0x06003149 RID: 12617 RVA: 0x00025CAE File Offset: 0x00023EAE
		public bool isStopped
		{
			get
			{
				return !this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb && (this.KcjUyjgQElPqGibZwuAFTPGncWQbA == null || !this.KcjUyjgQElPqGibZwuAFTPGncWQbA.IsAlive);
			}
		}

		// Token: 0x17000B2F RID: 2863
		// (get) Token: 0x0600314A RID: 12618 RVA: 0x00025CD2 File Offset: 0x00023ED2
		// (set) Token: 0x0600314B RID: 12619 RVA: 0x00025CF0 File Offset: 0x00023EF0
		public bool useHighPrecitionTimer
		{
			get
			{
				return this.nGZCLjKBVAmGdbdegvAEnNGFTLPXA || (long)this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA >= 750L;
			}
			set
			{
				if (value == this.nGZCLjKBVAmGdbdegvAEnNGFTLPXA)
				{
					return;
				}
				this.nGZCLjKBVAmGdbdegvAEnNGFTLPXA = value;
				this.sXgtPLfFLLsotqoPAwmtQyUYCjpR();
			}
		}

		// Token: 0x17000B30 RID: 2864
		// (get) Token: 0x0600314C RID: 12620 RVA: 0x00025D09 File Offset: 0x00023F09
		public bool useFixedTimeStep
		{
			get
			{
				return this.FfPDxUPodYWeDUuiERhQwCMFlGMF;
			}
		}

		// Token: 0x17000B31 RID: 2865
		// (get) Token: 0x0600314D RID: 12621 RVA: 0x00025D11 File Offset: 0x00023F11
		// (set) Token: 0x0600314E RID: 12622 RVA: 0x00025D19 File Offset: 0x00023F19
		public int fixedTimeStepFPS
		{
			get
			{
				return this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA;
			}
			set
			{
				this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA = ((value > 0) ? value : 0);
				this.sXgtPLfFLLsotqoPAwmtQyUYCjpR();
			}
		}

		// Token: 0x17000B32 RID: 2866
		// (get) Token: 0x0600314F RID: 12623 RVA: 0x00025D2F File Offset: 0x00023F2F
		// (set) Token: 0x06003150 RID: 12624 RVA: 0x00025D37 File Offset: 0x00023F37
		public int timeoutMS
		{
			get
			{
				return this.nbrjsrvACQzduswsvnfKkzvcmCEM;
			}
			set
			{
				this.nbrjsrvACQzduswsvnfKkzvcmCEM = ((value > 0) ? value : 0);
				this.sXgtPLfFLLsotqoPAwmtQyUYCjpR();
			}
		}

		// Token: 0x17000B33 RID: 2867
		// (get) Token: 0x06003151 RID: 12625 RVA: 0x00025D4D File Offset: 0x00023F4D
		public uint tick
		{
			get
			{
				return this.HHNgQnHoclmLMsSgCKqropwfZJOt;
			}
		}

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x06003152 RID: 12626 RVA: 0x00025D55 File Offset: 0x00023F55
		// (remove) Token: 0x06003153 RID: 12627 RVA: 0x00025D6E File Offset: 0x00023F6E
		public event Action ThreadUpdateEvent
		{
			add
			{
				this.DKKwIYbAIMYQDsCQqyQqgSHRNNYv = (Action)Delegate.Combine(this.DKKwIYbAIMYQDsCQqyQqgSHRNNYv, value);
			}
			remove
			{
				this.DKKwIYbAIMYQDsCQqyQqgSHRNNYv = (Action)Delegate.Remove(this.DKKwIYbAIMYQDsCQqyQqgSHRNNYv, value);
			}
		}

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x06003154 RID: 12628 RVA: 0x000AB88C File Offset: 0x000A9A8C
		// (remove) Token: 0x06003155 RID: 12629 RVA: 0x000AB8C4 File Offset: 0x000A9AC4
		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = this.EBRIlKrZGpKVrtZDuJoimIyVqxdw;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange<Action>(ref this.EBRIlKrZGpKVrtZDuJoimIyVqxdw, value2, action2);
				}
				while (action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.EBRIlKrZGpKVrtZDuJoimIyVqxdw;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange<Action>(ref this.EBRIlKrZGpKVrtZDuJoimIyVqxdw, value2, action2);
				}
				while (action != action2);
			}
		}

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x06003156 RID: 12630 RVA: 0x00025D87 File Offset: 0x00023F87
		// (remove) Token: 0x06003157 RID: 12631 RVA: 0x00025D90 File Offset: 0x00023F90
		public event Action ThreadStartedEvent
		{
			add
			{
				this._ThreadStartedEvent += value;
			}
			remove
			{
				this._ThreadStartedEvent -= value;
			}
		}

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x06003158 RID: 12632 RVA: 0x000AB8FC File Offset: 0x000A9AFC
		// (remove) Token: 0x06003159 RID: 12633 RVA: 0x000AB934 File Offset: 0x000A9B34
		private event Action _ThreadPreStopEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange<Action>(ref this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA, value2, action2);
				}
				while (action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange<Action>(ref this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA, value2, action2);
				}
				while (action != action2);
			}
		}

		// Token: 0x1400006F RID: 111
		// (add) Token: 0x0600315A RID: 12634 RVA: 0x00025D99 File Offset: 0x00023F99
		// (remove) Token: 0x0600315B RID: 12635 RVA: 0x00025DA2 File Offset: 0x00023FA2
		public event Action ThreadPreStopEvent
		{
			add
			{
				this._ThreadPreStopEvent += value;
			}
			remove
			{
				this._ThreadPreStopEvent -= value;
			}
		}

		// Token: 0x0600315C RID: 12636 RVA: 0x00025DAB File Offset: 0x00023FAB
		private ThreadHelper() : this(0)
		{
		}

		// Token: 0x0600315D RID: 12637 RVA: 0x00025DB4 File Offset: 0x00023FB4
		private ThreadHelper(int A_1) : this(0, false, A_1)
		{
		}

		// Token: 0x0600315E RID: 12638 RVA: 0x000AB96C File Offset: 0x000A9B6C
		private ThreadHelper(int A_1, bool A_2, int A_3)
		{
			this.KdjkMIrKRSAGMGdCinJstmvjFEUlA = Stopwatch.Global;
			if (A_1 < 0)
			{
				A_1 = 0;
			}
			if (A_3 < 0)
			{
				A_3 = 0;
			}
			this.nbrjsrvACQzduswsvnfKkzvcmCEM = A_3;
			this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA = A_1;
			this.nGZCLjKBVAmGdbdegvAEnNGFTLPXA = A_2;
			this.sXgtPLfFLLsotqoPAwmtQyUYCjpR();
			this.PWScEJVxBUHcjykwslxNwBZNhmAh = new ManualResetEvent(false);
			this.tPSMNSfeZIdhBQDlDkLaOPjGtkOW = new ManualResetEvent(false);
			this.tiMFFCGGlnOyhJNNdUOPwoeDBjYU = new AutoResetEvent(false);
			this.EhUOtomyoeHKpgPGtyICCvHuEmbT = new object();
			this.DWncyRkxDdSFDuZQTfDdCgdjHehc = new Queue<Action>();
			this.SXVBMBpnoYFrBsjVrbShxgiGfAIh = new Queue<Action>();
		}

		// Token: 0x0600315F RID: 12639 RVA: 0x000AB9F8 File Offset: 0x000A9BF8
		public bool Start(bool wait)
		{
			if (this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb)
			{
				return false;
			}
			bool result;
			try
			{
				this.PWScEJVxBUHcjykwslxNwBZNhmAh.Reset();
				this.tiMFFCGGlnOyhJNNdUOPwoeDBjYU.Reset();
				this.KcjUyjgQElPqGibZwuAFTPGncWQbA = new Thread(new ThreadStart(this.VKYzPpwowcGLDhsxymsfwunpIrFCb));
				this.KcjUyjgQElPqGibZwuAFTPGncWQbA.Start();
				if (wait)
				{
					this.PWScEJVxBUHcjykwslxNwBZNhmAh.WaitOne();
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06003160 RID: 12640 RVA: 0x000ABA74 File Offset: 0x000A9C74
		public void Stop(bool wait)
		{
			if (this.KcjUyjgQElPqGibZwuAFTPGncWQbA == null)
			{
				return;
			}
			if (!this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb)
			{
				return;
			}
			if (!this.kHjLOCBTHzgrUdBoznoVRefuTtdX)
			{
				return;
			}
			this.PWScEJVxBUHcjykwslxNwBZNhmAh.Reset();
			this.kHjLOCBTHzgrUdBoznoVRefuTtdX = false;
			this.tiMFFCGGlnOyhJNNdUOPwoeDBjYU.Set();
			if (wait)
			{
				this.PWScEJVxBUHcjykwslxNwBZNhmAh.WaitOne();
			}
			this.xtmmCiiHMyHCQZGuPfZECcySSZFG();
		}

		// Token: 0x06003161 RID: 12641 RVA: 0x000ABAD0 File Offset: 0x000A9CD0
		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb)
			{
				return false;
			}
			if (!this.kHjLOCBTHzgrUdBoznoVRefuTtdX)
			{
				return false;
			}
			this.ResetTimeout();
			object ehUOtomyoeHKpgPGtyICCvHuEmbT = this.EhUOtomyoeHKpgPGtyICCvHuEmbT;
			lock (ehUOtomyoeHKpgPGtyICCvHuEmbT)
			{
				this.DWncyRkxDdSFDuZQTfDdCgdjHehc.Enqueue(action);
				this.oOKFXmHlxqSEFAQbDiQWnAGBMimy = true;
				this.tiMFFCGGlnOyhJNNdUOPwoeDBjYU.Set();
			}
			return true;
		}

		// Token: 0x06003162 RID: 12642 RVA: 0x00025DBF File Offset: 0x00023FBF
		public bool InvokeActionSync(Action action)
		{
			if (!this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb)
			{
				return false;
			}
			if (!this.kHjLOCBTHzgrUdBoznoVRefuTtdX)
			{
				return false;
			}
			this.EnqueueAction(action);
			this.WaitForActionQueueToFinish();
			return true;
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x000ABB4C File Offset: 0x000A9D4C
		public void WaitForActionQueueToFinish()
		{
			if (!this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb)
			{
				return;
			}
			if (!this.kHjLOCBTHzgrUdBoznoVRefuTtdX)
			{
				return;
			}
			this.ResetTimeout();
			object ehUOtomyoeHKpgPGtyICCvHuEmbT = this.EhUOtomyoeHKpgPGtyICCvHuEmbT;
			lock (ehUOtomyoeHKpgPGtyICCvHuEmbT)
			{
				this.tPSMNSfeZIdhBQDlDkLaOPjGtkOW.Reset();
				this.hVaWGkigAQalxeZoyDYnakbSCcSuA++;
			}
			this.tiMFFCGGlnOyhJNNdUOPwoeDBjYU.Set();
			this.tPSMNSfeZIdhBQDlDkLaOPjGtkOW.WaitOne();
			ehUOtomyoeHKpgPGtyICCvHuEmbT = this.EhUOtomyoeHKpgPGtyICCvHuEmbT;
			lock (ehUOtomyoeHKpgPGtyICCvHuEmbT)
			{
				this.hVaWGkigAQalxeZoyDYnakbSCcSuA--;
			}
		}

		// Token: 0x06003164 RID: 12644 RVA: 0x00025DE4 File Offset: 0x00023FE4
		public void ResetTimeout()
		{
			this.XOtANSnnWlvAlWndzZhCeyBSTEio = ((this.nbrjsrvACQzduswsvnfKkzvcmCEM > 0) ? (this.KdjkMIrKRSAGMGdCinJstmvjFEUlA.elapsedMillisecondsRaw + (long)this.nbrjsrvACQzduswsvnfKkzvcmCEM) : 0L);
		}

		// Token: 0x06003165 RID: 12645 RVA: 0x000ABC08 File Offset: 0x000A9E08
		private void VKYzPpwowcGLDhsxymsfwunpIrFCb()
		{
			this.ResetTimeout();
			this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb = true;
			this.kHjLOCBTHzgrUdBoznoVRefuTtdX = true;
			this.PWScEJVxBUHcjykwslxNwBZNhmAh.Set();
			if (this.EBRIlKrZGpKVrtZDuJoimIyVqxdw == null)
			{
				goto IL_19F;
			}
			Action obj = this.EBRIlKrZGpKVrtZDuJoimIyVqxdw;
			lock (obj)
			{
				try
				{
					this.EBRIlKrZGpKVrtZDuJoimIyVqxdw();
					goto IL_19F;
				}
				catch (Exception ex)
				{
					string str = "Caught exception in thread start event callback.\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null), true);
					goto IL_19F;
				}
			}
			IL_79:
			long num = this.KdjkMIrKRSAGMGdCinJstmvjFEUlA.elapsedTicksRaw + this.WZsmbCBDqmraQqGUcerZISKmCTxEb;
			this.isuomgxYFpHdwkCiHVnzYkxReFRo();
			object ehUOtomyoeHKpgPGtyICCvHuEmbT = this.EhUOtomyoeHKpgPGtyICCvHuEmbT;
			lock (ehUOtomyoeHKpgPGtyICCvHuEmbT)
			{
				if (!this.oOKFXmHlxqSEFAQbDiQWnAGBMimy && this.hVaWGkigAQalxeZoyDYnakbSCcSuA > 0)
				{
					this.tPSMNSfeZIdhBQDlDkLaOPjGtkOW.Set();
				}
			}
			if (this.DKKwIYbAIMYQDsCQqyQqgSHRNNYv != null)
			{
				try
				{
					this.DKKwIYbAIMYQDsCQqyQqgSHRNNYv();
				}
				catch (Exception ex3)
				{
					string str2 = "Exception occurred in a Thread Update Event callback.\n";
					Exception ex4 = ex3;
					Logger.LogError(str2 + ((ex4 != null) ? ex4.ToString() : null), true);
				}
			}
			if (this.FfPDxUPodYWeDUuiERhQwCMFlGMF)
			{
				if (this.nGZCLjKBVAmGdbdegvAEnNGFTLPXA || (long)this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA >= 750L)
				{
					while (this.KdjkMIrKRSAGMGdCinJstmvjFEUlA.elapsedTicksRaw < num)
					{
					}
				}
				else
				{
					long num2 = num - this.KdjkMIrKRSAGMGdCinJstmvjFEUlA.elapsedTicksRaw;
					if (num2 > 0L)
					{
						this.tiMFFCGGlnOyhJNNdUOPwoeDBjYU.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
					}
				}
			}
			this.HHNgQnHoclmLMsSgCKqropwfZJOt = ((this.HHNgQnHoclmLMsSgCKqropwfZJOt == uint.MaxValue) ? 0U : (this.HHNgQnHoclmLMsSgCKqropwfZJOt + 1U));
			if (this.nbrjsrvACQzduswsvnfKkzvcmCEM > 0 && this.KdjkMIrKRSAGMGdCinJstmvjFEUlA.elapsedMillisecondsRaw >= this.XOtANSnnWlvAlWndzZhCeyBSTEio)
			{
				this.kHjLOCBTHzgrUdBoznoVRefuTtdX = false;
			}
			IL_19F:
			if (!this.kHjLOCBTHzgrUdBoznoVRefuTtdX)
			{
				if (this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA != null)
				{
					obj = this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA;
					lock (obj)
					{
						try
						{
							this.KLnwdwfkfbemqQbBTgeOdMmZMXJxA();
						}
						catch (Exception ex5)
						{
							string str3 = "Caught exception in thread pre-stop event event callback.\n";
							Exception ex6 = ex5;
							Logger.LogError(str3 + ((ex6 != null) ? ex6.ToString() : null), true);
						}
					}
				}
				this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb = false;
				this.PWScEJVxBUHcjykwslxNwBZNhmAh.Set();
				return;
			}
			goto IL_79;
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x000ABE70 File Offset: 0x000AA070
		private void isuomgxYFpHdwkCiHVnzYkxReFRo()
		{
			if (!this.oOKFXmHlxqSEFAQbDiQWnAGBMimy)
			{
				return;
			}
			object ehUOtomyoeHKpgPGtyICCvHuEmbT = this.EhUOtomyoeHKpgPGtyICCvHuEmbT;
			lock (ehUOtomyoeHKpgPGtyICCvHuEmbT)
			{
				MiscTools.Swap<Queue<Action>>(ref this.DWncyRkxDdSFDuZQTfDdCgdjHehc, ref this.SXVBMBpnoYFrBsjVrbShxgiGfAIh);
				this.oOKFXmHlxqSEFAQbDiQWnAGBMimy = false;
				goto IL_72;
			}
			IL_3E:
			Action action = this.SXVBMBpnoYFrBsjVrbShxgiGfAIh.Dequeue();
			try
			{
				action();
			}
			catch (Exception ex)
			{
				string str = "Exception occurred while processing thread Action queue.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null), true);
			}
			IL_72:
			if (this.SXVBMBpnoYFrBsjVrbShxgiGfAIh.Count <= 0)
			{
				return;
			}
			goto IL_3E;
		}

		// Token: 0x06003167 RID: 12647 RVA: 0x00025E0C File Offset: 0x0002400C
		private void sXgtPLfFLLsotqoPAwmtQyUYCjpR()
		{
			if (this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA <= 0)
			{
				this.FfPDxUPodYWeDUuiERhQwCMFlGMF = false;
			}
			else
			{
				this.FfPDxUPodYWeDUuiERhQwCMFlGMF = true;
				this.WZsmbCBDqmraQqGUcerZISKmCTxEb = Stopwatch.frequency / (long)this.fmZEeQCZVtgiMDqiGUvmQlCFLLTXA;
			}
			this.ResetTimeout();
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x000ABF1C File Offset: 0x000AA11C
		private void xtmmCiiHMyHCQZGuPfZECcySSZFG()
		{
			this.KcjUyjgQElPqGibZwuAFTPGncWQbA = null;
			this.eHlwbsAagCiXHAGRDHqUEOsdLWwzb = false;
			this.kHjLOCBTHzgrUdBoznoVRefuTtdX = false;
			this.DWncyRkxDdSFDuZQTfDdCgdjHehc.Clear();
			this.SXVBMBpnoYFrBsjVrbShxgiGfAIh.Clear();
			this.oOKFXmHlxqSEFAQbDiQWnAGBMimy = false;
			this.hVaWGkigAQalxeZoyDYnakbSCcSuA = 0;
			this.PWScEJVxBUHcjykwslxNwBZNhmAh.Reset();
			this.tPSMNSfeZIdhBQDlDkLaOPjGtkOW.Reset();
			this.XOtANSnnWlvAlWndzZhCeyBSTEio = 0L;
			this.HHNgQnHoclmLMsSgCKqropwfZJOt = 0U;
		}

		// Token: 0x06003169 RID: 12649 RVA: 0x00025E40 File Offset: 0x00024040
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600316A RID: 12650 RVA: 0x000ABF8C File Offset: 0x000AA18C
		~ThreadHelper()
		{
			this.Dispose(false);
		}

		// Token: 0x0600316B RID: 12651 RVA: 0x00025E4F File Offset: 0x0002404F
		protected void Dispose(bool disposing)
		{
			if (this.aAVIpdikkpkNycXDCzgUjTZlfzcF)
			{
				return;
			}
			if (disposing)
			{
				this.Stop(true);
			}
			else
			{
				this.kHjLOCBTHzgrUdBoznoVRefuTtdX = false;
			}
			this.aAVIpdikkpkNycXDCzgUjTZlfzcF = true;
		}

		// Token: 0x0600316C RID: 12652 RVA: 0x00025E74 File Offset: 0x00024074
		[Conditional("DEBUG_THREAD_HELPER")]
		private static void QYpjUldoGfEvUKAOKNdHFuodtVkm(object A_0)
		{
			if (A_0 == null)
			{
				return;
			}
			Logger.Log(A_0, true);
		}

		// Token: 0x04001AFF RID: 6911
		private const uint CJZUiFDoSupolKDPkPDTllaMDGnK = 750U;

		// Token: 0x04001B00 RID: 6912
		private readonly Stopwatch KdjkMIrKRSAGMGdCinJstmvjFEUlA;

		// Token: 0x04001B01 RID: 6913
		private Thread KcjUyjgQElPqGibZwuAFTPGncWQbA;

		// Token: 0x04001B02 RID: 6914
		private ManualResetEvent PWScEJVxBUHcjykwslxNwBZNhmAh;

		// Token: 0x04001B03 RID: 6915
		private ManualResetEvent tPSMNSfeZIdhBQDlDkLaOPjGtkOW;

		// Token: 0x04001B04 RID: 6916
		private AutoResetEvent tiMFFCGGlnOyhJNNdUOPwoeDBjYU;

		// Token: 0x04001B05 RID: 6917
		private bool kHjLOCBTHzgrUdBoznoVRefuTtdX;

		// Token: 0x04001B06 RID: 6918
		private bool eHlwbsAagCiXHAGRDHqUEOsdLWwzb;

		// Token: 0x04001B07 RID: 6919
		private int hVaWGkigAQalxeZoyDYnakbSCcSuA;

		// Token: 0x04001B08 RID: 6920
		private bool nGZCLjKBVAmGdbdegvAEnNGFTLPXA;

		// Token: 0x04001B09 RID: 6921
		private int fmZEeQCZVtgiMDqiGUvmQlCFLLTXA;

		// Token: 0x04001B0A RID: 6922
		private long WZsmbCBDqmraQqGUcerZISKmCTxEb;

		// Token: 0x04001B0B RID: 6923
		private bool FfPDxUPodYWeDUuiERhQwCMFlGMF;

		// Token: 0x04001B0C RID: 6924
		private int nbrjsrvACQzduswsvnfKkzvcmCEM;

		// Token: 0x04001B0D RID: 6925
		private long XOtANSnnWlvAlWndzZhCeyBSTEio;

		// Token: 0x04001B0E RID: 6926
		private uint HHNgQnHoclmLMsSgCKqropwfZJOt;

		// Token: 0x04001B0F RID: 6927
		private readonly object EhUOtomyoeHKpgPGtyICCvHuEmbT;

		// Token: 0x04001B10 RID: 6928
		private Queue<Action> DWncyRkxDdSFDuZQTfDdCgdjHehc;

		// Token: 0x04001B11 RID: 6929
		private Queue<Action> SXVBMBpnoYFrBsjVrbShxgiGfAIh;

		// Token: 0x04001B12 RID: 6930
		private bool oOKFXmHlxqSEFAQbDiQWnAGBMimy;

		// Token: 0x04001B13 RID: 6931
		private Action DKKwIYbAIMYQDsCQqyQqgSHRNNYv;

		// Token: 0x04001B14 RID: 6932
		[CompilerGenerated]
		private Action EBRIlKrZGpKVrtZDuJoimIyVqxdw;

		// Token: 0x04001B15 RID: 6933
		[CompilerGenerated]
		private Action KLnwdwfkfbemqQbBTgeOdMmZMXJxA;

		// Token: 0x04001B16 RID: 6934
		private bool aAVIpdikkpkNycXDCzgUjTZlfzcF;
	}
}
