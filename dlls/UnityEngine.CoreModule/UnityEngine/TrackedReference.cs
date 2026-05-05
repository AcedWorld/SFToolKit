using System;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000263 RID: 611
	[UsedByNativeCode]
	[StructLayout(LayoutKind.Sequential)]
	public class TrackedReference
	{
		// Token: 0x0600199D RID: 6557 RVA: 0x00009E2F File Offset: 0x0000802F
		protected TrackedReference()
		{
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x0002B104 File Offset: 0x00029304
		public static bool operator ==(TrackedReference x, TrackedReference y)
		{
			bool flag = y == null && x == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = y == null;
				if (flag2)
				{
					result = (x.m_Ptr == IntPtr.Zero);
				}
				else
				{
					bool flag3 = x == null;
					if (flag3)
					{
						result = (y.m_Ptr == IntPtr.Zero);
					}
					else
					{
						result = (x.m_Ptr == y.m_Ptr);
					}
				}
			}
			return result;
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x0002B178 File Offset: 0x00029378
		public static bool operator !=(TrackedReference x, TrackedReference y)
		{
			return !(x == y);
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x0002B194 File Offset: 0x00029394
		public override bool Equals(object o)
		{
			return o as TrackedReference == this;
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x0002B1B4 File Offset: 0x000293B4
		public override int GetHashCode()
		{
			return (int)this.m_Ptr;
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x0002B1D4 File Offset: 0x000293D4
		public static implicit operator bool(TrackedReference exists)
		{
			return exists != null;
		}

		// Token: 0x040008E6 RID: 2278
		internal IntPtr m_Ptr;
	}
}
