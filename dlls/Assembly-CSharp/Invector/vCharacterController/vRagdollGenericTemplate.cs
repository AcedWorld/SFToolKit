using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x0200040C RID: 1036
	public class vRagdollGenericTemplate : ScriptableObject
	{
		// Token: 0x06001556 RID: 5462 RVA: 0x0006FD01 File Offset: 0x0006DF01
		public Transform GetRoot(Transform rootTransform)
		{
			return this.GetBone(this.root, rootTransform);
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0006FD10 File Offset: 0x0006DF10
		public Transform GetLeftHips(Transform rootTransform)
		{
			return this.GetBone(this.leftHips, rootTransform);
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0006FD1F File Offset: 0x0006DF1F
		public Transform GetLeftKnee(Transform rootTransform)
		{
			return this.GetBone(this.leftKnee, rootTransform);
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0006FD2E File Offset: 0x0006DF2E
		public Transform GetLeftFoot(Transform rootTransform)
		{
			return this.GetBone(this.leftFoot, rootTransform);
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0006FD3D File Offset: 0x0006DF3D
		public Transform GetRightHips(Transform rootTransform)
		{
			return this.GetBone(this.rightHips, rootTransform);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0006FD4C File Offset: 0x0006DF4C
		public Transform GetRightKnee(Transform rootTransform)
		{
			return this.GetBone(this.rightKnee, rootTransform);
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0006FD5B File Offset: 0x0006DF5B
		public Transform GetRightFoot(Transform rootTransform)
		{
			return this.GetBone(this.rightFoot, rootTransform);
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0006FD6A File Offset: 0x0006DF6A
		public Transform GetLeftArm(Transform rootTransform)
		{
			return this.GetBone(this.leftArm, rootTransform);
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0006FD79 File Offset: 0x0006DF79
		public Transform GetLeftElbow(Transform rootTransform)
		{
			return this.GetBone(this.leftElbow, rootTransform);
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x0006FD88 File Offset: 0x0006DF88
		public Transform GetRightArm(Transform rootTransform)
		{
			return this.GetBone(this.rightArm, rootTransform);
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x0006FD97 File Offset: 0x0006DF97
		public Transform GetRightElbow(Transform rootTransform)
		{
			return this.GetBone(this.rightElbow, rootTransform);
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x0006FDA6 File Offset: 0x0006DFA6
		public Transform GetMiddleSpine(Transform rootTransform)
		{
			return this.GetBone(this.middleSpine, rootTransform);
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0006FDB5 File Offset: 0x0006DFB5
		public Transform GetHead(Transform rootTransform)
		{
			return this.GetBone(this.head, rootTransform);
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x0006FDC4 File Offset: 0x0006DFC4
		private Transform GetBone(string boneName, Transform rootTransform)
		{
			Transform[] componentsInChildren = rootTransform.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].gameObject.name.Contains(boneName))
				{
					return componentsInChildren[i];
				}
				if (componentsInChildren[i].gameObject.name.ToUpper().Contains(boneName))
				{
					return componentsInChildren[i];
				}
				if (componentsInChildren[i].gameObject.name.ToUpper().Contains(boneName.ToUpper()))
				{
					return componentsInChildren[i];
				}
				if (componentsInChildren[i].gameObject.name.ToLower().Contains(boneName.ToUpper()))
				{
					return componentsInChildren[i];
				}
				if (componentsInChildren[i].gameObject.name.ToLower().Contains(boneName.ToLower()))
				{
					return componentsInChildren[i];
				}
				if (componentsInChildren[i].gameObject.name.ToLower().Contains(boneName))
				{
					return componentsInChildren[i];
				}
			}
			return null;
		}

		// Token: 0x04001B3C RID: 6972
		[Header("--- Bones Names ---")]
		public string root = "Hips";

		// Token: 0x04001B3D RID: 6973
		public string leftHips = "LeftUpperLeg";

		// Token: 0x04001B3E RID: 6974
		public string leftKnee = "LeftLowerLeg";

		// Token: 0x04001B3F RID: 6975
		public string leftFoot = "LeftFoot";

		// Token: 0x04001B40 RID: 6976
		public string rightHips = "RightUpperLeg";

		// Token: 0x04001B41 RID: 6977
		public string rightKnee = "RightLowerLeg";

		// Token: 0x04001B42 RID: 6978
		public string rightFoot = "RightFoot";

		// Token: 0x04001B43 RID: 6979
		public string leftArm = "LeftUpperArm";

		// Token: 0x04001B44 RID: 6980
		public string leftElbow = "LeftLowerArm";

		// Token: 0x04001B45 RID: 6981
		public string rightArm = "RightUpperArm";

		// Token: 0x04001B46 RID: 6982
		public string rightElbow = "RightLowerArm";

		// Token: 0x04001B47 RID: 6983
		public string middleSpine = "Chest";

		// Token: 0x04001B48 RID: 6984
		public string head = "Head";
	}
}
