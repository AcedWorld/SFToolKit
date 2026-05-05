using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200051C RID: 1308
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class KeyedGetSetValueStore<TKey> : IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>, IEnumerable
	{
		// Token: 0x17000C0C RID: 3084
		// (get) Token: 0x060035D9 RID: 13785 RVA: 0x0002A263 File Offset: 0x00028463
		public int Count
		{
			get
			{
				return this.arRPxAXGrKSWkQAelubhRVNPeKZf.Count;
			}
		}

		// Token: 0x17000C0D RID: 3085
		// (get) Token: 0x060035DA RID: 13786 RVA: 0x0002A270 File Offset: 0x00028470
		public bool isReadOnlyCollection
		{
			get
			{
				return this.tGKEmJaeiufCJCbgjfeuNsCDTGiYC;
			}
		}

		// Token: 0x060035DB RID: 13787 RVA: 0x0002A278 File Offset: 0x00028478
		public KeyedGetSetValueStore(Dictionary<TKey, object> A_1, bool A_2)
		{
			this.arRPxAXGrKSWkQAelubhRVNPeKZf = A_1;
			this.tGKEmJaeiufCJCbgjfeuNsCDTGiYC = A_2;
		}

		// Token: 0x060035DC RID: 13788 RVA: 0x0002A28E File Offset: 0x0002848E
		public KeyedGetSetValueStore(bool A_1)
		{
			this.tGKEmJaeiufCJCbgjfeuNsCDTGiYC = A_1;
			this.arRPxAXGrKSWkQAelubhRVNPeKZf = new Dictionary<TKey, object>();
		}

		// Token: 0x060035DD RID: 13789 RVA: 0x0002A2A8 File Offset: 0x000284A8
		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			this.arRPxAXGrKSWkQAelubhRVNPeKZf.Add(key, item);
		}

		// Token: 0x060035DE RID: 13790 RVA: 0x000B5F1C File Offset: 0x000B411C
		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			object obj;
			IGetSetValue<TValue> result;
			if (!this.arRPxAXGrKSWkQAelubhRVNPeKZf.TryGetValue(key, out obj) || (result = (obj as IGetSetValue<TValue>)) == null)
			{
				KeyedGetSetValueStore<TKey>.CaGdpScgFiOFBPGZFLImGjqFqjnl(key, typeof(TValue));
				return null;
			}
			return result;
		}

		// Token: 0x060035DF RID: 13791 RVA: 0x0002A2CB File Offset: 0x000284CB
		public bool RemoveItem<TValue>(TKey key)
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.Remove(key);
		}

		// Token: 0x060035E0 RID: 13792 RVA: 0x0002A2DF File Offset: 0x000284DF
		public bool ContainsKey(TKey key)
		{
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.ContainsKey(key);
		}

		// Token: 0x060035E1 RID: 13793 RVA: 0x0002A2ED File Offset: 0x000284ED
		public void Clear()
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			this.arRPxAXGrKSWkQAelubhRVNPeKZf.Clear();
		}

		// Token: 0x060035E2 RID: 13794 RVA: 0x000B5F58 File Offset: 0x000B4158
		public bool ContainsValue<TValue>(TKey key)
		{
			object obj;
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.TryGetValue(key, out obj) && obj is IGetSetValue<TValue>;
		}

		// Token: 0x060035E3 RID: 13795 RVA: 0x000B5F80 File Offset: 0x000B4180
		public TValue GetValue<TValue>(TKey key)
		{
			TValue result;
			if (!this.TryGetValue<TValue>(key, out result))
			{
				KeyedGetSetValueStore<TKey>.CaGdpScgFiOFBPGZFLImGjqFqjnl(key, typeof(TValue));
			}
			return result;
		}

		// Token: 0x060035E4 RID: 13796 RVA: 0x0002A300 File Offset: 0x00028500
		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!this.TrySetValue<TValue>(key, value))
			{
				KeyedGetSetValueStore<TKey>.CaGdpScgFiOFBPGZFLImGjqFqjnl(key, typeof(TValue));
			}
		}

		// Token: 0x060035E5 RID: 13797 RVA: 0x000B5FAC File Offset: 0x000B41AC
		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			object obj;
			IGetValue<TValue> getValue;
			if (!this.arRPxAXGrKSWkQAelubhRVNPeKZf.TryGetValue(key, out obj) || (getValue = (obj as IGetValue<TValue>)) == null)
			{
				value = default(TValue);
				Logger.LogError(KeyedGetSetValueStore<TKey>.BrWyNoWMOaxnHPtTlijZxLDGVNhW(key, typeof(TValue)), true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		// Token: 0x060035E6 RID: 13798 RVA: 0x000B6000 File Offset: 0x000B4200
		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			object obj;
			ISetValue<TValue> setValue;
			if (!this.arRPxAXGrKSWkQAelubhRVNPeKZf.TryGetValue(key, out obj) || (setValue = (obj as GetSetValue<TValue>)) == null)
			{
				Logger.LogError(KeyedGetSetValueStore<TKey>.BrWyNoWMOaxnHPtTlijZxLDGVNhW(key, typeof(TValue)), true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		// Token: 0x060035E7 RID: 13799 RVA: 0x0002A31C File Offset: 0x0002851C
		private void uhcKaRrAbUdqkEzyBbGBOCWtxUzx()
		{
			if (this.tGKEmJaeiufCJCbgjfeuNsCDTGiYC)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		// Token: 0x060035E8 RID: 13800 RVA: 0x0002A331 File Offset: 0x00028531
		private static void CaGdpScgFiOFBPGZFLImGjqFqjnl(TKey A_0, Type A_1)
		{
			throw new Exception(KeyedGetSetValueStore<TKey>.BrWyNoWMOaxnHPtTlijZxLDGVNhW(A_0, A_1));
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x000B6048 File Offset: 0x000B4248
		private static string BrWyNoWMOaxnHPtTlijZxLDGVNhW(TKey A_0, Type A_1)
		{
			string[] array = new string[5];
			array[0] = "Value with key ";
			int num = 1;
			TKey tkey = A_0;
			array[num] = ((tkey != null) ? tkey.ToString() : null);
			array[2] = " of type ";
			array[3] = ((A_1 != null) ? A_1.ToString() : null);
			array[4] = " not found.";
			return string.Concat(array);
		}

		// Token: 0x060035EA RID: 13802 RVA: 0x0002A33F File Offset: 0x0002853F
		void IDictionary<!0, object>.TUfVPCOPDxrLKaPFkujszflnqTXj(TKey A_1, object A_2)
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			this.arRPxAXGrKSWkQAelubhRVNPeKZf.Add(A_1, A_2);
		}

		// Token: 0x060035EB RID: 13803 RVA: 0x0002A354 File Offset: 0x00028554
		bool IDictionary<!0, object>.mPpIhFFRpgenfPeFggzWWYFmYOAJ(TKey A_1)
		{
			return this.ContainsKey(A_1);
		}

		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x060035EC RID: 13804 RVA: 0x0002A35D File Offset: 0x0002855D
		ICollection<TKey> IDictionary<!0, object>.Keys
		{
			get
			{
				return this.arRPxAXGrKSWkQAelubhRVNPeKZf.Keys;
			}
		}

		// Token: 0x060035ED RID: 13805 RVA: 0x0002A2CB File Offset: 0x000284CB
		bool IDictionary<!0, object>.vJXfpihhnAJUAskpDTtICAMKsEDLA(TKey A_1)
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.Remove(A_1);
		}

		// Token: 0x060035EE RID: 13806 RVA: 0x0002A36A File Offset: 0x0002856A
		bool IDictionary<!0, object>.jfTGaKgBToKpDgeUEtIRZjZqfcKwB(TKey A_1, out object A_2)
		{
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.TryGetValue(A_1, out A_2);
		}

		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x060035EF RID: 13807 RVA: 0x0002A379 File Offset: 0x00028579
		ICollection<object> IDictionary<!0, object>.Values
		{
			get
			{
				return this.arRPxAXGrKSWkQAelubhRVNPeKZf.Values;
			}
		}

		// Token: 0x17000C10 RID: 3088
		object IDictionary<!0, object>.this[TKey]
		{
			get
			{
				return this.arRPxAXGrKSWkQAelubhRVNPeKZf[A_1];
			}
			set
			{
				this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
				this.arRPxAXGrKSWkQAelubhRVNPeKZf[A_1] = value;
			}
		}

		// Token: 0x060035F2 RID: 13810 RVA: 0x0002A3A9 File Offset: 0x000285A9
		void ICollection<KeyValuePair<!0, object>>.dwabrrtRykUPiKJUSEqWqYMoyjmA(KeyValuePair<TKey, object> A_1)
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			((ICollection<KeyValuePair<!0, object>>)this.arRPxAXGrKSWkQAelubhRVNPeKZf).Add(A_1);
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x0002A3BD File Offset: 0x000285BD
		void ICollection<KeyValuePair<!0, object>>.BGqJoSEEgzYmmcFznUYAardsrEPl()
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			((ICollection<KeyValuePair<!0, object>>)this.arRPxAXGrKSWkQAelubhRVNPeKZf).Clear();
		}

		// Token: 0x060035F4 RID: 13812 RVA: 0x0002A3D0 File Offset: 0x000285D0
		bool ICollection<KeyValuePair<!0, object>>.oljCrwhYyeGghwkwTclNwMndDosk(KeyValuePair<TKey, object> A_1)
		{
			return ((ICollection<KeyValuePair<!0, object>>)this.arRPxAXGrKSWkQAelubhRVNPeKZf).Contains(A_1);
		}

		// Token: 0x060035F5 RID: 13813 RVA: 0x0002A3DE File Offset: 0x000285DE
		void ICollection<KeyValuePair<!0, object>>.FkszAgmSiZpKTrkXXxOXEFlobrfJ(KeyValuePair<TKey, object>[] A_1, int A_2)
		{
			((ICollection<KeyValuePair<!0, object>>)this.arRPxAXGrKSWkQAelubhRVNPeKZf).CopyTo(A_1, A_2);
		}

		// Token: 0x17000C11 RID: 3089
		// (get) Token: 0x060035F6 RID: 13814 RVA: 0x0002A263 File Offset: 0x00028463
		int ICollection<KeyValuePair<!0, object>>.Count
		{
			get
			{
				return this.arRPxAXGrKSWkQAelubhRVNPeKZf.Count;
			}
		}

		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x060035F7 RID: 13815 RVA: 0x0002A270 File Offset: 0x00028470
		bool ICollection<KeyValuePair<!0, object>>.IsReadOnly
		{
			get
			{
				return this.tGKEmJaeiufCJCbgjfeuNsCDTGiYC;
			}
		}

		// Token: 0x060035F8 RID: 13816 RVA: 0x0002A3ED File Offset: 0x000285ED
		bool ICollection<KeyValuePair<!0, object>>.MgJhTMEKJvDkbFDBWbLkrzmwnAQx(KeyValuePair<TKey, object> A_1)
		{
			this.uhcKaRrAbUdqkEzyBbGBOCWtxUzx();
			return ((ICollection<KeyValuePair<!0, object>>)this.arRPxAXGrKSWkQAelubhRVNPeKZf).Remove(A_1);
		}

		// Token: 0x060035F9 RID: 13817 RVA: 0x0002A401 File Offset: 0x00028601
		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<!0, object>>.DkNxZGCogpJzOCOsYNzTiKaGvveN()
		{
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.GetEnumerator();
		}

		// Token: 0x060035FA RID: 13818 RVA: 0x0002A401 File Offset: 0x00028601
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.arRPxAXGrKSWkQAelubhRVNPeKZf.GetEnumerator();
		}

		// Token: 0x04001C6F RID: 7279
		private readonly Dictionary<TKey, object> arRPxAXGrKSWkQAelubhRVNPeKZf;

		// Token: 0x04001C70 RID: 7280
		private readonly bool tGKEmJaeiufCJCbgjfeuNsCDTGiYC;
	}
}
