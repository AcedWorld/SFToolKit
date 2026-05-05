using System;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A0 RID: 416
	public class fsSerializationCallbackReceiverProcessor : fsObjectProcessor
	{
		// Token: 0x06000AE4 RID: 2788 RVA: 0x0002D5F0 File Offset: 0x0002B7F0
		public override bool CanProcess(Type type)
		{
			return typeof(ISerializationCallbackReceiver).IsAssignableFrom(type);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0002D602 File Offset: 0x0002B802
		public override void OnBeforeSerialize(Type storageType, object instance)
		{
			if (instance == null || instance is Object)
			{
				return;
			}
			((ISerializationCallbackReceiver)instance).OnBeforeSerialize();
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0002D61B File Offset: 0x0002B81B
		public override void OnAfterDeserialize(Type storageType, object instance)
		{
			if (instance == null || instance is Object)
			{
				return;
			}
			((ISerializationCallbackReceiver)instance).OnAfterDeserialize();
		}
	}
}
