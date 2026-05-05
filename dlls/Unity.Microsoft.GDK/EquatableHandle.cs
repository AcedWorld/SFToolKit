using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000004 RID: 4
	public abstract class EquatableHandle : SafeHandle
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000021A0 File Offset: 0x000003A0
		public EquatableHandle(IntPtr invalidHandleValue, bool ownsHandle, IntPtr handle) : base(invalidHandleValue, ownsHandle)
		{
			base.SetHandle(handle);
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021B1 File Offset: 0x000003B1
		public IntPtr Handle
		{
			get
			{
				return this.handle;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021BC File Offset: 0x000003BC
		public override bool Equals(object obj)
		{
			if (obj is EquatableHandle)
			{
				EquatableHandle equatableHandle = (EquatableHandle)obj;
				return this.handle == equatableHandle.handle;
			}
			return false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021EB File Offset: 0x000003EB
		public override int GetHashCode()
		{
			return this.handle.GetHashCode();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021F8 File Offset: 0x000003F8
		public static bool operator ==(EquatableHandle handle1, EquatableHandle handle2)
		{
			if (handle1 != null)
			{
				return handle1.Equals(handle2);
			}
			return handle2 == null;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002209 File Offset: 0x00000409
		public static bool operator !=(EquatableHandle handle1, EquatableHandle handle2)
		{
			return !(handle1 == handle2);
		}
	}
}
