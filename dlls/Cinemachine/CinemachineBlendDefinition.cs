using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x0200002F RID: 47
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[Serializable]
	public struct CinemachineBlendDefinition
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0001142B File Offset: 0x0000F62B
		public float BlendTime
		{
			get
			{
				if (this.m_Style != CinemachineBlendDefinition.Style.Cut)
				{
					return this.m_Time;
				}
				return 0f;
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00011441 File Offset: 0x0000F641
		public CinemachineBlendDefinition(CinemachineBlendDefinition.Style style, float time)
		{
			this.m_Style = style;
			this.m_Time = time;
			this.m_CustomCurve = null;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00011458 File Offset: 0x0000F658
		private void CreateStandardCurves()
		{
			CinemachineBlendDefinition.sStandardCurves = new AnimationCurve[7];
			CinemachineBlendDefinition.sStandardCurves[0] = null;
			CinemachineBlendDefinition.sStandardCurves[1] = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
			CinemachineBlendDefinition.sStandardCurves[2] = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			Keyframe[] keys = CinemachineBlendDefinition.sStandardCurves[2].keys;
			keys[0].outTangent = 1.4f;
			keys[1].inTangent = 0f;
			CinemachineBlendDefinition.sStandardCurves[2].keys = keys;
			CinemachineBlendDefinition.sStandardCurves[3] = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			keys = CinemachineBlendDefinition.sStandardCurves[3].keys;
			keys[0].outTangent = 0f;
			keys[1].inTangent = 1.4f;
			CinemachineBlendDefinition.sStandardCurves[3].keys = keys;
			CinemachineBlendDefinition.sStandardCurves[4] = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			keys = CinemachineBlendDefinition.sStandardCurves[4].keys;
			keys[0].outTangent = 0f;
			keys[1].inTangent = 3f;
			CinemachineBlendDefinition.sStandardCurves[4].keys = keys;
			CinemachineBlendDefinition.sStandardCurves[5] = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			keys = CinemachineBlendDefinition.sStandardCurves[5].keys;
			keys[0].outTangent = 3f;
			keys[1].inTangent = 0f;
			CinemachineBlendDefinition.sStandardCurves[5].keys = keys;
			CinemachineBlendDefinition.sStandardCurves[6] = AnimationCurve.Linear(0f, 0f, 1f, 1f);
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00011628 File Offset: 0x0000F828
		public AnimationCurve BlendCurve
		{
			get
			{
				if (this.m_Style == CinemachineBlendDefinition.Style.Custom)
				{
					if (this.m_CustomCurve == null)
					{
						this.m_CustomCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
					}
					return this.m_CustomCurve;
				}
				if (CinemachineBlendDefinition.sStandardCurves == null)
				{
					this.CreateStandardCurves();
				}
				return CinemachineBlendDefinition.sStandardCurves[(int)this.m_Style];
			}
		}

		// Token: 0x040001B7 RID: 439
		[Tooltip("Shape of the blend curve")]
		public CinemachineBlendDefinition.Style m_Style;

		// Token: 0x040001B8 RID: 440
		[Tooltip("Duration of the blend, in seconds")]
		public float m_Time;

		// Token: 0x040001B9 RID: 441
		public AnimationCurve m_CustomCurve;

		// Token: 0x040001BA RID: 442
		private static AnimationCurve[] sStandardCurves;

		// Token: 0x020000A5 RID: 165
		[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
		public enum Style
		{
			// Token: 0x04000367 RID: 871
			Cut,
			// Token: 0x04000368 RID: 872
			EaseInOut,
			// Token: 0x04000369 RID: 873
			EaseIn,
			// Token: 0x0400036A RID: 874
			EaseOut,
			// Token: 0x0400036B RID: 875
			HardIn,
			// Token: 0x0400036C RID: 876
			HardOut,
			// Token: 0x0400036D RID: 877
			Linear,
			// Token: 0x0400036E RID: 878
			Custom
		}
	}
}
