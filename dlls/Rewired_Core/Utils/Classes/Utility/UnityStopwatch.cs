using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004DB RID: 1243
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		// Token: 0x17000B52 RID: 2898
		// (get) Token: 0x060031E3 RID: 12771 RVA: 0x00026399 File Offset: 0x00024599
		public static UnityStopwatch Global
		{
			get
			{
				UnityStopwatch result;
				if ((result = UnityStopwatch.psTeSsixzoXkIRUyaqIMfehAlhMyB) == null)
				{
					result = (UnityStopwatch.psTeSsixzoXkIRUyaqIMfehAlhMyB = new UnityStopwatch(true));
				}
				return result;
			}
		}

		// Token: 0x17000B53 RID: 2899
		// (get) Token: 0x060031E4 RID: 12772 RVA: 0x000263B0 File Offset: 0x000245B0
		public static long frequency
		{
			get
			{
				return 10000000L;
			}
		}

		// Token: 0x060031E5 RID: 12773 RVA: 0x000263B8 File Offset: 0x000245B8
		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		// Token: 0x060031E6 RID: 12774 RVA: 0x0000612A File Offset: 0x0000432A
		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		// Token: 0x17000B54 RID: 2900
		// (get) Token: 0x060031E7 RID: 12775 RVA: 0x000263C6 File Offset: 0x000245C6
		// (set) Token: 0x060031E8 RID: 12776 RVA: 0x000263CE File Offset: 0x000245CE
		public override double offsetSeconds
		{
			get
			{
				return this.LwUYUkSzNNFxkLLsYnWRrtGQptCf;
			}
			set
			{
				this.LwUYUkSzNNFxkLLsYnWRrtGQptCf = value;
			}
		}

		// Token: 0x17000B55 RID: 2901
		// (get) Token: 0x060031E9 RID: 12777 RVA: 0x000263D7 File Offset: 0x000245D7
		// (set) Token: 0x060031EA RID: 12778 RVA: 0x000263EA File Offset: 0x000245EA
		public override long offsetTicks
		{
			get
			{
				return (long)(this.LwUYUkSzNNFxkLLsYnWRrtGQptCf * 10000000.0);
			}
			set
			{
				this.LwUYUkSzNNFxkLLsYnWRrtGQptCf = (double)value / 10000000.0;
			}
		}

		// Token: 0x17000B56 RID: 2902
		// (get) Token: 0x060031EB RID: 12779 RVA: 0x000263FE File Offset: 0x000245FE
		public override double elapsedSeconds
		{
			get
			{
				return this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.fpTvJomexyZPkMpCExUUwDhUIaPeA + this.offsetSeconds;
			}
		}

		// Token: 0x17000B57 RID: 2903
		// (get) Token: 0x060031EC RID: 12780 RVA: 0x00026412 File Offset: 0x00024612
		public override double elapsedSecondsRaw
		{
			get
			{
				return this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.fpTvJomexyZPkMpCExUUwDhUIaPeA;
			}
		}

		// Token: 0x17000B58 RID: 2904
		// (get) Token: 0x060031ED RID: 12781 RVA: 0x0002641F File Offset: 0x0002461F
		public override long elapsedMilliseconds
		{
			get
			{
				return (long)((this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.fpTvJomexyZPkMpCExUUwDhUIaPeA + this.LwUYUkSzNNFxkLLsYnWRrtGQptCf) * 1000.0);
			}
		}

		// Token: 0x17000B59 RID: 2905
		// (get) Token: 0x060031EE RID: 12782 RVA: 0x0002643E File Offset: 0x0002463E
		public override long elapsedMillisecondsRaw
		{
			get
			{
				return (long)(this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.fpTvJomexyZPkMpCExUUwDhUIaPeA * 1000.0);
			}
		}

		// Token: 0x17000B5A RID: 2906
		// (get) Token: 0x060031EF RID: 12783 RVA: 0x00026456 File Offset: 0x00024656
		public override long elapsedTicks
		{
			get
			{
				return (long)(this.elapsedSeconds * 10000000.0);
			}
		}

		// Token: 0x17000B5B RID: 2907
		// (get) Token: 0x060031F0 RID: 12784 RVA: 0x00026469 File Offset: 0x00024669
		public override long elapsedTicksRaw
		{
			get
			{
				return (long)(this.elapsedSecondsRaw * 10000000.0);
			}
		}

		// Token: 0x17000B5C RID: 2908
		// (get) Token: 0x060031F1 RID: 12785 RVA: 0x0002647C File Offset: 0x0002467C
		public override bool isRunning
		{
			get
			{
				return this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.JSxrtsdFmSpgAykMlGpjLVzKLlCS;
			}
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x00026489 File Offset: 0x00024689
		public UnityStopwatch() : this(false)
		{
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x00026492 File Offset: 0x00024692
		private UnityStopwatch(bool A_1)
		{
			this.FyxggxDCwfnlfqjntzFwwDLXeoFbA = new UnityStopwatch.FtKGwQgRoYYcRZfopDyfajxdZsGMA();
			this.igVZqDHrxCOVWwTEhcviGNBSRxNi();
			if (A_1)
			{
				this.Start();
			}
			this.crHgvIhUZkobRwuviLpvArebWFNI = A_1;
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x000AD08C File Offset: 0x000AB28C
		~UnityStopwatch()
		{
			this.LhaWBlTAmeDCYWITVPlbMOffbnvc();
		}

		// Token: 0x060031F5 RID: 12789 RVA: 0x000264BB File Offset: 0x000246BB
		public override void Stop()
		{
			if (this.crHgvIhUZkobRwuviLpvArebWFNI)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.VbaNSTBNOqSxJrhrHPoVAmkkyiuM();
		}

		// Token: 0x060031F6 RID: 12790 RVA: 0x000264DB File Offset: 0x000246DB
		public override void Start()
		{
			if (this.crHgvIhUZkobRwuviLpvArebWFNI)
			{
				return;
			}
			this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.UAPREIvBiqIzfalXbjdpATkFFIjcb();
		}

		// Token: 0x060031F7 RID: 12791 RVA: 0x000264F1 File Offset: 0x000246F1
		public override void Reset()
		{
			if (this.crHgvIhUZkobRwuviLpvArebWFNI)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.wDhhtFBgYQTOurvGEXSlJLmRPJIMA();
		}

		// Token: 0x060031F8 RID: 12792 RVA: 0x00026511 File Offset: 0x00024711
		private void igVZqDHrxCOVWwTEhcviGNBSRxNi()
		{
			this.LhaWBlTAmeDCYWITVPlbMOffbnvc();
			ReInput.BeforeTimeManagerUpdateEvent += this.ROnKdohOlzWACbINdGHzeuzJWwAK;
		}

		// Token: 0x060031F9 RID: 12793 RVA: 0x0002652A File Offset: 0x0002472A
		private void LhaWBlTAmeDCYWITVPlbMOffbnvc()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= this.ROnKdohOlzWACbINdGHzeuzJWwAK;
		}

		// Token: 0x060031FA RID: 12794 RVA: 0x0002653D File Offset: 0x0002473D
		private void ROnKdohOlzWACbINdGHzeuzJWwAK(UpdateLoopType A_1)
		{
			this.FyxggxDCwfnlfqjntzFwwDLXeoFbA.VSReTuOYouDskMqoCqBEhutnIhFM();
		}

		// Token: 0x04001B51 RID: 6993
		private const long ElKbAixhQJGXEGlcQRFprZlPttmOA = 10000000L;

		// Token: 0x04001B52 RID: 6994
		private static UnityStopwatch psTeSsixzoXkIRUyaqIMfehAlhMyB;

		// Token: 0x04001B53 RID: 6995
		private readonly UnityStopwatch.FtKGwQgRoYYcRZfopDyfajxdZsGMA FyxggxDCwfnlfqjntzFwwDLXeoFbA;

		// Token: 0x04001B54 RID: 6996
		private readonly bool crHgvIhUZkobRwuviLpvArebWFNI;

		// Token: 0x04001B55 RID: 6997
		private double LwUYUkSzNNFxkLLsYnWRrtGQptCf;

		// Token: 0x020004DC RID: 1244
		private class FtKGwQgRoYYcRZfopDyfajxdZsGMA
		{
			// Token: 0x17000B5D RID: 2909
			// (get) Token: 0x060031FB RID: 12795 RVA: 0x0002654A File Offset: 0x0002474A
			public bool JSxrtsdFmSpgAykMlGpjLVzKLlCS
			{
				get
				{
					return this.dfoGKFgMlECzgbwpikwkNTTxlzvAA;
				}
			}

			// Token: 0x17000B5E RID: 2910
			// (get) Token: 0x060031FC RID: 12796 RVA: 0x00026552 File Offset: 0x00024752
			public double fpTvJomexyZPkMpCExUUwDhUIaPeA
			{
				get
				{
					if (!this.dfoGKFgMlECzgbwpikwkNTTxlzvAA)
					{
						return this.JXewGwshjkmJvGXHIICtYJFWXGbA;
					}
					return (double)Time.realtimeSinceStartup - this.ZyYPSFWANuzWsfQNemWEIHpqzrbc;
				}
			}

			// Token: 0x060031FE RID: 12798 RVA: 0x00026570 File Offset: 0x00024770
			public void VSReTuOYouDskMqoCqBEhutnIhFM()
			{
				this.lFDlvhlVmnIBckficAdRHopjJkxQA = (double)Time.realtimeSinceStartup;
			}

			// Token: 0x060031FF RID: 12799 RVA: 0x0002657E File Offset: 0x0002477E
			public void UAPREIvBiqIzfalXbjdpATkFFIjcb()
			{
				if (this.dfoGKFgMlECzgbwpikwkNTTxlzvAA)
				{
					return;
				}
				this.dfoGKFgMlECzgbwpikwkNTTxlzvAA = true;
				this.ZyYPSFWANuzWsfQNemWEIHpqzrbc = this.lFDlvhlVmnIBckficAdRHopjJkxQA;
			}

			// Token: 0x06003200 RID: 12800 RVA: 0x0002659C File Offset: 0x0002479C
			public void VbaNSTBNOqSxJrhrHPoVAmkkyiuM()
			{
				if (!this.dfoGKFgMlECzgbwpikwkNTTxlzvAA)
				{
					return;
				}
				this.dfoGKFgMlECzgbwpikwkNTTxlzvAA = false;
				this.JXewGwshjkmJvGXHIICtYJFWXGbA += this.lFDlvhlVmnIBckficAdRHopjJkxQA - this.ZyYPSFWANuzWsfQNemWEIHpqzrbc;
			}

			// Token: 0x06003201 RID: 12801 RVA: 0x000265C8 File Offset: 0x000247C8
			public void wDhhtFBgYQTOurvGEXSlJLmRPJIMA()
			{
				this.ZyYPSFWANuzWsfQNemWEIHpqzrbc = 0.0;
				this.JXewGwshjkmJvGXHIICtYJFWXGbA = 0.0;
				bool flag = this.dfoGKFgMlECzgbwpikwkNTTxlzvAA;
				this.dfoGKFgMlECzgbwpikwkNTTxlzvAA = false;
				if (flag)
				{
					this.UAPREIvBiqIzfalXbjdpATkFFIjcb();
				}
			}

			// Token: 0x04001B56 RID: 6998
			public const long seGivNEJOBBJeKgtTzQcEUEuGgyjA = 10000000L;

			// Token: 0x04001B57 RID: 6999
			private double lFDlvhlVmnIBckficAdRHopjJkxQA;

			// Token: 0x04001B58 RID: 7000
			private bool dfoGKFgMlECzgbwpikwkNTTxlzvAA;

			// Token: 0x04001B59 RID: 7001
			private double ZyYPSFWANuzWsfQNemWEIHpqzrbc;

			// Token: 0x04001B5A RID: 7002
			private double JXewGwshjkmJvGXHIICtYJFWXGbA;
		}
	}
}
