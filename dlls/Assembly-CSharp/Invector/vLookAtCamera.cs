using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000388 RID: 904
	public class vLookAtCamera : MonoBehaviour
	{
		// Token: 0x0600124E RID: 4686 RVA: 0x0006126E File Offset: 0x0005F46E
		private void Start()
		{
			if (this.detachOnStart)
			{
				this.parent = base.transform.parent;
				base.transform.SetParent(null);
			}
			this.cameraMain = Camera.main;
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x000612A0 File Offset: 0x0005F4A0
		private void FixedUpdate()
		{
			if (this.alignUp && this.parent)
			{
				base.transform.position = this.parent.position + Vector3.up * this.height;
			}
			if (!this.cameraMain)
			{
				return;
			}
			Vector3 forward = this.cameraMain.transform.position - base.transform.position;
			forward.y = 0f;
			Quaternion b = Quaternion.LookRotation(forward);
			if (this.useSmothRotation)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 4f);
				base.transform.eulerAngles = new Vector3(this.justY ? 0f : base.transform.eulerAngles.x, base.transform.eulerAngles.y, 0f);
				return;
			}
			base.transform.eulerAngles = new Vector3(this.justY ? 0f : b.eulerAngles.x, b.eulerAngles.y, 0f);
		}

		// Token: 0x0400181A RID: 6170
		[Tooltip("Align position to stay always on top of parent")]
		public bool alignUp;

		// Token: 0x0400181B RID: 6171
		[Tooltip("Height of alignment on top of parent \n!!(Check alignUp to work)!!")]
		public float height = 1f;

		// Token: 0x0400181C RID: 6172
		[Tooltip("Detach of the parent on start \n!!(if alignUp not is checked, the object not follow the parent)!!")]
		public bool detachOnStart;

		// Token: 0x0400181D RID: 6173
		[Tooltip("use smoth to look at camera")]
		public bool useSmothRotation = true;

		// Token: 0x0400181E RID: 6174
		protected Transform parent;

		// Token: 0x0400181F RID: 6175
		public bool justY;

		// Token: 0x04001820 RID: 6176
		internal Camera cameraMain;
	}
}
