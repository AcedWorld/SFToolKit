using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A5 RID: 421
	public abstract class fsObjectProcessor
	{
		// Token: 0x06000B0B RID: 2827 RVA: 0x0002E8B7 File Offset: 0x0002CAB7
		public virtual bool CanProcess(Type type)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0002E8BE File Offset: 0x0002CABE
		public virtual void OnBeforeSerialize(Type storageType, object instance)
		{
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0002E8C0 File Offset: 0x0002CAC0
		public virtual void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0002E8C2 File Offset: 0x0002CAC2
		public virtual void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0002E8C4 File Offset: 0x0002CAC4
		public virtual void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data)
		{
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0002E8C6 File Offset: 0x0002CAC6
		public virtual void OnAfterDeserialize(Type storageType, object instance)
		{
		}
	}
}
