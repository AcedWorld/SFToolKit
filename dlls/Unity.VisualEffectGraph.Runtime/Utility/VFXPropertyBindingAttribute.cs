using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000040 RID: 64
	[AttributeUsage(AttributeTargets.Field)]
	public class VFXPropertyBindingAttribute : PropertyAttribute
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x00009176 File Offset: 0x00007376
		public VFXPropertyBindingAttribute(params string[] editorTypes)
		{
			this.EditorTypes = editorTypes;
		}

		// Token: 0x04000114 RID: 276
		public string[] EditorTypes;
	}
}
