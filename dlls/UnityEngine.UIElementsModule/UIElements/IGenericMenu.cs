using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000B4 RID: 180
	internal interface IGenericMenu
	{
		// Token: 0x06000640 RID: 1600
		void AddItem(string itemName, bool isChecked, Action action);

		// Token: 0x06000641 RID: 1601
		void AddItem(string itemName, bool isChecked, Action<object> action, object data);

		// Token: 0x06000642 RID: 1602
		void AddDisabledItem(string itemName, bool isChecked);

		// Token: 0x06000643 RID: 1603
		void AddSeparator(string path);

		// Token: 0x06000644 RID: 1604
		void DropDown(Rect position, VisualElement targetElement = null, bool anchored = false);
	}
}
