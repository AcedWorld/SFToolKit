using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000110 RID: 272
	[HelpURL("http://www.root-motion.com/finalikdox/html/page14.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Rotation Limits/Rotation Limit Polygonal")]
	public class RotationLimitPolygonal : RotationLimit
	{
		// Token: 0x06000922 RID: 2338 RVA: 0x00039EC7 File Offset: 0x000380C7
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page14.html");
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0003A0BA File Offset: 0x000382BA
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_rotation_limit_polygonal.html");
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0003A0C6 File Offset: 0x000382C6
		public void SetLimitPoints(RotationLimitPolygonal.LimitPoint[] points)
		{
			if (points.Length < 3)
			{
				base.LogWarning("The polygon must have at least 3 Limit Points.");
				return;
			}
			this.points = points;
			this.BuildReachCones();
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0003A0E7 File Offset: 0x000382E7
		protected override Quaternion LimitRotation(Quaternion rotation)
		{
			if (this.reachCones.Length == 0)
			{
				this.Start();
			}
			return RotationLimit.LimitTwist(this.LimitSwing(rotation), this.axis, base.secondaryAxis, this.twistLimit);
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0003A118 File Offset: 0x00038318
		private void Start()
		{
			if (this.points.Length < 3)
			{
				this.ResetToDefault();
			}
			for (int i = 0; i < this.reachCones.Length; i++)
			{
				if (!this.reachCones[i].isValid)
				{
					if (this.smoothIterations <= 0)
					{
						int num;
						if (i < this.reachCones.Length - 1)
						{
							num = i + 1;
						}
						else
						{
							num = 0;
						}
						base.LogWarning(string.Concat(new string[]
						{
							"Reach Cone {point ",
							i.ToString(),
							", point ",
							num.ToString(),
							", Origin} has negative volume. Make sure Axis vector is in the reachable area and the polygon is convex."
						}));
					}
					else
					{
						base.LogWarning("One of the Reach Cones in the polygon has negative volume. Make sure Axis vector is in the reachable area and the polygon is convex.");
					}
				}
			}
			this.axis = this.axis.normalized;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0003A1D8 File Offset: 0x000383D8
		public void ResetToDefault()
		{
			this.points = new RotationLimitPolygonal.LimitPoint[4];
			for (int i = 0; i < this.points.Length; i++)
			{
				this.points[i] = new RotationLimitPolygonal.LimitPoint();
			}
			Quaternion quaternion = Quaternion.AngleAxis(45f, Vector3.right);
			Quaternion quaternion2 = Quaternion.AngleAxis(45f, Vector3.up);
			this.points[0].point = quaternion * quaternion2 * this.axis;
			this.points[1].point = Quaternion.Inverse(quaternion) * quaternion2 * this.axis;
			this.points[2].point = Quaternion.Inverse(quaternion) * Quaternion.Inverse(quaternion2) * this.axis;
			this.points[3].point = quaternion * Quaternion.Inverse(quaternion2) * this.axis;
			this.BuildReachCones();
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0003A2C8 File Offset: 0x000384C8
		public void BuildReachCones()
		{
			this.smoothIterations = Mathf.Clamp(this.smoothIterations, 0, 3);
			this.P = new Vector3[this.points.Length];
			for (int i = 0; i < this.points.Length; i++)
			{
				this.P[i] = this.points[i].point.normalized;
			}
			for (int j = 0; j < this.smoothIterations; j++)
			{
				this.P = this.SmoothPoints();
			}
			this.reachCones = new RotationLimitPolygonal.ReachCone[this.P.Length];
			for (int k = 0; k < this.reachCones.Length - 1; k++)
			{
				this.reachCones[k] = new RotationLimitPolygonal.ReachCone(Vector3.zero, this.axis.normalized, this.P[k], this.P[k + 1]);
			}
			this.reachCones[this.P.Length - 1] = new RotationLimitPolygonal.ReachCone(Vector3.zero, this.axis.normalized, this.P[this.P.Length - 1], this.P[0]);
			for (int l = 0; l < this.reachCones.Length; l++)
			{
				this.reachCones[l].Calculate();
			}
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0003A410 File Offset: 0x00038610
		private Vector3[] SmoothPoints()
		{
			Vector3[] array = new Vector3[this.P.Length * 2];
			float scalar = this.GetScalar(this.P.Length);
			for (int i = 0; i < array.Length; i += 2)
			{
				array[i] = this.PointToTangentPlane(this.P[i / 2], 1f);
			}
			for (int j = 1; j < array.Length; j += 2)
			{
				Vector3 b = Vector3.zero;
				Vector3 vector = Vector3.zero;
				Vector3 b2 = Vector3.zero;
				if (j > 1 && j < array.Length - 2)
				{
					b = array[j - 2];
					b2 = array[j + 1];
				}
				else if (j == 1)
				{
					b = array[array.Length - 2];
					b2 = array[j + 1];
				}
				else if (j == array.Length - 1)
				{
					b = array[j - 2];
					b2 = array[0];
				}
				if (j < array.Length - 1)
				{
					vector = array[j + 1];
				}
				else
				{
					vector = array[0];
				}
				int num = array.Length / this.points.Length;
				array[j] = 0.5f * (array[j - 1] + vector) + scalar * this.points[j / num].tangentWeight * (vector - b) + scalar * this.points[j / num].tangentWeight * (array[j - 1] - b2);
			}
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = this.TangentPointToSphere(array[k], 1f);
			}
			return array;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0003A5BD File Offset: 0x000387BD
		private float GetScalar(int k)
		{
			if (k <= 3)
			{
				return 0.1667f;
			}
			if (k == 4)
			{
				return 0.1036f;
			}
			if (k == 5)
			{
				return 0.085f;
			}
			if (k == 6)
			{
				return 0.0773f;
			}
			if (k == 7)
			{
				return 0.07f;
			}
			return 0.0625f;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0003A5F8 File Offset: 0x000387F8
		private Vector3 PointToTangentPlane(Vector3 p, float r)
		{
			float num = Vector3.Dot(this.axis, p);
			float num2 = 2f * r * r / (r * r + num);
			return num2 * p + (1f - num2) * -this.axis;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0003A648 File Offset: 0x00038848
		private Vector3 TangentPointToSphere(Vector3 q, float r)
		{
			float num = Vector3.Dot(q - this.axis, q - this.axis);
			float num2 = 4f * r * r / (4f * r * r + num);
			return num2 * q + (1f - num2) * -this.axis;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0003A6AC File Offset: 0x000388AC
		private Quaternion LimitSwing(Quaternion rotation)
		{
			if (rotation == Quaternion.identity)
			{
				return rotation;
			}
			Vector3 vector = rotation * this.axis;
			int reachCone = this.GetReachCone(vector);
			if (reachCone == -1)
			{
				if (!Warning.logged)
				{
					base.LogWarning("RotationLimitPolygonal reach cones are invalid.");
				}
				return rotation;
			}
			if (Vector3.Dot(this.reachCones[reachCone].B, vector) > 0f)
			{
				return rotation;
			}
			Vector3 rhs = Vector3.Cross(this.axis, vector);
			vector = Vector3.Cross(-this.reachCones[reachCone].B, rhs);
			return Quaternion.FromToRotation(rotation * this.axis, vector) * rotation;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0003A750 File Offset: 0x00038950
		private int GetReachCone(Vector3 L)
		{
			float num = Vector3.Dot(this.reachCones[0].S, L);
			for (int i = 0; i < this.reachCones.Length; i++)
			{
				float num2 = num;
				if (i < this.reachCones.Length - 1)
				{
					num = Vector3.Dot(this.reachCones[i + 1].S, L);
				}
				else
				{
					num = Vector3.Dot(this.reachCones[0].S, L);
				}
				if (num2 >= 0f && num < 0f)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x04000856 RID: 2134
		[Range(0f, 180f)]
		public float twistLimit = 180f;

		// Token: 0x04000857 RID: 2135
		[Range(0f, 3f)]
		public int smoothIterations;

		// Token: 0x04000858 RID: 2136
		[HideInInspector]
		public RotationLimitPolygonal.LimitPoint[] points;

		// Token: 0x04000859 RID: 2137
		[HideInInspector]
		public Vector3[] P;

		// Token: 0x0400085A RID: 2138
		[HideInInspector]
		public RotationLimitPolygonal.ReachCone[] reachCones = new RotationLimitPolygonal.ReachCone[0];

		// Token: 0x02000111 RID: 273
		[Serializable]
		public class ReachCone
		{
			// Token: 0x17000106 RID: 262
			// (get) Token: 0x06000932 RID: 2354 RVA: 0x0003A7EF File Offset: 0x000389EF
			public Vector3 o
			{
				get
				{
					return this.tetrahedron[0];
				}
			}

			// Token: 0x17000107 RID: 263
			// (get) Token: 0x06000933 RID: 2355 RVA: 0x0003A7FD File Offset: 0x000389FD
			public Vector3 a
			{
				get
				{
					return this.tetrahedron[1];
				}
			}

			// Token: 0x17000108 RID: 264
			// (get) Token: 0x06000934 RID: 2356 RVA: 0x0003A80B File Offset: 0x00038A0B
			public Vector3 b
			{
				get
				{
					return this.tetrahedron[2];
				}
			}

			// Token: 0x17000109 RID: 265
			// (get) Token: 0x06000935 RID: 2357 RVA: 0x0003A819 File Offset: 0x00038A19
			public Vector3 c
			{
				get
				{
					return this.tetrahedron[3];
				}
			}

			// Token: 0x06000936 RID: 2358 RVA: 0x0003A828 File Offset: 0x00038A28
			public ReachCone(Vector3 _o, Vector3 _a, Vector3 _b, Vector3 _c)
			{
				this.tetrahedron = new Vector3[4];
				this.tetrahedron[0] = _o;
				this.tetrahedron[1] = _a;
				this.tetrahedron[2] = _b;
				this.tetrahedron[3] = _c;
				this.volume = 0f;
				this.S = Vector3.zero;
				this.B = Vector3.zero;
			}

			// Token: 0x1700010A RID: 266
			// (get) Token: 0x06000937 RID: 2359 RVA: 0x0003A89D File Offset: 0x00038A9D
			public bool isValid
			{
				get
				{
					return this.volume > 0f;
				}
			}

			// Token: 0x06000938 RID: 2360 RVA: 0x0003A8AC File Offset: 0x00038AAC
			public void Calculate()
			{
				Vector3 lhs = Vector3.Cross(this.a, this.b);
				this.volume = Vector3.Dot(lhs, this.c) / 6f;
				this.S = Vector3.Cross(this.a, this.b).normalized;
				this.B = Vector3.Cross(this.b, this.c).normalized;
			}

			// Token: 0x0400085B RID: 2139
			public Vector3[] tetrahedron;

			// Token: 0x0400085C RID: 2140
			public float volume;

			// Token: 0x0400085D RID: 2141
			public Vector3 S;

			// Token: 0x0400085E RID: 2142
			public Vector3 B;
		}

		// Token: 0x02000112 RID: 274
		[Serializable]
		public class LimitPoint
		{
			// Token: 0x06000939 RID: 2361 RVA: 0x0003A921 File Offset: 0x00038B21
			public LimitPoint()
			{
				this.point = Vector3.forward;
				this.tangentWeight = 1f;
			}

			// Token: 0x0400085F RID: 2143
			public Vector3 point;

			// Token: 0x04000860 RID: 2144
			public float tangentWeight;
		}
	}
}
