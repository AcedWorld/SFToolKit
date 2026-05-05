using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x02000106 RID: 262
	[Serializable]
	public class SortColumnDescriptions : ICollection<SortColumnDescription>, IEnumerable<SortColumnDescription>, IEnumerable
	{
		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060008FD RID: 2301 RVA: 0x00023030 File Offset: 0x00021230
		// (remove) Token: 0x060008FE RID: 2302 RVA: 0x00023068 File Offset: 0x00021268
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action changed;

		// Token: 0x060008FF RID: 2303 RVA: 0x000230A0 File Offset: 0x000212A0
		public IEnumerator<SortColumnDescription> GetEnumerator()
		{
			return this.m_Descriptions.GetEnumerator();
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x000230C0 File Offset: 0x000212C0
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x000230D8 File Offset: 0x000212D8
		public void Add(SortColumnDescription item)
		{
			this.Insert(this.m_Descriptions.Count, item);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000230F0 File Offset: 0x000212F0
		public void Clear()
		{
			while (this.m_Descriptions.Count > 0)
			{
				this.Remove(this.m_Descriptions[0]);
			}
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00023128 File Offset: 0x00021328
		public bool Contains(SortColumnDescription item)
		{
			return this.m_Descriptions.Contains(item);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00023146 File Offset: 0x00021346
		public void CopyTo(SortColumnDescription[] array, int arrayIndex)
		{
			this.m_Descriptions.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00023158 File Offset: 0x00021358
		public bool Remove(SortColumnDescription desc)
		{
			bool flag = desc == null;
			if (flag)
			{
				throw new ArgumentException("Cannot remove null description");
			}
			bool flag2 = this.m_Descriptions.Remove(desc);
			bool result;
			if (flag2)
			{
				desc.column = null;
				desc.changed -= this.OnDescriptionChanged;
				Action action = this.changed;
				if (action != null)
				{
					action();
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x000231C0 File Offset: 0x000213C0
		private void OnDescriptionChanged(SortColumnDescription desc)
		{
			Action action = this.changed;
			if (action != null)
			{
				action();
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x000231D5 File Offset: 0x000213D5
		public int Count
		{
			get
			{
				return this.m_Descriptions.Count;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x000231E2 File Offset: 0x000213E2
		public bool IsReadOnly
		{
			get
			{
				return this.m_Descriptions.IsReadOnly;
			}
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000231F0 File Offset: 0x000213F0
		public int IndexOf(SortColumnDescription desc)
		{
			return this.m_Descriptions.IndexOf(desc);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00023210 File Offset: 0x00021410
		public void Insert(int index, SortColumnDescription desc)
		{
			bool flag = desc == null;
			if (flag)
			{
				throw new ArgumentException("Cannot insert null description");
			}
			bool flag2 = this.Contains(desc);
			if (flag2)
			{
				throw new ArgumentException("Already contains this description");
			}
			this.m_Descriptions.Insert(index, desc);
			desc.changed += this.OnDescriptionChanged;
			Action action = this.changed;
			if (action != null)
			{
				action();
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0002327A File Offset: 0x0002147A
		public void RemoveAt(int index)
		{
			this.Remove(this.m_Descriptions[index]);
		}

		// Token: 0x170001AF RID: 431
		public SortColumnDescription this[int index]
		{
			get
			{
				return this.m_Descriptions[index];
			}
		}

		// Token: 0x0400040E RID: 1038
		[SerializeField]
		private readonly IList<SortColumnDescription> m_Descriptions = new List<SortColumnDescription>();

		// Token: 0x02000107 RID: 263
		internal class UxmlObjectFactory<T> : UxmlObjectFactory<T, SortColumnDescriptions.UxmlObjectTraits<T>> where T : SortColumnDescriptions, new()
		{
		}

		// Token: 0x02000108 RID: 264
		internal class UxmlObjectTraits<T> : UnityEngine.UIElements.UxmlObjectTraits<T> where T : SortColumnDescriptions
		{
			// Token: 0x0600090F RID: 2319 RVA: 0x000232CC File Offset: 0x000214CC
			public override void Init(ref T obj, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ref obj, bag, cc);
				List<SortColumnDescription> valueFromBag = this.m_SortColumnDescriptions.GetValueFromBag(bag, cc);
				bool flag = valueFromBag != null;
				if (flag)
				{
					foreach (SortColumnDescription item in valueFromBag)
					{
						obj.Add(item);
					}
				}
			}

			// Token: 0x04000410 RID: 1040
			private readonly UxmlObjectListAttributeDescription<SortColumnDescription> m_SortColumnDescriptions = new UxmlObjectListAttributeDescription<SortColumnDescription>();
		}
	}
}
