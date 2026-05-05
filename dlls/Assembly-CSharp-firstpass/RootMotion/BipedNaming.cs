using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200001D RID: 29
	public static class BipedNaming
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00004CB4 File Offset: 0x00002EB4
		public static Transform[] GetBonesOfType(BipedNaming.BoneType boneType, Transform[] bones)
		{
			Transform[] array = new Transform[0];
			foreach (Transform transform in bones)
			{
				if (transform != null && BipedNaming.GetBoneType(transform.name) == boneType)
				{
					Array.Resize<Transform>(ref array, array.Length + 1);
					array[array.Length - 1] = transform;
				}
			}
			return array;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004D08 File Offset: 0x00002F08
		public static Transform[] GetBonesOfSide(BipedNaming.BoneSide boneSide, Transform[] bones)
		{
			Transform[] array = new Transform[0];
			foreach (Transform transform in bones)
			{
				if (transform != null && BipedNaming.GetBoneSide(transform.name) == boneSide)
				{
					Array.Resize<Transform>(ref array, array.Length + 1);
					array[array.Length - 1] = transform;
				}
			}
			return array;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004D5C File Offset: 0x00002F5C
		public static Transform[] GetBonesOfTypeAndSide(BipedNaming.BoneType boneType, BipedNaming.BoneSide boneSide, Transform[] bones)
		{
			Transform[] bonesOfType = BipedNaming.GetBonesOfType(boneType, bones);
			return BipedNaming.GetBonesOfSide(boneSide, bonesOfType);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004D78 File Offset: 0x00002F78
		public static Transform GetFirstBoneOfTypeAndSide(BipedNaming.BoneType boneType, BipedNaming.BoneSide boneSide, Transform[] bones)
		{
			Transform[] bonesOfTypeAndSide = BipedNaming.GetBonesOfTypeAndSide(boneType, boneSide, bones);
			if (bonesOfTypeAndSide.Length == 0)
			{
				return null;
			}
			return bonesOfTypeAndSide[0];
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004D98 File Offset: 0x00002F98
		public static Transform GetNamingMatch(Transform[] transforms, params string[][] namings)
		{
			foreach (Transform transform in transforms)
			{
				bool flag = true;
				foreach (string[] namingConvention in namings)
				{
					if (!BipedNaming.matchesNaming(transform.name, namingConvention))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return transform;
				}
			}
			return null;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004DF1 File Offset: 0x00002FF1
		public static BipedNaming.BoneType GetBoneType(string boneName)
		{
			if (BipedNaming.isSpine(boneName))
			{
				return BipedNaming.BoneType.Spine;
			}
			if (BipedNaming.isHead(boneName))
			{
				return BipedNaming.BoneType.Head;
			}
			if (BipedNaming.isArm(boneName))
			{
				return BipedNaming.BoneType.Arm;
			}
			if (BipedNaming.isLeg(boneName))
			{
				return BipedNaming.BoneType.Leg;
			}
			if (BipedNaming.isTail(boneName))
			{
				return BipedNaming.BoneType.Tail;
			}
			if (BipedNaming.isEye(boneName))
			{
				return BipedNaming.BoneType.Eye;
			}
			return BipedNaming.BoneType.Unassigned;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004E30 File Offset: 0x00003030
		public static BipedNaming.BoneSide GetBoneSide(string boneName)
		{
			if (BipedNaming.isLeft(boneName))
			{
				return BipedNaming.BoneSide.Left;
			}
			if (BipedNaming.isRight(boneName))
			{
				return BipedNaming.BoneSide.Right;
			}
			return BipedNaming.BoneSide.Center;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004E47 File Offset: 0x00003047
		public static Transform GetBone(Transform[] transforms, BipedNaming.BoneType boneType, BipedNaming.BoneSide boneSide = BipedNaming.BoneSide.Center, params string[][] namings)
		{
			return BipedNaming.GetNamingMatch(BipedNaming.GetBonesOfTypeAndSide(boneType, boneSide, transforms), namings);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004E57 File Offset: 0x00003057
		private static bool isLeft(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeLeft) || BipedNaming.lastLetter(boneName) == "L" || BipedNaming.firstLetter(boneName) == "L";
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004E8A File Offset: 0x0000308A
		private static bool isRight(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeRight) || BipedNaming.lastLetter(boneName) == "R" || BipedNaming.firstLetter(boneName) == "R";
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004EBD File Offset: 0x000030BD
		private static bool isSpine(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeSpine) && !BipedNaming.excludesNaming(boneName, BipedNaming.typeExcludeSpine);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004EDC File Offset: 0x000030DC
		private static bool isHead(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeHead) && !BipedNaming.excludesNaming(boneName, BipedNaming.typeExcludeHead);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004EFB File Offset: 0x000030FB
		private static bool isArm(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeArm) && !BipedNaming.excludesNaming(boneName, BipedNaming.typeExcludeArm);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004F1A File Offset: 0x0000311A
		private static bool isLeg(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeLeg) && !BipedNaming.excludesNaming(boneName, BipedNaming.typeExcludeLeg);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004F39 File Offset: 0x00003139
		private static bool isTail(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeTail) && !BipedNaming.excludesNaming(boneName, BipedNaming.typeExcludeTail);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004F58 File Offset: 0x00003158
		private static bool isEye(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeEye) && !BipedNaming.excludesNaming(boneName, BipedNaming.typeExcludeEye);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004F77 File Offset: 0x00003177
		private static bool isTypeExclude(string boneName)
		{
			return BipedNaming.matchesNaming(boneName, BipedNaming.typeExclude);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004F84 File Offset: 0x00003184
		private static bool matchesNaming(string boneName, string[] namingConvention)
		{
			if (BipedNaming.excludesNaming(boneName, BipedNaming.typeExclude))
			{
				return false;
			}
			foreach (string value in namingConvention)
			{
				if (boneName.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004FC0 File Offset: 0x000031C0
		private static bool excludesNaming(string boneName, string[] namingConvention)
		{
			foreach (string value in namingConvention)
			{
				if (boneName.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004FF0 File Offset: 0x000031F0
		private static bool matchesLastLetter(string boneName, string[] namingConvention)
		{
			foreach (string letter in namingConvention)
			{
				if (BipedNaming.LastLetterIs(boneName, letter))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000501D File Offset: 0x0000321D
		private static bool LastLetterIs(string boneName, string letter)
		{
			return boneName.Substring(boneName.Length - 1, 1) == letter;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00005034 File Offset: 0x00003234
		private static string firstLetter(string boneName)
		{
			if (boneName.Length > 0)
			{
				return boneName.Substring(0, 1);
			}
			return "";
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000504D File Offset: 0x0000324D
		private static string lastLetter(string boneName)
		{
			if (boneName.Length > 0)
			{
				return boneName.Substring(boneName.Length - 1, 1);
			}
			return "";
		}

		// Token: 0x040000B5 RID: 181
		public static string[] typeLeft = new string[]
		{
			" L ",
			"_L_",
			"-L-",
			" l ",
			"_l_",
			"-l-",
			"Left",
			"left",
			"CATRigL"
		};

		// Token: 0x040000B6 RID: 182
		public static string[] typeRight = new string[]
		{
			" R ",
			"_R_",
			"-R-",
			" r ",
			"_r_",
			"-r-",
			"Right",
			"right",
			"CATRigR"
		};

		// Token: 0x040000B7 RID: 183
		public static string[] typeSpine = new string[]
		{
			"Spine",
			"spine",
			"Pelvis",
			"pelvis",
			"Root",
			"root",
			"Torso",
			"torso",
			"Body",
			"body",
			"Hips",
			"hips",
			"Neck",
			"neck",
			"Chest",
			"chest"
		};

		// Token: 0x040000B8 RID: 184
		public static string[] typeHead = new string[]
		{
			"Head",
			"head"
		};

		// Token: 0x040000B9 RID: 185
		public static string[] typeArm = new string[]
		{
			"Arm",
			"arm",
			"Hand",
			"hand",
			"Wrist",
			"Wrist",
			"Elbow",
			"elbow",
			"Palm",
			"palm"
		};

		// Token: 0x040000BA RID: 186
		public static string[] typeLeg = new string[]
		{
			"Leg",
			"leg",
			"Thigh",
			"thigh",
			"Calf",
			"calf",
			"Femur",
			"femur",
			"Knee",
			"knee",
			"Foot",
			"foot",
			"Ankle",
			"ankle",
			"Hip",
			"hip"
		};

		// Token: 0x040000BB RID: 187
		public static string[] typeTail = new string[]
		{
			"Tail",
			"tail"
		};

		// Token: 0x040000BC RID: 188
		public static string[] typeEye = new string[]
		{
			"Eye",
			"eye"
		};

		// Token: 0x040000BD RID: 189
		public static string[] typeExclude = new string[]
		{
			"Nub",
			"Dummy",
			"dummy",
			"Tip",
			"IK",
			"Mesh"
		};

		// Token: 0x040000BE RID: 190
		public static string[] typeExcludeSpine = new string[]
		{
			"Head",
			"head"
		};

		// Token: 0x040000BF RID: 191
		public static string[] typeExcludeHead = new string[]
		{
			"Top",
			"End"
		};

		// Token: 0x040000C0 RID: 192
		public static string[] typeExcludeArm = new string[]
		{
			"Collar",
			"collar",
			"Clavicle",
			"clavicle",
			"Finger",
			"finger",
			"Index",
			"index",
			"Mid",
			"mid",
			"Pinky",
			"pinky",
			"Ring",
			"Thumb",
			"thumb",
			"Adjust",
			"adjust",
			"Twist",
			"twist"
		};

		// Token: 0x040000C1 RID: 193
		public static string[] typeExcludeLeg = new string[]
		{
			"Toe",
			"toe",
			"Platform",
			"Adjust",
			"adjust",
			"Twist",
			"twist"
		};

		// Token: 0x040000C2 RID: 194
		public static string[] typeExcludeTail = new string[0];

		// Token: 0x040000C3 RID: 195
		public static string[] typeExcludeEye = new string[]
		{
			"Lid",
			"lid",
			"Brow",
			"brow",
			"Lash",
			"lash"
		};

		// Token: 0x040000C4 RID: 196
		public static string[] pelvis = new string[]
		{
			"Pelvis",
			"pelvis",
			"Hip",
			"hip"
		};

		// Token: 0x040000C5 RID: 197
		public static string[] hand = new string[]
		{
			"Hand",
			"hand",
			"Wrist",
			"wrist",
			"Palm",
			"palm"
		};

		// Token: 0x040000C6 RID: 198
		public static string[] foot = new string[]
		{
			"Foot",
			"foot",
			"Ankle",
			"ankle"
		};

		// Token: 0x0200001E RID: 30
		[Serializable]
		public enum BoneType
		{
			// Token: 0x040000C8 RID: 200
			Unassigned,
			// Token: 0x040000C9 RID: 201
			Spine,
			// Token: 0x040000CA RID: 202
			Head,
			// Token: 0x040000CB RID: 203
			Arm,
			// Token: 0x040000CC RID: 204
			Leg,
			// Token: 0x040000CD RID: 205
			Tail,
			// Token: 0x040000CE RID: 206
			Eye
		}

		// Token: 0x0200001F RID: 31
		[Serializable]
		public enum BoneSide
		{
			// Token: 0x040000D0 RID: 208
			Center,
			// Token: 0x040000D1 RID: 209
			Left,
			// Token: 0x040000D2 RID: 210
			Right
		}
	}
}
