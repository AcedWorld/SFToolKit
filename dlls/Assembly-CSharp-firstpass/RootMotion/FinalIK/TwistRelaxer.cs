using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000ED RID: 237
	public class TwistRelaxer : MonoBehaviour
	{
		// Token: 0x06000809 RID: 2057 RVA: 0x00034A48 File Offset: 0x00032C48
		public void Start()
		{
			if (this.twistSolvers.Length == 0)
			{
				Debug.LogError("TwistRelaxer has no TwistSolvers. TwistRelaxer.cs was restructured for FIK v2.0 to support multiple relaxers on the same body part and TwistRelaxer components need to be set up again, sorry for the inconvenience!", base.transform);
				return;
			}
			TwistSolver[] array = this.twistSolvers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initiate();
			}
			if (this.ik != null)
			{
				IKSolver iksolver = this.ik.GetIKSolver();
				iksolver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00034AC8 File Offset: 0x00032CC8
		private void Update()
		{
			if (this.ik != null && this.ik.fixTransforms)
			{
				TwistSolver[] array = this.twistSolvers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].FixTransforms();
				}
			}
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00034B10 File Offset: 0x00032D10
		private void OnPostUpdate()
		{
			if (this.ik != null)
			{
				TwistSolver[] array = this.twistSolvers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Relax();
				}
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00034B48 File Offset: 0x00032D48
		private void LateUpdate()
		{
			if (this.ik == null)
			{
				TwistSolver[] array = this.twistSolvers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Relax();
				}
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00034B80 File Offset: 0x00032D80
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolver iksolver = this.ik.GetIKSolver();
				iksolver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(iksolver.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
			}
		}

		// Token: 0x04000766 RID: 1894
		public IK ik;

		// Token: 0x04000767 RID: 1895
		[Tooltip("If using multiple solvers, add them in inverse hierarchical order - first forearm roll bone, then forearm bone and upper arm bone.")]
		public TwistSolver[] twistSolvers = new TwistSolver[0];
	}
}
