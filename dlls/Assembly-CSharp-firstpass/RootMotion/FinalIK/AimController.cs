using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000114 RID: 276
	public class AimController : MonoBehaviour
	{
		// Token: 0x06000942 RID: 2370 RVA: 0x0003AA44 File Offset: 0x00038C44
		private void Start()
		{
			this.lastPosition = this.ik.solver.IKPosition;
			this.dir = this.ik.solver.IKPosition - this.pivot;
			this.ik.solver.target = null;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0003AA9C File Offset: 0x00038C9C
		private void LateUpdate()
		{
			if (this.target != this.lastTarget)
			{
				if (this.lastTarget == null && this.target != null && this.ik.solver.IKPositionWeight <= 0f)
				{
					this.lastPosition = this.target.position;
					this.dir = this.target.position - this.pivot;
					this.ik.solver.IKPosition = this.target.position + this.offset;
				}
				else
				{
					this.lastPosition = this.ik.solver.IKPosition;
					this.dir = this.ik.solver.IKPosition - this.pivot;
				}
				this.switchWeight = 0f;
				this.lastTarget = this.target;
			}
			float num = (this.target != null) ? this.weight : 0f;
			this.ik.solver.IKPositionWeight = Mathf.SmoothDamp(this.ik.solver.IKPositionWeight, num, ref this.weightV, this.weightSmoothTime);
			if (this.ik.solver.IKPositionWeight >= 0.999f && num > this.ik.solver.IKPositionWeight)
			{
				this.ik.solver.IKPositionWeight = 1f;
			}
			if (this.ik.solver.IKPositionWeight <= 0.001f && num < this.ik.solver.IKPositionWeight)
			{
				this.ik.solver.IKPositionWeight = 0f;
			}
			if (this.ik.solver.IKPositionWeight <= 0f)
			{
				return;
			}
			this.switchWeight = Mathf.SmoothDamp(this.switchWeight, 1f, ref this.switchWeightV, this.targetSwitchSmoothTime);
			if (this.switchWeight >= 0.999f)
			{
				this.switchWeight = 1f;
			}
			if (this.target != null)
			{
				this.ik.solver.IKPosition = Vector3.Lerp(this.lastPosition, this.target.position + this.offset, this.switchWeight);
			}
			if (this.smoothTurnTowardsTarget != this.lastSmoothTowardsTarget)
			{
				this.dir = this.ik.solver.IKPosition - this.pivot;
				this.lastSmoothTowardsTarget = this.smoothTurnTowardsTarget;
			}
			if (this.smoothTurnTowardsTarget)
			{
				Vector3 vector = this.ik.solver.IKPosition - this.pivot;
				if (this.slerpSpeed > 0f)
				{
					this.dir = Vector3.Slerp(this.dir, vector, Time.deltaTime * this.slerpSpeed);
				}
				if (this.maxRadiansDelta > 0f || this.maxMagnitudeDelta > 0f)
				{
					this.dir = Vector3.RotateTowards(this.dir, vector, Time.deltaTime * this.maxRadiansDelta, this.maxMagnitudeDelta);
				}
				if (this.smoothDampTime > 0f)
				{
					float yaw = V3Tools.GetYaw(this.dir);
					float yaw2 = V3Tools.GetYaw(vector);
					float y = Mathf.SmoothDampAngle(yaw, yaw2, ref this.yawV, this.smoothDampTime);
					float pitch = V3Tools.GetPitch(this.dir);
					float pitch2 = V3Tools.GetPitch(vector);
					float x = Mathf.SmoothDampAngle(pitch, pitch2, ref this.pitchV, this.smoothDampTime);
					float d = Mathf.SmoothDamp(this.dir.magnitude, vector.magnitude, ref this.dirMagV, this.smoothDampTime);
					this.dir = Quaternion.Euler(x, y, 0f) * Vector3.forward * d;
				}
				this.ik.solver.IKPosition = this.pivot + this.dir;
			}
			this.ApplyMinDistance();
			this.RootRotation();
			if (this.useAnimatedAimDirection)
			{
				this.ik.solver.axis = this.ik.solver.transform.InverseTransformVector(this.ik.transform.rotation * this.animatedAimDirection);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x0003AEDE File Offset: 0x000390DE
		private Vector3 pivot
		{
			get
			{
				return this.ik.transform.position + this.ik.transform.rotation * this.pivotOffsetFromRoot;
			}
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0003AF10 File Offset: 0x00039110
		private void ApplyMinDistance()
		{
			Vector3 pivot = this.pivot;
			Vector3 b = this.ik.solver.IKPosition - pivot;
			b = b.normalized * Mathf.Max(b.magnitude, this.minDistance);
			this.ik.solver.IKPosition = pivot + b;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0003AF74 File Offset: 0x00039174
		private void RootRotation()
		{
			float num = Mathf.Lerp(180f, this.maxRootAngle * this.turnToTargetMlp, this.ik.solver.IKPositionWeight);
			if (num < 180f)
			{
				Vector3 vector = Quaternion.Inverse(this.ik.transform.rotation) * (this.ik.solver.IKPosition - this.pivot);
				float num2 = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				float angle = 0f;
				if (num2 > num)
				{
					angle = num2 - num;
					if (!this.turningToTarget && this.turnToTarget)
					{
						base.StartCoroutine(this.TurnToTarget());
					}
				}
				if (num2 < -num)
				{
					angle = num2 + num;
					if (!this.turningToTarget && this.turnToTarget)
					{
						base.StartCoroutine(this.TurnToTarget());
					}
				}
				this.ik.transform.rotation = Quaternion.AngleAxis(angle, this.ik.transform.up) * this.ik.transform.rotation;
			}
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0003B08E File Offset: 0x0003928E
		private IEnumerator TurnToTarget()
		{
			this.turningToTarget = true;
			while (this.turnToTargetMlp > 0f)
			{
				this.turnToTargetMlp = Mathf.SmoothDamp(this.turnToTargetMlp, 0f, ref this.turnToTargetMlpV, this.turnToTargetTime);
				if (this.turnToTargetMlp < 0.01f)
				{
					this.turnToTargetMlp = 0f;
				}
				yield return null;
			}
			this.turnToTargetMlp = 1f;
			this.turningToTarget = false;
			yield break;
		}

		// Token: 0x04000863 RID: 2147
		[Tooltip("Reference to the AimIK component.")]
		public AimIK ik;

		// Token: 0x04000864 RID: 2148
		[Tooltip("Master weight of the IK solver.")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000865 RID: 2149
		[Header("Target Smoothing")]
		[Tooltip("The target to aim at. Do not use the Target transform that is assigned to AimIK. Set to null if you wish to stop aiming.")]
		public Transform target;

		// Token: 0x04000866 RID: 2150
		[Tooltip("The time it takes to switch targets.")]
		public float targetSwitchSmoothTime = 0.3f;

		// Token: 0x04000867 RID: 2151
		[Tooltip("The time it takes to blend in/out of AimIK weight.")]
		public float weightSmoothTime = 0.3f;

		// Token: 0x04000868 RID: 2152
		[Header("Turning Towards The Target")]
		[Tooltip("Enables smooth turning towards the target according to the parameters under this header.")]
		public bool smoothTurnTowardsTarget = true;

		// Token: 0x04000869 RID: 2153
		[Tooltip("Speed of turning towards the target using Vector3.RotateTowards.")]
		public float maxRadiansDelta = 3f;

		// Token: 0x0400086A RID: 2154
		[Tooltip("Speed of moving towards the target using Vector3.RotateTowards.")]
		public float maxMagnitudeDelta = 3f;

		// Token: 0x0400086B RID: 2155
		[Tooltip("Speed of slerping towards the target.")]
		public float slerpSpeed = 3f;

		// Token: 0x0400086C RID: 2156
		[Tooltip("Smoothing time for turning towards the yaw and pitch of the target using Mathf.SmoothDampAngle. Value of 0 means smooth damping is disabled.")]
		public float smoothDampTime;

		// Token: 0x0400086D RID: 2157
		[Tooltip("The position of the pivot that the aim target is rotated around relative to the root of the character.")]
		public Vector3 pivotOffsetFromRoot = Vector3.up;

		// Token: 0x0400086E RID: 2158
		[Tooltip("Minimum distance of aiming from the first bone. Keeps the solver from failing if the target is too close.")]
		public float minDistance = 1f;

		// Token: 0x0400086F RID: 2159
		[Tooltip("Offset applied to the target in world space. Convenient for scripting aiming inaccuracy.")]
		public Vector3 offset;

		// Token: 0x04000870 RID: 2160
		[Header("RootRotation")]
		[Tooltip("Character root will be rotate around the Y axis to keep root forward within this angle from the aiming direction.")]
		[Range(0f, 180f)]
		public float maxRootAngle = 45f;

		// Token: 0x04000871 RID: 2161
		[Tooltip("If enabled, aligns the root forward to target direction after 'Max Root Angle' has been exceeded.")]
		public bool turnToTarget;

		// Token: 0x04000872 RID: 2162
		[Tooltip("The time of turning towards the target direction if 'Max Root Angle has been exceeded and 'Turn To Target' is enabled.")]
		public float turnToTargetTime = 0.2f;

		// Token: 0x04000873 RID: 2163
		[Header("Mode")]
		[Tooltip("If true, AimIK will consider whatever the current direction of the weapon to be the forward aiming direction and work additively on top of that. This enables you to use recoil and reloading animations seamlessly with AimIK. Adjust the Vector3 value below if the weapon is not aiming perfectly forward in the aiming animation clip.")]
		public bool useAnimatedAimDirection;

		// Token: 0x04000874 RID: 2164
		[Tooltip("The direction of the animated weapon aiming in character space. Tweak this value to adjust the aiming. 'Use Animated Aim Direction' must be enabled for this property to work.")]
		public Vector3 animatedAimDirection = Vector3.forward;

		// Token: 0x04000875 RID: 2165
		private Transform lastTarget;

		// Token: 0x04000876 RID: 2166
		private float switchWeight;

		// Token: 0x04000877 RID: 2167
		private float switchWeightV;

		// Token: 0x04000878 RID: 2168
		private float weightV;

		// Token: 0x04000879 RID: 2169
		private Vector3 lastPosition;

		// Token: 0x0400087A RID: 2170
		private Vector3 dir;

		// Token: 0x0400087B RID: 2171
		private bool lastSmoothTowardsTarget;

		// Token: 0x0400087C RID: 2172
		private bool turningToTarget;

		// Token: 0x0400087D RID: 2173
		private float turnToTargetMlp = 1f;

		// Token: 0x0400087E RID: 2174
		private float turnToTargetMlpV;

		// Token: 0x0400087F RID: 2175
		private float yawV;

		// Token: 0x04000880 RID: 2176
		private float pitchV;

		// Token: 0x04000881 RID: 2177
		private float dirMagV;
	}
}
