using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000085 RID: 133
	[HelpURL("https://www.youtube.com/watch?v=y-luLRVmL7E&index=1&list=PLVxSIA1OaTOuE2SB9NUbckQ9r2hTg4mvL")]
	[AddComponentMenu("Scripts/RootMotion.Dynamics/Ragdoll Manager/Biped Ragdoll Creator")]
	public class BipedRagdollCreator : RagdollCreator
	{
		// Token: 0x0600042B RID: 1067 RVA: 0x00018C5B File Offset: 0x00016E5B
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page1.html");
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00018C67 File Offset: 0x00016E67
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/class_root_motion_1_1_dynamics_1_1_biped_ragdoll_creator.html#details");
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00018C73 File Offset: 0x00016E73
		[ContextMenu("TUTORIAL VIDEO")]
		private void OpenTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=y-luLRVmL7E&index=1&list=PLVxSIA1OaTOuE2SB9NUbckQ9r2hTg4mvL");
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00018C80 File Offset: 0x00016E80
		public static BipedRagdollCreator.Options AutodetectOptions(BipedRagdollReferences r)
		{
			BipedRagdollCreator.Options @default = BipedRagdollCreator.Options.Default;
			if (r.spine == null)
			{
				@default.spine = false;
			}
			if (r.chest == null)
			{
				@default.chest = false;
			}
			if (@default.chest && Vector3.Dot(r.root.up, r.chest.position - BipedRagdollCreator.GetUpperArmCentroid(r)) > 0f)
			{
				@default.chest = false;
				if (r.spine != null)
				{
					@default.spine = true;
				}
			}
			return @default;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00018D14 File Offset: 0x00016F14
		public static void Create(BipedRagdollReferences r, BipedRagdollCreator.Options options)
		{
			string empty = string.Empty;
			if (!r.IsValid(ref empty))
			{
				Debug.LogWarning(empty);
				return;
			}
			RagdollCreator.ClearAll(r.root);
			BipedRagdollCreator.CreateColliders(r, options);
			BipedRagdollCreator.MassDistribution(r, options);
			BipedRagdollCreator.CreateJoints(r, options);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00018D5C File Offset: 0x00016F5C
		private static void CreateColliders(BipedRagdollReferences r, BipedRagdollCreator.Options options)
		{
			Vector3 upperArmToHeadCentroid = BipedRagdollCreator.GetUpperArmToHeadCentroid(r);
			if (r.spine == null)
			{
				options.spine = false;
			}
			if (r.chest == null)
			{
				options.chest = false;
			}
			Vector3 widthDirection = r.rightUpperArm.position - r.leftUpperArm.position;
			float magnitude = widthDirection.magnitude;
			float proportionAspect = 0.6f;
			Vector3 vector = r.hips.position;
			float num = Vector3.Distance(r.head.position, r.root.position);
			if (Vector3.Distance(r.hips.position, r.root.position) < num * 0.2f)
			{
				vector = Vector3.Lerp(r.leftUpperLeg.position, r.rightUpperLeg.position, 0.5f);
			}
			Vector3 vector2 = options.spine ? r.spine.position : (options.chest ? r.chest.position : upperArmToHeadCentroid);
			vector += (vector - upperArmToHeadCentroid) * 0.1f;
			float width = (options.spine || options.chest) ? (magnitude * 0.8f) : magnitude;
			RagdollCreator.CreateCollider(r.hips, vector, vector2, options.torsoColliders, options.colliderLengthOverlap, width, proportionAspect, widthDirection);
			if (options.spine)
			{
				Vector3 startPoint = vector2;
				vector2 = (options.chest ? r.chest.position : upperArmToHeadCentroid);
				float width2 = options.chest ? (magnitude * 0.75f) : magnitude;
				RagdollCreator.CreateCollider(r.spine, startPoint, vector2, options.torsoColliders, options.colliderLengthOverlap, width2, proportionAspect, widthDirection);
			}
			if (options.chest)
			{
				Vector3 startPoint2 = vector2;
				vector2 = upperArmToHeadCentroid;
				RagdollCreator.CreateCollider(r.chest, startPoint2, vector2, options.torsoColliders, options.colliderLengthOverlap, magnitude, proportionAspect, widthDirection);
			}
			Vector3 vector3 = vector2;
			Vector3 vector4 = vector3 + (vector3 - vector) * 0.45f;
			Vector3 onNormal = r.head.TransformVector(AxisTools.GetAxisVectorToDirection(r.head, vector4 - vector3));
			vector4 = vector3 + Vector3.Project(vector4 - vector3, onNormal).normalized * (vector4 - vector3).magnitude;
			RagdollCreator.CreateCollider(r.head, vector3, vector4, options.headCollider, options.colliderLengthOverlap, Vector3.Distance(vector3, vector4) * 0.8f, null);
			float num2 = 0.4f;
			float num3 = Vector3.Distance(r.leftUpperArm.position, r.leftLowerArm.position) * num2;
			RagdollCreator.CreateCollider(r.leftUpperArm, r.leftUpperArm.position, r.leftLowerArm.position, options.armColliders, options.colliderLengthOverlap, num3, null);
			RagdollCreator.CreateCollider(r.leftLowerArm, r.leftLowerArm.position, r.leftHand.position, options.armColliders, options.colliderLengthOverlap, num3 * 0.9f, null);
			float num4 = Vector3.Distance(r.rightUpperArm.position, r.rightLowerArm.position) * num2;
			RagdollCreator.CreateCollider(r.rightUpperArm, r.rightUpperArm.position, r.rightLowerArm.position, options.armColliders, options.colliderLengthOverlap, num4, null);
			RagdollCreator.CreateCollider(r.rightLowerArm, r.rightLowerArm.position, r.rightHand.position, options.armColliders, options.colliderLengthOverlap, num4 * 0.9f, null);
			float num5 = 0.3f;
			float num6 = Vector3.Distance(r.leftUpperLeg.position, r.leftLowerLeg.position) * num5;
			RagdollCreator.CreateCollider(r.leftUpperLeg, r.leftUpperLeg.position, r.leftLowerLeg.position, options.legColliders, options.colliderLengthOverlap, num6, null);
			RagdollCreator.CreateCollider(r.leftLowerLeg, r.leftLowerLeg.position, r.leftFoot.position, options.legColliders, options.colliderLengthOverlap, num6 * 0.9f, null);
			float num7 = Vector3.Distance(r.rightUpperLeg.position, r.rightLowerLeg.position) * num5;
			RagdollCreator.CreateCollider(r.rightUpperLeg, r.rightUpperLeg.position, r.rightLowerLeg.position, options.legColliders, options.colliderLengthOverlap, num7, null);
			RagdollCreator.CreateCollider(r.rightLowerLeg, r.rightLowerLeg.position, r.rightFoot.position, options.legColliders, options.colliderLengthOverlap, num7 * 0.9f, null);
			if (options.hands)
			{
				BipedRagdollCreator.CreateHandCollider(r.leftHand, r.leftLowerArm, r.root, options);
				BipedRagdollCreator.CreateHandCollider(r.rightHand, r.rightLowerArm, r.root, options);
			}
			if (options.feet)
			{
				BipedRagdollCreator.CreateFootCollider(r.leftFoot, r.leftLowerLeg, r.leftUpperLeg, r.root, options);
				BipedRagdollCreator.CreateFootCollider(r.rightFoot, r.rightLowerLeg, r.rightUpperLeg, r.root, options);
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00019290 File Offset: 0x00017490
		private static Collider CopyCollider(Collider c, GameObject destination)
		{
			if (c is CapsuleCollider)
			{
				return BipedRagdollCreator.CopyCapsuleCollider(c as CapsuleCollider, destination);
			}
			if (c is SphereCollider)
			{
				return BipedRagdollCreator.CopySphereCollider(c as SphereCollider, destination);
			}
			if (c is BoxCollider)
			{
				return BipedRagdollCreator.CopyBoxCollider(c as BoxCollider, destination);
			}
			return null;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000192E0 File Offset: 0x000174E0
		private static CapsuleCollider CopyCapsuleCollider(CapsuleCollider o, GameObject destination)
		{
			CapsuleCollider capsuleCollider = destination.GetComponent<CapsuleCollider>();
			if (capsuleCollider == null)
			{
				capsuleCollider = destination.AddComponent<CapsuleCollider>();
			}
			capsuleCollider.isTrigger = o.isTrigger;
			capsuleCollider.sharedMaterial = o.sharedMaterial;
			capsuleCollider.center = o.center;
			capsuleCollider.radius = o.radius;
			capsuleCollider.height = o.height;
			capsuleCollider.direction = o.direction;
			return capsuleCollider;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00019350 File Offset: 0x00017550
		private static SphereCollider CopySphereCollider(SphereCollider o, GameObject destination)
		{
			SphereCollider sphereCollider = destination.GetComponent<SphereCollider>();
			if (sphereCollider == null)
			{
				sphereCollider = destination.AddComponent<SphereCollider>();
			}
			sphereCollider.isTrigger = o.isTrigger;
			sphereCollider.sharedMaterial = o.sharedMaterial;
			sphereCollider.center = o.center;
			sphereCollider.radius = o.radius;
			return sphereCollider;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000193A8 File Offset: 0x000175A8
		private static BoxCollider CopyBoxCollider(BoxCollider o, GameObject destination)
		{
			BoxCollider boxCollider = destination.GetComponent<BoxCollider>();
			if (boxCollider == null)
			{
				boxCollider = destination.AddComponent<BoxCollider>();
			}
			boxCollider.isTrigger = o.isTrigger;
			boxCollider.sharedMaterial = o.sharedMaterial;
			boxCollider.center = o.center;
			boxCollider.size = o.size;
			return boxCollider;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00019400 File Offset: 0x00017600
		private static void CreateHandCollider(Transform hand, Transform lowerArm, Transform root, BipedRagdollCreator.Options options)
		{
			Vector3 onNormal = hand.TransformVector(AxisTools.GetAxisVectorToPoint(hand, BipedRagdollCreator.GetChildCentroid(hand, lowerArm.position)));
			Vector3 vector = hand.position - (lowerArm.position - hand.position) * 0.75f;
			vector = hand.position + Vector3.Project(vector - hand.position, onNormal).normalized * (vector - hand.position).magnitude;
			RagdollCreator.CreateCollider(hand, hand.position, vector, options.handColliders, options.colliderLengthOverlap, Vector3.Distance(vector, hand.position) * 0.5f, null);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000194BC File Offset: 0x000176BC
		private static void CreateFootCollider(Transform foot, Transform lowerLeg, Transform upperLeg, Transform root, BipedRagdollCreator.Options options)
		{
			float magnitude = (upperLeg.position - foot.position).magnitude;
			Vector3 onNormal = foot.TransformVector(AxisTools.GetAxisVectorToPoint(foot, BipedRagdollCreator.GetChildCentroid(foot, foot.position + root.forward) + root.forward * magnitude * 0.2f));
			Vector3 a = foot.position + root.forward * magnitude * 0.25f;
			a = foot.position + Vector3.Project(a - foot.position, onNormal).normalized * (a - foot.position).magnitude;
			float num = Vector3.Distance(a, foot.position) * 0.5f;
			Vector3 vector = foot.position;
			Vector3 b = (Vector3.Dot(root.up, foot.position - root.position) < 0f) ? Vector3.zero : Vector3.Project(vector - root.up * num * 0.5f - root.position, root.up);
			Vector3 a2 = a - vector;
			vector -= a2 * 0.2f;
			if (options.fixFootColliderRotation)
			{
				Vector3 vector2 = AxisTools.GetAxisVectorToDirection(foot, root.forward);
				if (Vector3.Dot(foot.rotation * vector2, root.forward) < 0f)
				{
					vector2 = -vector2;
				}
				Vector3 up = Vector3.up;
				Vector3 b2 = foot.rotation * vector2;
				Vector3.OrthoNormalize(ref up, ref b2);
				Vector3 vector3 = foot.position + b2;
				Vector3 childCentroidRecursive = BipedRagdollCreator.GetChildCentroidRecursive(foot, vector3);
				childCentroidRecursive - foot.position;
				Transform transform = new GameObject("Foot Collider").transform;
				transform.parent = foot;
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				Collider c = RagdollCreator.CreateCollider(transform, vector - b, a - b, options.footColliders, options.colliderLengthOverlap, num, foot);
				transform.rotation = Quaternion.FromToRotation(transform.rotation * vector2, childCentroidRecursive - transform.position) * transform.rotation;
				BipedRagdollCreator.Orthogonize(transform, root.forward, root.up);
				BipedRagdollCreator.Orthogonize(transform, root.right, root.up);
				if (childCentroidRecursive != vector3)
				{
					Vector3 a3 = Vector3.Lerp(foot.position, childCentroidRecursive, 0.5f);
					Vector3 colliderCenter = BipedRagdollCreator.GetColliderCenter(c);
					transform.position += a3 - colliderCenter;
					float colliderBottom = BipedRagdollCreator.GetColliderBottom(c, root.up);
					transform.position += Vector3.up * (root.position.y - colliderBottom);
					return;
				}
			}
			else
			{
				RagdollCreator.CreateCollider(foot, vector - b, a - b, options.footColliders, options.colliderLengthOverlap, num, null);
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00019808 File Offset: 0x00017A08
		public static Collider FixFootCollider(Transform foot, Transform root)
		{
			Vector3 vector = AxisTools.GetAxisVectorToDirection(foot, root.forward);
			if (Vector3.Dot(foot.rotation * vector, root.forward) < 0f)
			{
				vector = -vector;
			}
			Vector3 up = Vector3.up;
			Vector3 b = foot.rotation * vector;
			Vector3.OrthoNormalize(ref up, ref b);
			Vector3 vector2 = foot.position + b;
			Vector3 childCentroidRecursive = BipedRagdollCreator.GetChildCentroidRecursive(foot, vector2);
			childCentroidRecursive - foot.position;
			Transform transform = new GameObject("Foot Collider").transform;
			transform.parent = foot;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			Collider component = foot.GetComponent<Collider>();
			Collider collider = BipedRagdollCreator.CopyCollider(component, transform.gameObject);
			if (Application.isPlaying)
			{
				Object.Destroy(component);
			}
			else
			{
				Object.DestroyImmediate(component);
			}
			transform.rotation = Quaternion.FromToRotation(transform.rotation * vector, childCentroidRecursive - transform.position) * transform.rotation;
			BipedRagdollCreator.Orthogonize(transform, root.forward, root.up);
			BipedRagdollCreator.Orthogonize(transform, root.right, root.up);
			if (childCentroidRecursive != vector2)
			{
				Vector3 a = Vector3.Lerp(foot.position, childCentroidRecursive, 0.5f);
				Vector3 colliderCenter = BipedRagdollCreator.GetColliderCenter(collider);
				transform.position += a - colliderCenter;
				float colliderBottom = BipedRagdollCreator.GetColliderBottom(collider, root.up);
				transform.position += Vector3.up * (root.position.y - colliderBottom);
			}
			return collider;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000199C0 File Offset: 0x00017BC0
		private static Vector3 GetColliderCenter(Collider c)
		{
			if (c is BoxCollider)
			{
				return c.transform.TransformPoint((c as BoxCollider).center);
			}
			if (c is CapsuleCollider)
			{
				return c.transform.TransformPoint((c as CapsuleCollider).center);
			}
			return c.transform.position;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00019A18 File Offset: 0x00017C18
		private static float GetColliderBottom(Collider c, Vector3 up)
		{
			Transform transform = c.transform;
			if (c is BoxCollider)
			{
				BoxCollider boxCollider = c as BoxCollider;
				Vector3 vector = AxisTools.GetAxisVectorToDirection(transform, -up);
				if (Vector3.Dot(transform.rotation * vector, -up) < 0f)
				{
					vector = -vector;
				}
				Vector3 point = Vector3.Scale(boxCollider.size, vector * 0.5f);
				return (transform.TransformPoint(boxCollider.center) + transform.rotation * point).y;
			}
			if (c is CapsuleCollider)
			{
				CapsuleCollider capsuleCollider = c as CapsuleCollider;
				Vector3 vector2 = AxisTools.GetAxisVectorToDirection(transform, -up);
				if (Vector3.Dot(transform.rotation * vector2, -up) < 0f)
				{
					vector2 = -vector2;
				}
				Vector3 point2 = capsuleCollider.radius * vector2 * 0.5f;
				return (transform.TransformPoint(capsuleCollider.center) + transform.rotation * point2).y;
			}
			return BipedRagdollCreator.GetColliderCenter(c).y;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00019B38 File Offset: 0x00017D38
		private static void Orthogonize(Transform t, Vector3 direction, Vector3 normal)
		{
			Vector3 vector = AxisTools.GetAxisVectorToDirection(t, direction);
			if (Vector3.Dot(t.rotation * vector, direction) < 0f)
			{
				vector = -vector;
			}
			Vector3 toDirection = t.rotation * vector;
			Vector3.OrthoNormalize(ref normal, ref toDirection);
			t.rotation = Quaternion.FromToRotation(t.rotation * vector, toDirection) * t.rotation;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00019BA8 File Offset: 0x00017DA8
		private static Vector3 GetChildCentroidRecursive(Transform t, Vector3 fallback)
		{
			Transform[] componentsInChildren = t.GetComponentsInChildren<Transform>();
			if (componentsInChildren.Length < 2)
			{
				return fallback;
			}
			Vector3 a = Vector3.zero;
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				a += componentsInChildren[i].position;
			}
			return a / (float)(componentsInChildren.Length - 1);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00019BF8 File Offset: 0x00017DF8
		private static Vector3 GetChildCentroid(Transform t, Vector3 fallback)
		{
			if (t.childCount == 0)
			{
				return fallback;
			}
			Vector3 a = Vector3.zero;
			for (int i = 0; i < t.childCount; i++)
			{
				a += t.GetChild(i).position;
			}
			return a / (float)t.childCount;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00019C48 File Offset: 0x00017E48
		private static void MassDistribution(BipedRagdollReferences r, BipedRagdollCreator.Options o)
		{
			int num = 3;
			if (r.spine == null)
			{
				o.spine = false;
				num--;
			}
			if (r.chest == null)
			{
				o.chest = false;
				num--;
			}
			float num2 = 0.508f / (float)num;
			float num3 = 0.0732f;
			float num4 = 0.027f;
			float num5 = 0.016f;
			float num6 = 0.0066f;
			float num7 = 0.0988f;
			float num8 = 0.0465f;
			float num9 = 0.0145f;
			r.hips.GetComponent<Rigidbody>().mass = num2 * o.weight;
			if (o.spine)
			{
				r.spine.GetComponent<Rigidbody>().mass = num2 * o.weight;
			}
			if (o.chest)
			{
				r.chest.GetComponent<Rigidbody>().mass = num2 * o.weight;
			}
			r.head.GetComponent<Rigidbody>().mass = num3 * o.weight;
			r.leftUpperArm.GetComponent<Rigidbody>().mass = num4 * o.weight;
			r.rightUpperArm.GetComponent<Rigidbody>().mass = r.leftUpperArm.GetComponent<Rigidbody>().mass;
			r.leftLowerArm.GetComponent<Rigidbody>().mass = num5 * o.weight;
			r.rightLowerArm.GetComponent<Rigidbody>().mass = r.leftLowerArm.GetComponent<Rigidbody>().mass;
			if (o.hands)
			{
				r.leftHand.GetComponent<Rigidbody>().mass = num6 * o.weight;
				r.rightHand.GetComponent<Rigidbody>().mass = r.leftHand.GetComponent<Rigidbody>().mass;
			}
			r.leftUpperLeg.GetComponent<Rigidbody>().mass = num7 * o.weight;
			r.rightUpperLeg.GetComponent<Rigidbody>().mass = r.leftUpperLeg.GetComponent<Rigidbody>().mass;
			r.leftLowerLeg.GetComponent<Rigidbody>().mass = num8 * o.weight;
			r.rightLowerLeg.GetComponent<Rigidbody>().mass = r.leftLowerLeg.GetComponent<Rigidbody>().mass;
			if (o.feet)
			{
				r.leftFoot.GetComponent<Rigidbody>().mass = num9 * o.weight;
				r.rightFoot.GetComponent<Rigidbody>().mass = r.leftFoot.GetComponent<Rigidbody>().mass;
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00019E98 File Offset: 0x00018098
		private static void CreateJoints(BipedRagdollReferences r, BipedRagdollCreator.Options o)
		{
			if (r.spine == null)
			{
				o.spine = false;
			}
			if (r.chest == null)
			{
				o.chest = false;
			}
			float minSwing = -30f * o.jointRange;
			float maxSwing = 10f * o.jointRange;
			float swing = 25f * o.jointRange;
			float twist = 25f * o.jointRange;
			RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(r.hips.GetComponent<Rigidbody>(), null, o.spine ? r.spine : (o.chest ? r.chest : r.head), r.root.right, new RagdollCreator.CreateJointParams.Limits(0f, 0f, 0f, 0f), o.joints));
			if (o.spine)
			{
				RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(r.spine.GetComponent<Rigidbody>(), r.hips.GetComponent<Rigidbody>(), o.chest ? r.chest : r.head, r.root.right, new RagdollCreator.CreateJointParams.Limits(minSwing, maxSwing, swing, twist), o.joints));
			}
			if (o.chest)
			{
				RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(r.chest.GetComponent<Rigidbody>(), o.spine ? r.spine.GetComponent<Rigidbody>() : r.hips.GetComponent<Rigidbody>(), r.head, r.root.right, new RagdollCreator.CreateJointParams.Limits(minSwing, maxSwing, swing, twist), o.joints));
			}
			Transform transform = o.chest ? r.chest : (o.spine ? r.spine : r.hips);
			RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(r.head.GetComponent<Rigidbody>(), transform.GetComponent<Rigidbody>(), null, r.root.right, new RagdollCreator.CreateJointParams.Limits(-30f, 30f, 30f, 85f), o.joints));
			RagdollCreator.CreateJointParams.Limits limits = new RagdollCreator.CreateJointParams.Limits(-35f * o.jointRange, 120f * o.jointRange, 85f * o.jointRange, 45f * o.jointRange);
			RagdollCreator.CreateJointParams.Limits limits2 = new RagdollCreator.CreateJointParams.Limits(0f, 140f * o.jointRange, 10f * o.jointRange, 45f * o.jointRange);
			RagdollCreator.CreateJointParams.Limits limits3 = new RagdollCreator.CreateJointParams.Limits(-50f * o.jointRange, 50f * o.jointRange, 50f * o.jointRange, 25f * o.jointRange);
			BipedRagdollCreator.CreateLimbJoints(transform, r.leftUpperArm, r.leftLowerArm, r.leftHand, r.root, -r.root.right, o.joints, limits, limits2, limits3);
			BipedRagdollCreator.CreateLimbJoints(transform, r.rightUpperArm, r.rightLowerArm, r.rightHand, r.root, r.root.right, o.joints, limits, limits2, limits3);
			RagdollCreator.CreateJointParams.Limits limits4 = new RagdollCreator.CreateJointParams.Limits(-120f * o.jointRange, 35f * o.jointRange, 85f * o.jointRange, 45f * o.jointRange);
			RagdollCreator.CreateJointParams.Limits limits5 = new RagdollCreator.CreateJointParams.Limits(0f, 140f * o.jointRange, 10f * o.jointRange, 45f * o.jointRange);
			RagdollCreator.CreateJointParams.Limits limits6 = new RagdollCreator.CreateJointParams.Limits(-50f * o.jointRange, 50f * o.jointRange, 50f * o.jointRange, 25f * o.jointRange);
			BipedRagdollCreator.CreateLimbJoints(r.hips, r.leftUpperLeg, r.leftLowerLeg, r.leftFoot, r.root, -r.root.up, o.joints, limits4, limits5, limits6);
			BipedRagdollCreator.CreateLimbJoints(r.hips, r.rightUpperLeg, r.rightLowerLeg, r.rightFoot, r.root, -r.root.up, o.joints, limits4, limits5, limits6);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0001A2BC File Offset: 0x000184BC
		private static void CreateLimbJoints(Transform connectedBone, Transform bone1, Transform bone2, Transform bone3, Transform root, Vector3 defaultWorldDirection, RagdollCreator.JointType jointType, RagdollCreator.CreateJointParams.Limits limits1, RagdollCreator.CreateJointParams.Limits limits2, RagdollCreator.CreateJointParams.Limits limits3)
		{
			Quaternion localRotation = bone1.localRotation;
			bone1.rotation = Quaternion.FromToRotation(bone1.rotation * (bone2.position - bone1.position), defaultWorldDirection) * bone1.rotation;
			Vector3 normalized = (bone2.position - bone1.position).normalized;
			Vector3 normalized2 = (bone3.position - bone2.position).normalized;
			Vector3 worldSwingAxis = -Vector3.Cross(normalized, normalized2);
			float num = Vector3.Angle(normalized, normalized2);
			bool flag = Mathf.Abs(Vector3.Dot(normalized, root.up)) > 0.5f;
			float num2 = flag ? 100f : 1f;
			if (num < 0.01f * num2)
			{
				if (flag)
				{
					worldSwingAxis = ((Vector3.Dot(normalized, root.up) > 0f) ? root.right : (-root.right));
				}
				else
				{
					worldSwingAxis = ((Vector3.Dot(normalized, root.right) > 0f) ? root.up : (-root.up));
				}
			}
			RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(bone1.GetComponent<Rigidbody>(), connectedBone.GetComponent<Rigidbody>(), bone2, worldSwingAxis, limits1, jointType));
			RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(bone2.GetComponent<Rigidbody>(), bone1.GetComponent<Rigidbody>(), bone3, worldSwingAxis, new RagdollCreator.CreateJointParams.Limits(limits2.minSwing - num, limits2.maxSwing - num, limits2.swing2, limits2.twist), jointType));
			if (bone3.GetComponent<Rigidbody>() != null)
			{
				RagdollCreator.CreateJoint(new RagdollCreator.CreateJointParams(bone3.GetComponent<Rigidbody>(), bone2.GetComponent<Rigidbody>(), null, worldSwingAxis, limits3, jointType));
			}
			bone1.localRotation = localRotation;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0001A474 File Offset: 0x00018674
		public static void ClearBipedRagdoll(BipedRagdollReferences r)
		{
			Transform[] ragdollTransforms = r.GetRagdollTransforms();
			for (int i = 0; i < ragdollTransforms.Length; i++)
			{
				RagdollCreator.ClearTransform(ragdollTransforms[i]);
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0001A4A0 File Offset: 0x000186A0
		public static bool IsClear(BipedRagdollReferences r)
		{
			Transform[] ragdollTransforms = r.GetRagdollTransforms();
			for (int i = 0; i < ragdollTransforms.Length; i++)
			{
				if (ragdollTransforms[i].GetComponent<Rigidbody>() != null)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0001A4D6 File Offset: 0x000186D6
		private static Vector3 GetUpperArmToHeadCentroid(BipedRagdollReferences r)
		{
			return Vector3.Lerp(BipedRagdollCreator.GetUpperArmCentroid(r), r.head.position, 0.5f);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0001A4F3 File Offset: 0x000186F3
		private static Vector3 GetUpperArmCentroid(BipedRagdollReferences r)
		{
			return Vector3.Lerp(r.leftUpperArm.position, r.rightUpperArm.position, 0.5f);
		}

		// Token: 0x040003BC RID: 956
		public bool canBuild;

		// Token: 0x040003BD RID: 957
		public BipedRagdollReferences references;

		// Token: 0x040003BE RID: 958
		public BipedRagdollCreator.Options options = BipedRagdollCreator.Options.Default;

		// Token: 0x02000086 RID: 134
		[Serializable]
		public struct Options
		{
			// Token: 0x1700007B RID: 123
			// (get) Token: 0x06000445 RID: 1093 RVA: 0x0001A528 File Offset: 0x00018728
			public static BipedRagdollCreator.Options Default
			{
				get
				{
					return new BipedRagdollCreator.Options
					{
						weight = 75f,
						colliderLengthOverlap = 0.1f,
						jointRange = 1f,
						chest = true,
						headCollider = RagdollCreator.ColliderType.Capsule,
						armColliders = RagdollCreator.ColliderType.Capsule,
						hands = true,
						handColliders = RagdollCreator.ColliderType.Capsule,
						legColliders = RagdollCreator.ColliderType.Capsule,
						feet = true,
						fixFootColliderRotation = true
					};
				}
			}

			// Token: 0x040003BF RID: 959
			public float weight;

			// Token: 0x040003C0 RID: 960
			[Header("Optional Bones")]
			public bool spine;

			// Token: 0x040003C1 RID: 961
			public bool chest;

			// Token: 0x040003C2 RID: 962
			public bool hands;

			// Token: 0x040003C3 RID: 963
			public bool feet;

			// Token: 0x040003C4 RID: 964
			[Header("Joints")]
			public RagdollCreator.JointType joints;

			// Token: 0x040003C5 RID: 965
			public float jointRange;

			// Token: 0x040003C6 RID: 966
			[Header("Colliders")]
			public float colliderLengthOverlap;

			// Token: 0x040003C7 RID: 967
			public RagdollCreator.ColliderType torsoColliders;

			// Token: 0x040003C8 RID: 968
			public RagdollCreator.ColliderType headCollider;

			// Token: 0x040003C9 RID: 969
			public RagdollCreator.ColliderType armColliders;

			// Token: 0x040003CA RID: 970
			public RagdollCreator.ColliderType handColliders;

			// Token: 0x040003CB RID: 971
			public RagdollCreator.ColliderType legColliders;

			// Token: 0x040003CC RID: 972
			public RagdollCreator.ColliderType footColliders;

			// Token: 0x040003CD RID: 973
			public bool fixFootColliderRotation;
		}
	}
}
