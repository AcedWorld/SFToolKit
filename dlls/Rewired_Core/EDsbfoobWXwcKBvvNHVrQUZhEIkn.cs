using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

// Token: 0x02000025 RID: 37
internal class EDsbfoobWXwcKBvvNHVrQUZhEIkn
{
	// Token: 0x060001B1 RID: 433 RVA: 0x0002CF18 File Offset: 0x0002B118
	private void UWFHailCWyegPhCRlNQklPGtsUXW()
	{
		if (this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		IList<InputAction> list = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qHlLGZqAmOchfaxcwteLsvTnFDpEb;
		int num = (list != null) ? list.Count : 0;
		this.qVyzLlkmGoGkacyWpOnmgNfXweZiA = new AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>[num + 1];
		this.gszdagCSBzHMxcgEhZkjnxuEPrIFA = new int[ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.nEoFXOvBRwYSCZduQDPLTLMHVBUo + 1];
		ArrayTools.Populate<AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>>(this.qVyzLlkmGoGkacyWpOnmgNfXweZiA, 0, this.qVyzLlkmGoGkacyWpOnmgNfXweZiA.Length, new Func<AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>>(EDsbfoobWXwcKBvvNHVrQUZhEIkn.swuDHrfvaYWVDSZzpbfunIhSnOLY.<>9.dnFwaPbOBGyKWSzEqNUsnQZSfSyB));
		for (int i = 0; i < num; i++)
		{
			this.gszdagCSBzHMxcgEhZkjnxuEPrIFA[list[i].id] = i;
		}
		this.ASUaYGuBXyGrpKKlnDmguGsPJsbV = num;
		this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV = true;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x0002CFCC File Offset: 0x0002B1CC
	public void oflwYiaDYKXvuXodiKZyLupBEZNq(iWmRLdlDqgwSNYjkwtUZeqvQOyqs A_1, UpdateLoopType A_2)
	{
		AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist = this.qVyzLlkmGoGkacyWpOnmgNfXweZiA[this.gszdagCSBzHMxcgEhZkjnxuEPrIFA[A_1.nrhdAYZedZAtVEfTnqlPfrkEHCxob]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				alist = this.qVyzLlkmGoGkacyWpOnmgNfXweZiA[this.ASUaYGuBXyGrpKKlnDmguGsPJsbV];
			}
			int count = alist._count;
			if (EDsbfoobWXwcKBvvNHVrQUZhEIkn.fDMKtmzNqXbWQeFXkJPItWrUzJhi.Length < count)
			{
				EDsbfoobWXwcKBvvNHVrQUZhEIkn.fDMKtmzNqXbWQeFXkJPItWrUzJhi = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(alist._items, EDsbfoobWXwcKBvvNHVrQUZhEIkn.fDMKtmzNqXbWQeFXkJPItWrUzJhi, count);
			}
			for (int j = 0; j < count; j++)
			{
				EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA dBPfqMTgQmBXOAuMmjBnwihtQOyIA = EDsbfoobWXwcKBvvNHVrQUZhEIkn.fDMKtmzNqXbWQeFXkJPItWrUzJhi[j];
				if (dBPfqMTgQmBXOAuMmjBnwihtQOyIA != null && (A_1.FTSguAcJYczMlZkHpDdfJFjfzvIr || dBPfqMTgQmBXOAuMmjBnwihtQOyIA.rCuYJEVkdsAmyCeBZwVGpREtuhUy) && dBPfqMTgQmBXOAuMmjBnwihtQOyIA.ZAgMPsuCWAERdJzqmUPgQhZKDjvYA == A_2 && (dBPfqMTgQmBXOAuMmjBnwihtQOyIA.qIAJdDCnAnCElrdseztlPhiieNqGA < 0 || dBPfqMTgQmBXOAuMmjBnwihtQOyIA.qIAJdDCnAnCElrdseztlPhiieNqGA == A_1.nrhdAYZedZAtVEfTnqlPfrkEHCxob))
				{
					bool flag = false;
					InputActionEventType xaBVZtDDQxrMeYTmafKIzlpxaeNIA = dBPfqMTgQmBXOAuMmjBnwihtQOyIA.XaBVZtDDQxrMeYTmafKIzlpxaeNIA;
					switch (xaBVZtDDQxrMeYTmafKIzlpxaeNIA)
					{
					case InputActionEventType.Update:
						flag = true;
						break;
					case InputActionEventType.ButtonPressed:
						if (A_1.PLEzowLfRVYnmqUhFdELfVgtLRUU())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonUnpressed:
						if (!A_1.PLEzowLfRVYnmqUhFdELfVgtLRUU())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonJustPressed:
						if (A_1.cgnNvIBXdjcArepYxqVhcluOaiAF())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonJustReleased:
						if (A_1.iqpRhWPPruMPiSurJSIiJhNgoOiO())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonDoublePressed:
					{
						float num;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num);
						if (A_1.oZfcBbUtGNPizYqlKFKnHBYvkUFRA(num))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.ButtonJustDoublePressed:
					{
						float num2;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num2);
						if (A_1.tVtvoroswQXEnbdAENmIGAElmIBc(num2))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.ButtonPressedForTime:
					{
						float num3;
						if (!dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num3))
						{
							goto IL_651;
						}
						float num4;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(1, out num4);
						if (A_1.zpvDECrzpTCpSrBbeXUUgieFKOlg(num3, num4))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.ButtonJustPressedForTime:
					{
						float num5;
						if (!dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num5))
						{
							goto IL_651;
						}
						if (A_1.aGvkASuRZjHXWXpVpTxDBOXESHpc(num5))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.ButtonPressedForTimeJustReleased:
					{
						float num6;
						if (!dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num6))
						{
							goto IL_651;
						}
						float num7;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(1, out num7);
						if (A_1.DHssSjYakDuhVUAVpnowwTPiMpSE(num6, num7))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.ButtonShortPressed:
						if (A_1.DCYPHQBUQWTQyFmGGGYmeiAycAZR())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonJustShortPressed:
						if (A_1.HPuKJdCWHuCwPrBFJVtqnvtpQLnn())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonShortPressJustReleased:
						if (A_1.zyIWmXRVRLmtfjUGqPWKrVhOpplL())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonLongPressed:
						if (A_1.QXrrgbvJsTRiAGESJowgdvzQClRh())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonJustLongPressed:
						if (A_1.qTObevNNKnAiasvGCHaKAchXpabA())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonLongPressJustReleased:
						if (A_1.byeGARHXOEmjPxcQoTOUGzYnfkKu())
						{
							flag = true;
						}
						break;
					case InputActionEventType.ButtonRepeating:
						if (A_1.bydTKFtJThpJiBleSRZzwDlRDOBL())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonPressed:
						if (A_1.HWGpqzxmCQzoZIFrUhOuHScOhfbr())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonUnpressed:
						if (!A_1.HWGpqzxmCQzoZIFrUhOuHScOhfbr())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonJustPressed:
						if (A_1.DEqKIDythebfGxHycCDdFiTYHWfF())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonJustReleased:
						if (A_1.YJetLbybKqkFHlIxOBMORKTNchaY())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonDoublePressed:
					{
						float num8;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num8);
						if (A_1.RTWkHLUpAmesTmkgELyVDjMemKUn(num8))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.NegativeButtonJustDoublePressed:
					{
						float num9;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num9);
						if (A_1.HiYmLLYxrhaYHiqeBOjtIGIuNpEQ(num9))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.NegativeButtonPressedForTime:
					{
						float num10;
						if (!dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num10))
						{
							goto IL_651;
						}
						float num11;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(1, out num11);
						if (A_1.HJcCPAAxaZKAkATvymNFuNUGeixn(num10, num11))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.NegativeButtonJustPressedForTime:
					{
						float num12;
						if (!dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num12))
						{
							goto IL_651;
						}
						if (A_1.kxPJKadwjgTEVvjOoxRmKCjcGMshA(num12))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
					{
						float num13;
						if (!dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num13))
						{
							goto IL_651;
						}
						float num14;
						dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(1, out num14);
						if (A_1.VNMQdEPgUWpZCUdysrrlMBNQfMpq(num13, num14))
						{
							flag = true;
						}
						break;
					}
					case InputActionEventType.NegativeButtonShortPressed:
						if (A_1.yekfXbpfvbVIhCPSOETpyFIXXvZI())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonJustShortPressed:
						if (A_1.mlPISDGCNvaJJTDdHhtCJbYKKcQL())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonShortPressJustReleased:
						if (A_1.JGiKRKJdtaebnxDHKwGTQnLkWoQE())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonLongPressed:
						if (A_1.MOMLKtzwDEKbkXbSyroGZcZPmBrg())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonJustLongPressed:
						if (A_1.gNKMpTVSjVbOBkSwBfMifjCrZDNH())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonLongPressJustReleased:
						if (A_1.VhxSlbANjTXbiijCgfOaJwIAMgygA())
						{
							flag = true;
						}
						break;
					case InputActionEventType.NegativeButtonRepeating:
						if (A_1.aXIfnVraJSaGrMGfbgfHhEprqwOnA())
						{
							flag = true;
						}
						break;
					case InputActionEventType.AxisActive:
						if (!MathTools.ApproximatelyZero(A_1.ZPnnWnuioRHnHyXZXKWHKDyfDapAA()))
						{
							flag = true;
						}
						break;
					case InputActionEventType.AxisInactive:
						if (MathTools.ApproximatelyZero(A_1.ZPnnWnuioRHnHyXZXKWHKDyfDapAA()))
						{
							flag = true;
						}
						break;
					case InputActionEventType.AxisRawActive:
						if (!MathTools.ApproximatelyZero(A_1.KBRilOANCOjinFxICUYpQZAcnxarB()))
						{
							flag = true;
						}
						break;
					case InputActionEventType.AxisRawInactive:
						if (MathTools.ApproximatelyZero(A_1.KBRilOANCOjinFxICUYpQZAcnxarB()))
						{
							flag = true;
						}
						break;
					case InputActionEventType.AxisActiveOrJustInactive:
						if (!MathTools.ApproximatelyZero(A_1.ZPnnWnuioRHnHyXZXKWHKDyfDapAA()) || !MathTools.ApproximatelyZero(A_1.zeIvxBEyQDnSJZoRCukhvNlOQqPk()))
						{
							flag = true;
						}
						break;
					case InputActionEventType.AxisRawActiveOrJustInactive:
						if (!MathTools.ApproximatelyZero(A_1.KBRilOANCOjinFxICUYpQZAcnxarB()) || !MathTools.ApproximatelyZero(A_1.HkvMKqVfYwmAfauEGBultMpQzGWC()))
						{
							flag = true;
						}
						break;
					default:
						switch (xaBVZtDDQxrMeYTmafKIzlpxaeNIA)
						{
						case InputActionEventType.ButtonDoublePressJustReleased:
						{
							float num15;
							dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num15);
							if (A_1.JZbmLwFjMyOqchpEzbxnChuSPPgo(num15))
							{
								flag = true;
							}
							break;
						}
						case InputActionEventType.ButtonSinglePressed:
							if (A_1.TtiHmMweSqotoAUWwlbDjsYVgpkcA())
							{
								flag = true;
							}
							break;
						case InputActionEventType.ButtonJustSinglePressed:
							if (A_1.LWbCfZDYbtngeYfwehddWnTHkZmL())
							{
								flag = true;
							}
							break;
						case InputActionEventType.ButtonSinglePressJustReleased:
							if (A_1.HfbBeghVKYofUBdMipStTLDWnePt())
							{
								flag = true;
							}
							break;
						default:
							switch (xaBVZtDDQxrMeYTmafKIzlpxaeNIA)
							{
							case InputActionEventType.NegativeButtonDoublePressJustReleased:
							{
								float num16;
								dBPfqMTgQmBXOAuMmjBnwihtQOyIA.zqgsClEhVlTgDSgeJhjXUMTDfWjT(0, out num16);
								if (A_1.hZDmLiEfhVfHuJFrpmbvWeZDliNEb(num16))
								{
									flag = true;
								}
								break;
							}
							case InputActionEventType.NegativeButtonSinglePressed:
								if (A_1.gKhqNfBJWPQCWmZgQkjzVxTeghGO())
								{
									flag = true;
								}
								break;
							case InputActionEventType.NegativeButtonJustSinglePressed:
								if (A_1.UobencRdPOsVfpqTAcwrMWBOlucv())
								{
									flag = true;
								}
								break;
							case InputActionEventType.NegativeButtonSinglePressJustReleased:
								if (A_1.AaTsVPLVcybQrrgogrjJLSkxuclV())
								{
									flag = true;
								}
								break;
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					try
					{
						if (flag)
						{
							InputActionEventData obj = A_1.HyjLngXpGsCKcToxwewWyYkRweJx(A_2);
							obj.eventType = dBPfqMTgQmBXOAuMmjBnwihtQOyIA.XaBVZtDDQxrMeYTmafKIzlpxaeNIA;
							dBPfqMTgQmBXOAuMmjBnwihtQOyIA.dXuyJzUXwNotxplGXahZukfwGmJGA(obj);
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("Player input event callback", exception);
					}
				}
				IL_651:;
			}
		}
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0002D650 File Offset: 0x0002B850
	public void TcNARvDvKIxGffnLFhDNJGHZhBzY(Action<InputActionEventData> A_1, UpdateLoopType A_2, InputActionEventType A_3, int A_4, object[] A_5)
	{
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			this.UWFHailCWyegPhCRlNQklPGtsUXW();
		}
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA item;
		try
		{
			if (A_4 > ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.nEoFXOvBRwYSCZduQDPLTLMHVBUo)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + A_4.ToString());
			}
			item = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA(A_1, A_2, A_3, A_4, A_5);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (A_4 < 0)
		{
			this.qVyzLlkmGoGkacyWpOnmgNfXweZiA[this.ASUaYGuBXyGrpKKlnDmguGsPJsbV].Add(item);
		}
		else
		{
			this.qVyzLlkmGoGkacyWpOnmgNfXweZiA[this.gszdagCSBzHMxcgEhZkjnxuEPrIFA[A_4]].Add(item);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x0002D700 File Offset: 0x0002B900
	public void fNhbpLEVNSnTCKazlPYfPXCmHhBW(Action<InputActionEventData> A_1, UpdateLoopType A_2, InputActionEventType A_3, object[] A_4)
	{
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			this.UWFHailCWyegPhCRlNQklPGtsUXW();
		}
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA item;
		try
		{
			item = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA(A_1, A_2, A_3, -1, A_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		this.qVyzLlkmGoGkacyWpOnmgNfXweZiA[this.ASUaYGuBXyGrpKKlnDmguGsPJsbV].Add(item);
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0002D76C File Offset: 0x0002B96C
	public void aKlPrLhWNDpBllATLzxbtoiGoeMD(Action<InputActionEventData> A_1)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.fYTVYRBfNWFAemJaFTuZYVYesvbb fYTVYRBfNWFAemJaFTuZYVYesvbb = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.fYTVYRBfNWFAemJaFTuZYVYesvbb();
		fYTVYRBfNWFAemJaFTuZYVYesvbb.gfIVFjtaoFBUSTyIJaAZqAyrfHXZ = A_1;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = fYTVYRBfNWFAemJaFTuZYVYesvbb.BMihFruVTNKOaWtwpldkLAhdkhBO) == null)
			{
				match = (fYTVYRBfNWFAemJaFTuZYVYesvbb.BMihFruVTNKOaWtwpldkLAhdkhBO = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(fYTVYRBfNWFAemJaFTuZYVYesvbb.RxSsFjTQaChLyyABwffIBxaGhFcTA));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0002D7D4 File Offset: 0x0002B9D4
	public void sXWgAQJblgqZOPXEzLnjLKQmLywbb(Action<InputActionEventData> A_1, int A_2)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.CaGYElKojQKUvbaKycljhSgAvuWo caGYElKojQKUvbaKycljhSgAvuWo = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.CaGYElKojQKUvbaKycljhSgAvuWo();
		caGYElKojQKUvbaKycljhSgAvuWo.zOQqnSmbwSsxPOkIFmJSzTCvQjpH = A_1;
		caGYElKojQKUvbaKycljhSgAvuWo.byTgZDNDEcfBwxbSJmpEKdefhxsZ = A_2;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		if (caGYElKojQKUvbaKycljhSgAvuWo.byTgZDNDEcfBwxbSJmpEKdefhxsZ > ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.nEoFXOvBRwYSCZduQDPLTLMHVBUo)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = caGYElKojQKUvbaKycljhSgAvuWo.XlIenYdZxtzupNAiENCedhJxKIuO) == null)
			{
				match = (caGYElKojQKUvbaKycljhSgAvuWo.XlIenYdZxtzupNAiENCedhJxKIuO = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(caGYElKojQKUvbaKycljhSgAvuWo.mfzFKtmNBgEokcphsMMUwYSCkkBp));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0002D854 File Offset: 0x0002BA54
	public void ghUGCTAKryLQFcvSzFIafGwncrWR(Action<InputActionEventData> A_1, UpdateLoopType A_2)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.pMhGiFYxDHKUMPCwAbTjLYMqfpDU pMhGiFYxDHKUMPCwAbTjLYMqfpDU = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.pMhGiFYxDHKUMPCwAbTjLYMqfpDU();
		pMhGiFYxDHKUMPCwAbTjLYMqfpDU.JTaEHlJRFgfosakEvfvCAVgEOhHIb = A_1;
		pMhGiFYxDHKUMPCwAbTjLYMqfpDU.DBAxyOybRdnwlFBVUWKxPmoPBIUhA = A_2;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = pMhGiFYxDHKUMPCwAbTjLYMqfpDU.AzjSXbvkAnslKLrATOINoWLcNVcG) == null)
			{
				match = (pMhGiFYxDHKUMPCwAbTjLYMqfpDU.AzjSXbvkAnslKLrATOINoWLcNVcG = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(pMhGiFYxDHKUMPCwAbTjLYMqfpDU.dwIfnIAckcEVOvhJdlDLLxdScvQyA));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0002D8C4 File Offset: 0x0002BAC4
	public void dRqvjvEIijZaajZZtJtWeThJtxjr(Action<InputActionEventData> A_1, InputActionEventType A_2)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.jWNpkLeyYRSQwxLNmIfwZTIaSuab jWNpkLeyYRSQwxLNmIfwZTIaSuab = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.jWNpkLeyYRSQwxLNmIfwZTIaSuab();
		jWNpkLeyYRSQwxLNmIfwZTIaSuab.gNrIGqezctKIorUHZsTWlCEbaPJN = A_1;
		jWNpkLeyYRSQwxLNmIfwZTIaSuab.MNPTpowghPtMgXoSiAXWnWRZqooU = A_2;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = jWNpkLeyYRSQwxLNmIfwZTIaSuab.RFxKdFqrjfOBUBTMUbrMbjWEKAxT) == null)
			{
				match = (jWNpkLeyYRSQwxLNmIfwZTIaSuab.RFxKdFqrjfOBUBTMUbrMbjWEKAxT = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(jWNpkLeyYRSQwxLNmIfwZTIaSuab.HtoQYmlaSbuZCqhMfRIVjUWpsRpl));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0002D934 File Offset: 0x0002BB34
	public void fWaXpZQfEjIMvrMtiixwKVBOAIwG(Action<InputActionEventData> A_1, UpdateLoopType A_2, int A_3)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.pxYkoWmUHucauiArMxaQQiXRUrYn pxYkoWmUHucauiArMxaQQiXRUrYn = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.pxYkoWmUHucauiArMxaQQiXRUrYn();
		pxYkoWmUHucauiArMxaQQiXRUrYn.fTffujbbzCywcSCevzQwFSgAmtFS = A_1;
		pxYkoWmUHucauiArMxaQQiXRUrYn.EprAjgBAlOXEHHRRdFrUFfZNRRkmA = A_2;
		pxYkoWmUHucauiArMxaQQiXRUrYn.SUoxFtgHeJPkuBKJRaiYBFzemozVA = A_3;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		if (pxYkoWmUHucauiArMxaQQiXRUrYn.SUoxFtgHeJPkuBKJRaiYBFzemozVA > ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.nEoFXOvBRwYSCZduQDPLTLMHVBUo)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = pxYkoWmUHucauiArMxaQQiXRUrYn.YzrFiOsWtVjtwaWYvGhJMHKlaYZr) == null)
			{
				match = (pxYkoWmUHucauiArMxaQQiXRUrYn.YzrFiOsWtVjtwaWYvGhJMHKlaYZr = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(pxYkoWmUHucauiArMxaQQiXRUrYn.EAjfuraNMBwXkDXwMwJBpBuAJWWu));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0002D9BC File Offset: 0x0002BBBC
	public void hoSpDQKBahNwaMaqNcaQciMEUzTy(Action<InputActionEventData> A_1, UpdateLoopType A_2, InputActionEventType A_3, int A_4)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.cMFCyyQkiHcypetQaphkxUywtCXJ cMFCyyQkiHcypetQaphkxUywtCXJ = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.cMFCyyQkiHcypetQaphkxUywtCXJ();
		cMFCyyQkiHcypetQaphkxUywtCXJ.aYVjfwICAOKGcPvOxCcansEnyqtg = A_1;
		cMFCyyQkiHcypetQaphkxUywtCXJ.dPZLIZKfdVIkIhqxoQRqcHuPfDicb = A_2;
		cMFCyyQkiHcypetQaphkxUywtCXJ.XjxWgaFFufvgAcrSBhoLzETUwczv = A_4;
		cMFCyyQkiHcypetQaphkxUywtCXJ.kxAnWEFzPLOUhxOLEbDprNjERvSd = A_3;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		if (cMFCyyQkiHcypetQaphkxUywtCXJ.XjxWgaFFufvgAcrSBhoLzETUwczv > ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.nEoFXOvBRwYSCZduQDPLTLMHVBUo)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = cMFCyyQkiHcypetQaphkxUywtCXJ.SvovjehHekuAaNgbyrEZusdcIHu) == null)
			{
				match = (cMFCyyQkiHcypetQaphkxUywtCXJ.SvovjehHekuAaNgbyrEZusdcIHu = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(cMFCyyQkiHcypetQaphkxUywtCXJ.iHOcNNxCxYkrtEojBtaPWMNbPBol));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0002DA4C File Offset: 0x0002BC4C
	public void JsNNOYtGIYKigpakEbftqksoiwwA(Action<InputActionEventData> A_1, UpdateLoopType A_2, InputActionEventType A_3)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.XEhFTZALGhKlEdrgApjPtelxqbPE xehFTZALGhKlEdrgApjPtelxqbPE = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.XEhFTZALGhKlEdrgApjPtelxqbPE();
		xehFTZALGhKlEdrgApjPtelxqbPE.eSHETbzFOwqBPWFXCigtSkvpdFQD = A_1;
		xehFTZALGhKlEdrgApjPtelxqbPE.RfmWddLSqqksEakWwwInvyJrdMFy = A_2;
		xehFTZALGhKlEdrgApjPtelxqbPE.szffwvZNveGPbCfxndGfDQVYZVpqA = A_3;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = xehFTZALGhKlEdrgApjPtelxqbPE.viUeTgyNrFgiufEgyLzyZQIAhYGGb) == null)
			{
				match = (xehFTZALGhKlEdrgApjPtelxqbPE.viUeTgyNrFgiufEgyLzyZQIAhYGGb = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(xehFTZALGhKlEdrgApjPtelxqbPE.RXhsAbliONcagxQNNWrMGsosJpYt));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0002DAC0 File Offset: 0x0002BCC0
	public void NhRaRtGtbOtwKsMEefGXFbcUHutMA(Action<InputActionEventData> A_1, InputActionEventType A_2, int A_3)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn.uOmakZGOudnLqcZSKEvzllTOKesSA uOmakZGOudnLqcZSKEvzllTOKesSA = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.uOmakZGOudnLqcZSKEvzllTOKesSA();
		uOmakZGOudnLqcZSKEvzllTOKesSA.TCAfjggHZxmGyroPoMLwBSHtqqnD = A_1;
		uOmakZGOudnLqcZSKEvzllTOKesSA.hdXBGaLrmEPAarkMeaRmJLLgMlpiA = A_3;
		uOmakZGOudnLqcZSKEvzllTOKesSA.yrcpkvVhpWLeWHGCCUUhasEpWgDK = A_2;
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		if (uOmakZGOudnLqcZSKEvzllTOKesSA.hdXBGaLrmEPAarkMeaRmJLLgMlpiA > ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.nEoFXOvBRwYSCZduQDPLTLMHVBUo)
		{
			return;
		}
		foreach (AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> alist in this.qVyzLlkmGoGkacyWpOnmgNfXweZiA)
		{
			Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> match;
			if ((match = uOmakZGOudnLqcZSKEvzllTOKesSA.heqGrUYAReaiKtultBWUFlRLFRIiA) == null)
			{
				match = (uOmakZGOudnLqcZSKEvzllTOKesSA.heqGrUYAReaiKtultBWUFlRLFRIiA = new Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>(uOmakZGOudnLqcZSKEvzllTOKesSA.jZWfanmXelJmRQOmtfqZULLlDhbdA));
			}
			alist.RemoveAll(match);
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0002DB48 File Offset: 0x0002BD48
	public void StdAWPUyotLZUXBheXfqknuHIBxn()
	{
		if (!this.qDtSnOGRmtBjmJkcsBXzuOJUpKOV)
		{
			return;
		}
		AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>[] array = this.qVyzLlkmGoGkacyWpOnmgNfXweZiA;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Clear();
		}
		this.FxuLdXxkYKWaoVuDcoOAIunGQFkL();
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0002DB84 File Offset: 0x0002BD84
	private void FxuLdXxkYKWaoVuDcoOAIunGQFkL()
	{
		int num = 0;
		for (int i = 0; i < this.qVyzLlkmGoGkacyWpOnmgNfXweZiA.Length; i++)
		{
			num += this.qVyzLlkmGoGkacyWpOnmgNfXweZiA[i]._count;
		}
		this.dvrNpBCudvGHLNbZbdfKCDuHtjMlA = num;
	}

	// Token: 0x040000A9 RID: 169
	private static EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA[] fDMKtmzNqXbWQeFXkJPItWrUzJhi = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA[100];

	// Token: 0x040000AA RID: 170
	private bool qDtSnOGRmtBjmJkcsBXzuOJUpKOV;

	// Token: 0x040000AB RID: 171
	private AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>[] qVyzLlkmGoGkacyWpOnmgNfXweZiA;

	// Token: 0x040000AC RID: 172
	private int[] gszdagCSBzHMxcgEhZkjnxuEPrIFA;

	// Token: 0x040000AD RID: 173
	private int ASUaYGuBXyGrpKKlnDmguGsPJsbV;

	// Token: 0x040000AE RID: 174
	public int dvrNpBCudvGHLNbZbdfKCDuHtjMlA;

	// Token: 0x02000026 RID: 38
	public class dBPfqMTgQmBXOAuMmjBnwihtQOyIA
	{
		// Token: 0x060001BF RID: 447 RVA: 0x0002DBC0 File Offset: 0x0002BDC0
		public dBPfqMTgQmBXOAuMmjBnwihtQOyIA(Action<InputActionEventData> A_1, UpdateLoopType A_2, InputActionEventType A_3, int A_4, object[] A_5)
		{
			this.ZAgMPsuCWAERdJzqmUPgQhZKDjvYA = A_2;
			this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA = A_3;
			this.qIAJdDCnAnCElrdseztlPhiieNqGA = A_4;
			this.dXuyJzUXwNotxplGXahZukfwGmJGA = A_1;
			this.YqubBsynVUoAZnEoYhPdjJJCzTQs(A_5);
			if (A_3 <= InputActionEventType.ButtonUnpressed)
			{
				if (A_3 != InputActionEventType.Update && A_3 != InputActionEventType.ButtonUnpressed)
				{
					return;
				}
			}
			else if (A_3 != InputActionEventType.NegativeButtonUnpressed && A_3 != InputActionEventType.AxisInactive && A_3 != InputActionEventType.AxisRawInactive)
			{
				return;
			}
			this.rCuYJEVkdsAmyCeBZwVGpREtuhUy = true;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00003887 File Offset: 0x00001A87
		public bool zqgsClEhVlTgDSgeJhjXUMTDfWjT(int A_1, out float A_2)
		{
			if (this.dHcHADruyzNwoJmOBQWzdXFgvYSD == null || this.dHcHADruyzNwoJmOBQWzdXFgvYSD.Length <= A_1)
			{
				A_2 = 0f;
				return false;
			}
			A_2 = this.dHcHADruyzNwoJmOBQWzdXFgvYSD[A_1];
			return true;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0002DC1C File Offset: 0x0002BE1C
		private void YqubBsynVUoAZnEoYhPdjJJCzTQs(object[] A_1)
		{
			InputActionEventType xaBVZtDDQxrMeYTmafKIzlpxaeNIA = this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA;
			if (xaBVZtDDQxrMeYTmafKIzlpxaeNIA <= InputActionEventType.NegativeButtonPressedForTimeJustReleased)
			{
				switch (xaBVZtDDQxrMeYTmafKIzlpxaeNIA)
				{
				case InputActionEventType.ButtonDoublePressed:
				case InputActionEventType.ButtonJustDoublePressed:
					goto IL_201;
				case InputActionEventType.ButtonPressedForTime:
				case InputActionEventType.ButtonPressedForTimeJustReleased:
					break;
				case InputActionEventType.ButtonJustPressedForTime:
					goto IL_163;
				default:
					switch (xaBVZtDDQxrMeYTmafKIzlpxaeNIA)
					{
					case InputActionEventType.NegativeButtonDoublePressed:
					case InputActionEventType.NegativeButtonJustDoublePressed:
						goto IL_201;
					case InputActionEventType.NegativeButtonPressedForTime:
					case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
						break;
					case InputActionEventType.NegativeButtonJustPressedForTime:
						goto IL_163;
					default:
						return;
					}
					break;
				}
				if (A_1 == null || A_1.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				this.dHcHADruyzNwoJmOBQWzdXFgvYSD = new float[2];
				if (A_1[0] is float)
				{
					this.dHcHADruyzNwoJmOBQWzdXFgvYSD[0] = (float)A_1[0];
				}
				else
				{
					if (!(A_1[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA.ToString() + "\". Argument 0: time [float]");
					}
					this.dHcHADruyzNwoJmOBQWzdXFgvYSD[0] = (float)((int)A_1[0]);
				}
				if (A_1.Length <= 1)
				{
					return;
				}
				if (A_1[1] is float)
				{
					this.dHcHADruyzNwoJmOBQWzdXFgvYSD[1] = (float)A_1[1];
					return;
				}
				if (A_1[1] is int)
				{
					this.dHcHADruyzNwoJmOBQWzdXFgvYSD[1] = (float)((int)A_1[1]);
					return;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA.ToString() + "\". Argument 1 (optional): expireIn [float]");
				IL_163:
				if (A_1 == null || A_1.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA.ToString() + "\". Requires 1 argument: time [float]");
				}
				this.dHcHADruyzNwoJmOBQWzdXFgvYSD = new float[1];
				if (A_1[0] is float)
				{
					this.dHcHADruyzNwoJmOBQWzdXFgvYSD[0] = (float)A_1[0];
					return;
				}
				if (A_1[0] is int)
				{
					this.dHcHADruyzNwoJmOBQWzdXFgvYSD[0] = (float)((int)A_1[0]);
					return;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA.ToString() + "\". Argument 0: time [float]");
			}
			else if (xaBVZtDDQxrMeYTmafKIzlpxaeNIA != InputActionEventType.ButtonDoublePressJustReleased && xaBVZtDDQxrMeYTmafKIzlpxaeNIA != InputActionEventType.NegativeButtonDoublePressJustReleased)
			{
				return;
			}
			IL_201:
			if (A_1 == null || A_1.Length < 1)
			{
				return;
			}
			this.dHcHADruyzNwoJmOBQWzdXFgvYSD = new float[1];
			if (A_1[0] is float)
			{
				this.dHcHADruyzNwoJmOBQWzdXFgvYSD[0] = (float)A_1[0];
				return;
			}
			if (A_1[0] is int)
			{
				this.dHcHADruyzNwoJmOBQWzdXFgvYSD[0] = (float)((int)A_1[0]);
				return;
			}
			throw new Exception("Wrong argument type passed for Input event type \"" + this.XaBVZtDDQxrMeYTmafKIzlpxaeNIA.ToString() + "\". Argument 0 (optional): time [float]");
		}

		// Token: 0x040000AF RID: 175
		public readonly Action<InputActionEventData> dXuyJzUXwNotxplGXahZukfwGmJGA;

		// Token: 0x040000B0 RID: 176
		public readonly UpdateLoopType ZAgMPsuCWAERdJzqmUPgQhZKDjvYA;

		// Token: 0x040000B1 RID: 177
		public readonly InputActionEventType XaBVZtDDQxrMeYTmafKIzlpxaeNIA;

		// Token: 0x040000B2 RID: 178
		public readonly int qIAJdDCnAnCElrdseztlPhiieNqGA;

		// Token: 0x040000B3 RID: 179
		public readonly bool rCuYJEVkdsAmyCeBZwVGpREtuhUy;

		// Token: 0x040000B4 RID: 180
		public float[] dHcHADruyzNwoJmOBQWzdXFgvYSD;
	}

	// Token: 0x02000027 RID: 39
	[CompilerGenerated]
	[Serializable]
	private sealed class swuDHrfvaYWVDSZzpbfunIhSnOLY
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x000038BC File Offset: 0x00001ABC
		internal AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> dnFwaPbOBGyKWSzEqNUsnQZSfSyB()
		{
			return new AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>();
		}

		// Token: 0x040000B5 RID: 181
		public static readonly EDsbfoobWXwcKBvvNHVrQUZhEIkn.swuDHrfvaYWVDSZzpbfunIhSnOLY <>9 = new EDsbfoobWXwcKBvvNHVrQUZhEIkn.swuDHrfvaYWVDSZzpbfunIhSnOLY();

		// Token: 0x040000B6 RID: 182
		public static Func<AList<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA>> <>9__8_0;
	}

	// Token: 0x02000028 RID: 40
	[CompilerGenerated]
	private sealed class fYTVYRBfNWFAemJaFTuZYVYesvbb
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x000038C3 File Offset: 0x00001AC3
		internal bool RxSsFjTQaChLyyABwffIBxaGhFcTA(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.gfIVFjtaoFBUSTyIJaAZqAyrfHXZ;
		}

		// Token: 0x040000B7 RID: 183
		public Action<InputActionEventData> gfIVFjtaoFBUSTyIJaAZqAyrfHXZ;

		// Token: 0x040000B8 RID: 184
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> BMihFruVTNKOaWtwpldkLAhdkhBO;
	}

	// Token: 0x02000029 RID: 41
	[CompilerGenerated]
	private sealed class CaGYElKojQKUvbaKycljhSgAvuWo
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x000038D6 File Offset: 0x00001AD6
		internal bool mfzFKtmNBgEokcphsMMUwYSCkkBp(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.zOQqnSmbwSsxPOkIFmJSzTCvQjpH && A_1.qIAJdDCnAnCElrdseztlPhiieNqGA == this.byTgZDNDEcfBwxbSJmpEKdefhxsZ;
		}

		// Token: 0x040000B9 RID: 185
		public Action<InputActionEventData> zOQqnSmbwSsxPOkIFmJSzTCvQjpH;

		// Token: 0x040000BA RID: 186
		public int byTgZDNDEcfBwxbSJmpEKdefhxsZ;

		// Token: 0x040000BB RID: 187
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> XlIenYdZxtzupNAiENCedhJxKIuO;
	}

	// Token: 0x0200002A RID: 42
	[CompilerGenerated]
	private sealed class pMhGiFYxDHKUMPCwAbTjLYMqfpDU
	{
		// Token: 0x060001CA RID: 458 RVA: 0x000038FB File Offset: 0x00001AFB
		internal bool dwIfnIAckcEVOvhJdlDLLxdScvQyA(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.JTaEHlJRFgfosakEvfvCAVgEOhHIb && A_1.ZAgMPsuCWAERdJzqmUPgQhZKDjvYA == this.DBAxyOybRdnwlFBVUWKxPmoPBIUhA;
		}

		// Token: 0x040000BC RID: 188
		public Action<InputActionEventData> JTaEHlJRFgfosakEvfvCAVgEOhHIb;

		// Token: 0x040000BD RID: 189
		public UpdateLoopType DBAxyOybRdnwlFBVUWKxPmoPBIUhA;

		// Token: 0x040000BE RID: 190
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> AzjSXbvkAnslKLrATOINoWLcNVcG;
	}

	// Token: 0x0200002B RID: 43
	[CompilerGenerated]
	private sealed class jWNpkLeyYRSQwxLNmIfwZTIaSuab
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00003920 File Offset: 0x00001B20
		internal bool HtoQYmlaSbuZCqhMfRIVjUWpsRpl(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.gNrIGqezctKIorUHZsTWlCEbaPJN && A_1.XaBVZtDDQxrMeYTmafKIzlpxaeNIA == this.MNPTpowghPtMgXoSiAXWnWRZqooU;
		}

		// Token: 0x040000BF RID: 191
		public Action<InputActionEventData> gNrIGqezctKIorUHZsTWlCEbaPJN;

		// Token: 0x040000C0 RID: 192
		public InputActionEventType MNPTpowghPtMgXoSiAXWnWRZqooU;

		// Token: 0x040000C1 RID: 193
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> RFxKdFqrjfOBUBTMUbrMbjWEKAxT;
	}

	// Token: 0x0200002C RID: 44
	[CompilerGenerated]
	private sealed class pxYkoWmUHucauiArMxaQQiXRUrYn
	{
		// Token: 0x060001CE RID: 462 RVA: 0x00003945 File Offset: 0x00001B45
		internal bool EAjfuraNMBwXkDXwMwJBpBuAJWWu(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.fTffujbbzCywcSCevzQwFSgAmtFS && A_1.ZAgMPsuCWAERdJzqmUPgQhZKDjvYA == this.EprAjgBAlOXEHHRRdFrUFfZNRRkmA && A_1.qIAJdDCnAnCElrdseztlPhiieNqGA == this.SUoxFtgHeJPkuBKJRaiYBFzemozVA;
		}

		// Token: 0x040000C2 RID: 194
		public Action<InputActionEventData> fTffujbbzCywcSCevzQwFSgAmtFS;

		// Token: 0x040000C3 RID: 195
		public UpdateLoopType EprAjgBAlOXEHHRRdFrUFfZNRRkmA;

		// Token: 0x040000C4 RID: 196
		public int SUoxFtgHeJPkuBKJRaiYBFzemozVA;

		// Token: 0x040000C5 RID: 197
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> YzrFiOsWtVjtwaWYvGhJMHKlaYZr;
	}

	// Token: 0x0200002D RID: 45
	[CompilerGenerated]
	private sealed class cMFCyyQkiHcypetQaphkxUywtCXJ
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x0002DEA0 File Offset: 0x0002C0A0
		internal bool iHOcNNxCxYkrtEojBtaPWMNbPBol(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.aYVjfwICAOKGcPvOxCcansEnyqtg && A_1.ZAgMPsuCWAERdJzqmUPgQhZKDjvYA == this.dPZLIZKfdVIkIhqxoQRqcHuPfDicb && A_1.qIAJdDCnAnCElrdseztlPhiieNqGA == this.XjxWgaFFufvgAcrSBhoLzETUwczv && A_1.XaBVZtDDQxrMeYTmafKIzlpxaeNIA == this.kxAnWEFzPLOUhxOLEbDprNjERvSd;
		}

		// Token: 0x040000C6 RID: 198
		public Action<InputActionEventData> aYVjfwICAOKGcPvOxCcansEnyqtg;

		// Token: 0x040000C7 RID: 199
		public UpdateLoopType dPZLIZKfdVIkIhqxoQRqcHuPfDicb;

		// Token: 0x040000C8 RID: 200
		public int XjxWgaFFufvgAcrSBhoLzETUwczv;

		// Token: 0x040000C9 RID: 201
		public InputActionEventType kxAnWEFzPLOUhxOLEbDprNjERvSd;

		// Token: 0x040000CA RID: 202
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> SvovjehHekuAaNgbyrEZusdcIHu;
	}

	// Token: 0x0200002E RID: 46
	[CompilerGenerated]
	private sealed class XEhFTZALGhKlEdrgApjPtelxqbPE
	{
		// Token: 0x060001D2 RID: 466 RVA: 0x00003978 File Offset: 0x00001B78
		internal bool RXhsAbliONcagxQNNWrMGsosJpYt(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.eSHETbzFOwqBPWFXCigtSkvpdFQD && A_1.ZAgMPsuCWAERdJzqmUPgQhZKDjvYA == this.RfmWddLSqqksEakWwwInvyJrdMFy && A_1.XaBVZtDDQxrMeYTmafKIzlpxaeNIA == this.szffwvZNveGPbCfxndGfDQVYZVpqA;
		}

		// Token: 0x040000CB RID: 203
		public Action<InputActionEventData> eSHETbzFOwqBPWFXCigtSkvpdFQD;

		// Token: 0x040000CC RID: 204
		public UpdateLoopType RfmWddLSqqksEakWwwInvyJrdMFy;

		// Token: 0x040000CD RID: 205
		public InputActionEventType szffwvZNveGPbCfxndGfDQVYZVpqA;

		// Token: 0x040000CE RID: 206
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> viUeTgyNrFgiufEgyLzyZQIAhYGGb;
	}

	// Token: 0x0200002F RID: 47
	[CompilerGenerated]
	private sealed class uOmakZGOudnLqcZSKEvzllTOKesSA
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x000039AB File Offset: 0x00001BAB
		internal bool jZWfanmXelJmRQOmtfqZULLlDhbdA(EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA A_1)
		{
			return A_1.dXuyJzUXwNotxplGXahZukfwGmJGA == this.TCAfjggHZxmGyroPoMLwBSHtqqnD && A_1.qIAJdDCnAnCElrdseztlPhiieNqGA == this.hdXBGaLrmEPAarkMeaRmJLLgMlpiA && A_1.XaBVZtDDQxrMeYTmafKIzlpxaeNIA == this.yrcpkvVhpWLeWHGCCUUhasEpWgDK;
		}

		// Token: 0x040000CF RID: 207
		public Action<InputActionEventData> TCAfjggHZxmGyroPoMLwBSHtqqnD;

		// Token: 0x040000D0 RID: 208
		public int hdXBGaLrmEPAarkMeaRmJLLgMlpiA;

		// Token: 0x040000D1 RID: 209
		public InputActionEventType yrcpkvVhpWLeWHGCCUUhasEpWgDK;

		// Token: 0x040000D2 RID: 210
		public Predicate<EDsbfoobWXwcKBvvNHVrQUZhEIkn.dBPfqMTgQmBXOAuMmjBnwihtQOyIA> heqGrUYAReaiKtultBWUFlRLFRIiA;
	}
}
