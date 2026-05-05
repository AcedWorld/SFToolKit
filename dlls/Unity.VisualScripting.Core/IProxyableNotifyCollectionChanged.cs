using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001B RID: 27
	public interface IProxyableNotifyCollectionChanged<T>
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000A1 RID: 161
		// (set) Token: 0x060000A2 RID: 162
		bool ProxyCollectionChange { get; set; }

		// Token: 0x060000A3 RID: 163
		void BeforeAdd(T item);

		// Token: 0x060000A4 RID: 164
		void AfterAdd(T item);

		// Token: 0x060000A5 RID: 165
		void BeforeRemove(T item);

		// Token: 0x060000A6 RID: 166
		void AfterRemove(T item);
	}
}
