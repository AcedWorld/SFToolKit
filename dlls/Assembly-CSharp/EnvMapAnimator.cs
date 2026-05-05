using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000219 RID: 537
public class EnvMapAnimator : MonoBehaviour
{
	// Token: 0x06000879 RID: 2169 RVA: 0x0003B6BA File Offset: 0x000398BA
	private void Awake()
	{
		this.m_textMeshPro = base.GetComponent<TMP_Text>();
		this.m_material = this.m_textMeshPro.fontSharedMaterial;
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x0003B6D9 File Offset: 0x000398D9
	private IEnumerator Start()
	{
		Matrix4x4 matrix = default(Matrix4x4);
		for (;;)
		{
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
			this.m_material.SetMatrix("_EnvMatrix", matrix);
			yield return null;
		}
		yield break;
	}

	// Token: 0x04000EAE RID: 3758
	public Vector3 RotationSpeeds;

	// Token: 0x04000EAF RID: 3759
	private TMP_Text m_textMeshPro;

	// Token: 0x04000EB0 RID: 3760
	private Material m_material;
}
