using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001C1 RID: 449
	[Serializable]
	public class ScalableSettingValue<T>
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x0006F13A File Offset: 0x0006D33A
		// (set) Token: 0x06000DBE RID: 3518 RVA: 0x0006F142 File Offset: 0x0006D342
		public int level
		{
			get
			{
				return this.m_Level;
			}
			set
			{
				this.m_Level = value;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x0006F14B File Offset: 0x0006D34B
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x0006F153 File Offset: 0x0006D353
		public bool useOverride
		{
			get
			{
				return this.m_UseOverride;
			}
			set
			{
				this.m_UseOverride = value;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x0006F15C File Offset: 0x0006D35C
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x0006F164 File Offset: 0x0006D364
		public T @override
		{
			get
			{
				return this.m_Override;
			}
			set
			{
				this.m_Override = value;
			}
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x0006F16D File Offset: 0x0006D36D
		public T Value(ScalableSetting<T> source)
		{
			if (!this.m_UseOverride && source != null)
			{
				return source[this.m_Level];
			}
			return this.m_Override;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x0006F18D File Offset: 0x0006D38D
		public void CopyTo(ScalableSettingValue<T> target)
		{
			target.m_Override = this.m_Override;
			target.m_UseOverride = this.m_UseOverride;
			target.m_Level = this.m_Level;
		}

		// Token: 0x04001597 RID: 5527
		[SerializeField]
		private T m_Override;

		// Token: 0x04001598 RID: 5528
		[SerializeField]
		private bool m_UseOverride;

		// Token: 0x04001599 RID: 5529
		[SerializeField]
		private int m_Level;
	}
}
