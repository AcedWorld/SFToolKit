using System;
using System.Collections.Generic;
using Unity.Collections;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000451 RID: 1105
	internal class NativePagedList<T> : IDisposable where T : struct
	{
		// Token: 0x0600228C RID: 8844 RVA: 0x00084F98 File Offset: 0x00083198
		public NativePagedList(int poolCapacity)
		{
			Debug.Assert(poolCapacity > 0);
			this.k_PoolCapacity = Mathf.NextPowerOfTwo(poolCapacity);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x00084FD0 File Offset: 0x000831D0
		public void Add(ref T data)
		{
			bool flag = this.m_CurrentPageCount < this.m_CurrentPage.Length;
			if (flag)
			{
				int currentPageCount = this.m_CurrentPageCount;
				this.m_CurrentPageCount = currentPageCount + 1;
				this.m_CurrentPage[currentPageCount] = data;
			}
			else
			{
				int length = (this.m_Pages.Count > 0) ? (this.m_CurrentPage.Length << 1) : this.k_PoolCapacity;
				this.m_CurrentPage = new NativeArray<T>(length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				this.m_Pages.Add(this.m_CurrentPage);
				this.m_CurrentPage[0] = data;
				this.m_CurrentPageCount = 1;
			}
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x00085079 File Offset: 0x00083279
		public void Add(T data)
		{
			this.Add(ref data);
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x00085088 File Offset: 0x00083288
		public List<NativeSlice<T>> GetPages()
		{
			this.m_Enumerator.Clear();
			bool flag = this.m_Pages.Count > 0;
			if (flag)
			{
				int num = this.m_Pages.Count - 1;
				for (int i = 0; i < num; i++)
				{
					this.m_Enumerator.Add(this.m_Pages[i]);
				}
				bool flag2 = this.m_CurrentPageCount > 0;
				if (flag2)
				{
					this.m_Enumerator.Add(this.m_CurrentPage.Slice(0, this.m_CurrentPageCount));
				}
			}
			return this.m_Enumerator;
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x0008512C File Offset: 0x0008332C
		public void Reset()
		{
			bool flag = this.m_Pages.Count > 1;
			if (flag)
			{
				this.m_CurrentPage = this.m_Pages[0];
				for (int i = 1; i < this.m_Pages.Count; i++)
				{
					this.m_Pages[i].Dispose();
				}
				this.m_Pages.Clear();
				this.m_Pages.Add(this.m_CurrentPage);
			}
			this.m_CurrentPageCount = 0;
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06002291 RID: 8849 RVA: 0x000851B4 File Offset: 0x000833B4
		// (set) Token: 0x06002292 RID: 8850 RVA: 0x000851BC File Offset: 0x000833BC
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002293 RID: 8851 RVA: 0x000851C5 File Offset: 0x000833C5
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x000851D8 File Offset: 0x000833D8
		protected void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					for (int i = 0; i < this.m_Pages.Count; i++)
					{
						this.m_Pages[i].Dispose();
					}
					this.m_Pages.Clear();
					this.m_CurrentPageCount = 0;
				}
				this.disposed = true;
			}
		}

		// Token: 0x04000F73 RID: 3955
		private readonly int k_PoolCapacity;

		// Token: 0x04000F74 RID: 3956
		private List<NativeArray<T>> m_Pages = new List<NativeArray<T>>(8);

		// Token: 0x04000F75 RID: 3957
		private NativeArray<T> m_CurrentPage;

		// Token: 0x04000F76 RID: 3958
		private int m_CurrentPageCount;

		// Token: 0x04000F77 RID: 3959
		private List<NativeSlice<T>> m_Enumerator = new List<NativeSlice<T>>(8);
	}
}
