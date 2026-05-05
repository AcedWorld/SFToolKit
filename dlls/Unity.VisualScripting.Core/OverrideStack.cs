using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200015E RID: 350
	public class OverrideStack<T>
	{
		// Token: 0x06000941 RID: 2369 RVA: 0x0002823C File Offset: 0x0002643C
		public OverrideStack(T defaultValue)
		{
			this._value = defaultValue;
			this.getValue = (() => this._value);
			this.setValue = delegate(T value)
			{
				this._value = value;
			};
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0002827C File Offset: 0x0002647C
		public OverrideStack(Func<T> getValue, Action<T> setValue)
		{
			Ensure.That("getValue").IsNotNull<Func<T>>(getValue);
			Ensure.That("setValue").IsNotNull<Action<T>>(setValue);
			this.getValue = getValue;
			this.setValue = setValue;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x000282C8 File Offset: 0x000264C8
		public OverrideStack(Func<T> getValue, Action<T> setValue, Action clearValue) : this(getValue, setValue)
		{
			Ensure.That("clearValue").IsNotNull<Action>(clearValue);
			this.clearValue = clearValue;
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x000282E9 File Offset: 0x000264E9
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x000282F6 File Offset: 0x000264F6
		public T value
		{
			get
			{
				return this.getValue();
			}
			internal set
			{
				this.setValue(value);
			}
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00028304 File Offset: 0x00026504
		public OverrideLayer<T> Override(T item)
		{
			return new OverrideLayer<T>(this, item);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0002830D File Offset: 0x0002650D
		public void BeginOverride(T item)
		{
			this.previous.Push(this.value);
			this.value = item;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00028328 File Offset: 0x00026528
		public void EndOverride()
		{
			if (this.previous.Count == 0)
			{
				throw new InvalidOperationException();
			}
			this.value = this.previous.Pop();
			if (this.previous.Count == 0)
			{
				Action action = this.clearValue;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00028376 File Offset: 0x00026576
		public static implicit operator T(OverrideStack<T> stack)
		{
			Ensure.That("stack").IsNotNull<OverrideStack<T>>(stack);
			return stack.value;
		}

		// Token: 0x04000231 RID: 561
		private readonly Func<T> getValue;

		// Token: 0x04000232 RID: 562
		private readonly Action<T> setValue;

		// Token: 0x04000233 RID: 563
		private readonly Action clearValue;

		// Token: 0x04000234 RID: 564
		private T _value;

		// Token: 0x04000235 RID: 565
		private readonly Stack<T> previous = new Stack<T>();
	}
}
