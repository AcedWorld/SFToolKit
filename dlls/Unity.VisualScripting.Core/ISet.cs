using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200001C RID: 28
	public interface ISet<T> : ICollection<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060000A7 RID: 167
		bool Add(T item);

		// Token: 0x060000A8 RID: 168
		void UnionWith(IEnumerable<T> other);

		// Token: 0x060000A9 RID: 169
		void IntersectWith(IEnumerable<T> other);

		// Token: 0x060000AA RID: 170
		void ExceptWith(IEnumerable<T> other);

		// Token: 0x060000AB RID: 171
		void SymmetricExceptWith(IEnumerable<T> other);

		// Token: 0x060000AC RID: 172
		bool IsSubsetOf(IEnumerable<T> other);

		// Token: 0x060000AD RID: 173
		bool IsSupersetOf(IEnumerable<T> other);

		// Token: 0x060000AE RID: 174
		bool IsProperSupersetOf(IEnumerable<T> other);

		// Token: 0x060000AF RID: 175
		bool IsProperSubsetOf(IEnumerable<T> other);

		// Token: 0x060000B0 RID: 176
		bool Overlaps(IEnumerable<T> other);

		// Token: 0x060000B1 RID: 177
		bool SetEquals(IEnumerable<T> other);
	}
}
