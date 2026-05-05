using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B8 RID: 696
	internal static class UIRUtility
	{
		// Token: 0x0600141F RID: 5151 RVA: 0x00047AF4 File Offset: 0x00045CF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ShapeWindingIsClockwise(int maskDepth, int stencilRef)
		{
			Debug.Assert(maskDepth == stencilRef || maskDepth == stencilRef + 1);
			return maskDepth == stencilRef;
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x00047B20 File Offset: 0x00045D20
		public static Vector4 ToVector4(Rect rc)
		{
			return new Vector4(rc.xMin, rc.yMin, rc.xMax, rc.yMax);
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x00047B54 File Offset: 0x00045D54
		public static bool IsRoundRect(VisualElement ve)
		{
			IResolvedStyle resolvedStyle = ve.resolvedStyle;
			return resolvedStyle.borderTopLeftRadius >= 1E-30f || resolvedStyle.borderTopRightRadius >= 1E-30f || resolvedStyle.borderBottomLeftRadius >= 1E-30f || resolvedStyle.borderBottomRightRadius >= 1E-30f;
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x00047BA8 File Offset: 0x00045DA8
		public static void Multiply2D(this Quaternion rotation, ref Vector2 point)
		{
			float num = rotation.z * 2f;
			float num2 = 1f - rotation.z * num;
			float num3 = rotation.w * num;
			point = new Vector2(num2 * point.x - num3 * point.y, num3 * point.x + num2 * point.y);
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x00047C08 File Offset: 0x00045E08
		public static bool IsVectorImageBackground(VisualElement ve)
		{
			return ve.computedStyle.backgroundImage.vectorImage != null;
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x00047C34 File Offset: 0x00045E34
		public static bool IsElementSelfHidden(VisualElement ve)
		{
			return ve.resolvedStyle.visibility == Visibility.Hidden;
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x00047C54 File Offset: 0x00045E54
		public static void Destroy(Object obj)
		{
			bool flag = obj == null;
			if (!flag)
			{
				bool isPlaying = Application.isPlaying;
				if (isPlaying)
				{
					Object.Destroy(obj);
				}
				else
				{
					Object.DestroyImmediate(obj);
				}
			}
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x00047C88 File Offset: 0x00045E88
		public static int GetPrevPow2(int n)
		{
			int num = 0;
			while (n > 1)
			{
				n >>= 1;
				num++;
			}
			return 1 << num;
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x00047CB8 File Offset: 0x00045EB8
		public static int GetNextPow2(int n)
		{
			int i;
			for (i = 1; i < n; i <<= 1)
			{
			}
			return i;
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x00047CDC File Offset: 0x00045EDC
		public static int GetNextPow2Exp(int n)
		{
			int i = 1;
			int num = 0;
			while (i < n)
			{
				i <<= 1;
				num++;
			}
			return num;
		}

		// Token: 0x0400095E RID: 2398
		public static readonly string k_DefaultShaderName = Shaders.k_Runtime;

		// Token: 0x0400095F RID: 2399
		public static readonly string k_DefaultWorldSpaceShaderName = Shaders.k_RuntimeWorld;

		// Token: 0x04000960 RID: 2400
		public const float k_Epsilon = 1E-30f;

		// Token: 0x04000961 RID: 2401
		public const float k_ClearZ = 0.99f;

		// Token: 0x04000962 RID: 2402
		public const float k_MeshPosZ = 0f;

		// Token: 0x04000963 RID: 2403
		public const float k_MaskPosZ = 1f;

		// Token: 0x04000964 RID: 2404
		public const int k_MaxMaskDepth = 7;
	}
}
