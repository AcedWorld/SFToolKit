using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000C9 RID: 201
	public interface INotifyValueChanged<T>
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060006C3 RID: 1731
		// (set) Token: 0x060006C4 RID: 1732
		T value { get; set; }

		// Token: 0x060006C5 RID: 1733
		void SetValueWithoutNotify(T newValue);
	}
}
