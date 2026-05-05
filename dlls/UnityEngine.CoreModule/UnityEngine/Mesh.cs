using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001C5 RID: 453
	[ExcludeFromPreset]
	[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
	[RequiredByNativeCode]
	public sealed class Mesh : Object
	{
		// Token: 0x06001058 RID: 4184
		[FreeFunction("MeshScripting::CreateMesh")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] Mesh mono);

		// Token: 0x06001059 RID: 4185 RVA: 0x00015EEE File Offset: 0x000140EE
		[RequiredByNativeCode]
		public Mesh()
		{
			Mesh.Internal_Create(this);
		}

		// Token: 0x0600105A RID: 4186
		[FreeFunction("MeshScripting::MeshFromInstanceId")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Mesh FromInstanceID(int id);

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x0600105B RID: 4187
		// (set) Token: 0x0600105C RID: 4188
		public extern IndexFormat indexFormat { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x0600105D RID: 4189
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern uint GetTotalIndexCount();

		// Token: 0x0600105E RID: 4190
		[FreeFunction(Name = "MeshScripting::SetIndexBufferParams", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetIndexBufferParams(int indexCount, IndexFormat format);

		// Token: 0x0600105F RID: 4191
		[FreeFunction(Name = "MeshScripting::InternalSetIndexBufferData", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalSetIndexBufferData(IntPtr data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags);

		// Token: 0x06001060 RID: 4192
		[FreeFunction(Name = "MeshScripting::InternalSetIndexBufferDataFromArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalSetIndexBufferDataFromArray(Array data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags);

		// Token: 0x06001061 RID: 4193
		[FreeFunction(Name = "MeshScripting::SetVertexBufferParamsFromPtr", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetVertexBufferParamsFromPtr(int vertexCount, IntPtr attributesPtr, int attributesCount);

		// Token: 0x06001062 RID: 4194
		[FreeFunction(Name = "MeshScripting::SetVertexBufferParamsFromArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetVertexBufferParamsFromArray(int vertexCount, [Unmarshalled] params VertexAttributeDescriptor[] attributes);

		// Token: 0x06001063 RID: 4195
		[FreeFunction(Name = "MeshScripting::InternalSetVertexBufferData", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalSetVertexBufferData(int stream, IntPtr data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags);

		// Token: 0x06001064 RID: 4196
		[FreeFunction(Name = "MeshScripting::InternalSetVertexBufferDataFromArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalSetVertexBufferDataFromArray(int stream, Array data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags);

		// Token: 0x06001065 RID: 4197
		[FreeFunction(Name = "MeshScripting::GetVertexAttributesAlloc", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Array GetVertexAttributesAlloc();

		// Token: 0x06001066 RID: 4198
		[FreeFunction(Name = "MeshScripting::GetVertexAttributesArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetVertexAttributesArray([NotNull("ArgumentNullException")] [Unmarshalled] VertexAttributeDescriptor[] attributes);

		// Token: 0x06001067 RID: 4199
		[FreeFunction(Name = "MeshScripting::GetVertexAttributesList", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetVertexAttributesList([NotNull("ArgumentNullException")] List<VertexAttributeDescriptor> attributes);

		// Token: 0x06001068 RID: 4200
		[FreeFunction(Name = "MeshScripting::GetVertexAttributesCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetVertexAttributeCountImpl();

		// Token: 0x06001069 RID: 4201 RVA: 0x00015F00 File Offset: 0x00014100
		[FreeFunction(Name = "MeshScripting::GetVertexAttributeByIndex", HasExplicitThis = true, ThrowsException = true)]
		public VertexAttributeDescriptor GetVertexAttribute(int index)
		{
			VertexAttributeDescriptor result;
			this.GetVertexAttribute_Injected(index, out result);
			return result;
		}

		// Token: 0x0600106A RID: 4202
		[FreeFunction(Name = "MeshScripting::GetIndexStart", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern uint GetIndexStartImpl(int submesh);

		// Token: 0x0600106B RID: 4203
		[FreeFunction(Name = "MeshScripting::GetIndexCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern uint GetIndexCountImpl(int submesh);

		// Token: 0x0600106C RID: 4204
		[FreeFunction(Name = "MeshScripting::GetTrianglesCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern uint GetTrianglesCountImpl(int submesh);

		// Token: 0x0600106D RID: 4205
		[FreeFunction(Name = "MeshScripting::GetBaseVertex", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern uint GetBaseVertexImpl(int submesh);

		// Token: 0x0600106E RID: 4206
		[FreeFunction(Name = "MeshScripting::GetTriangles", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int[] GetTrianglesImpl(int submesh, bool applyBaseVertex);

		// Token: 0x0600106F RID: 4207
		[FreeFunction(Name = "MeshScripting::GetIndices", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int[] GetIndicesImpl(int submesh, bool applyBaseVertex);

		// Token: 0x06001070 RID: 4208
		[FreeFunction(Name = "SetMeshIndicesFromScript", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetIndicesImpl(int submesh, MeshTopology topology, IndexFormat indicesFormat, Array indices, int arrayStart, int arraySize, bool calculateBounds, int baseVertex);

		// Token: 0x06001071 RID: 4209
		[FreeFunction(Name = "SetMeshIndicesFromNativeArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetIndicesNativeArrayImpl(int submesh, MeshTopology topology, IndexFormat indicesFormat, IntPtr indices, int arrayStart, int arraySize, bool calculateBounds, int baseVertex);

		// Token: 0x06001072 RID: 4210
		[FreeFunction(Name = "MeshScripting::ExtractTrianglesToArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetTrianglesNonAllocImpl([Out] int[] values, int submesh, bool applyBaseVertex);

		// Token: 0x06001073 RID: 4211
		[FreeFunction(Name = "MeshScripting::ExtractTrianglesToArray16", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetTrianglesNonAllocImpl16([Out] ushort[] values, int submesh, bool applyBaseVertex);

		// Token: 0x06001074 RID: 4212
		[FreeFunction(Name = "MeshScripting::ExtractIndicesToArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetIndicesNonAllocImpl([Out] int[] values, int submesh, bool applyBaseVertex);

		// Token: 0x06001075 RID: 4213
		[FreeFunction(Name = "MeshScripting::ExtractIndicesToArray16", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetIndicesNonAllocImpl16([Out] ushort[] values, int submesh, bool applyBaseVertex);

		// Token: 0x06001076 RID: 4214
		[FreeFunction(Name = "MeshScripting::PrintErrorCantAccessChannel", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void PrintErrorCantAccessChannel(VertexAttribute ch);

		// Token: 0x06001077 RID: 4215
		[FreeFunction(Name = "MeshScripting::HasChannel", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool HasVertexAttribute(VertexAttribute attr);

		// Token: 0x06001078 RID: 4216
		[FreeFunction(Name = "MeshScripting::GetChannelDimension", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetVertexAttributeDimension(VertexAttribute attr);

		// Token: 0x06001079 RID: 4217
		[FreeFunction(Name = "MeshScripting::GetChannelFormat", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern VertexAttributeFormat GetVertexAttributeFormat(VertexAttribute attr);

		// Token: 0x0600107A RID: 4218
		[FreeFunction(Name = "MeshScripting::GetChannelStream", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetVertexAttributeStream(VertexAttribute attr);

		// Token: 0x0600107B RID: 4219
		[FreeFunction(Name = "MeshScripting::GetChannelOffset", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetVertexAttributeOffset(VertexAttribute attr);

		// Token: 0x0600107C RID: 4220
		[FreeFunction(Name = "SetMeshComponentFromArrayFromScript", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetArrayForChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, Array values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags);

		// Token: 0x0600107D RID: 4221
		[FreeFunction(Name = "SetMeshComponentFromNativeArrayFromScript", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetNativeArrayForChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, IntPtr values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags);

		// Token: 0x0600107E RID: 4222
		[FreeFunction(Name = "AllocExtractMeshComponentFromScript", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Array GetAllocArrayFromChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim);

		// Token: 0x0600107F RID: 4223
		[FreeFunction(Name = "ExtractMeshComponentFromScript", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetArrayFromChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, Array values);

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06001080 RID: 4224
		public extern int vertexBufferCount { [FreeFunction(Name = "MeshScripting::GetVertexBufferCount", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001081 RID: 4225
		[FreeFunction(Name = "MeshScripting::GetVertexBufferStride", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetVertexBufferStride(int stream);

		// Token: 0x06001082 RID: 4226
		[FreeFunction(Name = "MeshScripting::GetNativeVertexBufferPtr", HasExplicitThis = true)]
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern IntPtr GetNativeVertexBufferPtr(int index);

		// Token: 0x06001083 RID: 4227
		[FreeFunction(Name = "MeshScripting::GetNativeIndexBufferPtr", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern IntPtr GetNativeIndexBufferPtr();

		// Token: 0x06001084 RID: 4228
		[FreeFunction(Name = "MeshScripting::GetVertexBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern GraphicsBuffer GetVertexBufferImpl(int index);

		// Token: 0x06001085 RID: 4229
		[FreeFunction(Name = "MeshScripting::GetIndexBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern GraphicsBuffer GetIndexBufferImpl();

		// Token: 0x06001086 RID: 4230
		[FreeFunction(Name = "MeshScripting::GetBoneWeightBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern GraphicsBuffer GetBoneWeightBufferImpl(int bonesPerVertex);

		// Token: 0x06001087 RID: 4231
		[FreeFunction(Name = "MeshScripting::GetBlendShapeBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern GraphicsBuffer GetBlendShapeBufferImpl(int layout);

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06001088 RID: 4232
		// (set) Token: 0x06001089 RID: 4233
		public extern GraphicsBuffer.Target vertexBufferTarget { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x0600108A RID: 4234
		// (set) Token: 0x0600108B RID: 4235
		public extern GraphicsBuffer.Target indexBufferTarget { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x0600108C RID: 4236
		public extern int blendShapeCount { [NativeMethod(Name = "GetBlendShapeChannelCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600108D RID: 4237
		[FreeFunction(Name = "MeshScripting::ClearBlendShapes", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void ClearBlendShapes();

		// Token: 0x0600108E RID: 4238
		[FreeFunction(Name = "MeshScripting::GetBlendShapeName", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern string GetBlendShapeName(int shapeIndex);

		// Token: 0x0600108F RID: 4239
		[FreeFunction(Name = "MeshScripting::GetBlendShapeIndex", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetBlendShapeIndex(string blendShapeName);

		// Token: 0x06001090 RID: 4240
		[FreeFunction(Name = "MeshScripting::GetBlendShapeFrameCount", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetBlendShapeFrameCount(int shapeIndex);

		// Token: 0x06001091 RID: 4241
		[FreeFunction(Name = "MeshScripting::GetBlendShapeFrameWeight", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern float GetBlendShapeFrameWeight(int shapeIndex, int frameIndex);

		// Token: 0x06001092 RID: 4242
		[FreeFunction(Name = "GetBlendShapeFrameVerticesFromScript", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetBlendShapeFrameVertices(int shapeIndex, int frameIndex, [Unmarshalled] Vector3[] deltaVertices, [Unmarshalled] Vector3[] deltaNormals, [Unmarshalled] Vector3[] deltaTangents);

		// Token: 0x06001093 RID: 4243
		[FreeFunction(Name = "AddBlendShapeFrameFromScript", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void AddBlendShapeFrame(string shapeName, float frameWeight, [Unmarshalled] Vector3[] deltaVertices, [Unmarshalled] Vector3[] deltaNormals, [Unmarshalled] Vector3[] deltaTangents);

		// Token: 0x06001094 RID: 4244 RVA: 0x00015F18 File Offset: 0x00014118
		[FreeFunction(Name = "MeshScripting::GetBlendShapeOffset", HasExplicitThis = true)]
		private BlendShape GetBlendShapeOffsetInternal(int index)
		{
			BlendShape result;
			this.GetBlendShapeOffsetInternal_Injected(index, out result);
			return result;
		}

		// Token: 0x06001095 RID: 4245
		[NativeMethod("HasBoneWeights")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasBoneWeights();

		// Token: 0x06001096 RID: 4246
		[FreeFunction(Name = "MeshScripting::GetBoneWeights", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern BoneWeight[] GetBoneWeightsImpl();

		// Token: 0x06001097 RID: 4247
		[FreeFunction(Name = "MeshScripting::SetBoneWeights", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetBoneWeightsImpl(BoneWeight[] weights);

		// Token: 0x06001098 RID: 4248 RVA: 0x00015F2F File Offset: 0x0001412F
		public void SetBoneWeights(NativeArray<byte> bonesPerVertex, NativeArray<BoneWeight1> weights)
		{
			this.InternalSetBoneWeights((IntPtr)bonesPerVertex.GetUnsafeReadOnlyPtr<byte>(), bonesPerVertex.Length, (IntPtr)weights.GetUnsafeReadOnlyPtr<BoneWeight1>(), weights.Length);
		}

		// Token: 0x06001099 RID: 4249
		[FreeFunction(Name = "MeshScripting::SetBoneWeights", HasExplicitThis = true)]
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalSetBoneWeights(IntPtr bonesPerVertex, int bonesPerVertexSize, IntPtr weights, int weightsSize);

		// Token: 0x0600109A RID: 4250 RVA: 0x00015F60 File Offset: 0x00014160
		public unsafe NativeArray<BoneWeight1> GetAllBoneWeights()
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<BoneWeight1>((void*)this.GetAllBoneWeightsArray(), this.GetAllBoneWeightsArraySize(), Allocator.None);
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x00015F8C File Offset: 0x0001418C
		public unsafe NativeArray<byte> GetBonesPerVertex()
		{
			int length = this.HasBoneWeights() ? this.vertexCount : 0;
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)this.GetBonesPerVertexArray(), length, Allocator.None);
		}

		// Token: 0x0600109C RID: 4252
		[FreeFunction(Name = "MeshScripting::GetAllBoneWeightsArraySize", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetAllBoneWeightsArraySize();

		// Token: 0x0600109D RID: 4253
		[NativeMethod("GetBoneWeightBufferDimension")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetBoneWeightBufferLayoutInternal();

		// Token: 0x0600109E RID: 4254
		[SecurityCritical]
		[FreeFunction(Name = "MeshScripting::GetAllBoneWeightsArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetAllBoneWeightsArray();

		// Token: 0x0600109F RID: 4255
		[SecurityCritical]
		[FreeFunction(Name = "MeshScripting::GetBonesPerVertexArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetBonesPerVertexArray();

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x060010A0 RID: 4256
		public extern int bindposeCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x060010A1 RID: 4257
		// (set) Token: 0x060010A2 RID: 4258
		[NativeName("BindPosesFromScript")]
		public extern Matrix4x4[] bindposes { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060010A3 RID: 4259 RVA: 0x00015FC4 File Offset: 0x000141C4
		public unsafe NativeArray<Matrix4x4> GetBindposes()
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Matrix4x4>((void*)this.GetBindposesArray(), this.bindposeCount, Allocator.None);
		}

		// Token: 0x060010A4 RID: 4260
		[SecurityCritical]
		[FreeFunction(Name = "MeshScripting::GetBindposesArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetBindposesArray();

		// Token: 0x060010A5 RID: 4261
		[FreeFunction(Name = "MeshScripting::ExtractBoneWeightsIntoArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetBoneWeightsNonAllocImpl([Out] BoneWeight[] values);

		// Token: 0x060010A6 RID: 4262
		[FreeFunction(Name = "MeshScripting::ExtractBindPosesIntoArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetBindposesNonAllocImpl([Out] Matrix4x4[] values);

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x060010A7 RID: 4263
		public extern bool isReadable { [NativeMethod("GetIsReadable")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x060010A8 RID: 4264
		internal extern bool canAccess { [NativeMethod("CanAccessFromScript")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x060010A9 RID: 4265
		public extern int vertexCount { [NativeMethod("GetVertexCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x060010AA RID: 4266
		// (set) Token: 0x060010AB RID: 4267
		public extern int subMeshCount { [NativeMethod(Name = "GetSubMeshCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(Name = "MeshScripting::SetSubMeshCount", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060010AC RID: 4268 RVA: 0x00015FEF File Offset: 0x000141EF
		[FreeFunction("MeshScripting::SetSubMesh", HasExplicitThis = true, ThrowsException = true)]
		public void SetSubMesh(int index, SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			this.SetSubMesh_Injected(index, ref desc, flags);
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x00015FFC File Offset: 0x000141FC
		[FreeFunction("MeshScripting::GetSubMesh", HasExplicitThis = true, ThrowsException = true)]
		public SubMeshDescriptor GetSubMesh(int index)
		{
			SubMeshDescriptor result;
			this.GetSubMesh_Injected(index, out result);
			return result;
		}

		// Token: 0x060010AE RID: 4270
		[FreeFunction("MeshScripting::SetAllSubMeshesAtOnceFromArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetAllSubMeshesAtOnceFromArray(SubMeshDescriptor[] desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default);

		// Token: 0x060010AF RID: 4271
		[FreeFunction("MeshScripting::SetAllSubMeshesAtOnceFromNativeArray", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetAllSubMeshesAtOnceFromNativeArray(IntPtr desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default);

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x00016014 File Offset: 0x00014214
		// (set) Token: 0x060010B1 RID: 4273 RVA: 0x0001602A File Offset: 0x0001422A
		public Bounds bounds
		{
			get
			{
				Bounds result;
				this.get_bounds_Injected(out result);
				return result;
			}
			set
			{
				this.set_bounds_Injected(ref value);
			}
		}

		// Token: 0x060010B2 RID: 4274
		[NativeMethod("Clear")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ClearImpl(bool keepVertexLayout);

		// Token: 0x060010B3 RID: 4275
		[NativeMethod("RecalculateBounds")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RecalculateBoundsImpl(MeshUpdateFlags flags);

		// Token: 0x060010B4 RID: 4276
		[NativeMethod("RecalculateNormals")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RecalculateNormalsImpl(MeshUpdateFlags flags);

		// Token: 0x060010B5 RID: 4277
		[NativeMethod("RecalculateTangents")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RecalculateTangentsImpl(MeshUpdateFlags flags);

		// Token: 0x060010B6 RID: 4278
		[NativeMethod("MarkDynamic")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void MarkDynamicImpl();

		// Token: 0x060010B7 RID: 4279
		[NativeMethod("MarkModified")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void MarkModified();

		// Token: 0x060010B8 RID: 4280
		[NativeMethod("UploadMeshData")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void UploadMeshDataImpl(bool markNoLongerReadable);

		// Token: 0x060010B9 RID: 4281
		[FreeFunction(Name = "MeshScripting::GetPrimitiveType", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern MeshTopology GetTopologyImpl(int submesh);

		// Token: 0x060010BA RID: 4282
		[NativeMethod("RecalculateMeshMetric")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RecalculateUVDistributionMetricImpl(int uvSetIndex, float uvAreaThreshold);

		// Token: 0x060010BB RID: 4283
		[NativeMethod("RecalculateMeshMetrics")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RecalculateUVDistributionMetricsImpl(float uvAreaThreshold);

		// Token: 0x060010BC RID: 4284
		[NativeMethod("GetMeshMetric")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern float GetUVDistributionMetric(int uvSetIndex);

		// Token: 0x060010BD RID: 4285
		[NativeMethod(Name = "MeshScripting::CombineMeshes", IsFreeFunction = true, ThrowsException = true, HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void CombineMeshesImpl(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices, bool hasLightmapData);

		// Token: 0x060010BE RID: 4286
		[NativeMethod("Optimize")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void OptimizeImpl();

		// Token: 0x060010BF RID: 4287
		[NativeMethod("OptimizeIndexBuffers")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void OptimizeIndexBuffersImpl();

		// Token: 0x060010C0 RID: 4288
		[NativeMethod("OptimizeReorderVertexBuffer")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void OptimizeReorderVertexBufferImpl();

		// Token: 0x060010C1 RID: 4289 RVA: 0x00016034 File Offset: 0x00014234
		internal static VertexAttribute GetUVChannel(int uvIndex)
		{
			bool flag = uvIndex < 0 || uvIndex > 7;
			if (flag)
			{
				throw new ArgumentException("GetUVChannel called for bad uvIndex", "uvIndex");
			}
			return VertexAttribute.TexCoord0 + uvIndex;
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x00016068 File Offset: 0x00014268
		internal static int DefaultDimensionForChannel(VertexAttribute channel)
		{
			bool flag = channel == VertexAttribute.Position || channel == VertexAttribute.Normal;
			int result;
			if (flag)
			{
				result = 3;
			}
			else
			{
				bool flag2 = channel >= VertexAttribute.TexCoord0 && channel <= VertexAttribute.TexCoord7;
				if (flag2)
				{
					result = 2;
				}
				else
				{
					bool flag3 = channel == VertexAttribute.Tangent || channel == VertexAttribute.Color;
					if (!flag3)
					{
						throw new ArgumentException("DefaultDimensionForChannel called for bad channel", "channel");
					}
					result = 4;
				}
			}
			return result;
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x000160C4 File Offset: 0x000142C4
		private T[] GetAllocArrayFromChannel<T>(VertexAttribute channel, VertexAttributeFormat format, int dim)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				bool flag = this.HasVertexAttribute(channel);
				if (flag)
				{
					return (T[])this.GetAllocArrayFromChannelImpl(channel, format, dim);
				}
			}
			else
			{
				this.PrintErrorCantAccessChannel(channel);
			}
			return new T[0];
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x00016110 File Offset: 0x00014310
		private T[] GetAllocArrayFromChannel<T>(VertexAttribute channel)
		{
			return this.GetAllocArrayFromChannel<T>(channel, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(channel));
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x00016130 File Offset: 0x00014330
		private void SetSizedArrayForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, Array values, int valuesArrayLength, int valuesStart, int valuesCount, MeshUpdateFlags flags)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				bool flag = valuesStart < 0;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("valuesStart", valuesStart, "Mesh data array start index can't be negative.");
				}
				bool flag2 = valuesCount < 0;
				if (flag2)
				{
					throw new ArgumentOutOfRangeException("valuesCount", valuesCount, "Mesh data array length can't be negative.");
				}
				bool flag3 = valuesStart >= valuesArrayLength && valuesCount != 0;
				if (flag3)
				{
					throw new ArgumentOutOfRangeException("valuesStart", valuesStart, "Mesh data array start is outside of array size.");
				}
				bool flag4 = valuesStart + valuesCount > valuesArrayLength;
				if (flag4)
				{
					throw new ArgumentOutOfRangeException("valuesCount", valuesStart + valuesCount, "Mesh data array start+count is outside of array size.");
				}
				bool flag5 = values == null;
				if (flag5)
				{
					valuesStart = 0;
				}
				this.SetArrayForChannelImpl(channel, format, dim, values, valuesArrayLength, valuesStart, valuesCount, flags);
			}
			else
			{
				this.PrintErrorCantAccessChannel(channel);
			}
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0001620C File Offset: 0x0001440C
		private void SetSizedNativeArrayForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, IntPtr values, int valuesArrayLength, int valuesStart, int valuesCount, MeshUpdateFlags flags)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				bool flag = valuesStart < 0;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("valuesStart", valuesStart, "Mesh data array start index can't be negative.");
				}
				bool flag2 = valuesCount < 0;
				if (flag2)
				{
					throw new ArgumentOutOfRangeException("valuesCount", valuesCount, "Mesh data array length can't be negative.");
				}
				bool flag3 = valuesStart >= valuesArrayLength && valuesCount != 0;
				if (flag3)
				{
					throw new ArgumentOutOfRangeException("valuesStart", valuesStart, "Mesh data array start is outside of array size.");
				}
				bool flag4 = valuesStart + valuesCount > valuesArrayLength;
				if (flag4)
				{
					throw new ArgumentOutOfRangeException("valuesCount", valuesStart + valuesCount, "Mesh data array start+count is outside of array size.");
				}
				this.SetNativeArrayForChannelImpl(channel, format, dim, values, valuesArrayLength, valuesStart, valuesCount, flags);
			}
			else
			{
				this.PrintErrorCantAccessChannel(channel);
			}
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000162DC File Offset: 0x000144DC
		private void SetArrayForChannel<T>(VertexAttribute channel, VertexAttributeFormat format, int dim, T[] values, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			int num = NoAllocHelpers.SafeLength(values);
			this.SetSizedArrayForChannel(channel, format, dim, values, num, 0, num, flags);
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x00016304 File Offset: 0x00014504
		private void SetArrayForChannel<T>(VertexAttribute channel, T[] values, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			int num = NoAllocHelpers.SafeLength(values);
			this.SetSizedArrayForChannel(channel, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(channel), values, num, 0, num, flags);
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x00016330 File Offset: 0x00014530
		private void SetListForChannel<T>(VertexAttribute channel, VertexAttributeFormat format, int dim, List<T> values, int start, int length, MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(channel, format, dim, NoAllocHelpers.ExtractArrayFromList(values), NoAllocHelpers.SafeLength<T>(values), start, length, flags);
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0001635C File Offset: 0x0001455C
		private void SetListForChannel<T>(VertexAttribute channel, List<T> values, int start, int length, MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(channel, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(channel), NoAllocHelpers.ExtractArrayFromList(values), NoAllocHelpers.SafeLength<T>(values), start, length, flags);
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0001638A File Offset: 0x0001458A
		private void GetListForChannel<T>(List<T> buffer, int capacity, VertexAttribute channel, int dim)
		{
			this.GetListForChannel<T>(buffer, capacity, channel, dim, VertexAttributeFormat.Float32);
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0001639C File Offset: 0x0001459C
		private void GetListForChannel<T>(List<T> buffer, int capacity, VertexAttribute channel, int dim, VertexAttributeFormat channelType)
		{
			buffer.Clear();
			bool flag = !this.canAccess;
			if (flag)
			{
				this.PrintErrorCantAccessChannel(channel);
			}
			else
			{
				bool flag2 = !this.HasVertexAttribute(channel);
				if (!flag2)
				{
					NoAllocHelpers.EnsureListElemCount<T>(buffer, capacity);
					this.GetArrayFromChannelImpl(channel, channelType, dim, NoAllocHelpers.ExtractArrayFromList(buffer));
				}
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x060010CD RID: 4301 RVA: 0x000163F4 File Offset: 0x000145F4
		// (set) Token: 0x060010CE RID: 4302 RVA: 0x0001640D File Offset: 0x0001460D
		public Vector3[] vertices
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector3>(VertexAttribute.Position);
			}
			set
			{
				this.SetArrayForChannel<Vector3>(VertexAttribute.Position, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x060010CF RID: 4303 RVA: 0x0001641C File Offset: 0x0001461C
		// (set) Token: 0x060010D0 RID: 4304 RVA: 0x00016435 File Offset: 0x00014635
		public Vector3[] normals
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector3>(VertexAttribute.Normal);
			}
			set
			{
				this.SetArrayForChannel<Vector3>(VertexAttribute.Normal, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x060010D1 RID: 4305 RVA: 0x00016444 File Offset: 0x00014644
		// (set) Token: 0x060010D2 RID: 4306 RVA: 0x0001645D File Offset: 0x0001465D
		public Vector4[] tangents
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector4>(VertexAttribute.Tangent);
			}
			set
			{
				this.SetArrayForChannel<Vector4>(VertexAttribute.Tangent, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x060010D3 RID: 4307 RVA: 0x0001646C File Offset: 0x0001466C
		// (set) Token: 0x060010D4 RID: 4308 RVA: 0x00016485 File Offset: 0x00014685
		public Vector2[] uv
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord0);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord0, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00016494 File Offset: 0x00014694
		// (set) Token: 0x060010D6 RID: 4310 RVA: 0x000164AD File Offset: 0x000146AD
		public Vector2[] uv2
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord1);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord1, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060010D7 RID: 4311 RVA: 0x000164BC File Offset: 0x000146BC
		// (set) Token: 0x060010D8 RID: 4312 RVA: 0x000164D5 File Offset: 0x000146D5
		public Vector2[] uv3
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord2);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord2, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060010D9 RID: 4313 RVA: 0x000164E4 File Offset: 0x000146E4
		// (set) Token: 0x060010DA RID: 4314 RVA: 0x000164FD File Offset: 0x000146FD
		public Vector2[] uv4
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord3);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord3, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x0001650C File Offset: 0x0001470C
		// (set) Token: 0x060010DC RID: 4316 RVA: 0x00016525 File Offset: 0x00014725
		public Vector2[] uv5
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord4);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord4, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060010DD RID: 4317 RVA: 0x00016534 File Offset: 0x00014734
		// (set) Token: 0x060010DE RID: 4318 RVA: 0x0001654E File Offset: 0x0001474E
		public Vector2[] uv6
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord5);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord5, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060010DF RID: 4319 RVA: 0x0001655C File Offset: 0x0001475C
		// (set) Token: 0x060010E0 RID: 4320 RVA: 0x00016576 File Offset: 0x00014776
		public Vector2[] uv7
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord6);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord6, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060010E1 RID: 4321 RVA: 0x00016584 File Offset: 0x00014784
		// (set) Token: 0x060010E2 RID: 4322 RVA: 0x0001659E File Offset: 0x0001479E
		public Vector2[] uv8
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(VertexAttribute.TexCoord7);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(VertexAttribute.TexCoord7, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060010E3 RID: 4323 RVA: 0x000165AC File Offset: 0x000147AC
		// (set) Token: 0x060010E4 RID: 4324 RVA: 0x000165C5 File Offset: 0x000147C5
		public Color[] colors
		{
			get
			{
				return this.GetAllocArrayFromChannel<Color>(VertexAttribute.Color);
			}
			set
			{
				this.SetArrayForChannel<Color>(VertexAttribute.Color, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060010E5 RID: 4325 RVA: 0x000165D4 File Offset: 0x000147D4
		// (set) Token: 0x060010E6 RID: 4326 RVA: 0x000165EF File Offset: 0x000147EF
		public Color32[] colors32
		{
			get
			{
				return this.GetAllocArrayFromChannel<Color32>(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4);
			}
			set
			{
				this.SetArrayForChannel<Color32>(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4, value, MeshUpdateFlags.Default);
			}
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x00016600 File Offset: 0x00014800
		public void GetVertices(List<Vector3> vertices)
		{
			bool flag = vertices == null;
			if (flag)
			{
				throw new ArgumentNullException("vertices", "The result vertices list cannot be null.");
			}
			this.GetListForChannel<Vector3>(vertices, this.vertexCount, VertexAttribute.Position, Mesh.DefaultDimensionForChannel(VertexAttribute.Position));
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0001663B File Offset: 0x0001483B
		public void SetVertices(List<Vector3> inVertices)
		{
			this.SetVertices(inVertices, 0, NoAllocHelpers.SafeLength<Vector3>(inVertices));
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0001664D File Offset: 0x0001484D
		[ExcludeFromDocs]
		public void SetVertices(List<Vector3> inVertices, int start, int length)
		{
			this.SetVertices(inVertices, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0001665B File Offset: 0x0001485B
		public void SetVertices(List<Vector3> inVertices, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetListForChannel<Vector3>(VertexAttribute.Position, inVertices, start, length, flags);
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0001666B File Offset: 0x0001486B
		public void SetVertices(Vector3[] inVertices)
		{
			this.SetVertices(inVertices, 0, NoAllocHelpers.SafeLength(inVertices));
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0001667D File Offset: 0x0001487D
		[ExcludeFromDocs]
		public void SetVertices(Vector3[] inVertices, int start, int length)
		{
			this.SetVertices(inVertices, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0001668C File Offset: 0x0001488C
		public void SetVertices(Vector3[] inVertices, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(VertexAttribute.Position, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(VertexAttribute.Position), inVertices, NoAllocHelpers.SafeLength(inVertices), start, length, flags);
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x000166B4 File Offset: 0x000148B4
		public void SetVertices<T>(NativeArray<T> inVertices) where T : struct
		{
			this.SetVertices<T>(inVertices, 0, inVertices.Length);
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x000166C7 File Offset: 0x000148C7
		[ExcludeFromDocs]
		public void SetVertices<T>(NativeArray<T> inVertices, int start, int length) where T : struct
		{
			this.SetVertices<T>(inVertices, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x000166D8 File Offset: 0x000148D8
		public void SetVertices<T>(NativeArray<T> inVertices, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct
		{
			bool flag = UnsafeUtility.SizeOf<T>() != 12;
			if (flag)
			{
				throw new ArgumentException("SetVertices with NativeArray should use struct type that is 12 bytes (3x float) in size");
			}
			this.SetSizedNativeArrayForChannel(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, (IntPtr)inVertices.GetUnsafeReadOnlyPtr<T>(), inVertices.Length, start, length, flags);
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x00016724 File Offset: 0x00014924
		public void GetNormals(List<Vector3> normals)
		{
			bool flag = normals == null;
			if (flag)
			{
				throw new ArgumentNullException("normals", "The result normals list cannot be null.");
			}
			this.GetListForChannel<Vector3>(normals, this.vertexCount, VertexAttribute.Normal, Mesh.DefaultDimensionForChannel(VertexAttribute.Normal));
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0001675F File Offset: 0x0001495F
		public void SetNormals(List<Vector3> inNormals)
		{
			this.SetNormals(inNormals, 0, NoAllocHelpers.SafeLength<Vector3>(inNormals));
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x00016771 File Offset: 0x00014971
		[ExcludeFromDocs]
		public void SetNormals(List<Vector3> inNormals, int start, int length)
		{
			this.SetNormals(inNormals, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x0001677F File Offset: 0x0001497F
		public void SetNormals(List<Vector3> inNormals, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetListForChannel<Vector3>(VertexAttribute.Normal, inNormals, start, length, flags);
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x0001678F File Offset: 0x0001498F
		public void SetNormals(Vector3[] inNormals)
		{
			this.SetNormals(inNormals, 0, NoAllocHelpers.SafeLength(inNormals));
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x000167A1 File Offset: 0x000149A1
		[ExcludeFromDocs]
		public void SetNormals(Vector3[] inNormals, int start, int length)
		{
			this.SetNormals(inNormals, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x000167B0 File Offset: 0x000149B0
		public void SetNormals(Vector3[] inNormals, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(VertexAttribute.Normal, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(VertexAttribute.Normal), inNormals, NoAllocHelpers.SafeLength(inNormals), start, length, flags);
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x000167D8 File Offset: 0x000149D8
		public void SetNormals<T>(NativeArray<T> inNormals) where T : struct
		{
			this.SetNormals<T>(inNormals, 0, inNormals.Length);
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x000167EB File Offset: 0x000149EB
		[ExcludeFromDocs]
		public void SetNormals<T>(NativeArray<T> inNormals, int start, int length) where T : struct
		{
			this.SetNormals<T>(inNormals, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x000167FC File Offset: 0x000149FC
		public void SetNormals<T>(NativeArray<T> inNormals, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct
		{
			bool flag = UnsafeUtility.SizeOf<T>() != 12;
			if (flag)
			{
				throw new ArgumentException("SetNormals with NativeArray should use struct type that is 12 bytes (3x float) in size");
			}
			this.SetSizedNativeArrayForChannel(VertexAttribute.Normal, VertexAttributeFormat.Float32, 3, (IntPtr)inNormals.GetUnsafeReadOnlyPtr<T>(), inNormals.Length, start, length, flags);
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x00016848 File Offset: 0x00014A48
		public void GetTangents(List<Vector4> tangents)
		{
			bool flag = tangents == null;
			if (flag)
			{
				throw new ArgumentNullException("tangents", "The result tangents list cannot be null.");
			}
			this.GetListForChannel<Vector4>(tangents, this.vertexCount, VertexAttribute.Tangent, Mesh.DefaultDimensionForChannel(VertexAttribute.Tangent));
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x00016883 File Offset: 0x00014A83
		public void SetTangents(List<Vector4> inTangents)
		{
			this.SetTangents(inTangents, 0, NoAllocHelpers.SafeLength<Vector4>(inTangents));
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x00016895 File Offset: 0x00014A95
		[ExcludeFromDocs]
		public void SetTangents(List<Vector4> inTangents, int start, int length)
		{
			this.SetTangents(inTangents, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x000168A3 File Offset: 0x00014AA3
		public void SetTangents(List<Vector4> inTangents, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetListForChannel<Vector4>(VertexAttribute.Tangent, inTangents, start, length, flags);
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x000168B3 File Offset: 0x00014AB3
		public void SetTangents(Vector4[] inTangents)
		{
			this.SetTangents(inTangents, 0, NoAllocHelpers.SafeLength(inTangents));
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x000168C5 File Offset: 0x00014AC5
		[ExcludeFromDocs]
		public void SetTangents(Vector4[] inTangents, int start, int length)
		{
			this.SetTangents(inTangents, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x000168D4 File Offset: 0x00014AD4
		public void SetTangents(Vector4[] inTangents, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(VertexAttribute.Tangent, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(VertexAttribute.Tangent), inTangents, NoAllocHelpers.SafeLength(inTangents), start, length, flags);
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x000168FC File Offset: 0x00014AFC
		public void SetTangents<T>(NativeArray<T> inTangents) where T : struct
		{
			this.SetTangents<T>(inTangents, 0, inTangents.Length);
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0001690F File Offset: 0x00014B0F
		[ExcludeFromDocs]
		public void SetTangents<T>(NativeArray<T> inTangents, int start, int length) where T : struct
		{
			this.SetTangents<T>(inTangents, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x00016920 File Offset: 0x00014B20
		public void SetTangents<T>(NativeArray<T> inTangents, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct
		{
			bool flag = UnsafeUtility.SizeOf<T>() != 16;
			if (flag)
			{
				throw new ArgumentException("SetTangents with NativeArray should use struct type that is 16 bytes (4x float) in size");
			}
			this.SetSizedNativeArrayForChannel(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4, (IntPtr)inTangents.GetUnsafeReadOnlyPtr<T>(), inTangents.Length, start, length, flags);
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0001696C File Offset: 0x00014B6C
		public void GetColors(List<Color> colors)
		{
			bool flag = colors == null;
			if (flag)
			{
				throw new ArgumentNullException("colors", "The result colors list cannot be null.");
			}
			this.GetListForChannel<Color>(colors, this.vertexCount, VertexAttribute.Color, Mesh.DefaultDimensionForChannel(VertexAttribute.Color));
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x000169A7 File Offset: 0x00014BA7
		public void SetColors(List<Color> inColors)
		{
			this.SetColors(inColors, 0, NoAllocHelpers.SafeLength<Color>(inColors));
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x000169B9 File Offset: 0x00014BB9
		[ExcludeFromDocs]
		public void SetColors(List<Color> inColors, int start, int length)
		{
			this.SetColors(inColors, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x000169C7 File Offset: 0x00014BC7
		public void SetColors(List<Color> inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetListForChannel<Color>(VertexAttribute.Color, inColors, start, length, flags);
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x000169D7 File Offset: 0x00014BD7
		public void SetColors(Color[] inColors)
		{
			this.SetColors(inColors, 0, NoAllocHelpers.SafeLength(inColors));
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x000169E9 File Offset: 0x00014BE9
		[ExcludeFromDocs]
		public void SetColors(Color[] inColors, int start, int length)
		{
			this.SetColors(inColors, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x000169F8 File Offset: 0x00014BF8
		public void SetColors(Color[] inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(VertexAttribute.Color, VertexAttributeFormat.Float32, Mesh.DefaultDimensionForChannel(VertexAttribute.Color), inColors, NoAllocHelpers.SafeLength(inColors), start, length, flags);
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x00016A20 File Offset: 0x00014C20
		public void GetColors(List<Color32> colors)
		{
			bool flag = colors == null;
			if (flag)
			{
				throw new ArgumentNullException("colors", "The result colors list cannot be null.");
			}
			this.GetListForChannel<Color32>(colors, this.vertexCount, VertexAttribute.Color, 4, VertexAttributeFormat.UNorm8);
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x00016A57 File Offset: 0x00014C57
		public void SetColors(List<Color32> inColors)
		{
			this.SetColors(inColors, 0, NoAllocHelpers.SafeLength<Color32>(inColors));
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x00016A69 File Offset: 0x00014C69
		[ExcludeFromDocs]
		public void SetColors(List<Color32> inColors, int start, int length)
		{
			this.SetColors(inColors, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x00016A77 File Offset: 0x00014C77
		public void SetColors(List<Color32> inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetListForChannel<Color32>(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4, inColors, start, length, flags);
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x00016A89 File Offset: 0x00014C89
		public void SetColors(Color32[] inColors)
		{
			this.SetColors(inColors, 0, NoAllocHelpers.SafeLength(inColors));
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x00016A9B File Offset: 0x00014C9B
		[ExcludeFromDocs]
		public void SetColors(Color32[] inColors, int start, int length)
		{
			this.SetColors(inColors, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x00016AAC File Offset: 0x00014CAC
		public void SetColors(Color32[] inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetSizedArrayForChannel(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4, inColors, NoAllocHelpers.SafeLength(inColors), start, length, flags);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00016ACF File Offset: 0x00014CCF
		public void SetColors<T>(NativeArray<T> inColors) where T : struct
		{
			this.SetColors<T>(inColors, 0, inColors.Length);
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x00016AE2 File Offset: 0x00014CE2
		[ExcludeFromDocs]
		public void SetColors<T>(NativeArray<T> inColors, int start, int length) where T : struct
		{
			this.SetColors<T>(inColors, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00016AF0 File Offset: 0x00014CF0
		public void SetColors<T>(NativeArray<T> inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct
		{
			int num = UnsafeUtility.SizeOf<T>();
			bool flag = num != 16 && num != 4;
			if (flag)
			{
				throw new ArgumentException("SetColors with NativeArray should use struct type that is 16 bytes (4x float) or 4 bytes (4x unorm) in size");
			}
			this.SetSizedNativeArrayForChannel(VertexAttribute.Color, (num == 4) ? VertexAttributeFormat.UNorm8 : VertexAttributeFormat.Float32, 4, (IntPtr)inColors.GetUnsafeReadOnlyPtr<T>(), inColors.Length, start, length, flags);
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x00016B4C File Offset: 0x00014D4C
		private void SetUvsImpl<T>(int uvIndex, int dim, List<T> uvs, int start, int length, MeshUpdateFlags flags)
		{
			bool flag = uvIndex < 0 || uvIndex > 7;
			if (flag)
			{
				Debug.LogError("The uv index is invalid. Must be in the range 0 to 7.");
			}
			else
			{
				this.SetListForChannel<T>(Mesh.GetUVChannel(uvIndex), VertexAttributeFormat.Float32, dim, uvs, start, length, flags);
			}
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x00016B8D File Offset: 0x00014D8D
		public void SetUVs(int channel, List<Vector2> uvs)
		{
			this.SetUVs(channel, uvs, 0, NoAllocHelpers.SafeLength<Vector2>(uvs));
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x00016BA0 File Offset: 0x00014DA0
		public void SetUVs(int channel, List<Vector3> uvs)
		{
			this.SetUVs(channel, uvs, 0, NoAllocHelpers.SafeLength<Vector3>(uvs));
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x00016BB3 File Offset: 0x00014DB3
		public void SetUVs(int channel, List<Vector4> uvs)
		{
			this.SetUVs(channel, uvs, 0, NoAllocHelpers.SafeLength<Vector4>(uvs));
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x00016BC6 File Offset: 0x00014DC6
		[ExcludeFromDocs]
		public void SetUVs(int channel, List<Vector2> uvs, int start, int length)
		{
			this.SetUVs(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x00016BD6 File Offset: 0x00014DD6
		public void SetUVs(int channel, List<Vector2> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetUvsImpl<Vector2>(channel, 2, uvs, start, length, flags);
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x00016BE8 File Offset: 0x00014DE8
		[ExcludeFromDocs]
		public void SetUVs(int channel, List<Vector3> uvs, int start, int length)
		{
			this.SetUVs(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x00016BF8 File Offset: 0x00014DF8
		public void SetUVs(int channel, List<Vector3> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetUvsImpl<Vector3>(channel, 3, uvs, start, length, flags);
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x00016C0A File Offset: 0x00014E0A
		[ExcludeFromDocs]
		public void SetUVs(int channel, List<Vector4> uvs, int start, int length)
		{
			this.SetUVs(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x00016C1A File Offset: 0x00014E1A
		public void SetUVs(int channel, List<Vector4> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetUvsImpl<Vector4>(channel, 4, uvs, start, length, flags);
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x00016C2C File Offset: 0x00014E2C
		private void SetUvsImpl(int uvIndex, int dim, Array uvs, int arrayStart, int arraySize, MeshUpdateFlags flags)
		{
			bool flag = uvIndex < 0 || uvIndex > 7;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("uvIndex", uvIndex, "The uv index is invalid. Must be in the range 0 to 7.");
			}
			this.SetSizedArrayForChannel(Mesh.GetUVChannel(uvIndex), VertexAttributeFormat.Float32, dim, uvs, NoAllocHelpers.SafeLength(uvs), arrayStart, arraySize, flags);
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x00016C7B File Offset: 0x00014E7B
		public void SetUVs(int channel, Vector2[] uvs)
		{
			this.SetUVs(channel, uvs, 0, NoAllocHelpers.SafeLength(uvs));
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x00016C8E File Offset: 0x00014E8E
		public void SetUVs(int channel, Vector3[] uvs)
		{
			this.SetUVs(channel, uvs, 0, NoAllocHelpers.SafeLength(uvs));
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x00016CA1 File Offset: 0x00014EA1
		public void SetUVs(int channel, Vector4[] uvs)
		{
			this.SetUVs(channel, uvs, 0, NoAllocHelpers.SafeLength(uvs));
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x00016CB4 File Offset: 0x00014EB4
		[ExcludeFromDocs]
		public void SetUVs(int channel, Vector2[] uvs, int start, int length)
		{
			this.SetUVs(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x00016CC4 File Offset: 0x00014EC4
		public void SetUVs(int channel, Vector2[] uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetUvsImpl(channel, 2, uvs, start, length, flags);
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x00016CD6 File Offset: 0x00014ED6
		[ExcludeFromDocs]
		public void SetUVs(int channel, Vector3[] uvs, int start, int length)
		{
			this.SetUVs(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x00016CE6 File Offset: 0x00014EE6
		public void SetUVs(int channel, Vector3[] uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetUvsImpl(channel, 3, uvs, start, length, flags);
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x00016CF8 File Offset: 0x00014EF8
		[ExcludeFromDocs]
		public void SetUVs(int channel, Vector4[] uvs, int start, int length)
		{
			this.SetUVs(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x00016D08 File Offset: 0x00014F08
		public void SetUVs(int channel, Vector4[] uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			this.SetUvsImpl(channel, 4, uvs, start, length, flags);
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x00016D1A File Offset: 0x00014F1A
		public void SetUVs<T>(int channel, NativeArray<T> uvs) where T : struct
		{
			this.SetUVs<T>(channel, uvs, 0, uvs.Length);
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x00016D2E File Offset: 0x00014F2E
		[ExcludeFromDocs]
		public void SetUVs<T>(int channel, NativeArray<T> uvs, int start, int length) where T : struct
		{
			this.SetUVs<T>(channel, uvs, start, length, MeshUpdateFlags.Default);
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x00016D40 File Offset: 0x00014F40
		public void SetUVs<T>(int channel, NativeArray<T> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct
		{
			bool flag = channel < 0 || channel > 7;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("channel", channel, "The uv index is invalid. Must be in the range 0 to 7.");
			}
			int num = UnsafeUtility.SizeOf<T>();
			bool flag2 = (num & 3) != 0;
			if (flag2)
			{
				throw new ArgumentException("SetUVs with NativeArray should use struct type that is multiple of 4 bytes in size");
			}
			int num2 = num / 4;
			bool flag3 = num2 < 1 || num2 > 4;
			if (flag3)
			{
				throw new ArgumentException("SetUVs with NativeArray should use struct type that is 1..4 floats in size");
			}
			this.SetSizedNativeArrayForChannel(Mesh.GetUVChannel(channel), VertexAttributeFormat.Float32, num2, (IntPtr)uvs.GetUnsafeReadOnlyPtr<T>(), uvs.Length, start, length, flags);
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x00016DD4 File Offset: 0x00014FD4
		private void GetUVsImpl<T>(int uvIndex, List<T> uvs, int dim)
		{
			bool flag = uvs == null;
			if (flag)
			{
				throw new ArgumentNullException("uvs", "The result uvs list cannot be null.");
			}
			bool flag2 = uvIndex < 0 || uvIndex > 7;
			if (flag2)
			{
				throw new IndexOutOfRangeException("The uv index is invalid. Must be in the range 0 to 7.");
			}
			this.GetListForChannel<T>(uvs, this.vertexCount, Mesh.GetUVChannel(uvIndex), dim);
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x00016E29 File Offset: 0x00015029
		public void GetUVs(int channel, List<Vector2> uvs)
		{
			this.GetUVsImpl<Vector2>(channel, uvs, 2);
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x00016E36 File Offset: 0x00015036
		public void GetUVs(int channel, List<Vector3> uvs)
		{
			this.GetUVsImpl<Vector3>(channel, uvs, 3);
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x00016E43 File Offset: 0x00015043
		public void GetUVs(int channel, List<Vector4> uvs)
		{
			this.GetUVsImpl<Vector4>(channel, uvs, 4);
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06001131 RID: 4401 RVA: 0x00016E50 File Offset: 0x00015050
		public int vertexAttributeCount
		{
			get
			{
				return this.GetVertexAttributeCountImpl();
			}
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x00016E68 File Offset: 0x00015068
		public VertexAttributeDescriptor[] GetVertexAttributes()
		{
			return (VertexAttributeDescriptor[])this.GetVertexAttributesAlloc();
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x00016E88 File Offset: 0x00015088
		public int GetVertexAttributes(VertexAttributeDescriptor[] attributes)
		{
			return this.GetVertexAttributesArray(attributes);
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x00016EA4 File Offset: 0x000150A4
		public int GetVertexAttributes(List<VertexAttributeDescriptor> attributes)
		{
			return this.GetVertexAttributesList(attributes);
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x00016EBD File Offset: 0x000150BD
		public void SetVertexBufferParams(int vertexCount, params VertexAttributeDescriptor[] attributes)
		{
			this.SetVertexBufferParamsFromArray(vertexCount, attributes);
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x00016EC9 File Offset: 0x000150C9
		public void SetVertexBufferParams(int vertexCount, NativeArray<VertexAttributeDescriptor> attributes)
		{
			this.SetVertexBufferParamsFromPtr(vertexCount, (IntPtr)attributes.GetUnsafeReadOnlyPtr<VertexAttributeDescriptor>(), attributes.Length);
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x00016EE8 File Offset: 0x000150E8
		public void SetVertexBufferData<T>(NativeArray<T> data, int dataStart, int meshBufferStart, int count, int stream = 0, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = !this.canAccess;
			if (flag)
			{
				throw new InvalidOperationException("Not allowed to access vertex data on mesh '" + base.name + "' (isReadable is false; Read/Write must be enabled in import settings)");
			}
			bool flag2 = dataStart < 0 || meshBufferStart < 0 || count < 0 || dataStart + count > data.Length;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (dataStart:{0} meshBufferStart:{1} count:{2})", dataStart, meshBufferStart, count));
			}
			this.InternalSetVertexBufferData(stream, (IntPtr)data.GetUnsafeReadOnlyPtr<T>(), dataStart, meshBufferStart, count, UnsafeUtility.SizeOf<T>(), flags);
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x00016F84 File Offset: 0x00015184
		public void SetVertexBufferData<T>(T[] data, int dataStart, int meshBufferStart, int count, int stream = 0, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = !this.canAccess;
			if (flag)
			{
				throw new InvalidOperationException("Not allowed to access vertex data on mesh '" + base.name + "' (isReadable is false; Read/Write must be enabled in import settings)");
			}
			bool flag2 = !UnsafeUtility.IsArrayBlittable(data);
			if (flag2)
			{
				throw new ArgumentException("Array passed to SetVertexBufferData must be blittable.\n" + UnsafeUtility.GetReasonForArrayNonBlittable(data));
			}
			bool flag3 = dataStart < 0 || meshBufferStart < 0 || count < 0 || dataStart + count > data.Length;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (dataStart:{0} meshBufferStart:{1} count:{2})", dataStart, meshBufferStart, count));
			}
			this.InternalSetVertexBufferDataFromArray(stream, data, dataStart, meshBufferStart, count, UnsafeUtility.SizeOf<T>(), flags);
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x00017034 File Offset: 0x00015234
		public void SetVertexBufferData<T>(List<T> data, int dataStart, int meshBufferStart, int count, int stream = 0, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = !this.canAccess;
			if (flag)
			{
				throw new InvalidOperationException("Not allowed to access vertex data on mesh '" + base.name + "' (isReadable is false; Read/Write must be enabled in import settings)");
			}
			bool flag2 = !UnsafeUtility.IsGenericListBlittable<T>();
			if (flag2)
			{
				throw new ArgumentException(string.Format("List<{0}> passed to {1} must be blittable.\n{2}", typeof(T), "SetVertexBufferData", UnsafeUtility.GetReasonForGenericListNonBlittable<T>()));
			}
			bool flag3 = dataStart < 0 || meshBufferStart < 0 || count < 0 || dataStart + count > data.Count;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (dataStart:{0} meshBufferStart:{1} count:{2})", dataStart, meshBufferStart, count));
			}
			this.InternalSetVertexBufferDataFromArray(stream, NoAllocHelpers.ExtractArrayFromList(data), dataStart, meshBufferStart, count, UnsafeUtility.SizeOf<T>(), flags);
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x000170F8 File Offset: 0x000152F8
		public static Mesh.MeshDataArray AcquireReadOnlyMeshData(Mesh mesh)
		{
			return new Mesh.MeshDataArray(mesh, true);
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x00017114 File Offset: 0x00015314
		public static Mesh.MeshDataArray AcquireReadOnlyMeshData(Mesh[] meshes)
		{
			bool flag = meshes == null;
			if (flag)
			{
				throw new ArgumentNullException("meshes", "Mesh array is null");
			}
			return new Mesh.MeshDataArray(meshes, meshes.Length, true);
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x00017148 File Offset: 0x00015348
		public static Mesh.MeshDataArray AcquireReadOnlyMeshData(List<Mesh> meshes)
		{
			bool flag = meshes == null;
			if (flag)
			{
				throw new ArgumentNullException("meshes", "Mesh list is null");
			}
			return new Mesh.MeshDataArray(NoAllocHelpers.ExtractArrayFromListT<Mesh>(meshes), meshes.Count, true);
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x00017184 File Offset: 0x00015384
		public static Mesh.MeshDataArray AllocateWritableMeshData(int meshCount)
		{
			return new Mesh.MeshDataArray(meshCount);
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x0001719C File Offset: 0x0001539C
		public static void ApplyAndDisposeWritableMeshData(Mesh.MeshDataArray data, Mesh mesh, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			bool flag = mesh == null;
			if (flag)
			{
				throw new ArgumentNullException("mesh", "Mesh is null");
			}
			bool flag2 = data.Length != 1;
			if (flag2)
			{
				throw new InvalidOperationException(string.Format("{0} length must be 1 to apply to one mesh, was {1}", "MeshDataArray", data.Length));
			}
			data.ApplyToMeshAndDispose(mesh, flags);
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x00017204 File Offset: 0x00015404
		public static void ApplyAndDisposeWritableMeshData(Mesh.MeshDataArray data, Mesh[] meshes, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			bool flag = meshes == null;
			if (flag)
			{
				throw new ArgumentNullException("meshes", "Mesh array is null");
			}
			bool flag2 = data.Length != meshes.Length;
			if (flag2)
			{
				throw new InvalidOperationException(string.Format("{0} length ({1}) must match destination meshes array length ({2})", "MeshDataArray", data.Length, meshes.Length));
			}
			data.ApplyToMeshesAndDispose(meshes, flags);
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x00017270 File Offset: 0x00015470
		public static void ApplyAndDisposeWritableMeshData(Mesh.MeshDataArray data, List<Mesh> meshes, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			bool flag = meshes == null;
			if (flag)
			{
				throw new ArgumentNullException("meshes", "Mesh list is null");
			}
			bool flag2 = data.Length != meshes.Count;
			if (flag2)
			{
				throw new InvalidOperationException(string.Format("{0} length ({1}) must match destination meshes list length ({2})", "MeshDataArray", data.Length, meshes.Count));
			}
			data.ApplyToMeshesAndDispose(NoAllocHelpers.ExtractArrayFromListT<Mesh>(meshes), flags);
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x000172E8 File Offset: 0x000154E8
		public GraphicsBuffer GetVertexBuffer(int index)
		{
			bool flag = this == null;
			if (flag)
			{
				throw new NullReferenceException();
			}
			return this.GetVertexBufferImpl(index);
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x00017314 File Offset: 0x00015514
		public GraphicsBuffer GetIndexBuffer()
		{
			bool flag = this == null;
			if (flag)
			{
				throw new NullReferenceException();
			}
			return this.GetIndexBufferImpl();
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x00017340 File Offset: 0x00015540
		public GraphicsBuffer GetBoneWeightBuffer(SkinWeights layout)
		{
			bool flag = this == null;
			if (flag)
			{
				throw new NullReferenceException();
			}
			bool flag2 = layout == SkinWeights.None;
			GraphicsBuffer result;
			if (flag2)
			{
				Debug.LogError(string.Format("Only possible to access bone weights buffer for values: {0}, {1}, {2} and {3}.", new object[]
				{
					SkinWeights.OneBone,
					SkinWeights.TwoBones,
					SkinWeights.FourBones,
					SkinWeights.Unlimited
				}));
				result = null;
			}
			else
			{
				GraphicsBuffer boneWeightBufferImpl = this.GetBoneWeightBufferImpl((int)layout);
				result = boneWeightBufferImpl;
			}
			return result;
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x000173B8 File Offset: 0x000155B8
		public GraphicsBuffer GetBlendShapeBuffer(BlendShapeBufferLayout layout)
		{
			bool flag = this == null;
			if (flag)
			{
				throw new NullReferenceException();
			}
			bool flag2 = !SystemInfo.supportsComputeShaders;
			GraphicsBuffer result;
			if (flag2)
			{
				Debug.LogError("Only possible to access Blend Shape buffer on platforms that supports compute shaders.");
				result = null;
			}
			else
			{
				GraphicsBuffer blendShapeBufferImpl = this.GetBlendShapeBufferImpl((int)layout);
				result = blendShapeBufferImpl;
			}
			return result;
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x00017400 File Offset: 0x00015600
		public GraphicsBuffer GetBlendShapeBuffer()
		{
			bool flag = this == null;
			if (flag)
			{
				throw new NullReferenceException();
			}
			bool flag2 = !SystemInfo.supportsComputeShaders;
			GraphicsBuffer result;
			if (flag2)
			{
				Debug.LogError("Only possible to access Blend Shape buffer on platforms that supports compute shaders.");
				result = null;
			}
			else
			{
				GraphicsBuffer blendShapeBufferImpl = this.GetBlendShapeBufferImpl(0);
				result = blendShapeBufferImpl;
			}
			return result;
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x00017448 File Offset: 0x00015648
		public BlendShapeBufferRange GetBlendShapeBufferRange(int blendShapeIndex)
		{
			bool flag = blendShapeIndex >= this.blendShapeCount || blendShapeIndex < 0;
			BlendShapeBufferRange result;
			if (flag)
			{
				Debug.LogError("Incorrect index used to get blend shape buffer range");
				result = default(BlendShapeBufferRange);
			}
			else
			{
				BlendShape blendShapeOffsetInternal = this.GetBlendShapeOffsetInternal(blendShapeIndex);
				result = new BlendShapeBufferRange
				{
					startIndex = blendShapeOffsetInternal.firstVertex,
					endIndex = blendShapeOffsetInternal.firstVertex + blendShapeOffsetInternal.vertexCount - 1U
				};
			}
			return result;
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x000174C2 File Offset: 0x000156C2
		private void PrintErrorCantAccessIndices()
		{
			Debug.LogError(string.Format("Not allowed to access triangles/indices on mesh '{0}' (isReadable is false; Read/Write must be enabled in import settings)", base.name));
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x000174DC File Offset: 0x000156DC
		private bool CheckCanAccessSubmesh(int submesh, bool errorAboutTriangles)
		{
			bool flag = !this.canAccess;
			bool result;
			if (flag)
			{
				this.PrintErrorCantAccessIndices();
				result = false;
			}
			else
			{
				bool flag2 = submesh < 0 || submesh >= this.subMeshCount;
				if (flag2)
				{
					Debug.LogError(string.Format("Failed getting {0}. Submesh index is out of bounds.", errorAboutTriangles ? "triangles" : "indices"), this);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x00017544 File Offset: 0x00015744
		private bool CheckCanAccessSubmeshTriangles(int submesh)
		{
			return this.CheckCanAccessSubmesh(submesh, true);
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x00017560 File Offset: 0x00015760
		private bool CheckCanAccessSubmeshIndices(int submesh)
		{
			return this.CheckCanAccessSubmesh(submesh, false);
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x0001757C File Offset: 0x0001577C
		// (set) Token: 0x0600114C RID: 4428 RVA: 0x000175B0 File Offset: 0x000157B0
		public int[] triangles
		{
			get
			{
				bool canAccess = this.canAccess;
				int[] result;
				if (canAccess)
				{
					result = this.GetTrianglesImpl(-1, true);
				}
				else
				{
					this.PrintErrorCantAccessIndices();
					result = new int[0];
				}
				return result;
			}
			set
			{
				bool canAccess = this.canAccess;
				if (canAccess)
				{
					this.SetTrianglesImpl(-1, IndexFormat.UInt32, value, NoAllocHelpers.SafeLength(value), 0, NoAllocHelpers.SafeLength(value), true, 0);
				}
				else
				{
					this.PrintErrorCantAccessIndices();
				}
			}
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x000175EC File Offset: 0x000157EC
		public int[] GetTriangles(int submesh)
		{
			return this.GetTriangles(submesh, true);
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x00017608 File Offset: 0x00015808
		public int[] GetTriangles(int submesh, [DefaultValue("true")] bool applyBaseVertex)
		{
			return this.CheckCanAccessSubmeshTriangles(submesh) ? this.GetTrianglesImpl(submesh, applyBaseVertex) : new int[0];
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x00017633 File Offset: 0x00015833
		public void GetTriangles(List<int> triangles, int submesh)
		{
			this.GetTriangles(triangles, submesh, true);
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x00017640 File Offset: 0x00015840
		public void GetTriangles(List<int> triangles, int submesh, [DefaultValue("true")] bool applyBaseVertex)
		{
			bool flag = triangles == null;
			if (flag)
			{
				throw new ArgumentNullException("triangles", "The result triangles list cannot be null.");
			}
			bool flag2 = submesh < 0 || submesh >= this.subMeshCount;
			if (flag2)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			NoAllocHelpers.EnsureListElemCount<int>(triangles, (int)(3U * this.GetTrianglesCountImpl(submesh)));
			this.GetTrianglesNonAllocImpl(NoAllocHelpers.ExtractArrayFromListT<int>(triangles), submesh, applyBaseVertex);
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x000176A8 File Offset: 0x000158A8
		public void GetTriangles(List<ushort> triangles, int submesh, bool applyBaseVertex = true)
		{
			bool flag = triangles == null;
			if (flag)
			{
				throw new ArgumentNullException("triangles", "The result triangles list cannot be null.");
			}
			bool flag2 = submesh < 0 || submesh >= this.subMeshCount;
			if (flag2)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			NoAllocHelpers.EnsureListElemCount<ushort>(triangles, (int)(3U * this.GetTrianglesCountImpl(submesh)));
			this.GetTrianglesNonAllocImpl16(NoAllocHelpers.ExtractArrayFromListT<ushort>(triangles), submesh, applyBaseVertex);
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x00017710 File Offset: 0x00015910
		[ExcludeFromDocs]
		public int[] GetIndices(int submesh)
		{
			return this.GetIndices(submesh, true);
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x0001772C File Offset: 0x0001592C
		public int[] GetIndices(int submesh, [DefaultValue("true")] bool applyBaseVertex)
		{
			return this.CheckCanAccessSubmeshIndices(submesh) ? this.GetIndicesImpl(submesh, applyBaseVertex) : new int[0];
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x00017757 File Offset: 0x00015957
		[ExcludeFromDocs]
		public void GetIndices(List<int> indices, int submesh)
		{
			this.GetIndices(indices, submesh, true);
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x00017764 File Offset: 0x00015964
		public void GetIndices(List<int> indices, int submesh, [DefaultValue("true")] bool applyBaseVertex)
		{
			bool flag = indices == null;
			if (flag)
			{
				throw new ArgumentNullException("indices", "The result indices list cannot be null.");
			}
			bool flag2 = submesh < 0 || submesh >= this.subMeshCount;
			if (flag2)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			NoAllocHelpers.EnsureListElemCount<int>(indices, (int)this.GetIndexCount(submesh));
			this.GetIndicesNonAllocImpl(NoAllocHelpers.ExtractArrayFromListT<int>(indices), submesh, applyBaseVertex);
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x000177CC File Offset: 0x000159CC
		public void GetIndices(List<ushort> indices, int submesh, bool applyBaseVertex = true)
		{
			bool flag = indices == null;
			if (flag)
			{
				throw new ArgumentNullException("indices", "The result indices list cannot be null.");
			}
			bool flag2 = submesh < 0 || submesh >= this.subMeshCount;
			if (flag2)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			NoAllocHelpers.EnsureListElemCount<ushort>(indices, (int)this.GetIndexCount(submesh));
			this.GetIndicesNonAllocImpl16(NoAllocHelpers.ExtractArrayFromListT<ushort>(indices), submesh, applyBaseVertex);
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x00017834 File Offset: 0x00015A34
		public void SetIndexBufferData<T>(NativeArray<T> data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = !this.canAccess;
			if (flag)
			{
				this.PrintErrorCantAccessIndices();
			}
			else
			{
				bool flag2 = dataStart < 0 || meshBufferStart < 0 || count < 0 || dataStart + count > data.Length;
				if (flag2)
				{
					throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (dataStart:{0} meshBufferStart:{1} count:{2})", dataStart, meshBufferStart, count));
				}
				this.InternalSetIndexBufferData((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), dataStart, meshBufferStart, count, UnsafeUtility.SizeOf<T>(), flags);
			}
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x000178BC File Offset: 0x00015ABC
		public void SetIndexBufferData<T>(T[] data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = !this.canAccess;
			if (flag)
			{
				this.PrintErrorCantAccessIndices();
			}
			else
			{
				bool flag2 = !UnsafeUtility.IsArrayBlittable(data);
				if (flag2)
				{
					throw new ArgumentException("Array passed to SetIndexBufferData must be blittable.\n" + UnsafeUtility.GetReasonForArrayNonBlittable(data));
				}
				bool flag3 = dataStart < 0 || meshBufferStart < 0 || count < 0 || dataStart + count > data.Length;
				if (flag3)
				{
					throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (dataStart:{0} meshBufferStart:{1} count:{2})", dataStart, meshBufferStart, count));
				}
				this.InternalSetIndexBufferDataFromArray(data, dataStart, meshBufferStart, count, UnsafeUtility.SizeOf<T>(), flags);
			}
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x00017958 File Offset: 0x00015B58
		public void SetIndexBufferData<T>(List<T> data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = !this.canAccess;
			if (flag)
			{
				this.PrintErrorCantAccessIndices();
			}
			else
			{
				bool flag2 = !UnsafeUtility.IsGenericListBlittable<T>();
				if (flag2)
				{
					throw new ArgumentException(string.Format("List<{0}> passed to {1} must be blittable.\n{2}", typeof(T), "SetIndexBufferData", UnsafeUtility.GetReasonForGenericListNonBlittable<T>()));
				}
				bool flag3 = dataStart < 0 || meshBufferStart < 0 || count < 0 || dataStart + count > data.Count;
				if (flag3)
				{
					throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (dataStart:{0} meshBufferStart:{1} count:{2})", dataStart, meshBufferStart, count));
				}
				this.InternalSetIndexBufferDataFromArray(NoAllocHelpers.ExtractArrayFromList(data), dataStart, meshBufferStart, count, UnsafeUtility.SizeOf<T>(), flags);
			}
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x00017A0C File Offset: 0x00015C0C
		public uint GetIndexStart(int submesh)
		{
			bool flag = submesh < 0 || submesh >= this.subMeshCount;
			if (flag)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			return this.GetIndexStartImpl(submesh);
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x00017A48 File Offset: 0x00015C48
		public uint GetIndexCount(int submesh)
		{
			bool flag = submesh < 0 || submesh >= this.subMeshCount;
			if (flag)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			return this.GetIndexCountImpl(submesh);
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x00017A84 File Offset: 0x00015C84
		public uint GetBaseVertex(int submesh)
		{
			bool flag = submesh < 0 || submesh >= this.subMeshCount;
			if (flag)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			return this.GetBaseVertexImpl(submesh);
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x00017AC0 File Offset: 0x00015CC0
		private void CheckIndicesArrayRange(int valuesLength, int start, int length)
		{
			bool flag = start < 0;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("start", start, "Mesh indices array start can't be negative.");
			}
			bool flag2 = length < 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("length", length, "Mesh indices array length can't be negative.");
			}
			bool flag3 = start >= valuesLength && length != 0;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("start", start, "Mesh indices array start is outside of array size.");
			}
			bool flag4 = start + length > valuesLength;
			if (flag4)
			{
				throw new ArgumentOutOfRangeException("length", start + length, "Mesh indices array start+count is outside of array size.");
			}
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x00017B54 File Offset: 0x00015D54
		private void SetTrianglesImpl(int submesh, IndexFormat indicesFormat, Array triangles, int trianglesArrayLength, int start, int length, bool calculateBounds, int baseVertex)
		{
			this.CheckIndicesArrayRange(trianglesArrayLength, start, length);
			this.SetIndicesImpl(submesh, MeshTopology.Triangles, indicesFormat, triangles, start, length, calculateBounds, baseVertex);
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x00017B82 File Offset: 0x00015D82
		[ExcludeFromDocs]
		public void SetTriangles(int[] triangles, int submesh)
		{
			this.SetTriangles(triangles, submesh, true, 0);
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x00017B90 File Offset: 0x00015D90
		[ExcludeFromDocs]
		public void SetTriangles(int[] triangles, int submesh, bool calculateBounds)
		{
			this.SetTriangles(triangles, submesh, calculateBounds, 0);
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x00017B9E File Offset: 0x00015D9E
		public void SetTriangles(int[] triangles, int submesh, [DefaultValue("true")] bool calculateBounds, [DefaultValue("0")] int baseVertex)
		{
			this.SetTriangles(triangles, 0, NoAllocHelpers.SafeLength(triangles), submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x00017BB4 File Offset: 0x00015DB4
		public void SetTriangles(int[] triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshTriangles(submesh);
			if (flag)
			{
				this.SetTrianglesImpl(submesh, IndexFormat.UInt32, triangles, NoAllocHelpers.SafeLength(triangles), trianglesStart, trianglesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x00017BE5 File Offset: 0x00015DE5
		public void SetTriangles(ushort[] triangles, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			this.SetTriangles(triangles, 0, NoAllocHelpers.SafeLength(triangles), submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x00017BFC File Offset: 0x00015DFC
		public void SetTriangles(ushort[] triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshTriangles(submesh);
			if (flag)
			{
				this.SetTrianglesImpl(submesh, IndexFormat.UInt16, triangles, NoAllocHelpers.SafeLength(triangles), trianglesStart, trianglesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x00017C2D File Offset: 0x00015E2D
		[ExcludeFromDocs]
		public void SetTriangles(List<int> triangles, int submesh)
		{
			this.SetTriangles(triangles, submesh, true, 0);
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x00017C3B File Offset: 0x00015E3B
		[ExcludeFromDocs]
		public void SetTriangles(List<int> triangles, int submesh, bool calculateBounds)
		{
			this.SetTriangles(triangles, submesh, calculateBounds, 0);
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x00017C49 File Offset: 0x00015E49
		public void SetTriangles(List<int> triangles, int submesh, [DefaultValue("true")] bool calculateBounds, [DefaultValue("0")] int baseVertex)
		{
			this.SetTriangles(triangles, 0, NoAllocHelpers.SafeLength<int>(triangles), submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x00017C60 File Offset: 0x00015E60
		public void SetTriangles(List<int> triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshTriangles(submesh);
			if (flag)
			{
				this.SetTrianglesImpl(submesh, IndexFormat.UInt32, NoAllocHelpers.ExtractArrayFromList(triangles), NoAllocHelpers.SafeLength<int>(triangles), trianglesStart, trianglesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x00017C96 File Offset: 0x00015E96
		public void SetTriangles(List<ushort> triangles, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			this.SetTriangles(triangles, 0, NoAllocHelpers.SafeLength<ushort>(triangles), submesh, calculateBounds, baseVertex);
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x00017CAC File Offset: 0x00015EAC
		public void SetTriangles(List<ushort> triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshTriangles(submesh);
			if (flag)
			{
				this.SetTrianglesImpl(submesh, IndexFormat.UInt16, NoAllocHelpers.ExtractArrayFromList(triangles), NoAllocHelpers.SafeLength<ushort>(triangles), trianglesStart, trianglesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x00017CE2 File Offset: 0x00015EE2
		[ExcludeFromDocs]
		public void SetIndices(int[] indices, MeshTopology topology, int submesh)
		{
			this.SetIndices(indices, topology, submesh, true, 0);
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x00017CF1 File Offset: 0x00015EF1
		[ExcludeFromDocs]
		public void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds)
		{
			this.SetIndices(indices, topology, submesh, calculateBounds, 0);
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x00017D01 File Offset: 0x00015F01
		public void SetIndices(int[] indices, MeshTopology topology, int submesh, [DefaultValue("true")] bool calculateBounds, [DefaultValue("0")] int baseVertex)
		{
			this.SetIndices(indices, 0, NoAllocHelpers.SafeLength(indices), topology, submesh, calculateBounds, baseVertex);
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x00017D1C File Offset: 0x00015F1C
		public void SetIndices(int[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshIndices(submesh);
			if (flag)
			{
				this.CheckIndicesArrayRange(NoAllocHelpers.SafeLength(indices), indicesStart, indicesLength);
				this.SetIndicesImpl(submesh, topology, IndexFormat.UInt32, indices, indicesStart, indicesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x00017D5A File Offset: 0x00015F5A
		public void SetIndices(ushort[] indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			this.SetIndices(indices, 0, NoAllocHelpers.SafeLength(indices), topology, submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x00017D74 File Offset: 0x00015F74
		public void SetIndices(ushort[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshIndices(submesh);
			if (flag)
			{
				this.CheckIndicesArrayRange(NoAllocHelpers.SafeLength(indices), indicesStart, indicesLength);
				this.SetIndicesImpl(submesh, topology, IndexFormat.UInt16, indices, indicesStart, indicesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x00017DB2 File Offset: 0x00015FB2
		public void SetIndices<T>(NativeArray<T> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) where T : struct
		{
			this.SetIndices<T>(indices, 0, indices.Length, topology, submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x00017DCC File Offset: 0x00015FCC
		public void SetIndices<T>(NativeArray<T> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) where T : struct
		{
			bool flag = this.CheckCanAccessSubmeshIndices(submesh);
			if (flag)
			{
				int num = UnsafeUtility.SizeOf<T>();
				bool flag2 = num != 2 && num != 4;
				if (flag2)
				{
					throw new ArgumentException("SetIndices with NativeArray should use type is 2 or 4 bytes in size");
				}
				this.CheckIndicesArrayRange(indices.Length, indicesStart, indicesLength);
				this.SetIndicesNativeArrayImpl(submesh, topology, (num == 2) ? IndexFormat.UInt16 : IndexFormat.UInt32, (IntPtr)indices.GetUnsafeReadOnlyPtr<T>(), indicesStart, indicesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x00017E3F File Offset: 0x0001603F
		public void SetIndices(List<int> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			this.SetIndices(indices, 0, NoAllocHelpers.SafeLength<int>(indices), topology, submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x00017E58 File Offset: 0x00016058
		public void SetIndices(List<int> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshIndices(submesh);
			if (flag)
			{
				Array indices2 = NoAllocHelpers.ExtractArrayFromList(indices);
				this.CheckIndicesArrayRange(NoAllocHelpers.SafeLength<int>(indices), indicesStart, indicesLength);
				this.SetIndicesImpl(submesh, topology, IndexFormat.UInt32, indices2, indicesStart, indicesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x00017E9D File Offset: 0x0001609D
		public void SetIndices(List<ushort> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			this.SetIndices(indices, 0, NoAllocHelpers.SafeLength<ushort>(indices), topology, submesh, calculateBounds, baseVertex);
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x00017EB8 File Offset: 0x000160B8
		public void SetIndices(List<ushort> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0)
		{
			bool flag = this.CheckCanAccessSubmeshIndices(submesh);
			if (flag)
			{
				Array indices2 = NoAllocHelpers.ExtractArrayFromList(indices);
				this.CheckIndicesArrayRange(NoAllocHelpers.SafeLength<ushort>(indices), indicesStart, indicesLength);
				this.SetIndicesImpl(submesh, topology, IndexFormat.UInt16, indices2, indicesStart, indicesLength, calculateBounds, baseVertex);
			}
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x00017F00 File Offset: 0x00016100
		public void SetSubMeshes(SubMeshDescriptor[] desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			bool flag = count > 0 && desc == null;
			if (flag)
			{
				throw new ArgumentNullException("desc", "Array of submeshes cannot be null unless count is zero.");
			}
			int num = (desc != null) ? desc.Length : 0;
			bool flag2 = start < 0 || count < 0 || start + count > num;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1} desc.Length:{2})", start, count, num));
			}
			for (int i = start; i < start + count; i++)
			{
				MeshTopology topology = desc[i].topology;
				bool flag3 = topology < MeshTopology.Triangles || topology > MeshTopology.Points;
				if (flag3)
				{
					throw new ArgumentException("desc", string.Format("{0}-th submesh descriptor has invalid topology ({1}).", i, (int)topology));
				}
				bool flag4 = topology == (MeshTopology)1;
				if (flag4)
				{
					throw new ArgumentException("desc", string.Format("{0}-th submesh descriptor has triangles strip topology, which is no longer supported.", i));
				}
			}
			this.SetAllSubMeshesAtOnceFromArray(desc, start, count, flags);
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x00017FF9 File Offset: 0x000161F9
		public void SetSubMeshes(SubMeshDescriptor[] desc, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			this.SetSubMeshes(desc, 0, (desc != null) ? desc.Length : 0, flags);
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x0001800F File Offset: 0x0001620F
		public void SetSubMeshes(List<SubMeshDescriptor> desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			this.SetSubMeshes(NoAllocHelpers.ExtractArrayFromListT<SubMeshDescriptor>(desc), start, count, flags);
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x00018023 File Offset: 0x00016223
		public void SetSubMeshes(List<SubMeshDescriptor> desc, MeshUpdateFlags flags = MeshUpdateFlags.Default)
		{
			this.SetSubMeshes(NoAllocHelpers.ExtractArrayFromListT<SubMeshDescriptor>(desc), 0, (desc != null) ? desc.Count : 0, flags);
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x00018044 File Offset: 0x00016244
		public void SetSubMeshes<T>(NativeArray<T> desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			bool flag = UnsafeUtility.SizeOf<T>() != UnsafeUtility.SizeOf<SubMeshDescriptor>();
			if (flag)
			{
				throw new ArgumentException(string.Format("{0} with NativeArray should use struct type that is {1} bytes in size", "SetSubMeshes", UnsafeUtility.SizeOf<SubMeshDescriptor>()));
			}
			bool flag2 = start < 0 || count < 0 || start + count > desc.Length;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1} desc.Length:{2})", start, count, desc.Length));
			}
			this.SetAllSubMeshesAtOnceFromNativeArray((IntPtr)desc.GetUnsafeReadOnlyPtr<T>(), start, count, flags);
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x000180DD File Offset: 0x000162DD
		public void SetSubMeshes<T>(NativeArray<T> desc, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct
		{
			this.SetSubMeshes<T>(desc, 0, desc.Length, flags);
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x000180F4 File Offset: 0x000162F4
		public void GetBindposes(List<Matrix4x4> bindposes)
		{
			bool flag = bindposes == null;
			if (flag)
			{
				throw new ArgumentNullException("bindposes", "The result bindposes list cannot be null.");
			}
			NoAllocHelpers.EnsureListElemCount<Matrix4x4>(bindposes, this.bindposeCount);
			this.GetBindposesNonAllocImpl(NoAllocHelpers.ExtractArrayFromListT<Matrix4x4>(bindposes));
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x00018134 File Offset: 0x00016334
		public void GetBoneWeights(List<BoneWeight> boneWeights)
		{
			bool flag = boneWeights == null;
			if (flag)
			{
				throw new ArgumentNullException("boneWeights", "The result boneWeights list cannot be null.");
			}
			bool flag2 = this.HasBoneWeights();
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<BoneWeight>(boneWeights, this.vertexCount);
			}
			this.GetBoneWeightsNonAllocImpl(NoAllocHelpers.ExtractArrayFromListT<BoneWeight>(boneWeights));
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x0600117F RID: 4479 RVA: 0x00018180 File Offset: 0x00016380
		// (set) Token: 0x06001180 RID: 4480 RVA: 0x00018198 File Offset: 0x00016398
		public BoneWeight[] boneWeights
		{
			get
			{
				return this.GetBoneWeightsImpl();
			}
			set
			{
				this.SetBoneWeightsImpl(value);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06001181 RID: 4481 RVA: 0x000181A4 File Offset: 0x000163A4
		public SkinWeights skinWeightBufferLayout
		{
			get
			{
				return (SkinWeights)this.GetBoneWeightBufferLayoutInternal();
			}
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x000181BC File Offset: 0x000163BC
		public void Clear([DefaultValue("true")] bool keepVertexLayout)
		{
			this.ClearImpl(keepVertexLayout);
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x000181C7 File Offset: 0x000163C7
		[ExcludeFromDocs]
		public void Clear()
		{
			this.ClearImpl(true);
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x000181D2 File Offset: 0x000163D2
		[ExcludeFromDocs]
		public void RecalculateBounds()
		{
			this.RecalculateBounds(MeshUpdateFlags.Default);
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x000181DD File Offset: 0x000163DD
		[ExcludeFromDocs]
		public void RecalculateNormals()
		{
			this.RecalculateNormals(MeshUpdateFlags.Default);
		}

		// Token: 0x06001186 RID: 4486 RVA: 0x000181E8 File Offset: 0x000163E8
		[ExcludeFromDocs]
		public void RecalculateTangents()
		{
			this.RecalculateTangents(MeshUpdateFlags.Default);
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x000181F4 File Offset: 0x000163F4
		public void RecalculateBounds([DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.RecalculateBoundsImpl(flags);
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call RecalculateBounds() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x0001822C File Offset: 0x0001642C
		public void RecalculateNormals([DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.RecalculateNormalsImpl(flags);
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call RecalculateNormals() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x06001189 RID: 4489 RVA: 0x00018264 File Offset: 0x00016464
		public void RecalculateTangents([DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.RecalculateTangentsImpl(flags);
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call RecalculateTangents() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x0600118A RID: 4490 RVA: 0x0001829C File Offset: 0x0001649C
		public void RecalculateUVDistributionMetric(int uvSetIndex, float uvAreaThreshold = 1E-09f)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.RecalculateUVDistributionMetricImpl(uvSetIndex, uvAreaThreshold);
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call RecalculateUVDistributionMetric() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x000182D8 File Offset: 0x000164D8
		public void RecalculateUVDistributionMetrics(float uvAreaThreshold = 1E-09f)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.RecalculateUVDistributionMetricsImpl(uvAreaThreshold);
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call RecalculateUVDistributionMetrics() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x00018310 File Offset: 0x00016510
		public void MarkDynamic()
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.MarkDynamicImpl();
			}
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00018330 File Offset: 0x00016530
		public void UploadMeshData(bool markNoLongerReadable)
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.UploadMeshDataImpl(markNoLongerReadable);
			}
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x00018350 File Offset: 0x00016550
		public void Optimize()
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.OptimizeImpl();
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call Optimize() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x00018388 File Offset: 0x00016588
		public void OptimizeIndexBuffers()
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.OptimizeIndexBuffersImpl();
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call OptimizeIndexBuffers() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x000183C0 File Offset: 0x000165C0
		public void OptimizeReorderVertexBuffer()
		{
			bool canAccess = this.canAccess;
			if (canAccess)
			{
				this.OptimizeReorderVertexBufferImpl();
			}
			else
			{
				Debug.LogError(string.Format("Not allowed to call OptimizeReorderVertexBuffer() on mesh '{0}'", base.name));
			}
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x000183F8 File Offset: 0x000165F8
		public MeshTopology GetTopology(int submesh)
		{
			bool flag = submesh < 0 || submesh >= this.subMeshCount;
			MeshTopology result;
			if (flag)
			{
				Debug.LogError("Failed getting topology. Submesh index is out of bounds.", this);
				result = MeshTopology.Triangles;
			}
			else
			{
				result = this.GetTopologyImpl(submesh);
			}
			return result;
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x00018439 File Offset: 0x00016639
		public void CombineMeshes(CombineInstance[] combine, [DefaultValue("true")] bool mergeSubMeshes, [DefaultValue("true")] bool useMatrices, [DefaultValue("false")] bool hasLightmapData)
		{
			this.CombineMeshesImpl(combine, mergeSubMeshes, useMatrices, hasLightmapData);
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x00018448 File Offset: 0x00016648
		[ExcludeFromDocs]
		public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices)
		{
			this.CombineMeshesImpl(combine, mergeSubMeshes, useMatrices, false);
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x00018456 File Offset: 0x00016656
		[ExcludeFromDocs]
		public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes)
		{
			this.CombineMeshesImpl(combine, mergeSubMeshes, true, false);
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x00018464 File Offset: 0x00016664
		[ExcludeFromDocs]
		public void CombineMeshes(CombineInstance[] combine)
		{
			this.CombineMeshesImpl(combine, true, true, false);
		}

		// Token: 0x06001196 RID: 4502
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetVertexAttribute_Injected(int index, out VertexAttributeDescriptor ret);

		// Token: 0x06001197 RID: 4503
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetBlendShapeOffsetInternal_Injected(int index, out BlendShape ret);

		// Token: 0x06001198 RID: 4504
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetSubMesh_Injected(int index, ref SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default);

		// Token: 0x06001199 RID: 4505
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetSubMesh_Injected(int index, out SubMeshDescriptor ret);

		// Token: 0x0600119A RID: 4506
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_bounds_Injected(out Bounds ret);

		// Token: 0x0600119B RID: 4507
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_bounds_Injected(ref Bounds value);

		// Token: 0x020001C6 RID: 454
		[StaticAccessor("MeshDataBindings", StaticAccessorType.DoubleColon)]
		[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
		public struct MeshData
		{
			// Token: 0x0600119C RID: 4508
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern bool HasVertexAttribute(IntPtr self, VertexAttribute attr);

			// Token: 0x0600119D RID: 4509
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetVertexAttributeDimension(IntPtr self, VertexAttribute attr);

			// Token: 0x0600119E RID: 4510
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern VertexAttributeFormat GetVertexAttributeFormat(IntPtr self, VertexAttribute attr);

			// Token: 0x0600119F RID: 4511
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetVertexAttributeStream(IntPtr self, VertexAttribute attr);

			// Token: 0x060011A0 RID: 4512
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetVertexAttributeOffset(IntPtr self, VertexAttribute attr);

			// Token: 0x060011A1 RID: 4513
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetVertexCount(IntPtr self);

			// Token: 0x060011A2 RID: 4514
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetVertexBufferCount(IntPtr self);

			// Token: 0x060011A3 RID: 4515
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern IntPtr GetVertexDataPtr(IntPtr self, int stream);

			// Token: 0x060011A4 RID: 4516
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern ulong GetVertexDataSize(IntPtr self, int stream);

			// Token: 0x060011A5 RID: 4517
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetVertexBufferStride(IntPtr self, int stream);

			// Token: 0x060011A6 RID: 4518
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void CopyAttributeIntoPtr(IntPtr self, VertexAttribute attr, VertexAttributeFormat format, int dim, IntPtr dst);

			// Token: 0x060011A7 RID: 4519
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void CopyIndicesIntoPtr(IntPtr self, int submesh, bool applyBaseVertex, int dstStride, IntPtr dst);

			// Token: 0x060011A8 RID: 4520
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern IndexFormat GetIndexFormat(IntPtr self);

			// Token: 0x060011A9 RID: 4521
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetIndexCount(IntPtr self, int submesh);

			// Token: 0x060011AA RID: 4522
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern IntPtr GetIndexDataPtr(IntPtr self);

			// Token: 0x060011AB RID: 4523
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern ulong GetIndexDataSize(IntPtr self);

			// Token: 0x060011AC RID: 4524
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern int GetSubMeshCount(IntPtr self);

			// Token: 0x060011AD RID: 4525 RVA: 0x00018474 File Offset: 0x00016674
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			private static SubMeshDescriptor GetSubMesh(IntPtr self, int index)
			{
				SubMeshDescriptor result;
				Mesh.MeshData.GetSubMesh_Injected(self, index, out result);
				return result;
			}

			// Token: 0x060011AE RID: 4526
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void SetVertexBufferParamsFromPtr(IntPtr self, int vertexCount, IntPtr attributesPtr, int attributesCount);

			// Token: 0x060011AF RID: 4527
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void SetVertexBufferParamsFromArray(IntPtr self, int vertexCount, [Unmarshalled] params VertexAttributeDescriptor[] attributes);

			// Token: 0x060011B0 RID: 4528
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void SetIndexBufferParamsImpl(IntPtr self, int indexCount, IndexFormat indexFormat);

			// Token: 0x060011B1 RID: 4529
			[NativeMethod(IsThreadSafe = true)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void SetSubMeshCount(IntPtr self, int count);

			// Token: 0x060011B2 RID: 4530 RVA: 0x0001848B File Offset: 0x0001668B
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			private static void SetSubMeshImpl(IntPtr self, int index, SubMeshDescriptor desc, MeshUpdateFlags flags)
			{
				Mesh.MeshData.SetSubMeshImpl_Injected(self, index, ref desc, flags);
			}

			// Token: 0x1700038A RID: 906
			// (get) Token: 0x060011B3 RID: 4531 RVA: 0x00018498 File Offset: 0x00016698
			public int vertexCount
			{
				get
				{
					return Mesh.MeshData.GetVertexCount(this.m_Ptr);
				}
			}

			// Token: 0x1700038B RID: 907
			// (get) Token: 0x060011B4 RID: 4532 RVA: 0x000184B8 File Offset: 0x000166B8
			public int vertexBufferCount
			{
				get
				{
					return Mesh.MeshData.GetVertexBufferCount(this.m_Ptr);
				}
			}

			// Token: 0x060011B5 RID: 4533 RVA: 0x000184D8 File Offset: 0x000166D8
			public int GetVertexBufferStride(int stream)
			{
				return Mesh.MeshData.GetVertexBufferStride(this.m_Ptr, stream);
			}

			// Token: 0x060011B6 RID: 4534 RVA: 0x000184F8 File Offset: 0x000166F8
			public bool HasVertexAttribute(VertexAttribute attr)
			{
				return Mesh.MeshData.HasVertexAttribute(this.m_Ptr, attr);
			}

			// Token: 0x060011B7 RID: 4535 RVA: 0x00018518 File Offset: 0x00016718
			public int GetVertexAttributeDimension(VertexAttribute attr)
			{
				return Mesh.MeshData.GetVertexAttributeDimension(this.m_Ptr, attr);
			}

			// Token: 0x060011B8 RID: 4536 RVA: 0x00018538 File Offset: 0x00016738
			public VertexAttributeFormat GetVertexAttributeFormat(VertexAttribute attr)
			{
				return Mesh.MeshData.GetVertexAttributeFormat(this.m_Ptr, attr);
			}

			// Token: 0x060011B9 RID: 4537 RVA: 0x00018558 File Offset: 0x00016758
			public int GetVertexAttributeStream(VertexAttribute attr)
			{
				return Mesh.MeshData.GetVertexAttributeStream(this.m_Ptr, attr);
			}

			// Token: 0x060011BA RID: 4538 RVA: 0x00018578 File Offset: 0x00016778
			public int GetVertexAttributeOffset(VertexAttribute attr)
			{
				return Mesh.MeshData.GetVertexAttributeOffset(this.m_Ptr, attr);
			}

			// Token: 0x060011BB RID: 4539 RVA: 0x00018596 File Offset: 0x00016796
			public void GetVertices(NativeArray<Vector3> outVertices)
			{
				this.CopyAttributeInto<Vector3>(outVertices, VertexAttribute.Position, VertexAttributeFormat.Float32, 3);
			}

			// Token: 0x060011BC RID: 4540 RVA: 0x000185A4 File Offset: 0x000167A4
			public void GetNormals(NativeArray<Vector3> outNormals)
			{
				this.CopyAttributeInto<Vector3>(outNormals, VertexAttribute.Normal, VertexAttributeFormat.Float32, 3);
			}

			// Token: 0x060011BD RID: 4541 RVA: 0x000185B2 File Offset: 0x000167B2
			public void GetTangents(NativeArray<Vector4> outTangents)
			{
				this.CopyAttributeInto<Vector4>(outTangents, VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4);
			}

			// Token: 0x060011BE RID: 4542 RVA: 0x000185C0 File Offset: 0x000167C0
			public void GetColors(NativeArray<Color> outColors)
			{
				this.CopyAttributeInto<Color>(outColors, VertexAttribute.Color, VertexAttributeFormat.Float32, 4);
			}

			// Token: 0x060011BF RID: 4543 RVA: 0x000185CE File Offset: 0x000167CE
			public void GetColors(NativeArray<Color32> outColors)
			{
				this.CopyAttributeInto<Color32>(outColors, VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4);
			}

			// Token: 0x060011C0 RID: 4544 RVA: 0x000185DC File Offset: 0x000167DC
			public void GetUVs(int channel, NativeArray<Vector2> outUVs)
			{
				bool flag = channel < 0 || channel > 7;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("channel", channel, "The uv index is invalid. Must be in the range 0 to 7.");
				}
				this.CopyAttributeInto<Vector2>(outUVs, Mesh.GetUVChannel(channel), VertexAttributeFormat.Float32, 2);
			}

			// Token: 0x060011C1 RID: 4545 RVA: 0x00018620 File Offset: 0x00016820
			public void GetUVs(int channel, NativeArray<Vector3> outUVs)
			{
				bool flag = channel < 0 || channel > 7;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("channel", channel, "The uv index is invalid. Must be in the range 0 to 7.");
				}
				this.CopyAttributeInto<Vector3>(outUVs, Mesh.GetUVChannel(channel), VertexAttributeFormat.Float32, 3);
			}

			// Token: 0x060011C2 RID: 4546 RVA: 0x00018664 File Offset: 0x00016864
			public void GetUVs(int channel, NativeArray<Vector4> outUVs)
			{
				bool flag = channel < 0 || channel > 7;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("channel", channel, "The uv index is invalid. Must be in the range 0 to 7.");
				}
				this.CopyAttributeInto<Vector4>(outUVs, Mesh.GetUVChannel(channel), VertexAttributeFormat.Float32, 4);
			}

			// Token: 0x060011C3 RID: 4547 RVA: 0x000186A8 File Offset: 0x000168A8
			public unsafe NativeArray<T> GetVertexData<T>([DefaultValue("0")] int stream = 0) where T : struct
			{
				bool flag = stream < 0 || stream >= this.vertexBufferCount;
				if (flag)
				{
					throw new ArgumentOutOfRangeException(string.Format("{0} out of bounds, should be below {1} but was {2}", "stream", this.vertexBufferCount, stream));
				}
				ulong vertexDataSize = Mesh.MeshData.GetVertexDataSize(this.m_Ptr, stream);
				ulong num = (ulong)((long)UnsafeUtility.SizeOf<T>());
				bool flag2 = vertexDataSize % num > 0UL;
				if (flag2)
				{
					throw new ArgumentException(string.Format("Type passed to {0} can't capture the vertex buffer. Mesh vertex buffer size is {1} which is not a multiple of type size {2}", "GetVertexData", vertexDataSize, num));
				}
				ulong num2 = vertexDataSize / num;
				return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)Mesh.MeshData.GetVertexDataPtr(this.m_Ptr, stream), (int)num2, Allocator.None);
			}

			// Token: 0x060011C4 RID: 4548 RVA: 0x00018760 File Offset: 0x00016960
			private void CopyAttributeInto<T>(NativeArray<T> buffer, VertexAttribute channel, VertexAttributeFormat format, int dim) where T : struct
			{
				bool flag = !this.HasVertexAttribute(channel);
				if (flag)
				{
					throw new InvalidOperationException(string.Format("Mesh data does not have {0} vertex component", channel));
				}
				bool flag2 = buffer.Length < this.vertexCount;
				if (flag2)
				{
					throw new InvalidOperationException(string.Format("Not enough space in output buffer (need {0}, has {1})", this.vertexCount, buffer.Length));
				}
				Mesh.MeshData.CopyAttributeIntoPtr(this.m_Ptr, channel, format, dim, (IntPtr)buffer.GetUnsafePtr<T>());
			}

			// Token: 0x060011C5 RID: 4549 RVA: 0x000187E7 File Offset: 0x000169E7
			public void SetVertexBufferParams(int vertexCount, params VertexAttributeDescriptor[] attributes)
			{
				Mesh.MeshData.SetVertexBufferParamsFromArray(this.m_Ptr, vertexCount, attributes);
			}

			// Token: 0x060011C6 RID: 4550 RVA: 0x000187F8 File Offset: 0x000169F8
			public void SetVertexBufferParams(int vertexCount, NativeArray<VertexAttributeDescriptor> attributes)
			{
				Mesh.MeshData.SetVertexBufferParamsFromPtr(this.m_Ptr, vertexCount, (IntPtr)attributes.GetUnsafeReadOnlyPtr<VertexAttributeDescriptor>(), attributes.Length);
			}

			// Token: 0x060011C7 RID: 4551 RVA: 0x0001881C File Offset: 0x00016A1C
			public void SetIndexBufferParams(int indexCount, IndexFormat format)
			{
				Mesh.MeshData.SetIndexBufferParamsImpl(this.m_Ptr, indexCount, format);
			}

			// Token: 0x1700038C RID: 908
			// (get) Token: 0x060011C8 RID: 4552 RVA: 0x00018830 File Offset: 0x00016A30
			public IndexFormat indexFormat
			{
				get
				{
					return Mesh.MeshData.GetIndexFormat(this.m_Ptr);
				}
			}

			// Token: 0x060011C9 RID: 4553 RVA: 0x00018850 File Offset: 0x00016A50
			public void GetIndices(NativeArray<ushort> outIndices, int submesh, [DefaultValue("true")] bool applyBaseVertex = true)
			{
				bool flag = submesh < 0 || submesh >= this.subMeshCount;
				if (flag)
				{
					throw new IndexOutOfRangeException(string.Format("Specified submesh ({0}) is out of range. Must be greater or equal to 0 and less than subMeshCount ({1}).", submesh, this.subMeshCount));
				}
				int indexCount = Mesh.MeshData.GetIndexCount(this.m_Ptr, submesh);
				bool flag2 = outIndices.Length < indexCount;
				if (flag2)
				{
					throw new InvalidOperationException(string.Format("Not enough space in output buffer (need {0}, has {1})", indexCount, outIndices.Length));
				}
				Mesh.MeshData.CopyIndicesIntoPtr(this.m_Ptr, submesh, applyBaseVertex, 2, (IntPtr)outIndices.GetUnsafePtr<ushort>());
			}

			// Token: 0x060011CA RID: 4554 RVA: 0x000188F0 File Offset: 0x00016AF0
			public void GetIndices(NativeArray<int> outIndices, int submesh, [DefaultValue("true")] bool applyBaseVertex = true)
			{
				bool flag = submesh < 0 || submesh >= this.subMeshCount;
				if (flag)
				{
					throw new IndexOutOfRangeException(string.Format("Specified submesh ({0}) is out of range. Must be greater or equal to 0 and less than subMeshCount ({1}).", submesh, this.subMeshCount));
				}
				int indexCount = Mesh.MeshData.GetIndexCount(this.m_Ptr, submesh);
				bool flag2 = outIndices.Length < indexCount;
				if (flag2)
				{
					throw new InvalidOperationException(string.Format("Not enough space in output buffer (need {0}, has {1})", indexCount, outIndices.Length));
				}
				Mesh.MeshData.CopyIndicesIntoPtr(this.m_Ptr, submesh, applyBaseVertex, 4, (IntPtr)outIndices.GetUnsafePtr<int>());
			}

			// Token: 0x060011CB RID: 4555 RVA: 0x00018990 File Offset: 0x00016B90
			public unsafe NativeArray<T> GetIndexData<T>() where T : struct
			{
				ulong indexDataSize = Mesh.MeshData.GetIndexDataSize(this.m_Ptr);
				ulong num = (ulong)((long)UnsafeUtility.SizeOf<T>());
				bool flag = indexDataSize % num > 0UL;
				if (flag)
				{
					throw new ArgumentException(string.Format("Type passed to {0} can't capture the index buffer. Mesh index buffer size is {1} which is not a multiple of type size {2}", "GetIndexData", indexDataSize, num));
				}
				ulong num2 = indexDataSize / num;
				return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)Mesh.MeshData.GetIndexDataPtr(this.m_Ptr), (int)num2, Allocator.None);
			}

			// Token: 0x1700038D RID: 909
			// (get) Token: 0x060011CC RID: 4556 RVA: 0x00018A04 File Offset: 0x00016C04
			// (set) Token: 0x060011CD RID: 4557 RVA: 0x00018A21 File Offset: 0x00016C21
			public int subMeshCount
			{
				get
				{
					return Mesh.MeshData.GetSubMeshCount(this.m_Ptr);
				}
				set
				{
					Mesh.MeshData.SetSubMeshCount(this.m_Ptr, value);
				}
			}

			// Token: 0x060011CE RID: 4558 RVA: 0x00018A34 File Offset: 0x00016C34
			public SubMeshDescriptor GetSubMesh(int index)
			{
				return Mesh.MeshData.GetSubMesh(this.m_Ptr, index);
			}

			// Token: 0x060011CF RID: 4559 RVA: 0x00018A52 File Offset: 0x00016C52
			public void SetSubMesh(int index, SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default)
			{
				Mesh.MeshData.SetSubMeshImpl(this.m_Ptr, index, desc, flags);
			}

			// Token: 0x060011D0 RID: 4560 RVA: 0x00002669 File Offset: 0x00000869
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckReadAccess()
			{
			}

			// Token: 0x060011D1 RID: 4561 RVA: 0x00002669 File Offset: 0x00000869
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckWriteAccess()
			{
			}

			// Token: 0x060011D2 RID: 4562
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void GetSubMesh_Injected(IntPtr self, int index, out SubMeshDescriptor ret);

			// Token: 0x060011D3 RID: 4563
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void SetSubMeshImpl_Injected(IntPtr self, int index, ref SubMeshDescriptor desc, MeshUpdateFlags flags);

			// Token: 0x0400063C RID: 1596
			[NativeDisableUnsafePtrRestriction]
			internal IntPtr m_Ptr;
		}

		// Token: 0x020001C7 RID: 455
		[NativeContainer]
		[StaticAccessor("MeshDataArrayBindings", StaticAccessorType.DoubleColon)]
		[NativeContainerSupportsMinMaxWriteRestriction]
		public struct MeshDataArray : IDisposable
		{
			// Token: 0x060011D4 RID: 4564
			[MethodImpl(MethodImplOptions.InternalCall)]
			private unsafe static extern void AcquireReadOnlyMeshData([NotNull("ArgumentNullException")] Mesh mesh, IntPtr* datas);

			// Token: 0x060011D5 RID: 4565
			[MethodImpl(MethodImplOptions.InternalCall)]
			private unsafe static extern void AcquireReadOnlyMeshDatas([NotNull("ArgumentNullException")] Mesh[] meshes, IntPtr* datas, int count);

			// Token: 0x060011D6 RID: 4566
			[MethodImpl(MethodImplOptions.InternalCall)]
			private unsafe static extern void ReleaseMeshDatas(IntPtr* datas, int count);

			// Token: 0x060011D7 RID: 4567
			[MethodImpl(MethodImplOptions.InternalCall)]
			private unsafe static extern void CreateNewMeshDatas(IntPtr* datas, int count);

			// Token: 0x060011D8 RID: 4568
			[NativeThrows]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private unsafe static extern void ApplyToMeshesImpl([NotNull("ArgumentNullException")] Mesh[] meshes, IntPtr* datas, int count, MeshUpdateFlags flags);

			// Token: 0x060011D9 RID: 4569
			[NativeThrows]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void ApplyToMeshImpl([NotNull("ArgumentNullException")] Mesh mesh, IntPtr data, MeshUpdateFlags flags);

			// Token: 0x1700038E RID: 910
			// (get) Token: 0x060011DA RID: 4570 RVA: 0x00018A64 File Offset: 0x00016C64
			public int Length
			{
				get
				{
					return this.m_Length;
				}
			}

			// Token: 0x1700038F RID: 911
			public unsafe Mesh.MeshData this[int index]
			{
				get
				{
					Mesh.MeshData result;
					result.m_Ptr = this.m_Ptrs[(IntPtr)index * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
					return result;
				}
			}

			// Token: 0x060011DC RID: 4572 RVA: 0x00018A98 File Offset: 0x00016C98
			public unsafe void Dispose()
			{
				UnsafeUtility.LeakErase((IntPtr)((void*)this.m_Ptrs), LeakCategory.MeshDataArray);
				bool flag = this.m_Length != 0;
				if (flag)
				{
					Mesh.MeshDataArray.ReleaseMeshDatas(this.m_Ptrs, this.m_Length);
					UnsafeUtility.Free((void*)this.m_Ptrs, Allocator.Persistent);
				}
				this.m_Ptrs = null;
				this.m_Length = 0;
			}

			// Token: 0x060011DD RID: 4573 RVA: 0x00018AF8 File Offset: 0x00016CF8
			internal unsafe void ApplyToMeshAndDispose(Mesh mesh, MeshUpdateFlags flags)
			{
				bool flag = !mesh.canAccess;
				if (flag)
				{
					throw new InvalidOperationException("Not allowed to access vertex data on mesh '" + mesh.name + "' (isReadable is false; Read/Write must be enabled in import settings)");
				}
				Mesh.MeshDataArray.ApplyToMeshImpl(mesh, *this.m_Ptrs, flags);
				this.Dispose();
			}

			// Token: 0x060011DE RID: 4574 RVA: 0x00018B44 File Offset: 0x00016D44
			internal void ApplyToMeshesAndDispose(Mesh[] meshes, MeshUpdateFlags flags)
			{
				for (int i = 0; i < this.m_Length; i++)
				{
					Mesh mesh = meshes[i];
					bool flag = mesh == null;
					if (flag)
					{
						throw new ArgumentNullException("meshes", string.Format("Mesh at index {0} is null", i));
					}
					bool flag2 = !mesh.canAccess;
					if (flag2)
					{
						throw new InvalidOperationException(string.Format("Not allowed to access vertex data on mesh '{0}' at array index {1} (isReadable is false; Read/Write must be enabled in import settings)", mesh.name, i));
					}
				}
				Mesh.MeshDataArray.ApplyToMeshesImpl(meshes, this.m_Ptrs, this.m_Length, flags);
				this.Dispose();
			}

			// Token: 0x060011DF RID: 4575 RVA: 0x00018BDC File Offset: 0x00016DDC
			internal unsafe MeshDataArray(Mesh mesh, bool checkReadWrite = true)
			{
				bool flag = mesh == null;
				if (flag)
				{
					throw new ArgumentNullException("mesh", "Mesh is null");
				}
				bool flag2 = checkReadWrite && !mesh.canAccess;
				if (flag2)
				{
					throw new InvalidOperationException("Not allowed to access vertex data on mesh '" + mesh.name + "' (isReadable is false; Read/Write must be enabled in import settings)");
				}
				this.m_Length = 1;
				int num = UnsafeUtility.SizeOf<IntPtr>();
				this.m_Ptrs = (IntPtr*)UnsafeUtility.Malloc((long)num, UnsafeUtility.AlignOf<IntPtr>(), Allocator.Persistent);
				Mesh.MeshDataArray.AcquireReadOnlyMeshData(mesh, this.m_Ptrs);
				UnsafeUtility.LeakRecord((IntPtr)((void*)this.m_Ptrs), LeakCategory.MeshDataArray, 0);
			}

			// Token: 0x060011E0 RID: 4576 RVA: 0x00018C74 File Offset: 0x00016E74
			internal unsafe MeshDataArray(Mesh[] meshes, int meshesCount, bool checkReadWrite = true)
			{
				bool flag = meshes.Length < meshesCount;
				if (flag)
				{
					throw new InvalidOperationException(string.Format("Meshes array size ({0}) is smaller than meshes count ({1})", meshes.Length, meshesCount));
				}
				for (int i = 0; i < meshesCount; i++)
				{
					Mesh mesh = meshes[i];
					bool flag2 = mesh == null;
					if (flag2)
					{
						throw new ArgumentNullException("meshes", string.Format("Mesh at index {0} is null", i));
					}
					bool flag3 = checkReadWrite && !mesh.canAccess;
					if (flag3)
					{
						throw new InvalidOperationException(string.Format("Not allowed to access vertex data on mesh '{0}' at array index {1} (isReadable is false; Read/Write must be enabled in import settings)", mesh.name, i));
					}
				}
				this.m_Length = meshesCount;
				int num = UnsafeUtility.SizeOf<IntPtr>() * meshesCount;
				this.m_Ptrs = (IntPtr*)UnsafeUtility.Malloc((long)num, UnsafeUtility.AlignOf<IntPtr>(), Allocator.Persistent);
				Mesh.MeshDataArray.AcquireReadOnlyMeshDatas(meshes, this.m_Ptrs, meshesCount);
			}

			// Token: 0x060011E1 RID: 4577 RVA: 0x00018D4C File Offset: 0x00016F4C
			internal unsafe MeshDataArray(int meshesCount)
			{
				bool flag = meshesCount < 0;
				if (flag)
				{
					throw new InvalidOperationException(string.Format("Mesh count can not be negative (was {0})", meshesCount));
				}
				this.m_Length = meshesCount;
				int num = UnsafeUtility.SizeOf<IntPtr>() * meshesCount;
				this.m_Ptrs = (IntPtr*)UnsafeUtility.Malloc((long)num, UnsafeUtility.AlignOf<IntPtr>(), Allocator.Persistent);
				Mesh.MeshDataArray.CreateNewMeshDatas(this.m_Ptrs, meshesCount);
			}

			// Token: 0x060011E2 RID: 4578 RVA: 0x00002669 File Offset: 0x00000869
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckElementReadAccess(int index)
			{
			}

			// Token: 0x0400063D RID: 1597
			[NativeDisableUnsafePtrRestriction]
			internal unsafe IntPtr* m_Ptrs;

			// Token: 0x0400063E RID: 1598
			internal int m_Length;
		}
	}
}
