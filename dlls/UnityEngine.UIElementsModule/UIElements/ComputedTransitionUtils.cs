using System;
using System.Collections.Generic;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x020002C9 RID: 713
	internal static class ComputedTransitionUtils
	{
		// Token: 0x06001528 RID: 5416 RVA: 0x00054124 File Offset: 0x00052324
		internal static void UpdateComputedTransitions(ref ComputedStyle computedStyle)
		{
			bool flag = computedStyle.computedTransitions == null;
			if (flag)
			{
				computedStyle.computedTransitions = ComputedTransitionUtils.GetOrComputeTransitionPropertyData(ref computedStyle);
			}
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x00054150 File Offset: 0x00052350
		internal static bool HasTransitionProperty(this ComputedStyle computedStyle, StylePropertyId id)
		{
			for (int i = computedStyle.computedTransitions.Length - 1; i >= 0; i--)
			{
				ComputedTransitionProperty computedTransitionProperty = computedStyle.computedTransitions[i];
				bool flag = computedTransitionProperty.id == id || StylePropertyUtil.IsMatchingShorthand(computedTransitionProperty.id, id);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x000541B0 File Offset: 0x000523B0
		internal static bool GetTransitionProperty(this ComputedStyle computedStyle, StylePropertyId id, out ComputedTransitionProperty result)
		{
			for (int i = computedStyle.computedTransitions.Length - 1; i >= 0; i--)
			{
				ComputedTransitionProperty computedTransitionProperty = computedStyle.computedTransitions[i];
				bool flag = computedTransitionProperty.id == id || StylePropertyUtil.IsMatchingShorthand(computedTransitionProperty.id, id);
				if (flag)
				{
					result = computedTransitionProperty;
					return true;
				}
			}
			result = default(ComputedTransitionProperty);
			return false;
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x00054220 File Offset: 0x00052420
		private static ComputedTransitionProperty[] GetOrComputeTransitionPropertyData(ref ComputedStyle computedStyle)
		{
			int transitionHashCode = ComputedTransitionUtils.GetTransitionHashCode(ref computedStyle);
			ComputedTransitionProperty[] array;
			bool flag = !StyleCache.TryGetValue(transitionHashCode, out array);
			if (flag)
			{
				ComputedTransitionUtils.ComputeTransitionPropertyData(ref computedStyle, ComputedTransitionUtils.s_ComputedTransitionsBuffer);
				array = new ComputedTransitionProperty[ComputedTransitionUtils.s_ComputedTransitionsBuffer.Count];
				ComputedTransitionUtils.s_ComputedTransitionsBuffer.CopyTo(array);
				ComputedTransitionUtils.s_ComputedTransitionsBuffer.Clear();
				StyleCache.SetValue(transitionHashCode, array);
			}
			return array;
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x00054288 File Offset: 0x00052488
		private static int GetTransitionHashCode(ref ComputedStyle cs)
		{
			int num = 0;
			foreach (TimeValue timeValue in cs.transitionDelay)
			{
				num = (num * 397 ^ timeValue.GetHashCode());
			}
			foreach (TimeValue timeValue2 in cs.transitionDuration)
			{
				num = (num * 397 ^ timeValue2.GetHashCode());
			}
			foreach (StylePropertyName stylePropertyName in cs.transitionProperty)
			{
				num = (num * 397 ^ stylePropertyName.GetHashCode());
			}
			foreach (EasingFunction easingFunction in cs.transitionTimingFunction)
			{
				num = (num * 397 ^ easingFunction.GetHashCode());
			}
			return num;
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x000543F8 File Offset: 0x000525F8
		internal static bool SameTransitionProperty(ref ComputedStyle x, ref ComputedStyle y)
		{
			bool flag = x.computedTransitions == y.computedTransitions && x.computedTransitions != null;
			return flag || (ComputedTransitionUtils.SameTransitionProperty(x.transitionProperty, y.transitionProperty) && ComputedTransitionUtils.SameTransitionProperty(x.transitionDuration, y.transitionDuration) && ComputedTransitionUtils.SameTransitionProperty(x.transitionDelay, y.transitionDelay));
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x00054468 File Offset: 0x00052668
		private static bool SameTransitionProperty(List<StylePropertyName> a, List<StylePropertyName> b)
		{
			bool flag = a == b;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = a == null || b == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = a.Count != b.Count;
					if (flag3)
					{
						result = false;
					}
					else
					{
						int count = a.Count;
						for (int i = 0; i < count; i++)
						{
							bool flag4 = a[i] != b[i];
							if (flag4)
							{
								return false;
							}
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x000544F0 File Offset: 0x000526F0
		private static bool SameTransitionProperty(List<TimeValue> a, List<TimeValue> b)
		{
			bool flag = a == b;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = a == null || b == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = a.Count != b.Count;
					if (flag3)
					{
						result = false;
					}
					else
					{
						int count = a.Count;
						for (int i = 0; i < count; i++)
						{
							bool flag4 = a[i] != b[i];
							if (flag4)
							{
								return false;
							}
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x00054578 File Offset: 0x00052778
		private static void ComputeTransitionPropertyData(ref ComputedStyle computedStyle, List<ComputedTransitionProperty> outData)
		{
			List<StylePropertyName> transitionProperty = computedStyle.transitionProperty;
			bool flag = transitionProperty == null || transitionProperty.Count == 0;
			if (!flag)
			{
				List<TimeValue> transitionDuration = computedStyle.transitionDuration;
				List<TimeValue> transitionDelay = computedStyle.transitionDelay;
				List<EasingFunction> transitionTimingFunction = computedStyle.transitionTimingFunction;
				int count = transitionProperty.Count;
				for (int i = 0; i < count; i++)
				{
					StylePropertyId id = transitionProperty[i].id;
					bool flag2 = id == StylePropertyId.Unknown || !StylePropertyUtil.IsAnimatable(id);
					if (!flag2)
					{
						int num = ComputedTransitionUtils.ConvertTransitionTime(ComputedTransitionUtils.GetWrappingTransitionData<TimeValue>(transitionDuration, i, new TimeValue(0f)));
						int num2 = ComputedTransitionUtils.ConvertTransitionTime(ComputedTransitionUtils.GetWrappingTransitionData<TimeValue>(transitionDelay, i, new TimeValue(0f)));
						float num3 = (float)(Mathf.Max(0, num) + num2);
						bool flag3 = num3 <= 0f;
						if (!flag3)
						{
							EasingFunction wrappingTransitionData = ComputedTransitionUtils.GetWrappingTransitionData<EasingFunction>(transitionTimingFunction, i, EasingMode.Ease);
							outData.Add(new ComputedTransitionProperty
							{
								id = id,
								durationMs = num,
								delayMs = num2,
								easingCurve = ComputedTransitionUtils.ConvertTransitionFunction(wrappingTransitionData.mode)
							});
						}
					}
				}
			}
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x000546B8 File Offset: 0x000528B8
		private static T GetWrappingTransitionData<T>(List<T> list, int i, T defaultValue)
		{
			return (list.Count == 0) ? defaultValue : list[i % list.Count];
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x000546E4 File Offset: 0x000528E4
		private static int ConvertTransitionTime(TimeValue time)
		{
			return Mathf.RoundToInt((time.unit == TimeUnit.Millisecond) ? time.value : (time.value * 1000f));
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0005471C File Offset: 0x0005291C
		private static Func<float, float> ConvertTransitionFunction(EasingMode mode)
		{
			Func<float, float> result;
			switch (mode)
			{
			default:
				result = ((float t) => t * (1.8f + t * (-0.6f + t * -0.2f)));
				break;
			case EasingMode.EaseIn:
				result = ((float t) => Easing.InQuad(t));
				break;
			case EasingMode.EaseOut:
				result = ((float t) => Easing.OutQuad(t));
				break;
			case EasingMode.EaseInOut:
				result = ((float t) => Easing.InOutQuad(t));
				break;
			case EasingMode.Linear:
				result = ((float t) => Easing.Linear(t));
				break;
			case EasingMode.EaseInSine:
				result = ((float t) => Easing.InSine(t));
				break;
			case EasingMode.EaseOutSine:
				result = ((float t) => Easing.OutSine(t));
				break;
			case EasingMode.EaseInOutSine:
				result = ((float t) => Easing.InOutSine(t));
				break;
			case EasingMode.EaseInCubic:
				result = ((float t) => Easing.InCubic(t));
				break;
			case EasingMode.EaseOutCubic:
				result = ((float t) => Easing.OutCubic(t));
				break;
			case EasingMode.EaseInOutCubic:
				result = ((float t) => Easing.InOutCubic(t));
				break;
			case EasingMode.EaseInCirc:
				result = ((float t) => Easing.InCirc(t));
				break;
			case EasingMode.EaseOutCirc:
				result = ((float t) => Easing.OutCirc(t));
				break;
			case EasingMode.EaseInOutCirc:
				result = ((float t) => Easing.InOutCirc(t));
				break;
			case EasingMode.EaseInElastic:
				result = ((float t) => Easing.InElastic(t));
				break;
			case EasingMode.EaseOutElastic:
				result = ((float t) => Easing.OutElastic(t));
				break;
			case EasingMode.EaseInOutElastic:
				result = ((float t) => Easing.InOutElastic(t));
				break;
			case EasingMode.EaseInBack:
				result = ((float t) => Easing.InBack(t));
				break;
			case EasingMode.EaseOutBack:
				result = ((float t) => Easing.OutBack(t));
				break;
			case EasingMode.EaseInOutBack:
				result = ((float t) => Easing.InOutBack(t));
				break;
			case EasingMode.EaseInBounce:
				result = ((float t) => Easing.InBounce(t));
				break;
			case EasingMode.EaseOutBounce:
				result = ((float t) => Easing.OutBounce(t));
				break;
			case EasingMode.EaseInOutBounce:
				result = ((float t) => Easing.InOutBounce(t));
				break;
			}
			return result;
		}

		// Token: 0x0400099F RID: 2463
		private static List<ComputedTransitionProperty> s_ComputedTransitionsBuffer = new List<ComputedTransitionProperty>();
	}
}
