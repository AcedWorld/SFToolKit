using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x02000138 RID: 312
	public sealed class GetVariable : UnifiedVariableUnit
	{
		// Token: 0x170002DF RID: 735
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0000F772 File Offset: 0x0000D972
		// (set) Token: 0x06000850 RID: 2128 RVA: 0x0000F77A File Offset: 0x0000D97A
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0000F783 File Offset: 0x0000D983
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x0000F78B File Offset: 0x0000D98B
		[DoNotSerialize]
		public ValueInput fallback { get; private set; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x0000F794 File Offset: 0x0000D994
		// (set) Token: 0x06000854 RID: 2132 RVA: 0x0000F79C File Offset: 0x0000D99C
		[Serialize]
		[Inspectable]
		[InspectorLabel("Fallback")]
		public bool specifyFallback { get; set; }

		// Token: 0x06000855 RID: 2133 RVA: 0x0000F7A8 File Offset: 0x0000D9A8
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<object>("value", new Func<Flow, object>(this.Get)).PredictableIf(new Func<Flow, bool>(this.IsDefined));
			base.Requirement(base.name, this.value);
			if (base.kind == VariableKind.Object)
			{
				base.Requirement(base.@object, this.value);
			}
			if (this.specifyFallback)
			{
				this.fallback = base.ValueInput<object>("fallback");
				base.Requirement(this.fallback, this.value);
			}
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0000F844 File Offset: 0x0000DA44
		private bool IsDefined(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			GameObject gameObject = null;
			if (base.kind == VariableKind.Object)
			{
				gameObject = flow.GetValue<GameObject>(base.@object);
				if (gameObject == null)
				{
					return false;
				}
			}
			Scene? scene = flow.stack.scene;
			if (base.kind == VariableKind.Scene && (scene == null || !scene.Value.IsValid() || !scene.Value.isLoaded || !Variables.ExistInScene(scene)))
			{
				return false;
			}
			switch (base.kind)
			{
			case VariableKind.Flow:
				return flow.variables.IsDefined(value);
			case VariableKind.Graph:
				return Variables.Graph(flow.stack).IsDefined(value);
			case VariableKind.Object:
				return Variables.Object(gameObject).IsDefined(value);
			case VariableKind.Scene:
				return Variables.Scene(new Scene?(scene.Value)).IsDefined(value);
			case VariableKind.Application:
				return Variables.Application.IsDefined(value);
			case VariableKind.Saved:
				return Variables.Saved.IsDefined(value);
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0000F968 File Offset: 0x0000DB68
		private object Get(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			VariableDeclarations variableDeclarations;
			switch (base.kind)
			{
			case VariableKind.Flow:
				variableDeclarations = flow.variables;
				break;
			case VariableKind.Graph:
				variableDeclarations = Variables.Graph(flow.stack);
				break;
			case VariableKind.Object:
				variableDeclarations = Variables.Object(flow.GetValue<GameObject>(base.@object));
				break;
			case VariableKind.Scene:
				variableDeclarations = Variables.Scene(flow.stack.scene);
				break;
			case VariableKind.Application:
				variableDeclarations = Variables.Application;
				break;
			case VariableKind.Saved:
				variableDeclarations = Variables.Saved;
				break;
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
			if (this.specifyFallback && !variableDeclarations.IsDefined(value))
			{
				return flow.GetValue(this.fallback);
			}
			return variableDeclarations.Get(value);
		}
	}
}
