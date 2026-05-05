using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004EF RID: 1263
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	[Serializable]
	internal sealed class RingBuffer<T> : ICollection<!0>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x17000BB2 RID: 2994
		// (get) Token: 0x06003321 RID: 13089 RVA: 0x000273BA File Offset: 0x000255BA
		public int Count
		{
			get
			{
				return this.VzySJJMHgRZFujDtfkOVrZbpRHQK;
			}
		}

		// Token: 0x17000BB3 RID: 2995
		// (get) Token: 0x06003322 RID: 13090 RVA: 0x000273C2 File Offset: 0x000255C2
		public int Capacity
		{
			get
			{
				return this.pmRmFlPQfJMQSucQaEihTZGHphju;
			}
		}

		// Token: 0x17000BB4 RID: 2996
		// (get) Token: 0x06003323 RID: 13091 RVA: 0x000273CA File Offset: 0x000255CA
		public int OverrunCount
		{
			get
			{
				return this.pWRxIKdkXyhIZmfrZGfNuyxjMAMD;
			}
		}

		// Token: 0x17000BB5 RID: 2997
		// (get) Token: 0x06003324 RID: 13092 RVA: 0x000273D2 File Offset: 0x000255D2
		// (set) Token: 0x06003325 RID: 13093 RVA: 0x000273DA File Offset: 0x000255DA
		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return this.WmztXsJeVxuRuIcyCJkFvxVmxfbG;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				this.WmztXsJeVxuRuIcyCJkFvxVmxfbG = value;
			}
		}

		// Token: 0x17000BB6 RID: 2998
		public T this[int index]
		{
			get
			{
				int num = this.dCULsPPeuDbYdiQguDxMByEBQfPWA(index);
				if (!this.UwTkfaaPxODkTfZDoMMirfbJScWYA(num))
				{
					throw new IndexOutOfRangeException();
				}
				return this.TwBciHnjTJTeLIZyzcRXFthDQrWy[num];
			}
			set
			{
				int num = this.dCULsPPeuDbYdiQguDxMByEBQfPWA(index);
				if (!this.UwTkfaaPxODkTfZDoMMirfbJScWYA(num))
				{
					throw new IndexOutOfRangeException();
				}
				this.TwBciHnjTJTeLIZyzcRXFthDQrWy[num] = value;
			}
		}

		// Token: 0x06003328 RID: 13096 RVA: 0x000273ED File Offset: 0x000255ED
		public RingBuffer(int A_1)
		{
			if (A_1 <= 0)
			{
				throw new ArgumentOutOfRangeException("capacity must be > 0.");
			}
			this.TwBciHnjTJTeLIZyzcRXFthDQrWy = new T[A_1];
			this.pmRmFlPQfJMQSucQaEihTZGHphju = A_1;
			this.Clear();
		}

		// Token: 0x06003329 RID: 13097 RVA: 0x000AF84C File Offset: 0x000ADA4C
		public void Enqueue(T item)
		{
			this.jhdciyJGncrfyqhnQQoMHkcwMyxBA = ((this.jhdciyJGncrfyqhnQQoMHkcwMyxBA < this.pmRmFlPQfJMQSucQaEihTZGHphju - 1) ? (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA + 1) : 0);
			if (this.VzySJJMHgRZFujDtfkOVrZbpRHQK == 0)
			{
				this.TxoUOjHHTqJBuSysanAMfEaKALzj = 0;
			}
			else if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA == this.TxoUOjHHTqJBuSysanAMfEaKALzj)
			{
				this.TxoUOjHHTqJBuSysanAMfEaKALzj = ((this.TxoUOjHHTqJBuSysanAMfEaKALzj < this.pmRmFlPQfJMQSucQaEihTZGHphju - 1) ? (this.TxoUOjHHTqJBuSysanAMfEaKALzj + 1) : 0);
				this.pWRxIKdkXyhIZmfrZGfNuyxjMAMD++;
			}
			this.TwBciHnjTJTeLIZyzcRXFthDQrWy[this.jhdciyJGncrfyqhnQQoMHkcwMyxBA] = item;
			if (this.VzySJJMHgRZFujDtfkOVrZbpRHQK < this.pmRmFlPQfJMQSucQaEihTZGHphju)
			{
				this.VzySJJMHgRZFujDtfkOVrZbpRHQK++;
			}
		}

		// Token: 0x0600332A RID: 13098 RVA: 0x00027428 File Offset: 0x00025628
		public bool EnqueueIfUnique(T item)
		{
			if (this.Contains(item))
			{
				return false;
			}
			this.Enqueue(item);
			return true;
		}

		// Token: 0x0600332B RID: 13099 RVA: 0x000AF8F8 File Offset: 0x000ADAF8
		public T Dequeue()
		{
			if (this.VzySJJMHgRZFujDtfkOVrZbpRHQK == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = this.TwBciHnjTJTeLIZyzcRXFthDQrWy[this.TxoUOjHHTqJBuSysanAMfEaKALzj];
			if (this.TxoUOjHHTqJBuSysanAMfEaKALzj == this.jhdciyJGncrfyqhnQQoMHkcwMyxBA)
			{
				this.Clear();
				return result;
			}
			this.TwBciHnjTJTeLIZyzcRXFthDQrWy[this.TxoUOjHHTqJBuSysanAMfEaKALzj] = default(T);
			this.TxoUOjHHTqJBuSysanAMfEaKALzj = ((this.TxoUOjHHTqJBuSysanAMfEaKALzj < this.pmRmFlPQfJMQSucQaEihTZGHphju - 1) ? (this.TxoUOjHHTqJBuSysanAMfEaKALzj + 1) : 0);
			this.pWRxIKdkXyhIZmfrZGfNuyxjMAMD = 0;
			this.VzySJJMHgRZFujDtfkOVrZbpRHQK--;
			this.tSanjjuSYPEETTBqoswLhqrqtTov++;
			return result;
		}

		// Token: 0x0600332C RID: 13100 RVA: 0x0002743D File Offset: 0x0002563D
		public T Peek()
		{
			if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return this.TwBciHnjTJTeLIZyzcRXFthDQrWy[this.TxoUOjHHTqJBuSysanAMfEaKALzj];
		}

		// Token: 0x0600332D RID: 13101 RVA: 0x00027464 File Offset: 0x00025664
		public bool Contains(T item)
		{
			return this.ysRzoylInGXfrctDHCVOFONGQOnb(item, this.WmztXsJeVxuRuIcyCJkFvxVmxfbG) >= 0;
		}

		// Token: 0x0600332E RID: 13102 RVA: 0x00027479 File Offset: 0x00025679
		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return this.ysRzoylInGXfrctDHCVOFONGQOnb(item, comparer) >= 0;
		}

		// Token: 0x0600332F RID: 13103 RVA: 0x00027489 File Offset: 0x00025689
		public int IndexOf(T item)
		{
			return this.IndexOf(item, this.WmztXsJeVxuRuIcyCJkFvxVmxfbG);
		}

		// Token: 0x06003330 RID: 13104 RVA: 0x00027498 File Offset: 0x00025698
		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return this.lKtISYsgTqtkEhZwyQwkrZIbUZw(this.ysRzoylInGXfrctDHCVOFONGQOnb(item, comparer));
		}

		// Token: 0x06003331 RID: 13105 RVA: 0x000274A8 File Offset: 0x000256A8
		public bool Remove(T item)
		{
			return this.Remove(item, this.WmztXsJeVxuRuIcyCJkFvxVmxfbG);
		}

		// Token: 0x06003332 RID: 13106 RVA: 0x000AF99C File Offset: 0x000ADB9C
		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (this.Count == 0)
			{
				return false;
			}
			int num = this.ysRzoylInGXfrctDHCVOFONGQOnb(item, comparer);
			if (num < 0)
			{
				return false;
			}
			this.OJGhKDEixyeEnuaaDxPmMdxUKZXS(num);
			return true;
		}

		// Token: 0x06003333 RID: 13107 RVA: 0x000274B7 File Offset: 0x000256B7
		public void RemoveAt(int index)
		{
			this.OJGhKDEixyeEnuaaDxPmMdxUKZXS(this.dCULsPPeuDbYdiQguDxMByEBQfPWA(index));
		}

		// Token: 0x06003334 RID: 13108 RVA: 0x000274C6 File Offset: 0x000256C6
		public int RemoveAll(T item)
		{
			return this.RemoveAll(item, this.WmztXsJeVxuRuIcyCJkFvxVmxfbG);
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x000AF9D8 File Offset: 0x000ADBD8
		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			int num = 0;
			for (int i = this.Count - 1; i >= 0; i--)
			{
				if (comparer.Equals(this[i], item))
				{
					this.RemoveAt(i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x000AFA24 File Offset: 0x000ADC24
		public void Clear()
		{
			if (this.VzySJJMHgRZFujDtfkOVrZbpRHQK > 0)
			{
				if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA >= this.TxoUOjHHTqJBuSysanAMfEaKALzj)
				{
					Array.Clear(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, this.TxoUOjHHTqJBuSysanAMfEaKALzj, this.jhdciyJGncrfyqhnQQoMHkcwMyxBA - this.TxoUOjHHTqJBuSysanAMfEaKALzj + 1);
				}
				else
				{
					Array.Clear(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, 0, this.jhdciyJGncrfyqhnQQoMHkcwMyxBA + 1);
					Array.Clear(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, this.TxoUOjHHTqJBuSysanAMfEaKALzj, this.pmRmFlPQfJMQSucQaEihTZGHphju - this.TxoUOjHHTqJBuSysanAMfEaKALzj);
				}
				this.VzySJJMHgRZFujDtfkOVrZbpRHQK = 0;
			}
			this.jhdciyJGncrfyqhnQQoMHkcwMyxBA = -1;
			this.TxoUOjHHTqJBuSysanAMfEaKALzj = -1;
			this.pWRxIKdkXyhIZmfrZGfNuyxjMAMD = 0;
			this.tSanjjuSYPEETTBqoswLhqrqtTov++;
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x000274D5 File Offset: 0x000256D5
		private int siPlynuoKczrlhGOgKXTJQZgEUMJ(T A_1)
		{
			return this.ysRzoylInGXfrctDHCVOFONGQOnb(A_1, this.WmztXsJeVxuRuIcyCJkFvxVmxfbG);
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x000AFAC8 File Offset: 0x000ADCC8
		private int ysRzoylInGXfrctDHCVOFONGQOnb(T A_1, IEqualityComparer<T> A_2)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (this.VzySJJMHgRZFujDtfkOVrZbpRHQK == 0)
			{
				return -1;
			}
			if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA >= this.TxoUOjHHTqJBuSysanAMfEaKALzj)
			{
				for (int i = this.TxoUOjHHTqJBuSysanAMfEaKALzj; i <= this.jhdciyJGncrfyqhnQQoMHkcwMyxBA; i++)
				{
					if (A_2.Equals(this.TwBciHnjTJTeLIZyzcRXFthDQrWy[i], A_1))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= this.jhdciyJGncrfyqhnQQoMHkcwMyxBA; j++)
				{
					if (A_2.Equals(this.TwBciHnjTJTeLIZyzcRXFthDQrWy[j], A_1))
					{
						return j;
					}
				}
				for (int k = this.TxoUOjHHTqJBuSysanAMfEaKALzj; k < this.pmRmFlPQfJMQSucQaEihTZGHphju; k++)
				{
					if (A_2.Equals(this.TwBciHnjTJTeLIZyzcRXFthDQrWy[k], A_1))
					{
						return k;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x000AFB80 File Offset: 0x000ADD80
		private void OJGhKDEixyeEnuaaDxPmMdxUKZXS(int A_1)
		{
			if (!this.UwTkfaaPxODkTfZDoMMirfbJScWYA(A_1))
			{
				throw new IndexOutOfRangeException();
			}
			if (A_1 == this.TxoUOjHHTqJBuSysanAMfEaKALzj)
			{
				this.Dequeue();
				return;
			}
			if (A_1 != this.jhdciyJGncrfyqhnQQoMHkcwMyxBA)
			{
				if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA > this.TxoUOjHHTqJBuSysanAMfEaKALzj)
				{
					Array.Copy(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, A_1 + 1, this.TwBciHnjTJTeLIZyzcRXFthDQrWy, A_1, this.jhdciyJGncrfyqhnQQoMHkcwMyxBA - A_1);
				}
				else if (A_1 < this.jhdciyJGncrfyqhnQQoMHkcwMyxBA)
				{
					Array.Copy(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, A_1 + 1, this.TwBciHnjTJTeLIZyzcRXFthDQrWy, A_1, this.jhdciyJGncrfyqhnQQoMHkcwMyxBA - A_1);
				}
				else
				{
					Array.Copy(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, A_1 + 1, this.TwBciHnjTJTeLIZyzcRXFthDQrWy, A_1, this.pmRmFlPQfJMQSucQaEihTZGHphju - A_1 - 1);
					this.TwBciHnjTJTeLIZyzcRXFthDQrWy[this.pmRmFlPQfJMQSucQaEihTZGHphju - 1] = this.TwBciHnjTJTeLIZyzcRXFthDQrWy[0];
					if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA > 0)
					{
						Array.Copy(this.TwBciHnjTJTeLIZyzcRXFthDQrWy, 1, this.TwBciHnjTJTeLIZyzcRXFthDQrWy, 0, this.jhdciyJGncrfyqhnQQoMHkcwMyxBA);
					}
				}
			}
			this.TwBciHnjTJTeLIZyzcRXFthDQrWy[this.jhdciyJGncrfyqhnQQoMHkcwMyxBA] = default(T);
			this.jhdciyJGncrfyqhnQQoMHkcwMyxBA = ((this.jhdciyJGncrfyqhnQQoMHkcwMyxBA > 0) ? (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA - 1) : (this.pmRmFlPQfJMQSucQaEihTZGHphju - 1));
			this.tSanjjuSYPEETTBqoswLhqrqtTov++;
			this.VzySJJMHgRZFujDtfkOVrZbpRHQK--;
		}

		// Token: 0x0600333A RID: 13114 RVA: 0x000AFCC8 File Offset: 0x000ADEC8
		private bool UwTkfaaPxODkTfZDoMMirfbJScWYA(int A_1)
		{
			if (this.VzySJJMHgRZFujDtfkOVrZbpRHQK == 0)
			{
				return false;
			}
			if (this.jhdciyJGncrfyqhnQQoMHkcwMyxBA >= this.TxoUOjHHTqJBuSysanAMfEaKALzj)
			{
				return A_1 >= this.TxoUOjHHTqJBuSysanAMfEaKALzj && A_1 <= this.jhdciyJGncrfyqhnQQoMHkcwMyxBA;
			}
			return A_1 >= this.TxoUOjHHTqJBuSysanAMfEaKALzj || A_1 <= this.jhdciyJGncrfyqhnQQoMHkcwMyxBA;
		}

		// Token: 0x0600333B RID: 13115 RVA: 0x000274E4 File Offset: 0x000256E4
		private int lKtISYsgTqtkEhZwyQwkrZIbUZw(int A_1)
		{
			if (A_1 >= this.pmRmFlPQfJMQSucQaEihTZGHphju)
			{
				return -1;
			}
			if (!this.UwTkfaaPxODkTfZDoMMirfbJScWYA(A_1))
			{
				return -1;
			}
			if (A_1 >= this.TxoUOjHHTqJBuSysanAMfEaKALzj)
			{
				return A_1 - this.TxoUOjHHTqJBuSysanAMfEaKALzj;
			}
			return A_1 + this.pmRmFlPQfJMQSucQaEihTZGHphju - this.TxoUOjHHTqJBuSysanAMfEaKALzj;
		}

		// Token: 0x0600333C RID: 13116 RVA: 0x0002751D File Offset: 0x0002571D
		private int dCULsPPeuDbYdiQguDxMByEBQfPWA(int A_1)
		{
			if (A_1 >= this.VzySJJMHgRZFujDtfkOVrZbpRHQK)
			{
				return -1;
			}
			A_1 = this.TxoUOjHHTqJBuSysanAMfEaKALzj + A_1;
			if (A_1 >= this.pmRmFlPQfJMQSucQaEihTZGHphju)
			{
				A_1 -= this.pmRmFlPQfJMQSucQaEihTZGHphju;
			}
			return A_1;
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x00027548 File Offset: 0x00025748
		void ICollection<!0>.lhUWpCaGTvNgctkGsACsXQtgZWvl(T A_1)
		{
			this.Enqueue(A_1);
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x00027551 File Offset: 0x00025751
		void ICollection<!0>.BDACrLJbVoqekCqvUXNFcPBBLmkjB()
		{
			this.Clear();
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x00027559 File Offset: 0x00025759
		bool ICollection<!0>.RAwRxwSpOffDHvDZYqEFVrPvnQwN(T A_1)
		{
			return this.Contains(A_1);
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x000AFD1C File Offset: 0x000ADF1C
		void ICollection<!0>.dtiCvkPPgsXzcQRYdNlkIjXyuTIE(T[] A_1, int A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (A_2 < 0 || A_2 + this.Count > A_1.Length)
			{
				throw new ArgumentException("array is too small to hold the collection.");
			}
			int count = this.Count;
			for (int i = 0; i < count; i++)
			{
				A_1[A_2 + i] = this[i];
			}
		}

		// Token: 0x17000BB7 RID: 2999
		// (get) Token: 0x06003341 RID: 13121 RVA: 0x00027562 File Offset: 0x00025762
		int ICollection<!0>.Count
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x17000BB8 RID: 3000
		// (get) Token: 0x06003342 RID: 13122 RVA: 0x00003E2B File Offset: 0x0000202B
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06003343 RID: 13123 RVA: 0x0002756A File Offset: 0x0002576A
		bool ICollection<!0>.acUWspRLsmmkGsvfdgcXuKTwTIYV(T A_1)
		{
			return this.Remove(A_1);
		}

		// Token: 0x06003344 RID: 13124 RVA: 0x00027573 File Offset: 0x00025773
		IEnumerator<T> IEnumerable<!0>.flZoAFdOGBzFcEMrOttnfdaFgfwv()
		{
			return new RingBuffer<T>.cZiiNELLnIdgaJslKqlcOkWXdicW(this);
		}

		// Token: 0x06003345 RID: 13125 RVA: 0x00027573 File Offset: 0x00025773
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new RingBuffer<T>.cZiiNELLnIdgaJslKqlcOkWXdicW(this);
		}

		// Token: 0x04001BA8 RID: 7080
		private readonly T[] TwBciHnjTJTeLIZyzcRXFthDQrWy;

		// Token: 0x04001BA9 RID: 7081
		private readonly int pmRmFlPQfJMQSucQaEihTZGHphju;

		// Token: 0x04001BAA RID: 7082
		private int jhdciyJGncrfyqhnQQoMHkcwMyxBA;

		// Token: 0x04001BAB RID: 7083
		private int TxoUOjHHTqJBuSysanAMfEaKALzj;

		// Token: 0x04001BAC RID: 7084
		private int VzySJJMHgRZFujDtfkOVrZbpRHQK;

		// Token: 0x04001BAD RID: 7085
		private int pWRxIKdkXyhIZmfrZGfNuyxjMAMD;

		// Token: 0x04001BAE RID: 7086
		private int tSanjjuSYPEETTBqoswLhqrqtTov;

		// Token: 0x04001BAF RID: 7087
		private IEqualityComparer<T> WmztXsJeVxuRuIcyCJkFvxVmxfbG = EqualityComparerNoAlloc<T>.Default;

		// Token: 0x020004F0 RID: 1264
		[Serializable]
		public struct cZiiNELLnIdgaJslKqlcOkWXdicW : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x06003346 RID: 13126 RVA: 0x00027580 File Offset: 0x00025780
			internal cZiiNELLnIdgaJslKqlcOkWXdicW(RingBuffer<\u0001> A_1)
			{
				this.buffer = A_1;
				this.index = 0;
				this.version = A_1.tSanjjuSYPEETTBqoswLhqrqtTov;
				this.current = default(\u0001);
			}

			// Token: 0x06003347 RID: 13127 RVA: 0x00002FF9 File Offset: 0x000011F9
			public void Dispose()
			{
			}

			// Token: 0x06003348 RID: 13128 RVA: 0x000AFD78 File Offset: 0x000ADF78
			public bool MoveNext()
			{
				if (this.version == this.buffer.tSanjjuSYPEETTBqoswLhqrqtTov && this.index < this.buffer.VzySJJMHgRZFujDtfkOVrZbpRHQK)
				{
					this.current = this.buffer[this.index];
					this.index++;
					return true;
				}
				return this.enlWzpfZpQsMZjpvJXfqmgELDuXHA();
			}

			// Token: 0x06003349 RID: 13129 RVA: 0x000275A8 File Offset: 0x000257A8
			private bool enlWzpfZpQsMZjpvJXfqmgELDuXHA()
			{
				if (this.version != this.buffer.tSanjjuSYPEETTBqoswLhqrqtTov)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				this.index = this.buffer.VzySJJMHgRZFujDtfkOVrZbpRHQK + 1;
				this.current = default(\u0001);
				return false;
			}

			// Token: 0x17000BB9 RID: 3001
			// (get) Token: 0x0600334A RID: 13130 RVA: 0x000275E8 File Offset: 0x000257E8
			public \u0001 Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000BBA RID: 3002
			// (get) Token: 0x0600334B RID: 13131 RVA: 0x000275F0 File Offset: 0x000257F0
			object IEnumerator.Current
			{
				get
				{
					if (this.index == 0 || this.index == this.buffer.VzySJJMHgRZFujDtfkOVrZbpRHQK + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			// Token: 0x0600334C RID: 13132 RVA: 0x00027620 File Offset: 0x00025820
			void IEnumerator.Reset()
			{
				if (this.version != this.buffer.tSanjjuSYPEETTBqoswLhqrqtTov)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				this.index = 0;
				this.current = default(\u0001);
			}

			// Token: 0x04001BB0 RID: 7088
			private RingBuffer<\u0001> buffer;

			// Token: 0x04001BB1 RID: 7089
			private int index;

			// Token: 0x04001BB2 RID: 7090
			private int version;

			// Token: 0x04001BB3 RID: 7091
			private \u0001 current;
		}
	}
}
