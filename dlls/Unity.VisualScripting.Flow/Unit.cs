using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200017E RID: 382
	[SerializationVersion("A", new Type[]
	{

	})]
	public abstract class Unit : GraphElement<FlowGraph>, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000A05 RID: 2565 RVA: 0x00011EF4 File Offset: 0x000100F4
		protected Unit()
		{
			this.controlInputs = new UnitPortCollection<ControlInput>(this);
			this.controlOutputs = new UnitPortCollection<ControlOutput>(this);
			this.valueInputs = new UnitPortCollection<ValueInput>(this);
			this.valueOutputs = new UnitPortCollection<ValueOutput>(this);
			this.invalidInputs = new UnitPortCollection<InvalidInput>(this);
			this.invalidOutputs = new UnitPortCollection<InvalidOutput>(this);
			this.relations = new ConnectionCollection<IUnitRelation, IUnitPort, IUnitPort>();
			this.defaultValues = new Dictionary<string, object>();
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00011F65 File Offset: 0x00010165
		public virtual IGraphElementDebugData CreateDebugData()
		{
			return new Unit.DebugData();
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00011F6C File Offset: 0x0001016C
		public override void AfterAdd()
		{
			this.Define();
			base.AfterAdd();
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00011F7A File Offset: 0x0001017A
		public override void BeforeRemove()
		{
			base.BeforeRemove();
			this.Disconnect();
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00011F88 File Offset: 0x00010188
		public override void Instantiate(GraphReference instance)
		{
			base.Instantiate(instance);
			IGraphEventListener graphEventListener = this as IGraphEventListener;
			if (graphEventListener != null && XGraphEventListener.IsHierarchyListening(instance))
			{
				graphEventListener.StartListening(instance);
			}
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00011FB8 File Offset: 0x000101B8
		public override void Uninstantiate(GraphReference instance)
		{
			IGraphEventListener graphEventListener = this as IGraphEventListener;
			if (graphEventListener != null)
			{
				graphEventListener.StopListening(instance);
			}
			base.Uninstantiate(instance);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00011FDD File Offset: 0x000101DD
		protected void CopyFrom(Unit source)
		{
			base.CopyFrom(source);
			this.defaultValues = source.defaultValues;
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000A0C RID: 2572 RVA: 0x00011FF2 File Offset: 0x000101F2
		[DoNotSerialize]
		public virtual bool canDefine
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00011FF5 File Offset: 0x000101F5
		[DoNotSerialize]
		public bool failedToDefine
		{
			get
			{
				return this.definitionException != null;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000A0E RID: 2574 RVA: 0x00012000 File Offset: 0x00010200
		// (set) Token: 0x06000A0F RID: 2575 RVA: 0x00012008 File Offset: 0x00010208
		[DoNotSerialize]
		public bool isDefined { get; private set; }

		// Token: 0x06000A10 RID: 2576
		protected abstract void Definition();

		// Token: 0x06000A11 RID: 2577 RVA: 0x00012011 File Offset: 0x00010211
		protected virtual void AfterDefine()
		{
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00012013 File Offset: 0x00010213
		protected virtual void BeforeUndefine()
		{
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00012018 File Offset: 0x00010218
		private void Undefine()
		{
			if (this.isDefined)
			{
				this.BeforeUndefine();
			}
			this.Disconnect();
			this.defaultValues.Clear();
			this.controlInputs.Clear();
			this.controlOutputs.Clear();
			this.valueInputs.Clear();
			this.valueOutputs.Clear();
			this.invalidInputs.Clear();
			this.invalidOutputs.Clear();
			this.relations.Clear();
			this.isDefined = false;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00012098 File Offset: 0x00010298
		public void EnsureDefined()
		{
			if (!this.isDefined)
			{
				this.Define();
			}
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x000120A8 File Offset: 0x000102A8
		public void Define()
		{
			UnitPreservation unitPreservation = UnitPreservation.Preserve(this);
			this.Undefine();
			if (this.canDefine)
			{
				try
				{
					this.Definition();
					this.isDefined = true;
					this.definitionException = null;
					this.AfterDefine();
				}
				catch (Exception ex)
				{
					this.Undefine();
					this.definitionException = ex;
					Debug.LogWarning(string.Format("Failed to define {0}:\n{1}", this, ex));
				}
			}
			unitPreservation.RestoreTo(this);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00012120 File Offset: 0x00010320
		public void RemoveUnconnectedInvalidPorts()
		{
			foreach (InvalidInput item in (from p in this.invalidInputs
			where !p.hasAnyConnection
			select p).ToArray<InvalidInput>())
			{
				this.invalidInputs.Remove(item);
			}
			foreach (InvalidOutput item2 in (from p in this.invalidOutputs
			where !p.hasAnyConnection
			select p).ToArray<InvalidOutput>())
			{
				this.invalidOutputs.Remove(item2);
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x000121CD File Offset: 0x000103CD
		[DoNotSerialize]
		public IUnitPortCollection<ControlInput> controlInputs { get; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x000121D5 File Offset: 0x000103D5
		[DoNotSerialize]
		public IUnitPortCollection<ControlOutput> controlOutputs { get; }

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x000121DD File Offset: 0x000103DD
		[DoNotSerialize]
		public IUnitPortCollection<ValueInput> valueInputs { get; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x000121E5 File Offset: 0x000103E5
		[DoNotSerialize]
		public IUnitPortCollection<ValueOutput> valueOutputs { get; }

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x000121ED File Offset: 0x000103ED
		[DoNotSerialize]
		public IUnitPortCollection<InvalidInput> invalidInputs { get; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x000121F5 File Offset: 0x000103F5
		[DoNotSerialize]
		public IUnitPortCollection<InvalidOutput> invalidOutputs { get; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x000121FD File Offset: 0x000103FD
		[DoNotSerialize]
		public IEnumerable<IUnitInputPort> inputs
		{
			get
			{
				return LinqUtility.Concat<IUnitInputPort>(new IEnumerable[]
				{
					this.controlInputs,
					this.valueInputs,
					this.invalidInputs
				});
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x00012225 File Offset: 0x00010425
		[DoNotSerialize]
		public IEnumerable<IUnitOutputPort> outputs
		{
			get
			{
				return LinqUtility.Concat<IUnitOutputPort>(new IEnumerable[]
				{
					this.controlOutputs,
					this.valueOutputs,
					this.invalidOutputs
				});
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000A1F RID: 2591 RVA: 0x0001224D File Offset: 0x0001044D
		[DoNotSerialize]
		public IEnumerable<IUnitInputPort> validInputs
		{
			get
			{
				return LinqUtility.Concat<IUnitInputPort>(new IEnumerable[]
				{
					this.controlInputs,
					this.valueInputs
				});
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x0001226C File Offset: 0x0001046C
		[DoNotSerialize]
		public IEnumerable<IUnitOutputPort> validOutputs
		{
			get
			{
				return LinqUtility.Concat<IUnitOutputPort>(new IEnumerable[]
				{
					this.controlOutputs,
					this.valueOutputs
				});
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x0001228B File Offset: 0x0001048B
		[DoNotSerialize]
		public IEnumerable<IUnitPort> ports
		{
			get
			{
				return LinqUtility.Concat<IUnitPort>(new IEnumerable[]
				{
					this.inputs,
					this.outputs
				});
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x000122AA File Offset: 0x000104AA
		[DoNotSerialize]
		public IEnumerable<IUnitPort> invalidPorts
		{
			get
			{
				return LinqUtility.Concat<IUnitPort>(new IEnumerable[]
				{
					this.invalidInputs,
					this.invalidOutputs
				});
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x000122C9 File Offset: 0x000104C9
		[DoNotSerialize]
		public IEnumerable<IUnitPort> validPorts
		{
			get
			{
				return LinqUtility.Concat<IUnitPort>(new IEnumerable[]
				{
					this.validInputs,
					this.validOutputs
				});
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000A24 RID: 2596 RVA: 0x000122E8 File Offset: 0x000104E8
		// (remove) Token: 0x06000A25 RID: 2597 RVA: 0x00012320 File Offset: 0x00010520
		public event Action onPortsChanged;

		// Token: 0x06000A26 RID: 2598 RVA: 0x00012355 File Offset: 0x00010555
		public void PortsChanged()
		{
			Action action = this.onPortsChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x00012367 File Offset: 0x00010567
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x0001236F File Offset: 0x0001056F
		[Serialize]
		public Dictionary<string, object> defaultValues { get; private set; }

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000A29 RID: 2601 RVA: 0x00012378 File Offset: 0x00010578
		// (set) Token: 0x06000A2A RID: 2602 RVA: 0x00012380 File Offset: 0x00010580
		[DoNotSerialize]
		public IConnectionCollection<IUnitRelation, IUnitPort, IUnitPort> relations { get; private set; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x00012389 File Offset: 0x00010589
		[DoNotSerialize]
		public IEnumerable<IUnitConnection> connections
		{
			get
			{
				return this.ports.SelectMany((IUnitPort p) => p.connections);
			}
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x000123B8 File Offset: 0x000105B8
		public void Disconnect()
		{
			for (;;)
			{
				if (!this.ports.Any((IUnitPort p) => p.hasAnyConnection))
				{
					break;
				}
				this.ports.First((IUnitPort p) => p.hasAnyConnection).Disconnect();
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x00012422 File Offset: 0x00010622
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x0001242A File Offset: 0x0001062A
		[DoNotSerialize]
		public virtual bool isControlRoot { get; protected set; }

		// Token: 0x06000A2F RID: 2607 RVA: 0x00012434 File Offset: 0x00010634
		protected void EnsureUniqueInput(string key)
		{
			if (this.controlInputs.Contains(key) || this.valueInputs.Contains(key) || this.invalidInputs.Contains(key))
			{
				throw new ArgumentException(string.Format("Duplicate input for '{0}' in {1}.", key, base.GetType()));
			}
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00012484 File Offset: 0x00010684
		protected void EnsureUniqueOutput(string key)
		{
			if (this.controlOutputs.Contains(key) || this.valueOutputs.Contains(key) || this.invalidOutputs.Contains(key))
			{
				throw new ArgumentException(string.Format("Duplicate output for '{0}' in {1}.", key, base.GetType()));
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x000124D4 File Offset: 0x000106D4
		protected ControlInput ControlInput(string key, Func<Flow, ControlOutput> action)
		{
			this.EnsureUniqueInput(key);
			ControlInput controlInput = new ControlInput(key, action);
			this.controlInputs.Add(controlInput);
			return controlInput;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00012500 File Offset: 0x00010700
		protected ControlInput ControlInputCoroutine(string key, Func<Flow, IEnumerator> coroutineAction)
		{
			this.EnsureUniqueInput(key);
			ControlInput controlInput = new ControlInput(key, coroutineAction);
			this.controlInputs.Add(controlInput);
			return controlInput;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0001252C File Offset: 0x0001072C
		protected ControlInput ControlInputCoroutine(string key, Func<Flow, ControlOutput> action, Func<Flow, IEnumerator> coroutineAction)
		{
			this.EnsureUniqueInput(key);
			ControlInput controlInput = new ControlInput(key, action, coroutineAction);
			this.controlInputs.Add(controlInput);
			return controlInput;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00012558 File Offset: 0x00010758
		protected ControlOutput ControlOutput(string key)
		{
			this.EnsureUniqueOutput(key);
			ControlOutput controlOutput = new ControlOutput(key);
			this.controlOutputs.Add(controlOutput);
			return controlOutput;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00012580 File Offset: 0x00010780
		protected ValueInput ValueInput(Type type, string key)
		{
			this.EnsureUniqueInput(key);
			ValueInput valueInput = new ValueInput(key, type);
			this.valueInputs.Add(valueInput);
			return valueInput;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x000125A9 File Offset: 0x000107A9
		protected ValueInput ValueInput<T>(string key)
		{
			return this.ValueInput(typeof(T), key);
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000125BC File Offset: 0x000107BC
		protected ValueInput ValueInput<T>(string key, T @default)
		{
			ValueInput valueInput = this.ValueInput<T>(key);
			valueInput.SetDefaultValue(@default);
			return valueInput;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000125D4 File Offset: 0x000107D4
		protected ValueOutput ValueOutput(Type type, string key)
		{
			this.EnsureUniqueOutput(key);
			ValueOutput valueOutput = new ValueOutput(key, type);
			this.valueOutputs.Add(valueOutput);
			return valueOutput;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00012600 File Offset: 0x00010800
		protected ValueOutput ValueOutput(Type type, string key, Func<Flow, object> getValue)
		{
			this.EnsureUniqueOutput(key);
			ValueOutput valueOutput = new ValueOutput(key, type, getValue);
			this.valueOutputs.Add(valueOutput);
			return valueOutput;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x0001262A File Offset: 0x0001082A
		protected ValueOutput ValueOutput<T>(string key)
		{
			return this.ValueOutput(typeof(T), key);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00012640 File Offset: 0x00010840
		protected ValueOutput ValueOutput<T>(string key, Func<Flow, T> getValue)
		{
			return this.ValueOutput(typeof(T), key, (Flow recursion) => getValue(recursion));
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00012677 File Offset: 0x00010877
		private void Relation(IUnitPort source, IUnitPort destination)
		{
			this.relations.Add(new UnitRelation(source, destination));
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0001268B File Offset: 0x0001088B
		protected void Requirement(ValueInput source, ControlInput destination)
		{
			this.Relation(source, destination);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00012695 File Offset: 0x00010895
		protected void Requirement(ValueInput source, ValueOutput destination)
		{
			this.Relation(source, destination);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0001269F File Offset: 0x0001089F
		protected void Assignment(ControlInput source, ValueOutput destination)
		{
			this.Relation(source, destination);
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x000126A9 File Offset: 0x000108A9
		protected void Succession(ControlInput source, ControlOutput destination)
		{
			this.Relation(source, destination);
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x000126B3 File Offset: 0x000108B3
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x000126BB File Offset: 0x000108BB
		[Serialize]
		public Vector2 position { get; set; }

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x000126C4 File Offset: 0x000108C4
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x000126CC File Offset: 0x000108CC
		[DoNotSerialize]
		public Exception definitionException { get; protected set; }

		// Token: 0x06000A45 RID: 2629 RVA: 0x000126D5 File Offset: 0x000108D5
		public override AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			AnalyticsIdentifier analyticsIdentifier = new AnalyticsIdentifier();
			analyticsIdentifier.Identifier = base.GetType().FullName;
			analyticsIdentifier.Namespace = base.GetType().Namespace;
			analyticsIdentifier.Hashcode = analyticsIdentifier.Identifier.GetHashCode();
			return analyticsIdentifier;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0001270F File Offset: 0x0001090F
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}

		// Token: 0x020001DE RID: 478
		public class DebugData : IUnitDebugData, IGraphElementDebugData
		{
			// Token: 0x170003D7 RID: 983
			// (get) Token: 0x06000C51 RID: 3153 RVA: 0x0001BE54 File Offset: 0x0001A054
			// (set) Token: 0x06000C52 RID: 3154 RVA: 0x0001BE5C File Offset: 0x0001A05C
			public int lastInvokeFrame { get; set; }

			// Token: 0x170003D8 RID: 984
			// (get) Token: 0x06000C53 RID: 3155 RVA: 0x0001BE65 File Offset: 0x0001A065
			// (set) Token: 0x06000C54 RID: 3156 RVA: 0x0001BE6D File Offset: 0x0001A06D
			public float lastInvokeTime { get; set; }

			// Token: 0x170003D9 RID: 985
			// (get) Token: 0x06000C55 RID: 3157 RVA: 0x0001BE76 File Offset: 0x0001A076
			// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0001BE7E File Offset: 0x0001A07E
			public Exception runtimeException { get; set; }
		}
	}
}
