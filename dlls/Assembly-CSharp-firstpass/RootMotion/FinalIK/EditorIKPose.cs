using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200011F RID: 287
	[CreateAssetMenu(fileName = "Editor IK Pose", menuName = "Final IK/Editor IK Pose", order = 1)]
	public class EditorIKPose : ScriptableObject
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0003BE5D File Offset: 0x0003A05D
		public bool poseStored
		{
			get
			{
				return this.localPositions.Length != 0;
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0003BE6C File Offset: 0x0003A06C
		public void Store(Transform[] T)
		{
			this.localPositions = new Vector3[T.Length];
			this.localRotations = new Quaternion[T.Length];
			for (int i = 1; i < T.Length; i++)
			{
				this.localPositions[i] = T[i].localPosition;
				this.localRotations[i] = T[i].localRotation;
			}
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0003BECC File Offset: 0x0003A0CC
		public bool Restore(Transform[] T)
		{
			if (this.localPositions.Length != T.Length)
			{
				Debug.LogError("Can not restore pose (unmatched bone count). Please stop the solver and click on 'Store Default Pose' if you have made changes to character hierarchy.");
				return false;
			}
			for (int i = 1; i < T.Length; i++)
			{
				T[i].localPosition = this.localPositions[i];
				T[i].localRotation = this.localRotations[i];
			}
			return true;
		}

		// Token: 0x040008A9 RID: 2217
		public Vector3[] localPositions = new Vector3[0];

		// Token: 0x040008AA RID: 2218
		public Quaternion[] localRotations = new Quaternion[0];
	}
}
