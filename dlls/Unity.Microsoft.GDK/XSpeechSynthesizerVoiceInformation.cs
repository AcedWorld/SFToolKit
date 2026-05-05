using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200016D RID: 365
	[MovedFrom("Unity.GameCore")]
	public class XSpeechSynthesizerVoiceInformation
	{
		// Token: 0x060008B9 RID: 2233 RVA: 0x0000E001 File Offset: 0x0000C201
		internal XSpeechSynthesizerVoiceInformation(XSpeechSynthesizerVoiceInformation interop)
		{
			this.interop = interop;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0000E010 File Offset: 0x0000C210
		public XSpeechSynthesizerVoiceInformation()
		{
			this.interop = default(XSpeechSynthesizerVoiceInformation);
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x0000E024 File Offset: 0x0000C224
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x0000E031 File Offset: 0x0000C231
		public string Description
		{
			get
			{
				return this.interop.Description;
			}
			set
			{
				this.interop.Description = value;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x0000E03F File Offset: 0x0000C23F
		// (set) Token: 0x060008BE RID: 2238 RVA: 0x0000E04C File Offset: 0x0000C24C
		public string DisplayName
		{
			get
			{
				return this.interop.DisplayName;
			}
			set
			{
				this.interop.DisplayName = value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0000E05A File Offset: 0x0000C25A
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x0000E067 File Offset: 0x0000C267
		public XSpeechSynthesizerVoiceGender Gender
		{
			get
			{
				return this.interop.Gender;
			}
			set
			{
				this.interop.Gender = value;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0000E075 File Offset: 0x0000C275
		// (set) Token: 0x060008C2 RID: 2242 RVA: 0x0000E082 File Offset: 0x0000C282
		public string VoiceId
		{
			get
			{
				return this.interop.VoiceId;
			}
			set
			{
				this.interop.VoiceId = value;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060008C3 RID: 2243 RVA: 0x0000E090 File Offset: 0x0000C290
		// (set) Token: 0x060008C4 RID: 2244 RVA: 0x0000E09D File Offset: 0x0000C29D
		public string Language
		{
			get
			{
				return this.interop.Language;
			}
			set
			{
				this.interop.Language = value;
			}
		}

		// Token: 0x04000517 RID: 1303
		internal XSpeechSynthesizerVoiceInformation interop;
	}
}
