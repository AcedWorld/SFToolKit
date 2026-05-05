using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001FD RID: 509
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public abstract class WindParameter : VolumeParameter<WindParameter.WindParamaterValue>
	{
		// Token: 0x06000F5A RID: 3930 RVA: 0x00077D48 File Offset: 0x00075F48
		public WindParameter(float value = 0f, WindParameter.WindOverrideMode mode = WindParameter.WindOverrideMode.Global, bool overrideState = false)
		{
			WindParameter.WindParamaterValue value2 = default(WindParameter.WindParamaterValue);
			base..ctor(value2, overrideState);
			value2 = new WindParameter.WindParamaterValue
			{
				mode = mode,
				customValue = ((mode <= WindParameter.WindOverrideMode.Global) ? value : 0f),
				additiveValue = ((mode == WindParameter.WindOverrideMode.Additive) ? value : 0f),
				multiplyValue = ((mode == WindParameter.WindOverrideMode.Multiply) ? value : 1f)
			};
			this.value = value2;
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x00077DB8 File Offset: 0x00075FB8
		public override void Interp(WindParameter.WindParamaterValue from, WindParameter.WindParamaterValue to, float t)
		{
			this.m_Value.mode = ((t > 0f) ? to.mode : from.mode);
			this.m_Value.customValue = from.customValue + (to.customValue - from.customValue) * t;
			this.m_Value.additiveValue = from.additiveValue + (to.additiveValue - from.additiveValue) * t;
			this.m_Value.multiplyValue = from.multiplyValue + (to.multiplyValue - from.multiplyValue) * t;
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x00077E4C File Offset: 0x0007604C
		public override int GetHashCode()
		{
			int num = (17 * 23 + this.overrideState.GetHashCode()) * 23;
			WindParameter.WindParamaterValue value = this.value;
			int num2 = (num + value.mode.GetHashCode()) * 23;
			value = this.value;
			int num3 = (num2 + value.customValue.GetHashCode()) * 23;
			value = this.value;
			int num4 = (num3 + value.additiveValue.GetHashCode()) * 23;
			value = this.value;
			return num4 + value.multiplyValue.GetHashCode();
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x00077ED0 File Offset: 0x000760D0
		public virtual float GetValue(HDCamera camera)
		{
			if (this.value.mode == WindParameter.WindOverrideMode.Custom)
			{
				return this.value.customValue;
			}
			float globalValue = this.GetGlobalValue(camera);
			if (this.value.mode == WindParameter.WindOverrideMode.Additive)
			{
				return globalValue + this.value.additiveValue;
			}
			if (this.value.mode == WindParameter.WindOverrideMode.Multiply)
			{
				return globalValue * this.value.multiplyValue;
			}
			return globalValue;
		}

		// Token: 0x06000F5E RID: 3934
		protected abstract float GetGlobalValue(HDCamera camera);

		// Token: 0x02000437 RID: 1079
		public enum WindOverrideMode
		{
			// Token: 0x0400295F RID: 10591
			Custom,
			// Token: 0x04002960 RID: 10592
			Global,
			// Token: 0x04002961 RID: 10593
			Additive,
			// Token: 0x04002962 RID: 10594
			Multiply
		}

		// Token: 0x02000438 RID: 1080
		[Serializable]
		public struct WindParamaterValue
		{
			// Token: 0x06001439 RID: 5177 RVA: 0x00099258 File Offset: 0x00097458
			public override string ToString()
			{
				if (this.mode == WindParameter.WindOverrideMode.Global)
				{
					return this.mode.ToString();
				}
				string str = null;
				if (this.mode == WindParameter.WindOverrideMode.Custom)
				{
					str = this.customValue.ToString();
				}
				if (this.mode == WindParameter.WindOverrideMode.Additive)
				{
					str = this.additiveValue.ToString();
				}
				if (this.mode == WindParameter.WindOverrideMode.Multiply)
				{
					str = this.multiplyValue.ToString();
				}
				return str + " (" + this.mode.ToString() + ")";
			}

			// Token: 0x04002963 RID: 10595
			public WindParameter.WindOverrideMode mode;

			// Token: 0x04002964 RID: 10596
			public float customValue;

			// Token: 0x04002965 RID: 10597
			public float additiveValue;

			// Token: 0x04002966 RID: 10598
			public float multiplyValue;
		}
	}
}
