using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x02000481 RID: 1153
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x06002D91 RID: 11665 RVA: 0x000231CD File Offset: 0x000213CD
		internal override int Count
		{
			get
			{
				return this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count;
			}
		}

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x06002D92 RID: 11666 RVA: 0x000231DA File Offset: 0x000213DA
		// (set) Token: 0x06002D93 RID: 11667 RVA: 0x000231E2 File Offset: 0x000213E2
		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return this.sImpmosgfrVmHchZmNAvjeOSPTMM;
			}
			set
			{
				this.sImpmosgfrVmHchZmNAvjeOSPTMM = value;
			}
		}

		// Token: 0x06002D94 RID: 11668 RVA: 0x000A0044 File Offset: 0x0009E244
		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH = new List<SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE>();
			this.RwKgNtaQpyVKKuHmJtjFbwQuCxtfb = new List<SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE>();
			if (this.sImpmosgfrVmHchZmNAvjeOSPTMM == null)
			{
				this.sImpmosgfrVmHchZmNAvjeOSPTMM = SafeDelegate.S_ExceptionHandler;
			}
		}

		// Token: 0x06002D95 RID: 11669 RVA: 0x000231EB File Offset: 0x000213EB
		protected SafeDelegate(Action<Exception> A_1) : this()
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			this.sImpmosgfrVmHchZmNAvjeOSPTMM = A_1;
		}

		// Token: 0x06002D96 RID: 11670 RVA: 0x000A00BC File Offset: 0x0009E2BC
		protected SafeDelegate(SafeDelegate<T> A_1) : this()
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (A_1.sImpmosgfrVmHchZmNAvjeOSPTMM != null)
			{
				this.sImpmosgfrVmHchZmNAvjeOSPTMM = A_1.sImpmosgfrVmHchZmNAvjeOSPTMM;
			}
			for (int i = 0; i < A_1.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count; i++)
			{
				this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Add(new SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE(A_1.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[i]));
			}
		}

		// Token: 0x06002D97 RID: 11671 RVA: 0x000A0124 File Offset: 0x0009E324
		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = SafeDelegate<T>.rDaTQGAsMDbwQOBEYwtKugHVpoOk((Delegate)((object)@delegate));
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T t = (T)((object)list[i]);
				if (!this.LwyOMZgmcWGuwMKdUtjSyhZSfDaU(t))
				{
					this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Add(new SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE(t));
				}
			}
		}

		// Token: 0x06002D98 RID: 11672 RVA: 0x000A0190 File Offset: 0x0009E390
		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = SafeDelegate<T>.rDaTQGAsMDbwQOBEYwtKugHVpoOk((Delegate)((object)@delegate));
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = count - 1; j >= 0; j--)
				{
					if (EqualityComparer<T>.Default.Equals(this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[j].fyDDqbQySTcVxQOGYFsaFekOwmgPA, (T)((object)list[i])))
					{
						this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.RemoveAt(j);
					}
				}
			}
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x000A0224 File Offset: 0x0009E424
		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int i = this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count - 1; i >= 0; i--)
			{
				Delegate @delegate = SafeDelegate<T>.wFatmTQIauGjaghGnsiPfyrXykAUA(obj, (Delegate)((object)this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[i].fyDDqbQySTcVxQOGYFsaFekOwmgPA));
				if (SafeDelegate<T>.hsaqQyNhCOZEXxDhuufusAyeHZf(@delegate) == 0)
				{
					this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.RemoveAt(i);
				}
				else
				{
					this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[i] = new SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE((T)((object)@delegate));
				}
			}
		}

		// Token: 0x06002D9A RID: 11674 RVA: 0x00023208 File Offset: 0x00021408
		internal override void Clear()
		{
			this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Clear();
		}

		// Token: 0x06002D9B RID: 11675 RVA: 0x000A0298 File Offset: 0x0009E498
		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count;
			if (count == 0)
			{
				return;
			}
			this.RwKgNtaQpyVKKuHmJtjFbwQuCxtfb.Clear();
			for (int i = 0; i < count; i++)
			{
				this.RwKgNtaQpyVKKuHmJtjFbwQuCxtfb.Add(this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE vxkBuTDWxIkdueGeuYhgbXaBOwkE = this.RwKgNtaQpyVKKuHmJtjFbwQuCxtfb[j];
				if (vxkBuTDWxIkdueGeuYhgbXaBOwkE.bFJjNTHtsZYdhyoSbCKRHkEmoTHg && vxkBuTDWxIkdueGeuYhgbXaBOwkE.TyNWAvNGTQKXBlOGtgCOdABGGahdA())
				{
					if (list == null)
					{
						list = TempListPool.Get<int>();
					}
					list.Add(j);
				}
				else
				{
					try
					{
						invokeCallback(this, vxkBuTDWxIkdueGeuYhgbXaBOwkE.fyDDqbQySTcVxQOGYFsaFekOwmgPA);
					}
					catch (Exception ex)
					{
						if (this.sImpmosgfrVmHchZmNAvjeOSPTMM != null)
						{
							this.sImpmosgfrVmHchZmNAvjeOSPTMM(ex);
						}
						else if (ex.InnerException != null)
						{
							Logger.LogError(ex.InnerException, true);
						}
						if (list == null)
						{
							list = TempListPool.Get<int>();
						}
						list.Add(j);
					}
				}
			}
			if (list != null)
			{
				for (int k = list.Count - 1; k >= 0; k--)
				{
					this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.RemoveAt(list[k]);
				}
				TempListPool.Return<int>(list);
			}
			if (count > 0)
			{
				this.RwKgNtaQpyVKKuHmJtjFbwQuCxtfb.Clear();
			}
		}

		// Token: 0x06002D9C RID: 11676 RVA: 0x000A03DC File Offset: 0x0009E5DC
		protected T GetCombinedDelegate()
		{
			if (this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH == null)
			{
				return default(T);
			}
			T t = default(T);
			for (int i = 0; i < this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count; i++)
			{
				T fyDDqbQySTcVxQOGYFsaFekOwmgPA = this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[i].fyDDqbQySTcVxQOGYFsaFekOwmgPA;
				if (t == null)
				{
					t = fyDDqbQySTcVxQOGYFsaFekOwmgPA;
				}
				else
				{
					try
					{
						t = (T)((object)Delegate.Combine((Delegate)((object)t), (Delegate)((object)fyDDqbQySTcVxQOGYFsaFekOwmgPA)));
					}
					catch
					{
					}
				}
			}
			return t;
		}

		// Token: 0x06002D9D RID: 11677 RVA: 0x00023215 File Offset: 0x00021415
		private bool LwyOMZgmcWGuwMKdUtjSyhZSfDaU(T A_1)
		{
			return this.MSiggHceqPVIDfErVIcLAUSfbbaRc(A_1) >= 0;
		}

		// Token: 0x06002D9E RID: 11678 RVA: 0x000A0470 File Offset: 0x0009E670
		private int MSiggHceqPVIDfErVIcLAUSfbbaRc(T A_1)
		{
			int count = this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(this.LtgoIfwDDQZIiAWuLqBQDmgHNjbH[i].fyDDqbQySTcVxQOGYFsaFekOwmgPA, A_1))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002D9F RID: 11679 RVA: 0x000A04B8 File Offset: 0x0009E6B8
		private static Delegate wFatmTQIauGjaghGnsiPfyrXykAUA(object A_0, Delegate A_1)
		{
			if (A_1 == null || A_0 == null)
			{
				return A_1;
			}
			if (A_0 is Delegate)
			{
				return SafeDelegate<T>.tzIDGSliqrOEspmnJBDfdzXErWMhA((Delegate)A_0, A_1);
			}
			try
			{
				Delegate[] invocationList = A_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					if (invocationList[i].Target == A_0 || ReflectionTools.GetMethodInfo(invocationList[i]) == A_0)
					{
						if (A_1 == null)
						{
							return A_1;
						}
						A_1 = Delegate.RemoveAll(A_1, invocationList[i]);
					}
				}
			}
			catch (Exception ex)
			{
				string str = "Exception caught while removing delegates from list (1):\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return A_1;
		}

		// Token: 0x06002DA0 RID: 11680 RVA: 0x000A0554 File Offset: 0x0009E754
		private static Delegate tzIDGSliqrOEspmnJBDfdzXErWMhA(Delegate A_0, Delegate A_1)
		{
			if (A_0 == null || A_1 == null)
			{
				return A_1;
			}
			if (A_0.GetType() != A_0.GetType())
			{
				return A_1;
			}
			try
			{
				Delegate[] invocationList = A_0.GetInvocationList();
				Delegate[] invocationList2 = A_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					object methodInfo = ReflectionTools.GetMethodInfo(invocationList[i]);
					foreach (Delegate @delegate in invocationList2)
					{
						object methodInfo2 = ReflectionTools.GetMethodInfo(@delegate);
						if (methodInfo == methodInfo2)
						{
							if (A_1 == null)
							{
								return A_1;
							}
							A_1 = Delegate.RemoveAll(A_1, @delegate);
						}
					}
				}
			}
			catch (Exception ex)
			{
				string str = "Exception caught while removing delegates from list (2):\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return A_1;
		}

		// Token: 0x06002DA1 RID: 11681 RVA: 0x000A0610 File Offset: 0x0009E810
		private static int hsaqQyNhCOZEXxDhuufusAyeHZf(Delegate A_0)
		{
			if (A_0 == null)
			{
				return 0;
			}
			Delegate[] invocationList = A_0.GetInvocationList();
			if (invocationList == null)
			{
				return 0;
			}
			return invocationList.Length;
		}

		// Token: 0x06002DA2 RID: 11682 RVA: 0x000A0634 File Offset: 0x0009E834
		private static List<Delegate> rDaTQGAsMDbwQOBEYwtKugHVpoOk(Delegate A_0)
		{
			if (A_0 == null)
			{
				return null;
			}
			Delegate[] invocationList = ((Delegate)A_0).GetInvocationList();
			if (invocationList == null)
			{
				return null;
			}
			List<Delegate> list = new List<Delegate>(invocationList.Length);
			for (int i = 0; i < invocationList.Length; i++)
			{
				list.Add(invocationList[i]);
			}
			return list;
		}

		// Token: 0x04001994 RID: 6548
		private Action<Exception> sImpmosgfrVmHchZmNAvjeOSPTMM;

		// Token: 0x04001995 RID: 6549
		private readonly List<SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE> LtgoIfwDDQZIiAWuLqBQDmgHNjbH;

		// Token: 0x04001996 RID: 6550
		private readonly List<SafeDelegate<T>.vxkBuTDWxIkdueGeuYhgbXaBOwkE> RwKgNtaQpyVKKuHmJtjFbwQuCxtfb;

		// Token: 0x02000482 RID: 1154
		private class vxkBuTDWxIkdueGeuYhgbXaBOwkE
		{
			// Token: 0x06002DA3 RID: 11683 RVA: 0x000A0678 File Offset: 0x0009E878
			public vxkBuTDWxIkdueGeuYhgbXaBOwkE(\u0001 A_1)
			{
				this.fyDDqbQySTcVxQOGYFsaFekOwmgPA = A_1;
				this.hJVMjDaFrANevmYDAQcbPqVNxvyA = ((Delegate)((object)A_1)).Target;
				try
				{
					this.UlxYnBSNRSqFPpOwGiWbeZqewNrE = ReflectionTools.GetMethodInfo((Delegate)((object)A_1));
				}
				catch
				{
					this.UlxYnBSNRSqFPpOwGiWbeZqewNrE = null;
				}
				this.bFJjNTHtsZYdhyoSbCKRHkEmoTHg = (this.hJVMjDaFrANevmYDAQcbPqVNxvyA != null && this.hJVMjDaFrANevmYDAQcbPqVNxvyA is Object);
			}

			// Token: 0x06002DA4 RID: 11684 RVA: 0x00023224 File Offset: 0x00021424
			public vxkBuTDWxIkdueGeuYhgbXaBOwkE(SafeDelegate<\u0001>.vxkBuTDWxIkdueGeuYhgbXaBOwkE A_1) : this(MiscTools.Clone(A_1.fyDDqbQySTcVxQOGYFsaFekOwmgPA) as \u0001)
			{
			}

			// Token: 0x06002DA5 RID: 11685 RVA: 0x00023246 File Offset: 0x00021446
			public bool TyNWAvNGTQKXBlOGtgCOdABGGahdA()
			{
				return this.hJVMjDaFrANevmYDAQcbPqVNxvyA == null || (this.hJVMjDaFrANevmYDAQcbPqVNxvyA is Object && (Object)this.hJVMjDaFrANevmYDAQcbPqVNxvyA == null);
			}

			// Token: 0x04001997 RID: 6551
			public readonly \u0001 fyDDqbQySTcVxQOGYFsaFekOwmgPA;

			// Token: 0x04001998 RID: 6552
			public readonly object hJVMjDaFrANevmYDAQcbPqVNxvyA;

			// Token: 0x04001999 RID: 6553
			public readonly object UlxYnBSNRSqFPpOwGiWbeZqewNrE;

			// Token: 0x0400199A RID: 6554
			public readonly bool bFJjNTHtsZYdhyoSbCKRHkEmoTHg;
		}
	}
}
