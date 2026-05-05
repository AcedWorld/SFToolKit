using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UIElements.StyleSheets.Syntax;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x020004A0 RID: 1184
	internal abstract class BaseStyleMatcher
	{
		// Token: 0x060024CF RID: 9423
		protected abstract bool MatchKeyword(string keyword);

		// Token: 0x060024D0 RID: 9424
		protected abstract bool MatchNumber();

		// Token: 0x060024D1 RID: 9425
		protected abstract bool MatchInteger();

		// Token: 0x060024D2 RID: 9426
		protected abstract bool MatchLength();

		// Token: 0x060024D3 RID: 9427
		protected abstract bool MatchPercentage();

		// Token: 0x060024D4 RID: 9428
		protected abstract bool MatchColor();

		// Token: 0x060024D5 RID: 9429
		protected abstract bool MatchResource();

		// Token: 0x060024D6 RID: 9430
		protected abstract bool MatchUrl();

		// Token: 0x060024D7 RID: 9431
		protected abstract bool MatchTime();

		// Token: 0x060024D8 RID: 9432
		protected abstract bool MatchAngle();

		// Token: 0x060024D9 RID: 9433
		protected abstract bool MatchCustomIdent();

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x060024DA RID: 9434
		public abstract int valueCount { get; }

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x060024DB RID: 9435
		public abstract bool isCurrentVariable { get; }

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x060024DC RID: 9436
		public abstract bool isCurrentComma { get; }

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x060024DD RID: 9437 RVA: 0x0009B343 File Offset: 0x00099543
		public bool hasCurrent
		{
			get
			{
				return this.m_CurrentContext.valueIndex < this.valueCount;
			}
		}

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x060024DE RID: 9438 RVA: 0x0009B358 File Offset: 0x00099558
		// (set) Token: 0x060024DF RID: 9439 RVA: 0x0009B365 File Offset: 0x00099565
		public int currentIndex
		{
			get
			{
				return this.m_CurrentContext.valueIndex;
			}
			set
			{
				this.m_CurrentContext.valueIndex = value;
			}
		}

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x060024E0 RID: 9440 RVA: 0x0009B373 File Offset: 0x00099573
		// (set) Token: 0x060024E1 RID: 9441 RVA: 0x0009B380 File Offset: 0x00099580
		public int matchedVariableCount
		{
			get
			{
				return this.m_CurrentContext.matchedVariableCount;
			}
			set
			{
				this.m_CurrentContext.matchedVariableCount = value;
			}
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x0009B38E File Offset: 0x0009958E
		protected void Initialize()
		{
			this.m_CurrentContext = default(BaseStyleMatcher.MatchContext);
			this.m_ContextStack.Clear();
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x0009B3AC File Offset: 0x000995AC
		public void MoveNext()
		{
			bool flag = this.currentIndex + 1 <= this.valueCount;
			if (flag)
			{
				int currentIndex = this.currentIndex;
				this.currentIndex = currentIndex + 1;
			}
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x0009B3E4 File Offset: 0x000995E4
		public void SaveContext()
		{
			this.m_ContextStack.Push(this.m_CurrentContext);
		}

		// Token: 0x060024E5 RID: 9445 RVA: 0x0009B3F9 File Offset: 0x000995F9
		public void RestoreContext()
		{
			this.m_CurrentContext = this.m_ContextStack.Pop();
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x0009B40D File Offset: 0x0009960D
		public void DropContext()
		{
			this.m_ContextStack.Pop();
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x0009B41C File Offset: 0x0009961C
		protected bool Match(Expression exp)
		{
			bool flag = exp.multiplier.type == ExpressionMultiplierType.None;
			bool result;
			if (flag)
			{
				result = this.MatchExpression(exp);
			}
			else
			{
				Debug.Assert(exp.multiplier.type != ExpressionMultiplierType.GroupAtLeastOne, "'!' multiplier in syntax expression is not supported");
				result = this.MatchExpressionWithMultiplier(exp);
			}
			return result;
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x0009B478 File Offset: 0x00099678
		private bool MatchExpression(Expression exp)
		{
			bool flag = false;
			bool flag2 = exp.type == ExpressionType.Combinator;
			if (flag2)
			{
				flag = this.MatchCombinator(exp);
			}
			else
			{
				bool isCurrentVariable = this.isCurrentVariable;
				if (isCurrentVariable)
				{
					flag = true;
					int matchedVariableCount = this.matchedVariableCount;
					this.matchedVariableCount = matchedVariableCount + 1;
				}
				else
				{
					bool flag3 = exp.type == ExpressionType.Data;
					if (flag3)
					{
						flag = this.MatchDataType(exp);
					}
					else
					{
						bool flag4 = exp.type == ExpressionType.Keyword;
						if (flag4)
						{
							flag = this.MatchKeyword(exp.keyword);
						}
					}
				}
				bool flag5 = flag;
				if (flag5)
				{
					this.MoveNext();
				}
			}
			bool flag6 = !flag && !this.hasCurrent && this.matchedVariableCount > 0;
			if (flag6)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x0009B534 File Offset: 0x00099734
		private bool MatchExpressionWithMultiplier(Expression exp)
		{
			bool flag = exp.multiplier.type == ExpressionMultiplierType.OneOrMoreComma;
			bool flag2 = true;
			int min = exp.multiplier.min;
			int max = exp.multiplier.max;
			int num = 0;
			int num2 = 0;
			while (flag2 && this.hasCurrent && num2 < max)
			{
				flag2 = this.MatchExpression(exp);
				bool flag3 = flag2;
				if (flag3)
				{
					num++;
					bool flag4 = flag;
					if (flag4)
					{
						bool flag5 = !this.isCurrentComma;
						if (flag5)
						{
							break;
						}
						this.MoveNext();
					}
				}
				num2++;
			}
			flag2 = (num >= min && num <= max);
			bool flag6 = !flag2 && num <= max && this.matchedVariableCount > 0;
			if (flag6)
			{
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x0009B600 File Offset: 0x00099800
		private bool MatchGroup(Expression exp)
		{
			Debug.Assert(exp.subExpressions.Length == 1, "Group has invalid number of sub expressions");
			Expression exp2 = exp.subExpressions[0];
			return this.Match(exp2);
		}

		// Token: 0x060024EB RID: 9451 RVA: 0x0009B638 File Offset: 0x00099838
		private bool MatchCombinator(Expression exp)
		{
			this.SaveContext();
			bool flag = false;
			switch (exp.combinator)
			{
			case ExpressionCombinator.Or:
				flag = this.MatchOr(exp);
				break;
			case ExpressionCombinator.OrOr:
				flag = this.MatchOrOr(exp);
				break;
			case ExpressionCombinator.AndAnd:
				flag = this.MatchAndAnd(exp);
				break;
			case ExpressionCombinator.Juxtaposition:
				flag = this.MatchJuxtaposition(exp);
				break;
			case ExpressionCombinator.Group:
				flag = this.MatchGroup(exp);
				break;
			}
			bool flag2 = flag;
			if (flag2)
			{
				this.DropContext();
			}
			else
			{
				this.RestoreContext();
			}
			return flag;
		}

		// Token: 0x060024EC RID: 9452 RVA: 0x0009B6C8 File Offset: 0x000998C8
		private bool MatchOr(Expression exp)
		{
			BaseStyleMatcher.MatchContext currentContext = default(BaseStyleMatcher.MatchContext);
			int num = 0;
			for (int i = 0; i < exp.subExpressions.Length; i++)
			{
				this.SaveContext();
				int currentIndex = this.currentIndex;
				bool flag = this.Match(exp.subExpressions[i]);
				int num2 = this.currentIndex - currentIndex;
				bool flag2 = flag && num2 > num;
				if (flag2)
				{
					num = num2;
					currentContext = this.m_CurrentContext;
				}
				this.RestoreContext();
			}
			bool flag3 = num > 0;
			bool result;
			if (flag3)
			{
				this.m_CurrentContext = currentContext;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060024ED RID: 9453 RVA: 0x0009B768 File Offset: 0x00099968
		private bool MatchOrOr(Expression exp)
		{
			int num = this.MatchMany(exp);
			return num > 0;
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x0009B788 File Offset: 0x00099988
		private bool MatchAndAnd(Expression exp)
		{
			int num = this.MatchMany(exp);
			int num2 = exp.subExpressions.Length;
			return num == num2;
		}

		// Token: 0x060024EF RID: 9455 RVA: 0x0009B7B0 File Offset: 0x000999B0
		private unsafe int MatchMany(Expression exp)
		{
			BaseStyleMatcher.MatchContext currentContext = default(BaseStyleMatcher.MatchContext);
			int num = 0;
			int num2 = -1;
			int num3 = exp.subExpressions.Length;
			int* ptr = stackalloc int[checked(unchecked((UIntPtr)num3) * 4)];
			do
			{
				this.SaveContext();
				num2++;
				for (int i = 0; i < num3; i++)
				{
					int num4 = (num2 > 0) ? ((num2 + i) % num3) : i;
					ptr[i] = num4;
				}
				int num5 = this.MatchManyByOrder(exp, ptr);
				bool flag = num5 > num;
				if (flag)
				{
					num = num5;
					currentContext = this.m_CurrentContext;
				}
				this.RestoreContext();
			}
			while (num < num3 && num2 < num3);
			bool flag2 = num > 0;
			if (flag2)
			{
				this.m_CurrentContext = currentContext;
			}
			return num;
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x0009B870 File Offset: 0x00099A70
		private unsafe int MatchManyByOrder(Expression exp, int* matchOrder)
		{
			int num = exp.subExpressions.Length;
			int* ptr = stackalloc int[checked(unchecked((UIntPtr)num) * 4)];
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			while (num4 < num && num2 + num3 < num)
			{
				int num5 = matchOrder[num4];
				bool flag = false;
				for (int i = 0; i < num2; i++)
				{
					bool flag2 = ptr[i] == num5;
					if (flag2)
					{
						flag = true;
						break;
					}
				}
				bool flag3 = false;
				bool flag4 = !flag;
				if (flag4)
				{
					flag3 = this.Match(exp.subExpressions[num5]);
				}
				bool flag5 = flag3;
				if (flag5)
				{
					bool flag6 = num3 == this.matchedVariableCount;
					if (flag6)
					{
						ptr[num2] = num5;
						num2++;
					}
					else
					{
						num3 = this.matchedVariableCount;
					}
					num4 = 0;
				}
				else
				{
					num4++;
				}
			}
			return num2 + num3;
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x0009B95C File Offset: 0x00099B5C
		private bool MatchJuxtaposition(Expression exp)
		{
			bool flag = true;
			int num = 0;
			while (flag && num < exp.subExpressions.Length)
			{
				flag = this.Match(exp.subExpressions[num]);
				num++;
			}
			return flag;
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x0009B9A0 File Offset: 0x00099BA0
		private bool MatchDataType(Expression exp)
		{
			bool result = false;
			bool hasCurrent = this.hasCurrent;
			if (hasCurrent)
			{
				switch (exp.dataType)
				{
				case DataType.Number:
					result = this.MatchNumber();
					break;
				case DataType.Integer:
					result = this.MatchInteger();
					break;
				case DataType.Length:
					result = this.MatchLength();
					break;
				case DataType.Percentage:
					result = this.MatchPercentage();
					break;
				case DataType.Color:
					result = this.MatchColor();
					break;
				case DataType.Resource:
					result = this.MatchResource();
					break;
				case DataType.Url:
					result = this.MatchUrl();
					break;
				case DataType.Time:
					result = this.MatchTime();
					break;
				case DataType.Angle:
					result = this.MatchAngle();
					break;
				case DataType.CustomIdent:
					result = this.MatchCustomIdent();
					break;
				}
			}
			return result;
		}

		// Token: 0x040011C1 RID: 4545
		protected static readonly Regex s_CustomIdentRegex = new Regex("^-?[_a-z][_a-z0-9-]*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		// Token: 0x040011C2 RID: 4546
		private Stack<BaseStyleMatcher.MatchContext> m_ContextStack = new Stack<BaseStyleMatcher.MatchContext>();

		// Token: 0x040011C3 RID: 4547
		private BaseStyleMatcher.MatchContext m_CurrentContext;

		// Token: 0x020004A1 RID: 1185
		private struct MatchContext
		{
			// Token: 0x040011C4 RID: 4548
			public int valueIndex;

			// Token: 0x040011C5 RID: 4549
			public int matchedVariableCount;
		}
	}
}
