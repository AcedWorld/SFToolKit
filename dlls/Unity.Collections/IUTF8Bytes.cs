using System;

namespace Unity.Collections
{
	// Token: 0x02000081 RID: 129
	public interface IUTF8Bytes
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000591 RID: 1425
		bool IsEmpty { get; }

		// Token: 0x06000592 RID: 1426
		unsafe byte* GetUnsafePtr();

		// Token: 0x06000593 RID: 1427
		bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory);
	}
}
