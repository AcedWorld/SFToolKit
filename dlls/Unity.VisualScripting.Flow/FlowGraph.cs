using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000018 RID: 24
	[SerializationVersion("A", new Type[]
	{

	})]
	[DisplayName("Script Graph")]
	public sealed class FlowGraph : Graph, IGraphWithVariables, IGraph, IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver, IGraphEventListener
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x00003534 File Offset: 0x00001734
		public FlowGraph()
		{
			this.units = new GraphElementCollection<IUnit>(this);
			this.controlConnections = new GraphConnectionCollection<ControlConnection, ControlOutput, ControlInput>(this);
			this.valueConnections = new GraphConnectionCollection<ValueConnection, ValueOutput, ValueInput>(this);
			this.invalidConnections = new GraphConnectionCollection<InvalidConnection, IUnitOutputPort, IUnitInputPort>(this);
			this.groups = new GraphElementCollection<GraphGroup>(this);
			this.sticky = new GraphElementCollection<StickyNote>(this);
			base.elements.Include<IUnit>(this.units);
			base.elements.Include<ControlConnection>(this.controlConnections);
			base.elements.Include<ValueConnection>(this.valueConnections);
			base.elements.Include<InvalidConnection>(this.invalidConnections);
			base.elements.Include<GraphGroup>(this.groups);
			base.elements.Include<StickyNote>(this.sticky);
			this.controlInputDefinitions = new UnitPortDefinitionCollection<ControlInputDefinition>();
			this.controlOutputDefinitions = new UnitPortDefinitionCollection<ControlOutputDefinition>();
			this.valueInputDefinitions = new UnitPortDefinitionCollection<ValueInputDefinition>();
			this.valueOutputDefinitions = new UnitPortDefinitionCollection<ValueOutputDefinition>();
			this.variables = new VariableDeclarations();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000362C File Offset: 0x0000182C
		public override IGraphData CreateData()
		{
			return new FlowGraphData(this);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003634 File Offset: 0x00001834
		public void StartListening(GraphStack stack)
		{
			stack.GetGraphData<FlowGraphData>().isListening = true;
			foreach (IUnit unit in this.units)
			{
				IGraphEventListener graphEventListener = unit as IGraphEventListener;
				if (graphEventListener != null)
				{
					graphEventListener.StartListening(stack);
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000369C File Offset: 0x0000189C
		public void StopListening(GraphStack stack)
		{
			foreach (IUnit unit in this.units)
			{
				IGraphEventListener graphEventListener = unit as IGraphEventListener;
				if (graphEventListener != null)
				{
					graphEventListener.StopListening(stack);
				}
			}
			stack.GetGraphData<FlowGraphData>().isListening = false;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003704 File Offset: 0x00001904
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetGraphData<FlowGraphData>().isListening;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003711 File Offset: 0x00001911
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00003719 File Offset: 0x00001919
		[Serialize]
		public VariableDeclarations variables { get; private set; }

		// Token: 0x060000B0 RID: 176 RVA: 0x00003724 File Offset: 0x00001924
		public IEnumerable<string> GetDynamicVariableNames(VariableKind kind, GraphReference reference)
		{
			return from name in (from v in this.units.OfType<IUnifiedVariableUnit>()
			where v.kind == kind && Flow.CanPredict(v.name, reference)
			select Flow.Predict<string>(v.name, reference) into name
			where !StringUtility.IsNullOrWhiteSpace(name)
			select name).Distinct<string>()
			orderby name
			select name;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000037BF File Offset: 0x000019BF
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x000037C7 File Offset: 0x000019C7
		[DoNotSerialize]
		public GraphElementCollection<IUnit> units { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x000037D0 File Offset: 0x000019D0
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000037D8 File Offset: 0x000019D8
		[DoNotSerialize]
		public GraphConnectionCollection<ControlConnection, ControlOutput, ControlInput> controlConnections { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000037E1 File Offset: 0x000019E1
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000037E9 File Offset: 0x000019E9
		[DoNotSerialize]
		public GraphConnectionCollection<ValueConnection, ValueOutput, ValueInput> valueConnections { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000037F2 File Offset: 0x000019F2
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000037FA File Offset: 0x000019FA
		[DoNotSerialize]
		public GraphConnectionCollection<InvalidConnection, IUnitOutputPort, IUnitInputPort> invalidConnections { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00003803 File Offset: 0x00001A03
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000380B File Offset: 0x00001A0B
		[DoNotSerialize]
		public GraphElementCollection<GraphGroup> groups { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003814 File Offset: 0x00001A14
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000381C File Offset: 0x00001A1C
		[DoNotSerialize]
		public GraphElementCollection<StickyNote> sticky { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003825 File Offset: 0x00001A25
		// (set) Token: 0x060000BE RID: 190 RVA: 0x0000382D File Offset: 0x00001A2D
		[Serialize]
		[InspectorLabel("Trigger Inputs")]
		[InspectorWide(true)]
		[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
		public UnitPortDefinitionCollection<ControlInputDefinition> controlInputDefinitions { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003836 File Offset: 0x00001A36
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000383E File Offset: 0x00001A3E
		[Serialize]
		[InspectorLabel("Trigger Outputs")]
		[InspectorWide(true)]
		[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
		public UnitPortDefinitionCollection<ControlOutputDefinition> controlOutputDefinitions { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003847 File Offset: 0x00001A47
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x0000384F File Offset: 0x00001A4F
		[Serialize]
		[InspectorLabel("Data Inputs")]
		[InspectorWide(true)]
		[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
		public UnitPortDefinitionCollection<ValueInputDefinition> valueInputDefinitions { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00003858 File Offset: 0x00001A58
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00003860 File Offset: 0x00001A60
		[Serialize]
		[InspectorLabel("Data Outputs")]
		[InspectorWide(true)]
		[WarnBeforeRemoving("Remove Port Definition", "Removing this definition will break any existing connection to this port. Are you sure you want to continue?")]
		public UnitPortDefinitionCollection<ValueOutputDefinition> valueOutputDefinitions { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000386C File Offset: 0x00001A6C
		public IEnumerable<IUnitPortDefinition> validPortDefinitions
		{
			get
			{
				return (from upd in LinqUtility.Concat<IUnitPortDefinition>(new IEnumerable[]
				{
					this.controlInputDefinitions,
					this.controlOutputDefinitions,
					this.valueInputDefinitions,
					this.valueOutputDefinitions
				})
				where upd.isValid
				select upd).DistinctBy((IUnitPortDefinition upd) => upd.key);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000C6 RID: 198 RVA: 0x000038F0 File Offset: 0x00001AF0
		// (remove) Token: 0x060000C7 RID: 199 RVA: 0x00003928 File Offset: 0x00001B28
		public event Action onPortDefinitionsChanged;

		// Token: 0x060000C8 RID: 200 RVA: 0x0000395D File Offset: 0x00001B5D
		public void PortDefinitionsChanged()
		{
			Action action = this.onPortDefinitionsChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003970 File Offset: 0x00001B70
		public static FlowGraph WithInputOutput()
		{
			return new FlowGraph
			{
				units = 
				{
					new GraphInput
					{
						position = new Vector2(-250f, -30f)
					},
					new GraphOutput
					{
						position = new Vector2(105f, -30f)
					}
				}
			};
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000039CC File Offset: 0x00001BCC
		public static FlowGraph WithStartUpdate()
		{
			return new FlowGraph
			{
				units = 
				{
					new Start
					{
						position = new Vector2(-204f, -144f)
					},
					new Update
					{
						position = new Vector2(-204f, 60f)
					}
				}
			};
		}

		// Token: 0x0400002D RID: 45
		private const string DefinitionRemoveWarningTitle = "Remove Port Definition";

		// Token: 0x0400002E RID: 46
		private const string DefinitionRemoveWarningMessage = "Removing this definition will break any existing connection to this port. Are you sure you want to continue?";
	}
}
