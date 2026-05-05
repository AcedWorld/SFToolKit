using System;
using System.Collections.Generic;

namespace UnityEngine.Formats.Fbx.Exporter
{
	// Token: 0x02000005 RID: 5
	internal class FbxPrefab : MonoBehaviour
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020DA File Offset: 0x000002DA
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020E2 File Offset: 0x000002E2
		public string FbxHistory
		{
			get
			{
				return this.m_fbxHistory;
			}
			set
			{
				this.m_fbxHistory = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020EB File Offset: 0x000002EB
		public List<StringPair> NameMapping
		{
			get
			{
				return this.m_nameMapping;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020F3 File Offset: 0x000002F3
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000020FB File Offset: 0x000002FB
		public GameObject FbxModel
		{
			get
			{
				return this.m_fbxModel;
			}
			set
			{
				this.m_fbxModel = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002104 File Offset: 0x00000304
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000210C File Offset: 0x0000030C
		public bool AutoUpdate
		{
			get
			{
				return this.m_autoUpdate;
			}
			set
			{
				this.m_autoUpdate = value;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000012 RID: 18 RVA: 0x00002118 File Offset: 0x00000318
		// (remove) Token: 0x06000013 RID: 19 RVA: 0x0000214C File Offset: 0x0000034C
		public static event HandleUpdate OnUpdate;

		// Token: 0x06000014 RID: 20 RVA: 0x0000217F File Offset: 0x0000037F
		public static void CallOnUpdate(FbxPrefab instance, IEnumerable<GameObject> updatedObjects)
		{
			if (FbxPrefab.OnUpdate != null)
			{
				FbxPrefab.OnUpdate(instance, updatedObjects);
			}
		}

		// Token: 0x04000003 RID: 3
		[SerializeField]
		private string m_fbxHistory;

		// Token: 0x04000004 RID: 4
		[SerializeField]
		private List<StringPair> m_nameMapping = new List<StringPair>();

		// Token: 0x04000005 RID: 5
		[SerializeField]
		[Tooltip("Which FBX file does this refer to?")]
		private GameObject m_fbxModel;

		// Token: 0x04000006 RID: 6
		[Tooltip("Should we auto-update this prefab when the FBX file is updated?")]
		[SerializeField]
		private bool m_autoUpdate = true;
	}
}
