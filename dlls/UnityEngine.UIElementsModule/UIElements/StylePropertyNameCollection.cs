using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000236 RID: 566
	public struct StylePropertyNameCollection : IEnumerable<StylePropertyName>, IEnumerable
	{
		// Token: 0x0600103A RID: 4154 RVA: 0x0003B395 File Offset: 0x00039595
		internal StylePropertyNameCollection(List<StylePropertyName> list)
		{
			this.propertiesList = list;
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x0003B3A0 File Offset: 0x000395A0
		public StylePropertyNameCollection.Enumerator GetEnumerator()
		{
			return new StylePropertyNameCollection.Enumerator(this.propertiesList.GetEnumerator());
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x0003B3C4 File Offset: 0x000395C4
		IEnumerator<StylePropertyName> IEnumerable<StylePropertyName>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0003B3E4 File Offset: 0x000395E4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0003B404 File Offset: 0x00039604
		public bool Contains(StylePropertyName stylePropertyName)
		{
			bool result;
			using (List<StylePropertyName>.Enumerator enumerator = this.propertiesList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					StylePropertyName lhs = enumerator.Current;
					bool flag = lhs == stylePropertyName;
					if (flag)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x04000732 RID: 1842
		internal List<StylePropertyName> propertiesList;

		// Token: 0x02000237 RID: 567
		public struct Enumerator : IEnumerator<StylePropertyName>, IEnumerator, IDisposable
		{
			// Token: 0x0600103F RID: 4159 RVA: 0x0003B468 File Offset: 0x00039668
			internal Enumerator(List<StylePropertyName>.Enumerator enumerator)
			{
				this.m_Enumerator = enumerator;
			}

			// Token: 0x06001040 RID: 4160 RVA: 0x0003B472 File Offset: 0x00039672
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x1700036D RID: 877
			// (get) Token: 0x06001041 RID: 4161 RVA: 0x0003B47F File Offset: 0x0003967F
			public StylePropertyName Current
			{
				get
				{
					return this.m_Enumerator.Current;
				}
			}

			// Token: 0x1700036E RID: 878
			// (get) Token: 0x06001042 RID: 4162 RVA: 0x0003B48C File Offset: 0x0003968C
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06001043 RID: 4163 RVA: 0x00003CD2 File Offset: 0x00001ED2
			public void Reset()
			{
			}

			// Token: 0x06001044 RID: 4164 RVA: 0x0003B499 File Offset: 0x00039699
			public void Dispose()
			{
				this.m_Enumerator.Dispose();
			}

			// Token: 0x04000733 RID: 1843
			private List<StylePropertyName>.Enumerator m_Enumerator;
		}
	}
}
