using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000238 RID: 568
	[EventCategory(EventCategory.StyleTransition)]
	public abstract class TransitionEventBase<T> : EventBase<T>, ITransitionEvent where T : TransitionEventBase<T>, new()
	{
		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06001045 RID: 4165 RVA: 0x0003B4A7 File Offset: 0x000396A7
		public StylePropertyNameCollection stylePropertyNames { get; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06001046 RID: 4166 RVA: 0x0003B4AF File Offset: 0x000396AF
		// (set) Token: 0x06001047 RID: 4167 RVA: 0x0003B4B7 File Offset: 0x000396B7
		public double elapsedTime { get; protected set; }

		// Token: 0x06001048 RID: 4168 RVA: 0x0003B4C0 File Offset: 0x000396C0
		protected TransitionEventBase()
		{
			this.stylePropertyNames = new StylePropertyNameCollection(new List<StylePropertyName>());
			this.LocalInit();
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0003B4E1 File Offset: 0x000396E1
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x0003B4F2 File Offset: 0x000396F2
		private void LocalInit()
		{
			base.propagation = EventBase.EventPropagation.Bubbles;
			base.propagateToIMGUI = false;
			this.stylePropertyNames.propertiesList.Clear();
			this.elapsedTime = 0.0;
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x0003B528 File Offset: 0x00039728
		public static T GetPooled(StylePropertyName stylePropertyName, double elapsedTime)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.stylePropertyNames.propertiesList.Add(stylePropertyName);
			pooled.elapsedTime = elapsedTime;
			return pooled;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x0003B568 File Offset: 0x00039768
		public bool AffectsProperty(StylePropertyName stylePropertyName)
		{
			return this.stylePropertyNames.Contains(stylePropertyName);
		}
	}
}
