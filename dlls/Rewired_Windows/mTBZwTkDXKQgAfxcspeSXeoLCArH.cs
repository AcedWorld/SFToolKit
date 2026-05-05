using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x020000F6 RID: 246
internal abstract class mTBZwTkDXKQgAfxcspeSXeoLCArH : HNFrkskWHnOofcjttKUrdSdtExHq
{
	// Token: 0x17000199 RID: 409
	// (get) Token: 0x060008AE RID: 2222 RVA: 0x000161E2 File Offset: 0x000143E2
	// (set) Token: 0x060008AF RID: 2223 RVA: 0x000161EA File Offset: 0x000143EA
	public YoTOcyXEwwLXCfwPNwDCnXTauRHE ktkRTqEyTskXJrpsmrUbjRSyeCrjA { get; private set; }

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x060008B0 RID: 2224
	protected abstract XwqAbDXwWgalgQlSaCpBbiiFygUTA lzlupqZVHarXLULHBdWWNRcZpJrO { get; }

	// Token: 0x060008B1 RID: 2225 RVA: 0x0003A2D0 File Offset: 0x000384D0
	public unsafe virtual void INAKpPIdivVlHuKeBRZwhBJKJAzd(YoTOcyXEwwLXCfwPNwDCnXTauRHE A_1)
	{
		this.ktkRTqEyTskXJrpsmrUbjRSyeCrjA = A_1;
		base.FXEBIagcuThOcOepHwiWojXacofZA = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.FXEBIagcuThOcOepHwiWojXacofZA, this.lzlupqZVHarXLULHBdWWNRcZpJrO.KINwfFyTjWgLxskjLkyJaObqDGkd);
		*(IntPtr*)((byte*)((void*)base.FXEBIagcuThOcOepHwiWojXacofZA) + sizeof(IntPtr)) = GCHandle.ToIntPtr(value);
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x0003A32C File Offset: 0x0003852C
	protected unsafe virtual void vgWPQgfXhKQaHaKwpOuvEKHCAMPc(bool A_1)
	{
		if (base.FXEBIagcuThOcOepHwiWojXacofZA != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(*(IntPtr*)((byte*)((void*)base.FXEBIagcuThOcOepHwiWojXacofZA) + sizeof(IntPtr))).Free();
			Marshal.FreeHGlobal(base.FXEBIagcuThOcOepHwiWojXacofZA);
			base.FXEBIagcuThOcOepHwiWojXacofZA = IntPtr.Zero;
		}
		this.ktkRTqEyTskXJrpsmrUbjRSyeCrjA = null;
		base.LoZSDNfpeNelBpnVbhMvjqYYJUcAb(A_1);
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x0003A390 File Offset: 0x00038590
	internal unsafe static \u0001 BsezmsvlbICtcfXWGJMoILyEhbQg<\u0001>(IntPtr A_0) where \u0001 : mTBZwTkDXKQgAfxcspeSXeoLCArH
	{
		return (\u0001)((object)GCHandle.FromIntPtr(*(IntPtr*)((byte*)((void*)A_0) + sizeof(IntPtr))).Target);
	}

	// Token: 0x0400085E RID: 2142
	[CompilerGenerated]
	private YoTOcyXEwwLXCfwPNwDCnXTauRHE rULiaLMfArpwTIBJNCOTGyDrKZAB;
}
