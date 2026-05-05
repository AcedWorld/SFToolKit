using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B9 RID: 697
	public struct TimerState : IEquatable<TimerState>
	{
		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x0600142A RID: 5162 RVA: 0x00047D1D File Offset: 0x00045F1D
		// (set) Token: 0x0600142B RID: 5163 RVA: 0x00047D25 File Offset: 0x00045F25
		public long start { readonly get; set; }

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x0600142C RID: 5164 RVA: 0x00047D2E File Offset: 0x00045F2E
		// (set) Token: 0x0600142D RID: 5165 RVA: 0x00047D36 File Offset: 0x00045F36
		public long now { readonly get; set; }

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x00047D40 File Offset: 0x00045F40
		public long deltaTime
		{
			get
			{
				return this.now - this.start;
			}
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x00047D60 File Offset: 0x00045F60
		public override bool Equals(object obj)
		{
			return obj is TimerState && this.Equals((TimerState)obj);
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x00047D8C File Offset: 0x00045F8C
		public bool Equals(TimerState other)
		{
			return this.start == other.start && this.now == other.now && this.deltaTime == other.deltaTime;
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00047DD0 File Offset: 0x00045FD0
		public override int GetHashCode()
		{
			int num = 540054806;
			num = num * -1521134295 + this.start.GetHashCode();
			num = num * -1521134295 + this.now.GetHashCode();
			return num * -1521134295 + this.deltaTime.GetHashCode();
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x00047E30 File Offset: 0x00046030
		public static bool operator ==(TimerState state1, TimerState state2)
		{
			return state1.Equals(state2);
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x00047E4C File Offset: 0x0004604C
		public static bool operator !=(TimerState state1, TimerState state2)
		{
			return !(state1 == state2);
		}
	}
}
