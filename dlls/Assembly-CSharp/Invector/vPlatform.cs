using System;
using Invector.vCharacterController;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000371 RID: 881
	public class vPlatform : vMonoBehaviour
	{
		// Token: 0x060011D9 RID: 4569 RVA: 0x0005F0A0 File Offset: 0x0005D2A0
		private void OnDrawGizmos()
		{
			if (this.points == null || this.points.Length == 0 || this.startIndex >= this.points.Length)
			{
				return;
			}
			Transform transform = this.points[0].transform;
			Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
			if (!Application.isPlaying)
			{
				base.transform.position = this.points[this.startIndex].transform.position;
				base.transform.eulerAngles = this.points[this.startIndex].transform.eulerAngles;
			}
			foreach (vPlatform.vPlatformPoint vPlatformPoint in this.points)
			{
				if (vPlatformPoint.transform != null && vPlatformPoint.transform != transform)
				{
					Gizmos.DrawLine(transform.position, vPlatformPoint.transform.position);
					transform = vPlatformPoint.transform;
				}
			}
			foreach (vPlatform.vPlatformPoint vPlatformPoint2 in this.points)
			{
				if (vPlatformPoint2.transform)
				{
					Gizmos.matrix = Matrix4x4.TRS(vPlatformPoint2.transform.position, vPlatformPoint2.transform.rotation, base.transform.lossyScale);
					Gizmos.DrawCube(Vector3.zero, Vector3.one);
				}
			}
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x0005F1FC File Offset: 0x0005D3FC
		public void SetPause(bool value)
		{
			this.pause = value;
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x0005F208 File Offset: 0x0005D408
		private void Start()
		{
			if (this.points.Length == 0 || this.startIndex >= this.points.Length)
			{
				return;
			}
			if (this.points.Length < 2)
			{
				return;
			}
			base.transform.position = this.points[this.startIndex].transform.position;
			base.transform.eulerAngles = this.points[this.startIndex].transform.eulerAngles;
			this.oldEuler = base.transform.eulerAngles;
			int num = this.startIndex;
			if (this.startIndex + 1 < this.points.Length)
			{
				num++;
			}
			else if (this.startIndex - 1 > 0)
			{
				num--;
				this.invert = true;
			}
			this.dist = Vector3.Distance(base.transform.position, this.points[num].transform.position);
			this.targetTransform = this.points[num].transform;
			this.currentTime = (this.points[this.startIndex].useDefaultStayTime ? this.defaultStayTime : this.points[this.index].stayTime);
			this.currentSpeed = (this.points[this.startIndex].useDefaultSpeed ? this.defaultSpeed : this.points[this.index].speedToNextPoint);
			this.index = num;
			this.canMove = true;
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x0005F378 File Offset: 0x0005D578
		private void FixedUpdate()
		{
			if (this.points.Length == 0 && !this.canMove)
			{
				return;
			}
			if (this.pause)
			{
				return;
			}
			this.currentDist = Vector3.Distance(base.transform.position, this.targetTransform.position);
			if (this.currentTime <= 0f)
			{
				float num = Mathf.Clamp((100f - 100f * this.currentDist / this.dist) * 0.01f, 0f, 1f);
				base.transform.position = Vector3.MoveTowards(base.transform.position, this.targetTransform.position, this.currentSpeed * Time.deltaTime);
				if (!float.IsNaN(num) && !float.IsInfinity(num) && this.oldEuler != this.oldEuler + (this.targetTransform.eulerAngles - this.oldEuler))
				{
					base.transform.eulerAngles = Vector3.Lerp(this.oldEuler, this.targetTransform.eulerAngles, num);
				}
			}
			else
			{
				this.currentTime -= Time.fixedDeltaTime;
			}
			if (this.currentDist < 0.02f)
			{
				this.currentSpeed = (this.points[this.index].useDefaultSpeed ? this.defaultSpeed : this.points[this.index].speedToNextPoint);
				this.currentTime = (this.points[this.index].useDefaultStayTime ? this.defaultStayTime : this.points[this.index].stayTime);
				if (!this.invert)
				{
					if (this.index + 1 < this.points.Length)
					{
						this.index++;
					}
					else
					{
						this.invert = true;
					}
				}
				else if (this.index - 1 >= 0)
				{
					this.index--;
				}
				else
				{
					this.invert = false;
				}
				this.dist = Vector3.Distance(this.targetTransform.position, this.points[this.index].transform.position);
				this.targetTransform = this.points[this.index].transform;
				this.oldEuler = base.transform.eulerAngles;
			}
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x0005F5CC File Offset: 0x0005D7CC
		private void OnTriggerStay(Collider other)
		{
			if (other.transform.parent != base.transform && other.transform.CompareTag("Player") && other.GetComponent<vCharacter>() != null)
			{
				other.transform.parent = base.transform;
			}
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x0005F624 File Offset: 0x0005D824
		private void OnTriggerExit(Collider other)
		{
			if (other.transform.parent == base.transform && other.transform.CompareTag("Player"))
			{
				other.transform.parent = null;
				other.transform.eulerAngles = new Vector3(0f, other.transform.eulerAngles.y, 0f);
			}
		}

		// Token: 0x040017B2 RID: 6066
		public vPlatform.vPlatformPoint[] points;

		// Token: 0x040017B3 RID: 6067
		[Tooltip("Movement speed between points")]
		public float defaultSpeed = 1f;

		// Token: 0x040017B4 RID: 6068
		[Tooltip("Time to stay in current point")]
		public float defaultStayTime = 2f;

		// Token: 0x040017B5 RID: 6069
		[Tooltip("Index to Starting point")]
		public int startIndex;

		// Token: 0x040017B6 RID: 6070
		public bool pause;

		// Token: 0x040017B7 RID: 6071
		[HideInInspector]
		public bool canMove;

		// Token: 0x040017B8 RID: 6072
		private Vector3 oldEuler;

		// Token: 0x040017B9 RID: 6073
		private int index;

		// Token: 0x040017BA RID: 6074
		private bool invert;

		// Token: 0x040017BB RID: 6075
		private float currentTime;

		// Token: 0x040017BC RID: 6076
		private float currentSpeed;

		// Token: 0x040017BD RID: 6077
		private float dist;

		// Token: 0x040017BE RID: 6078
		private float currentDist;

		// Token: 0x040017BF RID: 6079
		private Transform targetTransform;

		// Token: 0x02000372 RID: 882
		[Serializable]
		public class vPlatformPoint
		{
			// Token: 0x040017C0 RID: 6080
			public Transform transform;

			// Token: 0x040017C1 RID: 6081
			public bool useDefaultStayTime = true;

			// Token: 0x040017C2 RID: 6082
			[vHideInInspector("useDefaultstayTime", true)]
			public float stayTime;

			// Token: 0x040017C3 RID: 6083
			public bool useDefaultSpeed = true;

			// Token: 0x040017C4 RID: 6084
			[vHideInInspector("useDefaultSpeed", true)]
			public float speedToNextPoint = 1f;
		}
	}
}
