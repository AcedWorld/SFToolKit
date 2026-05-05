using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200005D RID: 93
	public abstract class DebugDisplaySettingsPanel<T> : DebugDisplaySettingsPanel where T : IDebugDisplaySettingsData
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000CC39 File Offset: 0x0000AE39
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x0000CC41 File Offset: 0x0000AE41
		public T data
		{
			get
			{
				return this.m_Data;
			}
			internal set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000CC4A File Offset: 0x0000AE4A
		protected DebugDisplaySettingsPanel(T data)
		{
			this.m_Data = data;
		}

		// Token: 0x040001AB RID: 427
		internal T m_Data;
	}
}
