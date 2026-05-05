using System;

namespace Unity.VisualScripting.Antlr3.Runtime
{
	// Token: 0x02000013 RID: 19
	public abstract class DFA
	{
		// Token: 0x060000FB RID: 251 RVA: 0x0000376C File Offset: 0x0000276C
		public int Predict(IIntStream input)
		{
			int marker = input.Mark();
			int num = 0;
			int result;
			try
			{
				char c;
				for (;;)
				{
					int num2 = (int)this.special[num];
					if (num2 >= 0)
					{
						num = this.specialStateTransitionHandler(this, num2, input);
						if (num == -1)
						{
							break;
						}
						input.Consume();
					}
					else
					{
						if (this.accept[num] >= 1)
						{
							goto Block_4;
						}
						c = (char)input.LA(1);
						if (c >= this.min[num] && c <= this.max[num])
						{
							int num3 = (int)this.transition[num][(int)(c - this.min[num])];
							if (num3 < 0)
							{
								if (this.eot[num] < 0)
								{
									goto IL_B3;
								}
								num = (int)this.eot[num];
								input.Consume();
							}
							else
							{
								num = num3;
								input.Consume();
							}
						}
						else
						{
							if (this.eot[num] < 0)
							{
								goto IL_ED;
							}
							num = (int)this.eot[num];
							input.Consume();
						}
					}
				}
				this.NoViableAlt(num, input);
				return 0;
				Block_4:
				return (int)this.accept[num];
				IL_B3:
				this.NoViableAlt(num, input);
				return 0;
				IL_ED:
				if (c == (char)Token.EOF && this.eof[num] >= 0)
				{
					result = (int)this.accept[(int)this.eof[num]];
				}
				else
				{
					this.NoViableAlt(num, input);
					result = 0;
				}
			}
			finally
			{
				input.Rewind(marker);
			}
			return result;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000038C0 File Offset: 0x000028C0
		protected void NoViableAlt(int s, IIntStream input)
		{
			if (this.recognizer.state.backtracking > 0)
			{
				this.recognizer.state.failed = true;
				return;
			}
			NoViableAltException ex = new NoViableAltException(this.Description, this.decisionNumber, s, input);
			this.Error(ex);
			throw ex;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000390E File Offset: 0x0000290E
		public virtual void Error(NoViableAltException nvae)
		{
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003910 File Offset: 0x00002910
		public virtual int SpecialStateTransition(int s, IIntStream input)
		{
			return -1;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00003913 File Offset: 0x00002913
		public virtual string Description
		{
			get
			{
				return "n/a";
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000391C File Offset: 0x0000291C
		public static short[] UnpackEncodedString(string encodedString)
		{
			int num = 0;
			for (int i = 0; i < encodedString.Length; i += 2)
			{
				num += (int)encodedString[i];
			}
			short[] array = new short[num];
			int num2 = 0;
			for (int j = 0; j < encodedString.Length; j += 2)
			{
				char c = encodedString[j];
				char c2 = encodedString[j + 1];
				for (int k = 1; k <= (int)c; k++)
				{
					array[num2++] = (short)c2;
				}
			}
			return array;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003998 File Offset: 0x00002998
		public static short[][] UnpackEncodedStringArray(string[] encodedStrings)
		{
			short[][] array = new short[encodedStrings.Length][];
			for (int i = 0; i < encodedStrings.Length; i++)
			{
				array[i] = DFA.UnpackEncodedString(encodedStrings[i]);
			}
			return array;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000039C8 File Offset: 0x000029C8
		public static char[] UnpackEncodedStringToUnsignedChars(string encodedString)
		{
			int num = 0;
			for (int i = 0; i < encodedString.Length; i += 2)
			{
				num += (int)encodedString[i];
			}
			char[] array = new char[num];
			int num2 = 0;
			for (int j = 0; j < encodedString.Length; j += 2)
			{
				char c = encodedString[j];
				char c2 = encodedString[j + 1];
				for (int k = 1; k <= (int)c; k++)
				{
					array[num2++] = c2;
				}
			}
			return array;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00003A41 File Offset: 0x00002A41
		public int SpecialTransition(int state, int symbol)
		{
			return 0;
		}

		// Token: 0x0400002D RID: 45
		public const bool debug = false;

		// Token: 0x0400002E RID: 46
		protected short[] eot;

		// Token: 0x0400002F RID: 47
		protected short[] eof;

		// Token: 0x04000030 RID: 48
		protected char[] min;

		// Token: 0x04000031 RID: 49
		protected char[] max;

		// Token: 0x04000032 RID: 50
		protected short[] accept;

		// Token: 0x04000033 RID: 51
		protected short[] special;

		// Token: 0x04000034 RID: 52
		protected short[][] transition;

		// Token: 0x04000035 RID: 53
		protected int decisionNumber;

		// Token: 0x04000036 RID: 54
		public DFA.SpecialStateTransitionHandler specialStateTransitionHandler;

		// Token: 0x04000037 RID: 55
		protected BaseRecognizer recognizer;

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x06000106 RID: 262
		public delegate int SpecialStateTransitionHandler(DFA dfa, int s, IIntStream input);
	}
}
