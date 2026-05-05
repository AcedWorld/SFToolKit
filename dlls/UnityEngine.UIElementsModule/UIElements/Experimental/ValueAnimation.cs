using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004C2 RID: 1218
	public sealed class ValueAnimation<T> : IValueAnimationUpdate, IValueAnimation
	{
		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x060025F9 RID: 9721 RVA: 0x0009F1BC File Offset: 0x0009D3BC
		// (set) Token: 0x060025FA RID: 9722 RVA: 0x0009F1D4 File Offset: 0x0009D3D4
		public int durationMs
		{
			get
			{
				return this.m_DurationMs;
			}
			set
			{
				bool flag = value < 1;
				if (flag)
				{
					value = 1;
				}
				this.m_DurationMs = value;
			}
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x060025FB RID: 9723 RVA: 0x0009F1F6 File Offset: 0x0009D3F6
		// (set) Token: 0x060025FC RID: 9724 RVA: 0x0009F1FE File Offset: 0x0009D3FE
		public Func<float, float> easingCurve { get; set; }

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x060025FD RID: 9725 RVA: 0x0009F207 File Offset: 0x0009D407
		// (set) Token: 0x060025FE RID: 9726 RVA: 0x0009F20F File Offset: 0x0009D40F
		public bool isRunning { get; private set; }

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x060025FF RID: 9727 RVA: 0x0009F218 File Offset: 0x0009D418
		// (set) Token: 0x06002600 RID: 9728 RVA: 0x0009F220 File Offset: 0x0009D420
		public Action onAnimationCompleted { get; set; }

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x06002601 RID: 9729 RVA: 0x0009F229 File Offset: 0x0009D429
		// (set) Token: 0x06002602 RID: 9730 RVA: 0x0009F231 File Offset: 0x0009D431
		public bool autoRecycle { get; set; }

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x06002603 RID: 9731 RVA: 0x0009F23A File Offset: 0x0009D43A
		// (set) Token: 0x06002604 RID: 9732 RVA: 0x0009F242 File Offset: 0x0009D442
		private bool recycled { get; set; }

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x06002605 RID: 9733 RVA: 0x0009F24B File Offset: 0x0009D44B
		// (set) Token: 0x06002606 RID: 9734 RVA: 0x0009F253 File Offset: 0x0009D453
		private VisualElement owner { get; set; }

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x06002607 RID: 9735 RVA: 0x0009F25C File Offset: 0x0009D45C
		// (set) Token: 0x06002608 RID: 9736 RVA: 0x0009F264 File Offset: 0x0009D464
		public Action<VisualElement, T> valueUpdated { get; set; }

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x06002609 RID: 9737 RVA: 0x0009F26D File Offset: 0x0009D46D
		// (set) Token: 0x0600260A RID: 9738 RVA: 0x0009F275 File Offset: 0x0009D475
		public Func<VisualElement, T> initialValue { get; set; }

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x0600260B RID: 9739 RVA: 0x0009F27E File Offset: 0x0009D47E
		// (set) Token: 0x0600260C RID: 9740 RVA: 0x0009F286 File Offset: 0x0009D486
		public Func<T, T, float, T> interpolator { get; set; }

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x0600260D RID: 9741 RVA: 0x0009F290 File Offset: 0x0009D490
		// (set) Token: 0x0600260E RID: 9742 RVA: 0x0009F2DE File Offset: 0x0009D4DE
		public T from
		{
			get
			{
				bool flag = !this.fromValueSet;
				if (flag)
				{
					bool flag2 = this.initialValue != null;
					if (flag2)
					{
						this.from = this.initialValue(this.owner);
					}
				}
				return this._from;
			}
			set
			{
				this.fromValueSet = true;
				this._from = value;
			}
		}

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x0600260F RID: 9743 RVA: 0x0009F2EF File Offset: 0x0009D4EF
		// (set) Token: 0x06002610 RID: 9744 RVA: 0x0009F2F7 File Offset: 0x0009D4F7
		public T to { get; set; }

		// Token: 0x06002611 RID: 9745 RVA: 0x0009F300 File Offset: 0x0009D500
		public ValueAnimation()
		{
			this.SetDefaultValues();
		}

		// Token: 0x06002612 RID: 9746 RVA: 0x0009F318 File Offset: 0x0009D518
		public void Start()
		{
			this.CheckNotRecycled();
			bool flag = this.owner != null;
			if (flag)
			{
				this.m_StartTimeMs = Panel.TimeSinceStartupMs();
				this.Register();
				this.isRunning = true;
			}
		}

		// Token: 0x06002613 RID: 9747 RVA: 0x0009F358 File Offset: 0x0009D558
		public void Stop()
		{
			this.CheckNotRecycled();
			bool isRunning = this.isRunning;
			if (isRunning)
			{
				this.Unregister();
				this.isRunning = false;
				Action onAnimationCompleted = this.onAnimationCompleted;
				if (onAnimationCompleted != null)
				{
					onAnimationCompleted();
				}
				bool autoRecycle = this.autoRecycle;
				if (autoRecycle)
				{
					bool flag = !this.recycled;
					if (flag)
					{
						this.Recycle();
					}
				}
			}
		}

		// Token: 0x06002614 RID: 9748 RVA: 0x0009F3BC File Offset: 0x0009D5BC
		public void Recycle()
		{
			this.CheckNotRecycled();
			bool isRunning = this.isRunning;
			if (isRunning)
			{
				bool flag = !this.autoRecycle;
				if (!flag)
				{
					this.Stop();
					return;
				}
				this.Stop();
			}
			this.SetDefaultValues();
			this.recycled = true;
			ValueAnimation<T>.sObjectPool.Release(this);
		}

		// Token: 0x06002615 RID: 9749 RVA: 0x0009F41C File Offset: 0x0009D61C
		void IValueAnimationUpdate.Tick(long currentTimeMs)
		{
			this.CheckNotRecycled();
			long num = currentTimeMs - this.m_StartTimeMs;
			float num2 = (float)num / (float)this.durationMs;
			bool flag = false;
			bool flag2 = num2 >= 1f;
			if (flag2)
			{
				num2 = 1f;
				flag = true;
			}
			Func<float, float> easingCurve = this.easingCurve;
			num2 = ((easingCurve != null) ? easingCurve(num2) : num2);
			bool flag3 = this.interpolator != null;
			if (flag3)
			{
				T arg = this.interpolator(this.from, this.to, num2);
				Action<VisualElement, T> valueUpdated = this.valueUpdated;
				if (valueUpdated != null)
				{
					valueUpdated(this.owner, arg);
				}
			}
			bool flag4 = flag;
			if (flag4)
			{
				this.Stop();
			}
		}

		// Token: 0x06002616 RID: 9750 RVA: 0x0009F4CC File Offset: 0x0009D6CC
		private void SetDefaultValues()
		{
			this.m_DurationMs = 400;
			this.autoRecycle = true;
			this.owner = null;
			this.m_StartTimeMs = 0L;
			this.onAnimationCompleted = null;
			this.valueUpdated = null;
			this.initialValue = null;
			this.interpolator = null;
			this.to = default(T);
			this.from = default(T);
			this.fromValueSet = false;
			this.easingCurve = new Func<float, float>(Easing.OutQuad);
		}

		// Token: 0x06002617 RID: 9751 RVA: 0x0009F558 File Offset: 0x0009D758
		private void Unregister()
		{
			bool flag = this.owner != null;
			if (flag)
			{
				this.owner.UnregisterAnimation(this);
			}
		}

		// Token: 0x06002618 RID: 9752 RVA: 0x0009F584 File Offset: 0x0009D784
		private void Register()
		{
			bool flag = this.owner != null;
			if (flag)
			{
				this.owner.RegisterAnimation(this);
			}
		}

		// Token: 0x06002619 RID: 9753 RVA: 0x0009F5B0 File Offset: 0x0009D7B0
		internal void SetOwner(VisualElement e)
		{
			bool isRunning = this.isRunning;
			if (isRunning)
			{
				this.Unregister();
			}
			this.owner = e;
			bool isRunning2 = this.isRunning;
			if (isRunning2)
			{
				this.Register();
			}
		}

		// Token: 0x0600261A RID: 9754 RVA: 0x0009F5EC File Offset: 0x0009D7EC
		private void CheckNotRecycled()
		{
			bool recycled = this.recycled;
			if (recycled)
			{
				throw new InvalidOperationException("Animation object has been recycled. Use KeepAlive() to keep a reference to an animation after it has been stopped.");
			}
		}

		// Token: 0x0600261B RID: 9755 RVA: 0x0009F610 File Offset: 0x0009D810
		public static ValueAnimation<T> Create(VisualElement e, Func<T, T, float, T> interpolator)
		{
			ValueAnimation<T> valueAnimation = ValueAnimation<T>.sObjectPool.Get();
			valueAnimation.recycled = false;
			valueAnimation.SetOwner(e);
			valueAnimation.interpolator = interpolator;
			return valueAnimation;
		}

		// Token: 0x0600261C RID: 9756 RVA: 0x0009F648 File Offset: 0x0009D848
		public ValueAnimation<T> Ease(Func<float, float> easing)
		{
			this.easingCurve = easing;
			return this;
		}

		// Token: 0x0600261D RID: 9757 RVA: 0x0009F664 File Offset: 0x0009D864
		public ValueAnimation<T> OnCompleted(Action callback)
		{
			this.onAnimationCompleted = callback;
			return this;
		}

		// Token: 0x0600261E RID: 9758 RVA: 0x0009F680 File Offset: 0x0009D880
		public ValueAnimation<T> KeepAlive()
		{
			this.autoRecycle = false;
			return this;
		}

		// Token: 0x0400123C RID: 4668
		private const int k_DefaultDurationMs = 400;

		// Token: 0x0400123D RID: 4669
		private const int k_DefaultMaxPoolSize = 100;

		// Token: 0x0400123E RID: 4670
		private long m_StartTimeMs;

		// Token: 0x0400123F RID: 4671
		private int m_DurationMs;

		// Token: 0x04001245 RID: 4677
		private static ObjectPool<ValueAnimation<T>> sObjectPool = new ObjectPool<ValueAnimation<T>>(() => new ValueAnimation<T>(), 100);

		// Token: 0x0400124A RID: 4682
		private T _from;

		// Token: 0x0400124B RID: 4683
		private bool fromValueSet = false;
	}
}
