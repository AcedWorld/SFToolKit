using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000024 RID: 36
	public class Hierarchy
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00006544 File Offset: 0x00004744
		public static bool HierarchyIsValid(Transform[] bones)
		{
			for (int i = 1; i < bones.Length; i++)
			{
				if (!Hierarchy.IsAncestor(bones[i], bones[i - 1]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006574 File Offset: 0x00004774
		public static Object ContainsDuplicate(Object[] objects)
		{
			for (int i = 0; i < objects.Length; i++)
			{
				for (int j = 0; j < objects.Length; j++)
				{
					if (i != j && objects[i] == objects[j])
					{
						return objects[i];
					}
				}
			}
			return null;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000065B4 File Offset: 0x000047B4
		public static bool IsAncestor(Transform transform, Transform ancestor)
		{
			return transform == null || ancestor == null || (!(transform.parent == null) && (transform.parent == ancestor || Hierarchy.IsAncestor(transform.parent, ancestor)));
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006604 File Offset: 0x00004804
		public static bool ContainsChild(Transform transform, Transform child)
		{
			if (transform == child)
			{
				return true;
			}
			Transform[] componentsInChildren = transform.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i] == child)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006640 File Offset: 0x00004840
		public static void AddAncestors(Transform transform, Transform blocker, ref Transform[] array)
		{
			if (transform.parent != null && transform.parent != blocker)
			{
				if (transform.parent.position != transform.position && transform.parent.position != blocker.position)
				{
					Array.Resize<Transform>(ref array, array.Length + 1);
					array[array.Length - 1] = transform.parent;
				}
				Hierarchy.AddAncestors(transform.parent, blocker, ref array);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000066C1 File Offset: 0x000048C1
		public static Transform GetAncestor(Transform transform, int minChildCount)
		{
			if (transform == null)
			{
				return null;
			}
			if (!(transform.parent != null))
			{
				return null;
			}
			if (transform.parent.childCount >= minChildCount)
			{
				return transform.parent;
			}
			return Hierarchy.GetAncestor(transform.parent, minChildCount);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00006700 File Offset: 0x00004900
		public static Transform GetFirstCommonAncestor(Transform t1, Transform t2)
		{
			if (t1 == null)
			{
				return null;
			}
			if (t2 == null)
			{
				return null;
			}
			if (t1.parent == null)
			{
				return null;
			}
			if (t2.parent == null)
			{
				return null;
			}
			if (Hierarchy.IsAncestor(t2, t1.parent))
			{
				return t1.parent;
			}
			return Hierarchy.GetFirstCommonAncestor(t1.parent, t2);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006764 File Offset: 0x00004964
		public static Transform GetFirstCommonAncestor(Transform[] transforms)
		{
			if (transforms == null)
			{
				Debug.LogWarning("Transforms is null.");
				return null;
			}
			if (transforms.Length == 0)
			{
				Debug.LogWarning("Transforms.Length is 0.");
				return null;
			}
			for (int i = 0; i < transforms.Length; i++)
			{
				if (transforms[i] == null)
				{
					return null;
				}
				if (Hierarchy.IsCommonAncestor(transforms[i], transforms))
				{
					return transforms[i];
				}
			}
			return Hierarchy.GetFirstCommonAncestorRecursive(transforms[0], transforms);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000067C4 File Offset: 0x000049C4
		public static Transform GetFirstCommonAncestorRecursive(Transform transform, Transform[] transforms)
		{
			if (transform == null)
			{
				Debug.LogWarning("Transform is null.");
				return null;
			}
			if (transforms == null)
			{
				Debug.LogWarning("Transforms is null.");
				return null;
			}
			if (transforms.Length == 0)
			{
				Debug.LogWarning("Transforms.Length is 0.");
				return null;
			}
			if (Hierarchy.IsCommonAncestor(transform, transforms))
			{
				return transform;
			}
			if (transform.parent == null)
			{
				return null;
			}
			return Hierarchy.GetFirstCommonAncestorRecursive(transform.parent, transforms);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000682C File Offset: 0x00004A2C
		public static bool IsCommonAncestor(Transform transform, Transform[] transforms)
		{
			if (transform == null)
			{
				Debug.LogWarning("Transform is null.");
				return false;
			}
			for (int i = 0; i < transforms.Length; i++)
			{
				if (transforms[i] == null)
				{
					Debug.Log("Transforms[" + i.ToString() + "] is null.");
					return false;
				}
				if (!Hierarchy.IsAncestor(transforms[i], transform) && transforms[i] != transform)
				{
					return false;
				}
			}
			return true;
		}
	}
}
