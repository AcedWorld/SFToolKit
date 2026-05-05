using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000191 RID: 401
	public class NCalcParser : Parser
	{
		// Token: 0x06000B14 RID: 2836 RVA: 0x00015F48 File Offset: 0x00014148
		public NCalcParser(ITokenStream input) : this(input, new RecognizerSharedState())
		{
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00015F56 File Offset: 0x00014156
		public NCalcParser(ITokenStream input, RecognizerSharedState state) : base(input, state)
		{
			this.InitializeCyclicDFAs();
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000B16 RID: 2838 RVA: 0x00015F71 File Offset: 0x00014171
		// (set) Token: 0x06000B17 RID: 2839 RVA: 0x00015F79 File Offset: 0x00014179
		public ITreeAdaptor TreeAdaptor
		{
			get
			{
				return this.adaptor;
			}
			set
			{
				this.adaptor = value;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000B18 RID: 2840 RVA: 0x00015F82 File Offset: 0x00014182
		public override string[] TokenNames
		{
			get
			{
				return NCalcParser.tokenNames;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x00015F89 File Offset: 0x00014189
		public override string GrammarFileName
		{
			get
			{
				return "C:\\Users\\s.ros\\Documents\\D�veloppement\\NCalc\\Grammar\\NCalc.g";
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x00015F90 File Offset: 0x00014190
		// (set) Token: 0x06000B1B RID: 2843 RVA: 0x00015F98 File Offset: 0x00014198
		public List<string> Errors { get; private set; }

		// Token: 0x06000B1C RID: 2844 RVA: 0x00015FA1 File Offset: 0x000141A1
		private void InitializeCyclicDFAs()
		{
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00015FA4 File Offset: 0x000141A4
		private string extractString(string text)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			int startIndex = 1;
			int num;
			while ((num = stringBuilder.ToString().IndexOf('\\', startIndex)) != -1)
			{
				char c = stringBuilder[num + 1];
				if (c <= '\\')
				{
					if (c != '\'')
					{
						if (c != '\\')
						{
							goto IL_13E;
						}
						stringBuilder.Remove(num, 2).Insert(num, '\\');
					}
					else
					{
						stringBuilder.Remove(num, 2).Insert(num, '\'');
					}
				}
				else if (c != 'n')
				{
					switch (c)
					{
					case 'r':
						stringBuilder.Remove(num, 2).Insert(num, '\r');
						break;
					case 's':
						goto IL_13E;
					case 't':
						stringBuilder.Remove(num, 2).Insert(num, '\t');
						break;
					case 'u':
					{
						string value = stringBuilder[num + 4] + stringBuilder[num + 5];
						string value2 = stringBuilder[num + 2] + stringBuilder[num + 3];
						char value3 = Encoding.Unicode.GetChars(new byte[]
						{
							Convert.ToByte(value, 16),
							Convert.ToByte(value2, 16)
						})[0];
						stringBuilder.Remove(num, 6).Insert(num, value3);
						break;
					}
					default:
						goto IL_13E;
					}
				}
				else
				{
					stringBuilder.Remove(num, 2).Insert(num, '\n');
				}
				startIndex = num + 1;
				continue;
				IL_13E:
				throw new RecognitionException("Unvalid escape sequence: \\" + c.ToString());
			}
			stringBuilder.Remove(0, 1);
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			return stringBuilder.ToString();
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00016140 File Offset: 0x00014340
		public override void DisplayRecognitionError(string[] tokenNames, RecognitionException e)
		{
			base.DisplayRecognitionError(tokenNames, e);
			if (this.Errors == null)
			{
				this.Errors = new List<string>();
			}
			string errorHeader = this.GetErrorHeader(e);
			string errorMessage = this.GetErrorMessage(e, tokenNames);
			this.Errors.Add(errorMessage + " at " + errorHeader);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x00016190 File Offset: 0x00014390
		public NCalcParser.ncalcExpression_return ncalcExpression()
		{
			NCalcParser.ncalcExpression_return ncalcExpression_return = new NCalcParser.ncalcExpression_return();
			ncalcExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_logicalExpression_in_ncalcExpression56);
				NCalcParser.logicalExpression_return logicalExpression_return = this.logicalExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, logicalExpression_return.Tree);
				IToken token = (IToken)this.Match(this.input, -1, NCalcParser.FOLLOW_EOF_in_ncalcExpression58);
				ncalcExpression_return.value = ((logicalExpression_return != null) ? logicalExpression_return.value : null);
				ncalcExpression_return.Stop = this.input.LT(-1);
				ncalcExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(ncalcExpression_return.Tree, (IToken)ncalcExpression_return.Start, (IToken)ncalcExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				ncalcExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)ncalcExpression_return.Start, this.input.LT(-1), ex);
			}
			return ncalcExpression_return;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x000162DC File Offset: 0x000144DC
		public NCalcParser.logicalExpression_return logicalExpression()
		{
			NCalcParser.logicalExpression_return logicalExpression_return = new NCalcParser.logicalExpression_return();
			logicalExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_conditionalExpression_in_logicalExpression78);
				NCalcParser.conditionalExpression_return conditionalExpression_return = this.conditionalExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, conditionalExpression_return.Tree);
				logicalExpression_return.value = ((conditionalExpression_return != null) ? conditionalExpression_return.value : null);
				int num = 2;
				if (this.input.LA(1) == 19)
				{
					num = 1;
				}
				if (num == 1)
				{
					IToken payload = (IToken)this.Match(this.input, 19, NCalcParser.FOLLOW_19_in_logicalExpression84);
					CommonTree child = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child);
					base.PushFollow(NCalcParser.FOLLOW_conditionalExpression_in_logicalExpression88);
					NCalcParser.conditionalExpression_return conditionalExpression_return2 = this.conditionalExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, conditionalExpression_return2.Tree);
					IToken payload2 = (IToken)this.Match(this.input, 20, NCalcParser.FOLLOW_20_in_logicalExpression90);
					CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
					this.adaptor.AddChild(commonTree, child2);
					base.PushFollow(NCalcParser.FOLLOW_conditionalExpression_in_logicalExpression94);
					NCalcParser.conditionalExpression_return conditionalExpression_return3 = this.conditionalExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, conditionalExpression_return3.Tree);
					logicalExpression_return.value = new TernaryExpression((conditionalExpression_return != null) ? conditionalExpression_return.value : null, (conditionalExpression_return2 != null) ? conditionalExpression_return2.value : null, (conditionalExpression_return3 != null) ? conditionalExpression_return3.value : null);
				}
				logicalExpression_return.Stop = this.input.LT(-1);
				logicalExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(logicalExpression_return.Tree, (IToken)logicalExpression_return.Start, (IToken)logicalExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				logicalExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)logicalExpression_return.Start, this.input.LT(-1), ex);
			}
			return logicalExpression_return;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0001656C File Offset: 0x0001476C
		public NCalcParser.conditionalExpression_return conditionalExpression()
		{
			NCalcParser.conditionalExpression_return conditionalExpression_return = new NCalcParser.conditionalExpression_return();
			conditionalExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_booleanAndExpression_in_conditionalExpression121);
				NCalcParser.booleanAndExpression_return booleanAndExpression_return = this.booleanAndExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, booleanAndExpression_return.Tree);
				conditionalExpression_return.value = ((booleanAndExpression_return != null) ? booleanAndExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 21 && num2 <= 22)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_179;
					}
					IToken payload = this.input.LT(1);
					if (this.input.LA(1) < 21 || this.input.LA(1) > 22)
					{
						break;
					}
					this.input.Consume();
					this.adaptor.AddChild(commonTree, (CommonTree)this.adaptor.Create(payload));
					this.state.errorRecovery = false;
					BinaryExpressionType type = BinaryExpressionType.Or;
					base.PushFollow(NCalcParser.FOLLOW_conditionalExpression_in_conditionalExpression146);
					NCalcParser.conditionalExpression_return conditionalExpression_return2 = this.conditionalExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, conditionalExpression_return2.Tree);
					conditionalExpression_return.value = new BinaryExpression(type, conditionalExpression_return.value, (conditionalExpression_return2 != null) ? conditionalExpression_return2.value : null);
				}
				throw new MismatchedSetException(null, this.input);
				IL_179:
				conditionalExpression_return.Stop = this.input.LT(-1);
				conditionalExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(conditionalExpression_return.Tree, (IToken)conditionalExpression_return.Start, (IToken)conditionalExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				conditionalExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)conditionalExpression_return.Start, this.input.LT(-1), ex);
			}
			return conditionalExpression_return;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000167B0 File Offset: 0x000149B0
		public NCalcParser.booleanAndExpression_return booleanAndExpression()
		{
			NCalcParser.booleanAndExpression_return booleanAndExpression_return = new NCalcParser.booleanAndExpression_return();
			booleanAndExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_bitwiseOrExpression_in_booleanAndExpression180);
				NCalcParser.bitwiseOrExpression_return bitwiseOrExpression_return = this.bitwiseOrExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, bitwiseOrExpression_return.Tree);
				booleanAndExpression_return.value = ((bitwiseOrExpression_return != null) ? bitwiseOrExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 23 && num2 <= 24)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_179;
					}
					IToken payload = this.input.LT(1);
					if (this.input.LA(1) < 23 || this.input.LA(1) > 24)
					{
						break;
					}
					this.input.Consume();
					this.adaptor.AddChild(commonTree, (CommonTree)this.adaptor.Create(payload));
					this.state.errorRecovery = false;
					BinaryExpressionType type = BinaryExpressionType.And;
					base.PushFollow(NCalcParser.FOLLOW_bitwiseOrExpression_in_booleanAndExpression205);
					NCalcParser.bitwiseOrExpression_return bitwiseOrExpression_return2 = this.bitwiseOrExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, bitwiseOrExpression_return2.Tree);
					booleanAndExpression_return.value = new BinaryExpression(type, booleanAndExpression_return.value, (bitwiseOrExpression_return2 != null) ? bitwiseOrExpression_return2.value : null);
				}
				throw new MismatchedSetException(null, this.input);
				IL_179:
				booleanAndExpression_return.Stop = this.input.LT(-1);
				booleanAndExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(booleanAndExpression_return.Tree, (IToken)booleanAndExpression_return.Start, (IToken)booleanAndExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				booleanAndExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)booleanAndExpression_return.Start, this.input.LT(-1), ex);
			}
			return booleanAndExpression_return;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x000169F4 File Offset: 0x00014BF4
		public NCalcParser.bitwiseOrExpression_return bitwiseOrExpression()
		{
			NCalcParser.bitwiseOrExpression_return bitwiseOrExpression_return = new NCalcParser.bitwiseOrExpression_return();
			bitwiseOrExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_bitwiseXOrExpression_in_bitwiseOrExpression237);
				NCalcParser.bitwiseXOrExpression_return bitwiseXOrExpression_return = this.bitwiseXOrExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, bitwiseXOrExpression_return.Tree);
				bitwiseOrExpression_return.value = ((bitwiseXOrExpression_return != null) ? bitwiseXOrExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					if (this.input.LA(1) == 25)
					{
						num = 1;
					}
					if (num != 1)
					{
						break;
					}
					IToken payload = (IToken)this.Match(this.input, 25, NCalcParser.FOLLOW_25_in_bitwiseOrExpression246);
					CommonTree child = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child);
					BinaryExpressionType type = BinaryExpressionType.BitwiseOr;
					base.PushFollow(NCalcParser.FOLLOW_bitwiseOrExpression_in_bitwiseOrExpression256);
					NCalcParser.bitwiseOrExpression_return bitwiseOrExpression_return2 = this.bitwiseOrExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, bitwiseOrExpression_return2.Tree);
					bitwiseOrExpression_return.value = new BinaryExpression(type, bitwiseOrExpression_return.value, (bitwiseOrExpression_return2 != null) ? bitwiseOrExpression_return2.value : null);
				}
				bitwiseOrExpression_return.Stop = this.input.LT(-1);
				bitwiseOrExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(bitwiseOrExpression_return.Tree, (IToken)bitwiseOrExpression_return.Start, (IToken)bitwiseOrExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				bitwiseOrExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)bitwiseOrExpression_return.Start, this.input.LT(-1), ex);
			}
			return bitwiseOrExpression_return;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00016BFC File Offset: 0x00014DFC
		public NCalcParser.bitwiseXOrExpression_return bitwiseXOrExpression()
		{
			NCalcParser.bitwiseXOrExpression_return bitwiseXOrExpression_return = new NCalcParser.bitwiseXOrExpression_return();
			bitwiseXOrExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_bitwiseAndExpression_in_bitwiseXOrExpression290);
				NCalcParser.bitwiseAndExpression_return bitwiseAndExpression_return = this.bitwiseAndExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, bitwiseAndExpression_return.Tree);
				bitwiseXOrExpression_return.value = ((bitwiseAndExpression_return != null) ? bitwiseAndExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					if (this.input.LA(1) == 26)
					{
						num = 1;
					}
					if (num != 1)
					{
						break;
					}
					IToken payload = (IToken)this.Match(this.input, 26, NCalcParser.FOLLOW_26_in_bitwiseXOrExpression299);
					CommonTree child = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child);
					BinaryExpressionType type = BinaryExpressionType.BitwiseXOr;
					base.PushFollow(NCalcParser.FOLLOW_bitwiseAndExpression_in_bitwiseXOrExpression309);
					NCalcParser.bitwiseAndExpression_return bitwiseAndExpression_return2 = this.bitwiseAndExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, bitwiseAndExpression_return2.Tree);
					bitwiseXOrExpression_return.value = new BinaryExpression(type, bitwiseXOrExpression_return.value, (bitwiseAndExpression_return2 != null) ? bitwiseAndExpression_return2.value : null);
				}
				bitwiseXOrExpression_return.Stop = this.input.LT(-1);
				bitwiseXOrExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(bitwiseXOrExpression_return.Tree, (IToken)bitwiseXOrExpression_return.Start, (IToken)bitwiseXOrExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				bitwiseXOrExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)bitwiseXOrExpression_return.Start, this.input.LT(-1), ex);
			}
			return bitwiseXOrExpression_return;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x00016E04 File Offset: 0x00015004
		public NCalcParser.bitwiseAndExpression_return bitwiseAndExpression()
		{
			NCalcParser.bitwiseAndExpression_return bitwiseAndExpression_return = new NCalcParser.bitwiseAndExpression_return();
			bitwiseAndExpression_return.Start = this.input.LT(1);
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_equalityExpression_in_bitwiseAndExpression341);
				NCalcParser.equalityExpression_return equalityExpression_return = this.equalityExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, equalityExpression_return.Tree);
				bitwiseAndExpression_return.value = ((equalityExpression_return != null) ? equalityExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					if (this.input.LA(1) == 27)
					{
						num = 1;
					}
					if (num != 1)
					{
						break;
					}
					IToken payload = (IToken)this.Match(this.input, 27, NCalcParser.FOLLOW_27_in_bitwiseAndExpression350);
					CommonTree child = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child);
					BinaryExpressionType type = BinaryExpressionType.BitwiseAnd;
					base.PushFollow(NCalcParser.FOLLOW_equalityExpression_in_bitwiseAndExpression360);
					NCalcParser.equalityExpression_return equalityExpression_return2 = this.equalityExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, equalityExpression_return2.Tree);
					bitwiseAndExpression_return.value = new BinaryExpression(type, bitwiseAndExpression_return.value, (equalityExpression_return2 != null) ? equalityExpression_return2.value : null);
				}
				bitwiseAndExpression_return.Stop = this.input.LT(-1);
				bitwiseAndExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(bitwiseAndExpression_return.Tree, (IToken)bitwiseAndExpression_return.Start, (IToken)bitwiseAndExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				bitwiseAndExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)bitwiseAndExpression_return.Start, this.input.LT(-1), ex);
			}
			return bitwiseAndExpression_return;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0001700C File Offset: 0x0001520C
		public NCalcParser.equalityExpression_return equalityExpression()
		{
			NCalcParser.equalityExpression_return equalityExpression_return = new NCalcParser.equalityExpression_return();
			equalityExpression_return.Start = this.input.LT(1);
			BinaryExpressionType type = BinaryExpressionType.Unknown;
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_relationalExpression_in_equalityExpression394);
				NCalcParser.relationalExpression_return relationalExpression_return = this.relationalExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, relationalExpression_return.Tree);
				equalityExpression_return.value = ((relationalExpression_return != null) ? relationalExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 28 && num2 <= 31)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_24A;
					}
					int num3 = this.input.LA(1);
					int num4;
					if (num3 >= 28 && num3 <= 29)
					{
						num4 = 1;
					}
					else
					{
						if (num3 < 30 || num3 > 31)
						{
							break;
						}
						num4 = 2;
					}
					if (num4 != 1)
					{
						if (num4 == 2)
						{
							IToken payload = this.input.LT(1);
							if (this.input.LA(1) < 30 || this.input.LA(1) > 31)
							{
								goto IL_1DB;
							}
							this.input.Consume();
							this.adaptor.AddChild(commonTree, (CommonTree)this.adaptor.Create(payload));
							this.state.errorRecovery = false;
							type = BinaryExpressionType.NotEqual;
						}
					}
					else
					{
						IToken payload2 = this.input.LT(1);
						if (this.input.LA(1) < 28 || this.input.LA(1) > 29)
						{
							goto IL_166;
						}
						this.input.Consume();
						this.adaptor.AddChild(commonTree, (CommonTree)this.adaptor.Create(payload2));
						this.state.errorRecovery = false;
						type = BinaryExpressionType.Equal;
					}
					base.PushFollow(NCalcParser.FOLLOW_relationalExpression_in_equalityExpression441);
					NCalcParser.relationalExpression_return relationalExpression_return2 = this.relationalExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, relationalExpression_return2.Tree);
					equalityExpression_return.value = new BinaryExpression(type, equalityExpression_return.value, (relationalExpression_return2 != null) ? relationalExpression_return2.value : null);
				}
				throw new NoViableAltException("", 7, 0, this.input);
				IL_166:
				throw new MismatchedSetException(null, this.input);
				IL_1DB:
				throw new MismatchedSetException(null, this.input);
				IL_24A:
				equalityExpression_return.Stop = this.input.LT(-1);
				equalityExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(equalityExpression_return.Tree, (IToken)equalityExpression_return.Start, (IToken)equalityExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				equalityExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)equalityExpression_return.Start, this.input.LT(-1), ex);
			}
			return equalityExpression_return;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00017324 File Offset: 0x00015524
		public NCalcParser.relationalExpression_return relationalExpression()
		{
			NCalcParser.relationalExpression_return relationalExpression_return = new NCalcParser.relationalExpression_return();
			relationalExpression_return.Start = this.input.LT(1);
			BinaryExpressionType type = BinaryExpressionType.Unknown;
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_shiftExpression_in_relationalExpression474);
				NCalcParser.shiftExpression_return shiftExpression_return = this.shiftExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, shiftExpression_return.Tree);
				relationalExpression_return.value = ((shiftExpression_return != null) ? shiftExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 32 && num2 <= 35)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_296;
					}
					int num3;
					switch (this.input.LA(1))
					{
					case 32:
						num3 = 1;
						goto IL_115;
					case 33:
						num3 = 2;
						goto IL_115;
					case 34:
						num3 = 3;
						goto IL_115;
					case 35:
						num3 = 4;
						goto IL_115;
					}
					break;
					IL_115:
					switch (num3)
					{
					case 1:
					{
						IToken payload = (IToken)this.Match(this.input, 32, NCalcParser.FOLLOW_32_in_relationalExpression485);
						CommonTree child = (CommonTree)this.adaptor.Create(payload);
						this.adaptor.AddChild(commonTree, child);
						type = BinaryExpressionType.Lesser;
						break;
					}
					case 2:
					{
						IToken payload2 = (IToken)this.Match(this.input, 33, NCalcParser.FOLLOW_33_in_relationalExpression495);
						CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
						this.adaptor.AddChild(commonTree, child2);
						type = BinaryExpressionType.LesserOrEqual;
						break;
					}
					case 3:
					{
						IToken payload3 = (IToken)this.Match(this.input, 34, NCalcParser.FOLLOW_34_in_relationalExpression506);
						CommonTree child3 = (CommonTree)this.adaptor.Create(payload3);
						this.adaptor.AddChild(commonTree, child3);
						type = BinaryExpressionType.Greater;
						break;
					}
					case 4:
					{
						IToken payload4 = (IToken)this.Match(this.input, 35, NCalcParser.FOLLOW_35_in_relationalExpression516);
						CommonTree child4 = (CommonTree)this.adaptor.Create(payload4);
						this.adaptor.AddChild(commonTree, child4);
						type = BinaryExpressionType.GreaterOrEqual;
						break;
					}
					}
					base.PushFollow(NCalcParser.FOLLOW_shiftExpression_in_relationalExpression528);
					NCalcParser.shiftExpression_return shiftExpression_return2 = this.shiftExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, shiftExpression_return2.Tree);
					relationalExpression_return.value = new BinaryExpression(type, relationalExpression_return.value, (shiftExpression_return2 != null) ? shiftExpression_return2.value : null);
				}
				throw new NoViableAltException("", 9, 0, this.input);
				IL_296:
				relationalExpression_return.Stop = this.input.LT(-1);
				relationalExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(relationalExpression_return.Tree, (IToken)relationalExpression_return.Start, (IToken)relationalExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				relationalExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)relationalExpression_return.Start, this.input.LT(-1), ex);
			}
			return relationalExpression_return;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00017688 File Offset: 0x00015888
		public NCalcParser.shiftExpression_return shiftExpression()
		{
			NCalcParser.shiftExpression_return shiftExpression_return = new NCalcParser.shiftExpression_return();
			shiftExpression_return.Start = this.input.LT(1);
			BinaryExpressionType type = BinaryExpressionType.Unknown;
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_additiveExpression_in_shiftExpression560);
				NCalcParser.additiveExpression_return additiveExpression_return = this.additiveExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, additiveExpression_return.Tree);
				shiftExpression_return.value = ((additiveExpression_return != null) ? additiveExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 36 && num2 <= 37)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_1D8;
					}
					int num3 = this.input.LA(1);
					int num4;
					if (num3 == 36)
					{
						num4 = 1;
					}
					else
					{
						if (num3 != 37)
						{
							break;
						}
						num4 = 2;
					}
					if (num4 != 1)
					{
						if (num4 == 2)
						{
							IToken payload = (IToken)this.Match(this.input, 37, NCalcParser.FOLLOW_37_in_shiftExpression581);
							CommonTree child = (CommonTree)this.adaptor.Create(payload);
							this.adaptor.AddChild(commonTree, child);
							type = BinaryExpressionType.RightShift;
						}
					}
					else
					{
						IToken payload2 = (IToken)this.Match(this.input, 36, NCalcParser.FOLLOW_36_in_shiftExpression571);
						CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
						this.adaptor.AddChild(commonTree, child2);
						type = BinaryExpressionType.LeftShift;
					}
					base.PushFollow(NCalcParser.FOLLOW_additiveExpression_in_shiftExpression593);
					NCalcParser.additiveExpression_return additiveExpression_return2 = this.additiveExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, additiveExpression_return2.Tree);
					shiftExpression_return.value = new BinaryExpression(type, shiftExpression_return.value, (additiveExpression_return2 != null) ? additiveExpression_return2.value : null);
				}
				throw new NoViableAltException("", 11, 0, this.input);
				IL_1D8:
				shiftExpression_return.Stop = this.input.LT(-1);
				shiftExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(shiftExpression_return.Tree, (IToken)shiftExpression_return.Start, (IToken)shiftExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				shiftExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)shiftExpression_return.Start, this.input.LT(-1), ex);
			}
			return shiftExpression_return;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0001792C File Offset: 0x00015B2C
		public NCalcParser.additiveExpression_return additiveExpression()
		{
			NCalcParser.additiveExpression_return additiveExpression_return = new NCalcParser.additiveExpression_return();
			additiveExpression_return.Start = this.input.LT(1);
			BinaryExpressionType type = BinaryExpressionType.Unknown;
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_multiplicativeExpression_in_additiveExpression625);
				NCalcParser.multiplicativeExpression_return multiplicativeExpression_return = this.multiplicativeExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, multiplicativeExpression_return.Tree);
				additiveExpression_return.value = ((multiplicativeExpression_return != null) ? multiplicativeExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 38 && num2 <= 39)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_1D7;
					}
					int num3 = this.input.LA(1);
					int num4;
					if (num3 == 38)
					{
						num4 = 1;
					}
					else
					{
						if (num3 != 39)
						{
							break;
						}
						num4 = 2;
					}
					if (num4 != 1)
					{
						if (num4 == 2)
						{
							IToken payload = (IToken)this.Match(this.input, 39, NCalcParser.FOLLOW_39_in_additiveExpression646);
							CommonTree child = (CommonTree)this.adaptor.Create(payload);
							this.adaptor.AddChild(commonTree, child);
							type = BinaryExpressionType.Minus;
						}
					}
					else
					{
						IToken payload2 = (IToken)this.Match(this.input, 38, NCalcParser.FOLLOW_38_in_additiveExpression636);
						CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
						this.adaptor.AddChild(commonTree, child2);
						type = BinaryExpressionType.Plus;
					}
					base.PushFollow(NCalcParser.FOLLOW_multiplicativeExpression_in_additiveExpression658);
					NCalcParser.multiplicativeExpression_return multiplicativeExpression_return2 = this.multiplicativeExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, multiplicativeExpression_return2.Tree);
					additiveExpression_return.value = new BinaryExpression(type, additiveExpression_return.value, (multiplicativeExpression_return2 != null) ? multiplicativeExpression_return2.value : null);
				}
				throw new NoViableAltException("", 13, 0, this.input);
				IL_1D7:
				additiveExpression_return.Stop = this.input.LT(-1);
				additiveExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(additiveExpression_return.Tree, (IToken)additiveExpression_return.Start, (IToken)additiveExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				additiveExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)additiveExpression_return.Start, this.input.LT(-1), ex);
			}
			return additiveExpression_return;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00017BD0 File Offset: 0x00015DD0
		public NCalcParser.multiplicativeExpression_return multiplicativeExpression()
		{
			NCalcParser.multiplicativeExpression_return multiplicativeExpression_return = new NCalcParser.multiplicativeExpression_return();
			multiplicativeExpression_return.Start = this.input.LT(1);
			BinaryExpressionType type = BinaryExpressionType.Unknown;
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_unaryExpression_in_multiplicativeExpression690);
				NCalcParser.unaryExpression_return unaryExpression_return = this.unaryExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, unaryExpression_return.Tree);
				multiplicativeExpression_return.value = ((unaryExpression_return != null) ? unaryExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					int num2 = this.input.LA(1);
					if (num2 >= 40 && num2 <= 42)
					{
						num = 1;
					}
					if (num != 1)
					{
						goto IL_242;
					}
					int num3;
					switch (this.input.LA(1))
					{
					case 40:
						num3 = 1;
						goto IL_106;
					case 41:
						num3 = 2;
						goto IL_106;
					case 42:
						num3 = 3;
						goto IL_106;
					}
					break;
					IL_106:
					switch (num3)
					{
					case 1:
					{
						IToken payload = (IToken)this.Match(this.input, 40, NCalcParser.FOLLOW_40_in_multiplicativeExpression701);
						CommonTree child = (CommonTree)this.adaptor.Create(payload);
						this.adaptor.AddChild(commonTree, child);
						type = BinaryExpressionType.Times;
						break;
					}
					case 2:
					{
						IToken payload2 = (IToken)this.Match(this.input, 41, NCalcParser.FOLLOW_41_in_multiplicativeExpression711);
						CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
						this.adaptor.AddChild(commonTree, child2);
						type = BinaryExpressionType.Div;
						break;
					}
					case 3:
					{
						IToken payload3 = (IToken)this.Match(this.input, 42, NCalcParser.FOLLOW_42_in_multiplicativeExpression721);
						CommonTree child3 = (CommonTree)this.adaptor.Create(payload3);
						this.adaptor.AddChild(commonTree, child3);
						type = BinaryExpressionType.Modulo;
						break;
					}
					}
					base.PushFollow(NCalcParser.FOLLOW_unaryExpression_in_multiplicativeExpression733);
					NCalcParser.unaryExpression_return unaryExpression_return2 = this.unaryExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, unaryExpression_return2.Tree);
					multiplicativeExpression_return.value = new BinaryExpression(type, multiplicativeExpression_return.value, (unaryExpression_return2 != null) ? unaryExpression_return2.value : null);
				}
				throw new NoViableAltException("", 15, 0, this.input);
				IL_242:
				multiplicativeExpression_return.Stop = this.input.LT(-1);
				multiplicativeExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(multiplicativeExpression_return.Tree, (IToken)multiplicativeExpression_return.Start, (IToken)multiplicativeExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				multiplicativeExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)multiplicativeExpression_return.Start, this.input.LT(-1), ex);
			}
			return multiplicativeExpression_return;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x00017EE0 File Offset: 0x000160E0
		public NCalcParser.unaryExpression_return unaryExpression()
		{
			NCalcParser.unaryExpression_return unaryExpression_return = new NCalcParser.unaryExpression_return();
			unaryExpression_return.Start = this.input.LT(1);
			CommonTree commonTree = null;
			try
			{
				int num = this.input.LA(1);
				int num2;
				if (num - 4 > 7)
				{
					switch (num)
					{
					case 39:
						num2 = 4;
						goto IL_9F;
					case 43:
					case 44:
						num2 = 2;
						goto IL_9F;
					case 45:
						num2 = 3;
						goto IL_9F;
					case 46:
						goto IL_77;
					}
					throw new NoViableAltException("", 17, 0, this.input);
				}
				IL_77:
				num2 = 1;
				IL_9F:
				switch (num2)
				{
				case 1:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					base.PushFollow(NCalcParser.FOLLOW_primaryExpression_in_unaryExpression760);
					NCalcParser.primaryExpression_return primaryExpression_return = this.primaryExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, primaryExpression_return.Tree);
					unaryExpression_return.value = ((primaryExpression_return != null) ? primaryExpression_return.value : null);
					break;
				}
				case 2:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken payload = this.input.LT(1);
					if (this.input.LA(1) < 43 || this.input.LA(1) > 44)
					{
						throw new MismatchedSetException(null, this.input);
					}
					this.input.Consume();
					this.adaptor.AddChild(commonTree, (CommonTree)this.adaptor.Create(payload));
					this.state.errorRecovery = false;
					base.PushFollow(NCalcParser.FOLLOW_primaryExpression_in_unaryExpression779);
					NCalcParser.primaryExpression_return primaryExpression_return2 = this.primaryExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, primaryExpression_return2.Tree);
					unaryExpression_return.value = new UnaryExpression(UnaryExpressionType.Not, (primaryExpression_return2 != null) ? primaryExpression_return2.value : null);
					break;
				}
				case 3:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken payload2 = (IToken)this.Match(this.input, 45, NCalcParser.FOLLOW_45_in_unaryExpression791);
					CommonTree child = (CommonTree)this.adaptor.Create(payload2);
					this.adaptor.AddChild(commonTree, child);
					base.PushFollow(NCalcParser.FOLLOW_primaryExpression_in_unaryExpression794);
					NCalcParser.primaryExpression_return primaryExpression_return3 = this.primaryExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, primaryExpression_return3.Tree);
					unaryExpression_return.value = new UnaryExpression(UnaryExpressionType.BitwiseNot, (primaryExpression_return3 != null) ? primaryExpression_return3.value : null);
					break;
				}
				case 4:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken payload3 = (IToken)this.Match(this.input, 39, NCalcParser.FOLLOW_39_in_unaryExpression805);
					CommonTree child2 = (CommonTree)this.adaptor.Create(payload3);
					this.adaptor.AddChild(commonTree, child2);
					base.PushFollow(NCalcParser.FOLLOW_primaryExpression_in_unaryExpression807);
					NCalcParser.primaryExpression_return primaryExpression_return4 = this.primaryExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, primaryExpression_return4.Tree);
					unaryExpression_return.value = new UnaryExpression(UnaryExpressionType.Negate, (primaryExpression_return4 != null) ? primaryExpression_return4.value : null);
					break;
				}
				}
				unaryExpression_return.Stop = this.input.LT(-1);
				unaryExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(unaryExpression_return.Tree, (IToken)unaryExpression_return.Start, (IToken)unaryExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				unaryExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)unaryExpression_return.Start, this.input.LT(-1), ex);
			}
			return unaryExpression_return;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x000182E8 File Offset: 0x000164E8
		public NCalcParser.primaryExpression_return primaryExpression()
		{
			NCalcParser.primaryExpression_return primaryExpression_return = new NCalcParser.primaryExpression_return();
			primaryExpression_return.Start = this.input.LT(1);
			CommonTree commonTree = null;
			try
			{
				int num = this.input.LA(1);
				int num2;
				if (num - 4 > 5)
				{
					if (num - 10 > 1)
					{
						if (num != 46)
						{
							throw new NoViableAltException("", 19, 0, this.input);
						}
						num2 = 1;
					}
					else
					{
						num2 = 3;
					}
				}
				else
				{
					num2 = 2;
				}
				switch (num2)
				{
				case 1:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken payload = (IToken)this.Match(this.input, 46, NCalcParser.FOLLOW_46_in_primaryExpression829);
					CommonTree child = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child);
					base.PushFollow(NCalcParser.FOLLOW_logicalExpression_in_primaryExpression831);
					NCalcParser.logicalExpression_return logicalExpression_return = this.logicalExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, logicalExpression_return.Tree);
					IToken payload2 = (IToken)this.Match(this.input, 47, NCalcParser.FOLLOW_47_in_primaryExpression833);
					CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
					this.adaptor.AddChild(commonTree, child2);
					primaryExpression_return.value = ((logicalExpression_return != null) ? logicalExpression_return.value : null);
					break;
				}
				case 2:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					base.PushFollow(NCalcParser.FOLLOW_value_in_primaryExpression843);
					NCalcParser.value_return value_return = this.value();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, value_return.Tree);
					primaryExpression_return.value = ((value_return != null) ? value_return.value : null);
					break;
				}
				case 3:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					base.PushFollow(NCalcParser.FOLLOW_identifier_in_primaryExpression851);
					NCalcParser.identifier_return identifier_return = this.identifier();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, identifier_return.Tree);
					primaryExpression_return.value = ((identifier_return != null) ? identifier_return.value : null);
					int num3 = 2;
					if (this.input.LA(1) == 46)
					{
						num3 = 1;
					}
					if (num3 == 1)
					{
						base.PushFollow(NCalcParser.FOLLOW_arguments_in_primaryExpression856);
						NCalcParser.arguments_return arguments_return = this.arguments();
						this.state.followingStackPointer--;
						this.adaptor.AddChild(commonTree, arguments_return.Tree);
						primaryExpression_return.value = new FunctionExpression((identifier_return != null) ? identifier_return.value : null, ((arguments_return != null) ? arguments_return.value : null).ToArray());
					}
					break;
				}
				}
				primaryExpression_return.Stop = this.input.LT(-1);
				primaryExpression_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(primaryExpression_return.Tree, (IToken)primaryExpression_return.Start, (IToken)primaryExpression_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				primaryExpression_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)primaryExpression_return.Start, this.input.LT(-1), ex);
			}
			return primaryExpression_return;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00018660 File Offset: 0x00016860
		public NCalcParser.value_return value()
		{
			NCalcParser.value_return value_return = new NCalcParser.value_return();
			value_return.Start = this.input.LT(1);
			CommonTree commonTree = null;
			IToken token = null;
			try
			{
				int num;
				switch (this.input.LA(1))
				{
				case 4:
					num = 1;
					break;
				case 5:
					num = 2;
					break;
				case 6:
					num = 3;
					break;
				case 7:
					num = 4;
					break;
				case 8:
					num = 5;
					break;
				case 9:
					num = 6;
					break;
				default:
					throw new NoViableAltException("", 20, 0, this.input);
				}
				switch (num)
				{
				case 1:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					token = (IToken)this.Match(this.input, 4, NCalcParser.FOLLOW_INTEGER_in_value876);
					CommonTree child = (CommonTree)this.adaptor.Create(token);
					this.adaptor.AddChild(commonTree, child);
					try
					{
						value_return.value = new ValueExpression(int.Parse((token != null) ? token.Text : null));
						goto IL_37D;
					}
					catch (OverflowException)
					{
						value_return.value = new ValueExpression((float)long.Parse((token != null) ? token.Text : null));
						goto IL_37D;
					}
					break;
				}
				case 2:
					break;
				case 3:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken token2 = (IToken)this.Match(this.input, 6, NCalcParser.FOLLOW_STRING_in_value892);
					CommonTree child2 = (CommonTree)this.adaptor.Create(token2);
					this.adaptor.AddChild(commonTree, child2);
					value_return.value = new ValueExpression(this.extractString((token2 != null) ? token2.Text : null));
					goto IL_37D;
				}
				case 4:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken token3 = (IToken)this.Match(this.input, 7, NCalcParser.FOLLOW_DATETIME_in_value901);
					CommonTree child3 = (CommonTree)this.adaptor.Create(token3);
					this.adaptor.AddChild(commonTree, child3);
					value_return.value = new ValueExpression(DateTime.Parse(((token3 != null) ? token3.Text : null).Substring(1, ((token3 != null) ? token3.Text : null).Length - 2)));
					goto IL_37D;
				}
				case 5:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken payload = (IToken)this.Match(this.input, 8, NCalcParser.FOLLOW_TRUE_in_value908);
					CommonTree child4 = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child4);
					value_return.value = new ValueExpression(true);
					goto IL_37D;
				}
				case 6:
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken payload2 = (IToken)this.Match(this.input, 9, NCalcParser.FOLLOW_FALSE_in_value916);
					CommonTree child5 = (CommonTree)this.adaptor.Create(payload2);
					this.adaptor.AddChild(commonTree, child5);
					value_return.value = new ValueExpression(false);
					goto IL_37D;
				}
				default:
					goto IL_37D;
				}
				commonTree = (CommonTree)this.adaptor.GetNilNode();
				IToken token4 = (IToken)this.Match(this.input, 5, NCalcParser.FOLLOW_FLOAT_in_value884);
				CommonTree child6 = (CommonTree)this.adaptor.Create(token4);
				this.adaptor.AddChild(commonTree, child6);
				value_return.value = new ValueExpression(double.Parse((token4 != null) ? token4.Text : null, NumberStyles.Float, NCalcParser.numberFormatInfo));
				IL_37D:
				value_return.Stop = this.input.LT(-1);
				value_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(value_return.Tree, (IToken)value_return.Start, (IToken)value_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				value_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)value_return.Start, this.input.LT(-1), ex);
			}
			return value_return;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00018AC0 File Offset: 0x00016CC0
		public NCalcParser.identifier_return identifier()
		{
			NCalcParser.identifier_return identifier_return = new NCalcParser.identifier_return();
			identifier_return.Start = this.input.LT(1);
			CommonTree commonTree = null;
			try
			{
				int num = this.input.LA(1);
				int num2;
				if (num == 10)
				{
					num2 = 1;
				}
				else
				{
					if (num != 11)
					{
						throw new NoViableAltException("", 21, 0, this.input);
					}
					num2 = 2;
				}
				if (num2 != 1)
				{
					if (num2 == 2)
					{
						commonTree = (CommonTree)this.adaptor.GetNilNode();
						IToken token = (IToken)this.Match(this.input, 11, NCalcParser.FOLLOW_NAME_in_identifier942);
						CommonTree child = (CommonTree)this.adaptor.Create(token);
						this.adaptor.AddChild(commonTree, child);
						identifier_return.value = new IdentifierExpression(((token != null) ? token.Text : null).Substring(1, ((token != null) ? token.Text : null).Length - 2));
					}
				}
				else
				{
					commonTree = (CommonTree)this.adaptor.GetNilNode();
					IToken token2 = (IToken)this.Match(this.input, 10, NCalcParser.FOLLOW_ID_in_identifier934);
					CommonTree child2 = (CommonTree)this.adaptor.Create(token2);
					this.adaptor.AddChild(commonTree, child2);
					identifier_return.value = new IdentifierExpression((token2 != null) ? token2.Text : null);
				}
				identifier_return.Stop = this.input.LT(-1);
				identifier_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(identifier_return.Tree, (IToken)identifier_return.Start, (IToken)identifier_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				identifier_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)identifier_return.Start, this.input.LT(-1), ex);
			}
			return identifier_return;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00018CD8 File Offset: 0x00016ED8
		public NCalcParser.expressionList_return expressionList()
		{
			NCalcParser.expressionList_return expressionList_return = new NCalcParser.expressionList_return();
			expressionList_return.Start = this.input.LT(1);
			List<LogicalExpression> list = new List<LogicalExpression>();
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				base.PushFollow(NCalcParser.FOLLOW_logicalExpression_in_expressionList966);
				NCalcParser.logicalExpression_return logicalExpression_return = this.logicalExpression();
				this.state.followingStackPointer--;
				this.adaptor.AddChild(commonTree, logicalExpression_return.Tree);
				list.Add((logicalExpression_return != null) ? logicalExpression_return.value : null);
				for (;;)
				{
					int num = 2;
					if (this.input.LA(1) == 48)
					{
						num = 1;
					}
					if (num != 1)
					{
						break;
					}
					IToken payload = (IToken)this.Match(this.input, 48, NCalcParser.FOLLOW_48_in_expressionList973);
					CommonTree child = (CommonTree)this.adaptor.Create(payload);
					this.adaptor.AddChild(commonTree, child);
					base.PushFollow(NCalcParser.FOLLOW_logicalExpression_in_expressionList977);
					NCalcParser.logicalExpression_return logicalExpression_return2 = this.logicalExpression();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, logicalExpression_return2.Tree);
					list.Add((logicalExpression_return2 != null) ? logicalExpression_return2.value : null);
				}
				expressionList_return.value = list;
				expressionList_return.Stop = this.input.LT(-1);
				expressionList_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(expressionList_return.Tree, (IToken)expressionList_return.Start, (IToken)expressionList_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				expressionList_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)expressionList_return.Start, this.input.LT(-1), ex);
			}
			return expressionList_return;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00018EDC File Offset: 0x000170DC
		public NCalcParser.arguments_return arguments()
		{
			NCalcParser.arguments_return arguments_return = new NCalcParser.arguments_return();
			arguments_return.Start = this.input.LT(1);
			arguments_return.value = new List<LogicalExpression>();
			try
			{
				CommonTree commonTree = (CommonTree)this.adaptor.GetNilNode();
				IToken payload = (IToken)this.Match(this.input, 46, NCalcParser.FOLLOW_46_in_arguments1006);
				CommonTree child = (CommonTree)this.adaptor.Create(payload);
				this.adaptor.AddChild(commonTree, child);
				int num = 2;
				int num2 = this.input.LA(1);
				if ((num2 >= 4 && num2 <= 11) || num2 == 39 || (num2 >= 43 && num2 <= 46))
				{
					num = 1;
				}
				if (num == 1)
				{
					base.PushFollow(NCalcParser.FOLLOW_expressionList_in_arguments1010);
					NCalcParser.expressionList_return expressionList_return = this.expressionList();
					this.state.followingStackPointer--;
					this.adaptor.AddChild(commonTree, expressionList_return.Tree);
					arguments_return.value = ((expressionList_return != null) ? expressionList_return.value : null);
				}
				IToken payload2 = (IToken)this.Match(this.input, 47, NCalcParser.FOLLOW_47_in_arguments1017);
				CommonTree child2 = (CommonTree)this.adaptor.Create(payload2);
				this.adaptor.AddChild(commonTree, child2);
				arguments_return.Stop = this.input.LT(-1);
				arguments_return.Tree = (CommonTree)this.adaptor.RulePostProcessing(commonTree);
				this.adaptor.SetTokenBoundaries(arguments_return.Tree, (IToken)arguments_return.Start, (IToken)arguments_return.Stop);
			}
			catch (RecognitionException ex)
			{
				this.ReportError(ex);
				this.Recover(this.input, ex);
				arguments_return.Tree = (CommonTree)this.adaptor.ErrorNode(this.input, (IToken)arguments_return.Start, this.input.LT(-1), ex);
			}
			return arguments_return;
		}

		// Token: 0x040002A9 RID: 681
		protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

		// Token: 0x040002AB RID: 683
		public const int T__29 = 29;

		// Token: 0x040002AC RID: 684
		public const int T__28 = 28;

		// Token: 0x040002AD RID: 685
		public const int T__27 = 27;

		// Token: 0x040002AE RID: 686
		public const int T__26 = 26;

		// Token: 0x040002AF RID: 687
		public const int T__25 = 25;

		// Token: 0x040002B0 RID: 688
		public const int T__24 = 24;

		// Token: 0x040002B1 RID: 689
		public const int T__23 = 23;

		// Token: 0x040002B2 RID: 690
		public const int LETTER = 12;

		// Token: 0x040002B3 RID: 691
		public const int T__22 = 22;

		// Token: 0x040002B4 RID: 692
		public const int T__21 = 21;

		// Token: 0x040002B5 RID: 693
		public const int T__20 = 20;

		// Token: 0x040002B6 RID: 694
		public const int FLOAT = 5;

		// Token: 0x040002B7 RID: 695
		public const int ID = 10;

		// Token: 0x040002B8 RID: 696
		public const int EOF = -1;

		// Token: 0x040002B9 RID: 697
		public const int HexDigit = 17;

		// Token: 0x040002BA RID: 698
		public const int T__19 = 19;

		// Token: 0x040002BB RID: 699
		public const int NAME = 11;

		// Token: 0x040002BC RID: 700
		public const int DIGIT = 13;

		// Token: 0x040002BD RID: 701
		public const int T__42 = 42;

		// Token: 0x040002BE RID: 702
		public const int INTEGER = 4;

		// Token: 0x040002BF RID: 703
		public const int E = 14;

		// Token: 0x040002C0 RID: 704
		public const int T__43 = 43;

		// Token: 0x040002C1 RID: 705
		public const int T__40 = 40;

		// Token: 0x040002C2 RID: 706
		public const int T__41 = 41;

		// Token: 0x040002C3 RID: 707
		public const int T__46 = 46;

		// Token: 0x040002C4 RID: 708
		public const int T__47 = 47;

		// Token: 0x040002C5 RID: 709
		public const int T__44 = 44;

		// Token: 0x040002C6 RID: 710
		public const int T__45 = 45;

		// Token: 0x040002C7 RID: 711
		public const int T__48 = 48;

		// Token: 0x040002C8 RID: 712
		public const int DATETIME = 7;

		// Token: 0x040002C9 RID: 713
		public const int TRUE = 8;

		// Token: 0x040002CA RID: 714
		public const int T__30 = 30;

		// Token: 0x040002CB RID: 715
		public const int T__31 = 31;

		// Token: 0x040002CC RID: 716
		public const int T__32 = 32;

		// Token: 0x040002CD RID: 717
		public const int WS = 18;

		// Token: 0x040002CE RID: 718
		public const int T__33 = 33;

		// Token: 0x040002CF RID: 719
		public const int T__34 = 34;

		// Token: 0x040002D0 RID: 720
		public const int T__35 = 35;

		// Token: 0x040002D1 RID: 721
		public const int T__36 = 36;

		// Token: 0x040002D2 RID: 722
		public const int T__37 = 37;

		// Token: 0x040002D3 RID: 723
		public const int T__38 = 38;

		// Token: 0x040002D4 RID: 724
		public const int T__39 = 39;

		// Token: 0x040002D5 RID: 725
		public const int UnicodeEscape = 16;

		// Token: 0x040002D6 RID: 726
		public const int FALSE = 9;

		// Token: 0x040002D7 RID: 727
		public const int EscapeSequence = 15;

		// Token: 0x040002D8 RID: 728
		public const int STRING = 6;

		// Token: 0x040002D9 RID: 729
		private const char BS = '\\';

		// Token: 0x040002DA RID: 730
		public static readonly string[] tokenNames = new string[]
		{
			"<invalid>",
			"<EOR>",
			"<DOWN>",
			"<UP>",
			"INTEGER",
			"FLOAT",
			"STRING",
			"DATETIME",
			"TRUE",
			"FALSE",
			"ID",
			"NAME",
			"LETTER",
			"DIGIT",
			"E",
			"EscapeSequence",
			"UnicodeEscape",
			"HexDigit",
			"WS",
			"'?'",
			"':'",
			"'||'",
			"'or'",
			"'&&'",
			"'and'",
			"'|'",
			"'^'",
			"'&'",
			"'=='",
			"'='",
			"'!='",
			"'<>'",
			"'<'",
			"'<='",
			"'>'",
			"'>='",
			"'<<'",
			"'>>'",
			"'+'",
			"'-'",
			"'*'",
			"'/'",
			"'%'",
			"'!'",
			"'not'",
			"'~'",
			"'('",
			"')'",
			"','"
		};

		// Token: 0x040002DB RID: 731
		private static NumberFormatInfo numberFormatInfo = new NumberFormatInfo();

		// Token: 0x040002DC RID: 732
		public static readonly BitSet FOLLOW_logicalExpression_in_ncalcExpression56 = new BitSet(new ulong[1]);

		// Token: 0x040002DD RID: 733
		public static readonly BitSet FOLLOW_EOF_in_ncalcExpression58 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040002DE RID: 734
		public static readonly BitSet FOLLOW_conditionalExpression_in_logicalExpression78 = new BitSet(new ulong[]
		{
			524290UL
		});

		// Token: 0x040002DF RID: 735
		public static readonly BitSet FOLLOW_19_in_logicalExpression84 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002E0 RID: 736
		public static readonly BitSet FOLLOW_conditionalExpression_in_logicalExpression88 = new BitSet(new ulong[]
		{
			1048576UL
		});

		// Token: 0x040002E1 RID: 737
		public static readonly BitSet FOLLOW_20_in_logicalExpression90 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002E2 RID: 738
		public static readonly BitSet FOLLOW_conditionalExpression_in_logicalExpression94 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x040002E3 RID: 739
		public static readonly BitSet FOLLOW_booleanAndExpression_in_conditionalExpression121 = new BitSet(new ulong[]
		{
			6291458UL
		});

		// Token: 0x040002E4 RID: 740
		public static readonly BitSet FOLLOW_set_in_conditionalExpression130 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002E5 RID: 741
		public static readonly BitSet FOLLOW_conditionalExpression_in_conditionalExpression146 = new BitSet(new ulong[]
		{
			6291458UL
		});

		// Token: 0x040002E6 RID: 742
		public static readonly BitSet FOLLOW_bitwiseOrExpression_in_booleanAndExpression180 = new BitSet(new ulong[]
		{
			25165826UL
		});

		// Token: 0x040002E7 RID: 743
		public static readonly BitSet FOLLOW_set_in_booleanAndExpression189 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002E8 RID: 744
		public static readonly BitSet FOLLOW_bitwiseOrExpression_in_booleanAndExpression205 = new BitSet(new ulong[]
		{
			25165826UL
		});

		// Token: 0x040002E9 RID: 745
		public static readonly BitSet FOLLOW_bitwiseXOrExpression_in_bitwiseOrExpression237 = new BitSet(new ulong[]
		{
			33554434UL
		});

		// Token: 0x040002EA RID: 746
		public static readonly BitSet FOLLOW_25_in_bitwiseOrExpression246 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002EB RID: 747
		public static readonly BitSet FOLLOW_bitwiseOrExpression_in_bitwiseOrExpression256 = new BitSet(new ulong[]
		{
			33554434UL
		});

		// Token: 0x040002EC RID: 748
		public static readonly BitSet FOLLOW_bitwiseAndExpression_in_bitwiseXOrExpression290 = new BitSet(new ulong[]
		{
			67108866UL
		});

		// Token: 0x040002ED RID: 749
		public static readonly BitSet FOLLOW_26_in_bitwiseXOrExpression299 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002EE RID: 750
		public static readonly BitSet FOLLOW_bitwiseAndExpression_in_bitwiseXOrExpression309 = new BitSet(new ulong[]
		{
			67108866UL
		});

		// Token: 0x040002EF RID: 751
		public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseAndExpression341 = new BitSet(new ulong[]
		{
			134217730UL
		});

		// Token: 0x040002F0 RID: 752
		public static readonly BitSet FOLLOW_27_in_bitwiseAndExpression350 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002F1 RID: 753
		public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseAndExpression360 = new BitSet(new ulong[]
		{
			134217730UL
		});

		// Token: 0x040002F2 RID: 754
		public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression394 = new BitSet(new ulong[]
		{
			(ulong)-268435454
		});

		// Token: 0x040002F3 RID: 755
		public static readonly BitSet FOLLOW_set_in_equalityExpression405 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002F4 RID: 756
		public static readonly BitSet FOLLOW_set_in_equalityExpression422 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002F5 RID: 757
		public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression441 = new BitSet(new ulong[]
		{
			(ulong)-268435454
		});

		// Token: 0x040002F6 RID: 758
		public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression474 = new BitSet(new ulong[]
		{
			64424509442UL
		});

		// Token: 0x040002F7 RID: 759
		public static readonly BitSet FOLLOW_32_in_relationalExpression485 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002F8 RID: 760
		public static readonly BitSet FOLLOW_33_in_relationalExpression495 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002F9 RID: 761
		public static readonly BitSet FOLLOW_34_in_relationalExpression506 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002FA RID: 762
		public static readonly BitSet FOLLOW_35_in_relationalExpression516 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002FB RID: 763
		public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression528 = new BitSet(new ulong[]
		{
			64424509442UL
		});

		// Token: 0x040002FC RID: 764
		public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression560 = new BitSet(new ulong[]
		{
			206158430210UL
		});

		// Token: 0x040002FD RID: 765
		public static readonly BitSet FOLLOW_36_in_shiftExpression571 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002FE RID: 766
		public static readonly BitSet FOLLOW_37_in_shiftExpression581 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x040002FF RID: 767
		public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression593 = new BitSet(new ulong[]
		{
			206158430210UL
		});

		// Token: 0x04000300 RID: 768
		public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression625 = new BitSet(new ulong[]
		{
			824633720834UL
		});

		// Token: 0x04000301 RID: 769
		public static readonly BitSet FOLLOW_38_in_additiveExpression636 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000302 RID: 770
		public static readonly BitSet FOLLOW_39_in_additiveExpression646 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000303 RID: 771
		public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression658 = new BitSet(new ulong[]
		{
			824633720834UL
		});

		// Token: 0x04000304 RID: 772
		public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression690 = new BitSet(new ulong[]
		{
			7696581394434UL
		});

		// Token: 0x04000305 RID: 773
		public static readonly BitSet FOLLOW_40_in_multiplicativeExpression701 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000306 RID: 774
		public static readonly BitSet FOLLOW_41_in_multiplicativeExpression711 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000307 RID: 775
		public static readonly BitSet FOLLOW_42_in_multiplicativeExpression721 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000308 RID: 776
		public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression733 = new BitSet(new ulong[]
		{
			7696581394434UL
		});

		// Token: 0x04000309 RID: 777
		public static readonly BitSet FOLLOW_primaryExpression_in_unaryExpression760 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400030A RID: 778
		public static readonly BitSet FOLLOW_set_in_unaryExpression771 = new BitSet(new ulong[]
		{
			70368744181744UL
		});

		// Token: 0x0400030B RID: 779
		public static readonly BitSet FOLLOW_primaryExpression_in_unaryExpression779 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400030C RID: 780
		public static readonly BitSet FOLLOW_45_in_unaryExpression791 = new BitSet(new ulong[]
		{
			70368744181744UL
		});

		// Token: 0x0400030D RID: 781
		public static readonly BitSet FOLLOW_primaryExpression_in_unaryExpression794 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400030E RID: 782
		public static readonly BitSet FOLLOW_39_in_unaryExpression805 = new BitSet(new ulong[]
		{
			70368744181744UL
		});

		// Token: 0x0400030F RID: 783
		public static readonly BitSet FOLLOW_primaryExpression_in_unaryExpression807 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000310 RID: 784
		public static readonly BitSet FOLLOW_46_in_primaryExpression829 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000311 RID: 785
		public static readonly BitSet FOLLOW_logicalExpression_in_primaryExpression831 = new BitSet(new ulong[]
		{
			140737488355328UL
		});

		// Token: 0x04000312 RID: 786
		public static readonly BitSet FOLLOW_47_in_primaryExpression833 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000313 RID: 787
		public static readonly BitSet FOLLOW_value_in_primaryExpression843 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000314 RID: 788
		public static readonly BitSet FOLLOW_identifier_in_primaryExpression851 = new BitSet(new ulong[]
		{
			70368744177666UL
		});

		// Token: 0x04000315 RID: 789
		public static readonly BitSet FOLLOW_arguments_in_primaryExpression856 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000316 RID: 790
		public static readonly BitSet FOLLOW_INTEGER_in_value876 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000317 RID: 791
		public static readonly BitSet FOLLOW_FLOAT_in_value884 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000318 RID: 792
		public static readonly BitSet FOLLOW_STRING_in_value892 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x04000319 RID: 793
		public static readonly BitSet FOLLOW_DATETIME_in_value901 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400031A RID: 794
		public static readonly BitSet FOLLOW_TRUE_in_value908 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400031B RID: 795
		public static readonly BitSet FOLLOW_FALSE_in_value916 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400031C RID: 796
		public static readonly BitSet FOLLOW_ID_in_identifier934 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400031D RID: 797
		public static readonly BitSet FOLLOW_NAME_in_identifier942 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x0400031E RID: 798
		public static readonly BitSet FOLLOW_logicalExpression_in_expressionList966 = new BitSet(new ulong[]
		{
			281474976710658UL
		});

		// Token: 0x0400031F RID: 799
		public static readonly BitSet FOLLOW_48_in_expressionList973 = new BitSet(new ulong[]
		{
			132491151151088UL
		});

		// Token: 0x04000320 RID: 800
		public static readonly BitSet FOLLOW_logicalExpression_in_expressionList977 = new BitSet(new ulong[]
		{
			281474976710658UL
		});

		// Token: 0x04000321 RID: 801
		public static readonly BitSet FOLLOW_46_in_arguments1006 = new BitSet(new ulong[]
		{
			273228639506416UL
		});

		// Token: 0x04000322 RID: 802
		public static readonly BitSet FOLLOW_expressionList_in_arguments1010 = new BitSet(new ulong[]
		{
			140737488355328UL
		});

		// Token: 0x04000323 RID: 803
		public static readonly BitSet FOLLOW_47_in_arguments1017 = new BitSet(new ulong[]
		{
			2UL
		});

		// Token: 0x020001E9 RID: 489
		public class ncalcExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E0 RID: 992
			// (get) Token: 0x06000C84 RID: 3204 RVA: 0x0001C42A File Offset: 0x0001A62A
			// (set) Token: 0x06000C85 RID: 3205 RVA: 0x0001C432 File Offset: 0x0001A632
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400042B RID: 1067
			public LogicalExpression value;

			// Token: 0x0400042C RID: 1068
			private CommonTree tree;
		}

		// Token: 0x020001EA RID: 490
		public class logicalExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E1 RID: 993
			// (get) Token: 0x06000C87 RID: 3207 RVA: 0x0001C448 File Offset: 0x0001A648
			// (set) Token: 0x06000C88 RID: 3208 RVA: 0x0001C450 File Offset: 0x0001A650
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400042D RID: 1069
			public LogicalExpression value;

			// Token: 0x0400042E RID: 1070
			private CommonTree tree;
		}

		// Token: 0x020001EB RID: 491
		public class conditionalExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E2 RID: 994
			// (get) Token: 0x06000C8A RID: 3210 RVA: 0x0001C466 File Offset: 0x0001A666
			// (set) Token: 0x06000C8B RID: 3211 RVA: 0x0001C46E File Offset: 0x0001A66E
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400042F RID: 1071
			public LogicalExpression value;

			// Token: 0x04000430 RID: 1072
			private CommonTree tree;
		}

		// Token: 0x020001EC RID: 492
		public class booleanAndExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E3 RID: 995
			// (get) Token: 0x06000C8D RID: 3213 RVA: 0x0001C484 File Offset: 0x0001A684
			// (set) Token: 0x06000C8E RID: 3214 RVA: 0x0001C48C File Offset: 0x0001A68C
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000431 RID: 1073
			public LogicalExpression value;

			// Token: 0x04000432 RID: 1074
			private CommonTree tree;
		}

		// Token: 0x020001ED RID: 493
		public class bitwiseOrExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E4 RID: 996
			// (get) Token: 0x06000C90 RID: 3216 RVA: 0x0001C4A2 File Offset: 0x0001A6A2
			// (set) Token: 0x06000C91 RID: 3217 RVA: 0x0001C4AA File Offset: 0x0001A6AA
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000433 RID: 1075
			public LogicalExpression value;

			// Token: 0x04000434 RID: 1076
			private CommonTree tree;
		}

		// Token: 0x020001EE RID: 494
		public class bitwiseXOrExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E5 RID: 997
			// (get) Token: 0x06000C93 RID: 3219 RVA: 0x0001C4C0 File Offset: 0x0001A6C0
			// (set) Token: 0x06000C94 RID: 3220 RVA: 0x0001C4C8 File Offset: 0x0001A6C8
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000435 RID: 1077
			public LogicalExpression value;

			// Token: 0x04000436 RID: 1078
			private CommonTree tree;
		}

		// Token: 0x020001EF RID: 495
		public class bitwiseAndExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E6 RID: 998
			// (get) Token: 0x06000C96 RID: 3222 RVA: 0x0001C4DE File Offset: 0x0001A6DE
			// (set) Token: 0x06000C97 RID: 3223 RVA: 0x0001C4E6 File Offset: 0x0001A6E6
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000437 RID: 1079
			public LogicalExpression value;

			// Token: 0x04000438 RID: 1080
			private CommonTree tree;
		}

		// Token: 0x020001F0 RID: 496
		public class equalityExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E7 RID: 999
			// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0001C4FC File Offset: 0x0001A6FC
			// (set) Token: 0x06000C9A RID: 3226 RVA: 0x0001C504 File Offset: 0x0001A704
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000439 RID: 1081
			public LogicalExpression value;

			// Token: 0x0400043A RID: 1082
			private CommonTree tree;
		}

		// Token: 0x020001F1 RID: 497
		public class relationalExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E8 RID: 1000
			// (get) Token: 0x06000C9C RID: 3228 RVA: 0x0001C51A File Offset: 0x0001A71A
			// (set) Token: 0x06000C9D RID: 3229 RVA: 0x0001C522 File Offset: 0x0001A722
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400043B RID: 1083
			public LogicalExpression value;

			// Token: 0x0400043C RID: 1084
			private CommonTree tree;
		}

		// Token: 0x020001F2 RID: 498
		public class shiftExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003E9 RID: 1001
			// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0001C538 File Offset: 0x0001A738
			// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x0001C540 File Offset: 0x0001A740
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400043D RID: 1085
			public LogicalExpression value;

			// Token: 0x0400043E RID: 1086
			private CommonTree tree;
		}

		// Token: 0x020001F3 RID: 499
		public class additiveExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003EA RID: 1002
			// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x0001C556 File Offset: 0x0001A756
			// (set) Token: 0x06000CA3 RID: 3235 RVA: 0x0001C55E File Offset: 0x0001A75E
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400043F RID: 1087
			public LogicalExpression value;

			// Token: 0x04000440 RID: 1088
			private CommonTree tree;
		}

		// Token: 0x020001F4 RID: 500
		public class multiplicativeExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003EB RID: 1003
			// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0001C574 File Offset: 0x0001A774
			// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x0001C57C File Offset: 0x0001A77C
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000441 RID: 1089
			public LogicalExpression value;

			// Token: 0x04000442 RID: 1090
			private CommonTree tree;
		}

		// Token: 0x020001F5 RID: 501
		public class unaryExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003EC RID: 1004
			// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x0001C592 File Offset: 0x0001A792
			// (set) Token: 0x06000CA9 RID: 3241 RVA: 0x0001C59A File Offset: 0x0001A79A
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000443 RID: 1091
			public LogicalExpression value;

			// Token: 0x04000444 RID: 1092
			private CommonTree tree;
		}

		// Token: 0x020001F6 RID: 502
		public class primaryExpression_return : ParserRuleReturnScope
		{
			// Token: 0x170003ED RID: 1005
			// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0001C5B0 File Offset: 0x0001A7B0
			// (set) Token: 0x06000CAC RID: 3244 RVA: 0x0001C5B8 File Offset: 0x0001A7B8
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000445 RID: 1093
			public LogicalExpression value;

			// Token: 0x04000446 RID: 1094
			private CommonTree tree;
		}

		// Token: 0x020001F7 RID: 503
		public class value_return : ParserRuleReturnScope
		{
			// Token: 0x170003EE RID: 1006
			// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0001C5CE File Offset: 0x0001A7CE
			// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0001C5D6 File Offset: 0x0001A7D6
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000447 RID: 1095
			public ValueExpression value;

			// Token: 0x04000448 RID: 1096
			private CommonTree tree;
		}

		// Token: 0x020001F8 RID: 504
		public class identifier_return : ParserRuleReturnScope
		{
			// Token: 0x170003EF RID: 1007
			// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x0001C5EC File Offset: 0x0001A7EC
			// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x04000449 RID: 1097
			public IdentifierExpression value;

			// Token: 0x0400044A RID: 1098
			private CommonTree tree;
		}

		// Token: 0x020001F9 RID: 505
		public class expressionList_return : ParserRuleReturnScope
		{
			// Token: 0x170003F0 RID: 1008
			// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0001C60A File Offset: 0x0001A80A
			// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x0001C612 File Offset: 0x0001A812
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400044B RID: 1099
			public List<LogicalExpression> value;

			// Token: 0x0400044C RID: 1100
			private CommonTree tree;
		}

		// Token: 0x020001FA RID: 506
		public class arguments_return : ParserRuleReturnScope
		{
			// Token: 0x170003F1 RID: 1009
			// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x0001C628 File Offset: 0x0001A828
			// (set) Token: 0x06000CB8 RID: 3256 RVA: 0x0001C630 File Offset: 0x0001A830
			public override object Tree
			{
				get
				{
					return this.tree;
				}
				set
				{
					this.tree = (CommonTree)value;
				}
			}

			// Token: 0x0400044D RID: 1101
			public List<LogicalExpression> value;

			// Token: 0x0400044E RID: 1102
			private CommonTree tree;
		}
	}
}
