using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000118 RID: 280
	public class Amplifier : OffsetModifier
	{
		// Token: 0x06000955 RID: 2389 RVA: 0x0003B3D8 File Offset: 0x000395D8
		protected override void OnModifyOffset()
		{
			if (!this.ik.fixTransforms)
			{
				if (!Warning.logged)
				{
					Warning.Log("Amplifier needs the Fix Transforms option of the FBBIK to be set to true. Otherwise it might amplify to infinity, should the animator of the character stop because of culling.", base.transform, false);
				}
				return;
			}
			Amplifier.Body[] array = this.bodies;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this.ik.solver, this.weight, base.deltaTime);
			}
		}

		// Token: 0x0400088D RID: 2189
		[Tooltip("The amplified bodies.")]
		public Amplifier.Body[] bodies;

		// Token: 0x02000119 RID: 281
		[Serializable]
		public class Body
		{
			// Token: 0x06000957 RID: 2391 RVA: 0x0003B448 File Offset: 0x00039648
			public void Update(IKSolverFullBodyBiped solver, float w, float deltaTime)
			{
				if (this.transform == null || this.relativeTo == null)
				{
					return;
				}
				Vector3 a = this.relativeTo.InverseTransformDirection(this.transform.position - this.relativeTo.position);
				if (this.firstUpdate)
				{
					this.lastRelativePos = a;
					this.firstUpdate = false;
				}
				Vector3 vector = (a - this.lastRelativePos) / deltaTime;
				this.smoothDelta = ((this.speed <= 0f) ? vector : Vector3.Lerp(this.smoothDelta, vector, deltaTime * this.speed));
				Vector3 v = this.relativeTo.TransformDirection(this.smoothDelta);
				Vector3 a2 = V3Tools.ExtractVertical(v, solver.GetRoot().up, this.verticalWeight) + V3Tools.ExtractHorizontal(v, solver.GetRoot().up, this.horizontalWeight);
				for (int i = 0; i < this.effectorLinks.Length; i++)
				{
					solver.GetEffector(this.effectorLinks[i].effector).positionOffset += a2 * w * this.effectorLinks[i].weight;
				}
				this.lastRelativePos = a;
			}

			// Token: 0x06000958 RID: 2392 RVA: 0x0003B58E File Offset: 0x0003978E
			private static Vector3 Multiply(Vector3 v1, Vector3 v2)
			{
				v1.x *= v2.x;
				v1.y *= v2.y;
				v1.z *= v2.z;
				return v1;
			}

			// Token: 0x0400088E RID: 2190
			[Tooltip("The Transform that's motion we are reading.")]
			public Transform transform;

			// Token: 0x0400088F RID: 2191
			[Tooltip("Amplify the 'transform's' position relative to this Transform.")]
			public Transform relativeTo;

			// Token: 0x04000890 RID: 2192
			[Tooltip("Linking the body to effectors. One Body can be used to offset more than one effector.")]
			public Amplifier.Body.EffectorLink[] effectorLinks;

			// Token: 0x04000891 RID: 2193
			[Tooltip("Amplification magnitude along the up axis of the character.")]
			public float verticalWeight = 1f;

			// Token: 0x04000892 RID: 2194
			[Tooltip("Amplification magnitude along the horizontal axes of the character.")]
			public float horizontalWeight = 1f;

			// Token: 0x04000893 RID: 2195
			[Tooltip("Speed of the amplifier. 0 means instant.")]
			public float speed = 3f;

			// Token: 0x04000894 RID: 2196
			private Vector3 lastRelativePos;

			// Token: 0x04000895 RID: 2197
			private Vector3 smoothDelta;

			// Token: 0x04000896 RID: 2198
			private bool firstUpdate;

			// Token: 0x0200011A RID: 282
			[Serializable]
			public class EffectorLink
			{
				// Token: 0x04000897 RID: 2199
				[Tooltip("Type of the FBBIK effector to use")]
				public FullBodyBipedEffector effector;

				// Token: 0x04000898 RID: 2200
				[Tooltip("Weight of using this effector")]
				public float weight;
			}
		}
	}
}
