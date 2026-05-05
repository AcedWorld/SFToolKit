using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000010 RID: 16
	public interface ICloner
	{
		// Token: 0x06000052 RID: 82
		bool Handles(Type type);

		// Token: 0x06000053 RID: 83
		object ConstructClone(Type type, object original);

		// Token: 0x06000054 RID: 84
		void BeforeClone(Type type, object original);

		// Token: 0x06000055 RID: 85
		void FillClone(Type type, ref object clone, object original, CloningContext context);

		// Token: 0x06000056 RID: 86
		void AfterClone(Type type, object clone);
	}
}
