using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace RootMotion.FinalIK
{
	// Token: 0x020000E1 RID: 225
	[Serializable]
	public class IKSolverVR : IKSolver
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x0002D7B8 File Offset: 0x0002B9B8
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x0002D7C0 File Offset: 0x0002B9C0
		public Animator animator { get; private set; }

		// Token: 0x06000761 RID: 1889 RVA: 0x0002D7CC File Offset: 0x0002B9CC
		public void SetToReferences(VRIK.References references)
		{
			if (!references.isFilled)
			{
				Debug.LogError("Invalid references, one or more Transforms are missing.");
				return;
			}
			this.animator = references.root.GetComponent<Animator>();
			this.solverTransforms = references.GetTransforms();
			this.hasChest = (this.solverTransforms[3] != null);
			this.hasNeck = (this.solverTransforms[4] != null);
			this.hasShoulders = (this.solverTransforms[6] != null && this.solverTransforms[10] != null);
			this.hasToes = (this.solverTransforms[17] != null && this.solverTransforms[21] != null);
			this.hasLegs = (this.solverTransforms[14] != null);
			this.hasArms = (this.solverTransforms[7] != null);
			this.readPositions = new Vector3[this.solverTransforms.Length];
			this.readRotations = new Quaternion[this.solverTransforms.Length];
			this.DefaultAnimationCurves();
			this.GuessHandOrientations(references, true);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0002D8E0 File Offset: 0x0002BAE0
		public void GuessHandOrientations(VRIK.References references, bool onlyIfZero)
		{
			if (!references.isFilled)
			{
				Debug.LogError("VRIK References are not filled in, can not guess hand orientations. Right-click on VRIK header and slect 'Guess Hand Orientations' when you have filled in the References.", references.root);
				return;
			}
			if (this.leftArm.wristToPalmAxis == Vector3.zero || !onlyIfZero)
			{
				this.leftArm.wristToPalmAxis = VRIKCalibrator.GuessWristToPalmAxis(references.leftHand, references.leftForearm);
			}
			if (this.leftArm.palmToThumbAxis == Vector3.zero || !onlyIfZero)
			{
				this.leftArm.palmToThumbAxis = VRIKCalibrator.GuessPalmToThumbAxis(references.leftHand, references.leftForearm);
			}
			if (this.rightArm.wristToPalmAxis == Vector3.zero || !onlyIfZero)
			{
				this.rightArm.wristToPalmAxis = VRIKCalibrator.GuessWristToPalmAxis(references.rightHand, references.rightForearm);
			}
			if (this.rightArm.palmToThumbAxis == Vector3.zero || !onlyIfZero)
			{
				this.rightArm.palmToThumbAxis = VRIKCalibrator.GuessPalmToThumbAxis(references.rightHand, references.rightForearm);
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0002D9E0 File Offset: 0x0002BBE0
		public void DefaultAnimationCurves()
		{
			if (this.locomotion.stepHeight == null)
			{
				this.locomotion.stepHeight = new AnimationCurve();
			}
			if (this.locomotion.heelHeight == null)
			{
				this.locomotion.heelHeight = new AnimationCurve();
			}
			if (this.locomotion.stepHeight.keys.Length == 0)
			{
				this.locomotion.stepHeight.keys = IKSolverVR.GetSineKeyframes(0.03f);
			}
			if (this.locomotion.heelHeight.keys.Length == 0)
			{
				this.locomotion.heelHeight.keys = IKSolverVR.GetSineKeyframes(0.03f);
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0002DA84 File Offset: 0x0002BC84
		public void AddPositionOffset(IKSolverVR.PositionOffset positionOffset, Vector3 value)
		{
			switch (positionOffset)
			{
			case IKSolverVR.PositionOffset.Pelvis:
				this.spine.pelvisPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.Chest:
				this.spine.chestPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.Head:
				this.spine.headPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.LeftHand:
				this.leftArm.handPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.RightHand:
				this.rightArm.handPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.LeftFoot:
				this.leftLeg.footPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.RightFoot:
				this.rightLeg.footPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.LeftHeel:
				this.leftLeg.heelPositionOffset += value;
				return;
			case IKSolverVR.PositionOffset.RightHeel:
				this.rightLeg.heelPositionOffset += value;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0002DB93 File Offset: 0x0002BD93
		public void AddRotationOffset(IKSolverVR.RotationOffset rotationOffset, Vector3 value)
		{
			this.AddRotationOffset(rotationOffset, Quaternion.Euler(value));
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0002DBA4 File Offset: 0x0002BDA4
		public void AddRotationOffset(IKSolverVR.RotationOffset rotationOffset, Quaternion value)
		{
			switch (rotationOffset)
			{
			case IKSolverVR.RotationOffset.Pelvis:
				this.spine.pelvisRotationOffset = value * this.spine.pelvisRotationOffset;
				return;
			case IKSolverVR.RotationOffset.Chest:
				this.spine.chestRotationOffset = value * this.spine.chestRotationOffset;
				return;
			case IKSolverVR.RotationOffset.Head:
				this.spine.headRotationOffset = value * this.spine.headRotationOffset;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0002DC1C File Offset: 0x0002BE1C
		public void AddPlatformMotion(Vector3 deltaPosition, Quaternion deltaRotation, Vector3 platformPivot)
		{
			this.locomotion.AddDeltaPosition(deltaPosition);
			this.raycastOriginPelvis += deltaPosition;
			this.locomotion.AddDeltaRotation(deltaRotation, platformPivot);
			this.spine.faceDirection = deltaRotation * this.spine.faceDirection;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0002DC70 File Offset: 0x0002BE70
		public void Reset()
		{
			if (!base.initiated)
			{
				return;
			}
			this.UpdateSolverTransforms();
			this.Read(this.readPositions, this.readRotations, this.hasChest, this.hasNeck, this.hasShoulders, this.hasToes, this.hasLegs, this.hasArms);
			this.spine.faceDirection = this.rootBone.readRotation * Vector3.forward;
			if (this.hasLegs)
			{
				this.locomotion.Reset(this.readPositions, this.readRotations);
				this.raycastOriginPelvis = this.spine.pelvis.readPosition;
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0002DD18 File Offset: 0x0002BF18
		public override void StoreDefaultLocalState()
		{
			for (int i = 1; i < this.solverTransforms.Length; i++)
			{
				if (this.solverTransforms[i] != null)
				{
					this.defaultLocalPositions[i - 1] = this.solverTransforms[i].localPosition;
					this.defaultLocalRotations[i - 1] = this.solverTransforms[i].localRotation;
				}
			}
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0002DD80 File Offset: 0x0002BF80
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			if (this.LOD >= 2)
			{
				return;
			}
			for (int i = 1; i < this.solverTransforms.Length; i++)
			{
				if (this.solverTransforms[i] != null)
				{
					bool flag = i == 1;
					bool flag2 = i == 8 || i == 9 || i == 12 || i == 13;
					bool flag3 = (i >= 15 && i <= 17) || (i >= 19 && i <= 21);
					if (flag || flag2 || flag3)
					{
						this.solverTransforms[i].localPosition = this.defaultLocalPositions[i - 1];
					}
					this.solverTransforms[i].localRotation = this.defaultLocalRotations[i - 1];
				}
			}
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0002DE3E File Offset: 0x0002C03E
		public override IKSolver.Point[] GetPoints()
		{
			Debug.LogError("GetPoints() is not applicable to IKSolverVR.");
			return null;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0002DE4B File Offset: 0x0002C04B
		public override IKSolver.Point GetPoint(Transform transform)
		{
			Debug.LogError("GetPoint is not applicable to IKSolverVR.");
			return null;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0002DE58 File Offset: 0x0002C058
		public override bool IsValid(ref string message)
		{
			if (this.solverTransforms == null || this.solverTransforms.Length == 0)
			{
				message = "Trying to initiate IKSolverVR with invalid bone references.";
				return false;
			}
			if (this.leftArm.wristToPalmAxis == Vector3.zero)
			{
				message = "Left arm 'Wrist To Palm Axis' needs to be set in VRIK. Please select the hand bone, set it to the axis that points from the wrist towards the palm. If the arrow points away from the palm, axis must be negative.";
				return false;
			}
			if (this.rightArm.wristToPalmAxis == Vector3.zero)
			{
				message = "Right arm 'Wrist To Palm Axis' needs to be set in VRIK. Please select the hand bone, set it to the axis that points from the wrist towards the palm. If the arrow points away from the palm, axis must be negative.";
				return false;
			}
			if (this.leftArm.palmToThumbAxis == Vector3.zero)
			{
				message = "Left arm 'Palm To Thumb Axis' needs to be set in VRIK. Please select the hand bone, set it to the axis that points from the palm towards the thumb. If the arrow points away from the thumb, axis must be negative.";
				return false;
			}
			if (this.rightArm.palmToThumbAxis == Vector3.zero)
			{
				message = "Right arm 'Palm To Thumb Axis' needs to be set in VRIK. Please select the hand bone, set it to the axis that points from the palm towards the thumb. If the arrow points away from the thumb, axis must be negative.";
				return false;
			}
			return true;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0002DF00 File Offset: 0x0002C100
		private Vector3 GetNormal(Transform[] transforms)
		{
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			for (int i = 0; i < transforms.Length; i++)
			{
				vector2 += transforms[i].position;
			}
			vector2 /= (float)transforms.Length;
			for (int j = 0; j < transforms.Length - 1; j++)
			{
				vector += Vector3.Cross(transforms[j].position - vector2, transforms[j + 1].position - vector2).normalized;
			}
			return vector;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0002DF88 File Offset: 0x0002C188
		private static Keyframe[] GetSineKeyframes(float mag)
		{
			Keyframe[] array = new Keyframe[3];
			array[0].time = 0f;
			array[0].value = 0f;
			array[1].time = 0.5f;
			array[1].value = mag;
			array[2].time = 1f;
			array[2].value = 0f;
			return array;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0002E000 File Offset: 0x0002C200
		private void UpdateSolverTransforms()
		{
			for (int i = 0; i < this.solverTransforms.Length; i++)
			{
				if (this.solverTransforms[i] != null)
				{
					this.readPositions[i] = this.solverTransforms[i].position;
					this.readRotations[i] = this.solverTransforms[i].rotation;
				}
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0002E064 File Offset: 0x0002C264
		protected override void OnInitiate()
		{
			this.UpdateSolverTransforms();
			this.Read(this.readPositions, this.readRotations, this.hasChest, this.hasNeck, this.hasShoulders, this.hasToes, this.hasLegs, this.hasArms);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0002E0B0 File Offset: 0x0002C2B0
		protected override void OnUpdate()
		{
			if (this.IKPositionWeight > 0f)
			{
				if (this.LOD < 2)
				{
					bool flag = false;
					if (this.lastLOD != this.LOD && this.lastLOD == 2)
					{
						this.spine.faceDirection = this.rootBone.readRotation * Vector3.forward;
						if (this.hasLegs)
						{
							if (this.locomotion.weight > 0f)
							{
								this.root.position = new Vector3(this.spine.headTarget.position.x, this.root.position.y, this.spine.headTarget.position.z);
								Vector3 faceDirection = this.spine.faceDirection;
								faceDirection.y = 0f;
								this.root.rotation = Quaternion.LookRotation(faceDirection, this.root.up);
								this.UpdateSolverTransforms();
								this.Read(this.readPositions, this.readRotations, this.hasChest, this.hasNeck, this.hasShoulders, this.hasToes, this.hasLegs, this.hasArms);
								flag = true;
								this.locomotion.Reset(this.readPositions, this.readRotations);
							}
							this.raycastOriginPelvis = this.spine.pelvis.readPosition;
						}
					}
					if (!flag)
					{
						this.UpdateSolverTransforms();
						this.Read(this.readPositions, this.readRotations, this.hasChest, this.hasNeck, this.hasShoulders, this.hasToes, this.hasLegs, this.hasArms);
					}
					this.Solve();
					this.Write();
					this.WriteTransforms();
				}
				else if (this.locomotion.weight > 0f)
				{
					this.root.position = new Vector3(this.spine.headTarget.position.x, this.root.position.y, this.spine.headTarget.position.z);
					Vector3 forward = this.spine.headTarget.rotation * this.spine.anchorRelativeToHead * Vector3.forward;
					forward.y = 0f;
					this.root.rotation = Quaternion.LookRotation(forward, this.root.up);
				}
			}
			this.lastLOD = this.LOD;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0002E338 File Offset: 0x0002C538
		private void WriteTransforms()
		{
			for (int i = 0; i < this.solverTransforms.Length; i++)
			{
				if (this.solverTransforms[i] != null)
				{
					bool flag = i < 2;
					bool flag2 = i == 8 || i == 9 || i == 12 || i == 13;
					bool flag3 = (i >= 15 && i <= 17) || (i >= 19 && i <= 21);
					if (this.LOD > 0)
					{
						flag2 = false;
						flag3 = false;
					}
					if (flag)
					{
						this.solverTransforms[i].position = V3Tools.Lerp(this.solverTransforms[i].position, this.GetPosition(i), this.IKPositionWeight);
					}
					if (flag2 || flag3)
					{
						if (this.IKPositionWeight < 1f)
						{
							Vector3 localPosition = this.solverTransforms[i].localPosition;
							this.solverTransforms[i].position = V3Tools.Lerp(this.solverTransforms[i].position, this.GetPosition(i), this.IKPositionWeight);
							this.solverTransforms[i].localPosition = Vector3.Project(this.solverTransforms[i].localPosition, localPosition);
						}
						else
						{
							this.solverTransforms[i].position = V3Tools.Lerp(this.solverTransforms[i].position, this.GetPosition(i), this.IKPositionWeight);
						}
					}
					this.solverTransforms[i].rotation = QuaTools.Lerp(this.solverTransforms[i].rotation, this.GetRotation(i), this.IKPositionWeight);
				}
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0002E4B0 File Offset: 0x0002C6B0
		private void Read(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, bool hasArms)
		{
			if (this.rootBone == null)
			{
				this.rootBone = new IKSolverVR.VirtualBone(positions[0], rotations[0]);
			}
			else
			{
				this.rootBone.Read(positions[0], rotations[0]);
			}
			this.spine.Read(positions, rotations, hasChest, hasNeck, hasShoulders, hasToes, hasLegs, 0, 1);
			if (hasArms)
			{
				this.leftArm.Read(positions, rotations, hasChest, hasNeck, hasShoulders, hasToes, hasLegs, hasChest ? 3 : 2, 6);
				this.rightArm.Read(positions, rotations, hasChest, hasNeck, hasShoulders, hasToes, hasLegs, hasChest ? 3 : 2, 10);
			}
			if (hasLegs)
			{
				this.leftLeg.Read(positions, rotations, hasChest, hasNeck, hasShoulders, hasToes, hasLegs, 1, 14);
				this.rightLeg.Read(positions, rotations, hasChest, hasNeck, hasShoulders, hasToes, hasLegs, 1, 18);
			}
			for (int i = 0; i < rotations.Length; i++)
			{
				this.solvedPositions[i] = positions[i];
				this.solvedRotations[i] = rotations[i];
			}
			if (!base.initiated)
			{
				if (hasLegs)
				{
					this.legs = new IKSolverVR.Leg[]
					{
						this.leftLeg,
						this.rightLeg
					};
				}
				if (hasArms)
				{
					this.arms = new IKSolverVR.Arm[]
					{
						this.leftArm,
						this.rightArm
					};
				}
				if (hasLegs)
				{
					this.locomotion.Initiate(this.animator, positions, rotations, hasToes, this.scale);
				}
				this.raycastOriginPelvis = this.spine.pelvis.readPosition;
				this.spine.faceDirection = this.readRotations[0] * Vector3.forward;
			}
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0002E664 File Offset: 0x0002C864
		private void Solve()
		{
			if (this.scale <= 0f)
			{
				Debug.LogError("VRIK solver scale <= 0, can not solve!");
				return;
			}
			if (this.hasLegs && this.lastLocomotionWeight <= 0f && this.locomotion.weight > 0f)
			{
				this.locomotion.Reset(this.readPositions, this.readRotations);
			}
			this.spine.SetLOD(this.LOD);
			if (this.hasArms)
			{
				IKSolverVR.Arm[] array = this.arms;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetLOD(this.LOD);
				}
			}
			if (this.hasLegs)
			{
				IKSolverVR.Leg[] array2 = this.legs;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].SetLOD(this.LOD);
				}
			}
			this.spine.PreSolve(this.scale);
			if (this.hasArms)
			{
				IKSolverVR.Arm[] array = this.arms;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].PreSolve(this.scale);
				}
			}
			if (this.hasLegs)
			{
				IKSolverVR.Leg[] array2 = this.legs;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].PreSolve(this.scale);
				}
			}
			if (this.hasArms)
			{
				IKSolverVR.Arm[] array = this.arms;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ApplyOffsets(this.scale);
				}
			}
			this.spine.ApplyOffsets(this.scale);
			this.spine.Solve(this.animator, this.rootBone, this.legs, this.arms, this.scale);
			if (this.hasLegs && this.spine.pelvisPositionWeight > 0f && this.plantFeet)
			{
				Warning.Log("If VRIK 'Pelvis Position Weight' is > 0, 'Plant Feet' should be disabled to improve performance and stability.", this.root, false);
			}
			float deltaTime = Time.deltaTime;
			if (this.hasLegs)
			{
				if (this.locomotion.weight > 0f)
				{
					IKSolverVR.Locomotion.Mode mode = this.locomotion.mode;
					if (mode != IKSolverVR.Locomotion.Mode.Procedural)
					{
						if (mode == IKSolverVR.Locomotion.Mode.Animated)
						{
							if (this.lastLocomotionWeight <= 0f)
							{
								this.locomotion.Reset_Animated(this.readPositions);
							}
							this.locomotion.Solve_Animated(this, this.scale, deltaTime);
						}
					}
					else
					{
						Vector3 a = Vector3.zero;
						Vector3 a2 = Vector3.zero;
						Quaternion identity = Quaternion.identity;
						Quaternion identity2 = Quaternion.identity;
						float num = 0f;
						float num2 = 0f;
						float d = 0f;
						float d2 = 0f;
						this.locomotion.Solve_Procedural(this.rootBone, this.spine, this.leftLeg, this.rightLeg, this.leftArm, this.rightArm, this.supportLegIndex, out a, out a2, out identity, out identity2, out num, out num2, out d, out d2, this.scale, deltaTime);
						a += this.root.up * num;
						a2 += this.root.up * num2;
						this.leftLeg.footPositionOffset += (a - this.leftLeg.lastBone.solverPosition) * this.IKPositionWeight * (1f - this.leftLeg.positionWeight) * this.locomotion.weight;
						this.rightLeg.footPositionOffset += (a2 - this.rightLeg.lastBone.solverPosition) * this.IKPositionWeight * (1f - this.rightLeg.positionWeight) * this.locomotion.weight;
						this.leftLeg.heelPositionOffset += this.root.up * d * this.locomotion.weight;
						this.rightLeg.heelPositionOffset += this.root.up * d2 * this.locomotion.weight;
						Quaternion quaternion = QuaTools.FromToRotation(this.leftLeg.lastBone.solverRotation, identity);
						Quaternion quaternion2 = QuaTools.FromToRotation(this.rightLeg.lastBone.solverRotation, identity2);
						quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, this.IKPositionWeight * (1f - this.leftLeg.rotationWeight) * this.locomotion.weight);
						quaternion2 = Quaternion.Lerp(Quaternion.identity, quaternion2, this.IKPositionWeight * (1f - this.rightLeg.rotationWeight) * this.locomotion.weight);
						this.leftLeg.footRotationOffset = quaternion * this.leftLeg.footRotationOffset;
						this.rightLeg.footRotationOffset = quaternion2 * this.rightLeg.footRotationOffset;
						Vector3 vector = Vector3.Lerp(this.leftLeg.position + this.leftLeg.footPositionOffset, this.rightLeg.position + this.rightLeg.footPositionOffset, 0.5f);
						vector = V3Tools.PointToPlane(vector, this.rootBone.solverPosition, this.root.up);
						Vector3 vector2 = this.rootBone.solverPosition + this.rootVelocity * deltaTime * 2f * this.locomotion.weight;
						vector2 = Vector3.Lerp(vector2, vector, deltaTime * this.locomotion.rootSpeed * this.locomotion.weight);
						this.rootBone.solverPosition = vector2;
						this.rootVelocity += (vector - this.rootBone.solverPosition) * deltaTime * 10f;
						Vector3 b = V3Tools.ExtractVertical(this.rootVelocity, this.root.up, 1f);
						this.rootVelocity -= b;
						float d3 = Mathf.Min(num + num2, this.locomotion.maxBodyYOffset * this.scale);
						this.bodyOffset = Vector3.Lerp(this.bodyOffset, this.root.up * d3, deltaTime * 3f);
						this.bodyOffset = Vector3.Lerp(Vector3.zero, this.bodyOffset, this.locomotion.weight);
					}
				}
				else if (this.lastLocomotionWeight > 0f)
				{
					this.locomotion.Reset_Animated(this.readPositions);
				}
			}
			this.lastLocomotionWeight = this.locomotion.weight;
			if (this.hasLegs)
			{
				IKSolverVR.Leg[] array2 = this.legs;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].ApplyOffsets(this.scale);
				}
				if (!this.plantFeet || this.LOD > 0)
				{
					this.spine.InverseTranslateToHead(this.legs, false, false, this.bodyOffset, 1f);
					array2 = this.legs;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].TranslateRoot(this.spine.pelvis.solverPosition, this.spine.pelvis.solverRotation);
					}
					array2 = this.legs;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].Solve(true);
					}
				}
				else
				{
					for (int j = 0; j < 2; j++)
					{
						this.spine.InverseTranslateToHead(this.legs, true, true, this.bodyOffset, 1f);
						array2 = this.legs;
						for (int i = 0; i < array2.Length; i++)
						{
							array2[i].TranslateRoot(this.spine.pelvis.solverPosition, this.spine.pelvis.solverRotation);
						}
						array2 = this.legs;
						for (int i = 0; i < array2.Length; i++)
						{
							array2[i].Solve(j == 0);
						}
					}
				}
			}
			else
			{
				this.spine.InverseTranslateToHead(this.legs, false, false, this.bodyOffset, 1f);
			}
			if (this.hasArms)
			{
				for (int k = 0; k < this.arms.Length; k++)
				{
					this.arms[k].TranslateRoot(this.spine.chest.solverPosition, this.spine.chest.solverRotation);
				}
				for (int l = 0; l < this.arms.Length; l++)
				{
					this.arms[l].Solve(l == 0);
				}
			}
			this.spine.ResetOffsets();
			if (this.hasLegs)
			{
				IKSolverVR.Leg[] array2 = this.legs;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].ResetOffsets();
				}
			}
			if (this.hasArms)
			{
				IKSolverVR.Arm[] array = this.arms;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ResetOffsets();
				}
			}
			if (this.hasLegs)
			{
				this.spine.pelvisPositionOffset += this.GetPelvisOffset(deltaTime);
				this.spine.chestPositionOffset += this.spine.pelvisPositionOffset;
			}
			this.Write();
			if (this.hasLegs)
			{
				this.supportLegIndex = -1;
				float num3 = float.PositiveInfinity;
				for (int m = 0; m < this.legs.Length; m++)
				{
					float num4 = Vector3.SqrMagnitude(this.legs[m].lastBone.solverPosition - this.legs[m].bones[0].solverPosition);
					if (num4 < num3)
					{
						this.supportLegIndex = m;
						num3 = num4;
					}
				}
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0002F01C File Offset: 0x0002D21C
		private Vector3 GetPosition(int index)
		{
			return this.solvedPositions[index];
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0002F02A File Offset: 0x0002D22A
		private Quaternion GetRotation(int index)
		{
			return this.solvedRotations[index];
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0002F038 File Offset: 0x0002D238
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x0002F040 File Offset: 0x0002D240
		[HideInInspector]
		public IKSolverVR.VirtualBone rootBone { get; private set; }

		// Token: 0x0600077A RID: 1914 RVA: 0x0002F04C File Offset: 0x0002D24C
		private void Write()
		{
			this.solvedPositions[0] = this.rootBone.solverPosition;
			this.solvedRotations[0] = this.rootBone.solverRotation;
			this.spine.Write(ref this.solvedPositions, ref this.solvedRotations);
			if (this.hasLegs)
			{
				IKSolverVR.Leg[] array = this.legs;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Write(ref this.solvedPositions, ref this.solvedRotations);
				}
			}
			if (this.hasArms)
			{
				IKSolverVR.Arm[] array2 = this.arms;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Write(ref this.solvedPositions, ref this.solvedRotations);
				}
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0002F100 File Offset: 0x0002D300
		private Vector3 GetPelvisOffset(float deltaTime)
		{
			if (this.locomotion.weight <= 0f)
			{
				return Vector3.zero;
			}
			if (this.locomotion.blockingLayers == -1)
			{
				return Vector3.zero;
			}
			Vector3 vector = this.raycastOriginPelvis;
			vector.y = this.spine.pelvis.solverPosition.y;
			Vector3 vector2 = this.spine.pelvis.readPosition;
			vector2.y = this.spine.pelvis.solverPosition.y;
			Vector3 direction = vector2 - vector;
			RaycastHit raycastHit;
			if (this.locomotion.raycastRadius <= 0f)
			{
				if (Physics.Raycast(vector, direction, out raycastHit, direction.magnitude * 1.1f, this.locomotion.blockingLayers))
				{
					vector2 = raycastHit.point;
				}
			}
			else if (Physics.SphereCast(vector, this.locomotion.raycastRadius * 1.1f, direction, out raycastHit, direction.magnitude, this.locomotion.blockingLayers))
			{
				vector2 = vector + direction.normalized * raycastHit.distance / 1.1f;
			}
			Vector3 a = this.spine.pelvis.solverPosition;
			direction = a - vector2;
			if (this.locomotion.raycastRadius <= 0f)
			{
				if (Physics.Raycast(vector2, direction, out raycastHit, direction.magnitude, this.locomotion.blockingLayers))
				{
					a = raycastHit.point;
				}
			}
			else if (Physics.SphereCast(vector2, this.locomotion.raycastRadius, direction, out raycastHit, direction.magnitude, this.locomotion.blockingLayers))
			{
				a = vector2 + direction.normalized * raycastHit.distance;
			}
			this.lastOffset = Vector3.Lerp(this.lastOffset, Vector3.zero, deltaTime * 3f);
			a += Vector3.ClampMagnitude(this.lastOffset, 0.75f);
			a.y = this.spine.pelvis.solverPosition.y;
			this.lastOffset = Vector3.Lerp(this.lastOffset, a - this.spine.pelvis.solverPosition, deltaTime * 15f);
			return this.lastOffset;
		}

		// Token: 0x04000657 RID: 1623
		private Transform[] solverTransforms = new Transform[0];

		// Token: 0x04000658 RID: 1624
		private bool hasChest;

		// Token: 0x04000659 RID: 1625
		private bool hasNeck;

		// Token: 0x0400065A RID: 1626
		private bool hasShoulders;

		// Token: 0x0400065B RID: 1627
		private bool hasToes;

		// Token: 0x0400065C RID: 1628
		private bool hasLegs;

		// Token: 0x0400065D RID: 1629
		private bool hasArms;

		// Token: 0x0400065E RID: 1630
		private Vector3[] readPositions = new Vector3[0];

		// Token: 0x0400065F RID: 1631
		private Quaternion[] readRotations = new Quaternion[0];

		// Token: 0x04000660 RID: 1632
		private Vector3[] solvedPositions = new Vector3[22];

		// Token: 0x04000661 RID: 1633
		private Quaternion[] solvedRotations = new Quaternion[22];

		// Token: 0x04000662 RID: 1634
		private Quaternion[] defaultLocalRotations = new Quaternion[21];

		// Token: 0x04000663 RID: 1635
		private Vector3[] defaultLocalPositions = new Vector3[21];

		// Token: 0x04000664 RID: 1636
		private Vector3 rootV;

		// Token: 0x04000665 RID: 1637
		private Vector3 rootVelocity;

		// Token: 0x04000666 RID: 1638
		private Vector3 bodyOffset;

		// Token: 0x04000667 RID: 1639
		private int supportLegIndex;

		// Token: 0x04000668 RID: 1640
		private int lastLOD;

		// Token: 0x04000669 RID: 1641
		private float lastLocomotionWeight;

		// Token: 0x0400066A RID: 1642
		[Tooltip("LOD 0: Full quality solving. LOD 1: Shoulder solving, stretching plant feet disabled, spine solving quality reduced. This provides about 30% of performance gain. LOD 2: Culled, but updating root position and rotation if locomotion is enabled.")]
		[Range(0f, 2f)]
		public int LOD;

		// Token: 0x0400066B RID: 1643
		[Tooltip("Scale of the character. Value of 1 means normal adult human size.")]
		public float scale = 1f;

		// Token: 0x0400066C RID: 1644
		[Tooltip("If true, will keep the toes planted even if head target is out of reach, so this can cause the camera to exit the head if it is too high for the model to reach. Enabling this increases the cost of the solver as the legs will have to be solved multiple times.")]
		public bool plantFeet = true;

		// Token: 0x0400066E RID: 1646
		[Tooltip("The spine solver.")]
		public IKSolverVR.Spine spine = new IKSolverVR.Spine();

		// Token: 0x0400066F RID: 1647
		[Tooltip("The left arm solver.")]
		public IKSolverVR.Arm leftArm = new IKSolverVR.Arm();

		// Token: 0x04000670 RID: 1648
		[Tooltip("The right arm solver.")]
		public IKSolverVR.Arm rightArm = new IKSolverVR.Arm();

		// Token: 0x04000671 RID: 1649
		[Tooltip("The left leg solver.")]
		public IKSolverVR.Leg leftLeg = new IKSolverVR.Leg();

		// Token: 0x04000672 RID: 1650
		[Tooltip("The right leg solver.")]
		public IKSolverVR.Leg rightLeg = new IKSolverVR.Leg();

		// Token: 0x04000673 RID: 1651
		[Tooltip("Procedural leg shuffling for stationary VR games. Not designed for roomscale and thumbstick locomotion. For those it would be better to use a strafing locomotion blend tree to make the character follow the horizontal direction towards the HMD by root motion or script.")]
		public IKSolverVR.Locomotion locomotion = new IKSolverVR.Locomotion();

		// Token: 0x04000674 RID: 1652
		private IKSolverVR.Leg[] legs = new IKSolverVR.Leg[2];

		// Token: 0x04000675 RID: 1653
		private IKSolverVR.Arm[] arms = new IKSolverVR.Arm[2];

		// Token: 0x04000676 RID: 1654
		private Vector3 headPosition;

		// Token: 0x04000677 RID: 1655
		private Vector3 headDeltaPosition;

		// Token: 0x04000678 RID: 1656
		private Vector3 raycastOriginPelvis;

		// Token: 0x04000679 RID: 1657
		private Vector3 lastOffset;

		// Token: 0x0400067A RID: 1658
		private Vector3 debugPos1;

		// Token: 0x0400067B RID: 1659
		private Vector3 debugPos2;

		// Token: 0x0400067C RID: 1660
		private Vector3 debugPos3;

		// Token: 0x0400067D RID: 1661
		private Vector3 debugPos4;

		// Token: 0x020000E2 RID: 226
		[Serializable]
		public class Arm : IKSolverVR.BodyPart
		{
			// Token: 0x170000CF RID: 207
			// (get) Token: 0x0600077D RID: 1917 RVA: 0x0002F433 File Offset: 0x0002D633
			// (set) Token: 0x0600077E RID: 1918 RVA: 0x0002F43B File Offset: 0x0002D63B
			public Vector3 position { get; private set; }

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x0600077F RID: 1919 RVA: 0x0002F444 File Offset: 0x0002D644
			// (set) Token: 0x06000780 RID: 1920 RVA: 0x0002F44C File Offset: 0x0002D64C
			public Quaternion rotation { get; private set; }

			// Token: 0x170000D1 RID: 209
			// (get) Token: 0x06000781 RID: 1921 RVA: 0x0002F455 File Offset: 0x0002D655
			private IKSolverVR.VirtualBone shoulder
			{
				get
				{
					return this.bones[0];
				}
			}

			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x06000782 RID: 1922 RVA: 0x0002F45F File Offset: 0x0002D65F
			private IKSolverVR.VirtualBone upperArm
			{
				get
				{
					return this.bones[this.hasShoulder ? 1 : 0];
				}
			}

			// Token: 0x170000D3 RID: 211
			// (get) Token: 0x06000783 RID: 1923 RVA: 0x0002F474 File Offset: 0x0002D674
			private IKSolverVR.VirtualBone forearm
			{
				get
				{
					return this.bones[this.hasShoulder ? 2 : 1];
				}
			}

			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x06000784 RID: 1924 RVA: 0x0002F489 File Offset: 0x0002D689
			private IKSolverVR.VirtualBone hand
			{
				get
				{
					return this.bones[this.hasShoulder ? 3 : 2];
				}
			}

			// Token: 0x06000785 RID: 1925 RVA: 0x0002F4A0 File Offset: 0x0002D6A0
			protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
				Vector3 position = positions[index];
				Quaternion rotation = rotations[index];
				Vector3 vector = positions[index + 1];
				Quaternion quaternion = rotations[index + 1];
				Vector3 vector2 = positions[index + 2];
				Quaternion rotation2 = rotations[index + 2];
				Vector3 vector3 = positions[index + 3];
				Quaternion quaternion2 = rotations[index + 3];
				if (!this.initiated)
				{
					this.IKPosition = vector3;
					this.IKRotation = quaternion2;
					this.rotation = this.IKRotation;
					this.hasShoulder = hasShoulders;
					this.bones = new IKSolverVR.VirtualBone[this.hasShoulder ? 4 : 3];
					if (this.hasShoulder)
					{
						this.bones[0] = new IKSolverVR.VirtualBone(position, rotation);
						this.bones[1] = new IKSolverVR.VirtualBone(vector, quaternion);
						this.bones[2] = new IKSolverVR.VirtualBone(vector2, rotation2);
						this.bones[3] = new IKSolverVR.VirtualBone(vector3, quaternion2);
					}
					else
					{
						this.bones[0] = new IKSolverVR.VirtualBone(vector, quaternion);
						this.bones[1] = new IKSolverVR.VirtualBone(vector2, rotation2);
						this.bones[2] = new IKSolverVR.VirtualBone(vector3, quaternion2);
					}
					Vector3 vector4 = rotations[0] * Vector3.forward;
					this.chestForwardAxis = Quaternion.Inverse(this.rootRotation) * vector4;
					this.chestUpAxis = Quaternion.Inverse(this.rootRotation) * (rotations[0] * Vector3.up);
					Vector3 vector5 = AxisTools.GetAxisVectorToDirection(quaternion, vector4);
					if (Vector3.Dot(quaternion * vector5, vector4) < 0f)
					{
						vector5 = -vector5;
					}
					this.upperArmBendAxis = Vector3.Cross(Quaternion.Inverse(quaternion) * (vector2 - vector), vector5);
					if (this.upperArmBendAxis == Vector3.zero)
					{
						Debug.LogError("VRIK can not calculate which way to bend the arms because the arms are perfectly straight. Please rotate the elbow bones slightly in their natural bending direction in the Editor.");
					}
				}
				if (this.hasShoulder)
				{
					this.bones[0].Read(position, rotation);
					this.bones[1].Read(vector, quaternion);
					this.bones[2].Read(vector2, rotation2);
					this.bones[3].Read(vector3, quaternion2);
					return;
				}
				this.bones[0].Read(vector, quaternion);
				this.bones[1].Read(vector2, rotation2);
				this.bones[2].Read(vector3, quaternion2);
			}

			// Token: 0x06000786 RID: 1926 RVA: 0x0002F6F8 File Offset: 0x0002D8F8
			public override void PreSolve(float scale)
			{
				if (this.target != null)
				{
					this.IKPosition = this.target.position;
					this.IKRotation = this.target.rotation;
				}
				this.position = V3Tools.Lerp(this.hand.solverPosition, this.IKPosition, this.positionWeight);
				this.rotation = QuaTools.Lerp(this.hand.solverRotation, this.IKRotation, this.rotationWeight);
				this.shoulder.axis = this.shoulder.axis.normalized;
				this.forearmRelToUpperArm = Quaternion.Inverse(this.upperArm.solverRotation) * this.forearm.solverRotation;
			}

			// Token: 0x06000787 RID: 1927 RVA: 0x0002F7BA File Offset: 0x0002D9BA
			public override void ApplyOffsets(float scale)
			{
				this.position += this.handPositionOffset;
			}

			// Token: 0x06000788 RID: 1928 RVA: 0x0002F7D4 File Offset: 0x0002D9D4
			private void Stretching()
			{
				float num = this.upperArm.length + this.forearm.length;
				Vector3 vector = Vector3.zero;
				Vector3 b = Vector3.zero;
				if (this.armLengthMlp != 1f)
				{
					num *= this.armLengthMlp;
					vector = (this.forearm.solverPosition - this.upperArm.solverPosition) * (this.armLengthMlp - 1f);
					b = (this.hand.solverPosition - this.forearm.solverPosition) * (this.armLengthMlp - 1f);
					this.forearm.solverPosition += vector;
					this.hand.solverPosition += vector + b;
				}
				float time = Vector3.Distance(this.upperArm.solverPosition, this.position) / num;
				float num2 = this.stretchCurve.Evaluate(time);
				num2 *= this.positionWeight;
				vector = (this.forearm.solverPosition - this.upperArm.solverPosition) * num2;
				b = (this.hand.solverPosition - this.forearm.solverPosition) * num2;
				this.forearm.solverPosition += vector;
				this.hand.solverPosition += vector + b;
			}

			// Token: 0x06000789 RID: 1929 RVA: 0x0002F958 File Offset: 0x0002DB58
			public void Solve(bool isLeft)
			{
				this.chestRotation = Quaternion.LookRotation(this.rootRotation * this.chestForwardAxis, this.rootRotation * this.chestUpAxis);
				this.chestForward = this.chestRotation * Vector3.forward;
				this.chestUp = this.chestRotation * Vector3.up;
				Vector3 vector = Vector3.zero;
				if (this.hasShoulder && this.shoulderRotationWeight > 0f && this.LOD < 1)
				{
					IKSolverVR.Arm.ShoulderRotationMode shoulderRotationMode = this.shoulderRotationMode;
					if (shoulderRotationMode != IKSolverVR.Arm.ShoulderRotationMode.YawPitch)
					{
						if (shoulderRotationMode == IKSolverVR.Arm.ShoulderRotationMode.FromTo)
						{
							Quaternion solverRotation = this.shoulder.solverRotation;
							Quaternion quaternion = Quaternion.FromToRotation((this.upperArm.solverPosition - this.shoulder.solverPosition).normalized + this.chestForward, this.position - this.shoulder.solverPosition);
							quaternion = Quaternion.Slerp(Quaternion.identity, quaternion, 0.5f * this.shoulderRotationWeight * this.positionWeight);
							IKSolverVR.VirtualBone.RotateBy(this.bones, quaternion);
							this.Stretching();
							IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 0, 2, 3, this.position, Vector3.Cross(this.forearm.solverPosition - this.shoulder.solverPosition, this.hand.solverPosition - this.shoulder.solverPosition), 0.5f * this.shoulderRotationWeight * this.positionWeight);
							vector = this.GetBendNormal(this.position - this.upperArm.solverPosition);
							IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 1, 2, 3, this.position, vector, this.positionWeight);
							Quaternion rotation = Quaternion.Inverse(Quaternion.LookRotation(this.chestUp, this.chestForward));
							Vector3 vector2 = rotation * (solverRotation * this.shoulder.axis);
							Vector3 vector3 = rotation * (this.shoulder.solverRotation * this.shoulder.axis);
							float current = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
							float num = Mathf.Atan2(vector3.x, vector3.z) * 57.29578f;
							float num2 = Mathf.DeltaAngle(current, num);
							if (isLeft)
							{
								num2 = -num2;
							}
							num2 = Mathf.Clamp(num2 * this.shoulderRotationWeight * this.shoulderTwistWeight * 2f * this.positionWeight, 0f, 180f);
							this.shoulder.solverRotation = Quaternion.AngleAxis(num2, this.shoulder.solverRotation * (isLeft ? this.shoulder.axis : (-this.shoulder.axis))) * this.shoulder.solverRotation;
							this.upperArm.solverRotation = Quaternion.AngleAxis(num2, this.upperArm.solverRotation * (isLeft ? this.upperArm.axis : (-this.upperArm.axis))) * this.upperArm.solverRotation;
						}
					}
					else
					{
						Vector3 point = (this.position - this.shoulder.solverPosition).normalized;
						float num3 = isLeft ? this.shoulderYawOffset : (-this.shoulderYawOffset);
						Quaternion quaternion2 = Quaternion.AngleAxis((isLeft ? -90f : 90f) + num3, this.chestUp) * this.chestRotation;
						Vector3 vector4 = Quaternion.Inverse(quaternion2) * point;
						float num4 = Mathf.Atan2(vector4.x, vector4.z) * 57.29578f;
						float num5 = Vector3.Dot(vector4, Vector3.up);
						num5 = 1f - Mathf.Abs(num5);
						num4 *= num5;
						num4 -= num3;
						float num6 = isLeft ? -20f : -50f;
						float num7 = isLeft ? 50f : 20f;
						num4 = this.DamperValue(num4, num6 - num3, num7 - num3, 0.7f);
						Vector3 fromDirection = this.shoulder.solverRotation * this.shoulder.axis;
						Vector3 toDirection = quaternion2 * (Quaternion.AngleAxis(num4, Vector3.up) * Vector3.forward);
						Quaternion rhs = Quaternion.FromToRotation(fromDirection, toDirection);
						quaternion2 = Quaternion.AngleAxis(isLeft ? -90f : 90f, this.chestUp) * this.chestRotation;
						quaternion2 = Quaternion.AngleAxis(isLeft ? this.shoulderPitchOffset : (-this.shoulderPitchOffset), this.chestForward) * quaternion2;
						point = this.position - (this.shoulder.solverPosition + this.chestRotation * (isLeft ? Vector3.right : Vector3.left) * base.mag);
						vector4 = Quaternion.Inverse(quaternion2) * point;
						float num8 = Mathf.Atan2(vector4.y, vector4.z) * 57.29578f;
						num8 -= this.shoulderPitchOffset;
						num8 = this.DamperValue(num8, -45f - this.shoulderPitchOffset, 45f - this.shoulderPitchOffset, 1f);
						Quaternion quaternion3 = Quaternion.AngleAxis(-num8, quaternion2 * Vector3.right) * rhs;
						if (this.shoulderRotationWeight * this.positionWeight < 1f)
						{
							quaternion3 = Quaternion.Lerp(Quaternion.identity, quaternion3, this.shoulderRotationWeight * this.positionWeight);
						}
						IKSolverVR.VirtualBone.RotateBy(this.bones, quaternion3);
						this.Stretching();
						vector = this.GetBendNormal(this.position - this.upperArm.solverPosition);
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 1, 2, 3, this.position, vector, this.positionWeight);
						float angle = Mathf.Clamp(num8 * this.positionWeight * this.shoulderRotationWeight * this.shoulderTwistWeight * 2f, 0f, 180f);
						this.shoulder.solverRotation = Quaternion.AngleAxis(angle, this.shoulder.solverRotation * (isLeft ? this.shoulder.axis : (-this.shoulder.axis))) * this.shoulder.solverRotation;
						this.upperArm.solverRotation = Quaternion.AngleAxis(angle, this.upperArm.solverRotation * (isLeft ? this.upperArm.axis : (-this.upperArm.axis))) * this.upperArm.solverRotation;
					}
				}
				else
				{
					if (this.LOD < 1)
					{
						this.Stretching();
					}
					vector = this.GetBendNormal(this.position - this.upperArm.solverPosition);
					if (this.hasShoulder)
					{
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 1, 2, 3, this.position, vector, this.positionWeight);
					}
					else
					{
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 0, 1, 2, this.position, vector, this.positionWeight);
					}
				}
				if (this.LOD < 1 && this.positionWeight > 0f)
				{
					Vector3 vector5 = Quaternion.Inverse(Quaternion.LookRotation(this.upperArm.solverRotation * this.upperArmBendAxis, this.forearm.solverPosition - this.upperArm.solverPosition)) * vector;
					float num9 = Mathf.Atan2(vector5.x, vector5.z) * 57.29578f;
					this.upperArm.solverRotation = Quaternion.AngleAxis(num9 * this.positionWeight, this.forearm.solverPosition - this.upperArm.solverPosition) * this.upperArm.solverRotation;
					Quaternion quaternion4 = this.upperArm.solverRotation * this.forearmRelToUpperArm;
					Quaternion lhs = Quaternion.FromToRotation(quaternion4 * this.forearm.axis, this.hand.solverPosition - this.forearm.solverPosition);
					base.RotateTo(this.forearm, lhs * quaternion4, this.positionWeight);
				}
				if (this.rotationWeight >= 1f)
				{
					this.hand.solverRotation = this.rotation;
					return;
				}
				if (this.rotationWeight > 0f)
				{
					this.hand.solverRotation = Quaternion.Lerp(this.hand.solverRotation, this.rotation, this.rotationWeight);
				}
			}

			// Token: 0x0600078A RID: 1930 RVA: 0x000301F5 File Offset: 0x0002E3F5
			public override void ResetOffsets()
			{
				this.handPositionOffset = Vector3.zero;
			}

			// Token: 0x0600078B RID: 1931 RVA: 0x00030204 File Offset: 0x0002E404
			public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
			{
				if (this.hasShoulder)
				{
					solvedPositions[this.index] = this.shoulder.solverPosition;
					solvedRotations[this.index] = this.shoulder.solverRotation;
				}
				solvedPositions[this.index + 1] = this.upperArm.solverPosition;
				solvedPositions[this.index + 2] = this.forearm.solverPosition;
				solvedPositions[this.index + 3] = this.hand.solverPosition;
				solvedRotations[this.index + 1] = this.upperArm.solverRotation;
				solvedRotations[this.index + 2] = this.forearm.solverRotation;
				solvedRotations[this.index + 3] = this.hand.solverRotation;
			}

			// Token: 0x0600078C RID: 1932 RVA: 0x000302E8 File Offset: 0x0002E4E8
			private float DamperValue(float value, float min, float max, float weight = 1f)
			{
				float num = max - min;
				if (weight < 1f)
				{
					float num2 = max - num * 0.5f;
					float num3 = value - num2;
					num3 *= 0.5f;
					value = num2 + num3;
				}
				value -= min;
				float t = Interp.Float(Mathf.Clamp(value / num, 0f, 1f), InterpolationMode.InOutQuintic);
				return Mathf.Lerp(min, max, t);
			}

			// Token: 0x0600078D RID: 1933 RVA: 0x00030344 File Offset: 0x0002E544
			private Vector3 GetBendNormal(Vector3 dir)
			{
				if (this.bendGoal != null)
				{
					this.bendDirection = this.bendGoal.position - this.bones[1].solverPosition;
				}
				Vector3 vector = this.bones[0].solverRotation * this.bones[0].axis;
				Vector3 down = Vector3.down;
				Vector3 toDirection = Quaternion.Inverse(this.chestRotation) * dir.normalized + Vector3.forward;
				Vector3 vector2 = Quaternion.FromToRotation(down, toDirection) * Vector3.back;
				Vector3 fromDirection = Quaternion.Inverse(this.chestRotation) * vector;
				toDirection = Quaternion.Inverse(this.chestRotation) * dir;
				vector2 = Quaternion.FromToRotation(fromDirection, toDirection) * vector2;
				vector2 = this.chestRotation * vector2;
				vector2 += vector;
				vector2 -= this.rotation * this.wristToPalmAxis;
				vector2 -= this.rotation * this.palmToThumbAxis * 0.5f;
				if (this.bendGoalWeight > 0f)
				{
					vector2 = Vector3.Slerp(vector2, this.bendDirection, this.bendGoalWeight);
				}
				if (this.swivelOffset != 0f)
				{
					vector2 = Quaternion.AngleAxis(this.swivelOffset, -dir) * vector2;
				}
				return Vector3.Cross(vector2, dir);
			}

			// Token: 0x0600078E RID: 1934 RVA: 0x000304A5 File Offset: 0x0002E6A5
			private void Visualize(IKSolverVR.VirtualBone bone1, IKSolverVR.VirtualBone bone2, IKSolverVR.VirtualBone bone3, Color color)
			{
				Debug.DrawLine(bone1.solverPosition, bone2.solverPosition, color);
				Debug.DrawLine(bone2.solverPosition, bone3.solverPosition, color);
			}

			// Token: 0x0400067E RID: 1662
			[LargeHeader("Hand")]
			[Tooltip("The hand target. This should not be the hand controller itself, but a child GameObject parented to it so you could adjust its position/rotation to match the orientation of the hand bone. The best practice for setup would be to move the hand controller to the avatar's hand as it it was held by the avatar, duplicate the avatar's hand bone and parent it to the hand controller. Then assign the duplicate to this slot.")]
			public Transform target;

			// Token: 0x0400067F RID: 1663
			[Tooltip("Positional weight of the hand target. Note that if you have nulled the target, the hand will still be pulled to the last position of the target until you set this value to 0.")]
			[Range(0f, 1f)]
			public float positionWeight = 1f;

			// Token: 0x04000680 RID: 1664
			[Tooltip("Rotational weight of the hand target. Note that if you have nulled the target, the hand will still be rotated to the last rotation of the target until you set this value to 0.")]
			[Range(0f, 1f)]
			public float rotationWeight = 1f;

			// Token: 0x04000681 RID: 1665
			[LargeHeader("Shoulder")]
			[Tooltip("The weight of shoulder rotation")]
			[Range(0f, 1f)]
			public float shoulderRotationWeight = 1f;

			// Token: 0x04000682 RID: 1666
			[Tooltip("Different techniques for shoulder bone rotation.")]
			[ShowIf("shoulderRotationWeight", 0f, float.PositiveInfinity, false, ShowIfMode.Hidden)]
			public IKSolverVR.Arm.ShoulderRotationMode shoulderRotationMode;

			// Token: 0x04000683 RID: 1667
			[Tooltip("The weight of twisting the shoulders backwards when arms are lifted up.")]
			[ShowRangeIf(0f, 1f, "shoulderRotationWeight", 0f, float.PositiveInfinity, false, ShowIfMode.Hidden)]
			public float shoulderTwistWeight = 1f;

			// Token: 0x04000684 RID: 1668
			[Tooltip("Tweak this value to adjust shoulder rotation around the yaw (up) axis.")]
			[ShowIf("shoulderRotationWeight", 0f, float.PositiveInfinity, false, ShowIfMode.Hidden)]
			public float shoulderYawOffset = 45f;

			// Token: 0x04000685 RID: 1669
			[Tooltip("Tweak this value to adjust shoulder rotation around the pitch (forward) axis.")]
			[ShowIf("shoulderRotationWeight", 0f, float.PositiveInfinity, false, ShowIfMode.Hidden)]
			public float shoulderPitchOffset = -30f;

			// Token: 0x04000686 RID: 1670
			[LargeHeader("Bending")]
			[Tooltip("The elbow will be bent towards this Transform if 'Bend Goal Weight' > 0.")]
			public Transform bendGoal;

			// Token: 0x04000687 RID: 1671
			[Tooltip("If greater than 0, will bend the elbow towards the 'Bend Goal' Transform.")]
			[Range(0f, 1f)]
			public float bendGoalWeight;

			// Token: 0x04000688 RID: 1672
			[Tooltip("Angular offset of the elbow bending direction.")]
			[Range(-180f, 180f)]
			public float swivelOffset;

			// Token: 0x04000689 RID: 1673
			[Tooltip("Local axis of the hand bone that points from the wrist towards the palm. Used for defining hand bone orientation. If you have copied VRIK component from another avatar that has different bone orientations, right-click on VRIK header and select 'Guess Hand Orientations' from the context menu.")]
			public Vector3 wristToPalmAxis = Vector3.zero;

			// Token: 0x0400068A RID: 1674
			[Tooltip("Local axis of the hand bone that points from the palm towards the thumb. Used for defining hand bone orientation. If you have copied VRIK component from another avatar that has different bone orientations, right-click on VRIK header and select 'Guess Hand Orientations' from the context menu.")]
			public Vector3 palmToThumbAxis = Vector3.zero;

			// Token: 0x0400068B RID: 1675
			[LargeHeader("Stretching")]
			[Tooltip("Use this to make the arm shorter/longer. Works by displacement of hand and forearm localPosition.")]
			[Range(0.01f, 2f)]
			public float armLengthMlp = 1f;

			// Token: 0x0400068C RID: 1676
			[Tooltip("'Time' represents (target distance / arm length) and 'value' represents the amount of stretching. So value at time 1 represents stretching amount at the point where distance to the target is equal to arm length. Value at time 2 represents stretching amount at the point where distance to the target is double the arm length. Linear stretching would be achieved with a linear curve going up by 45 degrees. Increase the range of stretching by moving the last key up and right by the same amount. Smoothing in the curve can help reduce elbow snapping (start stretching the arm slightly before target distance reaches arm length). To get a good optimal value for this curve, please go to the 'VRIK (Basic)' demo scene and copy the stretch curve over from the Pilot character.")]
			public AnimationCurve stretchCurve = new AnimationCurve();

			// Token: 0x0400068D RID: 1677
			[HideInInspector]
			[NonSerialized]
			public Vector3 IKPosition;

			// Token: 0x0400068E RID: 1678
			[HideInInspector]
			[NonSerialized]
			public Quaternion IKRotation = Quaternion.identity;

			// Token: 0x0400068F RID: 1679
			[HideInInspector]
			[NonSerialized]
			public Vector3 bendDirection = Vector3.back;

			// Token: 0x04000690 RID: 1680
			[HideInInspector]
			[NonSerialized]
			public Vector3 handPositionOffset;

			// Token: 0x04000693 RID: 1683
			private bool hasShoulder;

			// Token: 0x04000694 RID: 1684
			private Vector3 chestForwardAxis;

			// Token: 0x04000695 RID: 1685
			private Vector3 chestUpAxis;

			// Token: 0x04000696 RID: 1686
			private Quaternion chestRotation = Quaternion.identity;

			// Token: 0x04000697 RID: 1687
			private Vector3 chestForward;

			// Token: 0x04000698 RID: 1688
			private Vector3 chestUp;

			// Token: 0x04000699 RID: 1689
			private Quaternion forearmRelToUpperArm = Quaternion.identity;

			// Token: 0x0400069A RID: 1690
			private Vector3 upperArmBendAxis;

			// Token: 0x020000E3 RID: 227
			[Serializable]
			public enum ShoulderRotationMode
			{
				// Token: 0x0400069C RID: 1692
				YawPitch,
				// Token: 0x0400069D RID: 1693
				FromTo
			}
		}

		// Token: 0x020000E4 RID: 228
		[Serializable]
		public abstract class BodyPart
		{
			// Token: 0x06000790 RID: 1936
			protected abstract void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index);

			// Token: 0x06000791 RID: 1937
			public abstract void PreSolve(float scale);

			// Token: 0x06000792 RID: 1938
			public abstract void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations);

			// Token: 0x06000793 RID: 1939
			public abstract void ApplyOffsets(float scale);

			// Token: 0x06000794 RID: 1940
			public abstract void ResetOffsets();

			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x06000795 RID: 1941 RVA: 0x0003057D File Offset: 0x0002E77D
			// (set) Token: 0x06000796 RID: 1942 RVA: 0x00030585 File Offset: 0x0002E785
			public float sqrMag { get; private set; }

			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x06000797 RID: 1943 RVA: 0x0003058E File Offset: 0x0002E78E
			// (set) Token: 0x06000798 RID: 1944 RVA: 0x00030596 File Offset: 0x0002E796
			public float mag { get; private set; }

			// Token: 0x06000799 RID: 1945 RVA: 0x0003059F File Offset: 0x0002E79F
			public void SetLOD(int LOD)
			{
				this.LOD = LOD;
			}

			// Token: 0x0600079A RID: 1946 RVA: 0x000305A8 File Offset: 0x0002E7A8
			public void Read(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
				this.index = index;
				this.rootPosition = positions[rootIndex];
				this.rootRotation = rotations[rootIndex];
				this.OnRead(positions, rotations, hasChest, hasNeck, hasShoulders, hasToes, hasLegs, rootIndex, index);
				this.mag = IKSolverVR.VirtualBone.PreSolve(ref this.bones);
				this.sqrMag = this.mag * this.mag;
				this.initiated = true;
			}

			// Token: 0x0600079B RID: 1947 RVA: 0x0003061C File Offset: 0x0002E81C
			public void MovePosition(Vector3 position)
			{
				Vector3 b = position - this.bones[0].solverPosition;
				IKSolverVR.VirtualBone[] array = this.bones;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].solverPosition += b;
				}
			}

			// Token: 0x0600079C RID: 1948 RVA: 0x00030668 File Offset: 0x0002E868
			public void MoveRotation(Quaternion rotation)
			{
				Quaternion rotation2 = QuaTools.FromToRotation(this.bones[0].solverRotation, rotation);
				IKSolverVR.VirtualBone.RotateAroundPoint(this.bones, 0, this.bones[0].solverPosition, rotation2);
			}

			// Token: 0x0600079D RID: 1949 RVA: 0x000306A3 File Offset: 0x0002E8A3
			public void Translate(Vector3 position, Quaternion rotation)
			{
				this.MovePosition(position);
				this.MoveRotation(rotation);
			}

			// Token: 0x0600079E RID: 1950 RVA: 0x000306B4 File Offset: 0x0002E8B4
			public void TranslateRoot(Vector3 newRootPos, Quaternion newRootRot)
			{
				Vector3 b = newRootPos - this.rootPosition;
				this.rootPosition = newRootPos;
				IKSolverVR.VirtualBone[] array = this.bones;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].solverPosition += b;
				}
				Quaternion rotation = QuaTools.FromToRotation(this.rootRotation, newRootRot);
				this.rootRotation = newRootRot;
				IKSolverVR.VirtualBone.RotateAroundPoint(this.bones, 0, newRootPos, rotation);
			}

			// Token: 0x0600079F RID: 1951 RVA: 0x00030720 File Offset: 0x0002E920
			public void RotateTo(IKSolverVR.VirtualBone bone, Quaternion rotation, float weight = 1f)
			{
				if (weight <= 0f)
				{
					return;
				}
				Quaternion quaternion = QuaTools.FromToRotation(bone.solverRotation, rotation);
				if (weight < 1f)
				{
					quaternion = Quaternion.Slerp(Quaternion.identity, quaternion, weight);
				}
				for (int i = 0; i < this.bones.Length; i++)
				{
					if (this.bones[i] == bone)
					{
						IKSolverVR.VirtualBone.RotateAroundPoint(this.bones, i, this.bones[i].solverPosition, quaternion);
						return;
					}
				}
			}

			// Token: 0x060007A0 RID: 1952 RVA: 0x00030794 File Offset: 0x0002E994
			public void Visualize(Color color)
			{
				for (int i = 0; i < this.bones.Length - 1; i++)
				{
					Debug.DrawLine(this.bones[i].solverPosition, this.bones[i + 1].solverPosition, color);
				}
			}

			// Token: 0x060007A1 RID: 1953 RVA: 0x000307D8 File Offset: 0x0002E9D8
			public void Visualize()
			{
				this.Visualize(Color.white);
			}

			// Token: 0x040006A0 RID: 1696
			[HideInInspector]
			public IKSolverVR.VirtualBone[] bones = new IKSolverVR.VirtualBone[0];

			// Token: 0x040006A1 RID: 1697
			protected bool initiated;

			// Token: 0x040006A2 RID: 1698
			protected Vector3 rootPosition;

			// Token: 0x040006A3 RID: 1699
			protected Quaternion rootRotation = Quaternion.identity;

			// Token: 0x040006A4 RID: 1700
			protected int index = -1;

			// Token: 0x040006A5 RID: 1701
			protected int LOD;
		}

		// Token: 0x020000E5 RID: 229
		[Serializable]
		public class Footstep
		{
			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0003080B File Offset: 0x0002EA0B
			public bool isStepping
			{
				get
				{
					return this.stepProgress < 1f;
				}
			}

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0003081A File Offset: 0x0002EA1A
			// (set) Token: 0x060007A5 RID: 1957 RVA: 0x00030822 File Offset: 0x0002EA22
			public float stepProgress { get; private set; }

			// Token: 0x060007A6 RID: 1958 RVA: 0x0003082C File Offset: 0x0002EA2C
			public Footstep(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation, Vector3 characterSpaceOffset)
			{
				this.characterSpaceOffset = characterSpaceOffset;
				this.Reset(rootRotation, footPosition, footRotation);
				this.footRelativeToRoot = Quaternion.Inverse(rootRotation) * this.rotation;
			}

			// Token: 0x060007A7 RID: 1959 RVA: 0x000308AC File Offset: 0x0002EAAC
			public void Reset(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation)
			{
				this.position = footPosition;
				this.rotation = footRotation;
				this.stepFrom = this.position;
				this.stepTo = this.position;
				this.stepFromRot = this.rotation;
				this.stepToRot = this.rotation;
				this.stepToRootRot = rootRotation;
				this.stepProgress = 1f;
			}

			// Token: 0x060007A8 RID: 1960 RVA: 0x0003090C File Offset: 0x0002EB0C
			public void StepTo(Vector3 p, Quaternion rootRotation, float stepThreshold)
			{
				if (this.relaxFlag)
				{
					stepThreshold = 0f;
					this.relaxFlag = false;
				}
				if (Vector3.Magnitude(p - this.stepTo) < stepThreshold && Quaternion.Angle(rootRotation, this.stepToRootRot) < 25f)
				{
					return;
				}
				this.stepFrom = this.position;
				this.stepTo = p;
				this.stepFromRot = this.rotation;
				this.stepToRootRot = rootRotation;
				this.stepToRot = rootRotation * this.footRelativeToRoot;
				this.stepProgress = 0f;
			}

			// Token: 0x060007A9 RID: 1961 RVA: 0x0003099C File Offset: 0x0002EB9C
			public void UpdateStepping(Vector3 p, Quaternion rootRotation, float speed, float deltaTime)
			{
				this.stepTo = Vector3.Lerp(this.stepTo, p, deltaTime * speed);
				this.stepToRot = Quaternion.Lerp(this.stepToRot, rootRotation * this.footRelativeToRoot, deltaTime * speed);
				this.stepToRootRot = this.stepToRot * Quaternion.Inverse(this.footRelativeToRoot);
			}

			// Token: 0x060007AA RID: 1962 RVA: 0x000309FC File Offset: 0x0002EBFC
			public void UpdateStanding(Quaternion rootRotation, float minAngle, float speed, float deltaTime)
			{
				if (speed <= 0f || minAngle >= 180f)
				{
					return;
				}
				Quaternion quaternion = rootRotation * this.footRelativeToRoot;
				float num = Quaternion.Angle(this.rotation, quaternion);
				if (num > minAngle)
				{
					this.rotation = Quaternion.RotateTowards(this.rotation, quaternion, Mathf.Min(deltaTime * speed * (1f - this.supportLegW), num - minAngle));
				}
			}

			// Token: 0x060007AB RID: 1963 RVA: 0x00030A64 File Offset: 0x0002EC64
			public void Update(InterpolationMode interpolation, UnityEvent onStep, float deltaTime)
			{
				float target = this.isSupportLeg ? 1f : 0f;
				this.supportLegW = Mathf.SmoothDamp(this.supportLegW, target, ref this.supportLegWV, 0.2f);
				if (!this.isStepping)
				{
					return;
				}
				this.stepProgress = Mathf.MoveTowards(this.stepProgress, 1f, deltaTime * this.stepSpeed);
				if (this.stepProgress >= 1f)
				{
					onStep.Invoke();
				}
				float t = Interp.Float(this.stepProgress, interpolation);
				this.position = Vector3.Lerp(this.stepFrom, this.stepTo, t);
				this.rotation = Quaternion.Lerp(this.stepFromRot, this.stepToRot, t);
			}

			// Token: 0x040006A6 RID: 1702
			public float stepSpeed = 3f;

			// Token: 0x040006A7 RID: 1703
			public Vector3 characterSpaceOffset;

			// Token: 0x040006A8 RID: 1704
			public Vector3 position;

			// Token: 0x040006A9 RID: 1705
			public Quaternion rotation = Quaternion.identity;

			// Token: 0x040006AA RID: 1706
			public Quaternion stepToRootRot = Quaternion.identity;

			// Token: 0x040006AB RID: 1707
			public bool isSupportLeg;

			// Token: 0x040006AC RID: 1708
			public bool relaxFlag;

			// Token: 0x040006AE RID: 1710
			public Vector3 stepFrom;

			// Token: 0x040006AF RID: 1711
			public Vector3 stepTo;

			// Token: 0x040006B0 RID: 1712
			public Quaternion stepFromRot = Quaternion.identity;

			// Token: 0x040006B1 RID: 1713
			public Quaternion stepToRot = Quaternion.identity;

			// Token: 0x040006B2 RID: 1714
			private Quaternion footRelativeToRoot = Quaternion.identity;

			// Token: 0x040006B3 RID: 1715
			private float supportLegW;

			// Token: 0x040006B4 RID: 1716
			private float supportLegWV;
		}

		// Token: 0x020000E6 RID: 230
		[Serializable]
		public class Leg : IKSolverVR.BodyPart
		{
			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x060007AC RID: 1964 RVA: 0x00030B1A File Offset: 0x0002ED1A
			// (set) Token: 0x060007AD RID: 1965 RVA: 0x00030B22 File Offset: 0x0002ED22
			public Vector3 position { get; private set; }

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x060007AE RID: 1966 RVA: 0x00030B2B File Offset: 0x0002ED2B
			// (set) Token: 0x060007AF RID: 1967 RVA: 0x00030B33 File Offset: 0x0002ED33
			public Quaternion rotation { get; private set; }

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x060007B0 RID: 1968 RVA: 0x00030B3C File Offset: 0x0002ED3C
			// (set) Token: 0x060007B1 RID: 1969 RVA: 0x00030B44 File Offset: 0x0002ED44
			public bool hasToes { get; private set; }

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0002F455 File Offset: 0x0002D655
			public IKSolverVR.VirtualBone thigh
			{
				get
				{
					return this.bones[0];
				}
			}

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00030B4D File Offset: 0x0002ED4D
			private IKSolverVR.VirtualBone calf
			{
				get
				{
					return this.bones[1];
				}
			}

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x060007B4 RID: 1972 RVA: 0x00030B57 File Offset: 0x0002ED57
			private IKSolverVR.VirtualBone foot
			{
				get
				{
					return this.bones[2];
				}
			}

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x060007B5 RID: 1973 RVA: 0x00030B61 File Offset: 0x0002ED61
			private IKSolverVR.VirtualBone toes
			{
				get
				{
					return this.bones[3];
				}
			}

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x060007B6 RID: 1974 RVA: 0x00030B6B File Offset: 0x0002ED6B
			public IKSolverVR.VirtualBone lastBone
			{
				get
				{
					return this.bones[this.bones.Length - 1];
				}
			}

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x060007B7 RID: 1975 RVA: 0x00030B7E File Offset: 0x0002ED7E
			// (set) Token: 0x060007B8 RID: 1976 RVA: 0x00030B86 File Offset: 0x0002ED86
			public Vector3 thighRelativeToPelvis { get; private set; }

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x060007B9 RID: 1977 RVA: 0x00030B8F File Offset: 0x0002ED8F
			// (set) Token: 0x060007BA RID: 1978 RVA: 0x00030B97 File Offset: 0x0002ED97
			public Vector3 bendNormalRelToPelvis { get; set; }

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x060007BB RID: 1979 RVA: 0x00030BA0 File Offset: 0x0002EDA0
			// (set) Token: 0x060007BC RID: 1980 RVA: 0x00030BA8 File Offset: 0x0002EDA8
			public Vector3 bendNormalRelToTarget { get; set; }

			// Token: 0x060007BD RID: 1981 RVA: 0x00030BB4 File Offset: 0x0002EDB4
			protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
				Vector3 vector = positions[index];
				Quaternion rotation = rotations[index];
				Vector3 vector2 = positions[index + 1];
				Quaternion rotation2 = rotations[index + 1];
				Vector3 vector3 = positions[index + 2];
				Quaternion quaternion = rotations[index + 2];
				Vector3 vector4 = positions[index + 3];
				Quaternion quaternion2 = rotations[index + 3];
				if (!this.initiated)
				{
					this.hasToes = hasToes;
					this.bones = new IKSolverVR.VirtualBone[hasToes ? 4 : 3];
					if (hasToes)
					{
						this.bones[0] = new IKSolverVR.VirtualBone(vector, rotation);
						this.bones[1] = new IKSolverVR.VirtualBone(vector2, rotation2);
						this.bones[2] = new IKSolverVR.VirtualBone(vector3, quaternion);
						this.bones[3] = new IKSolverVR.VirtualBone(vector4, quaternion2);
						this.IKPosition = vector4;
						this.IKRotation = quaternion2;
					}
					else
					{
						this.bones[0] = new IKSolverVR.VirtualBone(vector, rotation);
						this.bones[1] = new IKSolverVR.VirtualBone(vector2, rotation2);
						this.bones[2] = new IKSolverVR.VirtualBone(vector3, quaternion);
						this.IKPosition = vector3;
						this.IKRotation = quaternion;
					}
					this.bendNormal = Vector3.Cross(vector2 - vector, vector3 - vector2);
					this.bendNormalRelToPelvis = Quaternion.Inverse(this.rootRotation) * this.bendNormal;
					this.bendNormalRelToTarget = Quaternion.Inverse(this.IKRotation) * this.bendNormal;
					this.rotation = this.IKRotation;
				}
				if (hasToes)
				{
					this.bones[0].Read(vector, rotation);
					this.bones[1].Read(vector2, rotation2);
					this.bones[2].Read(vector3, quaternion);
					this.bones[3].Read(vector4, quaternion2);
					return;
				}
				this.bones[0].Read(vector, rotation);
				this.bones[1].Read(vector2, rotation2);
				this.bones[2].Read(vector3, quaternion);
			}

			// Token: 0x060007BE RID: 1982 RVA: 0x00030DA8 File Offset: 0x0002EFA8
			public override void PreSolve(float scale)
			{
				if (this.target != null)
				{
					this.IKPosition = this.target.position;
					this.IKRotation = this.target.rotation;
				}
				this.footPosition = this.foot.solverPosition;
				this.footRotation = this.foot.solverRotation;
				this.position = this.lastBone.solverPosition;
				this.rotation = this.lastBone.solverRotation;
				if (this.rotationWeight > 0f)
				{
					this.ApplyRotationOffset(QuaTools.FromToRotation(this.rotation, this.IKRotation), this.rotationWeight);
				}
				if (this.positionWeight > 0f)
				{
					this.ApplyPositionOffset(this.IKPosition - this.position, this.positionWeight);
				}
				this.thighRelativeToPelvis = Quaternion.Inverse(this.rootRotation) * (this.thigh.solverPosition - this.rootPosition);
				this.calfRelToThigh = Quaternion.Inverse(this.thigh.solverRotation) * this.calf.solverRotation;
				this.thighRelToFoot = Quaternion.Inverse(this.lastBone.solverRotation) * this.thigh.solverRotation;
				if (this.useAnimatedBendNormal)
				{
					this.bendNormal = Vector3.Cross(this.calf.solverPosition - this.thigh.solverPosition, this.foot.solverPosition - this.calf.solverPosition);
				}
				else if (this.bendToTargetWeight <= 0f)
				{
					this.bendNormal = this.rootRotation * this.bendNormalRelToPelvis;
				}
				else if (this.bendToTargetWeight >= 1f)
				{
					this.bendNormal = this.rotation * this.bendNormalRelToTarget;
				}
				else
				{
					this.bendNormal = Vector3.Slerp(this.rootRotation * this.bendNormalRelToPelvis, this.rotation * this.bendNormalRelToTarget, this.bendToTargetWeight);
				}
				this.bendNormal = this.bendNormal.normalized;
			}

			// Token: 0x060007BF RID: 1983 RVA: 0x00030FD0 File Offset: 0x0002F1D0
			public override void ApplyOffsets(float scale)
			{
				this.ApplyPositionOffset(this.footPositionOffset, 1f);
				this.ApplyRotationOffset(this.footRotationOffset, 1f);
				Quaternion quaternion = Quaternion.FromToRotation(this.footPosition - this.position, this.footPosition + this.heelPositionOffset - this.position);
				this.footPosition = this.position + quaternion * (this.footPosition - this.position);
				this.footRotation = quaternion * this.footRotation;
				float num = 0f;
				if (this.bendGoal != null && this.bendGoalWeight > 0f)
				{
					Vector3 point = Vector3.Cross(this.bendGoal.position - this.thigh.solverPosition, this.position - this.thigh.solverPosition);
					Vector3 vector = Quaternion.Inverse(Quaternion.LookRotation(this.bendNormal, this.thigh.solverPosition - this.foot.solverPosition)) * point;
					num = Mathf.Atan2(vector.x, vector.z) * 57.29578f * this.bendGoalWeight;
				}
				float num2 = this.swivelOffset + num;
				if (num2 != 0f)
				{
					this.bendNormal = Quaternion.AngleAxis(num2, this.thigh.solverPosition - this.lastBone.solverPosition) * this.bendNormal;
					this.thigh.solverRotation = Quaternion.AngleAxis(-num2, this.thigh.solverRotation * this.thigh.axis) * this.thigh.solverRotation;
				}
			}

			// Token: 0x060007C0 RID: 1984 RVA: 0x0003119E File Offset: 0x0002F39E
			private void ApplyPositionOffset(Vector3 offset, float weight)
			{
				if (weight <= 0f)
				{
					return;
				}
				offset *= weight;
				this.footPosition += offset;
				this.position += offset;
			}

			// Token: 0x060007C1 RID: 1985 RVA: 0x000311D8 File Offset: 0x0002F3D8
			private void ApplyRotationOffset(Quaternion offset, float weight)
			{
				if (weight <= 0f)
				{
					return;
				}
				if (weight < 1f)
				{
					offset = Quaternion.Lerp(Quaternion.identity, offset, weight);
				}
				this.footRotation = offset * this.footRotation;
				this.rotation = offset * this.rotation;
				this.bendNormal = offset * this.bendNormal;
				this.footPosition = this.position + offset * (this.footPosition - this.position);
			}

			// Token: 0x060007C2 RID: 1986 RVA: 0x00031264 File Offset: 0x0002F464
			public void Solve(bool stretch)
			{
				if (stretch && this.LOD < 1)
				{
					this.Stretching();
				}
				IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 0, 1, 2, this.footPosition, this.bendNormal, 1f);
				base.RotateTo(this.foot, this.footRotation, 1f);
				if (!this.hasToes)
				{
					this.FixTwistRotations();
					return;
				}
				Vector3 normalized = Vector3.Cross(this.foot.solverPosition - this.thigh.solverPosition, this.toes.solverPosition - this.foot.solverPosition).normalized;
				IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, 0, 2, 3, this.position, normalized, 1f);
				this.FixTwistRotations();
				this.toes.solverRotation = this.rotation;
			}

			// Token: 0x060007C3 RID: 1987 RVA: 0x00031340 File Offset: 0x0002F540
			private void FixTwistRotations()
			{
				if (this.LOD < 1)
				{
					if (this.bendToTargetWeight > 0f)
					{
						Quaternion quaternion = this.rotation * this.thighRelToFoot;
						Quaternion lhs = Quaternion.FromToRotation(quaternion * this.thigh.axis, this.calf.solverPosition - this.thigh.solverPosition);
						if (this.bendToTargetWeight < 1f)
						{
							this.thigh.solverRotation = Quaternion.Slerp(this.thigh.solverRotation, lhs * quaternion, this.bendToTargetWeight);
						}
						else
						{
							this.thigh.solverRotation = lhs * quaternion;
						}
					}
					Quaternion quaternion2 = this.thigh.solverRotation * this.calfRelToThigh;
					Quaternion lhs2 = Quaternion.FromToRotation(quaternion2 * this.calf.axis, this.foot.solverPosition - this.calf.solverPosition);
					this.calf.solverRotation = lhs2 * quaternion2;
				}
			}

			// Token: 0x060007C4 RID: 1988 RVA: 0x00031454 File Offset: 0x0002F654
			private void Stretching()
			{
				float num = this.thigh.length + this.calf.length;
				Vector3 vector = Vector3.zero;
				Vector3 b = Vector3.zero;
				if (this.legLengthMlp != 1f)
				{
					num *= this.legLengthMlp;
					vector = (this.calf.solverPosition - this.thigh.solverPosition) * (this.legLengthMlp - 1f);
					b = (this.foot.solverPosition - this.calf.solverPosition) * (this.legLengthMlp - 1f);
					this.calf.solverPosition += vector;
					this.foot.solverPosition += vector + b;
					if (this.hasToes)
					{
						this.toes.solverPosition += vector + b;
					}
				}
				float time = Vector3.Distance(this.thigh.solverPosition, this.footPosition) / num;
				float d = this.stretchCurve.Evaluate(time);
				vector = (this.calf.solverPosition - this.thigh.solverPosition) * d;
				b = (this.foot.solverPosition - this.calf.solverPosition) * d;
				this.calf.solverPosition += vector;
				this.foot.solverPosition += vector + b;
				if (this.hasToes)
				{
					this.toes.solverPosition += vector + b;
				}
			}

			// Token: 0x060007C5 RID: 1989 RVA: 0x00031618 File Offset: 0x0002F818
			public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
			{
				solvedRotations[this.index] = this.thigh.solverRotation;
				solvedRotations[this.index + 1] = this.calf.solverRotation;
				solvedRotations[this.index + 2] = this.foot.solverRotation;
				solvedPositions[this.index] = this.thigh.solverPosition;
				solvedPositions[this.index + 1] = this.calf.solverPosition;
				solvedPositions[this.index + 2] = this.foot.solverPosition;
				if (this.hasToes)
				{
					solvedRotations[this.index + 3] = this.toes.solverRotation;
					solvedPositions[this.index + 3] = this.toes.solverPosition;
				}
			}

			// Token: 0x060007C6 RID: 1990 RVA: 0x000316F9 File Offset: 0x0002F8F9
			public override void ResetOffsets()
			{
				this.footPositionOffset = Vector3.zero;
				this.footRotationOffset = Quaternion.identity;
				this.heelPositionOffset = Vector3.zero;
			}

			// Token: 0x040006B5 RID: 1717
			[LargeHeader("Foot/Toe")]
			[Tooltip("The foot/toe target. This should not be the foot tracker itself, but a child GameObject parented to it so you could adjust its position/rotation to match the orientation of the foot/toe bone. If a toe bone is assigned in the References, the solver will match the toe bone to this target. If no toe bone assigned, foot bone will be used instead.")]
			public Transform target;

			// Token: 0x040006B6 RID: 1718
			[Tooltip("Positional weight of the toe/foot target. Note that if you have nulled the target, the foot will still be pulled to the last position of the target until you set this value to 0.")]
			[Range(0f, 1f)]
			public float positionWeight;

			// Token: 0x040006B7 RID: 1719
			[Tooltip("Rotational weight of the toe/foot target. Note that if you have nulled the target, the foot will still be rotated to the last rotation of the target until you set this value to 0.")]
			[Range(0f, 1f)]
			public float rotationWeight;

			// Token: 0x040006B8 RID: 1720
			[LargeHeader("Bending")]
			[Tooltip("The knee will be bent towards this Transform if 'Bend Goal Weight' > 0.")]
			public Transform bendGoal;

			// Token: 0x040006B9 RID: 1721
			[Tooltip("If greater than 0, will bend the knee towards the 'Bend Goal' Transform.")]
			[Range(0f, 1f)]
			public float bendGoalWeight;

			// Token: 0x040006BA RID: 1722
			[Tooltip("Angular offset of knee bending direction.")]
			[Range(-180f, 180f)]
			public float swivelOffset;

			// Token: 0x040006BB RID: 1723
			[Tooltip("If 0, the bend plane will be locked to the rotation of the pelvis and rotating the foot will have no effect on the knee direction. If 1, to the target rotation of the leg so that the knee will bend towards the forward axis of the foot. Values in between will be slerped between the two.")]
			[Range(0f, 1f)]
			public float bendToTargetWeight = 0.5f;

			// Token: 0x040006BC RID: 1724
			[LargeHeader("Stretching")]
			[Tooltip("Use this to make the leg shorter/longer. Works by displacement of foot and calf localPosition.")]
			[Range(0.01f, 2f)]
			public float legLengthMlp = 1f;

			// Token: 0x040006BD RID: 1725
			[Tooltip("Evaluates stretching of the leg by target distance relative to leg length. Value at time 1 represents stretching amount at the point where distance to the target is equal to leg length. Value at time 1 represents stretching amount at the point where distance to the target is double the leg length. Value represents the amount of stretching. Linear stretching would be achieved with a linear curve going up by 45 degrees. Increase the range of stretching by moving the last key up and right at the same amount. Smoothing in the curve can help reduce knee snapping (start stretching the arm slightly before target distance reaches leg length). To get a good optimal value for this curve, please go to the 'VRIK (Basic)' demo scene and copy the stretch curve over from the Pilot character.")]
			public AnimationCurve stretchCurve = new AnimationCurve();

			// Token: 0x040006BE RID: 1726
			[HideInInspector]
			[NonSerialized]
			public Vector3 IKPosition;

			// Token: 0x040006BF RID: 1727
			[HideInInspector]
			[NonSerialized]
			public Quaternion IKRotation = Quaternion.identity;

			// Token: 0x040006C0 RID: 1728
			[HideInInspector]
			[NonSerialized]
			public Vector3 footPositionOffset;

			// Token: 0x040006C1 RID: 1729
			[HideInInspector]
			[NonSerialized]
			public Vector3 heelPositionOffset;

			// Token: 0x040006C2 RID: 1730
			[HideInInspector]
			[NonSerialized]
			public Quaternion footRotationOffset = Quaternion.identity;

			// Token: 0x040006C3 RID: 1731
			[HideInInspector]
			[NonSerialized]
			public float currentMag;

			// Token: 0x040006C4 RID: 1732
			[HideInInspector]
			public bool useAnimatedBendNormal;

			// Token: 0x040006C9 RID: 1737
			private Vector3 footPosition;

			// Token: 0x040006CA RID: 1738
			private Quaternion footRotation = Quaternion.identity;

			// Token: 0x040006CB RID: 1739
			private Vector3 bendNormal;

			// Token: 0x040006CC RID: 1740
			private Quaternion calfRelToThigh = Quaternion.identity;

			// Token: 0x040006CD RID: 1741
			private Quaternion thighRelToFoot = Quaternion.identity;
		}

		// Token: 0x020000E7 RID: 231
		[Serializable]
		public class Locomotion
		{
			// Token: 0x060007C8 RID: 1992 RVA: 0x00031787 File Offset: 0x0002F987
			public void Initiate(Animator animator, Vector3[] positions, Quaternion[] rotations, bool hasToes, float scale)
			{
				this.Initiate_Procedural(positions, rotations, hasToes, scale);
				this.Initiate_Animated(animator, positions);
			}

			// Token: 0x060007C9 RID: 1993 RVA: 0x0003179D File Offset: 0x0002F99D
			public void Reset(Vector3[] positions, Quaternion[] rotations)
			{
				this.Reset_Procedural(positions, rotations);
				this.Reset_Animated(positions);
			}

			// Token: 0x060007CA RID: 1994 RVA: 0x000317AE File Offset: 0x0002F9AE
			public void Relax()
			{
				this.Relax_Procedural();
			}

			// Token: 0x060007CB RID: 1995 RVA: 0x000317B6 File Offset: 0x0002F9B6
			public void AddDeltaRotation(Quaternion delta, Vector3 pivot)
			{
				this.AddDeltaRotation_Procedural(delta, pivot);
				this.AddDeltaRotation_Animated(delta, pivot);
			}

			// Token: 0x060007CC RID: 1996 RVA: 0x000317C8 File Offset: 0x0002F9C8
			public void AddDeltaPosition(Vector3 delta)
			{
				this.AddDeltaPosition_Procedural(delta);
				this.AddDeltaPosition_Animated(delta);
			}

			// Token: 0x060007CD RID: 1997 RVA: 0x000317D8 File Offset: 0x0002F9D8
			public void Initiate_Animated(Animator animator, Vector3[] positions)
			{
				this.animator = animator;
				if (animator == null && this.mode == IKSolverVR.Locomotion.Mode.Animated)
				{
					Debug.LogError("VRIK is in Animated locomotion mode, but cannot find Animator on the VRIK root gameobject.");
				}
				this.ResetParams(positions);
			}

			// Token: 0x060007CE RID: 1998 RVA: 0x00031804 File Offset: 0x0002FA04
			private void ResetParams(Vector3[] positions)
			{
				this.lastHeadTargetPos = positions[5];
				this.lastSpeedRootPos = positions[0];
				this.lastEndRootPos = this.lastSpeedRootPos;
				this.lastCorrection = Vector3.zero;
				this.isMoving = false;
				this.currentAnimationSmoothTime = 0.05f;
				this.stopMoveTimer = 1f;
			}

			// Token: 0x060007CF RID: 1999 RVA: 0x00031860 File Offset: 0x0002FA60
			public void Reset_Animated(Vector3[] positions)
			{
				this.ResetParams(positions);
				if (this.animator == null)
				{
					return;
				}
				if (!IKSolverVR.Locomotion.isHashed)
				{
					IKSolverVR.Locomotion.VRIK_Horizontal = Animator.StringToHash("VRIK_Horizontal");
					IKSolverVR.Locomotion.VRIK_Vertical = Animator.StringToHash("VRIK_Vertical");
					IKSolverVR.Locomotion.VRIK_IsMoving = Animator.StringToHash("VRIK_IsMoving");
					IKSolverVR.Locomotion.VRIK_Speed = Animator.StringToHash("VRIK_Speed");
					IKSolverVR.Locomotion.VRIK_Turn = Animator.StringToHash("VRIK_Turn");
					IKSolverVR.Locomotion.isHashed = true;
				}
				if (!this.firstFrame)
				{
					this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Horizontal, 0f);
					this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Vertical, 0f);
					this.animator.SetBool(IKSolverVR.Locomotion.VRIK_IsMoving, false);
					this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Speed, 1f);
					this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Turn, 0f);
				}
			}

			// Token: 0x060007D0 RID: 2000 RVA: 0x00031948 File Offset: 0x0002FB48
			private void AddDeltaRotation_Animated(Quaternion delta, Vector3 pivot)
			{
				Vector3 point = this.lastEndRootPos - pivot;
				this.lastEndRootPos = pivot + delta * point;
				Vector3 point2 = this.lastSpeedRootPos - pivot;
				this.lastSpeedRootPos = pivot + delta * point2;
				Vector3 point3 = this.lastHeadTargetPos - pivot;
				this.lastHeadTargetPos = pivot + delta * point3;
			}

			// Token: 0x060007D1 RID: 2001 RVA: 0x000319B5 File Offset: 0x0002FBB5
			private void AddDeltaPosition_Animated(Vector3 delta)
			{
				this.lastEndRootPos += delta;
				this.lastSpeedRootPos += delta;
				this.lastHeadTargetPos += delta;
			}

			// Token: 0x060007D2 RID: 2002 RVA: 0x000319F0 File Offset: 0x0002FBF0
			public void Solve_Animated(IKSolverVR solver, float scale, float deltaTime)
			{
				if (this.animator == null)
				{
					Debug.LogError("VRIK cannot find Animator on the VRIK root gameobject.", solver.root);
					return;
				}
				if (deltaTime <= 0f)
				{
					return;
				}
				Vector3 vector = solver.rootBone.solverRotation * Vector3.up;
				Vector3 vector2 = solver.rootBone.solverPosition - this.lastEndRootPos;
				vector2 -= this.animator.deltaPosition;
				Vector3 vector3 = solver.spine.headPosition;
				Vector3 b = solver.rootBone.solverRotation * new Vector3(this.standOffset.x, 0f, this.standOffset.y) * scale;
				vector3 += b;
				if (this.firstFrame)
				{
					this.lastHeadTargetPos = vector3;
					this.firstFrame = false;
				}
				Vector3 vector4 = (vector3 - this.lastHeadTargetPos) / deltaTime;
				this.lastHeadTargetPos = vector3;
				vector4 = V3Tools.Flatten(vector4, vector);
				Vector3 vector5 = vector3 - solver.rootBone.solverPosition;
				vector5 -= vector2;
				vector5 -= this.lastCorrection;
				vector5 = V3Tools.Flatten(vector5, vector);
				Vector3 point = solver.spine.IKRotationHead * solver.spine.anchorRelativeToHead * Vector3.forward;
				point.y = 0f;
				Vector3 vector6 = Quaternion.Inverse(solver.rootBone.solverRotation) * point;
				float num = (Mathf.Atan2(vector6.x, vector6.z) * 57.29578f + solver.spine.rootHeadingOffset) / 90f;
				bool flag = true;
				if (Mathf.Abs(num) < 0.2f)
				{
					num = 0f;
					flag = false;
				}
				this.turn = Mathf.Lerp(this.turn, num, Time.deltaTime * 3f);
				this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Turn, this.turn * 2f);
				Vector3 vector7 = Quaternion.Inverse(solver.readRotations[0]) * (vector4 + vector5);
				vector7 *= this.weight * this.stepLengthMlp;
				float b2 = (flag && !this.isMoving) ? 0.2f : this.animationSmoothTime;
				this.currentAnimationSmoothTime = Mathf.Lerp(this.currentAnimationSmoothTime, b2, deltaTime * 20f);
				this.velocityLocal = Vector3.SmoothDamp(this.velocityLocal, vector7, ref this.velocityLocalV, this.currentAnimationSmoothTime, float.PositiveInfinity, deltaTime);
				float num2 = this.velocityLocal.magnitude / this.stepLengthMlp;
				this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Horizontal, this.velocityLocal.x / scale);
				this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Vertical, this.velocityLocal.z / scale);
				float num3 = this.moveThreshold * scale;
				if (this.isMoving)
				{
					num3 *= 0.9f;
				}
				bool flag2 = this.velocityLocal.sqrMagnitude > num3 * num3;
				if (flag2)
				{
					this.stopMoveTimer = 0f;
				}
				else
				{
					this.stopMoveTimer += deltaTime;
				}
				this.isMoving = (this.stopMoveTimer < 0.05f);
				float target = this.isMoving ? this.maxRootAngleMoving : this.maxRootAngleStanding;
				solver.spine.maxRootAngle = Mathf.SmoothDamp(solver.spine.maxRootAngle, target, ref this.maxRootAngleV, 0.2f, float.PositiveInfinity, deltaTime);
				this.animator.SetBool(IKSolverVR.Locomotion.VRIK_IsMoving, this.isMoving);
				Vector3 vector8 = (solver.rootBone.solverPosition - vector2 - this.lastCorrection - this.lastSpeedRootPos) / deltaTime;
				this.lastSpeedRootPos = solver.rootBone.solverPosition;
				float magnitude = vector8.magnitude;
				float num4 = this.minAnimationSpeed;
				if (magnitude > 0f && flag2)
				{
					num4 = this.animSpeed * (num2 / magnitude);
				}
				num4 = Mathf.Clamp(num4, this.minAnimationSpeed, this.maxAnimationSpeed);
				this.animSpeed = Mathf.SmoothDamp(this.animSpeed, num4, ref this.animSpeedV, 0.05f, float.PositiveInfinity, deltaTime);
				this.animSpeed = Mathf.Lerp(1f, this.animSpeed, this.weight);
				this.animator.SetFloat(IKSolverVR.Locomotion.VRIK_Speed, this.animSpeed);
				bool flag3 = this.animator.GetAnimatorTransitionInfo(0).IsUserName("VRIK_Stop");
				float num5 = 0f;
				if (this.isMoving)
				{
					num5 = this.rootLerpSpeedWhileMoving;
				}
				if (flag3)
				{
					num5 = this.rootLerpSpeedWhileStopping;
				}
				if (flag)
				{
					num5 = this.rootLerpSpeedWhileTurning;
				}
				num5 *= Mathf.Max(vector4.magnitude, 0.2f);
				this.rootLerpSpeed = Mathf.Lerp(this.rootLerpSpeed, num5, deltaTime * 20f);
				vector3 += V3Tools.ExtractVertical(solver.rootBone.solverPosition - vector3, vector, 1f);
				if (this.maxRootOffset > 0f)
				{
					Vector3 solverPosition = solver.rootBone.solverPosition;
					if (this.rootLerpSpeed > 0f)
					{
						solver.rootBone.solverPosition = Vector3.Lerp(solver.rootBone.solverPosition, vector3, this.rootLerpSpeed * deltaTime * this.weight);
					}
					this.lastCorrection = solver.rootBone.solverPosition - solverPosition;
					vector5 = vector3 - solver.rootBone.solverPosition;
					vector5 = V3Tools.Flatten(vector5, vector);
					float magnitude2 = vector5.magnitude;
					if (magnitude2 > this.maxRootOffset)
					{
						this.lastCorrection += (vector5 - vector5 / magnitude2 * this.maxRootOffset) * this.weight;
						solver.rootBone.solverPosition += this.lastCorrection;
					}
				}
				else
				{
					this.lastCorrection = (vector3 - solver.rootBone.solverPosition) * this.weight;
					solver.rootBone.solverPosition += this.lastCorrection;
				}
				this.lastEndRootPos = solver.rootBone.solverPosition;
			}

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x060007D3 RID: 2003 RVA: 0x00032041 File Offset: 0x00030241
			// (set) Token: 0x060007D4 RID: 2004 RVA: 0x00032049 File Offset: 0x00030249
			public Vector3 centerOfMass { get; private set; }

			// Token: 0x060007D5 RID: 2005 RVA: 0x00032054 File Offset: 0x00030254
			private void Initiate_Procedural(Vector3[] positions, Quaternion[] rotations, bool hasToes, float scale)
			{
				this.leftFootIndex = (hasToes ? 17 : 16);
				this.rightFootIndex = (hasToes ? 21 : 20);
				this.footsteps = new IKSolverVR.Footstep[]
				{
					new IKSolverVR.Footstep(rotations[0], positions[this.leftFootIndex], rotations[this.leftFootIndex], this.footDistance * scale * Vector3.left),
					new IKSolverVR.Footstep(rotations[0], positions[this.rightFootIndex], rotations[this.rightFootIndex], this.footDistance * scale * Vector3.right)
				};
			}

			// Token: 0x060007D6 RID: 2006 RVA: 0x00032100 File Offset: 0x00030300
			private void Reset_Procedural(Vector3[] positions, Quaternion[] rotations)
			{
				this.lastComPosition = Vector3.Lerp(positions[1], positions[5], 0.25f) + rotations[0] * this.offset;
				this.comVelocity = Vector3.zero;
				this.footsteps[0].Reset(rotations[0], positions[this.leftFootIndex], rotations[this.leftFootIndex]);
				this.footsteps[1].Reset(rotations[0], positions[this.rightFootIndex], rotations[this.rightFootIndex]);
			}

			// Token: 0x060007D7 RID: 2007 RVA: 0x000321A5 File Offset: 0x000303A5
			private void Relax_Procedural()
			{
				this.footsteps[0].relaxFlag = true;
				this.footsteps[1].relaxFlag = true;
			}

			// Token: 0x060007D8 RID: 2008 RVA: 0x000321C4 File Offset: 0x000303C4
			private void AddDeltaRotation_Procedural(Quaternion delta, Vector3 pivot)
			{
				Vector3 point = this.lastComPosition - pivot;
				this.lastComPosition = pivot + delta * point;
				foreach (IKSolverVR.Footstep footstep in this.footsteps)
				{
					footstep.rotation = delta * footstep.rotation;
					footstep.stepFromRot = delta * footstep.stepFromRot;
					footstep.stepToRot = delta * footstep.stepToRot;
					footstep.stepToRootRot = delta * footstep.stepToRootRot;
					Vector3 point2 = footstep.position - pivot;
					footstep.position = pivot + delta * point2;
					Vector3 point3 = footstep.stepFrom - pivot;
					footstep.stepFrom = pivot + delta * point3;
					Vector3 point4 = footstep.stepTo - pivot;
					footstep.stepTo = pivot + delta * point4;
				}
			}

			// Token: 0x060007D9 RID: 2009 RVA: 0x000322C0 File Offset: 0x000304C0
			private void AddDeltaPosition_Procedural(Vector3 delta)
			{
				this.lastComPosition += delta;
				foreach (IKSolverVR.Footstep footstep in this.footsteps)
				{
					footstep.position += delta;
					footstep.stepFrom += delta;
					footstep.stepTo += delta;
				}
			}

			// Token: 0x060007DA RID: 2010 RVA: 0x0003232C File Offset: 0x0003052C
			public void Solve_Procedural(IKSolverVR.VirtualBone rootBone, IKSolverVR.Spine spine, IKSolverVR.Leg leftLeg, IKSolverVR.Leg rightLeg, IKSolverVR.Arm leftArm, IKSolverVR.Arm rightArm, int supportLegIndex, out Vector3 leftFootPosition, out Vector3 rightFootPosition, out Quaternion leftFootRotation, out Quaternion rightFootRotation, out float leftFootOffset, out float rightFootOffset, out float leftHeelOffset, out float rightHeelOffset, float scale, float deltaTime)
			{
				if (this.weight <= 0f || deltaTime <= 0f)
				{
					leftFootPosition = Vector3.zero;
					rightFootPosition = Vector3.zero;
					leftFootRotation = Quaternion.identity;
					rightFootRotation = Quaternion.identity;
					leftFootOffset = 0f;
					rightFootOffset = 0f;
					leftHeelOffset = 0f;
					rightHeelOffset = 0f;
					return;
				}
				Vector3 vector = rootBone.solverRotation * Vector3.up;
				Vector3 vector2 = spine.pelvis.solverPosition + spine.pelvis.solverRotation * leftLeg.thighRelativeToPelvis;
				Vector3 vector3 = spine.pelvis.solverPosition + spine.pelvis.solverRotation * rightLeg.thighRelativeToPelvis;
				this.footsteps[0].characterSpaceOffset = this.footDistance * Vector3.left * scale;
				this.footsteps[1].characterSpaceOffset = this.footDistance * Vector3.right * scale;
				Vector3 faceDirection = spine.faceDirection;
				Vector3 b = V3Tools.ExtractVertical(faceDirection, vector, 1f);
				Quaternion quaternion = Quaternion.LookRotation(faceDirection - b, vector);
				if (spine.rootHeadingOffset != 0f)
				{
					quaternion = Quaternion.AngleAxis(spine.rootHeadingOffset, vector) * quaternion;
				}
				float num = 1f;
				float num2 = 1f;
				float num3 = 0.2f;
				float d = num + num2 + 2f * num3;
				this.centerOfMass = Vector3.zero;
				this.centerOfMass += spine.pelvis.solverPosition * num;
				this.centerOfMass += spine.head.solverPosition * num2;
				this.centerOfMass += leftArm.position * num3;
				this.centerOfMass += rightArm.position * num3;
				this.centerOfMass /= d;
				this.centerOfMass += rootBone.solverRotation * this.offset;
				this.comVelocity = ((deltaTime > 0f) ? ((this.centerOfMass - this.lastComPosition) / deltaTime) : Vector3.zero);
				this.lastComPosition = this.centerOfMass;
				this.comVelocity = Vector3.ClampMagnitude(this.comVelocity, this.maxVelocity) * this.velocityFactor * scale;
				Vector3 vector4 = this.centerOfMass + this.comVelocity;
				Vector3 a = V3Tools.PointToPlane(spine.pelvis.solverPosition, rootBone.solverPosition, vector);
				Vector3 a2 = V3Tools.PointToPlane(vector4, rootBone.solverPosition, vector);
				Vector3 b2 = Vector3.Lerp(this.footsteps[0].position, this.footsteps[1].position, 0.5f);
				float num4 = Vector3.Angle(vector4 - b2, rootBone.solverRotation * Vector3.up) * this.comAngleMlp;
				for (int i = 0; i < this.footsteps.Length; i++)
				{
					this.footsteps[i].isSupportLeg = (supportLegIndex == i);
				}
				for (int j = 0; j < this.footsteps.Length; j++)
				{
					if (this.footsteps[j].isStepping)
					{
						Vector3 vector5 = a2 + rootBone.solverRotation * this.footsteps[j].characterSpaceOffset;
						if (!this.StepBlocked(this.footsteps[j].stepFrom, vector5, rootBone.solverPosition))
						{
							this.footsteps[j].UpdateStepping(vector5, quaternion, 10f, deltaTime);
						}
					}
					else
					{
						this.footsteps[j].UpdateStanding(quaternion, this.relaxLegTwistMinAngle, this.relaxLegTwistSpeed, deltaTime);
					}
				}
				if (this.CanStep())
				{
					int num5 = -1;
					float num6 = float.NegativeInfinity;
					for (int k = 0; k < this.footsteps.Length; k++)
					{
						if (!this.footsteps[k].isStepping)
						{
							Vector3 vector6 = a2 + rootBone.solverRotation * this.footsteps[k].characterSpaceOffset;
							float num7 = (k == 0) ? leftLeg.mag : rightLeg.mag;
							Vector3 b3 = (k == 0) ? vector2 : vector3;
							float num8 = Vector3.Distance(this.footsteps[k].position, b3);
							bool flag = false;
							if (num8 >= num7 * this.maxLegStretch)
							{
								vector6 = a + rootBone.solverRotation * this.footsteps[k].characterSpaceOffset;
								flag = true;
							}
							bool flag2 = false;
							for (int l = 0; l < this.footsteps.Length; l++)
							{
								if (l != k && !flag)
								{
									if (Vector3.Distance(this.footsteps[k].position, this.footsteps[l].position) >= 0.25f * scale || (this.footsteps[k].position - vector6).sqrMagnitude >= (this.footsteps[l].position - vector6).sqrMagnitude)
									{
										flag2 = IKSolverVR.Locomotion.GetLineSphereCollision(this.footsteps[k].position, vector6, this.footsteps[l].position, 0.25f * scale);
									}
									if (flag2)
									{
										break;
									}
								}
							}
							float num9 = Quaternion.Angle(quaternion, this.footsteps[k].stepToRootRot);
							if (!flag2 || num9 > this.angleThreshold)
							{
								float num10 = Vector3.Distance(this.footsteps[k].position, vector6);
								float num11 = this.stepThreshold * scale;
								if (this.footsteps[k].relaxFlag)
								{
									num11 = 0f;
								}
								float num12 = Mathf.Lerp(num11, num11 * 0.1f, num4 * 0.015f);
								if (flag)
								{
									num12 *= 0.5f;
								}
								if (k == 0)
								{
									num12 *= 0.9f;
								}
								if (!this.StepBlocked(this.footsteps[k].position, vector6, rootBone.solverPosition) && (num10 > num12 || num9 > this.angleThreshold))
								{
									float num13 = 0f;
									num13 -= num10;
									if (num13 > num6)
									{
										num5 = k;
										num6 = num13;
									}
								}
							}
						}
					}
					if (num5 != -1)
					{
						Vector3 p = a2 + rootBone.solverRotation * this.footsteps[num5].characterSpaceOffset;
						this.footsteps[num5].stepSpeed = Random.Range(this.stepSpeed, this.stepSpeed * 1.5f);
						this.footsteps[num5].StepTo(p, quaternion, this.stepThreshold * scale);
					}
				}
				this.footsteps[0].Update(this.stepInterpolation, this.onLeftFootstep, deltaTime);
				this.footsteps[1].Update(this.stepInterpolation, this.onRightFootstep, deltaTime);
				leftFootPosition = this.footsteps[0].position;
				rightFootPosition = this.footsteps[1].position;
				leftFootPosition = V3Tools.PointToPlane(leftFootPosition, leftLeg.lastBone.readPosition, vector);
				rightFootPosition = V3Tools.PointToPlane(rightFootPosition, rightLeg.lastBone.readPosition, vector);
				leftFootOffset = this.stepHeight.Evaluate(this.footsteps[0].stepProgress) * scale;
				rightFootOffset = this.stepHeight.Evaluate(this.footsteps[1].stepProgress) * scale;
				leftHeelOffset = this.heelHeight.Evaluate(this.footsteps[0].stepProgress) * scale;
				rightHeelOffset = this.heelHeight.Evaluate(this.footsteps[1].stepProgress) * scale;
				leftFootRotation = this.footsteps[0].rotation;
				rightFootRotation = this.footsteps[1].rotation;
			}

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x060007DB RID: 2011 RVA: 0x00032B48 File Offset: 0x00030D48
			public Vector3 leftFootstepPosition
			{
				get
				{
					return this.footsteps[0].position;
				}
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x060007DC RID: 2012 RVA: 0x00032B57 File Offset: 0x00030D57
			public Vector3 rightFootstepPosition
			{
				get
				{
					return this.footsteps[1].position;
				}
			}

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x060007DD RID: 2013 RVA: 0x00032B66 File Offset: 0x00030D66
			public Quaternion leftFootstepRotation
			{
				get
				{
					return this.footsteps[0].rotation;
				}
			}

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x060007DE RID: 2014 RVA: 0x00032B75 File Offset: 0x00030D75
			public Quaternion rightFootstepRotation
			{
				get
				{
					return this.footsteps[1].rotation;
				}
			}

			// Token: 0x060007DF RID: 2015 RVA: 0x00032B84 File Offset: 0x00030D84
			private bool StepBlocked(Vector3 fromPosition, Vector3 toPosition, Vector3 rootPosition)
			{
				if (this.blockingLayers == -1 || !this.blockingEnabled)
				{
					return false;
				}
				Vector3 vector = fromPosition;
				vector.y = rootPosition.y + this.raycastHeight + this.raycastRadius;
				Vector3 direction = toPosition - vector;
				direction.y = 0f;
				RaycastHit raycastHit;
				if (this.raycastRadius <= 0f)
				{
					return Physics.Raycast(vector, direction, out raycastHit, direction.magnitude, this.blockingLayers);
				}
				return Physics.SphereCast(vector, this.raycastRadius, direction, out raycastHit, direction.magnitude, this.blockingLayers);
			}

			// Token: 0x060007E0 RID: 2016 RVA: 0x00032C24 File Offset: 0x00030E24
			private bool CanStep()
			{
				foreach (IKSolverVR.Footstep footstep in this.footsteps)
				{
					if (footstep.isStepping && footstep.stepProgress < 0.8f)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x060007E1 RID: 2017 RVA: 0x00032C64 File Offset: 0x00030E64
			private static bool GetLineSphereCollision(Vector3 lineStart, Vector3 lineEnd, Vector3 sphereCenter, float sphereRadius)
			{
				Vector3 forward = lineEnd - lineStart;
				Vector3 vector = sphereCenter - lineStart;
				float num = vector.magnitude - sphereRadius;
				if (num > forward.magnitude)
				{
					return false;
				}
				Vector3 vector2 = Quaternion.Inverse(Quaternion.LookRotation(forward, vector)) * vector;
				if (vector2.z < 0f)
				{
					return num < 0f;
				}
				return vector2.y - sphereRadius < 0f;
			}

			// Token: 0x040006D0 RID: 1744
			[Tooltip("Procedural (legacy) or animated locomotion.")]
			public IKSolverVR.Locomotion.Mode mode;

			// Token: 0x040006D1 RID: 1745
			[Tooltip("Used for blending in/out of procedural/animated locomotion.")]
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x040006D2 RID: 1746
			[Tooltip("Start moving (horizontal distance to HMD + HMD velocity) threshold.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float moveThreshold = 0.3f;

			// Token: 0x040006D3 RID: 1747
			[ShowLargeHeaderIf("Animation", "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			[SerializeField]
			private byte animationHeader;

			// Token: 0x040006D4 RID: 1748
			[Tooltip("Minimum locomotion animation speed.")]
			[ShowRangeIf(0.1f, 1f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float minAnimationSpeed = 0.2f;

			// Token: 0x040006D5 RID: 1749
			[Tooltip("Maximum locomotion animation speed.")]
			[ShowRangeIf(1f, 10f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float maxAnimationSpeed = 3f;

			// Token: 0x040006D6 RID: 1750
			[Tooltip("Smoothing time for Vector3.SmoothDamping 'VRIK_Horizontal' and 'VRIK_Vertical' parameters. Larger values make animation smoother, but less responsive.")]
			[ShowRangeIf(0.05f, 0.2f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float animationSmoothTime = 0.1f;

			// Token: 0x040006D7 RID: 1751
			[ShowLargeHeaderIf("Root Position", "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			[SerializeField]
			private byte rootPositionHeader;

			// Token: 0x040006D8 RID: 1752
			[Tooltip("X and Z standing offset from the horizontal position of the HMD.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public Vector2 standOffset;

			// Token: 0x040006D9 RID: 1753
			[Tooltip("Lerp root towards the horizontal position of the HMD with this speed while moving.")]
			[ShowRangeIf(0f, 50f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float rootLerpSpeedWhileMoving = 30f;

			// Token: 0x040006DA RID: 1754
			[Tooltip("Lerp root towards the horizontal position of the HMD with this speed while in transition from locomotion to idle state.")]
			[ShowRangeIf(0f, 50f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float rootLerpSpeedWhileStopping = 10f;

			// Token: 0x040006DB RID: 1755
			[Tooltip("Lerp root towards the horizontal position of the HMD with this speed while turning on spot.")]
			[ShowRangeIf(0f, 50f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float rootLerpSpeedWhileTurning = 10f;

			// Token: 0x040006DC RID: 1756
			[Tooltip("Max horizontal distance from the root to the HMD.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float maxRootOffset = 0.5f;

			// Token: 0x040006DD RID: 1757
			[ShowLargeHeaderIf("Root Rotation", "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			[SerializeField]
			private byte rootRotationHeader;

			// Token: 0x040006DE RID: 1758
			[Tooltip("Max root angle from head forward while moving (ik.solver.spine.maxRootAngle).")]
			[ShowRangeIf(0f, 180f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float maxRootAngleMoving = 10f;

			// Token: 0x040006DF RID: 1759
			[Tooltip("Max root angle from head forward while standing (ik.solver.spine.maxRootAngle.")]
			[ShowRangeIf(0f, 180f, "mode", IKSolverVR.Locomotion.Mode.Animated, null, false, ShowIfMode.Hidden)]
			public float maxRootAngleStanding = 90f;

			// Token: 0x040006E0 RID: 1760
			[HideInInspector]
			[SerializeField]
			public float stepLengthMlp = 1f;

			// Token: 0x040006E1 RID: 1761
			private Animator animator;

			// Token: 0x040006E2 RID: 1762
			private Vector3 velocityLocal;

			// Token: 0x040006E3 RID: 1763
			private Vector3 velocityLocalV;

			// Token: 0x040006E4 RID: 1764
			private Vector3 lastCorrection;

			// Token: 0x040006E5 RID: 1765
			private Vector3 lastHeadTargetPos;

			// Token: 0x040006E6 RID: 1766
			private Vector3 lastSpeedRootPos;

			// Token: 0x040006E7 RID: 1767
			private Vector3 lastEndRootPos;

			// Token: 0x040006E8 RID: 1768
			private float rootLerpSpeed;

			// Token: 0x040006E9 RID: 1769
			private float rootVelocityV;

			// Token: 0x040006EA RID: 1770
			private float animSpeed = 1f;

			// Token: 0x040006EB RID: 1771
			private float animSpeedV;

			// Token: 0x040006EC RID: 1772
			private float stopMoveTimer;

			// Token: 0x040006ED RID: 1773
			private float turn;

			// Token: 0x040006EE RID: 1774
			private float maxRootAngleV;

			// Token: 0x040006EF RID: 1775
			private float currentAnimationSmoothTime = 0.05f;

			// Token: 0x040006F0 RID: 1776
			private bool isMoving;

			// Token: 0x040006F1 RID: 1777
			private bool firstFrame = true;

			// Token: 0x040006F2 RID: 1778
			private static int VRIK_Horizontal;

			// Token: 0x040006F3 RID: 1779
			private static int VRIK_Vertical;

			// Token: 0x040006F4 RID: 1780
			private static int VRIK_IsMoving;

			// Token: 0x040006F5 RID: 1781
			private static int VRIK_Speed;

			// Token: 0x040006F6 RID: 1782
			private static int VRIK_Turn;

			// Token: 0x040006F7 RID: 1783
			private static bool isHashed;

			// Token: 0x040006F8 RID: 1784
			private float lastVelLocalMag;

			// Token: 0x040006F9 RID: 1785
			[Tooltip("Tries to maintain this distance between the legs.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float footDistance = 0.3f;

			// Token: 0x040006FA RID: 1786
			[Tooltip("Makes a step only if step target position is at least this far from the current footstep or the foot does not reach the current footstep anymore or footstep angle is past the 'Angle Threshold'.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float stepThreshold = 0.4f;

			// Token: 0x040006FB RID: 1787
			[Tooltip("Makes a step only if step target position is at least 'Step Threshold' far from the current footstep or the foot does not reach the current footstep anymore or footstep angle is past this value.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float angleThreshold = 60f;

			// Token: 0x040006FC RID: 1788
			[Tooltip("Multiplies angle of the center of mass - center of pressure vector. Larger value makes the character step sooner if losing balance.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float comAngleMlp = 1f;

			// Token: 0x040006FD RID: 1789
			[Tooltip("Maximum magnitude of head/hand target velocity used in prediction.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float maxVelocity = 0.4f;

			// Token: 0x040006FE RID: 1790
			[Tooltip("The amount of head/hand target velocity prediction.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float velocityFactor = 0.4f;

			// Token: 0x040006FF RID: 1791
			[Tooltip("How much can a leg be extended before it is forced to step to another position? 1 means fully stretched.")]
			[ShowRangeIf(0.9f, 1f, "mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float maxLegStretch = 1f;

			// Token: 0x04000700 RID: 1792
			[Tooltip("The speed of lerping the root of the character towards the horizontal mid-point of the footsteps.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float rootSpeed = 20f;

			// Token: 0x04000701 RID: 1793
			[Tooltip("The speed of moving a foot to the next position.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float stepSpeed = 3f;

			// Token: 0x04000702 RID: 1794
			[Tooltip("The height of the foot by normalized step progress (0 - 1).")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public AnimationCurve stepHeight;

			// Token: 0x04000703 RID: 1795
			[Tooltip("Reduce this value if locomotion makes the head bob too much.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float maxBodyYOffset = 0.05f;

			// Token: 0x04000704 RID: 1796
			[Tooltip("The height offset of the heel by normalized step progress (0 - 1).")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public AnimationCurve heelHeight;

			// Token: 0x04000705 RID: 1797
			[Tooltip("Rotates the foot while the leg is not stepping to relax the twist rotation of the leg if ideal rotation is past this angle.")]
			[ShowRangeIf(0f, 180f, "mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float relaxLegTwistMinAngle = 20f;

			// Token: 0x04000706 RID: 1798
			[Tooltip("The speed of rotating the foot while the leg is not stepping to relax the twist rotation of the leg.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public float relaxLegTwistSpeed = 400f;

			// Token: 0x04000707 RID: 1799
			[Tooltip("Interpolation mode of the step.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public InterpolationMode stepInterpolation = InterpolationMode.InOutSine;

			// Token: 0x04000708 RID: 1800
			[Tooltip("Offset for the approximated center of mass.")]
			[ShowIf("mode", IKSolverVR.Locomotion.Mode.Procedural, null, false, ShowIfMode.Hidden)]
			public Vector3 offset;

			// Token: 0x04000709 RID: 1801
			[HideInInspector]
			public bool blockingEnabled;

			// Token: 0x0400070A RID: 1802
			[HideInInspector]
			public LayerMask blockingLayers;

			// Token: 0x0400070B RID: 1803
			[HideInInspector]
			public float raycastRadius = 0.2f;

			// Token: 0x0400070C RID: 1804
			[HideInInspector]
			public float raycastHeight = 0.2f;

			// Token: 0x0400070D RID: 1805
			[HideInInspector]
			[SerializeField]
			public UnityEvent onLeftFootstep = new UnityEvent();

			// Token: 0x0400070E RID: 1806
			[HideInInspector]
			[SerializeField]
			public UnityEvent onRightFootstep = new UnityEvent();

			// Token: 0x04000710 RID: 1808
			private IKSolverVR.Footstep[] footsteps = new IKSolverVR.Footstep[0];

			// Token: 0x04000711 RID: 1809
			private Vector3 lastComPosition;

			// Token: 0x04000712 RID: 1810
			private Vector3 comVelocity;

			// Token: 0x04000713 RID: 1811
			private int leftFootIndex;

			// Token: 0x04000714 RID: 1812
			private int rightFootIndex;

			// Token: 0x020000E8 RID: 232
			[Serializable]
			public enum Mode
			{
				// Token: 0x04000716 RID: 1814
				Procedural,
				// Token: 0x04000717 RID: 1815
				Animated
			}
		}

		// Token: 0x020000E9 RID: 233
		[Serializable]
		public class Spine : IKSolverVR.BodyPart
		{
			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00032E47 File Offset: 0x00031047
			internal IKSolverVR.VirtualBone pelvis
			{
				get
				{
					return this.bones[this.pelvisIndex];
				}
			}

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x060007E4 RID: 2020 RVA: 0x00032E56 File Offset: 0x00031056
			internal IKSolverVR.VirtualBone firstSpineBone
			{
				get
				{
					return this.bones[this.spineIndex];
				}
			}

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x060007E5 RID: 2021 RVA: 0x00032E65 File Offset: 0x00031065
			internal IKSolverVR.VirtualBone chest
			{
				get
				{
					if (this.hasChest)
					{
						return this.bones[this.chestIndex];
					}
					return this.bones[this.spineIndex];
				}
			}

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x060007E6 RID: 2022 RVA: 0x00032E8A File Offset: 0x0003108A
			internal IKSolverVR.VirtualBone head
			{
				get
				{
					return this.bones[this.headIndex];
				}
			}

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00032E99 File Offset: 0x00031099
			private IKSolverVR.VirtualBone neck
			{
				get
				{
					return this.bones[this.neckIndex];
				}
			}

			// Token: 0x170000EE RID: 238
			// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00032EA8 File Offset: 0x000310A8
			// (set) Token: 0x060007E9 RID: 2025 RVA: 0x00032EB0 File Offset: 0x000310B0
			internal Quaternion anchorRotation { get; private set; }

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060007EA RID: 2026 RVA: 0x00032EB9 File Offset: 0x000310B9
			// (set) Token: 0x060007EB RID: 2027 RVA: 0x00032EC1 File Offset: 0x000310C1
			internal Quaternion anchorRelativeToHead { get; private set; }

			// Token: 0x060007EC RID: 2028 RVA: 0x00032ECC File Offset: 0x000310CC
			protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
			{
				Vector3 vector = positions[index];
				Quaternion quaternion = rotations[index];
				Vector3 vector2 = positions[index + 1];
				Quaternion quaternion2 = rotations[index + 1];
				Vector3 vector3 = positions[index + 2];
				Quaternion quaternion3 = rotations[index + 2];
				Vector3 position = positions[index + 3];
				Quaternion rotation = rotations[index + 3];
				Vector3 vector4 = positions[index + 4];
				Quaternion quaternion4 = rotations[index + 4];
				this.hasLegs = hasLegs;
				if (!hasChest)
				{
					vector3 = vector2;
					quaternion3 = quaternion2;
				}
				if (!this.initiated)
				{
					this.hasChest = hasChest;
					this.hasNeck = hasNeck;
					this.headHeight = V3Tools.ExtractVertical(vector4 - positions[0], rotations[0] * Vector3.up, 1f).magnitude;
					int num = 3;
					if (hasChest)
					{
						num++;
					}
					if (hasNeck)
					{
						num++;
					}
					this.bones = new IKSolverVR.VirtualBone[num];
					this.chestIndex = (hasChest ? 2 : 1);
					this.neckIndex = 1;
					if (hasChest)
					{
						this.neckIndex++;
					}
					if (hasNeck)
					{
						this.neckIndex++;
					}
					this.headIndex = 2;
					if (hasChest)
					{
						this.headIndex++;
					}
					if (hasNeck)
					{
						this.headIndex++;
					}
					this.bones[0] = new IKSolverVR.VirtualBone(vector, quaternion);
					this.bones[1] = new IKSolverVR.VirtualBone(vector2, quaternion2);
					if (hasChest)
					{
						this.bones[this.chestIndex] = new IKSolverVR.VirtualBone(vector3, quaternion3);
					}
					if (hasNeck)
					{
						this.bones[this.neckIndex] = new IKSolverVR.VirtualBone(position, rotation);
					}
					this.bones[this.headIndex] = new IKSolverVR.VirtualBone(vector4, quaternion4);
					this.pelvisRotationOffset = Quaternion.identity;
					this.chestRotationOffset = Quaternion.identity;
					this.headRotationOffset = Quaternion.identity;
					this.anchorRelativeToHead = Quaternion.Inverse(quaternion4) * rotations[0];
					this.anchorRelativeToPelvis = Quaternion.Inverse(quaternion) * rotations[0];
					this.faceDirection = rotations[0] * Vector3.forward;
					this.IKPositionHead = vector4;
					this.IKRotationHead = quaternion4;
					this.IKPositionPelvis = vector;
					this.IKRotationPelvis = quaternion;
					this.goalPositionChest = vector3 + rotations[0] * Vector3.forward;
				}
				this.pelvisRelativeRotation = Quaternion.Inverse(quaternion4) * quaternion;
				this.chestRelativeRotation = Quaternion.Inverse(quaternion4) * quaternion3;
				this.chestForward = Quaternion.Inverse(quaternion3) * (rotations[0] * Vector3.forward);
				this.bones[0].Read(vector, quaternion);
				this.bones[1].Read(vector2, quaternion2);
				if (hasChest)
				{
					this.bones[this.chestIndex].Read(vector3, quaternion3);
				}
				if (hasNeck)
				{
					this.bones[this.neckIndex].Read(position, rotation);
				}
				this.bones[this.headIndex].Read(vector4, quaternion4);
				float num2 = Vector3.Distance(vector, vector4);
				this.sizeMlp = num2 / 0.7f;
			}

			// Token: 0x060007ED RID: 2029 RVA: 0x00033208 File Offset: 0x00031408
			public override void PreSolve(float scale)
			{
				if (this.headTarget != null)
				{
					this.IKPositionHead = this.headTarget.position;
					this.IKRotationHead = this.headTarget.rotation;
				}
				if (this.chestGoal != null)
				{
					this.goalPositionChest = this.chestGoal.position;
				}
				if (this.pelvisTarget != null)
				{
					this.IKPositionPelvis = this.pelvisTarget.position;
					this.IKRotationPelvis = this.pelvisTarget.rotation;
				}
				if (this.useAnimatedHeadHeightWeight > 0f && this.useAnimatedHeadHeightRange > 0f)
				{
					Vector3 verticalAxis = this.rootRotation * Vector3.up;
					if (this.animatedHeadHeightBlend > 0f)
					{
						float num = Mathf.Abs(V3Tools.ExtractVertical(this.IKPositionHead - this.head.solverPosition, verticalAxis, 1f).magnitude);
						num = Mathf.Max(num - this.useAnimatedHeadHeightRange * scale, 0f);
						float num2 = Mathf.Lerp(0f, 1f, num / (this.animatedHeadHeightBlend * scale));
						num2 = Interp.Float(1f - num2, InterpolationMode.InOutSine);
						Vector3 v = this.head.solverPosition - this.IKPositionHead;
						this.IKPositionHead += V3Tools.ExtractVertical(v, verticalAxis, num2 * this.useAnimatedHeadHeightWeight);
					}
					else
					{
						this.IKPositionHead += V3Tools.ExtractVertical(this.head.solverPosition - this.IKPositionHead, verticalAxis, this.useAnimatedHeadHeightWeight);
					}
				}
				this.headPosition = V3Tools.Lerp(this.head.solverPosition, this.IKPositionHead, this.positionWeight);
				this.headRotation = QuaTools.Lerp(this.head.solverRotation, this.IKRotationHead, this.rotationWeight);
				this.pelvisRotation = QuaTools.Lerp(this.pelvis.solverRotation, this.IKRotationPelvis, this.rotationWeight);
			}

			// Token: 0x060007EE RID: 2030 RVA: 0x00033414 File Offset: 0x00031614
			public override void ApplyOffsets(float scale)
			{
				this.headPosition += this.headPositionOffset;
				float num = this.minHeadHeight * scale;
				Vector3 vector = this.rootRotation * Vector3.up;
				if (vector == Vector3.up)
				{
					this.headPosition.y = Math.Max(this.rootPosition.y + num, this.headPosition.y);
				}
				else
				{
					Vector3 vector2 = this.headPosition - this.rootPosition;
					Vector3 b = V3Tools.ExtractHorizontal(vector2, vector, 1f);
					Vector3 vector3 = vector2 - b;
					if (Vector3.Dot(vector3, vector) > 0f)
					{
						if (vector3.magnitude < num)
						{
							vector3 = vector3.normalized * num;
						}
					}
					else
					{
						vector3 = -vector3.normalized * num;
					}
					this.headPosition = this.rootPosition + b + vector3;
				}
				this.headRotation = this.headRotationOffset * this.headRotation;
				this.headDeltaPosition = this.headPosition - this.head.solverPosition;
				this.pelvisDeltaRotation = QuaTools.FromToRotation(this.pelvis.solverRotation, this.headRotation * this.pelvisRelativeRotation);
				if (this.pelvisRotationWeight <= 0f)
				{
					this.anchorRotation = this.headRotation * this.anchorRelativeToHead;
					return;
				}
				if (this.pelvisRotationWeight > 0f && this.pelvisRotationWeight < 1f)
				{
					this.anchorRotation = Quaternion.Lerp(this.headRotation * this.anchorRelativeToHead, this.pelvisRotation * this.anchorRelativeToPelvis, this.pelvisRotationWeight);
					return;
				}
				if (this.pelvisRotationWeight >= 1f)
				{
					this.anchorRotation = this.pelvisRotation * this.anchorRelativeToPelvis;
				}
			}

			// Token: 0x060007EF RID: 2031 RVA: 0x000335F4 File Offset: 0x000317F4
			private void CalculateChestTargetRotation(IKSolverVR.VirtualBone rootBone, IKSolverVR.Arm[] arms)
			{
				this.chestTargetRotation = this.headRotation * this.chestRelativeRotation;
				if (arms[0] != null)
				{
					this.AdjustChestByHands(ref this.chestTargetRotation, arms);
				}
				this.faceDirection = Vector3.Cross(this.anchorRotation * Vector3.right, rootBone.readRotation * Vector3.up) + this.anchorRotation * Vector3.forward;
			}

			// Token: 0x060007F0 RID: 2032 RVA: 0x0003366C File Offset: 0x0003186C
			public void Solve(Animator animator, IKSolverVR.VirtualBone rootBone, IKSolverVR.Leg[] legs, IKSolverVR.Arm[] arms, float scale)
			{
				this.CalculateChestTargetRotation(rootBone, arms);
				if (this.maxRootAngle < 180f)
				{
					Vector3 point = this.faceDirection;
					if (this.rootHeadingOffset != 0f)
					{
						point = Quaternion.AngleAxis(this.rootHeadingOffset, Vector3.up) * point;
					}
					Vector3 vector = Quaternion.Inverse(rootBone.solverRotation) * point;
					float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
					float angle = 0f;
					float num2 = this.maxRootAngle;
					if (num > num2)
					{
						angle = num - num2;
					}
					if (num < -num2)
					{
						angle = num + num2;
					}
					Quaternion quaternion = Quaternion.AngleAxis(angle, rootBone.readRotation * Vector3.up);
					if (animator != null && animator.enabled)
					{
						Vector3 vector2 = animator.applyRootMotion ? animator.pivotPosition : animator.transform.position;
						Vector3 point2 = rootBone.solverPosition - vector2;
						rootBone.solverPosition = vector2 + quaternion * point2;
					}
					rootBone.solverRotation = quaternion * rootBone.solverRotation;
				}
				Vector3 solverPosition = this.pelvis.solverPosition;
				Vector3 rootUp = rootBone.solverRotation * Vector3.up;
				this.TranslatePelvis(legs, this.headDeltaPosition, this.pelvisDeltaRotation, scale);
				this.FABRIKPass(solverPosition, rootUp, this.positionWeight);
				this.Bend(this.bones, this.pelvisIndex, this.chestIndex, this.chestTargetRotation, this.chestRotationOffset, this.chestClampWeight, false, this.neckStiffness * this.rotationWeight);
				if (this.LOD < 1 && this.chestGoalWeight > 0f)
				{
					Quaternion targetRotation = Quaternion.FromToRotation(this.bones[this.chestIndex].solverRotation * this.chestForward, this.goalPositionChest - this.bones[this.chestIndex].solverPosition) * this.bones[this.chestIndex].solverRotation;
					this.Bend(this.bones, this.pelvisIndex, this.chestIndex, targetRotation, this.chestRotationOffset, this.chestClampWeight, false, this.chestGoalWeight * this.rotationWeight);
				}
				this.InverseTranslateToHead(legs, false, false, Vector3.zero, this.positionWeight);
				if (this.LOD < 1)
				{
					this.FABRIKPass(solverPosition, rootUp, this.positionWeight);
				}
				this.Bend(this.bones, this.neckIndex, this.headIndex, this.headRotation, this.headClampWeight, true, this.rotationWeight);
				this.SolvePelvis();
			}

			// Token: 0x060007F1 RID: 2033 RVA: 0x00033910 File Offset: 0x00031B10
			private void FABRIKPass(Vector3 animatedPelvisPos, Vector3 rootUp, float weight)
			{
				Vector3 startPosition = Vector3.Lerp(this.pelvis.solverPosition, animatedPelvisPos, this.maintainPelvisPosition) + this.pelvisPositionOffset;
				Vector3 targetPosition = this.headPosition - this.chestPositionOffset;
				Vector3 zero = Vector3.zero;
				float num = Vector3.Distance(this.bones[0].solverPosition, this.bones[this.bones.Length - 1].solverPosition);
				IKSolverVR.VirtualBone.SolveFABRIK(this.bones, startPosition, targetPosition, weight, 1f, 1, num, zero);
			}

			// Token: 0x060007F2 RID: 2034 RVA: 0x00033998 File Offset: 0x00031B98
			private void SolvePelvis()
			{
				if (this.pelvisPositionWeight > 0f)
				{
					Quaternion solverRotation = this.head.solverRotation;
					Vector3 b = (this.IKPositionPelvis + this.pelvisPositionOffset - this.pelvis.solverPosition) * this.pelvisPositionWeight;
					IKSolverVR.VirtualBone[] bones = this.bones;
					for (int i = 0; i < bones.Length; i++)
					{
						bones[i].solverPosition += b;
					}
					Vector3 bendNormal = this.anchorRotation * Vector3.right;
					if (this.hasChest && this.hasNeck)
					{
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, this.spineIndex, this.chestIndex, this.headIndex, this.headPosition, bendNormal, this.pelvisPositionWeight * 0.9f);
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, this.chestIndex, this.neckIndex, this.headIndex, this.headPosition, bendNormal, this.pelvisPositionWeight);
					}
					else if (this.hasChest && !this.hasNeck)
					{
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, this.spineIndex, this.chestIndex, this.headIndex, this.headPosition, bendNormal, this.pelvisPositionWeight);
					}
					else if (!this.hasChest && this.hasNeck)
					{
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, this.spineIndex, this.neckIndex, this.headIndex, this.headPosition, bendNormal, this.pelvisPositionWeight);
					}
					else if (!this.hasNeck && !this.hasChest)
					{
						IKSolverVR.VirtualBone.SolveTrigonometric(this.bones, this.pelvisIndex, this.spineIndex, this.headIndex, this.headPosition, bendNormal, this.pelvisPositionWeight);
					}
					this.head.solverRotation = solverRotation;
				}
			}

			// Token: 0x060007F3 RID: 2035 RVA: 0x00033B5C File Offset: 0x00031D5C
			public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
			{
				solvedPositions[this.index] = this.bones[0].solverPosition;
				solvedRotations[this.index] = this.bones[0].solverRotation;
				solvedRotations[this.index + 1] = this.bones[1].solverRotation;
				if (this.hasChest)
				{
					solvedRotations[this.index + 2] = this.bones[this.chestIndex].solverRotation;
				}
				if (this.hasNeck)
				{
					solvedRotations[this.index + 3] = this.bones[this.neckIndex].solverRotation;
				}
				solvedRotations[this.index + 4] = this.bones[this.headIndex].solverRotation;
			}

			// Token: 0x060007F4 RID: 2036 RVA: 0x00033C2C File Offset: 0x00031E2C
			public override void ResetOffsets()
			{
				this.pelvisPositionOffset = Vector3.zero;
				this.chestPositionOffset = Vector3.zero;
				this.headPositionOffset = Vector3.zero;
				this.pelvisRotationOffset = Quaternion.identity;
				this.chestRotationOffset = Quaternion.identity;
				this.headRotationOffset = Quaternion.identity;
			}

			// Token: 0x060007F5 RID: 2037 RVA: 0x00033C7C File Offset: 0x00031E7C
			private void AdjustChestByHands(ref Quaternion chestTargetRotation, IKSolverVR.Arm[] arms)
			{
				if (this.LOD > 0)
				{
					return;
				}
				Quaternion rotation = Quaternion.Inverse(this.anchorRotation);
				Vector3 vector = rotation * (arms[0].position - this.headPosition) / this.sizeMlp;
				Vector3 vector2 = rotation * (arms[1].position - this.headPosition) / this.sizeMlp;
				Vector3 forward = Vector3.forward;
				forward.x += vector.x * Mathf.Abs(vector.x);
				forward.x += vector.z * Mathf.Abs(vector.z);
				forward.x += vector2.x * Mathf.Abs(vector2.x);
				forward.x -= vector2.z * Mathf.Abs(vector2.z);
				forward.x *= 5f * this.rotateChestByHands;
				Quaternion lhs = Quaternion.AngleAxis(Mathf.Atan2(forward.x, forward.z) * 57.29578f, this.rootRotation * Vector3.up);
				chestTargetRotation = lhs * chestTargetRotation;
				Vector3 up = Vector3.up;
				up.x += vector.y;
				up.x -= vector2.y;
				up.x *= 0.5f * this.rotateChestByHands;
				lhs = Quaternion.AngleAxis(Mathf.Atan2(up.x, up.y) * 57.29578f, this.rootRotation * Vector3.back);
				chestTargetRotation = lhs * chestTargetRotation;
			}

			// Token: 0x060007F6 RID: 2038 RVA: 0x00033E38 File Offset: 0x00032038
			public void InverseTranslateToHead(IKSolverVR.Leg[] legs, bool limited, bool useCurrentLegMag, Vector3 offset, float w)
			{
				Vector3 b = (this.headPosition + offset - this.head.solverPosition) * w;
				Vector3 vector = this.pelvis.solverPosition + b;
				base.MovePosition(limited ? this.LimitPelvisPosition(legs, vector, useCurrentLegMag, 2) : vector);
			}

			// Token: 0x060007F7 RID: 2039 RVA: 0x00033E94 File Offset: 0x00032094
			private void TranslatePelvis(IKSolverVR.Leg[] legs, Vector3 deltaPosition, Quaternion deltaRotation, float scale)
			{
				Vector3 solverPosition = this.head.solverPosition;
				deltaRotation = QuaTools.ClampRotation(deltaRotation, this.chestClampWeight, 2);
				Quaternion quaternion = Quaternion.Slerp(Quaternion.identity, deltaRotation, this.bodyRotStiffness * this.rotationWeight);
				quaternion = Quaternion.Slerp(quaternion, QuaTools.FromToRotation(this.pelvis.solverRotation, this.IKRotationPelvis), this.pelvisRotationWeight);
				IKSolverVR.VirtualBone.RotateAroundPoint(this.bones, 0, this.pelvis.solverPosition, this.pelvisRotationOffset * quaternion);
				deltaPosition -= this.head.solverPosition - solverPosition;
				Vector3 a = this.rootRotation * Vector3.forward;
				float num = V3Tools.ExtractVertical(deltaPosition, this.rootRotation * Vector3.up, 1f).magnitude;
				if (scale > 0f)
				{
					num /= scale;
				}
				float d = num * -this.moveBodyBackWhenCrouching * this.headHeight;
				deltaPosition += a * d;
				base.MovePosition(this.LimitPelvisPosition(legs, this.pelvis.solverPosition + deltaPosition * this.bodyPosStiffness * this.positionWeight, false, 2));
			}

			// Token: 0x060007F8 RID: 2040 RVA: 0x00033FD0 File Offset: 0x000321D0
			private Vector3 LimitPelvisPosition(IKSolverVR.Leg[] legs, Vector3 pelvisPosition, bool useCurrentLegMag, int it = 2)
			{
				if (!this.hasLegs)
				{
					return pelvisPosition;
				}
				if (useCurrentLegMag)
				{
					foreach (IKSolverVR.Leg leg in legs)
					{
						leg.currentMag = Mathf.Max(Vector3.Distance(leg.thigh.solverPosition, leg.lastBone.solverPosition), leg.currentMag);
					}
				}
				for (int j = 0; j < it; j++)
				{
					foreach (IKSolverVR.Leg leg2 in legs)
					{
						Vector3 b = pelvisPosition - this.pelvis.solverPosition;
						Vector3 vector = leg2.thigh.solverPosition + b;
						Vector3 vector2 = vector - leg2.position;
						float maxLength = useCurrentLegMag ? leg2.currentMag : leg2.mag;
						Vector3 a = leg2.position + Vector3.ClampMagnitude(vector2, maxLength);
						pelvisPosition += a - vector;
					}
				}
				return pelvisPosition;
			}

			// Token: 0x060007F9 RID: 2041 RVA: 0x000340CC File Offset: 0x000322CC
			private void Bend(IKSolverVR.VirtualBone[] bones, int firstIndex, int lastIndex, Quaternion targetRotation, float clampWeight, bool uniformWeight, float w)
			{
				if (w <= 0f)
				{
					return;
				}
				if (bones.Length == 0)
				{
					return;
				}
				int num = lastIndex + 1 - firstIndex;
				if (num < 1)
				{
					return;
				}
				Quaternion quaternion = QuaTools.FromToRotation(bones[lastIndex].solverRotation, targetRotation);
				quaternion = QuaTools.ClampRotation(quaternion, clampWeight, 2);
				float num2 = uniformWeight ? (1f / (float)num) : 0f;
				for (int i = firstIndex; i < lastIndex + 1; i++)
				{
					if (!uniformWeight)
					{
						num2 = Mathf.Clamp((float)((i - firstIndex + 1) / num), 0f, 1f);
					}
					IKSolverVR.VirtualBone.RotateAroundPoint(bones, i, bones[i].solverPosition, Quaternion.Slerp(Quaternion.identity, quaternion, num2 * w));
				}
			}

			// Token: 0x060007FA RID: 2042 RVA: 0x0003416C File Offset: 0x0003236C
			private void Bend(IKSolverVR.VirtualBone[] bones, int firstIndex, int lastIndex, Quaternion targetRotation, Quaternion rotationOffset, float clampWeight, bool uniformWeight, float w)
			{
				if (w <= 0f)
				{
					return;
				}
				if (bones.Length == 0)
				{
					return;
				}
				int num = lastIndex + 1 - firstIndex;
				if (num < 1)
				{
					return;
				}
				Quaternion quaternion = QuaTools.FromToRotation(bones[lastIndex].solverRotation, targetRotation);
				quaternion = QuaTools.ClampRotation(quaternion, clampWeight, 2);
				float num2 = uniformWeight ? (1f / (float)num) : 0f;
				for (int i = firstIndex; i < lastIndex + 1; i++)
				{
					if (!uniformWeight)
					{
						if (num == 1)
						{
							num2 = 1f;
						}
						else if (num == 2)
						{
							num2 = ((i == 0) ? 0.2f : 0.8f);
						}
						else if (num == 3)
						{
							if (i == 0)
							{
								num2 = 0.15f;
							}
							else if (i == 1)
							{
								num2 = 0.4f;
							}
							else
							{
								num2 = 0.45f;
							}
						}
						else if (num > 3)
						{
							num2 = 1f / (float)num;
						}
					}
					IKSolverVR.VirtualBone.RotateAroundPoint(bones, i, bones[i].solverPosition, Quaternion.Slerp(Quaternion.Slerp(Quaternion.identity, rotationOffset, num2), quaternion, num2 * w));
				}
			}

			// Token: 0x04000718 RID: 1816
			[LargeHeader("Head")]
			[Tooltip("The head target. This should not be the camera Transform itself, but a child GameObject parented to it so you could adjust its position/rotation  to match the orientation of the head bone. The best practice for setup would be to move the camera to the avatar's eyes, duplicate the avatar's head bone and parent it to the camera. Then assign the duplicate to this slot.")]
			public Transform headTarget;

			// Token: 0x04000719 RID: 1817
			[Tooltip("Positional weight of the head target. Note that if you have nulled the headTarget, the head will still be pulled to the last position of the headTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float positionWeight = 1f;

			// Token: 0x0400071A RID: 1818
			[Tooltip("Rotational weight of the head target. Note that if you have nulled the headTarget, the head will still be rotated to the last rotation of the headTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float rotationWeight = 1f;

			// Token: 0x0400071B RID: 1819
			[Tooltip("Clamps head rotation. Value of 0.5 allows 90 degrees of rotation for the head relative to the headTarget. Value of 0 allows 180 degrees and value of 1 means head rotation will be locked to the target.")]
			[Range(0f, 1f)]
			public float headClampWeight = 0.6f;

			// Token: 0x0400071C RID: 1820
			[Tooltip("Minimum height of the head from the root of the character.")]
			public float minHeadHeight = 0.8f;

			// Token: 0x0400071D RID: 1821
			[Tooltip("Allows for more natural locomotion animation for 3rd person networked avatars by inheriting vertical head bob motion from the animation while head target height is close to head bone height.")]
			[Range(0f, 1f)]
			public float useAnimatedHeadHeightWeight;

			// Token: 0x0400071E RID: 1822
			[Tooltip("If abs(head target height - head bone height) < this value, will use head bone height as head target Y.")]
			[ShowIf("useAnimatedHeadHeightWeight", 0f, float.PositiveInfinity, false, ShowIfMode.Hidden)]
			public float useAnimatedHeadHeightRange = 0.1f;

			// Token: 0x0400071F RID: 1823
			[Tooltip("Falloff range for the 'Use Animated Head Height Range' effect above. If head target height from head bone height is greater than useAnimatedHeadHeightRange + animatedHeadHeightBlend, then the head will be vertically locked to the head target again.")]
			[ShowIf("useAnimatedHeadHeightWeight", 0f, float.PositiveInfinity, false, ShowIfMode.Hidden)]
			public float animatedHeadHeightBlend = 0.3f;

			// Token: 0x04000720 RID: 1824
			[LargeHeader("Pelvis")]
			[Tooltip("The pelvis target (optional), useful for seated rigs or if you had an additional tracker on the backpack or belt are. The best practice for setup would be to duplicate the avatar's pelvis bone and parenting it to the pelvis tracker. Then assign the duplicate to this slot.")]
			public Transform pelvisTarget;

			// Token: 0x04000721 RID: 1825
			[Tooltip("Positional weight of the pelvis target. Note that if you have nulled the pelvisTarget, the pelvis will still be pulled to the last position of the pelvisTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float pelvisPositionWeight;

			// Token: 0x04000722 RID: 1826
			[Tooltip("Rotational weight of the pelvis target. Note that if you have nulled the pelvisTarget, the pelvis will still be rotated to the last rotation of the pelvisTarget until you set this value to 0.")]
			[Range(0f, 1f)]
			public float pelvisRotationWeight;

			// Token: 0x04000723 RID: 1827
			[Tooltip("How much will the pelvis maintain its animated position?")]
			[Range(0f, 1f)]
			public float maintainPelvisPosition = 0.2f;

			// Token: 0x04000724 RID: 1828
			[LargeHeader("Chest")]
			[Tooltip("If 'Chest Goal Weight' is greater than 0, the chest will be turned towards this Transform.")]
			public Transform chestGoal;

			// Token: 0x04000725 RID: 1829
			[Tooltip("Weight of turning the chest towards the 'Chest Goal'.")]
			[Range(0f, 1f)]
			public float chestGoalWeight;

			// Token: 0x04000726 RID: 1830
			[Tooltip("Clamps chest rotation. Value of 0.5 allows 90 degrees of rotation for the chest relative to the head. Value of 0 allows 180 degrees and value of 1 means the chest will be locked relative to the head.")]
			[Range(0f, 1f)]
			public float chestClampWeight = 0.5f;

			// Token: 0x04000727 RID: 1831
			[Tooltip("The amount of rotation applied to the chest based on hand positions.")]
			[Range(0f, 1f)]
			public float rotateChestByHands = 1f;

			// Token: 0x04000728 RID: 1832
			[LargeHeader("Spine")]
			[Tooltip("Determines how much the body will follow the position of the head.")]
			[Range(0f, 1f)]
			public float bodyPosStiffness = 0.55f;

			// Token: 0x04000729 RID: 1833
			[Tooltip("Determines how much the body will follow the rotation of the head.")]
			[Range(0f, 1f)]
			public float bodyRotStiffness = 0.1f;

			// Token: 0x0400072A RID: 1834
			[Tooltip("Determines how much the chest will rotate to the rotation of the head.")]
			[FormerlySerializedAs("chestRotationWeight")]
			[Range(0f, 1f)]
			public float neckStiffness = 0.2f;

			// Token: 0x0400072B RID: 1835
			[Tooltip("Moves the body horizontally along -character.forward axis by that value when the player is crouching.")]
			public float moveBodyBackWhenCrouching = 0.5f;

			// Token: 0x0400072C RID: 1836
			[LargeHeader("Root Rotation")]
			[Tooltip("Will automatically rotate the root of the character if the head target has turned past this angle.")]
			[Range(0f, 180f)]
			public float maxRootAngle = 25f;

			// Token: 0x0400072D RID: 1837
			[Tooltip("Angular offset for root heading. Adjust this value to turn the root relative to the HMD around the vertical axis. Usefulf for fighting or shooting games where you would sometimes want the avatar to stand at an angled stance.")]
			[Range(-180f, 180f)]
			public float rootHeadingOffset;

			// Token: 0x0400072E RID: 1838
			[HideInInspector]
			[NonSerialized]
			public Vector3 IKPositionHead;

			// Token: 0x0400072F RID: 1839
			[HideInInspector]
			[NonSerialized]
			public Quaternion IKRotationHead = Quaternion.identity;

			// Token: 0x04000730 RID: 1840
			[HideInInspector]
			[NonSerialized]
			public Vector3 IKPositionPelvis;

			// Token: 0x04000731 RID: 1841
			[HideInInspector]
			[NonSerialized]
			public Quaternion IKRotationPelvis = Quaternion.identity;

			// Token: 0x04000732 RID: 1842
			[HideInInspector]
			[NonSerialized]
			public Vector3 goalPositionChest;

			// Token: 0x04000733 RID: 1843
			[HideInInspector]
			[NonSerialized]
			public Vector3 pelvisPositionOffset;

			// Token: 0x04000734 RID: 1844
			[HideInInspector]
			[NonSerialized]
			public Vector3 chestPositionOffset;

			// Token: 0x04000735 RID: 1845
			[HideInInspector]
			[NonSerialized]
			public Vector3 headPositionOffset;

			// Token: 0x04000736 RID: 1846
			[HideInInspector]
			[NonSerialized]
			public Quaternion pelvisRotationOffset = Quaternion.identity;

			// Token: 0x04000737 RID: 1847
			[HideInInspector]
			[NonSerialized]
			public Quaternion chestRotationOffset = Quaternion.identity;

			// Token: 0x04000738 RID: 1848
			[HideInInspector]
			[NonSerialized]
			public Quaternion headRotationOffset = Quaternion.identity;

			// Token: 0x04000739 RID: 1849
			[HideInInspector]
			[NonSerialized]
			public Vector3 faceDirection;

			// Token: 0x0400073A RID: 1850
			[HideInInspector]
			[NonSerialized]
			internal Vector3 headPosition;

			// Token: 0x0400073D RID: 1853
			private Quaternion headRotation = Quaternion.identity;

			// Token: 0x0400073E RID: 1854
			private Quaternion pelvisRotation = Quaternion.identity;

			// Token: 0x0400073F RID: 1855
			private Quaternion anchorRelativeToPelvis = Quaternion.identity;

			// Token: 0x04000740 RID: 1856
			private Quaternion pelvisRelativeRotation = Quaternion.identity;

			// Token: 0x04000741 RID: 1857
			private Quaternion chestRelativeRotation = Quaternion.identity;

			// Token: 0x04000742 RID: 1858
			private Vector3 headDeltaPosition;

			// Token: 0x04000743 RID: 1859
			private Quaternion pelvisDeltaRotation = Quaternion.identity;

			// Token: 0x04000744 RID: 1860
			private Quaternion chestTargetRotation = Quaternion.identity;

			// Token: 0x04000745 RID: 1861
			private int pelvisIndex;

			// Token: 0x04000746 RID: 1862
			private int spineIndex = 1;

			// Token: 0x04000747 RID: 1863
			private int chestIndex = -1;

			// Token: 0x04000748 RID: 1864
			private int neckIndex = -1;

			// Token: 0x04000749 RID: 1865
			private int headIndex = -1;

			// Token: 0x0400074A RID: 1866
			private float length;

			// Token: 0x0400074B RID: 1867
			private bool hasChest;

			// Token: 0x0400074C RID: 1868
			private bool hasNeck;

			// Token: 0x0400074D RID: 1869
			private bool hasLegs;

			// Token: 0x0400074E RID: 1870
			private float headHeight;

			// Token: 0x0400074F RID: 1871
			private float sizeMlp;

			// Token: 0x04000750 RID: 1872
			private Vector3 chestForward;
		}

		// Token: 0x020000EA RID: 234
		[Serializable]
		public enum PositionOffset
		{
			// Token: 0x04000752 RID: 1874
			Pelvis,
			// Token: 0x04000753 RID: 1875
			Chest,
			// Token: 0x04000754 RID: 1876
			Head,
			// Token: 0x04000755 RID: 1877
			LeftHand,
			// Token: 0x04000756 RID: 1878
			RightHand,
			// Token: 0x04000757 RID: 1879
			LeftFoot,
			// Token: 0x04000758 RID: 1880
			RightFoot,
			// Token: 0x04000759 RID: 1881
			LeftHeel,
			// Token: 0x0400075A RID: 1882
			RightHeel
		}

		// Token: 0x020000EB RID: 235
		[Serializable]
		public enum RotationOffset
		{
			// Token: 0x0400075C RID: 1884
			Pelvis,
			// Token: 0x0400075D RID: 1885
			Chest,
			// Token: 0x0400075E RID: 1886
			Head
		}

		// Token: 0x020000EC RID: 236
		[Serializable]
		public class VirtualBone
		{
			// Token: 0x060007FC RID: 2044 RVA: 0x000343A1 File Offset: 0x000325A1
			public VirtualBone(Vector3 position, Quaternion rotation)
			{
				this.Read(position, rotation);
			}

			// Token: 0x060007FD RID: 2045 RVA: 0x000343B1 File Offset: 0x000325B1
			public void Read(Vector3 position, Quaternion rotation)
			{
				this.readPosition = position;
				this.readRotation = rotation;
				this.solverPosition = position;
				this.solverRotation = rotation;
			}

			// Token: 0x060007FE RID: 2046 RVA: 0x000343D0 File Offset: 0x000325D0
			public static void SwingRotation(IKSolverVR.VirtualBone[] bones, int index, Vector3 swingTarget, float weight = 1f)
			{
				if (weight <= 0f)
				{
					return;
				}
				Quaternion quaternion = Quaternion.FromToRotation(bones[index].solverRotation * bones[index].axis, swingTarget - bones[index].solverPosition);
				if (weight < 1f)
				{
					quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, weight);
				}
				for (int i = index; i < bones.Length; i++)
				{
					bones[i].solverRotation = quaternion * bones[i].solverRotation;
				}
			}

			// Token: 0x060007FF RID: 2047 RVA: 0x00034448 File Offset: 0x00032648
			public static float PreSolve(ref IKSolverVR.VirtualBone[] bones)
			{
				float num = 0f;
				for (int i = 0; i < bones.Length; i++)
				{
					if (i < bones.Length - 1)
					{
						bones[i].sqrMag = (bones[i + 1].solverPosition - bones[i].solverPosition).sqrMagnitude;
						bones[i].length = Mathf.Sqrt(bones[i].sqrMag);
						num += bones[i].length;
						bones[i].axis = Quaternion.Inverse(bones[i].solverRotation) * (bones[i + 1].solverPosition - bones[i].solverPosition);
					}
					else
					{
						bones[i].sqrMag = 0f;
						bones[i].length = 0f;
					}
				}
				return num;
			}

			// Token: 0x06000800 RID: 2048 RVA: 0x00034520 File Offset: 0x00032720
			public static void RotateAroundPoint(IKSolverVR.VirtualBone[] bones, int index, Vector3 point, Quaternion rotation)
			{
				for (int i = index; i < bones.Length; i++)
				{
					if (bones[i] != null)
					{
						Vector3 point2 = bones[i].solverPosition - point;
						bones[i].solverPosition = point + rotation * point2;
						bones[i].solverRotation = rotation * bones[i].solverRotation;
					}
				}
			}

			// Token: 0x06000801 RID: 2049 RVA: 0x0003457C File Offset: 0x0003277C
			public static void RotateBy(IKSolverVR.VirtualBone[] bones, int index, Quaternion rotation)
			{
				for (int i = index; i < bones.Length; i++)
				{
					if (bones[i] != null)
					{
						Vector3 point = bones[i].solverPosition - bones[index].solverPosition;
						bones[i].solverPosition = bones[index].solverPosition + rotation * point;
						bones[i].solverRotation = rotation * bones[i].solverRotation;
					}
				}
			}

			// Token: 0x06000802 RID: 2050 RVA: 0x000345E4 File Offset: 0x000327E4
			public static void RotateBy(IKSolverVR.VirtualBone[] bones, Quaternion rotation)
			{
				for (int i = 0; i < bones.Length; i++)
				{
					if (bones[i] != null)
					{
						if (i > 0)
						{
							Vector3 point = bones[i].solverPosition - bones[0].solverPosition;
							bones[i].solverPosition = bones[0].solverPosition + rotation * point;
						}
						bones[i].solverRotation = rotation * bones[i].solverRotation;
					}
				}
			}

			// Token: 0x06000803 RID: 2051 RVA: 0x00034650 File Offset: 0x00032850
			public static void RotateTo(IKSolverVR.VirtualBone[] bones, int index, Quaternion rotation)
			{
				Quaternion rotation2 = QuaTools.FromToRotation(bones[index].solverRotation, rotation);
				IKSolverVR.VirtualBone.RotateAroundPoint(bones, index, bones[index].solverPosition, rotation2);
			}

			// Token: 0x06000804 RID: 2052 RVA: 0x0003467C File Offset: 0x0003287C
			public static void SolveTrigonometric(IKSolverVR.VirtualBone[] bones, int first, int second, int third, Vector3 targetPosition, Vector3 bendNormal, float weight)
			{
				if (weight <= 0f)
				{
					return;
				}
				targetPosition = Vector3.Lerp(bones[third].solverPosition, targetPosition, weight);
				Vector3 vector = targetPosition - bones[first].solverPosition;
				float sqrMagnitude = vector.sqrMagnitude;
				if (sqrMagnitude == 0f)
				{
					return;
				}
				float directionMag = Mathf.Sqrt(sqrMagnitude);
				float sqrMagnitude2 = (bones[second].solverPosition - bones[first].solverPosition).sqrMagnitude;
				float sqrMagnitude3 = (bones[third].solverPosition - bones[second].solverPosition).sqrMagnitude;
				Vector3 bendDirection = Vector3.Cross(vector, bendNormal);
				Vector3 directionToBendPoint = IKSolverVR.VirtualBone.GetDirectionToBendPoint(vector, directionMag, bendDirection, sqrMagnitude2, sqrMagnitude3);
				Quaternion quaternion = Quaternion.FromToRotation(bones[second].solverPosition - bones[first].solverPosition, directionToBendPoint);
				if (weight < 1f)
				{
					quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, weight);
				}
				IKSolverVR.VirtualBone.RotateAroundPoint(bones, first, bones[first].solverPosition, quaternion);
				Quaternion quaternion2 = Quaternion.FromToRotation(bones[third].solverPosition - bones[second].solverPosition, targetPosition - bones[second].solverPosition);
				if (weight < 1f)
				{
					quaternion2 = Quaternion.Lerp(Quaternion.identity, quaternion2, weight);
				}
				IKSolverVR.VirtualBone.RotateAroundPoint(bones, second, bones[second].solverPosition, quaternion2);
			}

			// Token: 0x06000805 RID: 2053 RVA: 0x000347C4 File Offset: 0x000329C4
			private static Vector3 GetDirectionToBendPoint(Vector3 direction, float directionMag, Vector3 bendDirection, float sqrMag1, float sqrMag2)
			{
				float num = (directionMag * directionMag + (sqrMag1 - sqrMag2)) / 2f / directionMag;
				float y = (float)Math.Sqrt((double)Mathf.Clamp(sqrMag1 - num * num, 0f, float.PositiveInfinity));
				if (direction == Vector3.zero)
				{
					return Vector3.zero;
				}
				return Quaternion.LookRotation(direction, bendDirection) * new Vector3(0f, y, num);
			}

			// Token: 0x06000806 RID: 2054 RVA: 0x0003482C File Offset: 0x00032A2C
			public static void SolveFABRIK(IKSolverVR.VirtualBone[] bones, Vector3 startPosition, Vector3 targetPosition, float weight, float minNormalizedTargetDistance, int iterations, float length, Vector3 startOffset)
			{
				if (weight <= 0f)
				{
					return;
				}
				if (minNormalizedTargetDistance > 0f)
				{
					Vector3 a = targetPosition - startPosition;
					float magnitude = a.magnitude;
					Vector3 b = startPosition + a / magnitude * Mathf.Max(length * minNormalizedTargetDistance, magnitude);
					targetPosition = Vector3.Lerp(targetPosition, b, weight);
				}
				for (int i = 0; i < iterations; i++)
				{
					bones[bones.Length - 1].solverPosition = Vector3.Lerp(bones[bones.Length - 1].solverPosition, targetPosition, weight);
					for (int j = bones.Length - 2; j > -1; j--)
					{
						bones[j].solverPosition = IKSolverVR.VirtualBone.SolveFABRIKJoint(bones[j].solverPosition, bones[j + 1].solverPosition, bones[j].length);
					}
					if (i == 0)
					{
						for (int k = 0; k < bones.Length; k++)
						{
							bones[k].solverPosition += startOffset;
						}
					}
					bones[0].solverPosition = startPosition;
					for (int l = 1; l < bones.Length; l++)
					{
						bones[l].solverPosition = IKSolverVR.VirtualBone.SolveFABRIKJoint(bones[l].solverPosition, bones[l - 1].solverPosition, bones[l - 1].length);
					}
				}
				for (int m = 0; m < bones.Length - 1; m++)
				{
					IKSolverVR.VirtualBone.SwingRotation(bones, m, bones[m + 1].solverPosition, 1f);
				}
			}

			// Token: 0x06000807 RID: 2055 RVA: 0x00034998 File Offset: 0x00032B98
			private static Vector3 SolveFABRIKJoint(Vector3 pos1, Vector3 pos2, float length)
			{
				return pos2 + (pos1 - pos2).normalized * length;
			}

			// Token: 0x06000808 RID: 2056 RVA: 0x000349C0 File Offset: 0x00032BC0
			public static void SolveCCD(IKSolverVR.VirtualBone[] bones, Vector3 targetPosition, float weight, int iterations)
			{
				if (weight <= 0f)
				{
					return;
				}
				for (int i = 0; i < iterations; i++)
				{
					for (int j = bones.Length - 2; j > -1; j--)
					{
						Vector3 fromDirection = bones[bones.Length - 1].solverPosition - bones[j].solverPosition;
						Vector3 toDirection = targetPosition - bones[j].solverPosition;
						Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
						if (weight >= 1f)
						{
							IKSolverVR.VirtualBone.RotateBy(bones, j, quaternion);
						}
						else
						{
							IKSolverVR.VirtualBone.RotateBy(bones, j, Quaternion.Lerp(Quaternion.identity, quaternion, weight));
						}
					}
				}
			}

			// Token: 0x0400075F RID: 1887
			public Vector3 readPosition;

			// Token: 0x04000760 RID: 1888
			public Quaternion readRotation;

			// Token: 0x04000761 RID: 1889
			public Vector3 solverPosition;

			// Token: 0x04000762 RID: 1890
			public Quaternion solverRotation;

			// Token: 0x04000763 RID: 1891
			public float length;

			// Token: 0x04000764 RID: 1892
			public float sqrMag;

			// Token: 0x04000765 RID: 1893
			public Vector3 axis;
		}
	}
}
