using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003C1 RID: 961
	[vClassHeader("Set Transform", true, "icon_v2", false, "", openClose = false)]
	public class vSetTransform : vMonoBehaviour
	{
		// Token: 0x06001329 RID: 4905 RVA: 0x00064B56 File Offset: 0x00062D56
		public void SetPosition(Transform _target)
		{
			_target.position = this.SelfTransform.position;
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x00064B69 File Offset: 0x00062D69
		public void SetRotation(Transform _target)
		{
			_target.rotation = this.SelfTransform.rotation;
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x00064B7C File Offset: 0x00062D7C
		public void SetPositionAndRotation(Transform _target)
		{
			this.SetPosition(_target);
			this.SetRotation(_target);
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x0600132C RID: 4908 RVA: 0x00064B8C File Offset: 0x00062D8C
		public Transform SelfTransform
		{
			get
			{
				if (!this.targetPosition)
				{
					return base.transform;
				}
				return this.targetPosition;
			}
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x00064BA8 File Offset: 0x00062DA8
		public void SetPosition(Collider _target)
		{
			_target.transform.position = this.SelfTransform.position;
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x00064BC0 File Offset: 0x00062DC0
		public void SetRotation(Collider _target)
		{
			_target.transform.rotation = this.SelfTransform.rotation;
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x00064BD8 File Offset: 0x00062DD8
		public void SetPositionAndRotation(Collider _target)
		{
			this.SetPosition(_target);
			this.SetRotation(_target);
		}

		// Token: 0x040018EA RID: 6378
		public Transform targetPosition;
	}
}
