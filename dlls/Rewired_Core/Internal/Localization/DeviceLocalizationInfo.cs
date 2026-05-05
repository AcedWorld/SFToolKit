using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.Internal.Localization
{
	// Token: 0x0200043A RID: 1082
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class DeviceLocalizationInfo
	{
		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x06002B83 RID: 11139 RVA: 0x00021626 File Offset: 0x0001F826
		public ReadOnlyList<string> parentKeys
		{
			get
			{
				return this.aKcFIocybrPPpFIYVEuSYFhEcvQUA;
			}
		}

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06002B84 RID: 11140 RVA: 0x0002162E File Offset: 0x0001F82E
		public ReadOnlyList<Guid> controllerTemplateGuids
		{
			get
			{
				return this.ckMDrEgyPRLTnQxSjVENwSvmdwfW;
			}
		}

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06002B85 RID: 11141 RVA: 0x00021636 File Offset: 0x0001F836
		// (set) Token: 0x06002B86 RID: 11142 RVA: 0x0002163E File Offset: 0x0001F83E
		public string additionalIdentifyingInformation
		{
			get
			{
				return this.qhyVvwpVORGVKaJExeHUcKOBAcWi;
			}
			set
			{
				this.oLLzmoRnTornyJkobMsWexytOpvc();
				this.qhyVvwpVORGVKaJExeHUcKOBAcWi = value;
			}
		}

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06002B87 RID: 11143 RVA: 0x0002164D File Offset: 0x0001F84D
		public Bytes20 hash
		{
			get
			{
				return this.zdILDonBAfMDfwgUSGaYxivcHKEV;
			}
		}

		// Token: 0x06002B88 RID: 11144 RVA: 0x00021655 File Offset: 0x0001F855
		public DeviceLocalizationInfo()
		{
			this.IaooZioOZYgnCCxXMGIkrKLGRdyg = new List<string>();
			this.aKcFIocybrPPpFIYVEuSYFhEcvQUA = new ReadOnlyList<string>(this.IaooZioOZYgnCCxXMGIkrKLGRdyg);
		}

		// Token: 0x06002B89 RID: 11145 RVA: 0x0009C944 File Offset: 0x0009AB44
		public DeviceLocalizationInfo(ControllerType A_1, bool A_2, Guid A_3, IList<string> A_4, IList<Guid> A_5)
		{
			this.controllerType = A_1;
			this.isControllerTemplate = A_2;
			this.guid = A_3;
			IList<string> iaooZioOZYgnCCxXMGIkrKLGRdyg;
			if (A_4 == null)
			{
				IList<string> list = new List<string>();
				iaooZioOZYgnCCxXMGIkrKLGRdyg = list;
			}
			else
			{
				iaooZioOZYgnCCxXMGIkrKLGRdyg = A_4;
			}
			this.IaooZioOZYgnCCxXMGIkrKLGRdyg = iaooZioOZYgnCCxXMGIkrKLGRdyg;
			this.aKcFIocybrPPpFIYVEuSYFhEcvQUA = new ReadOnlyList<string>(this.IaooZioOZYgnCCxXMGIkrKLGRdyg);
			if (A_5 != null)
			{
				this.ckMDrEgyPRLTnQxSjVENwSvmdwfW = new ReadOnlyList<Guid>(A_5);
			}
		}

		// Token: 0x06002B8A RID: 11146 RVA: 0x0009C9A4 File Offset: 0x0009ABA4
		public DeviceLocalizationInfo(DeviceLocalizationInfo A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this.guid = A_1.guid;
			this.controllerType = A_1.controllerType;
			this.isControllerTemplate = A_1.isControllerTemplate;
			this.IaooZioOZYgnCCxXMGIkrKLGRdyg = ((A_1.IaooZioOZYgnCCxXMGIkrKLGRdyg != null) ? new List<string>(A_1.IaooZioOZYgnCCxXMGIkrKLGRdyg) : new List<string>());
			this.aKcFIocybrPPpFIYVEuSYFhEcvQUA = new ReadOnlyList<string>(this.IaooZioOZYgnCCxXMGIkrKLGRdyg);
			if (A_1.controllerTemplateGuids != null)
			{
				this.ckMDrEgyPRLTnQxSjVENwSvmdwfW = new ReadOnlyList<Guid>(A_1.controllerTemplateGuids);
			}
			this.qtZlWcQtAjrnYjhsYQUFvQKjtCLs = A_1.qtZlWcQtAjrnYjhsYQUFvQKjtCLs;
		}

		// Token: 0x06002B8B RID: 11147 RVA: 0x00021679 File Offset: 0x0001F879
		public void InsertParentKey(int index, string key)
		{
			this.oLLzmoRnTornyJkobMsWexytOpvc();
			if (string.IsNullOrEmpty(key))
			{
				return;
			}
			this.IaooZioOZYgnCCxXMGIkrKLGRdyg.Insert(index, key);
		}

		// Token: 0x06002B8C RID: 11148 RVA: 0x00021697 File Offset: 0x0001F897
		public void FinishRuntimeSetup()
		{
			this.ComputeHash();
			this.sYYyymHnoEQiWpBUuKGNGuEUEHsJ();
		}

		// Token: 0x06002B8D RID: 11149 RVA: 0x0009CA40 File Offset: 0x0009AC40
		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(this.controllerType.ToString());
			sharedStringBuilder.Append(this.isControllerTemplate.ToString());
			sharedStringBuilder.Append(this.guid.ToString());
			int count = this.IaooZioOZYgnCCxXMGIkrKLGRdyg.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(this.IaooZioOZYgnCCxXMGIkrKLGRdyg[i]))
				{
					sharedStringBuilder.Append(this.IaooZioOZYgnCCxXMGIkrKLGRdyg[i]);
				}
			}
			sharedStringBuilder.Append(this.qhyVvwpVORGVKaJExeHUcKOBAcWi);
			this.zdILDonBAfMDfwgUSGaYxivcHKEV = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return this.zdILDonBAfMDfwgUSGaYxivcHKEV;
		}

		// Token: 0x06002B8E RID: 11150 RVA: 0x000216A6 File Offset: 0x0001F8A6
		private void sYYyymHnoEQiWpBUuKGNGuEUEHsJ()
		{
			this.qtZlWcQtAjrnYjhsYQUFvQKjtCLs = true;
		}

		// Token: 0x06002B8F RID: 11151 RVA: 0x000216AF File Offset: 0x0001F8AF
		private void oLLzmoRnTornyJkobMsWexytOpvc()
		{
			if (this.qtZlWcQtAjrnYjhsYQUFvQKjtCLs)
			{
				throw new Exception("Cannot modify a read-only object.");
			}
		}

		// Token: 0x06002B90 RID: 11152 RVA: 0x0009CB08 File Offset: 0x0009AD08
		public static bool DataMatches(DeviceLocalizationInfo a, DeviceLocalizationInfo b)
		{
			if (a == null || b == null)
			{
				return false;
			}
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.IaooZioOZYgnCCxXMGIkrKLGRdyg.Count != b.IaooZioOZYgnCCxXMGIkrKLGRdyg.Count)
			{
				return false;
			}
			int count = a.IaooZioOZYgnCCxXMGIkrKLGRdyg.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.IaooZioOZYgnCCxXMGIkrKLGRdyg[i], b.IaooZioOZYgnCCxXMGIkrKLGRdyg[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = (a.ckMDrEgyPRLTnQxSjVENwSvmdwfW != null) ? a.ckMDrEgyPRLTnQxSjVENwSvmdwfW.Count : 0;
			int num2 = (b.ckMDrEgyPRLTnQxSjVENwSvmdwfW != null) ? b.ckMDrEgyPRLTnQxSjVENwSvmdwfW.Count : 0;
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.ckMDrEgyPRLTnQxSjVENwSvmdwfW[j] != b.ckMDrEgyPRLTnQxSjVENwSvmdwfW[j])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040018BE RID: 6334
		public readonly Guid guid;

		// Token: 0x040018BF RID: 6335
		public readonly ControllerType controllerType;

		// Token: 0x040018C0 RID: 6336
		public readonly bool isControllerTemplate;

		// Token: 0x040018C1 RID: 6337
		private readonly ReadOnlyList<string> aKcFIocybrPPpFIYVEuSYFhEcvQUA;

		// Token: 0x040018C2 RID: 6338
		private readonly IList<string> IaooZioOZYgnCCxXMGIkrKLGRdyg;

		// Token: 0x040018C3 RID: 6339
		private readonly ReadOnlyList<Guid> ckMDrEgyPRLTnQxSjVENwSvmdwfW;

		// Token: 0x040018C4 RID: 6340
		private string qhyVvwpVORGVKaJExeHUcKOBAcWi;

		// Token: 0x040018C5 RID: 6341
		private Bytes20 zdILDonBAfMDfwgUSGaYxivcHKEV;

		// Token: 0x040018C6 RID: 6342
		private bool qtZlWcQtAjrnYjhsYQUFvQKjtCLs;
	}
}
