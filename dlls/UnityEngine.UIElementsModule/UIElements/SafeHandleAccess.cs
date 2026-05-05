using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002A1 RID: 673
	internal struct SafeHandleAccess
	{
		// Token: 0x06001342 RID: 4930 RVA: 0x0004334E File Offset: 0x0004154E
		public SafeHandleAccess(IntPtr ptr)
		{
			this.m_Handle = ptr;
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x00043358 File Offset: 0x00041558
		public bool IsNull()
		{
			return this.m_Handle == IntPtr.Zero;
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x0004337C File Offset: 0x0004157C
		public static implicit operator IntPtr(SafeHandleAccess a)
		{
			bool flag = a.m_Handle == IntPtr.Zero;
			if (flag)
			{
				throw new ArgumentNullException();
			}
			return a.m_Handle;
		}

		// Token: 0x040008B9 RID: 2233
		private IntPtr m_Handle;
	}
}
