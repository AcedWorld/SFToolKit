using System;

namespace UnityEngine.VFX
{
	// Token: 0x0200000E RID: 14
	[Serializable]
	internal abstract class EventAttributeValue<T> : EventAttribute
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002929 File Offset: 0x00000B29
		protected EventAttributeValue(Func<VFXEventAttribute, int, bool> hasFunc, Action<VFXEventAttribute, int, T> applyFunc)
		{
			this.m_HasFunc = hasFunc;
			this.m_ApplyFunc = applyFunc;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000293F File Offset: 0x00000B3F
		public sealed override bool ApplyToVFX(VFXEventAttribute eventAttribute)
		{
			if (!this.m_HasFunc(eventAttribute, this.id))
			{
				return false;
			}
			this.m_ApplyFunc(eventAttribute, this.id, this.value);
			return true;
		}

		// Token: 0x04000025 RID: 37
		private readonly Func<VFXEventAttribute, int, bool> m_HasFunc;

		// Token: 0x04000026 RID: 38
		private readonly Action<VFXEventAttribute, int, T> m_ApplyFunc;

		// Token: 0x04000027 RID: 39
		public T value;
	}
}
