using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001FF RID: 511
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class WindSpeedParameter : WindParameter
	{
		// Token: 0x06000F63 RID: 3939 RVA: 0x00077FFA File Offset: 0x000761FA
		public WindSpeedParameter(float value = 100f, WindParameter.WindOverrideMode mode = WindParameter.WindOverrideMode.Global, bool overrideState = false) : base(value, mode, overrideState)
		{
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x00078005 File Offset: 0x00076205
		protected override float GetGlobalValue(HDCamera camera)
		{
			return camera.volumeStack.GetComponent<VisualEnvironment>().windSpeed.value;
		}
	}
}
