using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

namespace UnityEngine.UIElements
{
	// Token: 0x02000286 RID: 646
	[NativeHeader("ModuleOverrides/com.unity.ui/Core/Native/TextNative.bindings.h")]
	internal static class TextNative
	{
		// Token: 0x0600121F RID: 4639 RVA: 0x00040F98 File Offset: 0x0003F198
		public static Vector2 GetCursorPosition(TextNativeSettings settings, Rect rect, int cursorIndex)
		{
			bool flag = settings.font == null;
			Vector2 result;
			if (flag)
			{
				Debug.LogError("Cannot process a null font.");
				result = Vector2.zero;
			}
			else
			{
				result = TextNative.DoGetCursorPosition(settings, rect, cursorIndex);
			}
			return result;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00040FD8 File Offset: 0x0003F1D8
		public static float ComputeTextWidth(TextNativeSettings settings)
		{
			bool flag = settings.font == null;
			float result;
			if (flag)
			{
				Debug.LogError("Cannot process a null font.");
				result = 0f;
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(settings.text);
				if (flag2)
				{
					result = 0f;
				}
				else
				{
					result = TextNative.DoComputeTextWidth(settings);
				}
			}
			return result;
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x0004102C File Offset: 0x0003F22C
		public static float ComputeTextHeight(TextNativeSettings settings)
		{
			bool flag = settings.font == null;
			float result;
			if (flag)
			{
				Debug.LogError("Cannot process a null font.");
				result = 0f;
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(settings.text);
				if (flag2)
				{
					result = 0f;
				}
				else
				{
					result = TextNative.DoComputeTextHeight(settings);
				}
			}
			return result;
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x00041080 File Offset: 0x0003F280
		public static NativeArray<TextVertex> GetVertices(TextNativeSettings settings)
		{
			int num = 0;
			TextNative.GetVertices(settings, IntPtr.Zero, UnsafeUtility.SizeOf<TextVertex>(), ref num);
			NativeArray<TextVertex> nativeArray = new NativeArray<TextVertex>(num, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			bool flag = num > 0;
			if (flag)
			{
				TextNative.GetVertices(settings, (IntPtr)nativeArray.GetUnsafePtr<TextVertex>(), UnsafeUtility.SizeOf<TextVertex>(), ref num);
				Debug.Assert(num == nativeArray.Length);
			}
			return nativeArray;
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x000410E8 File Offset: 0x0003F2E8
		public static Vector2 GetOffset(TextNativeSettings settings, Rect screenRect)
		{
			bool flag = settings.font == null;
			Vector2 result;
			if (flag)
			{
				Debug.LogError("Cannot process a null font.");
				result = new Vector2(0f, 0f);
			}
			else
			{
				settings.text = (settings.text ?? "");
				result = TextNative.DoGetOffset(settings, screenRect);
			}
			return result;
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x00041148 File Offset: 0x0003F348
		public static float ComputeTextScaling(Matrix4x4 worldMatrix, float pixelsPerPoint)
		{
			Vector3 vector = new Vector3(worldMatrix.m00, worldMatrix.m10, worldMatrix.m20);
			Vector3 vector2 = new Vector3(worldMatrix.m01, worldMatrix.m11, worldMatrix.m21);
			float num = (vector.magnitude + vector2.magnitude) / 2f;
			return num * pixelsPerPoint;
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x000411A5 File Offset: 0x0003F3A5
		[FreeFunction(Name = "TextNative::ComputeTextWidth")]
		private static float DoComputeTextWidth(TextNativeSettings settings)
		{
			return TextNative.DoComputeTextWidth_Injected(ref settings);
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x000411AE File Offset: 0x0003F3AE
		[FreeFunction(Name = "TextNative::ComputeTextHeight")]
		private static float DoComputeTextHeight(TextNativeSettings settings)
		{
			return TextNative.DoComputeTextHeight_Injected(ref settings);
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x000411B8 File Offset: 0x0003F3B8
		[FreeFunction(Name = "TextNative::GetCursorPosition")]
		private static Vector2 DoGetCursorPosition(TextNativeSettings settings, Rect rect, int cursorPosition)
		{
			Vector2 result;
			TextNative.DoGetCursorPosition_Injected(ref settings, ref rect, cursorPosition, out result);
			return result;
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x000411D2 File Offset: 0x0003F3D2
		[FreeFunction(Name = "TextNative::GetVertices")]
		private static void GetVertices(TextNativeSettings settings, IntPtr buffer, int vertexSize, ref int vertexCount)
		{
			TextNative.GetVertices_Injected(ref settings, buffer, vertexSize, ref vertexCount);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x000411E0 File Offset: 0x0003F3E0
		[FreeFunction(Name = "TextNative::GetOffset")]
		private static Vector2 DoGetOffset(TextNativeSettings settings, Rect rect)
		{
			Vector2 result;
			TextNative.DoGetOffset_Injected(ref settings, ref rect, out result);
			return result;
		}

		// Token: 0x0600122A RID: 4650
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float DoComputeTextWidth_Injected(ref TextNativeSettings settings);

		// Token: 0x0600122B RID: 4651
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float DoComputeTextHeight_Injected(ref TextNativeSettings settings);

		// Token: 0x0600122C RID: 4652
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DoGetCursorPosition_Injected(ref TextNativeSettings settings, ref Rect rect, int cursorPosition, out Vector2 ret);

		// Token: 0x0600122D RID: 4653
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVertices_Injected(ref TextNativeSettings settings, IntPtr buffer, int vertexSize, ref int vertexCount);

		// Token: 0x0600122E RID: 4654
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DoGetOffset_Injected(ref TextNativeSettings settings, ref Rect rect, out Vector2 ret);
	}
}
