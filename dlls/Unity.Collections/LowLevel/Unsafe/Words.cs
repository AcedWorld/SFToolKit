using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000E9 RID: 233
	[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
	public struct Words
	{
		// Token: 0x06000933 RID: 2355 RVA: 0x0001CFDB File Offset: 0x0001B1DB
		public void ToFixedString<T>(ref T value) where T : IUTF8Bytes, INativeList<byte>
		{
			WordStorage.Instance.GetFixedString<T>(this.Index, ref value);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0001CFF0 File Offset: 0x0001B1F0
		public override string ToString()
		{
			FixedString512Bytes fixedString512Bytes = default(FixedString512Bytes);
			this.ToFixedString<FixedString512Bytes>(ref fixedString512Bytes);
			return fixedString512Bytes.ToString();
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0001D01A File Offset: 0x0001B21A
		public void SetFixedString<T>(ref T value) where T : IUTF8Bytes, INativeList<byte>
		{
			this.Index = WordStorage.Instance.GetOrCreateIndex<T>(ref value);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0001D030 File Offset: 0x0001B230
		public void SetString(string value)
		{
			FixedString512Bytes fixedString512Bytes = value;
			this.SetFixedString<FixedString512Bytes>(ref fixedString512Bytes);
		}

		// Token: 0x04000335 RID: 821
		private int Index;
	}
}
