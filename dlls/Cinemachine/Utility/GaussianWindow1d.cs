using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x02000060 RID: 96
	internal abstract class GaussianWindow1d<T>
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003BC RID: 956 RVA: 0x000170FF File Offset: 0x000152FF
		// (set) Token: 0x060003BD RID: 957 RVA: 0x00017107 File Offset: 0x00015307
		public float Sigma { get; private set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00017110 File Offset: 0x00015310
		public int KernelSize
		{
			get
			{
				return this.mKernel.Length;
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0001711C File Offset: 0x0001531C
		private void GenerateKernel(float sigma, int maxKernelRadius)
		{
			int num = Math.Min(maxKernelRadius, Mathf.FloorToInt(Mathf.Abs(sigma) * 2.5f));
			this.mKernel = new float[2 * num + 1];
			if (num == 0)
			{
				this.mKernel[0] = 1f;
			}
			else
			{
				float num2 = 0f;
				for (int i = -num; i <= num; i++)
				{
					this.mKernel[i + num] = (float)(Math.Exp((double)((float)(-(float)(i * i)) / (2f * sigma * sigma))) / (6.283185307179586 * (double)sigma * (double)sigma));
					num2 += this.mKernel[i + num];
				}
				for (int j = -num; j <= num; j++)
				{
					this.mKernel[j + num] /= num2;
				}
			}
			this.Sigma = sigma;
		}

		// Token: 0x060003C0 RID: 960
		protected abstract T Compute(int windowPos);

		// Token: 0x060003C1 RID: 961 RVA: 0x000171DA File Offset: 0x000153DA
		public GaussianWindow1d(float sigma, int maxKernelRadius = 10)
		{
			this.GenerateKernel(sigma, maxKernelRadius);
			this.mData = new T[this.KernelSize];
			this.mCurrentPos = -1;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00017209 File Offset: 0x00015409
		public void Reset()
		{
			this.mCurrentPos = -1;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00017212 File Offset: 0x00015412
		public bool IsEmpty()
		{
			return this.mCurrentPos < 0;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00017220 File Offset: 0x00015420
		public void AddValue(T v)
		{
			if (this.mCurrentPos < 0)
			{
				for (int i = 0; i < this.KernelSize; i++)
				{
					this.mData[i] = v;
				}
				this.mCurrentPos = Mathf.Min(1, this.KernelSize - 1);
			}
			this.mData[this.mCurrentPos] = v;
			int num = this.mCurrentPos + 1;
			this.mCurrentPos = num;
			if (num == this.KernelSize)
			{
				this.mCurrentPos = 0;
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001729A File Offset: 0x0001549A
		public T Filter(T v)
		{
			if (this.KernelSize < 3)
			{
				return v;
			}
			this.AddValue(v);
			return this.Value();
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000172B4 File Offset: 0x000154B4
		public T Value()
		{
			return this.Compute(this.mCurrentPos);
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x000172C2 File Offset: 0x000154C2
		public int BufferLength
		{
			get
			{
				return this.mData.Length;
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000172CC File Offset: 0x000154CC
		public void SetBufferValue(int index, T value)
		{
			this.mData[index] = value;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000172DB File Offset: 0x000154DB
		public T GetBufferValue(int index)
		{
			return this.mData[index];
		}

		// Token: 0x0400028F RID: 655
		protected T[] mData;

		// Token: 0x04000290 RID: 656
		protected float[] mKernel;

		// Token: 0x04000291 RID: 657
		protected int mCurrentPos = -1;
	}
}
