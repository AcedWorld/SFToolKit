using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000080 RID: 128
	public static class PuppetMasterTools
	{
		// Token: 0x0600041E RID: 1054 RVA: 0x000184F8 File Offset: 0x000166F8
		public static void PositionRagdoll(PuppetMaster puppetMaster)
		{
			Rigidbody[] componentsInChildren = puppetMaster.transform.GetComponentsInChildren<Rigidbody>();
			if (componentsInChildren.Length == 0)
			{
				return;
			}
			foreach (Muscle muscle in puppetMaster.muscles)
			{
				if (muscle.joint == null || muscle.target == null)
				{
					return;
				}
			}
			Vector3[] array = new Vector3[componentsInChildren.Length];
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				if (componentsInChildren[j].transform.childCount == 1)
				{
					array[j] = componentsInChildren[j].transform.InverseTransformDirection(componentsInChildren[j].transform.GetChild(0).position - componentsInChildren[j].transform.position);
				}
			}
			foreach (Rigidbody rigidbody in componentsInChildren)
			{
				foreach (Muscle muscle2 in puppetMaster.muscles)
				{
					if (muscle2.joint.GetComponent<Rigidbody>() == rigidbody)
					{
						rigidbody.transform.position = muscle2.target.position;
					}
				}
			}
			for (int l = 0; l < componentsInChildren.Length; l++)
			{
				if (componentsInChildren[l].transform.childCount == 1)
				{
					Vector3 position = componentsInChildren[l].transform.GetChild(0).position;
					componentsInChildren[l].transform.rotation = Quaternion.FromToRotation(componentsInChildren[l].transform.rotation * array[l], position - componentsInChildren[l].transform.position) * componentsInChildren[l].transform.rotation;
					componentsInChildren[l].transform.GetChild(0).position = position;
				}
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x000186CC File Offset: 0x000168CC
		public static void RealignRagdoll(PuppetMaster puppetMaster)
		{
			foreach (Muscle muscle in puppetMaster.muscles)
			{
				if (muscle.joint == null || muscle.joint.transform == null || muscle.target == null)
				{
					Debug.LogWarning("Muscles incomplete, can not realign ragdoll.");
					return;
				}
			}
			foreach (Muscle muscle2 in puppetMaster.muscles)
			{
				if (muscle2.target != null)
				{
					Transform[] array = new Transform[muscle2.joint.transform.childCount];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = muscle2.joint.transform.GetChild(j);
					}
					Transform[] array2 = array;
					for (int k = 0; k < array2.Length; k++)
					{
						array2[k].parent = null;
					}
					BoxCollider component = muscle2.joint.GetComponent<BoxCollider>();
					Vector3 vector = Vector3.zero;
					Vector3 vector2 = Vector3.zero;
					if (component != null)
					{
						vector = component.transform.TransformVector(component.size);
						vector2 = component.transform.TransformVector(component.center);
					}
					CapsuleCollider component2 = muscle2.joint.GetComponent<CapsuleCollider>();
					Vector3 vector3 = Vector3.zero;
					Vector3 direction = Vector3.zero;
					if (component2 != null)
					{
						vector3 = component2.transform.TransformVector(component2.center);
						direction = component2.transform.TransformVector(PuppetMasterTools.DirectionIntToVector3(component2.direction));
					}
					SphereCollider component3 = muscle2.joint.GetComponent<SphereCollider>();
					Vector3 vector4 = Vector3.zero;
					if (component3 != null)
					{
						vector4 = component3.transform.TransformVector(component3.center);
					}
					Vector3 vector5 = muscle2.joint.transform.TransformVector(muscle2.joint.axis);
					Vector3 vector6 = muscle2.joint.transform.TransformVector(muscle2.joint.secondaryAxis);
					muscle2.joint.transform.rotation = muscle2.target.rotation;
					if (component != null)
					{
						component.size = component.transform.InverseTransformVector(vector);
						component.center = component.transform.InverseTransformVector(vector2);
					}
					if (component2 != null)
					{
						component2.center = component2.transform.InverseTransformVector(vector3);
						Vector3 dir = component2.transform.InverseTransformDirection(direction);
						component2.direction = PuppetMasterTools.DirectionVector3ToInt(dir);
					}
					if (component3 != null)
					{
						component3.center = component3.transform.InverseTransformVector(vector4);
					}
					muscle2.joint.axis = muscle2.joint.transform.InverseTransformVector(vector5);
					muscle2.joint.secondaryAxis = muscle2.joint.transform.InverseTransformVector(vector6);
					array2 = array;
					for (int k = 0; k < array2.Length; k++)
					{
						array2[k].parent = muscle2.joint.transform;
					}
				}
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00004A42 File Offset: 0x00002C42
		private static Vector3 DirectionIntToVector3(int dir)
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

		// Token: 0x06000421 RID: 1057 RVA: 0x000189E0 File Offset: 0x00016BE0
		private static int DirectionVector3ToInt(Vector3 dir)
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
	}
}
