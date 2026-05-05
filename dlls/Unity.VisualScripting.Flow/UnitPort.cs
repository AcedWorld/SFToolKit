using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000173 RID: 371
	public abstract class UnitPort<TValidOther, TInvalidOther, TExternalConnection> : IUnitPort, IGraphItem where TValidOther : IUnitPort where TInvalidOther : IUnitPort where TExternalConnection : IUnitConnection
	{
		// Token: 0x0600097B RID: 2427 RVA: 0x00010F30 File Offset: 0x0000F130
		protected UnitPort(string key)
		{
			Ensure.That("key").IsNotNull(key);
			this.key = key;
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00010F4F File Offset: 0x0000F14F
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00010F57 File Offset: 0x0000F157
		public IUnit unit { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00010F60 File Offset: 0x0000F160
		public string key { get; }

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x00010F68 File Offset: 0x0000F168
		public IGraph graph
		{
			get
			{
				IUnit unit = this.unit;
				if (unit == null)
				{
					return null;
				}
				return unit.graph;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00010F7B File Offset: 0x0000F17B
		public IEnumerable<IUnitRelation> relations
		{
			get
			{
				return LinqUtility.Concat<IUnitRelation>(new IEnumerable[]
				{
					this.unit.relations.WithSource(this),
					this.unit.relations.WithDestination(this)
				}).Distinct<IUnitRelation>();
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000981 RID: 2433
		public abstract IEnumerable<TExternalConnection> validConnections { get; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000982 RID: 2434
		public abstract IEnumerable<InvalidConnection> invalidConnections { get; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000983 RID: 2435
		public abstract IEnumerable<TValidOther> validConnectedPorts { get; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000984 RID: 2436
		public abstract IEnumerable<TInvalidOther> invalidConnectedPorts { get; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x00010FB5 File Offset: 0x0000F1B5
		IEnumerable<IUnitConnection> IUnitPort.validConnections
		{
			get
			{
				return this.validConnections.Cast<IUnitConnection>();
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00010FC2 File Offset: 0x0000F1C2
		public IEnumerable<IUnitConnection> connections
		{
			get
			{
				return LinqUtility.Concat<IUnitConnection>(new IEnumerable[]
				{
					this.validConnections,
					this.invalidConnections
				});
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x00010FE1 File Offset: 0x0000F1E1
		public IEnumerable<IUnitPort> connectedPorts
		{
			get
			{
				return LinqUtility.Concat<IUnitPort>(new IEnumerable[]
				{
					this.validConnectedPorts,
					this.invalidConnectedPorts
				});
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x00011000 File Offset: 0x0000F200
		public bool hasAnyConnection
		{
			get
			{
				return this.hasValidConnection || this.hasInvalidConnection;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x00011012 File Offset: 0x0000F212
		public virtual bool hasValidConnection
		{
			get
			{
				return this.validConnections.Any<TExternalConnection>();
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0001101F File Offset: 0x0000F21F
		public virtual bool hasInvalidConnection
		{
			get
			{
				return this.invalidConnections.Any<InvalidConnection>();
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0001102C File Offset: 0x0000F22C
		private bool CanConnectTo(IUnitPort port)
		{
			Ensure.That("port").IsNotNull<IUnitPort>(port);
			return this.unit != null && port.unit != null && port.unit != this.unit && port.unit.graph == this.unit.graph;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00011081 File Offset: 0x0000F281
		public bool CanValidlyConnectTo(IUnitPort port)
		{
			return this.CanConnectTo(port) && port is TValidOther && this.CanConnectToValid((TValidOther)((object)port));
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x000110A2 File Offset: 0x0000F2A2
		public bool CanInvalidlyConnectTo(IUnitPort port)
		{
			return this.CanConnectTo(port) && port is TInvalidOther && this.CanConnectToInvalid((TInvalidOther)((object)port));
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x000110C3 File Offset: 0x0000F2C3
		public void ValidlyConnectTo(IUnitPort port)
		{
			Ensure.That("port").IsNotNull<IUnitPort>(port);
			if (!(port is TValidOther))
			{
				throw new InvalidConnectionException();
			}
			this.ConnectToValid((TValidOther)((object)port));
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x000110EF File Offset: 0x0000F2EF
		public void InvalidlyConnectTo(IUnitPort port)
		{
			Ensure.That("port").IsNotNull<IUnitPort>(port);
			if (!(port is TInvalidOther))
			{
				throw new InvalidConnectionException();
			}
			this.ConnectToInvalid((TInvalidOther)((object)port));
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0001111C File Offset: 0x0000F31C
		public void Disconnect()
		{
			while (this.validConnectedPorts.Any<TValidOther>())
			{
				this.DisconnectFromValid(this.validConnectedPorts.First<TValidOther>());
			}
			while (this.invalidConnectedPorts.Any<TInvalidOther>())
			{
				this.DisconnectFromInvalid(this.invalidConnectedPorts.First<TInvalidOther>());
			}
		}

		// Token: 0x06000991 RID: 2449
		public abstract bool CanConnectToValid(TValidOther port);

		// Token: 0x06000992 RID: 2450 RVA: 0x00011169 File Offset: 0x0000F369
		public bool CanConnectToInvalid(TInvalidOther port)
		{
			return true;
		}

		// Token: 0x06000993 RID: 2451
		public abstract void ConnectToValid(TValidOther port);

		// Token: 0x06000994 RID: 2452
		public abstract void ConnectToInvalid(TInvalidOther port);

		// Token: 0x06000995 RID: 2453
		public abstract void DisconnectFromValid(TValidOther port);

		// Token: 0x06000996 RID: 2454
		public abstract void DisconnectFromInvalid(TInvalidOther port);

		// Token: 0x06000997 RID: 2455
		public abstract IUnitPort CompatiblePort(IUnit unit);

		// Token: 0x06000998 RID: 2456 RVA: 0x0001116C File Offset: 0x0000F36C
		protected void ConnectInvalid(IUnitOutputPort source, IUnitInputPort destination)
		{
			if (this.unit.graph.invalidConnections.SingleOrDefault((InvalidConnection c) => c.source == source && c.destination == destination) != null)
			{
				return;
			}
			this.unit.graph.invalidConnections.Add(new InvalidConnection(source, destination));
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x000111D8 File Offset: 0x0000F3D8
		protected void DisconnectInvalid(IUnitOutputPort source, IUnitInputPort destination)
		{
			InvalidConnection invalidConnection = this.unit.graph.invalidConnections.SingleOrDefault((InvalidConnection c) => c.source == source && c.destination == destination);
			if (invalidConnection == null)
			{
				return;
			}
			this.unit.graph.invalidConnections.Remove(invalidConnection);
		}
	}
}
