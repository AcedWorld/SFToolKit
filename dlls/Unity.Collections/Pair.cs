using System;

namespace Unity.Collections
{
	// Token: 0x0200002E RID: 46
	internal struct Pair<Key, Value>
	{
		// Token: 0x060000EC RID: 236 RVA: 0x00004026 File Offset: 0x00002226
		public Pair(Key k, Value v)
		{
			this.key = k;
			this.value = v;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004036 File Offset: 0x00002236
		public override string ToString()
		{
			return string.Format("{0} = {1}", this.key, this.value);
		}

		// Token: 0x04000095 RID: 149
		public Key key;

		// Token: 0x04000096 RID: 150
		public Value value;
	}
}
