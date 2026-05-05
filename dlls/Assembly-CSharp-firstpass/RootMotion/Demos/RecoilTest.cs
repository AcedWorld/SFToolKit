using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000175 RID: 373
	public class RecoilTest : MonoBehaviour
	{
		// Token: 0x06000AD4 RID: 2772 RVA: 0x000453B0 File Offset: 0x000435B0
		private void Start()
		{
			this.recoil = base.GetComponent<Recoil>();
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x000453BE File Offset: 0x000435BE
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))
			{
				this.recoil.Fire(this.magnitude);
			}
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x000453E2 File Offset: 0x000435E2
		private void OnGUI()
		{
			GUILayout.Label("Press R or LMB for procedural recoil.", Array.Empty<GUILayoutOption>());
		}

		// Token: 0x04000AB0 RID: 2736
		public float magnitude = 1f;

		// Token: 0x04000AB1 RID: 2737
		private Recoil recoil;
	}
}
