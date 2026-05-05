using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x0200018A RID: 394
	public class Expression
	{
		// Token: 0x06000A88 RID: 2696 RVA: 0x00013DD4 File Offset: 0x00011FD4
		private Expression()
		{
			this.Parameters["null"] = (this.Parameters["NULL"] = null);
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00013E0B File Offset: 0x0001200B
		public Expression(string expression, EvaluateOptions options = EvaluateOptions.None) : this()
		{
			if (string.IsNullOrEmpty(expression))
			{
				throw new ArgumentException("Expression can't be empty", "expression");
			}
			expression = expression.Replace('"', '\'');
			this.OriginalExpression = expression;
			this.Options = options;
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00013E45 File Offset: 0x00012045
		public Expression(LogicalExpression expression, EvaluateOptions options = EvaluateOptions.None) : this()
		{
			if (expression == null)
			{
				throw new ArgumentException("Expression can't be null", "expression");
			}
			this.ParsedExpression = expression;
			this.Options = options;
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000A8B RID: 2699 RVA: 0x00013E70 File Offset: 0x00012070
		// (remove) Token: 0x06000A8C RID: 2700 RVA: 0x00013EA8 File Offset: 0x000120A8
		public event EvaluateFunctionHandler EvaluateFunction;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000A8D RID: 2701 RVA: 0x00013EE0 File Offset: 0x000120E0
		// (remove) Token: 0x06000A8E RID: 2702 RVA: 0x00013F18 File Offset: 0x00012118
		public event EvaluateParameterHandler EvaluateParameter;

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x00013F4D File Offset: 0x0001214D
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00013F55 File Offset: 0x00012155
		public EvaluateOptions Options { get; set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x00013F5E File Offset: 0x0001215E
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x00013F66 File Offset: 0x00012166
		public string Error { get; private set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x00013F6F File Offset: 0x0001216F
		// (set) Token: 0x06000A94 RID: 2708 RVA: 0x00013F77 File Offset: 0x00012177
		public LogicalExpression ParsedExpression { get; private set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00013F80 File Offset: 0x00012180
		// (set) Token: 0x06000A96 RID: 2710 RVA: 0x00013FA5 File Offset: 0x000121A5
		public Dictionary<string, object> Parameters
		{
			get
			{
				Dictionary<string, object> result;
				if ((result = this._parameters) == null)
				{
					result = (this._parameters = new Dictionary<string, object>());
				}
				return result;
			}
			set
			{
				this._parameters = value;
			}
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00013FB0 File Offset: 0x000121B0
		public void UpdateUnityTimeParameters()
		{
			this.Parameters["dt"] = (this.Parameters["DT"] = Time.deltaTime);
			this.Parameters["second"] = (this.Parameters["Second"] = 1f / Time.deltaTime);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00014020 File Offset: 0x00012220
		public bool HasErrors()
		{
			bool result;
			try
			{
				if (this.ParsedExpression == null)
				{
					this.ParsedExpression = Expression.Compile(this.OriginalExpression, (this.Options & EvaluateOptions.NoCache) == EvaluateOptions.NoCache);
				}
				result = (this.ParsedExpression != null && this.Error != null);
			}
			catch (Exception ex)
			{
				this.Error = ex.Message;
				result = true;
			}
			return result;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0001408C File Offset: 0x0001228C
		public object Evaluate(Flow flow)
		{
			if (this.HasErrors())
			{
				throw new EvaluationException(this.Error);
			}
			if (this.ParsedExpression == null)
			{
				this.ParsedExpression = Expression.Compile(this.OriginalExpression, (this.Options & EvaluateOptions.NoCache) == EvaluateOptions.NoCache);
			}
			EvaluationVisitor evaluationVisitor = new EvaluationVisitor(flow, this.Options);
			evaluationVisitor.EvaluateFunction += this.EvaluateFunction;
			evaluationVisitor.EvaluateParameter += this.EvaluateParameter;
			evaluationVisitor.Parameters = this.Parameters;
			if ((this.Options & EvaluateOptions.IterateParameters) == EvaluateOptions.IterateParameters)
			{
				int num = -1;
				this.ParameterEnumerators = new Dictionary<string, IEnumerator>();
				foreach (object obj in this.Parameters.Values)
				{
					IEnumerable enumerable = obj as IEnumerable;
					if (enumerable != null)
					{
						int num2 = 0;
						foreach (object obj2 in enumerable)
						{
							num2++;
						}
						if (num == -1)
						{
							num = num2;
						}
						else if (num2 != num)
						{
							throw new EvaluationException("When IterateParameters option is used, IEnumerable parameters must have the same number of items.");
						}
					}
				}
				foreach (string key in this.Parameters.Keys)
				{
					IEnumerable enumerable2 = this.Parameters[key] as IEnumerable;
					if (enumerable2 != null)
					{
						this.ParameterEnumerators.Add(key, enumerable2.GetEnumerator());
					}
				}
				List<object> list = new List<object>();
				for (int i = 0; i < num; i++)
				{
					foreach (string key2 in this.ParameterEnumerators.Keys)
					{
						IEnumerator enumerator5 = this.ParameterEnumerators[key2];
						enumerator5.MoveNext();
						this.Parameters[key2] = enumerator5.Current;
					}
					this.ParsedExpression.Accept(evaluationVisitor);
					list.Add(evaluationVisitor.Result);
				}
				return list;
			}
			this.ParsedExpression.Accept(evaluationVisitor);
			return evaluationVisitor.Result;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x000142EC File Offset: 0x000124EC
		public static LogicalExpression Compile(string expression, bool noCache)
		{
			LogicalExpression logicalExpression = null;
			if (Expression._cacheEnabled && !noCache)
			{
				try
				{
					Expression.Rwl.AcquireReaderLock(-1);
					if (Expression._compiledExpressions.ContainsKey(expression))
					{
						WeakReference weakReference = Expression._compiledExpressions[expression];
						logicalExpression = (weakReference.Target as LogicalExpression);
						if (weakReference.IsAlive && logicalExpression != null)
						{
							return logicalExpression;
						}
					}
				}
				finally
				{
					Expression.Rwl.ReleaseReaderLock();
				}
			}
			if (logicalExpression == null)
			{
				NCalcParser ncalcParser = new NCalcParser(new CommonTokenStream(new NCalcLexer(new ANTLRStringStream(expression))));
				logicalExpression = ncalcParser.ncalcExpression().value;
				if (ncalcParser.Errors != null && ncalcParser.Errors.Count > 0)
				{
					throw new EvaluationException(string.Join(Environment.NewLine, ncalcParser.Errors.ToArray()));
				}
				if (Expression._cacheEnabled && !noCache)
				{
					try
					{
						Expression.Rwl.AcquireWriterLock(-1);
						Expression._compiledExpressions[expression] = new WeakReference(logicalExpression);
					}
					finally
					{
						Expression.Rwl.ReleaseWriterLock();
					}
					Expression.CleanCache();
				}
			}
			return logicalExpression;
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00014404 File Offset: 0x00012604
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x0001440B File Offset: 0x0001260B
		public static bool CacheEnabled
		{
			get
			{
				return Expression._cacheEnabled;
			}
			set
			{
				Expression._cacheEnabled = value;
				if (!Expression.CacheEnabled)
				{
					Expression._compiledExpressions = new Dictionary<string, WeakReference>();
				}
			}
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00014424 File Offset: 0x00012624
		private static void CleanCache()
		{
			List<string> list = new List<string>();
			try
			{
				Expression.Rwl.AcquireWriterLock(-1);
				foreach (KeyValuePair<string, WeakReference> keyValuePair in Expression._compiledExpressions)
				{
					if (!keyValuePair.Value.IsAlive)
					{
						list.Add(keyValuePair.Key);
					}
				}
				foreach (string key in list)
				{
					Expression._compiledExpressions.Remove(key);
				}
			}
			finally
			{
				Expression.Rwl.ReleaseReaderLock();
			}
		}

		// Token: 0x0400024D RID: 589
		protected readonly string OriginalExpression;

		// Token: 0x0400024E RID: 590
		protected Dictionary<string, IEnumerator> ParameterEnumerators;

		// Token: 0x0400024F RID: 591
		private Dictionary<string, object> _parameters;

		// Token: 0x04000253 RID: 595
		private static bool _cacheEnabled = true;

		// Token: 0x04000254 RID: 596
		private static Dictionary<string, WeakReference> _compiledExpressions = new Dictionary<string, WeakReference>();

		// Token: 0x04000255 RID: 597
		private static readonly ReaderWriterLock Rwl = new ReaderWriterLock();
	}
}
