using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200035A RID: 858
	[Serializable]
	internal struct StyleValueHandle
	{
		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001CBA RID: 7354 RVA: 0x0006F6D4 File Offset: 0x0006D8D4
		// (set) Token: 0x06001CBB RID: 7355 RVA: 0x0006F6EC File Offset: 0x0006D8EC
		public StyleValueType valueType
		{
			get
			{
				return this.m_ValueType;
			}
			internal set
			{
				this.m_ValueType = value;
			}
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x0006F6F6 File Offset: 0x0006D8F6
		internal StyleValueHandle(int valueIndex, StyleValueType valueType)
		{
			this.valueIndex = valueIndex;
			this.m_ValueType = valueType;
		}

		// Token: 0x04000BF8 RID: 3064
		[SerializeField]
		private StyleValueType m_ValueType;

		// Token: 0x04000BF9 RID: 3065
		[SerializeField]
		internal int valueIndex;
	}
}
