using System;
using System.ComponentModel;

namespace Unity.VisualScripting
{
	// Token: 0x0200017D RID: 381
	[TypeIcon(typeof(FlowGraph))]
	[UnitCategory("Nesting")]
	[UnitTitle("Subgraph")]
	[RenamedFrom("Bolt.SuperUnit")]
	[RenamedFrom("Unity.VisualScripting.SuperUnit")]
	[DisplayName("Subgraph Node")]
	public sealed class SubgraphUnit : NesterUnit<FlowGraph, ScriptGraphAsset>, IGraphEventListener, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x060009F7 RID: 2551 RVA: 0x00011BE5 File Offset: 0x0000FDE5
		public IGraphElementData CreateData()
		{
			return new SubgraphUnit.Data();
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00011BEC File Offset: 0x0000FDEC
		public SubgraphUnit()
		{
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00011BF4 File Offset: 0x0000FDF4
		public SubgraphUnit(ScriptGraphAsset macro) : base(macro)
		{
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00011BFD File Offset: 0x0000FDFD
		public static SubgraphUnit WithInputOutput()
		{
			return new SubgraphUnit
			{
				nest = 
				{
					source = GraphSource.Embed
				},
				nest = 
				{
					embed = FlowGraph.WithInputOutput()
				}
			};
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00011C20 File Offset: 0x0000FE20
		public static SubgraphUnit WithStartUpdate()
		{
			return new SubgraphUnit
			{
				nest = 
				{
					source = GraphSource.Embed
				},
				nest = 
				{
					embed = FlowGraph.WithStartUpdate()
				}
			};
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00011C43 File Offset: 0x0000FE43
		public override FlowGraph DefaultGraph()
		{
			return FlowGraph.WithInputOutput();
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00011C4C File Offset: 0x0000FE4C
		protected override void Definition()
		{
			this.isControlRoot = true;
			foreach (IUnitPortDefinition unitPortDefinition in base.nest.graph.validPortDefinitions)
			{
				if (unitPortDefinition is ControlInputDefinition)
				{
					ControlInputDefinition controlInputDefinition = (ControlInputDefinition)unitPortDefinition;
					string key = controlInputDefinition.key;
					base.ControlInput(key, delegate(Flow flow)
					{
						foreach (IUnit unit in this.nest.graph.units)
						{
							if (unit is GraphInput)
							{
								Unit unit2 = (GraphInput)unit;
								flow.stack.EnterParentElement(this);
								return unit2.controlOutputs[key];
							}
						}
						return null;
					});
				}
				else if (unitPortDefinition is ValueInputDefinition)
				{
					ValueInputDefinition valueInputDefinition = (ValueInputDefinition)unitPortDefinition;
					string key3 = valueInputDefinition.key;
					Type type = valueInputDefinition.type;
					bool hasDefaultValue = valueInputDefinition.hasDefaultValue;
					object defaultValue = valueInputDefinition.defaultValue;
					ValueInput valueInput = base.ValueInput(type, key3);
					if (hasDefaultValue)
					{
						valueInput.SetDefaultValue(defaultValue);
					}
				}
				else if (unitPortDefinition is ControlOutputDefinition)
				{
					string key2 = ((ControlOutputDefinition)unitPortDefinition).key;
					base.ControlOutput(key2);
				}
				else if (unitPortDefinition is ValueOutputDefinition)
				{
					ValueOutputDefinition valueOutputDefinition = (ValueOutputDefinition)unitPortDefinition;
					string key = valueOutputDefinition.key;
					Type type2 = valueOutputDefinition.type;
					base.ValueOutput(type2, key, delegate(Flow flow)
					{
						flow.stack.EnterParentElement(this);
						foreach (IUnit unit in this.nest.graph.units)
						{
							if (unit is GraphOutput)
							{
								GraphOutput graphOutput = (GraphOutput)unit;
								object value = flow.GetValue(graphOutput.valueInputs[key]);
								flow.stack.ExitParentElement();
								return value;
							}
						}
						flow.stack.ExitParentElement();
						throw new InvalidOperationException("Missing output node when to get value.");
					});
				}
			}
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00011DB8 File Offset: 0x0000FFB8
		public void StartListening(GraphStack stack)
		{
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StartListening(stack);
				stack.ExitParentElement();
			}
			stack.GetElementData<SubgraphUnit.Data>(this).isListening = true;
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00011DE7 File Offset: 0x0000FFE7
		public void StopListening(GraphStack stack)
		{
			stack.GetElementData<SubgraphUnit.Data>(this).isListening = false;
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StopListening(stack);
				stack.ExitParentElement();
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00011E16 File Offset: 0x00010016
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetElementData<SubgraphUnit.Data>(this).isListening;
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00011E24 File Offset: 0x00010024
		public override void AfterAdd()
		{
			base.AfterAdd();
			base.nest.beforeGraphChange += this.StopWatchingPortDefinitions;
			base.nest.afterGraphChange += this.StartWatchingPortDefinitions;
			this.StartWatchingPortDefinitions();
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00011E60 File Offset: 0x00010060
		public override void BeforeRemove()
		{
			base.BeforeRemove();
			this.StopWatchingPortDefinitions();
			base.nest.beforeGraphChange -= this.StopWatchingPortDefinitions;
			base.nest.afterGraphChange -= this.StartWatchingPortDefinitions;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00011E9C File Offset: 0x0001009C
		private void StopWatchingPortDefinitions()
		{
			if (base.nest.graph != null)
			{
				base.nest.graph.onPortDefinitionsChanged -= this.Define;
			}
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00011EC8 File Offset: 0x000100C8
		private void StartWatchingPortDefinitions()
		{
			if (base.nest.graph != null)
			{
				base.nest.graph.onPortDefinitionsChanged += this.Define;
			}
		}

		// Token: 0x020001DB RID: 475
		public sealed class Data : IGraphElementData
		{
			// Token: 0x0400040A RID: 1034
			public bool isListening;
		}
	}
}
