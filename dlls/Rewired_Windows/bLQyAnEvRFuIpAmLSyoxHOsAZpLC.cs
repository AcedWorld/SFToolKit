using System;
using System.Runtime.InteropServices;

// Token: 0x02000231 RID: 561
internal class bLQyAnEvRFuIpAmLSyoxHOsAZpLC
{
	// Token: 0x06000E22 RID: 3618 RVA: 0x000114A8 File Offset: 0x0000F6A8
	protected bLQyAnEvRFuIpAmLSyoxHOsAZpLC()
	{
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x0001943D File Offset: 0x0001763D
	internal bLQyAnEvRFuIpAmLSyoxHOsAZpLC(int A_1, IntPtr A_2)
	{
		this.WfCHkluuOPTRWiCbZzlzraEcfupCA(A_1, A_2);
	}

	// Token: 0x06000E24 RID: 3620 RVA: 0x00042E28 File Offset: 0x00041028
	private unsafe void WfCHkluuOPTRWiCbZzlzraEcfupCA(int A_1, IntPtr A_2)
	{
		this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA = A_1;
		if (this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA > 0 && A_2 != IntPtr.Zero)
		{
			this.CwohSqVdNhxdBiGBOdPKypiKFzugA = new byte[A_1];
			byte[] array;
			byte* value;
			if ((array = this.CwohSqVdNhxdBiGBOdPKypiKFzugA) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = &array[0];
			}
			HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb((IntPtr)((void*)value), A_2, this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA);
			array = null;
		}
	}

	// Token: 0x06000E25 RID: 3621 RVA: 0x0001944D File Offset: 0x0001764D
	protected virtual bLQyAnEvRFuIpAmLSyoxHOsAZpLC MZRdCyCdkOpHGLYknEyFswnpqtZjA(int A_1, IntPtr A_2)
	{
		this.WfCHkluuOPTRWiCbZzlzraEcfupCA(A_1, A_2);
		return this;
	}

	// Token: 0x06000E26 RID: 3622 RVA: 0x00019458 File Offset: 0x00017658
	internal virtual void nqfBNDUedFKbLQbUwlpZWZmwGurI(IntPtr A_1)
	{
		if (A_1 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(A_1);
		}
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x00042E90 File Offset: 0x00041090
	internal unsafe virtual IntPtr MPzxLoWtKmodQybONYincWSzueSn()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA > 0 && this.CwohSqVdNhxdBiGBOdPKypiKFzugA != null)
		{
			intPtr = Marshal.AllocHGlobal(this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA);
			byte[] array;
			byte* value;
			if ((array = this.CwohSqVdNhxdBiGBOdPKypiKFzugA) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = &array[0];
			}
			HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb(intPtr, (IntPtr)((void*)value), this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA);
			array = null;
		}
		return intPtr;
	}

	// Token: 0x06000E28 RID: 3624 RVA: 0x00042EF4 File Offset: 0x000410F4
	public unsafe \u0001 MhaXVmvRQxyHuoEBkNmZCcIIjiVk<\u0001>() where \u0001 : bLQyAnEvRFuIpAmLSyoxHOsAZpLC, new()
	{
		if (base.GetType() == typeof(\u0001))
		{
			return (\u0001)((object)this);
		}
		if (base.GetType() == typeof(bLQyAnEvRFuIpAmLSyoxHOsAZpLC))
		{
			byte[] cwohSqVdNhxdBiGBOdPKypiKFzugA;
			void* value;
			if ((cwohSqVdNhxdBiGBOdPKypiKFzugA = this.CwohSqVdNhxdBiGBOdPKypiKFzugA) == null || cwohSqVdNhxdBiGBOdPKypiKFzugA.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&cwohSqVdNhxdBiGBOdPKypiKFzugA[0]);
			}
			return (\u0001)((object)Activator.CreateInstance<\u0001>().MZRdCyCdkOpHGLYknEyFswnpqtZjA(this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA, (IntPtr)value));
		}
		return default(\u0001);
	}

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000E29 RID: 3625 RVA: 0x0001946D File Offset: 0x0001766D
	public virtual int DzXDrmbBRWtCQfDISINwkdhMporx
	{
		get
		{
			return this.PMiTnUQoWrVKjfEyshUfrlUgbnqfA;
		}
	}

	// Token: 0x040028F6 RID: 10486
	private int PMiTnUQoWrVKjfEyshUfrlUgbnqfA;

	// Token: 0x040028F7 RID: 10487
	private byte[] CwohSqVdNhxdBiGBOdPKypiKFzugA;
}
