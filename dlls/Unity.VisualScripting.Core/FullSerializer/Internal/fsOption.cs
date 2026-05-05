using System;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001AE RID: 430
	public struct fsOption<T>
	{
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x00030CA8 File Offset: 0x0002EEA8
		public bool HasValue
		{
			get
			{
				return this._hasValue;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x00030CB0 File Offset: 0x0002EEB0
		public bool IsEmpty
		{
			get
			{
				return !this._hasValue;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000B78 RID: 2936 RVA: 0x00030CBB File Offset: 0x0002EEBB
		public T Value
		{
			get
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("fsOption is empty");
				}
				return this._value;
			}
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x00030CD6 File Offset: 0x0002EED6
		public fsOption(T value)
		{
			this._hasValue = true;
			this._value = value;
		}

		// Token: 0x040002C6 RID: 710
		private bool _hasValue;

		// Token: 0x040002C7 RID: 711
		private T _value;

		// Token: 0x040002C8 RID: 712
		public static fsOption<T> Empty;
	}
}
