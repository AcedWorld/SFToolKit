using System;
using UnityEngine;

// Token: 0x02000124 RID: 292
[ExecuteInEditMode]
public class BoneDonor : MonoBehaviour
{
	// Token: 0x060004C5 RID: 1221 RVA: 0x000212AF File Offset: 0x0001F4AF
	private void Update()
	{
		if (this.PressToReassign)
		{
			this.Reassign();
		}
		this.PressToReassign = false;
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x000212C8 File Offset: 0x0001F4C8
	public void Reassign()
	{
		if (this.newArmature == null)
		{
			Debug.Log("No new armature assigned");
			return;
		}
		Transform transform = this.newArmature.Find(this.rootBoneName);
		if (transform == null)
		{
			Debug.Log("Root bone not found");
			return;
		}
		Debug.Log("Reassigning bones");
		SkinnedMeshRenderer component = base.gameObject.GetComponent<SkinnedMeshRenderer>();
		if (component == null)
		{
			Debug.Log("No SkinnedMeshRenderer found");
			return;
		}
		Transform[] bones = component.bones;
		component.rootBone = transform;
		Transform[] componentsInChildren = this.newArmature.GetComponentsInChildren<Transform>();
		for (int i = 0; i < bones.Length; i++)
		{
			string b = bones[i].name.Replace("mixamorig:", "");
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				if (componentsInChildren[j].name == b)
				{
					bones[i] = componentsInChildren[j];
					break;
				}
			}
		}
		component.bones = bones;
	}

	// Token: 0x04000726 RID: 1830
	public Transform newArmature;

	// Token: 0x04000727 RID: 1831
	public string rootBoneName = "Hips";

	// Token: 0x04000728 RID: 1832
	public bool PressToReassign;
}
