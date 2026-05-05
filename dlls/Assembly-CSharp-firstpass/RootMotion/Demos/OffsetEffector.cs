using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200016E RID: 366
	public class OffsetEffector : OffsetModifier
	{
		// Token: 0x06000AB9 RID: 2745 RVA: 0x00044758 File Offset: 0x00042958
		protected override void Start()
		{
			base.Start();
			if (this.anchor != null)
			{
				this.posRelToAnchor = this.anchor.InverseTransformPoint(base.transform.position);
				this.rotRelToAnchor = Quaternion.Inverse(this.anchor.rotation) * base.transform.rotation;
			}
			foreach (OffsetEffector.EffectorLink effectorLink in this.effectorLinks)
			{
				Transform bone = this.ik.solver.GetEffector(effectorLink.effectorType).bone;
				effectorLink.localPosition = base.transform.InverseTransformPoint(bone.position);
				if (effectorLink.effectorType == FullBodyBipedEffector.Body)
				{
					this.ik.solver.bodyEffector.effectChildNodes = false;
				}
			}
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00044828 File Offset: 0x00042A28
		protected override void OnModifyOffset()
		{
			foreach (OffsetEffector.EffectorLink effectorLink in this.effectorLinks)
			{
				Vector3 a = base.transform.TransformPoint(effectorLink.localPosition);
				this.ik.solver.GetEffector(effectorLink.effectorType).positionOffset += (a - (this.ik.solver.GetEffector(effectorLink.effectorType).bone.position + this.ik.solver.GetEffector(effectorLink.effectorType).positionOffset)) * this.weight * effectorLink.weightMultiplier;
			}
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x000448E8 File Offset: 0x00042AE8
		public void Anchor()
		{
			if (this.anchor == null)
			{
				return;
			}
			base.transform.position = this.anchor.TransformPoint(this.posRelToAnchor);
			base.transform.rotation = this.anchor.rotation * this.rotRelToAnchor;
		}

		// Token: 0x04000A8B RID: 2699
		[Tooltip("Optional. Assign the bone Transform that is closest to this OffsetEffector to be able to call OffsetEffector.Anchor() in LateUpdate to match its position and rotation to animation.")]
		public Transform anchor;

		// Token: 0x04000A8C RID: 2700
		public OffsetEffector.EffectorLink[] effectorLinks;

		// Token: 0x04000A8D RID: 2701
		private Vector3 posRelToAnchor;

		// Token: 0x04000A8E RID: 2702
		private Quaternion rotRelToAnchor = Quaternion.identity;

		// Token: 0x0200016F RID: 367
		[Serializable]
		public class EffectorLink
		{
			// Token: 0x04000A8F RID: 2703
			public FullBodyBipedEffector effectorType;

			// Token: 0x04000A90 RID: 2704
			public float weightMultiplier = 1f;

			// Token: 0x04000A91 RID: 2705
			[HideInInspector]
			public Vector3 localPosition;
		}
	}
}
