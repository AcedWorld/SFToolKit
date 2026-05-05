using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000CA RID: 202
	public static class INotifyValueChangedExtensions
	{
		// Token: 0x060006C6 RID: 1734 RVA: 0x00019C58 File Offset: 0x00017E58
		public static bool RegisterValueChangedCallback<T>(this INotifyValueChanged<T> control, EventCallback<ChangeEvent<T>> callback)
		{
			CallbackEventHandler callbackEventHandler = control as CallbackEventHandler;
			bool flag = callbackEventHandler != null;
			bool result;
			if (flag)
			{
				callbackEventHandler.RegisterCallback<ChangeEvent<T>>(callback, TrickleDown.NoTrickleDown);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00019C88 File Offset: 0x00017E88
		public static bool UnregisterValueChangedCallback<T>(this INotifyValueChanged<T> control, EventCallback<ChangeEvent<T>> callback)
		{
			CallbackEventHandler callbackEventHandler = control as CallbackEventHandler;
			bool flag = callbackEventHandler != null;
			bool result;
			if (flag)
			{
				callbackEventHandler.UnregisterCallback<ChangeEvent<T>>(callback, TrickleDown.NoTrickleDown);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
