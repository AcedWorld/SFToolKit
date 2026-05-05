using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B9 RID: 441
	public abstract class CharacterAnimationBase : MonoBehaviour
	{
		// Token: 0x06000BD7 RID: 3031 RVA: 0x00049637 File Offset: 0x00047837
		public virtual Vector3 GetPivotPoint()
		{
			return base.transform.position;
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
		public virtual bool animationGrounded
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x00049644 File Offset: 0x00047844
		public float GetAngleFromForward(Vector3 worldDirection)
		{
			Vector3 vector = base.transform.InverseTransformDirection(worldDirection);
			return Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x00049678 File Offset: 0x00047878
		protected virtual void Start()
		{
			if (base.transform.parent.GetComponent<CharacterBase>() == null)
			{
				Debug.LogWarning("Animation controllers should be parented to character controllers!", base.transform);
			}
			this.lastPosition = base.transform.position;
			this.localPosition = base.transform.localPosition;
			this.lastRotation = base.transform.rotation;
			this.localRotation = base.transform.localRotation;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x000496F1 File Offset: 0x000478F1
		protected virtual void LateUpdate()
		{
			if (this.animatePhysics)
			{
				return;
			}
			this.SmoothFollow();
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x00049702 File Offset: 0x00047902
		protected virtual void FixedUpdate()
		{
			if (!this.animatePhysics)
			{
				return;
			}
			this.SmoothFollow();
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00049714 File Offset: 0x00047914
		private void SmoothFollow()
		{
			if (this.smoothFollow)
			{
				base.transform.position = Vector3.Lerp(this.lastPosition, base.transform.parent.TransformPoint(this.localPosition), Time.deltaTime * this.smoothFollowSpeed);
				base.transform.rotation = Quaternion.Lerp(this.lastRotation, base.transform.parent.rotation * this.localRotation, Time.deltaTime * this.smoothFollowSpeed);
			}
			else
			{
				base.transform.localPosition = this.localPosition;
				base.transform.localRotation = this.localRotation;
			}
			this.lastPosition = base.transform.position;
			this.lastRotation = base.transform.rotation;
		}

		// Token: 0x04000BF3 RID: 3059
		public bool smoothFollow = true;

		// Token: 0x04000BF4 RID: 3060
		public float smoothFollowSpeed = 20f;

		// Token: 0x04000BF5 RID: 3061
		protected bool animatePhysics;

		// Token: 0x04000BF6 RID: 3062
		private Vector3 lastPosition;

		// Token: 0x04000BF7 RID: 3063
		private Vector3 localPosition;

		// Token: 0x04000BF8 RID: 3064
		private Quaternion localRotation;

		// Token: 0x04000BF9 RID: 3065
		private Quaternion lastRotation;
	}
}
