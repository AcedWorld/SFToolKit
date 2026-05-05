using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F0 RID: 752
	internal struct TransitionData : IStyleDataGroup<TransitionData>, IEquatable<TransitionData>
	{
		// Token: 0x0600196C RID: 6508 RVA: 0x000628E8 File Offset: 0x00060AE8
		public TransitionData Copy()
		{
			return new TransitionData
			{
				transitionDelay = new List<TimeValue>(this.transitionDelay),
				transitionDuration = new List<TimeValue>(this.transitionDuration),
				transitionProperty = new List<StylePropertyName>(this.transitionProperty),
				transitionTimingFunction = new List<EasingFunction>(this.transitionTimingFunction)
			};
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x0006294C File Offset: 0x00060B4C
		public void CopyFrom(ref TransitionData other)
		{
			bool flag = this.transitionDelay != other.transitionDelay;
			if (flag)
			{
				this.transitionDelay.Clear();
				this.transitionDelay.AddRange(other.transitionDelay);
			}
			bool flag2 = this.transitionDuration != other.transitionDuration;
			if (flag2)
			{
				this.transitionDuration.Clear();
				this.transitionDuration.AddRange(other.transitionDuration);
			}
			bool flag3 = this.transitionProperty != other.transitionProperty;
			if (flag3)
			{
				this.transitionProperty.Clear();
				this.transitionProperty.AddRange(other.transitionProperty);
			}
			bool flag4 = this.transitionTimingFunction != other.transitionTimingFunction;
			if (flag4)
			{
				this.transitionTimingFunction.Clear();
				this.transitionTimingFunction.AddRange(other.transitionTimingFunction);
			}
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x00062A30 File Offset: 0x00060C30
		public static bool operator ==(TransitionData lhs, TransitionData rhs)
		{
			return lhs.transitionDelay == rhs.transitionDelay && lhs.transitionDuration == rhs.transitionDuration && lhs.transitionProperty == rhs.transitionProperty && lhs.transitionTimingFunction == rhs.transitionTimingFunction;
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x00062A80 File Offset: 0x00060C80
		public static bool operator !=(TransitionData lhs, TransitionData rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00062A9C File Offset: 0x00060C9C
		public bool Equals(TransitionData other)
		{
			return other == this;
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00062ABC File Offset: 0x00060CBC
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is TransitionData && this.Equals((TransitionData)obj);
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x00062AF4 File Offset: 0x00060CF4
		public override int GetHashCode()
		{
			int num = this.transitionDelay.GetHashCode();
			num = (num * 397 ^ this.transitionDuration.GetHashCode());
			num = (num * 397 ^ this.transitionProperty.GetHashCode());
			return num * 397 ^ this.transitionTimingFunction.GetHashCode();
		}

		// Token: 0x04000AAA RID: 2730
		public List<TimeValue> transitionDelay;

		// Token: 0x04000AAB RID: 2731
		public List<TimeValue> transitionDuration;

		// Token: 0x04000AAC RID: 2732
		public List<StylePropertyName> transitionProperty;

		// Token: 0x04000AAD RID: 2733
		public List<EasingFunction> transitionTimingFunction;
	}
}
