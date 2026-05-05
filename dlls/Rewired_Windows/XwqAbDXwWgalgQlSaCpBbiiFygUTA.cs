using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Token: 0x020000F7 RID: 247
internal class XwqAbDXwWgalgQlSaCpBbiiFygUTA
{
	// Token: 0x060008B5 RID: 2229 RVA: 0x000161F3 File Offset: 0x000143F3
	public XwqAbDXwWgalgQlSaCpBbiiFygUTA(int A_1)
	{
		this.rypdlDEPEVIMtOWJHfCiOXloEVxfA = Marshal.AllocHGlobal(IntPtr.Size * A_1);
		this.SWKBNJqbOuNHixueTciMTEmfBMpr = new List<Delegate>();
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00016218 File Offset: 0x00014418
	public IntPtr KINwfFyTjWgLxskjLkyJaObqDGkd
	{
		get
		{
			return this.rypdlDEPEVIMtOWJHfCiOXloEVxfA;
		}
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x0003A3C0 File Offset: 0x000385C0
	public unsafe void kHsPlBRsUTFRmZwwwHOFsZEJLaIT(Delegate A_1)
	{
		int count = this.SWKBNJqbOuNHixueTciMTEmfBMpr.Count;
		this.SWKBNJqbOuNHixueTciMTEmfBMpr.Add(A_1);
		*(IntPtr*)((byte*)((void*)this.rypdlDEPEVIMtOWJHfCiOXloEVxfA) + (IntPtr)count * (IntPtr)sizeof(IntPtr)) = Marshal.GetFunctionPointerForDelegate(A_1);
	}

	// Token: 0x0400085F RID: 2143
	private readonly List<Delegate> SWKBNJqbOuNHixueTciMTEmfBMpr;

	// Token: 0x04000860 RID: 2144
	private readonly IntPtr rypdlDEPEVIMtOWJHfCiOXloEVxfA;
}
