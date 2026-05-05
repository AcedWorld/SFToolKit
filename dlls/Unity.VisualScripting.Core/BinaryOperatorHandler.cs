using System;
using System.Collections.Generic;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000DE RID: 222
	public abstract class BinaryOperatorHandler : OperatorHandler
	{
		// Token: 0x06000626 RID: 1574 RVA: 0x000115C9 File Offset: 0x0000F7C9
		protected BinaryOperatorHandler(string name, string verb, string symbol, string customMethodName) : base(name, verb, symbol, customMethodName)
		{
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000115F8 File Offset: 0x0000F7F8
		public virtual object Operate(object leftOperand, object rightOperand)
		{
			Type type = (leftOperand != null) ? leftOperand.GetType() : null;
			Type type2 = (rightOperand != null) ? rightOperand.GetType() : null;
			BinaryOperatorHandler.OperatorQuery operatorQuery;
			if (type != null && type2 != null)
			{
				operatorQuery = new BinaryOperatorHandler.OperatorQuery(type, type2);
			}
			else if (type != null && type.IsNullable())
			{
				operatorQuery = new BinaryOperatorHandler.OperatorQuery(type, type);
			}
			else if (type2 != null && type2.IsNullable())
			{
				operatorQuery = new BinaryOperatorHandler.OperatorQuery(type2, type2);
			}
			else
			{
				if (type == null && type2 == null)
				{
					return this.BothNullHandling();
				}
				return this.SingleNullHandling();
			}
			if (this.handlers.ContainsKey(operatorQuery))
			{
				return this.handlers[operatorQuery](leftOperand, rightOperand);
			}
			if (base.customMethodName != null)
			{
				if (!this.userDefinedOperators.ContainsKey(operatorQuery))
				{
					MethodInfo method = operatorQuery.leftType.GetMethod(base.customMethodName, BindingFlags.Static | BindingFlags.Public, null, new Type[]
					{
						operatorQuery.leftType,
						operatorQuery.rightType
					}, null);
					if (operatorQuery.leftType != operatorQuery.rightType)
					{
						MethodInfo method2 = operatorQuery.rightType.GetMethod(base.customMethodName, BindingFlags.Static | BindingFlags.Public, null, new Type[]
						{
							operatorQuery.leftType,
							operatorQuery.rightType
						}, null);
						if (method != null && method2 != null)
						{
							throw new AmbiguousOperatorException(base.symbol, operatorQuery.leftType, operatorQuery.rightType);
						}
						MethodInfo methodInfo = method ?? method2;
						if (methodInfo != null)
						{
							this.userDefinedOperandTypes.Add(operatorQuery, BinaryOperatorHandler.ResolveUserDefinedOperandTypes(methodInfo));
						}
						this.userDefinedOperators.Add(operatorQuery, (methodInfo != null) ? methodInfo.Prewarm() : null);
					}
					else
					{
						if (method != null)
						{
							this.userDefinedOperandTypes.Add(operatorQuery, BinaryOperatorHandler.ResolveUserDefinedOperandTypes(method));
						}
						this.userDefinedOperators.Add(operatorQuery, (method != null) ? method.Prewarm() : null);
					}
				}
				if (this.userDefinedOperators[operatorQuery] != null)
				{
					leftOperand = ConversionUtility.Convert(leftOperand, this.userDefinedOperandTypes[operatorQuery].leftType);
					rightOperand = ConversionUtility.Convert(rightOperand, this.userDefinedOperandTypes[operatorQuery].rightType);
					return this.userDefinedOperators[operatorQuery].Invoke(null, leftOperand, rightOperand);
				}
			}
			return this.CustomHandling(leftOperand, rightOperand);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00011842 File Offset: 0x0000FA42
		protected virtual object CustomHandling(object leftOperand, object rightOperand)
		{
			throw new InvalidOperatorException(base.symbol, (leftOperand != null) ? leftOperand.GetType() : null, (rightOperand != null) ? rightOperand.GetType() : null);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00011867 File Offset: 0x0000FA67
		protected virtual object BothNullHandling()
		{
			throw new InvalidOperatorException(base.symbol, null, null);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00011876 File Offset: 0x0000FA76
		protected virtual object SingleNullHandling()
		{
			throw new InvalidOperatorException(base.symbol, null, null);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00011888 File Offset: 0x0000FA88
		protected void Handle<TLeft, TRight>(Func<TLeft, TRight, object> handler, bool reverse = false)
		{
			BinaryOperatorHandler.OperatorQuery key = new BinaryOperatorHandler.OperatorQuery(typeof(TLeft), typeof(TRight));
			if (this.handlers.ContainsKey(key))
			{
				throw new ArgumentException(string.Format("A handler is already registered for '{0} {1} {2}'.", typeof(TLeft), base.symbol, typeof(TRight)));
			}
			this.handlers.Add(key, (object left, object right) => handler((TLeft)((object)left), (TRight)((object)right)));
			if (reverse && typeof(TLeft) != typeof(TRight))
			{
				BinaryOperatorHandler.OperatorQuery key2 = new BinaryOperatorHandler.OperatorQuery(typeof(TRight), typeof(TLeft));
				if (!this.handlers.ContainsKey(key2))
				{
					this.handlers.Add(key2, (object left, object right) => handler((TLeft)((object)left), (TRight)((object)right)));
				}
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001196C File Offset: 0x0000FB6C
		private static BinaryOperatorHandler.OperatorQuery ResolveUserDefinedOperandTypes(MethodInfo userDefinedOperator)
		{
			ParameterInfo[] parameters = userDefinedOperator.GetParameters();
			return new BinaryOperatorHandler.OperatorQuery(parameters[0].ParameterType, parameters[1].ParameterType);
		}

		// Token: 0x0400016E RID: 366
		private readonly Dictionary<BinaryOperatorHandler.OperatorQuery, Func<object, object, object>> handlers = new Dictionary<BinaryOperatorHandler.OperatorQuery, Func<object, object, object>>();

		// Token: 0x0400016F RID: 367
		private readonly Dictionary<BinaryOperatorHandler.OperatorQuery, IOptimizedInvoker> userDefinedOperators = new Dictionary<BinaryOperatorHandler.OperatorQuery, IOptimizedInvoker>();

		// Token: 0x04000170 RID: 368
		private readonly Dictionary<BinaryOperatorHandler.OperatorQuery, BinaryOperatorHandler.OperatorQuery> userDefinedOperandTypes = new Dictionary<BinaryOperatorHandler.OperatorQuery, BinaryOperatorHandler.OperatorQuery>();

		// Token: 0x020001E3 RID: 483
		private struct OperatorQuery : IEquatable<BinaryOperatorHandler.OperatorQuery>
		{
			// Token: 0x06000D14 RID: 3348 RVA: 0x000337CD File Offset: 0x000319CD
			public OperatorQuery(Type leftType, Type rightType)
			{
				this.leftType = leftType;
				this.rightType = rightType;
			}

			// Token: 0x06000D15 RID: 3349 RVA: 0x000337DD File Offset: 0x000319DD
			public bool Equals(BinaryOperatorHandler.OperatorQuery other)
			{
				return this.leftType == other.leftType && this.rightType == other.rightType;
			}

			// Token: 0x06000D16 RID: 3350 RVA: 0x00033805 File Offset: 0x00031A05
			public override bool Equals(object obj)
			{
				return obj is BinaryOperatorHandler.OperatorQuery && this.Equals((BinaryOperatorHandler.OperatorQuery)obj);
			}

			// Token: 0x06000D17 RID: 3351 RVA: 0x0003381D File Offset: 0x00031A1D
			public override int GetHashCode()
			{
				return HashUtility.GetHashCode<Type, Type>(this.leftType, this.rightType);
			}

			// Token: 0x04000402 RID: 1026
			public readonly Type leftType;

			// Token: 0x04000403 RID: 1027
			public readonly Type rightType;
		}
	}
}
