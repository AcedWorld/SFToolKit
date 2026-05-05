using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x02000347 RID: 839
	internal class EmptyStylePropertyAnimationSystem : IStylePropertyAnimationSystem
	{
		// Token: 0x06001C34 RID: 7220 RVA: 0x0006E0A0 File Offset: 0x0006C2A0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, float startValue, float endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x0006E0B4 File Offset: 0x0006C2B4
		public bool StartTransition(VisualElement owner, StylePropertyId prop, int startValue, int endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x0006E0C8 File Offset: 0x0006C2C8
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Length startValue, Length endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x0006E0DC File Offset: 0x0006C2DC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Color startValue, Color endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x0006E0F0 File Offset: 0x0006C2F0
		public bool StartAnimationEnum(VisualElement owner, StylePropertyId prop, int startValue, int endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x0006E104 File Offset: 0x0006C304
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Background startValue, Background endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x0006E118 File Offset: 0x0006C318
		public bool StartTransition(VisualElement owner, StylePropertyId prop, FontDefinition startValue, FontDefinition endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x0006E12C File Offset: 0x0006C32C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Font startValue, Font endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x0006E140 File Offset: 0x0006C340
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Cursor startValue, Cursor endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x0006E154 File Offset: 0x0006C354
		public bool StartTransition(VisualElement owner, StylePropertyId prop, TextShadow startValue, TextShadow endValue, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x0006E168 File Offset: 0x0006C368
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Scale startValue, Scale endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x0006E17C File Offset: 0x0006C37C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, TransformOrigin startValue, TransformOrigin endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x0006E190 File Offset: 0x0006C390
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Translate startValue, Translate endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x0006E1A4 File Offset: 0x0006C3A4
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Rotate startValue, Rotate endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C42 RID: 7234 RVA: 0x0006E1B8 File Offset: 0x0006C3B8
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundPosition startValue, BackgroundPosition endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x0006E1CC File Offset: 0x0006C3CC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundRepeat startValue, BackgroundRepeat endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x0006E1E0 File Offset: 0x0006C3E0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundSize startValue, BackgroundSize endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return false;
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void CancelAllAnimations()
		{
		}

		// Token: 0x06001C46 RID: 7238 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void CancelAllAnimations(VisualElement owner)
		{
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void CancelAnimation(VisualElement owner, StylePropertyId id)
		{
		}

		// Token: 0x06001C48 RID: 7240 RVA: 0x0006E1F4 File Offset: 0x0006C3F4
		public bool HasRunningAnimation(VisualElement owner, StylePropertyId id)
		{
			return false;
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void UpdateAnimation(VisualElement owner, StylePropertyId id)
		{
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void GetAllAnimations(VisualElement owner, List<StylePropertyId> propertyIds)
		{
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void Update()
		{
		}
	}
}
