using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003C5 RID: 965
	public class vUpdateUIPosition : MonoBehaviour
	{
		// Token: 0x0600133F RID: 4927 RVA: 0x00064E26 File Offset: 0x00063026
		public void UpdatePosition(GameObject target)
		{
			this.SetLocalPosition(target.transform.position);
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x00064E39 File Offset: 0x00063039
		public void UpdatePosition(Collider target)
		{
			this.SetLocalPosition(target.transform.position);
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x00064E4C File Offset: 0x0006304C
		public void UpdatePosition(Transform target)
		{
			this.SetLocalPosition(target.position);
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00064E5C File Offset: 0x0006305C
		private void SetLocalPosition(Vector3 position)
		{
			if (this.limitOnBox && this.box)
			{
				position = this.box.ClosestPointOnBounds(position);
			}
			Vector3 vector = this.referenceLocalParent.InverseTransformPoint(position);
			Vector3 localPosition = base.transform.localPosition;
			if (this.updateLocalX)
			{
				localPosition.x = vector.x;
			}
			if (this.updateLocalY)
			{
				localPosition.y = vector.y;
			}
			if (this.updateLocalZ)
			{
				localPosition.z = vector.z;
			}
			base.transform.localPosition = localPosition;
		}

		// Token: 0x040018FE RID: 6398
		public Transform referenceLocalParent;

		// Token: 0x040018FF RID: 6399
		public bool updateLocalX;

		// Token: 0x04001900 RID: 6400
		public bool updateLocalY;

		// Token: 0x04001901 RID: 6401
		public bool updateLocalZ;

		// Token: 0x04001902 RID: 6402
		public bool limitOnBox;

		// Token: 0x04001903 RID: 6403
		[vHideInInspector("limitOnBox", false)]
		public BoxCollider box;
	}
}
