using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

// Token: 0x02000235 RID: 565
internal class SXzeyXYqAFvmtiXaUteubWFfCXrT : IDisposable
{
	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000E3C RID: 3644 RVA: 0x0001951B File Offset: 0x0001771B
	private bool UOrfLKsibWhfYiOLEDZIzuvWbwVwA
	{
		get
		{
			return hVaQpyMLtSMUpozCEslGMGuQGKOz.HrJoyuaKuYtJprtkbPUlfSbJixUd(this.bbiJOXVGhOKWWYaRJnaKNTAwveRE);
		}
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x0004303C File Offset: 0x0004123C
	public SXzeyXYqAFvmtiXaUteubWFfCXrT(string A_1, int A_2, int A_3)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (A_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		this.jsXyJerCIPeKGAsHkcIVxecCgBSkA = ObjectInstanceTracker.Default.Register(this);
		this.bbiJOXVGhOKWWYaRJnaKNTAwveRE = A_1;
		if (!this.SgYBFtFvHadsJqvSEKDktBWPWCtR())
		{
			throw new Exception("Could not open HID device.");
		}
		this.wGwQLpuqwmekWFBLVGqhJbCEkiTb = A_2;
		this.uAxFKMzjSPqfHQphBQMNHApKpFfm = A_2 + 8;
		this.XOhrnZHKnRdneGzWwBZiioUAKTrWA = new NativeBuffer(this.uAxFKMzjSPqfHQphBQMNHApKpFfm);
		this.kRfcbjGBnbVKfGNazOxwsRhKgjkIA = new KFTHDwYQBAyGhxeThcnbLWDUPSWS<InwmSbStntxHshbqEcOpJBZJJqVi.OmKXPaFMhykDSIIYgZgntVdGvhjP>();
		this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Idle;
		this.mhOdwJuCxrIBDgzMQEfJiFnxVoVl = ((A_3 < 0) ? 65535 : A_3);
		this.YSZkRaznkgbGZJwIsAhMwBiHBelkA = new object();
		this.jPsgprYmgjBpcSREXOQWChPRjDdX = new InwmSbStntxHshbqEcOpJBZJJqVi.fKnBasETCJOxAbtUJdnwYLJpKAnyA(SXzeyXYqAFvmtiXaUteubWFfCXrT.VNtthWOdtpDofbPewoSlHrYVUpKwA);
		this.tqfGUTAvxpJPsIJBcbXNwfLtihoFc();
	}

	// Token: 0x06000E3E RID: 3646 RVA: 0x00043110 File Offset: 0x00041310
	public SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG jQRXSNKSKFKlxvpbWFWAcsDcAnvKA(byte[] A_1)
	{
		object yszkRaznkgbGZJwIsAhMwBiHBelkA = this.YSZkRaznkgbGZJwIsAhMwBiHBelkA;
		SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG result;
		lock (yszkRaznkgbGZJwIsAhMwBiHBelkA)
		{
			if (this.UFvjtZHKHOJoHsGleYFNebDQyGNt)
			{
				result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.CriticalError;
			}
			else if (!this.fSdAMhcYRNqGihPnuSprAnJitsnS())
			{
				result = ((this.PuDLbwXSdBDtZBfXjdpfSiQaJLgl >= 10) ? SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.CriticalError : SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error);
			}
			else
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (A_1.Length < this.uAxFKMzjSPqfHQphBQMNHApKpFfm)
				{
					throw new Exception("buffer must be at least " + this.uAxFKMzjSPqfHQphBQMNHApKpFfm.ToString() + " bytes");
				}
				switch (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA)
				{
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Idle:
					this.ZawErYyJifQqXEQhCAcIokQmAiiCA();
					break;
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Waiting:
					this.lKmtnvpHcMclOAupYDdUsbPTsopw();
					break;
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.ErrorPending:
					this.edsgicGeFyyMfmVfogoLkyWuksAnA();
					break;
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.SuccessPending:
					this.IaXzimbMZOWWUXaJVbUBeOJiCTeU();
					break;
				}
				switch (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA)
				{
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Idle:
					result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Idle;
					break;
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Waiting:
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.ErrorPending:
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.SuccessPending:
					result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Waiting;
					break;
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.FinishedError:
					this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Idle;
					result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error;
					break;
				case SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.FinishedSuccess:
					this.XOhrnZHKnRdneGzWwBZiioUAKTrWA.TryReadBytes(A_1, this.uAxFKMzjSPqfHQphBQMNHApKpFfm, 0, 0);
					this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Idle;
					result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Success;
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}
		return result;
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x00043264 File Offset: 0x00041464
	private bool ZawErYyJifQqXEQhCAcIokQmAiiCA()
	{
		if (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA != SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Idle)
		{
			string str = "Cannot StartRead from this state. State = ";
			int num = (int)this.cPoCTonYEiaiIYpRdWHBKZZLvMhA;
			throw new Exception(str + num.ToString());
		}
		bool result;
		try
		{
			this.oYyqXBDGhPCtHhXnHKjSNvMHcImW();
			bool flag = InwmSbStntxHshbqEcOpJBZJJqVi.rmLxUtiLKKvpDHFFXebBQAfTmpsn(this.JdLuOeCnZRAZtUoAMNScXgjDTjCm, this.XOhrnZHKnRdneGzWwBZiioUAKTrWA, (uint)this.wGwQLpuqwmekWFBLVGqhJbCEkiTb, rldBWJiPNwVWNAQGlSaZBtbmtjRwA.BGZAgqFCOJwbYkvyudUcLwURrQAX(this.kRfcbjGBnbVKfGNazOxwsRhKgjkIA.UliKysXbcfYzEqXzsMIKufJRBCajA), this.jPsgprYmgjBpcSREXOQWChPRjDdX);
			if (flag)
			{
				this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Waiting;
				this.ZRXKMGtGhNXHJmGLKWGDgKLQtuep = true;
			}
			else
			{
				this.DeqjuLRhejdZCpCvLfwGMcTgimdg();
			}
			result = flag;
		}
		catch (Exception)
		{
			this.DeqjuLRhejdZCpCvLfwGMcTgimdg();
			result = false;
		}
		return result;
	}

	// Token: 0x06000E40 RID: 3648 RVA: 0x00043308 File Offset: 0x00041508
	private void lKmtnvpHcMclOAupYDdUsbPTsopw()
	{
		if (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA != SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Waiting)
		{
			string str = "Cannot CheckReadStatus from this state. State = ";
			int num = (int)this.cPoCTonYEiaiIYpRdWHBKZZLvMhA;
			throw new Exception(str + num.ToString());
		}
		switch (this.bGbPGNBJjEEJMlDeXIQuqiMAYtvw())
		{
		case SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Success:
			this.ojSgTkDgKvnaFJGvDCRoVUJOrBip();
			break;
		case SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error:
			this.DeqjuLRhejdZCpCvLfwGMcTgimdg();
			return;
		case SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Waiting:
			break;
		default:
			return;
		}
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x00043368 File Offset: 0x00041568
	private SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG bGbPGNBJjEEJMlDeXIQuqiMAYtvw()
	{
		if (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA != SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.Waiting)
		{
			return SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error;
		}
		SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG result;
		try
		{
			uint num = InwmSbStntxHshbqEcOpJBZJJqVi.heTkznCRAJqPtGiLiloPULxbqnkV(this.mhOdwJuCxrIBDgzMQEfJiFnxVoVl, true);
			if (num <= 128U)
			{
				if (num == 0U)
				{
					return SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Waiting;
				}
				if (num != 128U)
				{
					goto IL_7B;
				}
			}
			else if (num != 192U)
			{
				if (num != 258U && num != 4294967295U)
				{
					goto IL_7B;
				}
			}
			else
			{
				int num2;
				if (!InwmSbStntxHshbqEcOpJBZJJqVi.EWsWQYesCBPcCdBJjfXNxTtINRoU(this.JdLuOeCnZRAZtUoAMNScXgjDTjCm, rldBWJiPNwVWNAQGlSaZBtbmtjRwA.BGZAgqFCOJwbYkvyudUcLwURrQAX(this.kRfcbjGBnbVKfGNazOxwsRhKgjkIA.UliKysXbcfYzEqXzsMIKufJRBCajA), out num2, false))
				{
					return SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error;
				}
				return (num2 > 0) ? SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Success : SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error;
			}
			return SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Waiting;
			IL_7B:
			result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error;
		}
		catch
		{
			result = SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error;
		}
		return result;
	}

	// Token: 0x06000E42 RID: 3650 RVA: 0x00019528 File Offset: 0x00017728
	private void DeqjuLRhejdZCpCvLfwGMcTgimdg()
	{
		this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.ErrorPending;
		this.edsgicGeFyyMfmVfogoLkyWuksAnA();
	}

	// Token: 0x06000E43 RID: 3651 RVA: 0x0004340C File Offset: 0x0004160C
	private void edsgicGeFyyMfmVfogoLkyWuksAnA()
	{
		if (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA != SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.ErrorPending)
		{
			string str = "Cannot CheckErrorFinished from this state. State = ";
			int num = (int)this.cPoCTonYEiaiIYpRdWHBKZZLvMhA;
			throw new Exception(str + num.ToString());
		}
		this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.FinishedError;
	}

	// Token: 0x06000E44 RID: 3652 RVA: 0x00019537 File Offset: 0x00017737
	private void ojSgTkDgKvnaFJGvDCRoVUJOrBip()
	{
		this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.SuccessPending;
		this.IaXzimbMZOWWUXaJVbUBeOJiCTeU();
	}

	// Token: 0x06000E45 RID: 3653 RVA: 0x00043448 File Offset: 0x00041648
	private void IaXzimbMZOWWUXaJVbUBeOJiCTeU()
	{
		if (this.cPoCTonYEiaiIYpRdWHBKZZLvMhA != SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.SuccessPending)
		{
			string str = "Cannot CheckSuccessFinished from this state. State = ";
			int num = (int)this.cPoCTonYEiaiIYpRdWHBKZZLvMhA;
			throw new Exception(str + num.ToString());
		}
		this.cPoCTonYEiaiIYpRdWHBKZZLvMhA = SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA.FinishedSuccess;
		this.XOhrnZHKnRdneGzWwBZiioUAKTrWA.Write(ReInput.realTime, this.wGwQLpuqwmekWFBLVGqhJbCEkiTb);
	}

	// Token: 0x06000E46 RID: 3654 RVA: 0x00019546 File Offset: 0x00017746
	private void oYyqXBDGhPCtHhXnHKjSNvMHcImW()
	{
		this.tqfGUTAvxpJPsIJBcbXNwfLtihoFc();
		this.XOhrnZHKnRdneGzWwBZiioUAKTrWA.Clear();
		this.fdqavkkTTZiDTamWoYiGZuIUgkch = 0;
		this.ZRXKMGtGhNXHJmGLKWGDgKLQtuep = false;
	}

	// Token: 0x06000E47 RID: 3655 RVA: 0x0004349C File Offset: 0x0004169C
	private void tqfGUTAvxpJPsIJBcbXNwfLtihoFc()
	{
		InwmSbStntxHshbqEcOpJBZJJqVi.OmKXPaFMhykDSIIYgZgntVdGvhjP omKXPaFMhykDSIIYgZgntVdGvhjP;
		omKXPaFMhykDSIIYgZgntVdGvhjP.JyDlvgyAdvSfWaFosfMebHgJBdop = new IntPtr((int)this.jsXyJerCIPeKGAsHkcIVxecCgBSkA);
		omKXPaFMhykDSIIYgZgntVdGvhjP.divWfsRpyVmKNFzUffKpGmcdaZPDA = IntPtr.Zero;
		omKXPaFMhykDSIIYgZgntVdGvhjP.jufvHUECxQpwSsraSLjyHVqOXcGh = IntPtr.Zero;
		omKXPaFMhykDSIIYgZgntVdGvhjP.YzvjemyeoplMFhLwaihJUBqGlexd = 0;
		omKXPaFMhykDSIIYgZgntVdGvhjP.DiDBnzDBFOaVbUUoFQjZeibaQpjMA = 0;
		this.kRfcbjGBnbVKfGNazOxwsRhKgjkIA.yhGPmgDenGPRTCkELQiifieEdkHq = omKXPaFMhykDSIIYgZgntVdGvhjP;
	}

	// Token: 0x06000E48 RID: 3656 RVA: 0x00019567 File Offset: 0x00017767
	private bool fSdAMhcYRNqGihPnuSprAnJitsnS()
	{
		if (this.PuDLbwXSdBDtZBfXjdpfSiQaJLgl >= 10)
		{
			return false;
		}
		if (!this.SgYBFtFvHadsJqvSEKDktBWPWCtR())
		{
			this.PuDLbwXSdBDtZBfXjdpfSiQaJLgl++;
			return false;
		}
		if (this.PuDLbwXSdBDtZBfXjdpfSiQaJLgl > 0)
		{
			this.PuDLbwXSdBDtZBfXjdpfSiQaJLgl = 0;
		}
		return true;
	}

	// Token: 0x06000E49 RID: 3657 RVA: 0x000434F0 File Offset: 0x000416F0
	private bool SgYBFtFvHadsJqvSEKDktBWPWCtR()
	{
		if (this.JdLuOeCnZRAZtUoAMNScXgjDTjCm != InwmSbStntxHshbqEcOpJBZJJqVi.nSlEJXJkwsngJLggNFYSBfPgpZOPA)
		{
			return true;
		}
		if (!this.UOrfLKsibWhfYiOLEDZIzuvWbwVwA)
		{
			return false;
		}
		IntPtr intPtr = gGETNRbPSWqlyBUigXMEkvuRFmnB.sUqCujHxPvhbAItZrECwKbPHnhi(this.bbiJOXVGhOKWWYaRJnaKNTAwveRE, qxfynNTzhcgKivFwRJjlHgrcRzob.Overlapped, 3221225472U, hhPqsFbzywnSQVhdyrXfEDbDgBfaA.ShareRead | hhPqsFbzywnSQVhdyrXfEDbDgBfaA.ShareWrite);
		if (intPtr == InwmSbStntxHshbqEcOpJBZJJqVi.nSlEJXJkwsngJLggNFYSBfPgpZOPA)
		{
			return false;
		}
		this.JdLuOeCnZRAZtUoAMNScXgjDTjCm = intPtr;
		return true;
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x0001959E File Offset: 0x0001779E
	private void QyIrTfEOydVKcEmPxJVEMPaOGdme()
	{
		if (this.JdLuOeCnZRAZtUoAMNScXgjDTjCm == InwmSbStntxHshbqEcOpJBZJJqVi.nSlEJXJkwsngJLggNFYSBfPgpZOPA)
		{
			return;
		}
		gGETNRbPSWqlyBUigXMEkvuRFmnB.rueNvfdHvncohpilHeKujGQKqlfiA(this.JdLuOeCnZRAZtUoAMNScXgjDTjCm);
		this.JdLuOeCnZRAZtUoAMNScXgjDTjCm = InwmSbStntxHshbqEcOpJBZJJqVi.nSlEJXJkwsngJLggNFYSBfPgpZOPA;
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[MonoPInvokeCallback(typeof(InwmSbStntxHshbqEcOpJBZJJqVi.fKnBasETCJOxAbtUJdnwYLJpKAnyA))]
	private static void VNtthWOdtpDofbPewoSlHrYVUpKwA(int A_0, int A_1, IntPtr A_2)
	{
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x000195C9 File Offset: 0x000177C9
	public void Dispose()
	{
		this.CwtNrSLsBXvAQdnmKBoAEAlPnFPUA(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000E4D RID: 3661 RVA: 0x00043548 File Offset: 0x00041748
	protected virtual void GOVUmlCLjEGUfrSowbukicTZDTiUA()
	{
		try
		{
			this.CwtNrSLsBXvAQdnmKBoAEAlPnFPUA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000E4E RID: 3662 RVA: 0x00043578 File Offset: 0x00041778
	protected virtual void CwtNrSLsBXvAQdnmKBoAEAlPnFPUA(bool A_1)
	{
		if (this.UFvjtZHKHOJoHsGleYFNebDQyGNt)
		{
			return;
		}
		using (new Locker(this.YSZkRaznkgbGZJwIsAhMwBiHBelkA))
		{
			if (A_1)
			{
				this.kRfcbjGBnbVKfGNazOxwsRhKgjkIA.Dispose();
				ObjectInstanceTracker.Default.Unregister(this.jsXyJerCIPeKGAsHkcIVxecCgBSkA);
			}
			this.QyIrTfEOydVKcEmPxJVEMPaOGdme();
			this.UFvjtZHKHOJoHsGleYFNebDQyGNt = true;
		}
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[Conditional("DEBUGTHIS")]
	private void LLNbVldLgGTzzQzGifHtnIdgexfdA(string A_1)
	{
	}

	// Token: 0x040029C0 RID: 10688
	public const int JhKgReoueuCkHXdgEeSNKVvldsWQA = 8;

	// Token: 0x040029C1 RID: 10689
	private const int qxZfUGBHBnnDrhXwjJfVBetCjAoBc = 10;

	// Token: 0x040029C2 RID: 10690
	private readonly string bbiJOXVGhOKWWYaRJnaKNTAwveRE;

	// Token: 0x040029C3 RID: 10691
	private IntPtr JdLuOeCnZRAZtUoAMNScXgjDTjCm = InwmSbStntxHshbqEcOpJBZJJqVi.nSlEJXJkwsngJLggNFYSBfPgpZOPA;

	// Token: 0x040029C4 RID: 10692
	private readonly NativeBuffer XOhrnZHKnRdneGzWwBZiioUAKTrWA;

	// Token: 0x040029C5 RID: 10693
	private readonly int wGwQLpuqwmekWFBLVGqhJbCEkiTb;

	// Token: 0x040029C6 RID: 10694
	private readonly InwmSbStntxHshbqEcOpJBZJJqVi.fKnBasETCJOxAbtUJdnwYLJpKAnyA jPsgprYmgjBpcSREXOQWChPRjDdX;

	// Token: 0x040029C7 RID: 10695
	private readonly object YSZkRaznkgbGZJwIsAhMwBiHBelkA;

	// Token: 0x040029C8 RID: 10696
	private readonly uint jsXyJerCIPeKGAsHkcIVxecCgBSkA;

	// Token: 0x040029C9 RID: 10697
	private KFTHDwYQBAyGhxeThcnbLWDUPSWS<InwmSbStntxHshbqEcOpJBZJJqVi.OmKXPaFMhykDSIIYgZgntVdGvhjP> kRfcbjGBnbVKfGNazOxwsRhKgjkIA;

	// Token: 0x040029CA RID: 10698
	private SXzeyXYqAFvmtiXaUteubWFfCXrT.qziNZYHgRSvTjBbaBBcCgGRhsNatA cPoCTonYEiaiIYpRdWHBKZZLvMhA;

	// Token: 0x040029CB RID: 10699
	private int mhOdwJuCxrIBDgzMQEfJiFnxVoVl;

	// Token: 0x040029CC RID: 10700
	private bool ZRXKMGtGhNXHJmGLKWGDgKLQtuep;

	// Token: 0x040029CD RID: 10701
	private int fdqavkkTTZiDTamWoYiGZuIUgkch;

	// Token: 0x040029CE RID: 10702
	private int PuDLbwXSdBDtZBfXjdpfSiQaJLgl;

	// Token: 0x040029CF RID: 10703
	public readonly int uAxFKMzjSPqfHQphBQMNHApKpFfm;

	// Token: 0x040029D0 RID: 10704
	private bool UFvjtZHKHOJoHsGleYFNebDQyGNt;

	// Token: 0x02000236 RID: 566
	private enum qziNZYHgRSvTjBbaBBcCgGRhsNatA
	{
		// Token: 0x040029D2 RID: 10706
		Idle,
		// Token: 0x040029D3 RID: 10707
		Waiting,
		// Token: 0x040029D4 RID: 10708
		ErrorPending,
		// Token: 0x040029D5 RID: 10709
		FinishedError,
		// Token: 0x040029D6 RID: 10710
		SuccessPending,
		// Token: 0x040029D7 RID: 10711
		FinishedSuccess
	}

	// Token: 0x02000237 RID: 567
	public enum hLKqhdqJnsrKzEqdeLJBmfrXFwQG
	{
		// Token: 0x040029D9 RID: 10713
		Idle,
		// Token: 0x040029DA RID: 10714
		Success,
		// Token: 0x040029DB RID: 10715
		Error,
		// Token: 0x040029DC RID: 10716
		Waiting,
		// Token: 0x040029DD RID: 10717
		CriticalError
	}
}
