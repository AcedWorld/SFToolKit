using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

// Token: 0x02000018 RID: 24
internal class RXwELUeslTkclmlgxEgZCHffugOj
{
	// Token: 0x06000161 RID: 353 RVA: 0x0002C7EC File Offset: 0x0002A9EC
	public RXwELUeslTkclmlgxEgZCHffugOj(Type[] A_1, Type[] A_2)
	{
		if (A_1.Length != A_2.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		this.ioJgNRbvinuFHnGIHcHSJVwklLwV = A_1;
		this.lMxrqjiQQcrnPuchmgtcndGZNrEX = A_2;
		this.xyTrwZVsJWctZpTgaTeYzjCFGdup = this.ioJgNRbvinuFHnGIHcHSJVwklLwV.Length;
		this.OGQgjgFjqFEgEvCnyGWPikynEmKMA = new AList<RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA>();
		for (int i = 0; i < this.xyTrwZVsJWctZpTgaTeYzjCFGdup; i++)
		{
			this.OGQgjgFjqFEgEvCnyGWPikynEmKMA.Add(new RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA(this.lMxrqjiQQcrnPuchmgtcndGZNrEX[i]));
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0002C864 File Offset: 0x0002AA64
	public void zasBhsaAvoJpxZfKGoCjaYtFpigYB(Controller A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		int templateCount = A_1.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = A_1.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
			}
			else
			{
				Type type = this.yTuDUPDgfjDNKwRcCDdzkRuXqUpgA(controllerTemplate.GetType());
				if (type == null)
				{
					Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
				}
				else
				{
					RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA jaRCFdjswCMqwKtfdIjuTdGGOUcpA = this.VUvEredJrFdfxsusufQOBliEMfLKB(type);
					if (jaRCFdjswCMqwKtfdIjuTdGGOUcpA != null)
					{
						jaRCFdjswCMqwKtfdIjuTdGGOUcpA.vEVdqIGoHHOWsswpEkgGcdiIhRqu(controllerTemplate);
					}
				}
			}
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x0002C8F0 File Offset: 0x0002AAF0
	public void QvDjjGLIVKsQuJmOzAqldvnCtsBH(Controller A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		int templateCount = A_1.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = A_1.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
			}
			else
			{
				Type type = this.yTuDUPDgfjDNKwRcCDdzkRuXqUpgA(controllerTemplate.GetType());
				if (type == null)
				{
					Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
				}
				else
				{
					RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA jaRCFdjswCMqwKtfdIjuTdGGOUcpA = this.VUvEredJrFdfxsusufQOBliEMfLKB(type);
					if (jaRCFdjswCMqwKtfdIjuTdGGOUcpA != null)
					{
						jaRCFdjswCMqwKtfdIjuTdGGOUcpA.FoVOwfGHLeFUlVHjZiKcDtBxZTuPA(controllerTemplate);
					}
				}
			}
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0002C97C File Offset: 0x0002AB7C
	public IList<\u0001> FfJfewQUzyHPsLUFqdkzTuUdQThm<\u0001>() where \u0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(\u0001);
		for (int i = 0; i < this.OGQgjgFjqFEgEvCnyGWPikynEmKMA._count; i++)
		{
			RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA jaRCFdjswCMqwKtfdIjuTdGGOUcpA = this.OGQgjgFjqFEgEvCnyGWPikynEmKMA._items[i];
			if (jaRCFdjswCMqwKtfdIjuTdGGOUcpA.KJnxGYgWWqKpKdUkpZyOkMHjwpCH == typeFromHandle)
			{
				return jaRCFdjswCMqwKtfdIjuTdGGOUcpA.LuevnzMGLCBOVtsFwHvfjwdlmJHJ<\u0001>();
			}
		}
		string text = "";
		for (int j = 0; j < this.lMxrqjiQQcrnPuchmgtcndGZNrEX.Length; j++)
		{
			text += this.lMxrqjiQQcrnPuchmgtcndGZNrEX[j].Name;
			if (j != this.lMxrqjiQQcrnPuchmgtcndGZNrEX.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<\u0001>.EmptyReadOnlyIListT;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0002CA34 File Offset: 0x0002AC34
	private RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA VUvEredJrFdfxsusufQOBliEMfLKB(Type A_1)
	{
		for (int i = 0; i < this.OGQgjgFjqFEgEvCnyGWPikynEmKMA._count; i++)
		{
			if (A_1 == this.OGQgjgFjqFEgEvCnyGWPikynEmKMA._items[i].KJnxGYgWWqKpKdUkpZyOkMHjwpCH)
			{
				return this.OGQgjgFjqFEgEvCnyGWPikynEmKMA._items[i];
			}
		}
		return null;
	}

	// Token: 0x06000166 RID: 358 RVA: 0x0002CA7C File Offset: 0x0002AC7C
	private Type yTuDUPDgfjDNKwRcCDdzkRuXqUpgA(Type A_1)
	{
		for (int i = 0; i < this.xyTrwZVsJWctZpTgaTeYzjCFGdup; i++)
		{
			if (this.ioJgNRbvinuFHnGIHcHSJVwklLwV[i] == A_1)
			{
				return this.lMxrqjiQQcrnPuchmgtcndGZNrEX[i];
			}
		}
		return null;
	}

	// Token: 0x0400008A RID: 138
	private readonly AList<RXwELUeslTkclmlgxEgZCHffugOj.JaRCFdjswCMqwKtfdIjuTdGGOUcpA> OGQgjgFjqFEgEvCnyGWPikynEmKMA;

	// Token: 0x0400008B RID: 139
	private readonly Type[] ioJgNRbvinuFHnGIHcHSJVwklLwV;

	// Token: 0x0400008C RID: 140
	private readonly Type[] lMxrqjiQQcrnPuchmgtcndGZNrEX;

	// Token: 0x0400008D RID: 141
	private readonly int xyTrwZVsJWctZpTgaTeYzjCFGdup;

	// Token: 0x02000019 RID: 25
	private class JaRCFdjswCMqwKtfdIjuTdGGOUcpA
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00003533 File Offset: 0x00001733
		public JaRCFdjswCMqwKtfdIjuTdGGOUcpA(Type A_1)
		{
			this.KJnxGYgWWqKpKdUkpZyOkMHjwpCH = A_1;
			this.sRcQEVOmspzRyuaWFLDifaJNLcJD = new AList<IControllerTemplate>();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000354D File Offset: 0x0000174D
		public IList<\u0001> LuevnzMGLCBOVtsFwHvfjwdlmJHJ<\u0001>() where \u0001 : IControllerTemplate
		{
			if (this.yZctFsIvzyFZncTAUUoSflTqNNuu == null)
			{
				this.mxYpbTYrJdtgaqYHWlnbLBNSvRfm<\u0001>();
			}
			return this.wcSWDcflDtPZSwktFlhSQFMvelmQ as IList<\u0001>;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00003568 File Offset: 0x00001768
		public void vEVdqIGoHHOWsswpEkgGcdiIhRqu(IControllerTemplate A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.sRcQEVOmspzRyuaWFLDifaJNLcJD.Add(A_1);
			if (this.yZctFsIvzyFZncTAUUoSflTqNNuu != null)
			{
				this.yZctFsIvzyFZncTAUUoSflTqNNuu.Add(A_1);
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00003590 File Offset: 0x00001790
		public void FoVOwfGHLeFUlVHjZiKcDtBxZTuPA(IControllerTemplate A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.sRcQEVOmspzRyuaWFLDifaJNLcJD.Remove(A_1);
			if (this.yZctFsIvzyFZncTAUUoSflTqNNuu != null)
			{
				this.yZctFsIvzyFZncTAUUoSflTqNNuu.Remove(A_1);
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0002CAB0 File Offset: 0x0002ACB0
		private void mxYpbTYrJdtgaqYHWlnbLBNSvRfm<\u0001>() where \u0001 : IControllerTemplate
		{
			this.yZctFsIvzyFZncTAUUoSflTqNNuu = new AList<\u0001>();
			this.wcSWDcflDtPZSwktFlhSQFMvelmQ = new ReadOnlyCollection<\u0001>((AList<\u0001>)this.yZctFsIvzyFZncTAUUoSflTqNNuu);
			for (int i = 0; i < this.sRcQEVOmspzRyuaWFLDifaJNLcJD._count; i++)
			{
				this.yZctFsIvzyFZncTAUUoSflTqNNuu.Add(this.sRcQEVOmspzRyuaWFLDifaJNLcJD._items[i]);
			}
		}

		// Token: 0x0400008E RID: 142
		private readonly AList<IControllerTemplate> sRcQEVOmspzRyuaWFLDifaJNLcJD;

		// Token: 0x0400008F RID: 143
		private IList yZctFsIvzyFZncTAUUoSflTqNNuu;

		// Token: 0x04000090 RID: 144
		private IList wcSWDcflDtPZSwktFlhSQFMvelmQ;

		// Token: 0x04000091 RID: 145
		public readonly Type KJnxGYgWWqKpKdUkpZyOkMHjwpCH;
	}
}
