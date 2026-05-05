using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200016F RID: 367
	[MovedFrom("Unity.GameCore")]
	public class XSpeechSynthesizerStreamHandle : EquatableHandle
	{
		// Token: 0x060008CA RID: 2250 RVA: 0x0000E106 File Offset: 0x0000C306
		public XSpeechSynthesizerStreamHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x0000E115 File Offset: 0x0000C315
		// (set) Token: 0x060008CC RID: 2252 RVA: 0x0000E11D File Offset: 0x0000C31D
		public int CloseResult { get; private set; }

		// Token: 0x060008CD RID: 2253 RVA: 0x0000E126 File Offset: 0x0000C326
		protected override bool ReleaseHandle()
		{
			this.CloseResult = NativeMethods.XSpeechSynthesizerCloseStreamHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return HR.SUCCEEDED(this.CloseResult);
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x0000E14F File Offset: 0x0000C34F
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
