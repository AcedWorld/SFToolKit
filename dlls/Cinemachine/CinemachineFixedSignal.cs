using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000053 RID: 83
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineImpulseFixedSignals.html")]
	public class CinemachineFixedSignal : SignalSourceAsset
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00015C01 File Offset: 0x00013E01
		public override float SignalDuration
		{
			get
			{
				return Mathf.Max(this.AxisDuration(this.m_XCurve), Mathf.Max(this.AxisDuration(this.m_YCurve), this.AxisDuration(this.m_ZCurve)));
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00015C34 File Offset: 0x00013E34
		private float AxisDuration(AnimationCurve axis)
		{
			float result = 0f;
			if (axis != null && axis.length > 1)
			{
				float time = axis[0].time;
				result = axis[axis.length - 1].time - time;
			}
			return result;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00015C7D File Offset: 0x00013E7D
		public override void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
		{
			rot = Quaternion.identity;
			pos = new Vector3(this.AxisValue(this.m_XCurve, timeSinceSignalStart), this.AxisValue(this.m_YCurve, timeSinceSignalStart), this.AxisValue(this.m_ZCurve, timeSinceSignalStart));
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00015CBC File Offset: 0x00013EBC
		private float AxisValue(AnimationCurve axis, float time)
		{
			if (axis == null || axis.length == 0)
			{
				return 0f;
			}
			return axis.Evaluate(time);
		}

		// Token: 0x0400025B RID: 603
		[Tooltip("The raw signal shape along the X axis")]
		public AnimationCurve m_XCurve;

		// Token: 0x0400025C RID: 604
		[Tooltip("The raw signal shape along the Y axis")]
		public AnimationCurve m_YCurve;

		// Token: 0x0400025D RID: 605
		[Tooltip("The raw signal shape along the Z axis")]
		public AnimationCurve m_ZCurve;
	}
}
