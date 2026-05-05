using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004F6 RID: 1270
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	[Serializable]
	internal sealed class MappedArray<T> : IList<!0>, ICollection<!0>, IEnumerable<!0>, IEnumerable, IList, ICollection
	{
		// Token: 0x17000BD2 RID: 3026
		// (get) Token: 0x060033CB RID: 13259 RVA: 0x00027C97 File Offset: 0x00025E97
		// (set) Token: 0x060033CC RID: 13260 RVA: 0x00027C9F File Offset: 0x00025E9F
		public Func<int, int> indexMap
		{
			get
			{
				return this.KOklHGOPugZLvbXMphcgvKukCUZDA;
			}
			set
			{
				this.KOklHGOPugZLvbXMphcgvKukCUZDA = value;
				this.auuNhoSMMzznrecfrgIBxqHUiweF++;
			}
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x00027CB6 File Offset: 0x00025EB6
		public MappedArray(T[] A_1, Func<int, int> A_2)
		{
			this.GRUNpJfzHpRUvFolIQxVlrFOLVKP = A_1;
			this.KOklHGOPugZLvbXMphcgvKukCUZDA = A_2;
		}

		// Token: 0x17000BD3 RID: 3027
		public T this[int index]
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP[this.jjYRFNLQCYHdspOvKuxMxwBKLdXB(index)];
			}
			set
			{
				this.GRUNpJfzHpRUvFolIQxVlrFOLVKP[this.jjYRFNLQCYHdspOvKuxMxwBKLdXB(index)] = value;
			}
		}

		// Token: 0x17000BD4 RID: 3028
		// (get) Token: 0x060033D0 RID: 13264 RVA: 0x00027CF5 File Offset: 0x00025EF5
		public int Length
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Length;
			}
		}

		// Token: 0x17000BD5 RID: 3029
		// (get) Token: 0x060033D1 RID: 13265 RVA: 0x00027CF5 File Offset: 0x00025EF5
		int ICollection<!0>.Count
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Length;
			}
		}

		// Token: 0x17000BD6 RID: 3030
		// (get) Token: 0x060033D2 RID: 13266 RVA: 0x00027CFF File Offset: 0x00025EFF
		public bool IsReadOnly
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.IsReadOnly;
			}
		}

		// Token: 0x060033D3 RID: 13267 RVA: 0x000039F5 File Offset: 0x00001BF5
		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033D4 RID: 13268 RVA: 0x00027D0C File Offset: 0x00025F0C
		public void Clear()
		{
			Array.Clear(this.GRUNpJfzHpRUvFolIQxVlrFOLVKP, 0, this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Length);
		}

		// Token: 0x060033D5 RID: 13269 RVA: 0x00027D22 File Offset: 0x00025F22
		public bool Contains(T item)
		{
			return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Contains(item);
		}

		// Token: 0x060033D6 RID: 13270 RVA: 0x00027D30 File Offset: 0x00025F30
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.CopyTo(array, arrayIndex);
		}

		// Token: 0x060033D7 RID: 13271 RVA: 0x00027D3F File Offset: 0x00025F3F
		public IEnumerator<T> GetEnumerator()
		{
			return new MappedArray<T>.kmrXABtSHkhneMlGySYkHbORbFDS(this);
		}

		// Token: 0x060033D8 RID: 13272 RVA: 0x00027D4C File Offset: 0x00025F4C
		public int IndexOf(T item)
		{
			return this.jjYRFNLQCYHdspOvKuxMxwBKLdXB(this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.IndexOf(item));
		}

		// Token: 0x060033D9 RID: 13273 RVA: 0x000039F5 File Offset: 0x00001BF5
		void IList<!0>.NJBMfzkslEEAYigAywxmPuAWkDkC(int A_1, T A_2)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033DA RID: 13274 RVA: 0x000039F5 File Offset: 0x00001BF5
		bool ICollection<!0>.qrFAMofjiRRVpKmNmtJdPvUNvdpSA(T A_1)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033DB RID: 13275 RVA: 0x000039F5 File Offset: 0x00001BF5
		void IList<!0>.xpVnPzMvXbOkEYCjREroFsLSGeki(int A_1)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000BD7 RID: 3031
		object IList.this[int index]
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP[this.jjYRFNLQCYHdspOvKuxMxwBKLdXB(index)];
			}
			set
			{
				this.GRUNpJfzHpRUvFolIQxVlrFOLVKP[this.jjYRFNLQCYHdspOvKuxMxwBKLdXB(index)] = value;
			}
		}

		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x060033DE RID: 13278 RVA: 0x00027CF5 File Offset: 0x00025EF5
		int ICollection.Count
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Length;
			}
		}

		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x060033DF RID: 13279 RVA: 0x00027D89 File Offset: 0x00025F89
		bool IList.IsFixedSize
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.IsFixedSize;
			}
		}

		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x060033E0 RID: 13280 RVA: 0x00027D96 File Offset: 0x00025F96
		object ICollection.SyncRoot
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.SyncRoot;
			}
		}

		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x060033E1 RID: 13281 RVA: 0x00027DA3 File Offset: 0x00025FA3
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.IsSynchronized;
			}
		}

		// Token: 0x060033E2 RID: 13282 RVA: 0x000039F5 File Offset: 0x00001BF5
		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033E3 RID: 13283 RVA: 0x00027DB0 File Offset: 0x00025FB0
		bool IList.Contains(object value)
		{
			return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Contains(value);
		}

		// Token: 0x060033E4 RID: 13284 RVA: 0x00027D30 File Offset: 0x00025F30
		void ICollection.CopyTo(Array array, int index)
		{
			this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.CopyTo(array, index);
		}

		// Token: 0x060033E5 RID: 13285 RVA: 0x00027D3F File Offset: 0x00025F3F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MappedArray<T>.kmrXABtSHkhneMlGySYkHbORbFDS(this);
		}

		// Token: 0x060033E6 RID: 13286 RVA: 0x00027DBE File Offset: 0x00025FBE
		int IList.IndexOf(object value)
		{
			return this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.IndexOf(value);
		}

		// Token: 0x060033E7 RID: 13287 RVA: 0x000039F5 File Offset: 0x00001BF5
		void IList.Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033E8 RID: 13288 RVA: 0x000039F5 File Offset: 0x00001BF5
		void IList.Remove(object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x000039F5 File Offset: 0x00001BF5
		void IList.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060033EA RID: 13290 RVA: 0x00027DCC File Offset: 0x00025FCC
		private int jjYRFNLQCYHdspOvKuxMxwBKLdXB(int A_1)
		{
			if (this.KOklHGOPugZLvbXMphcgvKukCUZDA == null)
			{
				return A_1;
			}
			if (A_1 < 0 || A_1 >= this.GRUNpJfzHpRUvFolIQxVlrFOLVKP.Length)
			{
				return A_1;
			}
			return this.KOklHGOPugZLvbXMphcgvKukCUZDA(A_1);
		}

		// Token: 0x04001BCC RID: 7116
		private T[] GRUNpJfzHpRUvFolIQxVlrFOLVKP;

		// Token: 0x04001BCD RID: 7117
		private int auuNhoSMMzznrecfrgIBxqHUiweF;

		// Token: 0x04001BCE RID: 7118
		private Func<int, int> KOklHGOPugZLvbXMphcgvKukCUZDA;

		// Token: 0x020004F7 RID: 1271
		[Serializable]
		public struct kmrXABtSHkhneMlGySYkHbORbFDS : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x060033EB RID: 13291 RVA: 0x00027DF5 File Offset: 0x00025FF5
			internal kmrXABtSHkhneMlGySYkHbORbFDS(MappedArray<\u0001> A_1)
			{
				this.array = A_1;
				this.index = 0;
				this.version = A_1.auuNhoSMMzznrecfrgIBxqHUiweF;
				this.current = default(\u0001);
			}

			// Token: 0x060033EC RID: 13292 RVA: 0x00002FF9 File Offset: 0x000011F9
			public void Dispose()
			{
			}

			// Token: 0x060033ED RID: 13293 RVA: 0x000B1140 File Offset: 0x000AF340
			public bool MoveNext()
			{
				MappedArray<\u0001> mappedArray = this.array;
				if (this.version == mappedArray.auuNhoSMMzznrecfrgIBxqHUiweF && this.index < mappedArray.Length)
				{
					this.current = mappedArray.GRUNpJfzHpRUvFolIQxVlrFOLVKP[mappedArray.jjYRFNLQCYHdspOvKuxMxwBKLdXB(this.index)];
					this.index++;
					return true;
				}
				return this.LocsrAhOLKUjwxcvnDiNHhrprXenA();
			}

			// Token: 0x060033EE RID: 13294 RVA: 0x00027E1D File Offset: 0x0002601D
			private bool LocsrAhOLKUjwxcvnDiNHhrprXenA()
			{
				if (this.version != this.array.auuNhoSMMzznrecfrgIBxqHUiweF)
				{
					throw new InvalidOperationException("List was changed.");
				}
				this.index = this.array.Length + 1;
				this.current = default(\u0001);
				return false;
			}

			// Token: 0x17000BDC RID: 3036
			// (get) Token: 0x060033EF RID: 13295 RVA: 0x00027E5D File Offset: 0x0002605D
			public \u0001 Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000BDD RID: 3037
			// (get) Token: 0x060033F0 RID: 13296 RVA: 0x00027E65 File Offset: 0x00026065
			object IEnumerator.Current
			{
				get
				{
					if (this.index == 0 || this.index == this.array.Length + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			// Token: 0x060033F1 RID: 13297 RVA: 0x00027E95 File Offset: 0x00026095
			void IEnumerator.Reset()
			{
				if (this.version != this.array.auuNhoSMMzznrecfrgIBxqHUiweF)
				{
					throw new InvalidOperationException("List was changed.");
				}
				this.index = 0;
				this.current = default(\u0001);
			}

			// Token: 0x04001BCF RID: 7119
			private MappedArray<\u0001> array;

			// Token: 0x04001BD0 RID: 7120
			private int index;

			// Token: 0x04001BD1 RID: 7121
			private int version;

			// Token: 0x04001BD2 RID: 7122
			private \u0001 current;
		}
	}
}
