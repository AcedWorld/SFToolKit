using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils;

// Token: 0x020002D0 RID: 720
internal class AwnnodsOIsxGkOjbmSXwCAEEhdBEA
{
	// Token: 0x06001577 RID: 5495 RVA: 0x0004B6CC File Offset: 0x000498CC
	public void tcqVikrkQqmDYPXqqkaUwDdfoHrH()
	{
		byte[] value = this.AGMHMnUMVXAakjBruveYSCfmopYC.ToByteArray();
		Platform effectivePlatform = UnityTools.effectivePlatform;
		int startIndex;
		int startIndex2;
		if (effectivePlatform != Platform.Windows)
		{
			if (effectivePlatform != Platform.OSX)
			{
				if (effectivePlatform != Platform.Linux)
				{
					throw new NotImplementedException();
				}
				startIndex = 4;
				startIndex2 = 8;
			}
			else
			{
				startIndex = 0;
				startIndex2 = 8;
			}
		}
		else
		{
			startIndex = 0;
			startIndex2 = 2;
		}
		this.yKtebljiXenYkkxmvjrjPDZYpFOfA = (int)BitConverter.ToUInt16(value, startIndex);
		this.UcxBDNBvtiHJGlBCIqHnuNfonwVJA = (int)BitConverter.ToUInt16(value, startIndex2);
		this.EtsFbKxMDqhYjFCMHFupNqFFdULd = new PidVid((ushort)this.UcxBDNBvtiHJGlBCIqHnuNfonwVJA, (ushort)this.yKtebljiXenYkkxmvjrjPDZYpFOfA);
		this.xWMbPHAmbDkqbqdBAgVENxZcRbef = MiscTools.CreateGuidHashSHA1(this.GyJCCuXfBxtCNPuWqsuAJpiGEMzP + this.EtsFbKxMDqhYjFCMHFupNqFFdULd.ToString() + this.mMLUKOeESoEEDmUOAraXUCSKgkzK.ToString());
		if (string.IsNullOrEmpty(this.kVoAyAkzzbFunCHBxndeELGSfvgH))
		{
			this.kVoAyAkzzbFunCHBxndeELGSfvgH = this.GyJCCuXfBxtCNPuWqsuAJpiGEMzP;
		}
	}

	// Token: 0x06001578 RID: 5496 RVA: 0x0004B790 File Offset: 0x00049990
	public virtual string bjQURqBodkbvWLXGXpGvYgljYbYr()
	{
		string str = "" + "joystickIndex = " + this.nPIZASnxZsGZUTCeSjYFReezUUWu.ToString() + "\n" + "joystickId = " + this.mMLUKOeESoEEDmUOAraXUCSKgkzK.ToString() + "\n" + "isGameController = " + this.gJhuZAzXBNUtvvdRDfpOpWrcfexd.ToString() + "\n" + "hardwareName = " + this.GyJCCuXfBxtCNPuWqsuAJpiGEMzP + "\n" + "friendlyName = " + this.kVoAyAkzzbFunCHBxndeELGSfvgH + "\n";
		string str2 = "sdlJoystickGuid = ";
		Guid guid = this.AGMHMnUMVXAakjBruveYSCfmopYC;
		string str3 = str + str2 + guid.ToString() + "\n";
		string str4 = "sdlDeviceGuid = ";
		guid = this.DaGsNKYvYgLunHhdKoNVkqANcTIo;
		string str5 = str3 + str4 + guid.ToString() + "\n" + "buttonCount = " + this.SnkezaHKcWUgcPvYgaLIAwTFDbeTA.ToString() + "\n" + "axisCount = " + this.kWRnaPMqchyeUQUAhEyMQQBogOqA.ToString() + "\n" + "hatCount = " + this.QDNrcALgRxLhouPVMMqyxOiNYfr.ToString() + "\n" + "ballCount = " + this.aTDDxkffbnXcdBmOnWImviJYVQkVA.ToString() + "\n";
		string str6 = "pidVid = ";
		PidVid etsFbKxMDqhYjFCMHFupNqFFdULd = this.EtsFbKxMDqhYjFCMHFupNqFFdULd;
		string str7 = str5 + str6 + etsFbKxMDqhYjFCMHFupNqFFdULd.ToString() + "\n";
		string str8 = "instanceGuid = ";
		guid = this.xWMbPHAmbDkqbqdBAgVENxZcRbef;
		return str7 + str8 + guid.ToString() + "\n" + "vendorId = " + this.yKtebljiXenYkkxmvjrjPDZYpFOfA.ToString() + "\n" + "productId = " + this.UcxBDNBvtiHJGlBCIqHnuNfonwVJA.ToString() + "\n";
	}

	// Token: 0x04002EF1 RID: 12017
	public int nPIZASnxZsGZUTCeSjYFReezUUWu;

	// Token: 0x04002EF2 RID: 12018
	public int mMLUKOeESoEEDmUOAraXUCSKgkzK;

	// Token: 0x04002EF3 RID: 12019
	public bool gJhuZAzXBNUtvvdRDfpOpWrcfexd;

	// Token: 0x04002EF4 RID: 12020
	public string GyJCCuXfBxtCNPuWqsuAJpiGEMzP;

	// Token: 0x04002EF5 RID: 12021
	public string kVoAyAkzzbFunCHBxndeELGSfvgH;

	// Token: 0x04002EF6 RID: 12022
	public Guid AGMHMnUMVXAakjBruveYSCfmopYC;

	// Token: 0x04002EF7 RID: 12023
	public Guid DaGsNKYvYgLunHhdKoNVkqANcTIo;

	// Token: 0x04002EF8 RID: 12024
	public int SnkezaHKcWUgcPvYgaLIAwTFDbeTA;

	// Token: 0x04002EF9 RID: 12025
	public int kWRnaPMqchyeUQUAhEyMQQBogOqA;

	// Token: 0x04002EFA RID: 12026
	public int QDNrcALgRxLhouPVMMqyxOiNYfr;

	// Token: 0x04002EFB RID: 12027
	public int aTDDxkffbnXcdBmOnWImviJYVQkVA;

	// Token: 0x04002EFC RID: 12028
	public PidVid EtsFbKxMDqhYjFCMHFupNqFFdULd;

	// Token: 0x04002EFD RID: 12029
	public Guid xWMbPHAmbDkqbqdBAgVENxZcRbef;

	// Token: 0x04002EFE RID: 12030
	public int yKtebljiXenYkkxmvjrjPDZYpFOfA;

	// Token: 0x04002EFF RID: 12031
	public int UcxBDNBvtiHJGlBCIqHnuNfonwVJA;
}
