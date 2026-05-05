using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000008 RID: 8
	public abstract class UnitConnection<TSourcePort, TDestinationPort> : GraphElement<FlowGraph>, IConnection<TSourcePort, TDestinationPort> where TSourcePort : class, IUnitOutputPort where TDestinationPort : class, IUnitInputPort
	{
		// Token: 0x06000026 RID: 38 RVA: 0x000023BA File Offset: 0x000005BA
		[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
		protected UnitConnection()
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000023C4 File Offset: 0x000005C4
		protected UnitConnection(TSourcePort source, TDestinationPort destination)
		{
			Ensure.That("source").IsNotNull<TSourcePort>(source);
			Ensure.That("destination").IsNotNull<TDestinationPort>(destination);
			if (source.unit.graph != destination.unit.graph)
			{
				throw new NotSupportedException("Cannot create connections across graphs.");
			}
			if (source.unit == destination.unit)
			{
				throw new InvalidConnectionException("Cannot create connections on the same unit.");
			}
			this.sourceUnit = source.unit;
			this.sourceKey = source.key;
			this.destinationUnit = destination.unit;
			this.destinationKey = destination.key;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000248B File Offset: 0x0000068B
		public virtual IGraphElementDebugData CreateDebugData()
		{
			return new UnitConnectionDebugData();
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002492 File Offset: 0x00000692
		// (set) Token: 0x0600002A RID: 42 RVA: 0x0000249A File Offset: 0x0000069A
		[Serialize]
		private protected IUnit sourceUnit { protected get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000024A3 File Offset: 0x000006A3
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000024AB File Offset: 0x000006AB
		[Serialize]
		private protected string sourceKey { protected get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000024B4 File Offset: 0x000006B4
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000024BC File Offset: 0x000006BC
		[Serialize]
		private protected IUnit destinationUnit { protected get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000024C5 File Offset: 0x000006C5
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000024CD File Offset: 0x000006CD
		[Serialize]
		private protected string destinationKey { protected get; private set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000031 RID: 49
		[DoNotSerialize]
		public abstract TSourcePort source { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000032 RID: 50
		[DoNotSerialize]
		public abstract TDestinationPort destination { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000024D6 File Offset: 0x000006D6
		public override int dependencyOrder
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000034 RID: 52
		public abstract bool sourceExists { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000035 RID: 53
		public abstract bool destinationExists { get; }

		// Token: 0x06000036 RID: 54 RVA: 0x000024D9 File Offset: 0x000006D9
		protected void CopyFrom(UnitConnection<TSourcePort, TDestinationPort> source)
		{
			base.CopyFrom(source);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000024E4 File Offset: 0x000006E4
		public override bool HandleDependencies()
		{
			bool flag = true;
			IUnitOutputPort unitOutputPort;
			if (!this.sourceExists)
			{
				if (!this.sourceUnit.invalidOutputs.Contains(this.sourceKey))
				{
					this.sourceUnit.invalidOutputs.Add(new InvalidOutput(this.sourceKey));
				}
				unitOutputPort = this.sourceUnit.invalidOutputs[this.sourceKey];
				flag = false;
			}
			else
			{
				unitOutputPort = this.source;
			}
			IUnitInputPort unitInputPort;
			if (!this.destinationExists)
			{
				if (!this.destinationUnit.invalidInputs.Contains(this.destinationKey))
				{
					this.destinationUnit.invalidInputs.Add(new InvalidInput(this.destinationKey));
				}
				unitInputPort = this.destinationUnit.invalidInputs[this.destinationKey];
				flag = false;
			}
			else
			{
				unitInputPort = this.destination;
			}
			if (!unitOutputPort.CanValidlyConnectTo(unitInputPort))
			{
				flag = false;
			}
			if (!flag && unitOutputPort.CanInvalidlyConnectTo(unitInputPort))
			{
				unitOutputPort.InvalidlyConnectTo(unitInputPort);
				if (unitOutputPort.unit.GetType() != typeof(MissingType) && unitInputPort.unit.GetType() != typeof(MissingType))
				{
					Debug.LogWarning(string.Format("Could not load connection between '{0}' of '{1}' and '{2}' of '{3}'.", new object[]
					{
						unitOutputPort.key,
						this.sourceUnit,
						unitInputPort.key,
						this.destinationUnit
					}));
				}
			}
			return flag;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000264A File Offset: 0x0000084A
		public override AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			return null;
		}
	}
}
