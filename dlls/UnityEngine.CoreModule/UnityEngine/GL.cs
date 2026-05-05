using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine
{
	// Token: 0x0200014C RID: 332
	[NativeHeader("Runtime/Camera/Camera.h")]
	[NativeHeader("Runtime/GfxDevice/GfxDevice.h")]
	[StaticAccessor("GetGfxDevice()", StaticAccessorType.Dot)]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[NativeHeader("Runtime/Camera/CameraUtil.h")]
	public sealed class GL
	{
		// Token: 0x06000A3E RID: 2622
		[NativeName("ImmediateVertex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Vertex3(float x, float y, float z);

		// Token: 0x06000A3F RID: 2623 RVA: 0x00010F80 File Offset: 0x0000F180
		public static void Vertex(Vector3 v)
		{
			GL.Vertex3(v.x, v.y, v.z);
		}

		// Token: 0x06000A40 RID: 2624
		[NativeName("ImmediateVertices")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern void Vertices(Vector3* v, Vector3* coords, Vector4* colors, int length);

		// Token: 0x06000A41 RID: 2625
		[NativeName("ImmediateTexCoordAll")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void TexCoord3(float x, float y, float z);

		// Token: 0x06000A42 RID: 2626 RVA: 0x00010F9B File Offset: 0x0000F19B
		public static void TexCoord(Vector3 v)
		{
			GL.TexCoord3(v.x, v.y, v.z);
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00010FB6 File Offset: 0x0000F1B6
		public static void TexCoord2(float x, float y)
		{
			GL.TexCoord3(x, y, 0f);
		}

		// Token: 0x06000A44 RID: 2628
		[NativeName("ImmediateTexCoord")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void MultiTexCoord3(int unit, float x, float y, float z);

		// Token: 0x06000A45 RID: 2629 RVA: 0x00010FC6 File Offset: 0x0000F1C6
		public static void MultiTexCoord(int unit, Vector3 v)
		{
			GL.MultiTexCoord3(unit, v.x, v.y, v.z);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00010FE2 File Offset: 0x0000F1E2
		public static void MultiTexCoord2(int unit, float x, float y)
		{
			GL.MultiTexCoord3(unit, x, y, 0f);
		}

		// Token: 0x06000A47 RID: 2631
		[NativeName("ImmediateColor")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ImmediateColor(float r, float g, float b, float a);

		// Token: 0x06000A48 RID: 2632 RVA: 0x00010FF3 File Offset: 0x0000F1F3
		public static void Color(Color c)
		{
			GL.ImmediateColor(c.r, c.g, c.b, c.a);
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000A49 RID: 2633
		// (set) Token: 0x06000A4A RID: 2634
		public static extern bool wireframe { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000A4B RID: 2635
		// (set) Token: 0x06000A4C RID: 2636
		public static extern bool sRGBWrite { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000A4D RID: 2637
		// (set) Token: 0x06000A4E RID: 2638
		[NativeProperty("UserBackfaceMode")]
		public static extern bool invertCulling { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000A4F RID: 2639
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Flush();

		// Token: 0x06000A50 RID: 2640
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void RenderTargetBarrier();

		// Token: 0x06000A51 RID: 2641 RVA: 0x00011014 File Offset: 0x0000F214
		private static Matrix4x4 GetWorldViewMatrix()
		{
			Matrix4x4 result;
			GL.GetWorldViewMatrix_Injected(out result);
			return result;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00011029 File Offset: 0x0000F229
		private static void SetViewMatrix(Matrix4x4 m)
		{
			GL.SetViewMatrix_Injected(ref m);
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00011034 File Offset: 0x0000F234
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x0001104B File Offset: 0x0000F24B
		public static Matrix4x4 modelview
		{
			get
			{
				return GL.GetWorldViewMatrix();
			}
			set
			{
				GL.SetViewMatrix(value);
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00011055 File Offset: 0x0000F255
		[NativeName("SetWorldMatrix")]
		public static void MultMatrix(Matrix4x4 m)
		{
			GL.MultMatrix_Injected(ref m);
		}

		// Token: 0x06000A56 RID: 2646
		[NativeName("InsertCustomMarker")]
		[Obsolete("IssuePluginEvent(eventID) is deprecated. Use IssuePluginEvent(callback, eventID) instead.", false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void IssuePluginEvent(int eventID);

		// Token: 0x06000A57 RID: 2647
		[Obsolete("SetRevertBackfacing(revertBackFaces) is deprecated. Use invertCulling property instead. (UnityUpgradable) -> invertCulling", false)]
		[NativeName("SetUserBackfaceMode")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetRevertBackfacing(bool revertBackFaces);

		// Token: 0x06000A58 RID: 2648
		[FreeFunction("GLPushMatrixScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void PushMatrix();

		// Token: 0x06000A59 RID: 2649
		[FreeFunction("GLPopMatrixScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void PopMatrix();

		// Token: 0x06000A5A RID: 2650
		[FreeFunction("GLLoadIdentityScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void LoadIdentity();

		// Token: 0x06000A5B RID: 2651
		[FreeFunction("GLLoadOrthoScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void LoadOrtho();

		// Token: 0x06000A5C RID: 2652
		[FreeFunction("GLLoadPixelMatrixScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void LoadPixelMatrix();

		// Token: 0x06000A5D RID: 2653 RVA: 0x0001105E File Offset: 0x0000F25E
		[FreeFunction("GLLoadProjectionMatrixScript")]
		public static void LoadProjectionMatrix(Matrix4x4 mat)
		{
			GL.LoadProjectionMatrix_Injected(ref mat);
		}

		// Token: 0x06000A5E RID: 2654
		[FreeFunction("GLInvalidateState")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void InvalidateState();

		// Token: 0x06000A5F RID: 2655 RVA: 0x00011068 File Offset: 0x0000F268
		[FreeFunction("GLGetGPUProjectionMatrix")]
		public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture)
		{
			Matrix4x4 result;
			GL.GetGPUProjectionMatrix_Injected(ref proj, renderIntoTexture, out result);
			return result;
		}

		// Token: 0x06000A60 RID: 2656
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GLLoadPixelMatrixScript(float left, float right, float bottom, float top);

		// Token: 0x06000A61 RID: 2657 RVA: 0x00011080 File Offset: 0x0000F280
		public static void LoadPixelMatrix(float left, float right, float bottom, float top)
		{
			GL.GLLoadPixelMatrixScript(left, right, bottom, top);
		}

		// Token: 0x06000A62 RID: 2658
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GLIssuePluginEvent(IntPtr callback, int eventID);

		// Token: 0x06000A63 RID: 2659 RVA: 0x00011090 File Offset: 0x0000F290
		public static void IssuePluginEvent(IntPtr callback, int eventID)
		{
			bool flag = callback == IntPtr.Zero;
			if (flag)
			{
				throw new ArgumentException("Null callback specified.", "callback");
			}
			GL.GLIssuePluginEvent(callback, eventID);
		}

		// Token: 0x06000A64 RID: 2660
		[FreeFunction("GLBegin", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Begin(int mode);

		// Token: 0x06000A65 RID: 2661
		[FreeFunction("GLEnd")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void End();

		// Token: 0x06000A66 RID: 2662 RVA: 0x000110C5 File Offset: 0x0000F2C5
		[FreeFunction]
		private static void GLClear(bool clearDepth, bool clearColor, Color backgroundColor, float depth)
		{
			GL.GLClear_Injected(clearDepth, clearColor, ref backgroundColor, depth);
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x000110D1 File Offset: 0x0000F2D1
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, [DefaultValue("1.0f")] float depth)
		{
			GL.GLClear(clearDepth, clearColor, backgroundColor, depth);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x000110DE File Offset: 0x0000F2DE
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor)
		{
			GL.GLClear(clearDepth, clearColor, backgroundColor, 1f);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x000110EF File Offset: 0x0000F2EF
		[FreeFunction("SetGLViewport")]
		public static void Viewport(Rect pixelRect)
		{
			GL.Viewport_Injected(ref pixelRect);
		}

		// Token: 0x06000A6A RID: 2666
		[FreeFunction("ClearWithSkybox")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ClearWithSkybox(bool clearDepth, Camera camera);

		// Token: 0x06000A6C RID: 2668
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetWorldViewMatrix_Injected(out Matrix4x4 ret);

		// Token: 0x06000A6D RID: 2669
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetViewMatrix_Injected(ref Matrix4x4 m);

		// Token: 0x06000A6E RID: 2670
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MultMatrix_Injected(ref Matrix4x4 m);

		// Token: 0x06000A6F RID: 2671
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void LoadProjectionMatrix_Injected(ref Matrix4x4 mat);

		// Token: 0x06000A70 RID: 2672
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetGPUProjectionMatrix_Injected(ref Matrix4x4 proj, bool renderIntoTexture, out Matrix4x4 ret);

		// Token: 0x06000A71 RID: 2673
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GLClear_Injected(bool clearDepth, bool clearColor, ref Color backgroundColor, float depth);

		// Token: 0x06000A72 RID: 2674
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Viewport_Injected(ref Rect pixelRect);

		// Token: 0x04000429 RID: 1065
		public const int TRIANGLES = 4;

		// Token: 0x0400042A RID: 1066
		public const int TRIANGLE_STRIP = 5;

		// Token: 0x0400042B RID: 1067
		public const int QUADS = 7;

		// Token: 0x0400042C RID: 1068
		public const int LINES = 1;

		// Token: 0x0400042D RID: 1069
		public const int LINE_STRIP = 2;
	}
}
