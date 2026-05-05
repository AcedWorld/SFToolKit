using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002CB RID: 715
	public struct CustomStyleProperty<T> : IEquatable<CustomStyleProperty<T>>
	{
		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x00054BBB File Offset: 0x00052DBB
		// (set) Token: 0x0600154F RID: 5455 RVA: 0x00054BC3 File Offset: 0x00052DC3
		public string name { readonly get; private set; }

		// Token: 0x06001550 RID: 5456 RVA: 0x00054BCC File Offset: 0x00052DCC
		public CustomStyleProperty(string propertyName)
		{
			bool flag = !string.IsNullOrEmpty(propertyName) && !propertyName.StartsWith("--");
			if (flag)
			{
				throw new ArgumentException("Custom style property \"" + propertyName + "\" must start with \"--\" prefix.");
			}
			this.name = propertyName;
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x00054C18 File Offset: 0x00052E18
		public override bool Equals(object obj)
		{
			bool flag = !(obj is CustomStyleProperty<T>);
			return !flag && this.Equals((CustomStyleProperty<T>)obj);
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x00054C4C File Offset: 0x00052E4C
		public bool Equals(CustomStyleProperty<T> other)
		{
			return this.name == other.name;
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x00054C70 File Offset: 0x00052E70
		public override int GetHashCode()
		{
			return this.name.GetHashCode();
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x00054C90 File Offset: 0x00052E90
		public static bool operator ==(CustomStyleProperty<T> a, CustomStyleProperty<T> b)
		{
			return a.Equals(b);
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x00054CAC File Offset: 0x00052EAC
		public static bool operator !=(CustomStyleProperty<T> a, CustomStyleProperty<T> b)
		{
			return !(a == b);
		}
	}
}
