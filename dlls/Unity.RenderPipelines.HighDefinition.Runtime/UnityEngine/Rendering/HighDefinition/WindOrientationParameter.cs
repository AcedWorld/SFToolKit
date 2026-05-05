using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001FE RID: 510
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class WindOrientationParameter : WindParameter
	{
		// Token: 0x06000F5F RID: 3935 RVA: 0x00077F37 File Offset: 0x00076137
		public WindOrientationParameter(float value = 0f, WindParameter.WindOverrideMode mode = WindParameter.WindOverrideMode.Global, bool overrideState = false) : base(value, mode, overrideState)
		{
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x00077F42 File Offset: 0x00076142
		protected override float GetGlobalValue(HDCamera camera)
		{
			return camera.volumeStack.GetComponent<VisualEnvironment>().windOrientation.value;
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x00077F5C File Offset: 0x0007615C
		public override void Interp(WindParameter.WindParamaterValue from, WindParameter.WindParamaterValue to, float t)
		{
			this.m_Value.multiplyValue = 0f;
			this.m_Value.mode = ((t > 0f) ? to.mode : from.mode);
			this.m_Value.additiveValue = from.additiveValue + (to.additiveValue - from.additiveValue) * t;
			this.m_Value.customValue = HDUtils.InterpolateOrientation(from.customValue, to.customValue, t);
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x00077FD8 File Offset: 0x000761D8
		public override float GetValue(HDCamera camera)
		{
			if (this.value.mode == WindParameter.WindOverrideMode.Multiply)
			{
				throw new NotSupportedException("Texture format not supported");
			}
			return base.GetValue(camera);
		}
	}
}
