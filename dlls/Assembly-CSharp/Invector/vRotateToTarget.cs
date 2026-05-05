using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Invector
{
	// Token: 0x02000399 RID: 921
	[vClassHeader("Rotate To Target", true, "icon_v2", false, "")]
	public class vRotateToTarget : vMonoBehaviour
	{
		// Token: 0x17000365 RID: 869
		// (get) Token: 0x0600128B RID: 4747 RVA: 0x00061D93 File Offset: 0x0005FF93
		// (set) Token: 0x0600128A RID: 4746 RVA: 0x00061D8A File Offset: 0x0005FF8A
		public bool targetIsInAngleRange { get; protected set; }

		// Token: 0x0600128C RID: 4748 RVA: 0x00061D9B File Offset: 0x0005FF9B
		protected virtual void Start()
		{
			if (this.angleRootH == null)
			{
				this.angleRootH = base.transform;
			}
			if (this.angleRootV == null)
			{
				this.angleRootV = base.transform;
			}
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x00061DD4 File Offset: 0x0005FFD4
		protected virtual void Update()
		{
			if (!this.angleRootH || !this.rotatorV)
			{
				return;
			}
			Transform transform = this.targetTransform;
			if (this.rotatorV)
			{
				this.angleV = this.rotatorV.localEulerAngles.x;
			}
			if (this.rotatorH)
			{
				this.angleH = this.rotatorH.localEulerAngles.y;
			}
			if (transform)
			{
				Vector3 vector = transform.position - this.angleRootV.position;
				Vector3 vector2 = transform.position - this.angleRootH.position;
				float x = this.angleRootV.forward.AngleFormOtherDirection(vector.normalized).x;
				float y = this.angleRootH.forward.AngleFormOtherDirection(vector2.normalized).y;
				bool flag = Mathf.Abs(x) <= this.maxAngleVertical && Mathf.Abs(y) <= this.maxAngleHorizontal;
				if (flag != this.targetIsInAngleRange)
				{
					if (flag)
					{
						this.onEnterAngle.Invoke();
					}
					else
					{
						this.onExitAngle.Invoke();
					}
					this.targetIsInAngleRange = flag;
				}
				if (this.targetIsInAngleRange)
				{
					this.onStayAngle.Invoke();
					this.angleV = Mathf.LerpAngle(this.angleV, x, this.rotationSpeedInAngle * Time.deltaTime);
					this.angleH = Mathf.LerpAngle(this.angleH, y, this.rotationSpeedInAngle * Time.deltaTime);
				}
				else
				{
					this.angleV = Mathf.LerpAngle(this.angleV, 0f, this.rotationSpeedOutAngle * Time.deltaTime);
					this.angleH = Mathf.LerpAngle(this.angleH, 0f, this.rotationSpeedOutAngle * Time.deltaTime);
				}
			}
			else
			{
				if (this.targetIsInAngleRange)
				{
					this.onExitAngle.Invoke();
					this.targetIsInAngleRange = false;
				}
				if (this.rotatorV.localEulerAngles.magnitude > 0f)
				{
					this.angleV = Mathf.LerpAngle(this.angleV, 0f, this.rotationSpeedOutAngle * Time.deltaTime);
					this.angleH = Mathf.LerpAngle(this.angleH, 0f, this.rotationSpeedOutAngle * Time.deltaTime);
				}
			}
			if (this.rotateV && this.rotateV)
			{
				Vector3 localEulerAngles = this.rotatorV.localEulerAngles;
				localEulerAngles.x = this.angleV;
				this.rotatorV.localEulerAngles = localEulerAngles;
			}
			if (this.rotateH && this.rotatorH)
			{
				Vector3 localEulerAngles2 = this.rotatorH.localEulerAngles;
				localEulerAngles2.y = this.angleH;
				this.rotatorH.localEulerAngles = localEulerAngles2;
			}
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x00062097 File Offset: 0x00060297
		public void SetTarget(Transform target)
		{
			this.targetTransform = target;
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x000620A0 File Offset: 0x000602A0
		public void ClearTarget()
		{
			this.targetTransform = null;
		}

		// Token: 0x0400183C RID: 6204
		public Transform targetTransform;

		// Token: 0x0400183D RID: 6205
		[FormerlySerializedAs("angleRoot")]
		public Transform angleRootH;

		// Token: 0x0400183E RID: 6206
		public Transform rotatorH;

		// Token: 0x0400183F RID: 6207
		public Transform angleRootV;

		// Token: 0x04001840 RID: 6208
		[FormerlySerializedAs("rotator")]
		public Transform rotatorV;

		// Token: 0x04001841 RID: 6209
		public bool rotateH;

		// Token: 0x04001842 RID: 6210
		public bool rotateV;

		// Token: 0x04001843 RID: 6211
		public float rotationSpeedInAngle;

		// Token: 0x04001844 RID: 6212
		public float rotationSpeedOutAngle;

		// Token: 0x04001845 RID: 6213
		[Range(0f, 180f)]
		public float maxAngleVertical = 60f;

		// Token: 0x04001846 RID: 6214
		[Range(0f, 180f)]
		public float maxAngleHorizontal = 60f;

		// Token: 0x04001847 RID: 6215
		[Range(0f, 180f)]
		public float angleToReachTarget = 45f;

		// Token: 0x04001848 RID: 6216
		public UnityEvent onEnterAngle;

		// Token: 0x04001849 RID: 6217
		public UnityEvent onStayAngle;

		// Token: 0x0400184A RID: 6218
		public UnityEvent onExitAngle;

		// Token: 0x0400184C RID: 6220
		protected float angleH;

		// Token: 0x0400184D RID: 6221
		protected float angleV;
	}
}
