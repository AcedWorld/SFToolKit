using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x0200015F RID: 351
	public sealed class ControlInput : UnitPort<ControlOutput, IUnitOutputPort, ControlConnection>, IUnitControlPort, IUnitPort, IGraphItem, IUnitInputPort
	{
		// Token: 0x06000924 RID: 2340 RVA: 0x00010794 File Offset: 0x0000E994
		public ControlInput(string key, Func<Flow, ControlOutput> action) : base(key)
		{
			Ensure.That("action").IsNotNull<Func<Flow, ControlOutput>>(action);
			this.action = action;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000107B4 File Offset: 0x0000E9B4
		public ControlInput(string key, Func<Flow, IEnumerator> coroutineAction) : base(key)
		{
			Ensure.That("coroutineAction").IsNotNull<Func<Flow, IEnumerator>>(coroutineAction);
			this.coroutineAction = coroutineAction;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x000107D4 File Offset: 0x0000E9D4
		public ControlInput(string key, Func<Flow, ControlOutput> action, Func<Flow, IEnumerator> coroutineAction) : base(key)
		{
			Ensure.That("action").IsNotNull<Func<Flow, ControlOutput>>(action);
			Ensure.That("coroutineAction").IsNotNull<Func<Flow, IEnumerator>>(coroutineAction);
			this.action = action;
			this.coroutineAction = coroutineAction;
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0001080B File Offset: 0x0000EA0B
		public bool supportsCoroutine
		{
			get
			{
				return this.coroutineAction != null;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x00010816 File Offset: 0x0000EA16
		public bool requiresCoroutine
		{
			get
			{
				return this.action == null;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x00010821 File Offset: 0x0000EA21
		public override IEnumerable<ControlConnection> validConnections
		{
			get
			{
				IUnit unit = base.unit;
				IEnumerable<ControlConnection> enumerable;
				if (unit == null)
				{
					enumerable = null;
				}
				else
				{
					FlowGraph graph = unit.graph;
					enumerable = ((graph != null) ? graph.controlConnections.WithDestination(this) : null);
				}
				return enumerable ?? Enumerable.Empty<ControlConnection>();
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x00010850 File Offset: 0x0000EA50
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

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0001087F File Offset: 0x0000EA7F
		public override IEnumerable<ControlOutput> validConnectedPorts
		{
			get
			{
				return from c in this.validConnections
				select c.source;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x000108AB File Offset: 0x0000EAAB
		public override IEnumerable<IUnitOutputPort> invalidConnectedPorts
		{
			get
			{
				return from c in this.invalidConnections
				select c.source;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x000108D8 File Offset: 0x0000EAD8
		public bool isPredictable
		{
			get
			{
				bool result;
				using (Recursion recursion = Recursion.New(1))
				{
					result = this.IsPredictable(recursion);
				}
				return result;
			}
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00010914 File Offset: 0x0000EB14
		public bool IsPredictable(Recursion recursion)
		{
			if (!this.hasValidConnection)
			{
				return true;
			}
			Recursion recursion2 = recursion;
			if (recursion2 != null && !recursion2.TryEnter(this))
			{
				return false;
			}
			bool result = this.validConnectedPorts.All((ControlOutput cop) => cop.IsPredictable(recursion));
			Recursion recursion3 = recursion;
			if (recursion3 == null)
			{
				return result;
			}
			recursion3.Exit(this);
			return result;
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0001097C File Offset: 0x0000EB7C
		public bool couldBeEntered
		{
			get
			{
				if (!this.isPredictable)
				{
					throw new NotSupportedException();
				}
				if (!this.hasValidConnection)
				{
					return false;
				}
				return this.validConnectedPorts.Any((ControlOutput cop) => cop.couldBeEntered);
			}
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000109CB File Offset: 0x0000EBCB
		public override bool CanConnectToValid(ControlOutput port)
		{
			return true;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x000109D0 File Offset: 0x0000EBD0
		public override void ConnectToValid(ControlOutput port)
		{
			port.Disconnect();
			base.unit.graph.controlConnections.Add(new ControlConnection(port, this));
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00010A03 File Offset: 0x0000EC03
		public override void ConnectToInvalid(IUnitOutputPort port)
		{
			base.ConnectInvalid(port, this);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00010A10 File Offset: 0x0000EC10
		public override void DisconnectFromValid(ControlOutput port)
		{
			ControlConnection controlConnection = this.validConnections.SingleOrDefault((ControlConnection c) => c.source == port);
			if (controlConnection != null)
			{
				base.unit.graph.controlConnections.Remove(controlConnection);
			}
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00010A5C File Offset: 0x0000EC5C
		public override void DisconnectFromInvalid(IUnitOutputPort port)
		{
			base.DisconnectInvalid(port, this);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00010A66 File Offset: 0x0000EC66
		public override IUnitPort CompatiblePort(IUnit unit)
		{
			if (unit == base.unit)
			{
				return null;
			}
			return unit.controlOutputs.FirstOrDefault<ControlOutput>();
		}

		// Token: 0x040001FF RID: 511
		internal readonly Func<Flow, ControlOutput> action;

		// Token: 0x04000200 RID: 512
		internal readonly Func<Flow, IEnumerator> coroutineAction;
	}
}
