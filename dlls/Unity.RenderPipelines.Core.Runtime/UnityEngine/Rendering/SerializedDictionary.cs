using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000057 RID: 87
	[Serializable]
	public class SerializedDictionary<K, V> : SerializedDictionary<K, V, K, V>
	{
		// Token: 0x060002CC RID: 716 RVA: 0x0000C6E8 File Offset: 0x0000A8E8
		public override K SerializeKey(K key)
		{
			return key;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000C6EB File Offset: 0x0000A8EB
		public override V SerializeValue(V val)
		{
			return val;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000C6EE File Offset: 0x0000A8EE
		public override K DeserializeKey(K key)
		{
			return key;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000C6F1 File Offset: 0x0000A8F1
		public override V DeserializeValue(V val)
		{
			return val;
		}
	}
}
