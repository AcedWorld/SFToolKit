using System;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x020003A0 RID: 928
	public class vLookTarget : MonoBehaviour
	{
		// Token: 0x060012A9 RID: 4777 RVA: 0x00062756 File Offset: 0x00060956
		private void OnDrawGizmosSelected()
		{
			this.DrawBox();
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x00062760 File Offset: 0x00060960
		private void Start()
		{
			int layer = LayerMask.NameToLayer("HeadTrack");
			base.gameObject.layer = layer;
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x060012AB RID: 4779 RVA: 0x00062784 File Offset: 0x00060984
		public Vector3 lookPoint
		{
			get
			{
				if (this.lookPointTarget)
				{
					return this.lookPointTarget.position;
				}
				return base.transform.TransformPoint(this.centerArea);
			}
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x000627B0 File Offset: 0x000609B0
		private void DrawBox()
		{
			Gizmos.color = new Color(1f, 0f, 0f, 1f);
			Gizmos.DrawSphere(this.lookPoint, 0.05f);
			if (this.visibleCheckType == vLookTarget.VisibleCheckType.BoxCast)
			{
				float x = base.transform.lossyScale.x * this.sizeArea.x;
				float y = base.transform.lossyScale.y * this.sizeArea.y;
				float z = base.transform.lossyScale.z * this.sizeArea.z;
				float x2 = base.transform.lossyScale.x * this.centerArea.x;
				float y2 = base.transform.lossyScale.y * this.centerArea.y;
				float z2 = base.transform.lossyScale.z * this.centerArea.z;
				Gizmos.matrix = Matrix4x4.TRS(base.transform.position + new Vector3(x2, y2, z2), base.transform.rotation, new Vector3(x, y, z) * 2f);
				Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
				Gizmos.DrawCube(Vector3.zero, Vector3.one);
				Gizmos.color = new Color(0f, 1f, 0f, 1f);
				Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
				return;
			}
			if (this.visibleCheckType == vLookTarget.VisibleCheckType.SingleCast)
			{
				Vector3 center = base.transform.TransformPoint(this.centerArea);
				Gizmos.color = new Color(0f, 1f, 0f, 1f);
				Gizmos.DrawSphere(center, 0.05f);
			}
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x00062985 File Offset: 0x00060B85
		internal void EnterLook(vHeadTrack vHeadTrack)
		{
			this.onEnterLook.Invoke(vHeadTrack);
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x00062993 File Offset: 0x00060B93
		internal void ExitLook(vHeadTrack vHeadTrack)
		{
			this.onExitLook.Invoke(vHeadTrack);
		}

		// Token: 0x04001869 RID: 6249
		public bool ignoreHeadTrackAngle;

		// Token: 0x0400186A RID: 6250
		[Header("Set this to assign a different point to look")]
		public Transform lookPointTarget;

		// Token: 0x0400186B RID: 6251
		[Header("Area to check if is visible")]
		public Vector3 centerArea = Vector3.zero;

		// Token: 0x0400186C RID: 6252
		public Vector3 sizeArea = Vector3.one;

		// Token: 0x0400186D RID: 6253
		public bool useLimitToDetect = true;

		// Token: 0x0400186E RID: 6254
		public float minDistanceToDetect = 2f;

		// Token: 0x0400186F RID: 6255
		public vLookTarget.VisibleCheckType visibleCheckType;

		// Token: 0x04001870 RID: 6256
		[Tooltip("use this to turn the object undetectable")]
		public bool HideObject;

		// Token: 0x04001871 RID: 6257
		public vLookTarget.OnLookEvent onEnterLook;

		// Token: 0x04001872 RID: 6258
		public vLookTarget.OnLookEvent onExitLook;

		// Token: 0x020003A1 RID: 929
		[Serializable]
		public class OnLookEvent : UnityEvent<vHeadTrack>
		{
		}

		// Token: 0x020003A2 RID: 930
		public enum VisibleCheckType
		{
			// Token: 0x04001874 RID: 6260
			None,
			// Token: 0x04001875 RID: 6261
			SingleCast,
			// Token: 0x04001876 RID: 6262
			BoxCast
		}
	}
}
