using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000BA RID: 186
	[Serializable]
	public class FABRIKChain
	{
		// Token: 0x060005B7 RID: 1463 RVA: 0x0002138F File Offset: 0x0001F58F
		public bool IsValid(ref string message)
		{
			if (this.ik == null)
			{
				message = "IK unassigned in FABRIKChain.";
				return false;
			}
			return this.ik.solver.IsValid(ref message);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x000213BE File Offset: 0x0001F5BE
		public void Initiate()
		{
			this.ik.enabled = false;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x000213CC File Offset: 0x0001F5CC
		public void Stage1(FABRIKChain[] chain)
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				chain[this.children[i]].Stage1(chain);
			}
			if (this.children.Length == 0)
			{
				this.ik.solver.SolveForward(this.ik.solver.GetIKPosition());
				return;
			}
			this.ik.solver.SolveForward(this.GetCentroid(chain));
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00021440 File Offset: 0x0001F640
		public void Stage2(Vector3 rootPosition, FABRIKChain[] chain)
		{
			this.ik.solver.SolveBackward(rootPosition);
			for (int i = 0; i < this.children.Length; i++)
			{
				chain[this.children[i]].Stage2(this.ik.solver.bones[this.ik.solver.bones.Length - 1].transform.position, chain);
			}
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x000214B0 File Offset: 0x0001F6B0
		private Vector3 GetCentroid(FABRIKChain[] chain)
		{
			Vector3 ikposition = this.ik.solver.GetIKPosition();
			if (this.pin >= 1f)
			{
				return ikposition;
			}
			float num = 0f;
			for (int i = 0; i < this.children.Length; i++)
			{
				num += chain[this.children[i]].pull;
			}
			if (num <= 0f)
			{
				return ikposition;
			}
			if (num < 1f)
			{
				num = 1f;
			}
			Vector3 vector = ikposition;
			for (int j = 0; j < this.children.Length; j++)
			{
				Vector3 a = chain[this.children[j]].ik.solver.bones[0].solverPosition - ikposition;
				float d = chain[this.children[j]].pull / num;
				vector += a * d;
			}
			if (this.pin <= 0f)
			{
				return vector;
			}
			return vector + (ikposition - vector) * this.pin;
		}

		// Token: 0x040004E3 RID: 1251
		public FABRIK ik;

		// Token: 0x040004E4 RID: 1252
		[Range(0f, 1f)]
		public float pull = 1f;

		// Token: 0x040004E5 RID: 1253
		[Range(0f, 1f)]
		public float pin = 1f;

		// Token: 0x040004E6 RID: 1254
		public int[] children = new int[0];
	}
}
