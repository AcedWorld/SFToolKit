using System;

namespace UnityEngine.Windows.Speech
{
	// Token: 0x020002D7 RID: 727
	public struct PhraseRecognizedEventArgs
	{
		// Token: 0x06001EBD RID: 7869 RVA: 0x00032886 File Offset: 0x00030A86
		internal PhraseRecognizedEventArgs(string text, ConfidenceLevel confidence, SemanticMeaning[] semanticMeanings, DateTime phraseStartTime, TimeSpan phraseDuration)
		{
			this.text = text;
			this.confidence = confidence;
			this.semanticMeanings = semanticMeanings;
			this.phraseStartTime = phraseStartTime;
			this.phraseDuration = phraseDuration;
		}

		// Token: 0x04000A1F RID: 2591
		public readonly ConfidenceLevel confidence;

		// Token: 0x04000A20 RID: 2592
		public readonly SemanticMeaning[] semanticMeanings;

		// Token: 0x04000A21 RID: 2593
		public readonly string text;

		// Token: 0x04000A22 RID: 2594
		public readonly DateTime phraseStartTime;

		// Token: 0x04000A23 RID: 2595
		public readonly TimeSpan phraseDuration;
	}
}
