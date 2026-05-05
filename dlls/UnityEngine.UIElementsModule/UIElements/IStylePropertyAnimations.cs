using System;
using System.Collections.Generic;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x02000328 RID: 808
	internal interface IStylePropertyAnimations
	{
		// Token: 0x06001B47 RID: 6983
		bool Start(StylePropertyId id, float from, float to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B48 RID: 6984
		bool Start(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B49 RID: 6985
		bool Start(StylePropertyId id, Length from, Length to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B4A RID: 6986
		bool Start(StylePropertyId id, Color from, Color to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B4B RID: 6987
		bool StartEnum(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B4C RID: 6988
		bool Start(StylePropertyId id, Background from, Background to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B4D RID: 6989
		bool Start(StylePropertyId id, FontDefinition from, FontDefinition to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B4E RID: 6990
		bool Start(StylePropertyId id, Font from, Font to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B4F RID: 6991
		bool Start(StylePropertyId id, TextShadow from, TextShadow to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B50 RID: 6992
		bool Start(StylePropertyId id, Scale from, Scale to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B51 RID: 6993
		bool Start(StylePropertyId id, Translate from, Translate to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B52 RID: 6994
		bool Start(StylePropertyId id, Rotate from, Rotate to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B53 RID: 6995
		bool Start(StylePropertyId id, TransformOrigin from, TransformOrigin to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B54 RID: 6996
		bool Start(StylePropertyId id, BackgroundPosition from, BackgroundPosition to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B55 RID: 6997
		bool Start(StylePropertyId id, BackgroundRepeat from, BackgroundRepeat to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B56 RID: 6998
		bool Start(StylePropertyId id, BackgroundSize from, BackgroundSize to, int durationMs, int delayMs, Func<float, float> easingCurve);

		// Token: 0x06001B57 RID: 6999
		bool HasRunningAnimation(StylePropertyId id);

		// Token: 0x06001B58 RID: 7000
		void UpdateAnimation(StylePropertyId id);

		// Token: 0x06001B59 RID: 7001
		void GetAllAnimations(List<StylePropertyId> outPropertyIds);

		// Token: 0x06001B5A RID: 7002
		void CancelAnimation(StylePropertyId id);

		// Token: 0x06001B5B RID: 7003
		void CancelAllAnimations();

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06001B5C RID: 7004
		// (set) Token: 0x06001B5D RID: 7005
		int runningAnimationCount { get; set; }

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001B5E RID: 7006
		// (set) Token: 0x06001B5F RID: 7007
		int completedAnimationCount { get; set; }
	}
}
