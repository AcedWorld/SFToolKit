using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004F5 RID: 1269
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ReadOnlyList<T> : Rewired.Utils.Interfaces.IReadOnlyList<T>, IReadOnlyList, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x17000BCF RID: 3023
		// (get) Token: 0x060033BF RID: 13247 RVA: 0x00027BEF File Offset: 0x00025DEF
		public int Count
		{
			get
			{
				return this.uPLdrYOtkksMoowldcVNfrlwNncw.Count;
			}
		}

		// Token: 0x060033C0 RID: 13248 RVA: 0x00027BFC File Offset: 0x00025DFC
		public ReadOnlyList(IList<T> A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException();
			}
			this.uPLdrYOtkksMoowldcVNfrlwNncw = A_1;
		}

		// Token: 0x060033C1 RID: 13249 RVA: 0x00027C14 File Offset: 0x00025E14
		public ReadOnlyList(ReadOnlyList<T> A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException();
			}
			this.uPLdrYOtkksMoowldcVNfrlwNncw = new List<T>(A_1.uPLdrYOtkksMoowldcVNfrlwNncw);
		}

		// Token: 0x17000BD0 RID: 3024
		public T this[int index]
		{
			get
			{
				return this.uPLdrYOtkksMoowldcVNfrlwNncw[index];
			}
		}

		// Token: 0x060033C3 RID: 13251 RVA: 0x00027C44 File Offset: 0x00025E44
		public bool Contains(T value)
		{
			return this.uPLdrYOtkksMoowldcVNfrlwNncw.Contains(value);
		}

		// Token: 0x060033C4 RID: 13252 RVA: 0x00027C52 File Offset: 0x00025E52
		public int IndexOf(T value)
		{
			return this.uPLdrYOtkksMoowldcVNfrlwNncw.IndexOf(value);
		}

		// Token: 0x060033C5 RID: 13253 RVA: 0x000B1100 File Offset: 0x000AF300
		public void CopyTo(IList<T> destination)
		{
			if (destination == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < this.uPLdrYOtkksMoowldcVNfrlwNncw.Count; i++)
			{
				destination.Add(this.uPLdrYOtkksMoowldcVNfrlwNncw[i]);
			}
		}

		// Token: 0x17000BD1 RID: 3025
		object IReadOnlyList.this[int]
		{
			get
			{
				return (this as IList)[A_1];
			}
		}

		// Token: 0x060033C7 RID: 13255 RVA: 0x00027C6E File Offset: 0x00025E6E
		int IReadOnlyList.fLGLbxjpopschfrpcUfJuZvuHcvE(object A_1)
		{
			return (this as IList).IndexOf(A_1);
		}

		// Token: 0x060033C8 RID: 13256 RVA: 0x00027C7C File Offset: 0x00025E7C
		bool IReadOnlyList.qpFypazbIlJuYEodsLljPRlWzMGA(object A_1)
		{
			return (this as IList).Contains(A_1);
		}

		// Token: 0x060033C9 RID: 13257 RVA: 0x00027C8A File Offset: 0x00025E8A
		IEnumerator<T> IEnumerable<!0>.EAXDIrDNAqcGwUyRHwidTxydGery()
		{
			return this.uPLdrYOtkksMoowldcVNfrlwNncw.GetEnumerator();
		}

		// Token: 0x060033CA RID: 13258 RVA: 0x00027C8A File Offset: 0x00025E8A
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.uPLdrYOtkksMoowldcVNfrlwNncw.GetEnumerator();
		}

		// Token: 0x04001BCB RID: 7115
		private readonly IList<T> uPLdrYOtkksMoowldcVNfrlwNncw;
	}
}
