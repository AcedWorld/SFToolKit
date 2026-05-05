using System;
using System.Collections.Generic;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000F7 RID: 247
	public abstract class UnaryOperatorHandler : OperatorHandler
	{
		// Token: 0x06000670 RID: 1648 RVA: 0x0001EC95 File Offset: 0x0001CE95
		protected UnaryOperatorHandler(string name, string verb, string symbol, string customMethodName) : base(name, verb, symbol, customMethodName)
		{
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001ECC4 File Offset: 0x0001CEC4
		public object Operate(object operand)
		{
			Ensure.That("operand").IsNotNull<object>(operand);
			Type type = operand.GetType();
			if (this.manualHandlers.ContainsKey(type))
			{
				return this.manualHandlers[type](operand);
			}
			if (base.customMethodName != null)
			{
				if (!this.userDefinedOperators.ContainsKey(type))
				{
					MethodInfo method = type.GetMethod(base.customMethodName, BindingFlags.Static | BindingFlags.Public);
					if (method != null)
					{
						this.userDefinedOperandTypes.Add(type, UnaryOperatorHandler.ResolveUserDefinedOperandType(method));
					}
					this.userDefinedOperators.Add(type, (method != null) ? method.Prewarm() : null);
				}
				if (this.userDefinedOperators[type] != null)
				{
					operand = ConversionUtility.Convert(operand, this.userDefinedOperandTypes[type]);
					return this.userDefinedOperators[type].Invoke(null, operand);
				}
			}
			return this.CustomHandling(operand);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0001EDA1 File Offset: 0x0001CFA1
		protected virtual object CustomHandling(object operand)
		{
			throw new InvalidOperatorException(base.symbol, operand.GetType());
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001EDB4 File Offset: 0x0001CFB4
		protected void Handle<T>(Func<T, object> handler)
		{
			this.manualHandlers.Add(typeof(T), (object operand) => handler((T)((object)operand)));
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0001EDEF File Offset: 0x0001CFEF
		private static Type ResolveUserDefinedOperandType(MethodInfo userDefinedOperator)
		{
			return userDefinedOperator.GetParameters()[0].ParameterType;
		}

		// Token: 0x04000194 RID: 404
		private readonly Dictionary<Type, Func<object, object>> manualHandlers = new Dictionary<Type, Func<object, object>>();

		// Token: 0x04000195 RID: 405
		private readonly Dictionary<Type, IOptimizedInvoker> userDefinedOperators = new Dictionary<Type, IOptimizedInvoker>();

		// Token: 0x04000196 RID: 406
		private readonly Dictionary<Type, Type> userDefinedOperandTypes = new Dictionary<Type, Type>();
	}
}
