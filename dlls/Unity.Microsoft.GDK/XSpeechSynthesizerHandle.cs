using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200016E RID: 366
	[MovedFrom("Unity.GameCore")]
	public class XSpeechSynthesizerHandle : EquatableHandle
	{
		// Token: 0x060008C5 RID: 2245 RVA: 0x0000E0AB File Offset: 0x0000C2AB
		public XSpeechSynthesizerHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x0000E0BA File Offset: 0x0000C2BA
		// (set) Token: 0x060008C7 RID: 2247 RVA: 0x0000E0C2 File Offset: 0x0000C2C2
		public int CloseResult { get; private set; }

		// Token: 0x060008C8 RID: 2248 RVA: 0x0000E0CB File Offset: 0x0000C2CB
		protected override bool ReleaseHandle()
		{
			this.CloseResult = NativeMethods.XSpeechSynthesizerCloseHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return HR.SUCCEEDED(this.CloseResult);
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0000E0F4 File Offset: 0x0000C2F4
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
