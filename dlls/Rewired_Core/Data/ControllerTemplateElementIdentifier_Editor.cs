using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200029B RID: 667
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[Serializable]
	internal sealed class ControllerTemplateElementIdentifier_Editor : ControllerTemplateElementIdentifier, IControllerTemplateElementIdentifier_Editor, IControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal
	{
		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06001E3D RID: 7741 RVA: 0x00017B44 File Offset: 0x00015D44
		// (set) Token: 0x06001E3E RID: 7742 RVA: 0x00017B4C File Offset: 0x00015D4C
		internal string scriptingName
		{
			get
			{
				return this._scriptingName;
			}
			set
			{
				this._scriptingName = value;
			}
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x06001E3F RID: 7743 RVA: 0x00017B55 File Offset: 0x00015D55
		// (set) Token: 0x06001E40 RID: 7744 RVA: 0x00017B5D File Offset: 0x00015D5D
		internal string alternateScriptingName
		{
			get
			{
				return this._alternateScriptingName;
			}
			set
			{
				this._alternateScriptingName = value;
			}
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x06001E41 RID: 7745 RVA: 0x00017B66 File Offset: 0x00015D66
		internal bool excludeFromExport
		{
			get
			{
				return this._excludeFromExport;
			}
		}

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x06001E42 RID: 7746 RVA: 0x00017B6E File Offset: 0x00015D6E
		internal override bool useEditorElementTypeOverride
		{
			get
			{
				return this._useEditorElementTypeOverride;
			}
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06001E43 RID: 7747 RVA: 0x00017B76 File Offset: 0x00015D76
		internal override ControllerElementType editorElementTypeOverride
		{
			get
			{
				return this._editorElementTypeOverride;
			}
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06001E44 RID: 7748 RVA: 0x00017B7E File Offset: 0x00015D7E
		internal ControllerTemplateElementType effectiveElementType
		{
			get
			{
				if (!this._useEditorElementTypeOverride)
				{
					return base.elementType;
				}
				return gRvITEHjKMrWaeGYEmAHofbpCtEU.CkKlzxvjUXxuZLFtnYQkTRGMtKjm(this._editorElementTypeOverride, false);
			}
		}

		// Token: 0x06001E45 RID: 7749 RVA: 0x00017B9B File Offset: 0x00015D9B
		public ControllerTemplateElementIdentifier_Editor()
		{
		}

		// Token: 0x06001E46 RID: 7750 RVA: 0x000804F8 File Offset: 0x0007E6F8
		public ControllerTemplateElementIdentifier_Editor(ControllerTemplateElementIdentifier_Editor A_1) : base(A_1)
		{
			this._scriptingName = A_1._scriptingName;
			this._alternateScriptingName = A_1._alternateScriptingName;
			this._excludeFromExport = A_1._excludeFromExport;
			this._editorElementTypeOverride = A_1._editorElementTypeOverride;
			this._useEditorElementTypeOverride = A_1._useEditorElementTypeOverride;
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06001E47 RID: 7751 RVA: 0x00017B44 File Offset: 0x00015D44
		string IControllerTemplateElementIdentifier_Editor.scriptingName
		{
			get
			{
				return this._scriptingName;
			}
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06001E48 RID: 7752 RVA: 0x00017B55 File Offset: 0x00015D55
		string IControllerTemplateElementIdentifier_Editor.alternateScriptingName
		{
			get
			{
				return this._alternateScriptingName;
			}
		}

		// Token: 0x06001E49 RID: 7753 RVA: 0x00017BA3 File Offset: 0x00015DA3
		public override ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier_Editor(this);
		}

		// Token: 0x040010FE RID: 4350
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _scriptingName;

		// Token: 0x040010FF RID: 4351
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _alternateScriptingName;

		// Token: 0x04001100 RID: 4352
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _excludeFromExport;

		// Token: 0x04001101 RID: 4353
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useEditorElementTypeOverride;

		// Token: 0x04001102 RID: 4354
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementType _editorElementTypeOverride;
	}
}
