using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200021A RID: 538
	[UsedByNativeCode]
	public struct PropertyName : IEquatable<PropertyName>
	{
		// Token: 0x060017B4 RID: 6068 RVA: 0x00027736 File Offset: 0x00025936
		public PropertyName(string name)
		{
			this = new PropertyName(PropertyNameUtils.PropertyNameFromString(name));
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x00027746 File Offset: 0x00025946
		public PropertyName(PropertyName other)
		{
			this.id = other.id;
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x00027755 File Offset: 0x00025955
		public PropertyName(int id)
		{
			this.id = id;
		}

		// Token: 0x060017B7 RID: 6071 RVA: 0x00027760 File Offset: 0x00025960
		public static bool IsNullOrEmpty(PropertyName prop)
		{
			return prop.id == 0;
		}

		// Token: 0x060017B8 RID: 6072 RVA: 0x0002777C File Offset: 0x0002597C
		public static bool operator ==(PropertyName lhs, PropertyName rhs)
		{
			return lhs.id == rhs.id;
		}

		// Token: 0x060017B9 RID: 6073 RVA: 0x0002779C File Offset: 0x0002599C
		public static bool operator !=(PropertyName lhs, PropertyName rhs)
		{
			return lhs.id != rhs.id;
		}

		// Token: 0x060017BA RID: 6074 RVA: 0x000277C0 File Offset: 0x000259C0
		public override int GetHashCode()
		{
			return this.id;
		}

		// Token: 0x060017BB RID: 6075 RVA: 0x000277D8 File Offset: 0x000259D8
		public override bool Equals(object other)
		{
			return other is PropertyName && this.Equals((PropertyName)other);
		}

		// Token: 0x060017BC RID: 6076 RVA: 0x00027804 File Offset: 0x00025A04
		public bool Equals(PropertyName other)
		{
			return this == other;
		}

		// Token: 0x060017BD RID: 6077 RVA: 0x00027824 File Offset: 0x00025A24
		public static implicit operator PropertyName(string name)
		{
			return new PropertyName(name);
		}

		// Token: 0x060017BE RID: 6078 RVA: 0x0002783C File Offset: 0x00025A3C
		public static implicit operator PropertyName(int id)
		{
			return new PropertyName(id);
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x00027854 File Offset: 0x00025A54
		public override string ToString()
		{
			return string.Format("Unknown:{0}", this.id);
		}

		// Token: 0x0400087C RID: 2172
		internal int id;
	}
}
