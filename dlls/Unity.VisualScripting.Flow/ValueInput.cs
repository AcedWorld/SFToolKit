using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000176 RID: 374
	public sealed class ValueInput : UnitPort<ValueOutput, IUnitOutputPort, ValueConnection>, IUnitValuePort, IUnitPort, IGraphItem, IUnitInputPort
	{
		// Token: 0x060009B4 RID: 2484 RVA: 0x000113F4 File Offset: 0x0000F5F4
		public ValueInput(string key, Type type) : base(key)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			this.type = type;
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x00011414 File Offset: 0x0000F614
		public Type type { get; }

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0001141C File Offset: 0x0000F61C
		public bool hasDefaultValue
		{
			get
			{
				return base.unit.defaultValues.ContainsKey(base.key);
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x00011434 File Offset: 0x0000F634
		public override IEnumerable<ValueConnection> validConnections
		{
			get
			{
				IUnit unit = base.unit;
				IEnumerable<ValueConnection> enumerable;
				if (unit == null)
				{
					enumerable = null;
				}
				else
				{
					FlowGraph graph = unit.graph;
					enumerable = ((graph != null) ? graph.valueConnections.WithDestination(this) : null);
				}
				return enumerable ?? Enumerable.Empty<ValueConnection>();
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x00011463 File Offset: 0x0000F663
		public override IEnumerable<InvalidConnection> invalidConnections
		{
			get
			{
				IUnit unit = base.unit;
				IEnumerable<InvalidConnection> enumerable;
				if (unit == null)
				{
					enumerable = null;
				}
				else
				{
					FlowGraph graph = unit.graph;
					enumerable = ((graph != null) ? graph.invalidConnections.WithDestination(this) : null);
				}
				return enumerable ?? Enumerable.Empty<InvalidConnection>();
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x00011492 File Offset: 0x0000F692
		public override IEnumerable<ValueOutput> validConnectedPorts
		{
			get
			{
				return from c in this.validConnections
				select c.source;
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x000114BE File Offset: 0x0000F6BE
		public override IEnumerable<IUnitOutputPort> invalidConnectedPorts
		{
			get
			{
				return from c in this.invalidConnections
				select c.source;
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x000114EA File Offset: 0x0000F6EA
		// (set) Token: 0x060009BC RID: 2492 RVA: 0x00011502 File Offset: 0x0000F702
		[DoNotSerialize]
		internal object _defaultValue
		{
			get
			{
				return base.unit.defaultValues[base.key];
			}
			set
			{
				base.unit.defaultValues[base.key] = value;
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x0001151B File Offset: 0x0000F71B
		// (set) Token: 0x060009BE RID: 2494 RVA: 0x00011523 File Offset: 0x0000F723
		public bool nullMeansSelf { get; private set; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0001152C File Offset: 0x0000F72C
		// (set) Token: 0x060009C0 RID: 2496 RVA: 0x00011534 File Offset: 0x0000F734
		public bool allowsNull { get; private set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0001153D File Offset: 0x0000F73D
		public ValueConnection connection
		{
			get
			{
				FlowGraph graph = base.unit.graph;
				if (graph == null)
				{
					return null;
				}
				return graph.valueConnections.SingleOrDefaultWithDestination(this);
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x0001155B File Offset: 0x0000F75B
		public override bool hasValidConnection
		{
			get
			{
				return this.connection != null;
			}
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00011568 File Offset: 0x0000F768
		public void SetDefaultValue(object value)
		{
			Ensure.That("value").IsOfType<object>(value, this.type);
			if (!ValueInput.SupportsDefaultValue(this.type))
			{
				return;
			}
			if (base.unit.defaultValues.ContainsKey(base.key))
			{
				base.unit.defaultValues[base.key] = value;
				return;
			}
			base.unit.defaultValues.Add(base.key, value);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x000115E0 File Offset: 0x0000F7E0
		public override bool CanConnectToValid(ValueOutput port)
		{
			return port.type.IsConvertibleTo(this.type, false);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00011604 File Offset: 0x0000F804
		public override void ConnectToValid(ValueOutput port)
		{
			this.Disconnect();
			base.unit.graph.valueConnections.Add(new ValueConnection(port, this));
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00011637 File Offset: 0x0000F837
		public override void ConnectToInvalid(IUnitOutputPort port)
		{
			base.ConnectInvalid(port, this);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00011644 File Offset: 0x0000F844
		public override void DisconnectFromValid(ValueOutput port)
		{
			ValueConnection valueConnection = this.validConnections.SingleOrDefault((ValueConnection c) => c.source == port);
			if (valueConnection != null)
			{
				base.unit.graph.valueConnections.Remove(valueConnection);
			}
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00011690 File Offset: 0x0000F890
		public override void DisconnectFromInvalid(IUnitOutputPort port)
		{
			base.DisconnectInvalid(port, this);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0001169A File Offset: 0x0000F89A
		public ValueInput NullMeansSelf()
		{
			if (ComponentHolderProtocol.IsComponentHolderType(this.type))
			{
				this.nullMeansSelf = true;
			}
			return this;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x000116B1 File Offset: 0x0000F8B1
		public ValueInput AllowsNull()
		{
			if (this.type.IsNullable())
			{
				this.allowsNull = true;
			}
			return this;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x000116C8 File Offset: 0x0000F8C8
		public static bool SupportsDefaultValue(Type type)
		{
			return ValueInput.typesWithDefaultValues.Contains(type) || ValueInput.typesWithDefaultValues.Contains(Nullable.GetUnderlyingType(type)) || type.IsBasic() || typeof(Object).IsAssignableFrom(type);
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00011703 File Offset: 0x0000F903
		public override IUnitPort CompatiblePort(IUnit unit)
		{
			if (unit == base.unit)
			{
				return null;
			}
			return unit.CompatibleValueOutput(this.type);
		}

		// Token: 0x0400020B RID: 523
		private static readonly HashSet<Type> typesWithDefaultValues = new HashSet<Type>
		{
			typeof(Vector2),
			typeof(Vector3),
			typeof(Vector4),
			typeof(Color),
			typeof(AnimationCurve),
			typeof(Rect),
			typeof(Ray),
			typeof(Ray2D),
			typeof(Type)
		};
	}
}
