using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000BC RID: 188
	public class FBBIKHeadEffector : MonoBehaviour
	{
		// Token: 0x060005C1 RID: 1473 RVA: 0x000218B4 File Offset: 0x0001FAB4
		private void Start()
		{
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPreRead = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreRead, new IKSolver.UpdateDelegate(this.OnPreRead));
			IKSolverFullBodyBiped solver2 = this.ik.solver;
			solver2.OnPreIteration = (IKSolver.IterationDelegate)Delegate.Combine(solver2.OnPreIteration, new IKSolver.IterationDelegate(this.Iterate));
			IKSolverFullBodyBiped solver3 = this.ik.solver;
			solver3.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver3.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
			IKSolverFullBodyBiped solver4 = this.ik.solver;
			solver4.OnStoreDefaultLocalState = (IKSolver.UpdateDelegate)Delegate.Combine(solver4.OnStoreDefaultLocalState, new IKSolver.UpdateDelegate(this.OnStoreDefaultLocalState));
			IKSolverFullBodyBiped solver5 = this.ik.solver;
			solver5.OnFixTransforms = (IKSolver.UpdateDelegate)Delegate.Combine(solver5.OnFixTransforms, new IKSolver.UpdateDelegate(this.OnFixTransforms));
			this.OnStoreDefaultLocalState();
			this.headRotationRelativeToRoot = Quaternion.Inverse(this.ik.references.root.rotation) * this.ik.references.head.rotation;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x000219E0 File Offset: 0x0001FBE0
		private void OnStoreDefaultLocalState()
		{
			foreach (FBBIKHeadEffector.BendBone bendBone in this.bendBones)
			{
				if (bendBone != null)
				{
					bendBone.StoreDefaultLocalState();
				}
			}
			this.ccdDefaultLocalRotations = new Quaternion[this.CCDBones.Length];
			for (int j = 0; j < this.CCDBones.Length; j++)
			{
				if (this.CCDBones[j] != null)
				{
					this.ccdDefaultLocalRotations[j] = this.CCDBones[j].localRotation;
				}
			}
			this.headLocalPosition = this.ik.references.head.localPosition;
			this.headLocalRotation = this.ik.references.head.localRotation;
			this.stretchLocalPositions = new Vector3[this.stretchBones.Length];
			this.stretchLocalRotations = new Quaternion[this.stretchBones.Length];
			for (int k = 0; k < this.stretchBones.Length; k++)
			{
				if (this.stretchBones[k] != null)
				{
					this.stretchLocalPositions[k] = this.stretchBones[k].localPosition;
					this.stretchLocalRotations[k] = this.stretchBones[k].localRotation;
				}
			}
			this.chestLocalPositions = new Vector3[this.chestBones.Length];
			this.chestLocalRotations = new Quaternion[this.chestBones.Length];
			for (int l = 0; l < this.chestBones.Length; l++)
			{
				if (this.chestBones[l] != null)
				{
					this.chestLocalPositions[l] = this.chestBones[l].localPosition;
					this.chestLocalRotations[l] = this.chestBones[l].localRotation;
				}
			}
			this.bendBonesCount = this.bendBones.Length;
			this.ccdBonesCount = this.CCDBones.Length;
			this.stretchBonesCount = this.stretchBones.Length;
			this.chestBonesCount = this.chestBones.Length;
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00021BD4 File Offset: 0x0001FDD4
		private void OnFixTransforms()
		{
			if (!base.enabled)
			{
				return;
			}
			foreach (FBBIKHeadEffector.BendBone bendBone in this.bendBones)
			{
				if (bendBone != null)
				{
					bendBone.FixTransforms();
				}
			}
			for (int j = 0; j < this.CCDBones.Length; j++)
			{
				if (this.CCDBones[j] != null)
				{
					this.CCDBones[j].localRotation = this.ccdDefaultLocalRotations[j];
				}
			}
			this.ik.references.head.localPosition = this.headLocalPosition;
			this.ik.references.head.localRotation = this.headLocalRotation;
			for (int k = 0; k < this.stretchBones.Length; k++)
			{
				if (this.stretchBones[k] != null)
				{
					this.stretchBones[k].localPosition = this.stretchLocalPositions[k];
					this.stretchBones[k].localRotation = this.stretchLocalRotations[k];
				}
			}
			for (int l = 0; l < this.chestBones.Length; l++)
			{
				if (this.chestBones[l] != null)
				{
					this.chestBones[l].localPosition = this.chestLocalPositions[l];
					this.chestBones[l].localRotation = this.chestLocalRotations[l];
				}
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00021D3C File Offset: 0x0001FF3C
		private void OnPreRead()
		{
			if (!base.enabled)
			{
				return;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			if (this.ik.solver.iterations == 0)
			{
				return;
			}
			this.ik.solver.FABRIKPass = this.handsPullBody;
			if (this.bendBonesCount != this.bendBones.Length || this.ccdBonesCount != this.CCDBones.Length || this.stretchBonesCount != this.stretchBones.Length || this.chestBonesCount != this.chestBones.Length)
			{
				this.OnStoreDefaultLocalState();
			}
			this.ChestDirection();
			this.SpineBend();
			this.CCDPass();
			this.offset = base.transform.position - this.ik.references.head.position;
			this.shoulderDist = Vector3.Distance(this.ik.references.leftUpperArm.position, this.ik.references.rightUpperArm.position);
			this.leftShoulderDist = Vector3.Distance(this.ik.references.head.position, this.ik.references.leftUpperArm.position);
			this.rightShoulderDist = Vector3.Distance(this.ik.references.head.position, this.ik.references.rightUpperArm.position);
			this.headToBody = this.ik.solver.rootNode.position - this.ik.references.head.position;
			this.headToLeftThigh = this.ik.references.leftThigh.position - this.ik.references.head.position;
			this.headToRightThigh = this.ik.references.rightThigh.position - this.ik.references.head.position;
			this.leftShoulderPos = this.ik.references.leftUpperArm.position + this.offset * this.bodyWeight;
			this.rightShoulderPos = this.ik.references.rightUpperArm.position + this.offset * this.bodyWeight;
			this.chestRotation = Quaternion.LookRotation(this.ik.references.head.position - this.ik.references.leftUpperArm.position, this.ik.references.rightUpperArm.position - this.ik.references.leftUpperArm.position);
			if (this.OnPostHeadEffectorFK != null)
			{
				this.OnPostHeadEffectorFK();
			}
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00022028 File Offset: 0x00020228
		private void SpineBend()
		{
			float num = this.bendWeight * this.ik.solver.IKPositionWeight;
			if (num <= 0f)
			{
				return;
			}
			if (this.bendBones.Length == 0)
			{
				return;
			}
			Quaternion quaternion = base.transform.rotation * Quaternion.Inverse(this.ik.references.root.rotation * this.headRotationRelativeToRoot);
			quaternion = QuaTools.ClampRotation(quaternion, this.bodyClampWeight, 2);
			float num2 = 1f / (float)this.bendBones.Length;
			for (int i = 0; i < this.bendBones.Length; i++)
			{
				if (this.bendBones[i].transform != null)
				{
					this.bendBones[i].transform.rotation = Quaternion.Lerp(Quaternion.identity, quaternion, num2 * this.bendBones[i].weight * num) * this.bendBones[i].transform.rotation;
				}
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00022124 File Offset: 0x00020324
		private void CCDPass()
		{
			float num = this.CCDWeight * this.ik.solver.IKPositionWeight;
			if (num <= 0f)
			{
				return;
			}
			for (int i = this.CCDBones.Length - 1; i > -1; i--)
			{
				Quaternion quaternion = Quaternion.FromToRotation(this.ik.references.head.position - this.CCDBones[i].position, base.transform.position - this.CCDBones[i].position) * this.CCDBones[i].rotation;
				float num2 = Mathf.Lerp((float)((this.CCDBones.Length - i) / this.CCDBones.Length), 1f, this.roll);
				float num3 = Quaternion.Angle(Quaternion.identity, quaternion);
				num3 = Mathf.Lerp(0f, num3, (this.damper - num3) / this.damper);
				this.CCDBones[i].rotation = Quaternion.RotateTowards(this.CCDBones[i].rotation, quaternion, num3 * num * num2);
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00022240 File Offset: 0x00020440
		private void Iterate(int iteration)
		{
			if (!base.enabled)
			{
				return;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			if (this.ik.solver.iterations == 0)
			{
				return;
			}
			this.leftShoulderPos = base.transform.position + (this.leftShoulderPos - base.transform.position).normalized * this.leftShoulderDist;
			this.rightShoulderPos = base.transform.position + (this.rightShoulderPos - base.transform.position).normalized * this.rightShoulderDist;
			this.Solve(ref this.leftShoulderPos, ref this.rightShoulderPos, this.shoulderDist);
			this.LerpSolverPosition(this.ik.solver.leftShoulderEffector, this.leftShoulderPos, this.positionWeight * this.ik.solver.IKPositionWeight, this.ik.solver.leftShoulderEffector.positionOffset);
			this.LerpSolverPosition(this.ik.solver.rightShoulderEffector, this.rightShoulderPos, this.positionWeight * this.ik.solver.IKPositionWeight, this.ik.solver.rightShoulderEffector.positionOffset);
			Quaternion to = Quaternion.LookRotation(base.transform.position - this.leftShoulderPos, this.rightShoulderPos - this.leftShoulderPos);
			Quaternion quaternion = QuaTools.FromToRotation(this.chestRotation, to);
			Vector3 b = quaternion * this.headToBody;
			this.LerpSolverPosition(this.ik.solver.bodyEffector, base.transform.position + b, this.positionWeight * this.ik.solver.IKPositionWeight, this.ik.solver.bodyEffector.positionOffset - this.ik.solver.pullBodyOffset);
			Quaternion rotation = Quaternion.Lerp(Quaternion.identity, quaternion, this.thighWeight);
			Vector3 b2 = rotation * this.headToLeftThigh;
			Vector3 b3 = rotation * this.headToRightThigh;
			this.LerpSolverPosition(this.ik.solver.leftThighEffector, base.transform.position + b2, this.positionWeight * this.ik.solver.IKPositionWeight, this.ik.solver.bodyEffector.positionOffset - this.ik.solver.pullBodyOffset + this.ik.solver.leftThighEffector.positionOffset);
			this.LerpSolverPosition(this.ik.solver.rightThighEffector, base.transform.position + b3, this.positionWeight * this.ik.solver.IKPositionWeight, this.ik.solver.bodyEffector.positionOffset - this.ik.solver.pullBodyOffset + this.ik.solver.rightThighEffector.positionOffset);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00022580 File Offset: 0x00020780
		private void OnPostUpdate()
		{
			if (!base.enabled)
			{
				return;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			this.PostStretching();
			Quaternion quaternion = QuaTools.FromToRotation(this.ik.references.head.rotation, base.transform.rotation);
			quaternion = QuaTools.ClampRotation(quaternion, this.headClampWeight, 2);
			this.ik.references.head.rotation = Quaternion.Lerp(Quaternion.identity, quaternion, this.rotationWeight * this.ik.solver.IKPositionWeight) * this.ik.references.head.rotation;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00022630 File Offset: 0x00020830
		private void ChestDirection()
		{
			float num = this.chestDirectionWeight * this.ik.solver.IKPositionWeight;
			if (num <= 0f)
			{
				return;
			}
			bool flag = false;
			this.chestDirection = V3Tools.ClampDirection(this.chestDirection, this.ik.references.root.forward, 0.45f, 2, out flag);
			if (this.chestDirection == Vector3.zero)
			{
				return;
			}
			Quaternion quaternion = Quaternion.FromToRotation(this.ik.references.root.forward, this.chestDirection);
			quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, num * (1f / (float)this.chestBones.Length));
			foreach (Transform transform in this.chestBones)
			{
				transform.rotation = quaternion * transform.rotation;
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00022714 File Offset: 0x00020914
		private void PostStretching()
		{
			float num = this.postStretchWeight * this.ik.solver.IKPositionWeight;
			if (num > 0f)
			{
				Vector3 a = Vector3.ClampMagnitude(base.transform.position - this.ik.references.head.position, this.maxStretch);
				a *= num;
				this.stretchDamper = Mathf.Max(this.stretchDamper, 0f);
				if (this.stretchDamper > 0f)
				{
					a /= (1f + a.magnitude) * (1f + this.stretchDamper);
				}
				for (int i = 0; i < this.stretchBones.Length; i++)
				{
					if (this.stretchBones[i] != null)
					{
						this.stretchBones[i].position += a / (float)this.stretchBones.Length;
					}
				}
			}
			if (this.fixHead && this.ik.solver.IKPositionWeight > 0f)
			{
				this.ik.references.head.position = base.transform.position;
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0002284A File Offset: 0x00020A4A
		private void LerpSolverPosition(IKEffector effector, Vector3 position, float weight, Vector3 offset)
		{
			effector.GetNode(this.ik.solver).solverPosition = Vector3.Lerp(effector.GetNode(this.ik.solver).solverPosition, position + offset, weight);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00022888 File Offset: 0x00020A88
		private void Solve(ref Vector3 pos1, ref Vector3 pos2, float nominalDistance)
		{
			Vector3 a = pos2 - pos1;
			float magnitude = a.magnitude;
			if (magnitude == nominalDistance)
			{
				return;
			}
			if (magnitude == 0f)
			{
				return;
			}
			float num = 1f;
			num *= 1f - nominalDistance / magnitude;
			Vector3 b = a * num * 0.5f;
			pos1 += b;
			pos2 -= b;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00022908 File Offset: 0x00020B08
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPreRead = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreRead, new IKSolver.UpdateDelegate(this.OnPreRead));
				IKSolverFullBodyBiped solver2 = this.ik.solver;
				solver2.OnPreIteration = (IKSolver.IterationDelegate)Delegate.Remove(solver2.OnPreIteration, new IKSolver.IterationDelegate(this.Iterate));
				IKSolverFullBodyBiped solver3 = this.ik.solver;
				solver3.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver3.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
				IKSolverFullBodyBiped solver4 = this.ik.solver;
				solver4.OnStoreDefaultLocalState = (IKSolver.UpdateDelegate)Delegate.Remove(solver4.OnStoreDefaultLocalState, new IKSolver.UpdateDelegate(this.OnStoreDefaultLocalState));
				IKSolverFullBodyBiped solver5 = this.ik.solver;
				solver5.OnFixTransforms = (IKSolver.UpdateDelegate)Delegate.Remove(solver5.OnFixTransforms, new IKSolver.UpdateDelegate(this.OnFixTransforms));
			}
		}

		// Token: 0x040004EF RID: 1263
		[Tooltip("Reference to the FBBIK component.")]
		public FullBodyBipedIK ik;

		// Token: 0x040004F0 RID: 1264
		[LargeHeader("Position")]
		[Tooltip("Master weight for positioning the head.")]
		[Range(0f, 1f)]
		public float positionWeight = 1f;

		// Token: 0x040004F1 RID: 1265
		[Tooltip("The weight of moving the body along with the head")]
		[Range(0f, 1f)]
		public float bodyWeight = 0.8f;

		// Token: 0x040004F2 RID: 1266
		[Tooltip("The weight of moving the thighs along with the head")]
		[Range(0f, 1f)]
		public float thighWeight = 0.8f;

		// Token: 0x040004F3 RID: 1267
		[Tooltip("If false, hands will not pull the head away if they are too far. Disabling this will improve performance significantly.")]
		public bool handsPullBody = true;

		// Token: 0x040004F4 RID: 1268
		[LargeHeader("Rotation")]
		[Tooltip("The weight of rotating the head bone after solving")]
		[Range(0f, 1f)]
		public float rotationWeight;

		// Token: 0x040004F5 RID: 1269
		[Tooltip("Clamping the rotation of the body")]
		[Range(0f, 1f)]
		public float bodyClampWeight = 0.5f;

		// Token: 0x040004F6 RID: 1270
		[Tooltip("Clamping the rotation of the head")]
		[Range(0f, 1f)]
		public float headClampWeight = 0.5f;

		// Token: 0x040004F7 RID: 1271
		[Tooltip("The master weight of bending/twisting the spine to the rotation of the head effector. This is similar to CCD, but uses the rotation of the head effector not the position.")]
		[Range(0f, 1f)]
		public float bendWeight = 1f;

		// Token: 0x040004F8 RID: 1272
		[Tooltip("The bones to use for bending.")]
		public FBBIKHeadEffector.BendBone[] bendBones = new FBBIKHeadEffector.BendBone[0];

		// Token: 0x040004F9 RID: 1273
		[LargeHeader("CCD")]
		[Tooltip("Optional. The master weight of the CCD (Cyclic Coordinate Descent) IK effect that bends the spine towards the head effector before FBBIK solves.")]
		[Range(0f, 1f)]
		public float CCDWeight = 1f;

		// Token: 0x040004FA RID: 1274
		[Tooltip("The weight of rolling the bones in towards the target")]
		[Range(0f, 1f)]
		public float roll;

		// Token: 0x040004FB RID: 1275
		[Tooltip("Smoothing the CCD effect.")]
		[Range(0f, 1000f)]
		public float damper = 500f;

		// Token: 0x040004FC RID: 1276
		[Tooltip("Bones to use for the CCD pass. Assign spine and/or neck bones.")]
		public Transform[] CCDBones = new Transform[0];

		// Token: 0x040004FD RID: 1277
		[LargeHeader("Stretching")]
		[Tooltip("Stretching the spine/neck to help reach the target. This is useful for making sure the head stays locked relative to the VR headset. NB! Stretching is done after FBBIK has solved so if you have the hand effectors pinned and spine bones included in the 'Stretch Bones', the hands might become offset from their target positions.")]
		[Range(0f, 1f)]
		public float postStretchWeight = 1f;

		// Token: 0x040004FE RID: 1278
		[Tooltip("Stretch magnitude limit.")]
		public float maxStretch = 0.1f;

		// Token: 0x040004FF RID: 1279
		[Tooltip("If > 0, dampers the stretching effect.")]
		public float stretchDamper;

		// Token: 0x04000500 RID: 1280
		[Tooltip("If true, will fix head position to this Transform no matter what. Good for making sure the head will not budge away from the VR headset")]
		public bool fixHead;

		// Token: 0x04000501 RID: 1281
		[Tooltip("Bones to use for stretching. The more bones you add, the less noticable the effect.")]
		public Transform[] stretchBones = new Transform[0];

		// Token: 0x04000502 RID: 1282
		[LargeHeader("Chest Direction")]
		public Vector3 chestDirection = Vector3.forward;

		// Token: 0x04000503 RID: 1283
		[Range(0f, 1f)]
		public float chestDirectionWeight = 1f;

		// Token: 0x04000504 RID: 1284
		public Transform[] chestBones = new Transform[0];

		// Token: 0x04000505 RID: 1285
		public IKSolver.UpdateDelegate OnPostHeadEffectorFK;

		// Token: 0x04000506 RID: 1286
		private Vector3 offset;

		// Token: 0x04000507 RID: 1287
		private Vector3 headToBody;

		// Token: 0x04000508 RID: 1288
		private Vector3 shoulderCenterToHead;

		// Token: 0x04000509 RID: 1289
		private Vector3 headToLeftThigh;

		// Token: 0x0400050A RID: 1290
		private Vector3 headToRightThigh;

		// Token: 0x0400050B RID: 1291
		private Vector3 leftShoulderPos;

		// Token: 0x0400050C RID: 1292
		private Vector3 rightShoulderPos;

		// Token: 0x0400050D RID: 1293
		private float shoulderDist;

		// Token: 0x0400050E RID: 1294
		private float leftShoulderDist;

		// Token: 0x0400050F RID: 1295
		private float rightShoulderDist;

		// Token: 0x04000510 RID: 1296
		private Quaternion chestRotation;

		// Token: 0x04000511 RID: 1297
		private Quaternion headRotationRelativeToRoot;

		// Token: 0x04000512 RID: 1298
		private Quaternion[] ccdDefaultLocalRotations = new Quaternion[0];

		// Token: 0x04000513 RID: 1299
		private Vector3 headLocalPosition;

		// Token: 0x04000514 RID: 1300
		private Quaternion headLocalRotation;

		// Token: 0x04000515 RID: 1301
		private Vector3[] stretchLocalPositions = new Vector3[0];

		// Token: 0x04000516 RID: 1302
		private Quaternion[] stretchLocalRotations = new Quaternion[0];

		// Token: 0x04000517 RID: 1303
		private Vector3[] chestLocalPositions = new Vector3[0];

		// Token: 0x04000518 RID: 1304
		private Quaternion[] chestLocalRotations = new Quaternion[0];

		// Token: 0x04000519 RID: 1305
		private int bendBonesCount;

		// Token: 0x0400051A RID: 1306
		private int ccdBonesCount;

		// Token: 0x0400051B RID: 1307
		private int stretchBonesCount;

		// Token: 0x0400051C RID: 1308
		private int chestBonesCount;

		// Token: 0x020000BD RID: 189
		[Serializable]
		public class BendBone
		{
			// Token: 0x060005CF RID: 1487 RVA: 0x00022B0E File Offset: 0x00020D0E
			public BendBone()
			{
			}

			// Token: 0x060005D0 RID: 1488 RVA: 0x00022B2C File Offset: 0x00020D2C
			public BendBone(Transform transform, float weight)
			{
				this.transform = transform;
				this.weight = weight;
			}

			// Token: 0x060005D1 RID: 1489 RVA: 0x00022B58 File Offset: 0x00020D58
			public void StoreDefaultLocalState()
			{
				this.defaultLocalRotation = this.transform.localRotation;
			}

			// Token: 0x060005D2 RID: 1490 RVA: 0x00022B6B File Offset: 0x00020D6B
			public void FixTransforms()
			{
				this.transform.localRotation = this.defaultLocalRotation;
			}

			// Token: 0x0400051D RID: 1309
			[Tooltip("Assign spine and/or neck bones.")]
			public Transform transform;

			// Token: 0x0400051E RID: 1310
			[Tooltip("The weight of rotating this bone.")]
			[Range(0f, 1f)]
			public float weight = 0.5f;

			// Token: 0x0400051F RID: 1311
			private Quaternion defaultLocalRotation = Quaternion.identity;
		}
	}
}
