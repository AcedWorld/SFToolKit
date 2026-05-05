using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000115 RID: 277
	[Serializable]
	public class AnimationCurveParameter : VolumeParameter<AnimationCurve>
	{
		// Token: 0x06000855 RID: 2133 RVA: 0x000270BC File Offset: 0x000252BC
		public AnimationCurveParameter(AnimationCurve value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x000270C6 File Offset: 0x000252C6
		public override void Interp(AnimationCurve lhsCurve, AnimationCurve rhsCurve, float t)
		{
			this.m_Value = lhsCurve;
			KeyframeUtility.InterpAnimationCurve(ref this.m_Value, rhsCurve, t);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x000270DC File Offset: 0x000252DC
		public override void SetValue(VolumeParameter parameter)
		{
			this.m_Value.CopyFrom(((AnimationCurveParameter)parameter).m_Value);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x000270F4 File Offset: 0x000252F4
		public override object Clone()
		{
			return new AnimationCurveParameter(new AnimationCurve(base.GetValue<AnimationCurve>().keys), this.overrideState);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00027114 File Offset: 0x00025314
		public override int GetHashCode()
		{
			return this.overrideState.GetHashCode() * 23 + this.value.GetHashCode();
		}
	}
}
