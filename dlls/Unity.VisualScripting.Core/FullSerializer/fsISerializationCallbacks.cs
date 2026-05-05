using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200019E RID: 414
	public interface fsISerializationCallbacks
	{
		// Token: 0x06000ADA RID: 2778
		void OnBeforeSerialize(Type storageType);

		// Token: 0x06000ADB RID: 2779
		void OnAfterSerialize(Type storageType, ref fsData data);

		// Token: 0x06000ADC RID: 2780
		void OnBeforeDeserialize(Type storageType, ref fsData data);

		// Token: 0x06000ADD RID: 2781
		void OnAfterDeserialize(Type storageType);
	}
}
