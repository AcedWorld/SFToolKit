using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200005C RID: 92
	public static class PhysXTools
	{
		// Token: 0x06000292 RID: 658 RVA: 0x0000E97D File Offset: 0x0000CB7D
		public static void Predict(Rigidbody r, int steps, out Vector3 position, out Quaternion rotation)
		{
			PhysXTools.Predict(r, steps, out position, out rotation, Physics.gravity, r.drag, r.angularDrag);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000E99C File Offset: 0x0000CB9C
		public static void Predict(Rigidbody r, int steps, out Vector3 position, out Quaternion rotation, Vector3 gravity, float drag, float angularDrag)
		{
			position = r.position;
			rotation = r.rotation;
			Vector3 velocity = r.velocity;
			Vector3 angularVelocity = r.angularVelocity;
			for (int i = 0; i < steps; i++)
			{
				PhysXTools.Predict(ref position, ref rotation, ref velocity, ref angularVelocity, gravity, drag, angularDrag);
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000E9EC File Offset: 0x0000CBEC
		public static void Predict(ref Vector3 position, ref Quaternion rotation, ref Vector3 velocity, ref Vector3 angularVelocity, Vector3 gravity, float drag, float angularDrag)
		{
			velocity += gravity * Time.fixedDeltaTime;
			velocity -= velocity * drag * Time.fixedDeltaTime;
			angularVelocity -= angularVelocity * angularDrag * Time.fixedDeltaTime;
			Vector3 b = velocity * Time.fixedDeltaTime;
			Vector3 euler = angularVelocity * Time.fixedDeltaTime * 57.29578f;
			position += b;
			rotation *= Quaternion.Euler(euler);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000EABC File Offset: 0x0000CCBC
		public static Vector3 GetCenterOfMass(PuppetMaster puppet)
		{
			Vector3 a = Vector3.zero;
			float num = 0f;
			for (int i = 0; i < puppet.muscles.Length; i++)
			{
				if (puppet.muscles[i].joint.gameObject.activeInHierarchy)
				{
					a += puppet.muscles[i].rigidbody.worldCenterOfMass * puppet.muscles[i].rigidbody.mass;
					num += puppet.muscles[i].rigidbody.mass;
				}
			}
			return a / num;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000EB50 File Offset: 0x0000CD50
		public static Vector3 GetCenterOfMass(Rigidbody[] rigidbodies)
		{
			Vector3 a = Vector3.zero;
			float num = 0f;
			for (int i = 0; i < rigidbodies.Length; i++)
			{
				if (rigidbodies[i].gameObject.activeInHierarchy)
				{
					a += rigidbodies[i].worldCenterOfMass * rigidbodies[i].mass;
					num += rigidbodies[i].mass;
				}
			}
			return a / num;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
		public static Vector3 GetCenterOfMassVelocity(Rigidbody[] rigidbodies)
		{
			Vector3 a = Vector3.zero;
			float num = 0f;
			for (int i = 0; i < rigidbodies.Length; i++)
			{
				if (rigidbodies[i].gameObject.activeInHierarchy)
				{
					a += rigidbodies[i].velocity * rigidbodies[i].mass;
					num += rigidbodies[i].mass;
				}
			}
			return a / num;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000EC18 File Offset: 0x0000CE18
		public static void DivByInertia(ref Vector3 v, Quaternion rotation, Vector3 inertiaTensor)
		{
			v = rotation * PhysXTools.Div(Quaternion.Inverse(rotation) * v, inertiaTensor);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000EC3D File Offset: 0x0000CE3D
		public static void ScaleByInertia(ref Vector3 v, Quaternion rotation, Vector3 inertiaTensor)
		{
			v = rotation * Vector3.Scale(Quaternion.Inverse(rotation) * v, inertiaTensor);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000EC64 File Offset: 0x0000CE64
		public static Vector3 GetAngularVelocity(Quaternion lastRotation, Quaternion rotation, float deltaTime)
		{
			Quaternion quaternion = rotation * Quaternion.Inverse(lastRotation);
			float num = 0f;
			Vector3 vector = Vector3.zero;
			quaternion.ToAngleAxis(out num, out vector);
			if (float.IsNaN(vector.x))
			{
				return Vector3.zero;
			}
			if (float.IsInfinity(vector.x))
			{
				return Vector3.zero;
			}
			num *= 0.017453292f;
			num /= deltaTime;
			num = QuaTools.ToBiPolar(num);
			vector *= num;
			return vector;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000ECD8 File Offset: 0x0000CED8
		public static Vector3 GetFromToAcceleration(Vector3 fromV, Vector3 toV)
		{
			Quaternion quaternion = Quaternion.FromToRotation(fromV, toV);
			float d = 0f;
			Vector3 zero = Vector3.zero;
			quaternion.ToAngleAxis(out d, out zero);
			return d * zero * 0.017453292f / Time.fixedDeltaTime;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000ED20 File Offset: 0x0000CF20
		public static Vector3 GetAngularAcceleration(Quaternion fromR, Quaternion toR)
		{
			Vector3 a = Vector3.Cross(fromR * Vector3.forward, toR * Vector3.forward);
			Vector3 b = Vector3.Cross(fromR * Vector3.up, toR * Vector3.up);
			float d = Quaternion.Angle(fromR, toR);
			return Vector3.Normalize(a + b) * d * 0.017453292f / Time.fixedDeltaTime;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000ED94 File Offset: 0x0000CF94
		public static void AddFromToTorque(Rigidbody r, Quaternion toR, ForceMode forceMode)
		{
			Vector3 vector = PhysXTools.GetAngularAcceleration(r.rotation, toR);
			vector -= r.angularVelocity;
			switch (forceMode)
			{
			case ForceMode.Force:
			{
				Vector3 torque = vector / Time.fixedDeltaTime;
				PhysXTools.ScaleByInertia(ref torque, r.rotation, r.inertiaTensor);
				r.AddTorque(torque, forceMode);
				return;
			}
			case ForceMode.Impulse:
			{
				Vector3 torque2 = vector;
				PhysXTools.ScaleByInertia(ref torque2, r.rotation, r.inertiaTensor);
				r.AddTorque(torque2, forceMode);
				return;
			}
			case ForceMode.VelocityChange:
				r.AddTorque(vector, forceMode);
				break;
			case (ForceMode)3:
			case (ForceMode)4:
				break;
			case ForceMode.Acceleration:
				r.AddTorque(vector / Time.fixedDeltaTime, forceMode);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000EE3C File Offset: 0x0000D03C
		public static void AddFromToTorque(Rigidbody r, Vector3 fromV, Vector3 toV, ForceMode forceMode)
		{
			Vector3 vector = PhysXTools.GetFromToAcceleration(fromV, toV);
			vector -= r.angularVelocity;
			switch (forceMode)
			{
			case ForceMode.Force:
			{
				Vector3 torque = vector / Time.fixedDeltaTime;
				PhysXTools.ScaleByInertia(ref torque, r.rotation, r.inertiaTensor);
				r.AddTorque(torque, forceMode);
				return;
			}
			case ForceMode.Impulse:
			{
				Vector3 torque2 = vector;
				PhysXTools.ScaleByInertia(ref torque2, r.rotation, r.inertiaTensor);
				r.AddTorque(torque2, forceMode);
				return;
			}
			case ForceMode.VelocityChange:
				r.AddTorque(vector, forceMode);
				break;
			case (ForceMode)3:
			case (ForceMode)4:
				break;
			case ForceMode.Acceleration:
				r.AddTorque(vector / Time.fixedDeltaTime, forceMode);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
		public static void AddFromToForce(Rigidbody r, Vector3 fromV, Vector3 toV, ForceMode forceMode)
		{
			Vector3 vector = PhysXTools.GetLinearAcceleration(fromV, toV);
			vector -= r.velocity;
			switch (forceMode)
			{
			case ForceMode.Force:
			{
				Vector3 vector2 = vector / Time.fixedDeltaTime;
				vector2 *= r.mass;
				r.AddForce(vector2, forceMode);
				return;
			}
			case ForceMode.Impulse:
			{
				Vector3 vector3 = vector;
				vector3 *= r.mass;
				r.AddForce(vector3, forceMode);
				return;
			}
			case ForceMode.VelocityChange:
				r.AddForce(vector, forceMode);
				break;
			case (ForceMode)3:
			case (ForceMode)4:
				break;
			case ForceMode.Acceleration:
				r.AddForce(vector / Time.fixedDeltaTime, forceMode);
				return;
			default:
				return;
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000EF76 File Offset: 0x0000D176
		public static Vector3 GetLinearAcceleration(Vector3 fromPoint, Vector3 toPoint)
		{
			return (toPoint - fromPoint) / Time.fixedDeltaTime;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000EF8C File Offset: 0x0000D18C
		public static Quaternion ToJointSpace(ConfigurableJoint joint)
		{
			Vector3 vector = Vector3.Cross(joint.axis, joint.secondaryAxis);
			Vector3 upwards = Vector3.Cross(vector, joint.axis);
			return Quaternion.LookRotation(vector, upwards);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		public static Vector3 CalculateInertiaTensorCuboid(Vector3 size, float mass)
		{
			float num = size.x * size.x;
			float num2 = size.y * size.y;
			float num3 = size.z * size.z;
			float num4 = 0.083333336f * mass;
			return new Vector3(num4 * (num2 + num3), num4 * (num + num3), num4 * (num + num2));
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000866A File Offset: 0x0000686A
		public static Vector3 Div(Vector3 v, Vector3 v2)
		{
			return new Vector3(v.x / v2.x, v.y / v2.y, v.z / v2.z);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000F014 File Offset: 0x0000D214
		public static bool RayCapsuleIntersectUnscaled(Vector3 origin, Vector3 direction, CapsuleCollider capsule)
		{
			return PhysXTools.RayCapsuleIntersect(origin, direction, capsule.transform.position, capsule.transform.rotation, capsule.center, capsule.radius, capsule.height, capsule.direction, 1f);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000F05C File Offset: 0x0000D25C
		public static bool RayCapsuleIntersect(Vector3 origin, Vector3 direction, CapsuleCollider capsule, float uniformScale)
		{
			return PhysXTools.RayCapsuleIntersect(origin, direction, capsule.transform.position, capsule.transform.rotation, capsule.center, capsule.radius, capsule.height, capsule.direction, uniformScale);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000F0A0 File Offset: 0x0000D2A0
		public static bool RayCapsuleIntersect(Vector3 origin, Vector3 direction, Vector3 capsuleTransformPos, Quaternion capsuleTransformRot, Vector3 capsuleCenter, float capsuleRadius, float capsuleHeight, int capsuleDir, float scale)
		{
			float num = Mathf.Max(capsuleRadius, capsuleHeight);
			float num2 = capsuleRadius * scale;
			float num3 = num * scale;
			Vector3 vector = (capsuleDir == 0) ? Vector3.right : ((capsuleDir == 1) ? Vector3.up : Vector3.forward);
			vector = capsuleTransformRot * vector;
			float d = num3 * 0.5f - num2;
			Vector3 b = vector * d;
			Vector3 a = capsuleTransformPos + capsuleTransformRot * capsuleCenter * scale;
			Vector3 c = a - b;
			Vector3 c2 = a + b;
			return PhysXTools.RayCapsuleIntersect(origin, direction, c, c2, num2);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000F128 File Offset: 0x0000D328
		public static bool RayCapsuleIntersect(Vector3 rayOrigin, Vector3 rayDir, Vector3 c1, Vector3 c2, float cRadius)
		{
			Vector3 vector = c2 - c1;
			Vector3 vector2 = rayOrigin - c1;
			float num = Vector3.Dot(vector, vector);
			float num2 = Vector3.Dot(vector, rayDir);
			float num3 = Vector3.Dot(vector, vector2);
			float num4 = Vector3.Dot(rayDir, vector2);
			float num5 = Vector3.Dot(vector2, vector2);
			float num6 = num - num2 * num2;
			float num7 = num * num4 - num3 * num2;
			float num8 = num * num5 - num3 * num3 - cRadius * cRadius * num;
			float num9 = num7 * num7 - num6 * num8;
			if ((double)num9 >= 0.0)
			{
				float num10 = (-num7 - Mathf.Sqrt(num9)) / num6;
				float num11 = num3 + num10 * num2;
				if (num11 > 0f && num11 < num)
				{
					return num10 > 0f;
				}
				Vector3 vector3 = (num11 <= 0f) ? vector2 : (rayOrigin - c2);
				num7 = Vector3.Dot(rayDir, vector3);
				num8 = Vector3.Dot(vector3, vector3) - cRadius * cRadius;
				num9 = num7 * num7 - num8;
				if (num9 > 0f)
				{
					return -num7 - Mathf.Sqrt(num9) > 0f;
				}
			}
			return false;
		}
	}
}
