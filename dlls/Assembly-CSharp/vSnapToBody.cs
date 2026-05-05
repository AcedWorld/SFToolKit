using System;
using Invector;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class vSnapToBody : MonoBehaviour
{
	// Token: 0x060000A8 RID: 168 RVA: 0x00007FD0 File Offset: 0x000061D0
	private void Start()
	{
		this.bodySnap = base.transform.root.GetComponentInChildren<vBodySnappingControl>(true);
		if (this.boneName != "ManuallyAssign" && this.bodySnap != null && this.bodySnap.boneSnappingList != null)
		{
			this.boneToSnap = this.bodySnap.GetBone(this.boneName);
		}
		if (this.boneToSnap)
		{
			base.transform.parent = this.boneToSnap;
		}
	}

	// Token: 0x040000F2 RID: 242
	public const string manuallyAssignBone = "ManuallyAssign";

	// Token: 0x040000F3 RID: 243
	public vBodySnappingControl bodySnap;

	// Token: 0x040000F4 RID: 244
	public Transform boneToSnap;

	// Token: 0x040000F5 RID: 245
	public string boneName;
}
