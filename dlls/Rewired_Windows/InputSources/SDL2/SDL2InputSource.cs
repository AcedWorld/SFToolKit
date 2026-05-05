using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	// Token: 0x020002C8 RID: 712
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SDL2InputSource : IInputSource, IDisposable
	{
		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06001501 RID: 5377 RVA: 0x0001BC4F File Offset: 0x00019E4F
		public bool initialized
		{
			get
			{
				return this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL;
			}
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x0004AB88 File Offset: 0x00048D88
		public SDL2InputSource(UpdateLoopSetting A_1, bool A_2, bool A_3, bool A_4, bool A_5)
		{
			this.zmevhdICyDrmTJWXTIHDUeFFxkDl = A_2;
			this.qOWSICSuZUGvkSuGhhLfwKoTtPYn = A_3;
			this.sfWuhdwZWTfPBnknqRfgCTaCxNUy = A_4;
			this.zTIHJZYwiDgcwZuGPERWNcJqscEi = A_5;
			this.vkhBevlZYCmxnuXYxURLoNKNoEsg = new ADictionary<int, hCScdGJDBOkdnOPGkrrPXBSVwrVO>();
			this.JheIzzeaGxnGyYnSAthWmJJtGICp = new ADictionary<int, FKWuvwnsMzXJtmRAPGdltgaXTZrf>();
			int num;
			if (UnityTools.isEditor && UnityTools.editorPlatform == EditorPlatform.OSX)
			{
				num = 25088;
			}
			else
			{
				num = 29184;
			}
			try
			{
				OVAKMTRSqGwLcMwowcaAZSrdOdKd.QWvPnNQluHSSjuepRpXMshjIoQv(UnityTools.effectivePlatform);
				if (OVAKMTRSqGwLcMwowcaAZSrdOdKd.bzhPJGsDOsEpqUcGXnGYxJJukBRb((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL = true;
				if (A_3)
				{
					this.gZnBBEXZmzfzejVEUQYsSdWvlgCN();
				}
				this.qIVMkiFaZRjadcgTbajhbZdnMSb();
				this.jZcuvNdLrOMmtCXUkNIrhwHZhHbn = new NativeBuffer(56);
			}
			catch
			{
				this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL = false;
				this.Dispose();
				throw;
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06001503 RID: 5379 RVA: 0x0004AC50 File Offset: 0x00048E50
		// (remove) Token: 0x06001504 RID: 5380 RVA: 0x0004AC88 File Offset: 0x00048E88
		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = this.dBBOUjtgvsxlthZRjPndwSguhEqr;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange<Action>(ref this.dBBOUjtgvsxlthZRjPndwSguhEqr, value2, action2);
				}
				while (action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.dBBOUjtgvsxlthZRjPndwSguhEqr;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange<Action>(ref this.dBBOUjtgvsxlthZRjPndwSguhEqr, value2, action2);
				}
				while (action != action2);
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06001505 RID: 5381 RVA: 0x0001BC57 File Offset: 0x00019E57
		// (remove) Token: 0x06001506 RID: 5382 RVA: 0x0001BC60 File Offset: 0x00019E60
		public event Action DeviceChangedEvent
		{
			add
			{
				this._DeviceChangedEvent += value;
			}
			remove
			{
				this._DeviceChangedEvent -= value;
			}
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x0001331E File Offset: 0x0001151E
		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x0001331E File Offset: 0x0001151E
		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x0001BC69 File Offset: 0x00019E69
		public void Update()
		{
			bool flag = this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL;
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0001BC72 File Offset: 0x00019E72
		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (!this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL)
			{
				return;
			}
			this.JCErAmjXEwvhSTGgBGhKvDZIxVqk();
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0001BC69 File Offset: 0x00019E69
		public void UpdateFinished()
		{
			bool flag = this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0004ACC0 File Offset: 0x00048EC0
		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL)
			{
				return null;
			}
			List<gAkEWbhxgbYyrIrsrBCPaLxymaOwA> list = new List<gAkEWbhxgbYyrIrsrBCPaLxymaOwA>();
			if (this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				foreach (KeyValuePair<int, hCScdGJDBOkdnOPGkrrPXBSVwrVO> keyValuePair in this.vkhBevlZYCmxnuXYxURLoNKNoEsg)
				{
					if (keyValuePair.Value.AyUphnUpgWuvtMVHJETolaBqkFSi)
					{
						list.Add(keyValuePair.Value);
					}
				}
			}
			if (this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
			{
				foreach (KeyValuePair<int, FKWuvwnsMzXJtmRAPGdltgaXTZrf> keyValuePair2 in this.JheIzzeaGxnGyYnSAthWmJJtGICp)
				{
					FKWuvwnsMzXJtmRAPGdltgaXTZrf value = keyValuePair2.Value;
					if (value.AyUphnUpgWuvtMVHJETolaBqkFSi)
					{
						list.Add(value);
					}
				}
			}
			return list as IList<T>;
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x0001BC83 File Offset: 0x00019E83
		private int IdPTsLeMJHVSUaTaxkILaeRpkdLR()
		{
			if (!this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL)
			{
				return 0;
			}
			return Math.Min(OVAKMTRSqGwLcMwowcaAZSrdOdKd.WMFUOJqIzawfnywmDbouFtbRqhaQ(), 32);
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x0004ADA4 File Offset: 0x00048FA4
		private int qyVJdtHQQagtkKknaSpOUKuXwGbI()
		{
			if (!this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL)
			{
				return 0;
			}
			int num = this.IdPTsLeMJHVSUaTaxkILaeRpkdLR();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!OVAKMTRSqGwLcMwowcaAZSrdOdKd.tOKFOeLqafdRABgtmvlCEqneOXhLA(i))
				{
					num2++;
				}
			}
			return num2;
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x0004ADE0 File Offset: 0x00048FE0
		private hCScdGJDBOkdnOPGkrrPXBSVwrVO QqytJOYCBIpNzvOrCvyPiZOAWGBt(int A_1)
		{
			IntPtr intPtr = OVAKMTRSqGwLcMwowcaAZSrdOdKd.SxbdkDoTMYpWYxjiuAfnbrInMAeG(A_1);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			gdTQNPtfPdCCoXDeSpbzXzWFikml gdTQNPtfPdCCoXDeSpbzXzWFikml = new gdTQNPtfPdCCoXDeSpbzXzWFikml(intPtr);
			AwnnodsOIsxGkOjbmSXwCAEEhdBEA awnnodsOIsxGkOjbmSXwCAEEhdBEA = this.FeAwzSeqXwYAKvPoguNZtraiYVqD(A_1, gdTQNPtfPdCCoXDeSpbzXzWFikml);
			if (awnnodsOIsxGkOjbmSXwCAEEhdBEA == null)
			{
				OVAKMTRSqGwLcMwowcaAZSrdOdKd.dhjRSasjtwFBQYaLMTqqxsphgomi(intPtr);
				return null;
			}
			return new hCScdGJDBOkdnOPGkrrPXBSVwrVO(gdTQNPtfPdCCoXDeSpbzXzWFikml, awnnodsOIsxGkOjbmSXwCAEEhdBEA);
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0004AE28 File Offset: 0x00049028
		private FKWuvwnsMzXJtmRAPGdltgaXTZrf oupceNDBXxgneGJNuTDKRnZnhcCIb(int A_1)
		{
			IntPtr intPtr = OVAKMTRSqGwLcMwowcaAZSrdOdKd.naLniUnPaBkmqDhLhafrAUGkyUtc(A_1);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			fmerTmdMhpiRCuDcjKKFSFSlvXtF fmerTmdMhpiRCuDcjKKFSFSlvXtF = new fmerTmdMhpiRCuDcjKKFSFSlvXtF(intPtr);
			AwnnodsOIsxGkOjbmSXwCAEEhdBEA awnnodsOIsxGkOjbmSXwCAEEhdBEA = this.oddlguPgXjrutQDaYqvkNyLCCSLt(A_1, fmerTmdMhpiRCuDcjKKFSFSlvXtF);
			if (awnnodsOIsxGkOjbmSXwCAEEhdBEA == null)
			{
				return null;
			}
			if (!awnnodsOIsxGkOjbmSXwCAEEhdBEA.gJhuZAzXBNUtvvdRDfpOpWrcfexd)
			{
				OVAKMTRSqGwLcMwowcaAZSrdOdKd.hgsFHzbgmBFokmawUKWaBliFAaII(intPtr);
				return null;
			}
			awnnodsOIsxGkOjbmSXwCAEEhdBEA.kVoAyAkzzbFunCHBxndeELGSfvgH = OVAKMTRSqGwLcMwowcaAZSrdOdKd.zHJAqCJRtUZJMIsioJvlnMkIdhpRA(fmerTmdMhpiRCuDcjKKFSFSlvXtF);
			return new FKWuvwnsMzXJtmRAPGdltgaXTZrf(fmerTmdMhpiRCuDcjKKFSFSlvXtF, awnnodsOIsxGkOjbmSXwCAEEhdBEA);
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0004AE88 File Offset: 0x00049088
		private AwnnodsOIsxGkOjbmSXwCAEEhdBEA FeAwzSeqXwYAKvPoguNZtraiYVqD(int A_1, gdTQNPtfPdCCoXDeSpbzXzWFikml A_2)
		{
			if (!this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL)
			{
				return null;
			}
			if (A_1 < 0 || A_1 >= 32)
			{
				return null;
			}
			if (A_2 == null || !A_2.IsValid)
			{
				return null;
			}
			return new AwnnodsOIsxGkOjbmSXwCAEEhdBEA
			{
				nPIZASnxZsGZUTCeSjYFReezUUWu = A_1,
				mMLUKOeESoEEDmUOAraXUCSKgkzK = OVAKMTRSqGwLcMwowcaAZSrdOdKd.xygEXEyEZYlAWRRmpdNazRmVearN(A_2),
				gJhuZAzXBNUtvvdRDfpOpWrcfexd = OVAKMTRSqGwLcMwowcaAZSrdOdKd.tOKFOeLqafdRABgtmvlCEqneOXhLA(A_1),
				GyJCCuXfBxtCNPuWqsuAJpiGEMzP = OVAKMTRSqGwLcMwowcaAZSrdOdKd.QmVgiLQyeddLrvemqVQdpbbqudmf(A_2),
				AGMHMnUMVXAakjBruveYSCfmopYC = OVAKMTRSqGwLcMwowcaAZSrdOdKd.JmXyYquEndqtgDqKlbIkDvRRnacw(A_2),
				DaGsNKYvYgLunHhdKoNVkqANcTIo = OVAKMTRSqGwLcMwowcaAZSrdOdKd.iChuodBTAsVqMbacFQXuJXGsUrUB(A_1),
				SnkezaHKcWUgcPvYgaLIAwTFDbeTA = OVAKMTRSqGwLcMwowcaAZSrdOdKd.xAOYYkmLEncjDBcloacIcgafohlN(A_2),
				kWRnaPMqchyeUQUAhEyMQQBogOqA = OVAKMTRSqGwLcMwowcaAZSrdOdKd.BLuPzBmGbBiVCvAYiFiDiKpXCOqMA(A_2),
				QDNrcALgRxLhouPVMMqyxOiNYfr = OVAKMTRSqGwLcMwowcaAZSrdOdKd.NVfUTefLkXGkEGSILyyZnNhodZCDA(A_2),
				aTDDxkffbnXcdBmOnWImviJYVQkVA = OVAKMTRSqGwLcMwowcaAZSrdOdKd.JWokbtzfiQlvPbLexHnnXUkLRsOk(A_2)
			};
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0004AF54 File Offset: 0x00049154
		private AwnnodsOIsxGkOjbmSXwCAEEhdBEA oddlguPgXjrutQDaYqvkNyLCCSLt(int A_1, fmerTmdMhpiRCuDcjKKFSFSlvXtF A_2)
		{
			if (A_2 == null || !A_2.IsValid)
			{
				return null;
			}
			gdTQNPtfPdCCoXDeSpbzXzWFikml gdTQNPtfPdCCoXDeSpbzXzWFikml = new gdTQNPtfPdCCoXDeSpbzXzWFikml(OVAKMTRSqGwLcMwowcaAZSrdOdKd.DzczfrioOvgNjKqvuEwOxBsmlbYm(A_2));
			if (!gdTQNPtfPdCCoXDeSpbzXzWFikml.IsValid)
			{
				return null;
			}
			return this.FeAwzSeqXwYAKvPoguNZtraiYVqD(A_1, gdTQNPtfPdCCoXDeSpbzXzWFikml);
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x0004AF94 File Offset: 0x00049194
		private void qIVMkiFaZRjadcgTbajhbZdnMSb()
		{
			for (int i = 0; i < this.IdPTsLeMJHVSUaTaxkILaeRpkdLR(); i++)
			{
				if (this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
				{
					this.IbeUSwZpAjseEdmliihfbGQZSAWPA(i);
				}
				if (this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
				{
					this.hABMRgSFjQPbcaeVkJwRutTXsAnG(i);
				}
			}
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x0004AFD4 File Offset: 0x000491D4
		private void nICvODNLFVGhpKliKMjweVPdbanwB()
		{
			if (this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
			{
				foreach (KeyValuePair<int, FKWuvwnsMzXJtmRAPGdltgaXTZrf> keyValuePair in this.JheIzzeaGxnGyYnSAthWmJJtGICp)
				{
					FKWuvwnsMzXJtmRAPGdltgaXTZrf value = keyValuePair.Value;
					value.zOmYbPmlCNhOMZBaUYjslOvIDoSE();
					value.Dispose();
				}
				this.JheIzzeaGxnGyYnSAthWmJJtGICp.Clear();
			}
			if (this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				foreach (KeyValuePair<int, hCScdGJDBOkdnOPGkrrPXBSVwrVO> keyValuePair2 in this.vkhBevlZYCmxnuXYxURLoNKNoEsg)
				{
					hCScdGJDBOkdnOPGkrrPXBSVwrVO value2 = keyValuePair2.Value;
					value2.zOmYbPmlCNhOMZBaUYjslOvIDoSE();
					value2.Dispose();
				}
				this.vkhBevlZYCmxnuXYxURLoNKNoEsg.Clear();
			}
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0004B0A8 File Offset: 0x000492A8
		private bool IbeUSwZpAjseEdmliihfbGQZSAWPA(int A_1)
		{
			if (A_1 < 0 || A_1 >= 32)
			{
				return false;
			}
			if (this.qOWSICSuZUGvkSuGhhLfwKoTtPYn && OVAKMTRSqGwLcMwowcaAZSrdOdKd.tOKFOeLqafdRABgtmvlCEqneOXhLA(A_1))
			{
				return false;
			}
			hCScdGJDBOkdnOPGkrrPXBSVwrVO hCScdGJDBOkdnOPGkrrPXBSVwrVO = this.QqytJOYCBIpNzvOrCvyPiZOAWGBt(A_1);
			if (hCScdGJDBOkdnOPGkrrPXBSVwrVO == null)
			{
				return false;
			}
			int qznrZSkVufiYjJZVBqxucrCPBJPh = hCScdGJDBOkdnOPGkrrPXBSVwrVO.qznrZSkVufiYjJZVBqxucrCPBJPh;
			if (this.vkhBevlZYCmxnuXYxURLoNKNoEsg.ContainsKey(qznrZSkVufiYjJZVBqxucrCPBJPh))
			{
				this.vkhBevlZYCmxnuXYxURLoNKNoEsg[qznrZSkVufiYjJZVBqxucrCPBJPh].zOmYbPmlCNhOMZBaUYjslOvIDoSE();
				this.vkhBevlZYCmxnuXYxURLoNKNoEsg[qznrZSkVufiYjJZVBqxucrCPBJPh] = hCScdGJDBOkdnOPGkrrPXBSVwrVO;
			}
			else
			{
				this.vkhBevlZYCmxnuXYxURLoNKNoEsg.Add(qznrZSkVufiYjJZVBqxucrCPBJPh, hCScdGJDBOkdnOPGkrrPXBSVwrVO);
			}
			hCScdGJDBOkdnOPGkrrPXBSVwrVO.AUSBQMBQovUMipSEGovfAWXjtXDxA();
			return true;
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x0001BC9B File Offset: 0x00019E9B
		private void pQViFDzeHKIThkXVaJXYicMKdjqE(int A_1)
		{
			if (!this.vkhBevlZYCmxnuXYxURLoNKNoEsg.ContainsKey(A_1))
			{
				return;
			}
			this.vkhBevlZYCmxnuXYxURLoNKNoEsg[A_1].zOmYbPmlCNhOMZBaUYjslOvIDoSE();
			this.vkhBevlZYCmxnuXYxURLoNKNoEsg.Remove(A_1);
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0004B128 File Offset: 0x00049328
		private bool hABMRgSFjQPbcaeVkJwRutTXsAnG(int A_1)
		{
			if (A_1 < 0 || A_1 >= 32)
			{
				return false;
			}
			if (!OVAKMTRSqGwLcMwowcaAZSrdOdKd.tOKFOeLqafdRABgtmvlCEqneOXhLA(A_1))
			{
				return false;
			}
			FKWuvwnsMzXJtmRAPGdltgaXTZrf fkwuvwnsMzXJtmRAPGdltgaXTZrf = this.oupceNDBXxgneGJNuTDKRnZnhcCIb(A_1);
			if (fkwuvwnsMzXJtmRAPGdltgaXTZrf == null)
			{
				return false;
			}
			int qznrZSkVufiYjJZVBqxucrCPBJPh = fkwuvwnsMzXJtmRAPGdltgaXTZrf.qznrZSkVufiYjJZVBqxucrCPBJPh;
			if (this.JheIzzeaGxnGyYnSAthWmJJtGICp.ContainsKey(qznrZSkVufiYjJZVBqxucrCPBJPh))
			{
				this.JheIzzeaGxnGyYnSAthWmJJtGICp[qznrZSkVufiYjJZVBqxucrCPBJPh].zOmYbPmlCNhOMZBaUYjslOvIDoSE();
				this.JheIzzeaGxnGyYnSAthWmJJtGICp[qznrZSkVufiYjJZVBqxucrCPBJPh] = fkwuvwnsMzXJtmRAPGdltgaXTZrf;
			}
			else
			{
				this.JheIzzeaGxnGyYnSAthWmJJtGICp.Add(qznrZSkVufiYjJZVBqxucrCPBJPh, fkwuvwnsMzXJtmRAPGdltgaXTZrf);
			}
			fkwuvwnsMzXJtmRAPGdltgaXTZrf.AUSBQMBQovUMipSEGovfAWXjtXDxA();
			return true;
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0001BCCA File Offset: 0x00019ECA
		private void JfHUwzSisHAIJTrYhVIKnyUHPslj(int A_1)
		{
			if (!this.JheIzzeaGxnGyYnSAthWmJJtGICp.ContainsKey(A_1))
			{
				return;
			}
			this.JheIzzeaGxnGyYnSAthWmJJtGICp[A_1].zOmYbPmlCNhOMZBaUYjslOvIDoSE();
			this.JheIzzeaGxnGyYnSAthWmJJtGICp.Remove(A_1);
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x0004B1A0 File Offset: 0x000493A0
		private hCScdGJDBOkdnOPGkrrPXBSVwrVO BmkKSlIAWHCSokWmgLhRUPCMrXvQ(int A_1)
		{
			hCScdGJDBOkdnOPGkrrPXBSVwrVO result;
			if (!this.vkhBevlZYCmxnuXYxURLoNKNoEsg.TryGetValue(A_1, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x0004B1C0 File Offset: 0x000493C0
		private FKWuvwnsMzXJtmRAPGdltgaXTZrf WwBbblAneQcHaCPSIPkVbUvAwpjgB(int A_1)
		{
			FKWuvwnsMzXJtmRAPGdltgaXTZrf result;
			if (!this.JheIzzeaGxnGyYnSAthWmJJtGICp.TryGetValue(A_1, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x0004B1E0 File Offset: 0x000493E0
		private void JCErAmjXEwvhSTGgBGhKvDZIxVqk()
		{
			while (OVAKMTRSqGwLcMwowcaAZSrdOdKd.GAzCxnceNqJGICBAYeMNeblXgSydb(this.jZcuvNdLrOMmtCXUkNIrhwHZhHbn) != 0)
			{
				this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.uhXyMNLPUdqtIYKAqCvPcMafernR(this.jZcuvNdLrOMmtCXUkNIrhwHZhHbn);
				OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA cvqKZDFNCDxXwAOVkUSKRmJINkNm = this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.CVqKZDFNCDxXwAOVkUSKRmJINkNm;
				double realTime = ReInput.realTime;
				switch (cvqKZDFNCDxXwAOVkUSKRmJINkNm)
				{
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYAXISMOTION:
					this.DPKOtRyNKEVysvKqiPHIxBfIBhQn(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.VEPaphMpVLxXLCZvlgFIMBEaijzeA, realTime);
					break;
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYBALLMOTION:
					this.XDvuYYUGpSjMkvwnRUYMRgwNEKxJ(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.znOZOMbiHRieagFAZhbcepqgGney, realTime);
					break;
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYHATMOTION:
					this.RoXUUcOJyMohJpORmobehxVvfRmS(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.THiDsxWhYuOgaErAhVThKIhFpiGe, realTime);
					break;
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYBUTTONDOWN:
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYBUTTONUP:
					this.tpmhckCicfIunzwgAFlOquhvmAxJ(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.GcfgSiBjLTjbOeFlQJKxwjOjoVkQ, realTime);
					break;
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYDEVICEADDED:
					this.JyhtcRRtPhcepEfrSBGDHNJeTIyg(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.jWLgtApBrEABXqHhgsNRaSKcHzSf);
					break;
				case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_JOYDEVICEREMOVED:
					this.iFkItBKzSHoikqkQEkAbTEPFYOSF(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.jWLgtApBrEABXqHhgsNRaSKcHzSf);
					break;
				default:
					switch (cvqKZDFNCDxXwAOVkUSKRmJINkNm)
					{
					case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_CONTROLLERAXISMOTION:
						this.SxaJFJWZwUqlPkkXHUKpAOfNJsYc(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.LDeZDiRhkBgAltfdlIYHERKCXIX, realTime);
						break;
					case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_CONTROLLERBUTTONDOWN:
					case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_CONTROLLERBUTTONUP:
						this.jZfcyxTQkMBgVBjvRuWMozJbwdjm(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.KhHIwJZrHFHUjhNXxcmQjazMWByGA, realTime);
						break;
					case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_CONTROLLERDEVICEADDED:
						this.fdbLraNIVgMNnoduRGPVImRJFKKC(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.BQDlYIYAAsUNqeIgvLEioZfsRrNe);
						break;
					case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_CONTROLLERDEVICEREMOVED:
						this.MvhQxQbUrgFOBaEdoTmGCVvKwAob(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.BQDlYIYAAsUNqeIgvLEioZfsRrNe);
						break;
					case OVAKMTRSqGwLcMwowcaAZSrdOdKd.CVLVhjVPxhEsXfgUQMmlCSpfgewUA.SDL_CONTROLLERDEVICEREMAPPED:
						this.XeeBDuBjNRwRVwlfWCxUvHxyPxBq(ref this.WoNGcfSZYfjscUSVFFtNPQUNNuTM.BQDlYIYAAsUNqeIgvLEioZfsRrNe);
						break;
					}
					break;
				}
			}
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0001BCF9 File Offset: 0x00019EF9
		private void DPKOtRyNKEVysvKqiPHIxBfIBhQn(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.xQMUOAWjAtNFWNFjuvufBAuHSVFh A_1, double A_2)
		{
			if (!this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				return;
			}
			this.ZdUhfUeJxCgjEVEEXigbmJQtvlhM(A_1.YaKekKPCYfQpqBThQRaNOwLEyQQJ, ahUUPlizYNgaLHTIoVYkrEwoekAt.Axis, A_1.VJnbPUtVRFDrjnnBzEFntvUJoTJn, A_1.iVchyXyJyKBafAlriuoamxKeTJBIA, A_2);
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0001BD1E File Offset: 0x00019F1E
		private void tpmhckCicfIunzwgAFlOquhvmAxJ(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.RqDEokVZGKAbcfLGkHrwaFkJCZPGA A_1, double A_2)
		{
			if (!this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				return;
			}
			this.ZdUhfUeJxCgjEVEEXigbmJQtvlhM(A_1.ijaGVJcZvvWhdWqTAvhPoQIUdPSBA, ahUUPlizYNgaLHTIoVYkrEwoekAt.Button, A_1.IFuFuwiMRFlMvfVxIYIhdQPdEQOrA, (short)A_1.rsmBHEYdQYRpbeacbADcHPYNFmmuA, A_2);
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x0001BD43 File Offset: 0x00019F43
		private void RoXUUcOJyMohJpORmobehxVvfRmS(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.GnQeASRuJAjyXBSLwLNmGVVlKLzM A_1, double A_2)
		{
			if (!this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				return;
			}
			this.ZdUhfUeJxCgjEVEEXigbmJQtvlhM(A_1.AXhYDWlCWEscRjDSbLFFrHRDeBBkA, ahUUPlizYNgaLHTIoVYkrEwoekAt.Hat, A_1.szobIPMmhpasWgfEEEQDYYuDdEyj, (short)A_1.TlcGUdpJuKgAabpBDRDnrxeaQuJv, A_2);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0001BD68 File Offset: 0x00019F68
		private void XDvuYYUGpSjMkvwnRUYMRgwNEKxJ(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.zEanrQQDkLatAuKSteWAmOppYHql A_1, double A_2)
		{
			bool flag = this.zmevhdICyDrmTJWXTIHDUeFFxkDl;
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0001BD71 File Offset: 0x00019F71
		private void JyhtcRRtPhcepEfrSBGDHNJeTIyg(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.NbQRCgOvuPMwABiGgGNpLMrMJDRX A_1)
		{
			if (!this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				return;
			}
			this.IbeUSwZpAjseEdmliihfbGQZSAWPA(A_1.PBcCXAHlqQRqrfkcpBdlBTgtEtgx);
			if (this.dBBOUjtgvsxlthZRjPndwSguhEqr != null)
			{
				this.dBBOUjtgvsxlthZRjPndwSguhEqr();
			}
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x0001BD9C File Offset: 0x00019F9C
		private void iFkItBKzSHoikqkQEkAbTEPFYOSF(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.NbQRCgOvuPMwABiGgGNpLMrMJDRX A_1)
		{
			if (!this.zmevhdICyDrmTJWXTIHDUeFFxkDl)
			{
				return;
			}
			this.pQViFDzeHKIThkXVaJXYicMKdjqE(A_1.PBcCXAHlqQRqrfkcpBdlBTgtEtgx);
			if (this.dBBOUjtgvsxlthZRjPndwSguhEqr != null)
			{
				this.dBBOUjtgvsxlthZRjPndwSguhEqr();
			}
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x0001BDC6 File Offset: 0x00019FC6
		private void SxaJFJWZwUqlPkkXHUKpAOfNJsYc(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.ldnXILLnWSjtiHDbgRDQZjywptaW A_1, double A_2)
		{
			if (!this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
			{
				return;
			}
			if (A_1.FLdXXTHFTAhaXZgRlQDBTRgONbaW != 6)
			{
				this.CabTiDwuGKGQqJQwJNmEUKOAlDki(A_1.HoJhMoDkOxBXJdgWsvkkqWduQzMR, ahUUPlizYNgaLHTIoVYkrEwoekAt.Axis, A_1.FLdXXTHFTAhaXZgRlQDBTRgONbaW, A_1.gUcovRAgcwqjHqPqlCdCGtQLmxwE, A_2);
			}
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x0001BDF4 File Offset: 0x00019FF4
		private void jZfcyxTQkMBgVBjvRuWMozJbwdjm(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.QyQHrUeawrgSHeDmPCrJrGHAsyTr A_1, double A_2)
		{
			if (!this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
			{
				return;
			}
			if (A_1.JOYSsPzwOnWtNZyNOdOEFOolFmWI != 15)
			{
				this.CabTiDwuGKGQqJQwJNmEUKOAlDki(A_1.bRGwpmKJfrVHoppiGjLTLiCOACgc, ahUUPlizYNgaLHTIoVYkrEwoekAt.Button, A_1.JOYSsPzwOnWtNZyNOdOEFOolFmWI, (short)A_1.RzRGiYKfWRqQEbtqzPgJRhQuhaVC, A_2);
			}
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x0001BE23 File Offset: 0x0001A023
		private void fdbLraNIVgMNnoduRGPVImRJFKKC(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.wxUYgmTepJuRSPuSIQLxuPQsDanO A_1)
		{
			if (!this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
			{
				return;
			}
			this.hABMRgSFjQPbcaeVkJwRutTXsAnG(A_1.cHiAJpGQVQbcZUmywnJKXWqQKaPVA);
			if (this.dBBOUjtgvsxlthZRjPndwSguhEqr != null)
			{
				this.dBBOUjtgvsxlthZRjPndwSguhEqr();
			}
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x0001BE4E File Offset: 0x0001A04E
		private void MvhQxQbUrgFOBaEdoTmGCVvKwAob(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.wxUYgmTepJuRSPuSIQLxuPQsDanO A_1)
		{
			if (!this.qOWSICSuZUGvkSuGhhLfwKoTtPYn)
			{
				return;
			}
			this.JfHUwzSisHAIJTrYhVIKnyUHPslj(A_1.cHiAJpGQVQbcZUmywnJKXWqQKaPVA);
			if (this.dBBOUjtgvsxlthZRjPndwSguhEqr != null)
			{
				this.dBBOUjtgvsxlthZRjPndwSguhEqr();
			}
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0001BE78 File Offset: 0x0001A078
		private void XeeBDuBjNRwRVwlfWCxUvHxyPxBq(ref OVAKMTRSqGwLcMwowcaAZSrdOdKd.wxUYgmTepJuRSPuSIQLxuPQsDanO A_1)
		{
			bool flag = this.qOWSICSuZUGvkSuGhhLfwKoTtPYn;
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0004B364 File Offset: 0x00049564
		private void ZdUhfUeJxCgjEVEEXigbmJQtvlhM(int A_1, ahUUPlizYNgaLHTIoVYkrEwoekAt A_2, byte A_3, short A_4, double A_5)
		{
			hCScdGJDBOkdnOPGkrrPXBSVwrVO hCScdGJDBOkdnOPGkrrPXBSVwrVO = this.BmkKSlIAWHCSokWmgLhRUPCMrXvQ(A_1);
			if (hCScdGJDBOkdnOPGkrrPXBSVwrVO == null)
			{
				return;
			}
			hCScdGJDBOkdnOPGkrrPXBSVwrVO.TjyrgwYLenviWzlVzwvKQhCXIANw(A_2, A_3, A_4, A_5);
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0004B38C File Offset: 0x0004958C
		private void CabTiDwuGKGQqJQwJNmEUKOAlDki(int A_1, ahUUPlizYNgaLHTIoVYkrEwoekAt A_2, byte A_3, short A_4, double A_5)
		{
			FKWuvwnsMzXJtmRAPGdltgaXTZrf fkwuvwnsMzXJtmRAPGdltgaXTZrf = this.WwBbblAneQcHaCPSIPkVbUvAwpjgB(A_1);
			if (fkwuvwnsMzXJtmRAPGdltgaXTZrf == null)
			{
				return;
			}
			fkwuvwnsMzXJtmRAPGdltgaXTZrf.TjyrgwYLenviWzlVzwvKQhCXIANw(A_2, A_3, A_4, A_5);
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x0004B3B4 File Offset: 0x000495B4
		private void gZnBBEXZmzfzejVEUQYsSdWvlgCN()
		{
			string[] array = EoxVgmTuynHToByIamQRzTRBSiiF.AXxDZEOjYVdFXGxUXCsBUJEvDJfk();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(OVAKMTRSqGwLcMwowcaAZSrdOdKd.UpJZZNvPkYAGddRUHqlMKAjfVuYm(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					OVAKMTRSqGwLcMwowcaAZSrdOdKd.hVuSOvXFkgdKfvjmwDQYUFQSUhXU(array[i]);
				}
			}
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x0001BE81 File Offset: 0x0001A081
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x0004B41C File Offset: 0x0004961C
		~SDL2InputSource()
		{
			this.Dispose(false);
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0001BE90 File Offset: 0x0001A090
		protected virtual void Dispose(bool disposing)
		{
			if (this.XHNPQjESaNClhtKLqLMiORdLwsdY)
			{
				return;
			}
			if (disposing)
			{
				if (this.jZcuvNdLrOMmtCXUkNIrhwHZhHbn != null)
				{
					this.jZcuvNdLrOMmtCXUkNIrhwHZhHbn.Dispose();
				}
				this.nICvODNLFVGhpKliKMjweVPdbanwB();
			}
			OVAKMTRSqGwLcMwowcaAZSrdOdKd.kruEAVKRYRDFeZsDAEuhZNWoZxwh();
			this.wAjdjwAUKJTLDvOpoAKQjTIoXFKL = false;
			this.XHNPQjESaNClhtKLqLMiORdLwsdY = true;
		}

		// Token: 0x04002EDC RID: 11996
		private const int MABiQDJHjhAdxdIIWKApheThPvviB = 32;

		// Token: 0x04002EDD RID: 11997
		private bool zmevhdICyDrmTJWXTIHDUeFFxkDl;

		// Token: 0x04002EDE RID: 11998
		private bool qOWSICSuZUGvkSuGhhLfwKoTtPYn;

		// Token: 0x04002EDF RID: 11999
		private bool sfWuhdwZWTfPBnknqRfgCTaCxNUy;

		// Token: 0x04002EE0 RID: 12000
		private bool zTIHJZYwiDgcwZuGPERWNcJqscEi;

		// Token: 0x04002EE1 RID: 12001
		private bool wAjdjwAUKJTLDvOpoAKQjTIoXFKL;

		// Token: 0x04002EE2 RID: 12002
		private ADictionary<int, hCScdGJDBOkdnOPGkrrPXBSVwrVO> vkhBevlZYCmxnuXYxURLoNKNoEsg;

		// Token: 0x04002EE3 RID: 12003
		private ADictionary<int, FKWuvwnsMzXJtmRAPGdltgaXTZrf> JheIzzeaGxnGyYnSAthWmJJtGICp;

		// Token: 0x04002EE4 RID: 12004
		private OVAKMTRSqGwLcMwowcaAZSrdOdKd.DLYjnarDGrhcEHGWKsYUYkLnHLoeA WoNGcfSZYfjscUSVFFtNPQUNNuTM;

		// Token: 0x04002EE5 RID: 12005
		private NativeBuffer jZcuvNdLrOMmtCXUkNIrhwHZhHbn;

		// Token: 0x04002EE6 RID: 12006
		[CompilerGenerated]
		private Action dBBOUjtgvsxlthZRjPndwSguhEqr;

		// Token: 0x04002EE7 RID: 12007
		private bool XHNPQjESaNClhtKLqLMiORdLwsdY;

		// Token: 0x020002C9 RID: 713
		// (Invoke) Token: 0x0600152E RID: 5422
		public delegate void vSyAoleaGRTYQOkpuBrrqSpjHTzw(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		// Token: 0x020002CA RID: 714
		// (Invoke) Token: 0x06001532 RID: 5426
		public delegate void EfHeXYatBJjXtoVVQcDpHnYNiRCP(int joystickIndex);

		// Token: 0x020002CB RID: 715
		// (Invoke) Token: 0x06001536 RID: 5430
		public delegate void ElYAyrqcZRyFxvNnQcZFVgNHAMfY(int joystickId);

		// Token: 0x020002CC RID: 716
		// (Invoke) Token: 0x0600153A RID: 5434
		public delegate void iIjAwleidyTJGUYmVWrEcXxwwAzFA(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);
	}
}
