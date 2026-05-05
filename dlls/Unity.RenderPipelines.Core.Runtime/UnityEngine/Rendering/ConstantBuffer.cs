using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000037 RID: 55
	public class ConstantBuffer
	{
		// Token: 0x06000201 RID: 513 RVA: 0x0000A3A4 File Offset: 0x000085A4
		public static void PushGlobal<CBType>(CommandBuffer cmd, in CBType data, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType> instance = ConstantBufferSingleton<CBType>.instance;
			instance.UpdateData(cmd, data);
			instance.SetGlobal(cmd, shaderId);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000A3BA File Offset: 0x000085BA
		public static void PushGlobal<CBType>(in CBType data, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType> instance = ConstantBufferSingleton<CBType>.instance;
			instance.UpdateData(data);
			instance.SetGlobal(shaderId);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000A3CE File Offset: 0x000085CE
		public static void Push<CBType>(CommandBuffer cmd, in CBType data, ComputeShader cs, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType> instance = ConstantBufferSingleton<CBType>.instance;
			instance.UpdateData(cmd, data);
			instance.Set(cmd, cs, shaderId);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000A3E5 File Offset: 0x000085E5
		public static void Push<CBType>(in CBType data, ComputeShader cs, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType> instance = ConstantBufferSingleton<CBType>.instance;
			instance.UpdateData(data);
			instance.Set(cs, shaderId);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000A3FA File Offset: 0x000085FA
		public static void Push<CBType>(CommandBuffer cmd, in CBType data, Material mat, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType> instance = ConstantBufferSingleton<CBType>.instance;
			instance.UpdateData(cmd, data);
			instance.Set(mat, shaderId);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000A410 File Offset: 0x00008610
		public static void Push<CBType>(in CBType data, Material mat, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType> instance = ConstantBufferSingleton<CBType>.instance;
			instance.UpdateData(data);
			instance.Set(mat, shaderId);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000A425 File Offset: 0x00008625
		public static void UpdateData<CBType>(CommandBuffer cmd, in CBType data) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.UpdateData(cmd, data);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000A433 File Offset: 0x00008633
		public static void UpdateData<CBType>(in CBType data) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.UpdateData(data);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000A440 File Offset: 0x00008640
		public static void SetGlobal<CBType>(CommandBuffer cmd, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.SetGlobal(cmd, shaderId);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000A44E File Offset: 0x0000864E
		public static void SetGlobal<CBType>(int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.SetGlobal(shaderId);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000A45B File Offset: 0x0000865B
		public static void Set<CBType>(CommandBuffer cmd, ComputeShader cs, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.Set(cmd, cs, shaderId);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000A46A File Offset: 0x0000866A
		public static void Set<CBType>(ComputeShader cs, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.Set(cs, shaderId);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000A478 File Offset: 0x00008678
		public static void Set<CBType>(Material mat, int shaderId) where CBType : struct
		{
			ConstantBufferSingleton<CBType>.instance.Set(mat, shaderId);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000A488 File Offset: 0x00008688
		public static void ReleaseAll()
		{
			foreach (ConstantBufferBase constantBufferBase in ConstantBuffer.m_RegisteredConstantBuffers)
			{
				constantBufferBase.Release();
			}
			ConstantBuffer.m_RegisteredConstantBuffers.Clear();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000A4E4 File Offset: 0x000086E4
		internal static void Register(ConstantBufferBase cb)
		{
			ConstantBuffer.m_RegisteredConstantBuffers.Add(cb);
		}

		// Token: 0x04000141 RID: 321
		private static List<ConstantBufferBase> m_RegisteredConstantBuffers = new List<ConstantBufferBase>();
	}
}
