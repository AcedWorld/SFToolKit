using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x0200002C RID: 44
[CreateAssetMenu(menuName = "Invector/SnapBody/New Body Struct")]
public class vBodyStruct : ScriptableObject
{
	// Token: 0x0600009D RID: 157 RVA: 0x00007DB9 File Offset: 0x00005FB9
	protected virtual void Reset()
	{
		this.bones.Clear();
		this.bones = vBodyStruct.GetHumanBones();
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00007DD4 File Offset: 0x00005FD4
	public static List<vBodyStruct.Bone> GetHumanBones()
	{
		List<vBodyStruct.Bone> list = new List<vBodyStruct.Bone>();
		string[] names = Enum.GetNames(typeof(HumanBodyBones));
		for (int i = 0; i < names.Length; i++)
		{
			if (!vBodyStruct.IsIgnoredBone(names[i]))
			{
				HumanBodyBones humanBone = HumanBodyBones.Chest;
				if (names[i].ToEnum(ref humanBone))
				{
					list.Add(new vBodyStruct.Bone
					{
						isHuman = true,
						name = names[i],
						genericBone = names[i],
						humanBone = humanBone
					});
				}
			}
		}
		return (from x in list
		orderby x.name.ToUpper().Contains("LEFT"), x.name.ToUpper().Contains("RIGHT")
		select x).ToList<vBodyStruct.Bone>();
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600009F RID: 159 RVA: 0x00007EA0 File Offset: 0x000060A0
	private static string[] ignoreBones
	{
		get
		{
			return new string[]
			{
				"Thumb",
				"Distal",
				"Little",
				"Middle",
				"Index",
				"Ring",
				"Eye",
				"Toes",
				"Jaw",
				"LastBone"
			};
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00007F08 File Offset: 0x00006108
	private static bool IsIgnoredBone(string bone)
	{
		bool result = false;
		for (int i = 0; i < vBodyStruct.ignoreBones.Length; i++)
		{
			if (bone.Contains(vBodyStruct.ignoreBones[i]))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x040000EA RID: 234
	public List<vBodyStruct.Bone> bones = new List<vBodyStruct.Bone>();

	// Token: 0x0200002D RID: 45
	[Serializable]
	public class Bone
	{
		// Token: 0x040000EB RID: 235
		public string name;

		// Token: 0x040000EC RID: 236
		public HumanBodyBones humanBone;

		// Token: 0x040000ED RID: 237
		public string genericBone;

		// Token: 0x040000EE RID: 238
		public bool isHuman = true;
	}
}
