using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000D3 RID: 211
	public struct LooseAssemblyName
	{
		// Token: 0x0600052F RID: 1327 RVA: 0x0000C6B8 File Offset: 0x0000A8B8
		public LooseAssemblyName(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.name = name;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0000C6CF File Offset: 0x0000A8CF
		public override bool Equals(object obj)
		{
			return obj is LooseAssemblyName && ((LooseAssemblyName)obj).name == this.name;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0000C6F1 File Offset: 0x0000A8F1
		public override int GetHashCode()
		{
			return HashUtility.GetHashCode<string>(this.name);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0000C6FE File Offset: 0x0000A8FE
		public static bool operator ==(LooseAssemblyName a, LooseAssemblyName b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0000C713 File Offset: 0x0000A913
		public static bool operator !=(LooseAssemblyName a, LooseAssemblyName b)
		{
			return !(a == b);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0000C71F File Offset: 0x0000A91F
		public static implicit operator LooseAssemblyName(string name)
		{
			return new LooseAssemblyName(name);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0000C727 File Offset: 0x0000A927
		public static implicit operator string(LooseAssemblyName name)
		{
			return name.name;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000C72F File Offset: 0x0000A92F
		public static explicit operator LooseAssemblyName(AssemblyName strongAssemblyName)
		{
			return new LooseAssemblyName(strongAssemblyName.Name);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0000C73C File Offset: 0x0000A93C
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x04000128 RID: 296
		public readonly string name;
	}
}
