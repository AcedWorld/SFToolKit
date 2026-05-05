using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000140 RID: 320
	public static class VRIKCalibrator
	{
		// Token: 0x06000A02 RID: 2562 RVA: 0x0003E70D File Offset: 0x0003C90D
		public static void RecalibrateScale(VRIK ik, VRIKCalibrator.CalibrationData data, VRIKCalibrator.Settings settings)
		{
			VRIKCalibrator.RecalibrateScale(ik, data, settings.scaleMlp);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0003E71C File Offset: 0x0003C91C
		public static void RecalibrateScale(VRIK ik, VRIKCalibrator.CalibrationData data, float scaleMlp)
		{
			VRIKCalibrator.CalibrateScale(ik, scaleMlp);
			data.scale = ik.references.root.localScale.y;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0003E740 File Offset: 0x0003C940
		private static void CalibrateScale(VRIK ik, VRIKCalibrator.Settings settings)
		{
			VRIKCalibrator.CalibrateScale(ik, settings.scaleMlp);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0003E750 File Offset: 0x0003C950
		private static void CalibrateScale(VRIK ik, float scaleMlp = 1f)
		{
			float num = (ik.solver.spine.headTarget.position.y - ik.references.root.position.y) / (ik.references.head.position.y - ik.references.root.position.y);
			ik.references.root.localScale *= num * scaleMlp;
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0003E7D8 File Offset: 0x0003C9D8
		public static VRIKCalibrator.CalibrationData Calibrate(VRIK ik, VRIKCalibrator.Settings settings, Transform headTracker, Transform bodyTracker = null, Transform leftHandTracker = null, Transform rightHandTracker = null, Transform leftFootTracker = null, Transform rightFootTracker = null)
		{
			if (!ik.solver.initiated)
			{
				Debug.LogError("Can not calibrate before VRIK has initiated.");
				return null;
			}
			if (headTracker == null)
			{
				Debug.LogError("Can not calibrate VRIK without the head tracker.");
				return null;
			}
			VRIKCalibrator.CalibrationData calibrationData = new VRIKCalibrator.CalibrationData();
			ik.solver.FixTransforms();
			Vector3 vector = headTracker.position + headTracker.rotation * Quaternion.LookRotation(settings.headTrackerForward, settings.headTrackerUp) * settings.headOffset;
			ik.references.root.position = new Vector3(vector.x, ik.references.root.position.y, vector.z);
			Vector3 forward = headTracker.rotation * settings.headTrackerForward;
			forward.y = 0f;
			ik.references.root.rotation = Quaternion.LookRotation(forward);
			Transform transform = (ik.solver.spine.headTarget == null) ? new GameObject("Head Target").transform : ik.solver.spine.headTarget;
			transform.position = vector;
			transform.rotation = ik.references.head.rotation;
			transform.parent = headTracker;
			ik.solver.spine.headTarget = transform;
			float num = (transform.position.y - ik.references.root.position.y) / (ik.references.head.position.y - ik.references.root.position.y);
			ik.references.root.localScale *= num * settings.scaleMlp;
			if (bodyTracker != null)
			{
				Transform transform2 = (ik.solver.spine.pelvisTarget == null) ? new GameObject("Pelvis Target").transform : ik.solver.spine.pelvisTarget;
				transform2.position = ik.references.pelvis.position;
				transform2.rotation = ik.references.pelvis.rotation;
				transform2.parent = bodyTracker;
				ik.solver.spine.pelvisTarget = transform2;
				ik.solver.spine.pelvisPositionWeight = settings.pelvisPositionWeight;
				ik.solver.spine.pelvisRotationWeight = settings.pelvisRotationWeight;
				ik.solver.plantFeet = false;
				ik.solver.spine.maxRootAngle = 180f;
			}
			else if (leftFootTracker != null && rightFootTracker != null)
			{
				ik.solver.spine.maxRootAngle = 0f;
			}
			if (leftHandTracker != null)
			{
				Transform transform3 = (ik.solver.leftArm.target == null) ? new GameObject("Left Hand Target").transform : ik.solver.leftArm.target;
				transform3.position = leftHandTracker.position + leftHandTracker.rotation * Quaternion.LookRotation(settings.handTrackerForward, settings.handTrackerUp) * settings.handOffset;
				Vector3 axis = Vector3.Cross(ik.solver.leftArm.wristToPalmAxis, ik.solver.leftArm.palmToThumbAxis);
				transform3.rotation = QuaTools.MatchRotation(leftHandTracker.rotation * Quaternion.LookRotation(settings.handTrackerForward, settings.handTrackerUp), settings.handTrackerForward, settings.handTrackerUp, ik.solver.leftArm.wristToPalmAxis, axis);
				transform3.parent = leftHandTracker;
				ik.solver.leftArm.target = transform3;
				ik.solver.leftArm.positionWeight = 1f;
				ik.solver.leftArm.rotationWeight = 1f;
			}
			else
			{
				ik.solver.leftArm.positionWeight = 0f;
				ik.solver.leftArm.rotationWeight = 0f;
			}
			if (rightHandTracker != null)
			{
				Transform transform4 = (ik.solver.rightArm.target == null) ? new GameObject("Right Hand Target").transform : ik.solver.rightArm.target;
				transform4.position = rightHandTracker.position + rightHandTracker.rotation * Quaternion.LookRotation(settings.handTrackerForward, settings.handTrackerUp) * settings.handOffset;
				Vector3 axis2 = -Vector3.Cross(ik.solver.rightArm.wristToPalmAxis, ik.solver.rightArm.palmToThumbAxis);
				transform4.rotation = QuaTools.MatchRotation(rightHandTracker.rotation * Quaternion.LookRotation(settings.handTrackerForward, settings.handTrackerUp), settings.handTrackerForward, settings.handTrackerUp, ik.solver.rightArm.wristToPalmAxis, axis2);
				transform4.parent = rightHandTracker;
				ik.solver.rightArm.target = transform4;
				ik.solver.rightArm.positionWeight = 1f;
				ik.solver.rightArm.rotationWeight = 1f;
			}
			else
			{
				ik.solver.rightArm.positionWeight = 0f;
				ik.solver.rightArm.rotationWeight = 0f;
			}
			if (leftFootTracker != null)
			{
				VRIKCalibrator.CalibrateLeg(settings, leftFootTracker, ik.solver.leftLeg, (ik.references.leftToes != null) ? ik.references.leftToes : ik.references.leftFoot, ik.references.root.forward, true);
			}
			if (rightFootTracker != null)
			{
				VRIKCalibrator.CalibrateLeg(settings, rightFootTracker, ik.solver.rightLeg, (ik.references.rightToes != null) ? ik.references.rightToes : ik.references.rightFoot, ik.references.root.forward, false);
			}
			bool flag = bodyTracker != null || (leftFootTracker != null && rightFootTracker != null);
			VRIKRootController vrikrootController = ik.references.root.GetComponent<VRIKRootController>();
			if (flag)
			{
				if (vrikrootController == null)
				{
					vrikrootController = ik.references.root.gameObject.AddComponent<VRIKRootController>();
				}
				vrikrootController.Calibrate();
			}
			else if (vrikrootController != null)
			{
				Object.Destroy(vrikrootController);
			}
			ik.solver.spine.minHeadHeight = 0f;
			ik.solver.locomotion.weight = ((bodyTracker == null && leftFootTracker == null && rightFootTracker == null) ? 1f : 0f);
			calibrationData.scale = ik.references.root.localScale.y;
			calibrationData.head = new VRIKCalibrator.CalibrationData.Target(ik.solver.spine.headTarget);
			calibrationData.pelvis = new VRIKCalibrator.CalibrationData.Target(ik.solver.spine.pelvisTarget);
			calibrationData.leftHand = new VRIKCalibrator.CalibrationData.Target(ik.solver.leftArm.target);
			calibrationData.rightHand = new VRIKCalibrator.CalibrationData.Target(ik.solver.rightArm.target);
			calibrationData.leftFoot = new VRIKCalibrator.CalibrationData.Target(ik.solver.leftLeg.target);
			calibrationData.rightFoot = new VRIKCalibrator.CalibrationData.Target(ik.solver.rightLeg.target);
			calibrationData.leftLegGoal = new VRIKCalibrator.CalibrationData.Target(ik.solver.leftLeg.bendGoal);
			calibrationData.rightLegGoal = new VRIKCalibrator.CalibrationData.Target(ik.solver.rightLeg.bendGoal);
			calibrationData.pelvisTargetRight = ((vrikrootController != null) ? vrikrootController.pelvisTargetRight : Vector3.zero);
			calibrationData.pelvisPositionWeight = ik.solver.spine.pelvisPositionWeight;
			calibrationData.pelvisRotationWeight = ik.solver.spine.pelvisRotationWeight;
			return calibrationData;
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0003F020 File Offset: 0x0003D220
		private static void CalibrateLeg(VRIKCalibrator.Settings settings, Transform tracker, IKSolverVR.Leg leg, Transform lastBone, Vector3 rootForward, bool isLeft)
		{
			string str = isLeft ? "Left" : "Right";
			Transform transform = (leg.target == null) ? new GameObject(str + " Foot Target").transform : leg.target;
			Quaternion rotation = tracker.rotation * Quaternion.LookRotation(settings.footTrackerForward, settings.footTrackerUp);
			Vector3 vector = rotation * Vector3.forward;
			vector.y = 0f;
			rotation = Quaternion.LookRotation(vector);
			float x = isLeft ? settings.footInwardOffset : (-settings.footInwardOffset);
			transform.position = tracker.position + rotation * new Vector3(x, 0f, settings.footForwardOffset);
			transform.position = new Vector3(transform.position.x, lastBone.position.y, transform.position.z);
			transform.rotation = lastBone.rotation;
			Vector3 vector2 = AxisTools.GetAxisVectorToDirection(lastBone, rootForward);
			if (Vector3.Dot(lastBone.rotation * vector2, rootForward) < 0f)
			{
				vector2 = -vector2;
			}
			Vector3 vector3 = Quaternion.Inverse(Quaternion.LookRotation(transform.rotation * vector2)) * vector;
			float num = Mathf.Atan2(vector3.x, vector3.z) * 57.29578f;
			float num2 = isLeft ? settings.footHeadingOffset : (-settings.footHeadingOffset);
			transform.rotation = Quaternion.AngleAxis(num + num2, Vector3.up) * transform.rotation;
			transform.parent = tracker;
			leg.target = transform;
			leg.positionWeight = 1f;
			leg.rotationWeight = 1f;
			Transform transform2 = (leg.bendGoal == null) ? new GameObject(str + " Leg Bend Goal").transform : leg.bendGoal;
			transform2.position = lastBone.position + rotation * Vector3.forward + rotation * Vector3.up;
			transform2.parent = tracker;
			leg.bendGoal = transform2;
			leg.bendGoalWeight = 1f;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0003F254 File Offset: 0x0003D454
		public static void Calibrate(VRIK ik, VRIKCalibrator.CalibrationData data, Transform headTracker, Transform bodyTracker = null, Transform leftHandTracker = null, Transform rightHandTracker = null, Transform leftFootTracker = null, Transform rightFootTracker = null)
		{
			if (!ik.solver.initiated)
			{
				Debug.LogError("Can not calibrate before VRIK has initiated.");
				return;
			}
			if (headTracker == null)
			{
				Debug.LogError("Can not calibrate VRIK without the head tracker.");
				return;
			}
			ik.solver.FixTransforms();
			Transform transform = (ik.solver.spine.headTarget == null) ? new GameObject("Head Target").transform : ik.solver.spine.headTarget;
			transform.parent = headTracker;
			data.head.SetTo(transform);
			ik.solver.spine.headTarget = transform;
			ik.references.root.localScale = data.scale * Vector3.one;
			if (bodyTracker != null && data.pelvis != null)
			{
				Transform transform2 = (ik.solver.spine.pelvisTarget == null) ? new GameObject("Pelvis Target").transform : ik.solver.spine.pelvisTarget;
				transform2.parent = bodyTracker;
				data.pelvis.SetTo(transform2);
				ik.solver.spine.pelvisTarget = transform2;
				ik.solver.spine.pelvisPositionWeight = data.pelvisPositionWeight;
				ik.solver.spine.pelvisRotationWeight = data.pelvisRotationWeight;
				ik.solver.plantFeet = false;
				ik.solver.spine.maxRootAngle = 180f;
			}
			else if (leftFootTracker != null && rightFootTracker != null)
			{
				ik.solver.spine.maxRootAngle = 0f;
			}
			if (leftHandTracker != null)
			{
				Transform transform3 = (ik.solver.leftArm.target == null) ? new GameObject("Left Hand Target").transform : ik.solver.leftArm.target;
				transform3.parent = leftHandTracker;
				data.leftHand.SetTo(transform3);
				ik.solver.leftArm.target = transform3;
				ik.solver.leftArm.positionWeight = 1f;
				ik.solver.leftArm.rotationWeight = 1f;
			}
			else
			{
				ik.solver.leftArm.positionWeight = 0f;
				ik.solver.leftArm.rotationWeight = 0f;
			}
			if (rightHandTracker != null)
			{
				Transform transform4 = (ik.solver.rightArm.target == null) ? new GameObject("Right Hand Target").transform : ik.solver.rightArm.target;
				transform4.parent = rightHandTracker;
				data.rightHand.SetTo(transform4);
				ik.solver.rightArm.target = transform4;
				ik.solver.rightArm.positionWeight = 1f;
				ik.solver.rightArm.rotationWeight = 1f;
			}
			else
			{
				ik.solver.rightArm.positionWeight = 0f;
				ik.solver.rightArm.rotationWeight = 0f;
			}
			if (leftFootTracker != null)
			{
				VRIKCalibrator.CalibrateLeg(data, leftFootTracker, ik.solver.leftLeg, (ik.references.leftToes != null) ? ik.references.leftToes : ik.references.leftFoot, ik.references.root.forward, true);
			}
			if (rightFootTracker != null)
			{
				VRIKCalibrator.CalibrateLeg(data, rightFootTracker, ik.solver.rightLeg, (ik.references.rightToes != null) ? ik.references.rightToes : ik.references.rightFoot, ik.references.root.forward, false);
			}
			bool flag = bodyTracker != null || (leftFootTracker != null && rightFootTracker != null);
			VRIKRootController vrikrootController = ik.references.root.GetComponent<VRIKRootController>();
			if (flag)
			{
				if (vrikrootController == null)
				{
					vrikrootController = ik.references.root.gameObject.AddComponent<VRIKRootController>();
				}
				vrikrootController.Calibrate(data);
			}
			else if (vrikrootController != null)
			{
				Object.Destroy(vrikrootController);
			}
			ik.solver.spine.minHeadHeight = 0f;
			ik.solver.locomotion.weight = ((bodyTracker == null && leftFootTracker == null && rightFootTracker == null) ? 1f : 0f);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0003F6F8 File Offset: 0x0003D8F8
		private static void CalibrateLeg(VRIKCalibrator.CalibrationData data, Transform tracker, IKSolverVR.Leg leg, Transform lastBone, Vector3 rootForward, bool isLeft)
		{
			if (isLeft && data.leftFoot == null)
			{
				return;
			}
			if (!isLeft && data.rightFoot == null)
			{
				return;
			}
			string str = isLeft ? "Left" : "Right";
			Transform transform = (leg.target == null) ? new GameObject(str + " Foot Target").transform : leg.target;
			transform.parent = tracker;
			if (isLeft)
			{
				data.leftFoot.SetTo(transform);
			}
			else
			{
				data.rightFoot.SetTo(transform);
			}
			leg.target = transform;
			leg.positionWeight = 1f;
			leg.rotationWeight = 1f;
			Transform transform2 = (leg.bendGoal == null) ? new GameObject(str + " Leg Bend Goal").transform : leg.bendGoal;
			transform2.parent = tracker;
			if (isLeft)
			{
				data.leftLegGoal.SetTo(transform2);
			}
			else
			{
				data.rightLegGoal.SetTo(transform2);
			}
			leg.bendGoal = transform2;
			leg.bendGoalWeight = 1f;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0003F804 File Offset: 0x0003DA04
		public static VRIKCalibrator.CalibrationData Calibrate(VRIK ik, Transform centerEyeAnchor, Transform leftHandAnchor, Transform rightHandAnchor, Vector3 centerEyePositionOffset, Vector3 centerEyeRotationOffset, Vector3 handPositionOffset, Vector3 handRotationOffset, float scaleMlp = 1f)
		{
			VRIKCalibrator.CalibrateHead(ik, centerEyeAnchor, centerEyePositionOffset, centerEyeRotationOffset);
			VRIKCalibrator.CalibrateHands(ik, leftHandAnchor, rightHandAnchor, handPositionOffset, handRotationOffset);
			VRIKCalibrator.CalibrateScale(ik, scaleMlp);
			return new VRIKCalibrator.CalibrationData
			{
				scale = ik.references.root.localScale.y,
				head = new VRIKCalibrator.CalibrationData.Target(ik.solver.spine.headTarget),
				leftHand = new VRIKCalibrator.CalibrationData.Target(ik.solver.leftArm.target),
				rightHand = new VRIKCalibrator.CalibrationData.Target(ik.solver.rightArm.target)
			};
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0003F8A4 File Offset: 0x0003DAA4
		public static void CalibrateHead(VRIK ik, Transform centerEyeAnchor, Vector3 anchorPositionOffset, Vector3 anchorRotationOffset)
		{
			if (ik.solver.spine.headTarget == null)
			{
				ik.solver.spine.headTarget = new GameObject("Head IK Target").transform;
			}
			Vector3 forward = Quaternion.Inverse(ik.references.head.rotation) * ik.references.root.forward;
			Vector3 upwards = Quaternion.Inverse(ik.references.head.rotation) * ik.references.root.up;
			Quaternion rhs = Quaternion.LookRotation(forward, upwards);
			Vector3 b = ik.references.head.position + ik.references.head.rotation * rhs * anchorPositionOffset;
			Quaternion quaternion = Quaternion.Inverse(ik.references.head.rotation * rhs * Quaternion.Euler(anchorRotationOffset));
			ik.solver.spine.headTarget.parent = centerEyeAnchor;
			ik.solver.spine.headTarget.localPosition = quaternion * (ik.references.head.position - b);
			ik.solver.spine.headTarget.localRotation = quaternion * ik.references.head.rotation;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0003FA10 File Offset: 0x0003DC10
		public static void CalibrateBody(VRIK ik, Transform pelvisTracker, Vector3 trackerPositionOffset, Vector3 trackerRotationOffset)
		{
			if (ik.solver.spine.pelvisTarget == null)
			{
				ik.solver.spine.pelvisTarget = new GameObject("Pelvis IK Target").transform;
			}
			ik.solver.spine.pelvisTarget.position = ik.references.pelvis.position + ik.references.root.rotation * trackerPositionOffset;
			ik.solver.spine.pelvisTarget.rotation = ik.references.root.rotation * Quaternion.Euler(trackerRotationOffset);
			ik.solver.spine.pelvisTarget.parent = pelvisTracker;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0003FADC File Offset: 0x0003DCDC
		public static void CalibrateHands(VRIK ik, Transform leftHandAnchor, Transform rightHandAnchor, Vector3 anchorPositionOffset, Vector3 anchorRotationOffset)
		{
			if (ik.solver.leftArm.target == null)
			{
				ik.solver.leftArm.target = new GameObject("Left Hand IK Target").transform;
			}
			if (ik.solver.rightArm.target == null)
			{
				ik.solver.rightArm.target = new GameObject("Right Hand IK Target").transform;
			}
			VRIKCalibrator.CalibrateHand(ik, leftHandAnchor, anchorPositionOffset, anchorRotationOffset, true);
			VRIKCalibrator.CalibrateHand(ik, rightHandAnchor, anchorPositionOffset, anchorRotationOffset, false);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0003FB70 File Offset: 0x0003DD70
		private static void CalibrateHand(VRIK ik, Transform anchor, Vector3 positionOffset, Vector3 rotationOffset, bool isLeft)
		{
			if (isLeft)
			{
				positionOffset.x = -positionOffset.x;
				rotationOffset.y = -rotationOffset.y;
				rotationOffset.z = -rotationOffset.z;
			}
			Transform transform = isLeft ? ik.references.leftHand : ik.references.rightHand;
			Transform forearm = isLeft ? ik.references.leftForearm : ik.references.rightForearm;
			object obj = isLeft ? ik.solver.leftArm.target : ik.solver.rightArm.target;
			Vector3 vector = isLeft ? ik.solver.leftArm.wristToPalmAxis : ik.solver.rightArm.wristToPalmAxis;
			if (vector == Vector3.zero)
			{
				vector = VRIKCalibrator.GuessWristToPalmAxis(transform, forearm);
			}
			Vector3 vector2 = isLeft ? ik.solver.leftArm.palmToThumbAxis : ik.solver.rightArm.palmToThumbAxis;
			if (vector2 == Vector3.zero)
			{
				vector2 = VRIKCalibrator.GuessPalmToThumbAxis(transform, forearm);
			}
			Quaternion rhs = Quaternion.LookRotation(vector, vector2);
			Vector3 b = transform.position + transform.rotation * rhs * positionOffset;
			Quaternion quaternion = Quaternion.Inverse(transform.rotation * rhs * Quaternion.Euler(rotationOffset));
			object obj2 = obj;
			obj2.parent = anchor;
			obj2.localPosition = quaternion * (transform.position - b);
			obj2.localRotation = quaternion * transform.rotation;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x0003FD00 File Offset: 0x0003DF00
		public static Vector3 GuessWristToPalmAxis(Transform hand, Transform forearm)
		{
			Vector3 vector = forearm.position - hand.position;
			Vector3 vector2 = AxisTools.ToVector3(AxisTools.GetAxisToDirection(hand, vector));
			if (Vector3.Dot(vector, hand.rotation * vector2) > 0f)
			{
				vector2 = -vector2;
			}
			return vector2;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0003FD50 File Offset: 0x0003DF50
		public static Vector3 GuessPalmToThumbAxis(Transform hand, Transform forearm)
		{
			if (hand.childCount == 0)
			{
				Debug.LogWarning("Hand " + hand.name + " does not have any fingers, VRIK can not guess the hand bone's orientation. Please assign 'Wrist To Palm Axis' and 'Palm To Thumb Axis' manually for both arms in VRIK settings.", hand);
				return Vector3.zero;
			}
			float num = float.PositiveInfinity;
			int index = 0;
			for (int i = 0; i < hand.childCount; i++)
			{
				float num2 = Vector3.SqrMagnitude(hand.GetChild(i).position - hand.position);
				if (num2 < num)
				{
					num = num2;
					index = i;
				}
			}
			Vector3 vector = Vector3.Cross(Vector3.Cross(hand.position - forearm.position, hand.GetChild(index).position - hand.position), hand.position - forearm.position);
			Vector3 vector2 = AxisTools.ToVector3(AxisTools.GetAxisToDirection(hand, vector));
			if (Vector3.Dot(vector, hand.rotation * vector2) < 0f)
			{
				vector2 = -vector2;
			}
			return vector2;
		}

		// Token: 0x02000141 RID: 321
		[Serializable]
		public class Settings
		{
			// Token: 0x04000955 RID: 2389
			[Tooltip("Multiplies character scale")]
			public float scaleMlp = 1f;

			// Token: 0x04000956 RID: 2390
			[Tooltip("Local axis of the HMD facing forward.")]
			public Vector3 headTrackerForward = Vector3.forward;

			// Token: 0x04000957 RID: 2391
			[Tooltip("Local axis of the HMD facing up.")]
			public Vector3 headTrackerUp = Vector3.up;

			// Token: 0x04000958 RID: 2392
			[Tooltip("Local axis of the hand trackers pointing from the wrist towards the palm.")]
			public Vector3 handTrackerForward = Vector3.forward;

			// Token: 0x04000959 RID: 2393
			[Tooltip("Local axis of the hand trackers pointing in the direction of the surface normal of the back of the hand.")]
			public Vector3 handTrackerUp = Vector3.up;

			// Token: 0x0400095A RID: 2394
			[Tooltip("Local axis of the foot trackers towards the player's forward direction.")]
			public Vector3 footTrackerForward = Vector3.forward;

			// Token: 0x0400095B RID: 2395
			[Tooltip("Local axis of the foot tracker towards the up direction.")]
			public Vector3 footTrackerUp = Vector3.up;

			// Token: 0x0400095C RID: 2396
			[Space(10f)]
			[Tooltip("Offset of the head bone from the HMD in (headTrackerForward, headTrackerUp) space relative to the head tracker.")]
			public Vector3 headOffset;

			// Token: 0x0400095D RID: 2397
			[Tooltip("Offset of the hand bones from the hand trackers in (handTrackerForward, handTrackerUp) space relative to the hand trackers.")]
			public Vector3 handOffset;

			// Token: 0x0400095E RID: 2398
			[Tooltip("Forward offset of the foot bones from the foot trackers.")]
			public float footForwardOffset;

			// Token: 0x0400095F RID: 2399
			[Tooltip("Inward offset of the foot bones from the foot trackers.")]
			public float footInwardOffset;

			// Token: 0x04000960 RID: 2400
			[Tooltip("Used for adjusting foot heading relative to the foot trackers.")]
			[Range(-180f, 180f)]
			public float footHeadingOffset;

			// Token: 0x04000961 RID: 2401
			[Range(0f, 1f)]
			public float pelvisPositionWeight = 1f;

			// Token: 0x04000962 RID: 2402
			[Range(0f, 1f)]
			public float pelvisRotationWeight = 1f;
		}

		// Token: 0x02000142 RID: 322
		[Serializable]
		public class CalibrationData
		{
			// Token: 0x04000963 RID: 2403
			public float scale;

			// Token: 0x04000964 RID: 2404
			public VRIKCalibrator.CalibrationData.Target head;

			// Token: 0x04000965 RID: 2405
			public VRIKCalibrator.CalibrationData.Target leftHand;

			// Token: 0x04000966 RID: 2406
			public VRIKCalibrator.CalibrationData.Target rightHand;

			// Token: 0x04000967 RID: 2407
			public VRIKCalibrator.CalibrationData.Target pelvis;

			// Token: 0x04000968 RID: 2408
			public VRIKCalibrator.CalibrationData.Target leftFoot;

			// Token: 0x04000969 RID: 2409
			public VRIKCalibrator.CalibrationData.Target rightFoot;

			// Token: 0x0400096A RID: 2410
			public VRIKCalibrator.CalibrationData.Target leftLegGoal;

			// Token: 0x0400096B RID: 2411
			public VRIKCalibrator.CalibrationData.Target rightLegGoal;

			// Token: 0x0400096C RID: 2412
			public Vector3 pelvisTargetRight;

			// Token: 0x0400096D RID: 2413
			public float pelvisPositionWeight;

			// Token: 0x0400096E RID: 2414
			public float pelvisRotationWeight;

			// Token: 0x02000143 RID: 323
			[Serializable]
			public class Target
			{
				// Token: 0x06000A13 RID: 2579 RVA: 0x0003FEB6 File Offset: 0x0003E0B6
				public Target(Transform t)
				{
					this.used = (t != null);
					if (!this.used)
					{
						return;
					}
					this.localPosition = t.localPosition;
					this.localRotation = t.localRotation;
				}

				// Token: 0x06000A14 RID: 2580 RVA: 0x0003FEEC File Offset: 0x0003E0EC
				public void SetTo(Transform t)
				{
					if (!this.used)
					{
						return;
					}
					t.localPosition = this.localPosition;
					t.localRotation = this.localRotation;
				}

				// Token: 0x0400096F RID: 2415
				public bool used;

				// Token: 0x04000970 RID: 2416
				public Vector3 localPosition;

				// Token: 0x04000971 RID: 2417
				public Quaternion localRotation;
			}
		}
	}
}
