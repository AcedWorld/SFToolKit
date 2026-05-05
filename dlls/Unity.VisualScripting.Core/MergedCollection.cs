using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200001D RID: 29
	public class MergedCollection<T> : IMergedCollection<T>, ICollection<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00002FB0 File Offset: 0x000011B0
		public MergedCollection()
		{
			this.collections = new Dictionary<Type, ICollection<T>>();
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00002FC4 File Offset: 0x000011C4
		public int Count
		{
			get
			{
				int num = 0;
				foreach (ICollection<T> collection in this.collections.Values)
				{
					num += collection.Count;
				}
				return num;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00003024 File Offset: 0x00001224
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003027 File Offset: 0x00001227
		public void Include<TI>(ICollection<TI> collection) where TI : T
		{
			this.collections.Add(typeof(TI), new VariantCollection<T, TI>(collection));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003044 File Offset: 0x00001244
		public bool Includes<TI>() where TI : T
		{
			return this.Includes(typeof(TI));
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003056 File Offset: 0x00001256
		public bool Includes(Type implementationType)
		{
			return this.GetCollectionForType(implementationType, false) != null;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003063 File Offset: 0x00001263
		public ICollection<TI> ForType<TI>() where TI : T
		{
			return ((VariantCollection<T, TI>)this.GetCollectionForType(typeof(TI), true)).implementation;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003080 File Offset: 0x00001280
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003088 File Offset: 0x00001288
		public IEnumerator<T> GetEnumerator()
		{
			foreach (ICollection<T> collection in this.collections.Values)
			{
				foreach (T t in collection)
				{
					yield return t;
				}
				IEnumerator<T> enumerator2 = null;
			}
			Dictionary<Type, ICollection<T>>.ValueCollection.Enumerator enumerator = default(Dictionary<Type, ICollection<T>>.ValueCollection.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003097 File Offset: 0x00001297
		private ICollection<T> GetCollectionForItem(T item)
		{
			Ensure.That("item").IsNotNull<T>(item);
			return this.GetCollectionForType(item.GetType(), true);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000030C0 File Offset: 0x000012C0
		private ICollection<T> GetCollectionForType(Type type, bool throwOnFail = true)
		{
			if (this.collections.ContainsKey(type))
			{
				return this.collections[type];
			}
			foreach (KeyValuePair<Type, ICollection<T>> keyValuePair in this.collections)
			{
				if (keyValuePair.Key.IsAssignableFrom(type))
				{
					return keyValuePair.Value;
				}
			}
			if (throwOnFail)
			{
				throw new InvalidOperationException(string.Format("No sub-collection available for type '{0}'.", type));
			}
			return null;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003158 File Offset: 0x00001358
		public bool Contains(T item)
		{
			return this.GetCollectionForItem(item).Contains(item);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003167 File Offset: 0x00001367
		public virtual void Add(T item)
		{
			this.GetCollectionForItem(item).Add(item);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003178 File Offset: 0x00001378
		public virtual void Clear()
		{
			foreach (ICollection<T> collection in this.collections.Values)
			{
				collection.Clear();
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000031D0 File Offset: 0x000013D0
		public virtual bool Remove(T item)
		{
			return this.GetCollectionForItem(item).Remove(item);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000031E0 File Offset: 0x000013E0
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (array.Length - arrayIndex < this.Count)
			{
				throw new ArgumentException();
			}
			int num = 0;
			foreach (ICollection<T> collection in this.collections.Values)
			{
				collection.CopyTo(array, arrayIndex + num);
				num += collection.Count;
			}
		}

		// Token: 0x04000016 RID: 22
		private readonly Dictionary<Type, ICollection<T>> collections;
	}
}
