using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000164 RID: 356
	[NativeHeader("Runtime/Graphics/LineRenderer.h")]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public sealed class LineRenderer : Renderer
	{
		// Token: 0x06000BD5 RID: 3029 RVA: 0x00012097 File Offset: 0x00010297
		[Obsolete("Use startWidth, endWidth or widthCurve instead.", false)]
		public void SetWidth(float start, float end)
		{
			this.startWidth = start;
			this.endWidth = end;
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000120AA File Offset: 0x000102AA
		[Obsolete("Use startColor, endColor or colorGradient instead.", false)]
		public void SetColors(Color start, Color end)
		{
			this.startColor = start;
			this.endColor = end;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x000120BD File Offset: 0x000102BD
		[Obsolete("Use positionCount instead.", false)]
		public void SetVertexCount(int count)
		{
			this.positionCount = count;
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x000120C8 File Offset: 0x000102C8
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x000120BD File Offset: 0x000102BD
		[Obsolete("Use positionCount instead (UnityUpgradable) -> positionCount", false)]
		public int numPositions
		{
			get
			{
				return this.positionCount;
			}
			set
			{
				this.positionCount = value;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000BDA RID: 3034
		// (set) Token: 0x06000BDB RID: 3035
		public extern float startWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000BDC RID: 3036
		// (set) Token: 0x06000BDD RID: 3037
		public extern float endWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000BDE RID: 3038
		// (set) Token: 0x06000BDF RID: 3039
		public extern float widthMultiplier { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000BE0 RID: 3040
		// (set) Token: 0x06000BE1 RID: 3041
		public extern int numCornerVertices { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000BE2 RID: 3042
		// (set) Token: 0x06000BE3 RID: 3043
		public extern int numCapVertices { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000BE4 RID: 3044
		// (set) Token: 0x06000BE5 RID: 3045
		public extern bool useWorldSpace { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000BE6 RID: 3046
		// (set) Token: 0x06000BE7 RID: 3047
		public extern bool loop { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x000120E0 File Offset: 0x000102E0
		// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x000120F6 File Offset: 0x000102F6
		public Color startColor
		{
			get
			{
				Color result;
				this.get_startColor_Injected(out result);
				return result;
			}
			set
			{
				this.set_startColor_Injected(ref value);
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x00012100 File Offset: 0x00010300
		// (set) Token: 0x06000BEB RID: 3051 RVA: 0x00012116 File Offset: 0x00010316
		public Color endColor
		{
			get
			{
				Color result;
				this.get_endColor_Injected(out result);
				return result;
			}
			set
			{
				this.set_endColor_Injected(ref value);
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000BEC RID: 3052
		// (set) Token: 0x06000BED RID: 3053
		[NativeProperty("PositionsCount")]
		public extern int positionCount { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000BEE RID: 3054 RVA: 0x00012120 File Offset: 0x00010320
		public void SetPosition(int index, Vector3 position)
		{
			this.SetPosition_Injected(index, ref position);
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0001212C File Offset: 0x0001032C
		public Vector3 GetPosition(int index)
		{
			Vector3 result;
			this.GetPosition_Injected(index, out result);
			return result;
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x00012144 File Offset: 0x00010344
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x0001215A File Offset: 0x0001035A
		public Vector2 textureScale
		{
			get
			{
				Vector2 result;
				this.get_textureScale_Injected(out result);
				return result;
			}
			set
			{
				this.set_textureScale_Injected(ref value);
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000BF2 RID: 3058
		// (set) Token: 0x06000BF3 RID: 3059
		public extern float shadowBias { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000BF4 RID: 3060
		// (set) Token: 0x06000BF5 RID: 3061
		public extern bool generateLightingData { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000BF6 RID: 3062
		// (set) Token: 0x06000BF7 RID: 3063
		public extern LineTextureMode textureMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000BF8 RID: 3064
		// (set) Token: 0x06000BF9 RID: 3065
		public extern LineAlignment alignment { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000BFA RID: 3066
		// (set) Token: 0x06000BFB RID: 3067
		public extern SpriteMaskInteraction maskInteraction { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000BFC RID: 3068
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Simplify(float tolerance);

		// Token: 0x06000BFD RID: 3069 RVA: 0x00012164 File Offset: 0x00010364
		public void BakeMesh(Mesh mesh, bool useTransform = false)
		{
			this.BakeMesh(mesh, Camera.main, useTransform);
		}

		// Token: 0x06000BFE RID: 3070
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void BakeMesh([NotNull("ArgumentNullException")] Mesh mesh, [NotNull("ArgumentNullException")] Camera camera, bool useTransform = false);

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x00012178 File Offset: 0x00010378
		// (set) Token: 0x06000C00 RID: 3072 RVA: 0x00012190 File Offset: 0x00010390
		public AnimationCurve widthCurve
		{
			get
			{
				return this.GetWidthCurveCopy();
			}
			set
			{
				this.SetWidthCurve(value);
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x0001219C File Offset: 0x0001039C
		// (set) Token: 0x06000C02 RID: 3074 RVA: 0x000121B4 File Offset: 0x000103B4
		public Gradient colorGradient
		{
			get
			{
				return this.GetColorGradientCopy();
			}
			set
			{
				this.SetColorGradient(value);
			}
		}

		// Token: 0x06000C03 RID: 3075
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern AnimationCurve GetWidthCurveCopy();

		// Token: 0x06000C04 RID: 3076
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetWidthCurve([NotNull("ArgumentNullException")] AnimationCurve curve);

		// Token: 0x06000C05 RID: 3077
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Gradient GetColorGradientCopy();

		// Token: 0x06000C06 RID: 3078
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetColorGradient([NotNull("ArgumentNullException")] Gradient curve);

		// Token: 0x06000C07 RID: 3079
		[FreeFunction(Name = "LineRendererScripting::GetPositions", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetPositions([NotNull("ArgumentNullException")] [Out] Vector3[] positions);

		// Token: 0x06000C08 RID: 3080
		[FreeFunction(Name = "LineRendererScripting::SetPositions", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPositions([NotNull("ArgumentNullException")] Vector3[] positions);

		// Token: 0x06000C09 RID: 3081 RVA: 0x000121BF File Offset: 0x000103BF
		public void SetPositions(NativeArray<Vector3> positions)
		{
			this.SetPositionsWithNativeContainer((IntPtr)positions.GetUnsafeReadOnlyPtr<Vector3>(), positions.Length);
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x000121DD File Offset: 0x000103DD
		public void SetPositions(NativeSlice<Vector3> positions)
		{
			this.SetPositionsWithNativeContainer((IntPtr)positions.GetUnsafeReadOnlyPtr<Vector3>(), positions.Length);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x000121FC File Offset: 0x000103FC
		public int GetPositions([Out] NativeArray<Vector3> positions)
		{
			return this.GetPositionsWithNativeContainer((IntPtr)positions.GetUnsafePtr<Vector3>(), positions.Length);
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00012228 File Offset: 0x00010428
		public int GetPositions([Out] NativeSlice<Vector3> positions)
		{
			return this.GetPositionsWithNativeContainer((IntPtr)positions.GetUnsafePtr<Vector3>(), positions.Length);
		}

		// Token: 0x06000C0D RID: 3085
		[FreeFunction(Name = "LineRendererScripting::SetPositionsWithNativeContainer", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetPositionsWithNativeContainer(IntPtr positions, int count);

		// Token: 0x06000C0E RID: 3086
		[FreeFunction(Name = "LineRendererScripting::GetPositionsWithNativeContainer", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetPositionsWithNativeContainer(IntPtr positions, int length);

		// Token: 0x06000C10 RID: 3088
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_startColor_Injected(out Color ret);

		// Token: 0x06000C11 RID: 3089
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_startColor_Injected(ref Color value);

		// Token: 0x06000C12 RID: 3090
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_endColor_Injected(out Color ret);

		// Token: 0x06000C13 RID: 3091
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_endColor_Injected(ref Color value);

		// Token: 0x06000C14 RID: 3092
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetPosition_Injected(int index, ref Vector3 position);

		// Token: 0x06000C15 RID: 3093
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetPosition_Injected(int index, out Vector3 ret);

		// Token: 0x06000C16 RID: 3094
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_textureScale_Injected(out Vector2 ret);

		// Token: 0x06000C17 RID: 3095
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_textureScale_Injected(ref Vector2 value);
	}
}
