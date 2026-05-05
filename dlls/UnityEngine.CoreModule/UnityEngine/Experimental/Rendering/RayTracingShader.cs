using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004F1 RID: 1265
	[NativeHeader("Runtime/Shaders/RayTracingShader.h")]
	[NativeHeader("Runtime/Shaders/RayTracingAccelerationStructure.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public sealed class RayTracingShader : Object
	{
		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06002BD6 RID: 11222
		public extern float maxRecursionDepth { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06002BD7 RID: 11223
		[FreeFunction(Name = "RayTracingShaderScripting::SetFloat", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetFloat(int nameID, float val);

		// Token: 0x06002BD8 RID: 11224
		[FreeFunction(Name = "RayTracingShaderScripting::SetInt", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetInt(int nameID, int val);

		// Token: 0x06002BD9 RID: 11225 RVA: 0x00049B58 File Offset: 0x00047D58
		[FreeFunction(Name = "RayTracingShaderScripting::SetVector", HasExplicitThis = true)]
		public void SetVector(int nameID, Vector4 val)
		{
			this.SetVector_Injected(nameID, ref val);
		}

		// Token: 0x06002BDA RID: 11226 RVA: 0x00049B63 File Offset: 0x00047D63
		[FreeFunction(Name = "RayTracingShaderScripting::SetMatrix", HasExplicitThis = true)]
		public void SetMatrix(int nameID, Matrix4x4 val)
		{
			this.SetMatrix_Injected(nameID, ref val);
		}

		// Token: 0x06002BDB RID: 11227
		[FreeFunction(Name = "RayTracingShaderScripting::SetFloatArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetFloatArray(int nameID, float[] values);

		// Token: 0x06002BDC RID: 11228
		[FreeFunction(Name = "RayTracingShaderScripting::SetIntArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetIntArray(int nameID, int[] values);

		// Token: 0x06002BDD RID: 11229
		[FreeFunction(Name = "RayTracingShaderScripting::SetVectorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetVectorArray(int nameID, Vector4[] values);

		// Token: 0x06002BDE RID: 11230
		[FreeFunction(Name = "RayTracingShaderScripting::SetMatrixArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetMatrixArray(int nameID, Matrix4x4[] values);

		// Token: 0x06002BDF RID: 11231
		[NativeMethod(Name = "RayTracingShaderScripting::SetTexture", HasExplicitThis = true, IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetTexture(int nameID, [NotNull("ArgumentNullException")] Texture texture);

		// Token: 0x06002BE0 RID: 11232
		[NativeMethod(Name = "RayTracingShaderScripting::SetBuffer", HasExplicitThis = true, IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetBuffer(int nameID, [NotNull("ArgumentNullException")] ComputeBuffer buffer);

		// Token: 0x06002BE1 RID: 11233
		[NativeMethod(Name = "RayTracingShaderScripting::SetBuffer", HasExplicitThis = true, IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetGraphicsBuffer(int nameID, [NotNull("ArgumentNullException")] GraphicsBuffer buffer);

		// Token: 0x06002BE2 RID: 11234
		[FreeFunction(Name = "RayTracingShaderScripting::SetConstantBuffer", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetConstantComputeBuffer(int nameID, [NotNull("ArgumentNullException")] ComputeBuffer buffer, int offset, int size);

		// Token: 0x06002BE3 RID: 11235
		[FreeFunction(Name = "RayTracingShaderScripting::SetConstantBuffer", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetConstantGraphicsBuffer(int nameID, [NotNull("ArgumentNullException")] GraphicsBuffer buffer, int offset, int size);

		// Token: 0x06002BE4 RID: 11236
		[NativeMethod(Name = "RayTracingShaderScripting::SetAccelerationStructure", HasExplicitThis = true, IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetAccelerationStructure(int nameID, [NotNull("ArgumentNullException")] RayTracingAccelerationStructure accelerationStructure);

		// Token: 0x06002BE5 RID: 11237
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetShaderPass(string passName);

		// Token: 0x06002BE6 RID: 11238
		[NativeMethod(Name = "RayTracingShaderScripting::SetTextureFromGlobal", HasExplicitThis = true, IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetTextureFromGlobal(int nameID, int globalTextureNameID);

		// Token: 0x06002BE7 RID: 11239
		[NativeName("DispatchRays")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Dispatch(string rayGenFunctionName, int width, int height, int depth, Camera camera = null);

		// Token: 0x06002BE8 RID: 11240 RVA: 0x00049B6E File Offset: 0x00047D6E
		public void SetBuffer(int nameID, GraphicsBuffer buffer)
		{
			this.SetGraphicsBuffer(nameID, buffer);
		}

		// Token: 0x06002BE9 RID: 11241 RVA: 0x0001117A File Offset: 0x0000F37A
		private RayTracingShader()
		{
		}

		// Token: 0x06002BEA RID: 11242 RVA: 0x00049B7A File Offset: 0x00047D7A
		public void SetFloat(string name, float val)
		{
			this.SetFloat(Shader.PropertyToID(name), val);
		}

		// Token: 0x06002BEB RID: 11243 RVA: 0x00049B8B File Offset: 0x00047D8B
		public void SetInt(string name, int val)
		{
			this.SetInt(Shader.PropertyToID(name), val);
		}

		// Token: 0x06002BEC RID: 11244 RVA: 0x00049B9C File Offset: 0x00047D9C
		public void SetVector(string name, Vector4 val)
		{
			this.SetVector(Shader.PropertyToID(name), val);
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x00049BAD File Offset: 0x00047DAD
		public void SetMatrix(string name, Matrix4x4 val)
		{
			this.SetMatrix(Shader.PropertyToID(name), val);
		}

		// Token: 0x06002BEE RID: 11246 RVA: 0x00049BBE File Offset: 0x00047DBE
		public void SetVectorArray(string name, Vector4[] values)
		{
			this.SetVectorArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x00049BCF File Offset: 0x00047DCF
		public void SetMatrixArray(string name, Matrix4x4[] values)
		{
			this.SetMatrixArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06002BF0 RID: 11248 RVA: 0x00049BE0 File Offset: 0x00047DE0
		public void SetFloats(string name, params float[] values)
		{
			this.SetFloatArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06002BF1 RID: 11249 RVA: 0x00049BF1 File Offset: 0x00047DF1
		public void SetFloats(int nameID, params float[] values)
		{
			this.SetFloatArray(nameID, values);
		}

		// Token: 0x06002BF2 RID: 11250 RVA: 0x00049BFD File Offset: 0x00047DFD
		public void SetInts(string name, params int[] values)
		{
			this.SetIntArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06002BF3 RID: 11251 RVA: 0x00049C0E File Offset: 0x00047E0E
		public void SetInts(int nameID, params int[] values)
		{
			this.SetIntArray(nameID, values);
		}

		// Token: 0x06002BF4 RID: 11252 RVA: 0x00049C1A File Offset: 0x00047E1A
		public void SetBool(string name, bool val)
		{
			this.SetInt(Shader.PropertyToID(name), val ? 1 : 0);
		}

		// Token: 0x06002BF5 RID: 11253 RVA: 0x00049C31 File Offset: 0x00047E31
		public void SetBool(int nameID, bool val)
		{
			this.SetInt(nameID, val ? 1 : 0);
		}

		// Token: 0x06002BF6 RID: 11254 RVA: 0x00049C43 File Offset: 0x00047E43
		public void SetTexture(string name, Texture texture)
		{
			this.SetTexture(Shader.PropertyToID(name), texture);
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x00049C54 File Offset: 0x00047E54
		public void SetBuffer(string name, ComputeBuffer buffer)
		{
			this.SetBuffer(Shader.PropertyToID(name), buffer);
		}

		// Token: 0x06002BF8 RID: 11256 RVA: 0x00049C65 File Offset: 0x00047E65
		public void SetBuffer(string name, GraphicsBuffer buffer)
		{
			this.SetBuffer(Shader.PropertyToID(name), buffer);
		}

		// Token: 0x06002BF9 RID: 11257 RVA: 0x00049C76 File Offset: 0x00047E76
		public void SetConstantBuffer(int nameID, ComputeBuffer buffer, int offset, int size)
		{
			this.SetConstantComputeBuffer(nameID, buffer, offset, size);
		}

		// Token: 0x06002BFA RID: 11258 RVA: 0x00049C85 File Offset: 0x00047E85
		public void SetConstantBuffer(string name, ComputeBuffer buffer, int offset, int size)
		{
			this.SetConstantComputeBuffer(Shader.PropertyToID(name), buffer, offset, size);
		}

		// Token: 0x06002BFB RID: 11259 RVA: 0x00049C99 File Offset: 0x00047E99
		public void SetConstantBuffer(int nameID, GraphicsBuffer buffer, int offset, int size)
		{
			this.SetConstantGraphicsBuffer(nameID, buffer, offset, size);
		}

		// Token: 0x06002BFC RID: 11260 RVA: 0x00049CA8 File Offset: 0x00047EA8
		public void SetConstantBuffer(string name, GraphicsBuffer buffer, int offset, int size)
		{
			this.SetConstantGraphicsBuffer(Shader.PropertyToID(name), buffer, offset, size);
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x00049CBC File Offset: 0x00047EBC
		public void SetAccelerationStructure(string name, RayTracingAccelerationStructure accelerationStructure)
		{
			this.SetAccelerationStructure(Shader.PropertyToID(name), accelerationStructure);
		}

		// Token: 0x06002BFE RID: 11262 RVA: 0x00049CCD File Offset: 0x00047ECD
		public void SetTextureFromGlobal(string name, string globalTextureName)
		{
			this.SetTextureFromGlobal(Shader.PropertyToID(name), Shader.PropertyToID(globalTextureName));
		}

		// Token: 0x06002BFF RID: 11263
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetVector_Injected(int nameID, ref Vector4 val);

		// Token: 0x06002C00 RID: 11264
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetMatrix_Injected(int nameID, ref Matrix4x4 val);
	}
}
