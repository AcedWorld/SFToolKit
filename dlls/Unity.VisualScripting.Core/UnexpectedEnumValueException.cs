using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200005D RID: 93
	public class UnexpectedEnumValueException<T> : Exception
	{
		// Token: 0x06000293 RID: 659 RVA: 0x00006694 File Offset: 0x00004894
		public UnexpectedEnumValueException(T value)
		{
			string[] array = new string[5];
			array[0] = "Value ";
			int num = 1;
			T t = value;
			array[num] = ((t != null) ? t.ToString() : null);
			array[2] = " of enum ";
			array[3] = typeof(T).Name;
			array[4] = " is unexpected.";
			base..ctor(string.Concat(array));
			this.Value = value;
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00006700 File Offset: 0x00004900
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00006708 File Offset: 0x00004908
		public T Value { get; private set; }
	}
}
