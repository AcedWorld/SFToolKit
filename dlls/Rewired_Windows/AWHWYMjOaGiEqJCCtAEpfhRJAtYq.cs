using System;
using System.Runtime.InteropServices;

// Token: 0x020002D6 RID: 726
internal struct AWHWYMjOaGiEqJCCtAEpfhRJAtYq
{
	// Token: 0x17000369 RID: 873
	// (get) Token: 0x0600158B RID: 5515 RVA: 0x0001C0F1 File Offset: 0x0001A2F1
	public bool zCXtTCoqlMWsPtbqEZbgprDSRCik
	{
		get
		{
			return this.EpciQBCWsdlebyjSNjLjybjnupm != IntPtr.Zero && this.AkirggzVjIvPyNwvBNvlIJFsbwnv > 0 && this.wecDRwdtVamuAIClsAVTsQSmECoTA > 0;
		}
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x0001C119 File Offset: 0x0001A319
	public AWHWYMjOaGiEqJCCtAEpfhRJAtYq(IntPtr A_1, int A_2, int A_3)
	{
		this.EpciQBCWsdlebyjSNjLjybjnupm = A_1;
		this.AkirggzVjIvPyNwvBNvlIJFsbwnv = A_2;
		this.wecDRwdtVamuAIClsAVTsQSmECoTA = A_3;
		this.VFcPLOdKGWJLUQiPVizWfUYDMaON = UJcTHgtazRRmIgoeHeVUoZaJEtEL.None;
	}

	// Token: 0x0600158D RID: 5517 RVA: 0x0001C137 File Offset: 0x0001A337
	public void yrIDNITJFRoATXTreIqGdpfDgAmZ()
	{
		this.EpciQBCWsdlebyjSNjLjybjnupm = IntPtr.Zero;
		this.AkirggzVjIvPyNwvBNvlIJFsbwnv = 0;
		this.wecDRwdtVamuAIClsAVTsQSmECoTA = 0;
		this.VFcPLOdKGWJLUQiPVizWfUYDMaON = UJcTHgtazRRmIgoeHeVUoZaJEtEL.None;
	}

	// Token: 0x0600158E RID: 5518 RVA: 0x0004BCEC File Offset: 0x00049EEC
	public string ALWBaIKfCKnMMiWGIbjDeBjFokzuA()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((this.EpciQBCWsdlebyjSNjLjybjnupm == IntPtr.Zero) ? "NULL" : ("Is Valid (" + this.EpciQBCWsdlebyjSNjLjybjnupm.ToString() + ")")) + "\n";
		text = text + "bufferLength = " + this.AkirggzVjIvPyNwvBNvlIJFsbwnv.ToString() + "\n";
		text = text + "reportLength = " + this.wecDRwdtVamuAIClsAVTsQSmECoTA.ToString() + "\n";
		string str = text;
		string str2 = "options = ";
		int vfcPLOdKGWJLUQiPVizWfUYDMaON = (int)this.VFcPLOdKGWJLUQiPVizWfUYDMaON;
		text = str + str2 + vfcPLOdKGWJLUQiPVizWfUYDMaON.ToString() + "\n";
		if (this.EpciQBCWsdlebyjSNjLjybjnupm != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < this.wecDRwdtVamuAIClsAVTsQSmECoTA; i++)
			{
				text += Marshal.ReadByte(this.EpciQBCWsdlebyjSNjLjybjnupm, i).ToString("X2");
				if (i < this.wecDRwdtVamuAIClsAVTsQSmECoTA - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}

	// Token: 0x04002F13 RID: 12051
	public IntPtr EpciQBCWsdlebyjSNjLjybjnupm;

	// Token: 0x04002F14 RID: 12052
	public int AkirggzVjIvPyNwvBNvlIJFsbwnv;

	// Token: 0x04002F15 RID: 12053
	public int wecDRwdtVamuAIClsAVTsQSmECoTA;

	// Token: 0x04002F16 RID: 12054
	public UJcTHgtazRRmIgoeHeVUoZaJEtEL VFcPLOdKGWJLUQiPVizWfUYDMaON;
}
