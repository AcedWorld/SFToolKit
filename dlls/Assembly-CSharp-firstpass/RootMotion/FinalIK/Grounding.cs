using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000A5 RID: 165
	[Serializable]
	public class Grounding
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0001F199 File Offset: 0x0001D399
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x0001F1A1 File Offset: 0x0001D3A1
		public Grounding.Leg[] legs { get; private set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0001F1AA File Offset: 0x0001D3AA
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x0001F1B2 File Offset: 0x0001D3B2
		public Grounding.Pelvis pelvis { get; private set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0001F1BB File Offset: 0x0001D3BB
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x0001F1C3 File Offset: 0x0001D3C3
		public bool isGrounded { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0001F1CC File Offset: 0x0001D3CC
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x0001F1D4 File Offset: 0x0001D3D4
		public Transform root { get; private set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0001F1DD File Offset: 0x0001D3DD
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x0001F1E5 File Offset: 0x0001D3E5
		public RaycastHit rootHit { get; private set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x0001F1F0 File Offset: 0x0001D3F0
		public bool rootGrounded
		{
			get
			{
				return this.rootHit.distance < this.maxStep * 2f;
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0001F21C File Offset: 0x0001D41C
		public RaycastHit GetRootHit(float maxDistanceMlp = 10f)
		{
			RaycastHit result = default(RaycastHit);
			Vector3 up = this.up;
			Vector3 a = Vector3.zero;
			foreach (Grounding.Leg leg in this.legs)
			{
				a += leg.transform.position;
			}
			a /= (float)this.legs.Length;
			result.point = a - up * this.maxStep * 10f;
			float num = maxDistanceMlp + 1f;
			result.distance = this.maxStep * num;
			if (this.maxStep <= 0f)
			{
				return result;
			}
			if (this.quality != Grounding.Quality.Best)
			{
				this.Raycast(a + up * this.maxStep, -up, out result, this.maxStep * num, this.layers, QueryTriggerInteraction.Ignore);
			}
			else
			{
				this.SphereCast(a + up * this.maxStep, this.rootSphereCastRadius, -this.up, out result, this.maxStep * num, this.layers, QueryTriggerInteraction.Ignore);
			}
			return result;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001F358 File Offset: 0x0001D558
		public bool IsValid(ref string errorMessage)
		{
			if (this.root == null)
			{
				errorMessage = "Root transform is null. Can't initiate Grounding.";
				return false;
			}
			if (this.legs == null)
			{
				errorMessage = "Grounding legs is null. Can't initiate Grounding.";
				return false;
			}
			if (this.pelvis == null)
			{
				errorMessage = "Grounding pelvis is null. Can't initiate Grounding.";
				return false;
			}
			if (this.legs.Length == 0)
			{
				errorMessage = "Grounding has 0 legs. Can't initiate Grounding.";
				return false;
			}
			return true;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001F3B4 File Offset: 0x0001D5B4
		public void Initiate(Transform root, Transform[] feet)
		{
			this.root = root;
			this.initiated = false;
			this.rootHit = default(RaycastHit);
			if (this.legs == null)
			{
				this.legs = new Grounding.Leg[feet.Length];
			}
			if (this.legs.Length != feet.Length)
			{
				this.legs = new Grounding.Leg[feet.Length];
			}
			for (int i = 0; i < feet.Length; i++)
			{
				if (this.legs[i] == null)
				{
					this.legs[i] = new Grounding.Leg();
				}
			}
			if (this.pelvis == null)
			{
				this.pelvis = new Grounding.Pelvis();
			}
			string empty = string.Empty;
			if (!this.IsValid(ref empty))
			{
				Warning.Log(empty, root, false);
				return;
			}
			if (Application.isPlaying)
			{
				for (int j = 0; j < feet.Length; j++)
				{
					this.legs[j].Initiate(this, feet[j]);
				}
				this.pelvis.Initiate(this);
				this.initiated = true;
			}
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0001F49C File Offset: 0x0001D69C
		public void Update()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.layers == 0)
			{
				this.LogWarning("Grounding layers are set to nothing. Please add a ground layer.");
			}
			this.maxStep = Mathf.Clamp(this.maxStep, 0f, this.maxStep);
			this.footRadius = Mathf.Clamp(this.footRadius, 0.0001f, this.maxStep);
			this.pelvisDamper = Mathf.Clamp(this.pelvisDamper, 0f, 1f);
			this.rootSphereCastRadius = Mathf.Clamp(this.rootSphereCastRadius, 0.0001f, this.rootSphereCastRadius);
			this.maxFootRotationAngle = Mathf.Clamp(this.maxFootRotationAngle, 0f, 90f);
			this.prediction = Mathf.Clamp(this.prediction, 0f, this.prediction);
			this.footSpeed = Mathf.Clamp(this.footSpeed, 0f, this.footSpeed);
			this.rootHit = this.GetRootHit(10f);
			float num = float.NegativeInfinity;
			float num2 = float.PositiveInfinity;
			this.isGrounded = false;
			foreach (Grounding.Leg leg in this.legs)
			{
				leg.Process();
				if (leg.IKOffset > num)
				{
					num = leg.IKOffset;
				}
				if (leg.IKOffset < num2)
				{
					num2 = leg.IKOffset;
				}
				if (leg.isGrounded)
				{
					this.isGrounded = true;
				}
			}
			num = Mathf.Max(num, 0f);
			num2 = Mathf.Min(num2, 0f);
			this.pelvis.Process(-num * this.lowerPelvisWeight, -num2 * this.liftPelvisWeight, this.isGrounded);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001F640 File Offset: 0x0001D840
		public Vector3 GetLegsPlaneNormal()
		{
			if (!this.initiated)
			{
				return Vector3.up;
			}
			Vector3 up = this.up;
			Vector3 vector = up;
			for (int i = 0; i < this.legs.Length; i++)
			{
				Vector3 vector2 = this.legs[i].IKPosition - this.root.position;
				Vector3 vector3 = up;
				Vector3 fromDirection = vector2;
				Vector3.OrthoNormalize(ref vector3, ref fromDirection);
				vector = Quaternion.FromToRotation(fromDirection, vector2) * vector;
			}
			return vector;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0001F6B4 File Offset: 0x0001D8B4
		public void Reset()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			this.pelvis.Reset();
			Grounding.Leg[] legs = this.legs;
			for (int i = 0; i < legs.Length; i++)
			{
				legs[i].Reset();
			}
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0001F6F1 File Offset: 0x0001D8F1
		public void LogWarning(string message)
		{
			Warning.Log(message, this.root, false);
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0001F700 File Offset: 0x0001D900
		public Vector3 up
		{
			get
			{
				if (!this.useRootRotation)
				{
					return Vector3.up;
				}
				return this.root.up;
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0001F71B File Offset: 0x0001D91B
		public float GetVerticalOffset(Vector3 p1, Vector3 p2)
		{
			if (this.useRootRotation)
			{
				return (Quaternion.Inverse(this.root.rotation) * (p1 - p2)).y;
			}
			return p1.y - p2.y;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0001F754 File Offset: 0x0001D954
		public Vector3 Flatten(Vector3 v)
		{
			if (this.useRootRotation)
			{
				Vector3 onNormal = v;
				Vector3 up = this.root.up;
				Vector3.OrthoNormalize(ref up, ref onNormal);
				return Vector3.Project(v, onNormal);
			}
			v.y = 0f;
			return v;
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001F795 File Offset: 0x0001D995
		private bool useRootRotation
		{
			get
			{
				return this.rotateSolver && !(this.root.up == Vector3.up);
			}
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0001F7BB File Offset: 0x0001D9BB
		public Vector3 GetFootCenterOffset()
		{
			return this.root.forward * this.footRadius + this.root.forward * this.footCenterOffset;
		}

		// Token: 0x04000482 RID: 1154
		[Tooltip("Layers to ground the character to. Make sure to exclude the layer of the character controller.")]
		public LayerMask layers;

		// Token: 0x04000483 RID: 1155
		[Tooltip("Max step height. Maximum vertical distance of Grounding from the root of the character.")]
		public float maxStep = 0.5f;

		// Token: 0x04000484 RID: 1156
		[Tooltip("The height offset of the root.")]
		public float heightOffset;

		// Token: 0x04000485 RID: 1157
		[Tooltip("The speed of moving the feet up/down.")]
		public float footSpeed = 2.5f;

		// Token: 0x04000486 RID: 1158
		[Tooltip("CapsuleCast radius. Should match approximately with the size of the feet.")]
		public float footRadius = 0.15f;

		// Token: 0x04000487 RID: 1159
		[Tooltip("Offset of the foot center along character forward axis.")]
		[HideInInspector]
		public float footCenterOffset;

		// Token: 0x04000488 RID: 1160
		[Tooltip("Amount of velocity based prediction of the foot positions.")]
		public float prediction = 0.05f;

		// Token: 0x04000489 RID: 1161
		[Tooltip("Weight of rotating the feet to the ground normal offset.")]
		[Range(0f, 1f)]
		public float footRotationWeight = 1f;

		// Token: 0x0400048A RID: 1162
		[Tooltip("Speed of slerping the feet to their grounded rotations.")]
		public float footRotationSpeed = 7f;

		// Token: 0x0400048B RID: 1163
		[Tooltip("Max Foot Rotation Angle. Max angular offset from the foot's rotation.")]
		[Range(0f, 90f)]
		public float maxFootRotationAngle = 45f;

		// Token: 0x0400048C RID: 1164
		[Tooltip("If true, solver will rotate with the character root so the character can be grounded for example to spherical planets. For performance reasons leave this off unless needed.")]
		public bool rotateSolver;

		// Token: 0x0400048D RID: 1165
		[Tooltip("The speed of moving the character up/down.")]
		public float pelvisSpeed = 5f;

		// Token: 0x0400048E RID: 1166
		[Tooltip("Used for smoothing out vertical pelvis movement (range 0 - 1).")]
		[Range(0f, 1f)]
		public float pelvisDamper;

		// Token: 0x0400048F RID: 1167
		[Tooltip("The weight of lowering the pelvis to the lowest foot.")]
		public float lowerPelvisWeight = 1f;

		// Token: 0x04000490 RID: 1168
		[Tooltip("The weight of lifting the pelvis to the highest foot. This is useful when you don't want the feet to go too high relative to the body when crouching.")]
		public float liftPelvisWeight;

		// Token: 0x04000491 RID: 1169
		[Tooltip("The radius of the spherecast from the root that determines whether the character root is grounded.")]
		public float rootSphereCastRadius = 0.1f;

		// Token: 0x04000492 RID: 1170
		[Tooltip("If false, keeps the foot that is over a ledge at the root level. If true, lowers the overstepping foot and body by the 'Max Step' value.")]
		public bool overstepFallsDown = true;

		// Token: 0x04000493 RID: 1171
		[Tooltip("The raycasting quality. Fastest is a single raycast per foot, Simple is three raycasts, Best is one raycast and a capsule cast per foot.")]
		public Grounding.Quality quality = Grounding.Quality.Best;

		// Token: 0x04000499 RID: 1177
		public Grounding.OnRaycastDelegate Raycast = new Grounding.OnRaycastDelegate(Physics.Raycast);

		// Token: 0x0400049A RID: 1178
		public Grounding.OnCapsuleCastDelegate CapsuleCast = new Grounding.OnCapsuleCastDelegate(Physics.CapsuleCast);

		// Token: 0x0400049B RID: 1179
		public Grounding.OnSphereCastDelegate SphereCast = new Grounding.OnSphereCastDelegate(Physics.SphereCast);

		// Token: 0x0400049C RID: 1180
		private bool initiated;

		// Token: 0x020000A6 RID: 166
		[Serializable]
		public enum Quality
		{
			// Token: 0x0400049E RID: 1182
			Fastest,
			// Token: 0x0400049F RID: 1183
			Simple,
			// Token: 0x040004A0 RID: 1184
			Best
		}

		// Token: 0x020000A7 RID: 167
		// (Invoke) Token: 0x0600051F RID: 1311
		public delegate bool OnRaycastDelegate(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		// Token: 0x020000A8 RID: 168
		// (Invoke) Token: 0x06000523 RID: 1315
		public delegate bool OnCapsuleCastDelegate(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		// Token: 0x020000A9 RID: 169
		// (Invoke) Token: 0x06000527 RID: 1319
		public delegate bool OnSphereCastDelegate(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		// Token: 0x020000AA RID: 170
		public class Leg
		{
			// Token: 0x1700008E RID: 142
			// (get) Token: 0x0600052A RID: 1322 RVA: 0x0001F8B5 File Offset: 0x0001DAB5
			// (set) Token: 0x0600052B RID: 1323 RVA: 0x0001F8BD File Offset: 0x0001DABD
			public bool isGrounded { get; private set; }

			// Token: 0x1700008F RID: 143
			// (get) Token: 0x0600052C RID: 1324 RVA: 0x0001F8C6 File Offset: 0x0001DAC6
			// (set) Token: 0x0600052D RID: 1325 RVA: 0x0001F8CE File Offset: 0x0001DACE
			public Vector3 IKPosition { get; private set; }

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x0600052E RID: 1326 RVA: 0x0001F8D7 File Offset: 0x0001DAD7
			// (set) Token: 0x0600052F RID: 1327 RVA: 0x0001F8DF File Offset: 0x0001DADF
			public bool initiated { get; private set; }

			// Token: 0x17000091 RID: 145
			// (get) Token: 0x06000530 RID: 1328 RVA: 0x0001F8E8 File Offset: 0x0001DAE8
			// (set) Token: 0x06000531 RID: 1329 RVA: 0x0001F8F0 File Offset: 0x0001DAF0
			public float heightFromGround { get; private set; }

			// Token: 0x17000092 RID: 146
			// (get) Token: 0x06000532 RID: 1330 RVA: 0x0001F8F9 File Offset: 0x0001DAF9
			// (set) Token: 0x06000533 RID: 1331 RVA: 0x0001F901 File Offset: 0x0001DB01
			public Vector3 velocity { get; private set; }

			// Token: 0x17000093 RID: 147
			// (get) Token: 0x06000534 RID: 1332 RVA: 0x0001F90A File Offset: 0x0001DB0A
			// (set) Token: 0x06000535 RID: 1333 RVA: 0x0001F912 File Offset: 0x0001DB12
			public Transform transform { get; private set; }

			// Token: 0x17000094 RID: 148
			// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001F91B File Offset: 0x0001DB1B
			// (set) Token: 0x06000537 RID: 1335 RVA: 0x0001F923 File Offset: 0x0001DB23
			public float IKOffset { get; private set; }

			// Token: 0x17000095 RID: 149
			// (get) Token: 0x06000538 RID: 1336 RVA: 0x0001F92C File Offset: 0x0001DB2C
			// (set) Token: 0x06000539 RID: 1337 RVA: 0x0001F934 File Offset: 0x0001DB34
			public RaycastHit heelHit { get; private set; }

			// Token: 0x17000096 RID: 150
			// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001F93D File Offset: 0x0001DB3D
			// (set) Token: 0x0600053B RID: 1339 RVA: 0x0001F945 File Offset: 0x0001DB45
			public RaycastHit capsuleHit { get; private set; }

			// Token: 0x17000097 RID: 151
			// (get) Token: 0x0600053C RID: 1340 RVA: 0x0001F94E File Offset: 0x0001DB4E
			public RaycastHit GetHitPoint
			{
				get
				{
					if (this.grounding.quality == Grounding.Quality.Best)
					{
						return this.capsuleHit;
					}
					return this.heelHit;
				}
			}

			// Token: 0x0600053D RID: 1341 RVA: 0x0001F96B File Offset: 0x0001DB6B
			public void SetFootPosition(Vector3 position)
			{
				this.doOverrideFootPosition = true;
				this.overrideFootPosition = position;
			}

			// Token: 0x0600053E RID: 1342 RVA: 0x0001F97C File Offset: 0x0001DB7C
			public void Initiate(Grounding grounding, Transform transform)
			{
				this.initiated = false;
				this.grounding = grounding;
				this.transform = transform;
				this.up = Vector3.up;
				this.IKPosition = transform.position;
				this.rotationOffset = Quaternion.identity;
				this.initiated = true;
				this.OnEnable();
			}

			// Token: 0x0600053F RID: 1343 RVA: 0x0001F9CD File Offset: 0x0001DBCD
			public void OnEnable()
			{
				if (!this.initiated)
				{
					return;
				}
				this.lastPosition = this.transform.position;
				this.lastTime = Time.deltaTime;
			}

			// Token: 0x06000540 RID: 1344 RVA: 0x0001F9F4 File Offset: 0x0001DBF4
			public void Reset()
			{
				this.lastPosition = this.transform.position;
				this.lastTime = Time.deltaTime;
				this.IKOffset = 0f;
				this.IKPosition = this.transform.position;
				this.rotationOffset = Quaternion.identity;
			}

			// Token: 0x06000541 RID: 1345 RVA: 0x0001FA44 File Offset: 0x0001DC44
			public void Process()
			{
				if (!this.initiated)
				{
					return;
				}
				if (this.grounding.maxStep <= 0f)
				{
					return;
				}
				this.transformPosition = (this.doOverrideFootPosition ? this.overrideFootPosition : this.transform.position);
				this.doOverrideFootPosition = false;
				this.deltaTime = Time.time - this.lastTime;
				this.lastTime = Time.time;
				if (this.deltaTime == 0f)
				{
					return;
				}
				this.up = this.grounding.up;
				this.heightFromGround = float.PositiveInfinity;
				this.velocity = (this.transformPosition - this.lastPosition) / this.deltaTime;
				this.lastPosition = this.transformPosition;
				Vector3 vector = this.velocity * this.grounding.prediction;
				if (this.grounding.footRadius <= 0f)
				{
					this.grounding.quality = Grounding.Quality.Fastest;
				}
				this.isGrounded = false;
				switch (this.grounding.quality)
				{
				case Grounding.Quality.Fastest:
				{
					RaycastHit raycastHit = this.GetRaycastHit(vector);
					this.SetFootToPoint(raycastHit.normal, raycastHit.point);
					if (raycastHit.collider != null)
					{
						this.isGrounded = true;
					}
					break;
				}
				case Grounding.Quality.Simple:
				{
					this.heelHit = this.GetRaycastHit(Vector3.zero);
					Vector3 a = this.grounding.GetFootCenterOffset();
					if (this.invertFootCenter)
					{
						a = -a;
					}
					RaycastHit raycastHit2 = this.GetRaycastHit(a + vector);
					RaycastHit raycastHit3 = this.GetRaycastHit(this.grounding.root.right * this.grounding.footRadius * 0.5f);
					if (this.heelHit.collider != null || raycastHit2.collider != null || raycastHit3.collider != null)
					{
						this.isGrounded = true;
					}
					Vector3 vector2 = Vector3.Cross(raycastHit2.point - this.heelHit.point, raycastHit3.point - this.heelHit.point).normalized;
					if (Vector3.Dot(vector2, this.up) < 0f)
					{
						vector2 = -vector2;
					}
					this.SetFootToPlane(vector2, this.heelHit.point, this.heelHit.point);
					break;
				}
				case Grounding.Quality.Best:
					this.heelHit = this.GetRaycastHit(this.invertFootCenter ? (-this.grounding.GetFootCenterOffset()) : Vector3.zero);
					this.capsuleHit = this.GetCapsuleHit(vector);
					if (this.heelHit.collider != null || this.capsuleHit.collider != null)
					{
						this.isGrounded = true;
					}
					this.SetFootToPlane(this.capsuleHit.normal, this.capsuleHit.point, this.heelHit.point);
					break;
				}
				float num = this.stepHeightFromGround;
				if (!this.grounding.rootGrounded)
				{
					num = 0f;
				}
				this.IKOffset = Interp.LerpValue(this.IKOffset, num, this.grounding.footSpeed, this.grounding.footSpeed);
				this.IKOffset = Mathf.Lerp(this.IKOffset, num, this.deltaTime * this.grounding.footSpeed);
				float verticalOffset = this.grounding.GetVerticalOffset(this.transformPosition, this.grounding.root.position);
				float num2 = Mathf.Clamp(this.grounding.maxStep - verticalOffset, 0f, this.grounding.maxStep);
				this.IKOffset = Mathf.Clamp(this.IKOffset, -num2, this.IKOffset);
				this.RotateFoot();
				this.IKPosition = this.transformPosition - this.up * this.IKOffset;
				float footRotationWeight = this.grounding.footRotationWeight;
				this.rotationOffset = ((footRotationWeight >= 1f) ? this.r : Quaternion.Slerp(Quaternion.identity, this.r, footRotationWeight));
			}

			// Token: 0x17000098 RID: 152
			// (get) Token: 0x06000542 RID: 1346 RVA: 0x0001FEA3 File Offset: 0x0001E0A3
			public float stepHeightFromGround
			{
				get
				{
					return Mathf.Clamp(this.heightFromGround, -this.grounding.maxStep, this.grounding.maxStep);
				}
			}

			// Token: 0x06000543 RID: 1347 RVA: 0x0001FEC8 File Offset: 0x0001E0C8
			private RaycastHit GetCapsuleHit(Vector3 offsetFromHeel)
			{
				RaycastHit result = default(RaycastHit);
				Vector3 vector = this.grounding.GetFootCenterOffset();
				if (this.invertFootCenter)
				{
					vector = -vector;
				}
				Vector3 vector2 = this.transformPosition + vector;
				if (this.grounding.overstepFallsDown)
				{
					result.point = vector2 - this.up * this.grounding.maxStep;
				}
				else
				{
					result.point = new Vector3(vector2.x, this.grounding.root.position.y, vector2.z);
				}
				result.normal = this.up;
				Vector3 vector3 = vector2 + this.grounding.maxStep * this.up;
				Vector3 point = vector3 + offsetFromHeel;
				if (this.grounding.CapsuleCast(vector3, point, this.grounding.footRadius, -this.up, out result, this.grounding.maxStep * 2f, this.grounding.layers, QueryTriggerInteraction.Ignore) && float.IsNaN(result.point.x))
				{
					result.point = vector2 - this.up * this.grounding.maxStep * 2f;
					result.normal = this.up;
				}
				if (result.point == Vector3.zero && result.normal == Vector3.zero)
				{
					if (this.grounding.overstepFallsDown)
					{
						result.point = vector2 - this.up * this.grounding.maxStep;
					}
					else
					{
						result.point = new Vector3(vector2.x, this.grounding.root.position.y, vector2.z);
					}
				}
				return result;
			}

			// Token: 0x06000544 RID: 1348 RVA: 0x000200BC File Offset: 0x0001E2BC
			private RaycastHit GetRaycastHit(Vector3 offsetFromHeel)
			{
				RaycastHit result = default(RaycastHit);
				Vector3 vector = this.transformPosition + offsetFromHeel;
				if (this.grounding.overstepFallsDown)
				{
					result.point = vector - this.up * this.grounding.maxStep;
				}
				else
				{
					result.point = new Vector3(vector.x, this.grounding.root.position.y, vector.z);
				}
				result.normal = this.up;
				if (this.grounding.maxStep <= 0f)
				{
					return result;
				}
				this.grounding.Raycast(vector + this.grounding.maxStep * this.up, -this.up, out result, this.grounding.maxStep * 2f, this.grounding.layers, QueryTriggerInteraction.Ignore);
				if (result.point == Vector3.zero && result.normal == Vector3.zero)
				{
					if (this.grounding.overstepFallsDown)
					{
						result.point = vector - this.up * this.grounding.maxStep;
					}
					else
					{
						result.point = new Vector3(vector.x, this.grounding.root.position.y, vector.z);
					}
				}
				return result;
			}

			// Token: 0x06000545 RID: 1349 RVA: 0x00020240 File Offset: 0x0001E440
			private Vector3 RotateNormal(Vector3 normal)
			{
				if (this.grounding.quality == Grounding.Quality.Best)
				{
					return normal;
				}
				return Vector3.RotateTowards(this.up, normal, this.grounding.maxFootRotationAngle * 0.017453292f, this.deltaTime);
			}

			// Token: 0x06000546 RID: 1350 RVA: 0x00020275 File Offset: 0x0001E475
			private void SetFootToPoint(Vector3 normal, Vector3 point)
			{
				this.toHitNormal = Quaternion.FromToRotation(this.up, this.RotateNormal(normal));
				this.heightFromGround = this.GetHeightFromGround(point);
			}

			// Token: 0x06000547 RID: 1351 RVA: 0x0002029C File Offset: 0x0001E49C
			private void SetFootToPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 heelHitPoint)
			{
				planeNormal = this.RotateNormal(planeNormal);
				this.toHitNormal = Quaternion.FromToRotation(this.up, planeNormal);
				Vector3 hitPoint = V3Tools.LineToPlane(this.transformPosition + this.up * this.grounding.maxStep, -this.up, planeNormal, planePoint);
				this.heightFromGround = this.GetHeightFromGround(hitPoint);
				float heightFromGround = this.GetHeightFromGround(heelHitPoint);
				this.heightFromGround = Mathf.Clamp(this.heightFromGround, float.NegativeInfinity, heightFromGround);
			}

			// Token: 0x06000548 RID: 1352 RVA: 0x00020324 File Offset: 0x0001E524
			private float GetHeightFromGround(Vector3 hitPoint)
			{
				return this.grounding.GetVerticalOffset(this.transformPosition, hitPoint) - this.rootYOffset;
			}

			// Token: 0x06000549 RID: 1353 RVA: 0x00020340 File Offset: 0x0001E540
			private void RotateFoot()
			{
				Quaternion rotationOffsetTarget = this.GetRotationOffsetTarget();
				this.r = Quaternion.Slerp(this.r, rotationOffsetTarget, this.deltaTime * this.grounding.footRotationSpeed);
			}

			// Token: 0x0600054A RID: 1354 RVA: 0x00020378 File Offset: 0x0001E578
			private Quaternion GetRotationOffsetTarget()
			{
				if (this.grounding.maxFootRotationAngle <= 0f)
				{
					return Quaternion.identity;
				}
				if (this.grounding.maxFootRotationAngle >= 180f)
				{
					return this.toHitNormal;
				}
				return Quaternion.RotateTowards(Quaternion.identity, this.toHitNormal, this.grounding.maxFootRotationAngle);
			}

			// Token: 0x17000099 RID: 153
			// (get) Token: 0x0600054B RID: 1355 RVA: 0x000203D1 File Offset: 0x0001E5D1
			private float rootYOffset
			{
				get
				{
					return this.grounding.GetVerticalOffset(this.transformPosition, this.grounding.root.position - this.up * this.grounding.heightOffset);
				}
			}

			// Token: 0x040004A3 RID: 1187
			public Quaternion rotationOffset = Quaternion.identity;

			// Token: 0x040004A9 RID: 1193
			public bool invertFootCenter;

			// Token: 0x040004AC RID: 1196
			private Grounding grounding;

			// Token: 0x040004AD RID: 1197
			private float lastTime;

			// Token: 0x040004AE RID: 1198
			private float deltaTime;

			// Token: 0x040004AF RID: 1199
			private Vector3 lastPosition;

			// Token: 0x040004B0 RID: 1200
			private Quaternion toHitNormal;

			// Token: 0x040004B1 RID: 1201
			private Quaternion r;

			// Token: 0x040004B2 RID: 1202
			private Vector3 up = Vector3.up;

			// Token: 0x040004B3 RID: 1203
			private bool doOverrideFootPosition;

			// Token: 0x040004B4 RID: 1204
			private Vector3 overrideFootPosition;

			// Token: 0x040004B5 RID: 1205
			private Vector3 transformPosition;
		}

		// Token: 0x020000AB RID: 171
		public class Pelvis
		{
			// Token: 0x1700009A RID: 154
			// (get) Token: 0x0600054D RID: 1357 RVA: 0x0002042D File Offset: 0x0001E62D
			// (set) Token: 0x0600054E RID: 1358 RVA: 0x00020435 File Offset: 0x0001E635
			public Vector3 IKOffset { get; private set; }

			// Token: 0x1700009B RID: 155
			// (get) Token: 0x0600054F RID: 1359 RVA: 0x0002043E File Offset: 0x0001E63E
			// (set) Token: 0x06000550 RID: 1360 RVA: 0x00020446 File Offset: 0x0001E646
			public float heightOffset { get; private set; }

			// Token: 0x06000551 RID: 1361 RVA: 0x0002044F File Offset: 0x0001E64F
			public void Initiate(Grounding grounding)
			{
				this.grounding = grounding;
				this.initiated = true;
				this.OnEnable();
			}

			// Token: 0x06000552 RID: 1362 RVA: 0x00020465 File Offset: 0x0001E665
			public void Reset()
			{
				this.lastRootPosition = this.grounding.root.transform.position;
				this.lastTime = Time.deltaTime;
				this.IKOffset = Vector3.zero;
				this.heightOffset = 0f;
			}

			// Token: 0x06000553 RID: 1363 RVA: 0x000204A3 File Offset: 0x0001E6A3
			public void OnEnable()
			{
				if (!this.initiated)
				{
					return;
				}
				this.lastRootPosition = this.grounding.root.transform.position;
				this.lastTime = Time.time;
			}

			// Token: 0x06000554 RID: 1364 RVA: 0x000204D4 File Offset: 0x0001E6D4
			public void Process(float lowestOffset, float highestOffset, bool isGrounded)
			{
				if (!this.initiated)
				{
					return;
				}
				float num = Time.time - this.lastTime;
				this.lastTime = Time.time;
				if (num <= 0f)
				{
					return;
				}
				float b = lowestOffset + highestOffset;
				if (!this.grounding.rootGrounded)
				{
					b = 0f;
				}
				this.heightOffset = Mathf.Lerp(this.heightOffset, b, num * this.grounding.pelvisSpeed);
				Vector3 p = this.grounding.root.position - this.lastRootPosition;
				this.lastRootPosition = this.grounding.root.position;
				this.damperF = Interp.LerpValue(this.damperF, isGrounded ? 1f : 0f, 1f, 10f);
				this.heightOffset -= this.grounding.GetVerticalOffset(p, Vector3.zero) * this.grounding.pelvisDamper * this.damperF;
				this.IKOffset = this.grounding.up * this.heightOffset;
			}

			// Token: 0x040004B8 RID: 1208
			private Grounding grounding;

			// Token: 0x040004B9 RID: 1209
			private Vector3 lastRootPosition;

			// Token: 0x040004BA RID: 1210
			private float damperF;

			// Token: 0x040004BB RID: 1211
			private bool initiated;

			// Token: 0x040004BC RID: 1212
			private float lastTime;
		}
	}
}
