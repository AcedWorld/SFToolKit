using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200001E RID: 30
	public class MergedKeyedCollection<TKey, TItem> : IMergedCollection<TItem>, ICollection<TItem>, IEnumerable<TItem>, IEnumerable
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x00003278 File Offset: 0x00001478
		public MergedKeyedCollection()
		{
			this.collections = new Dictionary<Type, IKeyedCollection<TKey, TItem>>();
			this.collectionsLookup = new Dictionary<Type, IKeyedCollection<TKey, TItem>>();
		}

		// Token: 0x17000023 RID: 35
		public TItem this[TKey key]
		{
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				foreach (KeyValuePair<Type, IKeyedCollection<TKey, TItem>> keyValuePair in this.collections)
				{
					if (keyValuePair.Value.Contains(key))
					{
						return keyValuePair.Value[key];
					}
				}
				throw new KeyNotFoundException();
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00003320 File Offset: 0x00001520
		public int Count
		{
			get
			{
				int num = 0;
				foreach (KeyValuePair<Type, IKeyedCollection<TKey, TItem>> keyValuePair in this.collections)
				{
					num += keyValuePair.Value.Count;
				}
				return num;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003380 File Offset: 0x00001580
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003383 File Offset: 0x00001583
		public bool Includes<TSubItem>() where TSubItem : TItem
		{
			return this.Includes(typeof(TSubItem));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003395 File Offset: 0x00001595
		public bool Includes(Type elementType)
		{
			return this.GetCollectionForType(elementType, false) != null;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000033A2 File Offset: 0x000015A2
		public IKeyedCollection<TKey, TSubItem> ForType<TSubItem>() where TSubItem : TItem
		{
			return ((VariantKeyedCollection<TItem, TSubItem, TKey>)this.GetCollectionForType(typeof(TSubItem), true)).implementation;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000033C0 File Offset: 0x000015C0
		public virtual void Include<TSubItem>(IKeyedCollection<TKey, TSubItem> collection) where TSubItem : TItem
		{
			Type typeFromHandle = typeof(TSubItem);
			VariantKeyedCollection<TItem, TSubItem, TKey> value = new VariantKeyedCollection<TItem, TSubItem, TKey>(collection);
			this.collections.Add(typeFromHandle, value);
			this.collectionsLookup.Add(typeFromHandle, value);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000033F9 File Offset: 0x000015F9
		protected IKeyedCollection<TKey, TItem> GetCollectionForItem(TItem item)
		{
			Ensure.That("item").IsNotNull<TItem>(item);
			return this.GetCollectionForType(item.GetType(), true);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003420 File Offset: 0x00001620
		protected IKeyedCollection<TKey, TItem> GetCollectionForType(Type type, bool throwOnFail = true)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			IKeyedCollection<TKey, TItem> value;
			if (this.collectionsLookup.TryGetValue(type, out value))
			{
				return value;
			}
			foreach (KeyValuePair<Type, IKeyedCollection<TKey, TItem>> keyValuePair in this.collections)
			{
				if (keyValuePair.Key.IsAssignableFrom(type))
				{
					value = keyValuePair.Value;
					this.collectionsLookup.Add(type, value);
					return value;
				}
			}
			if (throwOnFail)
			{
				throw new InvalidOperationException(string.Format("No sub-collection available for type '{0}'.", type));
			}
			return null;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000034D0 File Offset: 0x000016D0
		protected IKeyedCollection<TKey, TItem> GetCollectionForKey(TKey key, bool throwOnFail = true)
		{
			foreach (KeyValuePair<Type, IKeyedCollection<TKey, TItem>> keyValuePair in this.collections)
			{
				if (keyValuePair.Value.Contains(key))
				{
					return keyValuePair.Value;
				}
			}
			if (throwOnFail)
			{
				throw new InvalidOperationException(string.Format("No sub-collection available for key '{0}'.", key));
			}
			return null;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003554 File Offset: 0x00001754
		public bool TryGetValue(TKey key, out TItem value)
		{
			IKeyedCollection<TKey, TItem> collectionForKey = this.GetCollectionForKey(key, false);
			value = default(TItem);
			return collectionForKey != null && collectionForKey.TryGetValue(key, out value);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000357E File Offset: 0x0000177E
		public virtual void Add(TItem item)
		{
			this.GetCollectionForItem(item).Add(item);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003590 File Offset: 0x00001790
		public void Clear()
		{
			foreach (IKeyedCollection<TKey, TItem> keyedCollection in this.collections.Values)
			{
				keyedCollection.Clear();
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000035E8 File Offset: 0x000017E8
		public bool Contains(TItem item)
		{
			return this.GetCollectionForItem(item).Contains(item);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000035F7 File Offset: 0x000017F7
		public bool Remove(TItem item)
		{
			return this.GetCollectionForItem(item).Remove(item);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003608 File Offset: 0x00001808
		public void CopyTo(TItem[] array, int arrayIndex)
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
			foreach (IKeyedCollection<TKey, TItem> keyedCollection in this.collections.Values)
			{
				keyedCollection.CopyTo(array, arrayIndex + num);
				num += keyedCollection.Count;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000036A0 File Offset: 0x000018A0
		public bool Contains(TKey key)
		{
			return this.GetCollectionForKey(key, false) != null;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000036AD File Offset: 0x000018AD
		public bool Remove(TKey key)
		{
			return this.GetCollectionForKey(key, true).Remove(key);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000036BD File Offset: 0x000018BD
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000036CA File Offset: 0x000018CA
		IEnumerator<TItem> IEnumerable<!1>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000036D7 File Offset: 0x000018D7
		public MergedKeyedCollection<TKey, TItem>.Enumerator GetEnumerator()
		{
			return new MergedKeyedCollection<TKey, TItem>.Enumerator(this);
		}

		// Token: 0x04000017 RID: 23
		protected readonly Dictionary<Type, IKeyedCollection<TKey, TItem>> collections;

		// Token: 0x04000018 RID: 24
		protected readonly Dictionary<Type, IKeyedCollection<TKey, TItem>> collectionsLookup;

		// Token: 0x020001BC RID: 444
		public struct Enumerator : IEnumerator<TItem>, IEnumerator, IDisposable
		{
			// Token: 0x06000BC6 RID: 3014 RVA: 0x00031C87 File Offset: 0x0002FE87
			public Enumerator(MergedKeyedCollection<TKey, TItem> merged)
			{
				this = default(MergedKeyedCollection<TKey, TItem>.Enumerator);
				this.collectionsEnumerator = merged.collections.GetEnumerator();
			}

			// Token: 0x06000BC7 RID: 3015 RVA: 0x00031CA1 File Offset: 0x0002FEA1
			public void Dispose()
			{
			}

			// Token: 0x06000BC8 RID: 3016 RVA: 0x00031CA4 File Offset: 0x0002FEA4
			public bool MoveNext()
			{
				if (this.currentCollection == null)
				{
					if (!this.collectionsEnumerator.MoveNext())
					{
						this.currentItem = default(TItem);
						this.exceeded = true;
						return false;
					}
					KeyValuePair<Type, IKeyedCollection<TKey, TItem>> keyValuePair = this.collectionsEnumerator.Current;
					this.currentCollection = keyValuePair.Value;
					if (this.currentCollection == null)
					{
						throw new InvalidOperationException("Merged sub collection is null.");
					}
				}
				if (this.indexInCurrentCollection < this.currentCollection.Count)
				{
					this.currentItem = this.currentCollection[this.indexInCurrentCollection];
					this.indexInCurrentCollection++;
					return true;
				}
				while (this.collectionsEnumerator.MoveNext())
				{
					KeyValuePair<Type, IKeyedCollection<TKey, TItem>> keyValuePair = this.collectionsEnumerator.Current;
					this.currentCollection = keyValuePair.Value;
					this.indexInCurrentCollection = 0;
					if (this.currentCollection == null)
					{
						throw new InvalidOperationException("Merged sub collection is null.");
					}
					if (this.indexInCurrentCollection < this.currentCollection.Count)
					{
						this.currentItem = this.currentCollection[this.indexInCurrentCollection];
						this.indexInCurrentCollection++;
						return true;
					}
				}
				this.currentItem = default(TItem);
				this.exceeded = true;
				return false;
			}

			// Token: 0x17000200 RID: 512
			// (get) Token: 0x06000BC9 RID: 3017 RVA: 0x00031DD2 File Offset: 0x0002FFD2
			public TItem Current
			{
				get
				{
					return this.currentItem;
				}
			}

			// Token: 0x17000201 RID: 513
			// (get) Token: 0x06000BCA RID: 3018 RVA: 0x00031DDA File Offset: 0x0002FFDA
			object IEnumerator.Current
			{
				get
				{
					if (this.exceeded)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			// Token: 0x06000BCB RID: 3019 RVA: 0x00031DF5 File Offset: 0x0002FFF5
			void IEnumerator.Reset()
			{
				throw new InvalidOperationException();
			}

			// Token: 0x040002E9 RID: 745
			private Dictionary<Type, IKeyedCollection<TKey, TItem>>.Enumerator collectionsEnumerator;

			// Token: 0x040002EA RID: 746
			private TItem currentItem;

			// Token: 0x040002EB RID: 747
			private IKeyedCollection<TKey, TItem> currentCollection;

			// Token: 0x040002EC RID: 748
			private int indexInCurrentCollection;

			// Token: 0x040002ED RID: 749
			private bool exceeded;
		}
	}
}
