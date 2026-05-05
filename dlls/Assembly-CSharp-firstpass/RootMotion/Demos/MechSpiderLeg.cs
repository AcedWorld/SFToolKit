using System;
using System.Collections;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000150 RID: 336
	public class MechSpiderLeg : MonoBehaviour
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00041243 File Offset: 0x0003F443
		public bool isStepping
		{
			get
			{
				return this.stepProgress < 1f;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x00041252 File Offset: 0x0003F452
		// (set) Token: 0x06000A45 RID: 2629 RVA: 0x00041264 File Offset: 0x0003F464
		public Vector3 position
		{
			get
			{
				return this.ik.GetIKSolver().GetIKPosition();
			}
			set
			{
				this.ik.GetIKSolver().SetIKPosition(value);
			}
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00041278 File Offset: 0x0003F478
		private void Awake()
		{
			this.ik = base.GetComponent<IK>();
			if (this.foot != null)
			{
				if (this.footUpAxis == Vector3.zero)
				{
					this.footUpAxis = Quaternion.Inverse(this.foot.rotation) * Vector3.up;
				}
				this.lastFootLocalRotation = this.foot.localRotation;
				IKSolver iksolver = this.ik.GetIKSolver();
				iksolver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterIK));
			}
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00041310 File Offset: 0x0003F510
		private void AfterIK()
		{
			if (this.foot == null)
			{
				return;
			}
			this.foot.localRotation = this.lastFootLocalRotation;
			this.smoothHitNormal = Vector3.Slerp(this.smoothHitNormal, this.hit.normal, Time.deltaTime * this.footRotationSpeed);
			Quaternion lhs = Quaternion.FromToRotation(this.foot.rotation * this.footUpAxis, this.smoothHitNormal);
			this.foot.rotation = lhs * this.foot.rotation;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000413A4 File Offset: 0x0003F5A4
		private void Start()
		{
			this.stepProgress = 1f;
			this.hit = default(RaycastHit);
			IKSolver.Point[] points = this.ik.GetIKSolver().GetPoints();
			this.position = points[points.Length - 1].transform.position;
			this.lastStepPosition = this.position;
			this.hit.point = this.position;
			this.defaultPosition = this.mechSpider.transform.InverseTransformPoint(this.position + this.offset * this.mechSpider.scale);
			base.StartCoroutine(this.Step(this.position, this.position));
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00041460 File Offset: 0x0003F660
		private Vector3 GetStepTarget(out bool stepFound, float focus, float distance)
		{
			stepFound = false;
			Vector3 a = this.mechSpider.transform.TransformPoint(this.defaultPosition) + this.mechSpider.velocity * this.velocityPrediction;
			Vector3 vector = this.mechSpider.transform.up;
			Vector3 rhs = this.mechSpider.body.position - this.position;
			Vector3 axis = Vector3.Cross(vector, rhs);
			vector = Quaternion.AngleAxis(focus, axis) * vector;
			if (Physics.Raycast(a + vector * this.mechSpider.raycastHeight * this.mechSpider.scale, -vector, out this.hit, this.mechSpider.raycastHeight * this.mechSpider.scale + distance, this.mechSpider.raycastLayers))
			{
				stepFound = true;
			}
			return this.hit.point + this.hit.normal * this.footHeight * this.mechSpider.scale;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00041580 File Offset: 0x0003F780
		private void UpdatePosition(float distance)
		{
			Vector3 up = this.mechSpider.transform.up;
			if (Physics.Raycast(this.lastStepPosition + up * this.mechSpider.raycastHeight * this.mechSpider.scale, -up, out this.hit, this.mechSpider.raycastHeight * this.mechSpider.scale + distance, this.mechSpider.raycastLayers))
			{
				this.position = this.hit.point + this.hit.normal * this.footHeight * this.mechSpider.scale;
			}
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00041644 File Offset: 0x0003F844
		private void Update()
		{
			this.UpdatePosition(this.mechSpider.raycastDistance * this.mechSpider.scale);
			if (this.isStepping)
			{
				return;
			}
			if (Time.time < this.lastStepTime + this.minDelay)
			{
				return;
			}
			if (this.unSync != null && this.unSync.isStepping)
			{
				return;
			}
			bool flag = false;
			Vector3 stepTarget = this.GetStepTarget(out flag, this.raycastFocus, this.mechSpider.raycastDistance * this.mechSpider.scale);
			if (!flag)
			{
				stepTarget = this.GetStepTarget(out flag, -this.raycastFocus, this.mechSpider.raycastDistance * 3f * this.mechSpider.scale);
			}
			if (!flag)
			{
				return;
			}
			if (Vector3.Distance(this.position, stepTarget) < this.maxOffset * this.mechSpider.scale * Random.Range(0.9f, 1.2f))
			{
				return;
			}
			base.StopAllCoroutines();
			base.StartCoroutine(this.Step(this.position, stepTarget));
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0004174F File Offset: 0x0003F94F
		private IEnumerator Step(Vector3 stepStartPosition, Vector3 targetPosition)
		{
			this.stepProgress = 0f;
			while (this.stepProgress < 1f)
			{
				this.stepProgress += Time.deltaTime * this.stepSpeed;
				this.position = Vector3.Lerp(stepStartPosition, targetPosition, this.stepProgress);
				this.position += this.mechSpider.transform.up * this.yOffset.Evaluate(this.stepProgress) * this.mechSpider.scale;
				this.lastStepPosition = this.position;
				yield return null;
			}
			this.position = targetPosition;
			this.lastStepPosition = this.position;
			if (this.sand != null)
			{
				this.sand.transform.position = this.position - this.mechSpider.transform.up * this.footHeight * this.mechSpider.scale;
				this.sand.Emit(20);
			}
			this.lastStepTime = Time.time;
			yield break;
		}

		// Token: 0x040009C7 RID: 2503
		public MechSpider mechSpider;

		// Token: 0x040009C8 RID: 2504
		public MechSpiderLeg unSync;

		// Token: 0x040009C9 RID: 2505
		public Vector3 offset;

		// Token: 0x040009CA RID: 2506
		public float minDelay = 0.2f;

		// Token: 0x040009CB RID: 2507
		public float maxOffset = 1f;

		// Token: 0x040009CC RID: 2508
		public float stepSpeed = 5f;

		// Token: 0x040009CD RID: 2509
		public float footHeight = 0.15f;

		// Token: 0x040009CE RID: 2510
		public float velocityPrediction = 0.2f;

		// Token: 0x040009CF RID: 2511
		public float raycastFocus = 0.1f;

		// Token: 0x040009D0 RID: 2512
		public AnimationCurve yOffset;

		// Token: 0x040009D1 RID: 2513
		public Transform foot;

		// Token: 0x040009D2 RID: 2514
		public Vector3 footUpAxis;

		// Token: 0x040009D3 RID: 2515
		public float footRotationSpeed = 10f;

		// Token: 0x040009D4 RID: 2516
		public ParticleSystem sand;

		// Token: 0x040009D5 RID: 2517
		private IK ik;

		// Token: 0x040009D6 RID: 2518
		private float stepProgress = 1f;

		// Token: 0x040009D7 RID: 2519
		private float lastStepTime;

		// Token: 0x040009D8 RID: 2520
		private Vector3 defaultPosition;

		// Token: 0x040009D9 RID: 2521
		private RaycastHit hit;

		// Token: 0x040009DA RID: 2522
		private Quaternion lastFootLocalRotation;

		// Token: 0x040009DB RID: 2523
		private Vector3 smoothHitNormal = Vector3.up;

		// Token: 0x040009DC RID: 2524
		private Vector3 lastStepPosition;
	}
}
