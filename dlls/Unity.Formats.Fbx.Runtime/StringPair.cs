using System;

namespace UnityEngine.Formats.Fbx.Exporter
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	internal struct StringPair
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020B8 File Offset: 0x000002B8
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020C0 File Offset: 0x000002C0
		public string FBXObjectName
		{
			get
			{
				return this.m_fbxObjectName;
			}
			set
			{
				this.m_fbxObjectName = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020C9 File Offset: 0x000002C9
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020D1 File Offset: 0x000002D1
		public string UnityObjectName
		{
			get
			{
				return this.m_unityObjectName;
			}
			set
			{
				this.m_unityObjectName = value;
			}
		}

		// Token: 0x04000001 RID: 1
		private string m_fbxObjectName;

		// Token: 0x04000002 RID: 2
		private string m_unityObjectName;
	}
}
