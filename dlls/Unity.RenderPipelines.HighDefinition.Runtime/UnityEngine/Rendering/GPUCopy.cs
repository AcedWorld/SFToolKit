using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200001B RID: 27
	internal class GPUCopy
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00003C3B File Offset: 0x00001E3B
		public GPUCopy(ComputeShader shader)
		{
			this.m_Shader = shader;
			this.k_SampleKernel_xyzw2x_8 = this.m_Shader.FindKernel("KSampleCopy4_1_x_8");
			this.k_SampleKernel_xyzw2x_1 = this.m_Shader.FindKernel("KSampleCopy4_1_x_1");
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003C78 File Offset: 0x00001E78
		private unsafe void SampleCopyChannel(CommandBuffer cmd, RectInt rect, int _source, RenderTargetIdentifier source, int _target, RenderTargetIdentifier target, int slices, int kernel8, int kernel1)
		{
			RectInt* ptr = stackalloc RectInt[checked(unchecked((UIntPtr)3) * (UIntPtr)sizeof(RectInt))];
			int num = 0;
			RectInt rectInt = new RectInt(0, 0, 0, 0);
			RectInt rectInt2;
			RectInt rectInt3;
			RectInt rectInt4;
			RectInt rectInt5;
			if (TileLayoutUtils.TryLayoutByTiles(rect, 8U, out rectInt2, out rectInt3, out rectInt4, out rectInt5))
			{
				if (rectInt3.width > 0 && rectInt3.height > 0)
				{
					ptr[num] = rectInt3;
					num++;
				}
				if (rectInt4.width > 0 && rectInt4.height > 0)
				{
					ptr[num] = rectInt4;
					num++;
				}
				if (rectInt5.width > 0 && rectInt5.height > 0)
				{
					ptr[num] = rectInt5;
					num++;
				}
				rectInt = rectInt2;
			}
			else if (rect.width > 0 && rect.height > 0)
			{
				ptr[num] = rect;
				num++;
			}
			cmd.SetComputeTextureParam(this.m_Shader, kernel8, _source, source);
			cmd.SetComputeTextureParam(this.m_Shader, kernel1, _source, source);
			cmd.SetComputeTextureParam(this.m_Shader, kernel8, _target, target);
			cmd.SetComputeTextureParam(this.m_Shader, kernel1, _target, target);
			if (rectInt.width > 0 && rectInt.height > 0)
			{
				RectInt rectInt6 = rectInt;
				GPUCopy._IntParams[0] = rectInt6.x;
				GPUCopy._IntParams[1] = rectInt6.y;
				cmd.SetComputeIntParams(this.m_Shader, GPUCopy._RectOffset, GPUCopy._IntParams);
				cmd.DispatchCompute(this.m_Shader, kernel8, Mathf.Max(rectInt6.width / 8, 1), Mathf.Max(rectInt6.height / 8, 1), slices);
			}
			int i = 0;
			int num2 = num;
			while (i < num2)
			{
				RectInt rectInt7 = ptr[i];
				GPUCopy._IntParams[0] = rectInt7.x;
				GPUCopy._IntParams[1] = rectInt7.y;
				cmd.SetComputeIntParams(this.m_Shader, GPUCopy._RectOffset, GPUCopy._IntParams);
				cmd.DispatchCompute(this.m_Shader, kernel1, Mathf.Max(rectInt7.width, 1), Mathf.Max(rectInt7.height, 1), slices);
				i++;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003EB0 File Offset: 0x000020B0
		public void SampleCopyChannel_xyzw2x(CommandBuffer cmd, RTHandle source, RTHandle target, RectInt rect)
		{
			this.SampleCopyChannel(cmd, rect, GPUCopy._Source4, source, GPUCopy._Result1, target, source.rt.volumeDepth, this.k_SampleKernel_xyzw2x_8, this.k_SampleKernel_xyzw2x_1);
		}

		// Token: 0x0400007A RID: 122
		private ComputeShader m_Shader;

		// Token: 0x0400007B RID: 123
		private int k_SampleKernel_xyzw2x_8;

		// Token: 0x0400007C RID: 124
		private int k_SampleKernel_xyzw2x_1;

		// Token: 0x0400007D RID: 125
		private static readonly int _RectOffset = Shader.PropertyToID("_RectOffset");

		// Token: 0x0400007E RID: 126
		private static readonly int _Result1 = Shader.PropertyToID("_Result1");

		// Token: 0x0400007F RID: 127
		private static readonly int _Source4 = Shader.PropertyToID("_Source4");

		// Token: 0x04000080 RID: 128
		private static int[] _IntParams = new int[2];
	}
}
