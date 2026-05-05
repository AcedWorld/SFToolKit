using System;
using UnityEngine;
using UnityEngine.AI;

namespace RootMotion.Demos
{
	// Token: 0x020001C8 RID: 456
	[Serializable]
	public class Navigator
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x0004B839 File Offset: 0x00049A39
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x0004B841 File Offset: 0x00049A41
		public Vector3 normalizedDeltaPosition { get; private set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x0004B84A File Offset: 0x00049A4A
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x0004B852 File Offset: 0x00049A52
		public Navigator.State state { get; private set; }

		// Token: 0x06000C28 RID: 3112 RVA: 0x0004B85C File Offset: 0x00049A5C
		public void Initiate(Transform transform)
		{
			this.transform = transform;
			this.path = new NavMeshPath();
			this.initiated = true;
			this.cornerIndex = 0;
			this.corners = new Vector3[0];
			this.state = Navigator.State.Idle;
			this.lastTargetPosition = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0004B8B8 File Offset: 0x00049AB8
		public void Update(Vector3 targetPosition)
		{
			if (!this.initiated)
			{
				Debug.LogError("Trying to update an uninitiated Navigator.");
				return;
			}
			switch (this.state)
			{
			case Navigator.State.Idle:
				if (this.activeTargetSeeking && Time.time > this.nextPathTime)
				{
					this.CalculatePath(targetPosition);
				}
				break;
			case Navigator.State.Seeking:
				this.normalizedDeltaPosition = Vector3.zero;
				if (this.path.status == NavMeshPathStatus.PathComplete)
				{
					this.corners = this.path.corners;
					this.cornerIndex = 0;
					if (this.corners.Length == 0)
					{
						Debug.LogWarning("Zero Corner Path", this.transform);
						this.Stop();
					}
					else
					{
						this.state = Navigator.State.OnPath;
					}
				}
				if (this.path.status == NavMeshPathStatus.PathPartial)
				{
					Debug.LogWarning("Path Partial", this.transform);
				}
				if (this.path.status == NavMeshPathStatus.PathInvalid)
				{
					Debug.LogWarning("Path Invalid", this.transform);
					return;
				}
				break;
			case Navigator.State.OnPath:
				if (this.activeTargetSeeking && Time.time > this.nextPathTime && this.HorDistance(targetPosition, this.lastTargetPosition) > this.recalculateOnPathDistance)
				{
					this.CalculatePath(targetPosition);
					return;
				}
				if (this.cornerIndex < this.corners.Length)
				{
					Vector3 a = this.corners[this.cornerIndex] - this.transform.position;
					a.y = 0f;
					float magnitude = a.magnitude;
					if (magnitude > 0f)
					{
						this.normalizedDeltaPosition = a / a.magnitude;
					}
					else
					{
						this.normalizedDeltaPosition = Vector3.zero;
					}
					if (magnitude < this.cornerRadius)
					{
						this.cornerIndex++;
						if (this.cornerIndex >= this.corners.Length)
						{
							this.Stop();
							return;
						}
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0004BA75 File Offset: 0x00049C75
		private void CalculatePath(Vector3 targetPosition)
		{
			if (this.Find(targetPosition))
			{
				this.lastTargetPosition = targetPosition;
				this.state = Navigator.State.Seeking;
			}
			else
			{
				this.Stop();
			}
			this.nextPathTime = Time.time + this.nextPathInterval;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0004BAA8 File Offset: 0x00049CA8
		private bool Find(Vector3 targetPosition)
		{
			if (this.HorDistance(this.transform.position, targetPosition) < this.cornerRadius * 2f)
			{
				return false;
			}
			if (NavMesh.CalculatePath(this.transform.position, targetPosition, -1, this.path))
			{
				return true;
			}
			NavMeshHit navMeshHit = default(NavMeshHit);
			return NavMesh.SamplePosition(targetPosition, out navMeshHit, this.maxSampleDistance, -1) && NavMesh.CalculatePath(this.transform.position, navMeshHit.position, -1, this.path);
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0004BB2F File Offset: 0x00049D2F
		private void Stop()
		{
			this.state = Navigator.State.Idle;
			this.normalizedDeltaPosition = Vector3.zero;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0004BB43 File Offset: 0x00049D43
		private float HorDistance(Vector3 p1, Vector3 p2)
		{
			return Vector2.Distance(new Vector2(p1.x, p1.z), new Vector2(p2.x, p2.z));
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0004BB6C File Offset: 0x00049D6C
		public void Visualize()
		{
			if (this.state == Navigator.State.Idle)
			{
				Gizmos.color = Color.gray;
			}
			if (this.state == Navigator.State.Seeking)
			{
				Gizmos.color = Color.red;
			}
			if (this.state == Navigator.State.OnPath)
			{
				Gizmos.color = Color.green;
			}
			if (this.corners.Length != 0 && this.state == Navigator.State.OnPath && this.cornerIndex == 0)
			{
				Gizmos.DrawLine(this.transform.position, this.corners[0]);
			}
			for (int i = 0; i < this.corners.Length; i++)
			{
				Gizmos.DrawSphere(this.corners[i], 0.1f);
			}
			if (this.corners.Length > 1)
			{
				for (int j = 0; j < this.corners.Length - 1; j++)
				{
					Gizmos.DrawLine(this.corners[j], this.corners[j + 1]);
				}
			}
			Gizmos.color = Color.white;
		}

		// Token: 0x04000C84 RID: 3204
		[Tooltip("Should this Navigator be actively seeking a path.")]
		public bool activeTargetSeeking;

		// Token: 0x04000C85 RID: 3205
		[Tooltip("Increase this value if the character starts running in a circle, not able to reach the corner because of a too large turning radius.")]
		public float cornerRadius = 0.5f;

		// Token: 0x04000C86 RID: 3206
		[Tooltip("Recalculate path if target position has moved by this distance from the position it was at when the path was originally calculated")]
		public float recalculateOnPathDistance = 1f;

		// Token: 0x04000C87 RID: 3207
		[Tooltip("Sample within this distance from sourcePosition.")]
		public float maxSampleDistance = 5f;

		// Token: 0x04000C88 RID: 3208
		[Tooltip("Interval of updating the path")]
		public float nextPathInterval = 3f;

		// Token: 0x04000C8B RID: 3211
		private Transform transform;

		// Token: 0x04000C8C RID: 3212
		private int cornerIndex;

		// Token: 0x04000C8D RID: 3213
		private Vector3[] corners = new Vector3[0];

		// Token: 0x04000C8E RID: 3214
		private NavMeshPath path;

		// Token: 0x04000C8F RID: 3215
		private Vector3 lastTargetPosition;

		// Token: 0x04000C90 RID: 3216
		private bool initiated;

		// Token: 0x04000C91 RID: 3217
		private float nextPathTime;

		// Token: 0x020001C9 RID: 457
		public enum State
		{
			// Token: 0x04000C93 RID: 3219
			Idle,
			// Token: 0x04000C94 RID: 3220
			Seeking,
			// Token: 0x04000C95 RID: 3221
			OnPath
		}
	}
}
