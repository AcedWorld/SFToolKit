using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200017A RID: 378
	public class TouchWalls : MonoBehaviour
	{
		// Token: 0x06000AEB RID: 2795 RVA: 0x0004569C File Offset: 0x0004389C
		private void Start()
		{
			TouchWalls.EffectorLink[] array = this.effectorLinks;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initiate(this.interactionSystem);
			}
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x000456CC File Offset: 0x000438CC
		private void FixedUpdate()
		{
			for (int i = 0; i < this.effectorLinks.Length; i++)
			{
				this.effectorLinks[i].Update(this.interactionSystem);
			}
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00045700 File Offset: 0x00043900
		private void OnDestroy()
		{
			if (this.interactionSystem != null)
			{
				for (int i = 0; i < this.effectorLinks.Length; i++)
				{
					this.effectorLinks[i].Destroy(this.interactionSystem);
				}
			}
		}

		// Token: 0x04000AC1 RID: 2753
		public InteractionSystem interactionSystem;

		// Token: 0x04000AC2 RID: 2754
		public TouchWalls.EffectorLink[] effectorLinks;

		// Token: 0x0200017B RID: 379
		[Serializable]
		public class EffectorLink
		{
			// Token: 0x06000AEF RID: 2799 RVA: 0x00045744 File Offset: 0x00043944
			public void Initiate(InteractionSystem interactionSystem)
			{
				this.raycastDirectionLocal = this.spherecastFrom.InverseTransformDirection(this.interactionObject.transform.position - this.spherecastFrom.position);
				this.raycastDistance = Vector3.Distance(this.spherecastFrom.position, this.interactionObject.transform.position);
				interactionSystem.OnInteractionStart = (InteractionSystem.InteractionDelegate)Delegate.Combine(interactionSystem.OnInteractionStart, new InteractionSystem.InteractionDelegate(this.OnInteractionStart));
				interactionSystem.OnInteractionResume = (InteractionSystem.InteractionDelegate)Delegate.Combine(interactionSystem.OnInteractionResume, new InteractionSystem.InteractionDelegate(this.OnInteractionResume));
				interactionSystem.OnInteractionStop = (InteractionSystem.InteractionDelegate)Delegate.Combine(interactionSystem.OnInteractionStop, new InteractionSystem.InteractionDelegate(this.OnInteractionStop));
				this.hit.normal = Vector3.forward;
				this.targetPosition = this.interactionObject.transform.position;
				this.targetRotation = this.interactionObject.transform.rotation;
				this.initiated = true;
			}

			// Token: 0x06000AF0 RID: 2800 RVA: 0x00045854 File Offset: 0x00043A54
			private bool FindWalls(Vector3 direction)
			{
				if (!this.enabled)
				{
					return false;
				}
				bool result = Physics.SphereCast(this.spherecastFrom.position, this.spherecastRadius, direction, out this.hit, this.raycastDistance * this.distanceMlp, this.touchLayers);
				if (this.hit.distance < this.minDistance)
				{
					result = false;
				}
				return result;
			}

			// Token: 0x06000AF1 RID: 2801 RVA: 0x000458B8 File Offset: 0x00043AB8
			public void Update(InteractionSystem interactionSystem)
			{
				if (!this.initiated)
				{
					return;
				}
				Vector3 vector = this.spherecastFrom.TransformDirection(this.raycastDirectionLocal);
				this.hit.point = this.spherecastFrom.position + vector;
				bool flag = this.FindWalls(vector);
				if (!this.inTouch)
				{
					if (flag && Time.time > this.nextSwitchTime)
					{
						this.interactionObject.transform.parent = null;
						interactionSystem.StartInteraction(this.effectorType, this.interactionObject, true);
						this.nextSwitchTime = Time.time + this.minSwitchTime / interactionSystem.speed;
						this.targetPosition = this.hit.point;
						this.targetRotation = Quaternion.LookRotation(-this.hit.normal);
						this.interactionObject.transform.position = this.targetPosition;
						this.interactionObject.transform.rotation = this.targetRotation;
					}
				}
				else
				{
					if (!flag)
					{
						this.StopTouch(interactionSystem);
					}
					else if (!interactionSystem.IsPaused(this.effectorType) || this.sliding)
					{
						this.targetPosition = this.hit.point;
						this.targetRotation = Quaternion.LookRotation(-this.hit.normal);
					}
					if (Vector3.Distance(this.interactionObject.transform.position, this.hit.point) > this.releaseDistance)
					{
						if (flag)
						{
							this.targetPosition = this.hit.point;
							this.targetRotation = Quaternion.LookRotation(-this.hit.normal);
						}
						else
						{
							this.StopTouch(interactionSystem);
						}
					}
				}
				float b = (!this.inTouch || (interactionSystem.IsPaused(this.effectorType) && this.interactionObject.transform.position == this.targetPosition)) ? 0f : 1f;
				this.speedF = Mathf.Lerp(this.speedF, b, Time.deltaTime * 3f * interactionSystem.speed);
				float t = Time.deltaTime * this.lerpSpeed * this.speedF * interactionSystem.speed;
				this.interactionObject.transform.position = Vector3.Lerp(this.interactionObject.transform.position, this.targetPosition, t);
				this.interactionObject.transform.rotation = Quaternion.Slerp(this.interactionObject.transform.rotation, this.targetRotation, t);
			}

			// Token: 0x06000AF2 RID: 2802 RVA: 0x00045B48 File Offset: 0x00043D48
			private void StopTouch(InteractionSystem interactionSystem)
			{
				this.interactionObject.transform.parent = interactionSystem.transform;
				this.nextSwitchTime = Time.time + this.minSwitchTime / interactionSystem.speed;
				if (interactionSystem.IsPaused(this.effectorType))
				{
					interactionSystem.ResumeInteraction(this.effectorType);
					return;
				}
				this.speedF = 0f;
				this.targetPosition = this.hit.point;
				if (this.hit.normal != Vector3.zero)
				{
					this.targetRotation = Quaternion.LookRotation(-this.hit.normal);
				}
			}

			// Token: 0x06000AF3 RID: 2803 RVA: 0x00045BEE File Offset: 0x00043DEE
			private void OnInteractionStart(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
			{
				if (effectorType != this.effectorType || interactionObject != this.interactionObject)
				{
					return;
				}
				this.inTouch = true;
			}

			// Token: 0x06000AF4 RID: 2804 RVA: 0x00045C0F File Offset: 0x00043E0F
			private void OnInteractionResume(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
			{
				if (effectorType != this.effectorType || interactionObject != this.interactionObject)
				{
					return;
				}
				this.inTouch = false;
			}

			// Token: 0x06000AF5 RID: 2805 RVA: 0x00045C0F File Offset: 0x00043E0F
			private void OnInteractionStop(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
			{
				if (effectorType != this.effectorType || interactionObject != this.interactionObject)
				{
					return;
				}
				this.inTouch = false;
			}

			// Token: 0x06000AF6 RID: 2806 RVA: 0x00045C30 File Offset: 0x00043E30
			public void Destroy(InteractionSystem interactionSystem)
			{
				if (!this.initiated)
				{
					return;
				}
				interactionSystem.OnInteractionStart = (InteractionSystem.InteractionDelegate)Delegate.Remove(interactionSystem.OnInteractionStart, new InteractionSystem.InteractionDelegate(this.OnInteractionStart));
				interactionSystem.OnInteractionResume = (InteractionSystem.InteractionDelegate)Delegate.Remove(interactionSystem.OnInteractionResume, new InteractionSystem.InteractionDelegate(this.OnInteractionResume));
				interactionSystem.OnInteractionStop = (InteractionSystem.InteractionDelegate)Delegate.Remove(interactionSystem.OnInteractionStop, new InteractionSystem.InteractionDelegate(this.OnInteractionStop));
			}

			// Token: 0x04000AC3 RID: 2755
			public bool enabled = true;

			// Token: 0x04000AC4 RID: 2756
			public FullBodyBipedEffector effectorType;

			// Token: 0x04000AC5 RID: 2757
			public InteractionObject interactionObject;

			// Token: 0x04000AC6 RID: 2758
			public Transform spherecastFrom;

			// Token: 0x04000AC7 RID: 2759
			public float spherecastRadius = 0.1f;

			// Token: 0x04000AC8 RID: 2760
			public float minDistance = 0.3f;

			// Token: 0x04000AC9 RID: 2761
			public float distanceMlp = 1f;

			// Token: 0x04000ACA RID: 2762
			public LayerMask touchLayers;

			// Token: 0x04000ACB RID: 2763
			public float lerpSpeed = 10f;

			// Token: 0x04000ACC RID: 2764
			public float minSwitchTime = 0.2f;

			// Token: 0x04000ACD RID: 2765
			public float releaseDistance = 0.4f;

			// Token: 0x04000ACE RID: 2766
			public bool sliding;

			// Token: 0x04000ACF RID: 2767
			private Vector3 raycastDirectionLocal;

			// Token: 0x04000AD0 RID: 2768
			private float raycastDistance;

			// Token: 0x04000AD1 RID: 2769
			private bool inTouch;

			// Token: 0x04000AD2 RID: 2770
			private RaycastHit hit;

			// Token: 0x04000AD3 RID: 2771
			private Vector3 targetPosition;

			// Token: 0x04000AD4 RID: 2772
			private Quaternion targetRotation;

			// Token: 0x04000AD5 RID: 2773
			private bool initiated;

			// Token: 0x04000AD6 RID: 2774
			private float nextSwitchTime;

			// Token: 0x04000AD7 RID: 2775
			private float speedF;
		}
	}
}
