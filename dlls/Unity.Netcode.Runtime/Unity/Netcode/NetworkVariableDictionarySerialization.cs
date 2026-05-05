using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x020000D8 RID: 216
	internal class NetworkVariableDictionarySerialization<TKey, TVal> where TKey : IEquatable<TKey>
	{
		// Token: 0x06000525 RID: 1317 RVA: 0x00015A00 File Offset: 0x00013C00
		internal static bool GenericEqualsDictionary(ref Dictionary<TKey, TVal> a, ref Dictionary<TKey, TVal> b)
		{
			if (a == null != (b == null))
			{
				return false;
			}
			if (a == null)
			{
				return true;
			}
			if (a.Count != b.Count)
			{
				return false;
			}
			foreach (KeyValuePair<TKey, TVal> keyValuePair in a)
			{
				TVal tval;
				if (!b.TryGetValue(keyValuePair.Key, out tval))
				{
					return false;
				}
				TVal value = keyValuePair.Value;
				if (!NetworkVariableSerialization<TVal>.AreEqual(ref value, ref tval))
				{
					return false;
				}
			}
			return true;
		}
	}
}
