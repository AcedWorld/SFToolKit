using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000054 RID: 84
	public class ObservableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060002B0 RID: 688 RVA: 0x0000C304 File Offset: 0x0000A504
		// (remove) Token: 0x060002B1 RID: 689 RVA: 0x0000C33C File Offset: 0x0000A53C
		public event ListChangedEventHandler<T> ItemAdded;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060002B2 RID: 690 RVA: 0x0000C374 File Offset: 0x0000A574
		// (remove) Token: 0x060002B3 RID: 691 RVA: 0x0000C3AC File Offset: 0x0000A5AC
		public event ListChangedEventHandler<T> ItemRemoved;

		// Token: 0x17000050 RID: 80
		public T this[int index]
		{
			get
			{
				return this.m_List[index];
			}
			set
			{
				this.OnEvent(this.ItemRemoved, index, this.m_List[index]);
				this.m_List[index] = value;
				this.OnEvent(this.ItemAdded, index, value);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000C425 File Offset: 0x0000A625
		public int Count
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000C432 File Offset: 0x0000A632
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000C435 File Offset: 0x0000A635
		public ObservableList() : this(0)
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000C43E File Offset: 0x0000A63E
		public ObservableList(int capacity)
		{
			this.m_List = new List<T>(capacity);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000C452 File Offset: 0x0000A652
		public ObservableList(IEnumerable<T> collection)
		{
			this.m_List = new List<T>(collection);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000C466 File Offset: 0x0000A666
		private void OnEvent(ListChangedEventHandler<T> e, int index, T item)
		{
			if (e != null)
			{
				e(this, new ListChangedEventArgs<T>(index, item));
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000C479 File Offset: 0x0000A679
		public bool Contains(T item)
		{
			return this.m_List.Contains(item);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000C487 File Offset: 0x0000A687
		public int IndexOf(T item)
		{
			return this.m_List.IndexOf(item);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000C495 File Offset: 0x0000A695
		public void Add(T item)
		{
			this.m_List.Add(item);
			this.OnEvent(this.ItemAdded, this.m_List.IndexOf(item), item);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000C4BC File Offset: 0x0000A6BC
		public void Add(params T[] items)
		{
			foreach (T item in items)
			{
				this.Add(item);
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000C4E8 File Offset: 0x0000A6E8
		public void Insert(int index, T item)
		{
			this.m_List.Insert(index, item);
			this.OnEvent(this.ItemAdded, index, item);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000C508 File Offset: 0x0000A708
		public bool Remove(T item)
		{
			int index = this.m_List.IndexOf(item);
			bool flag = this.m_List.Remove(item);
			if (flag)
			{
				this.OnEvent(this.ItemRemoved, index, item);
			}
			return flag;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000C540 File Offset: 0x0000A740
		public int Remove(params T[] items)
		{
			if (items == null)
			{
				return 0;
			}
			int num = 0;
			foreach (T item in items)
			{
				num += (this.Remove(item) ? 1 : 0);
			}
			return num;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000C580 File Offset: 0x0000A780
		public void RemoveAt(int index)
		{
			T item = this.m_List[index];
			this.m_List.RemoveAt(index);
			this.OnEvent(this.ItemRemoved, index, item);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000C5B4 File Offset: 0x0000A7B4
		public void Clear()
		{
			while (this.Count > 0)
			{
				this.RemoveAt(this.Count - 1);
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000C5CF File Offset: 0x0000A7CF
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.m_List.CopyTo(array, arrayIndex);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000C5DE File Offset: 0x0000A7DE
		public IEnumerator<T> GetEnumerator()
		{
			return this.m_List.GetEnumerator();
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000C5EB File Offset: 0x0000A7EB
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040001A0 RID: 416
		private IList<T> m_List;
	}
}
