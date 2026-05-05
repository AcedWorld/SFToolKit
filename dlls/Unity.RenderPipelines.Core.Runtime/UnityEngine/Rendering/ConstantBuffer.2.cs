using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.Rendering
{
	// Token: 0x02000039 RID: 57
	public class ConstantBuffer<CBType> : ConstantBufferBase where CBType : struct
	{
		// Token: 0x06000214 RID: 532 RVA: 0x0000A50D File Offset: 0x0000870D
		public ConstantBuffer()
		{
			this.m_GPUConstantBuffer = new ComputeBuffer(1, UnsafeUtility.SizeOf<CBType>(), ComputeBufferType.Constant);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000A53E File Offset: 0x0000873E
		public void UpdateData(CommandBuffer cmd, in CBType data)
		{
			this.m_Data[0] = data;
			cmd.SetBufferData(this.m_GPUConstantBuffer, this.m_Data);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000A564 File Offset: 0x00008764
		public void UpdateData(in CBType data)
		{
			this.m_Data[0] = data;
			this.m_GPUConstantBuffer.SetData(this.m_Data);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000A589 File Offset: 0x00008789
		public void SetGlobal(CommandBuffer cmd, int shaderId)
		{
			this.m_GlobalBindings.Add(shaderId);
			cmd.SetGlobalConstantBuffer(this.m_GPUConstantBuffer, shaderId, 0, this.m_GPUConstantBuffer.stride);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000A5B1 File Offset: 0x000087B1
		public void SetGlobal(int shaderId)
		{
			this.m_GlobalBindings.Add(shaderId);
			Shader.SetGlobalConstantBuffer(shaderId, this.m_GPUConstantBuffer, 0, this.m_GPUConstantBuffer.stride);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000A5D8 File Offset: 0x000087D8
		public void Set(CommandBuffer cmd, ComputeShader cs, int shaderId)
		{
			cmd.SetComputeConstantBufferParam(cs, shaderId, this.m_GPUConstantBuffer, 0, this.m_GPUConstantBuffer.stride);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000A5F4 File Offset: 0x000087F4
		public void Set(ComputeShader cs, int shaderId)
		{
			cs.SetConstantBuffer(shaderId, this.m_GPUConstantBuffer, 0, this.m_GPUConstantBuffer.stride);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000A60F File Offset: 0x0000880F
		public void Set(Material mat, int shaderId)
		{
			mat.SetConstantBuffer(shaderId, this.m_GPUConstantBuffer, 0, this.m_GPUConstantBuffer.stride);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000A62A File Offset: 0x0000882A
		public void PushGlobal(CommandBuffer cmd, in CBType data, int shaderId)
		{
			this.UpdateData(cmd, data);
			this.SetGlobal(cmd, shaderId);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000A63C File Offset: 0x0000883C
		public void PushGlobal(in CBType data, int shaderId)
		{
			this.UpdateData(data);
			this.SetGlobal(shaderId);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000A64C File Offset: 0x0000884C
		public override void Release()
		{
			foreach (int nameID in this.m_GlobalBindings)
			{
				Shader.SetGlobalConstantBuffer(nameID, null, 0, 0);
			}
			this.m_GlobalBindings.Clear();
			CoreUtils.SafeRelease(this.m_GPUConstantBuffer);
		}

		// Token: 0x04000142 RID: 322
		private HashSet<int> m_GlobalBindings = new HashSet<int>();

		// Token: 0x04000143 RID: 323
		private CBType[] m_Data = new CBType[1];

		// Token: 0x04000144 RID: 324
		private ComputeBuffer m_GPUConstantBuffer;
	}
}
