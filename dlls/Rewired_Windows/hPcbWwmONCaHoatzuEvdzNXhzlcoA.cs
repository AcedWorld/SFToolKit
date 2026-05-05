using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x02000106 RID: 262
internal class hPcbWwmONCaHoatzuEvdzNXhzlcoA : fbGGPUHANlDlSxUqZFEHDtNCzIrkB
{
	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x060009AB RID: 2475 RVA: 0x00017066 File Offset: 0x00015266
	// (set) Token: 0x060009AC RID: 2476 RVA: 0x0001706E File Offset: 0x0001526E
	public IntPtr[] uPKqPGbbVQVvBLJKiIODiGbUPcRdA { get; private set; }

	// Token: 0x060009AD RID: 2477 RVA: 0x0003B214 File Offset: 0x00039414
	public void FuhrCpKNHkyKpAYKQafpgzWLOYAe(YoTOcyXEwwLXCfwPNwDCnXTauRHE A_1)
	{
		A_1.FeZGBinBmHhlKjxkmZHamedLsrbCb = this;
		Type type = A_1.GetType();
		Dictionary<Type, List<Type>> obj = hPcbWwmONCaHoatzuEvdzNXhzlcoA.ipWLoYNYFUMeUUgwSTZdsYxbqBBO;
		List<Type> list;
		lock (obj)
		{
			if (!hPcbWwmONCaHoatzuEvdzNXhzlcoA.ipWLoYNYFUMeUUgwSTZdsYxbqBBO.TryGetValue(type, out list))
			{
				Type[] interfaces = type.GetInterfaces();
				list = new List<Type>();
				list.AddRange(interfaces);
				hPcbWwmONCaHoatzuEvdzNXhzlcoA.ipWLoYNYFUMeUUgwSTZdsYxbqBBO.Add(type, list);
				foreach (Type type2 in interfaces)
				{
					if (LSfbzggqEHqKwxvKFNVQRxSmMGdX.YAoWqsiYgitWKYXzCaTXoqyhVoki(type2) == null)
					{
						list.Remove(type2);
					}
					else
					{
						foreach (Type item in type2.GetInterfaces())
						{
							list.Remove(item);
						}
					}
				}
			}
		}
		mTBZwTkDXKQgAfxcspeSXeoLCArH mTBZwTkDXKQgAfxcspeSXeoLCArH = null;
		foreach (Type type3 in list)
		{
			mTBZwTkDXKQgAfxcspeSXeoLCArH mTBZwTkDXKQgAfxcspeSXeoLCArH2 = (mTBZwTkDXKQgAfxcspeSXeoLCArH)Activator.CreateInstance(LSfbzggqEHqKwxvKFNVQRxSmMGdX.YAoWqsiYgitWKYXzCaTXoqyhVoki(type3).oZsXwPXpWMAyxSSLxkHZIoVRzSUt);
			mTBZwTkDXKQgAfxcspeSXeoLCArH2.INAKpPIdivVlHuKeBRZwhBJKJAzd(A_1);
			if (mTBZwTkDXKQgAfxcspeSXeoLCArH == null)
			{
				mTBZwTkDXKQgAfxcspeSXeoLCArH = mTBZwTkDXKQgAfxcspeSXeoLCArH2;
				this.kyuABWqJPOQeZxeSwhJNDokRZAz.Add(KSBhlnaEzwOPefVXJEJuEiJqyvE.fCIkgHnkZdDHdKXUwhLauvNorFby, mTBZwTkDXKQgAfxcspeSXeoLCArH);
			}
			this.kyuABWqJPOQeZxeSwhJNDokRZAz.Add(HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.GvhcvCTcTAFKTTeLHDNLioRSPkvbA(type3), mTBZwTkDXKQgAfxcspeSXeoLCArH2);
			foreach (Type type4 in type3.GetInterfaces())
			{
				if (LSfbzggqEHqKwxvKFNVQRxSmMGdX.YAoWqsiYgitWKYXzCaTXoqyhVoki(type4) != null)
				{
					this.kyuABWqJPOQeZxeSwhJNDokRZAz.Add(HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.GvhcvCTcTAFKTTeLHDNLioRSPkvbA(type4), mTBZwTkDXKQgAfxcspeSXeoLCArH2);
				}
			}
		}
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x00017077 File Offset: 0x00015277
	internal IntPtr DcBEziaNiLvbmSxHUzOtoevZxsQRA(Type A_1)
	{
		return this.NJhgFRECeKiQPSAWLSkvQBOjEFTIb(HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.GvhcvCTcTAFKTTeLHDNLioRSPkvbA(A_1));
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x0003B3BC File Offset: 0x000395BC
	internal IntPtr NJhgFRECeKiQPSAWLSkvQBOjEFTIb(Guid A_1)
	{
		mTBZwTkDXKQgAfxcspeSXeoLCArH mTBZwTkDXKQgAfxcspeSXeoLCArH = this.oboeRxdtwfNPVFTSKKVbNCHaGrCtd(A_1);
		if (mTBZwTkDXKQgAfxcspeSXeoLCArH != null)
		{
			return mTBZwTkDXKQgAfxcspeSXeoLCArH.FXEBIagcuThOcOepHwiWojXacofZA;
		}
		return IntPtr.Zero;
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x0003B3E0 File Offset: 0x000395E0
	internal mTBZwTkDXKQgAfxcspeSXeoLCArH oboeRxdtwfNPVFTSKKVbNCHaGrCtd(Guid A_1)
	{
		mTBZwTkDXKQgAfxcspeSXeoLCArH result;
		this.kyuABWqJPOQeZxeSwhJNDokRZAz.TryGetValue(A_1, out result);
		return result;
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x0003B400 File Offset: 0x00039600
	protected virtual void llPMXDIryCoUKWCgOapGenIqdiXhb(bool A_1)
	{
		if (A_1)
		{
			foreach (mTBZwTkDXKQgAfxcspeSXeoLCArH mTBZwTkDXKQgAfxcspeSXeoLCArH in this.kyuABWqJPOQeZxeSwhJNDokRZAz.Values)
			{
				mTBZwTkDXKQgAfxcspeSXeoLCArH.Dispose();
			}
			this.kyuABWqJPOQeZxeSwhJNDokRZAz.Clear();
			if (this.jBmEvXBWAxpNjoQJnisugTkoCgtuA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.jBmEvXBWAxpNjoQJnisugTkoCgtuA);
				this.jBmEvXBWAxpNjoQJnisugTkoCgtuA = IntPtr.Zero;
			}
		}
	}

	// Token: 0x04000895 RID: 2197
	private readonly Dictionary<Guid, mTBZwTkDXKQgAfxcspeSXeoLCArH> kyuABWqJPOQeZxeSwhJNDokRZAz = new Dictionary<Guid, mTBZwTkDXKQgAfxcspeSXeoLCArH>();

	// Token: 0x04000896 RID: 2198
	private static readonly Dictionary<Type, List<Type>> ipWLoYNYFUMeUUgwSTZdsYxbqBBO = new Dictionary<Type, List<Type>>();

	// Token: 0x04000897 RID: 2199
	private IntPtr jBmEvXBWAxpNjoQJnisugTkoCgtuA;

	// Token: 0x04000898 RID: 2200
	[CompilerGenerated]
	private IntPtr[] czQxisXDAKfKedTiDKditJSciaugA;
}
