using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000152 RID: 338
	internal class AncestorFilter
	{
		// Token: 0x06000AEE RID: 2798 RVA: 0x0002BFAB File Offset: 0x0002A1AB
		private void AddHash(int hash)
		{
			this.m_HashStack.Push(hash);
			this.m_CountingBloomFilter.InsertHash((uint)hash);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0002BFC8 File Offset: 0x0002A1C8
		public unsafe bool IsCandidate(StyleComplexSelector complexSel)
		{
			int i = 0;
			while (i < 4)
			{
				bool flag = *(ref complexSel.ancestorHashes.hashes.FixedElementField + (IntPtr)i * 4) == 0;
				bool result;
				if (flag)
				{
					result = true;
				}
				else
				{
					bool flag2 = !this.m_CountingBloomFilter.ContainsHash((uint)(*(ref complexSel.ancestorHashes.hashes.FixedElementField + (IntPtr)i * 4)));
					if (!flag2)
					{
						i++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return true;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0002C03C File Offset: 0x0002A23C
		public void PushElement(VisualElement element)
		{
			int count = this.m_HashStack.Count;
			this.AddHash(element.typeName.GetHashCode() * 13);
			bool flag = !string.IsNullOrEmpty(element.name);
			if (flag)
			{
				this.AddHash(element.name.GetHashCode() * 17);
			}
			foreach (string text in element.classList)
			{
				this.AddHash(text.GetHashCode() * 19);
			}
			this.m_HashStack.Push(this.m_HashStack.Count - count);
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0002C100 File Offset: 0x0002A300
		public void PopElement()
		{
			int i = this.m_HashStack.Peek();
			this.m_HashStack.Pop();
			while (i > 0)
			{
				int hash = this.m_HashStack.Peek();
				this.m_CountingBloomFilter.RemoveHash((uint)hash);
				this.m_HashStack.Pop();
				i--;
			}
		}

		// Token: 0x04000537 RID: 1335
		private CountingBloomFilter m_CountingBloomFilter;

		// Token: 0x04000538 RID: 1336
		private Stack<int> m_HashStack = new Stack<int>(100);
	}
}
