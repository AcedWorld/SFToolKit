using System;
using System.Collections;

namespace Unity.Collections
{
	// Token: 0x0200002F RID: 47
	internal struct ListPair<Key, Value> where Value : IList
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00004058 File Offset: 0x00002258
		public ListPair(Key k, Value v)
		{
			this.key = k;
			this.value = v;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00004068 File Offset: 0x00002268
		public override string ToString()
		{
			string text = string.Format("{0} = [", this.key);
			for (int i = 0; i < this.value.Count; i++)
			{
				string str = text;
				object obj = this.value[i];
				text = str + ((obj != null) ? obj.ToString() : null);
				if (i < this.value.Count - 1)
				{
					text += ", ";
				}
			}
			return text + "]";
		}

		// Token: 0x04000097 RID: 151
		public Key key;

		// Token: 0x04000098 RID: 152
		public Value value;
	}
}
