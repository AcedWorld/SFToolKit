using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000116 RID: 278
	public class AimPoser : MonoBehaviour
	{
		// Token: 0x0600094F RID: 2383 RVA: 0x0003B200 File Offset: 0x00039400
		public AimPoser.Pose GetPose(Vector3 localDirection)
		{
			if (this.poses.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < this.poses.Length - 1; i++)
			{
				if (this.poses[i].IsInDirection(localDirection))
				{
					return this.poses[i];
				}
			}
			return this.poses[this.poses.Length - 1];
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0003B258 File Offset: 0x00039458
		public void SetPoseActive(AimPoser.Pose pose)
		{
			for (int i = 0; i < this.poses.Length; i++)
			{
				this.poses[i].SetAngleBuffer((this.poses[i] == pose) ? this.angleBuffer : 0f);
			}
		}

		// Token: 0x04000885 RID: 2181
		public float angleBuffer = 5f;

		// Token: 0x04000886 RID: 2182
		public AimPoser.Pose[] poses = new AimPoser.Pose[0];

		// Token: 0x02000117 RID: 279
		[Serializable]
		public class Pose
		{
			// Token: 0x06000952 RID: 2386 RVA: 0x0003B2BC File Offset: 0x000394BC
			public bool IsInDirection(Vector3 d)
			{
				if (this.direction == Vector3.zero)
				{
					return false;
				}
				if (this.yaw <= 0f || this.pitch <= 0f)
				{
					return false;
				}
				if (this.yaw < 180f)
				{
					Vector3 forward = new Vector3(this.direction.x, 0f, this.direction.z);
					if (forward == Vector3.zero)
					{
						forward = Vector3.forward;
					}
					if (Vector3.Angle(new Vector3(d.x, 0f, d.z), forward) > this.yaw + this.angleBuffer)
					{
						return false;
					}
				}
				if (this.pitch >= 180f)
				{
					return true;
				}
				float num = Vector3.Angle(Vector3.up, this.direction);
				return Mathf.Abs(Vector3.Angle(Vector3.up, d) - num) < this.pitch + this.angleBuffer;
			}

			// Token: 0x06000953 RID: 2387 RVA: 0x0003B3A9 File Offset: 0x000395A9
			public void SetAngleBuffer(float value)
			{
				this.angleBuffer = value;
			}

			// Token: 0x04000887 RID: 2183
			public bool visualize = true;

			// Token: 0x04000888 RID: 2184
			public string name;

			// Token: 0x04000889 RID: 2185
			public Vector3 direction;

			// Token: 0x0400088A RID: 2186
			public float yaw = 75f;

			// Token: 0x0400088B RID: 2187
			public float pitch = 45f;

			// Token: 0x0400088C RID: 2188
			private float angleBuffer;
		}
	}
}
