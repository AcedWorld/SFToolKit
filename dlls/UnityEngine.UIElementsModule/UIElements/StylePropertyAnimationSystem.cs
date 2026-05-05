using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Assertions;
using UnityEngine.Pool;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x0200032A RID: 810
	internal class StylePropertyAnimationSystem : IStylePropertyAnimationSystem
	{
		// Token: 0x06001B77 RID: 7031 RVA: 0x0006AE2E File Offset: 0x0006902E
		public StylePropertyAnimationSystem()
		{
			this.m_CurrentTimeMs = Panel.TimeSinceStartupMs();
		}

		// Token: 0x06001B78 RID: 7032 RVA: 0x0006AE64 File Offset: 0x00069064
		private T GetOrCreate<T>(ref T values) where T : new()
		{
			T t = values;
			return (t != null) ? t : (values = Activator.CreateInstance<T>());
		}

		// Token: 0x06001B79 RID: 7033 RVA: 0x0006AE98 File Offset: 0x00069098
		private bool StartTransition<T>(VisualElement owner, StylePropertyId prop, T startValue, T endValue, int durationMs, int delayMs, Func<float, float> easingCurve, StylePropertyAnimationSystem.Values<T> values)
		{
			this.m_PropertyToValues[prop] = values;
			bool result = values.StartTransition(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.CurrentTimeMs());
			this.UpdateTracking<T>(values);
			return result;
		}

		// Token: 0x06001B7A RID: 7034 RVA: 0x0006AEDC File Offset: 0x000690DC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, float startValue, float endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<float>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesFloat>(ref this.m_Floats));
		}

		// Token: 0x06001B7B RID: 7035 RVA: 0x0006AF0C File Offset: 0x0006910C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, int startValue, int endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<int>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesInt>(ref this.m_Ints));
		}

		// Token: 0x06001B7C RID: 7036 RVA: 0x0006AF3C File Offset: 0x0006913C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Length startValue, Length endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Length>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesLength>(ref this.m_Lengths));
		}

		// Token: 0x06001B7D RID: 7037 RVA: 0x0006AF6C File Offset: 0x0006916C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Color startValue, Color endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Color>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesColor>(ref this.m_Colors));
		}

		// Token: 0x06001B7E RID: 7038 RVA: 0x0006AF9C File Offset: 0x0006919C
		public bool StartAnimationEnum(VisualElement owner, StylePropertyId prop, int startValue, int endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<int>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesEnum>(ref this.m_Enums));
		}

		// Token: 0x06001B7F RID: 7039 RVA: 0x0006AFCC File Offset: 0x000691CC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Background startValue, Background endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Background>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesBackground>(ref this.m_Backgrounds));
		}

		// Token: 0x06001B80 RID: 7040 RVA: 0x0006AFFC File Offset: 0x000691FC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, FontDefinition startValue, FontDefinition endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<FontDefinition>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesFontDefinition>(ref this.m_FontDefinitions));
		}

		// Token: 0x06001B81 RID: 7041 RVA: 0x0006B02C File Offset: 0x0006922C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Font startValue, Font endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Font>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesFont>(ref this.m_Fonts));
		}

		// Token: 0x06001B82 RID: 7042 RVA: 0x0006B05C File Offset: 0x0006925C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, TextShadow startValue, TextShadow endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<TextShadow>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesTextShadow>(ref this.m_TextShadows));
		}

		// Token: 0x06001B83 RID: 7043 RVA: 0x0006B08C File Offset: 0x0006928C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Scale startValue, Scale endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Scale>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesScale>(ref this.m_Scale));
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x0006B0BC File Offset: 0x000692BC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Rotate startValue, Rotate endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Rotate>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesRotate>(ref this.m_Rotate));
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x0006B0EC File Offset: 0x000692EC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Translate startValue, Translate endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<Translate>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesTranslate>(ref this.m_Translate));
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x0006B11C File Offset: 0x0006931C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, TransformOrigin startValue, TransformOrigin endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<TransformOrigin>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesTransformOrigin>(ref this.m_TransformOrigin));
		}

		// Token: 0x06001B87 RID: 7047 RVA: 0x0006B14C File Offset: 0x0006934C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundPosition startValue, BackgroundPosition endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<BackgroundPosition>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesBackgroundPosition>(ref this.m_BackgroundPosition));
		}

		// Token: 0x06001B88 RID: 7048 RVA: 0x0006B17C File Offset: 0x0006937C
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundRepeat startValue, BackgroundRepeat endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<BackgroundRepeat>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesBackgroundRepeat>(ref this.m_BackgroundRepeat));
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0006B1AC File Offset: 0x000693AC
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundSize startValue, BackgroundSize endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve)
		{
			return this.StartTransition<BackgroundSize>(owner, prop, startValue, endValue, durationMs, delayMs, easingCurve, this.GetOrCreate<StylePropertyAnimationSystem.ValuesBackgroundSize>(ref this.m_BackgroundSize));
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x0006B1DC File Offset: 0x000693DC
		public void CancelAllAnimations()
		{
			foreach (StylePropertyAnimationSystem.Values values in this.m_AllValues)
			{
				values.CancelAllAnimations();
			}
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x0006B234 File Offset: 0x00069434
		public void CancelAllAnimations(VisualElement owner)
		{
			foreach (StylePropertyAnimationSystem.Values values in this.m_AllValues)
			{
				values.CancelAllAnimations(owner);
			}
			Assert.AreEqual(0, owner.styleAnimation.runningAnimationCount);
			Assert.AreEqual(0, owner.styleAnimation.completedAnimationCount);
		}

		// Token: 0x06001B8C RID: 7052 RVA: 0x0006B2B4 File Offset: 0x000694B4
		public void CancelAnimation(VisualElement owner, StylePropertyId id)
		{
			StylePropertyAnimationSystem.Values values;
			bool flag = this.m_PropertyToValues.TryGetValue(id, out values);
			if (flag)
			{
				values.CancelAnimation(owner, id);
			}
		}

		// Token: 0x06001B8D RID: 7053 RVA: 0x0006B2E0 File Offset: 0x000694E0
		public bool HasRunningAnimation(VisualElement owner, StylePropertyId id)
		{
			StylePropertyAnimationSystem.Values values;
			return this.m_PropertyToValues.TryGetValue(id, out values) && values.HasRunningAnimation(owner, id);
		}

		// Token: 0x06001B8E RID: 7054 RVA: 0x0006B310 File Offset: 0x00069510
		public void UpdateAnimation(VisualElement owner, StylePropertyId id)
		{
			StylePropertyAnimationSystem.Values values;
			bool flag = this.m_PropertyToValues.TryGetValue(id, out values);
			if (flag)
			{
				values.UpdateAnimation(owner, id);
			}
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x0006B33C File Offset: 0x0006953C
		public void GetAllAnimations(VisualElement owner, List<StylePropertyId> propertyIds)
		{
			foreach (StylePropertyAnimationSystem.Values values in this.m_AllValues)
			{
				values.GetAllAnimations(owner, propertyIds);
			}
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x0006B394 File Offset: 0x00069594
		private void UpdateTracking<T>(StylePropertyAnimationSystem.Values<T> values)
		{
			bool flag = !values.isEmpty && !this.m_AllValues.Contains(values);
			if (flag)
			{
				this.m_AllValues.Add(values);
			}
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x0006B3D0 File Offset: 0x000695D0
		private long CurrentTimeMs()
		{
			return this.m_CurrentTimeMs;
		}

		// Token: 0x06001B92 RID: 7058 RVA: 0x0006B3E8 File Offset: 0x000695E8
		public void Update()
		{
			this.m_CurrentTimeMs = Panel.TimeSinceStartupMs();
			int count = this.m_AllValues.Count;
			for (int i = 0; i < count; i++)
			{
				this.m_AllValues[i].Update(this.m_CurrentTimeMs);
			}
		}

		// Token: 0x04000B61 RID: 2913
		private long m_CurrentTimeMs = 0L;

		// Token: 0x04000B62 RID: 2914
		private StylePropertyAnimationSystem.ValuesFloat m_Floats;

		// Token: 0x04000B63 RID: 2915
		private StylePropertyAnimationSystem.ValuesInt m_Ints;

		// Token: 0x04000B64 RID: 2916
		private StylePropertyAnimationSystem.ValuesLength m_Lengths;

		// Token: 0x04000B65 RID: 2917
		private StylePropertyAnimationSystem.ValuesColor m_Colors;

		// Token: 0x04000B66 RID: 2918
		private StylePropertyAnimationSystem.ValuesEnum m_Enums;

		// Token: 0x04000B67 RID: 2919
		private StylePropertyAnimationSystem.ValuesBackground m_Backgrounds;

		// Token: 0x04000B68 RID: 2920
		private StylePropertyAnimationSystem.ValuesFontDefinition m_FontDefinitions;

		// Token: 0x04000B69 RID: 2921
		private StylePropertyAnimationSystem.ValuesFont m_Fonts;

		// Token: 0x04000B6A RID: 2922
		private StylePropertyAnimationSystem.ValuesTextShadow m_TextShadows;

		// Token: 0x04000B6B RID: 2923
		private StylePropertyAnimationSystem.ValuesScale m_Scale;

		// Token: 0x04000B6C RID: 2924
		private StylePropertyAnimationSystem.ValuesRotate m_Rotate;

		// Token: 0x04000B6D RID: 2925
		private StylePropertyAnimationSystem.ValuesTranslate m_Translate;

		// Token: 0x04000B6E RID: 2926
		private StylePropertyAnimationSystem.ValuesTransformOrigin m_TransformOrigin;

		// Token: 0x04000B6F RID: 2927
		private StylePropertyAnimationSystem.ValuesBackgroundPosition m_BackgroundPosition;

		// Token: 0x04000B70 RID: 2928
		private StylePropertyAnimationSystem.ValuesBackgroundRepeat m_BackgroundRepeat;

		// Token: 0x04000B71 RID: 2929
		private StylePropertyAnimationSystem.ValuesBackgroundSize m_BackgroundSize;

		// Token: 0x04000B72 RID: 2930
		private readonly List<StylePropertyAnimationSystem.Values> m_AllValues = new List<StylePropertyAnimationSystem.Values>();

		// Token: 0x04000B73 RID: 2931
		private readonly Dictionary<StylePropertyId, StylePropertyAnimationSystem.Values> m_PropertyToValues = new Dictionary<StylePropertyId, StylePropertyAnimationSystem.Values>();

		// Token: 0x0200032B RID: 811
		[Flags]
		private enum TransitionState
		{
			// Token: 0x04000B75 RID: 2933
			None = 0,
			// Token: 0x04000B76 RID: 2934
			Running = 1,
			// Token: 0x04000B77 RID: 2935
			Started = 2,
			// Token: 0x04000B78 RID: 2936
			Ended = 4,
			// Token: 0x04000B79 RID: 2937
			Canceled = 8
		}

		// Token: 0x0200032C RID: 812
		private struct AnimationDataSet<TTimingData, TStyleData>
		{
			// Token: 0x1700068D RID: 1677
			// (get) Token: 0x06001B93 RID: 7059 RVA: 0x0006B437 File Offset: 0x00069637
			// (set) Token: 0x06001B94 RID: 7060 RVA: 0x0006B441 File Offset: 0x00069641
			private int capacity
			{
				get
				{
					return this.elements.Length;
				}
				set
				{
					Array.Resize<VisualElement>(ref this.elements, value);
					Array.Resize<StylePropertyId>(ref this.properties, value);
					Array.Resize<TTimingData>(ref this.timing, value);
					Array.Resize<TStyleData>(ref this.style, value);
				}
			}

			// Token: 0x06001B95 RID: 7061 RVA: 0x0006B478 File Offset: 0x00069678
			private void LocalInit()
			{
				this.elements = new VisualElement[2];
				this.properties = new StylePropertyId[2];
				this.timing = new TTimingData[2];
				this.style = new TStyleData[2];
				this.indices = new Dictionary<StylePropertyAnimationSystem.ElementPropertyPair, int>(StylePropertyAnimationSystem.ElementPropertyPair.Comparer);
			}

			// Token: 0x06001B96 RID: 7062 RVA: 0x0006B4C8 File Offset: 0x000696C8
			public static StylePropertyAnimationSystem.AnimationDataSet<TTimingData, TStyleData> Create()
			{
				StylePropertyAnimationSystem.AnimationDataSet<TTimingData, TStyleData> result = default(StylePropertyAnimationSystem.AnimationDataSet<TTimingData, TStyleData>);
				result.LocalInit();
				return result;
			}

			// Token: 0x06001B97 RID: 7063 RVA: 0x0006B4EC File Offset: 0x000696EC
			public bool IndexOf(VisualElement ve, StylePropertyId prop, out int index)
			{
				return this.indices.TryGetValue(new StylePropertyAnimationSystem.ElementPropertyPair(ve, prop), out index);
			}

			// Token: 0x06001B98 RID: 7064 RVA: 0x0006B514 File Offset: 0x00069714
			public void Add(VisualElement owner, StylePropertyId prop, TTimingData timingData, TStyleData styleData)
			{
				bool flag = this.count >= this.capacity;
				if (flag)
				{
					this.capacity *= 2;
				}
				int num = this.count;
				this.count = num + 1;
				int num2 = num;
				this.elements[num2] = owner;
				this.properties[num2] = prop;
				this.timing[num2] = timingData;
				this.style[num2] = styleData;
				this.indices.Add(new StylePropertyAnimationSystem.ElementPropertyPair(owner, prop), num2);
			}

			// Token: 0x06001B99 RID: 7065 RVA: 0x0006B59C File Offset: 0x0006979C
			public void Remove(int cancelledIndex)
			{
				int num = this.count - 1;
				this.count = num;
				int num2 = num;
				this.indices.Remove(new StylePropertyAnimationSystem.ElementPropertyPair(this.elements[cancelledIndex], this.properties[cancelledIndex]));
				bool flag = cancelledIndex != num2;
				if (flag)
				{
					VisualElement element = this.elements[cancelledIndex] = this.elements[num2];
					StylePropertyId property = this.properties[cancelledIndex] = this.properties[num2];
					this.timing[cancelledIndex] = this.timing[num2];
					this.style[cancelledIndex] = this.style[num2];
					this.indices[new StylePropertyAnimationSystem.ElementPropertyPair(element, property)] = cancelledIndex;
				}
				this.elements[num2] = null;
				this.properties[num2] = StylePropertyId.Unknown;
				this.timing[num2] = default(TTimingData);
				this.style[num2] = default(TStyleData);
			}

			// Token: 0x06001B9A RID: 7066 RVA: 0x0006B69A File Offset: 0x0006989A
			public void Replace(int index, TTimingData timingData, TStyleData styleData)
			{
				this.timing[index] = timingData;
				this.style[index] = styleData;
			}

			// Token: 0x06001B9B RID: 7067 RVA: 0x0006B6B8 File Offset: 0x000698B8
			public void RemoveAll(VisualElement ve)
			{
				int num = this.count;
				for (int i = num - 1; i >= 0; i--)
				{
					bool flag = this.elements[i] == ve;
					if (flag)
					{
						this.Remove(i);
					}
				}
			}

			// Token: 0x06001B9C RID: 7068 RVA: 0x0006B6FC File Offset: 0x000698FC
			public void RemoveAll()
			{
				this.capacity = 2;
				int length = Mathf.Min(this.count, this.capacity);
				Array.Clear(this.elements, 0, length);
				Array.Clear(this.properties, 0, length);
				Array.Clear(this.timing, 0, length);
				Array.Clear(this.style, 0, length);
				this.count = 0;
				this.indices.Clear();
			}

			// Token: 0x06001B9D RID: 7069 RVA: 0x0006B770 File Offset: 0x00069970
			public void GetActivePropertiesForElement(VisualElement ve, List<StylePropertyId> outProperties)
			{
				int num = this.count;
				for (int i = num - 1; i >= 0; i--)
				{
					bool flag = this.elements[i] == ve;
					if (flag)
					{
						outProperties.Add(this.properties[i]);
					}
				}
			}

			// Token: 0x04000B7A RID: 2938
			private const int InitialSize = 2;

			// Token: 0x04000B7B RID: 2939
			public VisualElement[] elements;

			// Token: 0x04000B7C RID: 2940
			public StylePropertyId[] properties;

			// Token: 0x04000B7D RID: 2941
			public TTimingData[] timing;

			// Token: 0x04000B7E RID: 2942
			public TStyleData[] style;

			// Token: 0x04000B7F RID: 2943
			public int count;

			// Token: 0x04000B80 RID: 2944
			private Dictionary<StylePropertyAnimationSystem.ElementPropertyPair, int> indices;
		}

		// Token: 0x0200032D RID: 813
		private struct ElementPropertyPair
		{
			// Token: 0x06001B9E RID: 7070 RVA: 0x0006B7BA File Offset: 0x000699BA
			public ElementPropertyPair(VisualElement element, StylePropertyId property)
			{
				this.element = element;
				this.property = property;
			}

			// Token: 0x04000B81 RID: 2945
			public static readonly IEqualityComparer<StylePropertyAnimationSystem.ElementPropertyPair> Comparer = new StylePropertyAnimationSystem.ElementPropertyPair.EqualityComparer();

			// Token: 0x04000B82 RID: 2946
			public readonly VisualElement element;

			// Token: 0x04000B83 RID: 2947
			public readonly StylePropertyId property;

			// Token: 0x0200032E RID: 814
			private class EqualityComparer : IEqualityComparer<StylePropertyAnimationSystem.ElementPropertyPair>
			{
				// Token: 0x06001BA0 RID: 7072 RVA: 0x0006B7D8 File Offset: 0x000699D8
				public bool Equals(StylePropertyAnimationSystem.ElementPropertyPair x, StylePropertyAnimationSystem.ElementPropertyPair y)
				{
					return x.element == y.element && x.property == y.property;
				}

				// Token: 0x06001BA1 RID: 7073 RVA: 0x0006B80C File Offset: 0x00069A0C
				public int GetHashCode(StylePropertyAnimationSystem.ElementPropertyPair obj)
				{
					return obj.element.GetHashCode() * 397 ^ (int)obj.property;
				}
			}
		}

		// Token: 0x0200032F RID: 815
		private abstract class Values
		{
			// Token: 0x06001BA3 RID: 7075
			public abstract void CancelAllAnimations();

			// Token: 0x06001BA4 RID: 7076
			public abstract void CancelAllAnimations(VisualElement ve);

			// Token: 0x06001BA5 RID: 7077
			public abstract void CancelAnimation(VisualElement ve, StylePropertyId id);

			// Token: 0x06001BA6 RID: 7078
			public abstract bool HasRunningAnimation(VisualElement ve, StylePropertyId id);

			// Token: 0x06001BA7 RID: 7079
			public abstract void UpdateAnimation(VisualElement ve, StylePropertyId id);

			// Token: 0x06001BA8 RID: 7080
			public abstract void GetAllAnimations(VisualElement ve, List<StylePropertyId> outPropertyIds);

			// Token: 0x06001BA9 RID: 7081
			public abstract void Update(long currentTimeMs);

			// Token: 0x06001BAA RID: 7082
			protected abstract void UpdateValues();

			// Token: 0x06001BAB RID: 7083
			protected abstract void UpdateComputedStyle();

			// Token: 0x06001BAC RID: 7084
			protected abstract void UpdateComputedStyle(int i);
		}

		// Token: 0x02000330 RID: 816
		private abstract class Values<T> : StylePropertyAnimationSystem.Values
		{
			// Token: 0x1700068E RID: 1678
			// (get) Token: 0x06001BAE RID: 7086 RVA: 0x0006B837 File Offset: 0x00069A37
			public bool isEmpty
			{
				get
				{
					return this.running.count + this.completed.count == 0;
				}
			}

			// Token: 0x1700068F RID: 1679
			// (get) Token: 0x06001BAF RID: 7087
			public abstract Func<T, T, bool> SameFunc { get; }

			// Token: 0x06001BB0 RID: 7088 RVA: 0x0006B854 File Offset: 0x00069A54
			protected virtual bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref T a, ref T b)
			{
				return true;
			}

			// Token: 0x06001BB1 RID: 7089 RVA: 0x0006B868 File Offset: 0x00069A68
			protected Values()
			{
				this.running = StylePropertyAnimationSystem.AnimationDataSet<StylePropertyAnimationSystem.Values<T>.TimingData, StylePropertyAnimationSystem.Values<T>.StyleData>.Create();
				this.completed = StylePropertyAnimationSystem.AnimationDataSet<StylePropertyAnimationSystem.Values<T>.EmptyData, T>.Create();
				this.m_CurrentTimeMs = Panel.TimeSinceStartupMs();
			}

			// Token: 0x06001BB2 RID: 7090 RVA: 0x0006B8BC File Offset: 0x00069ABC
			private void SwapFrameStates()
			{
				StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState currentFrameEventsState = this.m_CurrentFrameEventsState;
				this.m_CurrentFrameEventsState = this.m_NextFrameEventsState;
				this.m_NextFrameEventsState = currentFrameEventsState;
			}

			// Token: 0x06001BB3 RID: 7091 RVA: 0x0006B8E4 File Offset: 0x00069AE4
			private void QueueEvent(EventBase evt, StylePropertyAnimationSystem.ElementPropertyPair epp)
			{
				evt.target = epp.element;
				Queue<EventBase> pooledQueue;
				bool flag = !this.m_NextFrameEventsState.elementPropertyQueuedEvents.TryGetValue(epp, out pooledQueue);
				if (flag)
				{
					pooledQueue = StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState.GetPooledQueue();
					this.m_NextFrameEventsState.elementPropertyQueuedEvents.Add(epp, pooledQueue);
				}
				pooledQueue.Enqueue(evt);
				bool flag2 = this.m_NextFrameEventsState.panel == null;
				if (flag2)
				{
					this.m_NextFrameEventsState.panel = epp.element.panel;
				}
				this.m_NextFrameEventsState.RegisterChange();
			}

			// Token: 0x06001BB4 RID: 7092 RVA: 0x0006B970 File Offset: 0x00069B70
			private void ClearEventQueue(StylePropertyAnimationSystem.ElementPropertyPair epp)
			{
				Queue<EventBase> queue;
				bool flag = this.m_NextFrameEventsState.elementPropertyQueuedEvents.TryGetValue(epp, out queue);
				if (flag)
				{
					while (queue.Count > 0)
					{
						queue.Dequeue().Dispose();
						this.m_NextFrameEventsState.UnregisterChange();
					}
				}
			}

			// Token: 0x06001BB5 RID: 7093 RVA: 0x0006B9C0 File Offset: 0x00069BC0
			private void QueueTransitionRunEvent(VisualElement ve, int runningIndex)
			{
				bool flag = !ve.HasParentEventCallbacksOrDefaultActions(EventCategory.StyleTransition);
				if (!flag)
				{
					StylePropertyId stylePropertyId = this.running.properties[runningIndex];
					StylePropertyAnimationSystem.ElementPropertyPair elementPropertyPair = new StylePropertyAnimationSystem.ElementPropertyPair(ve, stylePropertyId);
					StylePropertyAnimationSystem.TransitionState transitionState;
					bool flag2 = this.m_NextFrameEventsState.elementPropertyStateDelta.TryGetValue(elementPropertyPair, out transitionState);
					if (flag2)
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta[elementPropertyPair] = (transitionState | StylePropertyAnimationSystem.TransitionState.Running);
					}
					else
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta.Add(elementPropertyPair, StylePropertyAnimationSystem.TransitionState.Running);
					}
					ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[runningIndex];
					int num = (ptr.delayMs < 0) ? Mathf.Min(Mathf.Max(-ptr.delayMs, 0), ptr.durationMs) : 0;
					TransitionRunEvent pooled = TransitionEventBase<TransitionRunEvent>.GetPooled(new StylePropertyName(stylePropertyId), (double)((float)num / 1000f));
					this.QueueEvent(pooled, elementPropertyPair);
				}
			}

			// Token: 0x06001BB6 RID: 7094 RVA: 0x0006BA98 File Offset: 0x00069C98
			private void QueueTransitionStartEvent(VisualElement ve, int runningIndex)
			{
				bool flag = !ve.HasParentEventCallbacksOrDefaultActions(EventCategory.StyleTransition);
				if (!flag)
				{
					StylePropertyId stylePropertyId = this.running.properties[runningIndex];
					StylePropertyAnimationSystem.ElementPropertyPair elementPropertyPair = new StylePropertyAnimationSystem.ElementPropertyPair(ve, stylePropertyId);
					StylePropertyAnimationSystem.TransitionState transitionState;
					bool flag2 = this.m_NextFrameEventsState.elementPropertyStateDelta.TryGetValue(elementPropertyPair, out transitionState);
					if (flag2)
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta[elementPropertyPair] = (transitionState | StylePropertyAnimationSystem.TransitionState.Started);
					}
					else
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta.Add(elementPropertyPair, StylePropertyAnimationSystem.TransitionState.Started);
					}
					ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[runningIndex];
					int num = (ptr.delayMs < 0) ? Mathf.Min(Mathf.Max(-ptr.delayMs, 0), ptr.durationMs) : 0;
					TransitionStartEvent pooled = TransitionEventBase<TransitionStartEvent>.GetPooled(new StylePropertyName(stylePropertyId), (double)((float)num / 1000f));
					this.QueueEvent(pooled, elementPropertyPair);
				}
			}

			// Token: 0x06001BB7 RID: 7095 RVA: 0x0006BB70 File Offset: 0x00069D70
			private void QueueTransitionEndEvent(VisualElement ve, int runningIndex)
			{
				bool flag = !ve.HasParentEventCallbacksOrDefaultActions(EventCategory.StyleTransition);
				if (!flag)
				{
					StylePropertyId stylePropertyId = this.running.properties[runningIndex];
					StylePropertyAnimationSystem.ElementPropertyPair elementPropertyPair = new StylePropertyAnimationSystem.ElementPropertyPair(ve, stylePropertyId);
					StylePropertyAnimationSystem.TransitionState transitionState;
					bool flag2 = this.m_NextFrameEventsState.elementPropertyStateDelta.TryGetValue(elementPropertyPair, out transitionState);
					if (flag2)
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta[elementPropertyPair] = (transitionState | StylePropertyAnimationSystem.TransitionState.Ended);
					}
					else
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta.Add(elementPropertyPair, StylePropertyAnimationSystem.TransitionState.Ended);
					}
					ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[runningIndex];
					TransitionEndEvent pooled = TransitionEventBase<TransitionEndEvent>.GetPooled(new StylePropertyName(stylePropertyId), (double)((float)ptr.durationMs / 1000f));
					this.QueueEvent(pooled, elementPropertyPair);
				}
			}

			// Token: 0x06001BB8 RID: 7096 RVA: 0x0006BC28 File Offset: 0x00069E28
			private void QueueTransitionCancelEvent(VisualElement ve, int runningIndex, long panelElapsedMs)
			{
				bool flag = !ve.HasParentEventCallbacksOrDefaultActions(EventCategory.StyleTransition);
				if (!flag)
				{
					StylePropertyId stylePropertyId = this.running.properties[runningIndex];
					StylePropertyAnimationSystem.ElementPropertyPair elementPropertyPair = new StylePropertyAnimationSystem.ElementPropertyPair(ve, stylePropertyId);
					StylePropertyAnimationSystem.TransitionState transitionState;
					bool flag2 = this.m_NextFrameEventsState.elementPropertyStateDelta.TryGetValue(elementPropertyPair, out transitionState);
					bool flag4;
					if (flag2)
					{
						bool flag3 = transitionState == StylePropertyAnimationSystem.TransitionState.None || (transitionState & StylePropertyAnimationSystem.TransitionState.Canceled) == StylePropertyAnimationSystem.TransitionState.Canceled;
						if (flag3)
						{
							this.m_NextFrameEventsState.elementPropertyStateDelta[elementPropertyPair] = StylePropertyAnimationSystem.TransitionState.Canceled;
							this.ClearEventQueue(elementPropertyPair);
							flag4 = true;
						}
						else
						{
							this.m_NextFrameEventsState.elementPropertyStateDelta[elementPropertyPair] = StylePropertyAnimationSystem.TransitionState.None;
							this.ClearEventQueue(elementPropertyPair);
							flag4 = false;
						}
					}
					else
					{
						this.m_NextFrameEventsState.elementPropertyStateDelta.Add(elementPropertyPair, StylePropertyAnimationSystem.TransitionState.Canceled);
						flag4 = true;
					}
					bool flag5 = !flag4;
					if (!flag5)
					{
						ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[runningIndex];
						long num = ptr.isStarted ? (panelElapsedMs - ptr.startTimeMs) : 0L;
						bool flag6 = ptr.delayMs < 0;
						if (flag6)
						{
							num = (long)(-(long)ptr.delayMs) + num;
						}
						TransitionCancelEvent pooled = TransitionEventBase<TransitionCancelEvent>.GetPooled(new StylePropertyName(stylePropertyId), (double)((float)num / 1000f));
						this.QueueEvent(pooled, elementPropertyPair);
					}
				}
			}

			// Token: 0x06001BB9 RID: 7097 RVA: 0x0006BD64 File Offset: 0x00069F64
			private void SendTransitionCancelEvent(VisualElement ve, int runningIndex, long panelElapsedMs)
			{
				bool flag = !ve.HasParentEventCallbacksOrDefaultActions(EventBase<TransitionCancelEvent>.EventCategory);
				if (!flag)
				{
					ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[runningIndex];
					StylePropertyId stylePropertyId = this.running.properties[runningIndex];
					long num = ptr.isStarted ? (panelElapsedMs - ptr.startTimeMs) : 0L;
					bool flag2 = ptr.delayMs < 0;
					if (flag2)
					{
						num = (long)(-(long)ptr.delayMs) + num;
					}
					using (TransitionCancelEvent pooled = TransitionEventBase<TransitionCancelEvent>.GetPooled(new StylePropertyName(stylePropertyId), (double)((float)num / 1000f)))
					{
						pooled.target = ve;
						ve.SendEvent(pooled);
					}
				}
			}

			// Token: 0x06001BBA RID: 7098 RVA: 0x0006BE24 File Offset: 0x0006A024
			public sealed override void CancelAllAnimations()
			{
				int count = this.running.count;
				bool flag = count > 0;
				if (flag)
				{
					using (new EventDispatcherGate(this.running.elements[0].panel.dispatcher))
					{
						for (int i = 0; i < count; i++)
						{
							VisualElement visualElement = this.running.elements[i];
							this.SendTransitionCancelEvent(visualElement, i, this.m_CurrentTimeMs);
							this.ForceComputedStyleEndValue(i);
							IStylePropertyAnimations styleAnimation = visualElement.styleAnimation;
							int num = styleAnimation.runningAnimationCount;
							styleAnimation.runningAnimationCount = num - 1;
						}
					}
					this.running.RemoveAll();
				}
				int count2 = this.completed.count;
				for (int j = 0; j < count2; j++)
				{
					VisualElement visualElement2 = this.completed.elements[j];
					IStylePropertyAnimations styleAnimation2 = visualElement2.styleAnimation;
					int num = styleAnimation2.completedAnimationCount;
					styleAnimation2.completedAnimationCount = num - 1;
				}
				this.completed.RemoveAll();
			}

			// Token: 0x06001BBB RID: 7099 RVA: 0x0006BF4C File Offset: 0x0006A14C
			public sealed override void CancelAllAnimations(VisualElement ve)
			{
				int count = this.running.count;
				bool flag = count > 0;
				if (flag)
				{
					using (new EventDispatcherGate(this.running.elements[0].panel.dispatcher))
					{
						for (int i = 0; i < count; i++)
						{
							bool flag2 = this.running.elements[i] == ve;
							if (flag2)
							{
								this.SendTransitionCancelEvent(ve, i, this.m_CurrentTimeMs);
								this.ForceComputedStyleEndValue(i);
								IStylePropertyAnimations styleAnimation = this.running.elements[i].styleAnimation;
								int num = styleAnimation.runningAnimationCount;
								styleAnimation.runningAnimationCount = num - 1;
							}
						}
					}
				}
				this.running.RemoveAll(ve);
				int count2 = this.completed.count;
				for (int j = 0; j < count2; j++)
				{
					bool flag3 = this.completed.elements[j] == ve;
					if (flag3)
					{
						IStylePropertyAnimations styleAnimation2 = this.completed.elements[j].styleAnimation;
						int num = styleAnimation2.completedAnimationCount;
						styleAnimation2.completedAnimationCount = num - 1;
					}
				}
				this.completed.RemoveAll(ve);
			}

			// Token: 0x06001BBC RID: 7100 RVA: 0x0006C0A0 File Offset: 0x0006A2A0
			public sealed override void CancelAnimation(VisualElement ve, StylePropertyId id)
			{
				int num;
				bool flag = this.running.IndexOf(ve, id, out num);
				if (flag)
				{
					this.QueueTransitionCancelEvent(ve, num, this.m_CurrentTimeMs);
					this.ForceComputedStyleEndValue(num);
					this.running.Remove(num);
					IStylePropertyAnimations styleAnimation = ve.styleAnimation;
					int num2 = styleAnimation.runningAnimationCount;
					styleAnimation.runningAnimationCount = num2 - 1;
				}
				int cancelledIndex;
				bool flag2 = this.completed.IndexOf(ve, id, out cancelledIndex);
				if (flag2)
				{
					this.completed.Remove(cancelledIndex);
					IStylePropertyAnimations styleAnimation2 = ve.styleAnimation;
					int num2 = styleAnimation2.completedAnimationCount;
					styleAnimation2.completedAnimationCount = num2 - 1;
				}
			}

			// Token: 0x06001BBD RID: 7101 RVA: 0x0006C138 File Offset: 0x0006A338
			public sealed override bool HasRunningAnimation(VisualElement ve, StylePropertyId id)
			{
				int num;
				return this.running.IndexOf(ve, id, out num);
			}

			// Token: 0x06001BBE RID: 7102 RVA: 0x0006C15C File Offset: 0x0006A35C
			public sealed override void UpdateAnimation(VisualElement ve, StylePropertyId id)
			{
				int i;
				bool flag = this.running.IndexOf(ve, id, out i);
				if (flag)
				{
					this.UpdateComputedStyle(i);
				}
			}

			// Token: 0x06001BBF RID: 7103 RVA: 0x0006C185 File Offset: 0x0006A385
			public sealed override void GetAllAnimations(VisualElement ve, List<StylePropertyId> outPropertyIds)
			{
				this.running.GetActivePropertiesForElement(ve, outPropertyIds);
				this.completed.GetActivePropertiesForElement(ve, outPropertyIds);
			}

			// Token: 0x06001BC0 RID: 7104 RVA: 0x0006C1A4 File Offset: 0x0006A3A4
			private float ComputeReversingShorteningFactor(int oldIndex)
			{
				ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[oldIndex];
				return Mathf.Clamp01(Mathf.Abs(1f - (1f - ptr.easedProgress) * ptr.reversingShorteningFactor));
			}

			// Token: 0x06001BC1 RID: 7105 RVA: 0x0006C1EC File Offset: 0x0006A3EC
			private int ComputeReversingDuration(int newTransitionDurationMs, float newReversingShorteningFactor)
			{
				return Mathf.RoundToInt((float)newTransitionDurationMs * newReversingShorteningFactor);
			}

			// Token: 0x06001BC2 RID: 7106 RVA: 0x0006C208 File Offset: 0x0006A408
			private int ComputeReversingDelay(int delayMs, float newReversingShorteningFactor)
			{
				return (delayMs < 0) ? Mathf.RoundToInt((float)delayMs * newReversingShorteningFactor) : delayMs;
			}

			// Token: 0x06001BC3 RID: 7107 RVA: 0x0006C22C File Offset: 0x0006A42C
			public bool StartTransition(VisualElement owner, StylePropertyId prop, T startValue, T endValue, int durationMs, int delayMs, Func<float, float> easingCurve, long currentTimeMs)
			{
				long startTimeMs = currentTimeMs + (long)delayMs;
				StylePropertyAnimationSystem.Values<T>.TimingData timingData = new StylePropertyAnimationSystem.Values<T>.TimingData
				{
					startTimeMs = startTimeMs,
					durationMs = durationMs,
					easingCurve = easingCurve,
					reversingShorteningFactor = 1f,
					delayMs = delayMs
				};
				StylePropertyAnimationSystem.Values<T>.StyleData styleData = new StylePropertyAnimationSystem.Values<T>.StyleData
				{
					startValue = startValue,
					endValue = endValue,
					currentValue = startValue,
					reversingAdjustedStartValue = startValue
				};
				int num = Mathf.Max(0, durationMs) + delayMs;
				bool flag = !this.ConvertUnits(owner, prop, ref styleData.startValue, ref styleData.endValue);
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					int num2;
					bool flag2 = this.completed.IndexOf(owner, prop, out num2);
					if (flag2)
					{
						bool flag3 = this.SameFunc(endValue, this.completed.style[num2]);
						if (flag3)
						{
							return false;
						}
						bool flag4 = num <= 0;
						if (flag4)
						{
							return false;
						}
						this.completed.Remove(num2);
						IStylePropertyAnimations styleAnimation = owner.styleAnimation;
						int num3 = styleAnimation.completedAnimationCount;
						styleAnimation.completedAnimationCount = num3 - 1;
					}
					int num4;
					bool flag5 = this.running.IndexOf(owner, prop, out num4);
					if (flag5)
					{
						bool flag6 = this.SameFunc(endValue, this.running.style[num4].endValue);
						if (flag6)
						{
							result = false;
						}
						else
						{
							bool flag7 = this.SameFunc(endValue, this.running.style[num4].currentValue);
							if (flag7)
							{
								this.QueueTransitionCancelEvent(owner, num4, currentTimeMs);
								this.running.Remove(num4);
								IStylePropertyAnimations styleAnimation2 = owner.styleAnimation;
								int num3 = styleAnimation2.runningAnimationCount;
								styleAnimation2.runningAnimationCount = num3 - 1;
								result = false;
							}
							else
							{
								bool flag8 = num <= 0;
								if (flag8)
								{
									this.QueueTransitionCancelEvent(owner, num4, currentTimeMs);
									this.running.Remove(num4);
									IStylePropertyAnimations styleAnimation3 = owner.styleAnimation;
									int num3 = styleAnimation3.runningAnimationCount;
									styleAnimation3.runningAnimationCount = num3 - 1;
									result = false;
								}
								else
								{
									styleData.startValue = this.running.style[num4].currentValue;
									bool flag9 = !this.ConvertUnits(owner, prop, ref styleData.startValue, ref styleData.endValue);
									if (flag9)
									{
										this.QueueTransitionCancelEvent(owner, num4, currentTimeMs);
										this.running.Remove(num4);
										IStylePropertyAnimations styleAnimation4 = owner.styleAnimation;
										int num3 = styleAnimation4.runningAnimationCount;
										styleAnimation4.runningAnimationCount = num3 - 1;
										result = false;
									}
									else
									{
										styleData.currentValue = styleData.startValue;
										bool flag10 = this.SameFunc(endValue, this.running.style[num4].reversingAdjustedStartValue);
										if (flag10)
										{
											float newReversingShorteningFactor = timingData.reversingShorteningFactor = this.ComputeReversingShorteningFactor(num4);
											timingData.startTimeMs = currentTimeMs + (long)this.ComputeReversingDelay(delayMs, newReversingShorteningFactor);
											timingData.durationMs = this.ComputeReversingDuration(durationMs, newReversingShorteningFactor);
											styleData.reversingAdjustedStartValue = this.running.style[num4].endValue;
										}
										this.running.timing[num4].isStarted = false;
										this.QueueTransitionCancelEvent(owner, num4, currentTimeMs);
										this.QueueTransitionRunEvent(owner, num4);
										this.running.Replace(num4, timingData, styleData);
										result = true;
									}
								}
							}
						}
					}
					else
					{
						bool flag11 = num <= 0;
						if (flag11)
						{
							result = false;
						}
						else
						{
							bool flag12 = this.SameFunc(startValue, endValue);
							if (flag12)
							{
								result = false;
							}
							else
							{
								this.running.Add(owner, prop, timingData, styleData);
								IStylePropertyAnimations styleAnimation5 = owner.styleAnimation;
								int num3 = styleAnimation5.runningAnimationCount;
								styleAnimation5.runningAnimationCount = num3 + 1;
								this.QueueTransitionRunEvent(owner, this.running.count - 1);
								result = true;
							}
						}
					}
				}
				return result;
			}

			// Token: 0x06001BC4 RID: 7108 RVA: 0x0006C614 File Offset: 0x0006A814
			private void ForceComputedStyleEndValue(int runningIndex)
			{
				ref StylePropertyAnimationSystem.Values<T>.StyleData ptr = ref this.running.style[runningIndex];
				ptr.currentValue = ptr.endValue;
				this.UpdateComputedStyle(runningIndex);
			}

			// Token: 0x06001BC5 RID: 7109 RVA: 0x0006C648 File Offset: 0x0006A848
			public sealed override void Update(long currentTimeMs)
			{
				this.m_CurrentTimeMs = currentTimeMs;
				this.UpdateProgress(currentTimeMs);
				this.UpdateValues();
				this.UpdateComputedStyle();
				bool flag = this.m_NextFrameEventsState.StateChanged();
				if (flag)
				{
					this.ProcessEventQueue();
				}
			}

			// Token: 0x06001BC6 RID: 7110 RVA: 0x0006C68C File Offset: 0x0006A88C
			private void ProcessEventQueue()
			{
				this.SwapFrameStates();
				IPanel panel = this.m_CurrentFrameEventsState.panel;
				EventDispatcher d = (panel != null) ? panel.dispatcher : null;
				using (new EventDispatcherGate(d))
				{
					foreach (KeyValuePair<StylePropertyAnimationSystem.ElementPropertyPair, Queue<EventBase>> keyValuePair in this.m_CurrentFrameEventsState.elementPropertyQueuedEvents)
					{
						StylePropertyAnimationSystem.ElementPropertyPair key = keyValuePair.Key;
						Queue<EventBase> value = keyValuePair.Value;
						VisualElement element = keyValuePair.Key.element;
						while (value.Count > 0)
						{
							EventBase eventBase = value.Dequeue();
							element.SendEvent(eventBase);
							eventBase.Dispose();
						}
					}
					this.m_CurrentFrameEventsState.Clear();
				}
			}

			// Token: 0x06001BC7 RID: 7111 RVA: 0x0006C784 File Offset: 0x0006A984
			private void UpdateProgress(long currentTimeMs)
			{
				int num = this.running.count;
				bool flag = num > 0;
				if (flag)
				{
					for (int i = 0; i < num; i++)
					{
						ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[i];
						bool flag2 = currentTimeMs < ptr.startTimeMs;
						if (flag2)
						{
							ptr.easedProgress = 0f;
						}
						else
						{
							bool flag3 = currentTimeMs >= ptr.startTimeMs + (long)ptr.durationMs;
							if (flag3)
							{
								ref StylePropertyAnimationSystem.Values<T>.StyleData ptr2 = ref this.running.style[i];
								ref VisualElement ptr3 = ref this.running.elements[i];
								ptr2.currentValue = ptr2.endValue;
								this.UpdateComputedStyle(i);
								this.completed.Add(ptr3, this.running.properties[i], StylePropertyAnimationSystem.Values<T>.EmptyData.Default, ptr2.endValue);
								IStylePropertyAnimations styleAnimation = ptr3.styleAnimation;
								int num2 = styleAnimation.runningAnimationCount;
								styleAnimation.runningAnimationCount = num2 - 1;
								IStylePropertyAnimations styleAnimation2 = ptr3.styleAnimation;
								num2 = styleAnimation2.completedAnimationCount;
								styleAnimation2.completedAnimationCount = num2 + 1;
								this.QueueTransitionEndEvent(ptr3, i);
								this.running.Remove(i);
								i--;
								num--;
							}
							else
							{
								bool flag4 = !ptr.isStarted;
								if (flag4)
								{
									ptr.isStarted = true;
									this.QueueTransitionStartEvent(this.running.elements[i], i);
								}
								float arg = (float)(currentTimeMs - ptr.startTimeMs) / (float)ptr.durationMs;
								ptr.easedProgress = ptr.easingCurve(arg);
							}
						}
					}
				}
			}

			// Token: 0x04000B84 RID: 2948
			private long m_CurrentTimeMs = 0L;

			// Token: 0x04000B85 RID: 2949
			private StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState m_CurrentFrameEventsState = new StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState();

			// Token: 0x04000B86 RID: 2950
			private StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState m_NextFrameEventsState = new StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState();

			// Token: 0x04000B87 RID: 2951
			public StylePropertyAnimationSystem.AnimationDataSet<StylePropertyAnimationSystem.Values<T>.TimingData, StylePropertyAnimationSystem.Values<T>.StyleData> running;

			// Token: 0x04000B88 RID: 2952
			public StylePropertyAnimationSystem.AnimationDataSet<StylePropertyAnimationSystem.Values<T>.EmptyData, T> completed;

			// Token: 0x02000331 RID: 817
			private class TransitionEventsFrameState
			{
				// Token: 0x06001BC8 RID: 7112 RVA: 0x0006C928 File Offset: 0x0006AB28
				public static Queue<EventBase> GetPooledQueue()
				{
					return StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState.k_EventQueuePool.Get();
				}

				// Token: 0x06001BC9 RID: 7113 RVA: 0x0006C944 File Offset: 0x0006AB44
				public void RegisterChange()
				{
					this.m_ChangesCount++;
				}

				// Token: 0x06001BCA RID: 7114 RVA: 0x0006C955 File Offset: 0x0006AB55
				public void UnregisterChange()
				{
					this.m_ChangesCount--;
				}

				// Token: 0x06001BCB RID: 7115 RVA: 0x0006C968 File Offset: 0x0006AB68
				public bool StateChanged()
				{
					return this.m_ChangesCount > 0;
				}

				// Token: 0x06001BCC RID: 7116 RVA: 0x0006C984 File Offset: 0x0006AB84
				public void Clear()
				{
					foreach (KeyValuePair<StylePropertyAnimationSystem.ElementPropertyPair, Queue<EventBase>> keyValuePair in this.elementPropertyQueuedEvents)
					{
						keyValuePair.Value.Clear();
						StylePropertyAnimationSystem.Values<T>.TransitionEventsFrameState.k_EventQueuePool.Release(keyValuePair.Value);
					}
					this.elementPropertyQueuedEvents.Clear();
					this.elementPropertyStateDelta.Clear();
					this.panel = null;
					this.m_ChangesCount = 0;
				}

				// Token: 0x04000B89 RID: 2953
				private static readonly ObjectPool<Queue<EventBase>> k_EventQueuePool = new ObjectPool<Queue<EventBase>>(() => new Queue<EventBase>(4), null, null, null, true, 10, 10000);

				// Token: 0x04000B8A RID: 2954
				public readonly Dictionary<StylePropertyAnimationSystem.ElementPropertyPair, StylePropertyAnimationSystem.TransitionState> elementPropertyStateDelta = new Dictionary<StylePropertyAnimationSystem.ElementPropertyPair, StylePropertyAnimationSystem.TransitionState>(StylePropertyAnimationSystem.ElementPropertyPair.Comparer);

				// Token: 0x04000B8B RID: 2955
				public readonly Dictionary<StylePropertyAnimationSystem.ElementPropertyPair, Queue<EventBase>> elementPropertyQueuedEvents = new Dictionary<StylePropertyAnimationSystem.ElementPropertyPair, Queue<EventBase>>(StylePropertyAnimationSystem.ElementPropertyPair.Comparer);

				// Token: 0x04000B8C RID: 2956
				public IPanel panel;

				// Token: 0x04000B8D RID: 2957
				private int m_ChangesCount;
			}

			// Token: 0x02000333 RID: 819
			public struct TimingData
			{
				// Token: 0x04000B8F RID: 2959
				public long startTimeMs;

				// Token: 0x04000B90 RID: 2960
				public int durationMs;

				// Token: 0x04000B91 RID: 2961
				public Func<float, float> easingCurve;

				// Token: 0x04000B92 RID: 2962
				public float easedProgress;

				// Token: 0x04000B93 RID: 2963
				public float reversingShorteningFactor;

				// Token: 0x04000B94 RID: 2964
				public bool isStarted;

				// Token: 0x04000B95 RID: 2965
				public int delayMs;
			}

			// Token: 0x02000334 RID: 820
			public struct StyleData
			{
				// Token: 0x04000B96 RID: 2966
				public T startValue;

				// Token: 0x04000B97 RID: 2967
				public T endValue;

				// Token: 0x04000B98 RID: 2968
				public T reversingAdjustedStartValue;

				// Token: 0x04000B99 RID: 2969
				public T currentValue;
			}

			// Token: 0x02000335 RID: 821
			public struct EmptyData
			{
				// Token: 0x04000B9A RID: 2970
				public static StylePropertyAnimationSystem.Values<T>.EmptyData Default = default(StylePropertyAnimationSystem.Values<T>.EmptyData);
			}
		}

		// Token: 0x02000336 RID: 822
		private class ValuesFloat : StylePropertyAnimationSystem.Values<float>
		{
			// Token: 0x17000690 RID: 1680
			// (get) Token: 0x06001BD3 RID: 7123 RVA: 0x0006CA8D File Offset: 0x0006AC8D
			public override Func<float, float, bool> SameFunc { get; } = new Func<float, float, bool>(StylePropertyAnimationSystem.ValuesFloat.IsSame);

			// Token: 0x06001BD4 RID: 7124 RVA: 0x0006CA95 File Offset: 0x0006AC95
			private static bool IsSame(float a, float b)
			{
				return Mathf.Approximately(a, b);
			}

			// Token: 0x06001BD5 RID: 7125 RVA: 0x0006CA9E File Offset: 0x0006AC9E
			private static float Lerp(float a, float b, float t)
			{
				return Mathf.LerpUnclamped(a, b, t);
			}

			// Token: 0x06001BD6 RID: 7126 RVA: 0x0006CAA8 File Offset: 0x0006ACA8
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<float>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<float>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesFloat.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}

			// Token: 0x06001BD7 RID: 7127 RVA: 0x0006CB18 File Offset: 0x0006AD18
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BD8 RID: 7128 RVA: 0x0006CB8C File Offset: 0x0006AD8C
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x02000337 RID: 823
		private class ValuesInt : StylePropertyAnimationSystem.Values<int>
		{
			// Token: 0x17000691 RID: 1681
			// (get) Token: 0x06001BDA RID: 7130 RVA: 0x0006CBFD File Offset: 0x0006ADFD
			public override Func<int, int, bool> SameFunc { get; } = new Func<int, int, bool>(StylePropertyAnimationSystem.ValuesInt.IsSame);

			// Token: 0x06001BDB RID: 7131 RVA: 0x0006CC05 File Offset: 0x0006AE05
			private static bool IsSame(int a, int b)
			{
				return a == b;
			}

			// Token: 0x06001BDC RID: 7132 RVA: 0x0006CC0B File Offset: 0x0006AE0B
			private static int Lerp(int a, int b, float t)
			{
				return Mathf.RoundToInt(Mathf.LerpUnclamped((float)a, (float)b, t));
			}

			// Token: 0x06001BDD RID: 7133 RVA: 0x0006CC1C File Offset: 0x0006AE1C
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<int>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<int>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesInt.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}

			// Token: 0x06001BDE RID: 7134 RVA: 0x0006CC8C File Offset: 0x0006AE8C
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BDF RID: 7135 RVA: 0x0006CD00 File Offset: 0x0006AF00
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x02000338 RID: 824
		private class ValuesLength : StylePropertyAnimationSystem.Values<Length>
		{
			// Token: 0x17000692 RID: 1682
			// (get) Token: 0x06001BE1 RID: 7137 RVA: 0x0006CD71 File Offset: 0x0006AF71
			public override Func<Length, Length, bool> SameFunc { get; } = new Func<Length, Length, bool>(StylePropertyAnimationSystem.ValuesLength.IsSame);

			// Token: 0x06001BE2 RID: 7138 RVA: 0x0006CD79 File Offset: 0x0006AF79
			private static bool IsSame(Length a, Length b)
			{
				return a.unit == b.unit && Mathf.Approximately(a.value, b.value);
			}

			// Token: 0x06001BE3 RID: 7139 RVA: 0x0006CDA4 File Offset: 0x0006AFA4
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref Length a, ref Length b)
			{
				return owner.TryConvertLengthUnits(prop, ref a, ref b, 0);
			}

			// Token: 0x06001BE4 RID: 7140 RVA: 0x0006CDC1 File Offset: 0x0006AFC1
			internal static Length Lerp(Length a, Length b, float t)
			{
				return new Length(Mathf.LerpUnclamped(a.value, b.value, t), b.unit);
			}

			// Token: 0x06001BE5 RID: 7141 RVA: 0x0006CDE4 File Offset: 0x0006AFE4
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<Length>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<Length>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesLength.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}

			// Token: 0x06001BE6 RID: 7142 RVA: 0x0006CE54 File Offset: 0x0006B054
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BE7 RID: 7143 RVA: 0x0006CEC8 File Offset: 0x0006B0C8
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x02000339 RID: 825
		private class ValuesColor : StylePropertyAnimationSystem.Values<Color>
		{
			// Token: 0x17000693 RID: 1683
			// (get) Token: 0x06001BE9 RID: 7145 RVA: 0x0006CF39 File Offset: 0x0006B139
			public override Func<Color, Color, bool> SameFunc { get; } = new Func<Color, Color, bool>(StylePropertyAnimationSystem.ValuesColor.IsSame);

			// Token: 0x06001BEA RID: 7146 RVA: 0x0006CF44 File Offset: 0x0006B144
			private static bool IsSame(Color c, Color d)
			{
				return Mathf.Approximately(c.r, d.r) && Mathf.Approximately(c.g, d.g) && Mathf.Approximately(c.b, d.b) && Mathf.Approximately(c.a, d.a);
			}

			// Token: 0x06001BEB RID: 7147 RVA: 0x0006CF9E File Offset: 0x0006B19E
			private static Color Lerp(Color a, Color b, float t)
			{
				return Color.LerpUnclamped(a, b, t);
			}

			// Token: 0x06001BEC RID: 7148 RVA: 0x0006CFA8 File Offset: 0x0006B1A8
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<Color>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<Color>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesColor.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}

			// Token: 0x06001BED RID: 7149 RVA: 0x0006D018 File Offset: 0x0006B218
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BEE RID: 7150 RVA: 0x0006D08C File Offset: 0x0006B28C
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x0200033A RID: 826
		private abstract class ValuesDiscrete<T> : StylePropertyAnimationSystem.Values<T>
		{
			// Token: 0x17000694 RID: 1684
			// (get) Token: 0x06001BF0 RID: 7152 RVA: 0x0006D0FD File Offset: 0x0006B2FD
			public override Func<T, T, bool> SameFunc { get; } = new Func<T, T, bool>(StylePropertyAnimationSystem.ValuesDiscrete<T>.IsSame);

			// Token: 0x06001BF1 RID: 7153 RVA: 0x0006D105 File Offset: 0x0006B305
			private static bool IsSame(T a, T b)
			{
				return EqualityComparer<T>.Default.Equals(a, b);
			}

			// Token: 0x06001BF2 RID: 7154 RVA: 0x0006D113 File Offset: 0x0006B313
			private static T Lerp(T a, T b, float t)
			{
				return (t < 0.5f) ? a : b;
			}

			// Token: 0x06001BF3 RID: 7155 RVA: 0x0006D124 File Offset: 0x0006B324
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<T>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<T>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesDiscrete<T>.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}
		}

		// Token: 0x0200033B RID: 827
		private class ValuesEnum : StylePropertyAnimationSystem.ValuesDiscrete<int>
		{
			// Token: 0x06001BF5 RID: 7157 RVA: 0x0006D1B0 File Offset: 0x0006B3B0
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BF6 RID: 7158 RVA: 0x0006D224 File Offset: 0x0006B424
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x0200033C RID: 828
		private class ValuesBackground : StylePropertyAnimationSystem.ValuesDiscrete<Background>
		{
			// Token: 0x06001BF8 RID: 7160 RVA: 0x0006D284 File Offset: 0x0006B484
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BF9 RID: 7161 RVA: 0x0006D2F8 File Offset: 0x0006B4F8
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x0200033D RID: 829
		private class ValuesFontDefinition : StylePropertyAnimationSystem.ValuesDiscrete<FontDefinition>
		{
			// Token: 0x06001BFB RID: 7163 RVA: 0x0006D358 File Offset: 0x0006B558
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BFC RID: 7164 RVA: 0x0006D3CC File Offset: 0x0006B5CC
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x0200033E RID: 830
		private class ValuesFont : StylePropertyAnimationSystem.ValuesDiscrete<Font>
		{
			// Token: 0x06001BFE RID: 7166 RVA: 0x0006D42C File Offset: 0x0006B62C
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001BFF RID: 7167 RVA: 0x0006D4A0 File Offset: 0x0006B6A0
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x0200033F RID: 831
		private class ValuesTextShadow : StylePropertyAnimationSystem.Values<TextShadow>
		{
			// Token: 0x17000695 RID: 1685
			// (get) Token: 0x06001C01 RID: 7169 RVA: 0x0006D4FF File Offset: 0x0006B6FF
			public override Func<TextShadow, TextShadow, bool> SameFunc { get; } = new Func<TextShadow, TextShadow, bool>(StylePropertyAnimationSystem.ValuesTextShadow.IsSame);

			// Token: 0x06001C02 RID: 7170 RVA: 0x0006D507 File Offset: 0x0006B707
			private static bool IsSame(TextShadow a, TextShadow b)
			{
				return a == b;
			}

			// Token: 0x06001C03 RID: 7171 RVA: 0x0006D510 File Offset: 0x0006B710
			private static TextShadow Lerp(TextShadow a, TextShadow b, float t)
			{
				return TextShadow.LerpUnclamped(a, b, t);
			}

			// Token: 0x06001C04 RID: 7172 RVA: 0x0006D51C File Offset: 0x0006B71C
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<TextShadow>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<TextShadow>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesTextShadow.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}

			// Token: 0x06001C05 RID: 7173 RVA: 0x0006D58C File Offset: 0x0006B78C
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C06 RID: 7174 RVA: 0x0006D600 File Offset: 0x0006B800
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x02000340 RID: 832
		private class ValuesScale : StylePropertyAnimationSystem.Values<Scale>
		{
			// Token: 0x17000696 RID: 1686
			// (get) Token: 0x06001C08 RID: 7176 RVA: 0x0006D671 File Offset: 0x0006B871
			public override Func<Scale, Scale, bool> SameFunc { get; } = new Func<Scale, Scale, bool>(StylePropertyAnimationSystem.ValuesScale.IsSame);

			// Token: 0x06001C09 RID: 7177 RVA: 0x0006D679 File Offset: 0x0006B879
			private static bool IsSame(Scale a, Scale b)
			{
				return a == b;
			}

			// Token: 0x06001C0A RID: 7178 RVA: 0x0006D684 File Offset: 0x0006B884
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C0B RID: 7179 RVA: 0x0006D6F8 File Offset: 0x0006B8F8
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}

			// Token: 0x06001C0C RID: 7180 RVA: 0x0006D74E File Offset: 0x0006B94E
			private static Scale Lerp(Scale a, Scale b, float t)
			{
				return new Scale(Vector3.LerpUnclamped(a.value, b.value, t));
			}

			// Token: 0x06001C0D RID: 7181 RVA: 0x0006D76C File Offset: 0x0006B96C
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<Scale>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<Scale>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesScale.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}
		}

		// Token: 0x02000341 RID: 833
		private class ValuesRotate : StylePropertyAnimationSystem.Values<Rotate>
		{
			// Token: 0x17000697 RID: 1687
			// (get) Token: 0x06001C0F RID: 7183 RVA: 0x0006D7F6 File Offset: 0x0006B9F6
			public override Func<Rotate, Rotate, bool> SameFunc { get; } = new Func<Rotate, Rotate, bool>(StylePropertyAnimationSystem.ValuesRotate.IsSame);

			// Token: 0x06001C10 RID: 7184 RVA: 0x0006D7FE File Offset: 0x0006B9FE
			private static bool IsSame(Rotate a, Rotate b)
			{
				return a == b;
			}

			// Token: 0x06001C11 RID: 7185 RVA: 0x0006D808 File Offset: 0x0006BA08
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C12 RID: 7186 RVA: 0x0006D87C File Offset: 0x0006BA7C
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}

			// Token: 0x06001C13 RID: 7187 RVA: 0x0006D8D4 File Offset: 0x0006BAD4
			private static Rotate Lerp(Rotate a, Rotate b, float t)
			{
				return new Rotate(Mathf.LerpUnclamped(a.angle.ToDegrees(), b.angle.ToDegrees(), t));
			}

			// Token: 0x06001C14 RID: 7188 RVA: 0x0006D910 File Offset: 0x0006BB10
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<Rotate>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<Rotate>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesRotate.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}
		}

		// Token: 0x02000342 RID: 834
		private class ValuesTranslate : StylePropertyAnimationSystem.Values<Translate>
		{
			// Token: 0x17000698 RID: 1688
			// (get) Token: 0x06001C16 RID: 7190 RVA: 0x0006D99A File Offset: 0x0006BB9A
			public override Func<Translate, Translate, bool> SameFunc { get; } = new Func<Translate, Translate, bool>(StylePropertyAnimationSystem.ValuesTranslate.IsSame);

			// Token: 0x06001C17 RID: 7191 RVA: 0x0006D9A2 File Offset: 0x0006BBA2
			private static bool IsSame(Translate a, Translate b)
			{
				return a == b;
			}

			// Token: 0x06001C18 RID: 7192 RVA: 0x0006D9AC File Offset: 0x0006BBAC
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref Translate a, ref Translate b)
			{
				return owner.TryConvertTranslateUnits(ref a, ref b);
			}

			// Token: 0x06001C19 RID: 7193 RVA: 0x0006D9C8 File Offset: 0x0006BBC8
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C1A RID: 7194 RVA: 0x0006DA3C File Offset: 0x0006BC3C
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}

			// Token: 0x06001C1B RID: 7195 RVA: 0x0006DA94 File Offset: 0x0006BC94
			private static Translate Lerp(Translate a, Translate b, float t)
			{
				return new Translate(StylePropertyAnimationSystem.ValuesLength.Lerp(a.x, b.x, t), StylePropertyAnimationSystem.ValuesLength.Lerp(a.y, b.y, t), Mathf.Lerp(a.z, b.z, t));
			}

			// Token: 0x06001C1C RID: 7196 RVA: 0x0006DAE4 File Offset: 0x0006BCE4
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<Translate>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<Translate>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesTranslate.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}
		}

		// Token: 0x02000343 RID: 835
		private class ValuesTransformOrigin : StylePropertyAnimationSystem.Values<TransformOrigin>
		{
			// Token: 0x17000699 RID: 1689
			// (get) Token: 0x06001C1E RID: 7198 RVA: 0x0006DB6E File Offset: 0x0006BD6E
			public override Func<TransformOrigin, TransformOrigin, bool> SameFunc { get; } = new Func<TransformOrigin, TransformOrigin, bool>(StylePropertyAnimationSystem.ValuesTransformOrigin.IsSame);

			// Token: 0x06001C1F RID: 7199 RVA: 0x0006DB76 File Offset: 0x0006BD76
			private static bool IsSame(TransformOrigin a, TransformOrigin b)
			{
				return a == b;
			}

			// Token: 0x06001C20 RID: 7200 RVA: 0x0006DB80 File Offset: 0x0006BD80
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref TransformOrigin a, ref TransformOrigin b)
			{
				return owner.TryConvertTransformOriginUnits(ref a, ref b);
			}

			// Token: 0x06001C21 RID: 7201 RVA: 0x0006DB9C File Offset: 0x0006BD9C
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C22 RID: 7202 RVA: 0x0006DC10 File Offset: 0x0006BE10
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}

			// Token: 0x06001C23 RID: 7203 RVA: 0x0006DC68 File Offset: 0x0006BE68
			private static TransformOrigin Lerp(TransformOrigin a, TransformOrigin b, float t)
			{
				return new TransformOrigin(StylePropertyAnimationSystem.ValuesLength.Lerp(a.x, b.x, t), StylePropertyAnimationSystem.ValuesLength.Lerp(a.y, b.y, t), Mathf.Lerp(a.z, b.z, t));
			}

			// Token: 0x06001C24 RID: 7204 RVA: 0x0006DCB8 File Offset: 0x0006BEB8
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<TransformOrigin>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<TransformOrigin>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesTransformOrigin.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}
		}

		// Token: 0x02000344 RID: 836
		private class ValuesBackgroundPosition : StylePropertyAnimationSystem.ValuesDiscrete<BackgroundPosition>
		{
			// Token: 0x06001C26 RID: 7206 RVA: 0x0006DD44 File Offset: 0x0006BF44
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C27 RID: 7207 RVA: 0x0006DDB8 File Offset: 0x0006BFB8
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x02000345 RID: 837
		private class ValuesBackgroundRepeat : StylePropertyAnimationSystem.ValuesDiscrete<BackgroundRepeat>
		{
			// Token: 0x06001C29 RID: 7209 RVA: 0x0006DE18 File Offset: 0x0006C018
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C2A RID: 7210 RVA: 0x0006DE8C File Offset: 0x0006C08C
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}
		}

		// Token: 0x02000346 RID: 838
		private class ValuesBackgroundSize : StylePropertyAnimationSystem.Values<BackgroundSize>
		{
			// Token: 0x1700069A RID: 1690
			// (get) Token: 0x06001C2C RID: 7212 RVA: 0x0006DEEB File Offset: 0x0006C0EB
			public override Func<BackgroundSize, BackgroundSize, bool> SameFunc { get; } = new Func<BackgroundSize, BackgroundSize, bool>(StylePropertyAnimationSystem.ValuesBackgroundSize.IsSame);

			// Token: 0x06001C2D RID: 7213 RVA: 0x0006DEF3 File Offset: 0x0006C0F3
			private static bool IsSame(BackgroundSize a, BackgroundSize b)
			{
				return a == b;
			}

			// Token: 0x06001C2E RID: 7214 RVA: 0x0006DEFC File Offset: 0x0006C0FC
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref BackgroundSize a, ref BackgroundSize b)
			{
				return owner.TryConvertBackgroundSizeUnits(ref a, ref b);
			}

			// Token: 0x06001C2F RID: 7215 RVA: 0x0006DF18 File Offset: 0x0006C118
			protected sealed override void UpdateComputedStyle()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
				}
			}

			// Token: 0x06001C30 RID: 7216 RVA: 0x0006DF8C File Offset: 0x0006C18C
			protected sealed override void UpdateComputedStyle(int i)
			{
				this.running.elements[i].computedStyle.ApplyPropertyAnimation(this.running.elements[i], this.running.properties[i], this.running.style[i].currentValue);
			}

			// Token: 0x06001C31 RID: 7217 RVA: 0x0006DFE2 File Offset: 0x0006C1E2
			private static BackgroundSize Lerp(BackgroundSize a, BackgroundSize b, float t)
			{
				return new BackgroundSize(StylePropertyAnimationSystem.ValuesLength.Lerp(a.x, b.x, t), StylePropertyAnimationSystem.ValuesLength.Lerp(a.y, b.y, t));
			}

			// Token: 0x06001C32 RID: 7218 RVA: 0x0006E014 File Offset: 0x0006C214
			protected sealed override void UpdateValues()
			{
				int count = this.running.count;
				for (int i = 0; i < count; i++)
				{
					ref StylePropertyAnimationSystem.Values<BackgroundSize>.TimingData ptr = ref this.running.timing[i];
					ref StylePropertyAnimationSystem.Values<BackgroundSize>.StyleData ptr2 = ref this.running.style[i];
					ptr2.currentValue = StylePropertyAnimationSystem.ValuesBackgroundSize.Lerp(ptr2.startValue, ptr2.endValue, ptr.easedProgress);
				}
			}
		}
	}
}
