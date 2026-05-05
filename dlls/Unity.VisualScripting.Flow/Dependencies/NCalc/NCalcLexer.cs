using System;
using Unity.VisualScripting.Antlr3.Runtime;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000190 RID: 400
	public class NCalcLexer : Lexer
	{
		// Token: 0x06000AE0 RID: 2784 RVA: 0x000149BF File Offset: 0x00012BBF
		public NCalcLexer()
		{
			this.InitializeCyclicDFAs();
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x000149CD File Offset: 0x00012BCD
		public NCalcLexer(ICharStream input) : this(input, null)
		{
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x000149D7 File Offset: 0x00012BD7
		public NCalcLexer(ICharStream input, RecognizerSharedState state) : base(input, state)
		{
			this.InitializeCyclicDFAs();
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x000149E7 File Offset: 0x00012BE7
		public override string GrammarFileName
		{
			get
			{
				return "C:\\Users\\s.ros\\Documents\\D�veloppement\\NCalc\\Grammar\\NCalc.g";
			}
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x000149EE File Offset: 0x00012BEE
		private void InitializeCyclicDFAs()
		{
			this.dfa7 = new NCalcLexer.DFA7(this);
			this.dfa14 = new NCalcLexer.DFA14(this);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00014A08 File Offset: 0x00012C08
		public void mT__19()
		{
			int type = 19;
			int channel = 0;
			this.Match(63);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00014A3C File Offset: 0x00012C3C
		public void mT__20()
		{
			int type = 20;
			int channel = 0;
			this.Match(58);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00014A70 File Offset: 0x00012C70
		public void mT__21()
		{
			int type = 21;
			int channel = 0;
			this.Match("||");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00014AA8 File Offset: 0x00012CA8
		public void mT__22()
		{
			int type = 22;
			int channel = 0;
			this.Match("or");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x00014AE0 File Offset: 0x00012CE0
		public void mT__23()
		{
			int type = 23;
			int channel = 0;
			this.Match("&&");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00014B18 File Offset: 0x00012D18
		public void mT__24()
		{
			int type = 24;
			int channel = 0;
			this.Match("and");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00014B50 File Offset: 0x00012D50
		public void mT__25()
		{
			int type = 25;
			int channel = 0;
			this.Match(124);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x00014B84 File Offset: 0x00012D84
		public void mT__26()
		{
			int type = 26;
			int channel = 0;
			this.Match(94);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00014BB8 File Offset: 0x00012DB8
		public void mT__27()
		{
			int type = 27;
			int channel = 0;
			this.Match(38);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00014BEC File Offset: 0x00012DEC
		public void mT__28()
		{
			int type = 28;
			int channel = 0;
			this.Match("==");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00014C24 File Offset: 0x00012E24
		public void mT__29()
		{
			int type = 29;
			int channel = 0;
			this.Match(61);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00014C58 File Offset: 0x00012E58
		public void mT__30()
		{
			int type = 30;
			int channel = 0;
			this.Match("!=");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00014C90 File Offset: 0x00012E90
		public void mT__31()
		{
			int type = 31;
			int channel = 0;
			this.Match("<>");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00014CC8 File Offset: 0x00012EC8
		public void mT__32()
		{
			int type = 32;
			int channel = 0;
			this.Match(60);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x00014CFC File Offset: 0x00012EFC
		public void mT__33()
		{
			int type = 33;
			int channel = 0;
			this.Match("<=");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00014D34 File Offset: 0x00012F34
		public void mT__34()
		{
			int type = 34;
			int channel = 0;
			this.Match(62);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x00014D68 File Offset: 0x00012F68
		public void mT__35()
		{
			int type = 35;
			int channel = 0;
			this.Match(">=");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x00014DA0 File Offset: 0x00012FA0
		public void mT__36()
		{
			int type = 36;
			int channel = 0;
			this.Match("<<");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x00014DD8 File Offset: 0x00012FD8
		public void mT__37()
		{
			int type = 37;
			int channel = 0;
			this.Match(">>");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00014E10 File Offset: 0x00013010
		public void mT__38()
		{
			int type = 38;
			int channel = 0;
			this.Match(43);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00014E44 File Offset: 0x00013044
		public void mT__39()
		{
			int type = 39;
			int channel = 0;
			this.Match(45);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x00014E78 File Offset: 0x00013078
		public void mT__40()
		{
			int type = 40;
			int channel = 0;
			this.Match(42);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00014EAC File Offset: 0x000130AC
		public void mT__41()
		{
			int type = 41;
			int channel = 0;
			this.Match(47);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00014EE0 File Offset: 0x000130E0
		public void mT__42()
		{
			int type = 42;
			int channel = 0;
			this.Match(37);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00014F14 File Offset: 0x00013114
		public void mT__43()
		{
			int type = 43;
			int channel = 0;
			this.Match(33);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00014F48 File Offset: 0x00013148
		public void mT__44()
		{
			int type = 44;
			int channel = 0;
			this.Match("not");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00014F80 File Offset: 0x00013180
		public void mT__45()
		{
			int type = 45;
			int channel = 0;
			this.Match(126);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00014FB4 File Offset: 0x000131B4
		public void mT__46()
		{
			int type = 46;
			int channel = 0;
			this.Match(40);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00014FE8 File Offset: 0x000131E8
		public void mT__47()
		{
			int type = 47;
			int channel = 0;
			this.Match(41);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0001501C File Offset: 0x0001321C
		public void mT__48()
		{
			int type = 48;
			int channel = 0;
			this.Match(44);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00015050 File Offset: 0x00013250
		public void mTRUE()
		{
			int type = 8;
			int channel = 0;
			this.Match("true");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00015084 File Offset: 0x00013284
		public void mFALSE()
		{
			int type = 9;
			int channel = 0;
			this.Match("false");
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x000150BC File Offset: 0x000132BC
		public void mID()
		{
			int type = 10;
			int channel = 0;
			this.mLETTER();
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if ((num2 >= 48 && num2 <= 57) || (num2 >= 65 && num2 <= 90) || num2 == 95 || (num2 >= 97 && num2 <= 122))
				{
					num = 1;
				}
				if (num != 1)
				{
					goto IL_DF;
				}
				if ((this.input.LA(1) < 48 || this.input.LA(1) > 57) && (this.input.LA(1) < 65 || this.input.LA(1) > 90) && this.input.LA(1) != 95 && (this.input.LA(1) < 97 || this.input.LA(1) > 122))
				{
					break;
				}
				this.input.Consume();
			}
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
			IL_DF:
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x000151C0 File Offset: 0x000133C0
		public void mINTEGER()
		{
			int type = 4;
			int channel = 0;
			int num = 0;
			for (;;)
			{
				int num2 = 2;
				int num3 = this.input.LA(1);
				if (num3 >= 48 && num3 <= 57)
				{
					num2 = 1;
				}
				if (num2 != 1)
				{
					break;
				}
				this.mDIGIT();
				num++;
			}
			if (num < 1)
			{
				throw new EarlyExitException(2, this.input);
			}
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0001522C File Offset: 0x0001342C
		public void mFLOAT()
		{
			int type = 5;
			int channel = 0;
			int num = this.dfa7.Predict(this.input);
			if (num != 1)
			{
				if (num == 2)
				{
					int num2 = 0;
					for (;;)
					{
						int num3 = 2;
						int num4 = this.input.LA(1);
						if (num4 >= 48 && num4 <= 57)
						{
							num3 = 1;
						}
						if (num3 != 1)
						{
							break;
						}
						this.mDIGIT();
						num2++;
					}
					if (num2 < 1)
					{
						throw new EarlyExitException(6, this.input);
					}
					this.mE();
				}
			}
			else
			{
				for (;;)
				{
					int num5 = 2;
					int num6 = this.input.LA(1);
					if (num6 >= 48 && num6 <= 57)
					{
						num5 = 1;
					}
					if (num5 != 1)
					{
						break;
					}
					this.mDIGIT();
				}
				this.Match(46);
				int num7 = 0;
				for (;;)
				{
					int num8 = 2;
					int num9 = this.input.LA(1);
					if (num9 >= 48 && num9 <= 57)
					{
						num8 = 1;
					}
					if (num8 != 1)
					{
						break;
					}
					this.mDIGIT();
					num7++;
				}
				if (num7 < 1)
				{
					throw new EarlyExitException(4, this.input);
				}
				int num10 = 2;
				int num11 = this.input.LA(1);
				if (num11 == 69 || num11 == 101)
				{
					num10 = 1;
				}
				if (num10 == 1)
				{
					this.mE();
				}
			}
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00015374 File Offset: 0x00013574
		public void mSTRING()
		{
			int type = 6;
			int channel = 0;
			this.Match(39);
			for (;;)
			{
				int num = 3;
				int num2 = this.input.LA(1);
				if (num2 == 92)
				{
					num = 1;
				}
				else if ((num2 >= 32 && num2 <= 38) || (num2 >= 40 && num2 <= 91) || (num2 >= 93 && num2 <= 65535))
				{
					num = 2;
				}
				if (num != 1)
				{
					if (num != 2)
					{
						break;
					}
					if ((this.input.LA(1) < 32 || this.input.LA(1) > 38) && (this.input.LA(1) < 40 || this.input.LA(1) > 91) && (this.input.LA(1) < 93 || this.input.LA(1) > 65535))
					{
						goto IL_CF;
					}
					this.input.Consume();
				}
				else
				{
					this.mEscapeSequence();
				}
			}
			this.Match(39);
			this.state.type = type;
			this.state.channel = channel;
			return;
			IL_CF:
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0001548C File Offset: 0x0001368C
		public void mDATETIME()
		{
			int type = 7;
			int channel = 0;
			this.Match(35);
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if ((num2 >= 0 && num2 <= 34) || (num2 >= 36 && num2 <= 65535))
				{
					num = 1;
				}
				if (num != 1)
				{
					goto IL_9F;
				}
				if ((this.input.LA(1) < 0 || this.input.LA(1) > 34) && (this.input.LA(1) < 36 || this.input.LA(1) > 65535))
				{
					break;
				}
				this.input.Consume();
			}
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
			IL_9F:
			this.Match(35);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00015558 File Offset: 0x00013758
		public void mNAME()
		{
			int type = 11;
			int channel = 0;
			this.Match(91);
			for (;;)
			{
				int num = 2;
				int num2 = this.input.LA(1);
				if ((num2 >= 0 && num2 <= 92) || (num2 >= 94 && num2 <= 65535))
				{
					num = 1;
				}
				if (num != 1)
				{
					goto IL_A0;
				}
				if ((this.input.LA(1) < 0 || this.input.LA(1) > 92) && (this.input.LA(1) < 94 || this.input.LA(1) > 65535))
				{
					break;
				}
				this.input.Consume();
			}
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
			IL_A0:
			this.Match(93);
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00015628 File Offset: 0x00013828
		public void mE()
		{
			int type = 14;
			int channel = 0;
			if (this.input.LA(1) != 69 && this.input.LA(1) != 101)
			{
				MismatchedSetException ex = new MismatchedSetException(null, this.input);
				this.Recover(ex);
				throw ex;
			}
			this.input.Consume();
			int num = 2;
			int num2 = this.input.LA(1);
			if (num2 == 43 || num2 == 45)
			{
				num = 1;
			}
			if (num == 1)
			{
				if (this.input.LA(1) != 43 && this.input.LA(1) != 45)
				{
					MismatchedSetException ex2 = new MismatchedSetException(null, this.input);
					this.Recover(ex2);
					throw ex2;
				}
				this.input.Consume();
			}
			int num3 = 0;
			for (;;)
			{
				int num4 = 2;
				int num5 = this.input.LA(1);
				if (num5 >= 48 && num5 <= 57)
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					break;
				}
				this.mDIGIT();
				num3++;
			}
			if (num3 < 1)
			{
				throw new EarlyExitException(12, this.input);
			}
			this.state.type = type;
			this.state.channel = channel;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00015748 File Offset: 0x00013948
		public void mLETTER()
		{
			if ((this.input.LA(1) >= 65 && this.input.LA(1) <= 90) || this.input.LA(1) == 95 || (this.input.LA(1) >= 97 && this.input.LA(1) <= 122))
			{
				this.input.Consume();
				return;
			}
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x000157C6 File Offset: 0x000139C6
		public void mDIGIT()
		{
			this.MatchRange(48, 57);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x000157D4 File Offset: 0x000139D4
		public void mEscapeSequence()
		{
			this.Match(92);
			int num = this.input.LA(1);
			int num2;
			if (num <= 92)
			{
				if (num == 39)
				{
					num2 = 4;
					goto IL_74;
				}
				if (num == 92)
				{
					num2 = 5;
					goto IL_74;
				}
			}
			else
			{
				if (num == 110)
				{
					num2 = 1;
					goto IL_74;
				}
				switch (num)
				{
				case 114:
					num2 = 2;
					goto IL_74;
				case 116:
					num2 = 3;
					goto IL_74;
				case 117:
					num2 = 6;
					goto IL_74;
				}
			}
			throw new NoViableAltException("", 13, 0, this.input);
			IL_74:
			switch (num2)
			{
			case 1:
				this.Match(110);
				return;
			case 2:
				this.Match(114);
				return;
			case 3:
				this.Match(116);
				return;
			case 4:
				this.Match(39);
				return;
			case 5:
				this.Match(92);
				return;
			case 6:
				this.mUnicodeEscape();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x000158AC File Offset: 0x00013AAC
		public void mHexDigit()
		{
			if ((this.input.LA(1) >= 48 && this.input.LA(1) <= 57) || (this.input.LA(1) >= 65 && this.input.LA(1) <= 70) || (this.input.LA(1) >= 97 && this.input.LA(1) <= 102))
			{
				this.input.Consume();
				return;
			}
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0001593A File Offset: 0x00013B3A
		public void mUnicodeEscape()
		{
			this.Match(117);
			this.mHexDigit();
			this.mHexDigit();
			this.mHexDigit();
			this.mHexDigit();
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0001595C File Offset: 0x00013B5C
		public void mWS()
		{
			int type = 18;
			if ((this.input.LA(1) >= 9 && this.input.LA(1) <= 10) || (this.input.LA(1) >= 12 && this.input.LA(1) <= 13) || this.input.LA(1) == 32)
			{
				this.input.Consume();
				int channel = 99;
				this.state.type = type;
				this.state.channel = channel;
				return;
			}
			MismatchedSetException ex = new MismatchedSetException(null, this.input);
			this.Recover(ex);
			throw ex;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x000159FC File Offset: 0x00013BFC
		public override void mTokens()
		{
			switch (this.dfa14.Predict(this.input))
			{
			case 1:
				this.mT__19();
				return;
			case 2:
				this.mT__20();
				return;
			case 3:
				this.mT__21();
				return;
			case 4:
				this.mT__22();
				return;
			case 5:
				this.mT__23();
				return;
			case 6:
				this.mT__24();
				return;
			case 7:
				this.mT__25();
				return;
			case 8:
				this.mT__26();
				return;
			case 9:
				this.mT__27();
				return;
			case 10:
				this.mT__28();
				return;
			case 11:
				this.mT__29();
				return;
			case 12:
				this.mT__30();
				return;
			case 13:
				this.mT__31();
				return;
			case 14:
				this.mT__32();
				return;
			case 15:
				this.mT__33();
				return;
			case 16:
				this.mT__34();
				return;
			case 17:
				this.mT__35();
				return;
			case 18:
				this.mT__36();
				return;
			case 19:
				this.mT__37();
				return;
			case 20:
				this.mT__38();
				return;
			case 21:
				this.mT__39();
				return;
			case 22:
				this.mT__40();
				return;
			case 23:
				this.mT__41();
				return;
			case 24:
				this.mT__42();
				return;
			case 25:
				this.mT__43();
				return;
			case 26:
				this.mT__44();
				return;
			case 27:
				this.mT__45();
				return;
			case 28:
				this.mT__46();
				return;
			case 29:
				this.mT__47();
				return;
			case 30:
				this.mT__48();
				return;
			case 31:
				this.mTRUE();
				return;
			case 32:
				this.mFALSE();
				return;
			case 33:
				this.mID();
				return;
			case 34:
				this.mINTEGER();
				return;
			case 35:
				this.mFLOAT();
				return;
			case 36:
				this.mSTRING();
				return;
			case 37:
				this.mDATETIME();
				return;
			case 38:
				this.mNAME();
				return;
			case 39:
				this.mE();
				return;
			case 40:
				this.mWS();
				return;
			default:
				return;
			}
		}

		// Token: 0x0400025D RID: 605
		protected NCalcLexer.DFA7 dfa7;

		// Token: 0x0400025E RID: 606
		protected NCalcLexer.DFA14 dfa14;

		// Token: 0x0400025F RID: 607
		public const int T__29 = 29;

		// Token: 0x04000260 RID: 608
		public const int T__28 = 28;

		// Token: 0x04000261 RID: 609
		public const int T__27 = 27;

		// Token: 0x04000262 RID: 610
		public const int T__26 = 26;

		// Token: 0x04000263 RID: 611
		public const int T__25 = 25;

		// Token: 0x04000264 RID: 612
		public const int T__24 = 24;

		// Token: 0x04000265 RID: 613
		public const int LETTER = 12;

		// Token: 0x04000266 RID: 614
		public const int T__23 = 23;

		// Token: 0x04000267 RID: 615
		public const int T__22 = 22;

		// Token: 0x04000268 RID: 616
		public const int T__21 = 21;

		// Token: 0x04000269 RID: 617
		public const int T__20 = 20;

		// Token: 0x0400026A RID: 618
		public const int FLOAT = 5;

		// Token: 0x0400026B RID: 619
		public const int ID = 10;

		// Token: 0x0400026C RID: 620
		public const int EOF = -1;

		// Token: 0x0400026D RID: 621
		public const int HexDigit = 17;

		// Token: 0x0400026E RID: 622
		public const int T__19 = 19;

		// Token: 0x0400026F RID: 623
		public const int NAME = 11;

		// Token: 0x04000270 RID: 624
		public const int DIGIT = 13;

		// Token: 0x04000271 RID: 625
		public const int T__42 = 42;

		// Token: 0x04000272 RID: 626
		public const int INTEGER = 4;

		// Token: 0x04000273 RID: 627
		public const int E = 14;

		// Token: 0x04000274 RID: 628
		public const int T__43 = 43;

		// Token: 0x04000275 RID: 629
		public const int T__40 = 40;

		// Token: 0x04000276 RID: 630
		public const int T__41 = 41;

		// Token: 0x04000277 RID: 631
		public const int T__46 = 46;

		// Token: 0x04000278 RID: 632
		public const int T__47 = 47;

		// Token: 0x04000279 RID: 633
		public const int T__44 = 44;

		// Token: 0x0400027A RID: 634
		public const int T__45 = 45;

		// Token: 0x0400027B RID: 635
		public const int T__48 = 48;

		// Token: 0x0400027C RID: 636
		public const int DATETIME = 7;

		// Token: 0x0400027D RID: 637
		public const int TRUE = 8;

		// Token: 0x0400027E RID: 638
		public const int T__30 = 30;

		// Token: 0x0400027F RID: 639
		public const int T__31 = 31;

		// Token: 0x04000280 RID: 640
		public const int T__32 = 32;

		// Token: 0x04000281 RID: 641
		public const int WS = 18;

		// Token: 0x04000282 RID: 642
		public const int T__33 = 33;

		// Token: 0x04000283 RID: 643
		public const int T__34 = 34;

		// Token: 0x04000284 RID: 644
		public const int T__35 = 35;

		// Token: 0x04000285 RID: 645
		public const int T__36 = 36;

		// Token: 0x04000286 RID: 646
		public const int T__37 = 37;

		// Token: 0x04000287 RID: 647
		public const int T__38 = 38;

		// Token: 0x04000288 RID: 648
		public const int T__39 = 39;

		// Token: 0x04000289 RID: 649
		public const int UnicodeEscape = 16;

		// Token: 0x0400028A RID: 650
		public const int FALSE = 9;

		// Token: 0x0400028B RID: 651
		public const int EscapeSequence = 15;

		// Token: 0x0400028C RID: 652
		public const int STRING = 6;

		// Token: 0x0400028D RID: 653
		private const string DFA7_eotS = "\u0004￿";

		// Token: 0x0400028E RID: 654
		private const string DFA7_eofS = "\u0004￿";

		// Token: 0x0400028F RID: 655
		private const string DFA7_minS = "\u0002.\u0002￿";

		// Token: 0x04000290 RID: 656
		private const string DFA7_maxS = "\u00019\u0001e\u0002￿";

		// Token: 0x04000291 RID: 657
		private const string DFA7_acceptS = "\u0002￿\u0001\u0001\u0001\u0002";

		// Token: 0x04000292 RID: 658
		private const string DFA7_specialS = "\u0004￿}>";

		// Token: 0x04000293 RID: 659
		private const string DFA14_eotS = "\u0003￿\u0001!\u0001\u001e\u0001$\u0001\u001e\u0001￿\u0001'\u0001)\u0001-\u00010\u0005￿\u0001\u001e\u0004￿\u0003\u001e\u00016\b￿\u00017\u0002￿\u0001\u001e\v￿\u0003\u001e\u0001￿\u0001\u001e\u0002￿\u0001<\u0001=\u0002\u001e\u0002￿\u0001@\u0001\u001e\u0001￿\u0001B\u0001￿";

		// Token: 0x04000294 RID: 660
		private const string DFA14_eofS = "C￿";

		// Token: 0x04000295 RID: 661
		private const string DFA14_minS = "\u0001\t\u0002￿\u0001|\u0001r\u0001&\u0001n\u0001￿\u0002=\u0001<\u0001=\u0005￿\u0001o\u0004￿\u0001r\u0001a\u0001+\u0001.\b￿\u00010\u0002￿\u0001d\v￿\u0001t\u0001u\u0001l\u0001￿\u00010\u0002￿\u00020\u0001e\u0001s\u0002￿\u00010\u0001e\u0001￿\u00010\u0001￿";

		// Token: 0x04000296 RID: 662
		private const string DFA14_maxS = "\u0001~\u0002￿\u0001|\u0001r\u0001&\u0001n\u0001￿\u0002=\u0002>\u0005￿\u0001o\u0004￿\u0001r\u0001a\u00019\u0001e\b￿\u0001z\u0002￿\u0001d\v￿\u0001t\u0001u\u0001l\u0001￿\u00019\u0002￿\u0002z\u0001e\u0001s\u0002￿\u0001z\u0001e\u0001￿\u0001z\u0001￿";

		// Token: 0x04000297 RID: 663
		private const string DFA14_acceptS = "\u0001￿\u0001\u0001\u0001\u0002\u0004￿\u0001\b\u0004￿\u0001\u0014\u0001\u0015\u0001\u0016\u0001\u0017\u0001\u0018\u0001￿\u0001\u001b\u0001\u001c\u0001\u001d\u0001\u001e\u0004￿\u0001#\u0001$\u0001%\u0001&\u0001!\u0001(\u0001\u0003\u0001\a\u0001￿\u0001\u0005\u0001\t\u0001￿\u0001\n\u0001\v\u0001\f\u0001\u0019\u0001\r\u0001\u000f\u0001\u0012\u0001\u000e\u0001\u0011\u0001\u0013\u0001\u0010\u0003￿\u0001'\u0001￿\u0001\"\u0001\u0004\u0004￿\u0001\u0006\u0001\u001a\u0002￿\u0001\u001f\u0001￿\u0001 ";

		// Token: 0x04000298 RID: 664
		private const string DFA14_specialS = "C￿}>";

		// Token: 0x04000299 RID: 665
		private static readonly string[] DFA7_transitionS = new string[]
		{
			"\u0001\u0002\u0001￿\n\u0001",
			"\u0001\u0002\u0001￿\n\u0001\v￿\u0001\u0003\u001f￿\u0001\u0003",
			"",
			""
		};

		// Token: 0x0400029A RID: 666
		private static readonly short[] DFA7_eot = DFA.UnpackEncodedString("\u0004￿");

		// Token: 0x0400029B RID: 667
		private static readonly short[] DFA7_eof = DFA.UnpackEncodedString("\u0004￿");

		// Token: 0x0400029C RID: 668
		private static readonly char[] DFA7_min = DFA.UnpackEncodedStringToUnsignedChars("\u0002.\u0002￿");

		// Token: 0x0400029D RID: 669
		private static readonly char[] DFA7_max = DFA.UnpackEncodedStringToUnsignedChars("\u00019\u0001e\u0002￿");

		// Token: 0x0400029E RID: 670
		private static readonly short[] DFA7_accept = DFA.UnpackEncodedString("\u0002￿\u0001\u0001\u0001\u0002");

		// Token: 0x0400029F RID: 671
		private static readonly short[] DFA7_special = DFA.UnpackEncodedString("\u0004￿}>");

		// Token: 0x040002A0 RID: 672
		private static readonly short[][] DFA7_transition = DFA.UnpackEncodedStringArray(NCalcLexer.DFA7_transitionS);

		// Token: 0x040002A1 RID: 673
		private static readonly string[] DFA14_transitionS = new string[]
		{
			"\u0002\u001f\u0001￿\u0002\u001f\u0012￿\u0001\u001f\u0001\t\u0001￿\u0001\u001c\u0001￿\u0001\u0010\u0001\u0005\u0001\u001b\u0001\u0013\u0001\u0014\u0001\u000e\u0001\f\u0001\u0015\u0001\r\u0001\u001a\u0001\u000f\n\u0019\u0001\u0002\u0001￿\u0001\n\u0001\b\u0001\v\u0001\u0001\u0001￿\u0004\u001e\u0001\u0018\u0015\u001e\u0001\u001d\u0002￿\u0001\a\u0001\u001e\u0001￿\u0001\u0006\u0003\u001e\u0001\u0018\u0001\u0017\a\u001e\u0001\u0011\u0001\u0004\u0004\u001e\u0001\u0016\u0006\u001e\u0001￿\u0001\u0003\u0001￿\u0001\u0012",
			"",
			"",
			"\u0001 ",
			"\u0001\"",
			"\u0001#",
			"\u0001%",
			"",
			"\u0001&",
			"\u0001(",
			"\u0001,\u0001+\u0001*",
			"\u0001.\u0001/",
			"",
			"",
			"",
			"",
			"",
			"\u00011",
			"",
			"",
			"",
			"",
			"\u00012",
			"\u00013",
			"\u00014\u0001￿\u00014\u0002￿\n5",
			"\u0001\u001a\u0001￿\n\u0019\v￿\u0001\u001a\u001f￿\u0001\u001a",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"\n\u001e\a￿\u001a\u001e\u0004￿\u0001\u001e\u0001￿\u001a\u001e",
			"",
			"",
			"\u00018",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"\u00019",
			"\u0001:",
			"\u0001;",
			"",
			"\n5",
			"",
			"",
			"\n\u001e\a￿\u001a\u001e\u0004￿\u0001\u001e\u0001￿\u001a\u001e",
			"\n\u001e\a￿\u001a\u001e\u0004￿\u0001\u001e\u0001￿\u001a\u001e",
			"\u0001>",
			"\u0001?",
			"",
			"",
			"\n\u001e\a￿\u001a\u001e\u0004￿\u0001\u001e\u0001￿\u001a\u001e",
			"\u0001A",
			"",
			"\n\u001e\a￿\u001a\u001e\u0004￿\u0001\u001e\u0001￿\u001a\u001e",
			""
		};

		// Token: 0x040002A2 RID: 674
		private static readonly short[] DFA14_eot = DFA.UnpackEncodedString("\u0003￿\u0001!\u0001\u001e\u0001$\u0001\u001e\u0001￿\u0001'\u0001)\u0001-\u00010\u0005￿\u0001\u001e\u0004￿\u0003\u001e\u00016\b￿\u00017\u0002￿\u0001\u001e\v￿\u0003\u001e\u0001￿\u0001\u001e\u0002￿\u0001<\u0001=\u0002\u001e\u0002￿\u0001@\u0001\u001e\u0001￿\u0001B\u0001￿");

		// Token: 0x040002A3 RID: 675
		private static readonly short[] DFA14_eof = DFA.UnpackEncodedString("C￿");

		// Token: 0x040002A4 RID: 676
		private static readonly char[] DFA14_min = DFA.UnpackEncodedStringToUnsignedChars("\u0001\t\u0002￿\u0001|\u0001r\u0001&\u0001n\u0001￿\u0002=\u0001<\u0001=\u0005￿\u0001o\u0004￿\u0001r\u0001a\u0001+\u0001.\b￿\u00010\u0002￿\u0001d\v￿\u0001t\u0001u\u0001l\u0001￿\u00010\u0002￿\u00020\u0001e\u0001s\u0002￿\u00010\u0001e\u0001￿\u00010\u0001￿");

		// Token: 0x040002A5 RID: 677
		private static readonly char[] DFA14_max = DFA.UnpackEncodedStringToUnsignedChars("\u0001~\u0002￿\u0001|\u0001r\u0001&\u0001n\u0001￿\u0002=\u0002>\u0005￿\u0001o\u0004￿\u0001r\u0001a\u00019\u0001e\b￿\u0001z\u0002￿\u0001d\v￿\u0001t\u0001u\u0001l\u0001￿\u00019\u0002￿\u0002z\u0001e\u0001s\u0002￿\u0001z\u0001e\u0001￿\u0001z\u0001￿");

		// Token: 0x040002A6 RID: 678
		private static readonly short[] DFA14_accept = DFA.UnpackEncodedString("\u0001￿\u0001\u0001\u0001\u0002\u0004￿\u0001\b\u0004￿\u0001\u0014\u0001\u0015\u0001\u0016\u0001\u0017\u0001\u0018\u0001￿\u0001\u001b\u0001\u001c\u0001\u001d\u0001\u001e\u0004￿\u0001#\u0001$\u0001%\u0001&\u0001!\u0001(\u0001\u0003\u0001\a\u0001￿\u0001\u0005\u0001\t\u0001￿\u0001\n\u0001\v\u0001\f\u0001\u0019\u0001\r\u0001\u000f\u0001\u0012\u0001\u000e\u0001\u0011\u0001\u0013\u0001\u0010\u0003￿\u0001'\u0001￿\u0001\"\u0001\u0004\u0004￿\u0001\u0006\u0001\u001a\u0002￿\u0001\u001f\u0001￿\u0001 ");

		// Token: 0x040002A7 RID: 679
		private static readonly short[] DFA14_special = DFA.UnpackEncodedString("C￿}>");

		// Token: 0x040002A8 RID: 680
		private static readonly short[][] DFA14_transition = DFA.UnpackEncodedStringArray(NCalcLexer.DFA14_transitionS);

		// Token: 0x020001E7 RID: 487
		protected class DFA7 : DFA
		{
			// Token: 0x06000C80 RID: 3200 RVA: 0x0001C33C File Offset: 0x0001A53C
			public DFA7(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 7;
				this.eot = NCalcLexer.DFA7_eot;
				this.eof = NCalcLexer.DFA7_eof;
				this.min = NCalcLexer.DFA7_min;
				this.max = NCalcLexer.DFA7_max;
				this.accept = NCalcLexer.DFA7_accept;
				this.special = NCalcLexer.DFA7_special;
				this.transition = NCalcLexer.DFA7_transition;
			}

			// Token: 0x170003DE RID: 990
			// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0001C3AA File Offset: 0x0001A5AA
			public override string Description
			{
				get
				{
					return "252:1: FLOAT : ( ( DIGIT )* '.' ( DIGIT )+ ( E )? | ( DIGIT )+ E );";
				}
			}
		}

		// Token: 0x020001E8 RID: 488
		protected class DFA14 : DFA
		{
			// Token: 0x06000C82 RID: 3202 RVA: 0x0001C3B4 File Offset: 0x0001A5B4
			public DFA14(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 14;
				this.eot = NCalcLexer.DFA14_eot;
				this.eof = NCalcLexer.DFA14_eof;
				this.min = NCalcLexer.DFA14_min;
				this.max = NCalcLexer.DFA14_max;
				this.accept = NCalcLexer.DFA14_accept;
				this.special = NCalcLexer.DFA14_special;
				this.transition = NCalcLexer.DFA14_transition;
			}

			// Token: 0x170003DF RID: 991
			// (get) Token: 0x06000C83 RID: 3203 RVA: 0x0001C423 File Offset: 0x0001A623
			public override string Description
			{
				get
				{
					return "1:1: Tokens : ( T__19 | T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | TRUE | FALSE | ID | INTEGER | FLOAT | STRING | DATETIME | NAME | E | WS );";
				}
			}
		}
	}
}
