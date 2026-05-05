using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200008A RID: 138
	public abstract class RagdollCreator : MonoBehaviour
	{
		// Token: 0x0600045A RID: 1114 RVA: 0x0001B25C File Offset: 0x0001945C
		public static void ClearAll(Transform root)
		{
			if (root == null)
			{
				return;
			}
			Transform transform = root;
			Animator componentInChildren = root.GetComponentInChildren<Animator>();
			if (componentInChildren != null && componentInChildren.isHuman)
			{
				Transform boneTransform = componentInChildren.GetBoneTransform(HumanBodyBones.Hips);
				if (boneTransform != null && boneTransform.GetComponentsInChildren<Transform>().Length > 2)
				{
					transform = boneTransform;
				}
			}
			Transform[] componentsInChildren = transform.GetComponentsInChildren<Transform>();
			if (componentsInChildren.Length < 2)
			{
				return;
			}
			for (int i = (componentInChildren != null && componentInChildren.isHuman) ? 0 : 1; i < componentsInChildren.Length; i++)
			{
				RagdollCreator.ClearTransform(componentsInChildren[i]);
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0001B2E8 File Offset: 0x000194E8
		protected static void ClearTransform(Transform transform)
		{
			if (transform == null)
			{
				return;
			}
			if (transform.name == "Foot Collider")
			{
				Object.DestroyImmediate(transform.gameObject);
				return;
			}
			foreach (Collider collider in transform.GetComponents<Collider>())
			{
				if (collider != null && !collider.isTrigger)
				{
					Object.DestroyImmediate(collider);
				}
			}
			Joint component = transform.GetComponent<Joint>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
			Rigidbody component2 = transform.GetComponent<Rigidbody>();
			if (component2 != null)
			{
				Object.DestroyImmediate(component2);
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0001B380 File Offset: 0x00019580
		protected static Collider CreateCollider(Transform t, Vector3 startPoint, Vector3 endPoint, RagdollCreator.ColliderType colliderType, float lengthOverlap, float width, Transform rigidbodyT = null)
		{
			if (rigidbodyT == null)
			{
				rigidbodyT = t;
			}
			Vector3 direction = endPoint - startPoint;
			float num = direction.magnitude * (1f + lengthOverlap);
			Vector3 axisVectorToDirection = AxisTools.GetAxisVectorToDirection(t, direction);
			rigidbodyT.gameObject.AddComponent<Rigidbody>();
			float scaleF = RagdollCreator.GetScaleF(t);
			if (colliderType == RagdollCreator.ColliderType.Box)
			{
				Vector3 vector = Vector3.Scale(axisVectorToDirection, new Vector3(num, num, num));
				if (vector.x == 0f)
				{
					vector.x = width;
				}
				if (vector.y == 0f)
				{
					vector.y = width;
				}
				if (vector.z == 0f)
				{
					vector.z = width;
				}
				BoxCollider boxCollider = t.gameObject.AddComponent<BoxCollider>();
				boxCollider.size = vector / scaleF;
				boxCollider.size = new Vector3(Mathf.Abs(boxCollider.size.x), Mathf.Abs(boxCollider.size.y), Mathf.Abs(boxCollider.size.z));
				boxCollider.center = t.InverseTransformPoint(Vector3.Lerp(startPoint, endPoint, 0.5f));
				return boxCollider;
			}
			if (colliderType == RagdollCreator.ColliderType.Capsule)
			{
				CapsuleCollider capsuleCollider = t.gameObject.AddComponent<CapsuleCollider>();
				capsuleCollider.height = Mathf.Abs(num / scaleF);
				capsuleCollider.radius = Mathf.Abs(width * 0.75f / scaleF);
				capsuleCollider.direction = RagdollCreator.DirectionVector3ToInt(axisVectorToDirection);
				capsuleCollider.center = t.InverseTransformPoint(Vector3.Lerp(startPoint, endPoint, 0.5f));
				return capsuleCollider;
			}
			return null;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0001B4FC File Offset: 0x000196FC
		protected static void CreateCollider(Transform t, Vector3 startPoint, Vector3 endPoint, RagdollCreator.ColliderType colliderType, float lengthOverlap, float width, float proportionAspect, Vector3 widthDirection)
		{
			if (colliderType == RagdollCreator.ColliderType.Capsule)
			{
				RagdollCreator.CreateCollider(t, startPoint, endPoint, colliderType, lengthOverlap, width * proportionAspect, null);
				return;
			}
			Vector3 direction = endPoint - startPoint;
			float num = direction.magnitude * (1f + lengthOverlap);
			Vector3 axisVectorToDirection = AxisTools.GetAxisVectorToDirection(t, direction);
			Vector3 axisVectorToDirection2 = AxisTools.GetAxisVectorToDirection(t, widthDirection);
			if (axisVectorToDirection2 == axisVectorToDirection)
			{
				Debug.LogWarning("Width axis = height axis on " + t.name, t);
				axisVectorToDirection2 = new Vector3(axisVectorToDirection.y, axisVectorToDirection.z, axisVectorToDirection.x);
			}
			t.gameObject.AddComponent<Rigidbody>();
			Vector3 a = Vector3.Scale(axisVectorToDirection, new Vector3(num, num, num));
			Vector3 b = Vector3.Scale(axisVectorToDirection2, new Vector3(width, width, width));
			Vector3 vector = a + b;
			if (vector.x == 0f)
			{
				vector.x = width * proportionAspect;
			}
			if (vector.y == 0f)
			{
				vector.y = width * proportionAspect;
			}
			if (vector.z == 0f)
			{
				vector.z = width * proportionAspect;
			}
			BoxCollider boxCollider = t.gameObject.AddComponent<BoxCollider>();
			boxCollider.size = vector / RagdollCreator.GetScaleF(t);
			boxCollider.center = t.InverseTransformPoint(Vector3.Lerp(startPoint, endPoint, 0.5f));
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0001B63C File Offset: 0x0001983C
		protected static float GetScaleF(Transform t)
		{
			Vector3 lossyScale = t.lossyScale;
			return (lossyScale.x + lossyScale.y + lossyScale.z) / 3f;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0001B66A File Offset: 0x0001986A
		protected static Vector3 Abs(Vector3 v)
		{
			RagdollCreator.Vector3Abs(ref v);
			return v;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0001B674 File Offset: 0x00019874
		protected static void Vector3Abs(ref Vector3 v)
		{
			v.x = Mathf.Abs(v.x);
			v.y = Mathf.Abs(v.y);
			v.z = Mathf.Abs(v.z);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00004A42 File Offset: 0x00002C42
		protected static Vector3 DirectionIntToVector3(int dir)
		{
			if (dir == 0)
			{
				return Vector3.right;
			}
			if (dir == 1)
			{
				return Vector3.up;
			}
			return Vector3.forward;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00004A42 File Offset: 0x00002C42
		protected static Vector3 DirectionToVector3(RagdollCreator.Direction dir)
		{
			if (dir == RagdollCreator.Direction.X)
			{
				return Vector3.right;
			}
			if (dir == RagdollCreator.Direction.Y)
			{
				return Vector3.up;
			}
			return Vector3.forward;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0001B6AC File Offset: 0x000198AC
		protected static int DirectionVector3ToInt(Vector3 dir)
		{
			float f = Vector3.Dot(dir, Vector3.right);
			float f2 = Vector3.Dot(dir, Vector3.up);
			float f3 = Vector3.Dot(dir, Vector3.forward);
			float num = Mathf.Abs(f);
			float num2 = Mathf.Abs(f2);
			float num3 = Mathf.Abs(f3);
			int result = 0;
			if (num2 > num && num2 > num3)
			{
				result = 1;
			}
			if (num3 > num && num3 > num2)
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0001B710 File Offset: 0x00019910
		protected static Vector3 GetLocalOrthoDirection(Transform transform, Vector3 worldDir)
		{
			worldDir = worldDir.normalized;
			float f = Vector3.Dot(worldDir, transform.right);
			float f2 = Vector3.Dot(worldDir, transform.up);
			float f3 = Vector3.Dot(worldDir, transform.forward);
			float num = Mathf.Abs(f);
			float num2 = Mathf.Abs(f2);
			float num3 = Mathf.Abs(f3);
			Vector3 vector = Vector3.right;
			if (num2 > num && num2 > num3)
			{
				vector = Vector3.up;
			}
			if (num3 > num && num3 > num2)
			{
				vector = Vector3.forward;
			}
			if (Vector3.Dot(worldDir, transform.rotation * vector) < 0f)
			{
				vector = -vector;
			}
			return vector;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0001B7B0 File Offset: 0x000199B0
		protected static Rigidbody GetConnectedBody(Transform bone, ref Transform[] bones)
		{
			if (bone.parent == null)
			{
				return null;
			}
			foreach (Transform transform in bones)
			{
				if (bone.parent == transform && transform.GetComponent<Rigidbody>() != null)
				{
					return transform.GetComponent<Rigidbody>();
				}
			}
			return RagdollCreator.GetConnectedBody(bone.parent, ref bones);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0001B814 File Offset: 0x00019A14
		protected static void CreateJoint(RagdollCreator.CreateJointParams p)
		{
			Vector3 localOrthoDirection = RagdollCreator.GetLocalOrthoDirection(p.rigidbody.transform, p.worldSwingAxis);
			Vector3 rhs = Vector3.forward;
			if (p.child != null)
			{
				rhs = RagdollCreator.GetLocalOrthoDirection(p.rigidbody.transform, p.child.position - p.rigidbody.transform.position);
			}
			else if (p.connectedBody != null)
			{
				rhs = RagdollCreator.GetLocalOrthoDirection(p.rigidbody.transform, p.rigidbody.transform.position - p.connectedBody.transform.position);
			}
			Vector3 vector = Vector3.Cross(localOrthoDirection, rhs);
			if (p.type == RagdollCreator.JointType.Configurable)
			{
				ConfigurableJoint configurableJoint = p.rigidbody.gameObject.AddComponent<ConfigurableJoint>();
				configurableJoint.connectedBody = p.connectedBody;
				ConfigurableJointMotion configurableJointMotion = (p.connectedBody != null) ? ConfigurableJointMotion.Locked : ConfigurableJointMotion.Free;
				ConfigurableJointMotion configurableJointMotion2 = (p.connectedBody != null) ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Free;
				configurableJoint.xMotion = configurableJointMotion;
				configurableJoint.yMotion = configurableJointMotion;
				configurableJoint.zMotion = configurableJointMotion;
				configurableJoint.angularXMotion = configurableJointMotion2;
				configurableJoint.angularYMotion = configurableJointMotion2;
				configurableJoint.angularZMotion = configurableJointMotion2;
				if (p.connectedBody != null)
				{
					configurableJoint.axis = localOrthoDirection;
					configurableJoint.secondaryAxis = vector;
					configurableJoint.lowAngularXLimit = RagdollCreator.ToSoftJointLimit(p.limits.minSwing);
					configurableJoint.highAngularXLimit = RagdollCreator.ToSoftJointLimit(p.limits.maxSwing);
					configurableJoint.angularYLimit = RagdollCreator.ToSoftJointLimit(p.limits.swing2);
					configurableJoint.angularZLimit = RagdollCreator.ToSoftJointLimit(p.limits.twist);
				}
				configurableJoint.anchor = Vector3.zero;
				return;
			}
			if (p.connectedBody == null)
			{
				return;
			}
			CharacterJoint characterJoint = p.rigidbody.gameObject.AddComponent<CharacterJoint>();
			characterJoint.connectedBody = p.connectedBody;
			characterJoint.axis = localOrthoDirection;
			characterJoint.swingAxis = vector;
			characterJoint.lowTwistLimit = RagdollCreator.ToSoftJointLimit(p.limits.minSwing);
			characterJoint.highTwistLimit = RagdollCreator.ToSoftJointLimit(p.limits.maxSwing);
			characterJoint.swing1Limit = RagdollCreator.ToSoftJointLimit(p.limits.swing2);
			characterJoint.swing2Limit = RagdollCreator.ToSoftJointLimit(p.limits.twist);
			characterJoint.anchor = Vector3.zero;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0001BA68 File Offset: 0x00019C68
		private static SoftJointLimit ToSoftJointLimit(float limit)
		{
			return new SoftJointLimit
			{
				limit = limit
			};
		}

		// Token: 0x0200008B RID: 139
		[Serializable]
		public enum ColliderType
		{
			// Token: 0x040003E3 RID: 995
			Box,
			// Token: 0x040003E4 RID: 996
			Capsule
		}

		// Token: 0x0200008C RID: 140
		[Serializable]
		public enum JointType
		{
			// Token: 0x040003E6 RID: 998
			Configurable,
			// Token: 0x040003E7 RID: 999
			Character
		}

		// Token: 0x0200008D RID: 141
		[Serializable]
		public enum Direction
		{
			// Token: 0x040003E9 RID: 1001
			X,
			// Token: 0x040003EA RID: 1002
			Y,
			// Token: 0x040003EB RID: 1003
			Z
		}

		// Token: 0x0200008E RID: 142
		public struct CreateJointParams
		{
			// Token: 0x06000469 RID: 1129 RVA: 0x0001BA86 File Offset: 0x00019C86
			public CreateJointParams(Rigidbody rigidbody, Rigidbody connectedBody, Transform child, Vector3 worldSwingAxis, RagdollCreator.CreateJointParams.Limits limits, RagdollCreator.JointType type)
			{
				this.rigidbody = rigidbody;
				this.connectedBody = connectedBody;
				this.child = child;
				this.worldSwingAxis = worldSwingAxis;
				this.limits = limits;
				this.type = type;
			}

			// Token: 0x040003EC RID: 1004
			public Rigidbody rigidbody;

			// Token: 0x040003ED RID: 1005
			public Rigidbody connectedBody;

			// Token: 0x040003EE RID: 1006
			public Transform child;

			// Token: 0x040003EF RID: 1007
			public Vector3 worldSwingAxis;

			// Token: 0x040003F0 RID: 1008
			public RagdollCreator.CreateJointParams.Limits limits;

			// Token: 0x040003F1 RID: 1009
			public RagdollCreator.JointType type;

			// Token: 0x0200008F RID: 143
			public struct Limits
			{
				// Token: 0x0600046A RID: 1130 RVA: 0x0001BAB5 File Offset: 0x00019CB5
				public Limits(float minSwing, float maxSwing, float swing2, float twist)
				{
					this.minSwing = minSwing;
					this.maxSwing = maxSwing;
					this.swing2 = swing2;
					this.twist = twist;
				}

				// Token: 0x040003F2 RID: 1010
				public float minSwing;

				// Token: 0x040003F3 RID: 1011
				public float maxSwing;

				// Token: 0x040003F4 RID: 1012
				public float swing2;

				// Token: 0x040003F5 RID: 1013
				public float twist;
			}
		}
	}
}
