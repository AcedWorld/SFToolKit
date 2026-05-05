using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x02000165 RID: 357
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[NativeHeader("Runtime/Shaders/ShaderPropertySheet.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[NativeHeader("Runtime/Math/SphericalHarmonicsL2.h")]
	public sealed class MaterialPropertyBlock
	{
		// Token: 0x06000C18 RID: 3096 RVA: 0x00012253 File Offset: 0x00010453
		[Obsolete("Use SetFloat instead (UnityUpgradable) -> SetFloat(*)", false)]
		public void AddFloat(string name, float value)
		{
			this.SetFloat(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x00012264 File Offset: 0x00010464
		[Obsolete("Use SetFloat instead (UnityUpgradable) -> SetFloat(*)", false)]
		public void AddFloat(int nameID, float value)
		{
			this.SetFloat(nameID, value);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00012270 File Offset: 0x00010470
		[Obsolete("Use SetVector instead (UnityUpgradable) -> SetVector(*)", false)]
		public void AddVector(string name, Vector4 value)
		{
			this.SetVector(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00012281 File Offset: 0x00010481
		[Obsolete("Use SetVector instead (UnityUpgradable) -> SetVector(*)", false)]
		public void AddVector(int nameID, Vector4 value)
		{
			this.SetVector(nameID, value);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0001228D File Offset: 0x0001048D
		[Obsolete("Use SetColor instead (UnityUpgradable) -> SetColor(*)", false)]
		public void AddColor(string name, Color value)
		{
			this.SetColor(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0001229E File Offset: 0x0001049E
		[Obsolete("Use SetColor instead (UnityUpgradable) -> SetColor(*)", false)]
		public void AddColor(int nameID, Color value)
		{
			this.SetColor(nameID, value);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x000122AA File Offset: 0x000104AA
		[Obsolete("Use SetMatrix instead (UnityUpgradable) -> SetMatrix(*)", false)]
		public void AddMatrix(string name, Matrix4x4 value)
		{
			this.SetMatrix(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x000122BB File Offset: 0x000104BB
		[Obsolete("Use SetMatrix instead (UnityUpgradable) -> SetMatrix(*)", false)]
		public void AddMatrix(int nameID, Matrix4x4 value)
		{
			this.SetMatrix(nameID, value);
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x000122C7 File Offset: 0x000104C7
		[Obsolete("Use SetTexture instead (UnityUpgradable) -> SetTexture(*)", false)]
		public void AddTexture(string name, Texture value)
		{
			this.SetTexture(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x000122D8 File Offset: 0x000104D8
		[Obsolete("Use SetTexture instead (UnityUpgradable) -> SetTexture(*)", false)]
		public void AddTexture(int nameID, Texture value)
		{
			this.SetTexture(nameID, value);
		}

		// Token: 0x06000C22 RID: 3106
		[NativeName("GetIntFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetIntImpl(int name);

		// Token: 0x06000C23 RID: 3107
		[ThreadSafe]
		[NativeName("GetFloatFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern float GetFloatImpl(int name);

		// Token: 0x06000C24 RID: 3108 RVA: 0x000122E4 File Offset: 0x000104E4
		[NativeName("GetVectorFromScript")]
		[ThreadSafe]
		private Vector4 GetVectorImpl(int name)
		{
			Vector4 result;
			this.GetVectorImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x000122FC File Offset: 0x000104FC
		[ThreadSafe]
		[NativeName("GetColorFromScript")]
		private Color GetColorImpl(int name)
		{
			Color result;
			this.GetColorImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00012314 File Offset: 0x00010514
		[ThreadSafe]
		[NativeName("GetMatrixFromScript")]
		private Matrix4x4 GetMatrixImpl(int name)
		{
			Matrix4x4 result;
			this.GetMatrixImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000C27 RID: 3111
		[NativeName("GetTextureFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Texture GetTextureImpl(int name);

		// Token: 0x06000C28 RID: 3112
		[NativeName("HasPropertyFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasPropertyImpl(int name);

		// Token: 0x06000C29 RID: 3113
		[NativeName("HasFloatFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasFloatImpl(int name);

		// Token: 0x06000C2A RID: 3114
		[NativeName("HasIntegerFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasIntImpl(int name);

		// Token: 0x06000C2B RID: 3115
		[NativeName("HasTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasTextureImpl(int name);

		// Token: 0x06000C2C RID: 3116
		[NativeName("HasMatrixFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasMatrixImpl(int name);

		// Token: 0x06000C2D RID: 3117
		[NativeName("HasVectorFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasVectorImpl(int name);

		// Token: 0x06000C2E RID: 3118
		[NativeName("HasBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasBufferImpl(int name);

		// Token: 0x06000C2F RID: 3119
		[NativeName("HasConstantBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasConstantBufferImpl(int name);

		// Token: 0x06000C30 RID: 3120
		[ThreadSafe]
		[NativeName("SetIntFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetIntImpl(int name, int value);

		// Token: 0x06000C31 RID: 3121
		[NativeName("SetFloatFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetFloatImpl(int name, float value);

		// Token: 0x06000C32 RID: 3122 RVA: 0x0001232B File Offset: 0x0001052B
		[ThreadSafe]
		[NativeName("SetVectorFromScript")]
		private void SetVectorImpl(int name, Vector4 value)
		{
			this.SetVectorImpl_Injected(name, ref value);
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00012336 File Offset: 0x00010536
		[NativeName("SetColorFromScript")]
		[ThreadSafe]
		private void SetColorImpl(int name, Color value)
		{
			this.SetColorImpl_Injected(name, ref value);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00012341 File Offset: 0x00010541
		[ThreadSafe]
		[NativeName("SetMatrixFromScript")]
		private void SetMatrixImpl(int name, Matrix4x4 value)
		{
			this.SetMatrixImpl_Injected(name, ref value);
		}

		// Token: 0x06000C35 RID: 3125
		[ThreadSafe]
		[NativeName("SetTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetTextureImpl(int name, [NotNull("ArgumentNullException")] Texture value);

		// Token: 0x06000C36 RID: 3126
		[ThreadSafe]
		[NativeName("SetRenderTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetRenderTextureImpl(int name, [NotNull("ArgumentNullException")] RenderTexture value, RenderTextureSubElement element);

		// Token: 0x06000C37 RID: 3127
		[ThreadSafe]
		[NativeName("SetBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetBufferImpl(int name, ComputeBuffer value);

		// Token: 0x06000C38 RID: 3128
		[ThreadSafe]
		[NativeName("SetBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetGraphicsBufferImpl(int name, GraphicsBuffer value);

		// Token: 0x06000C39 RID: 3129
		[ThreadSafe]
		[NativeName("SetConstantBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetConstantBufferImpl(int name, ComputeBuffer value, int offset, int size);

		// Token: 0x06000C3A RID: 3130
		[ThreadSafe]
		[NativeName("SetConstantBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetConstantGraphicsBufferImpl(int name, GraphicsBuffer value, int offset, int size);

		// Token: 0x06000C3B RID: 3131
		[ThreadSafe]
		[NativeName("SetFloatArrayFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetFloatArrayImpl(int name, float[] values, int count);

		// Token: 0x06000C3C RID: 3132
		[ThreadSafe]
		[NativeName("SetVectorArrayFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetVectorArrayImpl(int name, Vector4[] values, int count);

		// Token: 0x06000C3D RID: 3133
		[ThreadSafe]
		[NativeName("SetMatrixArrayFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetMatrixArrayImpl(int name, Matrix4x4[] values, int count);

		// Token: 0x06000C3E RID: 3134
		[NativeName("GetFloatArrayFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern float[] GetFloatArrayImpl(int name);

		// Token: 0x06000C3F RID: 3135
		[NativeName("GetVectorArrayFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Vector4[] GetVectorArrayImpl(int name);

		// Token: 0x06000C40 RID: 3136
		[NativeName("GetMatrixArrayFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Matrix4x4[] GetMatrixArrayImpl(int name);

		// Token: 0x06000C41 RID: 3137
		[ThreadSafe]
		[NativeName("GetFloatArrayCountFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetFloatArrayCountImpl(int name);

		// Token: 0x06000C42 RID: 3138
		[NativeName("GetVectorArrayCountFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetVectorArrayCountImpl(int name);

		// Token: 0x06000C43 RID: 3139
		[ThreadSafe]
		[NativeName("GetMatrixArrayCountFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetMatrixArrayCountImpl(int name);

		// Token: 0x06000C44 RID: 3140
		[ThreadSafe]
		[NativeName("ExtractFloatArrayFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractFloatArrayImpl(int name, [Out] float[] val);

		// Token: 0x06000C45 RID: 3141
		[NativeName("ExtractVectorArrayFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractVectorArrayImpl(int name, [Out] Vector4[] val);

		// Token: 0x06000C46 RID: 3142
		[ThreadSafe]
		[NativeName("ExtractMatrixArrayFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractMatrixArrayImpl(int name, [Out] Matrix4x4[] val);

		// Token: 0x06000C47 RID: 3143
		[FreeFunction("ConvertAndCopySHCoefficientArraysToPropertySheetFromScript")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_CopySHCoefficientArraysFrom(MaterialPropertyBlock properties, SphericalHarmonicsL2[] lightProbes, int sourceStart, int destStart, int count);

		// Token: 0x06000C48 RID: 3144
		[ThreadSafe]
		[FreeFunction("CopyProbeOcclusionArrayToPropertySheetFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_CopyProbeOcclusionArrayFrom(MaterialPropertyBlock properties, Vector4[] occlusionProbes, int sourceStart, int destStart, int count);

		// Token: 0x06000C49 RID: 3145
		[NativeMethod(Name = "MaterialPropertyBlockScripting::Create", IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreateImpl();

		// Token: 0x06000C4A RID: 3146
		[NativeMethod(Name = "MaterialPropertyBlockScripting::Destroy", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DestroyImpl(IntPtr mpb);

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000C4B RID: 3147
		public extern bool isEmpty { [NativeName("IsEmpty")] [ThreadSafe] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000C4C RID: 3148
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Clear(bool keepMemory);

		// Token: 0x06000C4D RID: 3149 RVA: 0x0001234C File Offset: 0x0001054C
		public void Clear()
		{
			this.Clear(true);
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00012358 File Offset: 0x00010558
		private void SetFloatArray(int name, float[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetFloatArrayImpl(name, values, count);
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x000123AC File Offset: 0x000105AC
		private void SetVectorArray(int name, Vector4[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetVectorArrayImpl(name, values, count);
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x00012400 File Offset: 0x00010600
		private void SetMatrixArray(int name, Matrix4x4[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetMatrixArrayImpl(name, values, count);
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00012454 File Offset: 0x00010654
		private void ExtractFloatArray(int name, List<float> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int floatArrayCountImpl = this.GetFloatArrayCountImpl(name);
			bool flag2 = floatArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<float>(values, floatArrayCountImpl);
				this.ExtractFloatArrayImpl(name, (float[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x000124AC File Offset: 0x000106AC
		private void ExtractVectorArray(int name, List<Vector4> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int vectorArrayCountImpl = this.GetVectorArrayCountImpl(name);
			bool flag2 = vectorArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<Vector4>(values, vectorArrayCountImpl);
				this.ExtractVectorArrayImpl(name, (Vector4[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00012504 File Offset: 0x00010704
		private void ExtractMatrixArray(int name, List<Matrix4x4> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int matrixArrayCountImpl = this.GetMatrixArrayCountImpl(name);
			bool flag2 = matrixArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<Matrix4x4>(values, matrixArrayCountImpl);
				this.ExtractMatrixArrayImpl(name, (Matrix4x4[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00012559 File Offset: 0x00010759
		public MaterialPropertyBlock()
		{
			this.m_Ptr = MaterialPropertyBlock.CreateImpl();
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00012570 File Offset: 0x00010770
		~MaterialPropertyBlock()
		{
			this.Dispose();
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x000125A0 File Offset: 0x000107A0
		private void Dispose()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				MaterialPropertyBlock.DestroyImpl(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x000125E2 File Offset: 0x000107E2
		public void SetInt(string name, int value)
		{
			this.SetFloatImpl(Shader.PropertyToID(name), (float)value);
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x000125F4 File Offset: 0x000107F4
		public void SetInt(int nameID, int value)
		{
			this.SetFloatImpl(nameID, (float)value);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00012601 File Offset: 0x00010801
		public void SetFloat(string name, float value)
		{
			this.SetFloatImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00012612 File Offset: 0x00010812
		public void SetFloat(int nameID, float value)
		{
			this.SetFloatImpl(nameID, value);
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0001261E File Offset: 0x0001081E
		public void SetInteger(string name, int value)
		{
			this.SetIntImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x0001262F File Offset: 0x0001082F
		public void SetInteger(int nameID, int value)
		{
			this.SetIntImpl(nameID, value);
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x0001263B File Offset: 0x0001083B
		public void SetVector(string name, Vector4 value)
		{
			this.SetVectorImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x0001264C File Offset: 0x0001084C
		public void SetVector(int nameID, Vector4 value)
		{
			this.SetVectorImpl(nameID, value);
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x00012658 File Offset: 0x00010858
		public void SetColor(string name, Color value)
		{
			this.SetColorImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00012669 File Offset: 0x00010869
		public void SetColor(int nameID, Color value)
		{
			this.SetColorImpl(nameID, value);
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00012675 File Offset: 0x00010875
		public void SetMatrix(string name, Matrix4x4 value)
		{
			this.SetMatrixImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00012686 File Offset: 0x00010886
		public void SetMatrix(int nameID, Matrix4x4 value)
		{
			this.SetMatrixImpl(nameID, value);
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00012692 File Offset: 0x00010892
		public void SetBuffer(string name, ComputeBuffer value)
		{
			this.SetBufferImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x000126A3 File Offset: 0x000108A3
		public void SetBuffer(int nameID, ComputeBuffer value)
		{
			this.SetBufferImpl(nameID, value);
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x000126AF File Offset: 0x000108AF
		public void SetBuffer(string name, GraphicsBuffer value)
		{
			this.SetGraphicsBufferImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x000126C0 File Offset: 0x000108C0
		public void SetBuffer(int nameID, GraphicsBuffer value)
		{
			this.SetGraphicsBufferImpl(nameID, value);
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x000126CC File Offset: 0x000108CC
		public void SetTexture(string name, Texture value)
		{
			this.SetTextureImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x000126DD File Offset: 0x000108DD
		public void SetTexture(int nameID, Texture value)
		{
			this.SetTextureImpl(nameID, value);
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x000126E9 File Offset: 0x000108E9
		public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element)
		{
			this.SetRenderTextureImpl(Shader.PropertyToID(name), value, element);
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x000126FB File Offset: 0x000108FB
		public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element)
		{
			this.SetRenderTextureImpl(nameID, value, element);
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x00012708 File Offset: 0x00010908
		public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size)
		{
			this.SetConstantBufferImpl(Shader.PropertyToID(name), value, offset, size);
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x0001271C File Offset: 0x0001091C
		public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size)
		{
			this.SetConstantBufferImpl(nameID, value, offset, size);
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0001272B File Offset: 0x0001092B
		public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size)
		{
			this.SetConstantGraphicsBufferImpl(Shader.PropertyToID(name), value, offset, size);
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x0001273F File Offset: 0x0001093F
		public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size)
		{
			this.SetConstantGraphicsBufferImpl(nameID, value, offset, size);
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0001274E File Offset: 0x0001094E
		public void SetFloatArray(string name, List<float> values)
		{
			this.SetFloatArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<float>(values), values.Count);
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0001276A File Offset: 0x0001096A
		public void SetFloatArray(int nameID, List<float> values)
		{
			this.SetFloatArray(nameID, NoAllocHelpers.ExtractArrayFromListT<float>(values), values.Count);
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00012781 File Offset: 0x00010981
		public void SetFloatArray(string name, float[] values)
		{
			this.SetFloatArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x00012795 File Offset: 0x00010995
		public void SetFloatArray(int nameID, float[] values)
		{
			this.SetFloatArray(nameID, values, values.Length);
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x000127A4 File Offset: 0x000109A4
		public void SetVectorArray(string name, List<Vector4> values)
		{
			this.SetVectorArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<Vector4>(values), values.Count);
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x000127C0 File Offset: 0x000109C0
		public void SetVectorArray(int nameID, List<Vector4> values)
		{
			this.SetVectorArray(nameID, NoAllocHelpers.ExtractArrayFromListT<Vector4>(values), values.Count);
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x000127D7 File Offset: 0x000109D7
		public void SetVectorArray(string name, Vector4[] values)
		{
			this.SetVectorArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x000127EB File Offset: 0x000109EB
		public void SetVectorArray(int nameID, Vector4[] values)
		{
			this.SetVectorArray(nameID, values, values.Length);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x000127FA File Offset: 0x000109FA
		public void SetMatrixArray(string name, List<Matrix4x4> values)
		{
			this.SetMatrixArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<Matrix4x4>(values), values.Count);
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x00012816 File Offset: 0x00010A16
		public void SetMatrixArray(int nameID, List<Matrix4x4> values)
		{
			this.SetMatrixArray(nameID, NoAllocHelpers.ExtractArrayFromListT<Matrix4x4>(values), values.Count);
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0001282D File Offset: 0x00010A2D
		public void SetMatrixArray(string name, Matrix4x4[] values)
		{
			this.SetMatrixArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x00012841 File Offset: 0x00010A41
		public void SetMatrixArray(int nameID, Matrix4x4[] values)
		{
			this.SetMatrixArray(nameID, values, values.Length);
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x00012850 File Offset: 0x00010A50
		public bool HasProperty(string name)
		{
			return this.HasPropertyImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x00012870 File Offset: 0x00010A70
		public bool HasProperty(int nameID)
		{
			return this.HasPropertyImpl(nameID);
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x0001288C File Offset: 0x00010A8C
		public bool HasInt(string name)
		{
			return this.HasFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x000128AC File Offset: 0x00010AAC
		public bool HasInt(int nameID)
		{
			return this.HasFloatImpl(nameID);
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x000128C8 File Offset: 0x00010AC8
		public bool HasFloat(string name)
		{
			return this.HasFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x000128E8 File Offset: 0x00010AE8
		public bool HasFloat(int nameID)
		{
			return this.HasFloatImpl(nameID);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00012904 File Offset: 0x00010B04
		public bool HasInteger(string name)
		{
			return this.HasIntImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00012924 File Offset: 0x00010B24
		public bool HasInteger(int nameID)
		{
			return this.HasIntImpl(nameID);
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00012940 File Offset: 0x00010B40
		public bool HasTexture(string name)
		{
			return this.HasTextureImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00012960 File Offset: 0x00010B60
		public bool HasTexture(int nameID)
		{
			return this.HasTextureImpl(nameID);
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0001297C File Offset: 0x00010B7C
		public bool HasMatrix(string name)
		{
			return this.HasMatrixImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0001299C File Offset: 0x00010B9C
		public bool HasMatrix(int nameID)
		{
			return this.HasMatrixImpl(nameID);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x000129B8 File Offset: 0x00010BB8
		public bool HasVector(string name)
		{
			return this.HasVectorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x000129D8 File Offset: 0x00010BD8
		public bool HasVector(int nameID)
		{
			return this.HasVectorImpl(nameID);
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x000129F4 File Offset: 0x00010BF4
		public bool HasColor(string name)
		{
			return this.HasVectorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00012A14 File Offset: 0x00010C14
		public bool HasColor(int nameID)
		{
			return this.HasVectorImpl(nameID);
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x00012A30 File Offset: 0x00010C30
		public bool HasBuffer(string name)
		{
			return this.HasBufferImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x00012A50 File Offset: 0x00010C50
		public bool HasBuffer(int nameID)
		{
			return this.HasBufferImpl(nameID);
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00012A6C File Offset: 0x00010C6C
		public bool HasConstantBuffer(string name)
		{
			return this.HasConstantBufferImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x00012A8C File Offset: 0x00010C8C
		public bool HasConstantBuffer(int nameID)
		{
			return this.HasConstantBufferImpl(nameID);
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x00012AA8 File Offset: 0x00010CA8
		public float GetFloat(string name)
		{
			return this.GetFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x00012AC8 File Offset: 0x00010CC8
		public float GetFloat(int nameID)
		{
			return this.GetFloatImpl(nameID);
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x00012AE4 File Offset: 0x00010CE4
		public int GetInt(string name)
		{
			return (int)this.GetFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x00012B04 File Offset: 0x00010D04
		public int GetInt(int nameID)
		{
			return (int)this.GetFloatImpl(nameID);
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x00012B20 File Offset: 0x00010D20
		public int GetInteger(string name)
		{
			return this.GetIntImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x00012B40 File Offset: 0x00010D40
		public int GetInteger(int nameID)
		{
			return this.GetIntImpl(nameID);
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x00012B5C File Offset: 0x00010D5C
		public Vector4 GetVector(string name)
		{
			return this.GetVectorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00012B7C File Offset: 0x00010D7C
		public Vector4 GetVector(int nameID)
		{
			return this.GetVectorImpl(nameID);
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00012B98 File Offset: 0x00010D98
		public Color GetColor(string name)
		{
			return this.GetColorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x00012BB8 File Offset: 0x00010DB8
		public Color GetColor(int nameID)
		{
			return this.GetColorImpl(nameID);
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00012BD4 File Offset: 0x00010DD4
		public Matrix4x4 GetMatrix(string name)
		{
			return this.GetMatrixImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00012BF4 File Offset: 0x00010DF4
		public Matrix4x4 GetMatrix(int nameID)
		{
			return this.GetMatrixImpl(nameID);
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00012C10 File Offset: 0x00010E10
		public Texture GetTexture(string name)
		{
			return this.GetTextureImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x00012C30 File Offset: 0x00010E30
		public Texture GetTexture(int nameID)
		{
			return this.GetTextureImpl(nameID);
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x00012C4C File Offset: 0x00010E4C
		public float[] GetFloatArray(string name)
		{
			return this.GetFloatArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x00012C6C File Offset: 0x00010E6C
		public float[] GetFloatArray(int nameID)
		{
			return (this.GetFloatArrayCountImpl(nameID) != 0) ? this.GetFloatArrayImpl(nameID) : null;
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x00012C94 File Offset: 0x00010E94
		public Vector4[] GetVectorArray(string name)
		{
			return this.GetVectorArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00012CB4 File Offset: 0x00010EB4
		public Vector4[] GetVectorArray(int nameID)
		{
			return (this.GetVectorArrayCountImpl(nameID) != 0) ? this.GetVectorArrayImpl(nameID) : null;
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x00012CDC File Offset: 0x00010EDC
		public Matrix4x4[] GetMatrixArray(string name)
		{
			return this.GetMatrixArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x00012CFC File Offset: 0x00010EFC
		public Matrix4x4[] GetMatrixArray(int nameID)
		{
			return (this.GetMatrixArrayCountImpl(nameID) != 0) ? this.GetMatrixArrayImpl(nameID) : null;
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x00012D21 File Offset: 0x00010F21
		public void GetFloatArray(string name, List<float> values)
		{
			this.ExtractFloatArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00012D32 File Offset: 0x00010F32
		public void GetFloatArray(int nameID, List<float> values)
		{
			this.ExtractFloatArray(nameID, values);
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x00012D3E File Offset: 0x00010F3E
		public void GetVectorArray(string name, List<Vector4> values)
		{
			this.ExtractVectorArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00012D4F File Offset: 0x00010F4F
		public void GetVectorArray(int nameID, List<Vector4> values)
		{
			this.ExtractVectorArray(nameID, values);
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x00012D5B File Offset: 0x00010F5B
		public void GetMatrixArray(string name, List<Matrix4x4> values)
		{
			this.ExtractMatrixArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x00012D6C File Offset: 0x00010F6C
		public void GetMatrixArray(int nameID, List<Matrix4x4> values)
		{
			this.ExtractMatrixArray(nameID, values);
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x00012D78 File Offset: 0x00010F78
		public void CopySHCoefficientArraysFrom(List<SphericalHarmonicsL2> lightProbes)
		{
			bool flag = lightProbes == null;
			if (flag)
			{
				throw new ArgumentNullException("lightProbes");
			}
			this.CopySHCoefficientArraysFrom(NoAllocHelpers.ExtractArrayFromListT<SphericalHarmonicsL2>(lightProbes), 0, 0, lightProbes.Count);
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x00012DB0 File Offset: 0x00010FB0
		public void CopySHCoefficientArraysFrom(SphericalHarmonicsL2[] lightProbes)
		{
			bool flag = lightProbes == null;
			if (flag)
			{
				throw new ArgumentNullException("lightProbes");
			}
			this.CopySHCoefficientArraysFrom(lightProbes, 0, 0, lightProbes.Length);
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00012DDE File Offset: 0x00010FDE
		public void CopySHCoefficientArraysFrom(List<SphericalHarmonicsL2> lightProbes, int sourceStart, int destStart, int count)
		{
			this.CopySHCoefficientArraysFrom(NoAllocHelpers.ExtractArrayFromListT<SphericalHarmonicsL2>(lightProbes), sourceStart, destStart, count);
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x00012DF4 File Offset: 0x00010FF4
		public void CopySHCoefficientArraysFrom(SphericalHarmonicsL2[] lightProbes, int sourceStart, int destStart, int count)
		{
			bool flag = lightProbes == null;
			if (flag)
			{
				throw new ArgumentNullException("lightProbes");
			}
			bool flag2 = sourceStart < 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("sourceStart", "Argument sourceStart must not be negative.");
			}
			bool flag3 = destStart < 0;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("sourceStart", "Argument destStart must not be negative.");
			}
			bool flag4 = count < 0;
			if (flag4)
			{
				throw new ArgumentOutOfRangeException("count", "Argument count must not be negative.");
			}
			bool flag5 = lightProbes.Length < sourceStart + count;
			if (flag5)
			{
				throw new ArgumentOutOfRangeException("The specified source start index or count is out of the range.");
			}
			MaterialPropertyBlock.Internal_CopySHCoefficientArraysFrom(this, lightProbes, sourceStart, destStart, count);
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x00012E84 File Offset: 0x00011084
		public void CopyProbeOcclusionArrayFrom(List<Vector4> occlusionProbes)
		{
			bool flag = occlusionProbes == null;
			if (flag)
			{
				throw new ArgumentNullException("occlusionProbes");
			}
			this.CopyProbeOcclusionArrayFrom(NoAllocHelpers.ExtractArrayFromListT<Vector4>(occlusionProbes), 0, 0, occlusionProbes.Count);
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x00012EBC File Offset: 0x000110BC
		public void CopyProbeOcclusionArrayFrom(Vector4[] occlusionProbes)
		{
			bool flag = occlusionProbes == null;
			if (flag)
			{
				throw new ArgumentNullException("occlusionProbes");
			}
			this.CopyProbeOcclusionArrayFrom(occlusionProbes, 0, 0, occlusionProbes.Length);
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x00012EEA File Offset: 0x000110EA
		public void CopyProbeOcclusionArrayFrom(List<Vector4> occlusionProbes, int sourceStart, int destStart, int count)
		{
			this.CopyProbeOcclusionArrayFrom(NoAllocHelpers.ExtractArrayFromListT<Vector4>(occlusionProbes), sourceStart, destStart, count);
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x00012F00 File Offset: 0x00011100
		public void CopyProbeOcclusionArrayFrom(Vector4[] occlusionProbes, int sourceStart, int destStart, int count)
		{
			bool flag = occlusionProbes == null;
			if (flag)
			{
				throw new ArgumentNullException("occlusionProbes");
			}
			bool flag2 = sourceStart < 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("sourceStart", "Argument sourceStart must not be negative.");
			}
			bool flag3 = destStart < 0;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("sourceStart", "Argument destStart must not be negative.");
			}
			bool flag4 = count < 0;
			if (flag4)
			{
				throw new ArgumentOutOfRangeException("count", "Argument count must not be negative.");
			}
			bool flag5 = occlusionProbes.Length < sourceStart + count;
			if (flag5)
			{
				throw new ArgumentOutOfRangeException("The specified source start index or count is out of the range.");
			}
			MaterialPropertyBlock.Internal_CopyProbeOcclusionArrayFrom(this, occlusionProbes, sourceStart, destStart, count);
		}

		// Token: 0x06000CB1 RID: 3249
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetVectorImpl_Injected(int name, out Vector4 ret);

		// Token: 0x06000CB2 RID: 3250
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetColorImpl_Injected(int name, out Color ret);

		// Token: 0x06000CB3 RID: 3251
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetMatrixImpl_Injected(int name, out Matrix4x4 ret);

		// Token: 0x06000CB4 RID: 3252
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetVectorImpl_Injected(int name, ref Vector4 value);

		// Token: 0x06000CB5 RID: 3253
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetColorImpl_Injected(int name, ref Color value);

		// Token: 0x06000CB6 RID: 3254
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetMatrixImpl_Injected(int name, ref Matrix4x4 value);

		// Token: 0x04000479 RID: 1145
		internal IntPtr m_Ptr;
	}
}
