using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x020000AA RID: 170
	public sealed class Formula : MultiInputUnit<object>
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0000A43C File Offset: 0x0000863C
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0000A444 File Offset: 0x00008644
		[DoNotSerialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[InspectorTextArea]
		public string formula
		{
			get
			{
				return this._formula;
			}
			set
			{
				this._formula = value;
				this.InitializeNCalc();
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0000A453 File Offset: 0x00008653
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x0000A45B File Offset: 0x0000865B
		[Serialize]
		[Inspectable(order = 2147483647)]
		[InspectorExpandTooltip]
		public bool cacheArguments { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000A464 File Offset: 0x00008664
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0000A46C File Offset: 0x0000866C
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput result { get; private set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0000A475 File Offset: 0x00008675
		protected override int minInputCount
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000A478 File Offset: 0x00008678
		protected override void Definition()
		{
			base.Definition();
			this.result = base.ValueOutput<object>("result", new Func<Flow, object>(this.Evaluate));
			base.InputsAllowNull();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.result);
			}
			this.InitializeNCalc();
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000A4FC File Offset: 0x000086FC
		private void InitializeNCalc()
		{
			if (string.IsNullOrEmpty(this.formula))
			{
				this.ncalc = null;
				return;
			}
			this.ncalc = new Expression(this.formula, EvaluateOptions.None);
			this.ncalc.Options = EvaluateOptions.IgnoreCase;
			this.ncalc.EvaluateParameter += this.EvaluateTreeParameter;
			this.ncalc.EvaluateFunction += this.EvaluateTreeFunction;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000A56A File Offset: 0x0000876A
		private object Evaluate(Flow flow)
		{
			if (this.ncalc == null)
			{
				throw new InvalidOperationException("No formula provided.");
			}
			this.ncalc.UpdateUnityTimeParameters();
			return this.ncalc.Evaluate(flow);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000A598 File Offset: 0x00008798
		private void EvaluateTreeFunction(Flow flow, string name, FunctionArgs args)
		{
			if (name == "v2" || name == "V2")
			{
				if (args.Parameters.Length != 2)
				{
					throw new ArgumentException(string.Format("v2() takes at exactly 2 arguments. {0} provided.", args.Parameters.Length));
				}
				args.Result = new Vector2(ConversionUtility.Convert<float>(args.Parameters[0].Evaluate(flow)), ConversionUtility.Convert<float>(args.Parameters[1].Evaluate(flow)));
				return;
			}
			else
			{
				if (!(name == "v3") && !(name == "V3"))
				{
					if (name == "v4" || name == "V4")
					{
						if (args.Parameters.Length != 4)
						{
							throw new ArgumentException(string.Format("v4() takes at exactly 4 arguments. {0} provided.", args.Parameters.Length));
						}
						args.Result = new Vector4(ConversionUtility.Convert<float>(args.Parameters[0].Evaluate(flow)), ConversionUtility.Convert<float>(args.Parameters[1].Evaluate(flow)), ConversionUtility.Convert<float>(args.Parameters[2].Evaluate(flow)), ConversionUtility.Convert<float>(args.Parameters[3].Evaluate(flow)));
					}
					return;
				}
				if (args.Parameters.Length != 3)
				{
					throw new ArgumentException(string.Format("v3() takes at exactly 3 arguments. {0} provided.", args.Parameters.Length));
				}
				args.Result = new Vector3(ConversionUtility.Convert<float>(args.Parameters[0].Evaluate(flow)), ConversionUtility.Convert<float>(args.Parameters[1].Evaluate(flow)), ConversionUtility.Convert<float>(args.Parameters[2].Evaluate(flow)));
				return;
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0000A74C File Offset: 0x0000894C
		public object GetParameterValue(Flow flow, string name)
		{
			if (name.Length == 1)
			{
				char c = name[0];
				if (char.IsLetter(c))
				{
					c = char.ToLower(c);
					int argumentIndex = Formula.GetArgumentIndex(c);
					if (argumentIndex < base.multiInputs.Count)
					{
						ValueInput valueInput = base.multiInputs[argumentIndex];
						if (this.cacheArguments && !flow.IsLocal(valueInput))
						{
							flow.SetValue(valueInput, flow.GetValue<object>(valueInput));
						}
						return flow.GetValue<object>(valueInput);
					}
				}
			}
			else
			{
				if (Variables.Graph(flow.stack).IsDefined(name))
				{
					return Variables.Graph(flow.stack).Get(name);
				}
				GameObject self = flow.stack.self;
				if (self != null && Variables.Object(self).IsDefined(name))
				{
					return Variables.Object(self).Get(name);
				}
				Scene? scene = flow.stack.scene;
				if (scene != null && Variables.Scene(scene).IsDefined(name))
				{
					return Variables.Scene(scene).Get(name);
				}
				if (Variables.Application.IsDefined(name))
				{
					return Variables.Application.Get(name);
				}
				if (Variables.Saved.IsDefined(name))
				{
					return Variables.Saved.Get(name);
				}
			}
			throw new InvalidOperationException("Unknown expression tree parameter: '" + name + "'.\nSupported parameter names are alphabetical indices and variable names.");
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000A898 File Offset: 0x00008A98
		private void EvaluateTreeParameter(Flow flow, string name, ParameterArgs args)
		{
			if (!name.Contains("."))
			{
				args.Result = this.GetParameterValue(flow, name);
				return;
			}
			string[] array = name.Split('.', StringSplitOptions.None);
			if (array.Length != 2)
			{
				throw new InvalidOperationException("Cannot parse expression tree parameter: [" + name + "]");
			}
			string text = array[0];
			string text2 = array[1].TrimEnd("()");
			object parameterValue = this.GetParameterValue(flow, text);
			Member member = new Member(parameterValue.GetType(), text2, Type.EmptyTypes);
			object target = parameterValue;
			if (member.isInvocable)
			{
				args.Result = member.Invoke(target);
				return;
			}
			if (member.isGettable)
			{
				args.Result = member.Get(target);
				return;
			}
			throw new InvalidOperationException(string.Concat(new string[]
			{
				"Cannot get or invoke expression tree parameter: [",
				text,
				".",
				text2,
				"]"
			}));
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000A97C File Offset: 0x00008B7C
		public static string GetArgumentName(int index)
		{
			if (index > 25)
			{
				throw new NotImplementedException("Argument indices above 26 are not yet supported.");
			}
			return ((char)(97 + index)).ToString();
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0000A9A6 File Offset: 0x00008BA6
		public static int GetArgumentIndex(char name)
		{
			if (name < 'a' || name > 'z')
			{
				throw new NotImplementedException("Unalphabetical argument names are not yet supported.");
			}
			return (int)(name - 'a');
		}

		// Token: 0x0400013A RID: 314
		[SerializeAs("Formula")]
		private string _formula;

		// Token: 0x0400013B RID: 315
		private Expression ncalc;
	}
}
