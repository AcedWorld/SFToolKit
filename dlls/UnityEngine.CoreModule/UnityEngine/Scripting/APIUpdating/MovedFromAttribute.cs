using System;

namespace UnityEngine.Scripting.APIUpdating
{
	// Token: 0x0200031E RID: 798
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
	public class MovedFromAttribute : Attribute
	{
		// Token: 0x06002046 RID: 8262 RVA: 0x00035AA0 File Offset: 0x00033CA0
		public MovedFromAttribute(bool autoUpdateAPI, string sourceNamespace = null, string sourceAssembly = null, string sourceClassName = null)
		{
			this.data.Set(autoUpdateAPI, sourceNamespace, sourceAssembly, sourceClassName);
		}

		// Token: 0x06002047 RID: 8263 RVA: 0x00035ABB File Offset: 0x00033CBB
		public MovedFromAttribute(string sourceNamespace)
		{
			this.data.Set(true, sourceNamespace, null, null);
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06002048 RID: 8264 RVA: 0x00035AD8 File Offset: 0x00033CD8
		internal bool AffectsAPIUpdater
		{
			get
			{
				return !this.data.classHasChanged && !this.data.assemblyHasChanged;
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06002049 RID: 8265 RVA: 0x00035B08 File Offset: 0x00033D08
		public bool IsInDifferentAssembly
		{
			get
			{
				return this.data.assemblyHasChanged;
			}
		}

		// Token: 0x04000AB0 RID: 2736
		internal MovedFromAttributeData data;
	}
}
