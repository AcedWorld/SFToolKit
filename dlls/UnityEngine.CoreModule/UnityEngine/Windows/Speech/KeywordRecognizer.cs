using System;
using System.Collections.Generic;

namespace UnityEngine.Windows.Speech
{
	// Token: 0x020002D8 RID: 728
	public sealed class KeywordRecognizer : PhraseRecognizer
	{
		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06001EBE RID: 7870 RVA: 0x000328AE File Offset: 0x00030AAE
		// (set) Token: 0x06001EBF RID: 7871 RVA: 0x000328B6 File Offset: 0x00030AB6
		public IEnumerable<string> Keywords { get; private set; }

		// Token: 0x06001EC0 RID: 7872 RVA: 0x000328BF File Offset: 0x00030ABF
		public KeywordRecognizer(string[] keywords) : this(keywords, ConfidenceLevel.Medium)
		{
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x000328CC File Offset: 0x00030ACC
		public KeywordRecognizer(string[] keywords, ConfidenceLevel minimumConfidence)
		{
			bool flag = keywords == null;
			if (flag)
			{
				throw new ArgumentNullException("keywords");
			}
			bool flag2 = keywords.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("At least one keyword must be specified.", "keywords");
			}
			int num = keywords.Length;
			for (int i = 0; i < num; i++)
			{
				bool flag3 = keywords[i] == null;
				if (flag3)
				{
					throw new ArgumentNullException(string.Format("Keyword at index {0} is null.", i));
				}
			}
			this.Keywords = keywords;
			this.m_Recognizer = PhraseRecognizer.CreateFromKeywords(this, keywords, minimumConfidence);
		}
	}
}
