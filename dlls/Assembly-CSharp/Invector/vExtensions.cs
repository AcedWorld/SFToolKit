using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Invector
{
	// Token: 0x0200037F RID: 895
	public static class vExtensions
	{
		// Token: 0x06001218 RID: 4632 RVA: 0x00060448 File Offset: 0x0005E648
		public static string InsertSpaceBeforeUpperCase(this string input)
		{
			string text = "";
			foreach (char c in input)
			{
				if (char.IsUpper(c) && !string.IsNullOrEmpty(text))
				{
					text += " ";
				}
				text += c.ToString();
			}
			return text;
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x000604A1 File Offset: 0x0005E6A1
		public static string RemoveUnderline(this string input)
		{
			return input.Replace("_", "");
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x000604B3 File Offset: 0x0005E6B3
		public static string ToClearUpper(this string target)
		{
			return target.Replace(" ", string.Empty).ToUpper();
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x000604CA File Offset: 0x0005E6CA
		public static bool IsInSideRange(this float value, float min, float max)
		{
			return value >= min && value <= max;
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x000604D9 File Offset: 0x0005E6D9
		public static bool IsInSideRange(this float value, Vector2 minMaxRange)
		{
			return value >= minMaxRange.x && value <= minMaxRange.y;
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x000604F2 File Offset: 0x0005E6F2
		public static bool IsVectorNaN(this Vector3 vector)
		{
			return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z);
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x0006051C File Offset: 0x0005E71C
		public static Vector3[] MakeSmoothCurve(this Vector3[] pts, float smoothFactor = 0.25f)
		{
			smoothFactor = Mathf.Clamp(smoothFactor, 0.1f, 0.9f);
			Vector3[] array = new Vector3[(pts.Length - 2) * 2 + 2];
			try
			{
				array[0] = pts[0];
				array[array.Length - 1] = pts[pts.Length - 1];
				int num = 1;
				for (int i = 0; i < pts.Length - 2; i++)
				{
					array[num] = pts[i] + (pts[i + 1] - pts[i]) * (1f - smoothFactor);
					array[num + 1] = pts[i + 1] + (pts[i + 2] - pts[i + 1]) * smoothFactor;
					num += 2;
				}
			}
			catch
			{
				array = pts;
			}
			return array;
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x00060604 File Offset: 0x0005E804
		public static float GetLenght(this NavMeshPath path)
		{
			float num = 0f;
			if (path != null && path.corners.Length > 1)
			{
				Vector3 a = path.corners[0];
				for (int i = 1; i < path.corners.Length; i++)
				{
					num += Vector3.Distance(a, path.corners[i]);
					a = path.corners[i];
				}
			}
			return num;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00060668 File Offset: 0x0005E868
		public static List<Vector3> MakeSmoothCurve(this List<Vector3> pts, float smoothFactor = 0.25f)
		{
			smoothFactor = Mathf.Clamp(smoothFactor, 0.1f, 0.9f);
			List<Vector3> list = new List<Vector3>((pts.Count - 2) * 2 + 2);
			try
			{
				list[0] = pts[0];
				list[list.Count - 1] = pts[pts.Count - 1];
				int num = 1;
				for (int i = 0; i < pts.Count - 2; i++)
				{
					list[num] = pts[i] + (pts[i + 1] - pts[i]) * (1f - smoothFactor);
					list[num + 1] = pts[i + 1] + (pts[i + 2] - pts[i + 1]) * smoothFactor;
					num += 2;
				}
			}
			catch
			{
				list = pts;
			}
			return list;
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x0006075C File Offset: 0x0005E95C
		public static Vector3[] MakeSmoothCurveArray(this List<Vector3> pts, float smoothFactor = 0.25f)
		{
			smoothFactor = Mathf.Clamp(smoothFactor, 0.1f, 0.9f);
			Vector3[] array = new Vector3[(pts.Count - 2) * 2 + 2];
			try
			{
				array[0] = pts[0];
				array[array.Length - 1] = pts[pts.Count - 1];
				int num = 1;
				for (int i = 0; i < pts.Count - 2; i++)
				{
					array[num] = pts[i] + (pts[i + 1] - pts[i]) * (1f - smoothFactor);
					array[num + 1] = pts[i + 1] + (pts[i + 2] - pts[i + 1]) * smoothFactor;
					num += 2;
				}
			}
			catch
			{
				array = pts.vToArray<Vector3>();
			}
			return array;
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x00060854 File Offset: 0x0005EA54
		public static void SetLayerRecursively(this GameObject obj, int layer)
		{
			obj.layer = layer;
			foreach (object obj2 in obj.transform)
			{
				((Transform)obj2).gameObject.SetLayerRecursively(layer);
			}
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x000608B8 File Offset: 0x0005EAB8
		public static bool ContainsLayer(this LayerMask layermask, int layer)
		{
			return layermask == (layermask | 1 << layer);
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x000608D0 File Offset: 0x0005EAD0
		public static void SetActiveChildren(this GameObject gameObjet, bool value)
		{
			foreach (object obj in gameObjet.transform)
			{
				((Transform)obj).gameObject.SetActive(value);
			}
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x0006092C File Offset: 0x0005EB2C
		public static bool isChild(this Transform me, Transform target)
		{
			if (!target)
			{
				return false;
			}
			string name = target.gameObject.name;
			Transform transform = me.FindChildByNameRecursive(name);
			return !(transform == null) && transform.Equals(target);
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x0006096C File Offset: 0x0005EB6C
		private static Transform FindChildByNameRecursive(this Transform me, string name)
		{
			if (me.name == name)
			{
				return me;
			}
			for (int i = 0; i < me.childCount; i++)
			{
				Transform transform = me.GetChild(i).FindChildByNameRecursive(name);
				if (transform != null)
				{
					return transform;
				}
			}
			return null;
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x000609B4 File Offset: 0x0005EBB4
		public static Vector3 NormalizeAngle(this Vector3 eulerAngle)
		{
			Vector3 vector = eulerAngle;
			if (vector.x > 180f)
			{
				vector.x -= 360f;
			}
			else if (vector.x < -180f)
			{
				vector.x += 360f;
			}
			if (vector.y > 180f)
			{
				vector.y -= 360f;
			}
			else if (vector.y < -180f)
			{
				vector.y += 360f;
			}
			if (vector.z > 180f)
			{
				vector.z -= 360f;
			}
			else if (vector.z < -180f)
			{
				vector.z += 360f;
			}
			return new Vector3(vector.x, vector.y, vector.z);
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x00060A8E File Offset: 0x0005EC8E
		public static Vector3 Difference(this Vector3 vector, Vector3 otherVector)
		{
			return otherVector - vector;
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x00060A98 File Offset: 0x0005EC98
		public static Vector3 AngleFormOtherDirection(this Vector3 directionA, Vector3 directionB)
		{
			return Quaternion.LookRotation(directionA).eulerAngles.AngleFormOtherEuler(Quaternion.LookRotation(directionB).eulerAngles);
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00060AC8 File Offset: 0x0005ECC8
		public static Vector3 AngleFormOtherDirection(this Vector3 directionA, Vector3 directionB, Vector3 up)
		{
			return Quaternion.LookRotation(directionA, up).eulerAngles.AngleFormOtherEuler(Quaternion.LookRotation(directionB, up).eulerAngles);
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00060AF8 File Offset: 0x0005ECF8
		public static Vector3 AngleFormOtherEuler(this Vector3 eulerA, Vector3 eulerB)
		{
			return eulerA.NormalizeAngle().Difference(eulerB.NormalizeAngle()).NormalizeAngle();
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x00060B10 File Offset: 0x0005ED10
		public static string ToStringColor(this bool value)
		{
			if (value)
			{
				return "<color=green>YES</color>";
			}
			return "<color=red>NO</color>";
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x00060B20 File Offset: 0x0005ED20
		public static float ClampAngle(float angle, float min, float max)
		{
			do
			{
				if (angle < -360f)
				{
					angle += 360f;
				}
				if (angle > 360f)
				{
					angle -= 360f;
				}
			}
			while (angle < -360f || angle > 360f);
			return Mathf.Clamp(angle, min, max);
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x00060B5C File Offset: 0x0005ED5C
		public static T[] Append<T>(this T[] arrayInitial, T[] arrayToAppend)
		{
			if (arrayToAppend == null)
			{
				throw new ArgumentNullException("The appended object cannot be null");
			}
			if (arrayInitial is string || arrayToAppend is string)
			{
				throw new ArgumentException("The argument must be an enumerable");
			}
			T[] array = new T[arrayInitial.Length + arrayToAppend.Length];
			arrayInitial.CopyTo(array, 0);
			arrayToAppend.CopyTo(array, arrayInitial.Length);
			return array;
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x00060BB4 File Offset: 0x0005EDB4
		public static List<T> vCopy<T>(this List<T> list)
		{
			List<T> list2 = new List<T>();
			if (list == null || list.Count == 0)
			{
				return list;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list2.Add(list[i]);
			}
			return list2;
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x00060BF4 File Offset: 0x0005EDF4
		public static List<T> vToList<T>(this T[] array)
		{
			List<T> list = new List<T>();
			if (array == null || array.Length == 0)
			{
				return list;
			}
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			return list;
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00060C2C File Offset: 0x0005EE2C
		public static T[] vToArray<T>(this List<T> list)
		{
			T[] array = new T[list.Count];
			if (list == null || list.Count == 0)
			{
				return array;
			}
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x00060C74 File Offset: 0x0005EE74
		public static Vector3 BoxSize(this BoxCollider boxCollider)
		{
			float x = boxCollider.transform.lossyScale.x * boxCollider.size.x;
			float z = boxCollider.transform.lossyScale.z * boxCollider.size.z;
			float y = boxCollider.transform.lossyScale.y * boxCollider.size.y;
			return new Vector3(x, y, z);
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x00060CE0 File Offset: 0x0005EEE0
		public static bool IsClosed(this BoxCollider boxCollider, Vector3 position, Vector3 margin, Vector3 centerOffset)
		{
			Vector3 vector = boxCollider.BoxSize();
			float x = margin.x;
			float y = margin.y;
			float z = margin.z;
			Vector3 vector2 = boxCollider.center + centerOffset;
			Vector2 minMaxRange = new Vector2(vector2.x - vector.x * 0.5f - x, vector2.x + vector.x * 0.5f + x);
			Vector2 minMaxRange2 = new Vector2(vector2.y - vector.y * 0.5f - y, vector2.y + vector.y * 0.5f + y);
			Vector2 minMaxRange3 = new Vector2(vector2.z - vector.z * 0.5f - z, vector2.z + vector.z * 0.5f + z);
			position = boxCollider.transform.InverseTransformPoint(position);
			bool flag = (position.x * boxCollider.transform.lossyScale.x).IsInSideRange(minMaxRange);
			bool flag2 = (position.y * boxCollider.transform.lossyScale.y).IsInSideRange(minMaxRange2);
			bool flag3 = (position.z * boxCollider.transform.lossyScale.z).IsInSideRange(minMaxRange3);
			return flag && flag2 && flag3;
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x00060E22 File Offset: 0x0005F022
		public static T ToEnum<T>(this string value, bool ignoreCase = true)
		{
			return (T)((object)Enum.Parse(typeof(T), value, ignoreCase));
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x00060E3C File Offset: 0x0005F03C
		public static bool Contains<T>(this Enum value, Enum lookingForFlag) where T : struct
		{
			int num = (int)value;
			int num2 = (int)lookingForFlag;
			return (num & num2) == num2;
		}
	}
}
