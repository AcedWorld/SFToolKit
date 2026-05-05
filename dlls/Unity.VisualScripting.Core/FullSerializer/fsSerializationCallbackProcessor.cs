using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200019F RID: 415
	public class fsSerializationCallbackProcessor : fsObjectProcessor
	{
		// Token: 0x06000ADE RID: 2782 RVA: 0x0002D546 File Offset: 0x0002B746
		public override bool CanProcess(Type type)
		{
			return typeof(fsISerializationCallbacks).IsAssignableFrom(type);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x0002D558 File Offset: 0x0002B758
		public override void OnBeforeSerialize(Type storageType, object instance)
		{
			if (instance == null)
			{
				return;
			}
			((fsISerializationCallbacks)instance).OnBeforeSerialize(storageType);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0002D56A File Offset: 0x0002B76A
		public override void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
			if (instance == null)
			{
				return;
			}
			((fsISerializationCallbacks)instance).OnAfterSerialize(storageType, ref data);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0002D580 File Offset: 0x0002B780
		public override void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data)
		{
			if (!(instance is fsISerializationCallbacks))
			{
				string str = "Please ensure the converter for ";
				string str2 = (storageType != null) ? storageType.ToString() : null;
				string str3 = " actually returns an instance of it, not an instance of ";
				Type type = instance.GetType();
				throw new InvalidCastException(str + str2 + str3 + ((type != null) ? type.ToString() : null));
			}
			((fsISerializationCallbacks)instance).OnBeforeDeserialize(storageType, ref data);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0002D5D6 File Offset: 0x0002B7D6
		public override void OnAfterDeserialize(Type storageType, object instance)
		{
			if (instance == null)
			{
				return;
			}
			((fsISerializationCallbacks)instance).OnAfterDeserialize(storageType);
		}
	}
}
