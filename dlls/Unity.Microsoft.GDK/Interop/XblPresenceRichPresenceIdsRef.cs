using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000220 RID: 544
	[StructLayout(LayoutKind.Sequential)]
	internal class XblPresenceRichPresenceIdsRef
	{
		// Token: 0x06000DDB RID: 3547 RVA: 0x000111B8 File Offset: 0x0000F3B8
		internal XblPresenceRichPresenceIdsRef(XblPresenceRichPresenceIds richPresenceIds, DisposableCollection disposableCollection)
		{
			this.scid = Converters.StringToNullTerminatedUTF8ByteArray(richPresenceIds.ServiceConfigurationId, 40);
			this.presenceId = new UTF8StringPtr(richPresenceIds.PresenceId, disposableCollection);
			this.presenceTokenIds = Converters.StringArrayToUTF8StringArray(richPresenceIds.PresenceTokenIds, disposableCollection, out this.presenceTokenIdsCount);
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x00011208 File Offset: 0x0000F408
		internal static bool ValidateFields(string scid)
		{
			return scid != null && Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= 40;
		}

		// Token: 0x04000784 RID: 1924
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] scid;

		// Token: 0x04000785 RID: 1925
		internal readonly UTF8StringPtr presenceId;

		// Token: 0x04000786 RID: 1926
		private readonly IntPtr presenceTokenIds;

		// Token: 0x04000787 RID: 1927
		private readonly SizeT presenceTokenIdsCount;
	}
}
