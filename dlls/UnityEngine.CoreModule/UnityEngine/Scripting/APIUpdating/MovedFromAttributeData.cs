using System;

namespace UnityEngine.Scripting.APIUpdating
{
	// Token: 0x0200031D RID: 797
	internal struct MovedFromAttributeData
	{
		// Token: 0x06002045 RID: 8261 RVA: 0x00035A48 File Offset: 0x00033C48
		public void Set(bool autoUpdateAPI, string sourceNamespace = null, string sourceAssembly = null, string sourceClassName = null)
		{
			this.className = sourceClassName;
			this.classHasChanged = (this.className != null);
			this.nameSpace = sourceNamespace;
			this.nameSpaceHasChanged = (this.nameSpace != null);
			this.assembly = sourceAssembly;
			this.assemblyHasChanged = (this.assembly != null);
			this.autoUdpateAPI = autoUpdateAPI;
		}

		// Token: 0x04000AA9 RID: 2729
		public string className;

		// Token: 0x04000AAA RID: 2730
		public string nameSpace;

		// Token: 0x04000AAB RID: 2731
		public string assembly;

		// Token: 0x04000AAC RID: 2732
		public bool classHasChanged;

		// Token: 0x04000AAD RID: 2733
		public bool nameSpaceHasChanged;

		// Token: 0x04000AAE RID: 2734
		public bool assemblyHasChanged;

		// Token: 0x04000AAF RID: 2735
		public bool autoUdpateAPI;
	}
}
