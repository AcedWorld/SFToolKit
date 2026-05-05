using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000089 RID: 137
	public static class JointConverter
	{
		// Token: 0x0600044F RID: 1103 RVA: 0x0001AD24 File Offset: 0x00018F24
		public static void ToConfigurable(GameObject root)
		{
			int num = 0;
			CharacterJoint[] componentsInChildren = root.GetComponentsInChildren<CharacterJoint>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				JointConverter.CharacterToConfigurable(componentsInChildren[i]);
				num++;
			}
			HingeJoint[] componentsInChildren2 = root.GetComponentsInChildren<HingeJoint>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				JointConverter.HingeToConfigurable(componentsInChildren2[j]);
				num++;
			}
			FixedJoint[] componentsInChildren3 = root.GetComponentsInChildren<FixedJoint>();
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				JointConverter.FixedToConfigurable(componentsInChildren3[k]);
				num++;
			}
			SpringJoint[] componentsInChildren4 = root.GetComponentsInChildren<SpringJoint>();
			for (int l = 0; l < componentsInChildren4.Length; l++)
			{
				JointConverter.SpringToConfigurable(componentsInChildren4[l]);
				num++;
			}
			if (num > 0)
			{
				Debug.Log(num.ToString() + " joints were successfully converted to ConfigurableJoints.");
				return;
			}
			Debug.Log("No joints found in the children of " + root.name + " to convert to ConfigurableJoints.");
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0001AE04 File Offset: 0x00019004
		public static void HingeToConfigurable(HingeJoint src)
		{
			ConfigurableJoint configurableJoint = src.gameObject.AddComponent<ConfigurableJoint>();
			JointConverter.ConvertJoint(ref configurableJoint, src);
			configurableJoint.secondaryAxis = Vector3.zero;
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularXMotion = (src.useLimits ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Free);
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			configurableJoint.highAngularXLimit = JointConverter.ConvertToHighSoftJointLimit(src.limits, src.spring, src.useSpring);
			configurableJoint.angularXLimitSpring = JointConverter.ConvertToSoftJointLimitSpring(src.limits, src.spring, src.useSpring);
			configurableJoint.lowAngularXLimit = JointConverter.ConvertToLowSoftJointLimit(src.limits, src.spring, src.useSpring);
			if (src.useMotor)
			{
				Debug.LogWarning("Can not convert HingeJoint Motor to ConfigurableJoint.");
			}
			Object.DestroyImmediate(src);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001AED4 File Offset: 0x000190D4
		public static void FixedToConfigurable(FixedJoint src)
		{
			ConfigurableJoint configurableJoint = src.gameObject.AddComponent<ConfigurableJoint>();
			JointConverter.ConvertJoint(ref configurableJoint, src);
			configurableJoint.secondaryAxis = Vector3.zero;
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			Object.DestroyImmediate(src);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0001AF30 File Offset: 0x00019130
		public static void SpringToConfigurable(SpringJoint src)
		{
			ConfigurableJoint configurableJoint = src.gameObject.AddComponent<ConfigurableJoint>();
			JointConverter.ConvertJoint(ref configurableJoint, src);
			configurableJoint.xMotion = ConfigurableJointMotion.Limited;
			configurableJoint.yMotion = ConfigurableJointMotion.Limited;
			configurableJoint.zMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
			SoftJointLimit linearLimit = new SoftJointLimit
			{
				bounciness = 0f,
				limit = src.maxDistance
			};
			configurableJoint.linearLimit = linearLimit;
			SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
			{
				damper = src.damper,
				spring = src.spring
			};
			configurableJoint.linearLimitSpring = linearLimitSpring;
			Object.DestroyImmediate(src);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0001AFD4 File Offset: 0x000191D4
		public static void CharacterToConfigurable(CharacterJoint src)
		{
			ConfigurableJoint configurableJoint = src.gameObject.AddComponent<ConfigurableJoint>();
			JointConverter.ConvertJoint(ref configurableJoint, src);
			configurableJoint.secondaryAxis = src.swingAxis;
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
			configurableJoint.highAngularXLimit = JointConverter.CopyLimit(src.highTwistLimit);
			configurableJoint.lowAngularXLimit = JointConverter.CopyLimit(src.lowTwistLimit);
			configurableJoint.angularYLimit = JointConverter.CopyLimit(src.swing1Limit);
			configurableJoint.angularZLimit = JointConverter.CopyLimit(src.swing2Limit);
			configurableJoint.angularXLimitSpring = JointConverter.CopyLimitSpring(src.twistLimitSpring);
			configurableJoint.angularYZLimitSpring = JointConverter.CopyLimitSpring(src.swingLimitSpring);
			configurableJoint.enableCollision = src.enableCollision;
			configurableJoint.projectionMode = (src.enableProjection ? JointProjectionMode.PositionAndRotation : JointProjectionMode.None);
			configurableJoint.projectionAngle = src.projectionAngle;
			configurableJoint.projectionDistance = src.projectionDistance;
			Object.DestroyImmediate(src);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0001B0D0 File Offset: 0x000192D0
		private static void ConvertJoint(ref ConfigurableJoint conf, Joint src)
		{
			conf.anchor = src.anchor;
			conf.autoConfigureConnectedAnchor = src.autoConfigureConnectedAnchor;
			conf.axis = src.axis;
			conf.breakForce = src.breakForce;
			conf.breakTorque = src.breakTorque;
			conf.connectedAnchor = src.connectedAnchor;
			conf.connectedBody = src.connectedBody;
			conf.enableCollision = src.enableCollision;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0001B148 File Offset: 0x00019348
		private static SoftJointLimit ConvertToHighSoftJointLimit(JointLimits src, JointSpring spring, bool useSpring)
		{
			return new SoftJointLimit
			{
				limit = -src.max,
				bounciness = src.bounciness
			};
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0001B17C File Offset: 0x0001937C
		private static SoftJointLimit ConvertToLowSoftJointLimit(JointLimits src, JointSpring spring, bool useSpring)
		{
			return new SoftJointLimit
			{
				limit = -src.min,
				bounciness = src.bounciness
			};
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0001B1B0 File Offset: 0x000193B0
		private static SoftJointLimitSpring ConvertToSoftJointLimitSpring(JointLimits src, JointSpring spring, bool useSpring)
		{
			return new SoftJointLimitSpring
			{
				damper = (useSpring ? spring.damper : 0f),
				spring = (useSpring ? spring.spring : 0f)
			};
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0001B1F4 File Offset: 0x000193F4
		private static SoftJointLimit CopyLimit(SoftJointLimit src)
		{
			return new SoftJointLimit
			{
				limit = src.limit,
				bounciness = src.bounciness
			};
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0001B228 File Offset: 0x00019428
		private static SoftJointLimitSpring CopyLimitSpring(SoftJointLimitSpring src)
		{
			return new SoftJointLimitSpring
			{
				damper = src.damper,
				spring = src.spring
			};
		}
	}
}
