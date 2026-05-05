using System;
using UnityEngine;

// Token: 0x020001AB RID: 427
public class RenameBones : MonoBehaviour
{
	// Token: 0x060006AF RID: 1711 RVA: 0x00032448 File Offset: 0x00030648
	[ContextMenu("Rename Bones")]
	public void RenameBonesInHierarchy()
	{
		foreach (Transform transform in base.GetComponentsInChildren<Transform>())
		{
			if (transform.name.StartsWith("mixamorig:"))
			{
				string text = transform.name.Replace("mixamorig:", "");
				Debug.Log("Renaming " + transform.name + " to " + text);
				transform.name = text;
			}
		}
		Debug.Log("Bone renaming completed.");
	}
}
