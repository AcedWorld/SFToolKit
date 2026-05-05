using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D7 RID: 215
	[Serializable]
	public class IKSolverFullBodyBiped : IKSolverFullBody
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x00029998 File Offset: 0x00027B98
		public IKEffector bodyEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.Body);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x000299A1 File Offset: 0x00027BA1
		public IKEffector leftShoulderEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.LeftShoulder);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x000299AA File Offset: 0x00027BAA
		public IKEffector rightShoulderEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.RightShoulder);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x000299B3 File Offset: 0x00027BB3
		public IKEffector leftThighEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.LeftThigh);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x000299BC File Offset: 0x00027BBC
		public IKEffector rightThighEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.RightThigh);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x000299C5 File Offset: 0x00027BC5
		public IKEffector leftHandEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.LeftHand);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x000299CE File Offset: 0x00027BCE
		public IKEffector rightHandEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.RightHand);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x000299D7 File Offset: 0x00027BD7
		public IKEffector leftFootEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.LeftFoot);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x000299E0 File Offset: 0x00027BE0
		public IKEffector rightFootEffector
		{
			get
			{
				return this.GetEffector(FullBodyBipedEffector.RightFoot);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x000299E9 File Offset: 0x00027BE9
		public FBIKChain leftArmChain
		{
			get
			{
				return this.chain[1];
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x000299F3 File Offset: 0x00027BF3
		public FBIKChain rightArmChain
		{
			get
			{
				return this.chain[2];
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x000299FD File Offset: 0x00027BFD
		public FBIKChain leftLegChain
		{
			get
			{
				return this.chain[3];
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x00029A07 File Offset: 0x00027C07
		public FBIKChain rightLegChain
		{
			get
			{
				return this.chain[4];
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00029A11 File Offset: 0x00027C11
		public IKMappingLimb leftArmMapping
		{
			get
			{
				return this.limbMappings[0];
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x00029A1B File Offset: 0x00027C1B
		public IKMappingLimb rightArmMapping
		{
			get
			{
				return this.limbMappings[1];
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00029A25 File Offset: 0x00027C25
		public IKMappingLimb leftLegMapping
		{
			get
			{
				return this.limbMappings[2];
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x00029A2F File Offset: 0x00027C2F
		public IKMappingLimb rightLegMapping
		{
			get
			{
				return this.limbMappings[3];
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00029A39 File Offset: 0x00027C39
		public IKMappingBone headMapping
		{
			get
			{
				return this.boneMappings[0];
			}
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00029A43 File Offset: 0x00027C43
		public void SetChainWeights(FullBodyBipedChain c, float pull, float reach = 0f)
		{
			this.GetChain(c).pull = pull;
			this.GetChain(c).reach = reach;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00029A5F File Offset: 0x00027C5F
		public void SetEffectorWeights(FullBodyBipedEffector effector, float positionWeight, float rotationWeight)
		{
			this.GetEffector(effector).positionWeight = Mathf.Clamp(positionWeight, 0f, 1f);
			this.GetEffector(effector).rotationWeight = Mathf.Clamp(rotationWeight, 0f, 1f);
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00029A99 File Offset: 0x00027C99
		public FBIKChain GetChain(FullBodyBipedChain c)
		{
			switch (c)
			{
			case FullBodyBipedChain.LeftArm:
				return this.chain[1];
			case FullBodyBipedChain.RightArm:
				return this.chain[2];
			case FullBodyBipedChain.LeftLeg:
				return this.chain[3];
			case FullBodyBipedChain.RightLeg:
				return this.chain[4];
			default:
				return null;
			}
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00029AD8 File Offset: 0x00027CD8
		public FBIKChain GetChain(FullBodyBipedEffector effector)
		{
			switch (effector)
			{
			case FullBodyBipedEffector.Body:
				return this.chain[0];
			case FullBodyBipedEffector.LeftShoulder:
				return this.chain[1];
			case FullBodyBipedEffector.RightShoulder:
				return this.chain[2];
			case FullBodyBipedEffector.LeftThigh:
				return this.chain[3];
			case FullBodyBipedEffector.RightThigh:
				return this.chain[4];
			case FullBodyBipedEffector.LeftHand:
				return this.chain[1];
			case FullBodyBipedEffector.RightHand:
				return this.chain[2];
			case FullBodyBipedEffector.LeftFoot:
				return this.chain[3];
			case FullBodyBipedEffector.RightFoot:
				return this.chain[4];
			default:
				return null;
			}
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00029B64 File Offset: 0x00027D64
		public IKEffector GetEffector(FullBodyBipedEffector effector)
		{
			switch (effector)
			{
			case FullBodyBipedEffector.Body:
				return this.effectors[0];
			case FullBodyBipedEffector.LeftShoulder:
				return this.effectors[1];
			case FullBodyBipedEffector.RightShoulder:
				return this.effectors[2];
			case FullBodyBipedEffector.LeftThigh:
				return this.effectors[3];
			case FullBodyBipedEffector.RightThigh:
				return this.effectors[4];
			case FullBodyBipedEffector.LeftHand:
				return this.effectors[5];
			case FullBodyBipedEffector.RightHand:
				return this.effectors[6];
			case FullBodyBipedEffector.LeftFoot:
				return this.effectors[7];
			case FullBodyBipedEffector.RightFoot:
				return this.effectors[8];
			default:
				return null;
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00029BEF File Offset: 0x00027DEF
		public IKEffector GetEndEffector(FullBodyBipedChain c)
		{
			switch (c)
			{
			case FullBodyBipedChain.LeftArm:
				return this.effectors[5];
			case FullBodyBipedChain.RightArm:
				return this.effectors[6];
			case FullBodyBipedChain.LeftLeg:
				return this.effectors[7];
			case FullBodyBipedChain.RightLeg:
				return this.effectors[8];
			default:
				return null;
			}
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00029C2E File Offset: 0x00027E2E
		public IKMappingLimb GetLimbMapping(FullBodyBipedChain chain)
		{
			switch (chain)
			{
			case FullBodyBipedChain.LeftArm:
				return this.limbMappings[0];
			case FullBodyBipedChain.RightArm:
				return this.limbMappings[1];
			case FullBodyBipedChain.LeftLeg:
				return this.limbMappings[2];
			case FullBodyBipedChain.RightLeg:
				return this.limbMappings[3];
			default:
				return null;
			}
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00029C70 File Offset: 0x00027E70
		public IKMappingLimb GetLimbMapping(FullBodyBipedEffector effector)
		{
			switch (effector)
			{
			case FullBodyBipedEffector.LeftShoulder:
				return this.limbMappings[0];
			case FullBodyBipedEffector.RightShoulder:
				return this.limbMappings[1];
			case FullBodyBipedEffector.LeftThigh:
				return this.limbMappings[2];
			case FullBodyBipedEffector.RightThigh:
				return this.limbMappings[3];
			case FullBodyBipedEffector.LeftHand:
				return this.limbMappings[0];
			case FullBodyBipedEffector.RightHand:
				return this.limbMappings[1];
			case FullBodyBipedEffector.LeftFoot:
				return this.limbMappings[2];
			case FullBodyBipedEffector.RightFoot:
				return this.limbMappings[3];
			default:
				return null;
			}
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00029CF0 File Offset: 0x00027EF0
		public IKMappingSpine GetSpineMapping()
		{
			return this.spineMapping;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00029A39 File Offset: 0x00027C39
		public IKMappingBone GetHeadMapping()
		{
			return this.boneMappings[0];
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00029CF8 File Offset: 0x00027EF8
		public IKConstraintBend GetBendConstraint(FullBodyBipedChain limb)
		{
			switch (limb)
			{
			case FullBodyBipedChain.LeftArm:
				return this.chain[1].bendConstraint;
			case FullBodyBipedChain.RightArm:
				return this.chain[2].bendConstraint;
			case FullBodyBipedChain.LeftLeg:
				return this.chain[3].bendConstraint;
			case FullBodyBipedChain.RightLeg:
				return this.chain[4].bendConstraint;
			default:
				return null;
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00029D58 File Offset: 0x00027F58
		public override bool IsValid(ref string message)
		{
			if (!base.IsValid(ref message))
			{
				return false;
			}
			if (this.rootNode == null)
			{
				message = "Root Node bone is null. FBBIK will not initiate.";
				return false;
			}
			if (this.chain.Length != 5 || this.chain[0].nodes.Length != 1 || this.chain[1].nodes.Length != 3 || this.chain[2].nodes.Length != 3 || this.chain[3].nodes.Length != 3 || this.chain[4].nodes.Length != 3 || this.effectors.Length != 9 || this.limbMappings.Length != 4)
			{
				message = "Invalid FBBIK setup. Please right-click on the component header and select 'Reinitiate'.";
				return false;
			}
			return true;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00029E10 File Offset: 0x00028010
		public void SetToReferences(BipedReferences references, Transform rootNode = null)
		{
			this.root = references.root;
			if (rootNode == null)
			{
				rootNode = IKSolverFullBodyBiped.DetectRootNodeBone(references);
			}
			this.rootNode = rootNode;
			if (this.chain == null || this.chain.Length != 5)
			{
				this.chain = new FBIKChain[5];
			}
			for (int i = 0; i < this.chain.Length; i++)
			{
				if (this.chain[i] == null)
				{
					this.chain[i] = new FBIKChain();
				}
			}
			this.chain[0].pin = 0f;
			this.chain[0].SetNodes(new Transform[]
			{
				rootNode
			});
			this.chain[0].children = new int[]
			{
				1,
				2,
				3,
				4
			};
			this.chain[1].SetNodes(new Transform[]
			{
				references.leftUpperArm,
				references.leftForearm,
				references.leftHand
			});
			this.chain[2].SetNodes(new Transform[]
			{
				references.rightUpperArm,
				references.rightForearm,
				references.rightHand
			});
			this.chain[3].SetNodes(new Transform[]
			{
				references.leftThigh,
				references.leftCalf,
				references.leftFoot
			});
			this.chain[4].SetNodes(new Transform[]
			{
				references.rightThigh,
				references.rightCalf,
				references.rightFoot
			});
			if (this.effectors.Length != 9)
			{
				this.effectors = new IKEffector[]
				{
					new IKEffector(),
					new IKEffector(),
					new IKEffector(),
					new IKEffector(),
					new IKEffector(),
					new IKEffector(),
					new IKEffector(),
					new IKEffector(),
					new IKEffector()
				};
			}
			this.effectors[0].bone = rootNode;
			this.effectors[0].childBones = new Transform[]
			{
				references.leftThigh,
				references.rightThigh
			};
			this.effectors[1].bone = references.leftUpperArm;
			this.effectors[2].bone = references.rightUpperArm;
			this.effectors[3].bone = references.leftThigh;
			this.effectors[4].bone = references.rightThigh;
			this.effectors[5].bone = references.leftHand;
			this.effectors[6].bone = references.rightHand;
			this.effectors[7].bone = references.leftFoot;
			this.effectors[8].bone = references.rightFoot;
			this.effectors[5].planeBone1 = references.leftUpperArm;
			this.effectors[5].planeBone2 = references.rightUpperArm;
			this.effectors[5].planeBone3 = rootNode;
			this.effectors[6].planeBone1 = references.rightUpperArm;
			this.effectors[6].planeBone2 = references.leftUpperArm;
			this.effectors[6].planeBone3 = rootNode;
			this.effectors[7].planeBone1 = references.leftThigh;
			this.effectors[7].planeBone2 = references.rightThigh;
			this.effectors[7].planeBone3 = rootNode;
			this.effectors[8].planeBone1 = references.rightThigh;
			this.effectors[8].planeBone2 = references.leftThigh;
			this.effectors[8].planeBone3 = rootNode;
			this.chain[0].childConstraints = new FBIKChain.ChildConstraint[]
			{
				new FBIKChain.ChildConstraint(references.leftUpperArm, references.rightThigh, 0f, 1f),
				new FBIKChain.ChildConstraint(references.rightUpperArm, references.leftThigh, 0f, 1f),
				new FBIKChain.ChildConstraint(references.leftUpperArm, references.rightUpperArm, 0f, 0f),
				new FBIKChain.ChildConstraint(references.leftThigh, references.rightThigh, 0f, 0f)
			};
			Transform[] array = new Transform[references.spine.Length + 1];
			array[0] = references.pelvis;
			for (int j = 0; j < references.spine.Length; j++)
			{
				array[j + 1] = references.spine[j];
			}
			if (this.spineMapping == null)
			{
				this.spineMapping = new IKMappingSpine();
				this.spineMapping.iterations = 3;
			}
			this.spineMapping.SetBones(array, references.leftUpperArm, references.rightUpperArm, references.leftThigh, references.rightThigh);
			int num = (references.head != null) ? 1 : 0;
			if (this.boneMappings.Length != num)
			{
				this.boneMappings = new IKMappingBone[num];
				for (int k = 0; k < this.boneMappings.Length; k++)
				{
					this.boneMappings[k] = new IKMappingBone();
				}
				if (num == 1)
				{
					this.boneMappings[0].maintainRotationWeight = 0f;
				}
			}
			if (this.boneMappings.Length != 0)
			{
				this.boneMappings[0].bone = references.head;
			}
			if (this.limbMappings.Length != 4)
			{
				this.limbMappings = new IKMappingLimb[]
				{
					new IKMappingLimb(),
					new IKMappingLimb(),
					new IKMappingLimb(),
					new IKMappingLimb()
				};
				this.limbMappings[2].maintainRotationWeight = 1f;
				this.limbMappings[3].maintainRotationWeight = 1f;
			}
			this.limbMappings[0].SetBones(references.leftUpperArm, references.leftForearm, references.leftHand, IKSolverFullBodyBiped.GetLeftClavicle(references));
			this.limbMappings[1].SetBones(references.rightUpperArm, references.rightForearm, references.rightHand, IKSolverFullBodyBiped.GetRightClavicle(references));
			this.limbMappings[2].SetBones(references.leftThigh, references.leftCalf, references.leftFoot, null);
			this.limbMappings[3].SetBones(references.rightThigh, references.rightCalf, references.rightFoot, null);
			if (Application.isPlaying)
			{
				base.Initiate(references.root);
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0002A408 File Offset: 0x00028608
		public static Transform DetectRootNodeBone(BipedReferences references)
		{
			if (!references.isFilled)
			{
				return null;
			}
			if (references.spine.Length < 1)
			{
				return null;
			}
			int num = references.spine.Length;
			if (num == 1)
			{
				return references.spine[0];
			}
			Vector3 b = Vector3.Lerp(references.leftThigh.position, references.rightThigh.position, 0.5f);
			Vector3 onNormal = Vector3.Lerp(references.leftUpperArm.position, references.rightUpperArm.position, 0.5f) - b;
			float magnitude = onNormal.magnitude;
			if (references.spine.Length < 2)
			{
				return references.spine[0];
			}
			int num2 = 0;
			for (int i = 1; i < num; i++)
			{
				Vector3 vector = Vector3.Project(references.spine[i].position - b, onNormal);
				if (Vector3.Dot(vector.normalized, onNormal.normalized) > 0f && vector.magnitude / magnitude < 0.5f)
				{
					num2 = i;
				}
			}
			return references.spine[num2];
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0002A50C File Offset: 0x0002870C
		public void SetLimbOrientations(BipedLimbOrientations o)
		{
			this.SetLimbOrientation(FullBodyBipedChain.LeftArm, o.leftArm);
			this.SetLimbOrientation(FullBodyBipedChain.RightArm, o.rightArm);
			this.SetLimbOrientation(FullBodyBipedChain.LeftLeg, o.leftLeg);
			this.SetLimbOrientation(FullBodyBipedChain.RightLeg, o.rightLeg);
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x0002A542 File Offset: 0x00028742
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x0002A54A File Offset: 0x0002874A
		public Vector3 pullBodyOffset { get; private set; }

		// Token: 0x060006EF RID: 1775 RVA: 0x0002A554 File Offset: 0x00028754
		private void SetLimbOrientation(FullBodyBipedChain chain, BipedLimbOrientations.LimbOrientation limbOrientation)
		{
			if (chain == FullBodyBipedChain.LeftArm || chain == FullBodyBipedChain.RightArm)
			{
				this.GetBendConstraint(chain).SetLimbOrientation(-limbOrientation.upperBoneForwardAxis, -limbOrientation.lowerBoneForwardAxis, -limbOrientation.lastBoneLeftAxis);
				this.GetLimbMapping(chain).SetLimbOrientation(-limbOrientation.upperBoneForwardAxis, -limbOrientation.lowerBoneForwardAxis);
				return;
			}
			this.GetBendConstraint(chain).SetLimbOrientation(limbOrientation.upperBoneForwardAxis, limbOrientation.lowerBoneForwardAxis, limbOrientation.lastBoneLeftAxis);
			this.GetLimbMapping(chain).SetLimbOrientation(limbOrientation.upperBoneForwardAxis, limbOrientation.lowerBoneForwardAxis);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0002A5F3 File Offset: 0x000287F3
		private static Transform GetLeftClavicle(BipedReferences references)
		{
			if (references.leftUpperArm == null)
			{
				return null;
			}
			if (!IKSolverFullBodyBiped.Contains(references.spine, references.leftUpperArm.parent))
			{
				return references.leftUpperArm.parent;
			}
			return null;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0002A62A File Offset: 0x0002882A
		private static Transform GetRightClavicle(BipedReferences references)
		{
			if (references.rightUpperArm == null)
			{
				return null;
			}
			if (!IKSolverFullBodyBiped.Contains(references.spine, references.rightUpperArm.parent))
			{
				return references.rightUpperArm.parent;
			}
			return null;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0002A664 File Offset: 0x00028864
		private static bool Contains(Transform[] array, Transform transform)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == transform)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0002A690 File Offset: 0x00028890
		protected override void ReadPose()
		{
			for (int i = 0; i < this.effectors.Length; i++)
			{
				this.effectors[i].SetToTarget();
			}
			this.PullBody();
			float pushElasticity = Mathf.Clamp(1f - this.spineStiffness, 0f, 1f);
			this.chain[0].childConstraints[0].pushElasticity = pushElasticity;
			this.chain[0].childConstraints[1].pushElasticity = pushElasticity;
			base.ReadPose();
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0002A710 File Offset: 0x00028910
		private void PullBody()
		{
			if (this.iterations < 1)
			{
				return;
			}
			if (this.pullBodyVertical != 0f || this.pullBodyHorizontal != 0f)
			{
				Vector3 bodyOffset = this.GetBodyOffset();
				this.pullBodyOffset = V3Tools.ExtractVertical(bodyOffset, this.root.up, this.pullBodyVertical) + V3Tools.ExtractHorizontal(bodyOffset, this.root.up, this.pullBodyHorizontal);
				this.bodyEffector.positionOffset += this.pullBodyOffset;
			}
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0002A7A0 File Offset: 0x000289A0
		private Vector3 GetBodyOffset()
		{
			Vector3 a = Vector3.zero + this.GetHandBodyPull(this.leftHandEffector, this.leftArmChain, Vector3.zero) * Mathf.Clamp(this.leftHandEffector.positionWeight, 0f, 1f);
			return a + this.GetHandBodyPull(this.rightHandEffector, this.rightArmChain, a) * Mathf.Clamp(this.rightHandEffector.positionWeight, 0f, 1f);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0002A828 File Offset: 0x00028A28
		private Vector3 GetHandBodyPull(IKEffector effector, FBIKChain arm, Vector3 offset)
		{
			Vector3 a = effector.position - (arm.nodes[0].transform.position + offset);
			float num = arm.nodes[0].length + arm.nodes[1].length;
			float magnitude = a.magnitude;
			if (magnitude < num)
			{
				return Vector3.zero;
			}
			float d = magnitude - num;
			return a / magnitude * d;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0002A898 File Offset: 0x00028A98
		protected override void ApplyBendConstraints()
		{
			if (this.iterations > 0)
			{
				this.chain[1].bendConstraint.rotationOffset = this.leftHandEffector.planeRotationOffset;
				this.chain[2].bendConstraint.rotationOffset = this.rightHandEffector.planeRotationOffset;
				this.chain[3].bendConstraint.rotationOffset = this.leftFootEffector.planeRotationOffset;
				this.chain[4].bendConstraint.rotationOffset = this.rightFootEffector.planeRotationOffset;
			}
			else
			{
				this.offset = Vector3.Lerp(this.effectors[0].positionOffset, this.effectors[0].position - (this.effectors[0].bone.position + this.effectors[0].positionOffset), this.effectors[0].positionWeight);
				for (int i = 0; i < 5; i++)
				{
					this.effectors[i].GetNode(this).solverPosition += this.offset;
				}
			}
			base.ApplyBendConstraints();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0002A9B8 File Offset: 0x00028BB8
		protected override void WritePose()
		{
			if (this.iterations == 0)
			{
				this.spineMapping.spineBones[0].position += this.offset;
			}
			base.WritePose();
		}

		// Token: 0x04000607 RID: 1543
		public Transform rootNode;

		// Token: 0x04000608 RID: 1544
		[Range(0f, 1f)]
		public float spineStiffness = 0.5f;

		// Token: 0x04000609 RID: 1545
		[Range(-1f, 1f)]
		public float pullBodyVertical = 0.5f;

		// Token: 0x0400060A RID: 1546
		[Range(-1f, 1f)]
		public float pullBodyHorizontal;

		// Token: 0x0400060C RID: 1548
		private Vector3 offset;
	}
}
