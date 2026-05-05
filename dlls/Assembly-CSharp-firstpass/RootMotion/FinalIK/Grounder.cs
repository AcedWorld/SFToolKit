using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200009D RID: 157
	public abstract class Grounder : MonoBehaviour
	{
		// Token: 0x060004BC RID: 1212
		public abstract void ResetPosition();

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0001CEE3 File Offset: 0x0001B0E3
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x0001CEEB File Offset: 0x0001B0EB
		public bool initiated { get; protected set; }

		// Token: 0x060004BF RID: 1215 RVA: 0x0001CEF4 File Offset: 0x0001B0F4
		protected Vector3 GetSpineOffsetTarget()
		{
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < this.solver.legs.Length; i++)
			{
				vector += this.GetLegSpineBendVector(this.solver.legs[i]);
			}
			return vector;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001BF4E File Offset: 0x0001A14E
		protected void LogWarning(string message)
		{
			Warning.Log(message, base.transform, false);
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001CF3C File Offset: 0x0001B13C
		private Vector3 GetLegSpineBendVector(Grounding.Leg leg)
		{
			Vector3 legSpineTangent = this.GetLegSpineTangent(leg);
			float d = (Vector3.Dot(this.solver.root.forward, legSpineTangent.normalized) + 1f) * 0.5f;
			float magnitude = (leg.IKPosition - leg.transform.position).magnitude;
			return legSpineTangent * magnitude * d;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0001CFA8 File Offset: 0x0001B1A8
		private Vector3 GetLegSpineTangent(Grounding.Leg leg)
		{
			Vector3 vector = leg.transform.position - this.solver.root.position;
			if (!this.solver.rotateSolver || this.solver.root.up == Vector3.up)
			{
				return new Vector3(vector.x, 0f, vector.z);
			}
			Vector3 up = this.solver.root.up;
			Vector3.OrthoNormalize(ref up, ref vector);
			return vector;
		}

		// Token: 0x060004C3 RID: 1219
		protected abstract void OpenUserManual();

		// Token: 0x060004C4 RID: 1220
		protected abstract void OpenScriptReference();

		// Token: 0x0400043A RID: 1082
		[Tooltip("The master weight. Use this to fade in/out the grounding effect.")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x0400043B RID: 1083
		[Tooltip("The Grounding solver. Not to confuse with IK solvers.")]
		public Grounding solver = new Grounding();

		// Token: 0x0400043C RID: 1084
		public Grounder.GrounderDelegate OnPreGrounder;

		// Token: 0x0400043D RID: 1085
		public Grounder.GrounderDelegate OnPostGrounder;

		// Token: 0x0400043E RID: 1086
		public Grounder.GrounderDelegate OnPostIK;

		// Token: 0x0200009E RID: 158
		// (Invoke) Token: 0x060004C7 RID: 1223
		public delegate void GrounderDelegate();
	}
}
