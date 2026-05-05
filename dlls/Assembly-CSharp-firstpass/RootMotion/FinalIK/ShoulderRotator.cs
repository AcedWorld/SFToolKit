using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200013F RID: 319
	public class ShoulderRotator : MonoBehaviour
	{
		// Token: 0x060009FC RID: 2556 RVA: 0x0003E485 File Offset: 0x0003C685
		private void Start()
		{
			this.ik = base.GetComponent<FullBodyBipedIK>();
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.RotateShoulders));
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0003E4C0 File Offset: 0x0003C6C0
		private void RotateShoulders()
		{
			if (this.ik == null)
			{
				return;
			}
			if (this.ik.solver.IKPositionWeight <= 0f)
			{
				return;
			}
			if (this.skip)
			{
				this.skip = false;
				return;
			}
			this.RotateShoulder(FullBodyBipedChain.LeftArm, this.weight, this.offset);
			this.RotateShoulder(FullBodyBipedChain.RightArm, this.weight, this.offset);
			this.skip = true;
			this.ik.solver.Update();
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0003E544 File Offset: 0x0003C744
		private void RotateShoulder(FullBodyBipedChain chain, float weight, float offset)
		{
			Quaternion b = Quaternion.FromToRotation(this.GetParentBoneMap(chain).swingDirection, this.ik.solver.GetEndEffector(chain).position - this.GetParentBoneMap(chain).transform.position);
			Vector3 vector = this.ik.solver.GetEndEffector(chain).position - this.ik.solver.GetLimbMapping(chain).bone1.position;
			float num = this.ik.solver.GetChain(chain).nodes[0].length + this.ik.solver.GetChain(chain).nodes[1].length;
			float num2 = vector.magnitude / num - 1f + offset;
			num2 = Mathf.Clamp(num2 * weight, 0f, 1f);
			Quaternion lhs = Quaternion.Lerp(Quaternion.identity, b, num2 * this.ik.solver.GetEndEffector(chain).positionWeight * this.ik.solver.IKPositionWeight);
			this.ik.solver.GetLimbMapping(chain).parentBone.rotation = lhs * this.ik.solver.GetLimbMapping(chain).parentBone.rotation;
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0003E69A File Offset: 0x0003C89A
		private IKMapping.BoneMap GetParentBoneMap(FullBodyBipedChain chain)
		{
			return this.ik.solver.GetLimbMapping(chain).GetBoneMap(IKMappingLimb.BoneMapType.Parent);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0003E6B3 File Offset: 0x0003C8B3
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.RotateShoulders));
			}
		}

		// Token: 0x04000951 RID: 2385
		[Tooltip("Weight of shoulder rotation")]
		public float weight = 1.5f;

		// Token: 0x04000952 RID: 2386
		[Tooltip("The greater the offset, the sooner the shoulder will start rotating")]
		public float offset = 0.2f;

		// Token: 0x04000953 RID: 2387
		private FullBodyBipedIK ik;

		// Token: 0x04000954 RID: 2388
		private bool skip;
	}
}
