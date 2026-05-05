using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000171 RID: 369
	public abstract class PickUp2Handed : MonoBehaviour
	{
		// Token: 0x06000AC1 RID: 2753 RVA: 0x00044D70 File Offset: 0x00042F70
		private void OnGUI()
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Space((float)this.GUIspace);
			if (!this.holding)
			{
				if (GUILayout.Button("Pick Up " + this.obj.name, Array.Empty<GUILayoutOption>()))
				{
					this.interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, this.obj, false);
					this.interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, this.obj, false);
				}
			}
			else
			{
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				if (this.holdingRight && GUILayout.Button("Release Right", Array.Empty<GUILayoutOption>()))
				{
					this.interactionSystem.ResumeInteraction(FullBodyBipedEffector.RightHand);
				}
				if (this.holdingLeft && GUILayout.Button("Release Left", Array.Empty<GUILayoutOption>()))
				{
					this.interactionSystem.ResumeInteraction(FullBodyBipedEffector.LeftHand);
				}
				if (GUILayout.Button("Drop " + this.obj.name, Array.Empty<GUILayoutOption>()))
				{
					this.interactionSystem.ResumeAll();
				}
				GUILayout.EndVertical();
			}
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000AC2 RID: 2754
		protected abstract void RotatePivot();

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00044E78 File Offset: 0x00043078
		private void Start()
		{
			InteractionSystem interactionSystem = this.interactionSystem;
			interactionSystem.OnInteractionStart = (InteractionSystem.InteractionDelegate)Delegate.Combine(interactionSystem.OnInteractionStart, new InteractionSystem.InteractionDelegate(this.OnStart));
			InteractionSystem interactionSystem2 = this.interactionSystem;
			interactionSystem2.OnInteractionPause = (InteractionSystem.InteractionDelegate)Delegate.Combine(interactionSystem2.OnInteractionPause, new InteractionSystem.InteractionDelegate(this.OnPause));
			InteractionSystem interactionSystem3 = this.interactionSystem;
			interactionSystem3.OnInteractionResume = (InteractionSystem.InteractionDelegate)Delegate.Combine(interactionSystem3.OnInteractionResume, new InteractionSystem.InteractionDelegate(this.OnDrop));
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00044EFC File Offset: 0x000430FC
		private void OnPause(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
		{
			if (effectorType != FullBodyBipedEffector.LeftHand)
			{
				return;
			}
			if (interactionObject != this.obj)
			{
				return;
			}
			this.obj.transform.parent = this.interactionSystem.transform;
			Rigidbody component = this.obj.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
			}
			this.pickUpPosition = this.obj.transform.position;
			this.pickUpRotation = this.obj.transform.rotation;
			this.holdWeight = 0f;
			this.holdWeightVel = 0f;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00044F96 File Offset: 0x00043196
		private void OnStart(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
		{
			if (effectorType != FullBodyBipedEffector.LeftHand)
			{
				return;
			}
			if (interactionObject != this.obj)
			{
				return;
			}
			this.holdPoint.rotation = this.obj.transform.rotation;
			this.RotatePivot();
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00044FD0 File Offset: 0x000431D0
		private void OnDrop(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
		{
			if (this.holding)
			{
				return;
			}
			if (interactionObject != this.obj)
			{
				return;
			}
			this.obj.transform.parent = null;
			if (this.obj.GetComponent<Rigidbody>() != null)
			{
				this.obj.GetComponent<Rigidbody>().isKinematic = false;
			}
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0004502C File Offset: 0x0004322C
		private void LateUpdate()
		{
			if (this.holding)
			{
				this.holdWeight = Mathf.SmoothDamp(this.holdWeight, 1f, ref this.holdWeightVel, this.pickUpTime);
				this.obj.transform.position = Vector3.Lerp(this.pickUpPosition, this.holdPoint.position, this.holdWeight);
				this.obj.transform.rotation = Quaternion.Lerp(this.pickUpRotation, this.holdPoint.rotation, this.holdWeight);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x000450BB File Offset: 0x000432BB
		private bool holding
		{
			get
			{
				return this.holdingLeft || this.holdingRight;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x000450CD File Offset: 0x000432CD
		private bool holdingLeft
		{
			get
			{
				return this.interactionSystem.IsPaused(FullBodyBipedEffector.LeftHand) && this.interactionSystem.GetInteractionObject(FullBodyBipedEffector.LeftHand) == this.obj;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000ACA RID: 2762 RVA: 0x000450F6 File Offset: 0x000432F6
		private bool holdingRight
		{
			get
			{
				return this.interactionSystem.IsPaused(FullBodyBipedEffector.RightHand) && this.interactionSystem.GetInteractionObject(FullBodyBipedEffector.RightHand) == this.obj;
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00045120 File Offset: 0x00043320
		private void OnDestroy()
		{
			if (this.interactionSystem == null)
			{
				return;
			}
			InteractionSystem interactionSystem = this.interactionSystem;
			interactionSystem.OnInteractionStart = (InteractionSystem.InteractionDelegate)Delegate.Remove(interactionSystem.OnInteractionStart, new InteractionSystem.InteractionDelegate(this.OnStart));
			InteractionSystem interactionSystem2 = this.interactionSystem;
			interactionSystem2.OnInteractionPause = (InteractionSystem.InteractionDelegate)Delegate.Remove(interactionSystem2.OnInteractionPause, new InteractionSystem.InteractionDelegate(this.OnPause));
			InteractionSystem interactionSystem3 = this.interactionSystem;
			interactionSystem3.OnInteractionResume = (InteractionSystem.InteractionDelegate)Delegate.Remove(interactionSystem3.OnInteractionResume, new InteractionSystem.InteractionDelegate(this.OnDrop));
		}

		// Token: 0x04000AA3 RID: 2723
		public int GUIspace;

		// Token: 0x04000AA4 RID: 2724
		public InteractionSystem interactionSystem;

		// Token: 0x04000AA5 RID: 2725
		public InteractionObject obj;

		// Token: 0x04000AA6 RID: 2726
		public Transform pivot;

		// Token: 0x04000AA7 RID: 2727
		public Transform holdPoint;

		// Token: 0x04000AA8 RID: 2728
		public float pickUpTime = 0.3f;

		// Token: 0x04000AA9 RID: 2729
		private float holdWeight;

		// Token: 0x04000AAA RID: 2730
		private float holdWeightVel;

		// Token: 0x04000AAB RID: 2731
		private Vector3 pickUpPosition;

		// Token: 0x04000AAC RID: 2732
		private Quaternion pickUpRotation;
	}
}
